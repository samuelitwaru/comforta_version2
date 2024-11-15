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
   public class trn_page : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Trn_Page", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrn_PageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_page( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_page( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbPageIsContentPage = new GXCombobox();
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_page_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      protected void fix_multi_value_controls( )
      {
         if ( cmbPageIsContentPage.ItemCount > 0 )
         {
            A439PageIsContentPage = StringUtil.StrToBool( cmbPageIsContentPage.getValidValue(StringUtil.BoolToStr( A439PageIsContentPage)));
            AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPageIsContentPage.CurrentValue = StringUtil.BoolToStr( A439PageIsContentPage);
            AssignProp("", false, cmbPageIsContentPage_Internalname, "Values", cmbPageIsContentPage.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Page.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_PageId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_PageId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_PageId_Internalname, A310Trn_PageId.ToString(), A310Trn_PageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_PageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_PageId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_PageName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_PageName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_PageName_Internalname, A318Trn_PageName, StringUtil.RTrim( context.localUtil.Format( A318Trn_PageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_PageName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_PageName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageJsonContent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageJsonContent_Internalname, context.GetMessage( "Json Content", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageJsonContent_Internalname, A431PageJsonContent, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", 0, 1, edtPageJsonContent_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageGJSHtml_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageGJSHtml_Internalname, context.GetMessage( "GJSHtml", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageGJSHtml_Internalname, A432PageGJSHtml, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", 1, 1, edtPageGJSHtml_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "GeneXus\\Html", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPageGJSJson_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPageGJSJson_Internalname, context.GetMessage( "GJSJson", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPageGJSJson_Internalname, A433PageGJSJson, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", 0, 1, edtPageGJSJson_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPageIsContentPage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPageIsContentPage_Internalname, context.GetMessage( "Content Page", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPageIsContentPage, cmbPageIsContentPage_Internalname, StringUtil.BoolToStr( A439PageIsContentPage), 1, cmbPageIsContentPage_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbPageIsContentPage.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_Trn_Page.htm");
         cmbPageIsContentPage.CurrentValue = StringUtil.BoolToStr( A439PageIsContentPage);
         AssignProp("", false, cmbPageIsContentPage_Internalname, "Values", (string)(cmbPageIsContentPage.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Page.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11172 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z310Trn_PageId = StringUtil.StrToGuid( cgiGet( "Z310Trn_PageId"));
               Z318Trn_PageName = cgiGet( "Z318Trn_PageName");
               Z434PageIsPublished = StringUtil.StrToBool( cgiGet( "Z434PageIsPublished"));
               Z439PageIsContentPage = StringUtil.StrToBool( cgiGet( "Z439PageIsContentPage"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z58ProductServiceId = StringUtil.StrToGuid( cgiGet( "Z58ProductServiceId"));
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               A434PageIsPublished = StringUtil.StrToBool( cgiGet( "Z434PageIsPublished"));
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               A29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               A58ProductServiceId = StringUtil.StrToGuid( cgiGet( "Z58ProductServiceId"));
               n58ProductServiceId = false;
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A434PageIsPublished = StringUtil.StrToBool( cgiGet( "PAGEISPUBLISHED"));
               A437PageChildren = cgiGet( "PAGECHILDREN");
               n437PageChildren = false;
               n437PageChildren = (String.IsNullOrEmpty(StringUtil.RTrim( A437PageChildren)) ? true : false);
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( "ORGANISATIONID"));
               A29LocationId = StringUtil.StrToGuid( cgiGet( "LOCATIONID"));
               A58ProductServiceId = StringUtil.StrToGuid( cgiGet( "PRODUCTSERVICEID"));
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtTrn_PageId_Internalname), "") == 0 )
               {
                  A310Trn_PageId = Guid.Empty;
                  AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
               }
               else
               {
                  try
                  {
                     A310Trn_PageId = StringUtil.StrToGuid( cgiGet( edtTrn_PageId_Internalname));
                     AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_PAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_PageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A318Trn_PageName = cgiGet( edtTrn_PageName_Internalname);
               AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
               A431PageJsonContent = cgiGet( edtPageJsonContent_Internalname);
               AssignAttri("", false, "A431PageJsonContent", A431PageJsonContent);
               A432PageGJSHtml = cgiGet( edtPageGJSHtml_Internalname);
               AssignAttri("", false, "A432PageGJSHtml", A432PageGJSHtml);
               A433PageGJSJson = cgiGet( edtPageGJSJson_Internalname);
               AssignAttri("", false, "A433PageGJSJson", A433PageGJSJson);
               cmbPageIsContentPage.CurrentValue = cgiGet( cmbPageIsContentPage_Internalname);
               A439PageIsContentPage = StringUtil.StrToBool( cgiGet( cmbPageIsContentPage_Internalname));
               AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Page");
               forbiddenHiddens.Add("PageIsPublished", StringUtil.BoolToStr( A434PageIsPublished));
               forbiddenHiddens.Add("ProductServiceId", A58ProductServiceId.ToString());
               forbiddenHiddens.Add("OrganisationId", A11OrganisationId.ToString());
               forbiddenHiddens.Add("LocationId", A29LocationId.ToString());
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A310Trn_PageId != Z310Trn_PageId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_page:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A310Trn_PageId = StringUtil.StrToGuid( GetPar( "Trn_PageId"));
                  AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
                  getEqualNoModal( ) ;
                  if ( IsIns( )  && (Guid.Empty==A310Trn_PageId) && ( Gx_BScreen == 0 ) )
                  {
                     A310Trn_PageId = Guid.NewGuid( );
                     AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons_dsp( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  getEqualNoModal( ) ;
                  standaloneModal( ) ;
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11172 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12172 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12172 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1789( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtntrn_enter_Visible = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1789( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption170( )
      {
      }

      protected void E11172( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E12172( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1789( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z318Trn_PageName = T00173_A318Trn_PageName[0];
               Z434PageIsPublished = T00173_A434PageIsPublished[0];
               Z439PageIsContentPage = T00173_A439PageIsContentPage[0];
               Z11OrganisationId = T00173_A11OrganisationId[0];
               Z29LocationId = T00173_A29LocationId[0];
               Z58ProductServiceId = T00173_A58ProductServiceId[0];
            }
            else
            {
               Z318Trn_PageName = A318Trn_PageName;
               Z434PageIsPublished = A434PageIsPublished;
               Z439PageIsContentPage = A439PageIsContentPage;
               Z11OrganisationId = A11OrganisationId;
               Z29LocationId = A29LocationId;
               Z58ProductServiceId = A58ProductServiceId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z310Trn_PageId = A310Trn_PageId;
            Z318Trn_PageName = A318Trn_PageName;
            Z431PageJsonContent = A431PageJsonContent;
            Z432PageGJSHtml = A432PageGJSHtml;
            Z433PageGJSJson = A433PageGJSJson;
            Z434PageIsPublished = A434PageIsPublished;
            Z439PageIsContentPage = A439PageIsContentPage;
            Z437PageChildren = A437PageChildren;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            Z58ProductServiceId = A58ProductServiceId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A439PageIsContentPage) && ( Gx_BScreen == 0 ) )
         {
            A439PageIsContentPage = false;
            AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
         }
         if ( IsIns( )  && (false==A434PageIsPublished) && ( Gx_BScreen == 0 ) )
         {
            A434PageIsPublished = false;
            AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
         }
         if ( IsIns( )  && (Guid.Empty==A310Trn_PageId) && ( Gx_BScreen == 0 ) )
         {
            A310Trn_PageId = Guid.NewGuid( );
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
         }
         /* Using cursor T00174 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor T00175 */
         pr_default.execute(3, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_delete_Enabled = 1;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1789( )
      {
         /* Using cursor T00176 */
         pr_default.execute(4, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound89 = 1;
            A318Trn_PageName = T00176_A318Trn_PageName[0];
            AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
            A431PageJsonContent = T00176_A431PageJsonContent[0];
            AssignAttri("", false, "A431PageJsonContent", A431PageJsonContent);
            A432PageGJSHtml = T00176_A432PageGJSHtml[0];
            AssignAttri("", false, "A432PageGJSHtml", A432PageGJSHtml);
            A433PageGJSJson = T00176_A433PageGJSJson[0];
            AssignAttri("", false, "A433PageGJSJson", A433PageGJSJson);
            A434PageIsPublished = T00176_A434PageIsPublished[0];
            A439PageIsContentPage = T00176_A439PageIsContentPage[0];
            AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
            A437PageChildren = T00176_A437PageChildren[0];
            n437PageChildren = T00176_n437PageChildren[0];
            A11OrganisationId = T00176_A11OrganisationId[0];
            A29LocationId = T00176_A29LocationId[0];
            A58ProductServiceId = T00176_A58ProductServiceId[0];
            n58ProductServiceId = T00176_n58ProductServiceId[0];
            ZM1789( -6) ;
         }
         pr_default.close(4);
         OnLoadActions1789( ) ;
      }

      protected void OnLoadActions1789( )
      {
      }

      protected void CheckExtendedTable1789( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00177 */
         pr_default.execute(5, new Object[] {A318Trn_PageName, A310Trn_PageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Page Name", "")}), 1, "TRN_PAGENAME");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A318Trn_PageName)) )
         {
            GX_msglist.addItem(context.GetMessage( "Page name cannot be empty.", ""), 1, "TRN_PAGENAME");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1789( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1789( )
      {
         /* Using cursor T00178 */
         pr_default.execute(6, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound89 = 1;
         }
         else
         {
            RcdFound89 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00173 */
         pr_default.execute(1, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1789( 6) ;
            RcdFound89 = 1;
            A310Trn_PageId = T00173_A310Trn_PageId[0];
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
            A318Trn_PageName = T00173_A318Trn_PageName[0];
            AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
            A431PageJsonContent = T00173_A431PageJsonContent[0];
            AssignAttri("", false, "A431PageJsonContent", A431PageJsonContent);
            A432PageGJSHtml = T00173_A432PageGJSHtml[0];
            AssignAttri("", false, "A432PageGJSHtml", A432PageGJSHtml);
            A433PageGJSJson = T00173_A433PageGJSJson[0];
            AssignAttri("", false, "A433PageGJSJson", A433PageGJSJson);
            A434PageIsPublished = T00173_A434PageIsPublished[0];
            A439PageIsContentPage = T00173_A439PageIsContentPage[0];
            AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
            A437PageChildren = T00173_A437PageChildren[0];
            n437PageChildren = T00173_n437PageChildren[0];
            A11OrganisationId = T00173_A11OrganisationId[0];
            A29LocationId = T00173_A29LocationId[0];
            A58ProductServiceId = T00173_A58ProductServiceId[0];
            n58ProductServiceId = T00173_n58ProductServiceId[0];
            Z310Trn_PageId = A310Trn_PageId;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1789( ) ;
            if ( AnyError == 1 )
            {
               RcdFound89 = 0;
               InitializeNonKey1789( ) ;
            }
            Gx_mode = sMode89;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound89 = 0;
            InitializeNonKey1789( ) ;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode89;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1789( ) ;
         if ( RcdFound89 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound89 = 0;
         /* Using cursor T00179 */
         pr_default.execute(7, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00179_A310Trn_PageId[0], A310Trn_PageId, 0) < 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00179_A310Trn_PageId[0], A310Trn_PageId, 0) > 0 ) ) )
            {
               A310Trn_PageId = T00179_A310Trn_PageId[0];
               AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
               RcdFound89 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound89 = 0;
         /* Using cursor T001710 */
         pr_default.execute(8, new Object[] {A310Trn_PageId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001710_A310Trn_PageId[0], A310Trn_PageId, 0) > 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001710_A310Trn_PageId[0], A310Trn_PageId, 0) < 0 ) ) )
            {
               A310Trn_PageId = T001710_A310Trn_PageId[0];
               AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
               RcdFound89 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1789( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrn_PageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1789( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound89 == 1 )
            {
               if ( A310Trn_PageId != Z310Trn_PageId )
               {
                  A310Trn_PageId = Z310Trn_PageId;
                  AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRN_PAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_PageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrn_PageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1789( ) ;
                  GX_FocusControl = edtTrn_PageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A310Trn_PageId != Z310Trn_PageId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTrn_PageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1789( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_PAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_PageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTrn_PageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1789( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A310Trn_PageId != Z310Trn_PageId )
         {
            A310Trn_PageId = Z310Trn_PageId;
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRN_PAGEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrn_PageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRN_PAGEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTrn_PageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1789( ) ;
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrn_PageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1789( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrn_PageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrn_PageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1789( ) ;
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound89 != 0 )
            {
               ScanNext1789( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrn_PageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1789( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1789( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00172 */
            pr_default.execute(0, new Object[] {A310Trn_PageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Page"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z318Trn_PageName, T00172_A318Trn_PageName[0]) != 0 ) || ( Z434PageIsPublished != T00172_A434PageIsPublished[0] ) || ( Z439PageIsContentPage != T00172_A439PageIsContentPage[0] ) || ( Z11OrganisationId != T00172_A11OrganisationId[0] ) || ( Z29LocationId != T00172_A29LocationId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z58ProductServiceId != T00172_A58ProductServiceId[0] ) )
            {
               if ( StringUtil.StrCmp(Z318Trn_PageName, T00172_A318Trn_PageName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_page:[seudo value changed for attri]"+"Trn_PageName");
                  GXUtil.WriteLogRaw("Old: ",Z318Trn_PageName);
                  GXUtil.WriteLogRaw("Current: ",T00172_A318Trn_PageName[0]);
               }
               if ( Z434PageIsPublished != T00172_A434PageIsPublished[0] )
               {
                  GXUtil.WriteLog("trn_page:[seudo value changed for attri]"+"PageIsPublished");
                  GXUtil.WriteLogRaw("Old: ",Z434PageIsPublished);
                  GXUtil.WriteLogRaw("Current: ",T00172_A434PageIsPublished[0]);
               }
               if ( Z439PageIsContentPage != T00172_A439PageIsContentPage[0] )
               {
                  GXUtil.WriteLog("trn_page:[seudo value changed for attri]"+"PageIsContentPage");
                  GXUtil.WriteLogRaw("Old: ",Z439PageIsContentPage);
                  GXUtil.WriteLogRaw("Current: ",T00172_A439PageIsContentPage[0]);
               }
               if ( Z11OrganisationId != T00172_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_page:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T00172_A11OrganisationId[0]);
               }
               if ( Z29LocationId != T00172_A29LocationId[0] )
               {
                  GXUtil.WriteLog("trn_page:[seudo value changed for attri]"+"LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z29LocationId);
                  GXUtil.WriteLogRaw("Current: ",T00172_A29LocationId[0]);
               }
               if ( Z58ProductServiceId != T00172_A58ProductServiceId[0] )
               {
                  GXUtil.WriteLog("trn_page:[seudo value changed for attri]"+"ProductServiceId");
                  GXUtil.WriteLogRaw("Old: ",Z58ProductServiceId);
                  GXUtil.WriteLogRaw("Current: ",T00172_A58ProductServiceId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Page"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1789( )
      {
         if ( ! IsAuthorized("trn_page_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1789( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1789( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1789( 0) ;
            CheckOptimisticConcurrency1789( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1789( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1789( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001711 */
                     pr_default.execute(9, new Object[] {A310Trn_PageId, A318Trn_PageName, A431PageJsonContent, A432PageGJSHtml, A433PageGJSJson, A434PageIsPublished, A439PageIsContentPage, n437PageChildren, A437PageChildren, A11OrganisationId, A29LocationId, n58ProductServiceId, A58ProductServiceId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
                     if ( (pr_default.getStatus(9) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption170( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1789( ) ;
            }
            EndLevel1789( ) ;
         }
         CloseExtendedTableCursors1789( ) ;
      }

      protected void Update1789( )
      {
         if ( ! IsAuthorized("trn_page_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1789( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1789( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1789( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1789( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1789( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001712 */
                     pr_default.execute(10, new Object[] {A318Trn_PageName, A431PageJsonContent, A432PageGJSHtml, A433PageGJSJson, A434PageIsPublished, A439PageIsContentPage, n437PageChildren, A437PageChildren, A11OrganisationId, A29LocationId, n58ProductServiceId, A58ProductServiceId, A310Trn_PageId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Page"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1789( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption170( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1789( ) ;
         }
         CloseExtendedTableCursors1789( ) ;
      }

      protected void DeferredUpdate1789( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_page_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1789( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1789( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1789( ) ;
            AfterConfirm1789( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1789( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001713 */
                  pr_default.execute(11, new Object[] {A310Trn_PageId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound89 == 0 )
                        {
                           InitAll1789( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption170( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode89 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1789( ) ;
         Gx_mode = sMode89;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1789( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1789( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1789( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_page",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues170( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_page",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1789( )
      {
         /* Scan By routine */
         /* Using cursor T001714 */
         pr_default.execute(12);
         RcdFound89 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound89 = 1;
            A310Trn_PageId = T001714_A310Trn_PageId[0];
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1789( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound89 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound89 = 1;
            A310Trn_PageId = T001714_A310Trn_PageId[0];
            AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
         }
      }

      protected void ScanEnd1789( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1789( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1789( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1789( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1789( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1789( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1789( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1789( )
      {
         edtTrn_PageId_Enabled = 0;
         AssignProp("", false, edtTrn_PageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageId_Enabled), 5, 0), true);
         edtTrn_PageName_Enabled = 0;
         AssignProp("", false, edtTrn_PageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_PageName_Enabled), 5, 0), true);
         edtPageJsonContent_Enabled = 0;
         AssignProp("", false, edtPageJsonContent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageJsonContent_Enabled), 5, 0), true);
         edtPageGJSHtml_Enabled = 0;
         AssignProp("", false, edtPageGJSHtml_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageGJSHtml_Enabled), 5, 0), true);
         edtPageGJSJson_Enabled = 0;
         AssignProp("", false, edtPageGJSJson_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageGJSJson_Enabled), 5, 0), true);
         cmbPageIsContentPage.Enabled = 0;
         AssignProp("", false, cmbPageIsContentPage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPageIsContentPage.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1789( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues170( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         MasterPageObj.master_styles();
         CloseStyles();
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_page.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Page");
         forbiddenHiddens.Add("PageIsPublished", StringUtil.BoolToStr( A434PageIsPublished));
         forbiddenHiddens.Add("ProductServiceId", A58ProductServiceId.ToString());
         forbiddenHiddens.Add("OrganisationId", A11OrganisationId.ToString());
         forbiddenHiddens.Add("LocationId", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_page:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z310Trn_PageId", Z310Trn_PageId.ToString());
         GxWebStd.gx_hidden_field( context, "Z318Trn_PageName", Z318Trn_PageName);
         GxWebStd.gx_boolean_hidden_field( context, "Z434PageIsPublished", Z434PageIsPublished);
         GxWebStd.gx_boolean_hidden_field( context, "Z439PageIsContentPage", Z439PageIsContentPage);
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z58ProductServiceId", Z58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "PAGEISPUBLISHED", A434PageIsPublished);
         GxWebStd.gx_hidden_field( context, "PAGECHILDREN", A437PageChildren);
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEID", A58ProductServiceId.ToString());
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("trn_page.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Page" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Page", "") ;
      }

      protected void InitializeNonKey1789( )
      {
         A318Trn_PageName = "";
         AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
         A431PageJsonContent = "";
         AssignAttri("", false, "A431PageJsonContent", A431PageJsonContent);
         A432PageGJSHtml = "";
         AssignAttri("", false, "A432PageGJSHtml", A432PageGJSHtml);
         A433PageGJSJson = "";
         AssignAttri("", false, "A433PageGJSJson", A433PageGJSJson);
         A437PageChildren = "";
         n437PageChildren = false;
         AssignAttri("", false, "A437PageChildren", A437PageChildren);
         A58ProductServiceId = Guid.Empty;
         n58ProductServiceId = false;
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A434PageIsPublished = false;
         AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
         A439PageIsContentPage = false;
         AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
         Z318Trn_PageName = "";
         Z434PageIsPublished = false;
         Z439PageIsContentPage = false;
         Z11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
      }

      protected void InitAll1789( )
      {
         A310Trn_PageId = Guid.NewGuid( );
         AssignAttri("", false, "A310Trn_PageId", A310Trn_PageId.ToString());
         InitializeNonKey1789( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A439PageIsContentPage = i439PageIsContentPage;
         AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
         A434PageIsPublished = i434PageIsPublished;
         AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411156371952", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("trn_page.js", "?202411156371952", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTrn_PageId_Internalname = "TRN_PAGEID";
         edtTrn_PageName_Internalname = "TRN_PAGENAME";
         edtPageJsonContent_Internalname = "PAGEJSONCONTENT";
         edtPageGJSHtml_Internalname = "PAGEGJSHTML";
         edtPageGJSJson_Internalname = "PAGEGJSJSON";
         cmbPageIsContentPage_Internalname = "PAGEISCONTENTPAGE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_Page", "");
         bttBtntrn_delete_Enabled = 1;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbPageIsContentPage_Jsonclick = "";
         cmbPageIsContentPage.Enabled = 1;
         edtPageGJSJson_Enabled = 1;
         edtPageGJSHtml_Enabled = 1;
         edtPageJsonContent_Enabled = 1;
         edtTrn_PageName_Jsonclick = "";
         edtTrn_PageName_Enabled = 1;
         edtTrn_PageId_Jsonclick = "";
         edtTrn_PageId_Enabled = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         cmbPageIsContentPage.Name = "PAGEISCONTENTPAGE";
         cmbPageIsContentPage.WebTags = "";
         cmbPageIsContentPage.addItem(StringUtil.BoolToStr( true), context.GetMessage( "true", ""), 0);
         cmbPageIsContentPage.addItem(StringUtil.BoolToStr( false), context.GetMessage( "false", ""), 0);
         if ( cmbPageIsContentPage.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A439PageIsContentPage) )
            {
               A439PageIsContentPage = false;
               AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
            }
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTrn_PageName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Trn_pageid( )
      {
         n58ProductServiceId = false;
         A439PageIsContentPage = StringUtil.StrToBool( cmbPageIsContentPage.CurrentValue);
         cmbPageIsContentPage.CurrentValue = StringUtil.BoolToStr( A439PageIsContentPage);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbPageIsContentPage.ItemCount > 0 )
         {
            A439PageIsContentPage = StringUtil.StrToBool( cmbPageIsContentPage.getValidValue(StringUtil.BoolToStr( A439PageIsContentPage)));
            cmbPageIsContentPage.CurrentValue = StringUtil.BoolToStr( A439PageIsContentPage);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPageIsContentPage.CurrentValue = StringUtil.BoolToStr( A439PageIsContentPage);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A318Trn_PageName", A318Trn_PageName);
         AssignAttri("", false, "A431PageJsonContent", A431PageJsonContent);
         AssignAttri("", false, "A432PageGJSHtml", A432PageGJSHtml);
         AssignAttri("", false, "A433PageGJSJson", A433PageGJSJson);
         AssignAttri("", false, "A434PageIsPublished", A434PageIsPublished);
         AssignAttri("", false, "A439PageIsContentPage", A439PageIsContentPage);
         cmbPageIsContentPage.CurrentValue = StringUtil.BoolToStr( A439PageIsContentPage);
         AssignProp("", false, cmbPageIsContentPage_Internalname, "Values", cmbPageIsContentPage.ToJavascriptSource(), true);
         AssignAttri("", false, "A437PageChildren", A437PageChildren);
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z310Trn_PageId", Z310Trn_PageId.ToString());
         GxWebStd.gx_hidden_field( context, "Z318Trn_PageName", Z318Trn_PageName);
         GxWebStd.gx_hidden_field( context, "Z431PageJsonContent", Z431PageJsonContent);
         GxWebStd.gx_hidden_field( context, "Z432PageGJSHtml", Z432PageGJSHtml);
         GxWebStd.gx_hidden_field( context, "Z433PageGJSJson", Z433PageGJSJson);
         GxWebStd.gx_hidden_field( context, "Z434PageIsPublished", StringUtil.BoolToStr( Z434PageIsPublished));
         GxWebStd.gx_hidden_field( context, "Z439PageIsContentPage", StringUtil.BoolToStr( Z439PageIsContentPage));
         GxWebStd.gx_hidden_field( context, "Z437PageChildren", Z437PageChildren);
         GxWebStd.gx_hidden_field( context, "Z58ProductServiceId", Z58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Trn_pagename( )
      {
         /* Using cursor T001715 */
         pr_default.execute(13, new Object[] {A318Trn_PageName, A310Trn_PageId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Page Name", "")}), 1, "TRN_PAGENAME");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageName_Internalname;
         }
         pr_default.close(13);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A318Trn_PageName)) )
         {
            GX_msglist.addItem(context.GetMessage( "Page name cannot be empty.", ""), 1, "TRN_PAGENAME");
            AnyError = 1;
            GX_FocusControl = edtTrn_PageName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12172","iparms":[]}""");
         setEventMetadata("VALID_TRN_PAGEID","""{"handler":"Valid_Trn_pageid","iparms":[{"av":"A310Trn_PageId","fld":"TRN_PAGEID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"cmbPageIsContentPage"},{"av":"A439PageIsContentPage","fld":"PAGEISCONTENTPAGE"},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"}]""");
         setEventMetadata("VALID_TRN_PAGEID",""","oparms":[{"av":"A318Trn_PageName","fld":"TRN_PAGENAME"},{"av":"A431PageJsonContent","fld":"PAGEJSONCONTENT"},{"av":"A432PageGJSHtml","fld":"PAGEGJSHTML"},{"av":"A433PageGJSJson","fld":"PAGEGJSJSON"},{"av":"A434PageIsPublished","fld":"PAGEISPUBLISHED"},{"av":"cmbPageIsContentPage"},{"av":"A439PageIsContentPage","fld":"PAGEISCONTENTPAGE"},{"av":"A437PageChildren","fld":"PAGECHILDREN"},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z310Trn_PageId"},{"av":"Z318Trn_PageName"},{"av":"Z431PageJsonContent"},{"av":"Z432PageGJSHtml"},{"av":"Z433PageGJSJson"},{"av":"Z434PageIsPublished"},{"av":"Z439PageIsContentPage"},{"av":"Z437PageChildren"},{"av":"Z58ProductServiceId"},{"av":"Z11OrganisationId"},{"av":"Z29LocationId"},{"ctrl":"BTNTRN_DELETE","prop":"Enabled"},{"ctrl":"BTNTRN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_TRN_PAGENAME","""{"handler":"Valid_Trn_pagename","iparms":[{"av":"A318Trn_PageName","fld":"TRN_PAGENAME"},{"av":"A310Trn_PageId","fld":"TRN_PAGEID"}]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z310Trn_PageId = Guid.Empty;
         Z318Trn_PageName = "";
         Z11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         A431PageJsonContent = "";
         A432PageGJSHtml = "";
         A433PageGJSJson = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A58ProductServiceId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Gx_mode = "";
         A437PageChildren = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z431PageJsonContent = "";
         Z432PageGJSHtml = "";
         Z433PageGJSJson = "";
         Z437PageChildren = "";
         T00174_A29LocationId = new Guid[] {Guid.Empty} ;
         T00175_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00175_n58ProductServiceId = new bool[] {false} ;
         T00176_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T00176_A318Trn_PageName = new string[] {""} ;
         T00176_A431PageJsonContent = new string[] {""} ;
         T00176_A432PageGJSHtml = new string[] {""} ;
         T00176_A433PageGJSJson = new string[] {""} ;
         T00176_A434PageIsPublished = new bool[] {false} ;
         T00176_A439PageIsContentPage = new bool[] {false} ;
         T00176_A437PageChildren = new string[] {""} ;
         T00176_n437PageChildren = new bool[] {false} ;
         T00176_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00176_A29LocationId = new Guid[] {Guid.Empty} ;
         T00176_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00176_n58ProductServiceId = new bool[] {false} ;
         T00177_A318Trn_PageName = new string[] {""} ;
         T00178_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T00173_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T00173_A318Trn_PageName = new string[] {""} ;
         T00173_A431PageJsonContent = new string[] {""} ;
         T00173_A432PageGJSHtml = new string[] {""} ;
         T00173_A433PageGJSJson = new string[] {""} ;
         T00173_A434PageIsPublished = new bool[] {false} ;
         T00173_A439PageIsContentPage = new bool[] {false} ;
         T00173_A437PageChildren = new string[] {""} ;
         T00173_n437PageChildren = new bool[] {false} ;
         T00173_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00173_A29LocationId = new Guid[] {Guid.Empty} ;
         T00173_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00173_n58ProductServiceId = new bool[] {false} ;
         sMode89 = "";
         T00179_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T001710_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T00172_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         T00172_A318Trn_PageName = new string[] {""} ;
         T00172_A431PageJsonContent = new string[] {""} ;
         T00172_A432PageGJSHtml = new string[] {""} ;
         T00172_A433PageGJSJson = new string[] {""} ;
         T00172_A434PageIsPublished = new bool[] {false} ;
         T00172_A439PageIsContentPage = new bool[] {false} ;
         T00172_A437PageChildren = new string[] {""} ;
         T00172_n437PageChildren = new bool[] {false} ;
         T00172_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T00172_A29LocationId = new Guid[] {Guid.Empty} ;
         T00172_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T00172_n58ProductServiceId = new bool[] {false} ;
         T001714_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ310Trn_PageId = Guid.Empty;
         ZZ318Trn_PageName = "";
         ZZ431PageJsonContent = "";
         ZZ432PageGJSHtml = "";
         ZZ433PageGJSJson = "";
         ZZ437PageChildren = "";
         ZZ58ProductServiceId = Guid.Empty;
         ZZ11OrganisationId = Guid.Empty;
         ZZ29LocationId = Guid.Empty;
         T001715_A318Trn_PageName = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_page__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_page__default(),
            new Object[][] {
                new Object[] {
               T00172_A310Trn_PageId, T00172_A318Trn_PageName, T00172_A431PageJsonContent, T00172_A432PageGJSHtml, T00172_A433PageGJSJson, T00172_A434PageIsPublished, T00172_A439PageIsContentPage, T00172_A437PageChildren, T00172_n437PageChildren, T00172_A11OrganisationId,
               T00172_A29LocationId, T00172_A58ProductServiceId, T00172_n58ProductServiceId
               }
               , new Object[] {
               T00173_A310Trn_PageId, T00173_A318Trn_PageName, T00173_A431PageJsonContent, T00173_A432PageGJSHtml, T00173_A433PageGJSJson, T00173_A434PageIsPublished, T00173_A439PageIsContentPage, T00173_A437PageChildren, T00173_n437PageChildren, T00173_A11OrganisationId,
               T00173_A29LocationId, T00173_A58ProductServiceId, T00173_n58ProductServiceId
               }
               , new Object[] {
               T00174_A29LocationId
               }
               , new Object[] {
               T00175_A58ProductServiceId
               }
               , new Object[] {
               T00176_A310Trn_PageId, T00176_A318Trn_PageName, T00176_A431PageJsonContent, T00176_A432PageGJSHtml, T00176_A433PageGJSJson, T00176_A434PageIsPublished, T00176_A439PageIsContentPage, T00176_A437PageChildren, T00176_n437PageChildren, T00176_A11OrganisationId,
               T00176_A29LocationId, T00176_A58ProductServiceId, T00176_n58ProductServiceId
               }
               , new Object[] {
               T00177_A318Trn_PageName
               }
               , new Object[] {
               T00178_A310Trn_PageId
               }
               , new Object[] {
               T00179_A310Trn_PageId
               }
               , new Object[] {
               T001710_A310Trn_PageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001714_A310Trn_PageId
               }
               , new Object[] {
               T001715_A318Trn_PageName
               }
            }
         );
         Z439PageIsContentPage = false;
         A439PageIsContentPage = false;
         i439PageIsContentPage = false;
         Z434PageIsPublished = false;
         A434PageIsPublished = false;
         i434PageIsPublished = false;
         Z310Trn_PageId = Guid.NewGuid( );
         A310Trn_PageId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound89 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtTrn_PageId_Enabled ;
      private int edtTrn_PageName_Enabled ;
      private int edtPageJsonContent_Enabled ;
      private int edtPageGJSHtml_Enabled ;
      private int edtPageGJSJson_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrn_PageId_Internalname ;
      private string cmbPageIsContentPage_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTrn_PageId_Jsonclick ;
      private string edtTrn_PageName_Internalname ;
      private string edtTrn_PageName_Jsonclick ;
      private string edtPageJsonContent_Internalname ;
      private string edtPageGJSHtml_Internalname ;
      private string edtPageGJSJson_Internalname ;
      private string cmbPageIsContentPage_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string Gx_mode ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode89 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z434PageIsPublished ;
      private bool Z439PageIsContentPage ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A439PageIsContentPage ;
      private bool n58ProductServiceId ;
      private bool A434PageIsPublished ;
      private bool n437PageChildren ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i439PageIsContentPage ;
      private bool i434PageIsPublished ;
      private bool ZZ434PageIsPublished ;
      private bool ZZ439PageIsContentPage ;
      private string A431PageJsonContent ;
      private string A432PageGJSHtml ;
      private string A433PageGJSJson ;
      private string A437PageChildren ;
      private string Z431PageJsonContent ;
      private string Z432PageGJSHtml ;
      private string Z433PageGJSJson ;
      private string Z437PageChildren ;
      private string ZZ431PageJsonContent ;
      private string ZZ432PageGJSHtml ;
      private string ZZ433PageGJSJson ;
      private string ZZ437PageChildren ;
      private string Z318Trn_PageName ;
      private string A318Trn_PageName ;
      private string ZZ318Trn_PageName ;
      private Guid Z310Trn_PageId ;
      private Guid Z11OrganisationId ;
      private Guid Z29LocationId ;
      private Guid Z58ProductServiceId ;
      private Guid A310Trn_PageId ;
      private Guid A58ProductServiceId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid ZZ310Trn_PageId ;
      private Guid ZZ58ProductServiceId ;
      private Guid ZZ11OrganisationId ;
      private Guid ZZ29LocationId ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPageIsContentPage ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00174_A29LocationId ;
      private Guid[] T00175_A58ProductServiceId ;
      private bool[] T00175_n58ProductServiceId ;
      private Guid[] T00176_A310Trn_PageId ;
      private string[] T00176_A318Trn_PageName ;
      private string[] T00176_A431PageJsonContent ;
      private string[] T00176_A432PageGJSHtml ;
      private string[] T00176_A433PageGJSJson ;
      private bool[] T00176_A434PageIsPublished ;
      private bool[] T00176_A439PageIsContentPage ;
      private string[] T00176_A437PageChildren ;
      private bool[] T00176_n437PageChildren ;
      private Guid[] T00176_A11OrganisationId ;
      private Guid[] T00176_A29LocationId ;
      private Guid[] T00176_A58ProductServiceId ;
      private bool[] T00176_n58ProductServiceId ;
      private string[] T00177_A318Trn_PageName ;
      private Guid[] T00178_A310Trn_PageId ;
      private Guid[] T00173_A310Trn_PageId ;
      private string[] T00173_A318Trn_PageName ;
      private string[] T00173_A431PageJsonContent ;
      private string[] T00173_A432PageGJSHtml ;
      private string[] T00173_A433PageGJSJson ;
      private bool[] T00173_A434PageIsPublished ;
      private bool[] T00173_A439PageIsContentPage ;
      private string[] T00173_A437PageChildren ;
      private bool[] T00173_n437PageChildren ;
      private Guid[] T00173_A11OrganisationId ;
      private Guid[] T00173_A29LocationId ;
      private Guid[] T00173_A58ProductServiceId ;
      private bool[] T00173_n58ProductServiceId ;
      private Guid[] T00179_A310Trn_PageId ;
      private Guid[] T001710_A310Trn_PageId ;
      private Guid[] T00172_A310Trn_PageId ;
      private string[] T00172_A318Trn_PageName ;
      private string[] T00172_A431PageJsonContent ;
      private string[] T00172_A432PageGJSHtml ;
      private string[] T00172_A433PageGJSJson ;
      private bool[] T00172_A434PageIsPublished ;
      private bool[] T00172_A439PageIsContentPage ;
      private string[] T00172_A437PageChildren ;
      private bool[] T00172_n437PageChildren ;
      private Guid[] T00172_A11OrganisationId ;
      private Guid[] T00172_A29LocationId ;
      private Guid[] T00172_A58ProductServiceId ;
      private bool[] T00172_n58ProductServiceId ;
      private Guid[] T001714_A310Trn_PageId ;
      private string[] T001715_A318Trn_PageName ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_page__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_page__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00172;
        prmT00172 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00173;
        prmT00173 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00174;
        prmT00174 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00175;
        prmT00175 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00176;
        prmT00176 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00177;
        prmT00177 = new Object[] {
        new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00178;
        prmT00178 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00179;
        prmT00179 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001710;
        prmT001710 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001711;
        prmT001711 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
        new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageIsPublished",GXType.Boolean,4,0) ,
        new ParDef("PageIsContentPage",GXType.Boolean,4,0) ,
        new ParDef("PageChildren",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT001712;
        prmT001712 = new Object[] {
        new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
        new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0) ,
        new ParDef("PageIsPublished",GXType.Boolean,4,0) ,
        new ParDef("PageIsContentPage",GXType.Boolean,4,0) ,
        new ParDef("PageChildren",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001713;
        prmT001713 = new Object[] {
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001714;
        prmT001714 = new Object[] {
        };
        Object[] prmT001715;
        prmT001715 = new Object[] {
        new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
        new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00172", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsContentPage, PageChildren, OrganisationId, LocationId, ProductServiceId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId  FOR UPDATE OF Trn_Page NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00172,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00173", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsContentPage, PageChildren, OrganisationId, LocationId, ProductServiceId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00173,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00174", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00174,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00175", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00175,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00176", "SELECT TM1.Trn_PageId, TM1.Trn_PageName, TM1.PageJsonContent, TM1.PageGJSHtml, TM1.PageGJSJson, TM1.PageIsPublished, TM1.PageIsContentPage, TM1.PageChildren, TM1.OrganisationId, TM1.LocationId, TM1.ProductServiceId FROM Trn_Page TM1 WHERE TM1.Trn_PageId = :Trn_PageId ORDER BY TM1.Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00176,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00177", "SELECT Trn_PageName FROM Trn_Page WHERE (Trn_PageName = :Trn_PageName) AND (Not ( Trn_PageId = :Trn_PageId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00177,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00178", "SELECT Trn_PageId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00178,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00179", "SELECT Trn_PageId FROM Trn_Page WHERE ( Trn_PageId > :Trn_PageId) ORDER BY Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00179,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001710", "SELECT Trn_PageId FROM Trn_Page WHERE ( Trn_PageId < :Trn_PageId) ORDER BY Trn_PageId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001710,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001711", "SAVEPOINT gxupdate;INSERT INTO Trn_Page(Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsContentPage, PageChildren, OrganisationId, LocationId, ProductServiceId) VALUES(:Trn_PageId, :Trn_PageName, :PageJsonContent, :PageGJSHtml, :PageGJSJson, :PageIsPublished, :PageIsContentPage, :PageChildren, :OrganisationId, :LocationId, :ProductServiceId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001711)
           ,new CursorDef("T001712", "SAVEPOINT gxupdate;UPDATE Trn_Page SET Trn_PageName=:Trn_PageName, PageJsonContent=:PageJsonContent, PageGJSHtml=:PageGJSHtml, PageGJSJson=:PageGJSJson, PageIsPublished=:PageIsPublished, PageIsContentPage=:PageIsContentPage, PageChildren=:PageChildren, OrganisationId=:OrganisationId, LocationId=:LocationId, ProductServiceId=:ProductServiceId  WHERE Trn_PageId = :Trn_PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001712)
           ,new CursorDef("T001713", "SAVEPOINT gxupdate;DELETE FROM Trn_Page  WHERE Trn_PageId = :Trn_PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001713)
           ,new CursorDef("T001714", "SELECT Trn_PageId FROM Trn_Page ORDER BY Trn_PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001714,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001715", "SELECT Trn_PageName FROM Trn_Page WHERE (Trn_PageName = :Trn_PageName) AND (Not ( Trn_PageId = :Trn_PageId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001715,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((Guid[]) buf[9])[0] = rslt.getGuid(9);
              ((Guid[]) buf[10])[0] = rslt.getGuid(10);
              ((Guid[]) buf[11])[0] = rslt.getGuid(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((Guid[]) buf[9])[0] = rslt.getGuid(9);
              ((Guid[]) buf[10])[0] = rslt.getGuid(10);
              ((Guid[]) buf[11])[0] = rslt.getGuid(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((Guid[]) buf[9])[0] = rslt.getGuid(9);
              ((Guid[]) buf[10])[0] = rslt.getGuid(10);
              ((Guid[]) buf[11])[0] = rslt.getGuid(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
