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
   public class wp_createorganisationandmanagerstep2 : GXWebComponent
   {
      public wp_createorganisationandmanagerstep2( )
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

      public wp_createorganisationandmanagerstep2( IGxContext context )
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
         this.AV41WebSessionKey = aP0_WebSessionKey;
         this.AV33PreviousStep = aP1_PreviousStep;
         this.AV11GoingBack = aP2_GoingBack;
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
         cmbavManagergender = new GXCombobox();
         dynavSdt_managers__organisationid = new GXCombobox();
         cmbavSdt_managers__managergender = new GXCombobox();
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
                  AV41WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV41WebSessionKey", AV41WebSessionKey);
                  AV33PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV33PreviousStep", AV33PreviousStep);
                  AV11GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV11GoingBack", AV11GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV41WebSessionKey,(string)AV33PreviousStep,(bool)AV11GoingBack});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdt_managerss") == 0 )
               {
                  gxnrGridsdt_managerss_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdt_managerss") == 0 )
               {
                  gxgrGridsdt_managerss_refresh_invoke( ) ;
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

      protected void gxnrGridsdt_managerss_newrow_invoke( )
      {
         nRC_GXsfl_44 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_44"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_44_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_44_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_44_idx = GetPar( "sGXsfl_44_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsdt_managerss_newrow( ) ;
         /* End function gxnrGridsdt_managerss_newrow_invoke */
      }

      protected void gxgrGridsdt_managerss_refresh_invoke( )
      {
         subGridsdt_managerss_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdt_managerss_Rows"), "."), 18, MidpointRounding.ToEven));
         AV12HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV12HasValidationErrors, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridsdt_managerss_refresh_invoke */
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
            PA4H2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdt_managers__managerid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerid_Enabled), 5, 0), !bGXsfl_44_Refreshing);
               dynavSdt_managers__organisationid.Enabled = 0;
               AssignProp(sPrefix, false, dynavSdt_managers__organisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavSdt_managers__organisationid.Enabled), 5, 0), !bGXsfl_44_Refreshing);
               edtavSdt_managers__managergivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managergivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managergivenname_Enabled), 5, 0), !bGXsfl_44_Refreshing);
               edtavSdt_managers__managerlastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerlastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerlastname_Enabled), 5, 0), !bGXsfl_44_Refreshing);
               edtavSdt_managers__managerinitials_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerinitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerinitials_Enabled), 5, 0), !bGXsfl_44_Refreshing);
               edtavSdt_managers__manageremail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__manageremail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__manageremail_Enabled), 5, 0), !bGXsfl_44_Refreshing);
               edtavSdt_managers__managerphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerphone_Enabled), 5, 0), !bGXsfl_44_Refreshing);
               cmbavSdt_managers__managergender.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSdt_managers__managergender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdt_managers__managergender.Enabled), 5, 0), !bGXsfl_44_Refreshing);
               edtavUdelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavUdelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUdelete_Enabled), 5, 0), !bGXsfl_44_Refreshing);
               WS4H2( ) ;
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
            context.SendWebValue( "WP_Create Organisation And Manager Step2") ;
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
            GXEncryptionTmp = "wp_createorganisationandmanagerstep2.aspx"+UrlEncode(StringUtil.RTrim(AV41WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV33PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV11GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createorganisationandmanagerstep2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV12HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV12HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_managers", AV35SDT_Managers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_managers", AV35SDT_Managers);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_44", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_44), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV41WebSessionKey", wcpOAV41WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV33PreviousStep", wcpOAV33PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV11GoingBack", wcpOAV11GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV5CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV12HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV12HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV41WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_MANAGERS", AV35SDT_Managers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_MANAGERS", AV35SDT_Managers);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV42WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV42WizardData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_MANAGER", AV36Trn_Manager);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_MANAGER", AV36Trn_Manager);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMESSAGES", AV8ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMESSAGES", AV8ErrorMessages);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISALREADYEXISTINGINGAM", AV15isAlreadyExistingInGAM);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV33PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV11GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm4H2( )
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
         return "WP_CreateOrganisationAndManagerStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return "WP_Create Organisation And Manager Step2" ;
      }

      protected void WB4H0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createorganisationandmanagerstep2.aspx");
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavManagergivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManagergivenname_Internalname, "Given Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagergivenname_Internalname, AV21ManagerGivenName, StringUtil.RTrim( context.localUtil.Format( AV21ManagerGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagergivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavManagergivenname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavManagerlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManagerlastname_Internalname, "Last Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerlastname_Internalname, AV24ManagerLastName, StringUtil.RTrim( context.localUtil.Format( AV24ManagerLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavManagerlastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavManageremail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManageremail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManageremail_Internalname, AV18ManagerEmail, StringUtil.RTrim( context.localUtil.Format( AV18ManagerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManageremail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavManageremail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavManagergender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavManagergender_Internalname, "Gender", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavManagergender, cmbavManagergender_Internalname, StringUtil.RTrim( AV20ManagerGender), 1, cmbavManagergender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavManagergender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            cmbavManagergender.CurrentValue = StringUtil.RTrim( AV20ManagerGender);
            AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", (string)(cmbavManagergender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavManagerphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManagerphone_Internalname, "Phone", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerphone_Internalname, StringUtil.RTrim( AV25ManagerPhone), StringUtil.RTrim( context.localUtil.Format( AV25ManagerPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavManagerphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuinsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(44), 2, 0)+","+"null"+");", "Add", bttBtnuinsert_Jsonclick, 5, "Add new item", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateOrganisationAndManagerStep2.htm");
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
            Gridsdt_managerssContainer.SetWrapped(nGXWrapped);
            StartGridControl44( ) ;
         }
         if ( wbEnd == 44 )
         {
            wbEnd = 0;
            nRC_GXsfl_44 = (int)(nGXsfl_44_idx-1);
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nEOF", GRIDSDT_MANAGERSS_nEOF);
               Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nFirstRecordOnPage", GRIDSDT_MANAGERSS_nFirstRecordOnPage);
               AV43GXV1 = nGXsfl_44_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_managerssContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_managerss", Gridsdt_managerssContainer, subGridsdt_managerss_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData", Gridsdt_managerssContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData"+"V", Gridsdt_managerssContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_managerssContainerData"+"V"+"\" value='"+Gridsdt_managerssContainer.GridValuesHidden()+"'/>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnfinishwizard_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(44), 2, 0)+","+"null"+");", "Finish", bttBtnfinishwizard_Jsonclick, 5, "Finish", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOFINISHWIZARD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateOrganisationAndManagerStep2.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerid_Internalname, AV22ManagerId.ToString(), AV22ManagerId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerid_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagerid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagergamguid_Internalname, AV19ManagerGAMGUID, StringUtil.RTrim( context.localUtil.Format( AV19ManagerGAMGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagergamguid_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagergamguid_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerinitials_Internalname, StringUtil.RTrim( AV23ManagerInitials), StringUtil.RTrim( context.localUtil.Format( AV23ManagerInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerinitials_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagerinitials_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* User Defined Control */
            ucGridsdt_managerss_empowerer.Render(context, "wwp.gridempowerer", Gridsdt_managerss_empowerer_Internalname, sPrefix+"GRIDSDT_MANAGERSS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 44 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nEOF", GRIDSDT_MANAGERSS_nEOF);
                  Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nFirstRecordOnPage", GRIDSDT_MANAGERSS_nFirstRecordOnPage);
                  AV43GXV1 = nGXsfl_44_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_managerssContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_managerss", Gridsdt_managerssContainer, subGridsdt_managerss_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData", Gridsdt_managerssContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData"+"V", Gridsdt_managerssContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_managerssContainerData"+"V"+"\" value='"+Gridsdt_managerssContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4H2( )
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
            Form.Meta.addItem("description", "WP_Create Organisation And Manager Step2", 0) ;
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
               STRUP4H0( ) ;
            }
         }
      }

      protected void WS4H2( )
      {
         START4H2( ) ;
         EVT4H2( ) ;
      }

      protected void EVT4H2( )
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
                                 STRUP4H0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E114H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUInsert' */
                                    E124H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFINISHWIZARD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoFinishWizard' */
                                    E134H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_MANAGERSSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDSDT_MANAGERSSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridsdt_managerss_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridsdt_managerss_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridsdt_managerss_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridsdt_managerss_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDSDT_MANAGERSS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4H0( ) ;
                              }
                              nGXsfl_44_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
                              SubsflControlProps_442( ) ;
                              AV43GXV1 = (int)(nGXsfl_44_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
                              if ( ( AV35SDT_Managers.Count >= AV43GXV1 ) && ( AV43GXV1 > 0 ) )
                              {
                                 AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1));
                                 AV38UDelete = cgiGet( edtavUdelete_Internalname);
                                 AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV38UDelete);
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
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E144H2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_MANAGERSS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Gridsdt_managerss.Load */
                                          E154H2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
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
                                                E164H2 ();
                                             }
                                             dynload_actions( ) ;
                                          }
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
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E174H2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP4H0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
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

      protected void WE4H2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4H2( ) ;
            }
         }
      }

      protected void PA4H2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createorganisationandmanagerstep2.aspx")), "wp_createorganisationandmanagerstep2.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createorganisationandmanagerstep2.aspx")))) ;
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
               GX_FocusControl = edtavManagergivenname_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsdt_managerss_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_442( ) ;
         while ( nGXsfl_44_idx <= nRC_GXsfl_44 )
         {
            sendrow_442( ) ;
            nGXsfl_44_idx = ((subGridsdt_managerss_Islastpage==1)&&(nGXsfl_44_idx+1>subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : nGXsfl_44_idx+1);
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsdt_managerssContainer)) ;
         /* End function gxnrGridsdt_managerss_newrow */
      }

      protected void gxgrGridsdt_managerss_refresh( int subGridsdt_managerss_Rows ,
                                                    bool AV12HasValidationErrors ,
                                                    string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSDT_MANAGERSS_nCurrentRecord = 0;
         RF4H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridsdt_managerss_refresh */
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
         if ( cmbavManagergender.ItemCount > 0 )
         {
            AV20ManagerGender = cmbavManagergender.getValidValue(AV20ManagerGender);
            AssignAttri(sPrefix, false, "AV20ManagerGender", AV20ManagerGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavManagergender.CurrentValue = StringUtil.RTrim( AV20ManagerGender);
            AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdt_managers__managerid_Enabled = 0;
         dynavSdt_managers__organisationid.Enabled = 0;
         edtavSdt_managers__managergivenname_Enabled = 0;
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerphone_Enabled = 0;
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavUdelete_Enabled = 0;
      }

      protected void RF4H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridsdt_managerssContainer.ClearRows();
         }
         wbStart = 44;
         nGXsfl_44_idx = 1;
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         bGXsfl_44_Refreshing = true;
         Gridsdt_managerssContainer.AddObjectProperty("GridName", "Gridsdt_managerss");
         Gridsdt_managerssContainer.AddObjectProperty("CmpContext", sPrefix);
         Gridsdt_managerssContainer.AddObjectProperty("InMasterPage", "false");
         Gridsdt_managerssContainer.AddObjectProperty("Class", "WorkWith");
         Gridsdt_managerssContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsdt_managerssContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsdt_managerssContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Backcolorstyle), 1, 0, ".", "")));
         Gridsdt_managerssContainer.PageSize = subGridsdt_managerss_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_442( ) ;
            /* Execute user event: Gridsdt_managerss.Load */
            E154H2 ();
            if ( ( subGridsdt_managerss_Islastpage == 0 ) && ( GRIDSDT_MANAGERSS_nCurrentRecord > 0 ) && ( GRIDSDT_MANAGERSS_nGridOutOfScope == 0 ) && ( nGXsfl_44_idx == 1 ) )
            {
               GRIDSDT_MANAGERSS_nCurrentRecord = 0;
               GRIDSDT_MANAGERSS_nGridOutOfScope = 1;
               subgridsdt_managerss_firstpage( ) ;
               /* Execute user event: Gridsdt_managerss.Load */
               E154H2 ();
            }
            wbEnd = 44;
            WB4H0( ) ;
         }
         bGXsfl_44_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4H2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV12HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV12HasValidationErrors, context));
      }

      protected int subGridsdt_managerss_fnc_Pagecount( )
      {
         GRIDSDT_MANAGERSS_nRecordCount = subGridsdt_managerss_fnc_Recordcount( );
         if ( ((int)((GRIDSDT_MANAGERSS_nRecordCount) % (subGridsdt_managerss_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_MANAGERSS_nRecordCount/ (decimal)(subGridsdt_managerss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_MANAGERSS_nRecordCount/ (decimal)(subGridsdt_managerss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridsdt_managerss_fnc_Recordcount( )
      {
         return AV35SDT_Managers.Count ;
      }

      protected int subGridsdt_managerss_fnc_Recordsperpage( )
      {
         if ( subGridsdt_managerss_Rows > 0 )
         {
            return subGridsdt_managerss_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdt_managerss_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_MANAGERSS_nFirstRecordOnPage/ (decimal)(subGridsdt_managerss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridsdt_managerss_firstpage( )
      {
         GRIDSDT_MANAGERSS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV12HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_managerss_nextpage( )
      {
         GRIDSDT_MANAGERSS_nRecordCount = subGridsdt_managerss_fnc_Recordcount( );
         if ( ( GRIDSDT_MANAGERSS_nRecordCount >= subGridsdt_managerss_fnc_Recordsperpage( ) ) && ( GRIDSDT_MANAGERSS_nEOF == 0 ) )
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nFirstRecordOnPage+subGridsdt_managerss_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nFirstRecordOnPage", GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV12HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDT_MANAGERSS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdt_managerss_previouspage( )
      {
         if ( GRIDSDT_MANAGERSS_nFirstRecordOnPage >= subGridsdt_managerss_fnc_Recordsperpage( ) )
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nFirstRecordOnPage-subGridsdt_managerss_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV12HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_managerss_lastpage( )
      {
         GRIDSDT_MANAGERSS_nRecordCount = subGridsdt_managerss_fnc_Recordcount( );
         if ( GRIDSDT_MANAGERSS_nRecordCount > subGridsdt_managerss_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDT_MANAGERSS_nRecordCount) % (subGridsdt_managerss_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nRecordCount-subGridsdt_managerss_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nRecordCount-((int)((GRIDSDT_MANAGERSS_nRecordCount) % (subGridsdt_managerss_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV12HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdt_managerss_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(subGridsdt_managerss_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV12HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdt_managers__managerid_Enabled = 0;
         dynavSdt_managers__organisationid.Enabled = 0;
         edtavSdt_managers__managergivenname_Enabled = 0;
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerphone_Enabled = 0;
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavUdelete_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E144H2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_managers"), AV35SDT_Managers);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_MANAGERS"), AV35SDT_Managers);
            /* Read saved values. */
            nRC_GXsfl_44 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_44"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOAV41WebSessionKey = cgiGet( sPrefix+"wcpOAV41WebSessionKey");
            wcpOAV33PreviousStep = cgiGet( sPrefix+"wcpOAV33PreviousStep");
            wcpOAV11GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV11GoingBack"));
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDSDT_MANAGERSS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_MANAGERSS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGridsdt_managerss_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_MANAGERSS_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Rows), 6, 0, ".", "")));
            nRC_GXsfl_44 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_44"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_44_fel_idx = 0;
            while ( nGXsfl_44_fel_idx < nRC_GXsfl_44 )
            {
               nGXsfl_44_fel_idx = ((subGridsdt_managerss_Islastpage==1)&&(nGXsfl_44_fel_idx+1>subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : nGXsfl_44_fel_idx+1);
               sGXsfl_44_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_442( ) ;
               AV43GXV1 = (int)(nGXsfl_44_fel_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
               if ( ( AV35SDT_Managers.Count >= AV43GXV1 ) && ( AV43GXV1 > 0 ) )
               {
                  AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1));
                  AV38UDelete = cgiGet( edtavUdelete_Internalname);
               }
            }
            if ( nGXsfl_44_fel_idx == 0 )
            {
               nGXsfl_44_idx = 1;
               sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
               SubsflControlProps_442( ) ;
            }
            nGXsfl_44_fel_idx = 1;
            /* Read variables values. */
            AV21ManagerGivenName = cgiGet( edtavManagergivenname_Internalname);
            AssignAttri(sPrefix, false, "AV21ManagerGivenName", AV21ManagerGivenName);
            AV24ManagerLastName = cgiGet( edtavManagerlastname_Internalname);
            AssignAttri(sPrefix, false, "AV24ManagerLastName", AV24ManagerLastName);
            AV18ManagerEmail = cgiGet( edtavManageremail_Internalname);
            AssignAttri(sPrefix, false, "AV18ManagerEmail", AV18ManagerEmail);
            cmbavManagergender.Name = cmbavManagergender_Internalname;
            cmbavManagergender.CurrentValue = cgiGet( cmbavManagergender_Internalname);
            AV20ManagerGender = cgiGet( cmbavManagergender_Internalname);
            AssignAttri(sPrefix, false, "AV20ManagerGender", AV20ManagerGender);
            AV25ManagerPhone = cgiGet( edtavManagerphone_Internalname);
            AssignAttri(sPrefix, false, "AV25ManagerPhone", AV25ManagerPhone);
            if ( StringUtil.StrCmp(cgiGet( edtavManagerid_Internalname), "") == 0 )
            {
               AV22ManagerId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV22ManagerId", AV22ManagerId.ToString());
            }
            else
            {
               try
               {
                  AV22ManagerId = StringUtil.StrToGuid( cgiGet( edtavManagerid_Internalname));
                  AssignAttri(sPrefix, false, "AV22ManagerId", AV22ManagerId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vMANAGERID");
                  GX_FocusControl = edtavManagerid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV19ManagerGAMGUID = cgiGet( edtavManagergamguid_Internalname);
            AssignAttri(sPrefix, false, "AV19ManagerGAMGUID", AV19ManagerGAMGUID);
            AV23ManagerInitials = cgiGet( edtavManagerinitials_Internalname);
            AssignAttri(sPrefix, false, "AV23ManagerInitials", AV23ManagerInitials);
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
         E144H2 ();
         if (returnInSub) return;
      }

      protected void E144H2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavManagerid_Visible = 0;
         AssignProp(sPrefix, false, edtavManagerid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagerid_Visible), 5, 0), true);
         edtavManagergamguid_Visible = 0;
         AssignProp(sPrefix, false, edtavManagergamguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagergamguid_Visible), 5, 0), true);
         edtavManagerinitials_Visible = 0;
         AssignProp(sPrefix, false, edtavManagerinitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagerinitials_Visible), 5, 0), true);
         Gridsdt_managerss_empowerer_Gridinternalname = subGridsdt_managerss_Internalname;
         ucGridsdt_managerss_empowerer.SendProperty(context, sPrefix, false, Gridsdt_managerss_empowerer_Internalname, "GridInternalName", Gridsdt_managerss_empowerer_Gridinternalname);
         subGridsdt_managerss_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Rows), 6, 0, ".", "")));
      }

      private void E154H2( )
      {
         /* Gridsdt_managerss_Load Routine */
         returnInSub = false;
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV35SDT_Managers.Count )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1));
            AV38UDelete = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV38UDelete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 44;
            }
            if ( ( subGridsdt_managerss_Islastpage == 1 ) || ( subGridsdt_managerss_Rows == 0 ) || ( ( GRIDSDT_MANAGERSS_nCurrentRecord >= GRIDSDT_MANAGERSS_nFirstRecordOnPage ) && ( GRIDSDT_MANAGERSS_nCurrentRecord < GRIDSDT_MANAGERSS_nFirstRecordOnPage + subGridsdt_managerss_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_442( ) ;
            }
            GRIDSDT_MANAGERSS_nEOF = (short)(((GRIDSDT_MANAGERSS_nCurrentRecord<GRIDSDT_MANAGERSS_nFirstRecordOnPage+subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nEOF), 1, 0, ".", "")));
            GRIDSDT_MANAGERSS_nCurrentRecord = (long)(GRIDSDT_MANAGERSS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_44_Refreshing )
            {
               DoAjaxLoad(44, Gridsdt_managerssRow);
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E164H2 ();
         if (returnInSub) return;
      }

      protected void E164H2( )
      {
         AV43GXV1 = (int)(nGXsfl_44_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV43GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV43GXV1 ) )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV5CheckRequiredFieldsResult && ! AV12HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
            AV40WebSession.Remove(AV41WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV42WizardData", AV42WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8ErrorMessages", AV8ErrorMessages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36Trn_Manager", AV36Trn_Manager);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35SDT_Managers", AV35SDT_Managers);
         nGXsfl_44_bak_idx = nGXsfl_44_idx;
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV12HasValidationErrors, sPrefix) ;
         nGXsfl_44_idx = nGXsfl_44_bak_idx;
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         cmbavManagergender.CurrentValue = StringUtil.RTrim( AV20ManagerGender);
         AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
      }

      protected void E114H2( )
      {
         AV43GXV1 = (int)(nGXsfl_44_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV43GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV43GXV1 ) )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1));
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
         GXEncryptionTmp = "wp_createorganisationandmanager.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wp_createorganisationandmanager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV42WizardData", AV42WizardData);
      }

      protected void E124H2( )
      {
         AV43GXV1 = (int)(nGXsfl_44_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV43GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV43GXV1 ) )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1));
         }
         /* 'DoUInsert' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV5CheckRequiredFieldsResult && ! AV12HasValidationErrors )
         {
            AV14isAlreadyAdded = false;
            AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbylogin("local", AV18ManagerEmail, out  AV9GAMErrors);
            if ( AV10GAMUser.success() )
            {
               AV15isAlreadyExistingInGAM = true;
               AssignAttri(sPrefix, false, "AV15isAlreadyExistingInGAM", AV15isAlreadyExistingInGAM);
            }
            AV52GXV10 = 1;
            while ( AV52GXV10 <= AV35SDT_Managers.Count )
            {
               AV34SDT_Manager = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV52GXV10));
               if ( StringUtil.StrCmp(AV34SDT_Manager.gxTpr_Manageremail, AV18ManagerEmail) == 0 )
               {
                  AV14isAlreadyAdded = true;
                  if (true) break;
               }
               AV52GXV10 = (int)(AV52GXV10+1);
            }
            if ( AV14isAlreadyAdded )
            {
               GX_msglist.addItem("This Manager email has already been added.");
            }
            else
            {
               if ( AV15isAlreadyExistingInGAM )
               {
                  GX_msglist.addItem("This email is already used in the system.");
               }
               else
               {
                  AV34SDT_Manager = new SdtSDT_Managers_SDT_ManagersItem(context);
                  AV34SDT_Manager.gxTpr_Managerid = Guid.NewGuid( );
                  AV34SDT_Manager.gxTpr_Managergivenname = AV21ManagerGivenName;
                  AV34SDT_Manager.gxTpr_Managerlastname = AV24ManagerLastName;
                  AV34SDT_Manager.gxTpr_Manageremail = AV18ManagerEmail;
                  AV34SDT_Manager.gxTpr_Managergender = AV20ManagerGender;
                  AV34SDT_Manager.gxTpr_Managerphone = AV25ManagerPhone;
                  AV35SDT_Managers.Add(AV34SDT_Manager, 0);
                  gx_BV44 = true;
                  /* Execute user subroutine: 'CLEARFORMVALUES' */
                  S152 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35SDT_Managers", AV35SDT_Managers);
         nGXsfl_44_bak_idx = nGXsfl_44_idx;
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV12HasValidationErrors, sPrefix) ;
         nGXsfl_44_idx = nGXsfl_44_bak_idx;
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         cmbavManagergender.CurrentValue = StringUtil.RTrim( AV20ManagerGender);
         AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
      }

      protected void E134H2( )
      {
         AV43GXV1 = (int)(nGXsfl_44_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV43GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV43GXV1 ) )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1));
         }
         /* 'DoFinishWizard' Routine */
         returnInSub = false;
         if ( AV35SDT_Managers.Count > 0 )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
         }
         else
         {
            GX_msglist.addItem("Add at least 1 manager");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV42WizardData", AV42WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8ErrorMessages", AV8ErrorMessages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36Trn_Manager", AV36Trn_Manager);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35SDT_Managers", AV35SDT_Managers);
         nGXsfl_44_bak_idx = nGXsfl_44_idx;
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV12HasValidationErrors, sPrefix) ;
         nGXsfl_44_idx = nGXsfl_44_bak_idx;
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         cmbavManagergender.CurrentValue = StringUtil.RTrim( AV20ManagerGender);
         AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV42WizardData.FromJSonString(AV40WebSession.Get(AV41WebSessionKey), null);
         AV22ManagerId = AV42WizardData.gxTpr_Step2.gxTpr_Managerid;
         AssignAttri(sPrefix, false, "AV22ManagerId", AV22ManagerId.ToString());
         AV19ManagerGAMGUID = AV42WizardData.gxTpr_Step2.gxTpr_Managergamguid;
         AssignAttri(sPrefix, false, "AV19ManagerGAMGUID", AV19ManagerGAMGUID);
         AV21ManagerGivenName = AV42WizardData.gxTpr_Step2.gxTpr_Managergivenname;
         AssignAttri(sPrefix, false, "AV21ManagerGivenName", AV21ManagerGivenName);
         AV24ManagerLastName = AV42WizardData.gxTpr_Step2.gxTpr_Managerlastname;
         AssignAttri(sPrefix, false, "AV24ManagerLastName", AV24ManagerLastName);
         AV18ManagerEmail = AV42WizardData.gxTpr_Step2.gxTpr_Manageremail;
         AssignAttri(sPrefix, false, "AV18ManagerEmail", AV18ManagerEmail);
         AV20ManagerGender = AV42WizardData.gxTpr_Step2.gxTpr_Managergender;
         AssignAttri(sPrefix, false, "AV20ManagerGender", AV20ManagerGender);
         AV23ManagerInitials = AV42WizardData.gxTpr_Step2.gxTpr_Managerinitials;
         AssignAttri(sPrefix, false, "AV23ManagerInitials", AV23ManagerInitials);
         AV25ManagerPhone = AV42WizardData.gxTpr_Step2.gxTpr_Managerphone;
         AssignAttri(sPrefix, false, "AV25ManagerPhone", AV25ManagerPhone);
         AV35SDT_Managers = AV42WizardData.gxTpr_Step2.gxTpr_Sdt_managers;
         gx_BV44 = true;
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV42WizardData.FromJSonString(AV40WebSession.Get(AV41WebSessionKey), null);
         AV42WizardData.gxTpr_Step2.gxTpr_Managerid = AV22ManagerId;
         AV42WizardData.gxTpr_Step2.gxTpr_Managergamguid = AV19ManagerGAMGUID;
         AV42WizardData.gxTpr_Step2.gxTpr_Managergivenname = AV21ManagerGivenName;
         AV42WizardData.gxTpr_Step2.gxTpr_Managerlastname = AV24ManagerLastName;
         AV42WizardData.gxTpr_Step2.gxTpr_Manageremail = AV18ManagerEmail;
         AV42WizardData.gxTpr_Step2.gxTpr_Managergender = AV20ManagerGender;
         AV42WizardData.gxTpr_Step2.gxTpr_Managerinitials = AV23ManagerInitials;
         AV42WizardData.gxTpr_Step2.gxTpr_Managerphone = AV25ManagerPhone;
         AV42WizardData.gxTpr_Step2.gxTpr_Sdt_managers = AV35SDT_Managers;
         AV40WebSession.Set(AV41WebSessionKey, AV42WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV8ErrorMessages.Clear();
         AV37Trn_Organisation = new SdtTrn_Organisation(context);
         AV37Trn_Organisation.gxTpr_Organisationid = AV42WizardData.gxTpr_Step1.gxTpr_Organisationid;
         AV37Trn_Organisation.gxTpr_Organisationname = AV42WizardData.gxTpr_Step1.gxTpr_Organisationname;
         AV37Trn_Organisation.gxTpr_Organisationemail = AV42WizardData.gxTpr_Step1.gxTpr_Organisationemail;
         AV37Trn_Organisation.gxTpr_Organisationkvknumber = AV42WizardData.gxTpr_Step1.gxTpr_Organisationkvknumber;
         AV37Trn_Organisation.gxTpr_Organisationphone = AV42WizardData.gxTpr_Step1.gxTpr_Organisationphone;
         AV37Trn_Organisation.gxTpr_Organisationvatnumber = AV42WizardData.gxTpr_Step1.gxTpr_Organisationvatnumber;
         AV37Trn_Organisation.gxTpr_Organisationtypeid = AV42WizardData.gxTpr_Step1.gxTpr_Organisationtypeid;
         AV37Trn_Organisation.gxTpr_Organisationaddresscity = AV42WizardData.gxTpr_Step1.gxTpr_Organisationaddresscity;
         AV37Trn_Organisation.gxTpr_Organisationaddresszipcode = AV42WizardData.gxTpr_Step1.gxTpr_Organisationaddresszipcode;
         AV37Trn_Organisation.gxTpr_Organisationaddresscountry = AV42WizardData.gxTpr_Step1.gxTpr_Organisationaddresscountry;
         AV37Trn_Organisation.gxTpr_Organisationaddressline1 = AV42WizardData.gxTpr_Step1.gxTpr_Organisationaddressline1;
         AV37Trn_Organisation.gxTpr_Organisationaddressline2 = AV42WizardData.gxTpr_Step1.gxTpr_Organisationaddressline2;
         AV17isOrganisationInserted = AV37Trn_Organisation.Insert();
         if ( AV17isOrganisationInserted )
         {
            AV53GXV11 = 1;
            while ( AV53GXV11 <= AV35SDT_Managers.Count )
            {
               AV34SDT_Manager = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV53GXV11));
               AV36Trn_Manager.gxTpr_Managerid = AV34SDT_Manager.gxTpr_Managerid;
               AV36Trn_Manager.gxTpr_Managergivenname = AV34SDT_Manager.gxTpr_Managergivenname;
               AV36Trn_Manager.gxTpr_Managerlastname = AV34SDT_Manager.gxTpr_Managerlastname;
               AV36Trn_Manager.gxTpr_Manageremail = AV34SDT_Manager.gxTpr_Manageremail;
               AV36Trn_Manager.gxTpr_Managerphone = AV34SDT_Manager.gxTpr_Managerphone;
               AV36Trn_Manager.gxTpr_Organisationid = AV37Trn_Organisation.gxTpr_Organisationid;
               AV36Trn_Manager.gxTpr_Managergender = AV34SDT_Manager.gxTpr_Managergender;
               AV36Trn_Manager.gxTpr_Managergamguid = AV34SDT_Manager.gxTpr_Managergamguid;
               AV16isManagerInserted = AV36Trn_Manager.Insert();
               if ( ! AV16isManagerInserted )
               {
                  AV8ErrorMessages = AV36Trn_Manager.GetMessages();
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S162 ();
                  if (returnInSub) return;
               }
               AV53GXV11 = (int)(AV53GXV11+1);
            }
            context.CommitDataStores("wp_createorganisationandmanagerstep2",pr_default);
            /* Execute user subroutine: 'CLEARFORMVALUES' */
            S152 ();
            if (returnInSub) return;
            AV40WebSession.Remove(AV41WebSessionKey);
            AV35SDT_Managers.Clear();
            gx_BV44 = true;
            if ( AV8ErrorMessages.Count > 0 )
            {
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S162 ();
               if (returnInSub) return;
            }
            else
            {
               CallWebObject(formatLink("trn_organisationww.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else
         {
            AV8ErrorMessages = AV37Trn_Organisation.GetMessages();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S162 ();
            if (returnInSub) return;
         }
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV5CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21ManagerGivenName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Given Name", "", "", "", "", "", "", "", ""),  "error",  edtavManagergivenname_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24ManagerLastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Last Name", "", "", "", "", "", "", "", ""),  "error",  edtavManagerlastname_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ManagerEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavManageremail_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
      }

      protected void E174H2( )
      {
         AV43GXV1 = (int)(nGXsfl_44_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV43GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV43GXV1 ) )
         {
            AV35SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1));
         }
         /* Udelete_Click Routine */
         returnInSub = false;
         AV35SDT_Managers.RemoveItem(AV35SDT_Managers.IndexOf(((SdtSDT_Managers_SDT_ManagersItem)(AV35SDT_Managers.CurrentItem))));
         gx_BV44 = true;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35SDT_Managers", AV35SDT_Managers);
         nGXsfl_44_bak_idx = nGXsfl_44_idx;
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV12HasValidationErrors, sPrefix) ;
         nGXsfl_44_idx = nGXsfl_44_bak_idx;
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
      }

      protected void S162( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV54GXV12 = 1;
         while ( AV54GXV12 <= AV8ErrorMessages.Count )
         {
            AV7Error = ((GeneXus.Utils.SdtMessages_Message)AV8ErrorMessages.Item(AV54GXV12));
            GX_msglist.addItem("Error: "+AV7Error.gxTpr_Description);
            AV54GXV12 = (int)(AV54GXV12+1);
         }
      }

      protected void S152( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV22ManagerId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV22ManagerId", AV22ManagerId.ToString());
         AV19ManagerGAMGUID = "";
         AssignAttri(sPrefix, false, "AV19ManagerGAMGUID", AV19ManagerGAMGUID);
         AV21ManagerGivenName = "";
         AssignAttri(sPrefix, false, "AV21ManagerGivenName", AV21ManagerGivenName);
         AV24ManagerLastName = "";
         AssignAttri(sPrefix, false, "AV24ManagerLastName", AV24ManagerLastName);
         AV18ManagerEmail = "";
         AssignAttri(sPrefix, false, "AV18ManagerEmail", AV18ManagerEmail);
         AV20ManagerGender = "";
         AssignAttri(sPrefix, false, "AV20ManagerGender", AV20ManagerGender);
         AV23ManagerInitials = "";
         AssignAttri(sPrefix, false, "AV23ManagerInitials", AV23ManagerInitials);
         AV25ManagerPhone = "";
         AssignAttri(sPrefix, false, "AV25ManagerPhone", AV25ManagerPhone);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV41WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV41WebSessionKey", AV41WebSessionKey);
         AV33PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV33PreviousStep", AV33PreviousStep);
         AV11GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV11GoingBack", AV11GoingBack);
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
         PA4H2( ) ;
         WS4H2( ) ;
         WE4H2( ) ;
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
         sCtrlAV41WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV33PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV11GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4H2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createorganisationandmanagerstep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4H2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV41WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV41WebSessionKey", AV41WebSessionKey);
            AV33PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV33PreviousStep", AV33PreviousStep);
            AV11GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV11GoingBack", AV11GoingBack);
         }
         wcpOAV41WebSessionKey = cgiGet( sPrefix+"wcpOAV41WebSessionKey");
         wcpOAV33PreviousStep = cgiGet( sPrefix+"wcpOAV33PreviousStep");
         wcpOAV11GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV11GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV41WebSessionKey, wcpOAV41WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV33PreviousStep, wcpOAV33PreviousStep) != 0 ) || ( AV11GoingBack != wcpOAV11GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV41WebSessionKey = AV41WebSessionKey;
         wcpOAV33PreviousStep = AV33PreviousStep;
         wcpOAV11GoingBack = AV11GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV41WebSessionKey = cgiGet( sPrefix+"AV41WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV41WebSessionKey) > 0 )
         {
            AV41WebSessionKey = cgiGet( sCtrlAV41WebSessionKey);
            AssignAttri(sPrefix, false, "AV41WebSessionKey", AV41WebSessionKey);
         }
         else
         {
            AV41WebSessionKey = cgiGet( sPrefix+"AV41WebSessionKey_PARM");
         }
         sCtrlAV33PreviousStep = cgiGet( sPrefix+"AV33PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV33PreviousStep) > 0 )
         {
            AV33PreviousStep = cgiGet( sCtrlAV33PreviousStep);
            AssignAttri(sPrefix, false, "AV33PreviousStep", AV33PreviousStep);
         }
         else
         {
            AV33PreviousStep = cgiGet( sPrefix+"AV33PreviousStep_PARM");
         }
         sCtrlAV11GoingBack = cgiGet( sPrefix+"AV11GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV11GoingBack) > 0 )
         {
            AV11GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV11GoingBack));
            AssignAttri(sPrefix, false, "AV11GoingBack", AV11GoingBack);
         }
         else
         {
            AV11GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV11GoingBack_PARM"));
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
         PA4H2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4H2( ) ;
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
         WS4H2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV41WebSessionKey_PARM", AV41WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV41WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV41WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV41WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV33PreviousStep_PARM", AV33PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV33PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV33PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV33PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11GoingBack_PARM", StringUtil.BoolToStr( AV11GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11GoingBack_CTRL", StringUtil.RTrim( sCtrlAV11GoingBack));
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
         WE4H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249271946917", true, true);
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
         context.AddJavascriptSource("wp_createorganisationandmanagerstep2.js", "?20249271946920", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_442( )
      {
         edtavSdt_managers__managerid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERID_"+sGXsfl_44_idx;
         dynavSdt_managers__organisationid_Internalname = sPrefix+"SDT_MANAGERS__ORGANISATIONID_"+sGXsfl_44_idx;
         edtavSdt_managers__managergivenname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGIVENNAME_"+sGXsfl_44_idx;
         edtavSdt_managers__managerlastname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERLASTNAME_"+sGXsfl_44_idx;
         edtavSdt_managers__managerinitials_Internalname = sPrefix+"SDT_MANAGERS__MANAGERINITIALS_"+sGXsfl_44_idx;
         edtavSdt_managers__manageremail_Internalname = sPrefix+"SDT_MANAGERS__MANAGEREMAIL_"+sGXsfl_44_idx;
         edtavSdt_managers__managerphone_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONE_"+sGXsfl_44_idx;
         cmbavSdt_managers__managergender_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGENDER_"+sGXsfl_44_idx;
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_44_idx;
      }

      protected void SubsflControlProps_fel_442( )
      {
         edtavSdt_managers__managerid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERID_"+sGXsfl_44_fel_idx;
         dynavSdt_managers__organisationid_Internalname = sPrefix+"SDT_MANAGERS__ORGANISATIONID_"+sGXsfl_44_fel_idx;
         edtavSdt_managers__managergivenname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGIVENNAME_"+sGXsfl_44_fel_idx;
         edtavSdt_managers__managerlastname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERLASTNAME_"+sGXsfl_44_fel_idx;
         edtavSdt_managers__managerinitials_Internalname = sPrefix+"SDT_MANAGERS__MANAGERINITIALS_"+sGXsfl_44_fel_idx;
         edtavSdt_managers__manageremail_Internalname = sPrefix+"SDT_MANAGERS__MANAGEREMAIL_"+sGXsfl_44_fel_idx;
         edtavSdt_managers__managerphone_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONE_"+sGXsfl_44_fel_idx;
         cmbavSdt_managers__managergender_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGENDER_"+sGXsfl_44_fel_idx;
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_44_fel_idx;
      }

      protected void sendrow_442( )
      {
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         WB4H0( ) ;
         if ( ( subGridsdt_managerss_Rows * 1 == 0 ) || ( nGXsfl_44_idx <= subGridsdt_managerss_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridsdt_managerssRow = GXWebRow.GetNew(context,Gridsdt_managerssContainer);
            if ( subGridsdt_managerss_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdt_managerss_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Odd";
               }
            }
            else if ( subGridsdt_managerss_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdt_managerss_Backstyle = 0;
               subGridsdt_managerss_Backcolor = subGridsdt_managerss_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Uniform";
               }
            }
            else if ( subGridsdt_managerss_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdt_managerss_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Odd";
               }
               subGridsdt_managerss_Backcolor = (int)(0x0);
            }
            else if ( subGridsdt_managerss_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdt_managerss_Backstyle = 1;
               if ( ((int)((nGXsfl_44_idx) % (2))) == 0 )
               {
                  subGridsdt_managerss_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Even";
                  }
               }
               else
               {
                  subGridsdt_managerss_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Odd";
                  }
               }
            }
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_44_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerid_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managerid.ToString(),((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managerid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managerid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)44,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( dynavSdt_managers__organisationid.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_MANAGERS__ORGANISATIONID_" + sGXsfl_44_idx;
               dynavSdt_managers__organisationid.Name = GXCCtl;
               dynavSdt_managers__organisationid.WebTags = "";
               dynavSdt_managers__organisationid.removeAllItems();
               /* Using cursor H004H2 */
               pr_default.execute(0);
               while ( (pr_default.getStatus(0) != 101) )
               {
                  dynavSdt_managers__organisationid.addItem(H004H2_A11OrganisationId[0].ToString(), H004H2_A13OrganisationName[0], 0);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               if ( dynavSdt_managers__organisationid.ItemCount > 0 )
               {
                  if ( ( AV43GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV43GXV1 ) && (Guid.Empty==((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Organisationid) )
                  {
                     ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Organisationid = StringUtil.StrToGuid( dynavSdt_managers__organisationid.getValidValue(((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Organisationid.ToString()));
                  }
               }
            }
            /* ComboBox */
            Gridsdt_managerssRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavSdt_managers__organisationid,(string)dynavSdt_managers__organisationid_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Organisationid.ToString(),(short)1,(string)dynavSdt_managers__organisationid_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"guid",(string)"",(short)0,dynavSdt_managers__organisationid.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            dynavSdt_managers__organisationid.CurrentValue = ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Organisationid.ToString();
            AssignProp(sPrefix, false, dynavSdt_managers__organisationid_Internalname, "Values", (string)(dynavSdt_managers__organisationid.ToJavascriptSource()), !bGXsfl_44_Refreshing);
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',44)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managergivenname_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managergivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managergivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__managergivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',44)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerlastname_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managerlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__managerlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerinitials_Internalname,StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managerinitials),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerinitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managerinitials_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',44)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__manageremail_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Manageremail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__manageremail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__manageremail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',44)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerphone_Internalname,StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managerphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__managerphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',44)\"";
            if ( ( cmbavSdt_managers__managergender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_MANAGERS__MANAGERGENDER_" + sGXsfl_44_idx;
               cmbavSdt_managers__managergender.Name = GXCCtl;
               cmbavSdt_managers__managergender.WebTags = "";
               cmbavSdt_managers__managergender.addItem("Male", "Male", 0);
               cmbavSdt_managers__managergender.addItem("Female", "Female", 0);
               cmbavSdt_managers__managergender.addItem("Other", "Other", 0);
               if ( cmbavSdt_managers__managergender.ItemCount > 0 )
               {
                  if ( ( AV43GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV43GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managergender)) )
                  {
                     ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managergender = cmbavSdt_managers__managergender.getValidValue(((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managergender);
                  }
               }
            }
            /* ComboBox */
            Gridsdt_managerssRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_managers__managergender,(string)cmbavSdt_managers__managergender_Internalname,StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managergender),(short)1,(string)cmbavSdt_managers__managergender_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavSdt_managers__managergender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_managers__managergender.CurrentValue = StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managergender);
            AssignProp(sPrefix, false, cmbavSdt_managers__managergender_Internalname, "Values", (string)(cmbavSdt_managers__managergender.ToJavascriptSource()), !bGXsfl_44_Refreshing);
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'" + sGXsfl_44_idx + "',44)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUdelete_Internalname,StringUtil.RTrim( AV38UDelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUDELETE.CLICK."+sGXsfl_44_idx+"'",(string)"",(string)"",(string)"Delete item",(string)"",(string)edtavUdelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUdelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)44,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes4H2( ) ;
            Gridsdt_managerssContainer.AddRow(Gridsdt_managerssRow);
            nGXsfl_44_idx = ((subGridsdt_managerss_Islastpage==1)&&(nGXsfl_44_idx+1>subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : nGXsfl_44_idx+1);
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
         }
         /* End function sendrow_442 */
      }

      protected void init_web_controls( )
      {
         cmbavManagergender.Name = "vMANAGERGENDER";
         cmbavManagergender.WebTags = "";
         cmbavManagergender.addItem("Male", "Male", 0);
         cmbavManagergender.addItem("Female", "Female", 0);
         cmbavManagergender.addItem("Other", "Other", 0);
         if ( cmbavManagergender.ItemCount > 0 )
         {
         }
         GXCCtl = "SDT_MANAGERS__ORGANISATIONID_" + sGXsfl_44_idx;
         dynavSdt_managers__organisationid.Name = GXCCtl;
         dynavSdt_managers__organisationid.WebTags = "";
         dynavSdt_managers__organisationid.removeAllItems();
         /* Using cursor H004H3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            dynavSdt_managers__organisationid.addItem(H004H3_A11OrganisationId[0].ToString(), H004H3_A13OrganisationName[0], 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( dynavSdt_managers__organisationid.ItemCount > 0 )
         {
            if ( ( AV43GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV43GXV1 ) && (Guid.Empty==((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Organisationid) )
            {
            }
         }
         GXCCtl = "SDT_MANAGERS__MANAGERGENDER_" + sGXsfl_44_idx;
         cmbavSdt_managers__managergender.Name = GXCCtl;
         cmbavSdt_managers__managergender.WebTags = "";
         cmbavSdt_managers__managergender.addItem("Male", "Male", 0);
         cmbavSdt_managers__managergender.addItem("Female", "Female", 0);
         cmbavSdt_managers__managergender.addItem("Other", "Other", 0);
         if ( cmbavSdt_managers__managergender.ItemCount > 0 )
         {
            if ( ( AV43GXV1 > 0 ) && ( AV35SDT_Managers.Count >= AV43GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV35SDT_Managers.Item(AV43GXV1)).gxTpr_Managergender)) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl44( )
      {
         if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_managerssContainer"+"DivS\" data-gxgridid=\"44\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridsdt_managerss_Internalname, subGridsdt_managerss_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridsdt_managerss_Backcolorstyle == 0 )
            {
               subGridsdt_managerss_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridsdt_managerss_Class) > 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Title";
               }
            }
            else
            {
               subGridsdt_managerss_Titlebackstyle = 1;
               if ( subGridsdt_managerss_Backcolorstyle == 1 )
               {
                  subGridsdt_managerss_Titlebackcolor = subGridsdt_managerss_Allbackcolor;
                  if ( StringUtil.Len( subGridsdt_managerss_Class) > 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridsdt_managerss_Class) > 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Manager Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Organisation Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Given Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Last Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Initials") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridsdt_managerssContainer.AddObjectProperty("GridName", "Gridsdt_managerss");
         }
         else
         {
            Gridsdt_managerssContainer.AddObjectProperty("GridName", "Gridsdt_managerss");
            Gridsdt_managerssContainer.AddObjectProperty("Header", subGridsdt_managerss_Header);
            Gridsdt_managerssContainer.AddObjectProperty("Class", "WorkWith");
            Gridsdt_managerssContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Backcolorstyle), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("CmpContext", sPrefix);
            Gridsdt_managerssContainer.AddObjectProperty("InMasterPage", "false");
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerid_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavSdt_managers__organisationid.Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managergivenname_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerlastname_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerinitials_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__manageremail_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerphone_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_managers__managergender.Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV38UDelete)));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUdelete_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Selectedindex), 4, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Allowselection), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Selectioncolor), 9, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Allowhovering), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Hoveringcolor), 9, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Allowcollapsing), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavManagergivenname_Internalname = sPrefix+"vMANAGERGIVENNAME";
         edtavManagerlastname_Internalname = sPrefix+"vMANAGERLASTNAME";
         edtavManageremail_Internalname = sPrefix+"vMANAGEREMAIL";
         cmbavManagergender_Internalname = sPrefix+"vMANAGERGENDER";
         edtavManagerphone_Internalname = sPrefix+"vMANAGERPHONE";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         bttBtnuinsert_Internalname = sPrefix+"BTNUINSERT";
         edtavSdt_managers__managerid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERID";
         dynavSdt_managers__organisationid_Internalname = sPrefix+"SDT_MANAGERS__ORGANISATIONID";
         edtavSdt_managers__managergivenname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGIVENNAME";
         edtavSdt_managers__managerlastname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERLASTNAME";
         edtavSdt_managers__managerinitials_Internalname = sPrefix+"SDT_MANAGERS__MANAGERINITIALS";
         edtavSdt_managers__manageremail_Internalname = sPrefix+"SDT_MANAGERS__MANAGEREMAIL";
         edtavSdt_managers__managerphone_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONE";
         cmbavSdt_managers__managergender_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGENDER";
         edtavUdelete_Internalname = sPrefix+"vUDELETE";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         bttBtnfinishwizard_Internalname = sPrefix+"BTNFINISHWIZARD";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavManagerid_Internalname = sPrefix+"vMANAGERID";
         edtavManagergamguid_Internalname = sPrefix+"vMANAGERGAMGUID";
         edtavManagerinitials_Internalname = sPrefix+"vMANAGERINITIALS";
         Gridsdt_managerss_empowerer_Internalname = sPrefix+"GRIDSDT_MANAGERSS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridsdt_managerss_Internalname = sPrefix+"GRIDSDT_MANAGERSS";
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
         subGridsdt_managerss_Allowcollapsing = 0;
         subGridsdt_managerss_Allowselection = 0;
         subGridsdt_managerss_Header = "";
         edtavUdelete_Jsonclick = "";
         edtavUdelete_Enabled = 1;
         cmbavSdt_managers__managergender_Jsonclick = "";
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavSdt_managers__managerphone_Jsonclick = "";
         edtavSdt_managers__managerphone_Enabled = 0;
         edtavSdt_managers__manageremail_Jsonclick = "";
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerinitials_Jsonclick = "";
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__managerlastname_Jsonclick = "";
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managergivenname_Jsonclick = "";
         edtavSdt_managers__managergivenname_Enabled = 0;
         dynavSdt_managers__organisationid_Jsonclick = "";
         dynavSdt_managers__organisationid.Enabled = 0;
         edtavSdt_managers__managerid_Jsonclick = "";
         edtavSdt_managers__managerid_Enabled = 0;
         subGridsdt_managerss_Class = "WorkWith";
         subGridsdt_managerss_Backcolorstyle = 0;
         edtavManagerinitials_Jsonclick = "";
         edtavManagerinitials_Visible = 1;
         edtavManagergamguid_Jsonclick = "";
         edtavManagergamguid_Visible = 1;
         edtavManagerid_Jsonclick = "";
         edtavManagerid_Visible = 1;
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = "Previous";
         Btnwizardprevious_Tooltiptext = "";
         edtavManagerphone_Jsonclick = "";
         edtavManagerphone_Enabled = 1;
         cmbavManagergender_Jsonclick = "";
         cmbavManagergender.Enabled = 1;
         edtavManageremail_Jsonclick = "";
         edtavManageremail_Enabled = 1;
         edtavManagerlastname_Jsonclick = "";
         edtavManagerlastname_Enabled = 1;
         edtavManagergivenname_Jsonclick = "";
         edtavManagergivenname_Enabled = 1;
         cmbavSdt_managers__managergender.Enabled = -1;
         edtavSdt_managers__managerphone_Enabled = -1;
         edtavSdt_managers__manageremail_Enabled = -1;
         edtavSdt_managers__managerinitials_Enabled = -1;
         edtavSdt_managers__managerlastname_Enabled = -1;
         edtavSdt_managers__managergivenname_Enabled = -1;
         dynavSdt_managers__organisationid.Enabled = -1;
         edtavSdt_managers__managerid_Enabled = -1;
         subGridsdt_managerss_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS.LOAD","""{"handler":"E154H2","iparms":[]""");
         setEventMetadata("GRIDSDT_MANAGERSS.LOAD",""","oparms":[{"av":"AV38UDelete","fld":"vUDELETE"}]}""");
         setEventMetadata("ENTER","""{"handler":"E164H2","iparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV41WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"AV42WizardData","fld":"vWIZARDDATA"},{"av":"AV36Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV42WizardData","fld":"vWIZARDDATA"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"},{"av":"AV36Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E114H2","iparms":[{"av":"AV41WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV42WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOUINSERT'","""{"handler":"E124H2","iparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"AV15isAlreadyExistingInGAM","fld":"vISALREADYEXISTINGINGAM"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("'DOUINSERT'",""","oparms":[{"av":"AV15isAlreadyExistingInGAM","fld":"vISALREADYEXISTINGINGAM"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"}]}""");
         setEventMetadata("'DOFINISHWIZARD'","""{"handler":"E134H2","iparms":[{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"AV41WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV42WizardData","fld":"vWIZARDDATA"},{"av":"AV36Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("'DOFINISHWIZARD'",""","oparms":[{"av":"AV42WizardData","fld":"vWIZARDDATA"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"},{"av":"AV36Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"AV22ManagerId","fld":"vMANAGERID"},{"av":"AV19ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV21ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV24ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV18ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"cmbavManagergender"},{"av":"AV20ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV23ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV25ManagerPhone","fld":"vMANAGERPHONE"}]}""");
         setEventMetadata("VUDELETE.CLICK","""{"handler":"E174H2","iparms":[{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VUDELETE.CLICK",""","oparms":[{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_FIRSTPAGE","""{"handler":"subgridsdt_managerss_firstpage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_PREVPAGE","""{"handler":"subgridsdt_managerss_previouspage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_NEXTPAGE","""{"handler":"subgridsdt_managerss_nextpage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_LASTPAGE","""{"handler":"subgridsdt_managerss_lastpage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV35SDT_Managers","fld":"vSDT_MANAGERS","grid":44},{"av":"nGXsfl_44_idx","ctrl":"GRID","prop":"GridCurrRow","grid":44},{"av":"nRC_GXsfl_44","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":44},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV12HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("VALIDV_MANAGEREMAIL","""{"handler":"Validv_Manageremail","iparms":[]}""");
         setEventMetadata("VALIDV_MANAGERGENDER","""{"handler":"Validv_Managergender","iparms":[]}""");
         setEventMetadata("VALIDV_MANAGERID","""{"handler":"Validv_Managerid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("VALIDV_GXV9","""{"handler":"Validv_Gxv9","iparms":[]}""");
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
         wcpOAV41WebSessionKey = "";
         wcpOAV33PreviousStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV35SDT_Managers = new GXBaseCollection<SdtSDT_Managers_SDT_ManagersItem>( context, "SDT_ManagersItem", "Comforta_version2");
         AV42WizardData = new SdtWP_CreateOrganisationAndManagerData(context);
         AV36Trn_Manager = new SdtTrn_Manager(context);
         AV8ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV21ManagerGivenName = "";
         AV24ManagerLastName = "";
         AV18ManagerEmail = "";
         AV20ManagerGender = "";
         AV25ManagerPhone = "";
         bttBtnuinsert_Jsonclick = "";
         Gridsdt_managerssContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         bttBtnfinishwizard_Jsonclick = "";
         AV22ManagerId = Guid.Empty;
         AV19ManagerGAMGUID = "";
         AV23ManagerInitials = "";
         ucGridsdt_managerss_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV38UDelete = "";
         GXDecQS = "";
         Gridsdt_managerss_empowerer_Gridinternalname = "";
         Gridsdt_managerssRow = new GXWebRow();
         AV40WebSession = context.GetSession();
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV34SDT_Manager = new SdtSDT_Managers_SDT_ManagersItem(context);
         AV37Trn_Organisation = new SdtTrn_Organisation(context);
         AV7Error = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV41WebSessionKey = "";
         sCtrlAV33PreviousStep = "";
         sCtrlAV11GoingBack = "";
         subGridsdt_managerss_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         H004H2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H004H2_A13OrganisationName = new string[] {""} ;
         H004H3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H004H3_A13OrganisationName = new string[] {""} ;
         Gridsdt_managerssColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_createorganisationandmanagerstep2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createorganisationandmanagerstep2__default(),
            new Object[][] {
                new Object[] {
               H004H2_A11OrganisationId, H004H2_A13OrganisationName
               }
               , new Object[] {
               H004H3_A11OrganisationId, H004H3_A13OrganisationName
               }
            }
         );
         /* GeneXus formulas. */
         edtavSdt_managers__managerid_Enabled = 0;
         dynavSdt_managers__organisationid.Enabled = 0;
         edtavSdt_managers__managergivenname_Enabled = 0;
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerphone_Enabled = 0;
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavUdelete_Enabled = 0;
      }

      private short GRIDSDT_MANAGERSS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGridsdt_managerss_Backcolorstyle ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGridsdt_managerss_Backstyle ;
      private short subGridsdt_managerss_Titlebackstyle ;
      private short subGridsdt_managerss_Allowselection ;
      private short subGridsdt_managerss_Allowhovering ;
      private short subGridsdt_managerss_Allowcollapsing ;
      private short subGridsdt_managerss_Collapsed ;
      private int nRC_GXsfl_44 ;
      private int subGridsdt_managerss_Rows ;
      private int nGXsfl_44_idx=1 ;
      private int edtavSdt_managers__managerid_Enabled ;
      private int edtavSdt_managers__managergivenname_Enabled ;
      private int edtavSdt_managers__managerlastname_Enabled ;
      private int edtavSdt_managers__managerinitials_Enabled ;
      private int edtavSdt_managers__manageremail_Enabled ;
      private int edtavSdt_managers__managerphone_Enabled ;
      private int edtavUdelete_Enabled ;
      private int edtavManagergivenname_Enabled ;
      private int edtavManagerlastname_Enabled ;
      private int edtavManageremail_Enabled ;
      private int edtavManagerphone_Enabled ;
      private int AV43GXV1 ;
      private int edtavManagerid_Visible ;
      private int edtavManagergamguid_Visible ;
      private int edtavManagerinitials_Visible ;
      private int subGridsdt_managerss_Islastpage ;
      private int GRIDSDT_MANAGERSS_nGridOutOfScope ;
      private int nGXsfl_44_fel_idx=1 ;
      private int nGXsfl_44_bak_idx=1 ;
      private int AV52GXV10 ;
      private int AV53GXV11 ;
      private int AV54GXV12 ;
      private int idxLst ;
      private int subGridsdt_managerss_Backcolor ;
      private int subGridsdt_managerss_Allbackcolor ;
      private int subGridsdt_managerss_Titlebackcolor ;
      private int subGridsdt_managerss_Selectedindex ;
      private int subGridsdt_managerss_Selectioncolor ;
      private int subGridsdt_managerss_Hoveringcolor ;
      private long GRIDSDT_MANAGERSS_nFirstRecordOnPage ;
      private long GRIDSDT_MANAGERSS_nCurrentRecord ;
      private long GRIDSDT_MANAGERSS_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_44_idx="0001" ;
      private string edtavSdt_managers__managerid_Internalname ;
      private string dynavSdt_managers__organisationid_Internalname ;
      private string edtavSdt_managers__managergivenname_Internalname ;
      private string edtavSdt_managers__managerlastname_Internalname ;
      private string edtavSdt_managers__managerinitials_Internalname ;
      private string edtavSdt_managers__manageremail_Internalname ;
      private string edtavSdt_managers__managerphone_Internalname ;
      private string cmbavSdt_managers__managergender_Internalname ;
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
      private string divUnnamedtable1_Internalname ;
      private string edtavManagergivenname_Internalname ;
      private string TempTags ;
      private string edtavManagergivenname_Jsonclick ;
      private string edtavManagerlastname_Internalname ;
      private string edtavManagerlastname_Jsonclick ;
      private string edtavManageremail_Internalname ;
      private string edtavManageremail_Jsonclick ;
      private string cmbavManagergender_Internalname ;
      private string cmbavManagergender_Jsonclick ;
      private string edtavManagerphone_Internalname ;
      private string AV25ManagerPhone ;
      private string edtavManagerphone_Jsonclick ;
      private string bttBtnuinsert_Internalname ;
      private string bttBtnuinsert_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGridsdt_managerss_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string bttBtnfinishwizard_Internalname ;
      private string bttBtnfinishwizard_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavManagerid_Internalname ;
      private string edtavManagerid_Jsonclick ;
      private string edtavManagergamguid_Internalname ;
      private string edtavManagergamguid_Jsonclick ;
      private string edtavManagerinitials_Internalname ;
      private string AV23ManagerInitials ;
      private string edtavManagerinitials_Jsonclick ;
      private string Gridsdt_managerss_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV38UDelete ;
      private string GXDecQS ;
      private string sGXsfl_44_fel_idx="0001" ;
      private string Gridsdt_managerss_empowerer_Gridinternalname ;
      private string sCtrlAV41WebSessionKey ;
      private string sCtrlAV33PreviousStep ;
      private string sCtrlAV11GoingBack ;
      private string subGridsdt_managerss_Class ;
      private string subGridsdt_managerss_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_managers__managerid_Jsonclick ;
      private string GXCCtl ;
      private string dynavSdt_managers__organisationid_Jsonclick ;
      private string edtavSdt_managers__managergivenname_Jsonclick ;
      private string edtavSdt_managers__managerlastname_Jsonclick ;
      private string edtavSdt_managers__managerinitials_Jsonclick ;
      private string edtavSdt_managers__manageremail_Jsonclick ;
      private string edtavSdt_managers__managerphone_Jsonclick ;
      private string cmbavSdt_managers__managergender_Jsonclick ;
      private string edtavUdelete_Jsonclick ;
      private string subGridsdt_managerss_Header ;
      private bool AV11GoingBack ;
      private bool wcpOAV11GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12HasValidationErrors ;
      private bool bGXsfl_44_Refreshing=false ;
      private bool AV5CheckRequiredFieldsResult ;
      private bool AV15isAlreadyExistingInGAM ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV14isAlreadyAdded ;
      private bool gx_BV44 ;
      private bool AV17isOrganisationInserted ;
      private bool AV16isManagerInserted ;
      private string AV41WebSessionKey ;
      private string AV33PreviousStep ;
      private string wcpOAV41WebSessionKey ;
      private string wcpOAV33PreviousStep ;
      private string AV21ManagerGivenName ;
      private string AV24ManagerLastName ;
      private string AV18ManagerEmail ;
      private string AV20ManagerGender ;
      private string AV19ManagerGAMGUID ;
      private Guid AV22ManagerId ;
      private GXWebGrid Gridsdt_managerssContainer ;
      private GXWebRow Gridsdt_managerssRow ;
      private GXWebColumn Gridsdt_managerssColumn ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucGridsdt_managerss_empowerer ;
      private GXWebForm Form ;
      private IGxSession AV40WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavManagergender ;
      private GXCombobox dynavSdt_managers__organisationid ;
      private GXCombobox cmbavSdt_managers__managergender ;
      private GXBaseCollection<SdtSDT_Managers_SDT_ManagersItem> AV35SDT_Managers ;
      private SdtWP_CreateOrganisationAndManagerData AV42WizardData ;
      private SdtTrn_Manager AV36Trn_Manager ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8ErrorMessages ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrors ;
      private SdtSDT_Managers_SDT_ManagersItem AV34SDT_Manager ;
      private SdtTrn_Organisation AV37Trn_Organisation ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Utils.SdtMessages_Message AV7Error ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] H004H2_A11OrganisationId ;
      private string[] H004H2_A13OrganisationName ;
      private Guid[] H004H3_A11OrganisationId ;
      private string[] H004H3_A13OrganisationName ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_createorganisationandmanagerstep2__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_createorganisationandmanagerstep2__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH004H2;
        prmH004H2 = new Object[] {
        };
        Object[] prmH004H3;
        prmH004H3 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H004H2", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H004H3", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H3,0, GxCacheFrequency.OFF ,true,false )
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
     }
  }

}

}