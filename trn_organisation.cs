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
   public class trn_organisation : GXDataArea
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
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A19OrganisationTypeId = StringUtil.StrToGuid( GetPar( "OrganisationTypeId"));
            AssignAttri("", false, "A19OrganisationTypeId", A19OrganisationTypeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A19OrganisationTypeId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            GxWebError = 1;
            context.HttpContext.Response.StatusCode = 403;
            context.WriteHtmlText( "<title>403 Forbidden</title>") ;
            context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
            context.WriteHtmlText( "<p /><hr />") ;
            GXUtil.WriteLog("send_http_error_code " + 403.ToString());
         }
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_organisation.aspx")), "trn_organisation.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_organisation.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "AV7OrganisationId", AV7OrganisationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV7OrganisationId, context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
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
         Form.Meta.addItem("description", "Organisations", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtOrganisationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_organisation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_OrganisationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7OrganisationId = aP1_OrganisationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
            return "trn_organisation_Execute" ;
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationName_Internalname, "Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationName_Internalname, A13OrganisationName, StringUtil.RTrim( context.localUtil.Format( A13OrganisationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationKvkNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationKvkNumber_Internalname, "KVK Number", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationKvkNumber_Internalname, A12OrganisationKvkNumber, StringUtil.RTrim( context.localUtil.Format( A12OrganisationKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationKvkNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationKvkNumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationEmail_Internalname, "Email", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationEmail_Internalname, A16OrganisationEmail, StringUtil.RTrim( context.localUtil.Format( A16OrganisationEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A16OrganisationEmail, "", "", "", edtOrganisationEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationPhone_Internalname, "Phone", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A17OrganisationPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationPhone_Internalname, StringUtil.RTrim( A17OrganisationPhone), StringUtil.RTrim( context.localUtil.Format( A17OrganisationPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtOrganisationPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedorganisationtypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockorganisationtypeid_Internalname, "Organisation Type", "", "", lblTextblockorganisationtypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_organisationtypeid.SetProperty("Caption", Combo_organisationtypeid_Caption);
         ucCombo_organisationtypeid.SetProperty("Cls", Combo_organisationtypeid_Cls);
         ucCombo_organisationtypeid.SetProperty("DataListProc", Combo_organisationtypeid_Datalistproc);
         ucCombo_organisationtypeid.SetProperty("DataListProcParametersPrefix", Combo_organisationtypeid_Datalistprocparametersprefix);
         ucCombo_organisationtypeid.SetProperty("EmptyItem", Combo_organisationtypeid_Emptyitem);
         ucCombo_organisationtypeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_organisationtypeid.SetProperty("DropDownOptionsData", AV15OrganisationTypeId_Data);
         ucCombo_organisationtypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationtypeid_Internalname, "COMBO_ORGANISATIONTYPEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationTypeId_Internalname, "Organisation Type Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationTypeId_Internalname, A19OrganisationTypeId.ToString(), A19OrganisationTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationTypeId_Visible, edtOrganisationTypeId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationVATNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationVATNumber_Internalname, "VAT Number", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationVATNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18OrganisationVATNumber), 8, 0, ".", "")), StringUtil.LTrim( ((edtOrganisationVATNumber_Enabled!=0) ? context.localUtil.Format( (decimal)(A18OrganisationVATNumber), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A18OrganisationVATNumber), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationVATNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationVATNumber_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedorganisationaddresscountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockorganisationaddresscountry_Internalname, "Country", "", "", lblTextblockorganisationaddresscountry_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_organisationaddresscountry.SetProperty("Caption", Combo_organisationaddresscountry_Caption);
         ucCombo_organisationaddresscountry.SetProperty("Cls", Combo_organisationaddresscountry_Cls);
         ucCombo_organisationaddresscountry.SetProperty("EmptyItem", Combo_organisationaddresscountry_Emptyitem);
         ucCombo_organisationaddresscountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_organisationaddresscountry.SetProperty("DropDownOptionsData", AV25OrganisationAddressCountry_Data);
         ucCombo_organisationaddresscountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationaddresscountry_Internalname, "COMBO_ORGANISATIONADDRESSCOUNTRYContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationAddressCountry_Internalname, "Organisation Address Country", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationAddressCountry_Internalname, A331OrganisationAddressCountry, StringUtil.RTrim( context.localUtil.Format( A331OrganisationAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationAddressCountry_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationAddressCountry_Visible, edtOrganisationAddressCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationAddressCity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationAddressCity_Internalname, "City", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationAddressCity_Internalname, A289OrganisationAddressCity, StringUtil.RTrim( context.localUtil.Format( A289OrganisationAddressCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationAddressCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationAddressCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationAddressZipCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationAddressZipCode_Internalname, "Zip Code", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationAddressZipCode_Internalname, A288OrganisationAddressZipCode, StringUtil.RTrim( context.localUtil.Format( A288OrganisationAddressZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationAddressZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationAddressZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationAddressLine1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationAddressLine1_Internalname, "Address Line1", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationAddressLine1_Internalname, A342OrganisationAddressLine1, StringUtil.RTrim( context.localUtil.Format( A342OrganisationAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Street", edtOrganisationAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationAddressLine2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationAddressLine2_Internalname, "Address Line2", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationAddressLine2_Internalname, A343OrganisationAddressLine2, StringUtil.RTrim( context.localUtil.Format( A343OrganisationAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "House/Building", edtOrganisationAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Organisation.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_organisationtypeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboorganisationtypeid_Internalname, AV20ComboOrganisationTypeId.ToString(), AV20ComboOrganisationTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboorganisationtypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboorganisationtypeid_Visible, edtavComboorganisationtypeid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_organisationaddresscountry_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboorganisationaddresscountry_Internalname, AV26ComboOrganisationAddressCountry, StringUtil.RTrim( context.localUtil.Format( AV26ComboOrganisationAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboorganisationaddresscountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboorganisationaddresscountry_Visible, edtavComboorganisationaddresscountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Organisation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vORGANISATIONTYPEID_DATA"), AV15OrganisationTypeId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vORGANISATIONADDRESSCOUNTRY_DATA"), AV25OrganisationAddressCountry_Data);
               /* Read saved values. */
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z331OrganisationAddressCountry = cgiGet( "Z331OrganisationAddressCountry");
               Z13OrganisationName = cgiGet( "Z13OrganisationName");
               Z12OrganisationKvkNumber = cgiGet( "Z12OrganisationKvkNumber");
               Z16OrganisationEmail = cgiGet( "Z16OrganisationEmail");
               Z17OrganisationPhone = cgiGet( "Z17OrganisationPhone");
               Z18OrganisationVATNumber = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z18OrganisationVATNumber"), ".", ","), 18, MidpointRounding.ToEven));
               Z289OrganisationAddressCity = cgiGet( "Z289OrganisationAddressCity");
               Z288OrganisationAddressZipCode = cgiGet( "Z288OrganisationAddressZipCode");
               Z342OrganisationAddressLine1 = cgiGet( "Z342OrganisationAddressLine1");
               Z343OrganisationAddressLine2 = cgiGet( "Z343OrganisationAddressLine2");
               Z19OrganisationTypeId = StringUtil.StrToGuid( cgiGet( "Z19OrganisationTypeId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N19OrganisationTypeId = StringUtil.StrToGuid( cgiGet( "N19OrganisationTypeId"));
               AV7OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_OrganisationTypeId = StringUtil.StrToGuid( cgiGet( "vINSERT_ORGANISATIONTYPEID"));
               A20OrganisationTypeName = cgiGet( "ORGANISATIONTYPENAME");
               AV27Pgmname = cgiGet( "vPGMNAME");
               Combo_organisationtypeid_Objectcall = cgiGet( "COMBO_ORGANISATIONTYPEID_Objectcall");
               Combo_organisationtypeid_Class = cgiGet( "COMBO_ORGANISATIONTYPEID_Class");
               Combo_organisationtypeid_Icontype = cgiGet( "COMBO_ORGANISATIONTYPEID_Icontype");
               Combo_organisationtypeid_Icon = cgiGet( "COMBO_ORGANISATIONTYPEID_Icon");
               Combo_organisationtypeid_Caption = cgiGet( "COMBO_ORGANISATIONTYPEID_Caption");
               Combo_organisationtypeid_Tooltip = cgiGet( "COMBO_ORGANISATIONTYPEID_Tooltip");
               Combo_organisationtypeid_Cls = cgiGet( "COMBO_ORGANISATIONTYPEID_Cls");
               Combo_organisationtypeid_Selectedvalue_set = cgiGet( "COMBO_ORGANISATIONTYPEID_Selectedvalue_set");
               Combo_organisationtypeid_Selectedvalue_get = cgiGet( "COMBO_ORGANISATIONTYPEID_Selectedvalue_get");
               Combo_organisationtypeid_Selectedtext_set = cgiGet( "COMBO_ORGANISATIONTYPEID_Selectedtext_set");
               Combo_organisationtypeid_Selectedtext_get = cgiGet( "COMBO_ORGANISATIONTYPEID_Selectedtext_get");
               Combo_organisationtypeid_Gamoauthtoken = cgiGet( "COMBO_ORGANISATIONTYPEID_Gamoauthtoken");
               Combo_organisationtypeid_Ddointernalname = cgiGet( "COMBO_ORGANISATIONTYPEID_Ddointernalname");
               Combo_organisationtypeid_Titlecontrolalign = cgiGet( "COMBO_ORGANISATIONTYPEID_Titlecontrolalign");
               Combo_organisationtypeid_Dropdownoptionstype = cgiGet( "COMBO_ORGANISATIONTYPEID_Dropdownoptionstype");
               Combo_organisationtypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONTYPEID_Enabled"));
               Combo_organisationtypeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONTYPEID_Visible"));
               Combo_organisationtypeid_Titlecontrolidtoreplace = cgiGet( "COMBO_ORGANISATIONTYPEID_Titlecontrolidtoreplace");
               Combo_organisationtypeid_Datalisttype = cgiGet( "COMBO_ORGANISATIONTYPEID_Datalisttype");
               Combo_organisationtypeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONTYPEID_Allowmultipleselection"));
               Combo_organisationtypeid_Datalistfixedvalues = cgiGet( "COMBO_ORGANISATIONTYPEID_Datalistfixedvalues");
               Combo_organisationtypeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONTYPEID_Isgriditem"));
               Combo_organisationtypeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONTYPEID_Hasdescription"));
               Combo_organisationtypeid_Datalistproc = cgiGet( "COMBO_ORGANISATIONTYPEID_Datalistproc");
               Combo_organisationtypeid_Datalistprocparametersprefix = cgiGet( "COMBO_ORGANISATIONTYPEID_Datalistprocparametersprefix");
               Combo_organisationtypeid_Remoteservicesparameters = cgiGet( "COMBO_ORGANISATIONTYPEID_Remoteservicesparameters");
               Combo_organisationtypeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONTYPEID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_organisationtypeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONTYPEID_Includeonlyselectedoption"));
               Combo_organisationtypeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONTYPEID_Includeselectalloption"));
               Combo_organisationtypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONTYPEID_Emptyitem"));
               Combo_organisationtypeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONTYPEID_Includeaddnewoption"));
               Combo_organisationtypeid_Htmltemplate = cgiGet( "COMBO_ORGANISATIONTYPEID_Htmltemplate");
               Combo_organisationtypeid_Multiplevaluestype = cgiGet( "COMBO_ORGANISATIONTYPEID_Multiplevaluestype");
               Combo_organisationtypeid_Loadingdata = cgiGet( "COMBO_ORGANISATIONTYPEID_Loadingdata");
               Combo_organisationtypeid_Noresultsfound = cgiGet( "COMBO_ORGANISATIONTYPEID_Noresultsfound");
               Combo_organisationtypeid_Emptyitemtext = cgiGet( "COMBO_ORGANISATIONTYPEID_Emptyitemtext");
               Combo_organisationtypeid_Onlyselectedvalues = cgiGet( "COMBO_ORGANISATIONTYPEID_Onlyselectedvalues");
               Combo_organisationtypeid_Selectalltext = cgiGet( "COMBO_ORGANISATIONTYPEID_Selectalltext");
               Combo_organisationtypeid_Multiplevaluesseparator = cgiGet( "COMBO_ORGANISATIONTYPEID_Multiplevaluesseparator");
               Combo_organisationtypeid_Addnewoptiontext = cgiGet( "COMBO_ORGANISATIONTYPEID_Addnewoptiontext");
               Combo_organisationtypeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONTYPEID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_organisationaddresscountry_Objectcall = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Objectcall");
               Combo_organisationaddresscountry_Class = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Class");
               Combo_organisationaddresscountry_Icontype = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Icontype");
               Combo_organisationaddresscountry_Icon = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Icon");
               Combo_organisationaddresscountry_Caption = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Caption");
               Combo_organisationaddresscountry_Tooltip = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Tooltip");
               Combo_organisationaddresscountry_Cls = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Cls");
               Combo_organisationaddresscountry_Selectedvalue_set = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Selectedvalue_set");
               Combo_organisationaddresscountry_Selectedvalue_get = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Selectedvalue_get");
               Combo_organisationaddresscountry_Selectedtext_set = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Selectedtext_set");
               Combo_organisationaddresscountry_Selectedtext_get = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Selectedtext_get");
               Combo_organisationaddresscountry_Gamoauthtoken = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Gamoauthtoken");
               Combo_organisationaddresscountry_Ddointernalname = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Ddointernalname");
               Combo_organisationaddresscountry_Titlecontrolalign = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Titlecontrolalign");
               Combo_organisationaddresscountry_Dropdownoptionstype = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Dropdownoptionstype");
               Combo_organisationaddresscountry_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Enabled"));
               Combo_organisationaddresscountry_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Visible"));
               Combo_organisationaddresscountry_Titlecontrolidtoreplace = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Titlecontrolidtoreplace");
               Combo_organisationaddresscountry_Datalisttype = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Datalisttype");
               Combo_organisationaddresscountry_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Allowmultipleselection"));
               Combo_organisationaddresscountry_Datalistfixedvalues = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Datalistfixedvalues");
               Combo_organisationaddresscountry_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Isgriditem"));
               Combo_organisationaddresscountry_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Hasdescription"));
               Combo_organisationaddresscountry_Datalistproc = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Datalistproc");
               Combo_organisationaddresscountry_Datalistprocparametersprefix = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Datalistprocparametersprefix");
               Combo_organisationaddresscountry_Remoteservicesparameters = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Remoteservicesparameters");
               Combo_organisationaddresscountry_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_organisationaddresscountry_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Includeonlyselectedoption"));
               Combo_organisationaddresscountry_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Includeselectalloption"));
               Combo_organisationaddresscountry_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Emptyitem"));
               Combo_organisationaddresscountry_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Includeaddnewoption"));
               Combo_organisationaddresscountry_Htmltemplate = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Htmltemplate");
               Combo_organisationaddresscountry_Multiplevaluestype = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Multiplevaluestype");
               Combo_organisationaddresscountry_Loadingdata = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Loadingdata");
               Combo_organisationaddresscountry_Noresultsfound = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Noresultsfound");
               Combo_organisationaddresscountry_Emptyitemtext = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Emptyitemtext");
               Combo_organisationaddresscountry_Onlyselectedvalues = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Onlyselectedvalues");
               Combo_organisationaddresscountry_Selectalltext = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Selectalltext");
               Combo_organisationaddresscountry_Multiplevaluesseparator = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Multiplevaluesseparator");
               Combo_organisationaddresscountry_Addnewoptiontext = cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Addnewoptiontext");
               Combo_organisationaddresscountry_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONADDRESSCOUNTRY_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A13OrganisationName = cgiGet( edtOrganisationName_Internalname);
               AssignAttri("", false, "A13OrganisationName", A13OrganisationName);
               A12OrganisationKvkNumber = cgiGet( edtOrganisationKvkNumber_Internalname);
               AssignAttri("", false, "A12OrganisationKvkNumber", A12OrganisationKvkNumber);
               A16OrganisationEmail = cgiGet( edtOrganisationEmail_Internalname);
               AssignAttri("", false, "A16OrganisationEmail", A16OrganisationEmail);
               A17OrganisationPhone = cgiGet( edtOrganisationPhone_Internalname);
               AssignAttri("", false, "A17OrganisationPhone", A17OrganisationPhone);
               if ( StringUtil.StrCmp(cgiGet( edtOrganisationTypeId_Internalname), "") == 0 )
               {
                  A19OrganisationTypeId = Guid.Empty;
                  AssignAttri("", false, "A19OrganisationTypeId", A19OrganisationTypeId.ToString());
               }
               else
               {
                  try
                  {
                     A19OrganisationTypeId = StringUtil.StrToGuid( cgiGet( edtOrganisationTypeId_Internalname));
                     AssignAttri("", false, "A19OrganisationTypeId", A19OrganisationTypeId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ORGANISATIONTYPEID");
                     AnyError = 1;
                     GX_FocusControl = edtOrganisationTypeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtOrganisationVATNumber_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrganisationVATNumber_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORGANISATIONVATNUMBER");
                  AnyError = 1;
                  GX_FocusControl = edtOrganisationVATNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A18OrganisationVATNumber = 0;
                  AssignAttri("", false, "A18OrganisationVATNumber", StringUtil.LTrimStr( (decimal)(A18OrganisationVATNumber), 8, 0));
               }
               else
               {
                  A18OrganisationVATNumber = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOrganisationVATNumber_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A18OrganisationVATNumber", StringUtil.LTrimStr( (decimal)(A18OrganisationVATNumber), 8, 0));
               }
               A331OrganisationAddressCountry = cgiGet( edtOrganisationAddressCountry_Internalname);
               AssignAttri("", false, "A331OrganisationAddressCountry", A331OrganisationAddressCountry);
               A289OrganisationAddressCity = cgiGet( edtOrganisationAddressCity_Internalname);
               AssignAttri("", false, "A289OrganisationAddressCity", A289OrganisationAddressCity);
               A288OrganisationAddressZipCode = cgiGet( edtOrganisationAddressZipCode_Internalname);
               AssignAttri("", false, "A288OrganisationAddressZipCode", A288OrganisationAddressZipCode);
               A342OrganisationAddressLine1 = cgiGet( edtOrganisationAddressLine1_Internalname);
               AssignAttri("", false, "A342OrganisationAddressLine1", A342OrganisationAddressLine1);
               A343OrganisationAddressLine2 = cgiGet( edtOrganisationAddressLine2_Internalname);
               AssignAttri("", false, "A343OrganisationAddressLine2", A343OrganisationAddressLine2);
               AV20ComboOrganisationTypeId = StringUtil.StrToGuid( cgiGet( edtavComboorganisationtypeid_Internalname));
               AssignAttri("", false, "AV20ComboOrganisationTypeId", AV20ComboOrganisationTypeId.ToString());
               AV26ComboOrganisationAddressCountry = cgiGet( edtavComboorganisationaddresscountry_Internalname);
               AssignAttri("", false, "AV26ComboOrganisationAddressCountry", AV26ComboOrganisationAddressCountry);
               if ( StringUtil.StrCmp(cgiGet( edtOrganisationId_Internalname), "") == 0 )
               {
                  A11OrganisationId = Guid.Empty;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
               else
               {
                  try
                  {
                     A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                     AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ORGANISATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtOrganisationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Organisation");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A11OrganisationId != Z11OrganisationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_organisation:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7OrganisationId) )
                  {
                     A11OrganisationId = AV7OrganisationId;
                     AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A11OrganisationId) && ( Gx_BScreen == 0 ) )
                     {
                        A11OrganisationId = Guid.NewGuid( );
                        AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7OrganisationId) )
                     {
                        A11OrganisationId = AV7OrganisationId;
                        AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A11OrganisationId) && ( Gx_BScreen == 0 ) )
                        {
                           A11OrganisationId = Guid.NewGuid( );
                           AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                        }
                     }
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ORGANISATIONID");
                        AnyError = 1;
                        GX_FocusControl = edtOrganisationId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_ORGANISATIONTYPEID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_organisationtypeid.Onoptionclicked */
                           E12012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            /* Execute user event: After Trn */
            E13012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll013( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes013( ) ;
         }
         AssignProp("", false, edtavComboorganisationtypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationtypeid_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboorganisationaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationaddresscountry_Enabled), 5, 0), true);
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

      protected void CONFIRM_010( )
      {
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls013( ) ;
            }
            else
            {
               CheckExtendedTable013( ) ;
               CloseExtendedTableCursors013( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtOrganisationAddressCountry_Visible = 0;
         AssignProp("", false, edtOrganisationAddressCountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationAddressCountry_Visible), 5, 0), true);
         AV26ComboOrganisationAddressCountry = "";
         AssignAttri("", false, "AV26ComboOrganisationAddressCountry", AV26ComboOrganisationAddressCountry);
         edtavComboorganisationaddresscountry_Visible = 0;
         AssignProp("", false, edtavComboorganisationaddresscountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboorganisationaddresscountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_organisationaddresscountry_Htmltemplate = GXt_char2;
         ucCombo_organisationaddresscountry.SendProperty(context, "", false, Combo_organisationaddresscountry_Internalname, "HTMLTemplate", Combo_organisationaddresscountry_Htmltemplate);
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV22GAMErrors);
         Combo_organisationtypeid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucCombo_organisationtypeid.SendProperty(context, "", false, Combo_organisationtypeid_Internalname, "GAMOAuthToken", Combo_organisationtypeid_Gamoauthtoken);
         edtOrganisationTypeId_Visible = 0;
         AssignProp("", false, edtOrganisationTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationTypeId_Visible), 5, 0), true);
         AV20ComboOrganisationTypeId = Guid.Empty;
         AssignAttri("", false, "AV20ComboOrganisationTypeId", AV20ComboOrganisationTypeId.ToString());
         edtavComboorganisationtypeid_Visible = 0;
         AssignProp("", false, edtavComboorganisationtypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboorganisationtypeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONTYPEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONADDRESSCOUNTRY' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV27Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV28GXV1 = 1;
            AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            while ( AV28GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "OrganisationTypeId") == 0 )
               {
                  AV13Insert_OrganisationTypeId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_OrganisationTypeId", AV13Insert_OrganisationTypeId.ToString());
                  if ( ! (Guid.Empty==AV13Insert_OrganisationTypeId) )
                  {
                     AV20ComboOrganisationTypeId = AV13Insert_OrganisationTypeId;
                     AssignAttri("", false, "AV20ComboOrganisationTypeId", AV20ComboOrganisationTypeId.ToString());
                     Combo_organisationtypeid_Selectedvalue_set = StringUtil.Trim( AV20ComboOrganisationTypeId.ToString());
                     ucCombo_organisationtypeid.SendProperty(context, "", false, Combo_organisationtypeid_Internalname, "SelectedValue_set", Combo_organisationtypeid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new trn_organisationloaddvcombo(context ).execute(  "OrganisationTypeId",  "GET",  false,  AV7OrganisationId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_organisationtypeid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_organisationtypeid.SendProperty(context, "", false, Combo_organisationtypeid_Internalname, "SelectedText_set", Combo_organisationtypeid_Selectedtext_set);
                     Combo_organisationtypeid_Enabled = false;
                     ucCombo_organisationtypeid.SendProperty(context, "", false, Combo_organisationtypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationtypeid_Enabled));
                  }
               }
               AV28GXV1 = (int)(AV28GXV1+1);
               AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            }
         }
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
      }

      protected void E13012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_organisationww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E12012( )
      {
         /* Combo_organisationtypeid_Onoptionclicked Routine */
         returnInSub = false;
         AV20ComboOrganisationTypeId = StringUtil.StrToGuid( Combo_organisationtypeid_Selectedvalue_get);
         AssignAttri("", false, "AV20ComboOrganisationTypeId", AV20ComboOrganisationTypeId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADCOMBOORGANISATIONADDRESSCOUNTRY' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new trn_organisationloaddvcombo(context ).execute(  "OrganisationAddressCountry",  Gx_mode,  false,  AV7OrganisationId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         AV25OrganisationAddressCountry_Data.FromJSonString(AV19Combo_DataJson, null);
         Combo_organisationaddresscountry_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_organisationaddresscountry.SendProperty(context, "", false, Combo_organisationaddresscountry_Internalname, "SelectedValue_set", Combo_organisationaddresscountry_Selectedvalue_set);
         AV26ComboOrganisationAddressCountry = AV17ComboSelectedValue;
         AssignAttri("", false, "AV26ComboOrganisationAddressCountry", AV26ComboOrganisationAddressCountry);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_organisationaddresscountry_Enabled = false;
            ucCombo_organisationaddresscountry.SendProperty(context, "", false, Combo_organisationaddresscountry_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationaddresscountry_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOORGANISATIONTYPEID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new trn_organisationloaddvcombo(context ).execute(  "OrganisationTypeId",  Gx_mode,  false,  AV7OrganisationId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_organisationtypeid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_organisationtypeid.SendProperty(context, "", false, Combo_organisationtypeid_Internalname, "SelectedValue_set", Combo_organisationtypeid_Selectedvalue_set);
         Combo_organisationtypeid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_organisationtypeid.SendProperty(context, "", false, Combo_organisationtypeid_Internalname, "SelectedText_set", Combo_organisationtypeid_Selectedtext_set);
         AV20ComboOrganisationTypeId = StringUtil.StrToGuid( AV17ComboSelectedValue);
         AssignAttri("", false, "AV20ComboOrganisationTypeId", AV20ComboOrganisationTypeId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_organisationtypeid_Enabled = false;
            ucCombo_organisationtypeid.SendProperty(context, "", false, Combo_organisationtypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationtypeid_Enabled));
         }
      }

      protected void ZM013( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z331OrganisationAddressCountry = T00013_A331OrganisationAddressCountry[0];
               Z13OrganisationName = T00013_A13OrganisationName[0];
               Z12OrganisationKvkNumber = T00013_A12OrganisationKvkNumber[0];
               Z16OrganisationEmail = T00013_A16OrganisationEmail[0];
               Z17OrganisationPhone = T00013_A17OrganisationPhone[0];
               Z18OrganisationVATNumber = T00013_A18OrganisationVATNumber[0];
               Z289OrganisationAddressCity = T00013_A289OrganisationAddressCity[0];
               Z288OrganisationAddressZipCode = T00013_A288OrganisationAddressZipCode[0];
               Z342OrganisationAddressLine1 = T00013_A342OrganisationAddressLine1[0];
               Z343OrganisationAddressLine2 = T00013_A343OrganisationAddressLine2[0];
               Z19OrganisationTypeId = T00013_A19OrganisationTypeId[0];
            }
            else
            {
               Z331OrganisationAddressCountry = A331OrganisationAddressCountry;
               Z13OrganisationName = A13OrganisationName;
               Z12OrganisationKvkNumber = A12OrganisationKvkNumber;
               Z16OrganisationEmail = A16OrganisationEmail;
               Z17OrganisationPhone = A17OrganisationPhone;
               Z18OrganisationVATNumber = A18OrganisationVATNumber;
               Z289OrganisationAddressCity = A289OrganisationAddressCity;
               Z288OrganisationAddressZipCode = A288OrganisationAddressZipCode;
               Z342OrganisationAddressLine1 = A342OrganisationAddressLine1;
               Z343OrganisationAddressLine2 = A343OrganisationAddressLine2;
               Z19OrganisationTypeId = A19OrganisationTypeId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z11OrganisationId = A11OrganisationId;
            Z331OrganisationAddressCountry = A331OrganisationAddressCountry;
            Z13OrganisationName = A13OrganisationName;
            Z12OrganisationKvkNumber = A12OrganisationKvkNumber;
            Z16OrganisationEmail = A16OrganisationEmail;
            Z17OrganisationPhone = A17OrganisationPhone;
            Z18OrganisationVATNumber = A18OrganisationVATNumber;
            Z289OrganisationAddressCity = A289OrganisationAddressCity;
            Z288OrganisationAddressZipCode = A288OrganisationAddressZipCode;
            Z342OrganisationAddressLine1 = A342OrganisationAddressLine1;
            Z343OrganisationAddressLine2 = A343OrganisationAddressLine2;
            Z19OrganisationTypeId = A19OrganisationTypeId;
            Z20OrganisationTypeName = A20OrganisationTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV27Pgmname = "Trn_Organisation";
         AssignAttri("", false, "AV27Pgmname", AV27Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_OrganisationTypeId) )
         {
            edtOrganisationTypeId_Enabled = 0;
            AssignProp("", false, edtOrganisationTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationTypeId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationTypeId_Enabled = 1;
            AssignProp("", false, edtOrganisationTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationTypeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_OrganisationTypeId) )
         {
            A19OrganisationTypeId = AV13Insert_OrganisationTypeId;
            AssignAttri("", false, "A19OrganisationTypeId", A19OrganisationTypeId.ToString());
         }
         else
         {
            A19OrganisationTypeId = AV20ComboOrganisationTypeId;
            AssignAttri("", false, "A19OrganisationTypeId", A19OrganisationTypeId.ToString());
         }
         A331OrganisationAddressCountry = AV26ComboOrganisationAddressCountry;
         AssignAttri("", false, "A331OrganisationAddressCountry", A331OrganisationAddressCountry);
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7OrganisationId) )
         {
            A11OrganisationId = AV7OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A11OrganisationId) && ( Gx_BScreen == 0 ) )
            {
               A11OrganisationId = Guid.NewGuid( );
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00014 */
            pr_default.execute(2, new Object[] {A19OrganisationTypeId});
            A20OrganisationTypeName = T00014_A20OrganisationTypeName[0];
            pr_default.close(2);
         }
      }

      protected void Load013( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
            A331OrganisationAddressCountry = T00015_A331OrganisationAddressCountry[0];
            AssignAttri("", false, "A331OrganisationAddressCountry", A331OrganisationAddressCountry);
            A13OrganisationName = T00015_A13OrganisationName[0];
            AssignAttri("", false, "A13OrganisationName", A13OrganisationName);
            A12OrganisationKvkNumber = T00015_A12OrganisationKvkNumber[0];
            AssignAttri("", false, "A12OrganisationKvkNumber", A12OrganisationKvkNumber);
            A16OrganisationEmail = T00015_A16OrganisationEmail[0];
            AssignAttri("", false, "A16OrganisationEmail", A16OrganisationEmail);
            A17OrganisationPhone = T00015_A17OrganisationPhone[0];
            AssignAttri("", false, "A17OrganisationPhone", A17OrganisationPhone);
            A18OrganisationVATNumber = T00015_A18OrganisationVATNumber[0];
            AssignAttri("", false, "A18OrganisationVATNumber", StringUtil.LTrimStr( (decimal)(A18OrganisationVATNumber), 8, 0));
            A289OrganisationAddressCity = T00015_A289OrganisationAddressCity[0];
            AssignAttri("", false, "A289OrganisationAddressCity", A289OrganisationAddressCity);
            A288OrganisationAddressZipCode = T00015_A288OrganisationAddressZipCode[0];
            AssignAttri("", false, "A288OrganisationAddressZipCode", A288OrganisationAddressZipCode);
            A342OrganisationAddressLine1 = T00015_A342OrganisationAddressLine1[0];
            AssignAttri("", false, "A342OrganisationAddressLine1", A342OrganisationAddressLine1);
            A343OrganisationAddressLine2 = T00015_A343OrganisationAddressLine2[0];
            AssignAttri("", false, "A343OrganisationAddressLine2", A343OrganisationAddressLine2);
            A20OrganisationTypeName = T00015_A20OrganisationTypeName[0];
            A19OrganisationTypeId = T00015_A19OrganisationTypeId[0];
            AssignAttri("", false, "A19OrganisationTypeId", A19OrganisationTypeId.ToString());
            ZM013( -13) ;
         }
         pr_default.close(3);
         OnLoadActions013( ) ;
      }

      protected void OnLoadActions013( )
      {
      }

      protected void CheckExtendedTable013( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A16OrganisationEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Organisation Email does not match the specified pattern", "OutOfRange", 1, "ORGANISATIONEMAIL");
            AnyError = 1;
            GX_FocusControl = edtOrganisationEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A19OrganisationTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_Organisation Type'.", "ForeignKeyNotFound", 1, "ORGANISATIONTYPEID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20OrganisationTypeName = T00014_A20OrganisationTypeName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors013( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( Guid A19OrganisationTypeId )
      {
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A19OrganisationTypeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_Organisation Type'.", "ForeignKeyNotFound", 1, "ORGANISATIONTYPEID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20OrganisationTypeName = T00016_A20OrganisationTypeName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A20OrganisationTypeName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey013( )
      {
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM013( 13) ;
            RcdFound3 = 1;
            A11OrganisationId = T00013_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A331OrganisationAddressCountry = T00013_A331OrganisationAddressCountry[0];
            AssignAttri("", false, "A331OrganisationAddressCountry", A331OrganisationAddressCountry);
            A13OrganisationName = T00013_A13OrganisationName[0];
            AssignAttri("", false, "A13OrganisationName", A13OrganisationName);
            A12OrganisationKvkNumber = T00013_A12OrganisationKvkNumber[0];
            AssignAttri("", false, "A12OrganisationKvkNumber", A12OrganisationKvkNumber);
            A16OrganisationEmail = T00013_A16OrganisationEmail[0];
            AssignAttri("", false, "A16OrganisationEmail", A16OrganisationEmail);
            A17OrganisationPhone = T00013_A17OrganisationPhone[0];
            AssignAttri("", false, "A17OrganisationPhone", A17OrganisationPhone);
            A18OrganisationVATNumber = T00013_A18OrganisationVATNumber[0];
            AssignAttri("", false, "A18OrganisationVATNumber", StringUtil.LTrimStr( (decimal)(A18OrganisationVATNumber), 8, 0));
            A289OrganisationAddressCity = T00013_A289OrganisationAddressCity[0];
            AssignAttri("", false, "A289OrganisationAddressCity", A289OrganisationAddressCity);
            A288OrganisationAddressZipCode = T00013_A288OrganisationAddressZipCode[0];
            AssignAttri("", false, "A288OrganisationAddressZipCode", A288OrganisationAddressZipCode);
            A342OrganisationAddressLine1 = T00013_A342OrganisationAddressLine1[0];
            AssignAttri("", false, "A342OrganisationAddressLine1", A342OrganisationAddressLine1);
            A343OrganisationAddressLine2 = T00013_A343OrganisationAddressLine2[0];
            AssignAttri("", false, "A343OrganisationAddressLine2", A343OrganisationAddressLine2);
            A19OrganisationTypeId = T00013_A19OrganisationTypeId[0];
            AssignAttri("", false, "A19OrganisationTypeId", A19OrganisationTypeId.ToString());
            Z11OrganisationId = A11OrganisationId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load013( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey013( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey013( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey013( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00018_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00018_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               A11OrganisationId = T00018_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound3 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00019 */
         pr_default.execute(7, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00019_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00019_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) ) )
            {
               A11OrganisationId = T00019_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               RcdFound3 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey013( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtOrganisationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert013( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A11OrganisationId != Z11OrganisationId )
               {
                  A11OrganisationId = Z11OrganisationId;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ORGANISATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtOrganisationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtOrganisationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update013( ) ;
                  GX_FocusControl = edtOrganisationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A11OrganisationId != Z11OrganisationId )
               {
                  /* Insert record */
                  GX_FocusControl = edtOrganisationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert013( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ORGANISATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtOrganisationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtOrganisationName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert013( ) ;
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
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A11OrganisationId != Z11OrganisationId )
         {
            A11OrganisationId = Z11OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtOrganisationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency013( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Organisation"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z331OrganisationAddressCountry, T00012_A331OrganisationAddressCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z13OrganisationName, T00012_A13OrganisationName[0]) != 0 ) || ( StringUtil.StrCmp(Z12OrganisationKvkNumber, T00012_A12OrganisationKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z16OrganisationEmail, T00012_A16OrganisationEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z17OrganisationPhone, T00012_A17OrganisationPhone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z18OrganisationVATNumber != T00012_A18OrganisationVATNumber[0] ) || ( StringUtil.StrCmp(Z289OrganisationAddressCity, T00012_A289OrganisationAddressCity[0]) != 0 ) || ( StringUtil.StrCmp(Z288OrganisationAddressZipCode, T00012_A288OrganisationAddressZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z342OrganisationAddressLine1, T00012_A342OrganisationAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z343OrganisationAddressLine2, T00012_A343OrganisationAddressLine2[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z19OrganisationTypeId != T00012_A19OrganisationTypeId[0] ) )
            {
               if ( StringUtil.StrCmp(Z331OrganisationAddressCountry, T00012_A331OrganisationAddressCountry[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_organisation:[seudo value changed for attri]"+"OrganisationAddressCountry");
                  GXUtil.WriteLogRaw("Old: ",Z331OrganisationAddressCountry);
                  GXUtil.WriteLogRaw("Current: ",T00012_A331OrganisationAddressCountry[0]);
               }
               if ( StringUtil.StrCmp(Z13OrganisationName, T00012_A13OrganisationName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_organisation:[seudo value changed for attri]"+"OrganisationName");
                  GXUtil.WriteLogRaw("Old: ",Z13OrganisationName);
                  GXUtil.WriteLogRaw("Current: ",T00012_A13OrganisationName[0]);
               }
               if ( StringUtil.StrCmp(Z12OrganisationKvkNumber, T00012_A12OrganisationKvkNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_organisation:[seudo value changed for attri]"+"OrganisationKvkNumber");
                  GXUtil.WriteLogRaw("Old: ",Z12OrganisationKvkNumber);
                  GXUtil.WriteLogRaw("Current: ",T00012_A12OrganisationKvkNumber[0]);
               }
               if ( StringUtil.StrCmp(Z16OrganisationEmail, T00012_A16OrganisationEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_organisation:[seudo value changed for attri]"+"OrganisationEmail");
                  GXUtil.WriteLogRaw("Old: ",Z16OrganisationEmail);
                  GXUtil.WriteLogRaw("Current: ",T00012_A16OrganisationEmail[0]);
               }
               if ( StringUtil.StrCmp(Z17OrganisationPhone, T00012_A17OrganisationPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_organisation:[seudo value changed for attri]"+"OrganisationPhone");
                  GXUtil.WriteLogRaw("Old: ",Z17OrganisationPhone);
                  GXUtil.WriteLogRaw("Current: ",T00012_A17OrganisationPhone[0]);
               }
               if ( Z18OrganisationVATNumber != T00012_A18OrganisationVATNumber[0] )
               {
                  GXUtil.WriteLog("trn_organisation:[seudo value changed for attri]"+"OrganisationVATNumber");
                  GXUtil.WriteLogRaw("Old: ",Z18OrganisationVATNumber);
                  GXUtil.WriteLogRaw("Current: ",T00012_A18OrganisationVATNumber[0]);
               }
               if ( StringUtil.StrCmp(Z289OrganisationAddressCity, T00012_A289OrganisationAddressCity[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_organisation:[seudo value changed for attri]"+"OrganisationAddressCity");
                  GXUtil.WriteLogRaw("Old: ",Z289OrganisationAddressCity);
                  GXUtil.WriteLogRaw("Current: ",T00012_A289OrganisationAddressCity[0]);
               }
               if ( StringUtil.StrCmp(Z288OrganisationAddressZipCode, T00012_A288OrganisationAddressZipCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_organisation:[seudo value changed for attri]"+"OrganisationAddressZipCode");
                  GXUtil.WriteLogRaw("Old: ",Z288OrganisationAddressZipCode);
                  GXUtil.WriteLogRaw("Current: ",T00012_A288OrganisationAddressZipCode[0]);
               }
               if ( StringUtil.StrCmp(Z342OrganisationAddressLine1, T00012_A342OrganisationAddressLine1[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_organisation:[seudo value changed for attri]"+"OrganisationAddressLine1");
                  GXUtil.WriteLogRaw("Old: ",Z342OrganisationAddressLine1);
                  GXUtil.WriteLogRaw("Current: ",T00012_A342OrganisationAddressLine1[0]);
               }
               if ( StringUtil.StrCmp(Z343OrganisationAddressLine2, T00012_A343OrganisationAddressLine2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_organisation:[seudo value changed for attri]"+"OrganisationAddressLine2");
                  GXUtil.WriteLogRaw("Old: ",Z343OrganisationAddressLine2);
                  GXUtil.WriteLogRaw("Current: ",T00012_A343OrganisationAddressLine2[0]);
               }
               if ( Z19OrganisationTypeId != T00012_A19OrganisationTypeId[0] )
               {
                  GXUtil.WriteLog("trn_organisation:[seudo value changed for attri]"+"OrganisationTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z19OrganisationTypeId);
                  GXUtil.WriteLogRaw("Current: ",T00012_A19OrganisationTypeId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Organisation"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert013( )
      {
         if ( ! IsAuthorized("trn_organisation_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable013( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM013( 0) ;
            CheckOptimisticConcurrency013( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm013( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert013( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000110 */
                     pr_default.execute(8, new Object[] {A11OrganisationId, A331OrganisationAddressCountry, A13OrganisationName, A12OrganisationKvkNumber, A16OrganisationEmail, A17OrganisationPhone, A18OrganisationVATNumber, A289OrganisationAddressCity, A288OrganisationAddressZipCode, A342OrganisationAddressLine1, A343OrganisationAddressLine2, A19OrganisationTypeId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
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
               Load013( ) ;
            }
            EndLevel013( ) ;
         }
         CloseExtendedTableCursors013( ) ;
      }

      protected void Update013( )
      {
         if ( ! IsAuthorized("trn_organisation_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable013( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency013( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm013( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate013( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000111 */
                     pr_default.execute(9, new Object[] {A331OrganisationAddressCountry, A13OrganisationName, A12OrganisationKvkNumber, A16OrganisationEmail, A17OrganisationPhone, A18OrganisationVATNumber, A289OrganisationAddressCity, A288OrganisationAddressZipCode, A342OrganisationAddressLine1, A343OrganisationAddressLine2, A19OrganisationTypeId, A11OrganisationId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Organisation"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate013( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
            EndLevel013( ) ;
         }
         CloseExtendedTableCursors013( ) ;
      }

      protected void DeferredUpdate013( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_organisation_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate013( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency013( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls013( ) ;
            AfterConfirm013( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete013( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000112 */
                  pr_default.execute(10, new Object[] {A11OrganisationId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
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
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel013( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls013( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000113 */
            pr_default.execute(11, new Object[] {A19OrganisationTypeId});
            A20OrganisationTypeName = T000113_A20OrganisationTypeName[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000114 */
            pr_default.execute(12, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Trn_Organisation Setting"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000115 */
            pr_default.execute(13, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Trn_Location"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000116 */
            pr_default.execute(14, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Trn_Manager"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel013( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete013( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_organisation",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_organisation",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart013( )
      {
         /* Scan By routine */
         /* Using cursor T000117 */
         pr_default.execute(15);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound3 = 1;
            A11OrganisationId = T000117_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext013( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound3 = 1;
            A11OrganisationId = T000117_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
      }

      protected void ScanEnd013( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm013( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert013( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate013( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete013( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete013( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate013( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes013( )
      {
         edtOrganisationName_Enabled = 0;
         AssignProp("", false, edtOrganisationName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationName_Enabled), 5, 0), true);
         edtOrganisationKvkNumber_Enabled = 0;
         AssignProp("", false, edtOrganisationKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationKvkNumber_Enabled), 5, 0), true);
         edtOrganisationEmail_Enabled = 0;
         AssignProp("", false, edtOrganisationEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationEmail_Enabled), 5, 0), true);
         edtOrganisationPhone_Enabled = 0;
         AssignProp("", false, edtOrganisationPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationPhone_Enabled), 5, 0), true);
         edtOrganisationTypeId_Enabled = 0;
         AssignProp("", false, edtOrganisationTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationTypeId_Enabled), 5, 0), true);
         edtOrganisationVATNumber_Enabled = 0;
         AssignProp("", false, edtOrganisationVATNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationVATNumber_Enabled), 5, 0), true);
         edtOrganisationAddressCountry_Enabled = 0;
         AssignProp("", false, edtOrganisationAddressCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationAddressCountry_Enabled), 5, 0), true);
         edtOrganisationAddressCity_Enabled = 0;
         AssignProp("", false, edtOrganisationAddressCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationAddressCity_Enabled), 5, 0), true);
         edtOrganisationAddressZipCode_Enabled = 0;
         AssignProp("", false, edtOrganisationAddressZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationAddressZipCode_Enabled), 5, 0), true);
         edtOrganisationAddressLine1_Enabled = 0;
         AssignProp("", false, edtOrganisationAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationAddressLine1_Enabled), 5, 0), true);
         edtOrganisationAddressLine2_Enabled = 0;
         AssignProp("", false, edtOrganisationAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationAddressLine2_Enabled), 5, 0), true);
         edtavComboorganisationtypeid_Enabled = 0;
         AssignProp("", false, edtavComboorganisationtypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationtypeid_Enabled), 5, 0), true);
         edtavComboorganisationaddresscountry_Enabled = 0;
         AssignProp("", false, edtavComboorganisationaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationaddresscountry_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes013( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "trn_organisation.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_organisation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Organisation");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_organisation:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z331OrganisationAddressCountry", Z331OrganisationAddressCountry);
         GxWebStd.gx_hidden_field( context, "Z13OrganisationName", Z13OrganisationName);
         GxWebStd.gx_hidden_field( context, "Z12OrganisationKvkNumber", Z12OrganisationKvkNumber);
         GxWebStd.gx_hidden_field( context, "Z16OrganisationEmail", Z16OrganisationEmail);
         GxWebStd.gx_hidden_field( context, "Z17OrganisationPhone", StringUtil.RTrim( Z17OrganisationPhone));
         GxWebStd.gx_hidden_field( context, "Z18OrganisationVATNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18OrganisationVATNumber), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z289OrganisationAddressCity", Z289OrganisationAddressCity);
         GxWebStd.gx_hidden_field( context, "Z288OrganisationAddressZipCode", Z288OrganisationAddressZipCode);
         GxWebStd.gx_hidden_field( context, "Z342OrganisationAddressLine1", Z342OrganisationAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z343OrganisationAddressLine2", Z343OrganisationAddressLine2);
         GxWebStd.gx_hidden_field( context, "Z19OrganisationTypeId", Z19OrganisationTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N19OrganisationTypeId", A19OrganisationTypeId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vORGANISATIONTYPEID_DATA", AV15OrganisationTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vORGANISATIONTYPEID_DATA", AV15OrganisationTypeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vORGANISATIONADDRESSCOUNTRY_DATA", AV25OrganisationAddressCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vORGANISATIONADDRESSCOUNTRY_DATA", AV25OrganisationAddressCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV7OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV7OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ORGANISATIONTYPEID", AV13Insert_OrganisationTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "ORGANISATIONTYPENAME", A20OrganisationTypeName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONTYPEID_Objectcall", StringUtil.RTrim( Combo_organisationtypeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONTYPEID_Cls", StringUtil.RTrim( Combo_organisationtypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONTYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_organisationtypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONTYPEID_Selectedtext_set", StringUtil.RTrim( Combo_organisationtypeid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONTYPEID_Gamoauthtoken", StringUtil.RTrim( Combo_organisationtypeid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONTYPEID_Enabled", StringUtil.BoolToStr( Combo_organisationtypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONTYPEID_Datalistproc", StringUtil.RTrim( Combo_organisationtypeid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONTYPEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_organisationtypeid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONTYPEID_Emptyitem", StringUtil.BoolToStr( Combo_organisationtypeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONADDRESSCOUNTRY_Objectcall", StringUtil.RTrim( Combo_organisationaddresscountry_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONADDRESSCOUNTRY_Cls", StringUtil.RTrim( Combo_organisationaddresscountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONADDRESSCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_organisationaddresscountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONADDRESSCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_organisationaddresscountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONADDRESSCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_organisationaddresscountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONADDRESSCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_organisationaddresscountry_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "trn_organisation.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7OrganisationId.ToString());
         return formatLink("trn_organisation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Organisation" ;
      }

      public override string GetPgmdesc( )
      {
         return "Organisations" ;
      }

      protected void InitializeNonKey013( )
      {
         A19OrganisationTypeId = Guid.Empty;
         AssignAttri("", false, "A19OrganisationTypeId", A19OrganisationTypeId.ToString());
         A331OrganisationAddressCountry = "";
         AssignAttri("", false, "A331OrganisationAddressCountry", A331OrganisationAddressCountry);
         A13OrganisationName = "";
         AssignAttri("", false, "A13OrganisationName", A13OrganisationName);
         A12OrganisationKvkNumber = "";
         AssignAttri("", false, "A12OrganisationKvkNumber", A12OrganisationKvkNumber);
         A16OrganisationEmail = "";
         AssignAttri("", false, "A16OrganisationEmail", A16OrganisationEmail);
         A17OrganisationPhone = "";
         AssignAttri("", false, "A17OrganisationPhone", A17OrganisationPhone);
         A18OrganisationVATNumber = 0;
         AssignAttri("", false, "A18OrganisationVATNumber", StringUtil.LTrimStr( (decimal)(A18OrganisationVATNumber), 8, 0));
         A289OrganisationAddressCity = "";
         AssignAttri("", false, "A289OrganisationAddressCity", A289OrganisationAddressCity);
         A288OrganisationAddressZipCode = "";
         AssignAttri("", false, "A288OrganisationAddressZipCode", A288OrganisationAddressZipCode);
         A342OrganisationAddressLine1 = "";
         AssignAttri("", false, "A342OrganisationAddressLine1", A342OrganisationAddressLine1);
         A343OrganisationAddressLine2 = "";
         AssignAttri("", false, "A343OrganisationAddressLine2", A343OrganisationAddressLine2);
         A20OrganisationTypeName = "";
         AssignAttri("", false, "A20OrganisationTypeName", A20OrganisationTypeName);
         Z331OrganisationAddressCountry = "";
         Z13OrganisationName = "";
         Z12OrganisationKvkNumber = "";
         Z16OrganisationEmail = "";
         Z17OrganisationPhone = "";
         Z18OrganisationVATNumber = 0;
         Z289OrganisationAddressCity = "";
         Z288OrganisationAddressZipCode = "";
         Z342OrganisationAddressLine1 = "";
         Z343OrganisationAddressLine2 = "";
         Z19OrganisationTypeId = Guid.Empty;
      }

      protected void InitAll013( )
      {
         A11OrganisationId = Guid.NewGuid( );
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         InitializeNonKey013( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202492719455275", true, true);
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
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("trn_organisation.js", "?202492719455277", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtOrganisationName_Internalname = "ORGANISATIONNAME";
         edtOrganisationKvkNumber_Internalname = "ORGANISATIONKVKNUMBER";
         edtOrganisationEmail_Internalname = "ORGANISATIONEMAIL";
         edtOrganisationPhone_Internalname = "ORGANISATIONPHONE";
         lblTextblockorganisationtypeid_Internalname = "TEXTBLOCKORGANISATIONTYPEID";
         Combo_organisationtypeid_Internalname = "COMBO_ORGANISATIONTYPEID";
         edtOrganisationTypeId_Internalname = "ORGANISATIONTYPEID";
         divTablesplittedorganisationtypeid_Internalname = "TABLESPLITTEDORGANISATIONTYPEID";
         edtOrganisationVATNumber_Internalname = "ORGANISATIONVATNUMBER";
         lblTextblockorganisationaddresscountry_Internalname = "TEXTBLOCKORGANISATIONADDRESSCOUNTRY";
         Combo_organisationaddresscountry_Internalname = "COMBO_ORGANISATIONADDRESSCOUNTRY";
         edtOrganisationAddressCountry_Internalname = "ORGANISATIONADDRESSCOUNTRY";
         divTablesplittedorganisationaddresscountry_Internalname = "TABLESPLITTEDORGANISATIONADDRESSCOUNTRY";
         edtOrganisationAddressCity_Internalname = "ORGANISATIONADDRESSCITY";
         edtOrganisationAddressZipCode_Internalname = "ORGANISATIONADDRESSZIPCODE";
         edtOrganisationAddressLine1_Internalname = "ORGANISATIONADDRESSLINE1";
         edtOrganisationAddressLine2_Internalname = "ORGANISATIONADDRESSLINE2";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboorganisationtypeid_Internalname = "vCOMBOORGANISATIONTYPEID";
         divSectionattribute_organisationtypeid_Internalname = "SECTIONATTRIBUTE_ORGANISATIONTYPEID";
         edtavComboorganisationaddresscountry_Internalname = "vCOMBOORGANISATIONADDRESSCOUNTRY";
         divSectionattribute_organisationaddresscountry_Internalname = "SECTIONATTRIBUTE_ORGANISATIONADDRESSCOUNTRY";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
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
         Form.Caption = "Organisations";
         Combo_organisationaddresscountry_Htmltemplate = "";
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         edtavComboorganisationaddresscountry_Jsonclick = "";
         edtavComboorganisationaddresscountry_Enabled = 0;
         edtavComboorganisationaddresscountry_Visible = 1;
         edtavComboorganisationtypeid_Jsonclick = "";
         edtavComboorganisationtypeid_Enabled = 0;
         edtavComboorganisationtypeid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtOrganisationAddressLine2_Jsonclick = "";
         edtOrganisationAddressLine2_Enabled = 1;
         edtOrganisationAddressLine1_Jsonclick = "";
         edtOrganisationAddressLine1_Enabled = 1;
         edtOrganisationAddressZipCode_Jsonclick = "";
         edtOrganisationAddressZipCode_Enabled = 1;
         edtOrganisationAddressCity_Jsonclick = "";
         edtOrganisationAddressCity_Enabled = 1;
         edtOrganisationAddressCountry_Jsonclick = "";
         edtOrganisationAddressCountry_Enabled = 1;
         edtOrganisationAddressCountry_Visible = 1;
         Combo_organisationaddresscountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_organisationaddresscountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_organisationaddresscountry_Caption = "";
         Combo_organisationaddresscountry_Enabled = Convert.ToBoolean( -1);
         edtOrganisationVATNumber_Jsonclick = "";
         edtOrganisationVATNumber_Enabled = 1;
         edtOrganisationTypeId_Jsonclick = "";
         edtOrganisationTypeId_Enabled = 1;
         edtOrganisationTypeId_Visible = 1;
         Combo_organisationtypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_organisationtypeid_Datalistprocparametersprefix = " \"ComboName\": \"OrganisationTypeId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"OrganisationId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_organisationtypeid_Datalistproc = "Trn_OrganisationLoadDVCombo";
         Combo_organisationtypeid_Cls = "ExtendedCombo Attribute";
         Combo_organisationtypeid_Caption = "";
         Combo_organisationtypeid_Enabled = Convert.ToBoolean( -1);
         edtOrganisationPhone_Jsonclick = "";
         edtOrganisationPhone_Enabled = 1;
         edtOrganisationEmail_Jsonclick = "";
         edtOrganisationEmail_Enabled = 1;
         edtOrganisationKvkNumber_Jsonclick = "";
         edtOrganisationKvkNumber_Enabled = 1;
         edtOrganisationName_Jsonclick = "";
         edtOrganisationName_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "General Information";
         Dvpanel_tableattributes_Cls = "PanelWithBorder Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         divLayoutmaintable_Class = "Table";
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

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
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

      public void Valid_Organisationtypeid( )
      {
         /* Using cursor T000113 */
         pr_default.execute(11, new Object[] {A19OrganisationTypeId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_Organisation Type'.", "ForeignKeyNotFound", 1, "ORGANISATIONTYPEID");
            AnyError = 1;
            GX_FocusControl = edtOrganisationTypeId_Internalname;
         }
         A20OrganisationTypeName = T000113_A20OrganisationTypeName[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A20OrganisationTypeName", A20OrganisationTypeName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7OrganisationId","fld":"vORGANISATIONID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7OrganisationId","fld":"vORGANISATIONID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E13012","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_ORGANISATIONTYPEID.ONOPTIONCLICKED","""{"handler":"E12012","iparms":[{"av":"Combo_organisationtypeid_Selectedvalue_get","ctrl":"COMBO_ORGANISATIONTYPEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_ORGANISATIONTYPEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV20ComboOrganisationTypeId","fld":"vCOMBOORGANISATIONTYPEID"}]}""");
         setEventMetadata("VALID_ORGANISATIONEMAIL","""{"handler":"Valid_Organisationemail","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONTYPEID","""{"handler":"Valid_Organisationtypeid","iparms":[{"av":"A19OrganisationTypeId","fld":"ORGANISATIONTYPEID"},{"av":"A20OrganisationTypeName","fld":"ORGANISATIONTYPENAME"}]""");
         setEventMetadata("VALID_ORGANISATIONTYPEID",""","oparms":[{"av":"A20OrganisationTypeName","fld":"ORGANISATIONTYPENAME"}]}""");
         setEventMetadata("VALIDV_COMBOORGANISATIONTYPEID","""{"handler":"Validv_Comboorganisationtypeid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOORGANISATIONADDRESSCOUNTRY","""{"handler":"Validv_Comboorganisationaddresscountry","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[]}""");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7OrganisationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z331OrganisationAddressCountry = "";
         Z13OrganisationName = "";
         Z12OrganisationKvkNumber = "";
         Z16OrganisationEmail = "";
         Z17OrganisationPhone = "";
         Z289OrganisationAddressCity = "";
         Z288OrganisationAddressZipCode = "";
         Z342OrganisationAddressLine1 = "";
         Z343OrganisationAddressLine2 = "";
         Z19OrganisationTypeId = Guid.Empty;
         N19OrganisationTypeId = Guid.Empty;
         Combo_organisationaddresscountry_Selectedvalue_get = "";
         Combo_organisationtypeid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A19OrganisationTypeId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A13OrganisationName = "";
         A12OrganisationKvkNumber = "";
         A16OrganisationEmail = "";
         gxphoneLink = "";
         A17OrganisationPhone = "";
         lblTextblockorganisationtypeid_Jsonclick = "";
         ucCombo_organisationtypeid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15OrganisationTypeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockorganisationaddresscountry_Jsonclick = "";
         ucCombo_organisationaddresscountry = new GXUserControl();
         AV25OrganisationAddressCountry_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A331OrganisationAddressCountry = "";
         A289OrganisationAddressCity = "";
         A288OrganisationAddressZipCode = "";
         A342OrganisationAddressLine1 = "";
         A343OrganisationAddressLine2 = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboOrganisationTypeId = Guid.Empty;
         AV26ComboOrganisationAddressCountry = "";
         A11OrganisationId = Guid.Empty;
         AV13Insert_OrganisationTypeId = Guid.Empty;
         A20OrganisationTypeName = "";
         AV27Pgmname = "";
         Combo_organisationtypeid_Objectcall = "";
         Combo_organisationtypeid_Class = "";
         Combo_organisationtypeid_Icontype = "";
         Combo_organisationtypeid_Icon = "";
         Combo_organisationtypeid_Tooltip = "";
         Combo_organisationtypeid_Selectedvalue_set = "";
         Combo_organisationtypeid_Selectedtext_set = "";
         Combo_organisationtypeid_Selectedtext_get = "";
         Combo_organisationtypeid_Gamoauthtoken = "";
         Combo_organisationtypeid_Ddointernalname = "";
         Combo_organisationtypeid_Titlecontrolalign = "";
         Combo_organisationtypeid_Dropdownoptionstype = "";
         Combo_organisationtypeid_Titlecontrolidtoreplace = "";
         Combo_organisationtypeid_Datalisttype = "";
         Combo_organisationtypeid_Datalistfixedvalues = "";
         Combo_organisationtypeid_Remoteservicesparameters = "";
         Combo_organisationtypeid_Htmltemplate = "";
         Combo_organisationtypeid_Multiplevaluestype = "";
         Combo_organisationtypeid_Loadingdata = "";
         Combo_organisationtypeid_Noresultsfound = "";
         Combo_organisationtypeid_Emptyitemtext = "";
         Combo_organisationtypeid_Onlyselectedvalues = "";
         Combo_organisationtypeid_Selectalltext = "";
         Combo_organisationtypeid_Multiplevaluesseparator = "";
         Combo_organisationtypeid_Addnewoptiontext = "";
         Combo_organisationaddresscountry_Objectcall = "";
         Combo_organisationaddresscountry_Class = "";
         Combo_organisationaddresscountry_Icontype = "";
         Combo_organisationaddresscountry_Icon = "";
         Combo_organisationaddresscountry_Tooltip = "";
         Combo_organisationaddresscountry_Selectedvalue_set = "";
         Combo_organisationaddresscountry_Selectedtext_set = "";
         Combo_organisationaddresscountry_Selectedtext_get = "";
         Combo_organisationaddresscountry_Gamoauthtoken = "";
         Combo_organisationaddresscountry_Ddointernalname = "";
         Combo_organisationaddresscountry_Titlecontrolalign = "";
         Combo_organisationaddresscountry_Dropdownoptionstype = "";
         Combo_organisationaddresscountry_Titlecontrolidtoreplace = "";
         Combo_organisationaddresscountry_Datalisttype = "";
         Combo_organisationaddresscountry_Datalistfixedvalues = "";
         Combo_organisationaddresscountry_Datalistproc = "";
         Combo_organisationaddresscountry_Datalistprocparametersprefix = "";
         Combo_organisationaddresscountry_Remoteservicesparameters = "";
         Combo_organisationaddresscountry_Multiplevaluestype = "";
         Combo_organisationaddresscountry_Loadingdata = "";
         Combo_organisationaddresscountry_Noresultsfound = "";
         Combo_organisationaddresscountry_Emptyitemtext = "";
         Combo_organisationaddresscountry_Onlyselectedvalues = "";
         Combo_organisationaddresscountry_Selectalltext = "";
         Combo_organisationaddresscountry_Multiplevaluesseparator = "";
         Combo_organisationaddresscountry_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV22GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         Z20OrganisationTypeName = "";
         T00014_A20OrganisationTypeName = new string[] {""} ;
         T00015_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00015_A331OrganisationAddressCountry = new string[] {""} ;
         T00015_A13OrganisationName = new string[] {""} ;
         T00015_A12OrganisationKvkNumber = new string[] {""} ;
         T00015_A16OrganisationEmail = new string[] {""} ;
         T00015_A17OrganisationPhone = new string[] {""} ;
         T00015_A18OrganisationVATNumber = new int[1] ;
         T00015_A289OrganisationAddressCity = new string[] {""} ;
         T00015_A288OrganisationAddressZipCode = new string[] {""} ;
         T00015_A342OrganisationAddressLine1 = new string[] {""} ;
         T00015_A343OrganisationAddressLine2 = new string[] {""} ;
         T00015_A20OrganisationTypeName = new string[] {""} ;
         T00015_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         T00016_A20OrganisationTypeName = new string[] {""} ;
         T00017_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00013_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00013_A331OrganisationAddressCountry = new string[] {""} ;
         T00013_A13OrganisationName = new string[] {""} ;
         T00013_A12OrganisationKvkNumber = new string[] {""} ;
         T00013_A16OrganisationEmail = new string[] {""} ;
         T00013_A17OrganisationPhone = new string[] {""} ;
         T00013_A18OrganisationVATNumber = new int[1] ;
         T00013_A289OrganisationAddressCity = new string[] {""} ;
         T00013_A288OrganisationAddressZipCode = new string[] {""} ;
         T00013_A342OrganisationAddressLine1 = new string[] {""} ;
         T00013_A343OrganisationAddressLine2 = new string[] {""} ;
         T00013_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         T00018_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00019_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00012_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00012_A331OrganisationAddressCountry = new string[] {""} ;
         T00012_A13OrganisationName = new string[] {""} ;
         T00012_A12OrganisationKvkNumber = new string[] {""} ;
         T00012_A16OrganisationEmail = new string[] {""} ;
         T00012_A17OrganisationPhone = new string[] {""} ;
         T00012_A18OrganisationVATNumber = new int[1] ;
         T00012_A289OrganisationAddressCity = new string[] {""} ;
         T00012_A288OrganisationAddressZipCode = new string[] {""} ;
         T00012_A342OrganisationAddressLine1 = new string[] {""} ;
         T00012_A343OrganisationAddressLine2 = new string[] {""} ;
         T00012_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         T000113_A20OrganisationTypeName = new string[] {""} ;
         T000114_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         T000115_A29LocationId = new Guid[] {Guid.Empty} ;
         T000115_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000116_A21ManagerId = new Guid[] {Guid.Empty} ;
         T000116_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000117_A11OrganisationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_organisation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisation__default(),
            new Object[][] {
                new Object[] {
               T00012_A11OrganisationId, T00012_A331OrganisationAddressCountry, T00012_A13OrganisationName, T00012_A12OrganisationKvkNumber, T00012_A16OrganisationEmail, T00012_A17OrganisationPhone, T00012_A18OrganisationVATNumber, T00012_A289OrganisationAddressCity, T00012_A288OrganisationAddressZipCode, T00012_A342OrganisationAddressLine1,
               T00012_A343OrganisationAddressLine2, T00012_A19OrganisationTypeId
               }
               , new Object[] {
               T00013_A11OrganisationId, T00013_A331OrganisationAddressCountry, T00013_A13OrganisationName, T00013_A12OrganisationKvkNumber, T00013_A16OrganisationEmail, T00013_A17OrganisationPhone, T00013_A18OrganisationVATNumber, T00013_A289OrganisationAddressCity, T00013_A288OrganisationAddressZipCode, T00013_A342OrganisationAddressLine1,
               T00013_A343OrganisationAddressLine2, T00013_A19OrganisationTypeId
               }
               , new Object[] {
               T00014_A20OrganisationTypeName
               }
               , new Object[] {
               T00015_A11OrganisationId, T00015_A331OrganisationAddressCountry, T00015_A13OrganisationName, T00015_A12OrganisationKvkNumber, T00015_A16OrganisationEmail, T00015_A17OrganisationPhone, T00015_A18OrganisationVATNumber, T00015_A289OrganisationAddressCity, T00015_A288OrganisationAddressZipCode, T00015_A342OrganisationAddressLine1,
               T00015_A343OrganisationAddressLine2, T00015_A20OrganisationTypeName, T00015_A19OrganisationTypeId
               }
               , new Object[] {
               T00016_A20OrganisationTypeName
               }
               , new Object[] {
               T00017_A11OrganisationId
               }
               , new Object[] {
               T00018_A11OrganisationId
               }
               , new Object[] {
               T00019_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000113_A20OrganisationTypeName
               }
               , new Object[] {
               T000114_A100OrganisationSettingid
               }
               , new Object[] {
               T000115_A29LocationId, T000115_A11OrganisationId
               }
               , new Object[] {
               T000116_A21ManagerId, T000116_A11OrganisationId
               }
               , new Object[] {
               T000117_A11OrganisationId
               }
            }
         );
         Z11OrganisationId = Guid.NewGuid( );
         A11OrganisationId = Guid.NewGuid( );
         AV27Pgmname = "Trn_Organisation";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound3 ;
      private short gxajaxcallmode ;
      private int Z18OrganisationVATNumber ;
      private int trnEnded ;
      private int edtOrganisationName_Enabled ;
      private int edtOrganisationKvkNumber_Enabled ;
      private int edtOrganisationEmail_Enabled ;
      private int edtOrganisationPhone_Enabled ;
      private int edtOrganisationTypeId_Visible ;
      private int edtOrganisationTypeId_Enabled ;
      private int A18OrganisationVATNumber ;
      private int edtOrganisationVATNumber_Enabled ;
      private int edtOrganisationAddressCountry_Visible ;
      private int edtOrganisationAddressCountry_Enabled ;
      private int edtOrganisationAddressCity_Enabled ;
      private int edtOrganisationAddressZipCode_Enabled ;
      private int edtOrganisationAddressLine1_Enabled ;
      private int edtOrganisationAddressLine2_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboorganisationtypeid_Visible ;
      private int edtavComboorganisationtypeid_Enabled ;
      private int edtavComboorganisationaddresscountry_Visible ;
      private int edtavComboorganisationaddresscountry_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int Combo_organisationtypeid_Datalistupdateminimumcharacters ;
      private int Combo_organisationtypeid_Gxcontroltype ;
      private int Combo_organisationaddresscountry_Datalistupdateminimumcharacters ;
      private int Combo_organisationaddresscountry_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV28GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z17OrganisationPhone ;
      private string Combo_organisationaddresscountry_Selectedvalue_get ;
      private string Combo_organisationtypeid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtOrganisationName_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtOrganisationName_Jsonclick ;
      private string edtOrganisationKvkNumber_Internalname ;
      private string edtOrganisationKvkNumber_Jsonclick ;
      private string edtOrganisationEmail_Internalname ;
      private string edtOrganisationEmail_Jsonclick ;
      private string edtOrganisationPhone_Internalname ;
      private string gxphoneLink ;
      private string A17OrganisationPhone ;
      private string edtOrganisationPhone_Jsonclick ;
      private string divTablesplittedorganisationtypeid_Internalname ;
      private string lblTextblockorganisationtypeid_Internalname ;
      private string lblTextblockorganisationtypeid_Jsonclick ;
      private string Combo_organisationtypeid_Caption ;
      private string Combo_organisationtypeid_Cls ;
      private string Combo_organisationtypeid_Datalistproc ;
      private string Combo_organisationtypeid_Datalistprocparametersprefix ;
      private string Combo_organisationtypeid_Internalname ;
      private string edtOrganisationTypeId_Internalname ;
      private string edtOrganisationTypeId_Jsonclick ;
      private string edtOrganisationVATNumber_Internalname ;
      private string edtOrganisationVATNumber_Jsonclick ;
      private string divTablesplittedorganisationaddresscountry_Internalname ;
      private string lblTextblockorganisationaddresscountry_Internalname ;
      private string lblTextblockorganisationaddresscountry_Jsonclick ;
      private string Combo_organisationaddresscountry_Caption ;
      private string Combo_organisationaddresscountry_Cls ;
      private string Combo_organisationaddresscountry_Internalname ;
      private string edtOrganisationAddressCountry_Internalname ;
      private string edtOrganisationAddressCountry_Jsonclick ;
      private string edtOrganisationAddressCity_Internalname ;
      private string edtOrganisationAddressCity_Jsonclick ;
      private string edtOrganisationAddressZipCode_Internalname ;
      private string edtOrganisationAddressZipCode_Jsonclick ;
      private string edtOrganisationAddressLine1_Internalname ;
      private string edtOrganisationAddressLine1_Jsonclick ;
      private string edtOrganisationAddressLine2_Internalname ;
      private string edtOrganisationAddressLine2_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_organisationtypeid_Internalname ;
      private string edtavComboorganisationtypeid_Internalname ;
      private string edtavComboorganisationtypeid_Jsonclick ;
      private string divSectionattribute_organisationaddresscountry_Internalname ;
      private string edtavComboorganisationaddresscountry_Internalname ;
      private string edtavComboorganisationaddresscountry_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string AV27Pgmname ;
      private string Combo_organisationtypeid_Objectcall ;
      private string Combo_organisationtypeid_Class ;
      private string Combo_organisationtypeid_Icontype ;
      private string Combo_organisationtypeid_Icon ;
      private string Combo_organisationtypeid_Tooltip ;
      private string Combo_organisationtypeid_Selectedvalue_set ;
      private string Combo_organisationtypeid_Selectedtext_set ;
      private string Combo_organisationtypeid_Selectedtext_get ;
      private string Combo_organisationtypeid_Gamoauthtoken ;
      private string Combo_organisationtypeid_Ddointernalname ;
      private string Combo_organisationtypeid_Titlecontrolalign ;
      private string Combo_organisationtypeid_Dropdownoptionstype ;
      private string Combo_organisationtypeid_Titlecontrolidtoreplace ;
      private string Combo_organisationtypeid_Datalisttype ;
      private string Combo_organisationtypeid_Datalistfixedvalues ;
      private string Combo_organisationtypeid_Remoteservicesparameters ;
      private string Combo_organisationtypeid_Htmltemplate ;
      private string Combo_organisationtypeid_Multiplevaluestype ;
      private string Combo_organisationtypeid_Loadingdata ;
      private string Combo_organisationtypeid_Noresultsfound ;
      private string Combo_organisationtypeid_Emptyitemtext ;
      private string Combo_organisationtypeid_Onlyselectedvalues ;
      private string Combo_organisationtypeid_Selectalltext ;
      private string Combo_organisationtypeid_Multiplevaluesseparator ;
      private string Combo_organisationtypeid_Addnewoptiontext ;
      private string Combo_organisationaddresscountry_Objectcall ;
      private string Combo_organisationaddresscountry_Class ;
      private string Combo_organisationaddresscountry_Icontype ;
      private string Combo_organisationaddresscountry_Icon ;
      private string Combo_organisationaddresscountry_Tooltip ;
      private string Combo_organisationaddresscountry_Selectedvalue_set ;
      private string Combo_organisationaddresscountry_Selectedtext_set ;
      private string Combo_organisationaddresscountry_Selectedtext_get ;
      private string Combo_organisationaddresscountry_Gamoauthtoken ;
      private string Combo_organisationaddresscountry_Ddointernalname ;
      private string Combo_organisationaddresscountry_Titlecontrolalign ;
      private string Combo_organisationaddresscountry_Dropdownoptionstype ;
      private string Combo_organisationaddresscountry_Titlecontrolidtoreplace ;
      private string Combo_organisationaddresscountry_Datalisttype ;
      private string Combo_organisationaddresscountry_Datalistfixedvalues ;
      private string Combo_organisationaddresscountry_Datalistproc ;
      private string Combo_organisationaddresscountry_Datalistprocparametersprefix ;
      private string Combo_organisationaddresscountry_Remoteservicesparameters ;
      private string Combo_organisationaddresscountry_Htmltemplate ;
      private string Combo_organisationaddresscountry_Multiplevaluestype ;
      private string Combo_organisationaddresscountry_Loadingdata ;
      private string Combo_organisationaddresscountry_Noresultsfound ;
      private string Combo_organisationaddresscountry_Emptyitemtext ;
      private string Combo_organisationaddresscountry_Onlyselectedvalues ;
      private string Combo_organisationaddresscountry_Selectalltext ;
      private string Combo_organisationaddresscountry_Multiplevaluesseparator ;
      private string Combo_organisationaddresscountry_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode3 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_organisationtypeid_Emptyitem ;
      private bool Combo_organisationaddresscountry_Emptyitem ;
      private bool Combo_organisationtypeid_Enabled ;
      private bool Combo_organisationtypeid_Visible ;
      private bool Combo_organisationtypeid_Allowmultipleselection ;
      private bool Combo_organisationtypeid_Isgriditem ;
      private bool Combo_organisationtypeid_Hasdescription ;
      private bool Combo_organisationtypeid_Includeonlyselectedoption ;
      private bool Combo_organisationtypeid_Includeselectalloption ;
      private bool Combo_organisationtypeid_Includeaddnewoption ;
      private bool Combo_organisationaddresscountry_Enabled ;
      private bool Combo_organisationaddresscountry_Visible ;
      private bool Combo_organisationaddresscountry_Allowmultipleselection ;
      private bool Combo_organisationaddresscountry_Isgriditem ;
      private bool Combo_organisationaddresscountry_Hasdescription ;
      private bool Combo_organisationaddresscountry_Includeonlyselectedoption ;
      private bool Combo_organisationaddresscountry_Includeselectalloption ;
      private bool Combo_organisationaddresscountry_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV19Combo_DataJson ;
      private string Z331OrganisationAddressCountry ;
      private string Z13OrganisationName ;
      private string Z12OrganisationKvkNumber ;
      private string Z16OrganisationEmail ;
      private string Z289OrganisationAddressCity ;
      private string Z288OrganisationAddressZipCode ;
      private string Z342OrganisationAddressLine1 ;
      private string Z343OrganisationAddressLine2 ;
      private string A13OrganisationName ;
      private string A12OrganisationKvkNumber ;
      private string A16OrganisationEmail ;
      private string A331OrganisationAddressCountry ;
      private string A289OrganisationAddressCity ;
      private string A288OrganisationAddressZipCode ;
      private string A342OrganisationAddressLine1 ;
      private string A343OrganisationAddressLine2 ;
      private string AV26ComboOrganisationAddressCountry ;
      private string A20OrganisationTypeName ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z20OrganisationTypeName ;
      private Guid wcpOAV7OrganisationId ;
      private Guid Z11OrganisationId ;
      private Guid Z19OrganisationTypeId ;
      private Guid N19OrganisationTypeId ;
      private Guid A19OrganisationTypeId ;
      private Guid AV7OrganisationId ;
      private Guid AV20ComboOrganisationTypeId ;
      private Guid A11OrganisationId ;
      private Guid AV13Insert_OrganisationTypeId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_organisationtypeid ;
      private GXUserControl ucCombo_organisationaddresscountry ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15OrganisationTypeId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25OrganisationAddressCountry_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00014_A20OrganisationTypeName ;
      private Guid[] T00015_A11OrganisationId ;
      private string[] T00015_A331OrganisationAddressCountry ;
      private string[] T00015_A13OrganisationName ;
      private string[] T00015_A12OrganisationKvkNumber ;
      private string[] T00015_A16OrganisationEmail ;
      private string[] T00015_A17OrganisationPhone ;
      private int[] T00015_A18OrganisationVATNumber ;
      private string[] T00015_A289OrganisationAddressCity ;
      private string[] T00015_A288OrganisationAddressZipCode ;
      private string[] T00015_A342OrganisationAddressLine1 ;
      private string[] T00015_A343OrganisationAddressLine2 ;
      private string[] T00015_A20OrganisationTypeName ;
      private Guid[] T00015_A19OrganisationTypeId ;
      private string[] T00016_A20OrganisationTypeName ;
      private Guid[] T00017_A11OrganisationId ;
      private Guid[] T00013_A11OrganisationId ;
      private string[] T00013_A331OrganisationAddressCountry ;
      private string[] T00013_A13OrganisationName ;
      private string[] T00013_A12OrganisationKvkNumber ;
      private string[] T00013_A16OrganisationEmail ;
      private string[] T00013_A17OrganisationPhone ;
      private int[] T00013_A18OrganisationVATNumber ;
      private string[] T00013_A289OrganisationAddressCity ;
      private string[] T00013_A288OrganisationAddressZipCode ;
      private string[] T00013_A342OrganisationAddressLine1 ;
      private string[] T00013_A343OrganisationAddressLine2 ;
      private Guid[] T00013_A19OrganisationTypeId ;
      private Guid[] T00018_A11OrganisationId ;
      private Guid[] T00019_A11OrganisationId ;
      private Guid[] T00012_A11OrganisationId ;
      private string[] T00012_A331OrganisationAddressCountry ;
      private string[] T00012_A13OrganisationName ;
      private string[] T00012_A12OrganisationKvkNumber ;
      private string[] T00012_A16OrganisationEmail ;
      private string[] T00012_A17OrganisationPhone ;
      private int[] T00012_A18OrganisationVATNumber ;
      private string[] T00012_A289OrganisationAddressCity ;
      private string[] T00012_A288OrganisationAddressZipCode ;
      private string[] T00012_A342OrganisationAddressLine1 ;
      private string[] T00012_A343OrganisationAddressLine2 ;
      private Guid[] T00012_A19OrganisationTypeId ;
      private string[] T000113_A20OrganisationTypeName ;
      private Guid[] T000114_A100OrganisationSettingid ;
      private Guid[] T000115_A29LocationId ;
      private Guid[] T000115_A11OrganisationId ;
      private Guid[] T000116_A21ManagerId ;
      private Guid[] T000116_A11OrganisationId ;
      private Guid[] T000117_A11OrganisationId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_organisation__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_organisation__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00012;
        prmT00012 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00013;
        prmT00013 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00014;
        prmT00014 = new Object[] {
        new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00015;
        prmT00015 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00016;
        prmT00016 = new Object[] {
        new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00017;
        prmT00017 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00018;
        prmT00018 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00019;
        prmT00019 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000110;
        prmT000110 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationAddressCountry",GXType.VarChar,100,0) ,
        new ParDef("OrganisationName",GXType.VarChar,100,0) ,
        new ParDef("OrganisationKvkNumber",GXType.VarChar,40,0) ,
        new ParDef("OrganisationEmail",GXType.VarChar,100,0) ,
        new ParDef("OrganisationPhone",GXType.Char,20,0) ,
        new ParDef("OrganisationVATNumber",GXType.Int32,8,0) ,
        new ParDef("OrganisationAddressCity",GXType.VarChar,100,0) ,
        new ParDef("OrganisationAddressZipCode",GXType.VarChar,100,0) ,
        new ParDef("OrganisationAddressLine1",GXType.VarChar,100,0) ,
        new ParDef("OrganisationAddressLine2",GXType.VarChar,100,0) ,
        new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000111;
        prmT000111 = new Object[] {
        new ParDef("OrganisationAddressCountry",GXType.VarChar,100,0) ,
        new ParDef("OrganisationName",GXType.VarChar,100,0) ,
        new ParDef("OrganisationKvkNumber",GXType.VarChar,40,0) ,
        new ParDef("OrganisationEmail",GXType.VarChar,100,0) ,
        new ParDef("OrganisationPhone",GXType.Char,20,0) ,
        new ParDef("OrganisationVATNumber",GXType.Int32,8,0) ,
        new ParDef("OrganisationAddressCity",GXType.VarChar,100,0) ,
        new ParDef("OrganisationAddressZipCode",GXType.VarChar,100,0) ,
        new ParDef("OrganisationAddressLine1",GXType.VarChar,100,0) ,
        new ParDef("OrganisationAddressLine2",GXType.VarChar,100,0) ,
        new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000112;
        prmT000112 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000113;
        prmT000113 = new Object[] {
        new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000114;
        prmT000114 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000115;
        prmT000115 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000116;
        prmT000116 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000117;
        prmT000117 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00012", "SELECT OrganisationId, OrganisationAddressCountry, OrganisationName, OrganisationKvkNumber, OrganisationEmail, OrganisationPhone, OrganisationVATNumber, OrganisationAddressCity, OrganisationAddressZipCode, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationTypeId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Organisation NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00013", "SELECT OrganisationId, OrganisationAddressCountry, OrganisationName, OrganisationKvkNumber, OrganisationEmail, OrganisationPhone, OrganisationVATNumber, OrganisationAddressCity, OrganisationAddressZipCode, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationTypeId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00014", "SELECT OrganisationTypeName FROM Trn_OrganisationType WHERE OrganisationTypeId = :OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00015", "SELECT TM1.OrganisationId, TM1.OrganisationAddressCountry, TM1.OrganisationName, TM1.OrganisationKvkNumber, TM1.OrganisationEmail, TM1.OrganisationPhone, TM1.OrganisationVATNumber, TM1.OrganisationAddressCity, TM1.OrganisationAddressZipCode, TM1.OrganisationAddressLine1, TM1.OrganisationAddressLine2, T2.OrganisationTypeName, TM1.OrganisationTypeId FROM (Trn_Organisation TM1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = TM1.OrganisationTypeId) WHERE TM1.OrganisationId = :OrganisationId ORDER BY TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00016", "SELECT OrganisationTypeName FROM Trn_OrganisationType WHERE OrganisationTypeId = :OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00017", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00018", "SELECT OrganisationId FROM Trn_Organisation WHERE ( OrganisationId > :OrganisationId) ORDER BY OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00019", "SELECT OrganisationId FROM Trn_Organisation WHERE ( OrganisationId < :OrganisationId) ORDER BY OrganisationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000110", "SAVEPOINT gxupdate;INSERT INTO Trn_Organisation(OrganisationId, OrganisationAddressCountry, OrganisationName, OrganisationKvkNumber, OrganisationEmail, OrganisationPhone, OrganisationVATNumber, OrganisationAddressCity, OrganisationAddressZipCode, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationTypeId) VALUES(:OrganisationId, :OrganisationAddressCountry, :OrganisationName, :OrganisationKvkNumber, :OrganisationEmail, :OrganisationPhone, :OrganisationVATNumber, :OrganisationAddressCity, :OrganisationAddressZipCode, :OrganisationAddressLine1, :OrganisationAddressLine2, :OrganisationTypeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000110)
           ,new CursorDef("T000111", "SAVEPOINT gxupdate;UPDATE Trn_Organisation SET OrganisationAddressCountry=:OrganisationAddressCountry, OrganisationName=:OrganisationName, OrganisationKvkNumber=:OrganisationKvkNumber, OrganisationEmail=:OrganisationEmail, OrganisationPhone=:OrganisationPhone, OrganisationVATNumber=:OrganisationVATNumber, OrganisationAddressCity=:OrganisationAddressCity, OrganisationAddressZipCode=:OrganisationAddressZipCode, OrganisationAddressLine1=:OrganisationAddressLine1, OrganisationAddressLine2=:OrganisationAddressLine2, OrganisationTypeId=:OrganisationTypeId  WHERE OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000111)
           ,new CursorDef("T000112", "SAVEPOINT gxupdate;DELETE FROM Trn_Organisation  WHERE OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000112)
           ,new CursorDef("T000113", "SELECT OrganisationTypeName FROM Trn_OrganisationType WHERE OrganisationTypeId = :OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000114", "SELECT OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000115", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000115,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000116", "SELECT ManagerId, OrganisationId FROM Trn_Manager WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000116,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000117", "SELECT OrganisationId FROM Trn_Organisation ORDER BY OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000117,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((Guid[]) buf[11])[0] = rslt.getGuid(12);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((Guid[]) buf[11])[0] = rslt.getGuid(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((Guid[]) buf[12])[0] = rslt.getGuid(13);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 15 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}