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
   public class wp_createresidentandnetworkstep3 : GXWebComponent
   {
      public wp_createresidentandnetworkstep3( )
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

      public wp_createresidentandnetworkstep3( IGxContext context )
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grids") == 0 )
               {
                  gxnrGrids_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grids") == 0 )
               {
                  gxgrGrids_refresh_invoke( ) ;
                  return  ;
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

      protected void gxnrGrids_newrow_invoke( )
      {
         nRC_GXsfl_65 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_65"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_65_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_65_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_65_idx = GetPar( "sGXsfl_65_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrids_newrow( ) ;
         /* End function gxnrGrids_newrow_invoke */
      }

      protected void gxgrGrids_refresh_invoke( )
      {
         subGrids_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrids_Rows"), "."), 18, MidpointRounding.ToEven));
         AV10HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrids_refresh_invoke */
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
            PA6S2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdt_networkcompanys__networkcompanyid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkcompanys__networkcompanyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkcompanys__networkcompanyid_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtavSdt_networkcompanys__networkcompanykvknumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkcompanys__networkcompanykvknumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkcompanys__networkcompanykvknumber_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtavSdt_networkcompanys__networkcompanyname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkcompanys__networkcompanyname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkcompanys__networkcompanyname_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtavSdt_networkcompanys__networkcompanyemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkcompanys__networkcompanyemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkcompanys__networkcompanyemail_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtavSdt_networkcompanys__networkcompanyphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkcompanys__networkcompanyphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkcompanys__networkcompanyphone_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtavSdt_networkcompanys__networkcompanycountry_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkcompanys__networkcompanycountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkcompanys__networkcompanycountry_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtavSdt_networkcompanys__networkcompanycity_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkcompanys__networkcompanycity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkcompanys__networkcompanycity_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtavSdt_networkcompanys__networkcompanyzipcode_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkcompanys__networkcompanyzipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkcompanys__networkcompanyzipcode_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtavSdt_networkcompanys__networkcompanyaddressline1_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkcompanys__networkcompanyaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkcompanys__networkcompanyaddressline1_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtavSdt_networkcompanys__networkcompanyaddressline2_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkcompanys__networkcompanyaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkcompanys__networkcompanyaddressline2_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtavSdt_networkcompanys__networkcompanyfulladdress_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkcompanys__networkcompanyfulladdress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkcompanys__networkcompanyfulladdress_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtavUdelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavUdelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUdelete_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               WS6S2( ) ;
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
            context.SendWebValue( "WP_Create Resident And Network Step3") ;
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GXEncryptionTmp = "wp_createresidentandnetworkstep3.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createresidentandnetworkstep3.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_networkcompanys", AV13SDT_NetworkCompanys);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_networkcompanys", AV13SDT_NetworkCompanys);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_65", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_65), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV35DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV35DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNETWORKCOMPANYCOUNTRY_DATA", AV34NetworkCompanyCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNETWORKCOMPANYCOUNTRY_DATA", AV34NetworkCompanyCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV24CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_NETWORKCOMPANYS", AV13SDT_NetworkCompanys);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_NETWORKCOMPANYS", AV13SDT_NetworkCompanys);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_RESIDENT", AV29Trn_Resident);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_RESIDENT", AV29Trn_Resident);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_NETWORKCOMPANYCOUNTRY_Selectedvalue_get", StringUtil.RTrim( Combo_networkcompanycountry_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm6S2( )
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
         return "WP_CreateResidentAndNetworkStep3" ;
      }

      public override string GetPgmdesc( )
      {
         return "WP_Create Resident And Network Step3" ;
      }

      protected void WB6S0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createresidentandnetworkstep3.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divIncformtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkcompanyname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkcompanyname_Internalname, "Company Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkcompanyname_Internalname, AV15NetworkCompanyName, StringUtil.RTrim( context.localUtil.Format( AV15NetworkCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkcompanyname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkcompanyname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkcompanykvknumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkcompanykvknumber_Internalname, "KVK Number", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkcompanykvknumber_Internalname, AV16NetworkCompanyKvkNumber, StringUtil.RTrim( context.localUtil.Format( AV16NetworkCompanyKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkcompanykvknumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkcompanykvknumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkcompanyemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkcompanyemail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkcompanyemail_Internalname, AV17NetworkCompanyEmail, StringUtil.RTrim( context.localUtil.Format( AV17NetworkCompanyEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkcompanyemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkcompanyemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkcompanyphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkcompanyphone_Internalname, "Phone", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkcompanyphone_Internalname, StringUtil.RTrim( AV18NetworkCompanyPhone), StringUtil.RTrim( context.localUtil.Format( AV18NetworkCompanyPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkcompanyphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkcompanyphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittednetworkcompanycountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_networkcompanycountry_Internalname, "Country", "", "", lblTextblockcombo_networkcompanycountry_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetworkStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_networkcompanycountry.SetProperty("Caption", Combo_networkcompanycountry_Caption);
            ucCombo_networkcompanycountry.SetProperty("Cls", Combo_networkcompanycountry_Cls);
            ucCombo_networkcompanycountry.SetProperty("EmptyItem", Combo_networkcompanycountry_Emptyitem);
            ucCombo_networkcompanycountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV35DDO_TitleSettingsIcons);
            ucCombo_networkcompanycountry.SetProperty("DropDownOptionsData", AV34NetworkCompanyCountry_Data);
            ucCombo_networkcompanycountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_networkcompanycountry_Internalname, sPrefix+"COMBO_NETWORKCOMPANYCOUNTRYContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkcompanycity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkcompanycity_Internalname, "City", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkcompanycity_Internalname, AV20NetworkCompanyCity, StringUtil.RTrim( context.localUtil.Format( AV20NetworkCompanyCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkcompanycity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkcompanycity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkcompanyzipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkcompanyzipcode_Internalname, "Zip Code", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkcompanyzipcode_Internalname, AV21NetworkCompanyZipCode, StringUtil.RTrim( context.localUtil.Format( AV21NetworkCompanyZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkcompanyzipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkcompanyzipcode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkcompanyaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkcompanyaddressline1_Internalname, "Address Line 1", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkcompanyaddressline1_Internalname, AV22NetworkCompanyAddressLine1, StringUtil.RTrim( context.localUtil.Format( AV22NetworkCompanyAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Street", edtavNetworkcompanyaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkcompanyaddressline1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkcompanyaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkcompanyaddressline2_Internalname, "Address Line 2", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkcompanyaddressline2_Internalname, AV23NetworkCompanyAddressLine2, StringUtil.RTrim( context.localUtil.Format( AV23NetworkCompanyAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Building/Floor", edtavNetworkcompanyaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkcompanyaddressline2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep3.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuinsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(65), 2, 0)+","+"null"+");", "Add", bttBtnuinsert_Jsonclick, 5, "Add new item", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateResidentAndNetworkStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridsContainer.SetWrapped(nGXWrapped);
            StartGridControl65( ) ;
         }
         if ( wbEnd == 65 )
         {
            wbEnd = 0;
            nRC_GXsfl_65 = (int)(nGXsfl_65_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridsContainer.AddObjectProperty("GRIDS_nEOF", GRIDS_nEOF);
               GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
               AV39GXV1 = nGXsfl_65_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grids", GridsContainer, subGrids_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData", GridsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData"+"V", GridsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            ucBtnwizardprevious.SetProperty("TooltipText", Btnwizardprevious_Tooltiptext);
            ucBtnwizardprevious.SetProperty("Caption", Btnwizardprevious_Caption);
            ucBtnwizardprevious.SetProperty("Class", Btnwizardprevious_Class);
            ucBtnwizardprevious.Render(context, "wwp_iconbutton", Btnwizardprevious_Internalname, sPrefix+"BTNWIZARDPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardlastnext.SetProperty("TooltipText", Btnwizardlastnext_Tooltiptext);
            ucBtnwizardlastnext.SetProperty("Caption", Btnwizardlastnext_Caption);
            ucBtnwizardlastnext.SetProperty("Class", Btnwizardlastnext_Class);
            ucBtnwizardlastnext.Render(context, "wwp_iconbutton", Btnwizardlastnext_Internalname, sPrefix+"BTNWIZARDLASTNEXTContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkcompanycountry_Internalname, AV19NetworkCompanyCountry, StringUtil.RTrim( context.localUtil.Format( AV19NetworkCompanyCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkcompanycountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavNetworkcompanycountry_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep3.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkcompanyid_Internalname, AV14NetworkCompanyId.ToString(), AV14NetworkCompanyId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkcompanyid_Jsonclick, 0, "Attribute", "", "", "", "", edtavNetworkcompanyid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetworkStep3.htm");
            /* User Defined Control */
            ucGrids_empowerer.Render(context, "wwp.gridempowerer", Grids_empowerer_Internalname, sPrefix+"GRIDS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 65 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridsContainer.AddObjectProperty("GRIDS_nEOF", GRIDS_nEOF);
                  GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
                  AV39GXV1 = nGXsfl_65_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grids", GridsContainer, subGrids_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData", GridsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridsContainerData"+"V", GridsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridsContainerData"+"V"+"\" value='"+GridsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START6S2( )
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
            Form.Meta.addItem("description", "WP_Create Resident And Network Step3", 0) ;
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
               STRUP6S0( ) ;
            }
         }
      }

      protected void WS6S2( )
      {
         START6S2( ) ;
         EVT6S2( ) ;
      }

      protected void EVT6S2( )
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
                                 STRUP6S0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6S0( ) ;
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
                                          E116S2 ();
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
                                 STRUP6S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E126S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUInsert' */
                                    E136S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdt_networkcompanys__networkcompanyid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6S0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrids_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrids_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrids_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrids_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRIDS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6S0( ) ;
                              }
                              nGXsfl_65_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
                              SubsflControlProps_652( ) ;
                              AV39GXV1 = (int)(nGXsfl_65_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV13SDT_NetworkCompanys.Count >= AV39GXV1 ) && ( AV39GXV1 > 0 ) )
                              {
                                 AV13SDT_NetworkCompanys.CurrentItem = ((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1));
                                 AV12UDelete = cgiGet( edtavUdelete_Internalname);
                                 AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV12UDelete);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_networkcompanys__networkcompanyid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E146S2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_networkcompanys__networkcompanyid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grids.Load */
                                          E156S2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUDELETE.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_networkcompanys__networkcompanyid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E166S2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP6S0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_networkcompanys__networkcompanyid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE6S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6S2( ) ;
            }
         }
      }

      protected void PA6S2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createresidentandnetworkstep3.aspx")), "wp_createresidentandnetworkstep3.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createresidentandnetworkstep3.aspx")))) ;
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
               GX_FocusControl = edtavNetworkcompanyname_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrids_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_652( ) ;
         while ( nGXsfl_65_idx <= nRC_GXsfl_65 )
         {
            sendrow_652( ) ;
            nGXsfl_65_idx = ((subGrids_Islastpage==1)&&(nGXsfl_65_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_65_idx+1);
            sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
            SubsflControlProps_652( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( int subGrids_Rows ,
                                        bool AV10HasValidationErrors ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF6S2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrids_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdt_networkcompanys__networkcompanyid_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanykvknumber_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyname_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyemail_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyphone_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanycountry_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanycity_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyzipcode_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyaddressline1_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyaddressline2_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyfulladdress_Enabled = 0;
         edtavUdelete_Enabled = 0;
      }

      protected void RF6S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 65;
         nGXsfl_65_idx = 1;
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_652( ) ;
         bGXsfl_65_Refreshing = true;
         GridsContainer.AddObjectProperty("GridName", "Grids");
         GridsContainer.AddObjectProperty("CmpContext", sPrefix);
         GridsContainer.AddObjectProperty("InMasterPage", "false");
         GridsContainer.AddObjectProperty("Class", "WorkWith");
         GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
         GridsContainer.PageSize = subGrids_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_652( ) ;
            /* Execute user event: Grids.Load */
            E156S2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_65_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               /* Execute user event: Grids.Load */
               E156S2 ();
            }
            wbEnd = 65;
            WB6S0( ) ;
         }
         bGXsfl_65_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6S2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected int subGrids_fnc_Pagecount( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( ((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nRecordCount/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nRecordCount/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrids_fnc_Recordcount( )
      {
         return AV13SDT_NetworkCompanys.Count ;
      }

      protected int subGrids_fnc_Recordsperpage( )
      {
         if ( subGrids_Rows > 0 )
         {
            return subGrids_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrids_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDS_nFirstRecordOnPage/ (decimal)(subGrids_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrids_firstpage( )
      {
         GRIDS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrids_nextpage( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( ( GRIDS_nRecordCount >= subGrids_fnc_Recordsperpage( ) ) && ( GRIDS_nEOF == 0 ) )
         {
            GRIDS_nFirstRecordOnPage = (long)(GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrids_previouspage( )
      {
         if ( GRIDS_nFirstRecordOnPage >= subGrids_fnc_Recordsperpage( ) )
         {
            GRIDS_nFirstRecordOnPage = (long)(GRIDS_nFirstRecordOnPage-subGrids_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrids_lastpage( )
      {
         GRIDS_nRecordCount = subGrids_fnc_Recordcount( );
         if ( GRIDS_nRecordCount > subGrids_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDS_nFirstRecordOnPage = (long)(GRIDS_nRecordCount-subGrids_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDS_nFirstRecordOnPage = (long)(GRIDS_nRecordCount-((int)((GRIDS_nRecordCount) % (subGrids_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrids_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDS_nFirstRecordOnPage = (long)(subGrids_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdt_networkcompanys__networkcompanyid_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanykvknumber_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyname_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyemail_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyphone_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanycountry_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanycity_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyzipcode_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyaddressline1_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyaddressline2_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyfulladdress_Enabled = 0;
         edtavUdelete_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E146S2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_networkcompanys"), AV13SDT_NetworkCompanys);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV35DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vNETWORKCOMPANYCOUNTRY_DATA"), AV34NetworkCompanyCountry_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_NETWORKCOMPANYS"), AV13SDT_NetworkCompanys);
            /* Read saved values. */
            nRC_GXsfl_65 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_65"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            GRIDS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrids_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
            nRC_GXsfl_65 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_65"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_65_fel_idx = 0;
            while ( nGXsfl_65_fel_idx < nRC_GXsfl_65 )
            {
               nGXsfl_65_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_65_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_65_fel_idx+1);
               sGXsfl_65_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_652( ) ;
               AV39GXV1 = (int)(nGXsfl_65_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV13SDT_NetworkCompanys.Count >= AV39GXV1 ) && ( AV39GXV1 > 0 ) )
               {
                  AV13SDT_NetworkCompanys.CurrentItem = ((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1));
                  AV12UDelete = cgiGet( edtavUdelete_Internalname);
               }
            }
            if ( nGXsfl_65_fel_idx == 0 )
            {
               nGXsfl_65_idx = 1;
               sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
               SubsflControlProps_652( ) ;
            }
            nGXsfl_65_fel_idx = 1;
            /* Read variables values. */
            AV15NetworkCompanyName = cgiGet( edtavNetworkcompanyname_Internalname);
            AssignAttri(sPrefix, false, "AV15NetworkCompanyName", AV15NetworkCompanyName);
            AV16NetworkCompanyKvkNumber = cgiGet( edtavNetworkcompanykvknumber_Internalname);
            AssignAttri(sPrefix, false, "AV16NetworkCompanyKvkNumber", AV16NetworkCompanyKvkNumber);
            AV17NetworkCompanyEmail = cgiGet( edtavNetworkcompanyemail_Internalname);
            AssignAttri(sPrefix, false, "AV17NetworkCompanyEmail", AV17NetworkCompanyEmail);
            AV18NetworkCompanyPhone = cgiGet( edtavNetworkcompanyphone_Internalname);
            AssignAttri(sPrefix, false, "AV18NetworkCompanyPhone", AV18NetworkCompanyPhone);
            AV20NetworkCompanyCity = cgiGet( edtavNetworkcompanycity_Internalname);
            AssignAttri(sPrefix, false, "AV20NetworkCompanyCity", AV20NetworkCompanyCity);
            AV21NetworkCompanyZipCode = cgiGet( edtavNetworkcompanyzipcode_Internalname);
            AssignAttri(sPrefix, false, "AV21NetworkCompanyZipCode", AV21NetworkCompanyZipCode);
            AV22NetworkCompanyAddressLine1 = cgiGet( edtavNetworkcompanyaddressline1_Internalname);
            AssignAttri(sPrefix, false, "AV22NetworkCompanyAddressLine1", AV22NetworkCompanyAddressLine1);
            AV23NetworkCompanyAddressLine2 = cgiGet( edtavNetworkcompanyaddressline2_Internalname);
            AssignAttri(sPrefix, false, "AV23NetworkCompanyAddressLine2", AV23NetworkCompanyAddressLine2);
            AV19NetworkCompanyCountry = cgiGet( edtavNetworkcompanycountry_Internalname);
            AssignAttri(sPrefix, false, "AV19NetworkCompanyCountry", AV19NetworkCompanyCountry);
            if ( StringUtil.StrCmp(cgiGet( edtavNetworkcompanyid_Internalname), "") == 0 )
            {
               AV14NetworkCompanyId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV14NetworkCompanyId", AV14NetworkCompanyId.ToString());
            }
            else
            {
               try
               {
                  AV14NetworkCompanyId = StringUtil.StrToGuid( cgiGet( edtavNetworkcompanyid_Internalname));
                  AssignAttri(sPrefix, false, "AV14NetworkCompanyId", AV14NetworkCompanyId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vNETWORKCOMPANYID");
                  GX_FocusControl = edtavNetworkcompanyid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E146S2 ();
         if (returnInSub) return;
      }

      protected void E146S2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV35DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV35DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavNetworkcompanycountry_Visible = 0;
         AssignProp(sPrefix, false, edtavNetworkcompanycountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkcompanycountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_networkcompanycountry_Htmltemplate = GXt_char2;
         ucCombo_networkcompanycountry.SendProperty(context, sPrefix, false, Combo_networkcompanycountry_Internalname, "HTMLTemplate", Combo_networkcompanycountry_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBONETWORKCOMPANYCOUNTRY' */
         S122 ();
         if (returnInSub) return;
         edtavNetworkcompanyid_Visible = 0;
         AssignProp(sPrefix, false, edtavNetworkcompanyid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkcompanyid_Visible), 5, 0), true);
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, sPrefix, false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         Combo_networkcompanycountry_Selectedtext_set = "Netherlands";
         ucCombo_networkcompanycountry.SendProperty(context, sPrefix, false, Combo_networkcompanycountry_Internalname, "SelectedText_set", Combo_networkcompanycountry_Selectedtext_set);
         Combo_networkcompanycountry_Selectedvalue_set = "Netherlands";
         ucCombo_networkcompanycountry.SendProperty(context, sPrefix, false, Combo_networkcompanycountry_Internalname, "SelectedValue_set", Combo_networkcompanycountry_Selectedvalue_set);
      }

      private void E156S2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV13SDT_NetworkCompanys.Count )
         {
            AV13SDT_NetworkCompanys.CurrentItem = ((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1));
            AV12UDelete = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV12UDelete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 65;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_652( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_65_Refreshing )
            {
               DoAjaxLoad(65, GridsRow);
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E116S2 ();
         if (returnInSub) return;
      }

      protected void E116S2( )
      {
         AV39GXV1 = (int)(nGXsfl_65_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV39GXV1 > 0 ) && ( AV13SDT_NetworkCompanys.Count >= AV39GXV1 ) )
         {
            AV13SDT_NetworkCompanys.CurrentItem = ((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( true )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
            AV5WebSession.Remove(AV6WebSessionKey);
         }
         else
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S152 ();
            if (returnInSub) return;
            if ( AV24CheckRequiredFieldsResult && ! AV10HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S132 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'FINISHWIZARD' */
               S142 ();
               if (returnInSub) return;
               AV5WebSession.Remove(AV6WebSessionKey);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV29Trn_Resident", AV29Trn_Resident);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDT_NetworkCompanys", AV13SDT_NetworkCompanys);
         nGXsfl_65_bak_idx = nGXsfl_65_idx;
         gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         nGXsfl_65_idx = nGXsfl_65_bak_idx;
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_652( ) ;
      }

      protected void E126S2( )
      {
         AV39GXV1 = (int)(nGXsfl_65_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV39GXV1 > 0 ) && ( AV13SDT_NetworkCompanys.Count >= AV39GXV1 ) )
         {
            AV13SDT_NetworkCompanys.CurrentItem = ((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1));
         }
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wp_createresidentandnetwork.aspx"+UrlEncode(StringUtil.RTrim("Step3")) + "," + UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wp_createresidentandnetwork.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E136S2( )
      {
         AV39GXV1 = (int)(nGXsfl_65_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV39GXV1 > 0 ) && ( AV13SDT_NetworkCompanys.Count >= AV39GXV1 ) )
         {
            AV13SDT_NetworkCompanys.CurrentItem = ((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1));
         }
         /* 'DoUInsert' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S152 ();
         if (returnInSub) return;
         if ( AV24CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            AV26isAlreadyAdded = false;
            AV51GXV13 = 1;
            while ( AV51GXV13 <= AV13SDT_NetworkCompanys.Count )
            {
               AV25SDT_NetworkCompany = ((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV51GXV13));
               if ( StringUtil.StrCmp(AV25SDT_NetworkCompany.gxTpr_Networkcompanykvknumber, AV16NetworkCompanyKvkNumber) == 0 )
               {
                  AV26isAlreadyAdded = true;
                  if (true) break;
               }
               AV51GXV13 = (int)(AV51GXV13+1);
            }
            if ( AV26isAlreadyAdded )
            {
               GX_msglist.addItem("This Company KVK Number is already registered");
            }
            else
            {
               AV25SDT_NetworkCompany = new SdtSDT_NetworkCompany(context);
               AV25SDT_NetworkCompany.gxTpr_Networkcompanyid = Guid.NewGuid( );
               AV25SDT_NetworkCompany.gxTpr_Networkcompanykvknumber = AV16NetworkCompanyKvkNumber;
               AV25SDT_NetworkCompany.gxTpr_Networkcompanyname = AV15NetworkCompanyName;
               AV25SDT_NetworkCompany.gxTpr_Networkcompanyemail = AV17NetworkCompanyEmail;
               AV25SDT_NetworkCompany.gxTpr_Networkcompanyphone = AV18NetworkCompanyPhone;
               AV25SDT_NetworkCompany.gxTpr_Networkcompanycountry = AV19NetworkCompanyCountry;
               AV25SDT_NetworkCompany.gxTpr_Networkcompanycity = AV20NetworkCompanyCity;
               AV25SDT_NetworkCompany.gxTpr_Networkcompanyzipcode = AV21NetworkCompanyZipCode;
               AV25SDT_NetworkCompany.gxTpr_Networkcompanyaddressline1 = AV22NetworkCompanyAddressLine1;
               AV25SDT_NetworkCompany.gxTpr_Networkcompanyaddressline2 = AV23NetworkCompanyAddressLine2;
               AV25SDT_NetworkCompany.gxTpr_Networkcompanyfulladdress = AV23NetworkCompanyAddressLine2+", "+AV22NetworkCompanyAddressLine1+", "+AV21NetworkCompanyZipCode+", "+AV20NetworkCompanyCity+" "+AV19NetworkCompanyCountry;
               AV13SDT_NetworkCompanys.Add(AV25SDT_NetworkCompany, 0);
               gx_BV65 = true;
               AV27Trn_NetworkCompany = new SdtTrn_NetworkCompany(context);
               AV27Trn_NetworkCompany.gxTpr_Networkcompanyid = AV25SDT_NetworkCompany.gxTpr_Networkcompanyid;
               AV27Trn_NetworkCompany.gxTpr_Networkcompanykvknumber = AV25SDT_NetworkCompany.gxTpr_Networkcompanykvknumber;
               AV27Trn_NetworkCompany.gxTpr_Networkcompanyname = AV25SDT_NetworkCompany.gxTpr_Networkcompanyname;
               AV27Trn_NetworkCompany.gxTpr_Networkcompanyemail = AV25SDT_NetworkCompany.gxTpr_Networkcompanyemail;
               AV27Trn_NetworkCompany.gxTpr_Networkcompanyphone = AV25SDT_NetworkCompany.gxTpr_Networkcompanyphone;
               AV27Trn_NetworkCompany.gxTpr_Networkcompanycountry = AV19NetworkCompanyCountry;
               AV27Trn_NetworkCompany.gxTpr_Networkcompanycity = AV20NetworkCompanyCity;
               AV27Trn_NetworkCompany.gxTpr_Networkcompanyzipcode = AV21NetworkCompanyZipCode;
               AV27Trn_NetworkCompany.gxTpr_Networkcompanyaddressline1 = AV22NetworkCompanyAddressLine1;
               AV27Trn_NetworkCompany.gxTpr_Networkcompanyaddressline2 = AV23NetworkCompanyAddressLine2;
               if ( AV27Trn_NetworkCompany.Insert() )
               {
                  context.CommitDataStores("wp_createresidentandnetworkstep3",pr_default);
               }
               /* Execute user subroutine: 'CLEARFORMVALUES' */
               S162 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDT_NetworkCompanys", AV13SDT_NetworkCompanys);
         nGXsfl_65_bak_idx = nGXsfl_65_idx;
         gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         nGXsfl_65_idx = nGXsfl_65_bak_idx;
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_652( ) ;
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV14NetworkCompanyId = AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyid;
         AssignAttri(sPrefix, false, "AV14NetworkCompanyId", AV14NetworkCompanyId.ToString());
         AV15NetworkCompanyName = AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyname;
         AssignAttri(sPrefix, false, "AV15NetworkCompanyName", AV15NetworkCompanyName);
         AV16NetworkCompanyKvkNumber = AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanykvknumber;
         AssignAttri(sPrefix, false, "AV16NetworkCompanyKvkNumber", AV16NetworkCompanyKvkNumber);
         AV17NetworkCompanyEmail = AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyemail;
         AssignAttri(sPrefix, false, "AV17NetworkCompanyEmail", AV17NetworkCompanyEmail);
         AV18NetworkCompanyPhone = AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyphone;
         AssignAttri(sPrefix, false, "AV18NetworkCompanyPhone", AV18NetworkCompanyPhone);
         AV19NetworkCompanyCountry = AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanycountry;
         AssignAttri(sPrefix, false, "AV19NetworkCompanyCountry", AV19NetworkCompanyCountry);
         AV20NetworkCompanyCity = AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanycity;
         AssignAttri(sPrefix, false, "AV20NetworkCompanyCity", AV20NetworkCompanyCity);
         AV21NetworkCompanyZipCode = AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyzipcode;
         AssignAttri(sPrefix, false, "AV21NetworkCompanyZipCode", AV21NetworkCompanyZipCode);
         AV22NetworkCompanyAddressLine1 = AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyaddressline1;
         AssignAttri(sPrefix, false, "AV22NetworkCompanyAddressLine1", AV22NetworkCompanyAddressLine1);
         AV23NetworkCompanyAddressLine2 = AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyaddressline2;
         AssignAttri(sPrefix, false, "AV23NetworkCompanyAddressLine2", AV23NetworkCompanyAddressLine2);
         AV13SDT_NetworkCompanys = AV11WizardData.gxTpr_Step3.gxTpr_Sdt_networkcompanys;
         gx_BV65 = true;
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyid = AV14NetworkCompanyId;
         AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyname = AV15NetworkCompanyName;
         AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanykvknumber = AV16NetworkCompanyKvkNumber;
         AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyemail = AV17NetworkCompanyEmail;
         AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyphone = AV18NetworkCompanyPhone;
         AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanycountry = AV19NetworkCompanyCountry;
         AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanycity = AV20NetworkCompanyCity;
         AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyzipcode = AV21NetworkCompanyZipCode;
         AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyaddressline1 = AV22NetworkCompanyAddressLine1;
         AV11WizardData.gxTpr_Step3.gxTpr_Networkcompanyaddressline2 = AV23NetworkCompanyAddressLine2;
         AV11WizardData.gxTpr_Step3.gxTpr_Sdt_networkcompanys = AV13SDT_NetworkCompanys;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV29Trn_Resident.gxTpr_Residentid = Guid.NewGuid( );
         GXt_guid3 = Guid.Empty;
         new prc_getuserlocationid(context ).execute( out  GXt_guid3) ;
         AV29Trn_Resident.gxTpr_Locationid = GXt_guid3;
         AV29Trn_Resident.gxTpr_Medicalindicationid = AV11WizardData.gxTpr_Step1.gxTpr_Medicalindicationid;
         AV29Trn_Resident.gxTpr_Residentcountry = AV11WizardData.gxTpr_Step1.gxTpr_Residentcountry;
         AV29Trn_Resident.gxTpr_Residentcity = AV11WizardData.gxTpr_Step1.gxTpr_Residentcity;
         AV29Trn_Resident.gxTpr_Residentzipcode = AV11WizardData.gxTpr_Step1.gxTpr_Residentzipcode;
         AV29Trn_Resident.gxTpr_Residentaddressline1 = AV11WizardData.gxTpr_Step1.gxTpr_Residentaddressline1;
         AV29Trn_Resident.gxTpr_Residentaddressline2 = AV11WizardData.gxTpr_Step1.gxTpr_Residentaddressline2;
         AV29Trn_Resident.gxTpr_Residentbirthdate = AV11WizardData.gxTpr_Step1.gxTpr_Residentbirthdate;
         AV29Trn_Resident.gxTpr_Residentbsnnumber = AV11WizardData.gxTpr_Step1.gxTpr_Residentbsnnumber;
         AV29Trn_Resident.gxTpr_Residentemail = AV11WizardData.gxTpr_Step1.gxTpr_Residentemail;
         AV29Trn_Resident.gxTpr_Residentgender = AV11WizardData.gxTpr_Step1.gxTpr_Residentgender;
         AV29Trn_Resident.gxTpr_Residentgivenname = AV11WizardData.gxTpr_Step1.gxTpr_Residentgivenname;
         AV29Trn_Resident.gxTpr_Residentlastname = AV11WizardData.gxTpr_Step1.gxTpr_Residentlastname;
         AV29Trn_Resident.gxTpr_Residentphone = AV11WizardData.gxTpr_Step1.gxTpr_Residentphone;
         AV29Trn_Resident.gxTpr_Residentsalutation = AV11WizardData.gxTpr_Step1.gxTpr_Residentsalutation;
         AV29Trn_Resident.gxTpr_Residenttypeid = AV11WizardData.gxTpr_Step1.gxTpr_Residenttypeid;
         AV52GXV14 = 1;
         while ( AV52GXV14 <= AV11WizardData.gxTpr_Step2.gxTpr_Sdt_networkindividuals.Count )
         {
            AV28SDT_NetworkIndividual = ((SdtSDT_NetworkIndividual)AV11WizardData.gxTpr_Step2.gxTpr_Sdt_networkindividuals.Item(AV52GXV14));
            AV30NetworkIndividual = new SdtTrn_Resident_NetworkIndividual(context);
            AV30NetworkIndividual.gxTpr_Networkindividualid = AV28SDT_NetworkIndividual.gxTpr_Networkindividualid;
            AV29Trn_Resident.gxTpr_Networkindividual.Add(AV30NetworkIndividual, 0);
            AV52GXV14 = (int)(AV52GXV14+1);
         }
         AV53GXV15 = 1;
         while ( AV53GXV15 <= AV11WizardData.gxTpr_Step3.gxTpr_Sdt_networkcompanys.Count )
         {
            AV25SDT_NetworkCompany = ((SdtSDT_NetworkCompany)AV11WizardData.gxTpr_Step3.gxTpr_Sdt_networkcompanys.Item(AV53GXV15));
            AV31NetworkCompany = new SdtTrn_Resident_NetworkCompany(context);
            AV31NetworkCompany.gxTpr_Networkcompanyid = AV25SDT_NetworkCompany.gxTpr_Networkcompanyid;
            AV29Trn_Resident.gxTpr_Networkcompany.Add(AV31NetworkCompany, 0);
            AV53GXV15 = (int)(AV53GXV15+1);
         }
         if ( AV29Trn_Resident.Insert() )
         {
            context.CommitDataStores("wp_createresidentandnetworkstep3",pr_default);
            /* Execute user subroutine: 'CLEARFORMVALUES' */
            S162 ();
            if (returnInSub) return;
            AV11WizardData.gxTpr_Step2.gxTpr_Sdt_networkindividuals.Clear();
            AV11WizardData.gxTpr_Step3.gxTpr_Sdt_networkcompanys.Clear();
            AV13SDT_NetworkCompanys.Clear();
            gx_BV65 = true;
            CallWebObject(formatLink("wp_locationresidents.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            context.RollbackDataStores("wp_createresidentandnetworkstep3",pr_default);
            AV32ErrorMessages = AV29Trn_Resident.GetMessages();
            GX_msglist.addItem(AV32ErrorMessages.ToJSonString(false));
         }
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV24CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV24CheckRequiredFieldsResult", AV24CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15NetworkCompanyName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Company Name", "", "", "", "", "", "", "", ""),  "error",  edtavNetworkcompanyname_Internalname,  "true",  ""));
            AV24CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV24CheckRequiredFieldsResult", AV24CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16NetworkCompanyKvkNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "KVK Number", "", "", "", "", "", "", "", ""),  "error",  edtavNetworkcompanykvknumber_Internalname,  "true",  ""));
            AV24CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV24CheckRequiredFieldsResult", AV24CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17NetworkCompanyEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavNetworkcompanyemail_Internalname,  "true",  ""));
            AV24CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV24CheckRequiredFieldsResult", AV24CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18NetworkCompanyPhone)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Phone", "", "", "", "", "", "", "", ""),  "error",  edtavNetworkcompanyphone_Internalname,  "true",  ""));
            AV24CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV24CheckRequiredFieldsResult", AV24CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBONETWORKCOMPANYCOUNTRY' Routine */
         returnInSub = false;
         AV55GXV17 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem4 = AV54GXV16;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem4) ;
         AV54GXV16 = GXt_objcol_SdtSDT_Country_SDT_CountryItem4;
         while ( AV55GXV17 <= AV54GXV16.Count )
         {
            AV38NetworkCompanyCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV54GXV16.Item(AV55GXV17));
            AV37Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV37Combo_DataItem.gxTpr_Id = AV38NetworkCompanyCountry_DPItem.gxTpr_Countryname;
            AV33ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV33ComboTitles.Add(AV38NetworkCompanyCountry_DPItem.gxTpr_Countryname, 0);
            AV33ComboTitles.Add(AV38NetworkCompanyCountry_DPItem.gxTpr_Countryflag, 0);
            AV37Combo_DataItem.gxTpr_Title = AV33ComboTitles.ToJSonString(false);
            AV34NetworkCompanyCountry_Data.Add(AV37Combo_DataItem, 0);
            AV55GXV17 = (int)(AV55GXV17+1);
         }
         AV34NetworkCompanyCountry_Data.Sort("Title");
         Combo_networkcompanycountry_Selectedvalue_set = AV19NetworkCompanyCountry;
         ucCombo_networkcompanycountry.SendProperty(context, sPrefix, false, Combo_networkcompanycountry_Internalname, "SelectedValue_set", Combo_networkcompanycountry_Selectedvalue_set);
      }

      protected void E166S2( )
      {
         AV39GXV1 = (int)(nGXsfl_65_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV39GXV1 > 0 ) && ( AV13SDT_NetworkCompanys.Count >= AV39GXV1 ) )
         {
            AV13SDT_NetworkCompanys.CurrentItem = ((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1));
         }
         /* Udelete_Click Routine */
         returnInSub = false;
         AV27Trn_NetworkCompany.Load(((SdtSDT_NetworkCompany)(AV13SDT_NetworkCompanys.CurrentItem)).gxTpr_Networkcompanyid);
         AV27Trn_NetworkCompany.Delete();
         if ( AV27Trn_NetworkCompany.Success() )
         {
            context.CommitDataStores("wp_createresidentandnetworkstep3",pr_default);
            AV13SDT_NetworkCompanys.RemoveItem(AV13SDT_NetworkCompanys.IndexOf(((SdtSDT_NetworkCompany)(AV13SDT_NetworkCompanys.CurrentItem))));
            gx_BV65 = true;
         }
         else
         {
            GX_msglist.addItem(StringUtil.RTrim( context.localUtil.Format( ((GeneXus.Utils.SdtMessages_Message)AV27Trn_NetworkCompany.GetMessages().Item(1)).gxTpr_Description, "")));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDT_NetworkCompanys", AV13SDT_NetworkCompanys);
         nGXsfl_65_bak_idx = nGXsfl_65_idx;
         gxgrGrids_refresh( subGrids_Rows, AV10HasValidationErrors, sPrefix) ;
         nGXsfl_65_idx = nGXsfl_65_bak_idx;
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_652( ) ;
      }

      protected void S162( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV16NetworkCompanyKvkNumber = "";
         AssignAttri(sPrefix, false, "AV16NetworkCompanyKvkNumber", AV16NetworkCompanyKvkNumber);
         AV15NetworkCompanyName = "";
         AssignAttri(sPrefix, false, "AV15NetworkCompanyName", AV15NetworkCompanyName);
         AV17NetworkCompanyEmail = "";
         AssignAttri(sPrefix, false, "AV17NetworkCompanyEmail", AV17NetworkCompanyEmail);
         AV18NetworkCompanyPhone = "";
         AssignAttri(sPrefix, false, "AV18NetworkCompanyPhone", AV18NetworkCompanyPhone);
         AV19NetworkCompanyCountry = "";
         AssignAttri(sPrefix, false, "AV19NetworkCompanyCountry", AV19NetworkCompanyCountry);
         AV20NetworkCompanyCity = "";
         AssignAttri(sPrefix, false, "AV20NetworkCompanyCity", AV20NetworkCompanyCity);
         AV21NetworkCompanyZipCode = "";
         AssignAttri(sPrefix, false, "AV21NetworkCompanyZipCode", AV21NetworkCompanyZipCode);
         AV22NetworkCompanyAddressLine1 = "";
         AssignAttri(sPrefix, false, "AV22NetworkCompanyAddressLine1", AV22NetworkCompanyAddressLine1);
         AV23NetworkCompanyAddressLine2 = "";
         AssignAttri(sPrefix, false, "AV23NetworkCompanyAddressLine2", AV23NetworkCompanyAddressLine2);
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
         PA6S2( ) ;
         WS6S2( ) ;
         WE6S2( ) ;
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
         PA6S2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createresidentandnetworkstep3", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6S2( ) ;
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
         PA6S2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6S2( ) ;
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
         WS6S2( ) ;
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
         WE6S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249271947292", true, true);
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
         context.AddJavascriptSource("wp_createresidentandnetworkstep3.js", "?20249271947293", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_652( )
      {
         edtavSdt_networkcompanys__networkcompanyid_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYID_"+sGXsfl_65_idx;
         edtavSdt_networkcompanys__networkcompanykvknumber_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYKVKNUMBER_"+sGXsfl_65_idx;
         edtavSdt_networkcompanys__networkcompanyname_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYNAME_"+sGXsfl_65_idx;
         edtavSdt_networkcompanys__networkcompanyemail_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYEMAIL_"+sGXsfl_65_idx;
         edtavSdt_networkcompanys__networkcompanyphone_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYPHONE_"+sGXsfl_65_idx;
         edtavSdt_networkcompanys__networkcompanycountry_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYCOUNTRY_"+sGXsfl_65_idx;
         edtavSdt_networkcompanys__networkcompanycity_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYCITY_"+sGXsfl_65_idx;
         edtavSdt_networkcompanys__networkcompanyzipcode_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYZIPCODE_"+sGXsfl_65_idx;
         edtavSdt_networkcompanys__networkcompanyaddressline1_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYADDRESSLINE1_"+sGXsfl_65_idx;
         edtavSdt_networkcompanys__networkcompanyaddressline2_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYADDRESSLINE2_"+sGXsfl_65_idx;
         edtavSdt_networkcompanys__networkcompanyfulladdress_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYFULLADDRESS_"+sGXsfl_65_idx;
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_65_idx;
      }

      protected void SubsflControlProps_fel_652( )
      {
         edtavSdt_networkcompanys__networkcompanyid_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYID_"+sGXsfl_65_fel_idx;
         edtavSdt_networkcompanys__networkcompanykvknumber_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYKVKNUMBER_"+sGXsfl_65_fel_idx;
         edtavSdt_networkcompanys__networkcompanyname_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYNAME_"+sGXsfl_65_fel_idx;
         edtavSdt_networkcompanys__networkcompanyemail_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYEMAIL_"+sGXsfl_65_fel_idx;
         edtavSdt_networkcompanys__networkcompanyphone_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYPHONE_"+sGXsfl_65_fel_idx;
         edtavSdt_networkcompanys__networkcompanycountry_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYCOUNTRY_"+sGXsfl_65_fel_idx;
         edtavSdt_networkcompanys__networkcompanycity_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYCITY_"+sGXsfl_65_fel_idx;
         edtavSdt_networkcompanys__networkcompanyzipcode_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYZIPCODE_"+sGXsfl_65_fel_idx;
         edtavSdt_networkcompanys__networkcompanyaddressline1_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYADDRESSLINE1_"+sGXsfl_65_fel_idx;
         edtavSdt_networkcompanys__networkcompanyaddressline2_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYADDRESSLINE2_"+sGXsfl_65_fel_idx;
         edtavSdt_networkcompanys__networkcompanyfulladdress_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYFULLADDRESS_"+sGXsfl_65_fel_idx;
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_65_fel_idx;
      }

      protected void sendrow_652( )
      {
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_652( ) ;
         WB6S0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_65_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
         {
            GridsRow = GXWebRow.GetNew(context,GridsContainer);
            if ( subGrids_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrids_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Odd";
               }
            }
            else if ( subGrids_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrids_Backstyle = 0;
               subGrids_Backcolor = subGrids_Allbackcolor;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Uniform";
               }
            }
            else if ( subGrids_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrids_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Odd";
               }
               subGrids_Backcolor = (int)(0x0);
            }
            else if ( subGrids_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrids_Backstyle = 1;
               if ( ((int)((nGXsfl_65_idx) % (2))) == 0 )
               {
                  subGrids_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Even";
                  }
               }
               else
               {
                  subGrids_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrids_Class, "") != 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Odd";
                  }
               }
            }
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_65_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkcompanys__networkcompanyid_Internalname,((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanyid.ToString(),((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanyid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkcompanys__networkcompanyid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkcompanys__networkcompanyid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)65,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkcompanys__networkcompanykvknumber_Internalname,((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanykvknumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkcompanys__networkcompanykvknumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_networkcompanys__networkcompanykvknumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkcompanys__networkcompanyname_Internalname,((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanyname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkcompanys__networkcompanyname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_networkcompanys__networkcompanyname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkcompanys__networkcompanyemail_Internalname,((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanyemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkcompanys__networkcompanyemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_networkcompanys__networkcompanyemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkcompanys__networkcompanyphone_Internalname,StringUtil.RTrim( ((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanyphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkcompanys__networkcompanyphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_networkcompanys__networkcompanyphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkcompanys__networkcompanycountry_Internalname,((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanycountry,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkcompanys__networkcompanycountry_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkcompanys__networkcompanycountry_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkcompanys__networkcompanycity_Internalname,((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanycity,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkcompanys__networkcompanycity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkcompanys__networkcompanycity_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkcompanys__networkcompanyzipcode_Internalname,((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanyzipcode,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkcompanys__networkcompanyzipcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkcompanys__networkcompanyzipcode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkcompanys__networkcompanyaddressline1_Internalname,((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanyaddressline1,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkcompanys__networkcompanyaddressline1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkcompanys__networkcompanyaddressline1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkcompanys__networkcompanyaddressline2_Internalname,((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanyaddressline2,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkcompanys__networkcompanyaddressline2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkcompanys__networkcompanyaddressline2_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkcompanys__networkcompanyfulladdress_Internalname,((SdtSDT_NetworkCompany)AV13SDT_NetworkCompanys.Item(AV39GXV1)).gxTpr_Networkcompanyfulladdress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkcompanys__networkcompanyfulladdress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_networkcompanys__networkcompanyfulladdress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'" + sGXsfl_65_idx + "',65)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUdelete_Internalname,StringUtil.RTrim( AV12UDelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUDELETE.CLICK."+sGXsfl_65_idx+"'",(string)"",(string)"",(string)"Delete item",(string)"",(string)edtavUdelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUdelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes6S2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_65_idx = ((subGrids_Islastpage==1)&&(nGXsfl_65_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_65_idx+1);
            sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
            SubsflControlProps_652( ) ;
         }
         /* End function sendrow_652 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl65( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"DivS\" data-gxgridid=\"65\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrids_Internalname, subGrids_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrids_Backcolorstyle == 0 )
            {
               subGrids_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrids_Class) > 0 )
               {
                  subGrids_Linesclass = subGrids_Class+"Title";
               }
            }
            else
            {
               subGrids_Titlebackstyle = 1;
               if ( subGrids_Backcolorstyle == 1 )
               {
                  subGrids_Titlebackcolor = subGrids_Allbackcolor;
                  if ( StringUtil.Len( subGrids_Class) > 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrids_Class) > 0 )
                  {
                     subGrids_Linesclass = subGrids_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Network Company Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "KVK Number") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Network Company Country") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Network Company City") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Network Company Zip Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Network Company Address Line1") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Network Company Address Line2") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Address") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridsContainer.AddObjectProperty("GridName", "Grids");
         }
         else
         {
            GridsContainer.AddObjectProperty("GridName", "Grids");
            GridsContainer.AddObjectProperty("Header", subGrids_Header);
            GridsContainer.AddObjectProperty("Class", "WorkWith");
            GridsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Backcolorstyle), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("CmpContext", sPrefix);
            GridsContainer.AddObjectProperty("InMasterPage", "false");
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkcompanys__networkcompanyid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkcompanys__networkcompanykvknumber_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkcompanys__networkcompanyname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkcompanys__networkcompanyemail_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkcompanys__networkcompanyphone_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkcompanys__networkcompanycountry_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkcompanys__networkcompanycity_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkcompanys__networkcompanyzipcode_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkcompanys__networkcompanyaddressline1_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkcompanys__networkcompanyaddressline2_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkcompanys__networkcompanyfulladdress_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12UDelete)));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUdelete_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectedindex), 4, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowselection), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Selectioncolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowhovering), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Hoveringcolor), 9, 0, ".", "")));
            GridsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Allowcollapsing), 1, 0, ".", "")));
            GridsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavNetworkcompanyname_Internalname = sPrefix+"vNETWORKCOMPANYNAME";
         edtavNetworkcompanykvknumber_Internalname = sPrefix+"vNETWORKCOMPANYKVKNUMBER";
         edtavNetworkcompanyemail_Internalname = sPrefix+"vNETWORKCOMPANYEMAIL";
         edtavNetworkcompanyphone_Internalname = sPrefix+"vNETWORKCOMPANYPHONE";
         lblTextblockcombo_networkcompanycountry_Internalname = sPrefix+"TEXTBLOCKCOMBO_NETWORKCOMPANYCOUNTRY";
         Combo_networkcompanycountry_Internalname = sPrefix+"COMBO_NETWORKCOMPANYCOUNTRY";
         divTablesplittednetworkcompanycountry_Internalname = sPrefix+"TABLESPLITTEDNETWORKCOMPANYCOUNTRY";
         edtavNetworkcompanycity_Internalname = sPrefix+"vNETWORKCOMPANYCITY";
         edtavNetworkcompanyzipcode_Internalname = sPrefix+"vNETWORKCOMPANYZIPCODE";
         edtavNetworkcompanyaddressline1_Internalname = sPrefix+"vNETWORKCOMPANYADDRESSLINE1";
         edtavNetworkcompanyaddressline2_Internalname = sPrefix+"vNETWORKCOMPANYADDRESSLINE2";
         divIncformtable_Internalname = sPrefix+"INCFORMTABLE";
         bttBtnuinsert_Internalname = sPrefix+"BTNUINSERT";
         edtavSdt_networkcompanys__networkcompanyid_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYID";
         edtavSdt_networkcompanys__networkcompanykvknumber_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYKVKNUMBER";
         edtavSdt_networkcompanys__networkcompanyname_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYNAME";
         edtavSdt_networkcompanys__networkcompanyemail_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYEMAIL";
         edtavSdt_networkcompanys__networkcompanyphone_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYPHONE";
         edtavSdt_networkcompanys__networkcompanycountry_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYCOUNTRY";
         edtavSdt_networkcompanys__networkcompanycity_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYCITY";
         edtavSdt_networkcompanys__networkcompanyzipcode_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYZIPCODE";
         edtavSdt_networkcompanys__networkcompanyaddressline1_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYADDRESSLINE1";
         edtavSdt_networkcompanys__networkcompanyaddressline2_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYADDRESSLINE2";
         edtavSdt_networkcompanys__networkcompanyfulladdress_Internalname = sPrefix+"SDT_NETWORKCOMPANYS__NETWORKCOMPANYFULLADDRESS";
         edtavUdelete_Internalname = sPrefix+"vUDELETE";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavNetworkcompanycountry_Internalname = sPrefix+"vNETWORKCOMPANYCOUNTRY";
         edtavNetworkcompanyid_Internalname = sPrefix+"vNETWORKCOMPANYID";
         Grids_empowerer_Internalname = sPrefix+"GRIDS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrids_Internalname = sPrefix+"GRIDS";
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
         subGrids_Allowcollapsing = 0;
         subGrids_Allowselection = 0;
         subGrids_Header = "";
         edtavUdelete_Jsonclick = "";
         edtavUdelete_Enabled = 1;
         edtavSdt_networkcompanys__networkcompanyfulladdress_Jsonclick = "";
         edtavSdt_networkcompanys__networkcompanyfulladdress_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyaddressline2_Jsonclick = "";
         edtavSdt_networkcompanys__networkcompanyaddressline2_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyaddressline1_Jsonclick = "";
         edtavSdt_networkcompanys__networkcompanyaddressline1_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyzipcode_Jsonclick = "";
         edtavSdt_networkcompanys__networkcompanyzipcode_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanycity_Jsonclick = "";
         edtavSdt_networkcompanys__networkcompanycity_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanycountry_Jsonclick = "";
         edtavSdt_networkcompanys__networkcompanycountry_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyphone_Jsonclick = "";
         edtavSdt_networkcompanys__networkcompanyphone_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyemail_Jsonclick = "";
         edtavSdt_networkcompanys__networkcompanyemail_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyname_Jsonclick = "";
         edtavSdt_networkcompanys__networkcompanyname_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanykvknumber_Jsonclick = "";
         edtavSdt_networkcompanys__networkcompanykvknumber_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyid_Jsonclick = "";
         edtavSdt_networkcompanys__networkcompanyid_Enabled = 0;
         subGrids_Class = "WorkWith";
         subGrids_Backcolorstyle = 0;
         Combo_networkcompanycountry_Htmltemplate = "";
         edtavNetworkcompanyid_Jsonclick = "";
         edtavNetworkcompanyid_Visible = 1;
         edtavNetworkcompanycountry_Jsonclick = "";
         edtavNetworkcompanycountry_Visible = 1;
         Btnwizardlastnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardlastnext_Caption = "Finish";
         Btnwizardlastnext_Tooltiptext = "";
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = "Previous";
         Btnwizardprevious_Tooltiptext = "";
         edtavNetworkcompanyaddressline2_Jsonclick = "";
         edtavNetworkcompanyaddressline2_Enabled = 1;
         edtavNetworkcompanyaddressline1_Jsonclick = "";
         edtavNetworkcompanyaddressline1_Enabled = 1;
         edtavNetworkcompanyzipcode_Jsonclick = "";
         edtavNetworkcompanyzipcode_Enabled = 1;
         edtavNetworkcompanycity_Jsonclick = "";
         edtavNetworkcompanycity_Enabled = 1;
         Combo_networkcompanycountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_networkcompanycountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_networkcompanycountry_Caption = "";
         edtavNetworkcompanyphone_Jsonclick = "";
         edtavNetworkcompanyphone_Enabled = 1;
         edtavNetworkcompanyemail_Jsonclick = "";
         edtavNetworkcompanyemail_Enabled = 1;
         edtavNetworkcompanykvknumber_Jsonclick = "";
         edtavNetworkcompanykvknumber_Enabled = 1;
         edtavNetworkcompanyname_Jsonclick = "";
         edtavNetworkcompanyname_Enabled = 1;
         edtavSdt_networkcompanys__networkcompanyfulladdress_Enabled = -1;
         edtavSdt_networkcompanys__networkcompanyaddressline2_Enabled = -1;
         edtavSdt_networkcompanys__networkcompanyaddressline1_Enabled = -1;
         edtavSdt_networkcompanys__networkcompanyzipcode_Enabled = -1;
         edtavSdt_networkcompanys__networkcompanycity_Enabled = -1;
         edtavSdt_networkcompanys__networkcompanycountry_Enabled = -1;
         edtavSdt_networkcompanys__networkcompanyphone_Enabled = -1;
         edtavSdt_networkcompanys__networkcompanyemail_Enabled = -1;
         edtavSdt_networkcompanys__networkcompanyname_Enabled = -1;
         edtavSdt_networkcompanys__networkcompanykvknumber_Enabled = -1;
         edtavSdt_networkcompanys__networkcompanyid_Enabled = -1;
         subGrids_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E156S2","iparms":[]""");
         setEventMetadata("GRIDS.LOAD",""","oparms":[{"av":"AV12UDelete","fld":"vUDELETE"}]}""");
         setEventMetadata("ENTER","""{"handler":"E116S2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV24CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV14NetworkCompanyId","fld":"vNETWORKCOMPANYID"},{"av":"AV15NetworkCompanyName","fld":"vNETWORKCOMPANYNAME"},{"av":"AV16NetworkCompanyKvkNumber","fld":"vNETWORKCOMPANYKVKNUMBER"},{"av":"AV17NetworkCompanyEmail","fld":"vNETWORKCOMPANYEMAIL"},{"av":"AV18NetworkCompanyPhone","fld":"vNETWORKCOMPANYPHONE"},{"av":"AV19NetworkCompanyCountry","fld":"vNETWORKCOMPANYCOUNTRY"},{"av":"AV20NetworkCompanyCity","fld":"vNETWORKCOMPANYCITY"},{"av":"AV21NetworkCompanyZipCode","fld":"vNETWORKCOMPANYZIPCODE"},{"av":"AV22NetworkCompanyAddressLine1","fld":"vNETWORKCOMPANYADDRESSLINE1"},{"av":"AV23NetworkCompanyAddressLine2","fld":"vNETWORKCOMPANYADDRESSLINE2"},{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65},{"av":"AV29Trn_Resident","fld":"vTRN_RESIDENT"},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV29Trn_Resident","fld":"vTRN_RESIDENT"},{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65},{"av":"AV24CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV16NetworkCompanyKvkNumber","fld":"vNETWORKCOMPANYKVKNUMBER"},{"av":"AV15NetworkCompanyName","fld":"vNETWORKCOMPANYNAME"},{"av":"AV17NetworkCompanyEmail","fld":"vNETWORKCOMPANYEMAIL"},{"av":"AV18NetworkCompanyPhone","fld":"vNETWORKCOMPANYPHONE"},{"av":"AV19NetworkCompanyCountry","fld":"vNETWORKCOMPANYCOUNTRY"},{"av":"AV20NetworkCompanyCity","fld":"vNETWORKCOMPANYCITY"},{"av":"AV21NetworkCompanyZipCode","fld":"vNETWORKCOMPANYZIPCODE"},{"av":"AV22NetworkCompanyAddressLine1","fld":"vNETWORKCOMPANYADDRESSLINE1"},{"av":"AV23NetworkCompanyAddressLine2","fld":"vNETWORKCOMPANYADDRESSLINE2"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E126S2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV14NetworkCompanyId","fld":"vNETWORKCOMPANYID"},{"av":"AV15NetworkCompanyName","fld":"vNETWORKCOMPANYNAME"},{"av":"AV16NetworkCompanyKvkNumber","fld":"vNETWORKCOMPANYKVKNUMBER"},{"av":"AV17NetworkCompanyEmail","fld":"vNETWORKCOMPANYEMAIL"},{"av":"AV18NetworkCompanyPhone","fld":"vNETWORKCOMPANYPHONE"},{"av":"AV19NetworkCompanyCountry","fld":"vNETWORKCOMPANYCOUNTRY"},{"av":"AV20NetworkCompanyCity","fld":"vNETWORKCOMPANYCITY"},{"av":"AV21NetworkCompanyZipCode","fld":"vNETWORKCOMPANYZIPCODE"},{"av":"AV22NetworkCompanyAddressLine1","fld":"vNETWORKCOMPANYADDRESSLINE1"},{"av":"AV23NetworkCompanyAddressLine2","fld":"vNETWORKCOMPANYADDRESSLINE2"},{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOUINSERT'","""{"handler":"E136S2","iparms":[{"av":"AV24CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65},{"av":"AV16NetworkCompanyKvkNumber","fld":"vNETWORKCOMPANYKVKNUMBER"},{"av":"AV15NetworkCompanyName","fld":"vNETWORKCOMPANYNAME"},{"av":"AV17NetworkCompanyEmail","fld":"vNETWORKCOMPANYEMAIL"},{"av":"AV18NetworkCompanyPhone","fld":"vNETWORKCOMPANYPHONE"},{"av":"AV19NetworkCompanyCountry","fld":"vNETWORKCOMPANYCOUNTRY"},{"av":"AV20NetworkCompanyCity","fld":"vNETWORKCOMPANYCITY"},{"av":"AV21NetworkCompanyZipCode","fld":"vNETWORKCOMPANYZIPCODE"},{"av":"AV22NetworkCompanyAddressLine1","fld":"vNETWORKCOMPANYADDRESSLINE1"},{"av":"AV23NetworkCompanyAddressLine2","fld":"vNETWORKCOMPANYADDRESSLINE2"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("'DOUINSERT'",""","oparms":[{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65},{"av":"AV24CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV16NetworkCompanyKvkNumber","fld":"vNETWORKCOMPANYKVKNUMBER"},{"av":"AV15NetworkCompanyName","fld":"vNETWORKCOMPANYNAME"},{"av":"AV17NetworkCompanyEmail","fld":"vNETWORKCOMPANYEMAIL"},{"av":"AV18NetworkCompanyPhone","fld":"vNETWORKCOMPANYPHONE"},{"av":"AV19NetworkCompanyCountry","fld":"vNETWORKCOMPANYCOUNTRY"},{"av":"AV20NetworkCompanyCity","fld":"vNETWORKCOMPANYCITY"},{"av":"AV21NetworkCompanyZipCode","fld":"vNETWORKCOMPANYZIPCODE"},{"av":"AV22NetworkCompanyAddressLine1","fld":"vNETWORKCOMPANYADDRESSLINE1"},{"av":"AV23NetworkCompanyAddressLine2","fld":"vNETWORKCOMPANYADDRESSLINE2"}]}""");
         setEventMetadata("VUDELETE.CLICK","""{"handler":"E166S2","iparms":[{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VUDELETE.CLICK",""","oparms":[{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65}]}""");
         setEventMetadata("GRIDS_FIRSTPAGE","""{"handler":"subgrids_firstpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDS_PREVPAGE","""{"handler":"subgrids_previouspage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDS_NEXTPAGE","""{"handler":"subgrids_nextpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDS_LASTPAGE","""{"handler":"subgrids_lastpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV13SDT_NetworkCompanys","fld":"vSDT_NETWORKCOMPANYS","grid":65},{"av":"nGXsfl_65_idx","ctrl":"GRID","prop":"GridCurrRow","grid":65},{"av":"nRC_GXsfl_65","ctrl":"GRIDS","prop":"GridRC","grid":65},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("VALIDV_NETWORKCOMPANYEMAIL","""{"handler":"Validv_Networkcompanyemail","iparms":[]}""");
         setEventMetadata("VALIDV_NETWORKCOMPANYID","""{"handler":"Validv_Networkcompanyid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Udelete","iparms":[]}""");
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
         Combo_networkcompanycountry_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV13SDT_NetworkCompanys = new GXBaseCollection<SdtSDT_NetworkCompany>( context, "SDT_NetworkCompany", "");
         AV35DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV34NetworkCompanyCountry_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV29Trn_Resident = new SdtTrn_Resident(context);
         AV11WizardData = new SdtWP_CreateResidentAndNetworkData(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV15NetworkCompanyName = "";
         AV16NetworkCompanyKvkNumber = "";
         AV17NetworkCompanyEmail = "";
         AV18NetworkCompanyPhone = "";
         lblTextblockcombo_networkcompanycountry_Jsonclick = "";
         ucCombo_networkcompanycountry = new GXUserControl();
         AV20NetworkCompanyCity = "";
         AV21NetworkCompanyZipCode = "";
         AV22NetworkCompanyAddressLine1 = "";
         AV23NetworkCompanyAddressLine2 = "";
         bttBtnuinsert_Jsonclick = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardlastnext = new GXUserControl();
         AV19NetworkCompanyCountry = "";
         AV14NetworkCompanyId = Guid.Empty;
         ucGrids_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV12UDelete = "";
         GXDecQS = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_char2 = "";
         Grids_empowerer_Gridinternalname = "";
         Combo_networkcompanycountry_Selectedtext_set = "";
         Combo_networkcompanycountry_Selectedvalue_set = "";
         GridsRow = new GXWebRow();
         AV5WebSession = context.GetSession();
         AV25SDT_NetworkCompany = new SdtSDT_NetworkCompany(context);
         AV27Trn_NetworkCompany = new SdtTrn_NetworkCompany(context);
         GXt_guid3 = Guid.Empty;
         AV28SDT_NetworkIndividual = new SdtSDT_NetworkIndividual(context);
         AV30NetworkIndividual = new SdtTrn_Resident_NetworkIndividual(context);
         AV31NetworkCompany = new SdtTrn_Resident_NetworkCompany(context);
         AV32ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV54GXV16 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem4 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV38NetworkCompanyCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV37Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV33ComboTitles = new GxSimpleCollection<string>();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         subGrids_Linesclass = "";
         ROClassString = "";
         GridsColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_createresidentandnetworkstep3__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createresidentandnetworkstep3__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavSdt_networkcompanys__networkcompanyid_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanykvknumber_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyname_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyemail_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyphone_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanycountry_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanycity_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyzipcode_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyaddressline1_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyaddressline2_Enabled = 0;
         edtavSdt_networkcompanys__networkcompanyfulladdress_Enabled = 0;
         edtavUdelete_Enabled = 0;
      }

      private short GRIDS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrids_Backcolorstyle ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrids_Backstyle ;
      private short subGrids_Titlebackstyle ;
      private short subGrids_Allowselection ;
      private short subGrids_Allowhovering ;
      private short subGrids_Allowcollapsing ;
      private short subGrids_Collapsed ;
      private int nRC_GXsfl_65 ;
      private int subGrids_Rows ;
      private int nGXsfl_65_idx=1 ;
      private int edtavSdt_networkcompanys__networkcompanyid_Enabled ;
      private int edtavSdt_networkcompanys__networkcompanykvknumber_Enabled ;
      private int edtavSdt_networkcompanys__networkcompanyname_Enabled ;
      private int edtavSdt_networkcompanys__networkcompanyemail_Enabled ;
      private int edtavSdt_networkcompanys__networkcompanyphone_Enabled ;
      private int edtavSdt_networkcompanys__networkcompanycountry_Enabled ;
      private int edtavSdt_networkcompanys__networkcompanycity_Enabled ;
      private int edtavSdt_networkcompanys__networkcompanyzipcode_Enabled ;
      private int edtavSdt_networkcompanys__networkcompanyaddressline1_Enabled ;
      private int edtavSdt_networkcompanys__networkcompanyaddressline2_Enabled ;
      private int edtavSdt_networkcompanys__networkcompanyfulladdress_Enabled ;
      private int edtavUdelete_Enabled ;
      private int edtavNetworkcompanyname_Enabled ;
      private int edtavNetworkcompanykvknumber_Enabled ;
      private int edtavNetworkcompanyemail_Enabled ;
      private int edtavNetworkcompanyphone_Enabled ;
      private int edtavNetworkcompanycity_Enabled ;
      private int edtavNetworkcompanyzipcode_Enabled ;
      private int edtavNetworkcompanyaddressline1_Enabled ;
      private int edtavNetworkcompanyaddressline2_Enabled ;
      private int AV39GXV1 ;
      private int edtavNetworkcompanycountry_Visible ;
      private int edtavNetworkcompanyid_Visible ;
      private int subGrids_Islastpage ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_65_fel_idx=1 ;
      private int nGXsfl_65_bak_idx=1 ;
      private int AV51GXV13 ;
      private int AV52GXV14 ;
      private int AV53GXV15 ;
      private int AV55GXV17 ;
      private int idxLst ;
      private int subGrids_Backcolor ;
      private int subGrids_Allbackcolor ;
      private int subGrids_Titlebackcolor ;
      private int subGrids_Selectedindex ;
      private int subGrids_Selectioncolor ;
      private int subGrids_Hoveringcolor ;
      private long GRIDS_nFirstRecordOnPage ;
      private long GRIDS_nCurrentRecord ;
      private long GRIDS_nRecordCount ;
      private string Combo_networkcompanycountry_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_65_idx="0001" ;
      private string edtavSdt_networkcompanys__networkcompanyid_Internalname ;
      private string edtavSdt_networkcompanys__networkcompanykvknumber_Internalname ;
      private string edtavSdt_networkcompanys__networkcompanyname_Internalname ;
      private string edtavSdt_networkcompanys__networkcompanyemail_Internalname ;
      private string edtavSdt_networkcompanys__networkcompanyphone_Internalname ;
      private string edtavSdt_networkcompanys__networkcompanycountry_Internalname ;
      private string edtavSdt_networkcompanys__networkcompanycity_Internalname ;
      private string edtavSdt_networkcompanys__networkcompanyzipcode_Internalname ;
      private string edtavSdt_networkcompanys__networkcompanyaddressline1_Internalname ;
      private string edtavSdt_networkcompanys__networkcompanyaddressline2_Internalname ;
      private string edtavSdt_networkcompanys__networkcompanyfulladdress_Internalname ;
      private string edtavUdelete_Internalname ;
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
      private string divIncformtable_Internalname ;
      private string edtavNetworkcompanyname_Internalname ;
      private string TempTags ;
      private string edtavNetworkcompanyname_Jsonclick ;
      private string edtavNetworkcompanykvknumber_Internalname ;
      private string edtavNetworkcompanykvknumber_Jsonclick ;
      private string edtavNetworkcompanyemail_Internalname ;
      private string edtavNetworkcompanyemail_Jsonclick ;
      private string edtavNetworkcompanyphone_Internalname ;
      private string AV18NetworkCompanyPhone ;
      private string edtavNetworkcompanyphone_Jsonclick ;
      private string divTablesplittednetworkcompanycountry_Internalname ;
      private string lblTextblockcombo_networkcompanycountry_Internalname ;
      private string lblTextblockcombo_networkcompanycountry_Jsonclick ;
      private string Combo_networkcompanycountry_Caption ;
      private string Combo_networkcompanycountry_Cls ;
      private string Combo_networkcompanycountry_Internalname ;
      private string edtavNetworkcompanycity_Internalname ;
      private string edtavNetworkcompanycity_Jsonclick ;
      private string edtavNetworkcompanyzipcode_Internalname ;
      private string edtavNetworkcompanyzipcode_Jsonclick ;
      private string edtavNetworkcompanyaddressline1_Internalname ;
      private string edtavNetworkcompanyaddressline1_Jsonclick ;
      private string edtavNetworkcompanyaddressline2_Internalname ;
      private string edtavNetworkcompanyaddressline2_Jsonclick ;
      private string bttBtnuinsert_Internalname ;
      private string bttBtnuinsert_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGrids_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardlastnext_Tooltiptext ;
      private string Btnwizardlastnext_Caption ;
      private string Btnwizardlastnext_Class ;
      private string Btnwizardlastnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavNetworkcompanycountry_Internalname ;
      private string edtavNetworkcompanycountry_Jsonclick ;
      private string edtavNetworkcompanyid_Internalname ;
      private string edtavNetworkcompanyid_Jsonclick ;
      private string Grids_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV12UDelete ;
      private string GXDecQS ;
      private string sGXsfl_65_fel_idx="0001" ;
      private string Combo_networkcompanycountry_Htmltemplate ;
      private string GXt_char2 ;
      private string Grids_empowerer_Gridinternalname ;
      private string Combo_networkcompanycountry_Selectedtext_set ;
      private string Combo_networkcompanycountry_Selectedvalue_set ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_networkcompanys__networkcompanyid_Jsonclick ;
      private string edtavSdt_networkcompanys__networkcompanykvknumber_Jsonclick ;
      private string edtavSdt_networkcompanys__networkcompanyname_Jsonclick ;
      private string edtavSdt_networkcompanys__networkcompanyemail_Jsonclick ;
      private string edtavSdt_networkcompanys__networkcompanyphone_Jsonclick ;
      private string edtavSdt_networkcompanys__networkcompanycountry_Jsonclick ;
      private string edtavSdt_networkcompanys__networkcompanycity_Jsonclick ;
      private string edtavSdt_networkcompanys__networkcompanyzipcode_Jsonclick ;
      private string edtavSdt_networkcompanys__networkcompanyaddressline1_Jsonclick ;
      private string edtavSdt_networkcompanys__networkcompanyaddressline2_Jsonclick ;
      private string edtavSdt_networkcompanys__networkcompanyfulladdress_Jsonclick ;
      private string edtavUdelete_Jsonclick ;
      private string subGrids_Header ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool bGXsfl_65_Refreshing=false ;
      private bool AV24CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Combo_networkcompanycountry_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV26isAlreadyAdded ;
      private bool gx_BV65 ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string AV15NetworkCompanyName ;
      private string AV16NetworkCompanyKvkNumber ;
      private string AV17NetworkCompanyEmail ;
      private string AV20NetworkCompanyCity ;
      private string AV21NetworkCompanyZipCode ;
      private string AV22NetworkCompanyAddressLine1 ;
      private string AV23NetworkCompanyAddressLine2 ;
      private string AV19NetworkCompanyCountry ;
      private Guid AV14NetworkCompanyId ;
      private Guid GXt_guid3 ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucCombo_networkcompanycountry ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardlastnext ;
      private GXUserControl ucGrids_empowerer ;
      private GXWebForm Form ;
      private IGxSession AV5WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_NetworkCompany> AV13SDT_NetworkCompanys ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV35DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV34NetworkCompanyCountry_Data ;
      private SdtTrn_Resident AV29Trn_Resident ;
      private SdtWP_CreateResidentAndNetworkData AV11WizardData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private SdtSDT_NetworkCompany AV25SDT_NetworkCompany ;
      private SdtTrn_NetworkCompany AV27Trn_NetworkCompany ;
      private IDataStoreProvider pr_default ;
      private SdtSDT_NetworkIndividual AV28SDT_NetworkIndividual ;
      private SdtTrn_Resident_NetworkIndividual AV30NetworkIndividual ;
      private SdtTrn_Resident_NetworkCompany AV31NetworkCompany ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV32ErrorMessages ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV54GXV16 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem4 ;
      private SdtSDT_Country_SDT_CountryItem AV38NetworkCompanyCountry_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV37Combo_DataItem ;
      private GxSimpleCollection<string> AV33ComboTitles ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_createresidentandnetworkstep3__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_createresidentandnetworkstep3__default : DataStoreHelperBase, IDataStoreHelper
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

}

}