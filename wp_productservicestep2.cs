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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wp_productservicestep2 : GXWebComponent
   {
      public wp_productservicestep2( )
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

      public wp_productservicestep2( IGxContext context )
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
         this.AV48WebSessionKey = aP0_WebSessionKey;
         this.AV36PreviousStep = aP1_PreviousStep;
         this.AV18GoingBack = aP2_GoingBack;
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
         cmbavCalltoactiontype = new GXCombobox();
         dynavSdt_calltoaction__organisationid = new GXCombobox();
         cmbavSdt_calltoaction__calltoactiontype = new GXCombobox();
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
                  AV48WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV48WebSessionKey", AV48WebSessionKey);
                  AV36PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV36PreviousStep", AV36PreviousStep);
                  AV18GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV18GoingBack", AV18GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV48WebSessionKey,(string)AV36PreviousStep,(bool)AV18GoingBack});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdt_calltoactions") == 0 )
               {
                  gxnrGridsdt_calltoactions_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdt_calltoactions") == 0 )
               {
                  gxgrGridsdt_calltoactions_refresh_invoke( ) ;
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

      protected void gxnrGridsdt_calltoactions_newrow_invoke( )
      {
         nRC_GXsfl_73 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_73"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_73_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_73_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_73_idx = GetPar( "sGXsfl_73_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsdt_calltoactions_newrow( ) ;
         /* End function gxnrGridsdt_calltoactions_newrow_invoke */
      }

      protected void gxgrGridsdt_calltoactions_refresh_invoke( )
      {
         subGridsdt_calltoactions_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdt_calltoactions_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38SDT_CallToAction);
         AV22HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV38SDT_CallToAction, AV22HasValidationErrors, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridsdt_calltoactions_refresh_invoke */
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
            PA732( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdt_calltoaction__calltoactionid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionid_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               dynavSdt_calltoaction__organisationid.Enabled = 0;
               AssignProp(sPrefix, false, dynavSdt_calltoaction__organisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavSdt_calltoaction__organisationid.Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtavSdt_calltoaction__locationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__locationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__locationid_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtavSdt_calltoaction__productserviceid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__productserviceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__productserviceid_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtavSdt_calltoaction__calltoactionname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionname_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSdt_calltoaction__calltoactiontype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdt_calltoaction__calltoactiontype.Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionphone_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionurl_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__calltoactionemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__calltoactionemail_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__locationdynamicformid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__locationdynamicformid_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_calltoaction__wwpformreferencename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_calltoaction__wwpformreferencename_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtavCalltoactionvariable_Enabled = 0;
               AssignProp(sPrefix, false, edtavCalltoactionvariable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCalltoactionvariable_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtavUseractionedit_Enabled = 0;
               AssignProp(sPrefix, false, edtavUseractionedit_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUseractionedit_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtavUseractiondelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavUseractiondelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUseractiondelete_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               WS732( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Product Service Step2", "")) ;
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
            GXEncryptionTmp = "wp_productservicestep2.aspx"+UrlEncode(StringUtil.RTrim(AV48WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV36PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV18GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_productservicestep2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV22HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV22HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_calltoaction", AV38SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_calltoaction", AV38SDT_CallToAction);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_73", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_73), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLOCATIONDYNAMICFORMID_DATA", AV27LocationDynamicFormId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLOCATIONDYNAMICFORMID_DATA", AV27LocationDynamicFormId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV48WebSessionKey", wcpOAV48WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV36PreviousStep", wcpOAV36PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV18GoingBack", wcpOAV18GoingBack);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_CALLTOACTION", AV38SDT_CallToAction);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_CALLTOACTION", AV38SDT_CallToAction);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV22HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV22HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV48WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV49WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV49WizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vIMAGEFILE", AV51ImageFile);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV36PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV18GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get", StringUtil.RTrim( Combo_locationdynamicformid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedtext_get", StringUtil.RTrim( Combo_locationdynamicformid_Selectedtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get", StringUtil.RTrim( Combo_locationdynamicformid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedtext_get", StringUtil.RTrim( Combo_locationdynamicformid_Selectedtext_get));
      }

      protected void RenderHtmlCloseForm732( )
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
         return "WP_ProductServiceStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Product Service Step2", "") ;
      }

      protected void WB730( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_productservicestep2.aspx");
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Call to Action", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_ProductServiceStep2.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavCalltoactiontype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCalltoactiontype_Internalname, context.GetMessage( "Type", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCalltoactiontype, cmbavCalltoactiontype_Internalname, StringUtil.RTrim( AV9CallToActionType), 1, cmbavCalltoactiontype_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavCalltoactiontype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "", true, 0, "HLP_WP_ProductServiceStep2.htm");
            cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV9CallToActionType);
            AssignProp(sPrefix, false, cmbavCalltoactiontype_Internalname, "Values", (string)(cmbavCalltoactiontype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionname_Internalname, context.GetMessage( "Label", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionname_Internalname, AV7CallToActionName, StringUtil.RTrim( context.localUtil.Format( AV7CallToActionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProductServiceStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableurl_Internalname, divTableurl_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionurl_Internalname, context.GetMessage( "Url", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionurl_Internalname, AV10CallToActionUrl, StringUtil.RTrim( context.localUtil.Format( AV10CallToActionUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionurl_Enabled, 0, "text", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_ProductServiceStep2.htm");
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
            GxWebStd.gx_div_start( context, divTablephone_Internalname, divTablephone_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionphone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionphone_Internalname, context.GetMessage( "Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionphone_Internalname, StringUtil.RTrim( AV8CallToActionPhone), StringUtil.RTrim( context.localUtil.Format( AV8CallToActionPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionphone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionphone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_ProductServiceStep2.htm");
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
            GxWebStd.gx_div_start( context, divTableform_Internalname, divTableform_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlocationdynamicformid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_locationdynamicformid_Internalname, context.GetMessage( "Form", ""), "", "", lblTextblockcombo_locationdynamicformid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProductServiceStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_locationdynamicformid.SetProperty("Caption", Combo_locationdynamicformid_Caption);
            ucCombo_locationdynamicformid.SetProperty("Cls", Combo_locationdynamicformid_Cls);
            ucCombo_locationdynamicformid.SetProperty("EmptyItem", Combo_locationdynamicformid_Emptyitem);
            ucCombo_locationdynamicformid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
            ucCombo_locationdynamicformid.SetProperty("DropDownOptionsData", AV27LocationDynamicFormId_Data);
            ucCombo_locationdynamicformid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_locationdynamicformid_Internalname, sPrefix+"COMBO_LOCATIONDYNAMICFORMIDContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableemail_Internalname, divTableemail_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCalltoactionemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCalltoactionemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionemail_Internalname, AV5CallToActionEmail, StringUtil.RTrim( context.localUtil.Format( AV5CallToActionEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCalltoactionemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_ProductServiceStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseractionadd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(73), 2, 0)+","+"null"+");", bttBtnuseractionadd_Caption, bttBtnuseractionadd_Jsonclick, 5, context.GetMessage( "Add", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUSERACTIONADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ProductServiceStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridsdt_calltoactionsContainer.SetWrapped(nGXWrapped);
            StartGridControl73( ) ;
         }
         if ( wbEnd == 73 )
         {
            wbEnd = 0;
            nRC_GXsfl_73 = (int)(nGXsfl_73_idx-1);
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nEOF", GRIDSDT_CALLTOACTIONS_nEOF);
               Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
               AV56GXV1 = nGXsfl_73_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_calltoactionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_calltoactions", Gridsdt_calltoactionsContainer, subGridsdt_calltoactions_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData", Gridsdt_calltoactionsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData"+"V", Gridsdt_calltoactionsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_calltoactionsContainerData"+"V"+"\" value='"+Gridsdt_calltoactionsContainer.GridValuesHidden()+"'/>") ;
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
            ucBtnwizardprevious.SetProperty("BeforeIconClass", Btnwizardprevious_Beforeiconclass);
            ucBtnwizardprevious.SetProperty("Caption", Btnwizardprevious_Caption);
            ucBtnwizardprevious.SetProperty("Class", Btnwizardprevious_Class);
            ucBtnwizardprevious.Render(context, "wwp_iconbutton", Btnwizardprevious_Internalname, sPrefix+"BTNWIZARDPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardlastnext.SetProperty("TooltipText", Btnwizardlastnext_Tooltiptext);
            ucBtnwizardlastnext.SetProperty("AfterIconClass", Btnwizardlastnext_Aftericonclass);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationdynamicformid_Internalname, AV26LocationDynamicFormId.ToString(), AV26LocationDynamicFormId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationdynamicformid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLocationdynamicformid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProductServiceStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCalltoactionid_Internalname, AV6CallToActionId.ToString(), AV6CallToActionId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCalltoactionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCalltoactionid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProductServiceStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWwpformreferencename_Internalname, AV50WWPFormReferenceName, StringUtil.RTrim( context.localUtil.Format( AV50WWPFormReferenceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwpformreferencename_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwpformreferencename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProductServiceStep2.htm");
            /* User Defined Control */
            ucGridsdt_calltoactions_empowerer.Render(context, "wwp.gridempowerer", Gridsdt_calltoactions_empowerer_Internalname, sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 73 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nEOF", GRIDSDT_CALLTOACTIONS_nEOF);
                  Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
                  AV56GXV1 = nGXsfl_73_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_calltoactionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_calltoactions", Gridsdt_calltoactionsContainer, subGridsdt_calltoactions_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData", Gridsdt_calltoactionsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_calltoactionsContainerData"+"V", Gridsdt_calltoactionsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_calltoactionsContainerData"+"V"+"\" value='"+Gridsdt_calltoactionsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START732( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Product Service Step2", ""), 0) ;
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
               STRUP730( ) ;
            }
         }
      }

      protected void WS732( )
      {
         START732( ) ;
         EVT732( ) ;
      }

      protected void EVT732( )
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
                                 STRUP730( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP730( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_locationdynamicformid.Onoptionclicked */
                                    E11732 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP730( ) ;
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
                                          E12732 ();
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
                                 STRUP730( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E13732 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTIONADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP730( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserActionAdd' */
                                    E14732 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP730( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_CALLTOACTIONSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP730( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridsdt_calltoactions_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridsdt_calltoactions_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridsdt_calltoactions_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridsdt_calltoactions_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "GRIDSDT_CALLTOACTIONS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VUSERACTIONEDIT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VUSERACTIONDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VUSERACTIONEDIT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VUSERACTIONDELETE.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP730( ) ;
                              }
                              nGXsfl_73_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
                              SubsflControlProps_732( ) ;
                              AV56GXV1 = (int)(nGXsfl_73_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
                              if ( ( AV38SDT_CallToAction.Count >= AV56GXV1 ) && ( AV56GXV1 > 0 ) )
                              {
                                 AV38SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1));
                                 AV11CallToActionVariable = cgiGet( edtavCalltoactionvariable_Internalname);
                                 AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV11CallToActionVariable);
                                 AV46UserActionEdit = cgiGet( edtavUseractionedit_Internalname);
                                 AssignAttri(sPrefix, false, edtavUseractionedit_Internalname, AV46UserActionEdit);
                                 AV45UserActionDelete = cgiGet( edtavUseractiondelete_Internalname);
                                 AssignAttri(sPrefix, false, edtavUseractiondelete_Internalname, AV45UserActionDelete);
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
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E15732 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_CALLTOACTIONS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Gridsdt_calltoactions.Load */
                                          E16732 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUSERACTIONEDIT.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E17732 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUSERACTIONDELETE.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E18732 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP730( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_calltoaction__calltoactionid_Internalname;
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

      protected void WE732( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm732( ) ;
            }
         }
      }

      protected void PA732( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_productservicestep2.aspx")), "wp_productservicestep2.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_productservicestep2.aspx")))) ;
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
               GX_FocusControl = cmbavCalltoactiontype_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsdt_calltoactions_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_732( ) ;
         while ( nGXsfl_73_idx <= nRC_GXsfl_73 )
         {
            sendrow_732( ) ;
            nGXsfl_73_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_73_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_732( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsdt_calltoactionsContainer)) ;
         /* End function gxnrGridsdt_calltoactions_newrow */
      }

      protected void gxgrGridsdt_calltoactions_refresh( int subGridsdt_calltoactions_Rows ,
                                                        GXBaseCollection<SdtSDT_CallToAction_SDT_CallToActionItem> AV38SDT_CallToAction ,
                                                        bool AV22HasValidationErrors ,
                                                        string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSDT_CALLTOACTIONS_nCurrentRecord = 0;
         RF732( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridsdt_calltoactions_refresh */
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
         if ( cmbavCalltoactiontype.ItemCount > 0 )
         {
            AV9CallToActionType = cmbavCalltoactiontype.getValidValue(AV9CallToActionType);
            AssignAttri(sPrefix, false, "AV9CallToActionType", AV9CallToActionType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV9CallToActionType);
            AssignProp(sPrefix, false, cmbavCalltoactiontype_Internalname, "Values", cmbavCalltoactiontype.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF732( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         dynavSdt_calltoaction__organisationid.Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
         edtavUseractionedit_Enabled = 0;
         edtavUseractiondelete_Enabled = 0;
      }

      protected void RF732( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridsdt_calltoactionsContainer.ClearRows();
         }
         wbStart = 73;
         nGXsfl_73_idx = 1;
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_732( ) ;
         bGXsfl_73_Refreshing = true;
         Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
         Gridsdt_calltoactionsContainer.AddObjectProperty("CmpContext", sPrefix);
         Gridsdt_calltoactionsContainer.AddObjectProperty("InMasterPage", "false");
         Gridsdt_calltoactionsContainer.AddObjectProperty("Class", "WorkWith");
         Gridsdt_calltoactionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Backcolorstyle), 1, 0, ".", "")));
         Gridsdt_calltoactionsContainer.PageSize = subGridsdt_calltoactions_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_732( ) ;
            /* Execute user event: Gridsdt_calltoactions.Load */
            E16732 ();
            if ( ( subGridsdt_calltoactions_Islastpage == 0 ) && ( GRIDSDT_CALLTOACTIONS_nCurrentRecord > 0 ) && ( GRIDSDT_CALLTOACTIONS_nGridOutOfScope == 0 ) && ( nGXsfl_73_idx == 1 ) )
            {
               GRIDSDT_CALLTOACTIONS_nCurrentRecord = 0;
               GRIDSDT_CALLTOACTIONS_nGridOutOfScope = 1;
               subgridsdt_calltoactions_firstpage( ) ;
               /* Execute user event: Gridsdt_calltoactions.Load */
               E16732 ();
            }
            wbEnd = 73;
            WB730( ) ;
         }
         bGXsfl_73_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes732( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV22HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV22HasValidationErrors, context));
      }

      protected int subGridsdt_calltoactions_fnc_Pagecount( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( ((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nRecordCount/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nRecordCount/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridsdt_calltoactions_fnc_Recordcount( )
      {
         return AV38SDT_CallToAction.Count ;
      }

      protected int subGridsdt_calltoactions_fnc_Recordsperpage( )
      {
         if ( subGridsdt_calltoactions_Rows > 0 )
         {
            return subGridsdt_calltoactions_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdt_calltoactions_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage/ (decimal)(subGridsdt_calltoactions_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridsdt_calltoactions_firstpage( )
      {
         GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV38SDT_CallToAction, AV22HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_calltoactions_nextpage( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( ( GRIDSDT_CALLTOACTIONS_nRecordCount >= subGridsdt_calltoactions_fnc_Recordsperpage( ) ) && ( GRIDSDT_CALLTOACTIONS_nEOF == 0 ) )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage+subGridsdt_calltoactions_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridsdt_calltoactionsContainer.AddObjectProperty("GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV38SDT_CallToAction, AV22HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDT_CALLTOACTIONS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdt_calltoactions_previouspage( )
      {
         if ( GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage >= subGridsdt_calltoactions_fnc_Recordsperpage( ) )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage-subGridsdt_calltoactions_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV38SDT_CallToAction, AV22HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_calltoactions_lastpage( )
      {
         GRIDSDT_CALLTOACTIONS_nRecordCount = subGridsdt_calltoactions_fnc_Recordcount( );
         if ( GRIDSDT_CALLTOACTIONS_nRecordCount > subGridsdt_calltoactions_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nRecordCount-subGridsdt_calltoactions_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(GRIDSDT_CALLTOACTIONS_nRecordCount-((int)((GRIDSDT_CALLTOACTIONS_nRecordCount) % (subGridsdt_calltoactions_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV38SDT_CallToAction, AV22HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdt_calltoactions_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(subGridsdt_calltoactions_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV38SDT_CallToAction, AV22HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         dynavSdt_calltoaction__organisationid.Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
         edtavUseractionedit_Enabled = 0;
         edtavUseractiondelete_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP730( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15732 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_calltoaction"), AV38SDT_CallToAction);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vLOCATIONDYNAMICFORMID_DATA"), AV27LocationDynamicFormId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_CALLTOACTION"), AV38SDT_CallToAction);
            /* Read saved values. */
            nRC_GXsfl_73 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_73"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV48WebSessionKey = cgiGet( sPrefix+"wcpOAV48WebSessionKey");
            wcpOAV36PreviousStep = cgiGet( sPrefix+"wcpOAV36PreviousStep");
            wcpOAV18GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV18GoingBack"));
            GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSDT_CALLTOACTIONS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridsdt_calltoactions_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_CALLTOACTIONS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
            Combo_locationdynamicformid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedvalue_get");
            Combo_locationdynamicformid_Selectedtext_get = cgiGet( sPrefix+"COMBO_LOCATIONDYNAMICFORMID_Selectedtext_get");
            nRC_GXsfl_73 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_73"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_73_fel_idx = 0;
            while ( nGXsfl_73_fel_idx < nRC_GXsfl_73 )
            {
               nGXsfl_73_fel_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_73_fel_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_73_fel_idx+1);
               sGXsfl_73_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_732( ) ;
               AV56GXV1 = (int)(nGXsfl_73_fel_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
               if ( ( AV38SDT_CallToAction.Count >= AV56GXV1 ) && ( AV56GXV1 > 0 ) )
               {
                  AV38SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1));
                  AV11CallToActionVariable = cgiGet( edtavCalltoactionvariable_Internalname);
                  AV46UserActionEdit = cgiGet( edtavUseractionedit_Internalname);
                  AV45UserActionDelete = cgiGet( edtavUseractiondelete_Internalname);
               }
            }
            if ( nGXsfl_73_fel_idx == 0 )
            {
               nGXsfl_73_idx = 1;
               sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
               SubsflControlProps_732( ) ;
            }
            nGXsfl_73_fel_idx = 1;
            /* Read variables values. */
            cmbavCalltoactiontype.Name = cmbavCalltoactiontype_Internalname;
            cmbavCalltoactiontype.CurrentValue = cgiGet( cmbavCalltoactiontype_Internalname);
            AV9CallToActionType = cgiGet( cmbavCalltoactiontype_Internalname);
            AssignAttri(sPrefix, false, "AV9CallToActionType", AV9CallToActionType);
            AV7CallToActionName = cgiGet( edtavCalltoactionname_Internalname);
            AssignAttri(sPrefix, false, "AV7CallToActionName", AV7CallToActionName);
            AV10CallToActionUrl = cgiGet( edtavCalltoactionurl_Internalname);
            AssignAttri(sPrefix, false, "AV10CallToActionUrl", AV10CallToActionUrl);
            AV8CallToActionPhone = cgiGet( edtavCalltoactionphone_Internalname);
            AssignAttri(sPrefix, false, "AV8CallToActionPhone", AV8CallToActionPhone);
            AV5CallToActionEmail = cgiGet( edtavCalltoactionemail_Internalname);
            AssignAttri(sPrefix, false, "AV5CallToActionEmail", AV5CallToActionEmail);
            if ( StringUtil.StrCmp(cgiGet( edtavLocationdynamicformid_Internalname), "") == 0 )
            {
               AV26LocationDynamicFormId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV26LocationDynamicFormId", AV26LocationDynamicFormId.ToString());
            }
            else
            {
               try
               {
                  AV26LocationDynamicFormId = StringUtil.StrToGuid( cgiGet( edtavLocationdynamicformid_Internalname));
                  AssignAttri(sPrefix, false, "AV26LocationDynamicFormId", AV26LocationDynamicFormId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vLOCATIONDYNAMICFORMID");
                  GX_FocusControl = edtavLocationdynamicformid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavCalltoactionid_Internalname), "") == 0 )
            {
               AV6CallToActionId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV6CallToActionId", AV6CallToActionId.ToString());
            }
            else
            {
               try
               {
                  AV6CallToActionId = StringUtil.StrToGuid( cgiGet( edtavCalltoactionid_Internalname));
                  AssignAttri(sPrefix, false, "AV6CallToActionId", AV6CallToActionId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCALLTOACTIONID");
                  GX_FocusControl = edtavCalltoactionid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV50WWPFormReferenceName = cgiGet( edtavWwpformreferencename_Internalname);
            AssignAttri(sPrefix, false, "AV50WWPFormReferenceName", AV50WWPFormReferenceName);
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
         E15732 ();
         if (returnInSub) return;
      }

      protected void E15732( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavLocationdynamicformid_Visible = 0;
         AssignProp(sPrefix, false, edtavLocationdynamicformid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLocationdynamicformid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOLOCATIONDYNAMICFORMID' */
         S122 ();
         if (returnInSub) return;
         edtavCalltoactionid_Visible = 0;
         AssignProp(sPrefix, false, edtavCalltoactionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCalltoactionid_Visible), 5, 0), true);
         edtavWwpformreferencename_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpformreferencename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpformreferencename_Visible), 5, 0), true);
         Gridsdt_calltoactions_empowerer_Gridinternalname = subGridsdt_calltoactions_Internalname;
         ucGridsdt_calltoactions_empowerer.SendProperty(context, sPrefix, false, Gridsdt_calltoactions_empowerer_Internalname, "GridInternalName", Gridsdt_calltoactions_empowerer_Gridinternalname);
         subGridsdt_calltoactions_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Rows), 6, 0, ".", "")));
         divTableurl_Visible = 0;
         AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
         divTableemail_Visible = 0;
         AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
         divTableform_Visible = 0;
         AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
         AV54IsEditing = false;
      }

      private void E16732( )
      {
         /* Gridsdt_calltoactions_Load Routine */
         returnInSub = false;
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV38SDT_CallToAction.Count )
         {
            AV38SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionphone)) )
            {
               AV11CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionphone;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV11CallToActionVariable);
            }
            else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionurl)) )
            {
               AV11CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionurl;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV11CallToActionVariable);
            }
            else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionemail)) )
            {
               AV11CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionemail;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV11CallToActionVariable);
            }
            else if ( ! (Guid.Empty==((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Locationdynamicformid) )
            {
               AV11CallToActionVariable = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Wwpformreferencename;
               AssignAttri(sPrefix, false, edtavCalltoactionvariable_Internalname, AV11CallToActionVariable);
            }
            AV46UserActionEdit = "<i class=\"fas fa-pen\"></i>";
            AssignAttri(sPrefix, false, edtavUseractionedit_Internalname, AV46UserActionEdit);
            AV45UserActionDelete = "<i class=\"fas fa-xmark\"></i>";
            AssignAttri(sPrefix, false, edtavUseractiondelete_Internalname, AV45UserActionDelete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 73;
            }
            if ( ( subGridsdt_calltoactions_Islastpage == 1 ) || ( subGridsdt_calltoactions_Rows == 0 ) || ( ( GRIDSDT_CALLTOACTIONS_nCurrentRecord >= GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage ) && ( GRIDSDT_CALLTOACTIONS_nCurrentRecord < GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage + subGridsdt_calltoactions_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_732( ) ;
            }
            GRIDSDT_CALLTOACTIONS_nEOF = (short)(((GRIDSDT_CALLTOACTIONS_nCurrentRecord<GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage+subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_CALLTOACTIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_CALLTOACTIONS_nEOF), 1, 0, ".", "")));
            GRIDSDT_CALLTOACTIONS_nCurrentRecord = (long)(GRIDSDT_CALLTOACTIONS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_73_Refreshing )
            {
               DoAjaxLoad(73, Gridsdt_calltoactionsRow);
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12732 ();
         if (returnInSub) return;
      }

      protected void E12732( )
      {
         AV56GXV1 = (int)(nGXsfl_73_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( ( AV56GXV1 > 0 ) && ( AV38SDT_CallToAction.Count >= AV56GXV1 ) )
         {
            AV38SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV22HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
            AV47WebSession.Remove(AV48WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49WizardData", AV49WizardData);
      }

      protected void E13732( )
      {
         AV56GXV1 = (int)(nGXsfl_73_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( ( AV56GXV1 > 0 ) && ( AV38SDT_CallToAction.Count >= AV56GXV1 ) )
         {
            AV38SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1));
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
         GXEncryptionTmp = "wp_productservice.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wp_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV49WizardData", AV49WizardData);
      }

      protected void E14732( )
      {
         AV56GXV1 = (int)(nGXsfl_73_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( ( AV56GXV1 > 0 ) && ( AV38SDT_CallToAction.Count >= AV56GXV1 ) )
         {
            AV38SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1));
         }
         /* 'DoUserActionAdd' Routine */
         returnInSub = false;
         AV39SDT_CallToActionItem = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
         AV39SDT_CallToActionItem.gxTpr_Calltoactionid = Guid.NewGuid( );
         AV39SDT_CallToActionItem.gxTpr_Calltoactionname = AV7CallToActionName;
         AV39SDT_CallToActionItem.gxTpr_Calltoactionemail = AV5CallToActionEmail;
         AV39SDT_CallToActionItem.gxTpr_Calltoactionphone = AV8CallToActionPhone;
         AV39SDT_CallToActionItem.gxTpr_Calltoactiontype = AV9CallToActionType;
         AV39SDT_CallToActionItem.gxTpr_Calltoactionurl = AV10CallToActionUrl;
         AV39SDT_CallToActionItem.gxTpr_Locationdynamicformid = AV26LocationDynamicFormId;
         AV39SDT_CallToActionItem.gxTpr_Wwpformreferencename = AV50WWPFormReferenceName;
         AV39SDT_CallToActionItem.gxTpr_Productserviceid = AV49WizardData.gxTpr_Step1.gxTpr_Productserviceid;
         AV38SDT_CallToAction.Add(AV39SDT_CallToActionItem, 0);
         gx_BV73 = true;
         divTablephone_Visible = 1;
         AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
         divTableurl_Visible = 0;
         AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
         divTableemail_Visible = 0;
         AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
         divTableform_Visible = 0;
         AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
         AV7CallToActionName = "";
         AssignAttri(sPrefix, false, "AV7CallToActionName", AV7CallToActionName);
         AV5CallToActionEmail = "";
         AssignAttri(sPrefix, false, "AV5CallToActionEmail", AV5CallToActionEmail);
         AV8CallToActionPhone = "";
         AssignAttri(sPrefix, false, "AV8CallToActionPhone", AV8CallToActionPhone);
         AV10CallToActionUrl = "";
         AssignAttri(sPrefix, false, "AV10CallToActionUrl", AV10CallToActionUrl);
         AV26LocationDynamicFormId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV26LocationDynamicFormId", AV26LocationDynamicFormId.ToString());
         AV9CallToActionType = "";
         AssignAttri(sPrefix, false, "AV9CallToActionType", AV9CallToActionType);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38SDT_CallToAction", AV38SDT_CallToAction);
         nGXsfl_73_bak_idx = nGXsfl_73_idx;
         gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV38SDT_CallToAction, AV22HasValidationErrors, sPrefix) ;
         nGXsfl_73_idx = nGXsfl_73_bak_idx;
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_732( ) ;
         cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV9CallToActionType);
         AssignProp(sPrefix, false, cmbavCalltoactiontype_Internalname, "Values", cmbavCalltoactiontype.ToJavascriptSource(), true);
      }

      protected void E11732( )
      {
         /* Combo_locationdynamicformid_Onoptionclicked Routine */
         returnInSub = false;
         AV26LocationDynamicFormId = StringUtil.StrToGuid( Combo_locationdynamicformid_Selectedvalue_get);
         AssignAttri(sPrefix, false, "AV26LocationDynamicFormId", AV26LocationDynamicFormId.ToString());
         AV50WWPFormReferenceName = Combo_locationdynamicformid_Selectedtext_get;
         AssignAttri(sPrefix, false, "AV50WWPFormReferenceName", AV50WWPFormReferenceName);
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV49WizardData.FromJSonString(AV47WebSession.Get(AV48WebSessionKey), null);
         AV6CallToActionId = AV49WizardData.gxTpr_Step2.gxTpr_Calltoactionid;
         AssignAttri(sPrefix, false, "AV6CallToActionId", AV6CallToActionId.ToString());
         AV9CallToActionType = AV49WizardData.gxTpr_Step2.gxTpr_Calltoactiontype;
         AssignAttri(sPrefix, false, "AV9CallToActionType", AV9CallToActionType);
         AV7CallToActionName = AV49WizardData.gxTpr_Step2.gxTpr_Calltoactionname;
         AssignAttri(sPrefix, false, "AV7CallToActionName", AV7CallToActionName);
         AV50WWPFormReferenceName = AV49WizardData.gxTpr_Step2.gxTpr_Wwpformreferencename;
         AssignAttri(sPrefix, false, "AV50WWPFormReferenceName", AV50WWPFormReferenceName);
         AV5CallToActionEmail = AV49WizardData.gxTpr_Step2.gxTpr_Calltoactionemail;
         AssignAttri(sPrefix, false, "AV5CallToActionEmail", AV5CallToActionEmail);
         AV26LocationDynamicFormId = AV49WizardData.gxTpr_Step2.gxTpr_Locationdynamicformid;
         AssignAttri(sPrefix, false, "AV26LocationDynamicFormId", AV26LocationDynamicFormId.ToString());
         AV8CallToActionPhone = AV49WizardData.gxTpr_Step2.gxTpr_Calltoactionphone;
         AssignAttri(sPrefix, false, "AV8CallToActionPhone", AV8CallToActionPhone);
         AV10CallToActionUrl = AV49WizardData.gxTpr_Step2.gxTpr_Calltoactionurl;
         AssignAttri(sPrefix, false, "AV10CallToActionUrl", AV10CallToActionUrl);
         AV38SDT_CallToAction = AV49WizardData.gxTpr_Step2.gxTpr_Sdt_calltoaction;
         gx_BV73 = true;
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV49WizardData.FromJSonString(AV47WebSession.Get(AV48WebSessionKey), null);
         AV49WizardData.gxTpr_Step2.gxTpr_Calltoactionid = AV6CallToActionId;
         AV49WizardData.gxTpr_Step2.gxTpr_Calltoactiontype = AV9CallToActionType;
         AV49WizardData.gxTpr_Step2.gxTpr_Calltoactionname = AV7CallToActionName;
         AV49WizardData.gxTpr_Step2.gxTpr_Wwpformreferencename = AV50WWPFormReferenceName;
         AV49WizardData.gxTpr_Step2.gxTpr_Calltoactionemail = AV5CallToActionEmail;
         AV49WizardData.gxTpr_Step2.gxTpr_Locationdynamicformid = AV26LocationDynamicFormId;
         AV49WizardData.gxTpr_Step2.gxTpr_Calltoactionphone = AV8CallToActionPhone;
         AV49WizardData.gxTpr_Step2.gxTpr_Calltoactionurl = AV10CallToActionUrl;
         AV49WizardData.gxTpr_Step2.gxTpr_Sdt_calltoaction = AV38SDT_CallToAction;
         AV47WebSession.Set(AV48WebSessionKey, AV49WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49WizardData.gxTpr_Step1.gxTpr_Productserviceimagevar)) )
         {
            AV51ImageFile=context.FileFromBase64( AV49WizardData.gxTpr_Step1.gxTpr_Productserviceimagevar) ;
         }
         else
         {
         }
         AV44Trn_ProductService = new SdtTrn_ProductService(context);
         AV44Trn_ProductService.gxTpr_Productserviceid = AV49WizardData.gxTpr_Step1.gxTpr_Productserviceid;
         AV44Trn_ProductService.gxTpr_Productservicename = AV49WizardData.gxTpr_Step1.gxTpr_Productservicename;
         AV44Trn_ProductService.gxTpr_Productservicedescription = AV49WizardData.gxTpr_Step1.gxTpr_Productservicedescription;
         AV44Trn_ProductService.gxTpr_Productservicetilename = AV49WizardData.gxTpr_Step1.gxTpr_Productservicetilename;
         AV44Trn_ProductService.gxTpr_Productserviceimage = AV51ImageFile;
         AV44Trn_ProductService.gxTpr_Productserviceimage_gxi = GXDbFile.GetUriFromFile( "", "", AV51ImageFile);
         if ( (Guid.Empty==AV49WizardData.gxTpr_Step1.gxTpr_Supplieragbid) )
         {
            AV44Trn_ProductService.gxTv_SdtTrn_ProductService_Supplieragbid_SetNull();
         }
         else
         {
            AV44Trn_ProductService.gxTpr_Supplieragbid = AV49WizardData.gxTpr_Step1.gxTpr_Supplieragbid;
         }
         if ( (Guid.Empty==AV49WizardData.gxTpr_Step1.gxTpr_Suppliergenid) )
         {
            AV44Trn_ProductService.gxTv_SdtTrn_ProductService_Suppliergenid_SetNull();
         }
         else
         {
            AV44Trn_ProductService.gxTpr_Suppliergenid = AV49WizardData.gxTpr_Step1.gxTpr_Suppliergenid;
         }
         AV44Trn_ProductService.Save();
         if ( AV44Trn_ProductService.Success() )
         {
            context.CommitDataStores("wp_productservicestep2",pr_default);
            AV68GXV13 = 1;
            while ( AV68GXV13 <= AV38SDT_CallToAction.Count )
            {
               AV39SDT_CallToActionItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV68GXV13));
               AV42Trn_CallToAction = new SdtTrn_CallToAction(context);
               AV42Trn_CallToAction.gxTpr_Calltoactionid = AV39SDT_CallToActionItem.gxTpr_Calltoactionid;
               AV42Trn_CallToAction.gxTpr_Calltoactionname = AV39SDT_CallToActionItem.gxTpr_Calltoactionname;
               AV42Trn_CallToAction.gxTpr_Calltoactiontype = AV39SDT_CallToActionItem.gxTpr_Calltoactiontype;
               AV42Trn_CallToAction.gxTpr_Calltoactionemail = AV39SDT_CallToActionItem.gxTpr_Calltoactionemail;
               AV42Trn_CallToAction.gxTpr_Calltoactionphone = AV39SDT_CallToActionItem.gxTpr_Calltoactionphone;
               AV42Trn_CallToAction.gxTpr_Calltoactionurl = AV39SDT_CallToActionItem.gxTpr_Calltoactionurl;
               if ( (Guid.Empty==AV39SDT_CallToActionItem.gxTpr_Locationdynamicformid) )
               {
                  AV42Trn_CallToAction.gxTv_SdtTrn_CallToAction_Locationdynamicformid_SetNull();
               }
               else
               {
                  AV42Trn_CallToAction.gxTpr_Locationdynamicformid = AV39SDT_CallToActionItem.gxTpr_Locationdynamicformid;
               }
               AV42Trn_CallToAction.gxTpr_Productserviceid = AV39SDT_CallToActionItem.gxTpr_Productserviceid;
               AV42Trn_CallToAction.Save();
               if ( ! AV42Trn_CallToAction.Success() )
               {
                  AV70GXV15 = 1;
                  AV69GXV14 = AV42Trn_CallToAction.GetMessages();
                  while ( AV70GXV15 <= AV69GXV14.Count )
                  {
                     AV32Message = ((GeneXus.Utils.SdtMessages_Message)AV69GXV14.Item(AV70GXV15));
                     GX_msglist.addItem(AV32Message.gxTpr_Description);
                     AV70GXV15 = (int)(AV70GXV15+1);
                  }
               }
               AV68GXV13 = (int)(AV68GXV13+1);
            }
            context.CommitDataStores("wp_productservicestep2",pr_default);
            CallWebObject(formatLink("trn_productserviceww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV72GXV17 = 1;
            AV71GXV16 = AV44Trn_ProductService.GetMessages();
            while ( AV72GXV17 <= AV71GXV16.Count )
            {
               AV32Message = ((GeneXus.Utils.SdtMessages_Message)AV71GXV16.Item(AV72GXV17));
               GX_msglist.addItem(AV32Message.gxTpr_Description);
               AV72GXV17 = (int)(AV72GXV17+1);
            }
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOLOCATIONDYNAMICFORMID' Routine */
         returnInSub = false;
         AV74GXV19 = 1;
         GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem2 = AV73GXV18;
         new dp_locationdynamicform(context ).execute( out  GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem2) ;
         AV73GXV18 = GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem2;
         while ( AV74GXV19 <= AV73GXV18.Count )
         {
            AV28LocationDynamicFormId_DPItem = ((SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem)AV73GXV18.Item(AV74GXV19));
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( AV28LocationDynamicFormId_DPItem.gxTpr_Locationdynamicformid.ToString());
            AV12Combo_DataItem.gxTpr_Title = AV28LocationDynamicFormId_DPItem.gxTpr_Wwpformreferencename;
            AV27LocationDynamicFormId_Data.Add(AV12Combo_DataItem, 0);
            AV74GXV19 = (int)(AV74GXV19+1);
         }
         AV27LocationDynamicFormId_Data.Sort("Title");
         Combo_locationdynamicformid_Selectedvalue_set = ((Guid.Empty==AV26LocationDynamicFormId) ? "" : StringUtil.Trim( AV26LocationDynamicFormId.ToString()));
         ucCombo_locationdynamicformid.SendProperty(context, sPrefix, false, Combo_locationdynamicformid_Internalname, "SelectedValue_set", Combo_locationdynamicformid_Selectedvalue_set);
      }

      protected void E17732( )
      {
         AV56GXV1 = (int)(nGXsfl_73_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( ( AV56GXV1 > 0 ) && ( AV38SDT_CallToAction.Count >= AV56GXV1 ) )
         {
            AV38SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1));
         }
         /* Useractionedit_Click Routine */
         returnInSub = false;
         AV53IndexToEdit = (short)(AV38SDT_CallToAction.IndexOf(((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem))));
         AV54IsEditing = true;
         AV6CallToActionId = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionid;
         AssignAttri(sPrefix, false, "AV6CallToActionId", AV6CallToActionId.ToString());
         AV7CallToActionName = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionname;
         AssignAttri(sPrefix, false, "AV7CallToActionName", AV7CallToActionName);
         AV9CallToActionType = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Calltoactiontype;
         AssignAttri(sPrefix, false, "AV9CallToActionType", AV9CallToActionType);
         AV10CallToActionUrl = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionurl;
         AssignAttri(sPrefix, false, "AV10CallToActionUrl", AV10CallToActionUrl);
         AV5CallToActionEmail = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Calltoactionemail;
         AssignAttri(sPrefix, false, "AV5CallToActionEmail", AV5CallToActionEmail);
         AV26LocationDynamicFormId = ((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem)).gxTpr_Locationdynamicformid;
         AssignAttri(sPrefix, false, "AV26LocationDynamicFormId", AV26LocationDynamicFormId.ToString());
         if ( StringUtil.StrCmp(AV9CallToActionType, "Phone") == 0 )
         {
            divTableurl_Visible = 0;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            divTableemail_Visible = 0;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            divTableform_Visible = 0;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            divTablephone_Visible = 1;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            AV10CallToActionUrl = "";
            AssignAttri(sPrefix, false, "AV10CallToActionUrl", AV10CallToActionUrl);
            AV5CallToActionEmail = "";
            AssignAttri(sPrefix, false, "AV5CallToActionEmail", AV5CallToActionEmail);
            AV26LocationDynamicFormId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV26LocationDynamicFormId", AV26LocationDynamicFormId.ToString());
            AV50WWPFormReferenceName = "";
            AssignAttri(sPrefix, false, "AV50WWPFormReferenceName", AV50WWPFormReferenceName);
         }
         else if ( StringUtil.StrCmp(AV9CallToActionType, "Email") == 0 )
         {
            divTableurl_Visible = 0;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            divTablephone_Visible = 0;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            divTableform_Visible = 0;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            divTableemail_Visible = 1;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            AV10CallToActionUrl = "";
            AssignAttri(sPrefix, false, "AV10CallToActionUrl", AV10CallToActionUrl);
            AV8CallToActionPhone = "";
            AssignAttri(sPrefix, false, "AV8CallToActionPhone", AV8CallToActionPhone);
            AV26LocationDynamicFormId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV26LocationDynamicFormId", AV26LocationDynamicFormId.ToString());
            AV50WWPFormReferenceName = "";
            AssignAttri(sPrefix, false, "AV50WWPFormReferenceName", AV50WWPFormReferenceName);
         }
         else if ( StringUtil.StrCmp(AV9CallToActionType, "Form") == 0 )
         {
            divTableurl_Visible = 0;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            divTablephone_Visible = 0;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            divTableemail_Visible = 0;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            divTableform_Visible = 1;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            AV10CallToActionUrl = "";
            AssignAttri(sPrefix, false, "AV10CallToActionUrl", AV10CallToActionUrl);
            AV8CallToActionPhone = "";
            AssignAttri(sPrefix, false, "AV8CallToActionPhone", AV8CallToActionPhone);
            AV5CallToActionEmail = "";
            AssignAttri(sPrefix, false, "AV5CallToActionEmail", AV5CallToActionEmail);
         }
         else if ( StringUtil.StrCmp(AV9CallToActionType, "SiteUrl") == 0 )
         {
            divTablephone_Visible = 0;
            AssignProp(sPrefix, false, divTablephone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablephone_Visible), 5, 0), true);
            divTableemail_Visible = 0;
            AssignProp(sPrefix, false, divTableemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableemail_Visible), 5, 0), true);
            divTableform_Visible = 0;
            AssignProp(sPrefix, false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
            divTableurl_Visible = 1;
            AssignProp(sPrefix, false, divTableurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableurl_Visible), 5, 0), true);
            AV10CallToActionUrl = "";
            AssignAttri(sPrefix, false, "AV10CallToActionUrl", AV10CallToActionUrl);
            AV8CallToActionPhone = "";
            AssignAttri(sPrefix, false, "AV8CallToActionPhone", AV8CallToActionPhone);
            AV26LocationDynamicFormId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV26LocationDynamicFormId", AV26LocationDynamicFormId.ToString());
            AV50WWPFormReferenceName = "";
            AssignAttri(sPrefix, false, "AV50WWPFormReferenceName", AV50WWPFormReferenceName);
         }
         bttBtnuseractionadd_Caption = context.GetMessage( "Save", "");
         AssignProp(sPrefix, false, bttBtnuseractionadd_Internalname, "Caption", bttBtnuseractionadd_Caption, true);
         /*  Sending Event outputs  */
         cmbavCalltoactiontype.CurrentValue = StringUtil.RTrim( AV9CallToActionType);
         AssignProp(sPrefix, false, cmbavCalltoactiontype_Internalname, "Values", cmbavCalltoactiontype.ToJavascriptSource(), true);
      }

      protected void E18732( )
      {
         AV56GXV1 = (int)(nGXsfl_73_idx+GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage);
         if ( ( AV56GXV1 > 0 ) && ( AV38SDT_CallToAction.Count >= AV56GXV1 ) )
         {
            AV38SDT_CallToAction.CurrentItem = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1));
         }
         /* Useractiondelete_Click Routine */
         returnInSub = false;
         AV38SDT_CallToAction.RemoveItem(AV38SDT_CallToAction.IndexOf(((SdtSDT_CallToAction_SDT_CallToActionItem)(AV38SDT_CallToAction.CurrentItem))));
         gx_BV73 = true;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38SDT_CallToAction", AV38SDT_CallToAction);
         nGXsfl_73_bak_idx = nGXsfl_73_idx;
         gxgrGridsdt_calltoactions_refresh( subGridsdt_calltoactions_Rows, AV38SDT_CallToAction, AV22HasValidationErrors, sPrefix) ;
         nGXsfl_73_idx = nGXsfl_73_bak_idx;
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_732( ) ;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV48WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV48WebSessionKey", AV48WebSessionKey);
         AV36PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV36PreviousStep", AV36PreviousStep);
         AV18GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV18GoingBack", AV18GoingBack);
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
         PA732( ) ;
         WS732( ) ;
         WE732( ) ;
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
         sCtrlAV48WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV36PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV18GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA732( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_productservicestep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA732( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV48WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV48WebSessionKey", AV48WebSessionKey);
            AV36PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV36PreviousStep", AV36PreviousStep);
            AV18GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV18GoingBack", AV18GoingBack);
         }
         wcpOAV48WebSessionKey = cgiGet( sPrefix+"wcpOAV48WebSessionKey");
         wcpOAV36PreviousStep = cgiGet( sPrefix+"wcpOAV36PreviousStep");
         wcpOAV18GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV18GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV48WebSessionKey, wcpOAV48WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV36PreviousStep, wcpOAV36PreviousStep) != 0 ) || ( AV18GoingBack != wcpOAV18GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV48WebSessionKey = AV48WebSessionKey;
         wcpOAV36PreviousStep = AV36PreviousStep;
         wcpOAV18GoingBack = AV18GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV48WebSessionKey = cgiGet( sPrefix+"AV48WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV48WebSessionKey) > 0 )
         {
            AV48WebSessionKey = cgiGet( sCtrlAV48WebSessionKey);
            AssignAttri(sPrefix, false, "AV48WebSessionKey", AV48WebSessionKey);
         }
         else
         {
            AV48WebSessionKey = cgiGet( sPrefix+"AV48WebSessionKey_PARM");
         }
         sCtrlAV36PreviousStep = cgiGet( sPrefix+"AV36PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV36PreviousStep) > 0 )
         {
            AV36PreviousStep = cgiGet( sCtrlAV36PreviousStep);
            AssignAttri(sPrefix, false, "AV36PreviousStep", AV36PreviousStep);
         }
         else
         {
            AV36PreviousStep = cgiGet( sPrefix+"AV36PreviousStep_PARM");
         }
         sCtrlAV18GoingBack = cgiGet( sPrefix+"AV18GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV18GoingBack) > 0 )
         {
            AV18GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV18GoingBack));
            AssignAttri(sPrefix, false, "AV18GoingBack", AV18GoingBack);
         }
         else
         {
            AV18GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV18GoingBack_PARM"));
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
         PA732( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS732( ) ;
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
         WS732( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV48WebSessionKey_PARM", AV48WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV48WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV48WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV48WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV36PreviousStep_PARM", AV36PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV36PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV36PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV36PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV18GoingBack_PARM", StringUtil.BoolToStr( AV18GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV18GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV18GoingBack_CTRL", StringUtil.RTrim( sCtrlAV18GoingBack));
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
         WE732( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024101617505246", true, true);
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
         context.AddJavascriptSource("wp_productservicestep2.js", "?2024101617505246", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_732( )
      {
         edtavSdt_calltoaction__calltoactionid_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONID_"+sGXsfl_73_idx;
         dynavSdt_calltoaction__organisationid_Internalname = sPrefix+"SDT_CALLTOACTION__ORGANISATIONID_"+sGXsfl_73_idx;
         edtavSdt_calltoaction__locationid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONID_"+sGXsfl_73_idx;
         edtavSdt_calltoaction__productserviceid_Internalname = sPrefix+"SDT_CALLTOACTION__PRODUCTSERVICEID_"+sGXsfl_73_idx;
         edtavSdt_calltoaction__calltoactionname_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONNAME_"+sGXsfl_73_idx;
         cmbavSdt_calltoaction__calltoactiontype_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONTYPE_"+sGXsfl_73_idx;
         edtavSdt_calltoaction__calltoactionphone_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONE_"+sGXsfl_73_idx;
         edtavSdt_calltoaction__calltoactionurl_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONURL_"+sGXsfl_73_idx;
         edtavSdt_calltoaction__calltoactionemail_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONEMAIL_"+sGXsfl_73_idx;
         edtavSdt_calltoaction__locationdynamicformid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONDYNAMICFORMID_"+sGXsfl_73_idx;
         edtavSdt_calltoaction__wwpformreferencename_Internalname = sPrefix+"SDT_CALLTOACTION__WWPFORMREFERENCENAME_"+sGXsfl_73_idx;
         edtavCalltoactionvariable_Internalname = sPrefix+"vCALLTOACTIONVARIABLE_"+sGXsfl_73_idx;
         edtavUseractionedit_Internalname = sPrefix+"vUSERACTIONEDIT_"+sGXsfl_73_idx;
         edtavUseractiondelete_Internalname = sPrefix+"vUSERACTIONDELETE_"+sGXsfl_73_idx;
      }

      protected void SubsflControlProps_fel_732( )
      {
         edtavSdt_calltoaction__calltoactionid_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONID_"+sGXsfl_73_fel_idx;
         dynavSdt_calltoaction__organisationid_Internalname = sPrefix+"SDT_CALLTOACTION__ORGANISATIONID_"+sGXsfl_73_fel_idx;
         edtavSdt_calltoaction__locationid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONID_"+sGXsfl_73_fel_idx;
         edtavSdt_calltoaction__productserviceid_Internalname = sPrefix+"SDT_CALLTOACTION__PRODUCTSERVICEID_"+sGXsfl_73_fel_idx;
         edtavSdt_calltoaction__calltoactionname_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONNAME_"+sGXsfl_73_fel_idx;
         cmbavSdt_calltoaction__calltoactiontype_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONTYPE_"+sGXsfl_73_fel_idx;
         edtavSdt_calltoaction__calltoactionphone_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONE_"+sGXsfl_73_fel_idx;
         edtavSdt_calltoaction__calltoactionurl_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONURL_"+sGXsfl_73_fel_idx;
         edtavSdt_calltoaction__calltoactionemail_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONEMAIL_"+sGXsfl_73_fel_idx;
         edtavSdt_calltoaction__locationdynamicformid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONDYNAMICFORMID_"+sGXsfl_73_fel_idx;
         edtavSdt_calltoaction__wwpformreferencename_Internalname = sPrefix+"SDT_CALLTOACTION__WWPFORMREFERENCENAME_"+sGXsfl_73_fel_idx;
         edtavCalltoactionvariable_Internalname = sPrefix+"vCALLTOACTIONVARIABLE_"+sGXsfl_73_fel_idx;
         edtavUseractionedit_Internalname = sPrefix+"vUSERACTIONEDIT_"+sGXsfl_73_fel_idx;
         edtavUseractiondelete_Internalname = sPrefix+"vUSERACTIONDELETE_"+sGXsfl_73_fel_idx;
      }

      protected void sendrow_732( )
      {
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_732( ) ;
         WB730( ) ;
         if ( ( subGridsdt_calltoactions_Rows * 1 == 0 ) || ( nGXsfl_73_idx <= subGridsdt_calltoactions_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridsdt_calltoactionsRow = GXWebRow.GetNew(context,Gridsdt_calltoactionsContainer);
            if ( subGridsdt_calltoactions_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
               }
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 0;
               subGridsdt_calltoactions_Backcolor = subGridsdt_calltoactions_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Uniform";
               }
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
               }
               subGridsdt_calltoactions_Backcolor = (int)(0x0);
            }
            else if ( subGridsdt_calltoactions_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdt_calltoactions_Backstyle = 1;
               if ( ((int)((nGXsfl_73_idx) % (2))) == 0 )
               {
                  subGridsdt_calltoactions_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Even";
                  }
               }
               else
               {
                  subGridsdt_calltoactions_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_calltoactions_Class, "") != 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Odd";
                  }
               }
            }
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_73_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactionid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactionid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)73,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( dynavSdt_calltoaction__organisationid.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_CALLTOACTION__ORGANISATIONID_" + sGXsfl_73_idx;
               dynavSdt_calltoaction__organisationid.Name = GXCCtl;
               dynavSdt_calltoaction__organisationid.WebTags = "";
               dynavSdt_calltoaction__organisationid.removeAllItems();
               /* Using cursor H00732 */
               pr_default.execute(0);
               while ( (pr_default.getStatus(0) != 101) )
               {
                  dynavSdt_calltoaction__organisationid.addItem(H00732_A11OrganisationId[0].ToString(), H00732_A13OrganisationName[0], 0);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               if ( dynavSdt_calltoaction__organisationid.ItemCount > 0 )
               {
                  if ( ( AV56GXV1 > 0 ) && ( AV38SDT_CallToAction.Count >= AV56GXV1 ) && (Guid.Empty==((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Organisationid) )
                  {
                     ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Organisationid = StringUtil.StrToGuid( dynavSdt_calltoaction__organisationid.getValidValue(((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Organisationid.ToString()));
                  }
               }
            }
            /* ComboBox */
            Gridsdt_calltoactionsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavSdt_calltoaction__organisationid,(string)dynavSdt_calltoaction__organisationid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Organisationid.ToString(),(short)1,(string)dynavSdt_calltoaction__organisationid_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"guid",(string)"",(short)0,dynavSdt_calltoaction__organisationid.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            dynavSdt_calltoaction__organisationid.CurrentValue = ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Organisationid.ToString();
            AssignProp(sPrefix, false, dynavSdt_calltoaction__organisationid_Internalname, "Values", (string)(dynavSdt_calltoaction__organisationid.ToJavascriptSource()), !bGXsfl_73_Refreshing);
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__locationid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)73,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__productserviceid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Productserviceid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Productserviceid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__productserviceid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__productserviceid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)73,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',73)\"";
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionname_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactionname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_calltoaction__calltoactionname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',73)\"";
            if ( ( cmbavSdt_calltoaction__calltoactiontype.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_CALLTOACTION__CALLTOACTIONTYPE_" + sGXsfl_73_idx;
               cmbavSdt_calltoaction__calltoactiontype.Name = GXCCtl;
               cmbavSdt_calltoaction__calltoactiontype.WebTags = "";
               cmbavSdt_calltoaction__calltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
               cmbavSdt_calltoaction__calltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
               if ( cmbavSdt_calltoaction__calltoactiontype.ItemCount > 0 )
               {
                  if ( ( AV56GXV1 > 0 ) && ( AV38SDT_CallToAction.Count >= AV56GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactiontype)) )
                  {
                     ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactiontype = cmbavSdt_calltoaction__calltoactiontype.getValidValue(((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactiontype);
                  }
               }
            }
            /* ComboBox */
            Gridsdt_calltoactionsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_calltoaction__calltoactiontype,(string)cmbavSdt_calltoaction__calltoactiontype_Internalname,StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactiontype),(short)1,(string)cmbavSdt_calltoaction__calltoactiontype_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavSdt_calltoaction__calltoactiontype.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_calltoaction__calltoactiontype.CurrentValue = StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactiontype);
            AssignProp(sPrefix, false, cmbavSdt_calltoaction__calltoactiontype_Internalname, "Values", (string)(cmbavSdt_calltoaction__calltoactiontype.ToJavascriptSource()), !bGXsfl_73_Refreshing);
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionphone_Internalname,StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactionphone),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionurl_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactionurl,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionurl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionurl_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__calltoactionemail_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactionemail,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__calltoactionemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__calltoactionemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__locationdynamicformid_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Locationdynamicformid.ToString(),((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Locationdynamicformid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__locationdynamicformid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__locationdynamicformid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)73,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_calltoaction__wwpformreferencename_Internalname,((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Wwpformreferencename,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_calltoaction__wwpformreferencename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_calltoaction__wwpformreferencename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',73)\"";
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCalltoactionvariable_Internalname,(string)AV11CallToActionVariable,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCalltoactionvariable_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavCalltoactionvariable_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',73)\"";
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseractionedit_Internalname,StringUtil.RTrim( AV46UserActionEdit),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUSERACTIONEDIT.CLICK."+sGXsfl_73_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUseractionedit_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUseractionedit_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)73,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'" + sGXsfl_73_idx + "',73)\"";
            ROClassString = "Attribute";
            Gridsdt_calltoactionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseractiondelete_Internalname,StringUtil.RTrim( AV45UserActionDelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUSERACTIONDELETE.CLICK."+sGXsfl_73_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUseractiondelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUseractiondelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)73,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes732( ) ;
            Gridsdt_calltoactionsContainer.AddRow(Gridsdt_calltoactionsRow);
            nGXsfl_73_idx = ((subGridsdt_calltoactions_Islastpage==1)&&(nGXsfl_73_idx+1>subGridsdt_calltoactions_fnc_Recordsperpage( )) ? 1 : nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_732( ) ;
         }
         /* End function sendrow_732 */
      }

      protected void init_web_controls( )
      {
         cmbavCalltoactiontype.Name = "vCALLTOACTIONTYPE";
         cmbavCalltoactiontype.WebTags = "";
         cmbavCalltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
         cmbavCalltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
         cmbavCalltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
         cmbavCalltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
         if ( cmbavCalltoactiontype.ItemCount > 0 )
         {
         }
         GXCCtl = "SDT_CALLTOACTION__ORGANISATIONID_" + sGXsfl_73_idx;
         dynavSdt_calltoaction__organisationid.Name = GXCCtl;
         dynavSdt_calltoaction__organisationid.WebTags = "";
         dynavSdt_calltoaction__organisationid.removeAllItems();
         /* Using cursor H00733 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            dynavSdt_calltoaction__organisationid.addItem(H00733_A11OrganisationId[0].ToString(), H00733_A13OrganisationName[0], 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( dynavSdt_calltoaction__organisationid.ItemCount > 0 )
         {
            if ( ( AV56GXV1 > 0 ) && ( AV38SDT_CallToAction.Count >= AV56GXV1 ) && (Guid.Empty==((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Organisationid) )
            {
            }
         }
         GXCCtl = "SDT_CALLTOACTION__CALLTOACTIONTYPE_" + sGXsfl_73_idx;
         cmbavSdt_calltoaction__calltoactiontype.Name = GXCCtl;
         cmbavSdt_calltoaction__calltoactiontype.WebTags = "";
         cmbavSdt_calltoaction__calltoactiontype.addItem("Phone", context.GetMessage( "Phone", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("Email", context.GetMessage( "Email", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("Form", context.GetMessage( "Form", ""), 0);
         cmbavSdt_calltoaction__calltoactiontype.addItem("SiteUrl", context.GetMessage( "Url", ""), 0);
         if ( cmbavSdt_calltoaction__calltoactiontype.ItemCount > 0 )
         {
            if ( ( AV56GXV1 > 0 ) && ( AV38SDT_CallToAction.Count >= AV56GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_CallToAction_SDT_CallToActionItem)AV38SDT_CallToAction.Item(AV56GXV1)).gxTpr_Calltoactiontype)) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl73( )
      {
         if ( Gridsdt_calltoactionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_calltoactionsContainer"+"DivS\" data-gxgridid=\"73\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridsdt_calltoactions_Internalname, subGridsdt_calltoactions_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridsdt_calltoactions_Backcolorstyle == 0 )
            {
               subGridsdt_calltoactions_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
               {
                  subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Title";
               }
            }
            else
            {
               subGridsdt_calltoactions_Titlebackstyle = 1;
               if ( subGridsdt_calltoactions_Backcolorstyle == 1 )
               {
                  subGridsdt_calltoactions_Titlebackcolor = subGridsdt_calltoactions_Allbackcolor;
                  if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridsdt_calltoactions_Class) > 0 )
                  {
                     subGridsdt_calltoactions_Linesclass = subGridsdt_calltoactions_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Product Service Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Label", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Type", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Url", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Form", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Reference Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Call To Action", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
         }
         else
         {
            Gridsdt_calltoactionsContainer.AddObjectProperty("GridName", "Gridsdt_calltoactions");
            Gridsdt_calltoactionsContainer.AddObjectProperty("Header", subGridsdt_calltoactions_Header);
            Gridsdt_calltoactionsContainer.AddObjectProperty("Class", "WorkWith");
            Gridsdt_calltoactionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Backcolorstyle), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("CmpContext", sPrefix);
            Gridsdt_calltoactionsContainer.AddObjectProperty("InMasterPage", "false");
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavSdt_calltoaction__organisationid.Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__locationid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__productserviceid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionname_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_calltoaction__calltoactiontype.Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionphone_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionurl_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__calltoactionemail_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__locationdynamicformid_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_calltoaction__wwpformreferencename_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV11CallToActionVariable));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCalltoactionvariable_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV46UserActionEdit)));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseractionedit_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV45UserActionDelete)));
            Gridsdt_calltoactionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseractiondelete_Enabled), 5, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddColumnProperties(Gridsdt_calltoactionsColumn);
            Gridsdt_calltoactionsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Selectedindex), 4, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowselection), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Selectioncolor), 9, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowhovering), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Hoveringcolor), 9, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Allowcollapsing), 1, 0, ".", "")));
            Gridsdt_calltoactionsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_calltoactions_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         cmbavCalltoactiontype_Internalname = sPrefix+"vCALLTOACTIONTYPE";
         edtavCalltoactionname_Internalname = sPrefix+"vCALLTOACTIONNAME";
         edtavCalltoactionurl_Internalname = sPrefix+"vCALLTOACTIONURL";
         divTableurl_Internalname = sPrefix+"TABLEURL";
         edtavCalltoactionphone_Internalname = sPrefix+"vCALLTOACTIONPHONE";
         divTablephone_Internalname = sPrefix+"TABLEPHONE";
         lblTextblockcombo_locationdynamicformid_Internalname = sPrefix+"TEXTBLOCKCOMBO_LOCATIONDYNAMICFORMID";
         Combo_locationdynamicformid_Internalname = sPrefix+"COMBO_LOCATIONDYNAMICFORMID";
         divTablesplittedlocationdynamicformid_Internalname = sPrefix+"TABLESPLITTEDLOCATIONDYNAMICFORMID";
         divTableform_Internalname = sPrefix+"TABLEFORM";
         edtavCalltoactionemail_Internalname = sPrefix+"vCALLTOACTIONEMAIL";
         divTableemail_Internalname = sPrefix+"TABLEEMAIL";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         bttBtnuseractionadd_Internalname = sPrefix+"BTNUSERACTIONADD";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         edtavSdt_calltoaction__calltoactionid_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONID";
         dynavSdt_calltoaction__organisationid_Internalname = sPrefix+"SDT_CALLTOACTION__ORGANISATIONID";
         edtavSdt_calltoaction__locationid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONID";
         edtavSdt_calltoaction__productserviceid_Internalname = sPrefix+"SDT_CALLTOACTION__PRODUCTSERVICEID";
         edtavSdt_calltoaction__calltoactionname_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONNAME";
         cmbavSdt_calltoaction__calltoactiontype_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONTYPE";
         edtavSdt_calltoaction__calltoactionphone_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONPHONE";
         edtavSdt_calltoaction__calltoactionurl_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONURL";
         edtavSdt_calltoaction__calltoactionemail_Internalname = sPrefix+"SDT_CALLTOACTION__CALLTOACTIONEMAIL";
         edtavSdt_calltoaction__locationdynamicformid_Internalname = sPrefix+"SDT_CALLTOACTION__LOCATIONDYNAMICFORMID";
         edtavSdt_calltoaction__wwpformreferencename_Internalname = sPrefix+"SDT_CALLTOACTION__WWPFORMREFERENCENAME";
         edtavCalltoactionvariable_Internalname = sPrefix+"vCALLTOACTIONVARIABLE";
         edtavUseractionedit_Internalname = sPrefix+"vUSERACTIONEDIT";
         edtavUseractiondelete_Internalname = sPrefix+"vUSERACTIONDELETE";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavLocationdynamicformid_Internalname = sPrefix+"vLOCATIONDYNAMICFORMID";
         edtavCalltoactionid_Internalname = sPrefix+"vCALLTOACTIONID";
         edtavWwpformreferencename_Internalname = sPrefix+"vWWPFORMREFERENCENAME";
         Gridsdt_calltoactions_empowerer_Internalname = sPrefix+"GRIDSDT_CALLTOACTIONS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridsdt_calltoactions_Internalname = sPrefix+"GRIDSDT_CALLTOACTIONS";
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
         subGridsdt_calltoactions_Allowcollapsing = 0;
         subGridsdt_calltoactions_Allowselection = 0;
         subGridsdt_calltoactions_Header = "";
         edtavUseractiondelete_Jsonclick = "";
         edtavUseractiondelete_Enabled = 1;
         edtavUseractionedit_Jsonclick = "";
         edtavUseractionedit_Enabled = 1;
         edtavCalltoactionvariable_Jsonclick = "";
         edtavCalltoactionvariable_Enabled = 1;
         edtavSdt_calltoaction__wwpformreferencename_Jsonclick = "";
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Jsonclick = "";
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype_Jsonclick = "";
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Jsonclick = "";
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         edtavSdt_calltoaction__locationid_Jsonclick = "";
         edtavSdt_calltoaction__locationid_Enabled = 0;
         dynavSdt_calltoaction__organisationid_Jsonclick = "";
         dynavSdt_calltoaction__organisationid.Enabled = 0;
         edtavSdt_calltoaction__calltoactionid_Jsonclick = "";
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         subGridsdt_calltoactions_Class = "WorkWith";
         subGridsdt_calltoactions_Backcolorstyle = 0;
         edtavWwpformreferencename_Jsonclick = "";
         edtavWwpformreferencename_Visible = 1;
         edtavCalltoactionid_Jsonclick = "";
         edtavCalltoactionid_Visible = 1;
         edtavLocationdynamicformid_Jsonclick = "";
         edtavLocationdynamicformid_Visible = 1;
         Btnwizardlastnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardlastnext_Caption = context.GetMessage( "WWP_WizardFinishCaption", "");
         Btnwizardlastnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardlastnext_Tooltiptext = "";
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = context.GetMessage( "GXM_previous", "");
         Btnwizardprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardprevious_Tooltiptext = "";
         bttBtnuseractionadd_Caption = context.GetMessage( "Add", "");
         edtavCalltoactionemail_Jsonclick = "";
         edtavCalltoactionemail_Enabled = 1;
         divTableemail_Visible = 1;
         Combo_locationdynamicformid_Emptyitem = Convert.ToBoolean( 0);
         Combo_locationdynamicformid_Cls = "ExtendedCombo Attribute";
         Combo_locationdynamicformid_Caption = "";
         divTableform_Visible = 1;
         edtavCalltoactionphone_Jsonclick = "";
         edtavCalltoactionphone_Enabled = 1;
         divTablephone_Visible = 1;
         edtavCalltoactionurl_Jsonclick = "";
         edtavCalltoactionurl_Enabled = 1;
         divTableurl_Visible = 1;
         edtavCalltoactionname_Jsonclick = "";
         edtavCalltoactionname_Enabled = 1;
         cmbavCalltoactiontype_Jsonclick = "";
         cmbavCalltoactiontype.Enabled = 1;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = -1;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = -1;
         edtavSdt_calltoaction__calltoactionemail_Enabled = -1;
         edtavSdt_calltoaction__calltoactionurl_Enabled = -1;
         edtavSdt_calltoaction__calltoactionphone_Enabled = -1;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = -1;
         edtavSdt_calltoaction__calltoactionname_Enabled = -1;
         edtavSdt_calltoaction__productserviceid_Enabled = -1;
         edtavSdt_calltoaction__locationid_Enabled = -1;
         dynavSdt_calltoaction__organisationid.Enabled = -1;
         edtavSdt_calltoaction__calltoactionid_Enabled = -1;
         subGridsdt_calltoactions_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73},{"av":"sPrefix"},{"av":"AV22HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS.LOAD","""{"handler":"E16732","iparms":[{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73}]""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS.LOAD",""","oparms":[{"av":"AV11CallToActionVariable","fld":"vCALLTOACTIONVARIABLE"},{"av":"AV46UserActionEdit","fld":"vUSERACTIONEDIT"},{"av":"AV45UserActionDelete","fld":"vUSERACTIONDELETE"}]}""");
         setEventMetadata("ENTER","""{"handler":"E12732","iparms":[{"av":"AV22HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV48WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV6CallToActionId","fld":"vCALLTOACTIONID"},{"av":"cmbavCalltoactiontype"},{"av":"AV9CallToActionType","fld":"vCALLTOACTIONTYPE"},{"av":"AV7CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"AV50WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME"},{"av":"AV5CallToActionEmail","fld":"vCALLTOACTIONEMAIL"},{"av":"AV26LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"AV8CallToActionPhone","fld":"vCALLTOACTIONPHONE"},{"av":"AV10CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73},{"av":"AV49WizardData","fld":"vWIZARDDATA"},{"av":"AV51ImageFile","fld":"vIMAGEFILE"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV49WizardData","fld":"vWIZARDDATA"},{"av":"AV51ImageFile","fld":"vIMAGEFILE"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E13732","iparms":[{"av":"AV48WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV6CallToActionId","fld":"vCALLTOACTIONID"},{"av":"cmbavCalltoactiontype"},{"av":"AV9CallToActionType","fld":"vCALLTOACTIONTYPE"},{"av":"AV7CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"AV50WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME"},{"av":"AV5CallToActionEmail","fld":"vCALLTOACTIONEMAIL"},{"av":"AV26LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"AV8CallToActionPhone","fld":"vCALLTOACTIONPHONE"},{"av":"AV10CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV49WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOUSERACTIONADD'","""{"handler":"E14732","iparms":[{"av":"AV7CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"AV5CallToActionEmail","fld":"vCALLTOACTIONEMAIL"},{"av":"AV8CallToActionPhone","fld":"vCALLTOACTIONPHONE"},{"av":"cmbavCalltoactiontype"},{"av":"AV9CallToActionType","fld":"vCALLTOACTIONTYPE"},{"av":"AV10CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV26LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"AV50WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME"},{"av":"AV49WizardData","fld":"vWIZARDDATA"},{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV22HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("'DOUSERACTIONADD'",""","oparms":[{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73},{"av":"divTablephone_Visible","ctrl":"TABLEPHONE","prop":"Visible"},{"av":"divTableurl_Visible","ctrl":"TABLEURL","prop":"Visible"},{"av":"divTableemail_Visible","ctrl":"TABLEEMAIL","prop":"Visible"},{"av":"divTableform_Visible","ctrl":"TABLEFORM","prop":"Visible"},{"av":"AV7CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"AV5CallToActionEmail","fld":"vCALLTOACTIONEMAIL"},{"av":"AV8CallToActionPhone","fld":"vCALLTOACTIONPHONE"},{"av":"AV10CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV26LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"cmbavCalltoactiontype"},{"av":"AV9CallToActionType","fld":"vCALLTOACTIONTYPE"}]}""");
         setEventMetadata("COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED","""{"handler":"E11732","iparms":[{"av":"Combo_locationdynamicformid_Selectedvalue_get","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"SelectedValue_get"},{"av":"Combo_locationdynamicformid_Selectedtext_get","ctrl":"COMBO_LOCATIONDYNAMICFORMID","prop":"SelectedText_get"}]""");
         setEventMetadata("COMBO_LOCATIONDYNAMICFORMID.ONOPTIONCLICKED",""","oparms":[{"av":"AV26LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"AV50WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME"}]}""");
         setEventMetadata("VUSERACTIONEDIT.CLICK","""{"handler":"E17732","iparms":[{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73}]""");
         setEventMetadata("VUSERACTIONEDIT.CLICK",""","oparms":[{"av":"AV6CallToActionId","fld":"vCALLTOACTIONID"},{"av":"AV7CallToActionName","fld":"vCALLTOACTIONNAME"},{"av":"cmbavCalltoactiontype"},{"av":"AV9CallToActionType","fld":"vCALLTOACTIONTYPE"},{"av":"AV10CallToActionUrl","fld":"vCALLTOACTIONURL"},{"av":"AV5CallToActionEmail","fld":"vCALLTOACTIONEMAIL"},{"av":"AV26LocationDynamicFormId","fld":"vLOCATIONDYNAMICFORMID"},{"av":"divTableurl_Visible","ctrl":"TABLEURL","prop":"Visible"},{"av":"divTableemail_Visible","ctrl":"TABLEEMAIL","prop":"Visible"},{"av":"divTableform_Visible","ctrl":"TABLEFORM","prop":"Visible"},{"av":"divTablephone_Visible","ctrl":"TABLEPHONE","prop":"Visible"},{"av":"AV50WWPFormReferenceName","fld":"vWWPFORMREFERENCENAME"},{"av":"AV8CallToActionPhone","fld":"vCALLTOACTIONPHONE"},{"ctrl":"BTNUSERACTIONADD","prop":"Caption"}]}""");
         setEventMetadata("VUSERACTIONDELETE.CLICK","""{"handler":"E18732","iparms":[{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV22HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VUSERACTIONDELETE.CLICK",""","oparms":[{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_FIRSTPAGE","""{"handler":"subgridsdt_calltoactions_firstpage","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73},{"av":"AV22HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_PREVPAGE","""{"handler":"subgridsdt_calltoactions_previouspage","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73},{"av":"AV22HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_NEXTPAGE","""{"handler":"subgridsdt_calltoactions_nextpage","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73},{"av":"AV22HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDSDT_CALLTOACTIONS_LASTPAGE","""{"handler":"subgridsdt_calltoactions_lastpage","iparms":[{"av":"GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage"},{"av":"GRIDSDT_CALLTOACTIONS_nEOF"},{"av":"subGridsdt_calltoactions_Rows","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"Rows"},{"av":"AV38SDT_CallToAction","fld":"vSDT_CALLTOACTION","grid":73},{"av":"nGXsfl_73_idx","ctrl":"GRID","prop":"GridCurrRow","grid":73},{"av":"nRC_GXsfl_73","ctrl":"GRIDSDT_CALLTOACTIONS","prop":"GridRC","grid":73},{"av":"AV22HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("VALIDV_CALLTOACTIONTYPE","""{"handler":"Validv_Calltoactiontype","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONURL","""{"handler":"Validv_Calltoactionurl","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONEMAIL","""{"handler":"Validv_Calltoactionemail","iparms":[]}""");
         setEventMetadata("VALIDV_LOCATIONDYNAMICFORMID","""{"handler":"Validv_Locationdynamicformid","iparms":[]}""");
         setEventMetadata("VALIDV_CALLTOACTIONID","""{"handler":"Validv_Calltoactionid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("VALIDV_GXV9","""{"handler":"Validv_Gxv9","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV11","""{"handler":"Validv_Gxv11","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Useractiondelete","iparms":[]}""");
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
         wcpOAV48WebSessionKey = "";
         wcpOAV36PreviousStep = "";
         Combo_locationdynamicformid_Selectedvalue_get = "";
         Combo_locationdynamicformid_Selectedtext_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV38SDT_CallToAction = new GXBaseCollection<SdtSDT_CallToAction_SDT_CallToActionItem>( context, "SDT_CallToActionItem", "Comforta_version2");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV27LocationDynamicFormId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV49WizardData = new SdtWP_ProductServiceData(context);
         AV51ImageFile = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV9CallToActionType = "";
         AV7CallToActionName = "";
         AV10CallToActionUrl = "";
         AV8CallToActionPhone = "";
         lblTextblockcombo_locationdynamicformid_Jsonclick = "";
         ucCombo_locationdynamicformid = new GXUserControl();
         AV5CallToActionEmail = "";
         bttBtnuseractionadd_Jsonclick = "";
         Gridsdt_calltoactionsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardlastnext = new GXUserControl();
         AV26LocationDynamicFormId = Guid.Empty;
         AV6CallToActionId = Guid.Empty;
         AV50WWPFormReferenceName = "";
         ucGridsdt_calltoactions_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV11CallToActionVariable = "";
         AV46UserActionEdit = "";
         AV45UserActionDelete = "";
         GXDecQS = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Gridsdt_calltoactions_empowerer_Gridinternalname = "";
         Gridsdt_calltoactionsRow = new GXWebRow();
         AV47WebSession = context.GetSession();
         AV39SDT_CallToActionItem = new SdtSDT_CallToAction_SDT_CallToActionItem(context);
         AV44Trn_ProductService = new SdtTrn_ProductService(context);
         AV42Trn_CallToAction = new SdtTrn_CallToAction(context);
         AV69GXV14 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV32Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV71GXV16 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV73GXV18 = new GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem>( context, "SDT_LocationDynamicFormItem", "Comforta_version2");
         GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem2 = new GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem>( context, "SDT_LocationDynamicFormItem", "Comforta_version2");
         AV28LocationDynamicFormId_DPItem = new SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem(context);
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         Combo_locationdynamicformid_Selectedvalue_set = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV48WebSessionKey = "";
         sCtrlAV36PreviousStep = "";
         sCtrlAV18GoingBack = "";
         subGridsdt_calltoactions_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         H00732_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00732_A13OrganisationName = new string[] {""} ;
         H00733_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00733_A13OrganisationName = new string[] {""} ;
         Gridsdt_calltoactionsColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_productservicestep2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_productservicestep2__default(),
            new Object[][] {
                new Object[] {
               H00732_A11OrganisationId, H00732_A13OrganisationName
               }
               , new Object[] {
               H00733_A11OrganisationId, H00733_A13OrganisationName
               }
            }
         );
         /* GeneXus formulas. */
         edtavSdt_calltoaction__calltoactionid_Enabled = 0;
         dynavSdt_calltoaction__organisationid.Enabled = 0;
         edtavSdt_calltoaction__locationid_Enabled = 0;
         edtavSdt_calltoaction__productserviceid_Enabled = 0;
         edtavSdt_calltoaction__calltoactionname_Enabled = 0;
         cmbavSdt_calltoaction__calltoactiontype.Enabled = 0;
         edtavSdt_calltoaction__calltoactionphone_Enabled = 0;
         edtavSdt_calltoaction__calltoactionurl_Enabled = 0;
         edtavSdt_calltoaction__calltoactionemail_Enabled = 0;
         edtavSdt_calltoaction__locationdynamicformid_Enabled = 0;
         edtavSdt_calltoaction__wwpformreferencename_Enabled = 0;
         edtavCalltoactionvariable_Enabled = 0;
         edtavUseractionedit_Enabled = 0;
         edtavUseractiondelete_Enabled = 0;
      }

      private short GRIDSDT_CALLTOACTIONS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGridsdt_calltoactions_Backcolorstyle ;
      private short gxcookieaux ;
      private short AV53IndexToEdit ;
      private short nGXWrapped ;
      private short subGridsdt_calltoactions_Backstyle ;
      private short subGridsdt_calltoactions_Titlebackstyle ;
      private short subGridsdt_calltoactions_Allowselection ;
      private short subGridsdt_calltoactions_Allowhovering ;
      private short subGridsdt_calltoactions_Allowcollapsing ;
      private short subGridsdt_calltoactions_Collapsed ;
      private int nRC_GXsfl_73 ;
      private int subGridsdt_calltoactions_Rows ;
      private int nGXsfl_73_idx=1 ;
      private int edtavSdt_calltoaction__calltoactionid_Enabled ;
      private int edtavSdt_calltoaction__locationid_Enabled ;
      private int edtavSdt_calltoaction__productserviceid_Enabled ;
      private int edtavSdt_calltoaction__calltoactionname_Enabled ;
      private int edtavSdt_calltoaction__calltoactionphone_Enabled ;
      private int edtavSdt_calltoaction__calltoactionurl_Enabled ;
      private int edtavSdt_calltoaction__calltoactionemail_Enabled ;
      private int edtavSdt_calltoaction__locationdynamicformid_Enabled ;
      private int edtavSdt_calltoaction__wwpformreferencename_Enabled ;
      private int edtavCalltoactionvariable_Enabled ;
      private int edtavUseractionedit_Enabled ;
      private int edtavUseractiondelete_Enabled ;
      private int edtavCalltoactionname_Enabled ;
      private int divTableurl_Visible ;
      private int edtavCalltoactionurl_Enabled ;
      private int divTablephone_Visible ;
      private int edtavCalltoactionphone_Enabled ;
      private int divTableform_Visible ;
      private int divTableemail_Visible ;
      private int edtavCalltoactionemail_Enabled ;
      private int AV56GXV1 ;
      private int edtavLocationdynamicformid_Visible ;
      private int edtavCalltoactionid_Visible ;
      private int edtavWwpformreferencename_Visible ;
      private int subGridsdt_calltoactions_Islastpage ;
      private int GRIDSDT_CALLTOACTIONS_nGridOutOfScope ;
      private int nGXsfl_73_fel_idx=1 ;
      private int nGXsfl_73_bak_idx=1 ;
      private int AV68GXV13 ;
      private int AV70GXV15 ;
      private int AV72GXV17 ;
      private int AV74GXV19 ;
      private int idxLst ;
      private int subGridsdt_calltoactions_Backcolor ;
      private int subGridsdt_calltoactions_Allbackcolor ;
      private int subGridsdt_calltoactions_Titlebackcolor ;
      private int subGridsdt_calltoactions_Selectedindex ;
      private int subGridsdt_calltoactions_Selectioncolor ;
      private int subGridsdt_calltoactions_Hoveringcolor ;
      private long GRIDSDT_CALLTOACTIONS_nFirstRecordOnPage ;
      private long GRIDSDT_CALLTOACTIONS_nCurrentRecord ;
      private long GRIDSDT_CALLTOACTIONS_nRecordCount ;
      private string Combo_locationdynamicformid_Selectedvalue_get ;
      private string Combo_locationdynamicformid_Selectedtext_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_73_idx="0001" ;
      private string edtavSdt_calltoaction__calltoactionid_Internalname ;
      private string dynavSdt_calltoaction__organisationid_Internalname ;
      private string edtavSdt_calltoaction__locationid_Internalname ;
      private string edtavSdt_calltoaction__productserviceid_Internalname ;
      private string edtavSdt_calltoaction__calltoactionname_Internalname ;
      private string cmbavSdt_calltoaction__calltoactiontype_Internalname ;
      private string edtavSdt_calltoaction__calltoactionphone_Internalname ;
      private string edtavSdt_calltoaction__calltoactionurl_Internalname ;
      private string edtavSdt_calltoaction__calltoactionemail_Internalname ;
      private string edtavSdt_calltoaction__locationdynamicformid_Internalname ;
      private string edtavSdt_calltoaction__wwpformreferencename_Internalname ;
      private string edtavCalltoactionvariable_Internalname ;
      private string edtavUseractionedit_Internalname ;
      private string edtavUseractiondelete_Internalname ;
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
      private string grpUnnamedgroup2_Internalname ;
      private string divTableattributes_Internalname ;
      private string cmbavCalltoactiontype_Internalname ;
      private string TempTags ;
      private string cmbavCalltoactiontype_Jsonclick ;
      private string edtavCalltoactionname_Internalname ;
      private string edtavCalltoactionname_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string divTableurl_Internalname ;
      private string edtavCalltoactionurl_Internalname ;
      private string edtavCalltoactionurl_Jsonclick ;
      private string divTablephone_Internalname ;
      private string edtavCalltoactionphone_Internalname ;
      private string AV8CallToActionPhone ;
      private string edtavCalltoactionphone_Jsonclick ;
      private string divTableform_Internalname ;
      private string divTablesplittedlocationdynamicformid_Internalname ;
      private string lblTextblockcombo_locationdynamicformid_Internalname ;
      private string lblTextblockcombo_locationdynamicformid_Jsonclick ;
      private string Combo_locationdynamicformid_Caption ;
      private string Combo_locationdynamicformid_Cls ;
      private string Combo_locationdynamicformid_Internalname ;
      private string divTableemail_Internalname ;
      private string edtavCalltoactionemail_Internalname ;
      private string edtavCalltoactionemail_Jsonclick ;
      private string bttBtnuseractionadd_Internalname ;
      private string bttBtnuseractionadd_Caption ;
      private string bttBtnuseractionadd_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string sStyleString ;
      private string subGridsdt_calltoactions_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Beforeiconclass ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardlastnext_Tooltiptext ;
      private string Btnwizardlastnext_Aftericonclass ;
      private string Btnwizardlastnext_Caption ;
      private string Btnwizardlastnext_Class ;
      private string Btnwizardlastnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavLocationdynamicformid_Internalname ;
      private string edtavLocationdynamicformid_Jsonclick ;
      private string edtavCalltoactionid_Internalname ;
      private string edtavCalltoactionid_Jsonclick ;
      private string edtavWwpformreferencename_Internalname ;
      private string edtavWwpformreferencename_Jsonclick ;
      private string Gridsdt_calltoactions_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV46UserActionEdit ;
      private string AV45UserActionDelete ;
      private string GXDecQS ;
      private string sGXsfl_73_fel_idx="0001" ;
      private string Gridsdt_calltoactions_empowerer_Gridinternalname ;
      private string Combo_locationdynamicformid_Selectedvalue_set ;
      private string sCtrlAV48WebSessionKey ;
      private string sCtrlAV36PreviousStep ;
      private string sCtrlAV18GoingBack ;
      private string subGridsdt_calltoactions_Class ;
      private string subGridsdt_calltoactions_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_calltoaction__calltoactionid_Jsonclick ;
      private string GXCCtl ;
      private string dynavSdt_calltoaction__organisationid_Jsonclick ;
      private string edtavSdt_calltoaction__locationid_Jsonclick ;
      private string edtavSdt_calltoaction__productserviceid_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionname_Jsonclick ;
      private string cmbavSdt_calltoaction__calltoactiontype_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionphone_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionurl_Jsonclick ;
      private string edtavSdt_calltoaction__calltoactionemail_Jsonclick ;
      private string edtavSdt_calltoaction__locationdynamicformid_Jsonclick ;
      private string edtavSdt_calltoaction__wwpformreferencename_Jsonclick ;
      private string edtavCalltoactionvariable_Jsonclick ;
      private string edtavUseractionedit_Jsonclick ;
      private string edtavUseractiondelete_Jsonclick ;
      private string subGridsdt_calltoactions_Header ;
      private bool AV18GoingBack ;
      private bool wcpOAV18GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV22HasValidationErrors ;
      private bool bGXsfl_73_Refreshing=false ;
      private bool wbLoad ;
      private bool Combo_locationdynamicformid_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV54IsEditing ;
      private bool gx_BV73 ;
      private string AV48WebSessionKey ;
      private string AV36PreviousStep ;
      private string wcpOAV48WebSessionKey ;
      private string wcpOAV36PreviousStep ;
      private string AV9CallToActionType ;
      private string AV7CallToActionName ;
      private string AV10CallToActionUrl ;
      private string AV5CallToActionEmail ;
      private string AV50WWPFormReferenceName ;
      private string AV11CallToActionVariable ;
      private Guid AV26LocationDynamicFormId ;
      private Guid AV6CallToActionId ;
      private string AV51ImageFile ;
      private GXWebGrid Gridsdt_calltoactionsContainer ;
      private GXWebRow Gridsdt_calltoactionsRow ;
      private GXWebColumn Gridsdt_calltoactionsColumn ;
      private GXUserControl ucCombo_locationdynamicformid ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardlastnext ;
      private GXUserControl ucGridsdt_calltoactions_empowerer ;
      private GXWebForm Form ;
      private IGxSession AV47WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCalltoactiontype ;
      private GXCombobox dynavSdt_calltoaction__organisationid ;
      private GXCombobox cmbavSdt_calltoaction__calltoactiontype ;
      private GXBaseCollection<SdtSDT_CallToAction_SDT_CallToActionItem> AV38SDT_CallToAction ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV27LocationDynamicFormId_Data ;
      private SdtWP_ProductServiceData AV49WizardData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private SdtSDT_CallToAction_SDT_CallToActionItem AV39SDT_CallToActionItem ;
      private SdtTrn_ProductService AV44Trn_ProductService ;
      private IDataStoreProvider pr_default ;
      private SdtTrn_CallToAction AV42Trn_CallToAction ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV69GXV14 ;
      private GeneXus.Utils.SdtMessages_Message AV32Message ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV71GXV16 ;
      private GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> AV73GXV18 ;
      private GXBaseCollection<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem> GXt_objcol_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem2 ;
      private SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem AV28LocationDynamicFormId_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] H00732_A11OrganisationId ;
      private string[] H00732_A13OrganisationName ;
      private Guid[] H00733_A11OrganisationId ;
      private string[] H00733_A13OrganisationName ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_productservicestep2__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_productservicestep2__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmH00732;
        prmH00732 = new Object[] {
        };
        Object[] prmH00733;
        prmH00733 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H00732", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00732,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00733", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00733,0, GxCacheFrequency.OFF ,true,false )
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