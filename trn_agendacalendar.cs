using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_agendacalendar : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel3"+"_"+"LOCATIONID") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX3ASALOCATIONID1358( Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Trn_Agenda Calendar", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_agendacalendar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_agendacalendar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkAgendaCalendarAllDay = new GXCheckbox();
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_agendacalendar_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void fix_multi_value_controls( )
      {
         A307AgendaCalendarAllDay = StringUtil.StrToBool( StringUtil.BoolToStr( A307AgendaCalendarAllDay));
         AssignAttri("", false, "A307AgendaCalendarAllDay", A307AgendaCalendarAllDay);
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Agenda Calendar", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgendaCalendarId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgendaCalendarId_Internalname, context.GetMessage( "Calendar Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgendaCalendarId_Internalname, A303AgendaCalendarId.ToString(), A303AgendaCalendarId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgendaCalendarId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAgendaCalendarId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgendaCalendarTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgendaCalendarTitle_Internalname, context.GetMessage( "Calendar Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAgendaCalendarTitle_Internalname, A304AgendaCalendarTitle, StringUtil.RTrim( context.localUtil.Format( A304AgendaCalendarTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgendaCalendarTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAgendaCalendarTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Title", "start", true, "", "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgendaCalendarStartDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgendaCalendarStartDate_Internalname, context.GetMessage( "Start Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAgendaCalendarStartDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAgendaCalendarStartDate_Internalname, context.localUtil.TToC( A305AgendaCalendarStartDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A305AgendaCalendarStartDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgendaCalendarStartDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAgendaCalendarStartDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_bitmap( context, edtAgendaCalendarStartDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAgendaCalendarStartDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_AgendaCalendar.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAgendaCalendarEndDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAgendaCalendarEndDate_Internalname, context.GetMessage( "End Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAgendaCalendarEndDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAgendaCalendarEndDate_Internalname, context.localUtil.TToC( A306AgendaCalendarEndDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A306AgendaCalendarEndDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAgendaCalendarEndDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAgendaCalendarEndDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_bitmap( context, edtAgendaCalendarEndDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAgendaCalendarEndDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_AgendaCalendar.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkAgendaCalendarAllDay_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkAgendaCalendarAllDay_Internalname, context.GetMessage( "All Day", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkAgendaCalendarAllDay_Internalname, StringUtil.BoolToStr( A307AgendaCalendarAllDay), "", context.GetMessage( "All Day", ""), 1, chkAgendaCalendarAllDay.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(54, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,54);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AgendaCalendar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z303AgendaCalendarId = StringUtil.StrToGuid( cgiGet( "Z303AgendaCalendarId"));
            Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
            Z304AgendaCalendarTitle = cgiGet( "Z304AgendaCalendarTitle");
            Z305AgendaCalendarStartDate = context.localUtil.CToT( cgiGet( "Z305AgendaCalendarStartDate"), 0);
            Z306AgendaCalendarEndDate = context.localUtil.CToT( cgiGet( "Z306AgendaCalendarEndDate"), 0);
            Z307AgendaCalendarAllDay = StringUtil.StrToBool( cgiGet( "Z307AgendaCalendarAllDay"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtAgendaCalendarId_Internalname), "") == 0 )
            {
               A303AgendaCalendarId = Guid.Empty;
               AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
            }
            else
            {
               try
               {
                  A303AgendaCalendarId = StringUtil.StrToGuid( cgiGet( edtAgendaCalendarId_Internalname));
                  AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "AGENDACALENDARID");
                  AnyError = 1;
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A304AgendaCalendarTitle = cgiGet( edtAgendaCalendarTitle_Internalname);
            AssignAttri("", false, "A304AgendaCalendarTitle", A304AgendaCalendarTitle);
            if ( context.localUtil.VCDateTime( cgiGet( edtAgendaCalendarStartDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Agenda Calendar Start Date", "")}), 1, "AGENDACALENDARSTARTDATE");
               AnyError = 1;
               GX_FocusControl = edtAgendaCalendarStartDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A305AgendaCalendarStartDate", context.localUtil.TToC( A305AgendaCalendarStartDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A305AgendaCalendarStartDate = context.localUtil.CToT( cgiGet( edtAgendaCalendarStartDate_Internalname));
               AssignAttri("", false, "A305AgendaCalendarStartDate", context.localUtil.TToC( A305AgendaCalendarStartDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtAgendaCalendarEndDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Agenda Calendar End Date", "")}), 1, "AGENDACALENDARENDDATE");
               AnyError = 1;
               GX_FocusControl = edtAgendaCalendarEndDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A306AgendaCalendarEndDate", context.localUtil.TToC( A306AgendaCalendarEndDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A306AgendaCalendarEndDate = context.localUtil.CToT( cgiGet( edtAgendaCalendarEndDate_Internalname));
               AssignAttri("", false, "A306AgendaCalendarEndDate", context.localUtil.TToC( A306AgendaCalendarEndDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            A307AgendaCalendarAllDay = StringUtil.StrToBool( cgiGet( chkAgendaCalendarAllDay_Internalname));
            AssignAttri("", false, "A307AgendaCalendarAllDay", A307AgendaCalendarAllDay);
            if ( StringUtil.StrCmp(cgiGet( edtLocationId_Internalname), "") == 0 )
            {
               A29LocationId = Guid.Empty;
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            }
            else
            {
               try
               {
                  A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "LOCATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A303AgendaCalendarId = StringUtil.StrToGuid( GetPar( "AgendaCalendarId"));
               AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A303AgendaCalendarId) && ( Gx_BScreen == 0 ) )
               {
                  A303AgendaCalendarId = Guid.NewGuid( );
                  AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
               }
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               getEqualNoModal( ) ;
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1358( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1358( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption130( )
      {
      }

      protected void ZM1358( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z29LocationId = T00133_A29LocationId[0];
               Z304AgendaCalendarTitle = T00133_A304AgendaCalendarTitle[0];
               Z305AgendaCalendarStartDate = T00133_A305AgendaCalendarStartDate[0];
               Z306AgendaCalendarEndDate = T00133_A306AgendaCalendarEndDate[0];
               Z307AgendaCalendarAllDay = T00133_A307AgendaCalendarAllDay[0];
            }
            else
            {
               Z29LocationId = A29LocationId;
               Z304AgendaCalendarTitle = A304AgendaCalendarTitle;
               Z305AgendaCalendarStartDate = A305AgendaCalendarStartDate;
               Z306AgendaCalendarEndDate = A306AgendaCalendarEndDate;
               Z307AgendaCalendarAllDay = A307AgendaCalendarAllDay;
            }
         }
         if ( GX_JID == -5 )
         {
            Z303AgendaCalendarId = A303AgendaCalendarId;
            Z29LocationId = A29LocationId;
            Z304AgendaCalendarTitle = A304AgendaCalendarTitle;
            Z305AgendaCalendarStartDate = A305AgendaCalendarStartDate;
            Z306AgendaCalendarEndDate = A306AgendaCalendarEndDate;
            Z307AgendaCalendarAllDay = A307AgendaCalendarAllDay;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         GXt_guid1 = A29LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         A29LocationId = GXt_guid1;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         if ( IsIns( )  && (Guid.Empty==A303AgendaCalendarId) && ( Gx_BScreen == 0 ) )
         {
            A303AgendaCalendarId = Guid.NewGuid( );
            AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1358( )
      {
         /* Using cursor T00134 */
         pr_default.execute(2, new Object[] {A303AgendaCalendarId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound58 = 1;
            A29LocationId = T00134_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A304AgendaCalendarTitle = T00134_A304AgendaCalendarTitle[0];
            AssignAttri("", false, "A304AgendaCalendarTitle", A304AgendaCalendarTitle);
            A305AgendaCalendarStartDate = T00134_A305AgendaCalendarStartDate[0];
            AssignAttri("", false, "A305AgendaCalendarStartDate", context.localUtil.TToC( A305AgendaCalendarStartDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A306AgendaCalendarEndDate = T00134_A306AgendaCalendarEndDate[0];
            AssignAttri("", false, "A306AgendaCalendarEndDate", context.localUtil.TToC( A306AgendaCalendarEndDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A307AgendaCalendarAllDay = T00134_A307AgendaCalendarAllDay[0];
            AssignAttri("", false, "A307AgendaCalendarAllDay", A307AgendaCalendarAllDay);
            ZM1358( -5) ;
         }
         pr_default.close(2);
         OnLoadActions1358( ) ;
      }

      protected void OnLoadActions1358( )
      {
      }

      protected void CheckExtendedTable1358( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1358( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1358( )
      {
         /* Using cursor T00135 */
         pr_default.execute(3, new Object[] {A303AgendaCalendarId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound58 = 1;
         }
         else
         {
            RcdFound58 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00133 */
         pr_default.execute(1, new Object[] {A303AgendaCalendarId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1358( 5) ;
            RcdFound58 = 1;
            A303AgendaCalendarId = T00133_A303AgendaCalendarId[0];
            AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
            A29LocationId = T00133_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A304AgendaCalendarTitle = T00133_A304AgendaCalendarTitle[0];
            AssignAttri("", false, "A304AgendaCalendarTitle", A304AgendaCalendarTitle);
            A305AgendaCalendarStartDate = T00133_A305AgendaCalendarStartDate[0];
            AssignAttri("", false, "A305AgendaCalendarStartDate", context.localUtil.TToC( A305AgendaCalendarStartDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A306AgendaCalendarEndDate = T00133_A306AgendaCalendarEndDate[0];
            AssignAttri("", false, "A306AgendaCalendarEndDate", context.localUtil.TToC( A306AgendaCalendarEndDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A307AgendaCalendarAllDay = T00133_A307AgendaCalendarAllDay[0];
            AssignAttri("", false, "A307AgendaCalendarAllDay", A307AgendaCalendarAllDay);
            Z303AgendaCalendarId = A303AgendaCalendarId;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1358( ) ;
            if ( AnyError == 1 )
            {
               RcdFound58 = 0;
               InitializeNonKey1358( ) ;
            }
            Gx_mode = sMode58;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound58 = 0;
            InitializeNonKey1358( ) ;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode58;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1358( ) ;
         if ( RcdFound58 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound58 = 0;
         /* Using cursor T00136 */
         pr_default.execute(4, new Object[] {A303AgendaCalendarId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T00136_A303AgendaCalendarId[0], A303AgendaCalendarId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T00136_A303AgendaCalendarId[0], A303AgendaCalendarId, 0) > 0 ) ) )
            {
               A303AgendaCalendarId = T00136_A303AgendaCalendarId[0];
               AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
               RcdFound58 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound58 = 0;
         /* Using cursor T00137 */
         pr_default.execute(5, new Object[] {A303AgendaCalendarId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T00137_A303AgendaCalendarId[0], A303AgendaCalendarId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T00137_A303AgendaCalendarId[0], A303AgendaCalendarId, 0) < 0 ) ) )
            {
               A303AgendaCalendarId = T00137_A303AgendaCalendarId[0];
               AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
               RcdFound58 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1358( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1358( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound58 == 1 )
            {
               if ( A303AgendaCalendarId != Z303AgendaCalendarId )
               {
                  A303AgendaCalendarId = Z303AgendaCalendarId;
                  AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AGENDACALENDARID");
                  AnyError = 1;
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1358( ) ;
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A303AgendaCalendarId != Z303AgendaCalendarId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAgendaCalendarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1358( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AGENDACALENDARID");
                     AnyError = 1;
                     GX_FocusControl = edtAgendaCalendarId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAgendaCalendarId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1358( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A303AgendaCalendarId != Z303AgendaCalendarId )
         {
            A303AgendaCalendarId = Z303AgendaCalendarId;
            AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AGENDACALENDARID");
            AnyError = 1;
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "AGENDACALENDARID");
            AnyError = 1;
            GX_FocusControl = edtAgendaCalendarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAgendaCalendarTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1358( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAgendaCalendarTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1358( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAgendaCalendarTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAgendaCalendarTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1358( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound58 != 0 )
            {
               ScanNext1358( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAgendaCalendarTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1358( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1358( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00132 */
            pr_default.execute(0, new Object[] {A303AgendaCalendarId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaCalendar"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z29LocationId != T00132_A29LocationId[0] ) || ( StringUtil.StrCmp(Z304AgendaCalendarTitle, T00132_A304AgendaCalendarTitle[0]) != 0 ) || ( Z305AgendaCalendarStartDate != T00132_A305AgendaCalendarStartDate[0] ) || ( Z306AgendaCalendarEndDate != T00132_A306AgendaCalendarEndDate[0] ) || ( Z307AgendaCalendarAllDay != T00132_A307AgendaCalendarAllDay[0] ) )
            {
               if ( Z29LocationId != T00132_A29LocationId[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z29LocationId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A29LocationId[0]);
               }
               if ( StringUtil.StrCmp(Z304AgendaCalendarTitle, T00132_A304AgendaCalendarTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarTitle");
                  GXUtil.WriteLogRaw("Old: ",Z304AgendaCalendarTitle);
                  GXUtil.WriteLogRaw("Current: ",T00132_A304AgendaCalendarTitle[0]);
               }
               if ( Z305AgendaCalendarStartDate != T00132_A305AgendaCalendarStartDate[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarStartDate");
                  GXUtil.WriteLogRaw("Old: ",Z305AgendaCalendarStartDate);
                  GXUtil.WriteLogRaw("Current: ",T00132_A305AgendaCalendarStartDate[0]);
               }
               if ( Z306AgendaCalendarEndDate != T00132_A306AgendaCalendarEndDate[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarEndDate");
                  GXUtil.WriteLogRaw("Old: ",Z306AgendaCalendarEndDate);
                  GXUtil.WriteLogRaw("Current: ",T00132_A306AgendaCalendarEndDate[0]);
               }
               if ( Z307AgendaCalendarAllDay != T00132_A307AgendaCalendarAllDay[0] )
               {
                  GXUtil.WriteLog("trn_agendacalendar:[seudo value changed for attri]"+"AgendaCalendarAllDay");
                  GXUtil.WriteLogRaw("Old: ",Z307AgendaCalendarAllDay);
                  GXUtil.WriteLogRaw("Current: ",T00132_A307AgendaCalendarAllDay[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AgendaCalendar"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1358( )
      {
         if ( ! IsAuthorized("trn_agendacalendar_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1358( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1358( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1358( 0) ;
            CheckOptimisticConcurrency1358( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1358( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1358( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00138 */
                     pr_default.execute(6, new Object[] {A303AgendaCalendarId, A29LocationId, A304AgendaCalendarTitle, A305AgendaCalendarStartDate, A306AgendaCalendarEndDate, A307AgendaCalendarAllDay});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption130( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1358( ) ;
            }
            EndLevel1358( ) ;
         }
         CloseExtendedTableCursors1358( ) ;
      }

      protected void Update1358( )
      {
         if ( ! IsAuthorized("trn_agendacalendar_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1358( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1358( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1358( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1358( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1358( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00139 */
                     pr_default.execute(7, new Object[] {A29LocationId, A304AgendaCalendarTitle, A305AgendaCalendarStartDate, A306AgendaCalendarEndDate, A307AgendaCalendarAllDay, A303AgendaCalendarId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AgendaCalendar"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1358( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption130( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1358( ) ;
         }
         CloseExtendedTableCursors1358( ) ;
      }

      protected void DeferredUpdate1358( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_agendacalendar_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1358( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1358( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1358( ) ;
            AfterConfirm1358( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1358( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001310 */
                  pr_default.execute(8, new Object[] {A303AgendaCalendarId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AgendaCalendar");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound58 == 0 )
                        {
                           InitAll1358( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption130( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode58 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1358( ) ;
         Gx_mode = sMode58;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1358( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1358( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1358( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_agendacalendar",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues130( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_agendacalendar",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1358( )
      {
         /* Using cursor T001311 */
         pr_default.execute(9);
         RcdFound58 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound58 = 1;
            A303AgendaCalendarId = T001311_A303AgendaCalendarId[0];
            AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1358( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound58 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound58 = 1;
            A303AgendaCalendarId = T001311_A303AgendaCalendarId[0];
            AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
         }
      }

      protected void ScanEnd1358( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1358( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1358( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1358( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1358( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1358( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1358( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1358( )
      {
         edtAgendaCalendarId_Enabled = 0;
         AssignProp("", false, edtAgendaCalendarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgendaCalendarId_Enabled), 5, 0), true);
         edtAgendaCalendarTitle_Enabled = 0;
         AssignProp("", false, edtAgendaCalendarTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgendaCalendarTitle_Enabled), 5, 0), true);
         edtAgendaCalendarStartDate_Enabled = 0;
         AssignProp("", false, edtAgendaCalendarStartDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgendaCalendarStartDate_Enabled), 5, 0), true);
         edtAgendaCalendarEndDate_Enabled = 0;
         AssignProp("", false, edtAgendaCalendarEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAgendaCalendarEndDate_Enabled), 5, 0), true);
         chkAgendaCalendarAllDay.Enabled = 0;
         AssignProp("", false, chkAgendaCalendarAllDay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkAgendaCalendarAllDay.Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1358( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues130( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1918140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_agendacalendar.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z303AgendaCalendarId", Z303AgendaCalendarId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z304AgendaCalendarTitle", Z304AgendaCalendarTitle);
         GxWebStd.gx_hidden_field( context, "Z305AgendaCalendarStartDate", context.localUtil.TToC( Z305AgendaCalendarStartDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z306AgendaCalendarEndDate", context.localUtil.TToC( Z306AgendaCalendarEndDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z307AgendaCalendarAllDay", Z307AgendaCalendarAllDay);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("trn_agendacalendar.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_AgendaCalendar" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Agenda Calendar", "") ;
      }

      protected void InitializeNonKey1358( )
      {
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A304AgendaCalendarTitle = "";
         AssignAttri("", false, "A304AgendaCalendarTitle", A304AgendaCalendarTitle);
         A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A305AgendaCalendarStartDate", context.localUtil.TToC( A305AgendaCalendarStartDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A306AgendaCalendarEndDate", context.localUtil.TToC( A306AgendaCalendarEndDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A307AgendaCalendarAllDay = false;
         AssignAttri("", false, "A307AgendaCalendarAllDay", A307AgendaCalendarAllDay);
         Z29LocationId = Guid.Empty;
         Z304AgendaCalendarTitle = "";
         Z305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         Z306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         Z307AgendaCalendarAllDay = false;
      }

      protected void InitAll1358( )
      {
         A303AgendaCalendarId = Guid.NewGuid( );
         AssignAttri("", false, "A303AgendaCalendarId", A303AgendaCalendarId.ToString());
         InitializeNonKey1358( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A29LocationId = i29LocationId;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024101016432721", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("trn_agendacalendar.js", "?2024101016432721", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtAgendaCalendarId_Internalname = "AGENDACALENDARID";
         edtAgendaCalendarTitle_Internalname = "AGENDACALENDARTITLE";
         edtAgendaCalendarStartDate_Internalname = "AGENDACALENDARSTARTDATE";
         edtAgendaCalendarEndDate_Internalname = "AGENDACALENDARENDDATE";
         chkAgendaCalendarAllDay_Internalname = "AGENDACALENDARALLDAY";
         edtLocationId_Internalname = "LOCATIONID";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_Agenda Calendar", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
         chkAgendaCalendarAllDay.Enabled = 1;
         edtAgendaCalendarEndDate_Jsonclick = "";
         edtAgendaCalendarEndDate_Enabled = 1;
         edtAgendaCalendarStartDate_Jsonclick = "";
         edtAgendaCalendarStartDate_Enabled = 1;
         edtAgendaCalendarTitle_Jsonclick = "";
         edtAgendaCalendarTitle_Enabled = 1;
         edtAgendaCalendarId_Jsonclick = "";
         edtAgendaCalendarId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX3ASALOCATIONID1358( string Gx_mode )
      {
         GXt_guid1 = A29LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         A29LocationId = GXt_guid1;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A29LocationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         chkAgendaCalendarAllDay.Name = "AGENDACALENDARALLDAY";
         chkAgendaCalendarAllDay.WebTags = "";
         chkAgendaCalendarAllDay.Caption = context.GetMessage( "All Day", "");
         AssignProp("", false, chkAgendaCalendarAllDay_Internalname, "TitleCaption", chkAgendaCalendarAllDay.Caption, true);
         chkAgendaCalendarAllDay.CheckedValue = "false";
         A307AgendaCalendarAllDay = StringUtil.StrToBool( StringUtil.BoolToStr( A307AgendaCalendarAllDay));
         AssignAttri("", false, "A307AgendaCalendarAllDay", A307AgendaCalendarAllDay);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAgendaCalendarTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Agendacalendarid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A307AgendaCalendarAllDay = StringUtil.StrToBool( StringUtil.BoolToStr( A307AgendaCalendarAllDay));
         /*  Sending validation outputs */
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         AssignAttri("", false, "A304AgendaCalendarTitle", A304AgendaCalendarTitle);
         AssignAttri("", false, "A305AgendaCalendarStartDate", context.localUtil.TToC( A305AgendaCalendarStartDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A306AgendaCalendarEndDate", context.localUtil.TToC( A306AgendaCalendarEndDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A307AgendaCalendarAllDay", A307AgendaCalendarAllDay);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z303AgendaCalendarId", Z303AgendaCalendarId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z304AgendaCalendarTitle", Z304AgendaCalendarTitle);
         GxWebStd.gx_hidden_field( context, "Z305AgendaCalendarStartDate", context.localUtil.TToC( Z305AgendaCalendarStartDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z306AgendaCalendarEndDate", context.localUtil.TToC( Z306AgendaCalendarEndDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z307AgendaCalendarAllDay", StringUtil.BoolToStr( Z307AgendaCalendarAllDay));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A307AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A307AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A307AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A307AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"}]}""");
         setEventMetadata("VALID_AGENDACALENDARID","""{"handler":"Valid_Agendacalendarid","iparms":[{"av":"A303AgendaCalendarId","fld":"AGENDACALENDARID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A307AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"}]""");
         setEventMetadata("VALID_AGENDACALENDARID",""","oparms":[{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A304AgendaCalendarTitle","fld":"AGENDACALENDARTITLE"},{"av":"A305AgendaCalendarStartDate","fld":"AGENDACALENDARSTARTDATE","pic":"99/99/99 99:99"},{"av":"A306AgendaCalendarEndDate","fld":"AGENDACALENDARENDDATE","pic":"99/99/99 99:99"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z303AgendaCalendarId"},{"av":"Z29LocationId"},{"av":"Z304AgendaCalendarTitle"},{"av":"Z305AgendaCalendarStartDate"},{"av":"Z306AgendaCalendarEndDate"},{"av":"Z307AgendaCalendarAllDay"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A307AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"A307AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"A307AgendaCalendarAllDay","fld":"AGENDACALENDARALLDAY"}]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z303AgendaCalendarId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z304AgendaCalendarTitle = "";
         Z305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         Z306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_mode = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A303AgendaCalendarId = Guid.Empty;
         A304AgendaCalendarTitle = "";
         A305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A29LocationId = Guid.Empty;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00134_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T00134_A29LocationId = new Guid[] {Guid.Empty} ;
         T00134_A304AgendaCalendarTitle = new string[] {""} ;
         T00134_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         T00134_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         T00134_A307AgendaCalendarAllDay = new bool[] {false} ;
         T00135_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T00133_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T00133_A29LocationId = new Guid[] {Guid.Empty} ;
         T00133_A304AgendaCalendarTitle = new string[] {""} ;
         T00133_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         T00133_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         T00133_A307AgendaCalendarAllDay = new bool[] {false} ;
         sMode58 = "";
         T00136_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T00137_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T00132_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         T00132_A29LocationId = new Guid[] {Guid.Empty} ;
         T00132_A304AgendaCalendarTitle = new string[] {""} ;
         T00132_A305AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         T00132_A306AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         T00132_A307AgendaCalendarAllDay = new bool[] {false} ;
         T001311_A303AgendaCalendarId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i29LocationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         ZZ303AgendaCalendarId = Guid.Empty;
         ZZ29LocationId = Guid.Empty;
         ZZ304AgendaCalendarTitle = "";
         ZZ305AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         ZZ306AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_agendacalendar__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_agendacalendar__default(),
            new Object[][] {
                new Object[] {
               T00132_A303AgendaCalendarId, T00132_A29LocationId, T00132_A304AgendaCalendarTitle, T00132_A305AgendaCalendarStartDate, T00132_A306AgendaCalendarEndDate, T00132_A307AgendaCalendarAllDay
               }
               , new Object[] {
               T00133_A303AgendaCalendarId, T00133_A29LocationId, T00133_A304AgendaCalendarTitle, T00133_A305AgendaCalendarStartDate, T00133_A306AgendaCalendarEndDate, T00133_A307AgendaCalendarAllDay
               }
               , new Object[] {
               T00134_A303AgendaCalendarId, T00134_A29LocationId, T00134_A304AgendaCalendarTitle, T00134_A305AgendaCalendarStartDate, T00134_A306AgendaCalendarEndDate, T00134_A307AgendaCalendarAllDay
               }
               , new Object[] {
               T00135_A303AgendaCalendarId
               }
               , new Object[] {
               T00136_A303AgendaCalendarId
               }
               , new Object[] {
               T00137_A303AgendaCalendarId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001311_A303AgendaCalendarId
               }
            }
         );
         Z303AgendaCalendarId = Guid.NewGuid( );
         A303AgendaCalendarId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound58 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAgendaCalendarId_Enabled ;
      private int edtAgendaCalendarTitle_Enabled ;
      private int edtAgendaCalendarStartDate_Enabled ;
      private int edtAgendaCalendarEndDate_Enabled ;
      private int edtLocationId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAgendaCalendarId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtAgendaCalendarId_Jsonclick ;
      private string edtAgendaCalendarTitle_Internalname ;
      private string edtAgendaCalendarTitle_Jsonclick ;
      private string edtAgendaCalendarStartDate_Internalname ;
      private string edtAgendaCalendarStartDate_Jsonclick ;
      private string edtAgendaCalendarEndDate_Internalname ;
      private string edtAgendaCalendarEndDate_Jsonclick ;
      private string chkAgendaCalendarAllDay_Internalname ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode58 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z305AgendaCalendarStartDate ;
      private DateTime Z306AgendaCalendarEndDate ;
      private DateTime A305AgendaCalendarStartDate ;
      private DateTime A306AgendaCalendarEndDate ;
      private DateTime ZZ305AgendaCalendarStartDate ;
      private DateTime ZZ306AgendaCalendarEndDate ;
      private bool Z307AgendaCalendarAllDay ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A307AgendaCalendarAllDay ;
      private bool ZZ307AgendaCalendarAllDay ;
      private string Z304AgendaCalendarTitle ;
      private string A304AgendaCalendarTitle ;
      private string ZZ304AgendaCalendarTitle ;
      private Guid Z303AgendaCalendarId ;
      private Guid Z29LocationId ;
      private Guid A303AgendaCalendarId ;
      private Guid A29LocationId ;
      private Guid i29LocationId ;
      private Guid GXt_guid1 ;
      private Guid ZZ303AgendaCalendarId ;
      private Guid ZZ29LocationId ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkAgendaCalendarAllDay ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00134_A303AgendaCalendarId ;
      private Guid[] T00134_A29LocationId ;
      private string[] T00134_A304AgendaCalendarTitle ;
      private DateTime[] T00134_A305AgendaCalendarStartDate ;
      private DateTime[] T00134_A306AgendaCalendarEndDate ;
      private bool[] T00134_A307AgendaCalendarAllDay ;
      private Guid[] T00135_A303AgendaCalendarId ;
      private Guid[] T00133_A303AgendaCalendarId ;
      private Guid[] T00133_A29LocationId ;
      private string[] T00133_A304AgendaCalendarTitle ;
      private DateTime[] T00133_A305AgendaCalendarStartDate ;
      private DateTime[] T00133_A306AgendaCalendarEndDate ;
      private bool[] T00133_A307AgendaCalendarAllDay ;
      private Guid[] T00136_A303AgendaCalendarId ;
      private Guid[] T00137_A303AgendaCalendarId ;
      private Guid[] T00132_A303AgendaCalendarId ;
      private Guid[] T00132_A29LocationId ;
      private string[] T00132_A304AgendaCalendarTitle ;
      private DateTime[] T00132_A305AgendaCalendarStartDate ;
      private DateTime[] T00132_A306AgendaCalendarEndDate ;
      private bool[] T00132_A307AgendaCalendarAllDay ;
      private Guid[] T001311_A303AgendaCalendarId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_agendacalendar__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class trn_agendacalendar__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00132;
        prmT00132 = new Object[] {
        new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00133;
        prmT00133 = new Object[] {
        new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00134;
        prmT00134 = new Object[] {
        new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00135;
        prmT00135 = new Object[] {
        new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00136;
        prmT00136 = new Object[] {
        new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00137;
        prmT00137 = new Object[] {
        new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00138;
        prmT00138 = new Object[] {
        new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AgendaCalendarTitle",GXType.VarChar,100,0) ,
        new ParDef("AgendaCalendarStartDate",GXType.DateTime,8,5) ,
        new ParDef("AgendaCalendarEndDate",GXType.DateTime,8,5) ,
        new ParDef("AgendaCalendarAllDay",GXType.Boolean,4,0)
        };
        Object[] prmT00139;
        prmT00139 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AgendaCalendarTitle",GXType.VarChar,100,0) ,
        new ParDef("AgendaCalendarStartDate",GXType.DateTime,8,5) ,
        new ParDef("AgendaCalendarEndDate",GXType.DateTime,8,5) ,
        new ParDef("AgendaCalendarAllDay",GXType.Boolean,4,0) ,
        new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001310;
        prmT001310 = new Object[] {
        new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001311;
        prmT001311 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00132", "SELECT AgendaCalendarId, LocationId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarAllDay FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId  FOR UPDATE OF Trn_AgendaCalendar NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00132,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00133", "SELECT AgendaCalendarId, LocationId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarAllDay FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00133,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00134", "SELECT TM1.AgendaCalendarId, TM1.LocationId, TM1.AgendaCalendarTitle, TM1.AgendaCalendarStartDate, TM1.AgendaCalendarEndDate, TM1.AgendaCalendarAllDay FROM Trn_AgendaCalendar TM1 WHERE TM1.AgendaCalendarId = :AgendaCalendarId ORDER BY TM1.AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00134,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00135", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE AgendaCalendarId = :AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00135,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00136", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE ( AgendaCalendarId > :AgendaCalendarId) ORDER BY AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00136,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00137", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE ( AgendaCalendarId < :AgendaCalendarId) ORDER BY AgendaCalendarId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00137,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00138", "SAVEPOINT gxupdate;INSERT INTO Trn_AgendaCalendar(AgendaCalendarId, LocationId, AgendaCalendarTitle, AgendaCalendarStartDate, AgendaCalendarEndDate, AgendaCalendarAllDay) VALUES(:AgendaCalendarId, :LocationId, :AgendaCalendarTitle, :AgendaCalendarStartDate, :AgendaCalendarEndDate, :AgendaCalendarAllDay);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT00138)
           ,new CursorDef("T00139", "SAVEPOINT gxupdate;UPDATE Trn_AgendaCalendar SET LocationId=:LocationId, AgendaCalendarTitle=:AgendaCalendarTitle, AgendaCalendarStartDate=:AgendaCalendarStartDate, AgendaCalendarEndDate=:AgendaCalendarEndDate, AgendaCalendarAllDay=:AgendaCalendarAllDay  WHERE AgendaCalendarId = :AgendaCalendarId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT00139)
           ,new CursorDef("T001310", "SAVEPOINT gxupdate;DELETE FROM Trn_AgendaCalendar  WHERE AgendaCalendarId = :AgendaCalendarId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001310)
           ,new CursorDef("T001311", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar ORDER BY AgendaCalendarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001311,100, GxCacheFrequency.OFF ,true,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
