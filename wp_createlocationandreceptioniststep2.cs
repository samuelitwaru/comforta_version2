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
   public class wp_createlocationandreceptioniststep2 : GXWebComponent
   {
      public wp_createlocationandreceptioniststep2( )
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

      public wp_createlocationandreceptioniststep2( IGxContext context )
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdt_receptionistss") == 0 )
               {
                  gxnrGridsdt_receptionistss_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdt_receptionistss") == 0 )
               {
                  gxgrGridsdt_receptionistss_refresh_invoke( ) ;
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

      protected void gxnrGridsdt_receptionistss_newrow_invoke( )
      {
         nRC_GXsfl_56 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_56"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_56_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_56_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_56_idx = GetPar( "sGXsfl_56_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsdt_receptionistss_newrow( ) ;
         /* End function gxnrGridsdt_receptionistss_newrow_invoke */
      }

      protected void gxgrGridsdt_receptionistss_refresh_invoke( )
      {
         subGridsdt_receptionistss_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdt_receptionistss_Rows"), "."), 18, MidpointRounding.ToEven));
         AV10HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV10HasValidationErrors, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridsdt_receptionistss_refresh_invoke */
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
            PA6U2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdt_receptionists__receptionistid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistid_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistgivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistgivenname_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavSdt_receptionists__receptionistlastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistlastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistlastname_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavSdt_receptionists__receptionistemail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistemail_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavSdt_receptionists__receptionistphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistphone_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavSdt_receptionists__receptionistphonecode_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistphonecode_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavSdt_receptionists__receptionistphonenumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistphonenumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistphonenumber_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavSdt_receptionists__receptioniststatus_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptioniststatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptioniststatus_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavSdt_receptionists__locationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__locationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__locationid_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__receptionistgamguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__receptionistgamguid_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavSdt_receptionists__organisationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_receptionists__organisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_receptionists__organisationid_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavUupdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUupdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUupdate_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               edtavUdelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavUdelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUdelete_Enabled), 5, 0), !bGXsfl_56_Refreshing);
               WS6U2( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Create Location And Receptionist Step2", "")) ;
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
            GXEncryptionTmp = "wp_createlocationandreceptioniststep2.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createlocationandreceptioniststep2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_receptionists", AV19SDT_Receptionists);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_receptionists", AV19SDT_Receptionists);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_56", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_56), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV32DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV32DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRECEPTIONISTPHONECODE_DATA", AV36ReceptionistPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRECEPTIONISTPHONECODE_DATA", AV36ReceptionistPhoneCode_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV18CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_RECEPTIONISTS", AV19SDT_Receptionists);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_RECEPTIONISTS", AV19SDT_Receptionists);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV11WizardData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_RECEPTIONIST", AV26Trn_Receptionist);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_RECEPTIONIST", AV26Trn_Receptionist);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMESSAGES", AV23ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMESSAGES", AV23ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"RECEPTIONISTEMAIL", A93ReceptionistEmail);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_LOCATION", AV24Trn_Location);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_LOCATION", AV24Trn_Location);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_RECEPTIONIST", AV21SDT_Receptionist);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_RECEPTIONIST", AV21SDT_Receptionist);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECEPTIONISTPHONECODE_Ddointernalname", StringUtil.RTrim( Combo_receptionistphonecode_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECEPTIONISTPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_receptionistphonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_RECEPTIONISTPHONECODE_Ddointernalname", StringUtil.RTrim( Combo_receptionistphonecode_Ddointernalname));
      }

      protected void RenderHtmlCloseForm6U2( )
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
         return "WP_CreateLocationAndReceptionistStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Location And Receptionist Step2", "") ;
      }

      protected void WB6U0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createlocationandreceptioniststep2.aspx");
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Receptionist Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFormtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReceptionistgivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistgivenname_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistgivenname_Internalname, AV14ReceptionistGivenName, StringUtil.RTrim( context.localUtil.Format( AV14ReceptionistGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistgivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavReceptionistgivenname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReceptionistlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistlastname_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistlastname_Internalname, AV15ReceptionistLastName, StringUtil.RTrim( context.localUtil.Format( AV15ReceptionistLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavReceptionistlastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavReceptionistemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistemail_Internalname, AV16ReceptionistEmail, StringUtil.RTrim( context.localUtil.Format( AV16ReceptionistEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavReceptionistemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Required ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedreceptionistphonecode_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_receptionistphonecode_Internalname, context.GetMessage( "Phone", ""), "", "", lblTextblockcombo_receptionistphonecode_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            wb_table1_41_6U2( true) ;
         }
         else
         {
            wb_table1_41_6U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_41_6U2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuinsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(56), 2, 0)+","+"null"+");", context.GetMessage( "Add", ""), bttBtnuinsert_Jsonclick, 5, context.GetMessage( "Add new item", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateLocationAndReceptionistStep2.htm");
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
            Gridsdt_receptionistssContainer.SetWrapped(nGXWrapped);
            StartGridControl56( ) ;
         }
         if ( wbEnd == 56 )
         {
            wbEnd = 0;
            nRC_GXsfl_56 = (int)(nGXsfl_56_idx-1);
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridsdt_receptionistssContainer.AddObjectProperty("GRIDSDT_RECEPTIONISTSS_nEOF", GRIDSDT_RECEPTIONISTSS_nEOF);
               Gridsdt_receptionistssContainer.AddObjectProperty("GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
               AV42GXV1 = nGXsfl_56_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_receptionistssContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_receptionistss", Gridsdt_receptionistssContainer, subGridsdt_receptionistss_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_receptionistssContainerData", Gridsdt_receptionistssContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_receptionistssContainerData"+"V", Gridsdt_receptionistssContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_receptionistssContainerData"+"V"+"\" value='"+Gridsdt_receptionistssContainer.GridValuesHidden()+"'/>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistphonecode_Internalname, AV35ReceptionistPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV35ReceptionistPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavReceptionistphonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistphone_Internalname, StringUtil.RTrim( AV17ReceptionistPhone), StringUtil.RTrim( context.localUtil.Format( AV17ReceptionistPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavReceptionistphone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistid_Internalname, AV13ReceptionistId.ToString(), AV13ReceptionistId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistid_Jsonclick, 0, "Attribute", "", "", "", "", edtavReceptionistid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            /* User Defined Control */
            ucGridsdt_receptionistss_empowerer.Render(context, "wwp.gridempowerer", Gridsdt_receptionistss_empowerer_Internalname, sPrefix+"GRIDSDT_RECEPTIONISTSS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 56 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridsdt_receptionistssContainer.AddObjectProperty("GRIDSDT_RECEPTIONISTSS_nEOF", GRIDSDT_RECEPTIONISTSS_nEOF);
                  Gridsdt_receptionistssContainer.AddObjectProperty("GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
                  AV42GXV1 = nGXsfl_56_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_receptionistssContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_receptionistss", Gridsdt_receptionistssContainer, subGridsdt_receptionistss_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_receptionistssContainerData", Gridsdt_receptionistssContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_receptionistssContainerData"+"V", Gridsdt_receptionistssContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_receptionistssContainerData"+"V"+"\" value='"+Gridsdt_receptionistssContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START6U2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Create Location And Receptionist Step2", ""), 0) ;
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
               STRUP6U0( ) ;
            }
         }
      }

      protected void WS6U2( )
      {
         START6U2( ) ;
         EVT6U2( ) ;
      }

      protected void EVT6U2( )
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
                                 STRUP6U0( ) ;
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
                                 STRUP6U0( ) ;
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
                                          E116U2 ();
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
                                 STRUP6U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E126U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUInsert' */
                                    E136U2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6U0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_RECEPTIONISTSSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6U0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDSDT_RECEPTIONISTSSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridsdt_receptionistss_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridsdt_receptionistss_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridsdt_receptionistss_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridsdt_receptionistss_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 27), "GRIDSDT_RECEPTIONISTSS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VUDELETE.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6U0( ) ;
                              }
                              nGXsfl_56_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
                              SubsflControlProps_562( ) ;
                              AV42GXV1 = (int)(nGXsfl_56_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
                              if ( ( AV19SDT_Receptionists.Count >= AV42GXV1 ) && ( AV42GXV1 > 0 ) )
                              {
                                 AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1));
                                 AV41UUpdate = cgiGet( edtavUupdate_Internalname);
                                 AssignAttri(sPrefix, false, edtavUupdate_Internalname, AV41UUpdate);
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
                                          GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E146U2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_RECEPTIONISTSS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Gridsdt_receptionistss.Load */
                                          E156U2 ();
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
                                          GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E166U2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUUPDATE.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E176U2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP6U0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_receptionists__receptionistid_Internalname;
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

      protected void WE6U2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6U2( ) ;
            }
         }
      }

      protected void PA6U2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createlocationandreceptioniststep2.aspx")), "wp_createlocationandreceptioniststep2.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createlocationandreceptioniststep2.aspx")))) ;
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
               GX_FocusControl = edtavReceptionistgivenname_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsdt_receptionistss_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_562( ) ;
         while ( nGXsfl_56_idx <= nRC_GXsfl_56 )
         {
            sendrow_562( ) ;
            nGXsfl_56_idx = ((subGridsdt_receptionistss_Islastpage==1)&&(nGXsfl_56_idx+1>subGridsdt_receptionistss_fnc_Recordsperpage( )) ? 1 : nGXsfl_56_idx+1);
            sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
            SubsflControlProps_562( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsdt_receptionistssContainer)) ;
         /* End function gxnrGridsdt_receptionistss_newrow */
      }

      protected void gxgrGridsdt_receptionistss_refresh( int subGridsdt_receptionistss_Rows ,
                                                         bool AV10HasValidationErrors ,
                                                         string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSDT_RECEPTIONISTSS_nCurrentRecord = 0;
         RF6U2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridsdt_receptionistss_refresh */
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
         RF6U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistphonecode_Enabled = 0;
         edtavSdt_receptionists__receptionistphonenumber_Enabled = 0;
         edtavSdt_receptionists__receptioniststatus_Enabled = 0;
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavUupdate_Enabled = 0;
         edtavUdelete_Enabled = 0;
      }

      protected void RF6U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridsdt_receptionistssContainer.ClearRows();
         }
         wbStart = 56;
         nGXsfl_56_idx = 1;
         sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
         SubsflControlProps_562( ) ;
         bGXsfl_56_Refreshing = true;
         Gridsdt_receptionistssContainer.AddObjectProperty("GridName", "Gridsdt_receptionistss");
         Gridsdt_receptionistssContainer.AddObjectProperty("CmpContext", sPrefix);
         Gridsdt_receptionistssContainer.AddObjectProperty("InMasterPage", "false");
         Gridsdt_receptionistssContainer.AddObjectProperty("Class", "WorkWith");
         Gridsdt_receptionistssContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsdt_receptionistssContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsdt_receptionistssContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Backcolorstyle), 1, 0, ".", "")));
         Gridsdt_receptionistssContainer.PageSize = subGridsdt_receptionistss_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_562( ) ;
            /* Execute user event: Gridsdt_receptionistss.Load */
            E156U2 ();
            if ( ( subGridsdt_receptionistss_Islastpage == 0 ) && ( GRIDSDT_RECEPTIONISTSS_nCurrentRecord > 0 ) && ( GRIDSDT_RECEPTIONISTSS_nGridOutOfScope == 0 ) && ( nGXsfl_56_idx == 1 ) )
            {
               GRIDSDT_RECEPTIONISTSS_nCurrentRecord = 0;
               GRIDSDT_RECEPTIONISTSS_nGridOutOfScope = 1;
               subgridsdt_receptionistss_firstpage( ) ;
               /* Execute user event: Gridsdt_receptionistss.Load */
               E156U2 ();
            }
            wbEnd = 56;
            WB6U0( ) ;
         }
         bGXsfl_56_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6U2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected int subGridsdt_receptionistss_fnc_Pagecount( )
      {
         GRIDSDT_RECEPTIONISTSS_nRecordCount = subGridsdt_receptionistss_fnc_Recordcount( );
         if ( ((int)((GRIDSDT_RECEPTIONISTSS_nRecordCount) % (subGridsdt_receptionistss_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_RECEPTIONISTSS_nRecordCount/ (decimal)(subGridsdt_receptionistss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_RECEPTIONISTSS_nRecordCount/ (decimal)(subGridsdt_receptionistss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridsdt_receptionistss_fnc_Recordcount( )
      {
         return AV19SDT_Receptionists.Count ;
      }

      protected int subGridsdt_receptionistss_fnc_Recordsperpage( )
      {
         if ( subGridsdt_receptionistss_Rows > 0 )
         {
            return subGridsdt_receptionistss_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdt_receptionistss_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage/ (decimal)(subGridsdt_receptionistss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridsdt_receptionistss_firstpage( )
      {
         GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_receptionistss_nextpage( )
      {
         GRIDSDT_RECEPTIONISTSS_nRecordCount = subGridsdt_receptionistss_fnc_Recordcount( );
         if ( ( GRIDSDT_RECEPTIONISTSS_nRecordCount >= subGridsdt_receptionistss_fnc_Recordsperpage( ) ) && ( GRIDSDT_RECEPTIONISTSS_nEOF == 0 ) )
         {
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage+subGridsdt_receptionistss_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridsdt_receptionistssContainer.AddObjectProperty("GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDT_RECEPTIONISTSS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdt_receptionistss_previouspage( )
      {
         if ( GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage >= subGridsdt_receptionistss_fnc_Recordsperpage( ) )
         {
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage-subGridsdt_receptionistss_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_receptionistss_lastpage( )
      {
         GRIDSDT_RECEPTIONISTSS_nRecordCount = subGridsdt_receptionistss_fnc_Recordcount( );
         if ( GRIDSDT_RECEPTIONISTSS_nRecordCount > subGridsdt_receptionistss_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDT_RECEPTIONISTSS_nRecordCount) % (subGridsdt_receptionistss_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(GRIDSDT_RECEPTIONISTSS_nRecordCount-subGridsdt_receptionistss_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(GRIDSDT_RECEPTIONISTSS_nRecordCount-((int)((GRIDSDT_RECEPTIONISTSS_nRecordCount) % (subGridsdt_receptionistss_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdt_receptionistss_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(subGridsdt_receptionistss_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV10HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistphonecode_Enabled = 0;
         edtavSdt_receptionists__receptionistphonenumber_Enabled = 0;
         edtavSdt_receptionists__receptioniststatus_Enabled = 0;
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavUupdate_Enabled = 0;
         edtavUdelete_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E146U2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_receptionists"), AV19SDT_Receptionists);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV32DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vRECEPTIONISTPHONECODE_DATA"), AV36ReceptionistPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_RECEPTIONISTS"), AV19SDT_Receptionists);
            /* Read saved values. */
            nRC_GXsfl_56 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_56"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSDT_RECEPTIONISTSS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_RECEPTIONISTSS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridsdt_receptionistss_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_RECEPTIONISTSS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Rows), 6, 0, ".", "")));
            Combo_receptionistphonecode_Ddointernalname = cgiGet( sPrefix+"COMBO_RECEPTIONISTPHONECODE_Ddointernalname");
            nRC_GXsfl_56 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_56"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_56_fel_idx = 0;
            while ( nGXsfl_56_fel_idx < nRC_GXsfl_56 )
            {
               nGXsfl_56_fel_idx = ((subGridsdt_receptionistss_Islastpage==1)&&(nGXsfl_56_fel_idx+1>subGridsdt_receptionistss_fnc_Recordsperpage( )) ? 1 : nGXsfl_56_fel_idx+1);
               sGXsfl_56_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_562( ) ;
               AV42GXV1 = (int)(nGXsfl_56_fel_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
               if ( ( AV19SDT_Receptionists.Count >= AV42GXV1 ) && ( AV42GXV1 > 0 ) )
               {
                  AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1));
                  AV41UUpdate = cgiGet( edtavUupdate_Internalname);
                  AV12UDelete = cgiGet( edtavUdelete_Internalname);
               }
            }
            if ( nGXsfl_56_fel_idx == 0 )
            {
               nGXsfl_56_idx = 1;
               sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
               SubsflControlProps_562( ) ;
            }
            nGXsfl_56_fel_idx = 1;
            /* Read variables values. */
            AV14ReceptionistGivenName = cgiGet( edtavReceptionistgivenname_Internalname);
            AssignAttri(sPrefix, false, "AV14ReceptionistGivenName", AV14ReceptionistGivenName);
            AV15ReceptionistLastName = cgiGet( edtavReceptionistlastname_Internalname);
            AssignAttri(sPrefix, false, "AV15ReceptionistLastName", AV15ReceptionistLastName);
            AV16ReceptionistEmail = cgiGet( edtavReceptionistemail_Internalname);
            AssignAttri(sPrefix, false, "AV16ReceptionistEmail", AV16ReceptionistEmail);
            AV38ReceptionistPhoneNumber = cgiGet( edtavReceptionistphonenumber_Internalname);
            AssignAttri(sPrefix, false, "AV38ReceptionistPhoneNumber", AV38ReceptionistPhoneNumber);
            AV35ReceptionistPhoneCode = cgiGet( edtavReceptionistphonecode_Internalname);
            AssignAttri(sPrefix, false, "AV35ReceptionistPhoneCode", AV35ReceptionistPhoneCode);
            AV17ReceptionistPhone = cgiGet( edtavReceptionistphone_Internalname);
            AssignAttri(sPrefix, false, "AV17ReceptionistPhone", AV17ReceptionistPhone);
            if ( StringUtil.StrCmp(cgiGet( edtavReceptionistid_Internalname), "") == 0 )
            {
               AV13ReceptionistId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV13ReceptionistId", AV13ReceptionistId.ToString());
            }
            else
            {
               try
               {
                  AV13ReceptionistId = StringUtil.StrToGuid( cgiGet( edtavReceptionistid_Internalname));
                  AssignAttri(sPrefix, false, "AV13ReceptionistId", AV13ReceptionistId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vRECEPTIONISTID");
                  GX_FocusControl = edtavReceptionistid_Internalname;
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
         E146U2 ();
         if (returnInSub) return;
      }

      protected void E146U2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV32DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV32DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavReceptionistphonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavReceptionistphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReceptionistphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_receptionistphonecode_Htmltemplate = GXt_char2;
         ucCombo_receptionistphonecode.SendProperty(context, sPrefix, false, Combo_receptionistphonecode_Internalname, "HTMLTemplate", Combo_receptionistphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBORECEPTIONISTPHONECODE' */
         S122 ();
         if (returnInSub) return;
         edtavReceptionistphone_Visible = 0;
         AssignProp(sPrefix, false, edtavReceptionistphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReceptionistphone_Visible), 5, 0), true);
         edtavReceptionistid_Visible = 0;
         AssignProp(sPrefix, false, edtavReceptionistid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavReceptionistid_Visible), 5, 0), true);
         Gridsdt_receptionistss_empowerer_Gridinternalname = subGridsdt_receptionistss_Internalname;
         ucGridsdt_receptionistss_empowerer.SendProperty(context, sPrefix, false, Gridsdt_receptionistss_empowerer_Internalname, "GridInternalName", Gridsdt_receptionistss_empowerer_Gridinternalname);
         subGridsdt_receptionistss_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Rows), 6, 0, ".", "")));
         AV33defaultCountryPhoneCode = "+31";
         AV35ReceptionistPhoneCode = "+31";
         AssignAttri(sPrefix, false, "AV35ReceptionistPhoneCode", AV35ReceptionistPhoneCode);
         Combo_receptionistphonecode_Selectedtext_set = AV33defaultCountryPhoneCode;
         ucCombo_receptionistphonecode.SendProperty(context, sPrefix, false, Combo_receptionistphonecode_Internalname, "SelectedText_set", Combo_receptionistphonecode_Selectedtext_set);
         Combo_receptionistphonecode_Selectedvalue_set = AV33defaultCountryPhoneCode;
         ucCombo_receptionistphonecode.SendProperty(context, sPrefix, false, Combo_receptionistphonecode_Internalname, "SelectedValue_set", Combo_receptionistphonecode_Selectedvalue_set);
      }

      private void E156U2( )
      {
         /* Gridsdt_receptionistss_Load Routine */
         returnInSub = false;
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV19SDT_Receptionists.Count )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1));
            AV41UUpdate = "<i class=\"fas fa-pencil\"></i>";
            AssignAttri(sPrefix, false, edtavUupdate_Internalname, AV41UUpdate);
            AV12UDelete = "<i class=\"fa fa-times fas fa-xmark\"></i>";
            AssignAttri(sPrefix, false, edtavUdelete_Internalname, AV12UDelete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 56;
            }
            if ( ( subGridsdt_receptionistss_Islastpage == 1 ) || ( subGridsdt_receptionistss_Rows == 0 ) || ( ( GRIDSDT_RECEPTIONISTSS_nCurrentRecord >= GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage ) && ( GRIDSDT_RECEPTIONISTSS_nCurrentRecord < GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage + subGridsdt_receptionistss_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_562( ) ;
            }
            GRIDSDT_RECEPTIONISTSS_nEOF = (short)(((GRIDSDT_RECEPTIONISTSS_nCurrentRecord<GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage+subGridsdt_receptionistss_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_RECEPTIONISTSS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_RECEPTIONISTSS_nEOF), 1, 0, ".", "")));
            GRIDSDT_RECEPTIONISTSS_nCurrentRecord = (long)(GRIDSDT_RECEPTIONISTSS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_56_Refreshing )
            {
               DoAjaxLoad(56, Gridsdt_receptionistssRow);
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E116U2 ();
         if (returnInSub) return;
      }

      protected void E116U2( )
      {
         AV42GXV1 = (int)(nGXsfl_56_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( ( AV42GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV42GXV1 ) )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1));
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
            if ( AV18CheckRequiredFieldsResult && ! AV10HasValidationErrors )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23ErrorMessages", AV23ErrorMessages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24Trn_Location", AV24Trn_Location);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21SDT_Receptionist", AV21SDT_Receptionist);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26Trn_Receptionist", AV26Trn_Receptionist);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19SDT_Receptionists", AV19SDT_Receptionists);
         nGXsfl_56_bak_idx = nGXsfl_56_idx;
         gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV10HasValidationErrors, sPrefix) ;
         nGXsfl_56_idx = nGXsfl_56_bak_idx;
         sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
         SubsflControlProps_562( ) ;
      }

      protected void E126U2( )
      {
         AV42GXV1 = (int)(nGXsfl_56_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( ( AV42GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV42GXV1 ) )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1));
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
         GXEncryptionTmp = "wp_createlocationandreceptionist.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wp_createlocationandreceptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11WizardData", AV11WizardData);
      }

      protected void E136U2( )
      {
         AV42GXV1 = (int)(nGXsfl_56_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( ( AV42GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV42GXV1 ) )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1));
         }
         /* 'DoUInsert' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S152 ();
         if (returnInSub) return;
         if ( AV18CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            AV20isAlreadyAdded = false;
            AV54GXV13 = 1;
            while ( AV54GXV13 <= AV19SDT_Receptionists.Count )
            {
               AV21SDT_Receptionist = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV54GXV13));
               if ( StringUtil.StrCmp(AV21SDT_Receptionist.gxTpr_Receptionistemail, AV16ReceptionistEmail) == 0 )
               {
                  AV20isAlreadyAdded = true;
                  if (true) break;
               }
               AV54GXV13 = (int)(AV54GXV13+1);
            }
            /* Using cursor H006U2 */
            pr_default.execute(0, new Object[] {AV16ReceptionistEmail});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A93ReceptionistEmail = H006U2_A93ReceptionistEmail[0];
               AV22isAlreadyRegistered = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV22isAlreadyRegistered )
            {
               GX_msglist.addItem(context.GetMessage( "The email already exists in the system", ""));
            }
            else
            {
               AV21SDT_Receptionist = new SdtSDT_Receptionists_SDT_ReceptionistsItem(context);
               AV21SDT_Receptionist.gxTpr_Receptionistid = Guid.NewGuid( );
               AV21SDT_Receptionist.gxTpr_Locationid = AV24Trn_Location.gxTpr_Locationid;
               AV21SDT_Receptionist.gxTpr_Receptionistemail = AV16ReceptionistEmail;
               AV21SDT_Receptionist.gxTpr_Receptionistgivenname = AV14ReceptionistGivenName;
               AV21SDT_Receptionist.gxTpr_Receptionistlastname = AV15ReceptionistLastName;
               AV21SDT_Receptionist.gxTpr_Receptionistphonecode = AV35ReceptionistPhoneCode;
               AV21SDT_Receptionist.gxTpr_Receptionistphonenumber = AV38ReceptionistPhoneNumber;
               GXt_char2 = "";
               new prc_concatenateintlphone(context ).execute(  AV35ReceptionistPhoneCode,  AV38ReceptionistPhoneNumber, out  GXt_char2) ;
               AV21SDT_Receptionist.gxTpr_Receptionistphone = GXt_char2;
               AV19SDT_Receptionists.Add(AV21SDT_Receptionist, 0);
               gx_BV56 = true;
               /* Execute user subroutine: 'CLEARFORMVALUES' */
               S162 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21SDT_Receptionist", AV21SDT_Receptionist);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19SDT_Receptionists", AV19SDT_Receptionists);
         nGXsfl_56_bak_idx = nGXsfl_56_idx;
         gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV10HasValidationErrors, sPrefix) ;
         nGXsfl_56_idx = nGXsfl_56_bak_idx;
         sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
         SubsflControlProps_562( ) ;
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV16ReceptionistEmail = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistemail;
         AssignAttri(sPrefix, false, "AV16ReceptionistEmail", AV16ReceptionistEmail);
         AV35ReceptionistPhoneCode = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphonecode;
         AssignAttri(sPrefix, false, "AV35ReceptionistPhoneCode", AV35ReceptionistPhoneCode);
         AV38ReceptionistPhoneNumber = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphonenumber;
         AssignAttri(sPrefix, false, "AV38ReceptionistPhoneNumber", AV38ReceptionistPhoneNumber);
         AV17ReceptionistPhone = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphone;
         AssignAttri(sPrefix, false, "AV17ReceptionistPhone", AV17ReceptionistPhone);
         AV13ReceptionistId = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistid;
         AssignAttri(sPrefix, false, "AV13ReceptionistId", AV13ReceptionistId.ToString());
         AV14ReceptionistGivenName = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistgivenname;
         AssignAttri(sPrefix, false, "AV14ReceptionistGivenName", AV14ReceptionistGivenName);
         AV15ReceptionistLastName = AV11WizardData.gxTpr_Step2.gxTpr_Receptionistlastname;
         AssignAttri(sPrefix, false, "AV15ReceptionistLastName", AV15ReceptionistLastName);
         AV19SDT_Receptionists = AV11WizardData.gxTpr_Step2.gxTpr_Sdt_receptionists;
         gx_BV56 = true;
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistemail = AV16ReceptionistEmail;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphonecode = AV35ReceptionistPhoneCode;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphonenumber = AV38ReceptionistPhoneNumber;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistphone = AV17ReceptionistPhone;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistid = AV13ReceptionistId;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistgivenname = AV14ReceptionistGivenName;
         AV11WizardData.gxTpr_Step2.gxTpr_Receptionistlastname = AV15ReceptionistLastName;
         AV11WizardData.gxTpr_Step2.gxTpr_Sdt_receptionists = AV19SDT_Receptionists;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         AV23ErrorMessages.Clear();
         AV24Trn_Location = new SdtTrn_Location(context);
         AV24Trn_Location.gxTpr_Locationid = AV11WizardData.gxTpr_Step1.gxTpr_Locationid;
         AV24Trn_Location.gxTpr_Locationname = AV11WizardData.gxTpr_Step1.gxTpr_Locationname;
         AV24Trn_Location.gxTpr_Locationemail = AV11WizardData.gxTpr_Step1.gxTpr_Locationemail;
         AV24Trn_Location.gxTpr_Locationphone = AV11WizardData.gxTpr_Step1.gxTpr_Locationphone;
         AV24Trn_Location.gxTpr_Locationphonecode = AV11WizardData.gxTpr_Step1.gxTpr_Locationphonecode;
         AV24Trn_Location.gxTpr_Locationphonenumber = AV11WizardData.gxTpr_Step1.gxTpr_Locationphonenumber;
         AV24Trn_Location.gxTpr_Locationcity = AV11WizardData.gxTpr_Step1.gxTpr_Locationcity;
         AV24Trn_Location.gxTpr_Locationzipcode = AV11WizardData.gxTpr_Step1.gxTpr_Locationzipcode;
         AV24Trn_Location.gxTpr_Locationaddressline1 = AV11WizardData.gxTpr_Step1.gxTpr_Locationaddressline1;
         AV24Trn_Location.gxTpr_Locationaddressline2 = AV11WizardData.gxTpr_Step1.gxTpr_Locationaddressline2;
         AV24Trn_Location.gxTpr_Locationdescription = AV11WizardData.gxTpr_Step1.gxTpr_Locationdescription;
         AV25isLocationInserted = AV24Trn_Location.Insert();
         if ( AV25isLocationInserted )
         {
            AV56GXV14 = 1;
            while ( AV56GXV14 <= AV19SDT_Receptionists.Count )
            {
               AV21SDT_Receptionist = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV56GXV14));
               AV26Trn_Receptionist.gxTpr_Receptionistid = AV21SDT_Receptionist.gxTpr_Receptionistid;
               AV26Trn_Receptionist.gxTpr_Receptionistgivenname = AV21SDT_Receptionist.gxTpr_Receptionistgivenname;
               AV26Trn_Receptionist.gxTpr_Receptionistlastname = AV21SDT_Receptionist.gxTpr_Receptionistlastname;
               AV26Trn_Receptionist.gxTpr_Receptionistemail = AV21SDT_Receptionist.gxTpr_Receptionistemail;
               AV26Trn_Receptionist.gxTpr_Receptionistphone = AV21SDT_Receptionist.gxTpr_Receptionistphone;
               AV26Trn_Receptionist.gxTpr_Receptionistphonecode = AV21SDT_Receptionist.gxTpr_Receptionistphonecode;
               AV26Trn_Receptionist.gxTpr_Receptionistphonenumber = AV21SDT_Receptionist.gxTpr_Receptionistphonenumber;
               AV26Trn_Receptionist.gxTpr_Locationid = AV24Trn_Location.gxTpr_Locationid;
               AV27isReceptionistInserted = AV26Trn_Receptionist.Insert();
               if ( ! AV27isReceptionistInserted )
               {
                  AV23ErrorMessages = AV26Trn_Receptionist.GetMessages();
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S172 ();
                  if (returnInSub) return;
               }
               AV56GXV14 = (int)(AV56GXV14+1);
            }
            context.CommitDataStores("wp_createlocationandreceptioniststep2",pr_default);
            /* Execute user subroutine: 'CLEARFORMVALUES' */
            S162 ();
            if (returnInSub) return;
            AV19SDT_Receptionists.Clear();
            gx_BV56 = true;
            if ( AV23ErrorMessages.Count > 0 )
            {
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S172 ();
               if (returnInSub) return;
            }
            else
            {
               CallWebObject(formatLink("trn_locationww.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else
         {
            AV23ErrorMessages = AV24Trn_Location.GetMessages();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S172 ();
            if (returnInSub) return;
         }
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV18CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14ReceptionistGivenName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "First Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavReceptionistgivenname_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15ReceptionistLastName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Last Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavReceptionistlastname_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ReceptionistEmail)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavReceptionistemail_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35ReceptionistPhoneCode)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Phone", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_receptionistphonecode_Ddointernalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38ReceptionistPhoneNumber)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Receptionist Phone Number", ""), "", "", "", "", "", "", "", ""),  "error",  edtavReceptionistphonenumber_Internalname,  "true",  ""));
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ReceptionistEmail)) && ! GxRegex.IsMatch(AV16ReceptionistEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            AV18CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV18CheckRequiredFieldsResult", AV18CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBORECEPTIONISTPHONECODE' Routine */
         returnInSub = false;
         AV58GXV16 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV57GXV15;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV57GXV15 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV58GXV16 <= AV57GXV15.Count )
         {
            AV37ReceptionistPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV57GXV15.Item(AV58GXV16));
            AV29Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV29Combo_DataItem.gxTpr_Id = AV37ReceptionistPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV31ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV31ComboTitles.Add(AV37ReceptionistPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV31ComboTitles.Add(AV37ReceptionistPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV29Combo_DataItem.gxTpr_Title = AV31ComboTitles.ToJSonString(false);
            AV36ReceptionistPhoneCode_Data.Add(AV29Combo_DataItem, 0);
            AV58GXV16 = (int)(AV58GXV16+1);
         }
         AV36ReceptionistPhoneCode_Data.Sort("Title");
         Combo_receptionistphonecode_Selectedvalue_set = AV35ReceptionistPhoneCode;
         ucCombo_receptionistphonecode.SendProperty(context, sPrefix, false, Combo_receptionistphonecode_Internalname, "SelectedValue_set", Combo_receptionistphonecode_Selectedvalue_set);
      }

      protected void E166U2( )
      {
         AV42GXV1 = (int)(nGXsfl_56_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( ( AV42GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV42GXV1 ) )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1));
         }
         /* Udelete_Click Routine */
         returnInSub = false;
         AV19SDT_Receptionists.RemoveItem(AV19SDT_Receptionists.IndexOf(((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem))));
         gx_BV56 = true;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19SDT_Receptionists", AV19SDT_Receptionists);
         nGXsfl_56_bak_idx = nGXsfl_56_idx;
         gxgrGridsdt_receptionistss_refresh( subGridsdt_receptionistss_Rows, AV10HasValidationErrors, sPrefix) ;
         nGXsfl_56_idx = nGXsfl_56_bak_idx;
         sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
         SubsflControlProps_562( ) ;
      }

      protected void E176U2( )
      {
         AV42GXV1 = (int)(nGXsfl_56_idx+GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage);
         if ( ( AV42GXV1 > 0 ) && ( AV19SDT_Receptionists.Count >= AV42GXV1 ) )
         {
            AV19SDT_Receptionists.CurrentItem = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1));
         }
         /* Uupdate_Click Routine */
         returnInSub = false;
         AV59Indextoedit = (decimal)(AV19SDT_Receptionists.IndexOf(((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem))));
         AV16ReceptionistEmail = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistemail;
         AssignAttri(sPrefix, false, "AV16ReceptionistEmail", AV16ReceptionistEmail);
         AV14ReceptionistGivenName = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistgivenname;
         AssignAttri(sPrefix, false, "AV14ReceptionistGivenName", AV14ReceptionistGivenName);
         AV15ReceptionistLastName = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistlastname;
         AssignAttri(sPrefix, false, "AV15ReceptionistLastName", AV15ReceptionistLastName);
         AV17ReceptionistPhone = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistphone;
         AssignAttri(sPrefix, false, "AV17ReceptionistPhone", AV17ReceptionistPhone);
         AV38ReceptionistPhoneNumber = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistphonenumber;
         AssignAttri(sPrefix, false, "AV38ReceptionistPhoneNumber", AV38ReceptionistPhoneNumber);
         AV13ReceptionistId = ((SdtSDT_Receptionists_SDT_ReceptionistsItem)(AV19SDT_Receptionists.CurrentItem)).gxTpr_Receptionistid;
         AssignAttri(sPrefix, false, "AV13ReceptionistId", AV13ReceptionistId.ToString());
         if ( AV21SDT_Receptionist.gxTpr_Receptionistid == AV13ReceptionistId )
         {
            AV21SDT_Receptionist.gxTpr_Locationid = AV24Trn_Location.gxTpr_Locationid;
            AV21SDT_Receptionist.gxTpr_Receptionistemail = AV16ReceptionistEmail;
            AV21SDT_Receptionist.gxTpr_Receptionistgivenname = AV14ReceptionistGivenName;
            AV21SDT_Receptionist.gxTpr_Receptionistlastname = AV15ReceptionistLastName;
            AV21SDT_Receptionist.gxTpr_Receptionistphonecode = AV35ReceptionistPhoneCode;
            AV21SDT_Receptionist.gxTpr_Receptionistphonenumber = AV38ReceptionistPhoneNumber;
            GXt_char2 = "";
            new prc_concatenateintlphone(context ).execute(  AV35ReceptionistPhoneCode,  AV38ReceptionistPhoneNumber, out  GXt_char2) ;
            AV21SDT_Receptionist.gxTpr_Receptionistphone = GXt_char2;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21SDT_Receptionist", AV21SDT_Receptionist);
      }

      protected void S162( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV16ReceptionistEmail = "";
         AssignAttri(sPrefix, false, "AV16ReceptionistEmail", AV16ReceptionistEmail);
         AV14ReceptionistGivenName = "";
         AssignAttri(sPrefix, false, "AV14ReceptionistGivenName", AV14ReceptionistGivenName);
         AV15ReceptionistLastName = "";
         AssignAttri(sPrefix, false, "AV15ReceptionistLastName", AV15ReceptionistLastName);
         AV17ReceptionistPhone = "";
         AssignAttri(sPrefix, false, "AV17ReceptionistPhone", AV17ReceptionistPhone);
         AV38ReceptionistPhoneNumber = "";
         AssignAttri(sPrefix, false, "AV38ReceptionistPhoneNumber", AV38ReceptionistPhoneNumber);
      }

      protected void S172( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV60GXV17 = 1;
         while ( AV60GXV17 <= AV23ErrorMessages.Count )
         {
            AV28Error = ((GeneXus.Utils.SdtMessages_Message)AV23ErrorMessages.Item(AV60GXV17));
            GX_msglist.addItem(context.GetMessage( "Error: ", "")+AV28Error.gxTpr_Description);
            AV60GXV17 = (int)(AV60GXV17+1);
         }
      }

      protected void wb_table1_41_6U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedreceptionistphonecode_Internalname, tblTablemergedreceptionistphonecode_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucCombo_receptionistphonecode.SetProperty("Caption", Combo_receptionistphonecode_Caption);
            ucCombo_receptionistphonecode.SetProperty("Cls", Combo_receptionistphonecode_Cls);
            ucCombo_receptionistphonecode.SetProperty("EmptyItem", Combo_receptionistphonecode_Emptyitem);
            ucCombo_receptionistphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV32DDO_TitleSettingsIcons);
            ucCombo_receptionistphonecode.SetProperty("DropDownOptionsData", AV36ReceptionistPhoneCode_Data);
            ucCombo_receptionistphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_receptionistphonecode_Internalname, sPrefix+"COMBO_RECEPTIONISTPHONECODEContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='Required'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistphonenumber_Internalname, context.GetMessage( "Receptionist Phone Number", ""), "gx-form-item AttributePhoneNumberLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistphonenumber_Internalname, AV38ReceptionistPhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV38ReceptionistPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistphonenumber_Jsonclick, 0, "AttributePhoneNumber", "", "", "", "", 1, edtavReceptionistphonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateLocationAndReceptionistStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_41_6U2e( true) ;
         }
         else
         {
            wb_table1_41_6U2e( false) ;
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
         PA6U2( ) ;
         WS6U2( ) ;
         WE6U2( ) ;
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
         PA6U2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createlocationandreceptioniststep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6U2( ) ;
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
         PA6U2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6U2( ) ;
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
         WS6U2( ) ;
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
         WE6U2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024102518404550", true, true);
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
         context.AddJavascriptSource("wp_createlocationandreceptioniststep2.js", "?2024102518404551", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_562( )
      {
         edtavSdt_receptionists__receptionistid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTID_"+sGXsfl_56_idx;
         edtavSdt_receptionists__receptionistgivenname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME_"+sGXsfl_56_idx;
         edtavSdt_receptionists__receptionistlastname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME_"+sGXsfl_56_idx;
         edtavSdt_receptionists__receptionistemail_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL_"+sGXsfl_56_idx;
         edtavSdt_receptionists__receptionistphone_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONE_"+sGXsfl_56_idx;
         edtavSdt_receptionists__receptionistphonecode_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONECODE_"+sGXsfl_56_idx;
         edtavSdt_receptionists__receptionistphonenumber_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONENUMBER_"+sGXsfl_56_idx;
         edtavSdt_receptionists__receptioniststatus_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTSTATUS_"+sGXsfl_56_idx;
         edtavSdt_receptionists__locationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__LOCATIONID_"+sGXsfl_56_idx;
         edtavSdt_receptionists__receptionistgamguid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGAMGUID_"+sGXsfl_56_idx;
         edtavSdt_receptionists__organisationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__ORGANISATIONID_"+sGXsfl_56_idx;
         edtavUupdate_Internalname = sPrefix+"vUUPDATE_"+sGXsfl_56_idx;
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_56_idx;
      }

      protected void SubsflControlProps_fel_562( )
      {
         edtavSdt_receptionists__receptionistid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTID_"+sGXsfl_56_fel_idx;
         edtavSdt_receptionists__receptionistgivenname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME_"+sGXsfl_56_fel_idx;
         edtavSdt_receptionists__receptionistlastname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME_"+sGXsfl_56_fel_idx;
         edtavSdt_receptionists__receptionistemail_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL_"+sGXsfl_56_fel_idx;
         edtavSdt_receptionists__receptionistphone_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONE_"+sGXsfl_56_fel_idx;
         edtavSdt_receptionists__receptionistphonecode_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONECODE_"+sGXsfl_56_fel_idx;
         edtavSdt_receptionists__receptionistphonenumber_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONENUMBER_"+sGXsfl_56_fel_idx;
         edtavSdt_receptionists__receptioniststatus_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTSTATUS_"+sGXsfl_56_fel_idx;
         edtavSdt_receptionists__locationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__LOCATIONID_"+sGXsfl_56_fel_idx;
         edtavSdt_receptionists__receptionistgamguid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGAMGUID_"+sGXsfl_56_fel_idx;
         edtavSdt_receptionists__organisationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__ORGANISATIONID_"+sGXsfl_56_fel_idx;
         edtavUupdate_Internalname = sPrefix+"vUUPDATE_"+sGXsfl_56_fel_idx;
         edtavUdelete_Internalname = sPrefix+"vUDELETE_"+sGXsfl_56_fel_idx;
      }

      protected void sendrow_562( )
      {
         sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
         SubsflControlProps_562( ) ;
         WB6U0( ) ;
         if ( ( subGridsdt_receptionistss_Rows * 1 == 0 ) || ( nGXsfl_56_idx <= subGridsdt_receptionistss_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridsdt_receptionistssRow = GXWebRow.GetNew(context,Gridsdt_receptionistssContainer);
            if ( subGridsdt_receptionistss_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdt_receptionistss_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdt_receptionistss_Class, "") != 0 )
               {
                  subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Odd";
               }
            }
            else if ( subGridsdt_receptionistss_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdt_receptionistss_Backstyle = 0;
               subGridsdt_receptionistss_Backcolor = subGridsdt_receptionistss_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdt_receptionistss_Class, "") != 0 )
               {
                  subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Uniform";
               }
            }
            else if ( subGridsdt_receptionistss_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdt_receptionistss_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdt_receptionistss_Class, "") != 0 )
               {
                  subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Odd";
               }
               subGridsdt_receptionistss_Backcolor = (int)(0x0);
            }
            else if ( subGridsdt_receptionistss_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdt_receptionistss_Backstyle = 1;
               if ( ((int)((nGXsfl_56_idx) % (2))) == 0 )
               {
                  subGridsdt_receptionistss_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_receptionistss_Class, "") != 0 )
                  {
                     subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Even";
                  }
               }
               else
               {
                  subGridsdt_receptionistss_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_receptionistss_Class, "") != 0 )
                  {
                     subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Odd";
                  }
               }
            }
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_56_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistid_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Receptionistid.ToString(),((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Receptionistid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptionistid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)56,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',56)\"";
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistgivenname_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Receptionistgivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistgivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_receptionists__receptionistgivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)56,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',56)\"";
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistlastname_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Receptionistlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_receptionists__receptionistlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)56,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',56)\"";
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistemail_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Receptionistemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_receptionists__receptionistemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)56,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',56)\"";
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistphone_Internalname,StringUtil.RTrim( ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Receptionistphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_receptionists__receptionistphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)56,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistphonecode_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Receptionistphonecode,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistphonecode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptionistphonecode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)56,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistphonenumber_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Receptionistphonenumber,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistphonenumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptionistphonenumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)56,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptioniststatus_Internalname,StringUtil.RTrim( ((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Receptioniststatus),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptioniststatus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptioniststatus_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)56,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__locationid_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)56,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__receptionistgamguid_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Receptionistgamguid,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__receptionistgamguid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__receptionistgamguid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)56,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_receptionists__organisationid_Internalname,((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_Receptionists_SDT_ReceptionistsItem)AV19SDT_Receptionists.Item(AV42GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_receptionists__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_receptionists__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)56,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',56)\"";
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUupdate_Internalname,StringUtil.RTrim( AV41UUpdate),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUUPDATE.CLICK."+sGXsfl_56_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUupdate_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUupdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)56,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'" + sGXsfl_56_idx + "',56)\"";
            ROClassString = "Attribute";
            Gridsdt_receptionistssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUdelete_Internalname,StringUtil.RTrim( AV12UDelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUDELETE.CLICK."+sGXsfl_56_idx+"'",(string)"",(string)"",context.GetMessage( "Delete item", ""),(string)"",(string)edtavUdelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUdelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)56,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes6U2( ) ;
            Gridsdt_receptionistssContainer.AddRow(Gridsdt_receptionistssRow);
            nGXsfl_56_idx = ((subGridsdt_receptionistss_Islastpage==1)&&(nGXsfl_56_idx+1>subGridsdt_receptionistss_fnc_Recordsperpage( )) ? 1 : nGXsfl_56_idx+1);
            sGXsfl_56_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_56_idx), 4, 0), 4, "0");
            SubsflControlProps_562( ) ;
         }
         /* End function sendrow_562 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl56( )
      {
         if ( Gridsdt_receptionistssContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_receptionistssContainer"+"DivS\" data-gxgridid=\"56\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridsdt_receptionistss_Internalname, subGridsdt_receptionistss_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridsdt_receptionistss_Backcolorstyle == 0 )
            {
               subGridsdt_receptionistss_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridsdt_receptionistss_Class) > 0 )
               {
                  subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Title";
               }
            }
            else
            {
               subGridsdt_receptionistss_Titlebackstyle = 1;
               if ( subGridsdt_receptionistss_Backcolorstyle == 1 )
               {
                  subGridsdt_receptionistss_Titlebackcolor = subGridsdt_receptionistss_Allbackcolor;
                  if ( StringUtil.Len( subGridsdt_receptionistss_Class) > 0 )
                  {
                     subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridsdt_receptionistss_Class) > 0 )
                  {
                     subGridsdt_receptionistss_Linesclass = subGridsdt_receptionistss_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Receptionist Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "First Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone Code", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Receptionist Status", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Receptionist GAMGUID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridsdt_receptionistssContainer.AddObjectProperty("GridName", "Gridsdt_receptionistss");
         }
         else
         {
            Gridsdt_receptionistssContainer.AddObjectProperty("GridName", "Gridsdt_receptionistss");
            Gridsdt_receptionistssContainer.AddObjectProperty("Header", subGridsdt_receptionistss_Header);
            Gridsdt_receptionistssContainer.AddObjectProperty("Class", "WorkWith");
            Gridsdt_receptionistssContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Backcolorstyle), 1, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("CmpContext", sPrefix);
            Gridsdt_receptionistssContainer.AddObjectProperty("InMasterPage", "false");
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistid_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistgivenname_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistlastname_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistemail_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistphone_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistphonecode_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistphonenumber_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptioniststatus_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__locationid_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__receptionistgamguid_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_receptionists__organisationid_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV41UUpdate)));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUupdate_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_receptionistssColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12UDelete)));
            Gridsdt_receptionistssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUdelete_Enabled), 5, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddColumnProperties(Gridsdt_receptionistssColumn);
            Gridsdt_receptionistssContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Selectedindex), 4, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Allowselection), 1, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Selectioncolor), 9, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Allowhovering), 1, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Hoveringcolor), 9, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Allowcollapsing), 1, 0, ".", "")));
            Gridsdt_receptionistssContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_receptionistss_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavReceptionistgivenname_Internalname = sPrefix+"vRECEPTIONISTGIVENNAME";
         edtavReceptionistlastname_Internalname = sPrefix+"vRECEPTIONISTLASTNAME";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         edtavReceptionistemail_Internalname = sPrefix+"vRECEPTIONISTEMAIL";
         lblTextblockcombo_receptionistphonecode_Internalname = sPrefix+"TEXTBLOCKCOMBO_RECEPTIONISTPHONECODE";
         Combo_receptionistphonecode_Internalname = sPrefix+"COMBO_RECEPTIONISTPHONECODE";
         edtavReceptionistphonenumber_Internalname = sPrefix+"vRECEPTIONISTPHONENUMBER";
         tblTablemergedreceptionistphonecode_Internalname = sPrefix+"TABLEMERGEDRECEPTIONISTPHONECODE";
         divTablesplittedreceptionistphonecode_Internalname = sPrefix+"TABLESPLITTEDRECEPTIONISTPHONECODE";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         divFormtable_Internalname = sPrefix+"FORMTABLE";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         bttBtnuinsert_Internalname = sPrefix+"BTNUINSERT";
         edtavSdt_receptionists__receptionistid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTID";
         edtavSdt_receptionists__receptionistgivenname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGIVENNAME";
         edtavSdt_receptionists__receptionistlastname_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTLASTNAME";
         edtavSdt_receptionists__receptionistemail_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTEMAIL";
         edtavSdt_receptionists__receptionistphone_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONE";
         edtavSdt_receptionists__receptionistphonecode_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONECODE";
         edtavSdt_receptionists__receptionistphonenumber_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTPHONENUMBER";
         edtavSdt_receptionists__receptioniststatus_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTSTATUS";
         edtavSdt_receptionists__locationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__LOCATIONID";
         edtavSdt_receptionists__receptionistgamguid_Internalname = sPrefix+"SDT_RECEPTIONISTS__RECEPTIONISTGAMGUID";
         edtavSdt_receptionists__organisationid_Internalname = sPrefix+"SDT_RECEPTIONISTS__ORGANISATIONID";
         edtavUupdate_Internalname = sPrefix+"vUUPDATE";
         edtavUdelete_Internalname = sPrefix+"vUDELETE";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardlastnext_Internalname = sPrefix+"BTNWIZARDLASTNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavReceptionistphonecode_Internalname = sPrefix+"vRECEPTIONISTPHONECODE";
         edtavReceptionistphone_Internalname = sPrefix+"vRECEPTIONISTPHONE";
         edtavReceptionistid_Internalname = sPrefix+"vRECEPTIONISTID";
         Gridsdt_receptionistss_empowerer_Internalname = sPrefix+"GRIDSDT_RECEPTIONISTSS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridsdt_receptionistss_Internalname = sPrefix+"GRIDSDT_RECEPTIONISTSS";
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
         subGridsdt_receptionistss_Allowcollapsing = 0;
         subGridsdt_receptionistss_Allowselection = 0;
         subGridsdt_receptionistss_Header = "";
         edtavUdelete_Jsonclick = "";
         edtavUdelete_Enabled = 1;
         edtavUupdate_Jsonclick = "";
         edtavUupdate_Enabled = 1;
         edtavSdt_receptionists__organisationid_Jsonclick = "";
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavSdt_receptionists__receptionistgamguid_Jsonclick = "";
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
         edtavSdt_receptionists__locationid_Jsonclick = "";
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__receptioniststatus_Jsonclick = "";
         edtavSdt_receptionists__receptioniststatus_Enabled = 0;
         edtavSdt_receptionists__receptionistphonenumber_Jsonclick = "";
         edtavSdt_receptionists__receptionistphonenumber_Enabled = 0;
         edtavSdt_receptionists__receptionistphonecode_Jsonclick = "";
         edtavSdt_receptionists__receptionistphonecode_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Jsonclick = "";
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Jsonclick = "";
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Jsonclick = "";
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Jsonclick = "";
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__receptionistid_Jsonclick = "";
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         subGridsdt_receptionistss_Class = "WorkWith";
         subGridsdt_receptionistss_Backcolorstyle = 0;
         edtavReceptionistphonenumber_Jsonclick = "";
         edtavReceptionistphonenumber_Enabled = 1;
         Combo_receptionistphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_receptionistphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_receptionistphonecode_Caption = "";
         Combo_receptionistphonecode_Htmltemplate = "";
         edtavReceptionistid_Jsonclick = "";
         edtavReceptionistid_Visible = 1;
         edtavReceptionistphone_Jsonclick = "";
         edtavReceptionistphone_Visible = 1;
         edtavReceptionistphonecode_Jsonclick = "";
         edtavReceptionistphonecode_Visible = 1;
         Btnwizardlastnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardlastnext_Caption = context.GetMessage( "WWP_WizardFinishCaption", "");
         Btnwizardlastnext_Tooltiptext = "";
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = context.GetMessage( "GXM_previous", "");
         Btnwizardprevious_Tooltiptext = "";
         edtavReceptionistemail_Jsonclick = "";
         edtavReceptionistemail_Enabled = 1;
         edtavReceptionistlastname_Jsonclick = "";
         edtavReceptionistlastname_Enabled = 1;
         edtavReceptionistgivenname_Jsonclick = "";
         edtavReceptionistgivenname_Enabled = 1;
         edtavSdt_receptionists__organisationid_Enabled = -1;
         edtavSdt_receptionists__receptionistgamguid_Enabled = -1;
         edtavSdt_receptionists__locationid_Enabled = -1;
         edtavSdt_receptionists__receptioniststatus_Enabled = -1;
         edtavSdt_receptionists__receptionistphonenumber_Enabled = -1;
         edtavSdt_receptionists__receptionistphonecode_Enabled = -1;
         edtavSdt_receptionists__receptionistphone_Enabled = -1;
         edtavSdt_receptionists__receptionistemail_Enabled = -1;
         edtavSdt_receptionists__receptionistlastname_Enabled = -1;
         edtavSdt_receptionists__receptionistgivenname_Enabled = -1;
         edtavSdt_receptionists__receptionistid_Enabled = -1;
         subGridsdt_receptionistss_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]}""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS.LOAD","""{"handler":"E156U2","iparms":[]""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS.LOAD",""","oparms":[{"av":"AV41UUpdate","fld":"vUUPDATE"},{"av":"AV12UDelete","fld":"vUDELETE"}]}""");
         setEventMetadata("ENTER","""{"handler":"E116U2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV35ReceptionistPhoneCode","fld":"vRECEPTIONISTPHONECODE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"},{"av":"AV17ReceptionistPhone","fld":"vRECEPTIONISTPHONE"},{"av":"AV13ReceptionistId","fld":"vRECEPTIONISTID"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56},{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV26Trn_Receptionist","fld":"vTRN_RECEPTIONIST"},{"av":"Combo_receptionistphonecode_Ddointernalname","ctrl":"COMBO_RECEPTIONISTPHONECODE","prop":"DDOInternalName"},{"av":"AV23ErrorMessages","fld":"vERRORMESSAGES"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"},{"av":"AV23ErrorMessages","fld":"vERRORMESSAGES"},{"av":"AV24Trn_Location","fld":"vTRN_LOCATION"},{"av":"AV21SDT_Receptionist","fld":"vSDT_RECEPTIONIST"},{"av":"AV26Trn_Receptionist","fld":"vTRN_RECEPTIONIST"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56},{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV17ReceptionistPhone","fld":"vRECEPTIONISTPHONE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E126U2","iparms":[{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV35ReceptionistPhoneCode","fld":"vRECEPTIONISTPHONECODE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"},{"av":"AV17ReceptionistPhone","fld":"vRECEPTIONISTPHONE"},{"av":"AV13ReceptionistId","fld":"vRECEPTIONISTID"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV11WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOUINSERT'","""{"handler":"E136U2","iparms":[{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"A93ReceptionistEmail","fld":"RECEPTIONISTEMAIL"},{"av":"AV24Trn_Location","fld":"vTRN_LOCATION"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV35ReceptionistPhoneCode","fld":"vRECEPTIONISTPHONECODE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"},{"av":"Combo_receptionistphonecode_Ddointernalname","ctrl":"COMBO_RECEPTIONISTPHONECODE","prop":"DDOInternalName"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("'DOUINSERT'",""","oparms":[{"av":"AV21SDT_Receptionist","fld":"vSDT_RECEPTIONIST"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56},{"av":"AV18CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV17ReceptionistPhone","fld":"vRECEPTIONISTPHONE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"}]}""");
         setEventMetadata("VUDELETE.CLICK","""{"handler":"E166U2","iparms":[{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VUDELETE.CLICK",""","oparms":[{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56}]}""");
         setEventMetadata("VUUPDATE.CLICK","""{"handler":"E176U2","iparms":[{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56},{"av":"AV21SDT_Receptionist","fld":"vSDT_RECEPTIONIST"},{"av":"AV24Trn_Location","fld":"vTRN_LOCATION"},{"av":"AV35ReceptionistPhoneCode","fld":"vRECEPTIONISTPHONECODE"}]""");
         setEventMetadata("VUUPDATE.CLICK",""","oparms":[{"av":"AV16ReceptionistEmail","fld":"vRECEPTIONISTEMAIL"},{"av":"AV14ReceptionistGivenName","fld":"vRECEPTIONISTGIVENNAME"},{"av":"AV15ReceptionistLastName","fld":"vRECEPTIONISTLASTNAME"},{"av":"AV17ReceptionistPhone","fld":"vRECEPTIONISTPHONE"},{"av":"AV38ReceptionistPhoneNumber","fld":"vRECEPTIONISTPHONENUMBER"},{"av":"AV13ReceptionistId","fld":"vRECEPTIONISTID"},{"av":"AV21SDT_Receptionist","fld":"vSDT_RECEPTIONIST"}]}""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_FIRSTPAGE","""{"handler":"subgridsdt_receptionistss_firstpage","iparms":[{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_PREVPAGE","""{"handler":"subgridsdt_receptionistss_previouspage","iparms":[{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_NEXTPAGE","""{"handler":"subgridsdt_receptionistss_nextpage","iparms":[{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("GRIDSDT_RECEPTIONISTSS_LASTPAGE","""{"handler":"subgridsdt_receptionistss_lastpage","iparms":[{"av":"GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage"},{"av":"GRIDSDT_RECEPTIONISTSS_nEOF"},{"av":"AV19SDT_Receptionists","fld":"vSDT_RECEPTIONISTS","grid":56},{"av":"nGXsfl_56_idx","ctrl":"GRID","prop":"GridCurrRow","grid":56},{"av":"nRC_GXsfl_56","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"GridRC","grid":56},{"av":"subGridsdt_receptionistss_Rows","ctrl":"GRIDSDT_RECEPTIONISTSS","prop":"Rows"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"}]}""");
         setEventMetadata("VALIDV_RECEPTIONISTEMAIL","""{"handler":"Validv_Receptionistemail","iparms":[]}""");
         setEventMetadata("VALIDV_RECEPTIONISTID","""{"handler":"Validv_Receptionistid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV5","""{"handler":"Validv_Gxv5","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV12","""{"handler":"Validv_Gxv12","iparms":[]}""");
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
         Combo_receptionistphonecode_Ddointernalname = "";
         Combo_receptionistphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV19SDT_Receptionists = new GXBaseCollection<SdtSDT_Receptionists_SDT_ReceptionistsItem>( context, "SDT_ReceptionistsItem", "Comforta_version2");
         AV32DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV36ReceptionistPhoneCode_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV11WizardData = new SdtWP_CreateLocationAndReceptionistData(context);
         AV26Trn_Receptionist = new SdtTrn_Receptionist(context);
         AV23ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         A93ReceptionistEmail = "";
         AV24Trn_Location = new SdtTrn_Location(context);
         AV21SDT_Receptionist = new SdtSDT_Receptionists_SDT_ReceptionistsItem(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV14ReceptionistGivenName = "";
         AV15ReceptionistLastName = "";
         AV16ReceptionistEmail = "";
         lblTextblockcombo_receptionistphonecode_Jsonclick = "";
         bttBtnuinsert_Jsonclick = "";
         Gridsdt_receptionistssContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardlastnext = new GXUserControl();
         AV35ReceptionistPhoneCode = "";
         AV17ReceptionistPhone = "";
         AV13ReceptionistId = Guid.Empty;
         ucGridsdt_receptionistss_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV41UUpdate = "";
         AV12UDelete = "";
         GXDecQS = "";
         AV38ReceptionistPhoneNumber = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         ucCombo_receptionistphonecode = new GXUserControl();
         Gridsdt_receptionistss_empowerer_Gridinternalname = "";
         AV33defaultCountryPhoneCode = "";
         Combo_receptionistphonecode_Selectedtext_set = "";
         Combo_receptionistphonecode_Selectedvalue_set = "";
         Gridsdt_receptionistssRow = new GXWebRow();
         AV5WebSession = context.GetSession();
         H006U2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         H006U2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006U2_A29LocationId = new Guid[] {Guid.Empty} ;
         H006U2_A93ReceptionistEmail = new string[] {""} ;
         AV57GXV15 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV37ReceptionistPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV29Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV31ComboTitles = new GxSimpleCollection<string>();
         GXt_char2 = "";
         AV28Error = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         subGridsdt_receptionistss_Linesclass = "";
         ROClassString = "";
         Gridsdt_receptionistssColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_createlocationandreceptioniststep2__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createlocationandreceptioniststep2__default(),
            new Object[][] {
                new Object[] {
               H006U2_A89ReceptionistId, H006U2_A11OrganisationId, H006U2_A29LocationId, H006U2_A93ReceptionistEmail
               }
            }
         );
         /* GeneXus formulas. */
         edtavSdt_receptionists__receptionistid_Enabled = 0;
         edtavSdt_receptionists__receptionistgivenname_Enabled = 0;
         edtavSdt_receptionists__receptionistlastname_Enabled = 0;
         edtavSdt_receptionists__receptionistemail_Enabled = 0;
         edtavSdt_receptionists__receptionistphone_Enabled = 0;
         edtavSdt_receptionists__receptionistphonecode_Enabled = 0;
         edtavSdt_receptionists__receptionistphonenumber_Enabled = 0;
         edtavSdt_receptionists__receptioniststatus_Enabled = 0;
         edtavSdt_receptionists__locationid_Enabled = 0;
         edtavSdt_receptionists__receptionistgamguid_Enabled = 0;
         edtavSdt_receptionists__organisationid_Enabled = 0;
         edtavUupdate_Enabled = 0;
         edtavUdelete_Enabled = 0;
      }

      private short GRIDSDT_RECEPTIONISTSS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGridsdt_receptionistss_Backcolorstyle ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGridsdt_receptionistss_Backstyle ;
      private short subGridsdt_receptionistss_Titlebackstyle ;
      private short subGridsdt_receptionistss_Allowselection ;
      private short subGridsdt_receptionistss_Allowhovering ;
      private short subGridsdt_receptionistss_Allowcollapsing ;
      private short subGridsdt_receptionistss_Collapsed ;
      private int nRC_GXsfl_56 ;
      private int subGridsdt_receptionistss_Rows ;
      private int nGXsfl_56_idx=1 ;
      private int edtavSdt_receptionists__receptionistid_Enabled ;
      private int edtavSdt_receptionists__receptionistgivenname_Enabled ;
      private int edtavSdt_receptionists__receptionistlastname_Enabled ;
      private int edtavSdt_receptionists__receptionistemail_Enabled ;
      private int edtavSdt_receptionists__receptionistphone_Enabled ;
      private int edtavSdt_receptionists__receptionistphonecode_Enabled ;
      private int edtavSdt_receptionists__receptionistphonenumber_Enabled ;
      private int edtavSdt_receptionists__receptioniststatus_Enabled ;
      private int edtavSdt_receptionists__locationid_Enabled ;
      private int edtavSdt_receptionists__receptionistgamguid_Enabled ;
      private int edtavSdt_receptionists__organisationid_Enabled ;
      private int edtavUupdate_Enabled ;
      private int edtavUdelete_Enabled ;
      private int edtavReceptionistgivenname_Enabled ;
      private int edtavReceptionistlastname_Enabled ;
      private int edtavReceptionistemail_Enabled ;
      private int AV42GXV1 ;
      private int edtavReceptionistphonecode_Visible ;
      private int edtavReceptionistphone_Visible ;
      private int edtavReceptionistid_Visible ;
      private int subGridsdt_receptionistss_Islastpage ;
      private int GRIDSDT_RECEPTIONISTSS_nGridOutOfScope ;
      private int nGXsfl_56_fel_idx=1 ;
      private int nGXsfl_56_bak_idx=1 ;
      private int AV54GXV13 ;
      private int AV56GXV14 ;
      private int AV58GXV16 ;
      private int AV60GXV17 ;
      private int edtavReceptionistphonenumber_Enabled ;
      private int idxLst ;
      private int subGridsdt_receptionistss_Backcolor ;
      private int subGridsdt_receptionistss_Allbackcolor ;
      private int subGridsdt_receptionistss_Titlebackcolor ;
      private int subGridsdt_receptionistss_Selectedindex ;
      private int subGridsdt_receptionistss_Selectioncolor ;
      private int subGridsdt_receptionistss_Hoveringcolor ;
      private long GRIDSDT_RECEPTIONISTSS_nFirstRecordOnPage ;
      private long GRIDSDT_RECEPTIONISTSS_nCurrentRecord ;
      private long GRIDSDT_RECEPTIONISTSS_nRecordCount ;
      private decimal AV59Indextoedit ;
      private string Combo_receptionistphonecode_Ddointernalname ;
      private string Combo_receptionistphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_56_idx="0001" ;
      private string edtavSdt_receptionists__receptionistid_Internalname ;
      private string edtavSdt_receptionists__receptionistgivenname_Internalname ;
      private string edtavSdt_receptionists__receptionistlastname_Internalname ;
      private string edtavSdt_receptionists__receptionistemail_Internalname ;
      private string edtavSdt_receptionists__receptionistphone_Internalname ;
      private string edtavSdt_receptionists__receptionistphonecode_Internalname ;
      private string edtavSdt_receptionists__receptionistphonenumber_Internalname ;
      private string edtavSdt_receptionists__receptioniststatus_Internalname ;
      private string edtavSdt_receptionists__locationid_Internalname ;
      private string edtavSdt_receptionists__receptionistgamguid_Internalname ;
      private string edtavSdt_receptionists__organisationid_Internalname ;
      private string edtavUupdate_Internalname ;
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
      private string grpUnnamedgroup1_Internalname ;
      private string divFormtable_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string edtavReceptionistgivenname_Internalname ;
      private string TempTags ;
      private string edtavReceptionistgivenname_Jsonclick ;
      private string edtavReceptionistlastname_Internalname ;
      private string edtavReceptionistlastname_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string edtavReceptionistemail_Internalname ;
      private string edtavReceptionistemail_Jsonclick ;
      private string divTablesplittedreceptionistphonecode_Internalname ;
      private string lblTextblockcombo_receptionistphonecode_Internalname ;
      private string lblTextblockcombo_receptionistphonecode_Jsonclick ;
      private string bttBtnuinsert_Internalname ;
      private string bttBtnuinsert_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGridsdt_receptionistss_Internalname ;
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
      private string edtavReceptionistphonecode_Internalname ;
      private string edtavReceptionistphonecode_Jsonclick ;
      private string edtavReceptionistphone_Internalname ;
      private string AV17ReceptionistPhone ;
      private string edtavReceptionistphone_Jsonclick ;
      private string edtavReceptionistid_Internalname ;
      private string edtavReceptionistid_Jsonclick ;
      private string Gridsdt_receptionistss_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV41UUpdate ;
      private string AV12UDelete ;
      private string GXDecQS ;
      private string sGXsfl_56_fel_idx="0001" ;
      private string edtavReceptionistphonenumber_Internalname ;
      private string Combo_receptionistphonecode_Htmltemplate ;
      private string Combo_receptionistphonecode_Internalname ;
      private string Gridsdt_receptionistss_empowerer_Gridinternalname ;
      private string Combo_receptionistphonecode_Selectedtext_set ;
      private string Combo_receptionistphonecode_Selectedvalue_set ;
      private string GXt_char2 ;
      private string tblTablemergedreceptionistphonecode_Internalname ;
      private string Combo_receptionistphonecode_Caption ;
      private string Combo_receptionistphonecode_Cls ;
      private string edtavReceptionistphonenumber_Jsonclick ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private string subGridsdt_receptionistss_Class ;
      private string subGridsdt_receptionistss_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_receptionists__receptionistid_Jsonclick ;
      private string edtavSdt_receptionists__receptionistgivenname_Jsonclick ;
      private string edtavSdt_receptionists__receptionistlastname_Jsonclick ;
      private string edtavSdt_receptionists__receptionistemail_Jsonclick ;
      private string edtavSdt_receptionists__receptionistphone_Jsonclick ;
      private string edtavSdt_receptionists__receptionistphonecode_Jsonclick ;
      private string edtavSdt_receptionists__receptionistphonenumber_Jsonclick ;
      private string edtavSdt_receptionists__receptioniststatus_Jsonclick ;
      private string edtavSdt_receptionists__locationid_Jsonclick ;
      private string edtavSdt_receptionists__receptionistgamguid_Jsonclick ;
      private string edtavSdt_receptionists__organisationid_Jsonclick ;
      private string edtavUupdate_Jsonclick ;
      private string edtavUdelete_Jsonclick ;
      private string subGridsdt_receptionistss_Header ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool bGXsfl_56_Refreshing=false ;
      private bool AV18CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV20isAlreadyAdded ;
      private bool AV22isAlreadyRegistered ;
      private bool gx_BV56 ;
      private bool AV25isLocationInserted ;
      private bool AV27isReceptionistInserted ;
      private bool Combo_receptionistphonecode_Emptyitem ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string A93ReceptionistEmail ;
      private string AV14ReceptionistGivenName ;
      private string AV15ReceptionistLastName ;
      private string AV16ReceptionistEmail ;
      private string AV35ReceptionistPhoneCode ;
      private string AV38ReceptionistPhoneNumber ;
      private string AV33defaultCountryPhoneCode ;
      private Guid AV13ReceptionistId ;
      private GXWebGrid Gridsdt_receptionistssContainer ;
      private GXWebRow Gridsdt_receptionistssRow ;
      private GXWebColumn Gridsdt_receptionistssColumn ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardlastnext ;
      private GXUserControl ucGridsdt_receptionistss_empowerer ;
      private GXUserControl ucCombo_receptionistphonecode ;
      private GXWebForm Form ;
      private IGxSession AV5WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_Receptionists_SDT_ReceptionistsItem> AV19SDT_Receptionists ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV32DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV36ReceptionistPhoneCode_Data ;
      private SdtWP_CreateLocationAndReceptionistData AV11WizardData ;
      private SdtTrn_Receptionist AV26Trn_Receptionist ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV23ErrorMessages ;
      private SdtTrn_Location AV24Trn_Location ;
      private SdtSDT_Receptionists_SDT_ReceptionistsItem AV21SDT_Receptionist ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private IDataStoreProvider pr_default ;
      private Guid[] H006U2_A89ReceptionistId ;
      private Guid[] H006U2_A11OrganisationId ;
      private Guid[] H006U2_A29LocationId ;
      private string[] H006U2_A93ReceptionistEmail ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV57GXV15 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV37ReceptionistPhoneCode_DPItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV29Combo_DataItem ;
      private GxSimpleCollection<string> AV31ComboTitles ;
      private GeneXus.Utils.SdtMessages_Message AV28Error ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_createlocationandreceptioniststep2__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_createlocationandreceptioniststep2__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH006U2;
        prmH006U2 = new Object[] {
        new ParDef("AV16ReceptionistEmail",GXType.VarChar,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("H006U2", "SELECT ReceptionistId, OrganisationId, LocationId, ReceptionistEmail FROM Trn_Receptionist WHERE ReceptionistEmail = ( :AV16ReceptionistEmail) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006U2,1, GxCacheFrequency.OFF ,false,true )
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
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
     }
  }

}

}
