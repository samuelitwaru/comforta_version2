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
   public class trn_receptionist : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action18") == 0 )
         {
            A93ReceptionistEmail = GetPar( "ReceptionistEmail");
            AssignAttri("", false, "A93ReceptionistEmail", A93ReceptionistEmail);
            A90ReceptionistGivenName = GetPar( "ReceptionistGivenName");
            AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
            A91ReceptionistLastName = GetPar( "ReceptionistLastName");
            AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_18_0C74( A93ReceptionistEmail, A90ReceptionistGivenName, A91ReceptionistLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action19") == 0 )
         {
            A90ReceptionistGivenName = GetPar( "ReceptionistGivenName");
            AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
            A91ReceptionistLastName = GetPar( "ReceptionistLastName");
            AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_19_0C74( A90ReceptionistGivenName, A91ReceptionistLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action20") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A95ReceptionistGAMGUID = GetPar( "ReceptionistGAMGUID");
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            A90ReceptionistGivenName = GetPar( "ReceptionistGivenName");
            AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
            A91ReceptionistLastName = GetPar( "ReceptionistLastName");
            AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_20_0C74( Gx_mode, A95ReceptionistGAMGUID, A90ReceptionistGivenName, A91ReceptionistLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action21") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A95ReceptionistGAMGUID = GetPar( "ReceptionistGAMGUID");
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_21_0C74( Gx_mode, A95ReceptionistGAMGUID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"LOCATIONID") == 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLALOCATIONID0C74( A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"ORGANISATIONID") == 0 )
         {
            AV21OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "AV21OrganisationId", AV21OrganisationId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV21OrganisationId, context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX7ASAORGANISATIONID0C74( AV21OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
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
            gxLoad_24( A29LocationId, A11OrganisationId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_receptionist.aspx")), "trn_receptionist.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_receptionist.aspx")))) ;
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
                  AV23ReceptionistId = StringUtil.StrToGuid( GetPar( "ReceptionistId"));
                  AssignAttri("", false, "AV23ReceptionistId", AV23ReceptionistId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vRECEPTIONISTID", GetSecureSignedToken( "", AV23ReceptionistId, context));
                  AV21OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "AV21OrganisationId", AV21OrganisationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV21OrganisationId, context));
                  AV19LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "AV19LocationId", AV19LocationId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV19LocationId, context));
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
         Form.Meta.addItem("description", "Receptionist", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_receptionist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_receptionist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_ReceptionistId ,
                           Guid aP2_OrganisationId ,
                           Guid aP3_LocationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV23ReceptionistId = aP1_ReceptionistId;
         this.AV21OrganisationId = aP2_OrganisationId;
         this.AV19LocationId = aP3_LocationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynLocationId = new GXCombobox();
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
            return "trn_receptionist_Execute" ;
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
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
            AssignProp("", false, dynLocationId_Internalname, "Values", dynLocationId.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynLocationId_Internalname, "Location", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynLocationId, dynLocationId_Internalname, A29LocationId.ToString(), 1, dynLocationId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "guid", "", 1, dynLocationId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_Trn_Receptionist.htm");
         dynLocationId.CurrentValue = A29LocationId.ToString();
         AssignProp("", false, dynLocationId_Internalname, "Values", (string)(dynLocationId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistGivenName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReceptionistGivenName_Internalname, "Given Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistGivenName_Internalname, A90ReceptionistGivenName, StringUtil.RTrim( context.localUtil.Format( A90ReceptionistGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistGivenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReceptionistGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistLastName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReceptionistLastName_Internalname, "Last Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistLastName_Internalname, A91ReceptionistLastName, StringUtil.RTrim( context.localUtil.Format( A91ReceptionistLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReceptionistLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReceptionistEmail_Internalname, "Email", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistEmail_Internalname, A93ReceptionistEmail, StringUtil.RTrim( context.localUtil.Format( A93ReceptionistEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A93ReceptionistEmail, "", "", "", edtReceptionistEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReceptionistEmail_Enabled, 1, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReceptionistPhone_Internalname, "Phone", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A94ReceptionistPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistPhone_Internalname, StringUtil.RTrim( A94ReceptionistPhone), StringUtil.RTrim( context.localUtil.Format( A94ReceptionistPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtReceptionistPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReceptionistPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_Receptionist.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Receptionist.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Receptionist.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistId_Internalname, A89ReceptionistId.ToString(), A89ReceptionistId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistId_Jsonclick, 0, "Attribute", "", "", "", "", edtReceptionistId_Visible, edtReceptionistId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Receptionist.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Receptionist.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistInitials_Internalname, StringUtil.RTrim( A92ReceptionistInitials), StringUtil.RTrim( context.localUtil.Format( A92ReceptionistInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistInitials_Jsonclick, 0, "Attribute", "", "", "", "", edtReceptionistInitials_Visible, edtReceptionistInitials_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Receptionist.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReceptionistGAMGUID_Internalname, A95ReceptionistGAMGUID, StringUtil.RTrim( context.localUtil.Format( A95ReceptionistGAMGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistGAMGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtReceptionistGAMGUID_Visible, edtReceptionistGAMGUID_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_Receptionist.htm");
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
         E110C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z89ReceptionistId = StringUtil.StrToGuid( cgiGet( "Z89ReceptionistId"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z95ReceptionistGAMGUID = cgiGet( "Z95ReceptionistGAMGUID");
               Z92ReceptionistInitials = cgiGet( "Z92ReceptionistInitials");
               Z90ReceptionistGivenName = cgiGet( "Z90ReceptionistGivenName");
               Z91ReceptionistLastName = cgiGet( "Z91ReceptionistLastName");
               Z93ReceptionistEmail = cgiGet( "Z93ReceptionistEmail");
               Z94ReceptionistPhone = cgiGet( "Z94ReceptionistPhone");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV23ReceptionistId = StringUtil.StrToGuid( cgiGet( "vRECEPTIONISTID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV21OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
               AV19LocationId = StringUtil.StrToGuid( cgiGet( "vLOCATIONID"));
               AV14GAMErrorResponse = cgiGet( "vGAMERRORRESPONSE");
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
               dynLocationId.CurrentValue = cgiGet( dynLocationId_Internalname);
               A29LocationId = StringUtil.StrToGuid( cgiGet( dynLocationId_Internalname));
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A90ReceptionistGivenName = cgiGet( edtReceptionistGivenName_Internalname);
               AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
               A91ReceptionistLastName = cgiGet( edtReceptionistLastName_Internalname);
               AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
               A93ReceptionistEmail = cgiGet( edtReceptionistEmail_Internalname);
               AssignAttri("", false, "A93ReceptionistEmail", A93ReceptionistEmail);
               A94ReceptionistPhone = cgiGet( edtReceptionistPhone_Internalname);
               AssignAttri("", false, "A94ReceptionistPhone", A94ReceptionistPhone);
               if ( StringUtil.StrCmp(cgiGet( edtReceptionistId_Internalname), "") == 0 )
               {
                  A89ReceptionistId = Guid.Empty;
                  AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
               }
               else
               {
                  try
                  {
                     A89ReceptionistId = StringUtil.StrToGuid( cgiGet( edtReceptionistId_Internalname));
                     AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "RECEPTIONISTID");
                     AnyError = 1;
                     GX_FocusControl = edtReceptionistId_Internalname;
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
               A92ReceptionistInitials = cgiGet( edtReceptionistInitials_Internalname);
               AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
               A95ReceptionistGAMGUID = cgiGet( edtReceptionistGAMGUID_Internalname);
               AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Receptionist");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_receptionist:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A89ReceptionistId = StringUtil.StrToGuid( GetPar( "ReceptionistId"));
                  AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV23ReceptionistId) )
                  {
                     A89ReceptionistId = AV23ReceptionistId;
                     AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A89ReceptionistId) && ( Gx_BScreen == 0 ) )
                     {
                        A89ReceptionistId = Guid.NewGuid( );
                        AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
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
                     sMode74 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV23ReceptionistId) )
                     {
                        A89ReceptionistId = AV23ReceptionistId;
                        AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A89ReceptionistId) && ( Gx_BScreen == 0 ) )
                        {
                           A89ReceptionistId = Guid.NewGuid( );
                           AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                        }
                     }
                     Gx_mode = sMode74;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound74 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "RECEPTIONISTID");
                        AnyError = 1;
                        GX_FocusControl = edtReceptionistId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120C2 ();
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
            E120C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0C74( ) ;
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
            DisableAttributes0C74( ) ;
         }
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C74( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C74( ) ;
            }
            else
            {
               CheckExtendedTable0C74( ) ;
               CloseExtendedTableCursors0C74( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0C0( )
      {
      }

      protected void E110C2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV29WWPContext) ;
         AV25TrnContext.FromXml(AV28WebSession.Get("TrnContext"), null, "", "");
         edtReceptionistId_Visible = 0;
         AssignProp("", false, edtReceptionistId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         edtReceptionistInitials_Visible = 0;
         AssignProp("", false, edtReceptionistInitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistInitials_Visible), 5, 0), true);
         edtReceptionistGAMGUID_Visible = 0;
         AssignProp("", false, edtReceptionistGAMGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistGAMGUID_Visible), 5, 0), true);
      }

      protected void E120C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV25TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_receptionistww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0C74( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z95ReceptionistGAMGUID = T000C3_A95ReceptionistGAMGUID[0];
               Z92ReceptionistInitials = T000C3_A92ReceptionistInitials[0];
               Z90ReceptionistGivenName = T000C3_A90ReceptionistGivenName[0];
               Z91ReceptionistLastName = T000C3_A91ReceptionistLastName[0];
               Z93ReceptionistEmail = T000C3_A93ReceptionistEmail[0];
               Z94ReceptionistPhone = T000C3_A94ReceptionistPhone[0];
            }
            else
            {
               Z95ReceptionistGAMGUID = A95ReceptionistGAMGUID;
               Z92ReceptionistInitials = A92ReceptionistInitials;
               Z90ReceptionistGivenName = A90ReceptionistGivenName;
               Z91ReceptionistLastName = A91ReceptionistLastName;
               Z93ReceptionistEmail = A93ReceptionistEmail;
               Z94ReceptionistPhone = A94ReceptionistPhone;
            }
         }
         if ( GX_JID == -23 )
         {
            Z89ReceptionistId = A89ReceptionistId;
            Z95ReceptionistGAMGUID = A95ReceptionistGAMGUID;
            Z92ReceptionistInitials = A92ReceptionistInitials;
            Z90ReceptionistGivenName = A90ReceptionistGivenName;
            Z91ReceptionistLastName = A91ReceptionistLastName;
            Z93ReceptionistEmail = A93ReceptionistEmail;
            Z94ReceptionistPhone = A94ReceptionistPhone;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV23ReceptionistId) )
         {
            edtReceptionistId_Enabled = 0;
            AssignProp("", false, edtReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Enabled), 5, 0), true);
         }
         else
         {
            edtReceptionistId_Enabled = 1;
            AssignProp("", false, edtReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV23ReceptionistId) )
         {
            edtReceptionistId_Enabled = 0;
            AssignProp("", false, edtReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV21OrganisationId) )
         {
            A11OrganisationId = AV21OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            GXt_guid1 = A11OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
            A11OrganisationId = GXt_guid1;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         if ( ! (Guid.Empty==AV21OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV21OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV19LocationId) )
         {
            A29LocationId = AV19LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            edtReceptionistEmail_Enabled = 0;
            AssignProp("", false, edtReceptionistEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistEmail_Enabled), 5, 0), true);
         }
         else
         {
            edtReceptionistEmail_Enabled = 1;
            AssignProp("", false, edtReceptionistEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistEmail_Enabled), 5, 0), true);
         }
         if ( IsUpd( )  )
         {
            edtReceptionistEmail_Enabled = 0;
            AssignProp("", false, edtReceptionistEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistEmail_Enabled), 5, 0), true);
         }
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
         if ( ! (Guid.Empty==AV23ReceptionistId) )
         {
            A89ReceptionistId = AV23ReceptionistId;
            AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A89ReceptionistId) && ( Gx_BScreen == 0 ) )
            {
               A89ReceptionistId = Guid.NewGuid( );
               AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXALOCATIONID_html0C74( A11OrganisationId) ;
         }
      }

      protected void Load0C74( )
      {
         /* Using cursor T000C5 */
         pr_default.execute(3, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound74 = 1;
            A95ReceptionistGAMGUID = T000C5_A95ReceptionistGAMGUID[0];
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            A92ReceptionistInitials = T000C5_A92ReceptionistInitials[0];
            AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
            A90ReceptionistGivenName = T000C5_A90ReceptionistGivenName[0];
            AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
            A91ReceptionistLastName = T000C5_A91ReceptionistLastName[0];
            AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
            A93ReceptionistEmail = T000C5_A93ReceptionistEmail[0];
            AssignAttri("", false, "A93ReceptionistEmail", A93ReceptionistEmail);
            A94ReceptionistPhone = T000C5_A94ReceptionistPhone[0];
            AssignAttri("", false, "A94ReceptionistPhone", A94ReceptionistPhone);
            ZM0C74( -23) ;
         }
         pr_default.close(3);
         OnLoadActions0C74( ) ;
      }

      protected void OnLoadActions0C74( )
      {
         GXALOCATIONID_html0C74( A11OrganisationId) ;
      }

      protected void CheckExtendedTable0C74( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         GXALOCATIONID_html0C74( A11OrganisationId) ;
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_Location'.", "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( (Guid.Empty==A29LocationId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Location Id", "", "", "", "", "", "", "", ""), 1, "LOCATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A90ReceptionistGivenName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Receptionist Given Name", "", "", "", "", "", "", "", ""), 1, "RECEPTIONISTGIVENNAME");
            AnyError = 1;
            GX_FocusControl = edtReceptionistGivenName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A91ReceptionistLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Receptionist Last Name", "", "", "", "", "", "", "", ""), 1, "RECEPTIONISTLASTNAME");
            AnyError = 1;
            GX_FocusControl = edtReceptionistLastName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A93ReceptionistEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Receptionist Email does not match the specified pattern", "OutOfRange", 1, "RECEPTIONISTEMAIL");
            AnyError = 1;
            GX_FocusControl = edtReceptionistEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A93ReceptionistEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Receptionist Email", "", "", "", "", "", "", "", ""), 1, "RECEPTIONISTEMAIL");
            AnyError = 1;
            GX_FocusControl = edtReceptionistEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0C74( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_24( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_Location'.", "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0C74( )
      {
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound74 = 1;
         }
         else
         {
            RcdFound74 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C74( 23) ;
            RcdFound74 = 1;
            A89ReceptionistId = T000C3_A89ReceptionistId[0];
            AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
            A95ReceptionistGAMGUID = T000C3_A95ReceptionistGAMGUID[0];
            AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            A92ReceptionistInitials = T000C3_A92ReceptionistInitials[0];
            AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
            A90ReceptionistGivenName = T000C3_A90ReceptionistGivenName[0];
            AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
            A91ReceptionistLastName = T000C3_A91ReceptionistLastName[0];
            AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
            A93ReceptionistEmail = T000C3_A93ReceptionistEmail[0];
            AssignAttri("", false, "A93ReceptionistEmail", A93ReceptionistEmail);
            A94ReceptionistPhone = T000C3_A94ReceptionistPhone[0];
            AssignAttri("", false, "A94ReceptionistPhone", A94ReceptionistPhone);
            A11OrganisationId = T000C3_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T000C3_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            Z89ReceptionistId = A89ReceptionistId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0C74( ) ;
            if ( AnyError == 1 )
            {
               RcdFound74 = 0;
               InitializeNonKey0C74( ) ;
            }
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound74 = 0;
            InitializeNonKey0C74( ) ;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C74( ) ;
         if ( RcdFound74 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound74 = 0;
         /* Using cursor T000C8 */
         pr_default.execute(6, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000C8_A89ReceptionistId[0], A89ReceptionistId, 0) < 0 ) || ( T000C8_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C8_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) || ( T000C8_A11OrganisationId[0] == A11OrganisationId ) && ( T000C8_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C8_A29LocationId[0], A29LocationId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000C8_A89ReceptionistId[0], A89ReceptionistId, 0) > 0 ) || ( T000C8_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C8_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) || ( T000C8_A11OrganisationId[0] == A11OrganisationId ) && ( T000C8_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C8_A29LocationId[0], A29LocationId, 0) > 0 ) ) )
            {
               A89ReceptionistId = T000C8_A89ReceptionistId[0];
               AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
               A11OrganisationId = T000C8_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               A29LocationId = T000C8_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               RcdFound74 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound74 = 0;
         /* Using cursor T000C9 */
         pr_default.execute(7, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000C9_A89ReceptionistId[0], A89ReceptionistId, 0) > 0 ) || ( T000C9_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C9_A11OrganisationId[0], A11OrganisationId, 0) > 0 ) || ( T000C9_A11OrganisationId[0] == A11OrganisationId ) && ( T000C9_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C9_A29LocationId[0], A29LocationId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000C9_A89ReceptionistId[0], A89ReceptionistId, 0) < 0 ) || ( T000C9_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C9_A11OrganisationId[0], A11OrganisationId, 0) < 0 ) || ( T000C9_A11OrganisationId[0] == A11OrganisationId ) && ( T000C9_A89ReceptionistId[0] == A89ReceptionistId ) && ( GuidUtil.Compare(T000C9_A29LocationId[0], A29LocationId, 0) < 0 ) ) )
            {
               A89ReceptionistId = T000C9_A89ReceptionistId[0];
               AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
               A11OrganisationId = T000C9_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               A29LocationId = T000C9_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               RcdFound74 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C74( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C74( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound74 == 1 )
            {
               if ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
               {
                  A89ReceptionistId = Z89ReceptionistId;
                  AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
                  A11OrganisationId = Z11OrganisationId;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  A29LocationId = Z29LocationId;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RECEPTIONISTID");
                  AnyError = 1;
                  GX_FocusControl = edtReceptionistId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0C74( ) ;
                  GX_FocusControl = dynLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
               {
                  /* Insert record */
                  GX_FocusControl = dynLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C74( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RECEPTIONISTID");
                     AnyError = 1;
                     GX_FocusControl = edtReceptionistId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = dynLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0C74( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( A89ReceptionistId != Z89ReceptionistId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
         {
            A89ReceptionistId = Z89ReceptionistId;
            AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
            A11OrganisationId = Z11OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = Z29LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RECEPTIONISTID");
            AnyError = 1;
            GX_FocusControl = edtReceptionistId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0C74( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Receptionist"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z95ReceptionistGAMGUID, T000C2_A95ReceptionistGAMGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z92ReceptionistInitials, T000C2_A92ReceptionistInitials[0]) != 0 ) || ( StringUtil.StrCmp(Z90ReceptionistGivenName, T000C2_A90ReceptionistGivenName[0]) != 0 ) || ( StringUtil.StrCmp(Z91ReceptionistLastName, T000C2_A91ReceptionistLastName[0]) != 0 ) || ( StringUtil.StrCmp(Z93ReceptionistEmail, T000C2_A93ReceptionistEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z94ReceptionistPhone, T000C2_A94ReceptionistPhone[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z95ReceptionistGAMGUID, T000C2_A95ReceptionistGAMGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistGAMGUID");
                  GXUtil.WriteLogRaw("Old: ",Z95ReceptionistGAMGUID);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A95ReceptionistGAMGUID[0]);
               }
               if ( StringUtil.StrCmp(Z92ReceptionistInitials, T000C2_A92ReceptionistInitials[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistInitials");
                  GXUtil.WriteLogRaw("Old: ",Z92ReceptionistInitials);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A92ReceptionistInitials[0]);
               }
               if ( StringUtil.StrCmp(Z90ReceptionistGivenName, T000C2_A90ReceptionistGivenName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistGivenName");
                  GXUtil.WriteLogRaw("Old: ",Z90ReceptionistGivenName);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A90ReceptionistGivenName[0]);
               }
               if ( StringUtil.StrCmp(Z91ReceptionistLastName, T000C2_A91ReceptionistLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistLastName");
                  GXUtil.WriteLogRaw("Old: ",Z91ReceptionistLastName);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A91ReceptionistLastName[0]);
               }
               if ( StringUtil.StrCmp(Z93ReceptionistEmail, T000C2_A93ReceptionistEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistEmail");
                  GXUtil.WriteLogRaw("Old: ",Z93ReceptionistEmail);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A93ReceptionistEmail[0]);
               }
               if ( StringUtil.StrCmp(Z94ReceptionistPhone, T000C2_A94ReceptionistPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_receptionist:[seudo value changed for attri]"+"ReceptionistPhone");
                  GXUtil.WriteLogRaw("Old: ",Z94ReceptionistPhone);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A94ReceptionistPhone[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Receptionist"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C74( )
      {
         if ( ! IsAuthorized("trn_receptionist_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C74( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C74( 0) ;
            CheckOptimisticConcurrency0C74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C10 */
                     pr_default.execute(8, new Object[] {A89ReceptionistId, A95ReceptionistGAMGUID, A92ReceptionistInitials, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A11OrganisationId, A29LocationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
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
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0C0( ) ;
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
               Load0C74( ) ;
            }
            EndLevel0C74( ) ;
         }
         CloseExtendedTableCursors0C74( ) ;
      }

      protected void Update0C74( )
      {
         if ( ! IsAuthorized("trn_receptionist_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C74( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C11 */
                     pr_default.execute(9, new Object[] {A95ReceptionistGAMGUID, A92ReceptionistInitials, A90ReceptionistGivenName, A91ReceptionistLastName, A93ReceptionistEmail, A94ReceptionistPhone, A89ReceptionistId, A11OrganisationId, A29LocationId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Receptionist"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C74( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        if ( IsUpd( )  )
                        {
                           new prc_updategamuseraccount(context ).execute(  A95ReceptionistGAMGUID,  A90ReceptionistGivenName,  A91ReceptionistLastName, out  AV14GAMErrorResponse) ;
                           AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
                        }
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
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
            EndLevel0C74( ) ;
         }
         CloseExtendedTableCursors0C74( ) ;
      }

      protected void DeferredUpdate0C74( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_receptionist_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C74( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C74( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C74( ) ;
            AfterConfirm0C74( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C74( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C12 */
                  pr_default.execute(10, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Receptionist");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     if ( IsDlt( )  )
                     {
                        new prc_deletegamuseraccount(context ).execute(  A95ReceptionistGAMGUID, out  AV14GAMErrorResponse) ;
                        AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
                     }
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
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
         sMode74 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C74( ) ;
         Gx_mode = sMode74;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C74( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXALOCATIONID_html0C74( A11OrganisationId) ;
         }
      }

      protected void EndLevel0C74( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C74( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_receptionist",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_receptionist",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C74( )
      {
         /* Scan By routine */
         /* Using cursor T000C13 */
         pr_default.execute(11);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound74 = 1;
            A89ReceptionistId = T000C13_A89ReceptionistId[0];
            AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
            A11OrganisationId = T000C13_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T000C13_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C74( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound74 = 1;
            A89ReceptionistId = T000C13_A89ReceptionistId[0];
            AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
            A11OrganisationId = T000C13_A11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = T000C13_A29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
      }

      protected void ScanEnd0C74( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0C74( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C74( )
      {
         /* Before Insert Rules */
         new prc_getnameinitials(context ).execute(  A90ReceptionistGivenName,  A91ReceptionistLastName, out  A92ReceptionistInitials) ;
         AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
         new prc_creategamuseraccount(context ).execute(  A93ReceptionistEmail,  A90ReceptionistGivenName,  A91ReceptionistLastName,  "Receptionist", out  A95ReceptionistGAMGUID) ;
         AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
      }

      protected void BeforeUpdate0C74( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C74( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C74( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C74( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C74( )
      {
         dynLocationId.Enabled = 0;
         AssignProp("", false, dynLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLocationId.Enabled), 5, 0), true);
         edtReceptionistGivenName_Enabled = 0;
         AssignProp("", false, edtReceptionistGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistGivenName_Enabled), 5, 0), true);
         edtReceptionistLastName_Enabled = 0;
         AssignProp("", false, edtReceptionistLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistLastName_Enabled), 5, 0), true);
         edtReceptionistEmail_Enabled = 0;
         AssignProp("", false, edtReceptionistEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistEmail_Enabled), 5, 0), true);
         edtReceptionistPhone_Enabled = 0;
         AssignProp("", false, edtReceptionistPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistPhone_Enabled), 5, 0), true);
         edtReceptionistId_Enabled = 0;
         AssignProp("", false, edtReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtReceptionistInitials_Enabled = 0;
         AssignProp("", false, edtReceptionistInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistInitials_Enabled), 5, 0), true);
         edtReceptionistGAMGUID_Enabled = 0;
         AssignProp("", false, edtReceptionistGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistGAMGUID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C74( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
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
         GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV23ReceptionistId.ToString()) + "," + UrlEncode(AV21OrganisationId.ToString()) + "," + UrlEncode(AV19LocationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Receptionist");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_receptionist:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z89ReceptionistId", Z89ReceptionistId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z95ReceptionistGAMGUID", Z95ReceptionistGAMGUID);
         GxWebStd.gx_hidden_field( context, "Z92ReceptionistInitials", StringUtil.RTrim( Z92ReceptionistInitials));
         GxWebStd.gx_hidden_field( context, "Z90ReceptionistGivenName", Z90ReceptionistGivenName);
         GxWebStd.gx_hidden_field( context, "Z91ReceptionistLastName", Z91ReceptionistLastName);
         GxWebStd.gx_hidden_field( context, "Z93ReceptionistEmail", Z93ReceptionistEmail);
         GxWebStd.gx_hidden_field( context, "Z94ReceptionistPhone", StringUtil.RTrim( Z94ReceptionistPhone));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV25TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV25TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV25TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vRECEPTIONISTID", AV23ReceptionistId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vRECEPTIONISTID", GetSecureSignedToken( "", AV23ReceptionistId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV21OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV21OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV19LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV19LocationId, context));
         GxWebStd.gx_hidden_field( context, "vGAMERRORRESPONSE", AV14GAMErrorResponse);
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
         GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV23ReceptionistId.ToString()) + "," + UrlEncode(AV21OrganisationId.ToString()) + "," + UrlEncode(AV19LocationId.ToString());
         return formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Receptionist" ;
      }

      public override string GetPgmdesc( )
      {
         return "Receptionist" ;
      }

      protected void InitializeNonKey0C74( )
      {
         A95ReceptionistGAMGUID = "";
         AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
         A92ReceptionistInitials = "";
         AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
         AV14GAMErrorResponse = "";
         AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         A90ReceptionistGivenName = "";
         AssignAttri("", false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
         A91ReceptionistLastName = "";
         AssignAttri("", false, "A91ReceptionistLastName", A91ReceptionistLastName);
         A93ReceptionistEmail = "";
         AssignAttri("", false, "A93ReceptionistEmail", A93ReceptionistEmail);
         A94ReceptionistPhone = "";
         AssignAttri("", false, "A94ReceptionistPhone", A94ReceptionistPhone);
         Z95ReceptionistGAMGUID = "";
         Z92ReceptionistInitials = "";
         Z90ReceptionistGivenName = "";
         Z91ReceptionistLastName = "";
         Z93ReceptionistEmail = "";
         Z94ReceptionistPhone = "";
      }

      protected void InitAll0C74( )
      {
         A89ReceptionistId = Guid.NewGuid( );
         AssignAttri("", false, "A89ReceptionistId", A89ReceptionistId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         InitializeNonKey0C74( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202492719464678", true, true);
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
         context.AddJavascriptSource("trn_receptionist.js", "?202492719464680", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         dynLocationId_Internalname = "LOCATIONID";
         edtReceptionistGivenName_Internalname = "RECEPTIONISTGIVENNAME";
         edtReceptionistLastName_Internalname = "RECEPTIONISTLASTNAME";
         edtReceptionistEmail_Internalname = "RECEPTIONISTEMAIL";
         edtReceptionistPhone_Internalname = "RECEPTIONISTPHONE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtReceptionistId_Internalname = "RECEPTIONISTID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtReceptionistInitials_Internalname = "RECEPTIONISTINITIALS";
         edtReceptionistGAMGUID_Internalname = "RECEPTIONISTGAMGUID";
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
         Form.Caption = "Receptionist";
         edtReceptionistGAMGUID_Jsonclick = "";
         edtReceptionistGAMGUID_Enabled = 1;
         edtReceptionistGAMGUID_Visible = 1;
         edtReceptionistInitials_Jsonclick = "";
         edtReceptionistInitials_Enabled = 1;
         edtReceptionistInitials_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         edtReceptionistId_Jsonclick = "";
         edtReceptionistId_Enabled = 1;
         edtReceptionistId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtReceptionistPhone_Jsonclick = "";
         edtReceptionistPhone_Enabled = 1;
         edtReceptionistEmail_Jsonclick = "";
         edtReceptionistEmail_Enabled = 1;
         edtReceptionistLastName_Jsonclick = "";
         edtReceptionistLastName_Enabled = 1;
         edtReceptionistGivenName_Jsonclick = "";
         edtReceptionistGivenName_Enabled = 1;
         dynLocationId_Jsonclick = "";
         dynLocationId.Enabled = 1;
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
         GXALOCATIONID_html0C74( A11OrganisationId) ;
         /* End function dynload_actions */
      }

      protected void GXDLALOCATIONID0C74( Guid A11OrganisationId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLALOCATIONID_data0C74( A11OrganisationId) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXALOCATIONID_html0C74( Guid A11OrganisationId )
      {
         Guid gxdynajaxvalue;
         GXDLALOCATIONID_data0C74( A11OrganisationId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynLocationId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynLocationId.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLALOCATIONID_data0C74( Guid A11OrganisationId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000C14 */
         pr_default.execute(12);
         while ( (pr_default.getStatus(12) != 101) )
         {
            if ( A11OrganisationId == new prc_getuserorganisationid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(T000C14_A29LocationId[0].ToString());
               gxdynajaxctrldescr.Add(T000C14_A31LocationName[0]);
            }
            pr_default.readNext(12);
         }
         pr_default.close(12);
      }

      protected void GX7ASAORGANISATIONID0C74( Guid AV21OrganisationId )
      {
         if ( ! (Guid.Empty==AV21OrganisationId) )
         {
            A11OrganisationId = AV21OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            GXt_guid1 = A11OrganisationId;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
            A11OrganisationId = GXt_guid1;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A11OrganisationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_18_0C74( string A93ReceptionistEmail ,
                                 string A90ReceptionistGivenName ,
                                 string A91ReceptionistLastName )
      {
         new prc_creategamuseraccount(context ).execute(  A93ReceptionistEmail,  A90ReceptionistGivenName,  A91ReceptionistLastName,  "Receptionist", out  A95ReceptionistGAMGUID) ;
         AssignAttri("", false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A95ReceptionistGAMGUID)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_19_0C74( string A90ReceptionistGivenName ,
                                 string A91ReceptionistLastName )
      {
         new prc_getnameinitials(context ).execute(  A90ReceptionistGivenName,  A91ReceptionistLastName, out  A92ReceptionistInitials) ;
         AssignAttri("", false, "A92ReceptionistInitials", A92ReceptionistInitials);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A92ReceptionistInitials))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_20_0C74( string Gx_mode ,
                                 string A95ReceptionistGAMGUID ,
                                 string A90ReceptionistGivenName ,
                                 string A91ReceptionistLastName )
      {
         if ( IsUpd( )  )
         {
            new prc_updategamuseraccount(context ).execute(  A95ReceptionistGAMGUID,  A90ReceptionistGivenName,  A91ReceptionistLastName, out  AV14GAMErrorResponse) ;
            AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( AV14GAMErrorResponse)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_21_0C74( string Gx_mode ,
                                 string A95ReceptionistGAMGUID )
      {
         if ( IsDlt( )  )
         {
            new prc_deletegamuseraccount(context ).execute(  A95ReceptionistGAMGUID, out  AV14GAMErrorResponse) ;
            AssignAttri("", false, "AV14GAMErrorResponse", AV14GAMErrorResponse);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( AV14GAMErrorResponse)+"\"") ;
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
         dynLocationId.Name = "LOCATIONID";
         dynLocationId.WebTags = "";
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

      public void Valid_Organisationid( )
      {
         A29LocationId = StringUtil.StrToGuid( dynLocationId.CurrentValue);
         /* Using cursor T000C15 */
         pr_default.execute(13, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_Location'.", "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = dynLocationId_Internalname;
         }
         pr_default.close(13);
         GXALOCATIONID_html0C74( A11OrganisationId) ;
         dynload_actions( ) ;
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         dynLocationId.CurrentValue = A29LocationId.ToString();
         AssignProp("", false, dynLocationId_Internalname, "Values", dynLocationId.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV23ReceptionistId","fld":"vRECEPTIONISTID","hsh":true},{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV19LocationId","fld":"vLOCATIONID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV25TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV23ReceptionistId","fld":"vRECEPTIONISTID","hsh":true},{"av":"AV21OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV19LocationId","fld":"vLOCATIONID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120C2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV25TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("VALID_RECEPTIONISTGIVENNAME","""{"handler":"Valid_Receptionistgivenname","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_RECEPTIONISTGIVENNAME",""","oparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("VALID_RECEPTIONISTLASTNAME","""{"handler":"Valid_Receptionistlastname","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_RECEPTIONISTLASTNAME",""","oparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("VALID_RECEPTIONISTEMAIL","""{"handler":"Valid_Receptionistemail","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_RECEPTIONISTEMAIL",""","oparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("VALID_RECEPTIONISTID","""{"handler":"Valid_Receptionistid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_RECEPTIONISTID",""","oparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("VALID_RECEPTIONISTGAMGUID","""{"handler":"Valid_Receptionistgamguid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_RECEPTIONISTGAMGUID",""","oparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV23ReceptionistId = Guid.Empty;
         wcpOAV21OrganisationId = Guid.Empty;
         wcpOAV19LocationId = Guid.Empty;
         Z89ReceptionistId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z95ReceptionistGAMGUID = "";
         Z92ReceptionistInitials = "";
         Z90ReceptionistGivenName = "";
         Z91ReceptionistLastName = "";
         Z93ReceptionistEmail = "";
         Z94ReceptionistPhone = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A93ReceptionistEmail = "";
         A90ReceptionistGivenName = "";
         A91ReceptionistLastName = "";
         A95ReceptionistGAMGUID = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
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
         gxphoneLink = "";
         A94ReceptionistPhone = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A89ReceptionistId = Guid.Empty;
         A92ReceptionistInitials = "";
         AV14GAMErrorResponse = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode74 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV29WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV28WebSession = context.GetSession();
         T000C5_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C5_A95ReceptionistGAMGUID = new string[] {""} ;
         T000C5_A92ReceptionistInitials = new string[] {""} ;
         T000C5_A90ReceptionistGivenName = new string[] {""} ;
         T000C5_A91ReceptionistLastName = new string[] {""} ;
         T000C5_A93ReceptionistEmail = new string[] {""} ;
         T000C5_A94ReceptionistPhone = new string[] {""} ;
         T000C5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C5_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C4_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C6_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C7_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C7_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C3_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C3_A95ReceptionistGAMGUID = new string[] {""} ;
         T000C3_A92ReceptionistInitials = new string[] {""} ;
         T000C3_A90ReceptionistGivenName = new string[] {""} ;
         T000C3_A91ReceptionistLastName = new string[] {""} ;
         T000C3_A93ReceptionistEmail = new string[] {""} ;
         T000C3_A94ReceptionistPhone = new string[] {""} ;
         T000C3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C3_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C8_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C8_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C9_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C9_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C2_A95ReceptionistGAMGUID = new string[] {""} ;
         T000C2_A92ReceptionistInitials = new string[] {""} ;
         T000C2_A90ReceptionistGivenName = new string[] {""} ;
         T000C2_A91ReceptionistLastName = new string[] {""} ;
         T000C2_A93ReceptionistEmail = new string[] {""} ;
         T000C2_A94ReceptionistPhone = new string[] {""} ;
         T000C2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C2_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C13_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         T000C13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C13_A29LocationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000C14_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000C14_A29LocationId = new Guid[] {Guid.Empty} ;
         T000C14_A31LocationName = new string[] {""} ;
         GXt_guid1 = Guid.Empty;
         T000C15_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionist__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionist__default(),
            new Object[][] {
                new Object[] {
               T000C2_A89ReceptionistId, T000C2_A95ReceptionistGAMGUID, T000C2_A92ReceptionistInitials, T000C2_A90ReceptionistGivenName, T000C2_A91ReceptionistLastName, T000C2_A93ReceptionistEmail, T000C2_A94ReceptionistPhone, T000C2_A11OrganisationId, T000C2_A29LocationId
               }
               , new Object[] {
               T000C3_A89ReceptionistId, T000C3_A95ReceptionistGAMGUID, T000C3_A92ReceptionistInitials, T000C3_A90ReceptionistGivenName, T000C3_A91ReceptionistLastName, T000C3_A93ReceptionistEmail, T000C3_A94ReceptionistPhone, T000C3_A11OrganisationId, T000C3_A29LocationId
               }
               , new Object[] {
               T000C4_A29LocationId
               }
               , new Object[] {
               T000C5_A89ReceptionistId, T000C5_A95ReceptionistGAMGUID, T000C5_A92ReceptionistInitials, T000C5_A90ReceptionistGivenName, T000C5_A91ReceptionistLastName, T000C5_A93ReceptionistEmail, T000C5_A94ReceptionistPhone, T000C5_A11OrganisationId, T000C5_A29LocationId
               }
               , new Object[] {
               T000C6_A29LocationId
               }
               , new Object[] {
               T000C7_A89ReceptionistId, T000C7_A11OrganisationId, T000C7_A29LocationId
               }
               , new Object[] {
               T000C8_A89ReceptionistId, T000C8_A11OrganisationId, T000C8_A29LocationId
               }
               , new Object[] {
               T000C9_A89ReceptionistId, T000C9_A11OrganisationId, T000C9_A29LocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C13_A89ReceptionistId, T000C13_A11OrganisationId, T000C13_A29LocationId
               }
               , new Object[] {
               T000C14_A11OrganisationId, T000C14_A29LocationId, T000C14_A31LocationName
               }
               , new Object[] {
               T000C15_A29LocationId
               }
            }
         );
         Z89ReceptionistId = Guid.NewGuid( );
         A89ReceptionistId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound74 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtReceptionistGivenName_Enabled ;
      private int edtReceptionistLastName_Enabled ;
      private int edtReceptionistEmail_Enabled ;
      private int edtReceptionistPhone_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtReceptionistId_Visible ;
      private int edtReceptionistId_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int edtReceptionistInitials_Visible ;
      private int edtReceptionistInitials_Enabled ;
      private int edtReceptionistGAMGUID_Visible ;
      private int edtReceptionistGAMGUID_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z92ReceptionistInitials ;
      private string Z94ReceptionistPhone ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string dynLocationId_Internalname ;
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
      private string dynLocationId_Jsonclick ;
      private string edtReceptionistGivenName_Internalname ;
      private string edtReceptionistGivenName_Jsonclick ;
      private string edtReceptionistLastName_Internalname ;
      private string edtReceptionistLastName_Jsonclick ;
      private string edtReceptionistEmail_Internalname ;
      private string edtReceptionistEmail_Jsonclick ;
      private string edtReceptionistPhone_Internalname ;
      private string gxphoneLink ;
      private string A94ReceptionistPhone ;
      private string edtReceptionistPhone_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtReceptionistId_Internalname ;
      private string edtReceptionistId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtReceptionistInitials_Internalname ;
      private string A92ReceptionistInitials ;
      private string edtReceptionistInitials_Jsonclick ;
      private string edtReceptionistGAMGUID_Internalname ;
      private string edtReceptionistGAMGUID_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode74 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private string AV14GAMErrorResponse ;
      private string Z95ReceptionistGAMGUID ;
      private string Z90ReceptionistGivenName ;
      private string Z91ReceptionistLastName ;
      private string Z93ReceptionistEmail ;
      private string A93ReceptionistEmail ;
      private string A90ReceptionistGivenName ;
      private string A91ReceptionistLastName ;
      private string A95ReceptionistGAMGUID ;
      private Guid wcpOAV23ReceptionistId ;
      private Guid wcpOAV21OrganisationId ;
      private Guid wcpOAV19LocationId ;
      private Guid Z89ReceptionistId ;
      private Guid Z11OrganisationId ;
      private Guid Z29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV21OrganisationId ;
      private Guid A29LocationId ;
      private Guid AV23ReceptionistId ;
      private Guid AV19LocationId ;
      private Guid A89ReceptionistId ;
      private Guid GXt_guid1 ;
      private IGxSession AV28WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynLocationId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV29WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV25TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000C5_A89ReceptionistId ;
      private string[] T000C5_A95ReceptionistGAMGUID ;
      private string[] T000C5_A92ReceptionistInitials ;
      private string[] T000C5_A90ReceptionistGivenName ;
      private string[] T000C5_A91ReceptionistLastName ;
      private string[] T000C5_A93ReceptionistEmail ;
      private string[] T000C5_A94ReceptionistPhone ;
      private Guid[] T000C5_A11OrganisationId ;
      private Guid[] T000C5_A29LocationId ;
      private Guid[] T000C4_A29LocationId ;
      private Guid[] T000C6_A29LocationId ;
      private Guid[] T000C7_A89ReceptionistId ;
      private Guid[] T000C7_A11OrganisationId ;
      private Guid[] T000C7_A29LocationId ;
      private Guid[] T000C3_A89ReceptionistId ;
      private string[] T000C3_A95ReceptionistGAMGUID ;
      private string[] T000C3_A92ReceptionistInitials ;
      private string[] T000C3_A90ReceptionistGivenName ;
      private string[] T000C3_A91ReceptionistLastName ;
      private string[] T000C3_A93ReceptionistEmail ;
      private string[] T000C3_A94ReceptionistPhone ;
      private Guid[] T000C3_A11OrganisationId ;
      private Guid[] T000C3_A29LocationId ;
      private Guid[] T000C8_A89ReceptionistId ;
      private Guid[] T000C8_A11OrganisationId ;
      private Guid[] T000C8_A29LocationId ;
      private Guid[] T000C9_A89ReceptionistId ;
      private Guid[] T000C9_A11OrganisationId ;
      private Guid[] T000C9_A29LocationId ;
      private Guid[] T000C2_A89ReceptionistId ;
      private string[] T000C2_A95ReceptionistGAMGUID ;
      private string[] T000C2_A92ReceptionistInitials ;
      private string[] T000C2_A90ReceptionistGivenName ;
      private string[] T000C2_A91ReceptionistLastName ;
      private string[] T000C2_A93ReceptionistEmail ;
      private string[] T000C2_A94ReceptionistPhone ;
      private Guid[] T000C2_A11OrganisationId ;
      private Guid[] T000C2_A29LocationId ;
      private Guid[] T000C13_A89ReceptionistId ;
      private Guid[] T000C13_A11OrganisationId ;
      private Guid[] T000C13_A29LocationId ;
      private Guid[] T000C14_A11OrganisationId ;
      private Guid[] T000C14_A29LocationId ;
      private string[] T000C14_A31LocationName ;
      private Guid[] T000C15_A29LocationId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_receptionist__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_receptionist__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000C2;
        prmT000C2 = new Object[] {
        new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000C3;
        prmT000C3 = new Object[] {
        new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000C4;
        prmT000C4 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000C5;
        prmT000C5 = new Object[] {
        new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000C6;
        prmT000C6 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000C7;
        prmT000C7 = new Object[] {
        new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000C8;
        prmT000C8 = new Object[] {
        new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000C9;
        prmT000C9 = new Object[] {
        new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000C10;
        prmT000C10 = new Object[] {
        new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ReceptionistGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("ReceptionistInitials",GXType.Char,20,0) ,
        new ParDef("ReceptionistGivenName",GXType.VarChar,100,0) ,
        new ParDef("ReceptionistLastName",GXType.VarChar,100,0) ,
        new ParDef("ReceptionistEmail",GXType.VarChar,100,0) ,
        new ParDef("ReceptionistPhone",GXType.Char,20,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000C11;
        prmT000C11 = new Object[] {
        new ParDef("ReceptionistGAMGUID",GXType.VarChar,100,60) ,
        new ParDef("ReceptionistInitials",GXType.Char,20,0) ,
        new ParDef("ReceptionistGivenName",GXType.VarChar,100,0) ,
        new ParDef("ReceptionistLastName",GXType.VarChar,100,0) ,
        new ParDef("ReceptionistEmail",GXType.VarChar,100,0) ,
        new ParDef("ReceptionistPhone",GXType.Char,20,0) ,
        new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000C12;
        prmT000C12 = new Object[] {
        new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000C13;
        prmT000C13 = new Object[] {
        };
        Object[] prmT000C14;
        prmT000C14 = new Object[] {
        };
        Object[] prmT000C15;
        prmT000C15 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000C2", "SELECT ReceptionistId, ReceptionistGAMGUID, ReceptionistInitials, ReceptionistGivenName, ReceptionistLastName, ReceptionistEmail, ReceptionistPhone, OrganisationId, LocationId FROM Trn_Receptionist WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId  FOR UPDATE OF Trn_Receptionist NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C3", "SELECT ReceptionistId, ReceptionistGAMGUID, ReceptionistInitials, ReceptionistGivenName, ReceptionistLastName, ReceptionistEmail, ReceptionistPhone, OrganisationId, LocationId FROM Trn_Receptionist WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C4", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C5", "SELECT TM1.ReceptionistId, TM1.ReceptionistGAMGUID, TM1.ReceptionistInitials, TM1.ReceptionistGivenName, TM1.ReceptionistLastName, TM1.ReceptionistEmail, TM1.ReceptionistPhone, TM1.OrganisationId, TM1.LocationId FROM Trn_Receptionist TM1 WHERE TM1.ReceptionistId = :ReceptionistId and TM1.OrganisationId = :OrganisationId and TM1.LocationId = :LocationId ORDER BY TM1.ReceptionistId, TM1.OrganisationId, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C6", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C7", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C8", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE ( ReceptionistId > :ReceptionistId or ReceptionistId = :ReceptionistId and OrganisationId > :OrganisationId or OrganisationId = :OrganisationId and ReceptionistId = :ReceptionistId and LocationId > :LocationId) ORDER BY ReceptionistId, OrganisationId, LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000C9", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE ( ReceptionistId < :ReceptionistId or ReceptionistId = :ReceptionistId and OrganisationId < :OrganisationId or OrganisationId = :OrganisationId and ReceptionistId = :ReceptionistId and LocationId < :LocationId) ORDER BY ReceptionistId DESC, OrganisationId DESC, LocationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000C10", "SAVEPOINT gxupdate;INSERT INTO Trn_Receptionist(ReceptionistId, ReceptionistGAMGUID, ReceptionistInitials, ReceptionistGivenName, ReceptionistLastName, ReceptionistEmail, ReceptionistPhone, OrganisationId, LocationId) VALUES(:ReceptionistId, :ReceptionistGAMGUID, :ReceptionistInitials, :ReceptionistGivenName, :ReceptionistLastName, :ReceptionistEmail, :ReceptionistPhone, :OrganisationId, :LocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C10)
           ,new CursorDef("T000C11", "SAVEPOINT gxupdate;UPDATE Trn_Receptionist SET ReceptionistGAMGUID=:ReceptionistGAMGUID, ReceptionistInitials=:ReceptionistInitials, ReceptionistGivenName=:ReceptionistGivenName, ReceptionistLastName=:ReceptionistLastName, ReceptionistEmail=:ReceptionistEmail, ReceptionistPhone=:ReceptionistPhone  WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C11)
           ,new CursorDef("T000C12", "SAVEPOINT gxupdate;DELETE FROM Trn_Receptionist  WHERE ReceptionistId = :ReceptionistId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000C12)
           ,new CursorDef("T000C13", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist ORDER BY ReceptionistId, OrganisationId, LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C14", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location ORDER BY LocationName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C14,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C15", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C15,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((Guid[]) buf[7])[0] = rslt.getGuid(8);
              ((Guid[]) buf[8])[0] = rslt.getGuid(9);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((Guid[]) buf[7])[0] = rslt.getGuid(8);
              ((Guid[]) buf[8])[0] = rslt.getGuid(9);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((Guid[]) buf[7])[0] = rslt.getGuid(8);
              ((Guid[]) buf[8])[0] = rslt.getGuid(9);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
