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
   public class trn_locationdynamicform : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"WWPFORMLATESTVERSIONNUMBER") == 0 )
         {
            A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAWWPFORMLATESTVERSIONNUMBER1B79( A206WWPFormId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A206WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A206WWPFormId, A207WWPFormVersionNumber) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Location Dynamic Form", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLocationDynamicFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_locationdynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_locationdynamicform( IGxContext context )
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
         chkWWPFormIsWizard = new GXCheckbox();
         cmbWWPFormResume = new GXCombobox();
         chkWWPFormInstantiated = new GXCheckbox();
         cmbWWPFormType = new GXCombobox();
         chkWWPFormIsForDynamicValidations = new GXCheckbox();
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
            return "trn_loacationdynamicform_Execute" ;
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
         A232WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A232WWPFormIsWizard));
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         if ( cmbWWPFormResume.ItemCount > 0 )
         {
            A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
            AssignProp("", false, cmbWWPFormResume_Internalname, "Values", cmbWWPFormResume.ToJavascriptSource(), true);
         }
         A234WWPFormInstantiated = StringUtil.StrToBool( StringUtil.BoolToStr( A234WWPFormInstantiated));
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AssignProp("", false, cmbWWPFormType_Internalname, "Values", cmbWWPFormType.ToJavascriptSource(), true);
         }
         A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_Location Dynamic Form", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_LocationDynamicForm.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_LocationDynamicForm.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationDynamicFormId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationDynamicFormId_Internalname, context.GetMessage( "Form Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationDynamicFormId_Internalname, A395LocationDynamicFormId.ToString(), A395LocationDynamicFormId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationDynamicFormId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationDynamicFormId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationId_Internalname, context.GetMessage( "Organisation Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_LocationDynamicForm.htm");
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
         GxWebStd.gx_label_element( context, edtLocationId_Internalname, context.GetMessage( "Location Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormId_Internalname, context.GetMessage( "WWPForm Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormId_Enabled!=0) ? context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9") : context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormVersionNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormVersionNumber_Internalname, context.GetMessage( "WWPForm Version Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormVersionNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormVersionNumber_Enabled!=0) ? context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9") : context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormVersionNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormVersionNumber_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormReferenceName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormReferenceName_Internalname, context.GetMessage( "WWPForm Reference Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormReferenceName_Internalname, A208WWPFormReferenceName, StringUtil.RTrim( context.localUtil.Format( A208WWPFormReferenceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormReferenceName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormReferenceName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormTitle_Internalname, context.GetMessage( "WWPForm Title", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormTitle_Internalname, A209WWPFormTitle, StringUtil.RTrim( context.localUtil.Format( A209WWPFormTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormDate_Internalname, context.GetMessage( "WWPForm Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPFormDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPFormDate_Internalname, context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A231WWPFormDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormDate_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_bitmap( context, edtWWPFormDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPFormDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trn_LocationDynamicForm.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPFormIsWizard_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPFormIsWizard_Internalname, context.GetMessage( "WWPForm Is Wizard", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormIsWizard_Internalname, StringUtil.BoolToStr( A232WWPFormIsWizard), "", context.GetMessage( "WWPForm Is Wizard", ""), 1, chkWWPFormIsWizard.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPFormResume_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPFormResume_Internalname, context.GetMessage( "WWPForm Resume", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormResume, cmbWWPFormResume_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0)), 1, cmbWWPFormResume_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPFormResume.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_Trn_LocationDynamicForm.htm");
         cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         AssignProp("", false, cmbWWPFormResume_Internalname, "Values", (string)(cmbWWPFormResume.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormResumeMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormResumeMessage_Internalname, context.GetMessage( "WWPForm Resume Message", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPFormResumeMessage_Internalname, A235WWPFormResumeMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", 0, 1, edtWWPFormResumeMessage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormValidations_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormValidations_Internalname, context.GetMessage( "WWPForm Validations", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPFormValidations_Internalname, A233WWPFormValidations, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", 0, 1, edtWWPFormValidations_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPFormInstantiated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPFormInstantiated_Internalname, context.GetMessage( "WWPForm Instantiated", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormInstantiated_Internalname, StringUtil.BoolToStr( A234WWPFormInstantiated), "", context.GetMessage( "WWPForm Instantiated", ""), 1, chkWWPFormInstantiated.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(94, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,94);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormLatestVersionNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormLatestVersionNumber_Internalname, context.GetMessage( "WWPForm Latest Version Number", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPFormLatestVersionNumber_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWWPFormLatestVersionNumber_Enabled!=0) ? context.localUtil.Format( (decimal)(A219WWPFormLatestVersionNumber), "ZZZ9") : context.localUtil.Format( (decimal)(A219WWPFormLatestVersionNumber), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPFormLatestVersionNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPFormLatestVersionNumber_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPFormType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPFormType_Internalname, context.GetMessage( "WWPForm Type", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormType, cmbWWPFormType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0)), 1, cmbWWPFormType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPFormType.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "", true, 0, "HLP_Trn_LocationDynamicForm.htm");
         cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         AssignProp("", false, cmbWWPFormType_Internalname, "Values", (string)(cmbWWPFormType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPFormSectionRefElements_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPFormSectionRefElements_Internalname, context.GetMessage( "WWPForm Section Ref Elements", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPFormSectionRefElements_Internalname, A241WWPFormSectionRefElements, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", 0, 1, edtWWPFormSectionRefElements_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPFormIsForDynamicValidations_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPFormIsForDynamicValidations_Internalname, context.GetMessage( "WWPForm Is For Dynamic Validations", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPFormIsForDynamicValidations_Internalname, StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations), "", context.GetMessage( "WWPForm Is For Dynamic Validations", ""), 1, chkWWPFormIsForDynamicValidations.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(114, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,114);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationDynamicForm.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_LocationDynamicForm.htm");
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
            Z395LocationDynamicFormId = StringUtil.StrToGuid( cgiGet( "Z395LocationDynamicFormId"));
            Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
            Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
            Z206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z206WWPFormId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z207WWPFormVersionNumber"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtLocationDynamicFormId_Internalname), "") == 0 )
            {
               A395LocationDynamicFormId = Guid.Empty;
               n395LocationDynamicFormId = false;
               AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
            }
            else
            {
               try
               {
                  A395LocationDynamicFormId = StringUtil.StrToGuid( cgiGet( edtLocationDynamicFormId_Internalname));
                  n395LocationDynamicFormId = false;
                  AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "LOCATIONDYNAMICFORMID");
                  AnyError = 1;
                  GX_FocusControl = edtLocationDynamicFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMID");
               AnyError = 1;
               GX_FocusControl = edtWWPFormId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A206WWPFormId = 0;
               AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            }
            else
            {
               A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPFORMVERSIONNUMBER");
               AnyError = 1;
               GX_FocusControl = edtWWPFormVersionNumber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A207WWPFormVersionNumber = 0;
               AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            }
            else
            {
               A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            }
            A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
            AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
            A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname));
            AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A232WWPFormIsWizard = StringUtil.StrToBool( cgiGet( chkWWPFormIsWizard_Internalname));
            AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
            cmbWWPFormResume.CurrentValue = cgiGet( cmbWWPFormResume_Internalname);
            A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormResume_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
            A235WWPFormResumeMessage = cgiGet( edtWWPFormResumeMessage_Internalname);
            AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
            A233WWPFormValidations = cgiGet( edtWWPFormValidations_Internalname);
            AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
            A234WWPFormInstantiated = StringUtil.StrToBool( cgiGet( chkWWPFormInstantiated_Internalname));
            AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
            A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormLatestVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
            cmbWWPFormType.CurrentValue = cgiGet( cmbWWPFormType_Internalname);
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A241WWPFormSectionRefElements = cgiGet( edtWWPFormSectionRefElements_Internalname);
            AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
            A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( cgiGet( chkWWPFormIsForDynamicValidations_Internalname));
            AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
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
               A395LocationDynamicFormId = StringUtil.StrToGuid( GetPar( "LocationDynamicFormId"));
               n395LocationDynamicFormId = false;
               AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
               A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A395LocationDynamicFormId) && ( Gx_BScreen == 0 ) )
               {
                  A395LocationDynamicFormId = Guid.NewGuid( );
                  n395LocationDynamicFormId = false;
                  AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
               }
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
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
               InitAll1B79( ) ;
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
         DisableAttributes1B79( ) ;
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

      protected void ResetCaption1B0( )
      {
      }

      protected void ZM1B79( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z206WWPFormId = T001B3_A206WWPFormId[0];
               Z207WWPFormVersionNumber = T001B3_A207WWPFormVersionNumber[0];
            }
            else
            {
               Z206WWPFormId = A206WWPFormId;
               Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            }
         }
         if ( GX_JID == -6 )
         {
            Z395LocationDynamicFormId = A395LocationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z208WWPFormReferenceName = A208WWPFormReferenceName;
            Z209WWPFormTitle = A209WWPFormTitle;
            Z231WWPFormDate = A231WWPFormDate;
            Z232WWPFormIsWizard = A232WWPFormIsWizard;
            Z216WWPFormResume = A216WWPFormResume;
            Z235WWPFormResumeMessage = A235WWPFormResumeMessage;
            Z233WWPFormValidations = A233WWPFormValidations;
            Z234WWPFormInstantiated = A234WWPFormInstantiated;
            Z240WWPFormType = A240WWPFormType;
            Z241WWPFormSectionRefElements = A241WWPFormSectionRefElements;
            Z242WWPFormIsForDynamicValidations = A242WWPFormIsForDynamicValidations;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A395LocationDynamicFormId) && ( Gx_BScreen == 0 ) )
         {
            A395LocationDynamicFormId = Guid.NewGuid( );
            n395LocationDynamicFormId = false;
            AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
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

      protected void Load1B79( )
      {
         /* Using cursor T001B6 */
         pr_default.execute(4, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound79 = 1;
            A208WWPFormReferenceName = T001B6_A208WWPFormReferenceName[0];
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A209WWPFormTitle = T001B6_A209WWPFormTitle[0];
            AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
            A231WWPFormDate = T001B6_A231WWPFormDate[0];
            AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A232WWPFormIsWizard = T001B6_A232WWPFormIsWizard[0];
            AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
            A216WWPFormResume = T001B6_A216WWPFormResume[0];
            AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
            A235WWPFormResumeMessage = T001B6_A235WWPFormResumeMessage[0];
            AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
            A233WWPFormValidations = T001B6_A233WWPFormValidations[0];
            AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
            A234WWPFormInstantiated = T001B6_A234WWPFormInstantiated[0];
            AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
            A240WWPFormType = T001B6_A240WWPFormType[0];
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A241WWPFormSectionRefElements = T001B6_A241WWPFormSectionRefElements[0];
            AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
            A242WWPFormIsForDynamicValidations = T001B6_A242WWPFormIsForDynamicValidations[0];
            AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
            A206WWPFormId = T001B6_A206WWPFormId[0];
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T001B6_A207WWPFormVersionNumber[0];
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            ZM1B79( -6) ;
         }
         pr_default.close(4);
         OnLoadActions1B79( ) ;
      }

      protected void OnLoadActions1B79( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
      }

      protected void CheckExtendedTable1B79( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001B4 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001B5 */
         pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A208WWPFormReferenceName = T001B5_A208WWPFormReferenceName[0];
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         A209WWPFormTitle = T001B5_A209WWPFormTitle[0];
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         A231WWPFormDate = T001B5_A231WWPFormDate[0];
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A232WWPFormIsWizard = T001B5_A232WWPFormIsWizard[0];
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         A216WWPFormResume = T001B5_A216WWPFormResume[0];
         AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         A235WWPFormResumeMessage = T001B5_A235WWPFormResumeMessage[0];
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         A233WWPFormValidations = T001B5_A233WWPFormValidations[0];
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         A234WWPFormInstantiated = T001B5_A234WWPFormInstantiated[0];
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         A240WWPFormType = T001B5_A240WWPFormType[0];
         AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         A241WWPFormSectionRefElements = T001B5_A241WWPFormSectionRefElements[0];
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         A242WWPFormIsForDynamicValidations = T001B5_A242WWPFormIsForDynamicValidations[0];
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         pr_default.close(3);
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
      }

      protected void CloseExtendedTableCursors1B79( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( Guid A29LocationId ,
                               Guid A11OrganisationId )
      {
         /* Using cursor T001B7 */
         pr_default.execute(5, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_8( short A206WWPFormId ,
                               short A207WWPFormVersionNumber )
      {
         /* Using cursor T001B8 */
         pr_default.execute(6, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A208WWPFormReferenceName = T001B8_A208WWPFormReferenceName[0];
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         A209WWPFormTitle = T001B8_A209WWPFormTitle[0];
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         A231WWPFormDate = T001B8_A231WWPFormDate[0];
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A232WWPFormIsWizard = T001B8_A232WWPFormIsWizard[0];
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         A216WWPFormResume = T001B8_A216WWPFormResume[0];
         AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         A235WWPFormResumeMessage = T001B8_A235WWPFormResumeMessage[0];
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         A233WWPFormValidations = T001B8_A233WWPFormValidations[0];
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         A234WWPFormInstantiated = T001B8_A234WWPFormInstantiated[0];
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         A240WWPFormType = T001B8_A240WWPFormType[0];
         AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         A241WWPFormSectionRefElements = T001B8_A241WWPFormSectionRefElements[0];
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         A242WWPFormIsForDynamicValidations = T001B8_A242WWPFormIsForDynamicValidations[0];
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A208WWPFormReferenceName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A209WWPFormTitle)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A232WWPFormIsWizard))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A235WWPFormResumeMessage)+"\""+","+"\""+GXUtil.EncodeJSConstant( A233WWPFormValidations)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A234WWPFormInstantiated))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A240WWPFormType), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A241WWPFormSectionRefElements)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1B79( )
      {
         /* Using cursor T001B9 */
         pr_default.execute(7, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound79 = 1;
         }
         else
         {
            RcdFound79 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001B3 */
         pr_default.execute(1, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1B79( 6) ;
            RcdFound79 = 1;
            A395LocationDynamicFormId = T001B3_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = T001B3_n395LocationDynamicFormId[0];
            AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
            A11OrganisationId = T001B3_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T001B3_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A206WWPFormId = T001B3_A206WWPFormId[0];
            AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
            A207WWPFormVersionNumber = T001B3_A207WWPFormVersionNumber[0];
            AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
            Z395LocationDynamicFormId = A395LocationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1B79( ) ;
            if ( AnyError == 1 )
            {
               RcdFound79 = 0;
               InitializeNonKey1B79( ) ;
            }
            Gx_mode = sMode79;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound79 = 0;
            InitializeNonKey1B79( ) ;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode79;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1B79( ) ;
         if ( RcdFound79 == 0 )
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
         RcdFound79 = 0;
         /* Using cursor T001B10 */
         pr_default.execute(8, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001B10_A395LocationDynamicFormId[0], A395LocationDynamicFormId, 0) < 0 ) || ( T001B10_A395LocationDynamicFormId[0] == A395LocationDynamicFormId ) && ( GuidUtil.Compare(T001B10_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) || ( T001B10_A11OrganisationId[0] == A11OrganisationId ) && ( T001B10_A395LocationDynamicFormId[0] == A395LocationDynamicFormId ) && ( GuidUtil.Compare(T001B10_A29LocationId[0], A29LocationId, 0) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001B10_A395LocationDynamicFormId[0], A395LocationDynamicFormId, 0) > 0 ) || ( T001B10_A395LocationDynamicFormId[0] == A395LocationDynamicFormId ) && ( GuidUtil.Compare(T001B10_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) || ( T001B10_A11OrganisationId[0] == A11OrganisationId ) && ( T001B10_A395LocationDynamicFormId[0] == A395LocationDynamicFormId ) && ( GuidUtil.Compare(T001B10_A29LocationId[0], A29LocationId, 0) > 0 ) ) )
            {
               A395LocationDynamicFormId = T001B10_A395LocationDynamicFormId[0];
               n395LocationDynamicFormId = T001B10_n395LocationDynamicFormId[0];
               AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
               A11OrganisationId = T001B10_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               A29LocationId = T001B10_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               RcdFound79 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound79 = 0;
         /* Using cursor T001B11 */
         pr_default.execute(9, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001B11_A395LocationDynamicFormId[0], A395LocationDynamicFormId, 0) > 0 ) || ( T001B11_A395LocationDynamicFormId[0] == A395LocationDynamicFormId ) && ( GuidUtil.Compare(T001B11_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) || ( T001B11_A11OrganisationId[0] == A11OrganisationId ) && ( T001B11_A395LocationDynamicFormId[0] == A395LocationDynamicFormId ) && ( GuidUtil.Compare(T001B11_A29LocationId[0], A29LocationId, 0) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T001B11_A395LocationDynamicFormId[0], A395LocationDynamicFormId, 0) < 0 ) || ( T001B11_A395LocationDynamicFormId[0] == A395LocationDynamicFormId ) && ( GuidUtil.Compare(T001B11_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) || ( T001B11_A11OrganisationId[0] == A11OrganisationId ) && ( T001B11_A395LocationDynamicFormId[0] == A395LocationDynamicFormId ) && ( GuidUtil.Compare(T001B11_A29LocationId[0], A29LocationId, 0) < 0 ) ) )
            {
               A395LocationDynamicFormId = T001B11_A395LocationDynamicFormId[0];
               n395LocationDynamicFormId = T001B11_n395LocationDynamicFormId[0];
               AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
               A11OrganisationId = T001B11_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               A29LocationId = T001B11_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               RcdFound79 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1B79( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLocationDynamicFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1B79( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound79 == 1 )
            {
               if ( ( A395LocationDynamicFormId != Z395LocationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
               {
                  A395LocationDynamicFormId = Z395LocationDynamicFormId;
                  n395LocationDynamicFormId = false;
                  AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
                  A11OrganisationId = Z11OrganisationId;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  A29LocationId = Z29LocationId;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LOCATIONDYNAMICFORMID");
                  AnyError = 1;
                  GX_FocusControl = edtLocationDynamicFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLocationDynamicFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1B79( ) ;
                  GX_FocusControl = edtLocationDynamicFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A395LocationDynamicFormId != Z395LocationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLocationDynamicFormId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1B79( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LOCATIONDYNAMICFORMID");
                     AnyError = 1;
                     GX_FocusControl = edtLocationDynamicFormId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLocationDynamicFormId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1B79( ) ;
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
         if ( ( A395LocationDynamicFormId != Z395LocationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
         {
            A395LocationDynamicFormId = Z395LocationDynamicFormId;
            n395LocationDynamicFormId = false;
            AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
            A11OrganisationId = Z11OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = Z29LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LOCATIONDYNAMICFORMID");
            AnyError = 1;
            GX_FocusControl = edtLocationDynamicFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLocationDynamicFormId_Internalname;
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
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LOCATIONDYNAMICFORMID");
            AnyError = 1;
            GX_FocusControl = edtLocationDynamicFormId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPFormId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1B79( ) ;
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1B79( ) ;
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
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormId_Internalname;
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
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormId_Internalname;
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
         ScanStart1B79( ) ;
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound79 != 0 )
            {
               ScanNext1B79( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPFormId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1B79( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1B79( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001B2 */
            pr_default.execute(0, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_LocationDynamicForm"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z206WWPFormId != T001B2_A206WWPFormId[0] ) || ( Z207WWPFormVersionNumber != T001B2_A207WWPFormVersionNumber[0] ) )
            {
               if ( Z206WWPFormId != T001B2_A206WWPFormId[0] )
               {
                  GXUtil.WriteLog("trn_locationdynamicform:[seudo value changed for attri]"+"WWPFormId");
                  GXUtil.WriteLogRaw("Old: ",Z206WWPFormId);
                  GXUtil.WriteLogRaw("Current: ",T001B2_A206WWPFormId[0]);
               }
               if ( Z207WWPFormVersionNumber != T001B2_A207WWPFormVersionNumber[0] )
               {
                  GXUtil.WriteLog("trn_locationdynamicform:[seudo value changed for attri]"+"WWPFormVersionNumber");
                  GXUtil.WriteLogRaw("Old: ",Z207WWPFormVersionNumber);
                  GXUtil.WriteLogRaw("Current: ",T001B2_A207WWPFormVersionNumber[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_LocationDynamicForm"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1B79( )
      {
         if ( ! IsAuthorized("trn_loacationdynamicform_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1B79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B79( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1B79( 0) ;
            CheckOptimisticConcurrency1B79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1B79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001B12 */
                     pr_default.execute(10, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId, A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_LocationDynamicForm");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption1B0( ) ;
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
               Load1B79( ) ;
            }
            EndLevel1B79( ) ;
         }
         CloseExtendedTableCursors1B79( ) ;
      }

      protected void Update1B79( )
      {
         if ( ! IsAuthorized("trn_loacationdynamicform_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1B79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B79( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1B79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001B13 */
                     pr_default.execute(11, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_LocationDynamicForm");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_LocationDynamicForm"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1B79( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1B0( ) ;
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
            EndLevel1B79( ) ;
         }
         CloseExtendedTableCursors1B79( ) ;
      }

      protected void DeferredUpdate1B79( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_loacationdynamicform_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1B79( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B79( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1B79( ) ;
            AfterConfirm1B79( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1B79( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001B14 */
                  pr_default.execute(12, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_LocationDynamicForm");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound79 == 0 )
                        {
                           InitAll1B79( ) ;
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
                        ResetCaption1B0( ) ;
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
         sMode79 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1B79( ) ;
         Gx_mode = sMode79;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1B79( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
            /* Using cursor T001B15 */
            pr_default.execute(13, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = T001B15_A208WWPFormReferenceName[0];
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            A209WWPFormTitle = T001B15_A209WWPFormTitle[0];
            AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
            A231WWPFormDate = T001B15_A231WWPFormDate[0];
            AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A232WWPFormIsWizard = T001B15_A232WWPFormIsWizard[0];
            AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
            A216WWPFormResume = T001B15_A216WWPFormResume[0];
            AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
            A235WWPFormResumeMessage = T001B15_A235WWPFormResumeMessage[0];
            AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
            A233WWPFormValidations = T001B15_A233WWPFormValidations[0];
            AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
            A234WWPFormInstantiated = T001B15_A234WWPFormInstantiated[0];
            AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
            A240WWPFormType = T001B15_A240WWPFormType[0];
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A241WWPFormSectionRefElements = T001B15_A241WWPFormSectionRefElements[0];
            AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
            A242WWPFormIsForDynamicValidations = T001B15_A242WWPFormIsForDynamicValidations[0];
            AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001B16 */
            pr_default.execute(14, new Object[] {n395LocationDynamicFormId, A395LocationDynamicFormId, A11OrganisationId, A29LocationId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_CallToAction", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel1B79( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1B79( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_locationdynamicform",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_locationdynamicform",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1B79( )
      {
         /* Using cursor T001B17 */
         pr_default.execute(15);
         RcdFound79 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound79 = 1;
            A395LocationDynamicFormId = T001B17_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = T001B17_n395LocationDynamicFormId[0];
            AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
            A11OrganisationId = T001B17_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T001B17_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1B79( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound79 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound79 = 1;
            A395LocationDynamicFormId = T001B17_A395LocationDynamicFormId[0];
            n395LocationDynamicFormId = T001B17_n395LocationDynamicFormId[0];
            AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
            A11OrganisationId = T001B17_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T001B17_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
      }

      protected void ScanEnd1B79( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1B79( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1B79( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1B79( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1B79( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1B79( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1B79( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1B79( )
      {
         edtLocationDynamicFormId_Enabled = 0;
         AssignProp("", false, edtLocationDynamicFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationDynamicFormId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtWWPFormId_Enabled = 0;
         AssignProp("", false, edtWWPFormId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormId_Enabled), 5, 0), true);
         edtWWPFormVersionNumber_Enabled = 0;
         AssignProp("", false, edtWWPFormVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Enabled), 5, 0), true);
         edtWWPFormReferenceName_Enabled = 0;
         AssignProp("", false, edtWWPFormReferenceName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormReferenceName_Enabled), 5, 0), true);
         edtWWPFormTitle_Enabled = 0;
         AssignProp("", false, edtWWPFormTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Enabled), 5, 0), true);
         edtWWPFormDate_Enabled = 0;
         AssignProp("", false, edtWWPFormDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Enabled), 5, 0), true);
         chkWWPFormIsWizard.Enabled = 0;
         AssignProp("", false, chkWWPFormIsWizard_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormIsWizard.Enabled), 5, 0), true);
         cmbWWPFormResume.Enabled = 0;
         AssignProp("", false, cmbWWPFormResume_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormResume.Enabled), 5, 0), true);
         edtWWPFormResumeMessage_Enabled = 0;
         AssignProp("", false, edtWWPFormResumeMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormResumeMessage_Enabled), 5, 0), true);
         edtWWPFormValidations_Enabled = 0;
         AssignProp("", false, edtWWPFormValidations_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormValidations_Enabled), 5, 0), true);
         chkWWPFormInstantiated.Enabled = 0;
         AssignProp("", false, chkWWPFormInstantiated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormInstantiated.Enabled), 5, 0), true);
         edtWWPFormLatestVersionNumber_Enabled = 0;
         AssignProp("", false, edtWWPFormLatestVersionNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormLatestVersionNumber_Enabled), 5, 0), true);
         cmbWWPFormType.Enabled = 0;
         AssignProp("", false, cmbWWPFormType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Enabled), 5, 0), true);
         edtWWPFormSectionRefElements_Enabled = 0;
         AssignProp("", false, edtWWPFormSectionRefElements_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPFormSectionRefElements_Enabled), 5, 0), true);
         chkWWPFormIsForDynamicValidations.Enabled = 0;
         AssignProp("", false, chkWWPFormIsForDynamicValidations_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPFormIsForDynamicValidations.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1B79( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1B0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_locationdynamicform.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z395LocationDynamicFormId", Z395LocationDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("trn_locationdynamicform.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_LocationDynamicForm" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Location Dynamic Form", "") ;
      }

      protected void InitializeNonKey1B79( )
      {
         A219WWPFormLatestVersionNumber = 0;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         A206WWPFormId = 0;
         AssignAttri("", false, "A206WWPFormId", StringUtil.LTrimStr( (decimal)(A206WWPFormId), 4, 0));
         A207WWPFormVersionNumber = 0;
         AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(A207WWPFormVersionNumber), 4, 0));
         A208WWPFormReferenceName = "";
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         A209WWPFormTitle = "";
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A232WWPFormIsWizard = false;
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         A216WWPFormResume = 0;
         AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         A235WWPFormResumeMessage = "";
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         A233WWPFormValidations = "";
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         A234WWPFormInstantiated = false;
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         A240WWPFormType = 0;
         AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         A241WWPFormSectionRefElements = "";
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         A242WWPFormIsForDynamicValidations = false;
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         Z206WWPFormId = 0;
         Z207WWPFormVersionNumber = 0;
      }

      protected void InitAll1B79( )
      {
         A395LocationDynamicFormId = Guid.NewGuid( );
         n395LocationDynamicFormId = false;
         AssignAttri("", false, "A395LocationDynamicFormId", A395LocationDynamicFormId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         InitializeNonKey1B79( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024114973370", true, true);
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
         context.AddJavascriptSource("trn_locationdynamicform.js", "?2024114973370", false, true);
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
         edtLocationDynamicFormId_Internalname = "LOCATIONDYNAMICFORMID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtLocationId_Internalname = "LOCATIONID";
         edtWWPFormId_Internalname = "WWPFORMID";
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER";
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME";
         edtWWPFormTitle_Internalname = "WWPFORMTITLE";
         edtWWPFormDate_Internalname = "WWPFORMDATE";
         chkWWPFormIsWizard_Internalname = "WWPFORMISWIZARD";
         cmbWWPFormResume_Internalname = "WWPFORMRESUME";
         edtWWPFormResumeMessage_Internalname = "WWPFORMRESUMEMESSAGE";
         edtWWPFormValidations_Internalname = "WWPFORMVALIDATIONS";
         chkWWPFormInstantiated_Internalname = "WWPFORMINSTANTIATED";
         edtWWPFormLatestVersionNumber_Internalname = "WWPFORMLATESTVERSIONNUMBER";
         cmbWWPFormType_Internalname = "WWPFORMTYPE";
         edtWWPFormSectionRefElements_Internalname = "WWPFORMSECTIONREFELEMENTS";
         chkWWPFormIsForDynamicValidations_Internalname = "WWPFORMISFORDYNAMICVALIDATIONS";
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
         Form.Caption = context.GetMessage( "Trn_Location Dynamic Form", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPFormIsForDynamicValidations.Enabled = 0;
         edtWWPFormSectionRefElements_Enabled = 0;
         cmbWWPFormType_Jsonclick = "";
         cmbWWPFormType.Enabled = 0;
         edtWWPFormLatestVersionNumber_Jsonclick = "";
         edtWWPFormLatestVersionNumber_Enabled = 0;
         chkWWPFormInstantiated.Enabled = 0;
         edtWWPFormValidations_Enabled = 0;
         edtWWPFormResumeMessage_Enabled = 0;
         cmbWWPFormResume_Jsonclick = "";
         cmbWWPFormResume.Enabled = 0;
         chkWWPFormIsWizard.Enabled = 0;
         edtWWPFormDate_Jsonclick = "";
         edtWWPFormDate_Enabled = 0;
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormReferenceName_Jsonclick = "";
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormVersionNumber_Jsonclick = "";
         edtWWPFormVersionNumber_Enabled = 1;
         edtWWPFormId_Jsonclick = "";
         edtWWPFormId_Enabled = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtLocationDynamicFormId_Jsonclick = "";
         edtLocationDynamicFormId_Enabled = 1;
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

      protected void GX4ASAWWPFORMLATESTVERSIONNUMBER1B79( short A206WWPFormId )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")))+"\"") ;
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
         chkWWPFormIsWizard.Name = "WWPFORMISWIZARD";
         chkWWPFormIsWizard.WebTags = "";
         chkWWPFormIsWizard.Caption = context.GetMessage( "WWPForm Is Wizard", "");
         AssignProp("", false, chkWWPFormIsWizard_Internalname, "TitleCaption", chkWWPFormIsWizard.Caption, true);
         chkWWPFormIsWizard.CheckedValue = "false";
         A232WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A232WWPFormIsWizard));
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         cmbWWPFormResume.Name = "WWPFORMRESUME";
         cmbWWPFormResume.WebTags = "";
         cmbWWPFormResume.addItem("0", context.GetMessage( "WWP_DF_Resume_Never", ""), 0);
         cmbWWPFormResume.addItem("1", context.GetMessage( "WWP_DF_Resume_AskUser", ""), 0);
         cmbWWPFormResume.addItem("2", context.GetMessage( "WWP_DF_Resume_Always", ""), 0);
         if ( cmbWWPFormResume.ItemCount > 0 )
         {
            A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A216WWPFormResume", StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         }
         chkWWPFormInstantiated.Name = "WWPFORMINSTANTIATED";
         chkWWPFormInstantiated.WebTags = "";
         chkWWPFormInstantiated.Caption = context.GetMessage( "WWPForm Instantiated", "");
         AssignProp("", false, chkWWPFormInstantiated_Internalname, "TitleCaption", chkWWPFormInstantiated.Caption, true);
         chkWWPFormInstantiated.CheckedValue = "false";
         A234WWPFormInstantiated = StringUtil.StrToBool( StringUtil.BoolToStr( A234WWPFormInstantiated));
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         cmbWWPFormType.Name = "WWPFORMTYPE";
         cmbWWPFormType.WebTags = "";
         cmbWWPFormType.addItem("0", context.GetMessage( "WWP_DF_Type_DynamicForm", ""), 0);
         cmbWWPFormType.addItem("1", context.GetMessage( "WWP_DF_Type_DynamicSection", ""), 0);
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         }
         chkWWPFormIsForDynamicValidations.Name = "WWPFORMISFORDYNAMICVALIDATIONS";
         chkWWPFormIsForDynamicValidations.WebTags = "";
         chkWWPFormIsForDynamicValidations.Caption = context.GetMessage( "WWPForm Is For Dynamic Validations", "");
         AssignProp("", false, chkWWPFormIsForDynamicValidations_Internalname, "TitleCaption", chkWWPFormIsForDynamicValidations.Caption, true);
         chkWWPFormIsForDynamicValidations.CheckedValue = "false";
         A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T001B18 */
         pr_default.execute(16, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         GX_FocusControl = edtWWPFormId_Internalname;
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

      public void Valid_Locationid( )
      {
         A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         n395LocationDynamicFormId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001B18 */
         pr_default.execute(16, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtLocationId_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         A232WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A232WWPFormIsWizard));
         if ( cmbWWPFormResume.ItemCount > 0 )
         {
            A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         }
         A234WWPFormInstantiated = StringUtil.StrToBool( StringUtil.BoolToStr( A234WWPFormInstantiated));
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         }
         A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
         /*  Sending validation outputs */
         AssignAttri("", false, "A206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", "")));
         AssignAttri("", false, "A207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", "")));
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         AssignAttri("", false, "A216WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, ".", "")));
         cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         AssignProp("", false, cmbWWPFormResume_Internalname, "Values", cmbWWPFormResume.ToJavascriptSource(), true);
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         AssignAttri("", false, "A240WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A240WWPFormType), 1, 0, ".", "")));
         cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         AssignProp("", false, cmbWWPFormType_Internalname, "Values", cmbWWPFormType.ToJavascriptSource(), true);
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z395LocationDynamicFormId", Z395LocationDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z206WWPFormId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z206WWPFormId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z207WWPFormVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z207WWPFormVersionNumber), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z208WWPFormReferenceName", Z208WWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "Z209WWPFormTitle", Z209WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "Z231WWPFormDate", context.localUtil.TToC( Z231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z232WWPFormIsWizard", StringUtil.BoolToStr( Z232WWPFormIsWizard));
         GxWebStd.gx_hidden_field( context, "Z216WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z216WWPFormResume), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z235WWPFormResumeMessage", Z235WWPFormResumeMessage);
         GxWebStd.gx_hidden_field( context, "Z233WWPFormValidations", Z233WWPFormValidations);
         GxWebStd.gx_hidden_field( context, "Z234WWPFormInstantiated", StringUtil.BoolToStr( Z234WWPFormInstantiated));
         GxWebStd.gx_hidden_field( context, "Z240WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z240WWPFormType), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z241WWPFormSectionRefElements", Z241WWPFormSectionRefElements);
         GxWebStd.gx_hidden_field( context, "Z242WWPFormIsForDynamicValidations", StringUtil.BoolToStr( Z242WWPFormIsForDynamicValidations));
         GxWebStd.gx_hidden_field( context, "Z219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z219WWPFormLatestVersionNumber), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpformid( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", "")));
      }

      public void Valid_Wwpformversionnumber( )
      {
         A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         /* Using cursor T001B15 */
         pr_default.execute(13, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
            GX_FocusControl = edtWWPFormId_Internalname;
         }
         A208WWPFormReferenceName = T001B15_A208WWPFormReferenceName[0];
         A209WWPFormTitle = T001B15_A209WWPFormTitle[0];
         A231WWPFormDate = T001B15_A231WWPFormDate[0];
         A232WWPFormIsWizard = T001B15_A232WWPFormIsWizard[0];
         A216WWPFormResume = T001B15_A216WWPFormResume[0];
         cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         A235WWPFormResumeMessage = T001B15_A235WWPFormResumeMessage[0];
         A233WWPFormValidations = T001B15_A233WWPFormValidations[0];
         A234WWPFormInstantiated = T001B15_A234WWPFormInstantiated[0];
         A240WWPFormType = T001B15_A240WWPFormType[0];
         cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         A241WWPFormSectionRefElements = T001B15_A241WWPFormSectionRefElements[0];
         A242WWPFormIsForDynamicValidations = T001B15_A242WWPFormIsForDynamicValidations[0];
         pr_default.close(13);
         dynload_actions( ) ;
         A232WWPFormIsWizard = StringUtil.StrToBool( StringUtil.BoolToStr( A232WWPFormIsWizard));
         if ( cmbWWPFormResume.ItemCount > 0 )
         {
            A216WWPFormResume = (short)(Math.Round(NumberUtil.Val( cmbWWPFormResume.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormResume.CurrentValue = StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         }
         A234WWPFormInstantiated = StringUtil.StrToBool( StringUtil.BoolToStr( A234WWPFormInstantiated));
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPFormType.CurrentValue = StringUtil.Str( (decimal)(A240WWPFormType), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         }
         A242WWPFormIsForDynamicValidations = StringUtil.StrToBool( StringUtil.BoolToStr( A242WWPFormIsForDynamicValidations));
         /*  Sending validation outputs */
         AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
         AssignAttri("", false, "A209WWPFormTitle", A209WWPFormTitle);
         AssignAttri("", false, "A231WWPFormDate", context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A232WWPFormIsWizard", A232WWPFormIsWizard);
         AssignAttri("", false, "A216WWPFormResume", StringUtil.LTrim( StringUtil.NToC( (decimal)(A216WWPFormResume), 1, 0, ".", "")));
         cmbWWPFormResume.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A216WWPFormResume), 1, 0));
         AssignProp("", false, cmbWWPFormResume_Internalname, "Values", cmbWWPFormResume.ToJavascriptSource(), true);
         AssignAttri("", false, "A235WWPFormResumeMessage", A235WWPFormResumeMessage);
         AssignAttri("", false, "A233WWPFormValidations", A233WWPFormValidations);
         AssignAttri("", false, "A234WWPFormInstantiated", A234WWPFormInstantiated);
         AssignAttri("", false, "A240WWPFormType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A240WWPFormType), 1, 0, ".", "")));
         cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         AssignProp("", false, cmbWWPFormType_Internalname, "Values", cmbWWPFormType.ToJavascriptSource(), true);
         AssignAttri("", false, "A241WWPFormSectionRefElements", A241WWPFormSectionRefElements);
         AssignAttri("", false, "A242WWPFormIsForDynamicValidations", A242WWPFormIsForDynamicValidations);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_LOCATIONDYNAMICFORMID","""{"handler":"Valid_Locationdynamicformid","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_LOCATIONDYNAMICFORMID",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A395LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A231WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A235WWPFormResumeMessage","fld":"WWPFORMRESUMEMESSAGE"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z395LocationDynamicFormId"},{"av":"Z11OrganisationId"},{"av":"Z29LocationId"},{"av":"Z206WWPFormId"},{"av":"Z207WWPFormVersionNumber"},{"av":"Z208WWPFormReferenceName"},{"av":"Z209WWPFormTitle"},{"av":"Z231WWPFormDate"},{"av":"Z232WWPFormIsWizard"},{"av":"Z216WWPFormResume"},{"av":"Z235WWPFormResumeMessage"},{"av":"Z233WWPFormValidations"},{"av":"Z234WWPFormInstantiated"},{"av":"Z240WWPFormType"},{"av":"Z241WWPFormSectionRefElements"},{"av":"Z242WWPFormIsForDynamicValidations"},{"av":"Z219WWPFormLatestVersionNumber"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_WWPFORMID",""","oparms":[{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A231WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A235WWPFormResumeMessage","fld":"WWPFORMRESUMEMESSAGE"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER",""","oparms":[{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"},{"av":"A231WWPFormDate","fld":"WWPFORMDATE","pic":"99/99/99 99:99"},{"av":"cmbWWPFormResume"},{"av":"A216WWPFormResume","fld":"WWPFORMRESUME","pic":"9"},{"av":"A235WWPFormResumeMessage","fld":"WWPFORMRESUMEMESSAGE"},{"av":"A233WWPFormValidations","fld":"WWPFORMVALIDATIONS"},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A241WWPFormSectionRefElements","fld":"WWPFORMSECTIONREFELEMENTS"},{"av":"A232WWPFormIsWizard","fld":"WWPFORMISWIZARD"},{"av":"A234WWPFormInstantiated","fld":"WWPFORMINSTANTIATED"},{"av":"A242WWPFormIsForDynamicValidations","fld":"WWPFORMISFORDYNAMICVALIDATIONS"}]}""");
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
         pr_default.close(16);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z395LocationDynamicFormId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
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
         A395LocationDynamicFormId = Guid.Empty;
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         A235WWPFormResumeMessage = "";
         A233WWPFormValidations = "";
         A241WWPFormSectionRefElements = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z208WWPFormReferenceName = "";
         Z209WWPFormTitle = "";
         Z231WWPFormDate = (DateTime)(DateTime.MinValue);
         Z235WWPFormResumeMessage = "";
         Z233WWPFormValidations = "";
         Z241WWPFormSectionRefElements = "";
         T001B6_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T001B6_n395LocationDynamicFormId = new bool[] {false} ;
         T001B6_A208WWPFormReferenceName = new string[] {""} ;
         T001B6_A209WWPFormTitle = new string[] {""} ;
         T001B6_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001B6_A232WWPFormIsWizard = new bool[] {false} ;
         T001B6_A216WWPFormResume = new short[1] ;
         T001B6_A235WWPFormResumeMessage = new string[] {""} ;
         T001B6_A233WWPFormValidations = new string[] {""} ;
         T001B6_A234WWPFormInstantiated = new bool[] {false} ;
         T001B6_A240WWPFormType = new short[1] ;
         T001B6_A241WWPFormSectionRefElements = new string[] {""} ;
         T001B6_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001B6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001B6_A29LocationId = new Guid[] {Guid.Empty} ;
         T001B6_A206WWPFormId = new short[1] ;
         T001B6_A207WWPFormVersionNumber = new short[1] ;
         T001B4_A29LocationId = new Guid[] {Guid.Empty} ;
         T001B5_A208WWPFormReferenceName = new string[] {""} ;
         T001B5_A209WWPFormTitle = new string[] {""} ;
         T001B5_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001B5_A232WWPFormIsWizard = new bool[] {false} ;
         T001B5_A216WWPFormResume = new short[1] ;
         T001B5_A235WWPFormResumeMessage = new string[] {""} ;
         T001B5_A233WWPFormValidations = new string[] {""} ;
         T001B5_A234WWPFormInstantiated = new bool[] {false} ;
         T001B5_A240WWPFormType = new short[1] ;
         T001B5_A241WWPFormSectionRefElements = new string[] {""} ;
         T001B5_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001B7_A29LocationId = new Guid[] {Guid.Empty} ;
         T001B8_A208WWPFormReferenceName = new string[] {""} ;
         T001B8_A209WWPFormTitle = new string[] {""} ;
         T001B8_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001B8_A232WWPFormIsWizard = new bool[] {false} ;
         T001B8_A216WWPFormResume = new short[1] ;
         T001B8_A235WWPFormResumeMessage = new string[] {""} ;
         T001B8_A233WWPFormValidations = new string[] {""} ;
         T001B8_A234WWPFormInstantiated = new bool[] {false} ;
         T001B8_A240WWPFormType = new short[1] ;
         T001B8_A241WWPFormSectionRefElements = new string[] {""} ;
         T001B8_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001B9_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T001B9_n395LocationDynamicFormId = new bool[] {false} ;
         T001B9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001B9_A29LocationId = new Guid[] {Guid.Empty} ;
         T001B3_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T001B3_n395LocationDynamicFormId = new bool[] {false} ;
         T001B3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001B3_A29LocationId = new Guid[] {Guid.Empty} ;
         T001B3_A206WWPFormId = new short[1] ;
         T001B3_A207WWPFormVersionNumber = new short[1] ;
         sMode79 = "";
         T001B10_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T001B10_n395LocationDynamicFormId = new bool[] {false} ;
         T001B10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001B10_A29LocationId = new Guid[] {Guid.Empty} ;
         T001B11_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T001B11_n395LocationDynamicFormId = new bool[] {false} ;
         T001B11_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001B11_A29LocationId = new Guid[] {Guid.Empty} ;
         T001B2_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T001B2_n395LocationDynamicFormId = new bool[] {false} ;
         T001B2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001B2_A29LocationId = new Guid[] {Guid.Empty} ;
         T001B2_A206WWPFormId = new short[1] ;
         T001B2_A207WWPFormVersionNumber = new short[1] ;
         T001B15_A208WWPFormReferenceName = new string[] {""} ;
         T001B15_A209WWPFormTitle = new string[] {""} ;
         T001B15_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         T001B15_A232WWPFormIsWizard = new bool[] {false} ;
         T001B15_A216WWPFormResume = new short[1] ;
         T001B15_A235WWPFormResumeMessage = new string[] {""} ;
         T001B15_A233WWPFormValidations = new string[] {""} ;
         T001B15_A234WWPFormInstantiated = new bool[] {false} ;
         T001B15_A240WWPFormType = new short[1] ;
         T001B15_A241WWPFormSectionRefElements = new string[] {""} ;
         T001B15_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         T001B16_A367CallToActionId = new Guid[] {Guid.Empty} ;
         T001B17_A395LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         T001B17_n395LocationDynamicFormId = new bool[] {false} ;
         T001B17_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001B17_A29LocationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001B18_A29LocationId = new Guid[] {Guid.Empty} ;
         ZZ395LocationDynamicFormId = Guid.Empty;
         ZZ11OrganisationId = Guid.Empty;
         ZZ29LocationId = Guid.Empty;
         ZZ208WWPFormReferenceName = "";
         ZZ209WWPFormTitle = "";
         ZZ231WWPFormDate = (DateTime)(DateTime.MinValue);
         ZZ235WWPFormResumeMessage = "";
         ZZ233WWPFormValidations = "";
         ZZ241WWPFormSectionRefElements = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_locationdynamicform__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationdynamicform__default(),
            new Object[][] {
                new Object[] {
               T001B2_A395LocationDynamicFormId, T001B2_A11OrganisationId, T001B2_A29LocationId, T001B2_A206WWPFormId, T001B2_A207WWPFormVersionNumber
               }
               , new Object[] {
               T001B3_A395LocationDynamicFormId, T001B3_A11OrganisationId, T001B3_A29LocationId, T001B3_A206WWPFormId, T001B3_A207WWPFormVersionNumber
               }
               , new Object[] {
               T001B4_A29LocationId
               }
               , new Object[] {
               T001B5_A208WWPFormReferenceName, T001B5_A209WWPFormTitle, T001B5_A231WWPFormDate, T001B5_A232WWPFormIsWizard, T001B5_A216WWPFormResume, T001B5_A235WWPFormResumeMessage, T001B5_A233WWPFormValidations, T001B5_A234WWPFormInstantiated, T001B5_A240WWPFormType, T001B5_A241WWPFormSectionRefElements,
               T001B5_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T001B6_A395LocationDynamicFormId, T001B6_A208WWPFormReferenceName, T001B6_A209WWPFormTitle, T001B6_A231WWPFormDate, T001B6_A232WWPFormIsWizard, T001B6_A216WWPFormResume, T001B6_A235WWPFormResumeMessage, T001B6_A233WWPFormValidations, T001B6_A234WWPFormInstantiated, T001B6_A240WWPFormType,
               T001B6_A241WWPFormSectionRefElements, T001B6_A242WWPFormIsForDynamicValidations, T001B6_A11OrganisationId, T001B6_A29LocationId, T001B6_A206WWPFormId, T001B6_A207WWPFormVersionNumber
               }
               , new Object[] {
               T001B7_A29LocationId
               }
               , new Object[] {
               T001B8_A208WWPFormReferenceName, T001B8_A209WWPFormTitle, T001B8_A231WWPFormDate, T001B8_A232WWPFormIsWizard, T001B8_A216WWPFormResume, T001B8_A235WWPFormResumeMessage, T001B8_A233WWPFormValidations, T001B8_A234WWPFormInstantiated, T001B8_A240WWPFormType, T001B8_A241WWPFormSectionRefElements,
               T001B8_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T001B9_A395LocationDynamicFormId, T001B9_A11OrganisationId, T001B9_A29LocationId
               }
               , new Object[] {
               T001B10_A395LocationDynamicFormId, T001B10_A11OrganisationId, T001B10_A29LocationId
               }
               , new Object[] {
               T001B11_A395LocationDynamicFormId, T001B11_A11OrganisationId, T001B11_A29LocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001B15_A208WWPFormReferenceName, T001B15_A209WWPFormTitle, T001B15_A231WWPFormDate, T001B15_A232WWPFormIsWizard, T001B15_A216WWPFormResume, T001B15_A235WWPFormResumeMessage, T001B15_A233WWPFormValidations, T001B15_A234WWPFormInstantiated, T001B15_A240WWPFormType, T001B15_A241WWPFormSectionRefElements,
               T001B15_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               T001B16_A367CallToActionId
               }
               , new Object[] {
               T001B17_A395LocationDynamicFormId, T001B17_A11OrganisationId, T001B17_A29LocationId
               }
               , new Object[] {
               T001B18_A29LocationId
               }
            }
         );
         Z395LocationDynamicFormId = Guid.NewGuid( );
         n395LocationDynamicFormId = false;
         A395LocationDynamicFormId = Guid.NewGuid( );
         n395LocationDynamicFormId = false;
      }

      private short Z206WWPFormId ;
      private short Z207WWPFormVersionNumber ;
      private short GxWebError ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A216WWPFormResume ;
      private short A240WWPFormType ;
      private short A219WWPFormLatestVersionNumber ;
      private short Gx_BScreen ;
      private short Z216WWPFormResume ;
      private short Z240WWPFormType ;
      private short RcdFound79 ;
      private short gxajaxcallmode ;
      private short Z219WWPFormLatestVersionNumber ;
      private short ZZ206WWPFormId ;
      private short ZZ207WWPFormVersionNumber ;
      private short ZZ216WWPFormResume ;
      private short ZZ240WWPFormType ;
      private short ZZ219WWPFormLatestVersionNumber ;
      private short GXt_int1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLocationDynamicFormId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int edtWWPFormDate_Enabled ;
      private int edtWWPFormResumeMessage_Enabled ;
      private int edtWWPFormValidations_Enabled ;
      private int edtWWPFormLatestVersionNumber_Enabled ;
      private int edtWWPFormSectionRefElements_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLocationDynamicFormId_Internalname ;
      private string cmbWWPFormResume_Internalname ;
      private string cmbWWPFormType_Internalname ;
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
      private string edtLocationDynamicFormId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtWWPFormId_Internalname ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormReferenceName_Internalname ;
      private string edtWWPFormReferenceName_Jsonclick ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormTitle_Jsonclick ;
      private string edtWWPFormDate_Internalname ;
      private string edtWWPFormDate_Jsonclick ;
      private string chkWWPFormIsWizard_Internalname ;
      private string cmbWWPFormResume_Jsonclick ;
      private string edtWWPFormResumeMessage_Internalname ;
      private string edtWWPFormValidations_Internalname ;
      private string chkWWPFormInstantiated_Internalname ;
      private string edtWWPFormLatestVersionNumber_Internalname ;
      private string edtWWPFormLatestVersionNumber_Jsonclick ;
      private string cmbWWPFormType_Jsonclick ;
      private string edtWWPFormSectionRefElements_Internalname ;
      private string chkWWPFormIsForDynamicValidations_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode79 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime A231WWPFormDate ;
      private DateTime Z231WWPFormDate ;
      private DateTime ZZ231WWPFormDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A232WWPFormIsWizard ;
      private bool A234WWPFormInstantiated ;
      private bool A242WWPFormIsForDynamicValidations ;
      private bool n395LocationDynamicFormId ;
      private bool Z232WWPFormIsWizard ;
      private bool Z234WWPFormInstantiated ;
      private bool Z242WWPFormIsForDynamicValidations ;
      private bool ZZ232WWPFormIsWizard ;
      private bool ZZ234WWPFormInstantiated ;
      private bool ZZ242WWPFormIsForDynamicValidations ;
      private string A235WWPFormResumeMessage ;
      private string A233WWPFormValidations ;
      private string Z235WWPFormResumeMessage ;
      private string Z233WWPFormValidations ;
      private string ZZ235WWPFormResumeMessage ;
      private string ZZ233WWPFormValidations ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string A241WWPFormSectionRefElements ;
      private string Z208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string Z241WWPFormSectionRefElements ;
      private string ZZ208WWPFormReferenceName ;
      private string ZZ209WWPFormTitle ;
      private string ZZ241WWPFormSectionRefElements ;
      private Guid Z395LocationDynamicFormId ;
      private Guid Z11OrganisationId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A395LocationDynamicFormId ;
      private Guid ZZ395LocationDynamicFormId ;
      private Guid ZZ11OrganisationId ;
      private Guid ZZ29LocationId ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPFormIsWizard ;
      private GXCombobox cmbWWPFormResume ;
      private GXCheckbox chkWWPFormInstantiated ;
      private GXCombobox cmbWWPFormType ;
      private GXCheckbox chkWWPFormIsForDynamicValidations ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001B6_A395LocationDynamicFormId ;
      private bool[] T001B6_n395LocationDynamicFormId ;
      private string[] T001B6_A208WWPFormReferenceName ;
      private string[] T001B6_A209WWPFormTitle ;
      private DateTime[] T001B6_A231WWPFormDate ;
      private bool[] T001B6_A232WWPFormIsWizard ;
      private short[] T001B6_A216WWPFormResume ;
      private string[] T001B6_A235WWPFormResumeMessage ;
      private string[] T001B6_A233WWPFormValidations ;
      private bool[] T001B6_A234WWPFormInstantiated ;
      private short[] T001B6_A240WWPFormType ;
      private string[] T001B6_A241WWPFormSectionRefElements ;
      private bool[] T001B6_A242WWPFormIsForDynamicValidations ;
      private Guid[] T001B6_A11OrganisationId ;
      private Guid[] T001B6_A29LocationId ;
      private short[] T001B6_A206WWPFormId ;
      private short[] T001B6_A207WWPFormVersionNumber ;
      private Guid[] T001B4_A29LocationId ;
      private string[] T001B5_A208WWPFormReferenceName ;
      private string[] T001B5_A209WWPFormTitle ;
      private DateTime[] T001B5_A231WWPFormDate ;
      private bool[] T001B5_A232WWPFormIsWizard ;
      private short[] T001B5_A216WWPFormResume ;
      private string[] T001B5_A235WWPFormResumeMessage ;
      private string[] T001B5_A233WWPFormValidations ;
      private bool[] T001B5_A234WWPFormInstantiated ;
      private short[] T001B5_A240WWPFormType ;
      private string[] T001B5_A241WWPFormSectionRefElements ;
      private bool[] T001B5_A242WWPFormIsForDynamicValidations ;
      private Guid[] T001B7_A29LocationId ;
      private string[] T001B8_A208WWPFormReferenceName ;
      private string[] T001B8_A209WWPFormTitle ;
      private DateTime[] T001B8_A231WWPFormDate ;
      private bool[] T001B8_A232WWPFormIsWizard ;
      private short[] T001B8_A216WWPFormResume ;
      private string[] T001B8_A235WWPFormResumeMessage ;
      private string[] T001B8_A233WWPFormValidations ;
      private bool[] T001B8_A234WWPFormInstantiated ;
      private short[] T001B8_A240WWPFormType ;
      private string[] T001B8_A241WWPFormSectionRefElements ;
      private bool[] T001B8_A242WWPFormIsForDynamicValidations ;
      private Guid[] T001B9_A395LocationDynamicFormId ;
      private bool[] T001B9_n395LocationDynamicFormId ;
      private Guid[] T001B9_A11OrganisationId ;
      private Guid[] T001B9_A29LocationId ;
      private Guid[] T001B3_A395LocationDynamicFormId ;
      private bool[] T001B3_n395LocationDynamicFormId ;
      private Guid[] T001B3_A11OrganisationId ;
      private Guid[] T001B3_A29LocationId ;
      private short[] T001B3_A206WWPFormId ;
      private short[] T001B3_A207WWPFormVersionNumber ;
      private Guid[] T001B10_A395LocationDynamicFormId ;
      private bool[] T001B10_n395LocationDynamicFormId ;
      private Guid[] T001B10_A11OrganisationId ;
      private Guid[] T001B10_A29LocationId ;
      private Guid[] T001B11_A395LocationDynamicFormId ;
      private bool[] T001B11_n395LocationDynamicFormId ;
      private Guid[] T001B11_A11OrganisationId ;
      private Guid[] T001B11_A29LocationId ;
      private Guid[] T001B2_A395LocationDynamicFormId ;
      private bool[] T001B2_n395LocationDynamicFormId ;
      private Guid[] T001B2_A11OrganisationId ;
      private Guid[] T001B2_A29LocationId ;
      private short[] T001B2_A206WWPFormId ;
      private short[] T001B2_A207WWPFormVersionNumber ;
      private string[] T001B15_A208WWPFormReferenceName ;
      private string[] T001B15_A209WWPFormTitle ;
      private DateTime[] T001B15_A231WWPFormDate ;
      private bool[] T001B15_A232WWPFormIsWizard ;
      private short[] T001B15_A216WWPFormResume ;
      private string[] T001B15_A235WWPFormResumeMessage ;
      private string[] T001B15_A233WWPFormValidations ;
      private bool[] T001B15_A234WWPFormInstantiated ;
      private short[] T001B15_A240WWPFormType ;
      private string[] T001B15_A241WWPFormSectionRefElements ;
      private bool[] T001B15_A242WWPFormIsForDynamicValidations ;
      private Guid[] T001B16_A367CallToActionId ;
      private Guid[] T001B17_A395LocationDynamicFormId ;
      private bool[] T001B17_n395LocationDynamicFormId ;
      private Guid[] T001B17_A11OrganisationId ;
      private Guid[] T001B17_A29LocationId ;
      private Guid[] T001B18_A29LocationId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_locationdynamicform__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_locationdynamicform__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001B2;
        prmT001B2 = new Object[] {
        new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001B3;
        prmT001B3 = new Object[] {
        new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001B4;
        prmT001B4 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001B5;
        prmT001B5 = new Object[] {
        new ParDef("WWPFormId",GXType.Int16,4,0) ,
        new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
        };
        Object[] prmT001B6;
        prmT001B6 = new Object[] {
        new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001B7;
        prmT001B7 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001B8;
        prmT001B8 = new Object[] {
        new ParDef("WWPFormId",GXType.Int16,4,0) ,
        new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
        };
        Object[] prmT001B9;
        prmT001B9 = new Object[] {
        new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001B10;
        prmT001B10 = new Object[] {
        new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001B11;
        prmT001B11 = new Object[] {
        new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001B12;
        prmT001B12 = new Object[] {
        new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("WWPFormId",GXType.Int16,4,0) ,
        new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
        };
        Object[] prmT001B13;
        prmT001B13 = new Object[] {
        new ParDef("WWPFormId",GXType.Int16,4,0) ,
        new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
        new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001B14;
        prmT001B14 = new Object[] {
        new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001B15;
        prmT001B15 = new Object[] {
        new ParDef("WWPFormId",GXType.Int16,4,0) ,
        new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
        };
        Object[] prmT001B16;
        prmT001B16 = new Object[] {
        new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001B17;
        prmT001B17 = new Object[] {
        };
        Object[] prmT001B18;
        prmT001B18 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001B2", "SELECT LocationDynamicFormId, OrganisationId, LocationId, WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId  FOR UPDATE OF Trn_LocationDynamicForm NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B3", "SELECT LocationDynamicFormId, OrganisationId, LocationId, WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B4", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B5", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B6", "SELECT TM1.LocationDynamicFormId, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.LocationId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_LocationDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.LocationDynamicFormId = :LocationDynamicFormId and TM1.OrganisationId = :OrganisationId and TM1.LocationId = :LocationId ORDER BY TM1.LocationDynamicFormId, TM1.OrganisationId, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B7", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B8", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B9", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B10", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE ( LocationDynamicFormId > :LocationDynamicFormId or LocationDynamicFormId = :LocationDynamicFormId and OrganisationId > :OrganisationId or OrganisationId = :OrganisationId and LocationDynamicFormId = :LocationDynamicFormId and LocationId > :LocationId) ORDER BY LocationDynamicFormId, OrganisationId, LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B11", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE ( LocationDynamicFormId < :LocationDynamicFormId or LocationDynamicFormId = :LocationDynamicFormId and OrganisationId < :OrganisationId or OrganisationId = :OrganisationId and LocationDynamicFormId = :LocationDynamicFormId and LocationId < :LocationId) ORDER BY LocationDynamicFormId DESC, OrganisationId DESC, LocationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B12", "SAVEPOINT gxupdate;INSERT INTO Trn_LocationDynamicForm(LocationDynamicFormId, OrganisationId, LocationId, WWPFormId, WWPFormVersionNumber) VALUES(:LocationDynamicFormId, :OrganisationId, :LocationId, :WWPFormId, :WWPFormVersionNumber);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001B12)
           ,new CursorDef("T001B13", "SAVEPOINT gxupdate;UPDATE Trn_LocationDynamicForm SET WWPFormId=:WWPFormId, WWPFormVersionNumber=:WWPFormVersionNumber  WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001B13)
           ,new CursorDef("T001B14", "SAVEPOINT gxupdate;DELETE FROM Trn_LocationDynamicForm  WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001B14)
           ,new CursorDef("T001B15", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B16", "SELECT CallToActionId FROM Trn_CallToAction WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001B17", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm ORDER BY LocationDynamicFormId, OrganisationId, LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001B18", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B18,1, GxCacheFrequency.OFF ,true,false )
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
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((Guid[]) buf[12])[0] = rslt.getGuid(13);
              ((Guid[]) buf[13])[0] = rslt.getGuid(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 15 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 16 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
