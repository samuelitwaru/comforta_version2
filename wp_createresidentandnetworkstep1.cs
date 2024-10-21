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
   public class wp_createresidentandnetworkstep1 : GXWebComponent
   {
      public wp_createresidentandnetworkstep1( )
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

      public wp_createresidentandnetworkstep1( IGxContext context )
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
         cmbavResidentsalutation = new GXCombobox();
         cmbavResidentgender = new GXCombobox();
         dynavResidenttypeid = new GXCombobox();
         dynavMedicalindicationid = new GXCombobox();
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
            PA6Q2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS6Q2( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Create Resident And Network Step1", "")) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
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
            GXEncryptionTmp = "wp_createresidentandnetworkstep1.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createresidentandnetworkstep1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTPHONECODE_DATA", AV41ResidentPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTPHONECODE_DATA", AV41ResidentPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTCOUNTRY_DATA", AV33ResidentCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTCOUNTRY_DATA", AV33ResidentCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV31CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTCOUNTRY_Ddointernalname", StringUtil.RTrim( Combo_residentcountry_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTCOUNTRY_Selectedvalue_get", StringUtil.RTrim( Combo_residentcountry_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_residentphonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RESIDENTCOUNTRY_Ddointernalname", StringUtil.RTrim( Combo_residentcountry_Ddointernalname));
      }

      protected void RenderHtmlCloseForm6Q2( )
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
         return "WP_CreateResidentAndNetworkStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Resident And Network Step1", "") ;
      }

      protected void WB6Q0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createresidentandnetworkstep1.aspx");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Resident Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavResidentsalutation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResidentsalutation_Internalname, context.GetMessage( "Salutation", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResidentsalutation, cmbavResidentsalutation_Internalname, StringUtil.RTrim( AV13ResidentSalutation), 1, cmbavResidentsalutation_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavResidentsalutation.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", false, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            cmbavResidentsalutation.CurrentValue = StringUtil.RTrim( AV13ResidentSalutation);
            AssignProp(sPrefix, false, cmbavResidentsalutation_Internalname, "Values", (string)(cmbavResidentsalutation.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentgivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentgivenname_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentgivenname_Internalname, AV14ResidentGivenName, StringUtil.RTrim( context.localUtil.Format( AV14ResidentGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentgivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentgivenname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentlastname_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentlastname_Internalname, AV15ResidentLastName, StringUtil.RTrim( context.localUtil.Format( AV15ResidentLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentlastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavResidentgender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavResidentgender_Internalname, context.GetMessage( "Gender", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavResidentgender, cmbavResidentgender_Internalname, StringUtil.RTrim( AV16ResidentGender), 1, cmbavResidentgender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavResidentgender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", false, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            cmbavResidentgender.CurrentValue = StringUtil.RTrim( AV16ResidentGender);
            AssignProp(sPrefix, false, cmbavResidentgender_Internalname, "Values", (string)(cmbavResidentgender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentbirthdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentbirthdate_Internalname, context.GetMessage( "Date Of Birth", ""), "col-sm-4 AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavResidentbirthdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavResidentbirthdate_Internalname, context.localUtil.Format(AV17ResidentBirthDate, "99/99/9999"), context.localUtil.Format( AV17ResidentBirthDate, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentbirthdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavResidentbirthdate_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_bitmap( context, edtavResidentbirthdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavResidentbirthdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentemail_Internalname, AV18ResidentEmail, StringUtil.RTrim( context.localUtil.Format( AV18ResidentEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresidentphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_residentphonecode_Internalname, context.GetMessage( "Phone", ""), "", "", lblTextblockcombo_residentphonecode_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table1_57_6Q2( true) ;
         }
         else
         {
            wb_table1_57_6Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_57_6Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentbsnnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentbsnnumber_Internalname, context.GetMessage( "BSN Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentbsnnumber_Internalname, AV12ResidentBsnNumber, StringUtil.RTrim( context.localUtil.Format( AV12ResidentBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentbsnnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentbsnnumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavResidenttypeid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavResidenttypeid_Internalname, context.GetMessage( "Resident Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavResidenttypeid, dynavResidenttypeid_Internalname, AV23ResidentTypeId.ToString(), 1, dynavResidenttypeid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "guid", "", 1, dynavResidenttypeid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", false, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            dynavResidenttypeid.CurrentValue = AV23ResidentTypeId.ToString();
            AssignProp(sPrefix, false, dynavResidenttypeid_Internalname, "Values", (string)(dynavResidenttypeid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavMedicalindicationid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavMedicalindicationid_Internalname, context.GetMessage( "Medical Indication", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavMedicalindicationid, dynavMedicalindicationid_Internalname, AV25MedicalIndicationId.ToString(), 1, dynavMedicalindicationid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "guid", "", 1, dynavMedicalindicationid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", false, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            dynavMedicalindicationid.CurrentValue = AV25MedicalIndicationId.ToString();
            AssignProp(sPrefix, false, dynavMedicalindicationid_Internalname, "Values", (string)(dynavMedicalindicationid.ToJavascriptSource()), true);
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentaddressline1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentaddressline1_Internalname, AV29ResidentAddressLine1, StringUtil.RTrim( context.localUtil.Format( AV29ResidentAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentaddressline1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentaddressline2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentaddressline2_Internalname, AV30ResidentAddressLine2, StringUtil.RTrim( context.localUtil.Format( AV30ResidentAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentaddressline2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentzipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentzipcode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentzipcode_Internalname, AV28ResidentZipCode, StringUtil.RTrim( context.localUtil.Format( AV28ResidentZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentzipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentzipcode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResidentcity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentcity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentcity_Internalname, AV27ResidentCity, StringUtil.RTrim( context.localUtil.Format( AV27ResidentCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentcity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentcity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedresidentcountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_residentcountry_Internalname, context.GetMessage( "Country", ""), "", "", lblTextblockcombo_residentcountry_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_residentcountry.SetProperty("Caption", Combo_residentcountry_Caption);
            ucCombo_residentcountry.SetProperty("Cls", Combo_residentcountry_Cls);
            ucCombo_residentcountry.SetProperty("EmptyItem", Combo_residentcountry_Emptyitem);
            ucCombo_residentcountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
            ucCombo_residentcountry.SetProperty("DropDownOptionsData", AV33ResidentCountry_Data);
            ucCombo_residentcountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentcountry_Internalname, sPrefix+"COMBO_RESIDENTCOUNTRYContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentphonecode_Internalname, AV39ResidentPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV39ResidentPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentphonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentcountry_Internalname, AV26ResidentCountry, StringUtil.RTrim( context.localUtil.Format( AV26ResidentCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentcountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentcountry_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentid_Internalname, AV21ResidentId.ToString(), AV21ResidentId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentid_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, false, "", "", false, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentphone_Internalname, StringUtil.RTrim( AV19ResidentPhone), StringUtil.RTrim( context.localUtil.Format( AV19ResidentPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidentphone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidenttypename_Internalname, AV24ResidentTypeName, StringUtil.RTrim( context.localUtil.Format( AV24ResidentTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidenttypename_Jsonclick, 0, "Attribute", "", "", "", "", edtavResidenttypename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6Q2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Create Resident And Network Step1", ""), 0) ;
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
               STRUP6Q0( ) ;
            }
         }
      }

      protected void WS6Q2( )
      {
         START6Q2( ) ;
         EVT6Q2( ) ;
      }

      protected void EVT6Q2( )
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
                                 STRUP6Q0( ) ;
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
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E116Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E126Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
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
                                          E136Q2 ();
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
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E146Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESIDENTEMAIL.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E156Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESIDENTBSNNUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E166Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRESIDENTZIPCODE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E176Q2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E186Q2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6Q0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavResidentsalutation_Internalname;
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

      protected void WE6Q2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6Q2( ) ;
            }
         }
      }

      protected void PA6Q2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createresidentandnetworkstep1.aspx")), "wp_createresidentandnetworkstep1.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createresidentandnetworkstep1.aspx")))) ;
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
               GX_FocusControl = cmbavResidentsalutation_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvMEDICALINDICATIONID6Q1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvMEDICALINDICATIONID_data6Q1( ) ;
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

      protected void GXVvMEDICALINDICATIONID_html6Q1( )
      {
         Guid gxdynajaxvalue;
         GXDLVvMEDICALINDICATIONID_data6Q1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavMedicalindicationid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavMedicalindicationid.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavMedicalindicationid.ItemCount > 0 )
         {
            AV25MedicalIndicationId = StringUtil.StrToGuid( dynavMedicalindicationid.getValidValue(AV25MedicalIndicationId.ToString()));
            AssignAttri(sPrefix, false, "AV25MedicalIndicationId", AV25MedicalIndicationId.ToString());
         }
      }

      protected void GXDLVvMEDICALINDICATIONID_data6Q1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H006Q2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H006Q2_A98MedicalIndicationId[0].ToString());
            gxdynajaxctrldescr.Add(H006Q2_A99MedicalIndicationName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvRESIDENTTYPEID6Q1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvRESIDENTTYPEID_data6Q1( ) ;
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

      protected void GXVvRESIDENTTYPEID_html6Q1( )
      {
         Guid gxdynajaxvalue;
         GXDLVvRESIDENTTYPEID_data6Q1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavResidenttypeid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavResidenttypeid.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavResidenttypeid.ItemCount > 0 )
         {
            AV23ResidentTypeId = StringUtil.StrToGuid( dynavResidenttypeid.getValidValue(AV23ResidentTypeId.ToString()));
            AssignAttri(sPrefix, false, "AV23ResidentTypeId", AV23ResidentTypeId.ToString());
         }
      }

      protected void GXDLVvRESIDENTTYPEID_data6Q1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H006Q3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(H006Q3_A96ResidentTypeId[0].ToString());
            gxdynajaxctrldescr.Add(H006Q3_A97ResidentTypeName[0]);
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
            dynavMedicalindicationid.Name = "vMEDICALINDICATIONID";
            dynavMedicalindicationid.WebTags = "";
            dynavMedicalindicationid.removeAllItems();
            /* Using cursor H006Q4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               dynavMedicalindicationid.addItem(H006Q4_A98MedicalIndicationId[0].ToString(), H006Q4_A99MedicalIndicationName[0], 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( dynavMedicalindicationid.ItemCount > 0 )
            {
               AV25MedicalIndicationId = StringUtil.StrToGuid( dynavMedicalindicationid.getValidValue(AV25MedicalIndicationId.ToString()));
               AssignAttri(sPrefix, false, "AV25MedicalIndicationId", AV25MedicalIndicationId.ToString());
            }
            dynavResidenttypeid.Name = "vRESIDENTTYPEID";
            dynavResidenttypeid.WebTags = "";
            dynavResidenttypeid.removeAllItems();
            /* Using cursor H006Q5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynavResidenttypeid.addItem(H006Q5_A96ResidentTypeId[0].ToString(), H006Q5_A97ResidentTypeName[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynavResidenttypeid.ItemCount > 0 )
            {
               AV23ResidentTypeId = StringUtil.StrToGuid( dynavResidenttypeid.getValidValue(AV23ResidentTypeId.ToString()));
               AssignAttri(sPrefix, false, "AV23ResidentTypeId", AV23ResidentTypeId.ToString());
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavResidentsalutation.ItemCount > 0 )
         {
            AV13ResidentSalutation = cmbavResidentsalutation.getValidValue(AV13ResidentSalutation);
            AssignAttri(sPrefix, false, "AV13ResidentSalutation", AV13ResidentSalutation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResidentsalutation.CurrentValue = StringUtil.RTrim( AV13ResidentSalutation);
            AssignProp(sPrefix, false, cmbavResidentsalutation_Internalname, "Values", cmbavResidentsalutation.ToJavascriptSource(), true);
         }
         if ( cmbavResidentgender.ItemCount > 0 )
         {
            AV16ResidentGender = cmbavResidentgender.getValidValue(AV16ResidentGender);
            AssignAttri(sPrefix, false, "AV16ResidentGender", AV16ResidentGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavResidentgender.CurrentValue = StringUtil.RTrim( AV16ResidentGender);
            AssignProp(sPrefix, false, cmbavResidentgender_Internalname, "Values", cmbavResidentgender.ToJavascriptSource(), true);
         }
         if ( dynavResidenttypeid.ItemCount > 0 )
         {
            AV23ResidentTypeId = StringUtil.StrToGuid( dynavResidenttypeid.getValidValue(AV23ResidentTypeId.ToString()));
            AssignAttri(sPrefix, false, "AV23ResidentTypeId", AV23ResidentTypeId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavResidenttypeid.CurrentValue = AV23ResidentTypeId.ToString();
            AssignProp(sPrefix, false, dynavResidenttypeid_Internalname, "Values", dynavResidenttypeid.ToJavascriptSource(), true);
         }
         if ( dynavMedicalindicationid.ItemCount > 0 )
         {
            AV25MedicalIndicationId = StringUtil.StrToGuid( dynavMedicalindicationid.getValidValue(AV25MedicalIndicationId.ToString()));
            AssignAttri(sPrefix, false, "AV25MedicalIndicationId", AV25MedicalIndicationId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavMedicalindicationid.CurrentValue = AV25MedicalIndicationId.ToString();
            AssignProp(sPrefix, false, dynavMedicalindicationid_Internalname, "Values", dynavMedicalindicationid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF6Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E126Q2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E186Q2 ();
            WB6Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6Q2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116Q2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV34DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESIDENTPHONECODE_DATA"), AV41ResidentPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRESIDENTCOUNTRY_DATA"), AV33ResidentCountry_Data);
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            Combo_residentcountry_Ddointernalname = cgiGet( sPrefix+"COMBO_RESIDENTCOUNTRY_Ddointernalname");
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
         E116Q2 ();
         if (returnInSub) return;
      }

      protected void E116Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV34DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV34DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavResidentcountry_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentcountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentcountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_residentcountry_Htmltemplate = GXt_char2;
         ucCombo_residentcountry.SendProperty(context, sPrefix, false, Combo_residentcountry_Internalname, "HTMLTemplate", Combo_residentcountry_Htmltemplate);
         edtavResidentphonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_residentphonecode_Htmltemplate = GXt_char2;
         ucCombo_residentphonecode.SendProperty(context, sPrefix, false, Combo_residentphonecode_Internalname, "HTMLTemplate", Combo_residentphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBORESIDENTPHONECODE' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBORESIDENTCOUNTRY' */
         S132 ();
         if (returnInSub) return;
         edtavResidentid_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentid_Visible), 5, 0), true);
         edtavResidentphone_Visible = 0;
         AssignProp(sPrefix, false, edtavResidentphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidentphone_Visible), 5, 0), true);
         edtavResidenttypename_Visible = 0;
         AssignProp(sPrefix, false, edtavResidenttypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavResidenttypename_Visible), 5, 0), true);
         AV38defaultCountry = "Netherlands";
         Combo_residentcountry_Selectedtext_set = AV38defaultCountry;
         ucCombo_residentcountry.SendProperty(context, sPrefix, false, Combo_residentcountry_Internalname, "SelectedText_set", Combo_residentcountry_Selectedtext_set);
         Combo_residentcountry_Selectedvalue_set = AV38defaultCountry;
         ucCombo_residentcountry.SendProperty(context, sPrefix, false, Combo_residentcountry_Internalname, "SelectedValue_set", Combo_residentcountry_Selectedvalue_set);
         AV26ResidentCountry = AV38defaultCountry;
         AssignAttri(sPrefix, false, "AV26ResidentCountry", AV26ResidentCountry);
         AV43defaultCountryPhoneCode = "+31";
         AV39ResidentPhoneCode = "+31";
         AssignAttri(sPrefix, false, "AV39ResidentPhoneCode", AV39ResidentPhoneCode);
         Combo_residentphonecode_Selectedtext_set = AV43defaultCountryPhoneCode;
         ucCombo_residentphonecode.SendProperty(context, sPrefix, false, Combo_residentphonecode_Internalname, "SelectedText_set", Combo_residentphonecode_Selectedtext_set);
         Combo_residentphonecode_Selectedvalue_set = AV43defaultCountryPhoneCode;
         ucCombo_residentphonecode.SendProperty(context, sPrefix, false, Combo_residentphonecode_Internalname, "SelectedValue_set", Combo_residentphonecode_Selectedvalue_set);
      }

      protected void E126Q2( )
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
         E136Q2 ();
         if (returnInSub) return;
      }

      protected void E136Q2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S152 ();
         if (returnInSub) return;
         if ( AV31CheckRequiredFieldsResult && ! AV10HasValidationErrors )
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
            GXEncryptionTmp = "wp_createresidentandnetwork.aspx"+UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wp_createresidentandnetwork.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E146Q2( )
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
         AV29ResidentAddressLine1 = AV11WizardData.gxTpr_Step1.gxTpr_Residentaddressline1;
         AssignAttri(sPrefix, false, "AV29ResidentAddressLine1", AV29ResidentAddressLine1);
         AV30ResidentAddressLine2 = AV11WizardData.gxTpr_Step1.gxTpr_Residentaddressline2;
         AssignAttri(sPrefix, false, "AV30ResidentAddressLine2", AV30ResidentAddressLine2);
         AV28ResidentZipCode = AV11WizardData.gxTpr_Step1.gxTpr_Residentzipcode;
         AssignAttri(sPrefix, false, "AV28ResidentZipCode", AV28ResidentZipCode);
         AV27ResidentCity = AV11WizardData.gxTpr_Step1.gxTpr_Residentcity;
         AssignAttri(sPrefix, false, "AV27ResidentCity", AV27ResidentCity);
         AV26ResidentCountry = AV11WizardData.gxTpr_Step1.gxTpr_Residentcountry;
         AssignAttri(sPrefix, false, "AV26ResidentCountry", AV26ResidentCountry);
         AV21ResidentId = AV11WizardData.gxTpr_Step1.gxTpr_Residentid;
         AssignAttri(sPrefix, false, "AV21ResidentId", AV21ResidentId.ToString());
         AV13ResidentSalutation = AV11WizardData.gxTpr_Step1.gxTpr_Residentsalutation;
         AssignAttri(sPrefix, false, "AV13ResidentSalutation", AV13ResidentSalutation);
         AV14ResidentGivenName = AV11WizardData.gxTpr_Step1.gxTpr_Residentgivenname;
         AssignAttri(sPrefix, false, "AV14ResidentGivenName", AV14ResidentGivenName);
         AV15ResidentLastName = AV11WizardData.gxTpr_Step1.gxTpr_Residentlastname;
         AssignAttri(sPrefix, false, "AV15ResidentLastName", AV15ResidentLastName);
         AV16ResidentGender = AV11WizardData.gxTpr_Step1.gxTpr_Residentgender;
         AssignAttri(sPrefix, false, "AV16ResidentGender", AV16ResidentGender);
         AV17ResidentBirthDate = AV11WizardData.gxTpr_Step1.gxTpr_Residentbirthdate;
         AssignAttri(sPrefix, false, "AV17ResidentBirthDate", context.localUtil.Format(AV17ResidentBirthDate, "99/99/9999"));
         AV18ResidentEmail = AV11WizardData.gxTpr_Step1.gxTpr_Residentemail;
         AssignAttri(sPrefix, false, "AV18ResidentEmail", AV18ResidentEmail);
         AV39ResidentPhoneCode = AV11WizardData.gxTpr_Step1.gxTpr_Residentphonecode;
         AssignAttri(sPrefix, false, "AV39ResidentPhoneCode", AV39ResidentPhoneCode);
         AV40ResidentPhoneNumber = AV11WizardData.gxTpr_Step1.gxTpr_Residentphonenumber;
         AssignAttri(sPrefix, false, "AV40ResidentPhoneNumber", AV40ResidentPhoneNumber);
         AV19ResidentPhone = AV11WizardData.gxTpr_Step1.gxTpr_Residentphone;
         AssignAttri(sPrefix, false, "AV19ResidentPhone", AV19ResidentPhone);
         AV12ResidentBsnNumber = AV11WizardData.gxTpr_Step1.gxTpr_Residentbsnnumber;
         AssignAttri(sPrefix, false, "AV12ResidentBsnNumber", AV12ResidentBsnNumber);
         AV23ResidentTypeId = AV11WizardData.gxTpr_Step1.gxTpr_Residenttypeid;
         AssignAttri(sPrefix, false, "AV23ResidentTypeId", AV23ResidentTypeId.ToString());
         AV24ResidentTypeName = AV11WizardData.gxTpr_Step1.gxTpr_Residenttypename;
         AssignAttri(sPrefix, false, "AV24ResidentTypeName", AV24ResidentTypeName);
         AV25MedicalIndicationId = AV11WizardData.gxTpr_Step1.gxTpr_Medicalindicationid;
         AssignAttri(sPrefix, false, "AV25MedicalIndicationId", AV25MedicalIndicationId.ToString());
      }

      protected void S162( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         GXt_char2 = AV19ResidentPhone;
         new prc_concatenateintlphone(context ).execute(  AV39ResidentPhoneCode,  AV40ResidentPhoneNumber, out  GXt_char2) ;
         AV19ResidentPhone = GXt_char2;
         AssignAttri(sPrefix, false, "AV19ResidentPhone", AV19ResidentPhone);
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Step1.gxTpr_Residentaddressline1 = AV29ResidentAddressLine1;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentaddressline2 = AV30ResidentAddressLine2;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentzipcode = AV28ResidentZipCode;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentcity = AV27ResidentCity;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentcountry = AV26ResidentCountry;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentid = AV21ResidentId;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentsalutation = AV13ResidentSalutation;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentgivenname = AV14ResidentGivenName;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentlastname = AV15ResidentLastName;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentgender = AV16ResidentGender;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentbirthdate = AV17ResidentBirthDate;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentemail = AV18ResidentEmail;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentphonecode = AV39ResidentPhoneCode;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentphonenumber = AV40ResidentPhoneNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentphone = AV19ResidentPhone;
         AV11WizardData.gxTpr_Step1.gxTpr_Residentbsnnumber = AV12ResidentBsnNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Residenttypeid = AV23ResidentTypeId;
         AV11WizardData.gxTpr_Step1.gxTpr_Residenttypename = AV24ResidentTypeName;
         AV11WizardData.gxTpr_Step1.gxTpr_Medicalindicationid = AV25MedicalIndicationId;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV31CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14ResidentGivenName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "First Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentgivenname_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15ResidentLastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Last Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentlastname_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ResidentGender)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Gender", ""), "", "", "", "", "", "", "", ""),  "error",  cmbavResidentgender_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ResidentEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentemail_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12ResidentBsnNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "BSN Number", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentbsnnumber_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( (Guid.Empty==AV23ResidentTypeId) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Type", ""), "", "", "", "", "", "", "", ""),  "error",  dynavResidenttypeid_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29ResidentAddressLine1)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Address Line 1", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentaddressline1_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28ResidentZipCode)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Zip Code", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentzipcode_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27ResidentCity)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "City", ""), "", "", "", "", "", "", "", ""),  "error",  edtavResidentcity_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26ResidentCountry)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Country", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_residentcountry_Ddointernalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ResidentEmail)) && ! GxRegex.IsMatch(AV18ResidentEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBORESIDENTCOUNTRY' Routine */
         returnInSub = false;
         AV45GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV44GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV44GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV45GXV2 <= AV44GXV1.Count )
         {
            AV37ResidentCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV44GXV1.Item(AV45GXV2));
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = AV37ResidentCountry_DPItem.gxTpr_Countryname;
            AV32ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV32ComboTitles.Add(AV37ResidentCountry_DPItem.gxTpr_Countryname, 0);
            AV32ComboTitles.Add(AV37ResidentCountry_DPItem.gxTpr_Countryflag, 0);
            AV36Combo_DataItem.gxTpr_Title = AV32ComboTitles.ToJSonString(false);
            AV33ResidentCountry_Data.Add(AV36Combo_DataItem, 0);
            AV45GXV2 = (int)(AV45GXV2+1);
         }
         AV33ResidentCountry_Data.Sort("Title");
         Combo_residentcountry_Selectedvalue_set = AV26ResidentCountry;
         ucCombo_residentcountry.SendProperty(context, sPrefix, false, Combo_residentcountry_Internalname, "SelectedValue_set", Combo_residentcountry_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBORESIDENTPHONECODE' Routine */
         returnInSub = false;
         AV47GXV4 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV46GXV3;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV46GXV3 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV47GXV4 <= AV46GXV3.Count )
         {
            AV42ResidentPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV46GXV3.Item(AV47GXV4));
            AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV36Combo_DataItem.gxTpr_Id = AV42ResidentPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV32ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV32ComboTitles.Add(AV42ResidentPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV32ComboTitles.Add(AV42ResidentPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV36Combo_DataItem.gxTpr_Title = AV32ComboTitles.ToJSonString(false);
            AV41ResidentPhoneCode_Data.Add(AV36Combo_DataItem, 0);
            AV47GXV4 = (int)(AV47GXV4+1);
         }
         AV41ResidentPhoneCode_Data.Sort("Title");
         Combo_residentphonecode_Selectedvalue_set = AV39ResidentPhoneCode;
         ucCombo_residentphonecode.SendProperty(context, sPrefix, false, Combo_residentphonecode_Internalname, "SelectedValue_set", Combo_residentphonecode_Selectedvalue_set);
      }

      protected void E156Q2( )
      {
         /* Residentemail_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV18ResidentEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Email is incorrect", ""),  "error",  edtavResidentemail_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E166Q2( )
      {
         /* Residentbsnnumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( StringUtil.Len( AV12ResidentBsnNumber) != 9 )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "BSN is 9 digits long", ""),  "error",  edtavResidentbsnnumber_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E176Q2( )
      {
         /* Residentzipcode_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV28ResidentZipCode,context.GetMessage( "^\\d{4} [a-zA-Z]{2}$", "")) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Zip Code is incorrect", ""),  "error",  edtavResidentzipcode_Internalname,  "true",  ""));
            AV31CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV31CheckRequiredFieldsResult", AV31CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E186Q2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_57_6Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedresidentphonecode_Internalname, tblTablemergedresidentphonecode_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_residentphonecode.SetProperty("Caption", Combo_residentphonecode_Caption);
            ucCombo_residentphonecode.SetProperty("Cls", Combo_residentphonecode_Cls);
            ucCombo_residentphonecode.SetProperty("EmptyItem", Combo_residentphonecode_Emptyitem);
            ucCombo_residentphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
            ucCombo_residentphonecode.SetProperty("DropDownOptionsData", AV41ResidentPhoneCode_Data);
            ucCombo_residentphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_residentphonecode_Internalname, sPrefix+"COMBO_RESIDENTPHONECODEContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentphonenumber_Internalname, context.GetMessage( "Resident Phone Number", ""), "gx-form-item AttributePhoneNumberLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentphonenumber_Internalname, AV40ResidentPhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV40ResidentPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentphonenumber_Jsonclick, 0, "AttributePhoneNumber", "", "", "", "", 1, edtavResidentphonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, false, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_57_6Q2e( true) ;
         }
         else
         {
            wb_table1_57_6Q2e( false) ;
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
         PA6Q2( ) ;
         WS6Q2( ) ;
         WE6Q2( ) ;
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
         PA6Q2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createresidentandnetworkstep1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6Q2( ) ;
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
         PA6Q2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6Q2( ) ;
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
         WS6Q2( ) ;
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
         WE6Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241021934279", true, true);
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
         context.AddJavascriptSource("wp_createresidentandnetworkstep1.js", "?20241021934279", false, true);
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
         cmbavResidentsalutation.Name = "vRESIDENTSALUTATION";
         cmbavResidentsalutation.WebTags = "";
         cmbavResidentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbavResidentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbavResidentsalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
         cmbavResidentsalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
         if ( cmbavResidentsalutation.ItemCount > 0 )
         {
         }
         cmbavResidentgender.Name = "vRESIDENTGENDER";
         cmbavResidentgender.WebTags = "";
         cmbavResidentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavResidentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavResidentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavResidentgender.ItemCount > 0 )
         {
         }
         dynavResidenttypeid.Name = "vRESIDENTTYPEID";
         dynavResidenttypeid.WebTags = "";
         dynavResidenttypeid.removeAllItems();
         /* Using cursor H006Q6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            dynavResidenttypeid.addItem(H006Q6_A96ResidentTypeId[0].ToString(), H006Q6_A97ResidentTypeName[0], 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( dynavResidenttypeid.ItemCount > 0 )
         {
         }
         dynavMedicalindicationid.Name = "vMEDICALINDICATIONID";
         dynavMedicalindicationid.WebTags = "";
         dynavMedicalindicationid.removeAllItems();
         /* Using cursor H006Q7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            dynavMedicalindicationid.addItem(H006Q7_A98MedicalIndicationId[0].ToString(), H006Q7_A99MedicalIndicationName[0], 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         if ( dynavMedicalindicationid.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavResidentsalutation_Internalname = sPrefix+"vRESIDENTSALUTATION";
         edtavResidentgivenname_Internalname = sPrefix+"vRESIDENTGIVENNAME";
         edtavResidentlastname_Internalname = sPrefix+"vRESIDENTLASTNAME";
         cmbavResidentgender_Internalname = sPrefix+"vRESIDENTGENDER";
         edtavResidentbirthdate_Internalname = sPrefix+"vRESIDENTBIRTHDATE";
         edtavResidentemail_Internalname = sPrefix+"vRESIDENTEMAIL";
         lblTextblockcombo_residentphonecode_Internalname = sPrefix+"TEXTBLOCKCOMBO_RESIDENTPHONECODE";
         Combo_residentphonecode_Internalname = sPrefix+"COMBO_RESIDENTPHONECODE";
         edtavResidentphonenumber_Internalname = sPrefix+"vRESIDENTPHONENUMBER";
         tblTablemergedresidentphonecode_Internalname = sPrefix+"TABLEMERGEDRESIDENTPHONECODE";
         divTablesplittedresidentphonecode_Internalname = sPrefix+"TABLESPLITTEDRESIDENTPHONECODE";
         edtavResidentbsnnumber_Internalname = sPrefix+"vRESIDENTBSNNUMBER";
         dynavResidenttypeid_Internalname = sPrefix+"vRESIDENTTYPEID";
         dynavMedicalindicationid_Internalname = sPrefix+"vMEDICALINDICATIONID";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         edtavResidentaddressline1_Internalname = sPrefix+"vRESIDENTADDRESSLINE1";
         edtavResidentaddressline2_Internalname = sPrefix+"vRESIDENTADDRESSLINE2";
         edtavResidentzipcode_Internalname = sPrefix+"vRESIDENTZIPCODE";
         edtavResidentcity_Internalname = sPrefix+"vRESIDENTCITY";
         lblTextblockcombo_residentcountry_Internalname = sPrefix+"TEXTBLOCKCOMBO_RESIDENTCOUNTRY";
         Combo_residentcountry_Internalname = sPrefix+"COMBO_RESIDENTCOUNTRY";
         divTablesplittedresidentcountry_Internalname = sPrefix+"TABLESPLITTEDRESIDENTCOUNTRY";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavResidentphonecode_Internalname = sPrefix+"vRESIDENTPHONECODE";
         edtavResidentcountry_Internalname = sPrefix+"vRESIDENTCOUNTRY";
         edtavResidentid_Internalname = sPrefix+"vRESIDENTID";
         edtavResidentphone_Internalname = sPrefix+"vRESIDENTPHONE";
         edtavResidenttypename_Internalname = sPrefix+"vRESIDENTTYPENAME";
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
         edtavResidentphonenumber_Jsonclick = "";
         edtavResidentphonenumber_Enabled = 1;
         Combo_residentphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_residentphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_residentphonecode_Caption = "";
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         Combo_residentphonecode_Htmltemplate = "";
         Combo_residentcountry_Htmltemplate = "";
         edtavResidenttypename_Jsonclick = "";
         edtavResidenttypename_Visible = 1;
         edtavResidentphone_Jsonclick = "";
         edtavResidentphone_Visible = 1;
         edtavResidentid_Jsonclick = "";
         edtavResidentid_Visible = 1;
         edtavResidentcountry_Jsonclick = "";
         edtavResidentcountry_Visible = 1;
         edtavResidentphonecode_Jsonclick = "";
         edtavResidentphonecode_Visible = 1;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = context.GetMessage( "GX_BtnCancel", "");
         Btnwizardfirstprevious_Tooltiptext = "";
         Combo_residentcountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_residentcountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_residentcountry_Caption = "";
         edtavResidentcity_Jsonclick = "";
         edtavResidentcity_Enabled = 1;
         edtavResidentzipcode_Jsonclick = "";
         edtavResidentzipcode_Enabled = 1;
         edtavResidentaddressline2_Jsonclick = "";
         edtavResidentaddressline2_Enabled = 1;
         edtavResidentaddressline1_Jsonclick = "";
         edtavResidentaddressline1_Enabled = 1;
         dynavMedicalindicationid_Jsonclick = "";
         dynavMedicalindicationid.Enabled = 1;
         dynavResidenttypeid_Jsonclick = "";
         dynavResidenttypeid.Enabled = 1;
         edtavResidentbsnnumber_Jsonclick = "";
         edtavResidentbsnnumber_Enabled = 1;
         edtavResidentemail_Jsonclick = "";
         edtavResidentemail_Enabled = 1;
         edtavResidentbirthdate_Jsonclick = "";
         edtavResidentbirthdate_Enabled = 1;
         cmbavResidentgender_Jsonclick = "";
         cmbavResidentgender.Enabled = 1;
         edtavResidentlastname_Jsonclick = "";
         edtavResidentlastname_Enabled = 1;
         edtavResidentgivenname_Jsonclick = "";
         edtavResidentgivenname_Enabled = 1;
         cmbavResidentsalutation_Jsonclick = "";
         cmbavResidentsalutation.Enabled = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK"},{"av":"dynavMedicalindicationid"},{"av":"AV25MedicalIndicationId","fld":"vMEDICALINDICATIONID"},{"av":"dynavResidenttypeid"},{"av":"AV23ResidentTypeId","fld":"vRESIDENTTYPEID"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E136Q2","iparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV14ResidentGivenName","fld":"vRESIDENTGIVENNAME"},{"av":"AV15ResidentLastName","fld":"vRESIDENTLASTNAME"},{"av":"cmbavResidentgender"},{"av":"AV16ResidentGender","fld":"vRESIDENTGENDER"},{"av":"AV18ResidentEmail","fld":"vRESIDENTEMAIL"},{"av":"AV12ResidentBsnNumber","fld":"vRESIDENTBSNNUMBER"},{"av":"dynavResidenttypeid"},{"av":"AV23ResidentTypeId","fld":"vRESIDENTTYPEID"},{"av":"AV29ResidentAddressLine1","fld":"vRESIDENTADDRESSLINE1"},{"av":"AV28ResidentZipCode","fld":"vRESIDENTZIPCODE"},{"av":"AV27ResidentCity","fld":"vRESIDENTCITY"},{"av":"AV26ResidentCountry","fld":"vRESIDENTCOUNTRY"},{"av":"Combo_residentcountry_Ddointernalname","ctrl":"COMBO_RESIDENTCOUNTRY","prop":"DDOInternalName"},{"av":"AV39ResidentPhoneCode","fld":"vRESIDENTPHONECODE"},{"av":"AV40ResidentPhoneNumber","fld":"vRESIDENTPHONENUMBER"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV30ResidentAddressLine2","fld":"vRESIDENTADDRESSLINE2"},{"av":"AV21ResidentId","fld":"vRESIDENTID"},{"av":"cmbavResidentsalutation"},{"av":"AV13ResidentSalutation","fld":"vRESIDENTSALUTATION"},{"av":"AV17ResidentBirthDate","fld":"vRESIDENTBIRTHDATE"},{"av":"AV24ResidentTypeName","fld":"vRESIDENTTYPENAME"},{"av":"dynavMedicalindicationid"},{"av":"AV25MedicalIndicationId","fld":"vMEDICALINDICATIONID"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV19ResidentPhone","fld":"vRESIDENTPHONE"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E146Q2","iparms":[]}""");
         setEventMetadata("VRESIDENTEMAIL.CONTROLVALUECHANGED","""{"handler":"E156Q2","iparms":[{"av":"AV18ResidentEmail","fld":"vRESIDENTEMAIL"}]""");
         setEventMetadata("VRESIDENTEMAIL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VRESIDENTBSNNUMBER.CONTROLVALUECHANGED","""{"handler":"E166Q2","iparms":[{"av":"AV12ResidentBsnNumber","fld":"vRESIDENTBSNNUMBER"}]""");
         setEventMetadata("VRESIDENTBSNNUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VRESIDENTZIPCODE.CONTROLVALUECHANGED","""{"handler":"E176Q2","iparms":[{"av":"AV28ResidentZipCode","fld":"vRESIDENTZIPCODE"}]""");
         setEventMetadata("VRESIDENTZIPCODE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV31CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VALIDV_RESIDENTSALUTATION","""{"handler":"Validv_Residentsalutation","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTGENDER","""{"handler":"Validv_Residentgender","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTEMAIL","""{"handler":"Validv_Residentemail","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTTYPEID","""{"handler":"Validv_Residenttypeid","iparms":[]}""");
         setEventMetadata("VALIDV_MEDICALINDICATIONID","""{"handler":"Validv_Medicalindicationid","iparms":[]}""");
         setEventMetadata("VALIDV_RESIDENTID","""{"handler":"Validv_Residentid","iparms":[]}""");
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
         Combo_residentcountry_Ddointernalname = "";
         Combo_residentcountry_Selectedvalue_get = "";
         Combo_residentphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV34DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41ResidentPhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV33ResidentCountry_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV13ResidentSalutation = "";
         AV14ResidentGivenName = "";
         AV15ResidentLastName = "";
         AV16ResidentGender = "";
         AV17ResidentBirthDate = DateTime.MinValue;
         AV18ResidentEmail = "";
         lblTextblockcombo_residentphonecode_Jsonclick = "";
         AV12ResidentBsnNumber = "";
         AV23ResidentTypeId = Guid.Empty;
         AV25MedicalIndicationId = Guid.Empty;
         AV29ResidentAddressLine1 = "";
         AV30ResidentAddressLine2 = "";
         AV28ResidentZipCode = "";
         AV27ResidentCity = "";
         lblTextblockcombo_residentcountry_Jsonclick = "";
         ucCombo_residentcountry = new GXUserControl();
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV39ResidentPhoneCode = "";
         AV26ResidentCountry = "";
         AV21ResidentId = Guid.Empty;
         AV19ResidentPhone = "";
         AV24ResidentTypeName = "";
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
         H006Q2_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H006Q2_A99MedicalIndicationName = new string[] {""} ;
         H006Q3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H006Q3_A97ResidentTypeName = new string[] {""} ;
         H006Q4_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H006Q4_A99MedicalIndicationName = new string[] {""} ;
         H006Q5_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H006Q5_A97ResidentTypeName = new string[] {""} ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         ucCombo_residentphonecode = new GXUserControl();
         AV38defaultCountry = "";
         Combo_residentcountry_Selectedtext_set = "";
         Combo_residentcountry_Selectedvalue_set = "";
         AV43defaultCountryPhoneCode = "";
         Combo_residentphonecode_Selectedtext_set = "";
         Combo_residentphonecode_Selectedvalue_set = "";
         AV11WizardData = new SdtWP_CreateResidentAndNetworkData(context);
         AV5WebSession = context.GetSession();
         AV40ResidentPhoneNumber = "";
         GXt_char2 = "";
         AV44GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV37ResidentCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV36Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV32ComboTitles = new GxSimpleCollection<string>();
         AV46GXV3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV42ResidentPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         sStyleString = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         H006Q6_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H006Q6_A97ResidentTypeName = new string[] {""} ;
         H006Q7_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H006Q7_A99MedicalIndicationName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createresidentandnetworkstep1__default(),
            new Object[][] {
                new Object[] {
               H006Q2_A98MedicalIndicationId, H006Q2_A99MedicalIndicationName
               }
               , new Object[] {
               H006Q3_A96ResidentTypeId, H006Q3_A97ResidentTypeName
               }
               , new Object[] {
               H006Q4_A98MedicalIndicationId, H006Q4_A99MedicalIndicationName
               }
               , new Object[] {
               H006Q5_A96ResidentTypeId, H006Q5_A97ResidentTypeName
               }
               , new Object[] {
               H006Q6_A96ResidentTypeId, H006Q6_A97ResidentTypeName
               }
               , new Object[] {
               H006Q7_A98MedicalIndicationId, H006Q7_A99MedicalIndicationName
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
      private int edtavResidentgivenname_Enabled ;
      private int edtavResidentlastname_Enabled ;
      private int edtavResidentbirthdate_Enabled ;
      private int edtavResidentemail_Enabled ;
      private int edtavResidentbsnnumber_Enabled ;
      private int edtavResidentaddressline1_Enabled ;
      private int edtavResidentaddressline2_Enabled ;
      private int edtavResidentzipcode_Enabled ;
      private int edtavResidentcity_Enabled ;
      private int edtavResidentphonecode_Visible ;
      private int edtavResidentcountry_Visible ;
      private int edtavResidentid_Visible ;
      private int edtavResidentphone_Visible ;
      private int edtavResidenttypename_Visible ;
      private int gxdynajaxindex ;
      private int AV45GXV2 ;
      private int AV47GXV4 ;
      private int edtavResidentphonenumber_Enabled ;
      private int idxLst ;
      private string Combo_residentcountry_Ddointernalname ;
      private string Combo_residentcountry_Selectedvalue_get ;
      private string Combo_residentphonecode_Selectedvalue_get ;
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
      private string cmbavResidentsalutation_Internalname ;
      private string TempTags ;
      private string AV13ResidentSalutation ;
      private string cmbavResidentsalutation_Jsonclick ;
      private string edtavResidentgivenname_Internalname ;
      private string edtavResidentgivenname_Jsonclick ;
      private string edtavResidentlastname_Internalname ;
      private string edtavResidentlastname_Jsonclick ;
      private string cmbavResidentgender_Internalname ;
      private string cmbavResidentgender_Jsonclick ;
      private string edtavResidentbirthdate_Internalname ;
      private string edtavResidentbirthdate_Jsonclick ;
      private string edtavResidentemail_Internalname ;
      private string edtavResidentemail_Jsonclick ;
      private string divTablesplittedresidentphonecode_Internalname ;
      private string lblTextblockcombo_residentphonecode_Internalname ;
      private string lblTextblockcombo_residentphonecode_Jsonclick ;
      private string edtavResidentbsnnumber_Internalname ;
      private string edtavResidentbsnnumber_Jsonclick ;
      private string dynavResidenttypeid_Internalname ;
      private string dynavResidenttypeid_Jsonclick ;
      private string dynavMedicalindicationid_Internalname ;
      private string dynavMedicalindicationid_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtavResidentaddressline1_Internalname ;
      private string edtavResidentaddressline1_Jsonclick ;
      private string edtavResidentaddressline2_Internalname ;
      private string edtavResidentaddressline2_Jsonclick ;
      private string edtavResidentzipcode_Internalname ;
      private string edtavResidentzipcode_Jsonclick ;
      private string edtavResidentcity_Internalname ;
      private string edtavResidentcity_Jsonclick ;
      private string divTablesplittedresidentcountry_Internalname ;
      private string lblTextblockcombo_residentcountry_Internalname ;
      private string lblTextblockcombo_residentcountry_Jsonclick ;
      private string Combo_residentcountry_Caption ;
      private string Combo_residentcountry_Cls ;
      private string Combo_residentcountry_Internalname ;
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
      private string edtavResidentphonecode_Internalname ;
      private string edtavResidentphonecode_Jsonclick ;
      private string edtavResidentcountry_Internalname ;
      private string edtavResidentcountry_Jsonclick ;
      private string edtavResidentid_Internalname ;
      private string edtavResidentid_Jsonclick ;
      private string edtavResidentphone_Internalname ;
      private string AV19ResidentPhone ;
      private string edtavResidentphone_Jsonclick ;
      private string edtavResidenttypename_Internalname ;
      private string edtavResidenttypename_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string Combo_residentcountry_Htmltemplate ;
      private string Combo_residentphonecode_Htmltemplate ;
      private string Combo_residentphonecode_Internalname ;
      private string Combo_residentcountry_Selectedtext_set ;
      private string Combo_residentcountry_Selectedvalue_set ;
      private string Combo_residentphonecode_Selectedtext_set ;
      private string Combo_residentphonecode_Selectedvalue_set ;
      private string GXt_char2 ;
      private string sStyleString ;
      private string tblTablemergedresidentphonecode_Internalname ;
      private string Combo_residentphonecode_Caption ;
      private string Combo_residentphonecode_Cls ;
      private string edtavResidentphonenumber_Internalname ;
      private string edtavResidentphonenumber_Jsonclick ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private DateTime AV17ResidentBirthDate ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV31CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Combo_residentcountry_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool Btnwizardfirstprevious_Visible ;
      private bool Combo_residentphonecode_Emptyitem ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV14ResidentGivenName ;
      private string AV15ResidentLastName ;
      private string AV16ResidentGender ;
      private string AV18ResidentEmail ;
      private string AV12ResidentBsnNumber ;
      private string AV29ResidentAddressLine1 ;
      private string AV30ResidentAddressLine2 ;
      private string AV28ResidentZipCode ;
      private string AV27ResidentCity ;
      private string AV39ResidentPhoneCode ;
      private string AV26ResidentCountry ;
      private string AV24ResidentTypeName ;
      private string AV38defaultCountry ;
      private string AV43defaultCountryPhoneCode ;
      private string AV40ResidentPhoneNumber ;
      private Guid AV23ResidentTypeId ;
      private Guid AV25MedicalIndicationId ;
      private Guid AV21ResidentId ;
      private IGxSession AV5WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucCombo_residentcountry ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucCombo_residentphonecode ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavResidentsalutation ;
      private GXCombobox cmbavResidentgender ;
      private GXCombobox dynavResidenttypeid ;
      private GXCombobox dynavMedicalindicationid ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV34DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV41ResidentPhoneCode_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV33ResidentCountry_Data ;
      private IDataStoreProvider pr_default ;
      private Guid[] H006Q2_A98MedicalIndicationId ;
      private string[] H006Q2_A99MedicalIndicationName ;
      private Guid[] H006Q3_A96ResidentTypeId ;
      private string[] H006Q3_A97ResidentTypeName ;
      private Guid[] H006Q4_A98MedicalIndicationId ;
      private string[] H006Q4_A99MedicalIndicationName ;
      private Guid[] H006Q5_A96ResidentTypeId ;
      private string[] H006Q5_A97ResidentTypeName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private SdtWP_CreateResidentAndNetworkData AV11WizardData ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV44GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV37ResidentCountry_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV36Combo_DataItem ;
      private GxSimpleCollection<string> AV32ComboTitles ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV46GXV3 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV42ResidentPhoneCode_DPItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] H006Q6_A96ResidentTypeId ;
      private string[] H006Q6_A97ResidentTypeName ;
      private Guid[] H006Q7_A98MedicalIndicationId ;
      private string[] H006Q7_A99MedicalIndicationName ;
   }

   public class wp_createresidentandnetworkstep1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH006Q2;
          prmH006Q2 = new Object[] {
          };
          Object[] prmH006Q3;
          prmH006Q3 = new Object[] {
          };
          Object[] prmH006Q4;
          prmH006Q4 = new Object[] {
          };
          Object[] prmH006Q5;
          prmH006Q5 = new Object[] {
          };
          Object[] prmH006Q6;
          prmH006Q6 = new Object[] {
          };
          Object[] prmH006Q7;
          prmH006Q7 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H006Q2", "SELECT MedicalIndicationId, MedicalIndicationName FROM Trn_MedicalIndication ORDER BY MedicalIndicationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006Q3", "SELECT ResidentTypeId, ResidentTypeName FROM Trn_ResidentType ORDER BY ResidentTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006Q4", "SELECT MedicalIndicationId, MedicalIndicationName FROM Trn_MedicalIndication ORDER BY MedicalIndicationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006Q5", "SELECT ResidentTypeId, ResidentTypeName FROM Trn_ResidentType ORDER BY ResidentTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006Q6", "SELECT ResidentTypeId, ResidentTypeName FROM Trn_ResidentType ORDER BY ResidentTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q6,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006Q7", "SELECT MedicalIndicationId, MedicalIndicationName FROM Trn_MedicalIndication ORDER BY MedicalIndicationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q7,0, GxCacheFrequency.OFF ,true,false )
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
