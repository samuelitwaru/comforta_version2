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
   public class wp_createresidentandnetworkstep2 : GXWebComponent
   {
      public wp_createresidentandnetworkstep2( )
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

      public wp_createresidentandnetworkstep2( IGxContext context )
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
         this.AV26WebSessionKey = aP0_WebSessionKey;
         this.AV22PreviousStep = aP1_PreviousStep;
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
         cmbavNetworkindividualgender = new GXCombobox();
         cmbavSdt_networkindividuals__networkindividualgender = new GXCombobox();
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
                  AV26WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV26WebSessionKey", AV26WebSessionKey);
                  AV22PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV22PreviousStep", AV22PreviousStep);
                  AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV26WebSessionKey,(string)AV22PreviousStep,(bool)AV7GoingBack});
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
         nRC_GXsfl_74 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
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
         AV8HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrids_refresh( subGrids_Rows, AV8HasValidationErrors, sPrefix) ;
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
            PA6R2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdt_networkindividuals__networkindividualid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividualid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividualid_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavSdt_networkindividuals__networkindividualbsnnumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividualbsnnumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividualbsnnumber_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavSdt_networkindividuals__networkindividualgivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividualgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividualgivenname_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavSdt_networkindividuals__networkindividuallastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividuallastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividuallastname_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavSdt_networkindividuals__networkindividualemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividualemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividualemail_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavSdt_networkindividuals__networkindividualphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividualphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividualphone_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               cmbavSdt_networkindividuals__networkindividualgender.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSdt_networkindividuals__networkindividualgender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdt_networkindividuals__networkindividualgender.Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavSdt_networkindividuals__networkindividualcountry_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividualcountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividualcountry_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavSdt_networkindividuals__networkindividualcity_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividualcity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividualcity_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavSdt_networkindividuals__networkindividualzipcode_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividualzipcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividualzipcode_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavSdt_networkindividuals__networkindividualaddressline1_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividualaddressline1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividualaddressline1_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavSdt_networkindividuals__networkindividualaddressline2_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividualaddressline2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividualaddressline2_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavSdt_networkindividuals__networkindividualfulladdress_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_networkindividuals__networkindividualfulladdress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_networkindividuals__networkindividualfulladdress_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtavUdelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavUdelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUdelete_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               WS6R2( ) ;
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
            context.SendWebValue( "WP_Create Resident And Network Step2") ;
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
            GXEncryptionTmp = "wp_createresidentandnetworkstep2.aspx"+UrlEncode(StringUtil.RTrim(AV26WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV22PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createresidentandnetworkstep2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV8HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV8HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_networkindividuals", AV23SDT_NetworkIndividuals);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_networkindividuals", AV23SDT_NetworkIndividuals);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV33DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV33DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNETWORKINDIVIDUALCOUNTRY_DATA", AV32NetworkIndividualCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNETWORKINDIVIDUALCOUNTRY_DATA", AV32NetworkIndividualCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV26WebSessionKey", wcpOAV26WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV22PreviousStep", wcpOAV22PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV5CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV8HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV8HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV26WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_NETWORKINDIVIDUALS", AV23SDT_NetworkIndividuals);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_NETWORKINDIVIDUALS", AV23SDT_NetworkIndividuals);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV22PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_NETWORKINDIVIDUALCOUNTRY_Selectedvalue_get", StringUtil.RTrim( Combo_networkindividualcountry_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm6R2( )
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
         return "WP_CreateResidentAndNetworkStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return "WP_Create Resident And Network Step2" ;
      }

      protected void WB6R0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createresidentandnetworkstep2.aspx");
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
            GxWebStd.gx_div_start( context, divIniformtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualbsnnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualbsnnumber_Internalname, "BSN Number", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualbsnnumber_Internalname, AV12NetworkIndividualBsnNumber, StringUtil.RTrim( context.localUtil.Format( AV12NetworkIndividualBsnNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualbsnnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualbsnnumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualgivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualgivenname_Internalname, "Given Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualgivenname_Internalname, AV17NetworkIndividualGivenName, StringUtil.RTrim( context.localUtil.Format( AV17NetworkIndividualGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualgivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualgivenname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividuallastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividuallastname_Internalname, "Last Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividuallastname_Internalname, AV19NetworkIndividualLastName, StringUtil.RTrim( context.localUtil.Format( AV19NetworkIndividualLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividuallastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividuallastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavNetworkindividualgender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavNetworkindividualgender_Internalname, "Gender", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavNetworkindividualgender, cmbavNetworkindividualgender_Internalname, StringUtil.RTrim( AV16NetworkIndividualGender), 1, cmbavNetworkindividualgender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavNetworkindividualgender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_WP_CreateResidentAndNetworkStep2.htm");
            cmbavNetworkindividualgender.CurrentValue = StringUtil.RTrim( AV16NetworkIndividualGender);
            AssignProp(sPrefix, false, cmbavNetworkindividualgender_Internalname, "Values", (string)(cmbavNetworkindividualgender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualemail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualemail_Internalname, AV15NetworkIndividualEmail, StringUtil.RTrim( context.localUtil.Format( AV15NetworkIndividualEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualphone_Internalname, "Phone", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualphone_Internalname, StringUtil.RTrim( AV20NetworkIndividualPhone), StringUtil.RTrim( context.localUtil.Format( AV20NetworkIndividualPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittednetworkindividualcountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_networkindividualcountry_Internalname, "Country", "", "", lblTextblockcombo_networkindividualcountry_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateResidentAndNetworkStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_networkindividualcountry.SetProperty("Caption", Combo_networkindividualcountry_Caption);
            ucCombo_networkindividualcountry.SetProperty("Cls", Combo_networkindividualcountry_Cls);
            ucCombo_networkindividualcountry.SetProperty("EmptyItem", Combo_networkindividualcountry_Emptyitem);
            ucCombo_networkindividualcountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV33DDO_TitleSettingsIcons);
            ucCombo_networkindividualcountry.SetProperty("DropDownOptionsData", AV32NetworkIndividualCountry_Data);
            ucCombo_networkindividualcountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_networkindividualcountry_Internalname, sPrefix+"COMBO_NETWORKINDIVIDUALCOUNTRYContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualcity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualcity_Internalname, "City", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualcity_Internalname, AV13NetworkIndividualCity, StringUtil.RTrim( context.localUtil.Format( AV13NetworkIndividualCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualcity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualcity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualzipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualzipcode_Internalname, "Zip Code", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualzipcode_Internalname, AV21NetworkIndividualZipCode, StringUtil.RTrim( context.localUtil.Format( AV21NetworkIndividualZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualzipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualzipcode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualaddressline1_Internalname, "Address Line 1", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualaddressline1_Internalname, AV10NetworkIndividualAddressLine1, StringUtil.RTrim( context.localUtil.Format( AV10NetworkIndividualAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Street", edtavNetworkindividualaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualaddressline1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNetworkindividualaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNetworkindividualaddressline2_Internalname, "Address Line 2", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualaddressline2_Internalname, AV11NetworkIndividualAddressLine2, StringUtil.RTrim( context.localUtil.Format( AV11NetworkIndividualAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Building/Floor", edtavNetworkindividualaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNetworkindividualaddressline2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep2.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuinsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Add", bttBtnuinsert_Jsonclick, 5, "Add new item", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateResidentAndNetworkStep2.htm");
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
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridsContainer.AddObjectProperty("GRIDS_nEOF", GRIDS_nEOF);
               GridsContainer.AddObjectProperty("GRIDS_nFirstRecordOnPage", GRIDS_nFirstRecordOnPage);
               AV37GXV1 = nGXsfl_74_idx;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualcountry_Internalname, AV14NetworkIndividualCountry, StringUtil.RTrim( context.localUtil.Format( AV14NetworkIndividualCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualcountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavNetworkindividualcountry_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateResidentAndNetworkStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNetworkindividualid_Internalname, AV18NetworkIndividualId.ToString(), AV18NetworkIndividualId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNetworkindividualid_Jsonclick, 0, "Attribute", "", "", "", "", edtavNetworkindividualid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateResidentAndNetworkStep2.htm");
            /* User Defined Control */
            ucGrids_empowerer.Render(context, "wwp.gridempowerer", Grids_empowerer_Internalname, sPrefix+"GRIDS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 74 )
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
                  AV37GXV1 = nGXsfl_74_idx;
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

      protected void START6R2( )
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
            Form.Meta.addItem("description", "WP_Create Resident And Network Step2", 0) ;
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
               STRUP6R0( ) ;
            }
         }
      }

      protected void WS6R2( )
      {
         START6R2( ) ;
         EVT6R2( ) ;
      }

      protected void EVT6R2( )
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
                                 STRUP6R0( ) ;
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
                                 STRUP6R0( ) ;
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
                                          E116R2 ();
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
                                 STRUP6R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E126R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUInsert' */
                                    E136R2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6R0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdt_networkindividuals__networkindividualid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6R0( ) ;
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
                                 STRUP6R0( ) ;
                              }
                              nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV37GXV1 = (int)(nGXsfl_74_idx+GRIDS_nFirstRecordOnPage);
                              if ( ( AV23SDT_NetworkIndividuals.Count >= AV37GXV1 ) && ( AV37GXV1 > 0 ) )
                              {
                                 AV23SDT_NetworkIndividuals.CurrentItem = ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1));
                                 AV24UDelete = cgiGet( edtavUdelete_Internalname);
                                 AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV24UDelete);
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
                                          GX_FocusControl = edtavSdt_networkindividuals__networkindividualid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E146R2 ();
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
                                          GX_FocusControl = edtavSdt_networkindividuals__networkindividualid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grids.Load */
                                          E156R2 ();
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
                                          GX_FocusControl = edtavSdt_networkindividuals__networkindividualid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E166R2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP6R0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_networkindividuals__networkindividualid_Internalname;
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

      protected void WE6R2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6R2( ) ;
            }
         }
      }

      protected void PA6R2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createresidentandnetworkstep2.aspx")), "wp_createresidentandnetworkstep2.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createresidentandnetworkstep2.aspx")))) ;
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
               GX_FocusControl = edtavNetworkindividualbsnnumber_Internalname;
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
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrids_Islastpage==1)&&(nGXsfl_74_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridsContainer)) ;
         /* End function gxnrGrids_newrow */
      }

      protected void gxgrGrids_refresh( int subGrids_Rows ,
                                        bool AV8HasValidationErrors ,
                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDS_nCurrentRecord = 0;
         RF6R2( ) ;
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
         if ( cmbavNetworkindividualgender.ItemCount > 0 )
         {
            AV16NetworkIndividualGender = cmbavNetworkindividualgender.getValidValue(AV16NetworkIndividualGender);
            AssignAttri(sPrefix, false, "AV16NetworkIndividualGender", AV16NetworkIndividualGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavNetworkindividualgender.CurrentValue = StringUtil.RTrim( AV16NetworkIndividualGender);
            AssignProp(sPrefix, false, cmbavNetworkindividualgender_Internalname, "Values", cmbavNetworkindividualgender.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdt_networkindividuals__networkindividualid_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualbsnnumber_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualgivenname_Enabled = 0;
         edtavSdt_networkindividuals__networkindividuallastname_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualemail_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualphone_Enabled = 0;
         cmbavSdt_networkindividuals__networkindividualgender.Enabled = 0;
         edtavSdt_networkindividuals__networkindividualcountry_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualcity_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualzipcode_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualaddressline1_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualaddressline2_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualfulladdress_Enabled = 0;
         edtavUdelete_Enabled = 0;
      }

      protected void RF6R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridsContainer.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
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
            SubsflControlProps_742( ) ;
            /* Execute user event: Grids.Load */
            E156R2 ();
            if ( ( subGrids_Islastpage == 0 ) && ( GRIDS_nCurrentRecord > 0 ) && ( GRIDS_nGridOutOfScope == 0 ) && ( nGXsfl_74_idx == 1 ) )
            {
               GRIDS_nCurrentRecord = 0;
               GRIDS_nGridOutOfScope = 1;
               subgrids_firstpage( ) ;
               /* Execute user event: Grids.Load */
               E156R2 ();
            }
            wbEnd = 74;
            WB6R0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6R2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV8HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV8HasValidationErrors, context));
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
         return AV23SDT_NetworkIndividuals.Count ;
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
            gxgrGrids_refresh( subGrids_Rows, AV8HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV8HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV8HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV8HasValidationErrors, sPrefix) ;
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
            gxgrGrids_refresh( subGrids_Rows, AV8HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdt_networkindividuals__networkindividualid_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualbsnnumber_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualgivenname_Enabled = 0;
         edtavSdt_networkindividuals__networkindividuallastname_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualemail_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualphone_Enabled = 0;
         cmbavSdt_networkindividuals__networkindividualgender.Enabled = 0;
         edtavSdt_networkindividuals__networkindividualcountry_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualcity_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualzipcode_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualaddressline1_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualaddressline2_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualfulladdress_Enabled = 0;
         edtavUdelete_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E146R2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_networkindividuals"), AV23SDT_NetworkIndividuals);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV33DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vNETWORKINDIVIDUALCOUNTRY_DATA"), AV32NetworkIndividualCountry_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_NETWORKINDIVIDUALS"), AV23SDT_NetworkIndividuals);
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_74"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOAV26WebSessionKey = cgiGet( sPrefix+"wcpOAV26WebSessionKey");
            wcpOAV22PreviousStep = cgiGet( sPrefix+"wcpOAV22PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            GRIDS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrids_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDS_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
            nRC_GXsfl_74 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_74"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_74_fel_idx = 0;
            while ( nGXsfl_74_fel_idx < nRC_GXsfl_74 )
            {
               nGXsfl_74_fel_idx = ((subGrids_Islastpage==1)&&(nGXsfl_74_fel_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_fel_idx+1);
               sGXsfl_74_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_742( ) ;
               AV37GXV1 = (int)(nGXsfl_74_fel_idx+GRIDS_nFirstRecordOnPage);
               if ( ( AV23SDT_NetworkIndividuals.Count >= AV37GXV1 ) && ( AV37GXV1 > 0 ) )
               {
                  AV23SDT_NetworkIndividuals.CurrentItem = ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1));
                  AV24UDelete = cgiGet( edtavUdelete_Internalname);
               }
            }
            if ( nGXsfl_74_fel_idx == 0 )
            {
               nGXsfl_74_idx = 1;
               sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
               SubsflControlProps_742( ) ;
            }
            nGXsfl_74_fel_idx = 1;
            /* Read variables values. */
            AV12NetworkIndividualBsnNumber = cgiGet( edtavNetworkindividualbsnnumber_Internalname);
            AssignAttri(sPrefix, false, "AV12NetworkIndividualBsnNumber", AV12NetworkIndividualBsnNumber);
            AV17NetworkIndividualGivenName = cgiGet( edtavNetworkindividualgivenname_Internalname);
            AssignAttri(sPrefix, false, "AV17NetworkIndividualGivenName", AV17NetworkIndividualGivenName);
            AV19NetworkIndividualLastName = cgiGet( edtavNetworkindividuallastname_Internalname);
            AssignAttri(sPrefix, false, "AV19NetworkIndividualLastName", AV19NetworkIndividualLastName);
            cmbavNetworkindividualgender.Name = cmbavNetworkindividualgender_Internalname;
            cmbavNetworkindividualgender.CurrentValue = cgiGet( cmbavNetworkindividualgender_Internalname);
            AV16NetworkIndividualGender = cgiGet( cmbavNetworkindividualgender_Internalname);
            AssignAttri(sPrefix, false, "AV16NetworkIndividualGender", AV16NetworkIndividualGender);
            AV15NetworkIndividualEmail = cgiGet( edtavNetworkindividualemail_Internalname);
            AssignAttri(sPrefix, false, "AV15NetworkIndividualEmail", AV15NetworkIndividualEmail);
            AV20NetworkIndividualPhone = cgiGet( edtavNetworkindividualphone_Internalname);
            AssignAttri(sPrefix, false, "AV20NetworkIndividualPhone", AV20NetworkIndividualPhone);
            AV13NetworkIndividualCity = cgiGet( edtavNetworkindividualcity_Internalname);
            AssignAttri(sPrefix, false, "AV13NetworkIndividualCity", AV13NetworkIndividualCity);
            AV21NetworkIndividualZipCode = cgiGet( edtavNetworkindividualzipcode_Internalname);
            AssignAttri(sPrefix, false, "AV21NetworkIndividualZipCode", AV21NetworkIndividualZipCode);
            AV10NetworkIndividualAddressLine1 = cgiGet( edtavNetworkindividualaddressline1_Internalname);
            AssignAttri(sPrefix, false, "AV10NetworkIndividualAddressLine1", AV10NetworkIndividualAddressLine1);
            AV11NetworkIndividualAddressLine2 = cgiGet( edtavNetworkindividualaddressline2_Internalname);
            AssignAttri(sPrefix, false, "AV11NetworkIndividualAddressLine2", AV11NetworkIndividualAddressLine2);
            AV14NetworkIndividualCountry = cgiGet( edtavNetworkindividualcountry_Internalname);
            AssignAttri(sPrefix, false, "AV14NetworkIndividualCountry", AV14NetworkIndividualCountry);
            if ( StringUtil.StrCmp(cgiGet( edtavNetworkindividualid_Internalname), "") == 0 )
            {
               AV18NetworkIndividualId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV18NetworkIndividualId", AV18NetworkIndividualId.ToString());
            }
            else
            {
               try
               {
                  AV18NetworkIndividualId = StringUtil.StrToGuid( cgiGet( edtavNetworkindividualid_Internalname));
                  AssignAttri(sPrefix, false, "AV18NetworkIndividualId", AV18NetworkIndividualId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vNETWORKINDIVIDUALID");
                  GX_FocusControl = edtavNetworkindividualid_Internalname;
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
         E146R2 ();
         if (returnInSub) return;
      }

      protected void E146R2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV33DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV33DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavNetworkindividualcountry_Visible = 0;
         AssignProp(sPrefix, false, edtavNetworkindividualcountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualcountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_networkindividualcountry_Htmltemplate = GXt_char2;
         ucCombo_networkindividualcountry.SendProperty(context, sPrefix, false, Combo_networkindividualcountry_Internalname, "HTMLTemplate", Combo_networkindividualcountry_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBONETWORKINDIVIDUALCOUNTRY' */
         S122 ();
         if (returnInSub) return;
         edtavNetworkindividualid_Visible = 0;
         AssignProp(sPrefix, false, edtavNetworkindividualid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNetworkindividualid_Visible), 5, 0), true);
         Grids_empowerer_Gridinternalname = subGrids_Internalname;
         ucGrids_empowerer.SendProperty(context, sPrefix, false, Grids_empowerer_Internalname, "GridInternalName", Grids_empowerer_Gridinternalname);
         subGrids_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrids_Rows), 6, 0, ".", "")));
         Combo_networkindividualcountry_Selectedtext_set = "Netherlands";
         ucCombo_networkindividualcountry.SendProperty(context, sPrefix, false, Combo_networkindividualcountry_Internalname, "SelectedText_set", Combo_networkindividualcountry_Selectedtext_set);
         Combo_networkindividualcountry_Selectedvalue_set = "Netherlands";
         ucCombo_networkindividualcountry.SendProperty(context, sPrefix, false, Combo_networkindividualcountry_Internalname, "SelectedValue_set", Combo_networkindividualcountry_Selectedvalue_set);
      }

      private void E156R2( )
      {
         /* Grids_Load Routine */
         returnInSub = false;
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV23SDT_NetworkIndividuals.Count )
         {
            AV23SDT_NetworkIndividuals.CurrentItem = ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1));
            AV24UDelete = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV24UDelete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 74;
            }
            if ( ( subGrids_Islastpage == 1 ) || ( subGrids_Rows == 0 ) || ( ( GRIDS_nCurrentRecord >= GRIDS_nFirstRecordOnPage ) && ( GRIDS_nCurrentRecord < GRIDS_nFirstRecordOnPage + subGrids_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_742( ) ;
            }
            GRIDS_nEOF = (short)(((GRIDS_nCurrentRecord<GRIDS_nFirstRecordOnPage+subGrids_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDS_nEOF), 1, 0, ".", "")));
            GRIDS_nCurrentRecord = (long)(GRIDS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
            {
               DoAjaxLoad(74, GridsRow);
            }
            AV37GXV1 = (int)(AV37GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E116R2 ();
         if (returnInSub) return;
      }

      protected void E116R2( )
      {
         AV37GXV1 = (int)(nGXsfl_74_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV37GXV1 > 0 ) && ( AV23SDT_NetworkIndividuals.Count >= AV37GXV1 ) )
         {
            AV23SDT_NetworkIndividuals.CurrentItem = ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( true )
         {
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
            GXEncryptionTmp = "wp_createresidentandnetwork.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step3")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wp_createresidentandnetwork.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S142 ();
            if (returnInSub) return;
            if ( AV5CheckRequiredFieldsResult && ! AV8HasValidationErrors )
            {
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
               GXEncryptionTmp = "wp_createresidentandnetwork.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step3")) + "," + UrlEncode(StringUtil.BoolToStr(false));
               CallWebObject(formatLink("wp_createresidentandnetwork.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E126R2( )
      {
         AV37GXV1 = (int)(nGXsfl_74_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV37GXV1 > 0 ) && ( AV23SDT_NetworkIndividuals.Count >= AV37GXV1 ) )
         {
            AV23SDT_NetworkIndividuals.CurrentItem = ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1));
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
         GXEncryptionTmp = "wp_createresidentandnetwork.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wp_createresidentandnetwork.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      protected void E136R2( )
      {
         AV37GXV1 = (int)(nGXsfl_74_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV37GXV1 > 0 ) && ( AV23SDT_NetworkIndividuals.Count >= AV37GXV1 ) )
         {
            AV23SDT_NetworkIndividuals.CurrentItem = ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1));
         }
         /* 'DoUInsert' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S142 ();
         if (returnInSub) return;
         if ( AV5CheckRequiredFieldsResult && ! AV8HasValidationErrors )
         {
            AV9isAlreadyAdded = false;
            AV51GXV15 = 1;
            while ( AV51GXV15 <= AV23SDT_NetworkIndividuals.Count )
            {
               AV30SDT_NetworkIndividual = ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV51GXV15));
               if ( StringUtil.StrCmp(AV30SDT_NetworkIndividual.gxTpr_Networkindividualbsnnumber, AV12NetworkIndividualBsnNumber) == 0 )
               {
                  AV9isAlreadyAdded = true;
                  if (true) break;
               }
               AV51GXV15 = (int)(AV51GXV15+1);
            }
            if ( AV9isAlreadyAdded )
            {
               GX_msglist.addItem("This BSN Number has already been added");
            }
            else
            {
               AV30SDT_NetworkIndividual = new SdtSDT_NetworkIndividual(context);
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualid = Guid.NewGuid( );
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualbsnnumber = AV12NetworkIndividualBsnNumber;
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualgivenname = AV17NetworkIndividualGivenName;
               AV30SDT_NetworkIndividual.gxTpr_Networkindividuallastname = AV19NetworkIndividualLastName;
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualemail = AV15NetworkIndividualEmail;
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualphone = AV20NetworkIndividualPhone;
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualgender = AV16NetworkIndividualGender;
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualcountry = AV14NetworkIndividualCountry;
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualcity = AV13NetworkIndividualCity;
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualzipcode = AV21NetworkIndividualZipCode;
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualaddressline1 = AV10NetworkIndividualAddressLine1;
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualaddressline2 = AV11NetworkIndividualAddressLine2;
               GXt_char2 = "";
               new prc_concatenateaddress(context ).execute(  AV14NetworkIndividualCountry,  AV13NetworkIndividualCity,  AV21NetworkIndividualZipCode,  AV10NetworkIndividualAddressLine1,  AV11NetworkIndividualAddressLine2, out  GXt_char2) ;
               AV30SDT_NetworkIndividual.gxTpr_Networkindividualfulladdress = GXt_char2;
               AV23SDT_NetworkIndividuals.Add(AV30SDT_NetworkIndividual, 0);
               gx_BV74 = true;
               AV28BC_NetworkIndividual = new SdtTrn_NetworkIndividual(context);
               AV28BC_NetworkIndividual.gxTpr_Networkindividualid = AV30SDT_NetworkIndividual.gxTpr_Networkindividualid;
               AV28BC_NetworkIndividual.gxTpr_Networkindividualbsnnumber = AV12NetworkIndividualBsnNumber;
               AV28BC_NetworkIndividual.gxTpr_Networkindividualgivenname = AV17NetworkIndividualGivenName;
               AV28BC_NetworkIndividual.gxTpr_Networkindividuallastname = AV19NetworkIndividualLastName;
               AV28BC_NetworkIndividual.gxTpr_Networkindividualemail = AV15NetworkIndividualEmail;
               AV28BC_NetworkIndividual.gxTpr_Networkindividualphone = AV20NetworkIndividualPhone;
               AV28BC_NetworkIndividual.gxTpr_Networkindividualgender = AV16NetworkIndividualGender;
               AV28BC_NetworkIndividual.gxTpr_Networkindividualcountry = AV14NetworkIndividualCountry;
               AV28BC_NetworkIndividual.gxTpr_Networkindividualcountry = AV14NetworkIndividualCountry;
               AV28BC_NetworkIndividual.gxTpr_Networkindividualcity = AV13NetworkIndividualCity;
               AV28BC_NetworkIndividual.gxTpr_Networkindividualzipcode = AV21NetworkIndividualZipCode;
               AV28BC_NetworkIndividual.gxTpr_Networkindividualaddressline1 = AV10NetworkIndividualAddressLine1;
               AV28BC_NetworkIndividual.gxTpr_Networkindividualaddressline2 = AV11NetworkIndividualAddressLine2;
               if ( AV28BC_NetworkIndividual.Insert() )
               {
                  context.CommitDataStores("wp_createresidentandnetworkstep2",pr_default);
               }
               /* Execute user subroutine: 'CLEARFORMVALUES' */
               S152 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23SDT_NetworkIndividuals", AV23SDT_NetworkIndividuals);
         nGXsfl_74_bak_idx = nGXsfl_74_idx;
         gxgrGrids_refresh( subGrids_Rows, AV8HasValidationErrors, sPrefix) ;
         nGXsfl_74_idx = nGXsfl_74_bak_idx;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         cmbavNetworkindividualgender.CurrentValue = StringUtil.RTrim( AV16NetworkIndividualGender);
         AssignProp(sPrefix, false, cmbavNetworkindividualgender_Internalname, "Values", cmbavNetworkindividualgender.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV27WizardData.FromJSonString(AV25WebSession.Get(AV26WebSessionKey), null);
         AV18NetworkIndividualId = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualid;
         AssignAttri(sPrefix, false, "AV18NetworkIndividualId", AV18NetworkIndividualId.ToString());
         AV12NetworkIndividualBsnNumber = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualbsnnumber;
         AssignAttri(sPrefix, false, "AV12NetworkIndividualBsnNumber", AV12NetworkIndividualBsnNumber);
         AV17NetworkIndividualGivenName = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualgivenname;
         AssignAttri(sPrefix, false, "AV17NetworkIndividualGivenName", AV17NetworkIndividualGivenName);
         AV19NetworkIndividualLastName = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividuallastname;
         AssignAttri(sPrefix, false, "AV19NetworkIndividualLastName", AV19NetworkIndividualLastName);
         AV16NetworkIndividualGender = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualgender;
         AssignAttri(sPrefix, false, "AV16NetworkIndividualGender", AV16NetworkIndividualGender);
         AV15NetworkIndividualEmail = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualemail;
         AssignAttri(sPrefix, false, "AV15NetworkIndividualEmail", AV15NetworkIndividualEmail);
         AV20NetworkIndividualPhone = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualphone;
         AssignAttri(sPrefix, false, "AV20NetworkIndividualPhone", AV20NetworkIndividualPhone);
         AV14NetworkIndividualCountry = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualcountry;
         AssignAttri(sPrefix, false, "AV14NetworkIndividualCountry", AV14NetworkIndividualCountry);
         AV13NetworkIndividualCity = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualcity;
         AssignAttri(sPrefix, false, "AV13NetworkIndividualCity", AV13NetworkIndividualCity);
         AV21NetworkIndividualZipCode = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualzipcode;
         AssignAttri(sPrefix, false, "AV21NetworkIndividualZipCode", AV21NetworkIndividualZipCode);
         AV10NetworkIndividualAddressLine1 = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualaddressline1;
         AssignAttri(sPrefix, false, "AV10NetworkIndividualAddressLine1", AV10NetworkIndividualAddressLine1);
         AV11NetworkIndividualAddressLine2 = AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualaddressline2;
         AssignAttri(sPrefix, false, "AV11NetworkIndividualAddressLine2", AV11NetworkIndividualAddressLine2);
         AV23SDT_NetworkIndividuals = AV27WizardData.gxTpr_Step2.gxTpr_Sdt_networkindividuals;
         gx_BV74 = true;
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV27WizardData.FromJSonString(AV25WebSession.Get(AV26WebSessionKey), null);
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualid = AV18NetworkIndividualId;
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualbsnnumber = AV12NetworkIndividualBsnNumber;
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualgivenname = AV17NetworkIndividualGivenName;
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividuallastname = AV19NetworkIndividualLastName;
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualgender = AV16NetworkIndividualGender;
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualemail = AV15NetworkIndividualEmail;
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualphone = AV20NetworkIndividualPhone;
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualcountry = AV14NetworkIndividualCountry;
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualcity = AV13NetworkIndividualCity;
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualzipcode = AV21NetworkIndividualZipCode;
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualaddressline1 = AV10NetworkIndividualAddressLine1;
         AV27WizardData.gxTpr_Step2.gxTpr_Networkindividualaddressline2 = AV11NetworkIndividualAddressLine2;
         AV27WizardData.gxTpr_Step2.gxTpr_Sdt_networkindividuals = AV23SDT_NetworkIndividuals;
         AV25WebSession.Set(AV26WebSessionKey, AV27WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV5CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17NetworkIndividualGivenName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Given Name", "", "", "", "", "", "", "", ""),  "error",  edtavNetworkindividualgivenname_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19NetworkIndividualLastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Last Name", "", "", "", "", "", "", "", ""),  "error",  edtavNetworkindividuallastname_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15NetworkIndividualEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavNetworkindividualemail_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBONETWORKINDIVIDUALCOUNTRY' Routine */
         returnInSub = false;
         AV53GXV17 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV52GXV16;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV52GXV16 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV53GXV17 <= AV52GXV16.Count )
         {
            AV36NetworkIndividualCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV52GXV16.Item(AV53GXV17));
            AV35Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV35Combo_DataItem.gxTpr_Id = AV36NetworkIndividualCountry_DPItem.gxTpr_Countryname;
            AV31ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV31ComboTitles.Add(AV36NetworkIndividualCountry_DPItem.gxTpr_Countryname, 0);
            AV31ComboTitles.Add(AV36NetworkIndividualCountry_DPItem.gxTpr_Countryflag, 0);
            AV35Combo_DataItem.gxTpr_Title = AV31ComboTitles.ToJSonString(false);
            AV32NetworkIndividualCountry_Data.Add(AV35Combo_DataItem, 0);
            AV53GXV17 = (int)(AV53GXV17+1);
         }
         AV32NetworkIndividualCountry_Data.Sort("Title");
         Combo_networkindividualcountry_Selectedvalue_set = AV14NetworkIndividualCountry;
         ucCombo_networkindividualcountry.SendProperty(context, sPrefix, false, Combo_networkindividualcountry_Internalname, "SelectedValue_set", Combo_networkindividualcountry_Selectedvalue_set);
      }

      protected void E166R2( )
      {
         AV37GXV1 = (int)(nGXsfl_74_idx+GRIDS_nFirstRecordOnPage);
         if ( ( AV37GXV1 > 0 ) && ( AV23SDT_NetworkIndividuals.Count >= AV37GXV1 ) )
         {
            AV23SDT_NetworkIndividuals.CurrentItem = ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1));
         }
         /* Udelete_Click Routine */
         returnInSub = false;
         AV29Trn_NetworkIndividual.Load(((SdtSDT_NetworkIndividual)(AV23SDT_NetworkIndividuals.CurrentItem)).gxTpr_Networkindividualid);
         AV29Trn_NetworkIndividual.Delete();
         if ( AV29Trn_NetworkIndividual.Success() )
         {
            context.CommitDataStores("wp_createresidentandnetworkstep2",pr_default);
            AV23SDT_NetworkIndividuals.RemoveItem(AV23SDT_NetworkIndividuals.IndexOf(((SdtSDT_NetworkIndividual)(AV23SDT_NetworkIndividuals.CurrentItem))));
            gx_BV74 = true;
         }
         else
         {
            GX_msglist.addItem(StringUtil.RTrim( context.localUtil.Format( ((GeneXus.Utils.SdtMessages_Message)AV29Trn_NetworkIndividual.GetMessages().Item(1)).gxTpr_Description, "")));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23SDT_NetworkIndividuals", AV23SDT_NetworkIndividuals);
         nGXsfl_74_bak_idx = nGXsfl_74_idx;
         gxgrGrids_refresh( subGrids_Rows, AV8HasValidationErrors, sPrefix) ;
         nGXsfl_74_idx = nGXsfl_74_bak_idx;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
      }

      protected void S152( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV14NetworkIndividualCountry = "";
         AssignAttri(sPrefix, false, "AV14NetworkIndividualCountry", AV14NetworkIndividualCountry);
         AV13NetworkIndividualCity = "";
         AssignAttri(sPrefix, false, "AV13NetworkIndividualCity", AV13NetworkIndividualCity);
         AV21NetworkIndividualZipCode = "";
         AssignAttri(sPrefix, false, "AV21NetworkIndividualZipCode", AV21NetworkIndividualZipCode);
         AV10NetworkIndividualAddressLine1 = "";
         AssignAttri(sPrefix, false, "AV10NetworkIndividualAddressLine1", AV10NetworkIndividualAddressLine1);
         AV11NetworkIndividualAddressLine2 = "";
         AssignAttri(sPrefix, false, "AV11NetworkIndividualAddressLine2", AV11NetworkIndividualAddressLine2);
         AV12NetworkIndividualBsnNumber = "";
         AssignAttri(sPrefix, false, "AV12NetworkIndividualBsnNumber", AV12NetworkIndividualBsnNumber);
         AV15NetworkIndividualEmail = "";
         AssignAttri(sPrefix, false, "AV15NetworkIndividualEmail", AV15NetworkIndividualEmail);
         AV16NetworkIndividualGender = "";
         AssignAttri(sPrefix, false, "AV16NetworkIndividualGender", AV16NetworkIndividualGender);
         AV17NetworkIndividualGivenName = "";
         AssignAttri(sPrefix, false, "AV17NetworkIndividualGivenName", AV17NetworkIndividualGivenName);
         AV19NetworkIndividualLastName = "";
         AssignAttri(sPrefix, false, "AV19NetworkIndividualLastName", AV19NetworkIndividualLastName);
         AV20NetworkIndividualPhone = "";
         AssignAttri(sPrefix, false, "AV20NetworkIndividualPhone", AV20NetworkIndividualPhone);
         AV18NetworkIndividualId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV18NetworkIndividualId", AV18NetworkIndividualId.ToString());
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV26WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV26WebSessionKey", AV26WebSessionKey);
         AV22PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV22PreviousStep", AV22PreviousStep);
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
         PA6R2( ) ;
         WS6R2( ) ;
         WE6R2( ) ;
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
         sCtrlAV26WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV22PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV7GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA6R2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createresidentandnetworkstep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6R2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV26WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV26WebSessionKey", AV26WebSessionKey);
            AV22PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV22PreviousStep", AV22PreviousStep);
            AV7GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         wcpOAV26WebSessionKey = cgiGet( sPrefix+"wcpOAV26WebSessionKey");
         wcpOAV22PreviousStep = cgiGet( sPrefix+"wcpOAV22PreviousStep");
         wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV26WebSessionKey, wcpOAV26WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV22PreviousStep, wcpOAV22PreviousStep) != 0 ) || ( AV7GoingBack != wcpOAV7GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV26WebSessionKey = AV26WebSessionKey;
         wcpOAV22PreviousStep = AV22PreviousStep;
         wcpOAV7GoingBack = AV7GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV26WebSessionKey = cgiGet( sPrefix+"AV26WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV26WebSessionKey) > 0 )
         {
            AV26WebSessionKey = cgiGet( sCtrlAV26WebSessionKey);
            AssignAttri(sPrefix, false, "AV26WebSessionKey", AV26WebSessionKey);
         }
         else
         {
            AV26WebSessionKey = cgiGet( sPrefix+"AV26WebSessionKey_PARM");
         }
         sCtrlAV22PreviousStep = cgiGet( sPrefix+"AV22PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV22PreviousStep) > 0 )
         {
            AV22PreviousStep = cgiGet( sCtrlAV22PreviousStep);
            AssignAttri(sPrefix, false, "AV22PreviousStep", AV22PreviousStep);
         }
         else
         {
            AV22PreviousStep = cgiGet( sPrefix+"AV22PreviousStep_PARM");
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
         PA6R2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6R2( ) ;
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
         WS6R2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV26WebSessionKey_PARM", AV26WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV26WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV26WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV26WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV22PreviousStep_PARM", AV22PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV22PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV22PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV22PreviousStep));
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
         WE6R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202492719472249", true, true);
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
         context.AddJavascriptSource("wp_createresidentandnetworkstep2.js", "?202492719472249", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavSdt_networkindividuals__networkindividualid_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALID_"+sGXsfl_74_idx;
         edtavSdt_networkindividuals__networkindividualbsnnumber_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALBSNNUMBER_"+sGXsfl_74_idx;
         edtavSdt_networkindividuals__networkindividualgivenname_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALGIVENNAME_"+sGXsfl_74_idx;
         edtavSdt_networkindividuals__networkindividuallastname_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALLASTNAME_"+sGXsfl_74_idx;
         edtavSdt_networkindividuals__networkindividualemail_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALEMAIL_"+sGXsfl_74_idx;
         edtavSdt_networkindividuals__networkindividualphone_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALPHONE_"+sGXsfl_74_idx;
         cmbavSdt_networkindividuals__networkindividualgender_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALGENDER_"+sGXsfl_74_idx;
         edtavSdt_networkindividuals__networkindividualcountry_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALCOUNTRY_"+sGXsfl_74_idx;
         edtavSdt_networkindividuals__networkindividualcity_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALCITY_"+sGXsfl_74_idx;
         edtavSdt_networkindividuals__networkindividualzipcode_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALZIPCODE_"+sGXsfl_74_idx;
         edtavSdt_networkindividuals__networkindividualaddressline1_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALADDRESSLINE1_"+sGXsfl_74_idx;
         edtavSdt_networkindividuals__networkindividualaddressline2_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALADDRESSLINE2_"+sGXsfl_74_idx;
         edtavSdt_networkindividuals__networkindividualfulladdress_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALFULLADDRESS_"+sGXsfl_74_idx;
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavSdt_networkindividuals__networkindividualid_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALID_"+sGXsfl_74_fel_idx;
         edtavSdt_networkindividuals__networkindividualbsnnumber_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALBSNNUMBER_"+sGXsfl_74_fel_idx;
         edtavSdt_networkindividuals__networkindividualgivenname_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALGIVENNAME_"+sGXsfl_74_fel_idx;
         edtavSdt_networkindividuals__networkindividuallastname_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALLASTNAME_"+sGXsfl_74_fel_idx;
         edtavSdt_networkindividuals__networkindividualemail_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALEMAIL_"+sGXsfl_74_fel_idx;
         edtavSdt_networkindividuals__networkindividualphone_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALPHONE_"+sGXsfl_74_fel_idx;
         cmbavSdt_networkindividuals__networkindividualgender_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALGENDER_"+sGXsfl_74_fel_idx;
         edtavSdt_networkindividuals__networkindividualcountry_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALCOUNTRY_"+sGXsfl_74_fel_idx;
         edtavSdt_networkindividuals__networkindividualcity_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALCITY_"+sGXsfl_74_fel_idx;
         edtavSdt_networkindividuals__networkindividualzipcode_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALZIPCODE_"+sGXsfl_74_fel_idx;
         edtavSdt_networkindividuals__networkindividualaddressline1_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALADDRESSLINE1_"+sGXsfl_74_fel_idx;
         edtavSdt_networkindividuals__networkindividualaddressline2_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALADDRESSLINE2_"+sGXsfl_74_fel_idx;
         edtavSdt_networkindividuals__networkindividualfulladdress_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALFULLADDRESS_"+sGXsfl_74_fel_idx;
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WB6R0( ) ;
         if ( ( subGrids_Rows * 1 == 0 ) || ( nGXsfl_74_idx <= subGrids_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividualid_Internalname,((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualid.ToString(),((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividualid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkindividuals__networkindividualid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)74,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',74)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividualbsnnumber_Internalname,((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualbsnnumber,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividualbsnnumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_networkindividuals__networkindividualbsnnumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',74)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividualgivenname_Internalname,((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualgivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividualgivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_networkindividuals__networkindividualgivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',74)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividuallastname_Internalname,((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividuallastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividuallastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_networkindividuals__networkindividuallastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',74)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividualemail_Internalname,((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividualemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_networkindividuals__networkindividualemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',74)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividualphone_Internalname,StringUtil.RTrim( ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividualphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_networkindividuals__networkindividualphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',74)\"";
            if ( ( cmbavSdt_networkindividuals__networkindividualgender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALGENDER_" + sGXsfl_74_idx;
               cmbavSdt_networkindividuals__networkindividualgender.Name = GXCCtl;
               cmbavSdt_networkindividuals__networkindividualgender.WebTags = "";
               cmbavSdt_networkindividuals__networkindividualgender.addItem("Male", "Male", 0);
               cmbavSdt_networkindividuals__networkindividualgender.addItem("Female", "Female", 0);
               cmbavSdt_networkindividuals__networkindividualgender.addItem("Other", "Other", 0);
               if ( cmbavSdt_networkindividuals__networkindividualgender.ItemCount > 0 )
               {
                  if ( ( AV37GXV1 > 0 ) && ( AV23SDT_NetworkIndividuals.Count >= AV37GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualgender)) )
                  {
                     ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualgender = cmbavSdt_networkindividuals__networkindividualgender.getValidValue(((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualgender);
                  }
               }
            }
            /* ComboBox */
            GridsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_networkindividuals__networkindividualgender,(string)cmbavSdt_networkindividuals__networkindividualgender_Internalname,StringUtil.RTrim( ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualgender),(short)1,(string)cmbavSdt_networkindividuals__networkindividualgender_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavSdt_networkindividuals__networkindividualgender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_networkindividuals__networkindividualgender.CurrentValue = StringUtil.RTrim( ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualgender);
            AssignProp(sPrefix, false, cmbavSdt_networkindividuals__networkindividualgender_Internalname, "Values", (string)(cmbavSdt_networkindividuals__networkindividualgender.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividualcountry_Internalname,((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualcountry,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividualcountry_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkindividuals__networkindividualcountry_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividualcity_Internalname,((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualcity,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividualcity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkindividuals__networkindividualcity_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividualzipcode_Internalname,((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualzipcode,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividualzipcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkindividuals__networkindividualzipcode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividualaddressline1_Internalname,((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualaddressline1,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividualaddressline1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkindividuals__networkindividualaddressline1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividualaddressline2_Internalname,((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualaddressline2,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividualaddressline2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_networkindividuals__networkindividualaddressline2_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',74)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_networkindividuals__networkindividualfulladdress_Internalname,((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualfulladdress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_networkindividuals__networkindividualfulladdress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_networkindividuals__networkindividualfulladdress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'" + sGXsfl_74_idx + "',74)\"";
            ROClassString = "Attribute";
            GridsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUdelete_Internalname,StringUtil.RTrim( AV24UDelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUDELETE.CLICK."+sGXsfl_74_idx+"'",(string)"",(string)"",(string)"Delete item",(string)"",(string)edtavUdelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUdelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes6R2( ) ;
            GridsContainer.AddRow(GridsRow);
            nGXsfl_74_idx = ((subGrids_Islastpage==1)&&(nGXsfl_74_idx+1>subGrids_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavNetworkindividualgender.Name = "vNETWORKINDIVIDUALGENDER";
         cmbavNetworkindividualgender.WebTags = "";
         cmbavNetworkindividualgender.addItem("Male", "Male", 0);
         cmbavNetworkindividualgender.addItem("Female", "Female", 0);
         cmbavNetworkindividualgender.addItem("Other", "Other", 0);
         if ( cmbavNetworkindividualgender.ItemCount > 0 )
         {
         }
         GXCCtl = "SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALGENDER_" + sGXsfl_74_idx;
         cmbavSdt_networkindividuals__networkindividualgender.Name = GXCCtl;
         cmbavSdt_networkindividuals__networkindividualgender.WebTags = "";
         cmbavSdt_networkindividuals__networkindividualgender.addItem("Male", "Male", 0);
         cmbavSdt_networkindividuals__networkindividualgender.addItem("Female", "Female", 0);
         cmbavSdt_networkindividuals__networkindividualgender.addItem("Other", "Other", 0);
         if ( cmbavSdt_networkindividuals__networkindividualgender.ItemCount > 0 )
         {
            if ( ( AV37GXV1 > 0 ) && ( AV23SDT_NetworkIndividuals.Count >= AV37GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_NetworkIndividual)AV23SDT_NetworkIndividuals.Item(AV37GXV1)).gxTpr_Networkindividualgender)) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( GridsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridsContainer"+"DivS\" data-gxgridid=\"74\">") ;
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
            context.SendWebValue( "Network Individual Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "BSN Number") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Given Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Last Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Gender") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Network Individual Country") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Network Individual City") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Network Individual Zip Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Network Individual Address Line1") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Network Individual Address Line2") ;
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
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividualid_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividualbsnnumber_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividualgivenname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividuallastname_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividualemail_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividualphone_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_networkindividuals__networkindividualgender.Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividualcountry_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividualcity_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividualzipcode_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividualaddressline1_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividualaddressline2_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_networkindividuals__networkindividualfulladdress_Enabled), 5, 0, ".", "")));
            GridsContainer.AddColumnProperties(GridsColumn);
            GridsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV24UDelete)));
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
         edtavNetworkindividualbsnnumber_Internalname = sPrefix+"vNETWORKINDIVIDUALBSNNUMBER";
         edtavNetworkindividualgivenname_Internalname = sPrefix+"vNETWORKINDIVIDUALGIVENNAME";
         edtavNetworkindividuallastname_Internalname = sPrefix+"vNETWORKINDIVIDUALLASTNAME";
         cmbavNetworkindividualgender_Internalname = sPrefix+"vNETWORKINDIVIDUALGENDER";
         edtavNetworkindividualemail_Internalname = sPrefix+"vNETWORKINDIVIDUALEMAIL";
         edtavNetworkindividualphone_Internalname = sPrefix+"vNETWORKINDIVIDUALPHONE";
         lblTextblockcombo_networkindividualcountry_Internalname = sPrefix+"TEXTBLOCKCOMBO_NETWORKINDIVIDUALCOUNTRY";
         Combo_networkindividualcountry_Internalname = sPrefix+"COMBO_NETWORKINDIVIDUALCOUNTRY";
         divTablesplittednetworkindividualcountry_Internalname = sPrefix+"TABLESPLITTEDNETWORKINDIVIDUALCOUNTRY";
         edtavNetworkindividualcity_Internalname = sPrefix+"vNETWORKINDIVIDUALCITY";
         edtavNetworkindividualzipcode_Internalname = sPrefix+"vNETWORKINDIVIDUALZIPCODE";
         edtavNetworkindividualaddressline1_Internalname = sPrefix+"vNETWORKINDIVIDUALADDRESSLINE1";
         edtavNetworkindividualaddressline2_Internalname = sPrefix+"vNETWORKINDIVIDUALADDRESSLINE2";
         divIniformtable_Internalname = sPrefix+"INIFORMTABLE";
         bttBtnuinsert_Internalname = sPrefix+"BTNUINSERT";
         edtavSdt_networkindividuals__networkindividualid_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALID";
         edtavSdt_networkindividuals__networkindividualbsnnumber_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALBSNNUMBER";
         edtavSdt_networkindividuals__networkindividualgivenname_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALGIVENNAME";
         edtavSdt_networkindividuals__networkindividuallastname_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALLASTNAME";
         edtavSdt_networkindividuals__networkindividualemail_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALEMAIL";
         edtavSdt_networkindividuals__networkindividualphone_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALPHONE";
         cmbavSdt_networkindividuals__networkindividualgender_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALGENDER";
         edtavSdt_networkindividuals__networkindividualcountry_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALCOUNTRY";
         edtavSdt_networkindividuals__networkindividualcity_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALCITY";
         edtavSdt_networkindividuals__networkindividualzipcode_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALZIPCODE";
         edtavSdt_networkindividuals__networkindividualaddressline1_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALADDRESSLINE1";
         edtavSdt_networkindividuals__networkindividualaddressline2_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALADDRESSLINE2";
         edtavSdt_networkindividuals__networkindividualfulladdress_Internalname = sPrefix+"SDT_NETWORKINDIVIDUALS__NETWORKINDIVIDUALFULLADDRESS";
         edtavUdelete_Internalname = sPrefix+"vUDELETE";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavNetworkindividualcountry_Internalname = sPrefix+"vNETWORKINDIVIDUALCOUNTRY";
         edtavNetworkindividualid_Internalname = sPrefix+"vNETWORKINDIVIDUALID";
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
         edtavSdt_networkindividuals__networkindividualfulladdress_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividualfulladdress_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualaddressline2_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividualaddressline2_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualaddressline1_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividualaddressline1_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualzipcode_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividualzipcode_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualcity_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividualcity_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualcountry_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividualcountry_Enabled = 0;
         cmbavSdt_networkindividuals__networkindividualgender_Jsonclick = "";
         cmbavSdt_networkindividuals__networkindividualgender.Enabled = 0;
         edtavSdt_networkindividuals__networkindividualphone_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividualphone_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualemail_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividualemail_Enabled = 0;
         edtavSdt_networkindividuals__networkindividuallastname_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividuallastname_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualgivenname_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividualgivenname_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualbsnnumber_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividualbsnnumber_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualid_Jsonclick = "";
         edtavSdt_networkindividuals__networkindividualid_Enabled = 0;
         subGrids_Class = "WorkWith";
         subGrids_Backcolorstyle = 0;
         Combo_networkindividualcountry_Htmltemplate = "";
         edtavNetworkindividualid_Jsonclick = "";
         edtavNetworkindividualid_Visible = 1;
         edtavNetworkindividualcountry_Jsonclick = "";
         edtavNetworkindividualcountry_Visible = 1;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = "Next";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = "Previous";
         Btnwizardprevious_Tooltiptext = "";
         edtavNetworkindividualaddressline2_Jsonclick = "";
         edtavNetworkindividualaddressline2_Enabled = 1;
         edtavNetworkindividualaddressline1_Jsonclick = "";
         edtavNetworkindividualaddressline1_Enabled = 1;
         edtavNetworkindividualzipcode_Jsonclick = "";
         edtavNetworkindividualzipcode_Enabled = 1;
         edtavNetworkindividualcity_Jsonclick = "";
         edtavNetworkindividualcity_Enabled = 1;
         Combo_networkindividualcountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_networkindividualcountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_networkindividualcountry_Caption = "";
         edtavNetworkindividualphone_Jsonclick = "";
         edtavNetworkindividualphone_Enabled = 1;
         edtavNetworkindividualemail_Jsonclick = "";
         edtavNetworkindividualemail_Enabled = 1;
         cmbavNetworkindividualgender_Jsonclick = "";
         cmbavNetworkindividualgender.Enabled = 1;
         edtavNetworkindividuallastname_Jsonclick = "";
         edtavNetworkindividuallastname_Enabled = 1;
         edtavNetworkindividualgivenname_Jsonclick = "";
         edtavNetworkindividualgivenname_Enabled = 1;
         edtavNetworkindividualbsnnumber_Jsonclick = "";
         edtavNetworkindividualbsnnumber_Enabled = 1;
         edtavSdt_networkindividuals__networkindividualfulladdress_Enabled = -1;
         edtavSdt_networkindividuals__networkindividualaddressline2_Enabled = -1;
         edtavSdt_networkindividuals__networkindividualaddressline1_Enabled = -1;
         edtavSdt_networkindividuals__networkindividualzipcode_Enabled = -1;
         edtavSdt_networkindividuals__networkindividualcity_Enabled = -1;
         edtavSdt_networkindividuals__networkindividualcountry_Enabled = -1;
         cmbavSdt_networkindividuals__networkindividualgender.Enabled = -1;
         edtavSdt_networkindividuals__networkindividualphone_Enabled = -1;
         edtavSdt_networkindividuals__networkindividualemail_Enabled = -1;
         edtavSdt_networkindividuals__networkindividuallastname_Enabled = -1;
         edtavSdt_networkindividuals__networkindividualgivenname_Enabled = -1;
         edtavSdt_networkindividuals__networkindividualbsnnumber_Enabled = -1;
         edtavSdt_networkindividuals__networkindividualid_Enabled = -1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV23SDT_NetworkIndividuals","fld":"vSDT_NETWORKINDIVIDUALS","grid":74},{"av":"nGXsfl_74_idx","ctrl":"GRID","prop":"GridCurrRow","grid":74},{"av":"nRC_GXsfl_74","ctrl":"GRIDS","prop":"GridRC","grid":74},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV8HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]}""");
         setEventMetadata("GRIDS.LOAD","""{"handler":"E156R2","iparms":[]""");
         setEventMetadata("GRIDS.LOAD",""","oparms":[{"av":"AV24UDelete","fld":"vUDELETE"}]}""");
         setEventMetadata("ENTER","""{"handler":"E116R2","iparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV8HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV26WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV18NetworkIndividualId","fld":"vNETWORKINDIVIDUALID"},{"av":"AV12NetworkIndividualBsnNumber","fld":"vNETWORKINDIVIDUALBSNNUMBER"},{"av":"AV17NetworkIndividualGivenName","fld":"vNETWORKINDIVIDUALGIVENNAME"},{"av":"AV19NetworkIndividualLastName","fld":"vNETWORKINDIVIDUALLASTNAME"},{"av":"cmbavNetworkindividualgender"},{"av":"AV16NetworkIndividualGender","fld":"vNETWORKINDIVIDUALGENDER"},{"av":"AV15NetworkIndividualEmail","fld":"vNETWORKINDIVIDUALEMAIL"},{"av":"AV20NetworkIndividualPhone","fld":"vNETWORKINDIVIDUALPHONE"},{"av":"AV14NetworkIndividualCountry","fld":"vNETWORKINDIVIDUALCOUNTRY"},{"av":"AV13NetworkIndividualCity","fld":"vNETWORKINDIVIDUALCITY"},{"av":"AV21NetworkIndividualZipCode","fld":"vNETWORKINDIVIDUALZIPCODE"},{"av":"AV10NetworkIndividualAddressLine1","fld":"vNETWORKINDIVIDUALADDRESSLINE1"},{"av":"AV11NetworkIndividualAddressLine2","fld":"vNETWORKINDIVIDUALADDRESSLINE2"},{"av":"AV23SDT_NetworkIndividuals","fld":"vSDT_NETWORKINDIVIDUALS","grid":74},{"av":"nGXsfl_74_idx","ctrl":"GRID","prop":"GridCurrRow","grid":74},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_74","ctrl":"GRIDS","prop":"GridRC","grid":74}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E126R2","iparms":[{"av":"AV26WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV18NetworkIndividualId","fld":"vNETWORKINDIVIDUALID"},{"av":"AV12NetworkIndividualBsnNumber","fld":"vNETWORKINDIVIDUALBSNNUMBER"},{"av":"AV17NetworkIndividualGivenName","fld":"vNETWORKINDIVIDUALGIVENNAME"},{"av":"AV19NetworkIndividualLastName","fld":"vNETWORKINDIVIDUALLASTNAME"},{"av":"cmbavNetworkindividualgender"},{"av":"AV16NetworkIndividualGender","fld":"vNETWORKINDIVIDUALGENDER"},{"av":"AV15NetworkIndividualEmail","fld":"vNETWORKINDIVIDUALEMAIL"},{"av":"AV20NetworkIndividualPhone","fld":"vNETWORKINDIVIDUALPHONE"},{"av":"AV14NetworkIndividualCountry","fld":"vNETWORKINDIVIDUALCOUNTRY"},{"av":"AV13NetworkIndividualCity","fld":"vNETWORKINDIVIDUALCITY"},{"av":"AV21NetworkIndividualZipCode","fld":"vNETWORKINDIVIDUALZIPCODE"},{"av":"AV10NetworkIndividualAddressLine1","fld":"vNETWORKINDIVIDUALADDRESSLINE1"},{"av":"AV11NetworkIndividualAddressLine2","fld":"vNETWORKINDIVIDUALADDRESSLINE2"},{"av":"AV23SDT_NetworkIndividuals","fld":"vSDT_NETWORKINDIVIDUALS","grid":74},{"av":"nGXsfl_74_idx","ctrl":"GRID","prop":"GridCurrRow","grid":74},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_74","ctrl":"GRIDS","prop":"GridRC","grid":74}]}""");
         setEventMetadata("'DOUINSERT'","""{"handler":"E136R2","iparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV8HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV23SDT_NetworkIndividuals","fld":"vSDT_NETWORKINDIVIDUALS","grid":74},{"av":"nGXsfl_74_idx","ctrl":"GRID","prop":"GridCurrRow","grid":74},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_74","ctrl":"GRIDS","prop":"GridRC","grid":74},{"av":"AV12NetworkIndividualBsnNumber","fld":"vNETWORKINDIVIDUALBSNNUMBER"},{"av":"AV17NetworkIndividualGivenName","fld":"vNETWORKINDIVIDUALGIVENNAME"},{"av":"AV19NetworkIndividualLastName","fld":"vNETWORKINDIVIDUALLASTNAME"},{"av":"AV15NetworkIndividualEmail","fld":"vNETWORKINDIVIDUALEMAIL"},{"av":"AV20NetworkIndividualPhone","fld":"vNETWORKINDIVIDUALPHONE"},{"av":"cmbavNetworkindividualgender"},{"av":"AV16NetworkIndividualGender","fld":"vNETWORKINDIVIDUALGENDER"},{"av":"AV14NetworkIndividualCountry","fld":"vNETWORKINDIVIDUALCOUNTRY"},{"av":"AV13NetworkIndividualCity","fld":"vNETWORKINDIVIDUALCITY"},{"av":"AV21NetworkIndividualZipCode","fld":"vNETWORKINDIVIDUALZIPCODE"},{"av":"AV10NetworkIndividualAddressLine1","fld":"vNETWORKINDIVIDUALADDRESSLINE1"},{"av":"AV11NetworkIndividualAddressLine2","fld":"vNETWORKINDIVIDUALADDRESSLINE2"},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("'DOUINSERT'",""","oparms":[{"av":"AV23SDT_NetworkIndividuals","fld":"vSDT_NETWORKINDIVIDUALS","grid":74},{"av":"nGXsfl_74_idx","ctrl":"GRID","prop":"GridCurrRow","grid":74},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_74","ctrl":"GRIDS","prop":"GridRC","grid":74},{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV14NetworkIndividualCountry","fld":"vNETWORKINDIVIDUALCOUNTRY"},{"av":"AV13NetworkIndividualCity","fld":"vNETWORKINDIVIDUALCITY"},{"av":"AV21NetworkIndividualZipCode","fld":"vNETWORKINDIVIDUALZIPCODE"},{"av":"AV10NetworkIndividualAddressLine1","fld":"vNETWORKINDIVIDUALADDRESSLINE1"},{"av":"AV11NetworkIndividualAddressLine2","fld":"vNETWORKINDIVIDUALADDRESSLINE2"},{"av":"AV12NetworkIndividualBsnNumber","fld":"vNETWORKINDIVIDUALBSNNUMBER"},{"av":"AV15NetworkIndividualEmail","fld":"vNETWORKINDIVIDUALEMAIL"},{"av":"cmbavNetworkindividualgender"},{"av":"AV16NetworkIndividualGender","fld":"vNETWORKINDIVIDUALGENDER"},{"av":"AV17NetworkIndividualGivenName","fld":"vNETWORKINDIVIDUALGIVENNAME"},{"av":"AV19NetworkIndividualLastName","fld":"vNETWORKINDIVIDUALLASTNAME"},{"av":"AV20NetworkIndividualPhone","fld":"vNETWORKINDIVIDUALPHONE"},{"av":"AV18NetworkIndividualId","fld":"vNETWORKINDIVIDUALID"}]}""");
         setEventMetadata("VUDELETE.CLICK","""{"handler":"E166R2","iparms":[{"av":"AV23SDT_NetworkIndividuals","fld":"vSDT_NETWORKINDIVIDUALS","grid":74},{"av":"nGXsfl_74_idx","ctrl":"GRID","prop":"GridCurrRow","grid":74},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_74","ctrl":"GRIDS","prop":"GridRC","grid":74},{"av":"GRIDS_nEOF"},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV8HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VUDELETE.CLICK",""","oparms":[{"av":"AV23SDT_NetworkIndividuals","fld":"vSDT_NETWORKINDIVIDUALS","grid":74},{"av":"nGXsfl_74_idx","ctrl":"GRID","prop":"GridCurrRow","grid":74},{"av":"GRIDS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_74","ctrl":"GRIDS","prop":"GridRC","grid":74}]}""");
         setEventMetadata("GRIDS_FIRSTPAGE","""{"handler":"subgrids_firstpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV23SDT_NetworkIndividuals","fld":"vSDT_NETWORKINDIVIDUALS","grid":74},{"av":"nGXsfl_74_idx","ctrl":"GRID","prop":"GridCurrRow","grid":74},{"av":"nRC_GXsfl_74","ctrl":"GRIDS","prop":"GridRC","grid":74},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV8HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDS_PREVPAGE","""{"handler":"subgrids_previouspage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV23SDT_NetworkIndividuals","fld":"vSDT_NETWORKINDIVIDUALS","grid":74},{"av":"nGXsfl_74_idx","ctrl":"GRID","prop":"GridCurrRow","grid":74},{"av":"nRC_GXsfl_74","ctrl":"GRIDS","prop":"GridRC","grid":74},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV8HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDS_NEXTPAGE","""{"handler":"subgrids_nextpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV23SDT_NetworkIndividuals","fld":"vSDT_NETWORKINDIVIDUALS","grid":74},{"av":"nGXsfl_74_idx","ctrl":"GRID","prop":"GridCurrRow","grid":74},{"av":"nRC_GXsfl_74","ctrl":"GRIDS","prop":"GridRC","grid":74},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV8HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDS_LASTPAGE","""{"handler":"subgrids_lastpage","iparms":[{"av":"GRIDS_nFirstRecordOnPage"},{"av":"GRIDS_nEOF"},{"av":"AV23SDT_NetworkIndividuals","fld":"vSDT_NETWORKINDIVIDUALS","grid":74},{"av":"nGXsfl_74_idx","ctrl":"GRID","prop":"GridCurrRow","grid":74},{"av":"nRC_GXsfl_74","ctrl":"GRIDS","prop":"GridRC","grid":74},{"av":"subGrids_Rows","ctrl":"GRIDS","prop":"Rows"},{"av":"AV8HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("VALIDV_NETWORKINDIVIDUALGENDER","""{"handler":"Validv_Networkindividualgender","iparms":[]}""");
         setEventMetadata("VALIDV_NETWORKINDIVIDUALEMAIL","""{"handler":"Validv_Networkindividualemail","iparms":[]}""");
         setEventMetadata("VALIDV_NETWORKINDIVIDUALID","""{"handler":"Validv_Networkindividualid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_GXV8","""{"handler":"Validv_Gxv8","iparms":[]}""");
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
         wcpOAV26WebSessionKey = "";
         wcpOAV22PreviousStep = "";
         Combo_networkindividualcountry_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV23SDT_NetworkIndividuals = new GXBaseCollection<SdtSDT_NetworkIndividual>( context, "SDT_NetworkIndividual", "");
         AV33DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV32NetworkIndividualCountry_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV12NetworkIndividualBsnNumber = "";
         AV17NetworkIndividualGivenName = "";
         AV19NetworkIndividualLastName = "";
         AV16NetworkIndividualGender = "";
         AV15NetworkIndividualEmail = "";
         AV20NetworkIndividualPhone = "";
         lblTextblockcombo_networkindividualcountry_Jsonclick = "";
         ucCombo_networkindividualcountry = new GXUserControl();
         AV13NetworkIndividualCity = "";
         AV21NetworkIndividualZipCode = "";
         AV10NetworkIndividualAddressLine1 = "";
         AV11NetworkIndividualAddressLine2 = "";
         bttBtnuinsert_Jsonclick = "";
         GridsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV14NetworkIndividualCountry = "";
         AV18NetworkIndividualId = Guid.Empty;
         ucGrids_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV24UDelete = "";
         GXDecQS = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Grids_empowerer_Gridinternalname = "";
         Combo_networkindividualcountry_Selectedtext_set = "";
         Combo_networkindividualcountry_Selectedvalue_set = "";
         GridsRow = new GXWebRow();
         AV30SDT_NetworkIndividual = new SdtSDT_NetworkIndividual(context);
         GXt_char2 = "";
         AV28BC_NetworkIndividual = new SdtTrn_NetworkIndividual(context);
         AV27WizardData = new SdtWP_CreateResidentAndNetworkData(context);
         AV25WebSession = context.GetSession();
         AV52GXV16 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV36NetworkIndividualCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV35Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV31ComboTitles = new GxSimpleCollection<string>();
         AV29Trn_NetworkIndividual = new SdtTrn_NetworkIndividual(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV26WebSessionKey = "";
         sCtrlAV22PreviousStep = "";
         sCtrlAV7GoingBack = "";
         subGrids_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridsColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_createresidentandnetworkstep2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createresidentandnetworkstep2__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavSdt_networkindividuals__networkindividualid_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualbsnnumber_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualgivenname_Enabled = 0;
         edtavSdt_networkindividuals__networkindividuallastname_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualemail_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualphone_Enabled = 0;
         cmbavSdt_networkindividuals__networkindividualgender.Enabled = 0;
         edtavSdt_networkindividuals__networkindividualcountry_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualcity_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualzipcode_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualaddressline1_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualaddressline2_Enabled = 0;
         edtavSdt_networkindividuals__networkindividualfulladdress_Enabled = 0;
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
      private int nRC_GXsfl_74 ;
      private int subGrids_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavSdt_networkindividuals__networkindividualid_Enabled ;
      private int edtavSdt_networkindividuals__networkindividualbsnnumber_Enabled ;
      private int edtavSdt_networkindividuals__networkindividualgivenname_Enabled ;
      private int edtavSdt_networkindividuals__networkindividuallastname_Enabled ;
      private int edtavSdt_networkindividuals__networkindividualemail_Enabled ;
      private int edtavSdt_networkindividuals__networkindividualphone_Enabled ;
      private int edtavSdt_networkindividuals__networkindividualcountry_Enabled ;
      private int edtavSdt_networkindividuals__networkindividualcity_Enabled ;
      private int edtavSdt_networkindividuals__networkindividualzipcode_Enabled ;
      private int edtavSdt_networkindividuals__networkindividualaddressline1_Enabled ;
      private int edtavSdt_networkindividuals__networkindividualaddressline2_Enabled ;
      private int edtavSdt_networkindividuals__networkindividualfulladdress_Enabled ;
      private int edtavUdelete_Enabled ;
      private int edtavNetworkindividualbsnnumber_Enabled ;
      private int edtavNetworkindividualgivenname_Enabled ;
      private int edtavNetworkindividuallastname_Enabled ;
      private int edtavNetworkindividualemail_Enabled ;
      private int edtavNetworkindividualphone_Enabled ;
      private int edtavNetworkindividualcity_Enabled ;
      private int edtavNetworkindividualzipcode_Enabled ;
      private int edtavNetworkindividualaddressline1_Enabled ;
      private int edtavNetworkindividualaddressline2_Enabled ;
      private int AV37GXV1 ;
      private int edtavNetworkindividualcountry_Visible ;
      private int edtavNetworkindividualid_Visible ;
      private int subGrids_Islastpage ;
      private int GRIDS_nGridOutOfScope ;
      private int nGXsfl_74_fel_idx=1 ;
      private int AV51GXV15 ;
      private int nGXsfl_74_bak_idx=1 ;
      private int AV53GXV17 ;
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
      private string Combo_networkindividualcountry_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_74_idx="0001" ;
      private string edtavSdt_networkindividuals__networkindividualid_Internalname ;
      private string edtavSdt_networkindividuals__networkindividualbsnnumber_Internalname ;
      private string edtavSdt_networkindividuals__networkindividualgivenname_Internalname ;
      private string edtavSdt_networkindividuals__networkindividuallastname_Internalname ;
      private string edtavSdt_networkindividuals__networkindividualemail_Internalname ;
      private string edtavSdt_networkindividuals__networkindividualphone_Internalname ;
      private string cmbavSdt_networkindividuals__networkindividualgender_Internalname ;
      private string edtavSdt_networkindividuals__networkindividualcountry_Internalname ;
      private string edtavSdt_networkindividuals__networkindividualcity_Internalname ;
      private string edtavSdt_networkindividuals__networkindividualzipcode_Internalname ;
      private string edtavSdt_networkindividuals__networkindividualaddressline1_Internalname ;
      private string edtavSdt_networkindividuals__networkindividualaddressline2_Internalname ;
      private string edtavSdt_networkindividuals__networkindividualfulladdress_Internalname ;
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
      private string divIniformtable_Internalname ;
      private string edtavNetworkindividualbsnnumber_Internalname ;
      private string TempTags ;
      private string edtavNetworkindividualbsnnumber_Jsonclick ;
      private string edtavNetworkindividualgivenname_Internalname ;
      private string edtavNetworkindividualgivenname_Jsonclick ;
      private string edtavNetworkindividuallastname_Internalname ;
      private string edtavNetworkindividuallastname_Jsonclick ;
      private string cmbavNetworkindividualgender_Internalname ;
      private string cmbavNetworkindividualgender_Jsonclick ;
      private string edtavNetworkindividualemail_Internalname ;
      private string edtavNetworkindividualemail_Jsonclick ;
      private string edtavNetworkindividualphone_Internalname ;
      private string AV20NetworkIndividualPhone ;
      private string edtavNetworkindividualphone_Jsonclick ;
      private string divTablesplittednetworkindividualcountry_Internalname ;
      private string lblTextblockcombo_networkindividualcountry_Internalname ;
      private string lblTextblockcombo_networkindividualcountry_Jsonclick ;
      private string Combo_networkindividualcountry_Caption ;
      private string Combo_networkindividualcountry_Cls ;
      private string Combo_networkindividualcountry_Internalname ;
      private string edtavNetworkindividualcity_Internalname ;
      private string edtavNetworkindividualcity_Jsonclick ;
      private string edtavNetworkindividualzipcode_Internalname ;
      private string edtavNetworkindividualzipcode_Jsonclick ;
      private string edtavNetworkindividualaddressline1_Internalname ;
      private string edtavNetworkindividualaddressline1_Jsonclick ;
      private string edtavNetworkindividualaddressline2_Internalname ;
      private string edtavNetworkindividualaddressline2_Jsonclick ;
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
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavNetworkindividualcountry_Internalname ;
      private string edtavNetworkindividualcountry_Jsonclick ;
      private string edtavNetworkindividualid_Internalname ;
      private string edtavNetworkindividualid_Jsonclick ;
      private string Grids_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV24UDelete ;
      private string GXDecQS ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string Combo_networkindividualcountry_Htmltemplate ;
      private string Grids_empowerer_Gridinternalname ;
      private string Combo_networkindividualcountry_Selectedtext_set ;
      private string Combo_networkindividualcountry_Selectedvalue_set ;
      private string GXt_char2 ;
      private string sCtrlAV26WebSessionKey ;
      private string sCtrlAV22PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private string subGrids_Class ;
      private string subGrids_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_networkindividuals__networkindividualid_Jsonclick ;
      private string edtavSdt_networkindividuals__networkindividualbsnnumber_Jsonclick ;
      private string edtavSdt_networkindividuals__networkindividualgivenname_Jsonclick ;
      private string edtavSdt_networkindividuals__networkindividuallastname_Jsonclick ;
      private string edtavSdt_networkindividuals__networkindividualemail_Jsonclick ;
      private string edtavSdt_networkindividuals__networkindividualphone_Jsonclick ;
      private string GXCCtl ;
      private string cmbavSdt_networkindividuals__networkindividualgender_Jsonclick ;
      private string edtavSdt_networkindividuals__networkindividualcountry_Jsonclick ;
      private string edtavSdt_networkindividuals__networkindividualcity_Jsonclick ;
      private string edtavSdt_networkindividuals__networkindividualzipcode_Jsonclick ;
      private string edtavSdt_networkindividuals__networkindividualaddressline1_Jsonclick ;
      private string edtavSdt_networkindividuals__networkindividualaddressline2_Jsonclick ;
      private string edtavSdt_networkindividuals__networkindividualfulladdress_Jsonclick ;
      private string edtavUdelete_Jsonclick ;
      private string subGrids_Header ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8HasValidationErrors ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool AV5CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Combo_networkindividualcountry_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9isAlreadyAdded ;
      private bool gx_BV74 ;
      private string AV26WebSessionKey ;
      private string AV22PreviousStep ;
      private string wcpOAV26WebSessionKey ;
      private string wcpOAV22PreviousStep ;
      private string AV12NetworkIndividualBsnNumber ;
      private string AV17NetworkIndividualGivenName ;
      private string AV19NetworkIndividualLastName ;
      private string AV16NetworkIndividualGender ;
      private string AV15NetworkIndividualEmail ;
      private string AV13NetworkIndividualCity ;
      private string AV21NetworkIndividualZipCode ;
      private string AV10NetworkIndividualAddressLine1 ;
      private string AV11NetworkIndividualAddressLine2 ;
      private string AV14NetworkIndividualCountry ;
      private Guid AV18NetworkIndividualId ;
      private IGxSession AV25WebSession ;
      private GXWebGrid GridsContainer ;
      private GXWebRow GridsRow ;
      private GXWebColumn GridsColumn ;
      private GXUserControl ucCombo_networkindividualcountry ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucGrids_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavNetworkindividualgender ;
      private GXCombobox cmbavSdt_networkindividuals__networkindividualgender ;
      private GXBaseCollection<SdtSDT_NetworkIndividual> AV23SDT_NetworkIndividuals ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV33DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV32NetworkIndividualCountry_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private SdtSDT_NetworkIndividual AV30SDT_NetworkIndividual ;
      private SdtTrn_NetworkIndividual AV28BC_NetworkIndividual ;
      private IDataStoreProvider pr_default ;
      private SdtWP_CreateResidentAndNetworkData AV27WizardData ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV52GXV16 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV36NetworkIndividualCountry_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV35Combo_DataItem ;
      private GxSimpleCollection<string> AV31ComboTitles ;
      private SdtTrn_NetworkIndividual AV29Trn_NetworkIndividual ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_createresidentandnetworkstep2__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_createresidentandnetworkstep2__default : DataStoreHelperBase, IDataStoreHelper
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