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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_dfc_combobox_wc : GXWebComponent
   {
      public wwp_dfc_combobox_wc( )
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

      public wwp_dfc_combobox_wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPDynamicFormMode ,
                           short aP1_WWPFormElementId ,
                           short aP2_SessionId ,
                           ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm )
      {
         this.AV11WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV14WWPFormElementId = aP1_WWPFormElementId;
         this.AV9SessionId = aP2_SessionId;
         this.AV12WWPForm = aP3_WWPForm;
         ExecuteImpl();
         aP3_WWPForm=this.AV12WWPForm;
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
               gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
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
                  AV11WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV11WWPDynamicFormMode", AV11WWPDynamicFormMode);
                  AV14WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV14WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV14WWPFormElementId), 4, 0));
                  AV9SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV12WWPForm);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV11WWPDynamicFormMode,(short)AV14WWPFormElementId,(short)AV9SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)AV12WWPForm});
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
                  gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
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
            PA302( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS302( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form Creation_Combo Box_WC", "")) ;
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_dfc_combobox_wc.aspx"+UrlEncode(StringUtil.RTrim(AV11WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV14WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV9SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_dfc_combobox_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV7IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV7IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV8IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV8IsLastElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV24ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV24ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV20WWP_DynamicFormDataType), "Z9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDATA_DATA", AV15Data_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDATA_DATA", AV15Data_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11WWPDynamicFormMode", StringUtil.RTrim( wcpOAV11WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV14WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV14WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV9SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV7IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV7IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV8IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV8IsLastElement, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vNEEDTORELOADWC", AV19NeedToReloadWC);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMELEMENT", AV13WWPFormElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMELEMENT", AV13WWPFormElement);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV24ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV24ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV20WWP_DynamicFormDataType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DF_CHARCONTROLTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21WWP_DF_CharControlType), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vALLOWMULTIPLESELECTION", AV22AllowMultipleSelection);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMS_CHAR_MULTIPLEOPTIONS_CONTROLTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23WWP_DynamicForms_Char_MultipleOptions_ControlType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV10WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV10WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV11WWPDynamicFormMode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORM", AV12WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORM", AV12WWPForm);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDATA", AV5Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDATA", AV5Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Selectedvalue_get", StringUtil.RTrim( Combo_data_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENT_Wwpformelementmetadata", AV13WWPFormElement.gxTpr_Wwpformelementmetadata);
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndeleteelement_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"SETTINGS_MODAL_Result", StringUtil.RTrim( Settings_modal_Result));
      }

      protected void RenderHtmlCloseForm302( )
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
            if ( ! ( WebComp_Wwpaux_wc == null ) )
            {
               WebComp_Wwpaux_wc.componentjscripts();
            }
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
         return "WorkWithPlus.DynamicForms.WWP_DFC_ComboBox_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form Creation_Combo Box_WC", "") ;
      }

      protected void WB300( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_dfc_combobox_wc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableDynFormAddedElement", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatatitlecell_Internalname, divDatatitlecell_Visible, 0, "px", 0, "px", divDatatitlecell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatatitle_Internalname, lblDatatitle_Caption, "", "", lblDatatitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DynFormDataDescription", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DFC_ComboBox_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatacellname_Internalname, 1, 0, "px", 0, "px", divDatacellname_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplitteddata_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_data_Internalname, lblTextblockcombo_data_Caption, "", "", lblTextblockcombo_data_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DFC_ComboBox_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_data.SetProperty("Caption", Combo_data_Caption);
            ucCombo_data.SetProperty("Cls", Combo_data_Cls);
            ucCombo_data.SetProperty("AllowMultipleSelection", Combo_data_Allowmultipleselection);
            ucCombo_data.SetProperty("IncludeOnlySelectedOption", Combo_data_Includeonlyselectedoption);
            ucCombo_data.SetProperty("MultipleValuesType", Combo_data_Multiplevaluestype);
            ucCombo_data.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
            ucCombo_data.SetProperty("DropDownOptionsData", AV15Data_Data);
            ucCombo_data.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_data_Internalname, sPrefix+"COMBO_DATAContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 TableDynAddElementActionsCell", "end", "top", "", "", "div");
            wb_table1_20_302( true) ;
         }
         else
         {
            wb_table1_20_302( false) ;
         }
         return  ;
      }

      protected void wb_table1_20_302e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "end", "top", "div");
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
            wb_table2_33_302( true) ;
         }
         else
         {
            wb_table2_33_302( false) ;
         }
         return  ;
      }

      protected void wb_table2_33_302e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_38_302( true) ;
         }
         else
         {
            wb_table3_38_302( false) ;
         }
         return  ;
      }

      protected void wb_table3_38_302e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0044"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0044"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0044"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START302( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form Creation_Combo Box_WC", ""), 0) ;
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
               STRUP300( ) ;
            }
         }
      }

      protected void WS302( )
      {
         START302( ) ;
         EVT302( ) ;
      }

      protected void EVT302( )
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
                                 STRUP300( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_btndeleteelement.Close */
                                    E11302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Close */
                                    E12302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETTINGS_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Settings_modal.Onloadcomponent */
                                    E13302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E14302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E15302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEUP'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveUp' */
                                    E16302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMOVEDOWN'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMoveDown' */
                                    E17302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18302 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
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
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP300( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 44 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0044");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0044", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE302( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm302( ) ;
            }
         }
      }

      protected void PA302( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_combobox_wc.aspx")), "workwithplus.dynamicforms.wwp_dfc_combobox_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_dfc_combobox_wc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         RF302( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF302( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E15302 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E18302 ();
            WB300( ) ;
         }
      }

      protected void send_integrity_lvl_hashes302( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISFIRSTELEMENT", AV7IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV7IsFirstElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISLASTELEMENT", AV8IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV8IsLastElement, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vPARENTISGRIDMULTIPLEDATA", AV24ParentIsGridMultipleData);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPARENTISGRIDMULTIPLEDATA", GetSecureSignedToken( sPrefix, AV24ParentIsGridMultipleData, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWP_DYNAMICFORMDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20WWP_DynamicFormDataType), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV20WWP_DynamicFormDataType), "Z9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP300( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14302 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDATA_DATA"), AV15Data_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDATA"), AV5Data);
            /* Read saved values. */
            wcpOAV11WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV11WWPDynamicFormMode");
            wcpOAV14WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV14WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_btndeleteelement_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT_Result");
            Settings_modal_Result = cgiGet( sPrefix+"SETTINGS_MODAL_Result");
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
         E14302 ();
         if (returnInSub) return;
      }

      protected void E14302( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtWWP_Form_Element1 = AV13WWPFormElement;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV12WWPForm,  AV14WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
         AV13WWPFormElement = GXt_SdtWWP_Form_Element1;
         AV20WWP_DynamicFormDataType = AV13WWPFormElement.gxTpr_Wwpformelementdatatype;
         AssignAttri(sPrefix, false, "AV20WWP_DynamicFormDataType", StringUtil.LTrimStr( (decimal)(AV20WWP_DynamicFormDataType), 2, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DYNAMICFORMDATATYPE", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV20WWP_DynamicFormDataType), "Z9"), context));
         /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
         S112 ();
         if (returnInSub) return;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_canmoveelement(context ).execute(  AV12WWPForm,  AV13WWPFormElement, out  AV7IsFirstElement, out  AV8IsLastElement) ;
         AssignAttri(sPrefix, false, "AV7IsFirstElement", AV7IsFirstElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISFIRSTELEMENT", GetSecureSignedToken( sPrefix, AV7IsFirstElement, context));
         AssignAttri(sPrefix, false, "AV8IsLastElement", AV8IsLastElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISLASTELEMENT", GetSecureSignedToken( sPrefix, AV8IsLastElement, context));
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_showsmallbuttons(context).executeUdp( ref  AV12WWPForm,  AV13WWPFormElement.gxTpr_Wwpformelementparentid,  false, out  AV24ParentIsGridMultipleData) )
         {
            Btnmoveup_Caption = "";
            ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Caption", Btnmoveup_Caption);
            Btnmovedown_Caption = "";
            ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Caption", Btnmovedown_Caption);
            Btnsettings_Caption = "";
            ucBtnsettings.SendProperty(context, sPrefix, false, Btnsettings_Internalname, "Caption", Btnsettings_Caption);
            Btndeleteelement_Caption = "";
            ucBtndeleteelement.SendProperty(context, sPrefix, false, Btndeleteelement_Internalname, "Caption", Btndeleteelement_Caption);
            if ( AV24ParentIsGridMultipleData )
            {
               Btnmoveup_Tooltiptext = context.GetMessage( "Move left", "");
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "TooltipText", Btnmoveup_Tooltiptext);
               Btnmoveup_Beforeiconclass = "fas fa-arrow-left";
               ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "BeforeIconClass", Btnmoveup_Beforeiconclass);
               Btnmovedown_Tooltiptext = context.GetMessage( "Move right", "");
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "TooltipText", Btnmovedown_Tooltiptext);
               Btnmovedown_Beforeiconclass = "fas fa-arrow-right";
               ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "BeforeIconClass", Btnmovedown_Beforeiconclass);
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         /* Execute user subroutine: 'LOADCOMBODATA' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if (returnInSub) return;
      }

      protected void E15302( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E16302( )
      {
         /* 'DoMoveUp' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV9SessionId,  AV14WWPFormElementId,  true) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E17302( )
      {
         /* 'DoMoveDown' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_moveelement(context ).execute(  AV9SessionId,  AV14WWPFormElementId,  false) ;
         this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
      }

      protected void E11302( )
      {
         /* Dvelop_confirmpanel_btndeleteelement_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btndeleteelement_Result, "Yes") == 0 )
         {
            GXt_SdtWWP_Form3 = AV12WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV9SessionId, out  GXt_SdtWWP_Form3) ;
            AV12WWPForm = GXt_SdtWWP_Form3;
            GXt_SdtWWP_Form_Element1 = AV13WWPFormElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV12WWPForm,  AV14WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV13WWPFormElement = GXt_SdtWWP_Form_Element1;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_deleteelement(context ).execute( ref  AV12WWPForm, ref  AV13WWPFormElement) ;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV9SessionId,  AV12WWPForm) ;
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12WWPForm", AV12WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13WWPFormElement", AV13WWPFormElement);
      }

      protected void E13302( )
      {
         /* Settings_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WorkWithPlus.DynamicForms.WWP_DF_AddElement")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.dynamicforms.wwp_df_addelement", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WorkWithPlus.DynamicForms.WWP_DF_AddElement";
            WebComp_Wwpaux_wc_Component = "WorkWithPlus.DynamicForms.WWP_DF_AddElement";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0044",(string)"",(string)"UPD",(short)0,(short)AV14WWPFormElementId,(short)AV9SessionId});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0044"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV7IsFirstElement ) )
         {
            Btnmoveup_Visible = false;
            ucBtnmoveup.SendProperty(context, sPrefix, false, Btnmoveup_Internalname, "Visible", StringUtil.BoolToStr( Btnmoveup_Visible));
         }
         if ( ! ( ! AV8IsLastElement ) )
         {
            Btnmovedown_Visible = false;
            ucBtnmovedown.SendProperty(context, sPrefix, false, Btnmovedown_Internalname, "Visible", StringUtil.BoolToStr( Btnmovedown_Visible));
         }
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         tblTableactions_Visible = (((StringUtil.StrCmp(AV11WWPDynamicFormMode, "DSP")!=0)) ? 1 : 0);
         AssignProp(sPrefix, false, tblTableactions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTableactions_Visible), 5, 0), true);
      }

      protected void S122( )
      {
         /* 'LOADCOMBODATA' Routine */
         returnInSub = false;
         if ( AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection )
         {
            AV5Data = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            if ( AV15Data_Data.Count > 0 )
            {
               AV5Data.Add(((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV15Data_Data.Item(1)).gxTpr_Id, 0);
            }
            Combo_data_Selectedvalue_set = AV5Data.ToJSonString(false);
            ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedValue_set", Combo_data_Selectedvalue_set);
         }
         else
         {
            Combo_data_Allowmultipleselection = false;
            ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "AllowMultipleSelection", StringUtil.BoolToStr( Combo_data_Allowmultipleselection));
            Combo_data_Includeonlyselectedoption = false;
            ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "IncludeOnlySelectedOption", StringUtil.BoolToStr( Combo_data_Includeonlyselectedoption));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10WWP_DF_CharMetadata.gxTpr_Defaultvalue)) )
            {
               Combo_data_Selectedvalue_set = AV10WWP_DF_CharMetadata.gxTpr_Defaultvalue;
               ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedValue_set", Combo_data_Selectedvalue_set);
            }
            else
            {
               if ( AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue )
               {
                  Combo_data_Emptyitemtext = AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Emptytext;
                  ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "EmptyItemText", Combo_data_Emptyitemtext);
                  Combo_data_Selectedvalue_set = "";
                  ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedValue_set", Combo_data_Selectedvalue_set);
               }
               else
               {
                  if ( AV15Data_Data.Count > 0 )
                  {
                     Combo_data_Selectedvalue_set = ((GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item)AV15Data_Data.Item(1)).gxTpr_Id;
                     ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedValue_set", Combo_data_Selectedvalue_set);
                  }
               }
            }
         }
      }

      protected void S112( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
         if ( AV13WWPFormElement.gxTpr_Wwpformelementcaption == 2 )
         {
            lblDatatitle_Caption = AV13WWPFormElement.gxTpr_Wwpformelementtitle;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
            divDatatitlecell_Visible = 1;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         else
         {
            divDatatitlecell_Visible = 0;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         AV6DataCellNameClass = "DataContentCell DscTop";
         if ( AV13WWPFormElement.gxTpr_Wwpformelementcaption != 1 )
         {
            AV6DataCellNameClass += " DataContentCellNoLabel";
         }
         lblTextblockcombo_data_Caption = AV13WWPFormElement.gxTpr_Wwpformelementtitle;
         AssignProp(sPrefix, false, lblTextblockcombo_data_Internalname, "Caption", lblTextblockcombo_data_Caption, true);
         AV10WWP_DF_CharMetadata.FromJSonString(AV13WWPFormElement.gxTpr_Wwpformelementmetadata, null);
         AV21WWP_DF_CharControlType = AV10WWP_DF_CharMetadata.gxTpr_Controltype;
         AssignAttri(sPrefix, false, "AV21WWP_DF_CharControlType", StringUtil.LTrimStr( (decimal)(AV21WWP_DF_CharControlType), 4, 0));
         AV23WWP_DynamicForms_Char_MultipleOptions_ControlType = AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype;
         AssignAttri(sPrefix, false, "AV23WWP_DynamicForms_Char_MultipleOptions_ControlType", StringUtil.Str( (decimal)(AV23WWP_DynamicForms_Char_MultipleOptions_ControlType), 1, 0));
         AV22AllowMultipleSelection = AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection;
         AssignAttri(sPrefix, false, "AV22AllowMultipleSelection", AV22AllowMultipleSelection);
         if ( AV10WWP_DF_CharMetadata.gxTpr_Isrequired )
         {
            AV6DataCellNameClass = "Required" + AV6DataCellNameClass;
         }
         divDatacellname_Class = AV6DataCellNameClass;
         AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, true);
         divDatatitlecell_Class = AV6DataCellNameClass;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Class", divDatatitlecell_Class, true);
         AV15Data_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Count )
         {
            AV18WWP_DF_CharMetadata_Option = ((string)AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Options.Item(AV28GXV1));
            AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV17Combo_DataItem.gxTpr_Id = AV18WWP_DF_CharMetadata_Option;
            AV17Combo_DataItem.gxTpr_Title = AV18WWP_DF_CharMetadata_Option;
            AV15Data_Data.Add(AV17Combo_DataItem, 0);
            if ( AV15Data_Data.Count == 2 )
            {
               if (true) break;
            }
            AV28GXV1 = (int)(AV28GXV1+1);
         }
      }

      protected void E12302( )
      {
         /* Settings_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Settings_modal_Result, "OK") == 0 )
         {
            GXt_SdtWWP_Form3 = AV12WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV9SessionId, out  GXt_SdtWWP_Form3) ;
            AV12WWPForm = GXt_SdtWWP_Form3;
            GXt_SdtWWP_Form_Element1 = AV13WWPFormElement;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV12WWPForm,  AV14WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV13WWPFormElement = GXt_SdtWWP_Form_Element1;
            /* Execute user subroutine: 'NEED TO RELOAD WC' */
            S152 ();
            if (returnInSub) return;
            if ( AV19NeedToReloadWC )
            {
               this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "DynamicForms_RefreshParentGrid", new Object[] {(string)divLayoutmaintable_Internalname,(string)"LayoutMainTable"}, false);
            }
            else
            {
               /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
               S112 ();
               if (returnInSub) return;
            }
         }
         if ( ( StringUtil.StrCmp(Settings_modal_Result, "OK") == 0 ) && ! AV19NeedToReloadWC )
         {
            /* Execute user subroutine: 'LOADCOMBODATA' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12WWPForm", AV12WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13WWPFormElement", AV13WWPFormElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10WWP_DF_CharMetadata", AV10WWP_DF_CharMetadata);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV15Data_Data", AV15Data_Data);
      }

      protected void S152( )
      {
         /* 'NEED TO RELOAD WC' Routine */
         returnInSub = false;
         AV19NeedToReloadWC = (bool)((AV24ParentIsGridMultipleData||(AV13WWPFormElement.gxTpr_Wwpformelementdatatype!=AV20WWP_DynamicFormDataType)));
         AssignAttri(sPrefix, false, "AV19NeedToReloadWC", AV19NeedToReloadWC);
         if ( ! AV19NeedToReloadWC )
         {
            AV10WWP_DF_CharMetadata.FromJSonString(AV13WWPFormElement.gxTpr_Wwpformelementmetadata, null);
            AV19NeedToReloadWC = (bool)(((AV10WWP_DF_CharMetadata.gxTpr_Controltype!=AV21WWP_DF_CharControlType)||(AV22AllowMultipleSelection!=AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection)||(AV10WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Controltype!=AV23WWP_DynamicForms_Char_MultipleOptions_ControlType)));
            AssignAttri(sPrefix, false, "AV19NeedToReloadWC", AV19NeedToReloadWC);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E18302( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table3_38_302( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablesettings_modal_Internalname, tblTablesettings_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucSettings_modal.SetProperty("Width", Settings_modal_Width);
            ucSettings_modal.SetProperty("Title", Settings_modal_Title);
            ucSettings_modal.SetProperty("ConfirmType", Settings_modal_Confirmtype);
            ucSettings_modal.SetProperty("BodyType", Settings_modal_Bodytype);
            ucSettings_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Settings_modal_Internalname, sPrefix+"SETTINGS_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"SETTINGS_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_38_302e( true) ;
         }
         else
         {
            wb_table3_38_302e( false) ;
         }
      }

      protected void wb_table2_33_302( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btndeleteelement_Internalname, tblTabledvelop_confirmpanel_btndeleteelement_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("Title", Dvelop_confirmpanel_btndeleteelement_Title);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("ConfirmationText", Dvelop_confirmpanel_btndeleteelement_Confirmationtext);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btndeleteelement_Yesbuttoncaption);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btndeleteelement_Nobuttoncaption);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btndeleteelement_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btndeleteelement_Yesbuttonposition);
            ucDvelop_confirmpanel_btndeleteelement.SetProperty("ConfirmType", Dvelop_confirmpanel_btndeleteelement_Confirmtype);
            ucDvelop_confirmpanel_btndeleteelement.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btndeleteelement_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENTContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_33_302e( true) ;
         }
         else
         {
            wb_table2_33_302e( false) ;
         }
      }

      protected void wb_table1_20_302( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTableactions_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTableactions_Internalname, tblTableactions_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnmoveup.SetProperty("TooltipText", Btnmoveup_Tooltiptext);
            ucBtnmoveup.SetProperty("BeforeIconClass", Btnmoveup_Beforeiconclass);
            ucBtnmoveup.SetProperty("Caption", Btnmoveup_Caption);
            ucBtnmoveup.SetProperty("Class", Btnmoveup_Class);
            ucBtnmoveup.Render(context, "wwp_iconbutton", Btnmoveup_Internalname, sPrefix+"BTNMOVEUPContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnmovedown.SetProperty("TooltipText", Btnmovedown_Tooltiptext);
            ucBtnmovedown.SetProperty("BeforeIconClass", Btnmovedown_Beforeiconclass);
            ucBtnmovedown.SetProperty("Caption", Btnmovedown_Caption);
            ucBtnmovedown.SetProperty("Class", Btnmovedown_Class);
            ucBtnmovedown.Render(context, "wwp_iconbutton", Btnmovedown_Internalname, sPrefix+"BTNMOVEDOWNContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtndeleteelement.SetProperty("TooltipText", Btndeleteelement_Tooltiptext);
            ucBtndeleteelement.SetProperty("BeforeIconClass", Btndeleteelement_Beforeiconclass);
            ucBtndeleteelement.SetProperty("Caption", Btndeleteelement_Caption);
            ucBtndeleteelement.SetProperty("Class", Btndeleteelement_Class);
            ucBtndeleteelement.Render(context, "wwp_iconbutton", Btndeleteelement_Internalname, sPrefix+"BTNDELETEELEMENTContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucBtnsettings.SetProperty("TooltipText", Btnsettings_Tooltiptext);
            ucBtnsettings.SetProperty("BeforeIconClass", Btnsettings_Beforeiconclass);
            ucBtnsettings.SetProperty("Caption", Btnsettings_Caption);
            ucBtnsettings.SetProperty("Class", Btnsettings_Class);
            ucBtnsettings.Render(context, "wwp_iconbutton", Btnsettings_Internalname, sPrefix+"BTNSETTINGSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_20_302e( true) ;
         }
         else
         {
            wb_table1_20_302e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV11WWPDynamicFormMode", AV11WWPDynamicFormMode);
         AV14WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV14WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV14WWPFormElementId), 4, 0));
         AV9SessionId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
         AV12WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,3);
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
         PA302( ) ;
         WS302( ) ;
         WE302( ) ;
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
         sCtrlAV11WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV14WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV9SessionId = (string)((string)getParm(obj,2));
         sCtrlAV12WWPForm = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA302( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_dfc_combobox_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA302( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV11WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV11WWPDynamicFormMode", AV11WWPDynamicFormMode);
            AV14WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV14WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV14WWPFormElementId), 4, 0));
            AV9SessionId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
            AV12WWPForm = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form)getParm(obj,5);
         }
         wcpOAV11WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV11WWPDynamicFormMode");
         wcpOAV14WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV14WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV11WWPDynamicFormMode, wcpOAV11WWPDynamicFormMode) != 0 ) || ( AV14WWPFormElementId != wcpOAV14WWPFormElementId ) || ( AV9SessionId != wcpOAV9SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV11WWPDynamicFormMode = AV11WWPDynamicFormMode;
         wcpOAV14WWPFormElementId = AV14WWPFormElementId;
         wcpOAV9SessionId = AV9SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV11WWPDynamicFormMode = cgiGet( sPrefix+"AV11WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV11WWPDynamicFormMode) > 0 )
         {
            AV11WWPDynamicFormMode = cgiGet( sCtrlAV11WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV11WWPDynamicFormMode", AV11WWPDynamicFormMode);
         }
         else
         {
            AV11WWPDynamicFormMode = cgiGet( sPrefix+"AV11WWPDynamicFormMode_PARM");
         }
         sCtrlAV14WWPFormElementId = cgiGet( sPrefix+"AV14WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV14WWPFormElementId) > 0 )
         {
            AV14WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV14WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV14WWPFormElementId), 4, 0));
         }
         else
         {
            AV14WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV14WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV9SessionId = cgiGet( sPrefix+"AV9SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV9SessionId) > 0 )
         {
            AV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV9SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
         }
         else
         {
            AV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV9SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV12WWPForm = cgiGet( sPrefix+"AV12WWPForm_CTRL");
         if ( StringUtil.Len( sCtrlAV12WWPForm) > 0 )
         {
            AV12WWPForm.FromXml(cgiGet( sCtrlAV12WWPForm), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV12WWPForm_PARM"), AV12WWPForm);
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
         PA302( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS302( ) ;
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
         WS302( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11WWPDynamicFormMode_PARM", StringUtil.RTrim( AV11WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV11WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV14WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9SessionId_CTRL", StringUtil.RTrim( sCtrlAV9SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV12WWPForm_PARM", AV12WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV12WWPForm_PARM", AV12WWPForm);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12WWPForm)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12WWPForm_CTRL", StringUtil.RTrim( sCtrlAV12WWPForm));
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
         WE302( ) ;
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411156324247", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_dfc_combobox_wc.js", "?202411156324248", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblDatatitle_Internalname = sPrefix+"DATATITLE";
         divDatatitlecell_Internalname = sPrefix+"DATATITLECELL";
         lblTextblockcombo_data_Internalname = sPrefix+"TEXTBLOCKCOMBO_DATA";
         Combo_data_Internalname = sPrefix+"COMBO_DATA";
         divTablesplitteddata_Internalname = sPrefix+"TABLESPLITTEDDATA";
         divDatacellname_Internalname = sPrefix+"DATACELLNAME";
         Btnmoveup_Internalname = sPrefix+"BTNMOVEUP";
         Btnmovedown_Internalname = sPrefix+"BTNMOVEDOWN";
         Btndeleteelement_Internalname = sPrefix+"BTNDELETEELEMENT";
         Btnsettings_Internalname = sPrefix+"BTNSETTINGS";
         tblTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Dvelop_confirmpanel_btndeleteelement_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT";
         tblTabledvelop_confirmpanel_btndeleteelement_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_BTNDELETEELEMENT";
         Settings_modal_Internalname = sPrefix+"SETTINGS_MODAL";
         tblTablesettings_modal_Internalname = sPrefix+"TABLESETTINGS_MODAL";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
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
         Btnsettings_Class = "ButtonGray";
         Btnsettings_Beforeiconclass = "fas fa-gear";
         Btnsettings_Tooltiptext = "Settings";
         Btndeleteelement_Class = "ButtonGray";
         Btndeleteelement_Beforeiconclass = "fa-trash-can far";
         Btndeleteelement_Tooltiptext = "Delete";
         Btnmovedown_Class = "ButtonGray";
         Btnmoveup_Class = "ButtonGray";
         Dvelop_confirmpanel_btndeleteelement_Confirmtype = "1";
         Dvelop_confirmpanel_btndeleteelement_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btndeleteelement_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btndeleteelement_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btndeleteelement_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btndeleteelement_Confirmationtext = "DF_ConfirmCurrentElementDeletion";
         Dvelop_confirmpanel_btndeleteelement_Title = context.GetMessage( "GX_BtnDelete", "");
         Settings_modal_Bodytype = "WebComponent";
         Settings_modal_Confirmtype = "";
         Settings_modal_Title = context.GetMessage( "Element settings", "");
         Settings_modal_Width = "800";
         Combo_data_Emptyitemtext = "GX_EmptyItemText";
         tblTableactions_Visible = 1;
         Btnmovedown_Visible = Convert.ToBoolean( -1);
         Btnmoveup_Visible = Convert.ToBoolean( -1);
         Btnmovedown_Beforeiconclass = "fas fa-arrow-down";
         Btnmovedown_Tooltiptext = "Move down";
         Btnmoveup_Beforeiconclass = "fas fa-arrow-up";
         Btnmoveup_Tooltiptext = "Move up";
         Btndeleteelement_Caption = context.GetMessage( "GX_BtnDelete", "");
         Btnsettings_Caption = context.GetMessage( "WWP_DF_Settings", "");
         Btnmovedown_Caption = context.GetMessage( "WWP_DF_MoveDown", "");
         Btnmoveup_Caption = context.GetMessage( "WWP_DF_MoveUp", "");
         Combo_data_Multiplevaluestype = "Tags";
         Combo_data_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_data_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_data_Cls = "ExtendedCombo Attribute";
         Combo_data_Caption = "";
         lblTextblockcombo_data_Caption = context.GetMessage( "Data", "");
         divDatacellname_Class = "col-xs-12 DataContentCell DscTop ExtendedComboCell";
         lblDatatitle_Caption = context.GetMessage( "Title", "");
         divDatatitlecell_Class = "col-xs-12";
         divDatatitlecell_Visible = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7IsFirstElement","fld":"vISFIRSTELEMENT","hsh":true},{"av":"AV8IsLastElement","fld":"vISLASTELEMENT","hsh":true},{"av":"AV24ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV20WWP_DynamicFormDataType","fld":"vWWP_DYNAMICFORMDATATYPE","pic":"Z9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnmoveup_Visible","ctrl":"BTNMOVEUP","prop":"Visible"},{"av":"Btnmovedown_Visible","ctrl":"BTNMOVEDOWN","prop":"Visible"}]}""");
         setEventMetadata("'DOMOVEUP'","""{"handler":"E16302","iparms":[{"av":"AV9SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV14WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("'DOMOVEDOWN'","""{"handler":"E17302","iparms":[{"av":"AV9SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV14WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE","""{"handler":"E11302","iparms":[{"av":"Dvelop_confirmpanel_btndeleteelement_Result","ctrl":"DVELOP_CONFIRMPANEL_BTNDELETEELEMENT","prop":"Result"},{"av":"AV9SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV14WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDELETEELEMENT.CLOSE",""","oparms":[{"av":"AV12WWPForm","fld":"vWWPFORM"},{"av":"AV13WWPFormElement","fld":"vWWPFORMELEMENT"}]}""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT","""{"handler":"E13302","iparms":[{"av":"AV14WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV9SessionId","fld":"vSESSIONID","pic":"ZZZ9"}]""");
         setEventMetadata("SETTINGS_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("SETTINGS_MODAL.CLOSE","""{"handler":"E12302","iparms":[{"av":"Settings_modal_Result","ctrl":"SETTINGS_MODAL","prop":"Result"},{"av":"AV9SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV14WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV19NeedToReloadWC","fld":"vNEEDTORELOADWC"},{"av":"AV13WWPFormElement","fld":"vWWPFORMELEMENT"},{"av":"AV24ParentIsGridMultipleData","fld":"vPARENTISGRIDMULTIPLEDATA","hsh":true},{"av":"AV20WWP_DynamicFormDataType","fld":"vWWP_DYNAMICFORMDATATYPE","pic":"Z9","hsh":true},{"av":"AV21WWP_DF_CharControlType","fld":"vWWP_DF_CHARCONTROLTYPE","pic":"ZZZ9"},{"av":"AV22AllowMultipleSelection","fld":"vALLOWMULTIPLESELECTION"},{"av":"AV23WWP_DynamicForms_Char_MultipleOptions_ControlType","fld":"vWWP_DYNAMICFORMS_CHAR_MULTIPLEOPTIONS_CONTROLTYPE","pic":"9"},{"av":"AV10WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"AV15Data_Data","fld":"vDATA_DATA"}]""");
         setEventMetadata("SETTINGS_MODAL.CLOSE",""","oparms":[{"av":"AV12WWPForm","fld":"vWWPFORM"},{"av":"AV13WWPFormElement","fld":"vWWPFORMELEMENT"},{"av":"AV19NeedToReloadWC","fld":"vNEEDTORELOADWC"},{"av":"AV10WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA"},{"av":"lblDatatitle_Caption","ctrl":"DATATITLE","prop":"Caption"},{"av":"divDatatitlecell_Visible","ctrl":"DATATITLECELL","prop":"Visible"},{"av":"lblTextblockcombo_data_Caption","ctrl":"TEXTBLOCKCOMBO_DATA","prop":"Caption"},{"av":"AV21WWP_DF_CharControlType","fld":"vWWP_DF_CHARCONTROLTYPE","pic":"ZZZ9"},{"av":"AV23WWP_DynamicForms_Char_MultipleOptions_ControlType","fld":"vWWP_DYNAMICFORMS_CHAR_MULTIPLEOPTIONS_CONTROLTYPE","pic":"9"},{"av":"AV22AllowMultipleSelection","fld":"vALLOWMULTIPLESELECTION"},{"av":"divDatacellname_Class","ctrl":"DATACELLNAME","prop":"Class"},{"av":"divDatatitlecell_Class","ctrl":"DATATITLECELL","prop":"Class"},{"av":"AV15Data_Data","fld":"vDATA_DATA"},{"av":"Combo_data_Selectedvalue_set","ctrl":"COMBO_DATA","prop":"SelectedValue_set"},{"av":"Combo_data_Allowmultipleselection","ctrl":"COMBO_DATA","prop":"AllowMultipleSelection"},{"av":"Combo_data_Includeonlyselectedoption","ctrl":"COMBO_DATA","prop":"IncludeOnlySelectedOption"},{"av":"Combo_data_Emptyitemtext","ctrl":"COMBO_DATA","prop":"EmptyItemText"}]}""");
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
         AV12WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         wcpOAV11WWPDynamicFormMode = "";
         Dvelop_confirmpanel_btndeleteelement_Result = "";
         Combo_data_Selectedvalue_get = "";
         Settings_modal_Result = "";
         AV13WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15Data_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV10WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV5Data = new GxSimpleCollection<string>();
         GX_FocusControl = "";
         lblDatatitle_Jsonclick = "";
         lblTextblockcombo_data_Jsonclick = "";
         ucCombo_data = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         ucBtnmoveup = new GXUserControl();
         ucBtnmovedown = new GXUserControl();
         ucBtnsettings = new GXUserControl();
         ucBtndeleteelement = new GXUserControl();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Combo_data_Selectedvalue_set = "";
         AV6DataCellNameClass = "";
         AV18WWP_DF_CharMetadata_Option = "";
         AV17Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         GXt_SdtWWP_Form3 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         GXt_SdtWWP_Form_Element1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         sStyleString = "";
         ucSettings_modal = new GXUserControl();
         ucDvelop_confirmpanel_btndeleteelement = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV11WWPDynamicFormMode = "";
         sCtrlAV14WWPFormElementId = "";
         sCtrlAV9SessionId = "";
         sCtrlAV12WWPForm = "";
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV14WWPFormElementId ;
      private short AV9SessionId ;
      private short wcpOAV14WWPFormElementId ;
      private short wcpOAV9SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV20WWP_DynamicFormDataType ;
      private short AV21WWP_DF_CharControlType ;
      private short AV23WWP_DynamicForms_Char_MultipleOptions_ControlType ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int divDatatitlecell_Visible ;
      private int tblTableactions_Visible ;
      private int AV28GXV1 ;
      private int idxLst ;
      private string AV11WWPDynamicFormMode ;
      private string wcpOAV11WWPDynamicFormMode ;
      private string Dvelop_confirmpanel_btndeleteelement_Result ;
      private string Combo_data_Selectedvalue_get ;
      private string Settings_modal_Result ;
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
      private string divDatatitlecell_Internalname ;
      private string divDatatitlecell_Class ;
      private string lblDatatitle_Internalname ;
      private string lblDatatitle_Caption ;
      private string lblDatatitle_Jsonclick ;
      private string divDatacellname_Internalname ;
      private string divDatacellname_Class ;
      private string divTablesplitteddata_Internalname ;
      private string lblTextblockcombo_data_Internalname ;
      private string lblTextblockcombo_data_Caption ;
      private string lblTextblockcombo_data_Jsonclick ;
      private string Combo_data_Caption ;
      private string Combo_data_Cls ;
      private string Combo_data_Multiplevaluestype ;
      private string Combo_data_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Btnmoveup_Caption ;
      private string Btnmoveup_Internalname ;
      private string Btnmovedown_Caption ;
      private string Btnmovedown_Internalname ;
      private string Btnsettings_Caption ;
      private string Btnsettings_Internalname ;
      private string Btndeleteelement_Caption ;
      private string Btndeleteelement_Internalname ;
      private string Btnmoveup_Tooltiptext ;
      private string Btnmoveup_Beforeiconclass ;
      private string Btnmovedown_Tooltiptext ;
      private string Btnmovedown_Beforeiconclass ;
      private string tblTableactions_Internalname ;
      private string Combo_data_Selectedvalue_set ;
      private string Combo_data_Emptyitemtext ;
      private string sStyleString ;
      private string tblTablesettings_modal_Internalname ;
      private string Settings_modal_Width ;
      private string Settings_modal_Title ;
      private string Settings_modal_Confirmtype ;
      private string Settings_modal_Bodytype ;
      private string Settings_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_btndeleteelement_Internalname ;
      private string Dvelop_confirmpanel_btndeleteelement_Title ;
      private string Dvelop_confirmpanel_btndeleteelement_Confirmationtext ;
      private string Dvelop_confirmpanel_btndeleteelement_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btndeleteelement_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btndeleteelement_Confirmtype ;
      private string Dvelop_confirmpanel_btndeleteelement_Internalname ;
      private string Btnmoveup_Class ;
      private string Btnmovedown_Class ;
      private string Btndeleteelement_Tooltiptext ;
      private string Btndeleteelement_Beforeiconclass ;
      private string Btndeleteelement_Class ;
      private string Btnsettings_Tooltiptext ;
      private string Btnsettings_Beforeiconclass ;
      private string Btnsettings_Class ;
      private string sCtrlAV11WWPDynamicFormMode ;
      private string sCtrlAV14WWPFormElementId ;
      private string sCtrlAV9SessionId ;
      private string sCtrlAV12WWPForm ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV7IsFirstElement ;
      private bool AV8IsLastElement ;
      private bool AV24ParentIsGridMultipleData ;
      private bool AV19NeedToReloadWC ;
      private bool AV22AllowMultipleSelection ;
      private bool wbLoad ;
      private bool Combo_data_Allowmultipleselection ;
      private bool Combo_data_Includeonlyselectedoption ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool Btnmoveup_Visible ;
      private bool Btnmovedown_Visible ;
      private string AV6DataCellNameClass ;
      private string AV18WWP_DF_CharMetadata_Option ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucCombo_data ;
      private GXUserControl ucBtnmoveup ;
      private GXUserControl ucBtnmovedown ;
      private GXUserControl ucBtnsettings ;
      private GXUserControl ucBtndeleteelement ;
      private GXUserControl ucSettings_modal ;
      private GXUserControl ucDvelop_confirmpanel_btndeleteelement ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV12WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP3_WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV13WWPFormElement ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Data_Data ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV10WWP_DF_CharMetadata ;
      private GxSimpleCollection<string> AV5Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV17Combo_DataItem ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form3 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element GXt_SdtWWP_Form_Element1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
