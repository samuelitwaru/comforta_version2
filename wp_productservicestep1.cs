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
   public class wp_productservicestep1 : GXWebComponent
   {
      public wp_productservicestep1( )
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

      public wp_productservicestep1( IGxContext context )
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
         this.AV37WebSessionKey = aP0_WebSessionKey;
         this.AV20PreviousStep = aP1_PreviousStep;
         this.AV14GoingBack = aP2_GoingBack;
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
         cmbavProductserviceclass = new GXCombobox();
         cmbavProductservicegroup = new GXCombobox();
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
                  AV37WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV37WebSessionKey", AV37WebSessionKey);
                  AV20PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
                  AV14GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV37WebSessionKey,(string)AV20PreviousStep,(bool)AV14GoingBack});
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
            PA722( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavFilename_Enabled = 0;
               AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
               WS722( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Product Service Step1", "")) ;
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
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
            GXEncryptionTmp = "wp_productservicestep1.aspx"+UrlEncode(StringUtil.RTrim(AV37WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV20PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV14GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_productservicestep1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV34UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV34UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILES", AV9FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILES", AV9FailedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSUPPLIERAGBID_DATA", AV29SupplierAgbId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSUPPLIERAGBID_DATA", AV29SupplierAgbId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSUPPLIERGENID_DATA", AV31SupplierGenId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSUPPLIERGENID_DATA", AV31SupplierGenId_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV37WebSessionKey", wcpOAV37WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20PreviousStep", wcpOAV20PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV14GoingBack", wcpOAV14GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV14GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV5CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILETYPE", AV11FileType);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV37WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV20PreviousStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERGENID_Selectedvalue_get", StringUtil.RTrim( Combo_suppliergenid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERAGBID_Selectedvalue_get", StringUtil.RTrim( Combo_supplieragbid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERGENID_Selectedvalue_get", StringUtil.RTrim( Combo_suppliergenid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_SUPPLIERAGBID_Selectedvalue_get", StringUtil.RTrim( Combo_supplieragbid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm722( )
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
         return "WP_ProductServiceStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Product Service Step1", "") ;
      }

      protected void WB720( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_productservicestep1.aspx");
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Product/Service", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_ProductServiceStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProductservicename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductservicename_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductservicename_Internalname, AV26ProductServiceName, StringUtil.RTrim( context.localUtil.Format( AV26ProductServiceName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductservicename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductservicename_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProductservicetilename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductservicetilename_Internalname, context.GetMessage( "Tile Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductservicetilename_Internalname, StringUtil.RTrim( AV27ProductServiceTileName), StringUtil.RTrim( context.localUtil.Format( AV27ProductServiceTileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductservicetilename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductservicetilename_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProductserviceimagetext_Internalname, context.GetMessage( "Image", ""), "", "", lblProductserviceimagetext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-5", "start", "top", "", "", "div");
            wb_table1_37_722( true) ;
         }
         else
         {
            wb_table1_37_722( false) ;
         }
         return  ;
      }

      protected void wb_table1_37_722e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavProductserviceclass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavProductserviceclass_Internalname, context.GetMessage( "Category", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavProductserviceclass, cmbavProductserviceclass_Internalname, StringUtil.RTrim( AV39ProductServiceClass), 1, cmbavProductserviceclass_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavProductserviceclass.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_WP_ProductServiceStep1.htm");
            cmbavProductserviceclass.CurrentValue = StringUtil.RTrim( AV39ProductServiceClass);
            AssignProp(sPrefix, false, cmbavProductserviceclass_Internalname, "Values", (string)(cmbavProductserviceclass.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavProductservicegroup_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavProductservicegroup_Internalname, context.GetMessage( "Supplier group", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavProductservicegroup, cmbavProductservicegroup_Internalname, StringUtil.RTrim( AV22ProductServiceGroup), 1, cmbavProductservicegroup_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavProductservicegroup.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_WP_ProductServiceStep1.htm");
            cmbavProductservicegroup.CurrentValue = StringUtil.RTrim( AV22ProductServiceGroup);
            AssignProp(sPrefix, false, cmbavProductservicegroup_Internalname, "Values", (string)(cmbavProductservicegroup.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesupplieragb_Internalname, divTablesupplieragb_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsupplieragbid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_supplieragbid_Internalname, context.GetMessage( "AGB Supplier", ""), "", "", lblTextblockcombo_supplieragbid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_supplieragbid.SetProperty("Caption", Combo_supplieragbid_Caption);
            ucCombo_supplieragbid.SetProperty("Cls", Combo_supplieragbid_Cls);
            ucCombo_supplieragbid.SetProperty("EmptyItem", Combo_supplieragbid_Emptyitem);
            ucCombo_supplieragbid.SetProperty("DropDownOptionsData", AV29SupplierAgbId_Data);
            ucCombo_supplieragbid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplieragbid_Internalname, sPrefix+"COMBO_SUPPLIERAGBIDContainer");
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
            GxWebStd.gx_div_start( context, divTablesuppliergen_Internalname, divTablesuppliergen_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsuppliergenid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_suppliergenid_Internalname, context.GetMessage( "General Supplier", ""), "", "", lblTextblockcombo_suppliergenid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_suppliergenid.SetProperty("Caption", Combo_suppliergenid_Caption);
            ucCombo_suppliergenid.SetProperty("Cls", Combo_suppliergenid_Cls);
            ucCombo_suppliergenid.SetProperty("EmptyItem", Combo_suppliergenid_Emptyitem);
            ucCombo_suppliergenid.SetProperty("DropDownOptionsData", AV31SupplierGenId_Data);
            ucCombo_suppliergenid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenid_Internalname, sPrefix+"COMBO_SUPPLIERGENIDContainer");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProductservicedescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductservicedescription_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavProductservicedescription_Internalname, AV21ProductServiceDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", 0, 1, edtavProductservicedescription_Enabled, 0, 40, "chr", 5, "row", 0, StyleString, ClassString, "", "", "2097152", 1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WP_ProductServiceStep1.htm");
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
            ucBtnwizardfirstprevious.SetProperty("BeforeIconClass", Btnwizardfirstprevious_Beforeiconclass);
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardnext.SetProperty("TooltipText", Btnwizardnext_Tooltiptext);
            ucBtnwizardnext.SetProperty("AfterIconClass", Btnwizardnext_Aftericonclass);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSupplieragbid_Internalname, AV28SupplierAgbId.ToString(), AV28SupplierAgbId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSupplieragbid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSupplieragbid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProductServiceStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSuppliergenid_Internalname, AV30SupplierGenId.ToString(), AV30SupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSuppliergenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSuppliergenid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProductServiceStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductserviceid_Internalname, AV23ProductServiceId.ToString(), AV23ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductserviceid_Jsonclick, 0, "Attribute", "", "", "", "", edtavProductserviceid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_ProductServiceStep1.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavProductserviceimagevar_Internalname, AV25ProductServiceImageVar, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", 0, edtavProductserviceimagevar_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START722( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Product Service Step1", ""), 0) ;
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
               STRUP720( ) ;
            }
         }
      }

      protected void WS722( )
      {
         START722( ) ;
         EVT722( ) ;
      }

      protected void EVT722( )
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
                                 STRUP720( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERAGBID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_supplieragbid.Onoptionclicked */
                                    E11722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERGENID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_suppliergenid.Onoptionclicked */
                                    E12722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E14722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
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
                                          E15722 ();
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
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E16722 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E17722 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP720( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavProductservicename_Internalname;
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

      protected void WE722( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm722( ) ;
            }
         }
      }

      protected void PA722( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_productservicestep1.aspx")), "wp_productservicestep1.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_productservicestep1.aspx")))) ;
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
               GX_FocusControl = edtavProductservicename_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavProductserviceclass.ItemCount > 0 )
         {
            AV39ProductServiceClass = cmbavProductserviceclass.getValidValue(AV39ProductServiceClass);
            AssignAttri(sPrefix, false, "AV39ProductServiceClass", AV39ProductServiceClass);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavProductserviceclass.CurrentValue = StringUtil.RTrim( AV39ProductServiceClass);
            AssignProp(sPrefix, false, cmbavProductserviceclass_Internalname, "Values", cmbavProductserviceclass.ToJavascriptSource(), true);
         }
         if ( cmbavProductservicegroup.ItemCount > 0 )
         {
            AV22ProductServiceGroup = cmbavProductservicegroup.getValidValue(AV22ProductServiceGroup);
            AssignAttri(sPrefix, false, "AV22ProductServiceGroup", AV22ProductServiceGroup);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavProductservicegroup.CurrentValue = StringUtil.RTrim( AV22ProductServiceGroup);
            AssignProp(sPrefix, false, cmbavProductservicegroup_Internalname, "Values", cmbavProductservicegroup.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF722( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavFilename_Enabled = 0;
         AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
      }

      protected void RF722( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E14722 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E17722 ();
            WB720( ) ;
         }
      }

      protected void send_integrity_lvl_hashes722( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV15HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV15HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         edtavFilename_Enabled = 0;
         AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP720( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13722 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV34UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILES"), AV9FailedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSUPPLIERAGBID_DATA"), AV29SupplierAgbId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSUPPLIERGENID_DATA"), AV31SupplierGenId_Data);
            /* Read saved values. */
            wcpOAV37WebSessionKey = cgiGet( sPrefix+"wcpOAV37WebSessionKey");
            wcpOAV20PreviousStep = cgiGet( sPrefix+"wcpOAV20PreviousStep");
            wcpOAV14GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV14GoingBack"));
            Combo_suppliergenid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_SUPPLIERGENID_Selectedvalue_get");
            Combo_supplieragbid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_SUPPLIERAGBID_Selectedvalue_get");
            /* Read variables values. */
            AV26ProductServiceName = cgiGet( edtavProductservicename_Internalname);
            AssignAttri(sPrefix, false, "AV26ProductServiceName", AV26ProductServiceName);
            AV27ProductServiceTileName = cgiGet( edtavProductservicetilename_Internalname);
            AssignAttri(sPrefix, false, "AV27ProductServiceTileName", AV27ProductServiceTileName);
            AV10FileName = cgiGet( edtavFilename_Internalname);
            AssignAttri(sPrefix, false, "AV10FileName", AV10FileName);
            cmbavProductserviceclass.CurrentValue = cgiGet( cmbavProductserviceclass_Internalname);
            AV39ProductServiceClass = cgiGet( cmbavProductserviceclass_Internalname);
            AssignAttri(sPrefix, false, "AV39ProductServiceClass", AV39ProductServiceClass);
            cmbavProductservicegroup.CurrentValue = cgiGet( cmbavProductservicegroup_Internalname);
            AV22ProductServiceGroup = cgiGet( cmbavProductservicegroup_Internalname);
            AssignAttri(sPrefix, false, "AV22ProductServiceGroup", AV22ProductServiceGroup);
            AV21ProductServiceDescription = cgiGet( edtavProductservicedescription_Internalname);
            AssignAttri(sPrefix, false, "AV21ProductServiceDescription", AV21ProductServiceDescription);
            if ( StringUtil.StrCmp(cgiGet( edtavSupplieragbid_Internalname), "") == 0 )
            {
               AV28SupplierAgbId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
            }
            else
            {
               try
               {
                  AV28SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtavSupplieragbid_Internalname));
                  AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vSUPPLIERAGBID");
                  GX_FocusControl = edtavSupplieragbid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavSuppliergenid_Internalname), "") == 0 )
            {
               AV30SupplierGenId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
            }
            else
            {
               try
               {
                  AV30SupplierGenId = StringUtil.StrToGuid( cgiGet( edtavSuppliergenid_Internalname));
                  AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vSUPPLIERGENID");
                  GX_FocusControl = edtavSuppliergenid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtavProductserviceid_Internalname), "") == 0 )
            {
               AV23ProductServiceId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV23ProductServiceId", AV23ProductServiceId.ToString());
            }
            else
            {
               try
               {
                  AV23ProductServiceId = StringUtil.StrToGuid( cgiGet( edtavProductserviceid_Internalname));
                  AssignAttri(sPrefix, false, "AV23ProductServiceId", AV23ProductServiceId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vPRODUCTSERVICEID");
                  GX_FocusControl = edtavProductserviceid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV25ProductServiceImageVar = cgiGet( edtavProductserviceimagevar_Internalname);
            AssignAttri(sPrefix, false, "AV25ProductServiceImageVar", AV25ProductServiceImageVar);
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
         E13722 ();
         if (returnInSub) return;
      }

      protected void E13722( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_objcol_guid1 = AV43PreferredAgbSuppliers;
         new prc_getpreferredagbsuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV43PreferredAgbSuppliers = GXt_objcol_guid1;
         GXt_objcol_guid1 = AV44PreferredGenSuppliers;
         new prc_getpreferredgensuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV44PreferredGenSuppliers = GXt_objcol_guid1;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         edtavSuppliergenid_Visible = 0;
         AssignProp(sPrefix, false, edtavSuppliergenid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSuppliergenid_Visible), 5, 0), true);
         edtavSupplieragbid_Visible = 0;
         AssignProp(sPrefix, false, edtavSupplieragbid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplieragbid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENID' */
         S132 ();
         if (returnInSub) return;
         edtavProductserviceid_Visible = 0;
         AssignProp(sPrefix, false, edtavProductserviceid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProductserviceid_Visible), 5, 0), true);
         edtavProductserviceimagevar_Visible = 0;
         AssignProp(sPrefix, false, edtavProductserviceimagevar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProductserviceimagevar_Visible), 5, 0), true);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ProductServiceImageVar)) )
         {
            lblUseractiondelete_Visible = 0;
            AssignProp(sPrefix, false, lblUseractiondelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUseractiondelete_Visible), 5, 0), true);
         }
         else
         {
            lblUseractiondelete_Visible = 1;
            AssignProp(sPrefix, false, lblUseractiondelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUseractiondelete_Visible), 5, 0), true);
         }
         if ( (Guid.Empty==AV28SupplierAgbId) )
         {
            divTablesupplieragb_Visible = 0;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
         }
         else
         {
            divTablesupplieragb_Visible = 1;
            AssignProp(sPrefix, false, divTablesupplieragb_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesupplieragb_Visible), 5, 0), true);
         }
         if ( (Guid.Empty==AV30SupplierGenId) )
         {
            divTablesuppliergen_Visible = 0;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
         }
         else
         {
            divTablesuppliergen_Visible = 1;
            AssignProp(sPrefix, false, divTablesuppliergen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliergen_Visible), 5, 0), true);
         }
      }

      protected void E14722( )
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
         E15722 ();
         if (returnInSub) return;
      }

      protected void E15722( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S152 ();
         if (returnInSub) return;
         if ( AV5CheckRequiredFieldsResult && ! AV15HasValidationErrors )
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
            GXEncryptionTmp = "wp_productservice.aspx"+UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wp_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E16722( )
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

      protected void E12722( )
      {
         /* Combo_suppliergenid_Onoptionclicked Routine */
         returnInSub = false;
         AV28SupplierAgbId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
         AV30SupplierGenId = StringUtil.StrToGuid( Combo_suppliergenid_Selectedvalue_get);
         AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         /*  Sending Event outputs  */
      }

      protected void E11722( )
      {
         /* Combo_supplieragbid_Onoptionclicked Routine */
         returnInSub = false;
         AV30SupplierGenId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         AV28SupplierAgbId = StringUtil.StrToGuid( Combo_supplieragbid_Selectedvalue_get);
         AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV14GoingBack ) )
         {
            Btnwizardfirstprevious_Visible = false;
            ucBtnwizardfirstprevious.SendProperty(context, sPrefix, false, Btnwizardfirstprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnwizardfirstprevious_Visible));
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV38WizardData.FromJSonString(AV36WebSession.Get(AV37WebSessionKey), null);
         AV39ProductServiceClass = AV38WizardData.gxTpr_Step1.gxTpr_Productserviceclass;
         AssignAttri(sPrefix, false, "AV39ProductServiceClass", AV39ProductServiceClass);
         AV22ProductServiceGroup = AV38WizardData.gxTpr_Step1.gxTpr_Productservicegroup;
         AssignAttri(sPrefix, false, "AV22ProductServiceGroup", AV22ProductServiceGroup);
         AV21ProductServiceDescription = AV38WizardData.gxTpr_Step1.gxTpr_Productservicedescription;
         AssignAttri(sPrefix, false, "AV21ProductServiceDescription", AV21ProductServiceDescription);
         AV30SupplierGenId = AV38WizardData.gxTpr_Step1.gxTpr_Suppliergenid;
         AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         AV28SupplierAgbId = AV38WizardData.gxTpr_Step1.gxTpr_Supplieragbid;
         AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
         AV23ProductServiceId = AV38WizardData.gxTpr_Step1.gxTpr_Productserviceid;
         AssignAttri(sPrefix, false, "AV23ProductServiceId", AV23ProductServiceId.ToString());
         AV26ProductServiceName = AV38WizardData.gxTpr_Step1.gxTpr_Productservicename;
         AssignAttri(sPrefix, false, "AV26ProductServiceName", AV26ProductServiceName);
         AV27ProductServiceTileName = AV38WizardData.gxTpr_Step1.gxTpr_Productservicetilename;
         AssignAttri(sPrefix, false, "AV27ProductServiceTileName", AV27ProductServiceTileName);
         AV25ProductServiceImageVar = AV38WizardData.gxTpr_Step1.gxTpr_Productserviceimagevar;
         AssignAttri(sPrefix, false, "AV25ProductServiceImageVar", AV25ProductServiceImageVar);
         AV10FileName = AV38WizardData.gxTpr_Step1.gxTpr_Filename;
         AssignAttri(sPrefix, false, "AV10FileName", AV10FileName);
      }

      protected void S162( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         if ( AV34UploadedFiles.Count > 0 )
         {
            AV25ProductServiceImageVar = context.FileToBase64( ((SdtFileUploadData)AV34UploadedFiles.Item(1)).gxTpr_File);
            AssignAttri(sPrefix, false, "AV25ProductServiceImageVar", AV25ProductServiceImageVar);
            AV10FileName = ((SdtFileUploadData)AV34UploadedFiles.Item(1)).gxTpr_Fullname;
            AssignAttri(sPrefix, false, "AV10FileName", AV10FileName);
            AV11FileType = ((SdtFileUploadData)AV34UploadedFiles.Item(1)).gxTpr_Extension;
            AssignAttri(sPrefix, false, "AV11FileType", AV11FileType);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ProductServiceImageVar)) )
            {
               AV25ProductServiceImageVar = "";
               AssignAttri(sPrefix, false, "AV25ProductServiceImageVar", AV25ProductServiceImageVar);
               AV10FileName = "";
               AssignAttri(sPrefix, false, "AV10FileName", AV10FileName);
            }
            else
            {
               AssignAttri(sPrefix, false, "AV25ProductServiceImageVar", AV25ProductServiceImageVar);
               AssignAttri(sPrefix, false, "AV10FileName", AV10FileName);
               AssignAttri(sPrefix, false, "AV11FileType", AV11FileType);
            }
         }
         if ( StringUtil.StrCmp(AV22ProductServiceGroup, "Location") == 0 )
         {
            AV28SupplierAgbId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV28SupplierAgbId", AV28SupplierAgbId.ToString());
            AV30SupplierGenId = Guid.Empty;
            AssignAttri(sPrefix, false, "AV30SupplierGenId", AV30SupplierGenId.ToString());
         }
         new prc_logtofile(context ).execute(  AV22ProductServiceGroup) ;
         AV23ProductServiceId = Guid.NewGuid( );
         AssignAttri(sPrefix, false, "AV23ProductServiceId", AV23ProductServiceId.ToString());
         AV38WizardData.FromJSonString(AV36WebSession.Get(AV37WebSessionKey), null);
         AV38WizardData.gxTpr_Step1.gxTpr_Productserviceclass = AV39ProductServiceClass;
         AV38WizardData.gxTpr_Step1.gxTpr_Productservicegroup = AV22ProductServiceGroup;
         AV38WizardData.gxTpr_Step1.gxTpr_Productservicedescription = AV21ProductServiceDescription;
         AV38WizardData.gxTpr_Step1.gxTpr_Suppliergenid = AV30SupplierGenId;
         AV38WizardData.gxTpr_Step1.gxTpr_Supplieragbid = AV28SupplierAgbId;
         AV38WizardData.gxTpr_Step1.gxTpr_Productserviceid = AV23ProductServiceId;
         AV38WizardData.gxTpr_Step1.gxTpr_Productservicename = AV26ProductServiceName;
         AV38WizardData.gxTpr_Step1.gxTpr_Productservicetilename = AV27ProductServiceTileName;
         AV38WizardData.gxTpr_Step1.gxTpr_Productserviceimagevar = AV25ProductServiceImageVar;
         AV38WizardData.gxTpr_Step1.gxTpr_Filename = AV10FileName;
         AV36WebSession.Set(AV37WebSessionKey, AV38WizardData.ToJSonString(false, true));
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV5CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26ProductServiceName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavProductservicename_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27ProductServiceTileName)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Tile Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavProductservicetilename_Internalname,  "true",  ""));
            AV5CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOSUPPLIERGENID' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A42SupplierGenId ,
                                              AV44PreferredGenSuppliers } ,
                                              new int[]{
                                              }
         });
         /* Using cursor H00722 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A42SupplierGenId = H00722_A42SupplierGenId[0];
            A44SupplierGenCompanyName = H00722_A44SupplierGenCompanyName[0];
            AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV6Combo_DataItem.gxTpr_Id = StringUtil.Trim( A42SupplierGenId.ToString());
            AV6Combo_DataItem.gxTpr_Title = A44SupplierGenCompanyName;
            AV31SupplierGenId_Data.Add(AV6Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_suppliergenid_Selectedvalue_set = ((Guid.Empty==AV30SupplierGenId) ? "" : StringUtil.Trim( AV30SupplierGenId.ToString()));
         ucCombo_suppliergenid.SendProperty(context, sPrefix, false, Combo_suppliergenid_Internalname, "SelectedValue_set", Combo_suppliergenid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERAGBID' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A49SupplierAgbId ,
                                              AV43PreferredAgbSuppliers } ,
                                              new int[]{
                                              }
         });
         /* Using cursor H00723 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A49SupplierAgbId = H00723_A49SupplierAgbId[0];
            A51SupplierAgbName = H00723_A51SupplierAgbName[0];
            AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV6Combo_DataItem.gxTpr_Id = StringUtil.Trim( A49SupplierAgbId.ToString());
            AV6Combo_DataItem.gxTpr_Title = A51SupplierAgbName;
            AV29SupplierAgbId_Data.Add(AV6Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_supplieragbid_Selectedvalue_set = ((Guid.Empty==AV28SupplierAgbId) ? "" : StringUtil.Trim( AV28SupplierAgbId.ToString()));
         ucCombo_supplieragbid.SendProperty(context, sPrefix, false, Combo_supplieragbid_Internalname, "SelectedValue_set", Combo_supplieragbid_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E17722( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_37_722( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedusercontrol1_Internalname, tblTablemergedusercontrol1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucUsercontrol1.SetProperty("AutoUpload", Usercontrol1_Autoupload);
            ucUsercontrol1.SetProperty("HideAdditionalButtons", Usercontrol1_Hideadditionalbuttons);
            ucUsercontrol1.SetProperty("TooltipText", Usercontrol1_Tooltiptext);
            ucUsercontrol1.SetProperty("EnableUploadedFileCanceling", Usercontrol1_Enableuploadedfilecanceling);
            ucUsercontrol1.SetProperty("DisableImageResize", Usercontrol1_Disableimageresize);
            ucUsercontrol1.SetProperty("MaxFileSize", Usercontrol1_Maxfilesize);
            ucUsercontrol1.SetProperty("MaxNumberOfFiles", Usercontrol1_Maxnumberoffiles);
            ucUsercontrol1.SetProperty("AutoDisableAddingFiles", Usercontrol1_Autodisableaddingfiles);
            ucUsercontrol1.SetProperty("AcceptedFileTypes", Usercontrol1_Acceptedfiletypes);
            ucUsercontrol1.SetProperty("UploadedFiles", AV34UploadedFiles);
            ucUsercontrol1.SetProperty("FailedFiles", AV9FailedFiles);
            ucUsercontrol1.Render(context, "fileupload", Usercontrol1_Internalname, sPrefix+"USERCONTROL1Container");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilename_Internalname, context.GetMessage( "File Name", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilename_Internalname, AV10FileName, StringUtil.RTrim( context.localUtil.Format( AV10FileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilename_Jsonclick, 0, "Attribute", "", "", "", "", edtavFilename_Visible, edtavFilename_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProductServiceStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUseractiondelete_Internalname, context.GetMessage( "<i class=\"fas fa-trash-can\"></i>", ""), "", "", lblUseractiondelete_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e18721_client"+"'", "", "TextBlock", 7, "", lblUseractiondelete_Visible, 1, 0, 1, "HLP_WP_ProductServiceStep1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_37_722e( true) ;
         }
         else
         {
            wb_table1_37_722e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV37WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV37WebSessionKey", AV37WebSessionKey);
         AV20PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
         AV14GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
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
         PA722( ) ;
         WS722( ) ;
         WE722( ) ;
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
         sCtrlAV37WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV20PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV14GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA722( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_productservicestep1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA722( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV37WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV37WebSessionKey", AV37WebSessionKey);
            AV20PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
            AV14GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
         }
         wcpOAV37WebSessionKey = cgiGet( sPrefix+"wcpOAV37WebSessionKey");
         wcpOAV20PreviousStep = cgiGet( sPrefix+"wcpOAV20PreviousStep");
         wcpOAV14GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV14GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV37WebSessionKey, wcpOAV37WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV20PreviousStep, wcpOAV20PreviousStep) != 0 ) || ( AV14GoingBack != wcpOAV14GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV37WebSessionKey = AV37WebSessionKey;
         wcpOAV20PreviousStep = AV20PreviousStep;
         wcpOAV14GoingBack = AV14GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV37WebSessionKey = cgiGet( sPrefix+"AV37WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV37WebSessionKey) > 0 )
         {
            AV37WebSessionKey = cgiGet( sCtrlAV37WebSessionKey);
            AssignAttri(sPrefix, false, "AV37WebSessionKey", AV37WebSessionKey);
         }
         else
         {
            AV37WebSessionKey = cgiGet( sPrefix+"AV37WebSessionKey_PARM");
         }
         sCtrlAV20PreviousStep = cgiGet( sPrefix+"AV20PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV20PreviousStep) > 0 )
         {
            AV20PreviousStep = cgiGet( sCtrlAV20PreviousStep);
            AssignAttri(sPrefix, false, "AV20PreviousStep", AV20PreviousStep);
         }
         else
         {
            AV20PreviousStep = cgiGet( sPrefix+"AV20PreviousStep_PARM");
         }
         sCtrlAV14GoingBack = cgiGet( sPrefix+"AV14GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV14GoingBack) > 0 )
         {
            AV14GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV14GoingBack));
            AssignAttri(sPrefix, false, "AV14GoingBack", AV14GoingBack);
         }
         else
         {
            AV14GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV14GoingBack_PARM"));
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
         PA722( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS722( ) ;
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
         WS722( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV37WebSessionKey_PARM", AV37WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV37WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV37WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV37WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20PreviousStep_PARM", AV20PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV20PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV14GoingBack_PARM", StringUtil.BoolToStr( AV14GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV14GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV14GoingBack_CTRL", StringUtil.RTrim( sCtrlAV14GoingBack));
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
         WE722( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241028525667", true, true);
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
         context.AddJavascriptSource("wp_productservicestep1.js", "?20241028525667", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
         cmbavProductserviceclass.Name = "vPRODUCTSERVICECLASS";
         cmbavProductserviceclass.WebTags = "";
         cmbavProductserviceclass.addItem("MyLiving", context.GetMessage( "My Living", ""), 0);
         cmbavProductserviceclass.addItem("MyCare", context.GetMessage( "My Care", ""), 0);
         cmbavProductserviceclass.addItem("MyServices", context.GetMessage( "My Services", ""), 0);
         if ( cmbavProductserviceclass.ItemCount > 0 )
         {
         }
         cmbavProductservicegroup.Name = "vPRODUCTSERVICEGROUP";
         cmbavProductservicegroup.WebTags = "";
         cmbavProductservicegroup.addItem("Location", context.GetMessage( "Location", ""), 0);
         cmbavProductservicegroup.addItem(" AGB Supplier", context.GetMessage( "AGB Supplier", ""), 0);
         cmbavProductservicegroup.addItem("General Supplier", context.GetMessage( "General Supplier", ""), 0);
         if ( cmbavProductservicegroup.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavProductservicename_Internalname = sPrefix+"vPRODUCTSERVICENAME";
         edtavProductservicetilename_Internalname = sPrefix+"vPRODUCTSERVICETILENAME";
         lblProductserviceimagetext_Internalname = sPrefix+"PRODUCTSERVICEIMAGETEXT";
         Usercontrol1_Internalname = sPrefix+"USERCONTROL1";
         edtavFilename_Internalname = sPrefix+"vFILENAME";
         lblUseractiondelete_Internalname = sPrefix+"USERACTIONDELETE";
         tblTablemergedusercontrol1_Internalname = sPrefix+"TABLEMERGEDUSERCONTROL1";
         divUcfilecell_Internalname = sPrefix+"UCFILECELL";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         cmbavProductserviceclass_Internalname = sPrefix+"vPRODUCTSERVICECLASS";
         cmbavProductservicegroup_Internalname = sPrefix+"vPRODUCTSERVICEGROUP";
         lblTextblockcombo_supplieragbid_Internalname = sPrefix+"TEXTBLOCKCOMBO_SUPPLIERAGBID";
         Combo_supplieragbid_Internalname = sPrefix+"COMBO_SUPPLIERAGBID";
         divTablesplittedsupplieragbid_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERAGBID";
         divTablesupplieragb_Internalname = sPrefix+"TABLESUPPLIERAGB";
         lblTextblockcombo_suppliergenid_Internalname = sPrefix+"TEXTBLOCKCOMBO_SUPPLIERGENID";
         Combo_suppliergenid_Internalname = sPrefix+"COMBO_SUPPLIERGENID";
         divTablesplittedsuppliergenid_Internalname = sPrefix+"TABLESPLITTEDSUPPLIERGENID";
         divTablesuppliergen_Internalname = sPrefix+"TABLESUPPLIERGEN";
         divUnnamedtable4_Internalname = sPrefix+"UNNAMEDTABLE4";
         edtavProductservicedescription_Internalname = sPrefix+"vPRODUCTSERVICEDESCRIPTION";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavSupplieragbid_Internalname = sPrefix+"vSUPPLIERAGBID";
         edtavSuppliergenid_Internalname = sPrefix+"vSUPPLIERGENID";
         edtavProductserviceid_Internalname = sPrefix+"vPRODUCTSERVICEID";
         edtavProductserviceimagevar_Internalname = sPrefix+"vPRODUCTSERVICEIMAGEVAR";
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
         lblUseractiondelete_Visible = 1;
         edtavFilename_Jsonclick = "";
         edtavFilename_Enabled = 1;
         edtavFilename_Visible = 1;
         Usercontrol1_Acceptedfiletypes = "image";
         Usercontrol1_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Usercontrol1_Maxnumberoffiles = 1;
         Usercontrol1_Maxfilesize = 134217728;
         Usercontrol1_Disableimageresize = Convert.ToBoolean( 0);
         Usercontrol1_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Usercontrol1_Tooltiptext = "";
         Usercontrol1_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Usercontrol1_Autoupload = Convert.ToBoolean( -1);
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         edtavProductserviceimagevar_Visible = 1;
         edtavProductserviceid_Jsonclick = "";
         edtavProductserviceid_Visible = 1;
         edtavSuppliergenid_Jsonclick = "";
         edtavSuppliergenid_Visible = 1;
         edtavSupplieragbid_Jsonclick = "";
         edtavSupplieragbid_Visible = 1;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Aftericonclass = "fas fa-arrow-right";
         Btnwizardnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = context.GetMessage( "GX_BtnCancel", "");
         Btnwizardfirstprevious_Beforeiconclass = "fas fa-arrow-left";
         Btnwizardfirstprevious_Tooltiptext = "";
         edtavProductservicedescription_Enabled = 1;
         Combo_suppliergenid_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergenid_Cls = "ExtendedCombo Attribute";
         divTablesuppliergen_Visible = 1;
         Combo_supplieragbid_Emptyitem = Convert.ToBoolean( 0);
         Combo_supplieragbid_Cls = "ExtendedCombo Attribute";
         divTablesupplieragb_Visible = 1;
         cmbavProductservicegroup_Jsonclick = "";
         cmbavProductservicegroup.Enabled = 1;
         cmbavProductserviceclass_Jsonclick = "";
         cmbavProductserviceclass.Enabled = 1;
         edtavProductservicetilename_Jsonclick = "";
         edtavProductservicetilename_Enabled = 1;
         edtavProductservicename_Jsonclick = "";
         edtavProductservicename_Enabled = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV14GoingBack","fld":"vGOINGBACK"},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E15722","iparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV15HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV26ProductServiceName","fld":"vPRODUCTSERVICENAME"},{"av":"AV27ProductServiceTileName","fld":"vPRODUCTSERVICETILENAME"},{"av":"AV34UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV25ProductServiceImageVar","fld":"vPRODUCTSERVICEIMAGEVAR"},{"av":"AV10FileName","fld":"vFILENAME"},{"av":"AV11FileType","fld":"vFILETYPE"},{"av":"cmbavProductservicegroup"},{"av":"AV22ProductServiceGroup","fld":"vPRODUCTSERVICEGROUP"},{"av":"AV37WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"cmbavProductserviceclass"},{"av":"AV39ProductServiceClass","fld":"vPRODUCTSERVICECLASS"},{"av":"AV21ProductServiceDescription","fld":"vPRODUCTSERVICEDESCRIPTION"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV5CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV11FileType","fld":"vFILETYPE"},{"av":"AV25ProductServiceImageVar","fld":"vPRODUCTSERVICEIMAGEVAR"},{"av":"AV10FileName","fld":"vFILENAME"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV23ProductServiceId","fld":"vPRODUCTSERVICEID"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E16722","iparms":[]}""");
         setEventMetadata("'DOUSERACTIONDELETE'","""{"handler":"E18721","iparms":[]""");
         setEventMetadata("'DOUSERACTIONDELETE'",""","oparms":[{"av":"AV25ProductServiceImageVar","fld":"vPRODUCTSERVICEIMAGEVAR"},{"av":"AV10FileName","fld":"vFILENAME"},{"av":"lblUseractiondelete_Visible","ctrl":"USERACTIONDELETE","prop":"Visible"}]}""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED","""{"handler":"E12722","iparms":[{"av":"Combo_suppliergenid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERGENID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SUPPLIERGENID.ONOPTIONCLICKED",""","oparms":[{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"},{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"}]}""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED","""{"handler":"E11722","iparms":[{"av":"Combo_supplieragbid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERAGBID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SUPPLIERAGBID.ONOPTIONCLICKED",""","oparms":[{"av":"AV30SupplierGenId","fld":"vSUPPLIERGENID"},{"av":"AV28SupplierAgbId","fld":"vSUPPLIERAGBID"}]}""");
         setEventMetadata("VALIDV_PRODUCTSERVICECLASS","""{"handler":"Validv_Productserviceclass","iparms":[]}""");
         setEventMetadata("VALIDV_PRODUCTSERVICEGROUP","""{"handler":"Validv_Productservicegroup","iparms":[]}""");
         setEventMetadata("VALIDV_SUPPLIERAGBID","""{"handler":"Validv_Supplieragbid","iparms":[]}""");
         setEventMetadata("VALIDV_SUPPLIERGENID","""{"handler":"Validv_Suppliergenid","iparms":[]}""");
         setEventMetadata("VALIDV_PRODUCTSERVICEID","""{"handler":"Validv_Productserviceid","iparms":[]}""");
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         wcpOAV37WebSessionKey = "";
         wcpOAV20PreviousStep = "";
         Combo_suppliergenid_Selectedvalue_get = "";
         Combo_supplieragbid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV34UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV9FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV29SupplierAgbId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV31SupplierGenId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV11FileType = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV26ProductServiceName = "";
         AV27ProductServiceTileName = "";
         lblProductserviceimagetext_Jsonclick = "";
         AV39ProductServiceClass = "";
         AV22ProductServiceGroup = "";
         lblTextblockcombo_supplieragbid_Jsonclick = "";
         ucCombo_supplieragbid = new GXUserControl();
         Combo_supplieragbid_Caption = "";
         lblTextblockcombo_suppliergenid_Jsonclick = "";
         ucCombo_suppliergenid = new GXUserControl();
         Combo_suppliergenid_Caption = "";
         AV21ProductServiceDescription = "";
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV28SupplierAgbId = Guid.Empty;
         AV30SupplierGenId = Guid.Empty;
         AV23ProductServiceId = Guid.Empty;
         AV25ProductServiceImageVar = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV10FileName = "";
         AV43PreferredAgbSuppliers = new GxSimpleCollection<Guid>();
         AV44PreferredGenSuppliers = new GxSimpleCollection<Guid>();
         GXt_objcol_guid1 = new GxSimpleCollection<Guid>();
         AV38WizardData = new SdtWP_ProductServiceData(context);
         AV36WebSession = context.GetSession();
         A42SupplierGenId = Guid.Empty;
         H00722_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H00722_A44SupplierGenCompanyName = new string[] {""} ;
         A44SupplierGenCompanyName = "";
         AV6Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         Combo_suppliergenid_Selectedvalue_set = "";
         A49SupplierAgbId = Guid.Empty;
         H00723_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H00723_A51SupplierAgbName = new string[] {""} ;
         A51SupplierAgbName = "";
         Combo_supplieragbid_Selectedvalue_set = "";
         sStyleString = "";
         ucUsercontrol1 = new GXUserControl();
         lblUseractiondelete_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV37WebSessionKey = "";
         sCtrlAV20PreviousStep = "";
         sCtrlAV14GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_productservicestep1__default(),
            new Object[][] {
                new Object[] {
               H00722_A42SupplierGenId, H00722_A44SupplierGenCompanyName
               }
               , new Object[] {
               H00723_A49SupplierAgbId, H00723_A51SupplierAgbName
               }
            }
         );
         /* GeneXus formulas. */
         edtavFilename_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
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
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavFilename_Enabled ;
      private int edtavProductservicename_Enabled ;
      private int edtavProductservicetilename_Enabled ;
      private int divTablesupplieragb_Visible ;
      private int divTablesuppliergen_Visible ;
      private int edtavProductservicedescription_Enabled ;
      private int edtavSupplieragbid_Visible ;
      private int edtavSuppliergenid_Visible ;
      private int edtavProductserviceid_Visible ;
      private int edtavProductserviceimagevar_Visible ;
      private int lblUseractiondelete_Visible ;
      private int Usercontrol1_Maxfilesize ;
      private int Usercontrol1_Maxnumberoffiles ;
      private int edtavFilename_Visible ;
      private int idxLst ;
      private string Combo_suppliergenid_Selectedvalue_get ;
      private string Combo_supplieragbid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavFilename_Internalname ;
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
      private string grpUnnamedgroup1_Internalname ;
      private string divTableattributes_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string edtavProductservicename_Internalname ;
      private string TempTags ;
      private string edtavProductservicename_Jsonclick ;
      private string edtavProductservicetilename_Internalname ;
      private string AV27ProductServiceTileName ;
      private string edtavProductservicetilename_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblProductserviceimagetext_Internalname ;
      private string lblProductserviceimagetext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string cmbavProductserviceclass_Internalname ;
      private string cmbavProductserviceclass_Jsonclick ;
      private string cmbavProductservicegroup_Internalname ;
      private string cmbavProductservicegroup_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divTablesupplieragb_Internalname ;
      private string divTablesplittedsupplieragbid_Internalname ;
      private string lblTextblockcombo_supplieragbid_Internalname ;
      private string lblTextblockcombo_supplieragbid_Jsonclick ;
      private string Combo_supplieragbid_Caption ;
      private string Combo_supplieragbid_Cls ;
      private string Combo_supplieragbid_Internalname ;
      private string divTablesuppliergen_Internalname ;
      private string divTablesplittedsuppliergenid_Internalname ;
      private string lblTextblockcombo_suppliergenid_Internalname ;
      private string lblTextblockcombo_suppliergenid_Jsonclick ;
      private string Combo_suppliergenid_Caption ;
      private string Combo_suppliergenid_Cls ;
      private string Combo_suppliergenid_Internalname ;
      private string edtavProductservicedescription_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Beforeiconclass ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Aftericonclass ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSupplieragbid_Internalname ;
      private string edtavSupplieragbid_Jsonclick ;
      private string edtavSuppliergenid_Internalname ;
      private string edtavSuppliergenid_Jsonclick ;
      private string edtavProductserviceid_Internalname ;
      private string edtavProductserviceid_Jsonclick ;
      private string edtavProductserviceimagevar_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string lblUseractiondelete_Internalname ;
      private string Combo_suppliergenid_Selectedvalue_set ;
      private string Combo_supplieragbid_Selectedvalue_set ;
      private string sStyleString ;
      private string tblTablemergedusercontrol1_Internalname ;
      private string Usercontrol1_Tooltiptext ;
      private string Usercontrol1_Acceptedfiletypes ;
      private string Usercontrol1_Internalname ;
      private string edtavFilename_Jsonclick ;
      private string lblUseractiondelete_Jsonclick ;
      private string sCtrlAV37WebSessionKey ;
      private string sCtrlAV20PreviousStep ;
      private string sCtrlAV14GoingBack ;
      private bool AV14GoingBack ;
      private bool wcpOAV14GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15HasValidationErrors ;
      private bool AV5CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Combo_supplieragbid_Emptyitem ;
      private bool Combo_suppliergenid_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool Btnwizardfirstprevious_Visible ;
      private bool Usercontrol1_Autoupload ;
      private bool Usercontrol1_Hideadditionalbuttons ;
      private bool Usercontrol1_Enableuploadedfilecanceling ;
      private bool Usercontrol1_Disableimageresize ;
      private bool Usercontrol1_Autodisableaddingfiles ;
      private string AV21ProductServiceDescription ;
      private string AV25ProductServiceImageVar ;
      private string AV37WebSessionKey ;
      private string AV20PreviousStep ;
      private string wcpOAV37WebSessionKey ;
      private string wcpOAV20PreviousStep ;
      private string AV11FileType ;
      private string AV26ProductServiceName ;
      private string AV39ProductServiceClass ;
      private string AV22ProductServiceGroup ;
      private string AV10FileName ;
      private string A44SupplierGenCompanyName ;
      private string A51SupplierAgbName ;
      private Guid AV28SupplierAgbId ;
      private Guid AV30SupplierGenId ;
      private Guid AV23ProductServiceId ;
      private Guid A42SupplierGenId ;
      private Guid A49SupplierAgbId ;
      private IGxSession AV36WebSession ;
      private GXUserControl ucCombo_supplieragbid ;
      private GXUserControl ucCombo_suppliergenid ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucUsercontrol1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavProductserviceclass ;
      private GXCombobox cmbavProductservicegroup ;
      private GXBaseCollection<SdtFileUploadData> AV34UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV9FailedFiles ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV29SupplierAgbId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV31SupplierGenId_Data ;
      private GxSimpleCollection<Guid> AV43PreferredAgbSuppliers ;
      private GxSimpleCollection<Guid> AV44PreferredGenSuppliers ;
      private GxSimpleCollection<Guid> GXt_objcol_guid1 ;
      private SdtWP_ProductServiceData AV38WizardData ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00722_A42SupplierGenId ;
      private string[] H00722_A44SupplierGenCompanyName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV6Combo_DataItem ;
      private Guid[] H00723_A49SupplierAgbId ;
      private string[] H00723_A51SupplierAgbName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_productservicestep1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00722( IGxContext context ,
                                             Guid A42SupplierGenId ,
                                             GxSimpleCollection<Guid> AV44PreferredGenSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SupplierGenId, SupplierGenCompanyName FROM Trn_SupplierGen";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV44PreferredGenSuppliers, "SupplierGenId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierGenCompanyName";
         GXv_Object2[0] = scmdbuf;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00723( IGxContext context ,
                                             Guid A49SupplierAgbId ,
                                             GxSimpleCollection<Guid> AV43PreferredAgbSuppliers )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SupplierAgbId, SupplierAgbName FROM Trn_SupplierAGB";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV43PreferredAgbSuppliers, "SupplierAgbId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SupplierAgbName";
         GXv_Object4[0] = scmdbuf;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00722(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
               case 1 :
                     return conditional_H00723(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00722;
          prmH00722 = new Object[] {
          };
          Object[] prmH00723;
          prmH00723 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00722", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00722,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00723", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00723,100, GxCacheFrequency.OFF ,false,false )
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
