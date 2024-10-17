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
   public class wp_createorganisationandmanagerstep1 : GXWebComponent
   {
      public wp_createorganisationandmanagerstep1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wp_createorganisationandmanagerstep1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WebSessionKey ,
                           string aP1_PreviousStep ,
                           bool aP2_GoingBack )
      {
         this.AV6WebSessionKey = aP0_WebSessionKey;
         this.AV8PreviousStep = aP1_PreviousStep;
         this.AV7GoingBack = aP2_GoingBack;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         dynavOrganisationtypeid = new GXCombobox();
         dynavOrganisationid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV6WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
                  AV8PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
                  AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WebSessionKey,(string)AV8PreviousStep,(bool)AV7GoingBack});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA4G2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS4G2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "WP_Create Organisation And Manager Step1", "")) ;
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
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wp_createorganisationandmanagerstep1.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createorganisationandmanagerstep1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV29DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV29DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vORGANISATIONPHONECODE_DATA", AV39OrganisationPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vORGANISATIONPHONECODE_DATA", AV39OrganisationPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vORGANISATIONADDRESSCOUNTRY_DATA", AV28OrganisationAddressCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vORGANISATIONADDRESSCOUNTRY_DATA", AV28OrganisationAddressCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV22CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRY_Ddointernalname", StringUtil.RTrim( Combo_organisationaddresscountry_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRY_Selectedvalue_get", StringUtil.RTrim( Combo_organisationaddresscountry_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_organisationphonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRY_Ddointernalname", StringUtil.RTrim( Combo_organisationaddresscountry_Ddointernalname));
      }

      protected void RenderHtmlCloseForm4G2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WP_CreateOrganisationAndManagerStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Organisation And Manager Step1", "") ;
      }

      protected void WB4G0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createorganisationandmanagerstep1.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Organisation Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavOrganisationtypeid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavOrganisationtypeid_Internalname, context.GetMessage( "Organisation Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavOrganisationtypeid, dynavOrganisationtypeid_Internalname, AV21OrganisationTypeId.ToString(), 1, dynavOrganisationtypeid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "guid", "", 1, dynavOrganisationtypeid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", false, 0, "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            dynavOrganisationtypeid.CurrentValue = AV21OrganisationTypeId.ToString();
            AssignProp(sPrefix, false, dynavOrganisationtypeid_Internalname, "Values", (string)(dynavOrganisationtypeid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationname_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationname_Internalname, AV16OrganisationName, StringUtil.RTrim( context.localUtil.Format( AV16OrganisationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationkvknumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationkvknumber_Internalname, context.GetMessage( "KvK Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationkvknumber_Internalname, AV15OrganisationKvkNumber, StringUtil.RTrim( context.localUtil.Format( AV15OrganisationKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationkvknumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationkvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationvatnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationvatnumber_Internalname, context.GetMessage( "VAT Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationvatnumber_Internalname, AV19OrganisationVATNumber, StringUtil.RTrim( context.localUtil.Format( AV19OrganisationVATNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationvatnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationvatnumber_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationemail_Internalname, AV13OrganisationEmail, StringUtil.RTrim( context.localUtil.Format( AV13OrganisationEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 FreeStyleGrid ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedorganisationphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_organisationphonecode_Internalname, context.GetMessage( "Phone", ""), "", "", lblTextblockcombo_organisationphonecode_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table1_52_4G2( true) ;
         }
         else
         {
            wb_table1_52_4G2( false) ;
         }
         return  ;
      }

      protected void wb_table1_52_4G2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationaddressline1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationaddressline1_Internalname, AV34OrganisationAddressLine1, StringUtil.RTrim( context.localUtil.Format( AV34OrganisationAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationaddressline1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationaddressline2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationaddressline2_Internalname, AV35OrganisationAddressLine2, StringUtil.RTrim( context.localUtil.Format( AV35OrganisationAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationaddressline2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationaddresszipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationaddresszipcode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationaddresszipcode_Internalname, AV26OrganisationAddressZipCode, StringUtil.RTrim( context.localUtil.Format( AV26OrganisationAddressZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationaddresszipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationaddresszipcode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationaddresscity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationaddresscity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationaddresscity_Internalname, AV23OrganisationAddressCity, StringUtil.RTrim( context.localUtil.Format( AV23OrganisationAddressCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationaddresscity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationaddresscity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedorganisationaddresscountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_organisationaddresscountry_Internalname, context.GetMessage( "Country", ""), "", "", lblTextblockcombo_organisationaddresscountry_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_organisationaddresscountry.SetProperty("Caption", Combo_organisationaddresscountry_Caption);
            ucCombo_organisationaddresscountry.SetProperty("Cls", Combo_organisationaddresscountry_Cls);
            ucCombo_organisationaddresscountry.SetProperty("EmptyItem", Combo_organisationaddresscountry_Emptyitem);
            ucCombo_organisationaddresscountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV29DDO_TitleSettingsIcons);
            ucCombo_organisationaddresscountry.SetProperty("DropDownOptionsData", AV28OrganisationAddressCountry_Data);
            ucCombo_organisationaddresscountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationaddresscountry_Internalname, sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRYContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardfirstprevious.SetProperty("TooltipText", Btnwizardfirstprevious_Tooltiptext);
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardnext.SetProperty("TooltipText", Btnwizardnext_Tooltiptext);
            ucBtnwizardnext.SetProperty("Caption", Btnwizardnext_Caption);
            ucBtnwizardnext.SetProperty("Class", Btnwizardnext_Class);
            ucBtnwizardnext.Render(context, "wwp_iconbutton", Btnwizardnext_Internalname, sPrefix+"BTNWIZARDNEXTContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationphonecode_Internalname, AV38OrganisationPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV38OrganisationPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavOrganisationphonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationaddresscountry_Internalname, AV27OrganisationAddressCountry, StringUtil.RTrim( context.localUtil.Format( AV27OrganisationAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationaddresscountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavOrganisationaddresscountry_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavOrganisationid, dynavOrganisationid_Internalname, AV14OrganisationId.ToString(), 1, dynavOrganisationid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "guid", "", dynavOrganisationid.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "", false, 0, "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            dynavOrganisationid.CurrentValue = AV14OrganisationId.ToString();
            AssignProp(sPrefix, false, dynavOrganisationid_Internalname, "Values", (string)(dynavOrganisationid.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationphone_Internalname, StringUtil.RTrim( AV17OrganisationPhone), StringUtil.RTrim( context.localUtil.Format( AV17OrganisationPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavOrganisationphone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4G2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "WP_Create Organisation And Manager Step1", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP4G0( ) ;
            }
         }
      }

      protected void WS4G2( )
      {
         START4G2( ) ;
         EVT4G2( ) ;
      }

      protected void EVT4G2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E114G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E124G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E134G2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E144G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORGANISATIONVATNUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E154G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORGANISATIONEMAIL.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E164G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORGANISATIONKVKNUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E174G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORGANISATIONADDRESSZIPCODE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E184G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E194G2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = dynavOrganisationtypeid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE4G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4G2( ) ;
            }
         }
      }

      protected void PA4G2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createorganisationandmanagerstep1.aspx")), "wp_createorganisationandmanagerstep1.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createorganisationandmanagerstep1.aspx")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "WebSessionKey");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( toggleJsOutput )
                     {
                        if ( context.isSpaRequest( ) )
                        {
                           enableJsOutput();
                        }
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = dynavOrganisationtypeid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvORGANISATIONID4G1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvORGANISATIONID_data4G1( ) ;
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

      protected void GXVvORGANISATIONID_html4G1( )
      {
         Guid gxdynajaxvalue;
         GXDLVvORGANISATIONID_data4G1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavOrganisationid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavOrganisationid.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavOrganisationid.ItemCount > 0 )
         {
            AV14OrganisationId = StringUtil.StrToGuid( dynavOrganisationid.getValidValue(AV14OrganisationId.ToString()));
            AssignAttri(sPrefix, false, "AV14OrganisationId", AV14OrganisationId.ToString());
         }
      }

      protected void GXDLVvORGANISATIONID_data4G1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H004G2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H004G2_A11OrganisationId[0].ToString());
            gxdynajaxctrldescr.Add(H004G2_A13OrganisationName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvORGANISATIONTYPEID4G1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvORGANISATIONTYPEID_data4G1( ) ;
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

      protected void GXVvORGANISATIONTYPEID_html4G1( )
      {
         Guid gxdynajaxvalue;
         GXDLVvORGANISATIONTYPEID_data4G1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavOrganisationtypeid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavOrganisationtypeid.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavOrganisationtypeid.ItemCount > 0 )
         {
            AV21OrganisationTypeId = StringUtil.StrToGuid( dynavOrganisationtypeid.getValidValue(AV21OrganisationTypeId.ToString()));
            AssignAttri(sPrefix, false, "AV21OrganisationTypeId", AV21OrganisationTypeId.ToString());
         }
      }

      protected void GXDLVvORGANISATIONTYPEID_data4G1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H004G3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(H004G3_A19OrganisationTypeId[0].ToString());
            gxdynajaxctrldescr.Add(H004G3_A20OrganisationTypeName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavOrganisationid.Name = "vORGANISATIONID";
            dynavOrganisationid.WebTags = "";
            dynavOrganisationid.removeAllItems();
            /* Using cursor H004G4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               dynavOrganisationid.addItem(H004G4_A11OrganisationId[0].ToString(), H004G4_A13OrganisationName[0], 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( dynavOrganisationid.ItemCount > 0 )
            {
               AV14OrganisationId = StringUtil.StrToGuid( dynavOrganisationid.getValidValue(AV14OrganisationId.ToString()));
               AssignAttri(sPrefix, false, "AV14OrganisationId", AV14OrganisationId.ToString());
            }
            dynavOrganisationtypeid.Name = "vORGANISATIONTYPEID";
            dynavOrganisationtypeid.WebTags = "";
            dynavOrganisationtypeid.removeAllItems();
            /* Using cursor H004G5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynavOrganisationtypeid.addItem(H004G5_A19OrganisationTypeId[0].ToString(), H004G5_A20OrganisationTypeName[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynavOrganisationtypeid.ItemCount > 0 )
            {
               AV21OrganisationTypeId = StringUtil.StrToGuid( dynavOrganisationtypeid.getValidValue(AV21OrganisationTypeId.ToString()));
               AssignAttri(sPrefix, false, "AV21OrganisationTypeId", AV21OrganisationTypeId.ToString());
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavOrganisationtypeid.ItemCount > 0 )
         {
            AV21OrganisationTypeId = StringUtil.StrToGuid( dynavOrganisationtypeid.getValidValue(AV21OrganisationTypeId.ToString()));
            AssignAttri(sPrefix, false, "AV21OrganisationTypeId", AV21OrganisationTypeId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavOrganisationtypeid.CurrentValue = AV21OrganisationTypeId.ToString();
            AssignProp(sPrefix, false, dynavOrganisationtypeid_Internalname, "Values", dynavOrganisationtypeid.ToJavascriptSource(), true);
         }
         if ( dynavOrganisationid.ItemCount > 0 )
         {
            AV14OrganisationId = StringUtil.StrToGuid( dynavOrganisationid.getValidValue(AV14OrganisationId.ToString()));
            AssignAttri(sPrefix, false, "AV14OrganisationId", AV14OrganisationId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavOrganisationid.CurrentValue = AV14OrganisationId.ToString();
            AssignProp(sPrefix, false, dynavOrganisationid_Internalname, "Values", dynavOrganisationid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF4G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E124G2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E194G2 ();
            WB4G0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4G2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114G2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV29DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vORGANISATIONPHONECODE_DATA"), AV39OrganisationPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vORGANISATIONADDRESSCOUNTRY_DATA"), AV28OrganisationAddressCountry_Data);
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            Combo_organisationaddresscountry_Ddointernalname = cgiGet( sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRY_Ddointernalname");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E114G2 ();
         if (returnInSub) return;
      }

      protected void E114G2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV29DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV29DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavOrganisationaddresscountry_Visible = 0;
         AssignProp(sPrefix, false, edtavOrganisationaddresscountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOrganisationaddresscountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_organisationaddresscountry_Htmltemplate = GXt_char2;
         ucCombo_organisationaddresscountry.SendProperty(context, sPrefix, false, Combo_organisationaddresscountry_Internalname, "HTMLTemplate", Combo_organisationaddresscountry_Htmltemplate);
         edtavOrganisationphonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavOrganisationphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOrganisationphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_organisationphonecode_Htmltemplate = GXt_char2;
         ucCombo_organisationphonecode.SendProperty(context, sPrefix, false, Combo_organisationphonecode_Internalname, "HTMLTemplate", Combo_organisationphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONPHONECODE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONADDRESSCOUNTRY' */
         S132 ();
         if (returnInSub) return;
         dynavOrganisationid.Visible = 0;
         AssignProp(sPrefix, false, dynavOrganisationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavOrganisationid.Visible), 5, 0), true);
         edtavOrganisationphone_Visible = 0;
         AssignProp(sPrefix, false, edtavOrganisationphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOrganisationphone_Visible), 5, 0), true);
         AV36defaultCountry = "Netherlands";
         Combo_organisationaddresscountry_Selectedtext_set = AV36defaultCountry;
         ucCombo_organisationaddresscountry.SendProperty(context, sPrefix, false, Combo_organisationaddresscountry_Internalname, "SelectedText_set", Combo_organisationaddresscountry_Selectedtext_set);
         Combo_organisationaddresscountry_Selectedvalue_set = AV36defaultCountry;
         ucCombo_organisationaddresscountry.SendProperty(context, sPrefix, false, Combo_organisationaddresscountry_Internalname, "SelectedValue_set", Combo_organisationaddresscountry_Selectedvalue_set);
         AV27OrganisationAddressCountry = AV36defaultCountry;
         AssignAttri(sPrefix, false, "AV27OrganisationAddressCountry", AV27OrganisationAddressCountry);
         AV37defaultCountryPhoneCode = "+31";
         AV38OrganisationPhoneCode = "+31";
         AssignAttri(sPrefix, false, "AV38OrganisationPhoneCode", AV38OrganisationPhoneCode);
         Combo_organisationphonecode_Selectedtext_set = AV37defaultCountryPhoneCode;
         ucCombo_organisationphonecode.SendProperty(context, sPrefix, false, Combo_organisationphonecode_Internalname, "SelectedText_set", Combo_organisationphonecode_Selectedtext_set);
         Combo_organisationphonecode_Selectedvalue_set = AV37defaultCountryPhoneCode;
         ucCombo_organisationphonecode.SendProperty(context, sPrefix, false, Combo_organisationphonecode_Internalname, "SelectedValue_set", Combo_organisationphonecode_Selectedvalue_set);
      }

      protected void E124G2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E134G2 ();
         if (returnInSub) return;
      }

      protected void E134G2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S152 ();
         if (returnInSub) return;
         if ( AV22CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S162 ();
            if (returnInSub) return;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wp_createorganisationandmanager.aspx"+UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wp_createorganisationandmanager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
         dynavOrganisationid.CurrentValue = AV14OrganisationId.ToString();
         AssignProp(sPrefix, false, dynavOrganisationid_Internalname, "Values", dynavOrganisationid.ToJavascriptSource(), true);
      }

      protected void E144G2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV7GoingBack ) )
         {
            Btnwizardfirstprevious_Visible = false;
            ucBtnwizardfirstprevious.SendProperty(context, sPrefix, false, Btnwizardfirstprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnwizardfirstprevious_Visible));
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV34OrganisationAddressLine1 = AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddressline1;
         AssignAttri(sPrefix, false, "AV34OrganisationAddressLine1", AV34OrganisationAddressLine1);
         AV35OrganisationAddressLine2 = AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddressline2;
         AssignAttri(sPrefix, false, "AV35OrganisationAddressLine2", AV35OrganisationAddressLine2);
         AV26OrganisationAddressZipCode = AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresszipcode;
         AssignAttri(sPrefix, false, "AV26OrganisationAddressZipCode", AV26OrganisationAddressZipCode);
         AV23OrganisationAddressCity = AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresscity;
         AssignAttri(sPrefix, false, "AV23OrganisationAddressCity", AV23OrganisationAddressCity);
         AV27OrganisationAddressCountry = AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresscountry;
         AssignAttri(sPrefix, false, "AV27OrganisationAddressCountry", AV27OrganisationAddressCountry);
         AV14OrganisationId = AV11WizardData.gxTpr_Step1.gxTpr_Organisationid;
         AssignAttri(sPrefix, false, "AV14OrganisationId", AV14OrganisationId.ToString());
         AV21OrganisationTypeId = AV11WizardData.gxTpr_Step1.gxTpr_Organisationtypeid;
         AssignAttri(sPrefix, false, "AV21OrganisationTypeId", AV21OrganisationTypeId.ToString());
         AV16OrganisationName = AV11WizardData.gxTpr_Step1.gxTpr_Organisationname;
         AssignAttri(sPrefix, false, "AV16OrganisationName", AV16OrganisationName);
         AV15OrganisationKvkNumber = AV11WizardData.gxTpr_Step1.gxTpr_Organisationkvknumber;
         AssignAttri(sPrefix, false, "AV15OrganisationKvkNumber", AV15OrganisationKvkNumber);
         AV19OrganisationVATNumber = AV11WizardData.gxTpr_Step1.gxTpr_Organisationvatnumber;
         AssignAttri(sPrefix, false, "AV19OrganisationVATNumber", AV19OrganisationVATNumber);
         AV13OrganisationEmail = AV11WizardData.gxTpr_Step1.gxTpr_Organisationemail;
         AssignAttri(sPrefix, false, "AV13OrganisationEmail", AV13OrganisationEmail);
         AV38OrganisationPhoneCode = AV11WizardData.gxTpr_Step1.gxTpr_Organisationphonecode;
         AssignAttri(sPrefix, false, "AV38OrganisationPhoneCode", AV38OrganisationPhoneCode);
         AV41OrganisationPhoneNumber = AV11WizardData.gxTpr_Step1.gxTpr_Organisationphonenumber;
         AssignAttri(sPrefix, false, "AV41OrganisationPhoneNumber", AV41OrganisationPhoneNumber);
         AV17OrganisationPhone = AV11WizardData.gxTpr_Step1.gxTpr_Organisationphone;
         AssignAttri(sPrefix, false, "AV17OrganisationPhone", AV17OrganisationPhone);
      }

      protected void S162( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV14OrganisationId = Guid.NewGuid( );
         AssignAttri(sPrefix, false, "AV14OrganisationId", AV14OrganisationId.ToString());
         GXt_char2 = AV17OrganisationPhone;
         new prc_concatenateintlphone(context ).execute(  AV38OrganisationPhoneCode,  AV41OrganisationPhoneNumber, out  GXt_char2) ;
         AV17OrganisationPhone = GXt_char2;
         AssignAttri(sPrefix, false, "AV17OrganisationPhone", AV17OrganisationPhone);
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddressline1 = AV34OrganisationAddressLine1;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddressline2 = AV35OrganisationAddressLine2;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresszipcode = AV26OrganisationAddressZipCode;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresscity = AV23OrganisationAddressCity;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresscountry = AV27OrganisationAddressCountry;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationid = AV14OrganisationId;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationtypeid = AV21OrganisationTypeId;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationname = AV16OrganisationName;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationkvknumber = AV15OrganisationKvkNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationvatnumber = AV19OrganisationVATNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationemail = AV13OrganisationEmail;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationphonecode = AV38OrganisationPhoneCode;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationphonenumber = AV41OrganisationPhoneNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationphone = AV17OrganisationPhone;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV22CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         if ( (Guid.Empty==AV21OrganisationTypeId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Organisation Type", ""), "", "", "", "", "", "", "", ""),  "error",  dynavOrganisationtypeid_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16OrganisationName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationname_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15OrganisationKvkNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "KvK Number", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationkvknumber_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19OrganisationVATNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "VAT Number", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationvatnumber_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13OrganisationEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationemail_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34OrganisationAddressLine1)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Address Line 1", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationaddressline1_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26OrganisationAddressZipCode)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Zip Code", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationaddresszipcode_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23OrganisationAddressCity)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "City", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationaddresscity_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27OrganisationAddressCountry)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Country", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_organisationaddresscountry_Ddointernalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOORGANISATIONADDRESSCOUNTRY' Routine */
         returnInSub = false;
         AV44GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV43GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV43GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV44GXV2 <= AV43GXV1.Count )
         {
            AV32OrganisationAddressCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV43GXV1.Item(AV44GXV2));
            AV31Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV31Combo_DataItem.gxTpr_Id = AV32OrganisationAddressCountry_DPItem.gxTpr_Countryname;
            AV33ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV33ComboTitles.Add(AV32OrganisationAddressCountry_DPItem.gxTpr_Countryname, 0);
            AV33ComboTitles.Add(AV32OrganisationAddressCountry_DPItem.gxTpr_Countryflag, 0);
            AV31Combo_DataItem.gxTpr_Title = AV33ComboTitles.ToJSonString(false);
            AV28OrganisationAddressCountry_Data.Add(AV31Combo_DataItem, 0);
            AV44GXV2 = (int)(AV44GXV2+1);
         }
         AV28OrganisationAddressCountry_Data.Sort("Title");
         Combo_organisationaddresscountry_Selectedvalue_set = AV27OrganisationAddressCountry;
         ucCombo_organisationaddresscountry.SendProperty(context, sPrefix, false, Combo_organisationaddresscountry_Internalname, "SelectedValue_set", Combo_organisationaddresscountry_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOORGANISATIONPHONECODE' Routine */
         returnInSub = false;
         AV46GXV4 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV45GXV3;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV45GXV3 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV46GXV4 <= AV45GXV3.Count )
         {
            AV40OrganisationPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV45GXV3.Item(AV46GXV4));
            AV31Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV31Combo_DataItem.gxTpr_Id = AV40OrganisationPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV33ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV33ComboTitles.Add(AV40OrganisationPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV33ComboTitles.Add(AV40OrganisationPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV31Combo_DataItem.gxTpr_Title = AV33ComboTitles.ToJSonString(false);
            AV39OrganisationPhoneCode_Data.Add(AV31Combo_DataItem, 0);
            AV46GXV4 = (int)(AV46GXV4+1);
         }
         AV39OrganisationPhoneCode_Data.Sort("Title");
         Combo_organisationphonecode_Selectedvalue_set = AV38OrganisationPhoneCode;
         ucCombo_organisationphonecode.SendProperty(context, sPrefix, false, Combo_organisationphonecode_Internalname, "SelectedValue_set", Combo_organisationphonecode_Selectedvalue_set);
      }

      protected void E154G2( )
      {
         /* Organisationvatnumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV19OrganisationVATNumber,context.GetMessage( "[A-Za-z]{2}\\d{9}[A-Za-z]\\d{2}", "")) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "VAT is incorrect", ""),  "error",  edtavOrganisationvatnumber_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E164G2( )
      {
         /* Organisationemail_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV13OrganisationEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Email is incorrect", ""),  "error",  edtavOrganisationemail_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E174G2( )
      {
         /* Organisationkvknumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( StringUtil.Len( AV15OrganisationKvkNumber) != 8 )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "KVK is 8 digits long", ""),  "error",  edtavOrganisationkvknumber_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E184G2( )
      {
         /* Organisationaddresszipcode_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV26OrganisationAddressZipCode,context.GetMessage( "^\\d{4} [a-zA-Z]{2}$", "")) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Zip Code is incorrect", ""),  "error",  edtavOrganisationaddresszipcode_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E194G2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_52_4G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedorganisationphonecode_Internalname, tblTablemergedorganisationphonecode_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_organisationphonecode.SetProperty("Caption", Combo_organisationphonecode_Caption);
            ucCombo_organisationphonecode.SetProperty("Cls", Combo_organisationphonecode_Cls);
            ucCombo_organisationphonecode.SetProperty("EmptyItem", Combo_organisationphonecode_Emptyitem);
            ucCombo_organisationphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV29DDO_TitleSettingsIcons);
            ucCombo_organisationphonecode.SetProperty("DropDownOptionsData", AV39OrganisationPhoneCode_Data);
            ucCombo_organisationphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationphonecode_Internalname, sPrefix+"COMBO_ORGANISATIONPHONECODEContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationphonenumber_Internalname, context.GetMessage( "Organisation Phone Number", ""), "gx-form-item AttributePhoneNumberLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationphonenumber_Internalname, AV41OrganisationPhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV41OrganisationPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationphonenumber_Jsonclick, 0, "AttributePhoneNumber", "", "", "", "", 1, edtavOrganisationphonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_52_4G2e( true) ;
         }
         else
         {
            wb_table1_52_4G2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         AV8PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         AV7GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA4G2( ) ;
         WS4G2( ) ;
         WE4G2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SESSION ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV6WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV8PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV7GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4G2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createorganisationandmanagerstep1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4G2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
            AV8PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
            AV7GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
         wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
         wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WebSessionKey, wcpOAV6WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV8PreviousStep, wcpOAV8PreviousStep) != 0 ) || ( AV7GoingBack != wcpOAV7GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WebSessionKey = AV6WebSessionKey;
         wcpOAV8PreviousStep = AV8PreviousStep;
         wcpOAV7GoingBack = AV7GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV6WebSessionKey) > 0 )
         {
            AV6WebSessionKey = cgiGet( sCtrlAV6WebSessionKey);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         }
         else
         {
            AV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_PARM");
         }
         sCtrlAV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV8PreviousStep) > 0 )
         {
            AV8PreviousStep = cgiGet( sCtrlAV8PreviousStep);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         }
         else
         {
            AV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_PARM");
         }
         sCtrlAV7GoingBack = cgiGet( sPrefix+"AV7GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV7GoingBack) > 0 )
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV7GoingBack));
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         else
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV7GoingBack_PARM"));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA4G2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS4G2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_PARM", AV6WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV6WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_PARM", AV8PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV8PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_PARM", StringUtil.BoolToStr( AV7GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_CTRL", StringUtil.RTrim( sCtrlAV7GoingBack));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE4G2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202410161750025", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wp_createorganisationandmanagerstep1.js", "?202410161750025", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavOrganisationtypeid.Name = "vORGANISATIONTYPEID";
         dynavOrganisationtypeid.WebTags = "";
         dynavOrganisationtypeid.removeAllItems();
         /* Using cursor H004G6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            dynavOrganisationtypeid.addItem(H004G6_A19OrganisationTypeId[0].ToString(), H004G6_A20OrganisationTypeName[0], 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( dynavOrganisationtypeid.ItemCount > 0 )
         {
         }
         dynavOrganisationid.Name = "vORGANISATIONID";
         dynavOrganisationid.WebTags = "";
         dynavOrganisationid.removeAllItems();
         /* Using cursor H004G7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            dynavOrganisationid.addItem(H004G7_A11OrganisationId[0].ToString(), H004G7_A13OrganisationName[0], 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( dynavOrganisationid.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynavOrganisationtypeid_Internalname = sPrefix+"vORGANISATIONTYPEID";
         edtavOrganisationname_Internalname = sPrefix+"vORGANISATIONNAME";
         edtavOrganisationkvknumber_Internalname = sPrefix+"vORGANISATIONKVKNUMBER";
         edtavOrganisationvatnumber_Internalname = sPrefix+"vORGANISATIONVATNUMBER";
         edtavOrganisationemail_Internalname = sPrefix+"vORGANISATIONEMAIL";
         lblTextblockcombo_organisationphonecode_Internalname = sPrefix+"TEXTBLOCKCOMBO_ORGANISATIONPHONECODE";
         Combo_organisationphonecode_Internalname = sPrefix+"COMBO_ORGANISATIONPHONECODE";
         edtavOrganisationphonenumber_Internalname = sPrefix+"vORGANISATIONPHONENUMBER";
         tblTablemergedorganisationphonecode_Internalname = sPrefix+"TABLEMERGEDORGANISATIONPHONECODE";
         divTablesplittedorganisationphonecode_Internalname = sPrefix+"TABLESPLITTEDORGANISATIONPHONECODE";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         edtavOrganisationaddressline1_Internalname = sPrefix+"vORGANISATIONADDRESSLINE1";
         edtavOrganisationaddressline2_Internalname = sPrefix+"vORGANISATIONADDRESSLINE2";
         edtavOrganisationaddresszipcode_Internalname = sPrefix+"vORGANISATIONADDRESSZIPCODE";
         edtavOrganisationaddresscity_Internalname = sPrefix+"vORGANISATIONADDRESSCITY";
         lblTextblockcombo_organisationaddresscountry_Internalname = sPrefix+"TEXTBLOCKCOMBO_ORGANISATIONADDRESSCOUNTRY";
         Combo_organisationaddresscountry_Internalname = sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRY";
         divTablesplittedorganisationaddresscountry_Internalname = sPrefix+"TABLESPLITTEDORGANISATIONADDRESSCOUNTRY";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavOrganisationphonecode_Internalname = sPrefix+"vORGANISATIONPHONECODE";
         edtavOrganisationaddresscountry_Internalname = sPrefix+"vORGANISATIONADDRESSCOUNTRY";
         dynavOrganisationid_Internalname = sPrefix+"vORGANISATIONID";
         edtavOrganisationphone_Internalname = sPrefix+"vORGANISATIONPHONE";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtavOrganisationphonenumber_Jsonclick = "";
         edtavOrganisationphonenumber_Enabled = 1;
         Combo_organisationphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_organisationphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_organisationphonecode_Caption = "";
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         Combo_organisationphonecode_Htmltemplate = "";
         Combo_organisationaddresscountry_Htmltemplate = "";
         edtavOrganisationphone_Jsonclick = "";
         edtavOrganisationphone_Visible = 1;
         dynavOrganisationid_Jsonclick = "";
         dynavOrganisationid.Visible = 1;
         edtavOrganisationaddresscountry_Jsonclick = "";
         edtavOrganisationaddresscountry_Visible = 1;
         edtavOrganisationphonecode_Jsonclick = "";
         edtavOrganisationphonecode_Visible = 1;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = context.GetMessage( "GX_BtnCancel", "");
         Btnwizardfirstprevious_Tooltiptext = "";
         Combo_organisationaddresscountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_organisationaddresscountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_organisationaddresscountry_Caption = "";
         edtavOrganisationaddresscity_Jsonclick = "";
         edtavOrganisationaddresscity_Enabled = 1;
         edtavOrganisationaddresszipcode_Jsonclick = "";
         edtavOrganisationaddresszipcode_Enabled = 1;
         edtavOrganisationaddressline2_Jsonclick = "";
         edtavOrganisationaddressline2_Enabled = 1;
         edtavOrganisationaddressline1_Jsonclick = "";
         edtavOrganisationaddressline1_Enabled = 1;
         edtavOrganisationemail_Jsonclick = "";
         edtavOrganisationemail_Enabled = 1;
         edtavOrganisationvatnumber_Jsonclick = "";
         edtavOrganisationvatnumber_Enabled = 1;
         edtavOrganisationkvknumber_Jsonclick = "";
         edtavOrganisationkvknumber_Enabled = 1;
         edtavOrganisationname_Jsonclick = "";
         edtavOrganisationname_Enabled = 1;
         dynavOrganisationtypeid_Jsonclick = "";
         dynavOrganisationtypeid.Enabled = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK"},{"av":"dynavOrganisationid"},{"av":"AV14OrganisationId","fld":"vORGANISATIONID"},{"av":"dynavOrganisationtypeid"},{"av":"AV21OrganisationTypeId","fld":"vORGANISATIONTYPEID"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E134G2","iparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"dynavOrganisationtypeid"},{"av":"AV21OrganisationTypeId","fld":"vORGANISATIONTYPEID"},{"av":"AV16OrganisationName","fld":"vORGANISATIONNAME"},{"av":"AV15OrganisationKvkNumber","fld":"vORGANISATIONKVKNUMBER"},{"av":"AV19OrganisationVATNumber","fld":"vORGANISATIONVATNUMBER"},{"av":"AV13OrganisationEmail","fld":"vORGANISATIONEMAIL"},{"av":"AV34OrganisationAddressLine1","fld":"vORGANISATIONADDRESSLINE1"},{"av":"AV26OrganisationAddressZipCode","fld":"vORGANISATIONADDRESSZIPCODE"},{"av":"AV23OrganisationAddressCity","fld":"vORGANISATIONADDRESSCITY"},{"av":"AV27OrganisationAddressCountry","fld":"vORGANISATIONADDRESSCOUNTRY"},{"av":"Combo_organisationaddresscountry_Ddointernalname","ctrl":"COMBO_ORGANISATIONADDRESSCOUNTRY","prop":"DDOInternalName"},{"av":"AV38OrganisationPhoneCode","fld":"vORGANISATIONPHONECODE"},{"av":"AV41OrganisationPhoneNumber","fld":"vORGANISATIONPHONENUMBER"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV35OrganisationAddressLine2","fld":"vORGANISATIONADDRESSLINE2"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"dynavOrganisationid"},{"av":"AV14OrganisationId","fld":"vORGANISATIONID"},{"av":"AV17OrganisationPhone","fld":"vORGANISATIONPHONE"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E144G2","iparms":[]}""");
         setEventMetadata("VORGANISATIONVATNUMBER.CONTROLVALUECHANGED","""{"handler":"E154G2","iparms":[{"av":"AV19OrganisationVATNumber","fld":"vORGANISATIONVATNUMBER"}]""");
         setEventMetadata("VORGANISATIONVATNUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VORGANISATIONEMAIL.CONTROLVALUECHANGED","""{"handler":"E164G2","iparms":[{"av":"AV13OrganisationEmail","fld":"vORGANISATIONEMAIL"}]""");
         setEventMetadata("VORGANISATIONEMAIL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VORGANISATIONKVKNUMBER.CONTROLVALUECHANGED","""{"handler":"E174G2","iparms":[{"av":"AV15OrganisationKvkNumber","fld":"vORGANISATIONKVKNUMBER"}]""");
         setEventMetadata("VORGANISATIONKVKNUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VORGANISATIONADDRESSZIPCODE.CONTROLVALUECHANGED","""{"handler":"E184G2","iparms":[{"av":"AV26OrganisationAddressZipCode","fld":"vORGANISATIONADDRESSZIPCODE"}]""");
         setEventMetadata("VORGANISATIONADDRESSZIPCODE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VALIDV_ORGANISATIONTYPEID","""{"handler":"Validv_Organisationtypeid","iparms":[]}""");
         setEventMetadata("VALIDV_ORGANISATIONEMAIL","""{"handler":"Validv_Organisationemail","iparms":[]}""");
         setEventMetadata("VALIDV_ORGANISATIONID","""{"handler":"Validv_Organisationid","iparms":[]}""");
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

      public override void initialize( )
      {
         wcpOAV6WebSessionKey = "";
         wcpOAV8PreviousStep = "";
         Combo_organisationaddresscountry_Ddointernalname = "";
         Combo_organisationaddresscountry_Selectedvalue_get = "";
         Combo_organisationphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV29DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV39OrganisationPhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV28OrganisationAddressCountry_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV21OrganisationTypeId = Guid.Empty;
         AV16OrganisationName = "";
         AV15OrganisationKvkNumber = "";
         AV19OrganisationVATNumber = "";
         AV13OrganisationEmail = "";
         lblTextblockcombo_organisationphonecode_Jsonclick = "";
         AV34OrganisationAddressLine1 = "";
         AV35OrganisationAddressLine2 = "";
         AV26OrganisationAddressZipCode = "";
         AV23OrganisationAddressCity = "";
         lblTextblockcombo_organisationaddresscountry_Jsonclick = "";
         ucCombo_organisationaddresscountry = new GXUserControl();
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV38OrganisationPhoneCode = "";
         AV27OrganisationAddressCountry = "";
         AV14OrganisationId = Guid.Empty;
         AV17OrganisationPhone = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H004G2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H004G2_A13OrganisationName = new string[] {""} ;
         H004G3_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         H004G3_A20OrganisationTypeName = new string[] {""} ;
         H004G4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H004G4_A13OrganisationName = new string[] {""} ;
         H004G5_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         H004G5_A20OrganisationTypeName = new string[] {""} ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         ucCombo_organisationphonecode = new GXUserControl();
         AV36defaultCountry = "";
         Combo_organisationaddresscountry_Selectedtext_set = "";
         Combo_organisationaddresscountry_Selectedvalue_set = "";
         AV37defaultCountryPhoneCode = "";
         Combo_organisationphonecode_Selectedtext_set = "";
         Combo_organisationphonecode_Selectedvalue_set = "";
         AV11WizardData = new SdtWP_CreateOrganisationAndManagerData(context);
         AV5WebSession = context.GetSession();
         AV41OrganisationPhoneNumber = "";
         GXt_char2 = "";
         AV43GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV32OrganisationAddressCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV31Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV33ComboTitles = new GxSimpleCollection<string>();
         AV45GXV3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV40OrganisationPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         H004G6_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         H004G6_A20OrganisationTypeName = new string[] {""} ;
         H004G7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H004G7_A13OrganisationName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createorganisationandmanagerstep1__default(),
            new Object[][] {
                new Object[] {
               H004G2_A11OrganisationId, H004G2_A13OrganisationName
               }
               , new Object[] {
               H004G3_A19OrganisationTypeId, H004G3_A20OrganisationTypeName
               }
               , new Object[] {
               H004G4_A11OrganisationId, H004G4_A13OrganisationName
               }
               , new Object[] {
               H004G5_A19OrganisationTypeId, H004G5_A20OrganisationTypeName
               }
               , new Object[] {
               H004G6_A19OrganisationTypeId, H004G6_A20OrganisationTypeName
               }
               , new Object[] {
               H004G7_A11OrganisationId, H004G7_A13OrganisationName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavOrganisationname_Enabled ;
      private int edtavOrganisationkvknumber_Enabled ;
      private int edtavOrganisationvatnumber_Enabled ;
      private int edtavOrganisationemail_Enabled ;
      private int edtavOrganisationaddressline1_Enabled ;
      private int edtavOrganisationaddressline2_Enabled ;
      private int edtavOrganisationaddresszipcode_Enabled ;
      private int edtavOrganisationaddresscity_Enabled ;
      private int edtavOrganisationphonecode_Visible ;
      private int edtavOrganisationaddresscountry_Visible ;
      private int edtavOrganisationphone_Visible ;
      private int gxdynajaxindex ;
      private int AV44GXV2 ;
      private int AV46GXV4 ;
      private int edtavOrganisationphonenumber_Enabled ;
      private int idxLst ;
      private string Combo_organisationaddresscountry_Ddointernalname ;
      private string Combo_organisationaddresscountry_Selectedvalue_get ;
      private string Combo_organisationphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string dynavOrganisationtypeid_Internalname ;
      private string TempTags ;
      private string dynavOrganisationtypeid_Jsonclick ;
      private string edtavOrganisationname_Internalname ;
      private string edtavOrganisationname_Jsonclick ;
      private string edtavOrganisationkvknumber_Internalname ;
      private string edtavOrganisationkvknumber_Jsonclick ;
      private string edtavOrganisationvatnumber_Internalname ;
      private string edtavOrganisationvatnumber_Jsonclick ;
      private string edtavOrganisationemail_Internalname ;
      private string edtavOrganisationemail_Jsonclick ;
      private string divTablesplittedorganisationphonecode_Internalname ;
      private string lblTextblockcombo_organisationphonecode_Internalname ;
      private string lblTextblockcombo_organisationphonecode_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtavOrganisationaddressline1_Internalname ;
      private string edtavOrganisationaddressline1_Jsonclick ;
      private string edtavOrganisationaddressline2_Internalname ;
      private string edtavOrganisationaddressline2_Jsonclick ;
      private string edtavOrganisationaddresszipcode_Internalname ;
      private string edtavOrganisationaddresszipcode_Jsonclick ;
      private string edtavOrganisationaddresscity_Internalname ;
      private string edtavOrganisationaddresscity_Jsonclick ;
      private string divTablesplittedorganisationaddresscountry_Internalname ;
      private string lblTextblockcombo_organisationaddresscountry_Internalname ;
      private string lblTextblockcombo_organisationaddresscountry_Jsonclick ;
      private string Combo_organisationaddresscountry_Caption ;
      private string Combo_organisationaddresscountry_Cls ;
      private string Combo_organisationaddresscountry_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavOrganisationphonecode_Internalname ;
      private string edtavOrganisationphonecode_Jsonclick ;
      private string edtavOrganisationaddresscountry_Internalname ;
      private string edtavOrganisationaddresscountry_Jsonclick ;
      private string dynavOrganisationid_Internalname ;
      private string dynavOrganisationid_Jsonclick ;
      private string edtavOrganisationphone_Internalname ;
      private string AV17OrganisationPhone ;
      private string edtavOrganisationphone_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string Combo_organisationaddresscountry_Htmltemplate ;
      private string Combo_organisationphonecode_Htmltemplate ;
      private string Combo_organisationphonecode_Internalname ;
      private string Combo_organisationaddresscountry_Selectedtext_set ;
      private string Combo_organisationaddresscountry_Selectedvalue_set ;
      private string Combo_organisationphonecode_Selectedtext_set ;
      private string Combo_organisationphonecode_Selectedvalue_set ;
      private string GXt_char2 ;
      private string sStyleString ;
      private string tblTablemergedorganisationphonecode_Internalname ;
      private string Combo_organisationphonecode_Caption ;
      private string Combo_organisationphonecode_Cls ;
      private string edtavOrganisationphonenumber_Internalname ;
      private string edtavOrganisationphonenumber_Jsonclick ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV22CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Combo_organisationaddresscountry_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool Btnwizardfirstprevious_Visible ;
      private bool Combo_organisationphonecode_Emptyitem ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV16OrganisationName ;
      private string AV15OrganisationKvkNumber ;
      private string AV19OrganisationVATNumber ;
      private string AV13OrganisationEmail ;
      private string AV34OrganisationAddressLine1 ;
      private string AV35OrganisationAddressLine2 ;
      private string AV26OrganisationAddressZipCode ;
      private string AV23OrganisationAddressCity ;
      private string AV38OrganisationPhoneCode ;
      private string AV27OrganisationAddressCountry ;
      private string AV36defaultCountry ;
      private string AV37defaultCountryPhoneCode ;
      private string AV41OrganisationPhoneNumber ;
      private Guid AV21OrganisationTypeId ;
      private Guid AV14OrganisationId ;
      private IGxSession AV5WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucCombo_organisationaddresscountry ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucCombo_organisationphonecode ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavOrganisationtypeid ;
      private GXCombobox dynavOrganisationid ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV29DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV39OrganisationPhoneCode_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV28OrganisationAddressCountry_Data ;
      private IDataStoreProvider pr_default ;
      private Guid[] H004G2_A11OrganisationId ;
      private string[] H004G2_A13OrganisationName ;
      private Guid[] H004G3_A19OrganisationTypeId ;
      private string[] H004G3_A20OrganisationTypeName ;
      private Guid[] H004G4_A11OrganisationId ;
      private string[] H004G4_A13OrganisationName ;
      private Guid[] H004G5_A19OrganisationTypeId ;
      private string[] H004G5_A20OrganisationTypeName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private SdtWP_CreateOrganisationAndManagerData AV11WizardData ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV43GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV32OrganisationAddressCountry_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV31Combo_DataItem ;
      private GxSimpleCollection<string> AV33ComboTitles ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV45GXV3 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV40OrganisationPhoneCode_DPItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] H004G6_A19OrganisationTypeId ;
      private string[] H004G6_A20OrganisationTypeName ;
      private Guid[] H004G7_A11OrganisationId ;
      private string[] H004G7_A13OrganisationName ;
   }

   public class wp_createorganisationandmanagerstep1__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004G2;
          prmH004G2 = new Object[] {
          };
          Object[] prmH004G3;
          prmH004G3 = new Object[] {
          };
          Object[] prmH004G4;
          prmH004G4 = new Object[] {
          };
          Object[] prmH004G5;
          prmH004G5 = new Object[] {
          };
          Object[] prmH004G6;
          prmH004G6 = new Object[] {
          };
          Object[] prmH004G7;
          prmH004G7 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H004G2", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004G2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004G3", "SELECT OrganisationTypeId, OrganisationTypeName FROM Trn_OrganisationType ORDER BY OrganisationTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004G3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004G4", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004G4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004G5", "SELECT OrganisationTypeId, OrganisationTypeName FROM Trn_OrganisationType ORDER BY OrganisationTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004G5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004G6", "SELECT OrganisationTypeId, OrganisationTypeName FROM Trn_OrganisationType ORDER BY OrganisationTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004G6,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004G7", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004G7,0, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
