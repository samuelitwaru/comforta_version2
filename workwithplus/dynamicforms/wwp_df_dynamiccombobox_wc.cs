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
   public class wwp_df_dynamiccombobox_wc : GXWebComponent
   {
      public wwp_df_dynamiccombobox_wc( )
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

      public wwp_df_dynamiccombobox_wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPDynamicFormMode ,
                           short aP1_WWPFormElementId ,
                           short aP2_WWPFormInstanceElementId ,
                           short aP3_SessionId ,
                           ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance )
      {
         this.AV29WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV30WWPFormElementId = aP1_WWPFormElementId;
         this.AV8WWPFormInstanceElementId = aP2_WWPFormInstanceElementId;
         this.AV24SessionId = aP3_SessionId;
         this.AV32WWPFormInstance = aP4_WWPFormInstance;
         ExecuteImpl();
         aP4_WWPFormInstance=this.AV32WWPFormInstance;
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
                  AV29WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV29WWPDynamicFormMode", AV29WWPDynamicFormMode);
                  AV30WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV30WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV30WWPFormElementId), 4, 0));
                  AV8WWPFormInstanceElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormInstanceElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV8WWPFormInstanceElementId), 4, 0));
                  AV24SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV24SessionId", StringUtil.LTrimStr( (decimal)(AV24SessionId), 4, 0));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV32WWPFormInstance);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV29WWPDynamicFormMode,(short)AV30WWPFormElementId,(short)AV8WWPFormInstanceElementId,(short)AV24SessionId,(GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)AV32WWPFormInstance});
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
            PA212( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS212( ) ;
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
            context.SendWebValue( context.GetMessage( "WWP_Dynamic Form_Dynamic Combo Box_WC", "")) ;
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
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_dynamiccombobox_wc.aspx"+UrlEncode(StringUtil.RTrim(AV29WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV30WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8WWPFormInstanceElementId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV24SessionId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_dynamiccombobox_wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV5WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV5WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV5WWP_DF_CharMetadata, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV18HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV18HasReferenceId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV31WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV31WWPFormElementTitle, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDATA_DATA", AV34Data_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDATA_DATA", AV34Data_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV29WWPDynamicFormMode", StringUtil.RTrim( wcpOAV29WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV30WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV30WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8WWPFormInstanceElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV24SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV24SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV5WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV5WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV5WWP_DF_CharMetadata, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV18HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV18HasReferenceId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCE", AV32WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCE", AV32WWPFormInstance);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMINSTANCEELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDATA", AV11Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDATA", AV11Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV31WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV31WWPFormElementTitle, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORMINSTANCEELEMENT", AV33WWPFormInstanceElement);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORMINSTANCEELEMENT", AV33WWPFormInstanceElement);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vERRORIDS", AV40ErrorIds);
         GxWebStd.gx_hidden_field( context, sPrefix+"vAUXSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9AuxSessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vEXISTELEMENT", AV17ExistElement);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVISIBLECONDITION", AV27VisibleCondition);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVISIBLECONDITION", AV27VisibleCondition);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV29WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Cls", StringUtil.RTrim( Combo_data_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Selectedvalue_set", StringUtil.RTrim( Combo_data_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Selectedtext_set", StringUtil.RTrim( Combo_data_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Gamoauthtoken", StringUtil.RTrim( Combo_data_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Enabled", StringUtil.BoolToStr( Combo_data_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Allowmultipleselection", StringUtil.BoolToStr( Combo_data_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Datalistproc", StringUtil.RTrim( Combo_data_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Datalistprocparametersprefix", StringUtil.RTrim( Combo_data_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_data_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Emptyitem", StringUtil.BoolToStr( Combo_data_Emptyitem));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Multiplevaluestype", StringUtil.RTrim( Combo_data_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Emptyitemtext", StringUtil.RTrim( Combo_data_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Selectedvalue_get", StringUtil.RTrim( Combo_data_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Ddointernalname", StringUtil.RTrim( Combo_data_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Selectedvalue_get", StringUtil.RTrim( Combo_data_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_DATA_Ddointernalname", StringUtil.RTrim( Combo_data_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTMAINTABLE_Class", StringUtil.RTrim( divLayoutmaintable_Class));
      }

      protected void RenderHtmlCloseForm212( )
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
         return "WorkWithPlus.DynamicForms.WWP_DF_DynamicComboBox_WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Dynamic Form_Dynamic Combo Box_WC", "") ;
      }

      protected void WB210( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_dynamiccombobox_wc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatatitlecell_Internalname, divDatatitlecell_Visible, 0, "px", 0, "px", divDatatitlecell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDatatitle_Internalname, lblDatatitle_Caption, "", "", lblDatatitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DynFormDataDescription", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_DynamicComboBox_WC.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_data_Internalname, lblTextblockcombo_data_Caption, "", "", lblTextblockcombo_data_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_DynamicComboBox_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_data.SetProperty("Caption", Combo_data_Caption);
            ucCombo_data.SetProperty("Cls", Combo_data_Cls);
            ucCombo_data.SetProperty("AllowMultipleSelection", Combo_data_Allowmultipleselection);
            ucCombo_data.SetProperty("DataListProc", Combo_data_Datalistproc);
            ucCombo_data.SetProperty("IncludeOnlySelectedOption", Combo_data_Includeonlyselectedoption);
            ucCombo_data.SetProperty("MultipleValuesType", Combo_data_Multiplevaluestype);
            ucCombo_data.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
            ucCombo_data.SetProperty("DropDownOptionsData", AV34Data_Data);
            ucCombo_data.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_data_Internalname, sPrefix+"COMBO_DATAContainer");
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
            GxWebStd.gx_div_start( context, divHiddenvars_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_single_line_edit( context, edtavSessionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV24SessionId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSessionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSessionid_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_DynamicComboBox_WC.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavWwpformelementid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30WWPFormElementId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWwpformelementid_Jsonclick, 0, "Attribute", "", "", "", "", edtavWwpformelementid_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_DynamicComboBox_WC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START212( )
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
            Form.Meta.addItem("description", context.GetMessage( "WWP_Dynamic Form_Dynamic Combo Box_WC", ""), 0) ;
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
               STRUP210( ) ;
            }
         }
      }

      protected void WS212( )
      {
         START212( ) ;
         EVT212( ) ;
      }

      protected void EVT212( )
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
                                 STRUP210( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_DATA.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP210( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_data.Onoptionclicked */
                                    E11212 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP210( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E12212 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_VALIDATE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP210( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E13212 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP210( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E14212 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP210( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E15212 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP210( ) ;
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
                                 STRUP210( ) ;
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE212( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm212( ) ;
            }
         }
      }

      protected void PA212( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_dynamiccombobox_wc.aspx")), "workwithplus.dynamicforms.wwp_df_dynamiccombobox_wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_dynamiccombobox_wc.aspx")))) ;
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
         RF212( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF212( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15212 ();
            WB210( ) ;
         }
      }

      protected void send_integrity_lvl_hashes212( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWP_DF_CHARMETADATA", AV5WWP_DF_CharMetadata);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWP_DF_CHARMETADATA", AV5WWP_DF_CharMetadata);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWP_DF_CHARMETADATA", GetSecureSignedToken( sPrefix, AV5WWP_DF_CharMetadata, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASREFERENCEID", AV18HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV18HasReferenceId, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTTITLE", AV31WWPFormElementTitle);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV31WWPFormElementTitle, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP210( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12212 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDATA_DATA"), AV34Data_Data);
            /* Read saved values. */
            wcpOAV29WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV29WWPDynamicFormMode");
            wcpOAV30WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV30WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV8WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV24SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV24SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Combo_data_Cls = cgiGet( sPrefix+"COMBO_DATA_Cls");
            Combo_data_Selectedvalue_set = cgiGet( sPrefix+"COMBO_DATA_Selectedvalue_set");
            Combo_data_Selectedtext_set = cgiGet( sPrefix+"COMBO_DATA_Selectedtext_set");
            Combo_data_Gamoauthtoken = cgiGet( sPrefix+"COMBO_DATA_Gamoauthtoken");
            Combo_data_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DATA_Enabled"));
            Combo_data_Allowmultipleselection = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DATA_Allowmultipleselection"));
            Combo_data_Datalistproc = cgiGet( sPrefix+"COMBO_DATA_Datalistproc");
            Combo_data_Datalistprocparametersprefix = cgiGet( sPrefix+"COMBO_DATA_Datalistprocparametersprefix");
            Combo_data_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DATA_Includeonlyselectedoption"));
            Combo_data_Emptyitem = StringUtil.StrToBool( cgiGet( sPrefix+"COMBO_DATA_Emptyitem"));
            Combo_data_Multiplevaluestype = cgiGet( sPrefix+"COMBO_DATA_Multiplevaluestype");
            Combo_data_Emptyitemtext = cgiGet( sPrefix+"COMBO_DATA_Emptyitemtext");
            Combo_data_Selectedvalue_get = cgiGet( sPrefix+"COMBO_DATA_Selectedvalue_get");
            Combo_data_Ddointernalname = cgiGet( sPrefix+"COMBO_DATA_Ddointernalname");
            divLayoutmaintable_Class = cgiGet( sPrefix+"LAYOUTMAINTABLE_Class");
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
         E12212 ();
         if (returnInSub) return;
      }

      protected void E12212( )
      {
         /* Start Routine */
         returnInSub = false;
         AV19IsElementFocusable = true;
         AV18HasReferenceId = false;
         AssignAttri(sPrefix, false, "AV18HasReferenceId", AV18HasReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV18HasReferenceId, context));
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV32WWPFormInstance.gxTpr_Element.Count )
         {
            AV33WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV32WWPFormInstance.gxTpr_Element.Item(AV43GXV1));
            if ( ( AV33WWPFormInstanceElement.gxTpr_Wwpformelementid == AV30WWPFormElementId ) && ( AV33WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV8WWPFormInstanceElementId ) )
            {
               AV10CurrentWWPFormInstanceElement = AV33WWPFormInstanceElement;
               AV18HasReferenceId = (bool)((!String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV33WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)))));
               AssignAttri(sPrefix, false, "AV18HasReferenceId", AV18HasReferenceId);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASREFERENCEID", GetSecureSignedToken( sPrefix, AV18HasReferenceId, context));
               AV31WWPFormElementTitle = AV33WWPFormInstanceElement.gxTpr_Wwpformelementtitle;
               AssignAttri(sPrefix, false, "AV31WWPFormElementTitle", AV31WWPFormElementTitle);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vWWPFORMELEMENTTITLE", GetSecureSignedToken( sPrefix, AV31WWPFormElementTitle, context));
               AV7WWPFormElementMetadata = AV33WWPFormInstanceElement.gxTpr_Wwpformelementmetadata;
               AssignAttri(sPrefix, false, "AV7WWPFormElementMetadata", AV7WWPFormElementMetadata);
               AV6WWPFormElementCaption = AV33WWPFormInstanceElement.gxTpr_Wwpformelementcaption;
               AssignAttri(sPrefix, false, "AV6WWPFormElementCaption", StringUtil.Str( (decimal)(AV6WWPFormElementCaption), 1, 0));
               if (true) break;
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
         /* Execute user subroutine: 'LOAD TITLE AND METADATA' */
         S192 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GET DATA FROM CURRENT ELEMENT' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATE VISIBILITY' */
         S122 ();
         if (returnInSub) return;
         if ( AV19IsElementFocusable && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Table") == 0 ) && ( StringUtil.StrCmp(AV28WebSession.Get("WWPDynFormSetFocus"), "") != 0 ) )
         {
            /* Execute user subroutine: 'SET FOCUS TO ELEMENT' */
            S132 ();
            if (returnInSub) return;
            AV28WebSession.Remove("WWPDynFormSetFocus");
         }
         if ( ( StringUtil.StrCmp(AV29WWPDynamicFormMode, "DSP") != 0 ) && ( StringUtil.StrCmp(AV29WWPDynamicFormMode, "DLT") != 0 ) )
         {
            AV14DataEnabled = true;
            AssignAttri(sPrefix, false, "AV14DataEnabled", AV14DataEnabled);
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV41GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV42GAMErrors);
         Combo_data_Gamoauthtoken = AV41GAMSession.gxTpr_Token;
         ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "GAMOAuthToken", Combo_data_Gamoauthtoken);
         /* Execute user subroutine: 'LOADCOMBODATA' */
         S142 ();
         if (returnInSub) return;
         edtavSessionid_Visible = 0;
         AssignProp(sPrefix, false, edtavSessionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSessionid_Visible), 5, 0), true);
         edtavWwpformelementid_Visible = 0;
         AssignProp(sPrefix, false, edtavWwpformelementid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWwpformelementid_Visible), 5, 0), true);
         if ( ! AV5WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection )
         {
            Combo_data_Allowmultipleselection = false;
            ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "AllowMultipleSelection", StringUtil.BoolToStr( Combo_data_Allowmultipleselection));
            Combo_data_Includeonlyselectedoption = false;
            ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "IncludeOnlySelectedOption", StringUtil.BoolToStr( Combo_data_Includeonlyselectedoption));
         }
         Combo_data_Enabled = AV14DataEnabled;
         ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "Enabled", StringUtil.BoolToStr( Combo_data_Enabled));
      }

      protected void E11212( )
      {
         /* Combo_data_Onoptionclicked Routine */
         returnInSub = false;
         if ( ! AV5WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection )
         {
            AV11Data = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            if ( ! AV5WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue || ( StringUtil.StrCmp(Combo_data_Selectedvalue_get, AV5WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Emptytext) != 0 ) )
            {
               AV11Data.Add(Combo_data_Selectedvalue_get, 0);
            }
         }
         else
         {
            AV11Data.FromJSonString(Combo_data_Selectedvalue_get, null);
         }
         /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
         S152 ();
         if (returnInSub) return;
         if ( AV18HasReferenceId )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "DynamicForm_UpdateVisibilities", new Object[] {(short)AV24SessionId}, true);
         }
         /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11Data", AV11Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV33WWPFormInstanceElement", AV33WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32WWPFormInstance", AV32WWPFormInstance);
      }

      protected void S142( )
      {
         /* 'LOADCOMBODATA' Routine */
         returnInSub = false;
         Combo_data_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"Data\", \"Cond_SessionId\": \"#%1#\", \"Cond_WWPFormElementId\": \"#%2#\"", edtavSessionid_Internalname, edtavWwpformelementid_Internalname, "", "", "", "", "", "", "");
         ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "DataListProcParametersPrefix", Combo_data_Datalistprocparametersprefix);
         Combo_data_Selectedtext_set = AV13DataDescriptionCol.ToJSonString(false);
         ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedText_set", Combo_data_Selectedtext_set);
         Combo_data_Selectedvalue_set = AV11Data.ToJSonString(false);
         ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedValue_set", Combo_data_Selectedvalue_set);
         Combo_data_Emptyitem = false;
         ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "EmptyItem", StringUtil.BoolToStr( Combo_data_Emptyitem));
         if ( ! AV5WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection )
         {
            if ( AV5WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Includeemptyvalue )
            {
               Combo_data_Emptyitem = true;
               ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "EmptyItem", StringUtil.BoolToStr( Combo_data_Emptyitem));
               Combo_data_Emptyitemtext = AV5WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Combobox.gxTpr_Emptytext;
               ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "EmptyItemText", Combo_data_Emptyitemtext);
            }
            if ( AV11Data.Count > 0 )
            {
               Combo_data_Selectedvalue_set = ((string)AV11Data.Item(1));
               ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedValue_set", Combo_data_Selectedvalue_set);
               Combo_data_Selectedtext_set = ((string)AV13DataDescriptionCol.Item(1));
               ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedText_set", Combo_data_Selectedtext_set);
            }
            else
            {
               Combo_data_Selectedvalue_set = "";
               ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedValue_set", Combo_data_Selectedvalue_set);
               Combo_data_Selectedtext_set = "";
               ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedText_set", Combo_data_Selectedtext_set);
            }
         }
         else
         {
            Combo_data_Selectedtext_set = AV13DataDescriptionCol.ToJSonString(false);
            ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedText_set", Combo_data_Selectedtext_set);
            Combo_data_Selectedvalue_set = AV11Data.ToJSonString(false);
            ucCombo_data.SendProperty(context, sPrefix, false, Combo_data_Internalname, "SelectedValue_set", Combo_data_Selectedvalue_set);
         }
      }

      protected void E13212( )
      {
         /* General\GlobalEvents_Dynamicform_validate Routine */
         returnInSub = false;
         if ( ( AV9AuxSessionId == AV24SessionId ) && ( StringUtil.StrCmp(divLayoutmaintable_Class, "Invisible") != 0 ) && StringUtil.Contains( AV40ErrorIds, "|"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30WWPFormElementId), 4, 0))+"."+StringUtil.Trim( StringUtil.Str( (decimal)(AV8WWPFormInstanceElementId), 4, 0))+"|") )
         {
            /* Execute user subroutine: 'SAVE ELEMENT DATA TO SESSION' */
            S152 ();
            if (returnInSub) return;
            if ( AV17ExistElement )
            {
               /* Execute user subroutine: 'EXECUTE VALIDATIONS' */
               S162 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV33WWPFormInstanceElement", AV33WWPFormInstanceElement);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32WWPFormInstance", AV32WWPFormInstance);
      }

      protected void E14212( )
      {
         /* General\GlobalEvents_Dynamicform_updatevisibilities Routine */
         returnInSub = false;
         if ( ( AV9AuxSessionId == AV24SessionId ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV27VisibleCondition.gxTpr_Expression))) )
         {
            /* Execute user subroutine: 'GET FORM INSTANCE' */
            S172 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'UPDATE VISIBILITY' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32WWPFormInstance", AV32WWPFormInstance);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27VisibleCondition", AV27VisibleCondition);
      }

      protected void S172( )
      {
         /* 'GET FORM INSTANCE' Routine */
         returnInSub = false;
         GXt_SdtWWP_FormInstance2 = AV32WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV24SessionId, out  GXt_SdtWWP_FormInstance2) ;
         AV32WWPFormInstance = GXt_SdtWWP_FormInstance2;
      }

      protected void S112( )
      {
         /* 'GET DATA FROM CURRENT ELEMENT' Routine */
         returnInSub = false;
         AV11Data = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar)) )
         {
            if ( AV5WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection )
            {
               AV11Data.FromJSonString(AV10CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar, null);
            }
            else
            {
               AV11Data.Add(AV10CurrentWWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'SAVE ELEMENT DATA TO SESSION' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GET FORM INSTANCE' */
         S172 ();
         if (returnInSub) return;
         AV17ExistElement = false;
         AssignAttri(sPrefix, false, "AV17ExistElement", AV17ExistElement);
         AV44GXV2 = 1;
         while ( AV44GXV2 <= AV32WWPFormInstance.gxTpr_Element.Count )
         {
            AV33WWPFormInstanceElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV32WWPFormInstance.gxTpr_Element.Item(AV44GXV2));
            if ( ( AV33WWPFormInstanceElement.gxTpr_Wwpformelementid == AV30WWPFormElementId ) && ( AV33WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid == AV8WWPFormInstanceElementId ) )
            {
               AV17ExistElement = true;
               AssignAttri(sPrefix, false, "AV17ExistElement", AV17ExistElement);
               if (true) break;
            }
            AV44GXV2 = (int)(AV44GXV2+1);
         }
         if ( AV17ExistElement )
         {
            /* Execute user subroutine: 'SET DATA TO ELEMENT' */
            S182 ();
            if (returnInSub) return;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveforminstance(context ).execute(  AV24SessionId,  AV32WWPFormInstance) ;
         }
      }

      protected void S182( )
      {
         /* 'SET DATA TO ELEMENT' Routine */
         returnInSub = false;
         if ( AV5WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection )
         {
            AV33WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar = ((AV11Data.Count>0) ? AV11Data.ToJSonString(false) : "");
         }
         else
         {
            AV33WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar = ((string)AV11Data.Item(1));
         }
      }

      protected void S122( )
      {
         /* 'UPDATE VISIBILITY' Routine */
         returnInSub = false;
         AV27VisibleCondition = AV5WWP_DF_CharMetadata.gxTpr_Visiblecondition;
         if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV32WWPFormInstance,  AV8WWPFormInstanceElementId,  AV27VisibleCondition) )
         {
            divLayoutmaintable_Class = "Table";
            AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         }
         else
         {
            divLayoutmaintable_Class = "Invisible";
            AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         }
      }

      protected void S162( )
      {
         /* 'EXECUTE VALIDATIONS' Routine */
         returnInSub = false;
         AV20IsRequired = AV5WWP_DF_CharMetadata.gxTpr_Isrequired;
         AV26Validations = AV5WWP_DF_CharMetadata.gxTpr_Validations;
         AV16ElementInternalName = Combo_data_Ddointernalname;
         AV25ThisValueStr = "''";
         if ( AV11Data.Count > 0 )
         {
            if ( AV5WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Allowmultipleselection )
            {
               AV25ThisValueStr = StringUtil.Format( "'%1'", StringUtil.StringReplace( AV11Data.ToJSonString(false), "'", ""), "", "", "", "", "", "", "", "");
            }
            else
            {
               AV25ThisValueStr = StringUtil.Format( "'%1'", StringUtil.StringReplace( ((string)AV11Data.Item(1)), "'", ""), "", "", "", "", "", "", "", "");
            }
         }
         AV21IsValid = true;
         if ( AV20IsRequired && ( StringUtil.StrCmp(StringUtil.Trim( AV25ThisValueStr), "''") == 0 ) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), AV31WWPFormElementTitle, "", "", "", "", "", "", "", ""),  "error",  AV16ElementInternalName,  "true",  ""));
            AV21IsValid = false;
         }
         else
         {
            if ( AV26Validations.Count > 0 )
            {
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV32WWPFormInstance,  AV8WWPFormInstanceElementId,  AV25ThisValueStr,  AV26Validations, out  AV23Messages) ;
               AV45GXV3 = 1;
               while ( AV45GXV3 <= AV23Messages.Count )
               {
                  AV22Message = ((GeneXus.Utils.SdtMessages_Message)AV23Messages.Item(AV45GXV3));
                  GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV22Message.gxTpr_Description,  ((AV22Message.gxTpr_Type==1) ? "error" : "info"),  AV16ElementInternalName,  "true",  ""));
                  if ( AV22Message.gxTpr_Type == 1 )
                  {
                     AV21IsValid = false;
                     if (true) break;
                  }
                  AV45GXV3 = (int)(AV45GXV3+1);
               }
            }
         }
      }

      protected void S192( )
      {
         /* 'LOAD TITLE AND METADATA' Routine */
         returnInSub = false;
         if ( AV6WWPFormElementCaption == 2 )
         {
            lblDatatitle_Caption = AV31WWPFormElementTitle;
            AssignProp(sPrefix, false, lblDatatitle_Internalname, "Caption", lblDatatitle_Caption, true);
            divDatatitlecell_Visible = 1;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         else
         {
            divDatatitlecell_Visible = 0;
            AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDatatitlecell_Visible), 5, 0), true);
         }
         AV12DataCellNameClass = "DataContentCell DscTop";
         if ( AV6WWPFormElementCaption != 1 )
         {
            AV12DataCellNameClass += " DataContentCellNoLabel";
         }
         lblTextblockcombo_data_Caption = AV31WWPFormElementTitle;
         AssignProp(sPrefix, false, lblTextblockcombo_data_Internalname, "Caption", lblTextblockcombo_data_Caption, true);
         AV5WWP_DF_CharMetadata.FromJSonString(AV7WWPFormElementMetadata, null);
         if ( AV5WWP_DF_CharMetadata.gxTpr_Isrequired )
         {
            AV12DataCellNameClass = "Required" + AV12DataCellNameClass;
         }
         divDatacellname_Class = AV12DataCellNameClass;
         AssignProp(sPrefix, false, divDatacellname_Internalname, "Class", divDatacellname_Class, true);
         divDatatitlecell_Class = AV12DataCellNameClass;
         AssignProp(sPrefix, false, divDatatitlecell_Internalname, "Class", divDatatitlecell_Class, true);
      }

      protected void S132( )
      {
         /* 'SET FOCUS TO ELEMENT' Routine */
         returnInSub = false;
         GX_FocusControl = Combo_data_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      protected void nextLoad( )
      {
      }

      protected void E15212( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV29WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV29WWPDynamicFormMode", AV29WWPDynamicFormMode);
         AV30WWPFormElementId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV30WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV30WWPFormElementId), 4, 0));
         AV8WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV8WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV8WWPFormInstanceElementId), 4, 0));
         AV24SessionId = Convert.ToInt16(getParm(obj,3));
         AssignAttri(sPrefix, false, "AV24SessionId", StringUtil.LTrimStr( (decimal)(AV24SessionId), 4, 0));
         AV32WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,4);
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
         PA212( ) ;
         WS212( ) ;
         WE212( ) ;
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
         sCtrlAV29WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV30WWPFormElementId = (string)((string)getParm(obj,1));
         sCtrlAV8WWPFormInstanceElementId = (string)((string)getParm(obj,2));
         sCtrlAV24SessionId = (string)((string)getParm(obj,3));
         sCtrlAV32WWPFormInstance = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA212( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_dynamiccombobox_wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA212( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV29WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV29WWPDynamicFormMode", AV29WWPDynamicFormMode);
            AV30WWPFormElementId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV30WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV30WWPFormElementId), 4, 0));
            AV8WWPFormInstanceElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV8WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV8WWPFormInstanceElementId), 4, 0));
            AV24SessionId = Convert.ToInt16(getParm(obj,5));
            AssignAttri(sPrefix, false, "AV24SessionId", StringUtil.LTrimStr( (decimal)(AV24SessionId), 4, 0));
            AV32WWPFormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)getParm(obj,6);
         }
         wcpOAV29WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV29WWPDynamicFormMode");
         wcpOAV30WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV30WWPFormElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV8WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8WWPFormInstanceElementId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOAV24SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV24SessionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV29WWPDynamicFormMode, wcpOAV29WWPDynamicFormMode) != 0 ) || ( AV30WWPFormElementId != wcpOAV30WWPFormElementId ) || ( AV8WWPFormInstanceElementId != wcpOAV8WWPFormInstanceElementId ) || ( AV24SessionId != wcpOAV24SessionId ) ) )
         {
            setjustcreated();
         }
         wcpOAV29WWPDynamicFormMode = AV29WWPDynamicFormMode;
         wcpOAV30WWPFormElementId = AV30WWPFormElementId;
         wcpOAV8WWPFormInstanceElementId = AV8WWPFormInstanceElementId;
         wcpOAV24SessionId = AV24SessionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV29WWPDynamicFormMode = cgiGet( sPrefix+"AV29WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV29WWPDynamicFormMode) > 0 )
         {
            AV29WWPDynamicFormMode = cgiGet( sCtrlAV29WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV29WWPDynamicFormMode", AV29WWPDynamicFormMode);
         }
         else
         {
            AV29WWPDynamicFormMode = cgiGet( sPrefix+"AV29WWPDynamicFormMode_PARM");
         }
         sCtrlAV30WWPFormElementId = cgiGet( sPrefix+"AV30WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV30WWPFormElementId) > 0 )
         {
            AV30WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV30WWPFormElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV30WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV30WWPFormElementId), 4, 0));
         }
         else
         {
            AV30WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV30WWPFormElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV8WWPFormInstanceElementId = cgiGet( sPrefix+"AV8WWPFormInstanceElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV8WWPFormInstanceElementId) > 0 )
         {
            AV8WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8WWPFormInstanceElementId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8WWPFormInstanceElementId", StringUtil.LTrimStr( (decimal)(AV8WWPFormInstanceElementId), 4, 0));
         }
         else
         {
            AV8WWPFormInstanceElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8WWPFormInstanceElementId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV24SessionId = cgiGet( sPrefix+"AV24SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV24SessionId) > 0 )
         {
            AV24SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV24SessionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV24SessionId", StringUtil.LTrimStr( (decimal)(AV24SessionId), 4, 0));
         }
         else
         {
            AV24SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV24SessionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlAV32WWPFormInstance = cgiGet( sPrefix+"AV32WWPFormInstance_CTRL");
         if ( StringUtil.Len( sCtrlAV32WWPFormInstance) > 0 )
         {
            AV32WWPFormInstance.FromXml(cgiGet( sCtrlAV32WWPFormInstance), null, "", "");
         }
         else
         {
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"AV32WWPFormInstance_PARM"), AV32WWPFormInstance);
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
         PA212( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS212( ) ;
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
         WS212( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV29WWPDynamicFormMode_PARM", StringUtil.RTrim( AV29WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV29WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV29WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV29WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV30WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30WWPFormElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV30WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV30WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV30WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPFormInstanceElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8WWPFormInstanceElementId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8WWPFormInstanceElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8WWPFormInstanceElementId_CTRL", StringUtil.RTrim( sCtrlAV8WWPFormInstanceElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV24SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24SessionId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV24SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV24SessionId_CTRL", StringUtil.RTrim( sCtrlAV24SessionId));
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"AV32WWPFormInstance_PARM", AV32WWPFormInstance);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"AV32WWPFormInstance_PARM", AV32WWPFormInstance);
         }
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV32WWPFormInstance)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV32WWPFormInstance_CTRL", StringUtil.RTrim( sCtrlAV32WWPFormInstance));
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
         WE212( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411143342444", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_dynamiccombobox_wc.js", "?202411143342447", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         divHiddenvars_Internalname = sPrefix+"HIDDENVARS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavSessionid_Internalname = sPrefix+"vSESSIONID";
         edtavWwpformelementid_Internalname = sPrefix+"vWWPFORMELEMENTID";
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
         edtavWwpformelementid_Jsonclick = "";
         edtavWwpformelementid_Visible = 1;
         edtavSessionid_Jsonclick = "";
         edtavSessionid_Visible = 1;
         Combo_data_Caption = "";
         lblTextblockcombo_data_Caption = context.GetMessage( "Data", "");
         divDatacellname_Class = "col-xs-12 DataContentCell DscTop ExtendedComboCell";
         lblDatatitle_Caption = context.GetMessage( "Title", "");
         divDatatitlecell_Class = "col-xs-12";
         divDatatitlecell_Visible = 1;
         divLayoutmaintable_Class = "Table";
         Combo_data_Emptyitemtext = "GX_EmptyItemText";
         Combo_data_Multiplevaluestype = "Tags";
         Combo_data_Emptyitem = Convert.ToBoolean( -1);
         Combo_data_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_data_Datalistprocparametersprefix = "";
         Combo_data_Datalistproc = "WorkWithPlus.DynamicForms.WWP_DF_DynamicComboBox_WCLoadDVCombo";
         Combo_data_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_data_Enabled = Convert.ToBoolean( -1);
         Combo_data_Cls = "ExtendedCombo Attribute";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV5WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV18HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV31WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true}]}""");
         setEventMetadata("COMBO_DATA.ONOPTIONCLICKED","""{"handler":"E11212","iparms":[{"av":"AV5WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"Combo_data_Selectedvalue_get","ctrl":"COMBO_DATA","prop":"SelectedValue_get"},{"av":"AV18HasReferenceId","fld":"vHASREFERENCEID","hsh":true},{"av":"AV24SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV30WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV8WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"Combo_data_Ddointernalname","ctrl":"COMBO_DATA","prop":"DDOInternalName"},{"av":"AV11Data","fld":"vDATA"},{"av":"AV31WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV33WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("COMBO_DATA.ONOPTIONCLICKED",""","oparms":[{"av":"AV11Data","fld":"vDATA"},{"av":"AV17ExistElement","fld":"vEXISTELEMENT"},{"av":"AV33WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE","""{"handler":"E13212","iparms":[{"av":"AV40ErrorIds","fld":"vERRORIDS"},{"av":"AV9AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV24SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"},{"av":"AV30WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9"},{"av":"AV8WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV17ExistElement","fld":"vEXISTELEMENT"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV5WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"Combo_data_Ddointernalname","ctrl":"COMBO_DATA","prop":"DDOInternalName"},{"av":"AV11Data","fld":"vDATA"},{"av":"AV31WWPFormElementTitle","fld":"vWWPFORMELEMENTTITLE","hsh":true},{"av":"AV33WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_VALIDATE",""","oparms":[{"av":"AV17ExistElement","fld":"vEXISTELEMENT"},{"av":"AV33WWPFormInstanceElement","fld":"vWWPFORMINSTANCEELEMENT"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"}]}""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES","""{"handler":"E14212","iparms":[{"av":"AV9AuxSessionId","fld":"vAUXSESSIONID","pic":"ZZZ9"},{"av":"AV24SessionId","fld":"vSESSIONID","pic":"ZZZ9"},{"av":"AV27VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"AV5WWP_DF_CharMetadata","fld":"vWWP_DF_CHARMETADATA","hsh":true},{"av":"AV8WWPFormInstanceElementId","fld":"vWWPFORMINSTANCEELEMENTID","pic":"ZZZ9"},{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"}]""");
         setEventMetadata("GLOBALEVENTS.DYNAMICFORM_UPDATEVISIBILITIES",""","oparms":[{"av":"AV32WWPFormInstance","fld":"vWWPFORMINSTANCE"},{"av":"AV27VisibleCondition","fld":"vVISIBLECONDITION"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
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
         AV32WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         wcpOAV29WWPDynamicFormMode = "";
         Combo_data_Selectedvalue_get = "";
         Combo_data_Ddointernalname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV5WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV31WWPFormElementTitle = "";
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV34Data_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV11Data = new GxSimpleCollection<string>();
         AV33WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV40ErrorIds = "";
         AV27VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         Combo_data_Selectedvalue_set = "";
         Combo_data_Selectedtext_set = "";
         Combo_data_Gamoauthtoken = "";
         GX_FocusControl = "";
         lblDatatitle_Jsonclick = "";
         lblTextblockcombo_data_Jsonclick = "";
         ucCombo_data = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV10CurrentWWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV7WWPFormElementMetadata = "";
         AV28WebSession = context.GetSession();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV42GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13DataDescriptionCol = new GxSimpleCollection<string>();
         GXt_SdtWWP_FormInstance2 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         AV26Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Comforta_version2");
         AV16ElementInternalName = "";
         AV25ThisValueStr = "";
         AV23Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12DataCellNameClass = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV29WWPDynamicFormMode = "";
         sCtrlAV30WWPFormElementId = "";
         sCtrlAV8WWPFormInstanceElementId = "";
         sCtrlAV24SessionId = "";
         sCtrlAV32WWPFormInstance = "";
         /* GeneXus formulas. */
      }

      private short AV30WWPFormElementId ;
      private short AV8WWPFormInstanceElementId ;
      private short AV24SessionId ;
      private short wcpOAV30WWPFormElementId ;
      private short wcpOAV8WWPFormInstanceElementId ;
      private short wcpOAV24SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV9AuxSessionId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV6WWPFormElementCaption ;
      private short nGXWrapped ;
      private int divDatatitlecell_Visible ;
      private int edtavSessionid_Visible ;
      private int edtavWwpformelementid_Visible ;
      private int AV43GXV1 ;
      private int AV44GXV2 ;
      private int AV45GXV3 ;
      private int idxLst ;
      private string AV29WWPDynamicFormMode ;
      private string wcpOAV29WWPDynamicFormMode ;
      private string Combo_data_Selectedvalue_get ;
      private string Combo_data_Ddointernalname ;
      private string divLayoutmaintable_Class ;
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
      private string Combo_data_Cls ;
      private string Combo_data_Selectedvalue_set ;
      private string Combo_data_Selectedtext_set ;
      private string Combo_data_Gamoauthtoken ;
      private string Combo_data_Datalistproc ;
      private string Combo_data_Datalistprocparametersprefix ;
      private string Combo_data_Multiplevaluestype ;
      private string Combo_data_Emptyitemtext ;
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
      private string Combo_data_Internalname ;
      private string divHiddenvars_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSessionid_Internalname ;
      private string edtavSessionid_Jsonclick ;
      private string edtavWwpformelementid_Internalname ;
      private string edtavWwpformelementid_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV29WWPDynamicFormMode ;
      private string sCtrlAV30WWPFormElementId ;
      private string sCtrlAV8WWPFormInstanceElementId ;
      private string sCtrlAV24SessionId ;
      private string sCtrlAV32WWPFormInstance ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18HasReferenceId ;
      private bool AV17ExistElement ;
      private bool Combo_data_Enabled ;
      private bool Combo_data_Allowmultipleselection ;
      private bool Combo_data_Includeonlyselectedoption ;
      private bool Combo_data_Emptyitem ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV19IsElementFocusable ;
      private bool AV14DataEnabled ;
      private bool AV20IsRequired ;
      private bool AV21IsValid ;
      private string AV31WWPFormElementTitle ;
      private string AV7WWPFormElementMetadata ;
      private string AV40ErrorIds ;
      private string AV16ElementInternalName ;
      private string AV25ThisValueStr ;
      private string AV12DataCellNameClass ;
      private IGxSession AV28WebSession ;
      private GXUserControl ucCombo_data ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV32WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP4_WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV5WWP_DF_CharMetadata ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV34Data_Data ;
      private GxSimpleCollection<string> AV11Data ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV33WWPFormInstanceElement ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV27VisibleCondition ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV10CurrentWWPFormInstanceElement ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV41GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV42GAMErrors ;
      private GxSimpleCollection<string> AV13DataDescriptionCol ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance2 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV26Validations ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV23Messages ;
      private GeneXus.Utils.SdtMessages_Message AV22Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
