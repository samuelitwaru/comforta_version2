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
   public class trn_supplieragb : GXDataArea
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
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A283SupplierAgbTypeId = StringUtil.StrToGuid( GetPar( "SupplierAgbTypeId"));
            AssignAttri("", false, "A283SupplierAgbTypeId", A283SupplierAgbTypeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A283SupplierAgbTypeId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_supplieragb.aspx")), "trn_supplieragb.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_supplieragb.aspx")))) ;
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
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7SupplierAgbId = StringUtil.StrToGuid( GetPar( "SupplierAgbId"));
                  AssignAttri("", false, "AV7SupplierAgbId", AV7SupplierAgbId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERAGBID", GetSecureSignedToken( "", AV7SupplierAgbId, context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
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
         Form.Meta.addItem("description", "Agb Suppliers", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSupplierAgbNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_supplieragb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_supplieragb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_SupplierAgbId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SupplierAgbId = aP1_SupplierAgbId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
            return "trn_supplieragb_Execute" ;
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbNumber_Internalname, "AGB Number", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbNumber_Internalname, A50SupplierAgbNumber, StringUtil.RTrim( context.localUtil.Format( A50SupplierAgbNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbNumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "AgbNumber", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsupplieragbtypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksupplieragbtypeid_Internalname, "Supplier Category", "", "", lblTextblocksupplieragbtypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_supplieragbtypeid.SetProperty("Caption", Combo_supplieragbtypeid_Caption);
         ucCombo_supplieragbtypeid.SetProperty("Cls", Combo_supplieragbtypeid_Cls);
         ucCombo_supplieragbtypeid.SetProperty("EmptyItem", Combo_supplieragbtypeid_Emptyitem);
         ucCombo_supplieragbtypeid.SetProperty("DropDownOptionsData", AV15SupplierAgbTypeId_Data);
         ucCombo_supplieragbtypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplieragbtypeid_Internalname, "COMBO_SUPPLIERAGBTYPEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbTypeId_Internalname, "Supplier Agb Type Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbTypeId_Internalname, A283SupplierAgbTypeId.ToString(), A283SupplierAgbTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierAgbTypeId_Visible, edtSupplierAgbTypeId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbName_Internalname, "Supplier Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbName_Internalname, A51SupplierAgbName, StringUtil.RTrim( context.localUtil.Format( A51SupplierAgbName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbKvkNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbKvkNumber_Internalname, "KVK Number", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbKvkNumber_Internalname, A52SupplierAgbKvkNumber, StringUtil.RTrim( context.localUtil.Format( A52SupplierAgbKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbKvkNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbKvkNumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbContactName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbContactName_Internalname, "Contact Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbContactName_Internalname, A55SupplierAgbContactName, StringUtil.RTrim( context.localUtil.Format( A55SupplierAgbContactName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbContactName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbContactName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbPhone_Internalname, "Contact Phone", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A56SupplierAgbPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbPhone_Internalname, StringUtil.RTrim( A56SupplierAgbPhone), StringUtil.RTrim( context.localUtil.Format( A56SupplierAgbPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtSupplierAgbPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbEmail_Internalname, "Email", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbEmail_Internalname, A57SupplierAgbEmail, StringUtil.RTrim( context.localUtil.Format( A57SupplierAgbEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A57SupplierAgbEmail, "", "", "", edtSupplierAgbEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsupplieragbaddresscountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksupplieragbaddresscountry_Internalname, "Country", "", "", lblTextblocksupplieragbaddresscountry_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_supplieragbaddresscountry.SetProperty("Caption", Combo_supplieragbaddresscountry_Caption);
         ucCombo_supplieragbaddresscountry.SetProperty("Cls", Combo_supplieragbaddresscountry_Cls);
         ucCombo_supplieragbaddresscountry.SetProperty("EmptyItem", Combo_supplieragbaddresscountry_Emptyitem);
         ucCombo_supplieragbaddresscountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_supplieragbaddresscountry.SetProperty("DropDownOptionsData", AV23SupplierAGBAddressCountry_Data);
         ucCombo_supplieragbaddresscountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_supplieragbaddresscountry_Internalname, "COMBO_SUPPLIERAGBADDRESSCOUNTRYContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAGBAddressCountry_Internalname, "Supplier AGBAddress Country", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAGBAddressCountry_Internalname, A332SupplierAGBAddressCountry, StringUtil.RTrim( context.localUtil.Format( A332SupplierAGBAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAGBAddressCountry_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierAGBAddressCountry_Visible, edtSupplierAGBAddressCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbAddressCity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbAddressCity_Internalname, "City", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbAddressCity_Internalname, A299SupplierAgbAddressCity, StringUtil.RTrim( context.localUtil.Format( A299SupplierAgbAddressCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbAddressCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbAddressCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbAddressZipCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbAddressZipCode_Internalname, "Zip Code", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbAddressZipCode_Internalname, A298SupplierAgbAddressZipCode, StringUtil.RTrim( context.localUtil.Format( A298SupplierAgbAddressZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbAddressZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbAddressZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbAddressLine1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbAddressLine1_Internalname, "Address Line 1", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbAddressLine1_Internalname, A333SupplierAgbAddressLine1, StringUtil.RTrim( context.localUtil.Format( A333SupplierAgbAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAgbAddressLine2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAgbAddressLine2_Internalname, "Address Line 2", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbAddressLine2_Internalname, A334SupplierAgbAddressLine2, StringUtil.RTrim( context.localUtil.Format( A334SupplierAgbAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierAgbAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierAgb.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_supplieragbtypeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosupplieragbtypeid_Internalname, AV20ComboSupplierAgbTypeId.ToString(), AV20ComboSupplierAgbTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosupplieragbtypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosupplieragbtypeid_Visible, edtavCombosupplieragbtypeid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_supplieragbaddresscountry_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosupplieragbaddresscountry_Internalname, AV24ComboSupplierAGBAddressCountry, StringUtil.RTrim( context.localUtil.Format( AV24ComboSupplierAGBAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosupplieragbaddresscountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosupplieragbaddresscountry_Visible, edtavCombosupplieragbaddresscountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierAgb.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierAgbId_Internalname, A49SupplierAgbId.ToString(), A49SupplierAgbId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierAgbId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierAgbId_Visible, edtSupplierAgbId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierAgb.htm");
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
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERAGBTYPEID_DATA"), AV15SupplierAgbTypeId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERAGBADDRESSCOUNTRY_DATA"), AV23SupplierAGBAddressCountry_Data);
               /* Read saved values. */
               Z49SupplierAgbId = StringUtil.StrToGuid( cgiGet( "Z49SupplierAgbId"));
               Z332SupplierAGBAddressCountry = cgiGet( "Z332SupplierAGBAddressCountry");
               Z50SupplierAgbNumber = cgiGet( "Z50SupplierAgbNumber");
               Z51SupplierAgbName = cgiGet( "Z51SupplierAgbName");
               Z52SupplierAgbKvkNumber = cgiGet( "Z52SupplierAgbKvkNumber");
               Z299SupplierAgbAddressCity = cgiGet( "Z299SupplierAgbAddressCity");
               Z298SupplierAgbAddressZipCode = cgiGet( "Z298SupplierAgbAddressZipCode");
               Z333SupplierAgbAddressLine1 = cgiGet( "Z333SupplierAgbAddressLine1");
               Z334SupplierAgbAddressLine2 = cgiGet( "Z334SupplierAgbAddressLine2");
               Z55SupplierAgbContactName = cgiGet( "Z55SupplierAgbContactName");
               Z56SupplierAgbPhone = cgiGet( "Z56SupplierAgbPhone");
               Z57SupplierAgbEmail = cgiGet( "Z57SupplierAgbEmail");
               Z283SupplierAgbTypeId = StringUtil.StrToGuid( cgiGet( "Z283SupplierAgbTypeId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N283SupplierAgbTypeId = StringUtil.StrToGuid( cgiGet( "N283SupplierAgbTypeId"));
               AV7SupplierAgbId = StringUtil.StrToGuid( cgiGet( "vSUPPLIERAGBID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_SupplierAgbTypeId = StringUtil.StrToGuid( cgiGet( "vINSERT_SUPPLIERAGBTYPEID"));
               AV25Pgmname = cgiGet( "vPGMNAME");
               Combo_supplieragbtypeid_Objectcall = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Objectcall");
               Combo_supplieragbtypeid_Class = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Class");
               Combo_supplieragbtypeid_Icontype = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Icontype");
               Combo_supplieragbtypeid_Icon = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Icon");
               Combo_supplieragbtypeid_Caption = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Caption");
               Combo_supplieragbtypeid_Tooltip = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Tooltip");
               Combo_supplieragbtypeid_Cls = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Cls");
               Combo_supplieragbtypeid_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Selectedvalue_set");
               Combo_supplieragbtypeid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Selectedvalue_get");
               Combo_supplieragbtypeid_Selectedtext_set = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Selectedtext_set");
               Combo_supplieragbtypeid_Selectedtext_get = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Selectedtext_get");
               Combo_supplieragbtypeid_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Gamoauthtoken");
               Combo_supplieragbtypeid_Ddointernalname = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Ddointernalname");
               Combo_supplieragbtypeid_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Titlecontrolalign");
               Combo_supplieragbtypeid_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Dropdownoptionstype");
               Combo_supplieragbtypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBTYPEID_Enabled"));
               Combo_supplieragbtypeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBTYPEID_Visible"));
               Combo_supplieragbtypeid_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Titlecontrolidtoreplace");
               Combo_supplieragbtypeid_Datalisttype = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Datalisttype");
               Combo_supplieragbtypeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBTYPEID_Allowmultipleselection"));
               Combo_supplieragbtypeid_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Datalistfixedvalues");
               Combo_supplieragbtypeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBTYPEID_Isgriditem"));
               Combo_supplieragbtypeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBTYPEID_Hasdescription"));
               Combo_supplieragbtypeid_Datalistproc = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Datalistproc");
               Combo_supplieragbtypeid_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Datalistprocparametersprefix");
               Combo_supplieragbtypeid_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Remoteservicesparameters");
               Combo_supplieragbtypeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERAGBTYPEID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_supplieragbtypeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBTYPEID_Includeonlyselectedoption"));
               Combo_supplieragbtypeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBTYPEID_Includeselectalloption"));
               Combo_supplieragbtypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBTYPEID_Emptyitem"));
               Combo_supplieragbtypeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBTYPEID_Includeaddnewoption"));
               Combo_supplieragbtypeid_Htmltemplate = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Htmltemplate");
               Combo_supplieragbtypeid_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Multiplevaluestype");
               Combo_supplieragbtypeid_Loadingdata = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Loadingdata");
               Combo_supplieragbtypeid_Noresultsfound = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Noresultsfound");
               Combo_supplieragbtypeid_Emptyitemtext = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Emptyitemtext");
               Combo_supplieragbtypeid_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Onlyselectedvalues");
               Combo_supplieragbtypeid_Selectalltext = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Selectalltext");
               Combo_supplieragbtypeid_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Multiplevaluesseparator");
               Combo_supplieragbtypeid_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERAGBTYPEID_Addnewoptiontext");
               Combo_supplieragbtypeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERAGBTYPEID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_supplieragbaddresscountry_Objectcall = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Objectcall");
               Combo_supplieragbaddresscountry_Class = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Class");
               Combo_supplieragbaddresscountry_Icontype = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Icontype");
               Combo_supplieragbaddresscountry_Icon = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Icon");
               Combo_supplieragbaddresscountry_Caption = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Caption");
               Combo_supplieragbaddresscountry_Tooltip = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Tooltip");
               Combo_supplieragbaddresscountry_Cls = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Cls");
               Combo_supplieragbaddresscountry_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Selectedvalue_set");
               Combo_supplieragbaddresscountry_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Selectedvalue_get");
               Combo_supplieragbaddresscountry_Selectedtext_set = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Selectedtext_set");
               Combo_supplieragbaddresscountry_Selectedtext_get = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Selectedtext_get");
               Combo_supplieragbaddresscountry_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Gamoauthtoken");
               Combo_supplieragbaddresscountry_Ddointernalname = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Ddointernalname");
               Combo_supplieragbaddresscountry_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Titlecontrolalign");
               Combo_supplieragbaddresscountry_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Dropdownoptionstype");
               Combo_supplieragbaddresscountry_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Enabled"));
               Combo_supplieragbaddresscountry_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Visible"));
               Combo_supplieragbaddresscountry_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Titlecontrolidtoreplace");
               Combo_supplieragbaddresscountry_Datalisttype = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Datalisttype");
               Combo_supplieragbaddresscountry_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Allowmultipleselection"));
               Combo_supplieragbaddresscountry_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Datalistfixedvalues");
               Combo_supplieragbaddresscountry_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Isgriditem"));
               Combo_supplieragbaddresscountry_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Hasdescription"));
               Combo_supplieragbaddresscountry_Datalistproc = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Datalistproc");
               Combo_supplieragbaddresscountry_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Datalistprocparametersprefix");
               Combo_supplieragbaddresscountry_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Remoteservicesparameters");
               Combo_supplieragbaddresscountry_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_supplieragbaddresscountry_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Includeonlyselectedoption"));
               Combo_supplieragbaddresscountry_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Includeselectalloption"));
               Combo_supplieragbaddresscountry_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Emptyitem"));
               Combo_supplieragbaddresscountry_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Includeaddnewoption"));
               Combo_supplieragbaddresscountry_Htmltemplate = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Htmltemplate");
               Combo_supplieragbaddresscountry_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Multiplevaluestype");
               Combo_supplieragbaddresscountry_Loadingdata = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Loadingdata");
               Combo_supplieragbaddresscountry_Noresultsfound = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Noresultsfound");
               Combo_supplieragbaddresscountry_Emptyitemtext = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Emptyitemtext");
               Combo_supplieragbaddresscountry_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Onlyselectedvalues");
               Combo_supplieragbaddresscountry_Selectalltext = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Selectalltext");
               Combo_supplieragbaddresscountry_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Multiplevaluesseparator");
               Combo_supplieragbaddresscountry_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Addnewoptiontext");
               Combo_supplieragbaddresscountry_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A50SupplierAgbNumber = cgiGet( edtSupplierAgbNumber_Internalname);
               AssignAttri("", false, "A50SupplierAgbNumber", A50SupplierAgbNumber);
               if ( StringUtil.StrCmp(cgiGet( edtSupplierAgbTypeId_Internalname), "") == 0 )
               {
                  A283SupplierAgbTypeId = Guid.Empty;
                  AssignAttri("", false, "A283SupplierAgbTypeId", A283SupplierAgbTypeId.ToString());
               }
               else
               {
                  try
                  {
                     A283SupplierAgbTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbTypeId_Internalname));
                     AssignAttri("", false, "A283SupplierAgbTypeId", A283SupplierAgbTypeId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERAGBTYPEID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierAgbTypeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A51SupplierAgbName = cgiGet( edtSupplierAgbName_Internalname);
               AssignAttri("", false, "A51SupplierAgbName", A51SupplierAgbName);
               A52SupplierAgbKvkNumber = cgiGet( edtSupplierAgbKvkNumber_Internalname);
               AssignAttri("", false, "A52SupplierAgbKvkNumber", A52SupplierAgbKvkNumber);
               A55SupplierAgbContactName = cgiGet( edtSupplierAgbContactName_Internalname);
               AssignAttri("", false, "A55SupplierAgbContactName", A55SupplierAgbContactName);
               A56SupplierAgbPhone = cgiGet( edtSupplierAgbPhone_Internalname);
               AssignAttri("", false, "A56SupplierAgbPhone", A56SupplierAgbPhone);
               A57SupplierAgbEmail = cgiGet( edtSupplierAgbEmail_Internalname);
               AssignAttri("", false, "A57SupplierAgbEmail", A57SupplierAgbEmail);
               A332SupplierAGBAddressCountry = cgiGet( edtSupplierAGBAddressCountry_Internalname);
               AssignAttri("", false, "A332SupplierAGBAddressCountry", A332SupplierAGBAddressCountry);
               A299SupplierAgbAddressCity = cgiGet( edtSupplierAgbAddressCity_Internalname);
               AssignAttri("", false, "A299SupplierAgbAddressCity", A299SupplierAgbAddressCity);
               A298SupplierAgbAddressZipCode = cgiGet( edtSupplierAgbAddressZipCode_Internalname);
               AssignAttri("", false, "A298SupplierAgbAddressZipCode", A298SupplierAgbAddressZipCode);
               A333SupplierAgbAddressLine1 = cgiGet( edtSupplierAgbAddressLine1_Internalname);
               AssignAttri("", false, "A333SupplierAgbAddressLine1", A333SupplierAgbAddressLine1);
               A334SupplierAgbAddressLine2 = cgiGet( edtSupplierAgbAddressLine2_Internalname);
               AssignAttri("", false, "A334SupplierAgbAddressLine2", A334SupplierAgbAddressLine2);
               AV20ComboSupplierAgbTypeId = StringUtil.StrToGuid( cgiGet( edtavCombosupplieragbtypeid_Internalname));
               AssignAttri("", false, "AV20ComboSupplierAgbTypeId", AV20ComboSupplierAgbTypeId.ToString());
               AV24ComboSupplierAGBAddressCountry = cgiGet( edtavCombosupplieragbaddresscountry_Internalname);
               AssignAttri("", false, "AV24ComboSupplierAGBAddressCountry", AV24ComboSupplierAGBAddressCountry);
               if ( StringUtil.StrCmp(cgiGet( edtSupplierAgbId_Internalname), "") == 0 )
               {
                  A49SupplierAgbId = Guid.Empty;
                  n49SupplierAgbId = false;
                  AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
               }
               else
               {
                  try
                  {
                     A49SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbId_Internalname));
                     n49SupplierAgbId = false;
                     AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERAGBID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierAgbId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_SupplierAgb");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A49SupplierAgbId != Z49SupplierAgbId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_supplieragb:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A49SupplierAgbId = StringUtil.StrToGuid( GetPar( "SupplierAgbId"));
                  n49SupplierAgbId = false;
                  AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7SupplierAgbId) )
                  {
                     A49SupplierAgbId = AV7SupplierAgbId;
                     n49SupplierAgbId = false;
                     AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A49SupplierAgbId) && ( Gx_BScreen == 0 ) )
                     {
                        A49SupplierAgbId = Guid.NewGuid( );
                        n49SupplierAgbId = false;
                        AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode11 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7SupplierAgbId) )
                     {
                        A49SupplierAgbId = AV7SupplierAgbId;
                        n49SupplierAgbId = false;
                        AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A49SupplierAgbId) && ( Gx_BScreen == 0 ) )
                        {
                           A49SupplierAgbId = Guid.NewGuid( );
                           n49SupplierAgbId = false;
                           AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
                        }
                     }
                     Gx_mode = sMode11;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound11 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SUPPLIERAGBID");
                        AnyError = 1;
                        GX_FocusControl = edtSupplierAgbId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERAGBTYPEID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_supplieragbtypeid.Onoptionclicked */
                           E12072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            E13072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0711( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0711( ) ;
         }
         AssignProp("", false, edtavCombosupplieragbtypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbtypeid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosupplieragbaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbaddresscountry_Enabled), 5, 0), true);
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

      protected void CONFIRM_070( )
      {
         BeforeValidate0711( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0711( ) ;
            }
            else
            {
               CheckExtendedTable0711( ) ;
               CloseExtendedTableCursors0711( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtSupplierAGBAddressCountry_Visible = 0;
         AssignProp("", false, edtSupplierAGBAddressCountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAGBAddressCountry_Visible), 5, 0), true);
         AV24ComboSupplierAGBAddressCountry = "";
         AssignAttri("", false, "AV24ComboSupplierAGBAddressCountry", AV24ComboSupplierAGBAddressCountry);
         edtavCombosupplieragbaddresscountry_Visible = 0;
         AssignProp("", false, edtavCombosupplieragbaddresscountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbaddresscountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_supplieragbaddresscountry_Htmltemplate = GXt_char2;
         ucCombo_supplieragbaddresscountry.SendProperty(context, "", false, Combo_supplieragbaddresscountry_Internalname, "HTMLTemplate", Combo_supplieragbaddresscountry_Htmltemplate);
         edtSupplierAgbTypeId_Visible = 0;
         AssignProp("", false, edtSupplierAgbTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbTypeId_Visible), 5, 0), true);
         AV20ComboSupplierAgbTypeId = Guid.Empty;
         AssignAttri("", false, "AV20ComboSupplierAgbTypeId", AV20ComboSupplierAgbTypeId.ToString());
         edtavCombosupplieragbtypeid_Visible = 0;
         AssignProp("", false, edtavCombosupplieragbtypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbtypeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBTYPEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERAGBADDRESSCOUNTRY' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            while ( AV26GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SupplierAgbTypeId") == 0 )
               {
                  AV13Insert_SupplierAgbTypeId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_SupplierAgbTypeId", AV13Insert_SupplierAgbTypeId.ToString());
                  if ( ! (Guid.Empty==AV13Insert_SupplierAgbTypeId) )
                  {
                     AV20ComboSupplierAgbTypeId = AV13Insert_SupplierAgbTypeId;
                     AssignAttri("", false, "AV20ComboSupplierAgbTypeId", AV20ComboSupplierAgbTypeId.ToString());
                     Combo_supplieragbtypeid_Selectedvalue_set = StringUtil.Trim( AV20ComboSupplierAgbTypeId.ToString());
                     ucCombo_supplieragbtypeid.SendProperty(context, "", false, Combo_supplieragbtypeid_Internalname, "SelectedValue_set", Combo_supplieragbtypeid_Selectedvalue_set);
                     Combo_supplieragbtypeid_Enabled = false;
                     ucCombo_supplieragbtypeid.SendProperty(context, "", false, Combo_supplieragbtypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_supplieragbtypeid_Enabled));
                  }
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
         edtSupplierAgbId_Visible = 0;
         AssignProp("", false, edtSupplierAgbId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            Combo_supplieragbaddresscountry_Selectedvalue_set = "Netherlands";
            ucCombo_supplieragbaddresscountry.SendProperty(context, "", false, Combo_supplieragbaddresscountry_Internalname, "SelectedValue_set", Combo_supplieragbaddresscountry_Selectedvalue_set);
            Combo_supplieragbaddresscountry_Selectedtext_set = "Netherlands";
            ucCombo_supplieragbaddresscountry.SendProperty(context, "", false, Combo_supplieragbaddresscountry_Internalname, "SelectedText_set", Combo_supplieragbaddresscountry_Selectedtext_set);
         }
      }

      protected void E13072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_supplieragbww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E12072( )
      {
         /* Combo_supplieragbtypeid_Onoptionclicked Routine */
         returnInSub = false;
         AV20ComboSupplierAgbTypeId = StringUtil.StrToGuid( Combo_supplieragbtypeid_Selectedvalue_get);
         AssignAttri("", false, "AV20ComboSupplierAgbTypeId", AV20ComboSupplierAgbTypeId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERAGBADDRESSCOUNTRY' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV23SupplierAGBAddressCountry_Data;
         new trn_supplieragbloaddvcombo(context ).execute(  "SupplierAGBAddressCountry",  Gx_mode,  AV7SupplierAgbId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV23SupplierAGBAddressCountry_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
         Combo_supplieragbaddresscountry_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_supplieragbaddresscountry.SendProperty(context, "", false, Combo_supplieragbaddresscountry_Internalname, "SelectedValue_set", Combo_supplieragbaddresscountry_Selectedvalue_set);
         AV24ComboSupplierAGBAddressCountry = AV17ComboSelectedValue;
         AssignAttri("", false, "AV24ComboSupplierAGBAddressCountry", AV24ComboSupplierAGBAddressCountry);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_supplieragbaddresscountry_Enabled = false;
            ucCombo_supplieragbaddresscountry.SendProperty(context, "", false, Combo_supplieragbaddresscountry_Internalname, "Enabled", StringUtil.BoolToStr( Combo_supplieragbaddresscountry_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOSUPPLIERAGBTYPEID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV15SupplierAgbTypeId_Data;
         new trn_supplieragbloaddvcombo(context ).execute(  "SupplierAgbTypeId",  Gx_mode,  AV7SupplierAgbId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV15SupplierAgbTypeId_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
         Combo_supplieragbtypeid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_supplieragbtypeid.SendProperty(context, "", false, Combo_supplieragbtypeid_Internalname, "SelectedValue_set", Combo_supplieragbtypeid_Selectedvalue_set);
         AV20ComboSupplierAgbTypeId = StringUtil.StrToGuid( AV17ComboSelectedValue);
         AssignAttri("", false, "AV20ComboSupplierAgbTypeId", AV20ComboSupplierAgbTypeId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_supplieragbtypeid_Enabled = false;
            ucCombo_supplieragbtypeid.SendProperty(context, "", false, Combo_supplieragbtypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_supplieragbtypeid_Enabled));
         }
      }

      protected void ZM0711( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z332SupplierAGBAddressCountry = T00073_A332SupplierAGBAddressCountry[0];
               Z50SupplierAgbNumber = T00073_A50SupplierAgbNumber[0];
               Z51SupplierAgbName = T00073_A51SupplierAgbName[0];
               Z52SupplierAgbKvkNumber = T00073_A52SupplierAgbKvkNumber[0];
               Z299SupplierAgbAddressCity = T00073_A299SupplierAgbAddressCity[0];
               Z298SupplierAgbAddressZipCode = T00073_A298SupplierAgbAddressZipCode[0];
               Z333SupplierAgbAddressLine1 = T00073_A333SupplierAgbAddressLine1[0];
               Z334SupplierAgbAddressLine2 = T00073_A334SupplierAgbAddressLine2[0];
               Z55SupplierAgbContactName = T00073_A55SupplierAgbContactName[0];
               Z56SupplierAgbPhone = T00073_A56SupplierAgbPhone[0];
               Z57SupplierAgbEmail = T00073_A57SupplierAgbEmail[0];
               Z283SupplierAgbTypeId = T00073_A283SupplierAgbTypeId[0];
            }
            else
            {
               Z332SupplierAGBAddressCountry = A332SupplierAGBAddressCountry;
               Z50SupplierAgbNumber = A50SupplierAgbNumber;
               Z51SupplierAgbName = A51SupplierAgbName;
               Z52SupplierAgbKvkNumber = A52SupplierAgbKvkNumber;
               Z299SupplierAgbAddressCity = A299SupplierAgbAddressCity;
               Z298SupplierAgbAddressZipCode = A298SupplierAgbAddressZipCode;
               Z333SupplierAgbAddressLine1 = A333SupplierAgbAddressLine1;
               Z334SupplierAgbAddressLine2 = A334SupplierAgbAddressLine2;
               Z55SupplierAgbContactName = A55SupplierAgbContactName;
               Z56SupplierAgbPhone = A56SupplierAgbPhone;
               Z57SupplierAgbEmail = A57SupplierAgbEmail;
               Z283SupplierAgbTypeId = A283SupplierAgbTypeId;
            }
         }
         if ( GX_JID == -16 )
         {
            Z49SupplierAgbId = A49SupplierAgbId;
            Z332SupplierAGBAddressCountry = A332SupplierAGBAddressCountry;
            Z50SupplierAgbNumber = A50SupplierAgbNumber;
            Z51SupplierAgbName = A51SupplierAgbName;
            Z52SupplierAgbKvkNumber = A52SupplierAgbKvkNumber;
            Z299SupplierAgbAddressCity = A299SupplierAgbAddressCity;
            Z298SupplierAgbAddressZipCode = A298SupplierAgbAddressZipCode;
            Z333SupplierAgbAddressLine1 = A333SupplierAgbAddressLine1;
            Z334SupplierAgbAddressLine2 = A334SupplierAgbAddressLine2;
            Z55SupplierAgbContactName = A55SupplierAgbContactName;
            Z56SupplierAgbPhone = A56SupplierAgbPhone;
            Z57SupplierAgbEmail = A57SupplierAgbEmail;
            Z283SupplierAgbTypeId = A283SupplierAgbTypeId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV25Pgmname = "Trn_SupplierAgb";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7SupplierAgbId) )
         {
            edtSupplierAgbId_Enabled = 0;
            AssignProp("", false, edtSupplierAgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierAgbId_Enabled = 1;
            AssignProp("", false, edtSupplierAgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7SupplierAgbId) )
         {
            edtSupplierAgbId_Enabled = 0;
            AssignProp("", false, edtSupplierAgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_SupplierAgbTypeId) )
         {
            edtSupplierAgbTypeId_Enabled = 0;
            AssignProp("", false, edtSupplierAgbTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbTypeId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierAgbTypeId_Enabled = 1;
            AssignProp("", false, edtSupplierAgbTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbTypeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_SupplierAgbTypeId) )
         {
            A283SupplierAgbTypeId = AV13Insert_SupplierAgbTypeId;
            AssignAttri("", false, "A283SupplierAgbTypeId", A283SupplierAgbTypeId.ToString());
         }
         else
         {
            A283SupplierAgbTypeId = AV20ComboSupplierAgbTypeId;
            AssignAttri("", false, "A283SupplierAgbTypeId", A283SupplierAgbTypeId.ToString());
         }
         A332SupplierAGBAddressCountry = AV24ComboSupplierAGBAddressCountry;
         AssignAttri("", false, "A332SupplierAGBAddressCountry", A332SupplierAGBAddressCountry);
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
         if ( ! (Guid.Empty==AV7SupplierAgbId) )
         {
            A49SupplierAgbId = AV7SupplierAgbId;
            n49SupplierAgbId = false;
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A49SupplierAgbId) && ( Gx_BScreen == 0 ) )
            {
               A49SupplierAgbId = Guid.NewGuid( );
               n49SupplierAgbId = false;
               AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0711( )
      {
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound11 = 1;
            A332SupplierAGBAddressCountry = T00075_A332SupplierAGBAddressCountry[0];
            AssignAttri("", false, "A332SupplierAGBAddressCountry", A332SupplierAGBAddressCountry);
            A50SupplierAgbNumber = T00075_A50SupplierAgbNumber[0];
            AssignAttri("", false, "A50SupplierAgbNumber", A50SupplierAgbNumber);
            A51SupplierAgbName = T00075_A51SupplierAgbName[0];
            AssignAttri("", false, "A51SupplierAgbName", A51SupplierAgbName);
            A52SupplierAgbKvkNumber = T00075_A52SupplierAgbKvkNumber[0];
            AssignAttri("", false, "A52SupplierAgbKvkNumber", A52SupplierAgbKvkNumber);
            A299SupplierAgbAddressCity = T00075_A299SupplierAgbAddressCity[0];
            AssignAttri("", false, "A299SupplierAgbAddressCity", A299SupplierAgbAddressCity);
            A298SupplierAgbAddressZipCode = T00075_A298SupplierAgbAddressZipCode[0];
            AssignAttri("", false, "A298SupplierAgbAddressZipCode", A298SupplierAgbAddressZipCode);
            A333SupplierAgbAddressLine1 = T00075_A333SupplierAgbAddressLine1[0];
            AssignAttri("", false, "A333SupplierAgbAddressLine1", A333SupplierAgbAddressLine1);
            A334SupplierAgbAddressLine2 = T00075_A334SupplierAgbAddressLine2[0];
            AssignAttri("", false, "A334SupplierAgbAddressLine2", A334SupplierAgbAddressLine2);
            A55SupplierAgbContactName = T00075_A55SupplierAgbContactName[0];
            AssignAttri("", false, "A55SupplierAgbContactName", A55SupplierAgbContactName);
            A56SupplierAgbPhone = T00075_A56SupplierAgbPhone[0];
            AssignAttri("", false, "A56SupplierAgbPhone", A56SupplierAgbPhone);
            A57SupplierAgbEmail = T00075_A57SupplierAgbEmail[0];
            AssignAttri("", false, "A57SupplierAgbEmail", A57SupplierAgbEmail);
            A283SupplierAgbTypeId = T00075_A283SupplierAgbTypeId[0];
            AssignAttri("", false, "A283SupplierAgbTypeId", A283SupplierAgbTypeId.ToString());
            ZM0711( -16) ;
         }
         pr_default.close(3);
         OnLoadActions0711( ) ;
      }

      protected void OnLoadActions0711( )
      {
      }

      protected void CheckExtendedTable0711( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A50SupplierAgbNumber)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Supplier Agb Number", "", "", "", "", "", "", "", ""), 1, "SUPPLIERAGBNUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierAgbNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A283SupplierAgbTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_SupplierAgbType'.", "ForeignKeyNotFound", 1, "SUPPLIERAGBTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierAgbTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( (Guid.Empty==A283SupplierAgbTypeId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Supplier Agb Type Id", "", "", "", "", "", "", "", ""), 1, "SUPPLIERAGBTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierAgbTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A51SupplierAgbName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Supplier Agb Name", "", "", "", "", "", "", "", ""), 1, "SUPPLIERAGBNAME");
            AnyError = 1;
            GX_FocusControl = edtSupplierAgbName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A57SupplierAgbEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Supplier Agb Email does not match the specified pattern", "OutOfRange", 1, "SUPPLIERAGBEMAIL");
            AnyError = 1;
            GX_FocusControl = edtSupplierAgbEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0711( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( Guid A283SupplierAgbTypeId )
      {
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A283SupplierAgbTypeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_SupplierAgbType'.", "ForeignKeyNotFound", 1, "SUPPLIERAGBTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierAgbTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0711( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0711( 16) ;
            RcdFound11 = 1;
            A49SupplierAgbId = T00073_A49SupplierAgbId[0];
            n49SupplierAgbId = T00073_n49SupplierAgbId[0];
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
            A332SupplierAGBAddressCountry = T00073_A332SupplierAGBAddressCountry[0];
            AssignAttri("", false, "A332SupplierAGBAddressCountry", A332SupplierAGBAddressCountry);
            A50SupplierAgbNumber = T00073_A50SupplierAgbNumber[0];
            AssignAttri("", false, "A50SupplierAgbNumber", A50SupplierAgbNumber);
            A51SupplierAgbName = T00073_A51SupplierAgbName[0];
            AssignAttri("", false, "A51SupplierAgbName", A51SupplierAgbName);
            A52SupplierAgbKvkNumber = T00073_A52SupplierAgbKvkNumber[0];
            AssignAttri("", false, "A52SupplierAgbKvkNumber", A52SupplierAgbKvkNumber);
            A299SupplierAgbAddressCity = T00073_A299SupplierAgbAddressCity[0];
            AssignAttri("", false, "A299SupplierAgbAddressCity", A299SupplierAgbAddressCity);
            A298SupplierAgbAddressZipCode = T00073_A298SupplierAgbAddressZipCode[0];
            AssignAttri("", false, "A298SupplierAgbAddressZipCode", A298SupplierAgbAddressZipCode);
            A333SupplierAgbAddressLine1 = T00073_A333SupplierAgbAddressLine1[0];
            AssignAttri("", false, "A333SupplierAgbAddressLine1", A333SupplierAgbAddressLine1);
            A334SupplierAgbAddressLine2 = T00073_A334SupplierAgbAddressLine2[0];
            AssignAttri("", false, "A334SupplierAgbAddressLine2", A334SupplierAgbAddressLine2);
            A55SupplierAgbContactName = T00073_A55SupplierAgbContactName[0];
            AssignAttri("", false, "A55SupplierAgbContactName", A55SupplierAgbContactName);
            A56SupplierAgbPhone = T00073_A56SupplierAgbPhone[0];
            AssignAttri("", false, "A56SupplierAgbPhone", A56SupplierAgbPhone);
            A57SupplierAgbEmail = T00073_A57SupplierAgbEmail[0];
            AssignAttri("", false, "A57SupplierAgbEmail", A57SupplierAgbEmail);
            A283SupplierAgbTypeId = T00073_A283SupplierAgbTypeId[0];
            AssignAttri("", false, "A283SupplierAgbTypeId", A283SupplierAgbTypeId.ToString());
            Z49SupplierAgbId = A49SupplierAgbId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0711( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0711( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0711( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0711( ) ;
         if ( RcdFound11 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound11 = 0;
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00078_A49SupplierAgbId[0], A49SupplierAgbId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00078_A49SupplierAgbId[0], A49SupplierAgbId, 0) > 0 ) ) )
            {
               A49SupplierAgbId = T00078_A49SupplierAgbId[0];
               n49SupplierAgbId = T00078_n49SupplierAgbId[0];
               AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
               RcdFound11 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00079_A49SupplierAgbId[0], A49SupplierAgbId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00079_A49SupplierAgbId[0], A49SupplierAgbId, 0) < 0 ) ) )
            {
               A49SupplierAgbId = T00079_A49SupplierAgbId[0];
               n49SupplierAgbId = T00079_n49SupplierAgbId[0];
               AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
               RcdFound11 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0711( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSupplierAgbNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0711( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( A49SupplierAgbId != Z49SupplierAgbId )
               {
                  A49SupplierAgbId = Z49SupplierAgbId;
                  n49SupplierAgbId = false;
                  AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUPPLIERAGBID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierAgbId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupplierAgbNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0711( ) ;
                  GX_FocusControl = edtSupplierAgbNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A49SupplierAgbId != Z49SupplierAgbId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSupplierAgbNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0711( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUPPLIERAGBID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierAgbId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSupplierAgbNumber_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0711( ) ;
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
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A49SupplierAgbId != Z49SupplierAgbId )
         {
            A49SupplierAgbId = Z49SupplierAgbId;
            n49SupplierAgbId = false;
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUPPLIERAGBID");
            AnyError = 1;
            GX_FocusControl = edtSupplierAgbId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSupplierAgbNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0711( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierAGB"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z332SupplierAGBAddressCountry, T00072_A332SupplierAGBAddressCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z50SupplierAgbNumber, T00072_A50SupplierAgbNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z51SupplierAgbName, T00072_A51SupplierAgbName[0]) != 0 ) || ( StringUtil.StrCmp(Z52SupplierAgbKvkNumber, T00072_A52SupplierAgbKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z299SupplierAgbAddressCity, T00072_A299SupplierAgbAddressCity[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z298SupplierAgbAddressZipCode, T00072_A298SupplierAgbAddressZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z333SupplierAgbAddressLine1, T00072_A333SupplierAgbAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z334SupplierAgbAddressLine2, T00072_A334SupplierAgbAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z55SupplierAgbContactName, T00072_A55SupplierAgbContactName[0]) != 0 ) || ( StringUtil.StrCmp(Z56SupplierAgbPhone, T00072_A56SupplierAgbPhone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z57SupplierAgbEmail, T00072_A57SupplierAgbEmail[0]) != 0 ) || ( Z283SupplierAgbTypeId != T00072_A283SupplierAgbTypeId[0] ) )
            {
               if ( StringUtil.StrCmp(Z332SupplierAGBAddressCountry, T00072_A332SupplierAGBAddressCountry[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAGBAddressCountry");
                  GXUtil.WriteLogRaw("Old: ",Z332SupplierAGBAddressCountry);
                  GXUtil.WriteLogRaw("Current: ",T00072_A332SupplierAGBAddressCountry[0]);
               }
               if ( StringUtil.StrCmp(Z50SupplierAgbNumber, T00072_A50SupplierAgbNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAgbNumber");
                  GXUtil.WriteLogRaw("Old: ",Z50SupplierAgbNumber);
                  GXUtil.WriteLogRaw("Current: ",T00072_A50SupplierAgbNumber[0]);
               }
               if ( StringUtil.StrCmp(Z51SupplierAgbName, T00072_A51SupplierAgbName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAgbName");
                  GXUtil.WriteLogRaw("Old: ",Z51SupplierAgbName);
                  GXUtil.WriteLogRaw("Current: ",T00072_A51SupplierAgbName[0]);
               }
               if ( StringUtil.StrCmp(Z52SupplierAgbKvkNumber, T00072_A52SupplierAgbKvkNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAgbKvkNumber");
                  GXUtil.WriteLogRaw("Old: ",Z52SupplierAgbKvkNumber);
                  GXUtil.WriteLogRaw("Current: ",T00072_A52SupplierAgbKvkNumber[0]);
               }
               if ( StringUtil.StrCmp(Z299SupplierAgbAddressCity, T00072_A299SupplierAgbAddressCity[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAgbAddressCity");
                  GXUtil.WriteLogRaw("Old: ",Z299SupplierAgbAddressCity);
                  GXUtil.WriteLogRaw("Current: ",T00072_A299SupplierAgbAddressCity[0]);
               }
               if ( StringUtil.StrCmp(Z298SupplierAgbAddressZipCode, T00072_A298SupplierAgbAddressZipCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAgbAddressZipCode");
                  GXUtil.WriteLogRaw("Old: ",Z298SupplierAgbAddressZipCode);
                  GXUtil.WriteLogRaw("Current: ",T00072_A298SupplierAgbAddressZipCode[0]);
               }
               if ( StringUtil.StrCmp(Z333SupplierAgbAddressLine1, T00072_A333SupplierAgbAddressLine1[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAgbAddressLine1");
                  GXUtil.WriteLogRaw("Old: ",Z333SupplierAgbAddressLine1);
                  GXUtil.WriteLogRaw("Current: ",T00072_A333SupplierAgbAddressLine1[0]);
               }
               if ( StringUtil.StrCmp(Z334SupplierAgbAddressLine2, T00072_A334SupplierAgbAddressLine2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAgbAddressLine2");
                  GXUtil.WriteLogRaw("Old: ",Z334SupplierAgbAddressLine2);
                  GXUtil.WriteLogRaw("Current: ",T00072_A334SupplierAgbAddressLine2[0]);
               }
               if ( StringUtil.StrCmp(Z55SupplierAgbContactName, T00072_A55SupplierAgbContactName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAgbContactName");
                  GXUtil.WriteLogRaw("Old: ",Z55SupplierAgbContactName);
                  GXUtil.WriteLogRaw("Current: ",T00072_A55SupplierAgbContactName[0]);
               }
               if ( StringUtil.StrCmp(Z56SupplierAgbPhone, T00072_A56SupplierAgbPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAgbPhone");
                  GXUtil.WriteLogRaw("Old: ",Z56SupplierAgbPhone);
                  GXUtil.WriteLogRaw("Current: ",T00072_A56SupplierAgbPhone[0]);
               }
               if ( StringUtil.StrCmp(Z57SupplierAgbEmail, T00072_A57SupplierAgbEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAgbEmail");
                  GXUtil.WriteLogRaw("Old: ",Z57SupplierAgbEmail);
                  GXUtil.WriteLogRaw("Current: ",T00072_A57SupplierAgbEmail[0]);
               }
               if ( Z283SupplierAgbTypeId != T00072_A283SupplierAgbTypeId[0] )
               {
                  GXUtil.WriteLog("trn_supplieragb:[seudo value changed for attri]"+"SupplierAgbTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z283SupplierAgbTypeId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A283SupplierAgbTypeId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierAGB"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0711( )
      {
         if ( ! IsAuthorized("trn_supplieragb_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0711( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0711( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0711( 0) ;
            CheckOptimisticConcurrency0711( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0711( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0711( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000710 */
                     pr_default.execute(8, new Object[] {n49SupplierAgbId, A49SupplierAgbId, A332SupplierAGBAddressCountry, A50SupplierAgbNumber, A51SupplierAgbName, A52SupplierAgbKvkNumber, A299SupplierAgbAddressCity, A298SupplierAgbAddressZipCode, A333SupplierAgbAddressLine1, A334SupplierAgbAddressLine2, A55SupplierAgbContactName, A56SupplierAgbPhone, A57SupplierAgbEmail, A283SupplierAgbTypeId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAGB");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
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
               Load0711( ) ;
            }
            EndLevel0711( ) ;
         }
         CloseExtendedTableCursors0711( ) ;
      }

      protected void Update0711( )
      {
         if ( ! IsAuthorized("trn_supplieragb_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0711( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0711( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0711( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0711( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0711( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000711 */
                     pr_default.execute(9, new Object[] {A332SupplierAGBAddressCountry, A50SupplierAgbNumber, A51SupplierAgbName, A52SupplierAgbKvkNumber, A299SupplierAgbAddressCity, A298SupplierAgbAddressZipCode, A333SupplierAgbAddressLine1, A334SupplierAgbAddressLine2, A55SupplierAgbContactName, A56SupplierAgbPhone, A57SupplierAgbEmail, A283SupplierAgbTypeId, n49SupplierAgbId, A49SupplierAgbId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAGB");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierAGB"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0711( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
            EndLevel0711( ) ;
         }
         CloseExtendedTableCursors0711( ) ;
      }

      protected void DeferredUpdate0711( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_supplieragb_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0711( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0711( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0711( ) ;
            AfterConfirm0711( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0711( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000712 */
                  pr_default.execute(10, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAGB");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
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
         }
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0711( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0711( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000713 */
            pr_default.execute(11, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Trn_ProductService"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0711( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0711( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_supplieragb",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_supplieragb",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0711( )
      {
         /* Scan By routine */
         /* Using cursor T000714 */
         pr_default.execute(12);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound11 = 1;
            A49SupplierAgbId = T000714_A49SupplierAgbId[0];
            n49SupplierAgbId = T000714_n49SupplierAgbId[0];
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0711( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound11 = 1;
            A49SupplierAgbId = T000714_A49SupplierAgbId[0];
            n49SupplierAgbId = T000714_n49SupplierAgbId[0];
            AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
         }
      }

      protected void ScanEnd0711( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0711( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0711( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0711( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0711( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0711( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0711( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0711( )
      {
         edtSupplierAgbNumber_Enabled = 0;
         AssignProp("", false, edtSupplierAgbNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbNumber_Enabled), 5, 0), true);
         edtSupplierAgbTypeId_Enabled = 0;
         AssignProp("", false, edtSupplierAgbTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbTypeId_Enabled), 5, 0), true);
         edtSupplierAgbName_Enabled = 0;
         AssignProp("", false, edtSupplierAgbName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbName_Enabled), 5, 0), true);
         edtSupplierAgbKvkNumber_Enabled = 0;
         AssignProp("", false, edtSupplierAgbKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbKvkNumber_Enabled), 5, 0), true);
         edtSupplierAgbContactName_Enabled = 0;
         AssignProp("", false, edtSupplierAgbContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbContactName_Enabled), 5, 0), true);
         edtSupplierAgbPhone_Enabled = 0;
         AssignProp("", false, edtSupplierAgbPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbPhone_Enabled), 5, 0), true);
         edtSupplierAgbEmail_Enabled = 0;
         AssignProp("", false, edtSupplierAgbEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbEmail_Enabled), 5, 0), true);
         edtSupplierAGBAddressCountry_Enabled = 0;
         AssignProp("", false, edtSupplierAGBAddressCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAGBAddressCountry_Enabled), 5, 0), true);
         edtSupplierAgbAddressCity_Enabled = 0;
         AssignProp("", false, edtSupplierAgbAddressCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbAddressCity_Enabled), 5, 0), true);
         edtSupplierAgbAddressZipCode_Enabled = 0;
         AssignProp("", false, edtSupplierAgbAddressZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbAddressZipCode_Enabled), 5, 0), true);
         edtSupplierAgbAddressLine1_Enabled = 0;
         AssignProp("", false, edtSupplierAgbAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbAddressLine1_Enabled), 5, 0), true);
         edtSupplierAgbAddressLine2_Enabled = 0;
         AssignProp("", false, edtSupplierAgbAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbAddressLine2_Enabled), 5, 0), true);
         edtavCombosupplieragbtypeid_Enabled = 0;
         AssignProp("", false, edtavCombosupplieragbtypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbtypeid_Enabled), 5, 0), true);
         edtavCombosupplieragbaddresscountry_Enabled = 0;
         AssignProp("", false, edtavCombosupplieragbaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosupplieragbaddresscountry_Enabled), 5, 0), true);
         edtSupplierAgbId_Enabled = 0;
         AssignProp("", false, edtSupplierAgbId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAgbId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0711( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "trn_supplieragb.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7SupplierAgbId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_supplieragb.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_SupplierAgb");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_supplieragb:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z49SupplierAgbId", Z49SupplierAgbId.ToString());
         GxWebStd.gx_hidden_field( context, "Z332SupplierAGBAddressCountry", Z332SupplierAGBAddressCountry);
         GxWebStd.gx_hidden_field( context, "Z50SupplierAgbNumber", Z50SupplierAgbNumber);
         GxWebStd.gx_hidden_field( context, "Z51SupplierAgbName", Z51SupplierAgbName);
         GxWebStd.gx_hidden_field( context, "Z52SupplierAgbKvkNumber", Z52SupplierAgbKvkNumber);
         GxWebStd.gx_hidden_field( context, "Z299SupplierAgbAddressCity", Z299SupplierAgbAddressCity);
         GxWebStd.gx_hidden_field( context, "Z298SupplierAgbAddressZipCode", Z298SupplierAgbAddressZipCode);
         GxWebStd.gx_hidden_field( context, "Z333SupplierAgbAddressLine1", Z333SupplierAgbAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z334SupplierAgbAddressLine2", Z334SupplierAgbAddressLine2);
         GxWebStd.gx_hidden_field( context, "Z55SupplierAgbContactName", Z55SupplierAgbContactName);
         GxWebStd.gx_hidden_field( context, "Z56SupplierAgbPhone", StringUtil.RTrim( Z56SupplierAgbPhone));
         GxWebStd.gx_hidden_field( context, "Z57SupplierAgbEmail", Z57SupplierAgbEmail);
         GxWebStd.gx_hidden_field( context, "Z283SupplierAgbTypeId", Z283SupplierAgbTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N283SupplierAgbTypeId", A283SupplierAgbTypeId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERAGBTYPEID_DATA", AV15SupplierAgbTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERAGBTYPEID_DATA", AV15SupplierAgbTypeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERAGBADDRESSCOUNTRY_DATA", AV23SupplierAGBAddressCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERAGBADDRESSCOUNTRY_DATA", AV23SupplierAGBAddressCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vSUPPLIERAGBID", AV7SupplierAgbId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERAGBID", GetSecureSignedToken( "", AV7SupplierAgbId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERAGBTYPEID", AV13Insert_SupplierAgbTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBTYPEID_Objectcall", StringUtil.RTrim( Combo_supplieragbtypeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBTYPEID_Cls", StringUtil.RTrim( Combo_supplieragbtypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBTYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_supplieragbtypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBTYPEID_Enabled", StringUtil.BoolToStr( Combo_supplieragbtypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBTYPEID_Emptyitem", StringUtil.BoolToStr( Combo_supplieragbtypeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Objectcall", StringUtil.RTrim( Combo_supplieragbaddresscountry_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Cls", StringUtil.RTrim( Combo_supplieragbaddresscountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_supplieragbaddresscountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Selectedtext_set", StringUtil.RTrim( Combo_supplieragbaddresscountry_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_supplieragbaddresscountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_supplieragbaddresscountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERAGBADDRESSCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_supplieragbaddresscountry_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "trn_supplieragb.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7SupplierAgbId.ToString());
         return formatLink("trn_supplieragb.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_SupplierAgb" ;
      }

      public override string GetPgmdesc( )
      {
         return "Agb Suppliers" ;
      }

      protected void InitializeNonKey0711( )
      {
         A283SupplierAgbTypeId = Guid.Empty;
         AssignAttri("", false, "A283SupplierAgbTypeId", A283SupplierAgbTypeId.ToString());
         A332SupplierAGBAddressCountry = "";
         AssignAttri("", false, "A332SupplierAGBAddressCountry", A332SupplierAGBAddressCountry);
         A50SupplierAgbNumber = "";
         AssignAttri("", false, "A50SupplierAgbNumber", A50SupplierAgbNumber);
         A51SupplierAgbName = "";
         AssignAttri("", false, "A51SupplierAgbName", A51SupplierAgbName);
         A52SupplierAgbKvkNumber = "";
         AssignAttri("", false, "A52SupplierAgbKvkNumber", A52SupplierAgbKvkNumber);
         A299SupplierAgbAddressCity = "";
         AssignAttri("", false, "A299SupplierAgbAddressCity", A299SupplierAgbAddressCity);
         A298SupplierAgbAddressZipCode = "";
         AssignAttri("", false, "A298SupplierAgbAddressZipCode", A298SupplierAgbAddressZipCode);
         A333SupplierAgbAddressLine1 = "";
         AssignAttri("", false, "A333SupplierAgbAddressLine1", A333SupplierAgbAddressLine1);
         A334SupplierAgbAddressLine2 = "";
         AssignAttri("", false, "A334SupplierAgbAddressLine2", A334SupplierAgbAddressLine2);
         A55SupplierAgbContactName = "";
         AssignAttri("", false, "A55SupplierAgbContactName", A55SupplierAgbContactName);
         A56SupplierAgbPhone = "";
         AssignAttri("", false, "A56SupplierAgbPhone", A56SupplierAgbPhone);
         A57SupplierAgbEmail = "";
         AssignAttri("", false, "A57SupplierAgbEmail", A57SupplierAgbEmail);
         Z332SupplierAGBAddressCountry = "";
         Z50SupplierAgbNumber = "";
         Z51SupplierAgbName = "";
         Z52SupplierAgbKvkNumber = "";
         Z299SupplierAgbAddressCity = "";
         Z298SupplierAgbAddressZipCode = "";
         Z333SupplierAgbAddressLine1 = "";
         Z334SupplierAgbAddressLine2 = "";
         Z55SupplierAgbContactName = "";
         Z56SupplierAgbPhone = "";
         Z57SupplierAgbEmail = "";
         Z283SupplierAgbTypeId = Guid.Empty;
      }

      protected void InitAll0711( )
      {
         A49SupplierAgbId = Guid.NewGuid( );
         n49SupplierAgbId = false;
         AssignAttri("", false, "A49SupplierAgbId", A49SupplierAgbId.ToString());
         InitializeNonKey0711( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202492719463277", true, true);
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
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("trn_supplieragb.js", "?202492719463279", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSupplierAgbNumber_Internalname = "SUPPLIERAGBNUMBER";
         lblTextblocksupplieragbtypeid_Internalname = "TEXTBLOCKSUPPLIERAGBTYPEID";
         Combo_supplieragbtypeid_Internalname = "COMBO_SUPPLIERAGBTYPEID";
         edtSupplierAgbTypeId_Internalname = "SUPPLIERAGBTYPEID";
         divTablesplittedsupplieragbtypeid_Internalname = "TABLESPLITTEDSUPPLIERAGBTYPEID";
         edtSupplierAgbName_Internalname = "SUPPLIERAGBNAME";
         edtSupplierAgbKvkNumber_Internalname = "SUPPLIERAGBKVKNUMBER";
         edtSupplierAgbContactName_Internalname = "SUPPLIERAGBCONTACTNAME";
         edtSupplierAgbPhone_Internalname = "SUPPLIERAGBPHONE";
         edtSupplierAgbEmail_Internalname = "SUPPLIERAGBEMAIL";
         lblTextblocksupplieragbaddresscountry_Internalname = "TEXTBLOCKSUPPLIERAGBADDRESSCOUNTRY";
         Combo_supplieragbaddresscountry_Internalname = "COMBO_SUPPLIERAGBADDRESSCOUNTRY";
         edtSupplierAGBAddressCountry_Internalname = "SUPPLIERAGBADDRESSCOUNTRY";
         divTablesplittedsupplieragbaddresscountry_Internalname = "TABLESPLITTEDSUPPLIERAGBADDRESSCOUNTRY";
         edtSupplierAgbAddressCity_Internalname = "SUPPLIERAGBADDRESSCITY";
         edtSupplierAgbAddressZipCode_Internalname = "SUPPLIERAGBADDRESSZIPCODE";
         edtSupplierAgbAddressLine1_Internalname = "SUPPLIERAGBADDRESSLINE1";
         edtSupplierAgbAddressLine2_Internalname = "SUPPLIERAGBADDRESSLINE2";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombosupplieragbtypeid_Internalname = "vCOMBOSUPPLIERAGBTYPEID";
         divSectionattribute_supplieragbtypeid_Internalname = "SECTIONATTRIBUTE_SUPPLIERAGBTYPEID";
         edtavCombosupplieragbaddresscountry_Internalname = "vCOMBOSUPPLIERAGBADDRESSCOUNTRY";
         divSectionattribute_supplieragbaddresscountry_Internalname = "SECTIONATTRIBUTE_SUPPLIERAGBADDRESSCOUNTRY";
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         Form.Caption = "Agb Suppliers";
         Combo_supplieragbaddresscountry_Htmltemplate = "";
         edtSupplierAgbId_Jsonclick = "";
         edtSupplierAgbId_Enabled = 1;
         edtSupplierAgbId_Visible = 1;
         edtavCombosupplieragbaddresscountry_Jsonclick = "";
         edtavCombosupplieragbaddresscountry_Enabled = 0;
         edtavCombosupplieragbaddresscountry_Visible = 1;
         edtavCombosupplieragbtypeid_Jsonclick = "";
         edtavCombosupplieragbtypeid_Enabled = 0;
         edtavCombosupplieragbtypeid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSupplierAgbAddressLine2_Jsonclick = "";
         edtSupplierAgbAddressLine2_Enabled = 1;
         edtSupplierAgbAddressLine1_Jsonclick = "";
         edtSupplierAgbAddressLine1_Enabled = 1;
         edtSupplierAgbAddressZipCode_Jsonclick = "";
         edtSupplierAgbAddressZipCode_Enabled = 1;
         edtSupplierAgbAddressCity_Jsonclick = "";
         edtSupplierAgbAddressCity_Enabled = 1;
         edtSupplierAGBAddressCountry_Jsonclick = "";
         edtSupplierAGBAddressCountry_Enabled = 1;
         edtSupplierAGBAddressCountry_Visible = 1;
         Combo_supplieragbaddresscountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_supplieragbaddresscountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_supplieragbaddresscountry_Caption = "";
         Combo_supplieragbaddresscountry_Enabled = Convert.ToBoolean( -1);
         edtSupplierAgbEmail_Jsonclick = "";
         edtSupplierAgbEmail_Enabled = 1;
         edtSupplierAgbPhone_Jsonclick = "";
         edtSupplierAgbPhone_Enabled = 1;
         edtSupplierAgbContactName_Jsonclick = "";
         edtSupplierAgbContactName_Enabled = 1;
         edtSupplierAgbKvkNumber_Jsonclick = "";
         edtSupplierAgbKvkNumber_Enabled = 1;
         edtSupplierAgbName_Jsonclick = "";
         edtSupplierAgbName_Enabled = 1;
         edtSupplierAgbTypeId_Jsonclick = "";
         edtSupplierAgbTypeId_Enabled = 1;
         edtSupplierAgbTypeId_Visible = 1;
         Combo_supplieragbtypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_supplieragbtypeid_Cls = "ExtendedCombo Attribute";
         Combo_supplieragbtypeid_Enabled = Convert.ToBoolean( -1);
         edtSupplierAgbNumber_Jsonclick = "";
         edtSupplierAgbNumber_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "General Information";
         Dvpanel_tableattributes_Cls = "PanelWithBorder Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         divLayoutmaintable_Class = "Table";
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
         /* End function init_web_controls */
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

      public void Valid_Supplieragbtypeid( )
      {
         /* Using cursor T000715 */
         pr_default.execute(13, new Object[] {A283SupplierAgbTypeId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_SupplierAgbType'.", "ForeignKeyNotFound", 1, "SUPPLIERAGBTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierAgbTypeId_Internalname;
         }
         pr_default.close(13);
         if ( (Guid.Empty==A283SupplierAgbTypeId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Supplier Agb Type Id", "", "", "", "", "", "", "", ""), 1, "SUPPLIERAGBTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierAgbTypeId_Internalname;
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7SupplierAgbId","fld":"vSUPPLIERAGBID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7SupplierAgbId","fld":"vSUPPLIERAGBID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E13072","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_SUPPLIERAGBTYPEID.ONOPTIONCLICKED","""{"handler":"E12072","iparms":[{"av":"Combo_supplieragbtypeid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERAGBTYPEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SUPPLIERAGBTYPEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV20ComboSupplierAgbTypeId","fld":"vCOMBOSUPPLIERAGBTYPEID"}]}""");
         setEventMetadata("VALID_SUPPLIERAGBNUMBER","""{"handler":"Valid_Supplieragbnumber","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERAGBTYPEID","""{"handler":"Valid_Supplieragbtypeid","iparms":[{"av":"A283SupplierAgbTypeId","fld":"SUPPLIERAGBTYPEID"}]}""");
         setEventMetadata("VALID_SUPPLIERAGBNAME","""{"handler":"Valid_Supplieragbname","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERAGBEMAIL","""{"handler":"Valid_Supplieragbemail","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERAGBTYPEID","""{"handler":"Validv_Combosupplieragbtypeid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERAGBADDRESSCOUNTRY","""{"handler":"Validv_Combosupplieragbaddresscountry","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERAGBID","""{"handler":"Valid_Supplieragbid","iparms":[]}""");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7SupplierAgbId = Guid.Empty;
         Z49SupplierAgbId = Guid.Empty;
         Z332SupplierAGBAddressCountry = "";
         Z50SupplierAgbNumber = "";
         Z51SupplierAgbName = "";
         Z52SupplierAgbKvkNumber = "";
         Z299SupplierAgbAddressCity = "";
         Z298SupplierAgbAddressZipCode = "";
         Z333SupplierAgbAddressLine1 = "";
         Z334SupplierAgbAddressLine2 = "";
         Z55SupplierAgbContactName = "";
         Z56SupplierAgbPhone = "";
         Z57SupplierAgbEmail = "";
         Z283SupplierAgbTypeId = Guid.Empty;
         N283SupplierAgbTypeId = Guid.Empty;
         Combo_supplieragbaddresscountry_Selectedvalue_get = "";
         Combo_supplieragbtypeid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A283SupplierAgbTypeId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A50SupplierAgbNumber = "";
         lblTextblocksupplieragbtypeid_Jsonclick = "";
         ucCombo_supplieragbtypeid = new GXUserControl();
         Combo_supplieragbtypeid_Caption = "";
         AV15SupplierAgbTypeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A51SupplierAgbName = "";
         A52SupplierAgbKvkNumber = "";
         A55SupplierAgbContactName = "";
         gxphoneLink = "";
         A56SupplierAgbPhone = "";
         A57SupplierAgbEmail = "";
         lblTextblocksupplieragbaddresscountry_Jsonclick = "";
         ucCombo_supplieragbaddresscountry = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV23SupplierAGBAddressCountry_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A332SupplierAGBAddressCountry = "";
         A299SupplierAgbAddressCity = "";
         A298SupplierAgbAddressZipCode = "";
         A333SupplierAgbAddressLine1 = "";
         A334SupplierAgbAddressLine2 = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboSupplierAgbTypeId = Guid.Empty;
         AV24ComboSupplierAGBAddressCountry = "";
         A49SupplierAgbId = Guid.Empty;
         AV13Insert_SupplierAgbTypeId = Guid.Empty;
         AV25Pgmname = "";
         Combo_supplieragbtypeid_Objectcall = "";
         Combo_supplieragbtypeid_Class = "";
         Combo_supplieragbtypeid_Icontype = "";
         Combo_supplieragbtypeid_Icon = "";
         Combo_supplieragbtypeid_Tooltip = "";
         Combo_supplieragbtypeid_Selectedvalue_set = "";
         Combo_supplieragbtypeid_Selectedtext_set = "";
         Combo_supplieragbtypeid_Selectedtext_get = "";
         Combo_supplieragbtypeid_Gamoauthtoken = "";
         Combo_supplieragbtypeid_Ddointernalname = "";
         Combo_supplieragbtypeid_Titlecontrolalign = "";
         Combo_supplieragbtypeid_Dropdownoptionstype = "";
         Combo_supplieragbtypeid_Titlecontrolidtoreplace = "";
         Combo_supplieragbtypeid_Datalisttype = "";
         Combo_supplieragbtypeid_Datalistfixedvalues = "";
         Combo_supplieragbtypeid_Datalistproc = "";
         Combo_supplieragbtypeid_Datalistprocparametersprefix = "";
         Combo_supplieragbtypeid_Remoteservicesparameters = "";
         Combo_supplieragbtypeid_Htmltemplate = "";
         Combo_supplieragbtypeid_Multiplevaluestype = "";
         Combo_supplieragbtypeid_Loadingdata = "";
         Combo_supplieragbtypeid_Noresultsfound = "";
         Combo_supplieragbtypeid_Emptyitemtext = "";
         Combo_supplieragbtypeid_Onlyselectedvalues = "";
         Combo_supplieragbtypeid_Selectalltext = "";
         Combo_supplieragbtypeid_Multiplevaluesseparator = "";
         Combo_supplieragbtypeid_Addnewoptiontext = "";
         Combo_supplieragbaddresscountry_Objectcall = "";
         Combo_supplieragbaddresscountry_Class = "";
         Combo_supplieragbaddresscountry_Icontype = "";
         Combo_supplieragbaddresscountry_Icon = "";
         Combo_supplieragbaddresscountry_Tooltip = "";
         Combo_supplieragbaddresscountry_Selectedvalue_set = "";
         Combo_supplieragbaddresscountry_Selectedtext_set = "";
         Combo_supplieragbaddresscountry_Selectedtext_get = "";
         Combo_supplieragbaddresscountry_Gamoauthtoken = "";
         Combo_supplieragbaddresscountry_Ddointernalname = "";
         Combo_supplieragbaddresscountry_Titlecontrolalign = "";
         Combo_supplieragbaddresscountry_Dropdownoptionstype = "";
         Combo_supplieragbaddresscountry_Titlecontrolidtoreplace = "";
         Combo_supplieragbaddresscountry_Datalisttype = "";
         Combo_supplieragbaddresscountry_Datalistfixedvalues = "";
         Combo_supplieragbaddresscountry_Datalistproc = "";
         Combo_supplieragbaddresscountry_Datalistprocparametersprefix = "";
         Combo_supplieragbaddresscountry_Remoteservicesparameters = "";
         Combo_supplieragbaddresscountry_Multiplevaluestype = "";
         Combo_supplieragbaddresscountry_Loadingdata = "";
         Combo_supplieragbaddresscountry_Noresultsfound = "";
         Combo_supplieragbaddresscountry_Emptyitemtext = "";
         Combo_supplieragbaddresscountry_Onlyselectedvalues = "";
         Combo_supplieragbaddresscountry_Selectalltext = "";
         Combo_supplieragbaddresscountry_Multiplevaluesseparator = "";
         Combo_supplieragbaddresscountry_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode11 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_char2 = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_objcol_SdtDVB_SDTComboData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         T00075_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00075_n49SupplierAgbId = new bool[] {false} ;
         T00075_A332SupplierAGBAddressCountry = new string[] {""} ;
         T00075_A50SupplierAgbNumber = new string[] {""} ;
         T00075_A51SupplierAgbName = new string[] {""} ;
         T00075_A52SupplierAgbKvkNumber = new string[] {""} ;
         T00075_A299SupplierAgbAddressCity = new string[] {""} ;
         T00075_A298SupplierAgbAddressZipCode = new string[] {""} ;
         T00075_A333SupplierAgbAddressLine1 = new string[] {""} ;
         T00075_A334SupplierAgbAddressLine2 = new string[] {""} ;
         T00075_A55SupplierAgbContactName = new string[] {""} ;
         T00075_A56SupplierAgbPhone = new string[] {""} ;
         T00075_A57SupplierAgbEmail = new string[] {""} ;
         T00075_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         T00074_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         T00076_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         T00077_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00077_n49SupplierAgbId = new bool[] {false} ;
         T00073_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00073_n49SupplierAgbId = new bool[] {false} ;
         T00073_A332SupplierAGBAddressCountry = new string[] {""} ;
         T00073_A50SupplierAgbNumber = new string[] {""} ;
         T00073_A51SupplierAgbName = new string[] {""} ;
         T00073_A52SupplierAgbKvkNumber = new string[] {""} ;
         T00073_A299SupplierAgbAddressCity = new string[] {""} ;
         T00073_A298SupplierAgbAddressZipCode = new string[] {""} ;
         T00073_A333SupplierAgbAddressLine1 = new string[] {""} ;
         T00073_A334SupplierAgbAddressLine2 = new string[] {""} ;
         T00073_A55SupplierAgbContactName = new string[] {""} ;
         T00073_A56SupplierAgbPhone = new string[] {""} ;
         T00073_A57SupplierAgbEmail = new string[] {""} ;
         T00073_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         T00078_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00078_n49SupplierAgbId = new bool[] {false} ;
         T00079_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00079_n49SupplierAgbId = new bool[] {false} ;
         T00072_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T00072_n49SupplierAgbId = new bool[] {false} ;
         T00072_A332SupplierAGBAddressCountry = new string[] {""} ;
         T00072_A50SupplierAgbNumber = new string[] {""} ;
         T00072_A51SupplierAgbName = new string[] {""} ;
         T00072_A52SupplierAgbKvkNumber = new string[] {""} ;
         T00072_A299SupplierAgbAddressCity = new string[] {""} ;
         T00072_A298SupplierAgbAddressZipCode = new string[] {""} ;
         T00072_A333SupplierAgbAddressLine1 = new string[] {""} ;
         T00072_A334SupplierAgbAddressLine2 = new string[] {""} ;
         T00072_A55SupplierAgbContactName = new string[] {""} ;
         T00072_A56SupplierAgbPhone = new string[] {""} ;
         T00072_A57SupplierAgbEmail = new string[] {""} ;
         T00072_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         T000713_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000714_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         T000714_n49SupplierAgbId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000715_A283SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragb__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragb__default(),
            new Object[][] {
                new Object[] {
               T00072_A49SupplierAgbId, T00072_A332SupplierAGBAddressCountry, T00072_A50SupplierAgbNumber, T00072_A51SupplierAgbName, T00072_A52SupplierAgbKvkNumber, T00072_A299SupplierAgbAddressCity, T00072_A298SupplierAgbAddressZipCode, T00072_A333SupplierAgbAddressLine1, T00072_A334SupplierAgbAddressLine2, T00072_A55SupplierAgbContactName,
               T00072_A56SupplierAgbPhone, T00072_A57SupplierAgbEmail, T00072_A283SupplierAgbTypeId
               }
               , new Object[] {
               T00073_A49SupplierAgbId, T00073_A332SupplierAGBAddressCountry, T00073_A50SupplierAgbNumber, T00073_A51SupplierAgbName, T00073_A52SupplierAgbKvkNumber, T00073_A299SupplierAgbAddressCity, T00073_A298SupplierAgbAddressZipCode, T00073_A333SupplierAgbAddressLine1, T00073_A334SupplierAgbAddressLine2, T00073_A55SupplierAgbContactName,
               T00073_A56SupplierAgbPhone, T00073_A57SupplierAgbEmail, T00073_A283SupplierAgbTypeId
               }
               , new Object[] {
               T00074_A283SupplierAgbTypeId
               }
               , new Object[] {
               T00075_A49SupplierAgbId, T00075_A332SupplierAGBAddressCountry, T00075_A50SupplierAgbNumber, T00075_A51SupplierAgbName, T00075_A52SupplierAgbKvkNumber, T00075_A299SupplierAgbAddressCity, T00075_A298SupplierAgbAddressZipCode, T00075_A333SupplierAgbAddressLine1, T00075_A334SupplierAgbAddressLine2, T00075_A55SupplierAgbContactName,
               T00075_A56SupplierAgbPhone, T00075_A57SupplierAgbEmail, T00075_A283SupplierAgbTypeId
               }
               , new Object[] {
               T00076_A283SupplierAgbTypeId
               }
               , new Object[] {
               T00077_A49SupplierAgbId
               }
               , new Object[] {
               T00078_A49SupplierAgbId
               }
               , new Object[] {
               T00079_A49SupplierAgbId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000713_A58ProductServiceId
               }
               , new Object[] {
               T000714_A49SupplierAgbId
               }
               , new Object[] {
               T000715_A283SupplierAgbTypeId
               }
            }
         );
         Z49SupplierAgbId = Guid.NewGuid( );
         n49SupplierAgbId = false;
         A49SupplierAgbId = Guid.NewGuid( );
         n49SupplierAgbId = false;
         AV25Pgmname = "Trn_SupplierAgb";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound11 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtSupplierAgbNumber_Enabled ;
      private int edtSupplierAgbTypeId_Visible ;
      private int edtSupplierAgbTypeId_Enabled ;
      private int edtSupplierAgbName_Enabled ;
      private int edtSupplierAgbKvkNumber_Enabled ;
      private int edtSupplierAgbContactName_Enabled ;
      private int edtSupplierAgbPhone_Enabled ;
      private int edtSupplierAgbEmail_Enabled ;
      private int edtSupplierAGBAddressCountry_Visible ;
      private int edtSupplierAGBAddressCountry_Enabled ;
      private int edtSupplierAgbAddressCity_Enabled ;
      private int edtSupplierAgbAddressZipCode_Enabled ;
      private int edtSupplierAgbAddressLine1_Enabled ;
      private int edtSupplierAgbAddressLine2_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombosupplieragbtypeid_Visible ;
      private int edtavCombosupplieragbtypeid_Enabled ;
      private int edtavCombosupplieragbaddresscountry_Visible ;
      private int edtavCombosupplieragbaddresscountry_Enabled ;
      private int edtSupplierAgbId_Visible ;
      private int edtSupplierAgbId_Enabled ;
      private int Combo_supplieragbtypeid_Datalistupdateminimumcharacters ;
      private int Combo_supplieragbtypeid_Gxcontroltype ;
      private int Combo_supplieragbaddresscountry_Datalistupdateminimumcharacters ;
      private int Combo_supplieragbaddresscountry_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z56SupplierAgbPhone ;
      private string Combo_supplieragbaddresscountry_Selectedvalue_get ;
      private string Combo_supplieragbtypeid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSupplierAgbNumber_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtSupplierAgbNumber_Jsonclick ;
      private string divTablesplittedsupplieragbtypeid_Internalname ;
      private string lblTextblocksupplieragbtypeid_Internalname ;
      private string lblTextblocksupplieragbtypeid_Jsonclick ;
      private string Combo_supplieragbtypeid_Caption ;
      private string Combo_supplieragbtypeid_Cls ;
      private string Combo_supplieragbtypeid_Internalname ;
      private string edtSupplierAgbTypeId_Internalname ;
      private string edtSupplierAgbTypeId_Jsonclick ;
      private string edtSupplierAgbName_Internalname ;
      private string edtSupplierAgbName_Jsonclick ;
      private string edtSupplierAgbKvkNumber_Internalname ;
      private string edtSupplierAgbKvkNumber_Jsonclick ;
      private string edtSupplierAgbContactName_Internalname ;
      private string edtSupplierAgbContactName_Jsonclick ;
      private string edtSupplierAgbPhone_Internalname ;
      private string gxphoneLink ;
      private string A56SupplierAgbPhone ;
      private string edtSupplierAgbPhone_Jsonclick ;
      private string edtSupplierAgbEmail_Internalname ;
      private string edtSupplierAgbEmail_Jsonclick ;
      private string divTablesplittedsupplieragbaddresscountry_Internalname ;
      private string lblTextblocksupplieragbaddresscountry_Internalname ;
      private string lblTextblocksupplieragbaddresscountry_Jsonclick ;
      private string Combo_supplieragbaddresscountry_Caption ;
      private string Combo_supplieragbaddresscountry_Cls ;
      private string Combo_supplieragbaddresscountry_Internalname ;
      private string edtSupplierAGBAddressCountry_Internalname ;
      private string edtSupplierAGBAddressCountry_Jsonclick ;
      private string edtSupplierAgbAddressCity_Internalname ;
      private string edtSupplierAgbAddressCity_Jsonclick ;
      private string edtSupplierAgbAddressZipCode_Internalname ;
      private string edtSupplierAgbAddressZipCode_Jsonclick ;
      private string edtSupplierAgbAddressLine1_Internalname ;
      private string edtSupplierAgbAddressLine1_Jsonclick ;
      private string edtSupplierAgbAddressLine2_Internalname ;
      private string edtSupplierAgbAddressLine2_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_supplieragbtypeid_Internalname ;
      private string edtavCombosupplieragbtypeid_Internalname ;
      private string edtavCombosupplieragbtypeid_Jsonclick ;
      private string divSectionattribute_supplieragbaddresscountry_Internalname ;
      private string edtavCombosupplieragbaddresscountry_Internalname ;
      private string edtavCombosupplieragbaddresscountry_Jsonclick ;
      private string edtSupplierAgbId_Internalname ;
      private string edtSupplierAgbId_Jsonclick ;
      private string AV25Pgmname ;
      private string Combo_supplieragbtypeid_Objectcall ;
      private string Combo_supplieragbtypeid_Class ;
      private string Combo_supplieragbtypeid_Icontype ;
      private string Combo_supplieragbtypeid_Icon ;
      private string Combo_supplieragbtypeid_Tooltip ;
      private string Combo_supplieragbtypeid_Selectedvalue_set ;
      private string Combo_supplieragbtypeid_Selectedtext_set ;
      private string Combo_supplieragbtypeid_Selectedtext_get ;
      private string Combo_supplieragbtypeid_Gamoauthtoken ;
      private string Combo_supplieragbtypeid_Ddointernalname ;
      private string Combo_supplieragbtypeid_Titlecontrolalign ;
      private string Combo_supplieragbtypeid_Dropdownoptionstype ;
      private string Combo_supplieragbtypeid_Titlecontrolidtoreplace ;
      private string Combo_supplieragbtypeid_Datalisttype ;
      private string Combo_supplieragbtypeid_Datalistfixedvalues ;
      private string Combo_supplieragbtypeid_Datalistproc ;
      private string Combo_supplieragbtypeid_Datalistprocparametersprefix ;
      private string Combo_supplieragbtypeid_Remoteservicesparameters ;
      private string Combo_supplieragbtypeid_Htmltemplate ;
      private string Combo_supplieragbtypeid_Multiplevaluestype ;
      private string Combo_supplieragbtypeid_Loadingdata ;
      private string Combo_supplieragbtypeid_Noresultsfound ;
      private string Combo_supplieragbtypeid_Emptyitemtext ;
      private string Combo_supplieragbtypeid_Onlyselectedvalues ;
      private string Combo_supplieragbtypeid_Selectalltext ;
      private string Combo_supplieragbtypeid_Multiplevaluesseparator ;
      private string Combo_supplieragbtypeid_Addnewoptiontext ;
      private string Combo_supplieragbaddresscountry_Objectcall ;
      private string Combo_supplieragbaddresscountry_Class ;
      private string Combo_supplieragbaddresscountry_Icontype ;
      private string Combo_supplieragbaddresscountry_Icon ;
      private string Combo_supplieragbaddresscountry_Tooltip ;
      private string Combo_supplieragbaddresscountry_Selectedvalue_set ;
      private string Combo_supplieragbaddresscountry_Selectedtext_set ;
      private string Combo_supplieragbaddresscountry_Selectedtext_get ;
      private string Combo_supplieragbaddresscountry_Gamoauthtoken ;
      private string Combo_supplieragbaddresscountry_Ddointernalname ;
      private string Combo_supplieragbaddresscountry_Titlecontrolalign ;
      private string Combo_supplieragbaddresscountry_Dropdownoptionstype ;
      private string Combo_supplieragbaddresscountry_Titlecontrolidtoreplace ;
      private string Combo_supplieragbaddresscountry_Datalisttype ;
      private string Combo_supplieragbaddresscountry_Datalistfixedvalues ;
      private string Combo_supplieragbaddresscountry_Datalistproc ;
      private string Combo_supplieragbaddresscountry_Datalistprocparametersprefix ;
      private string Combo_supplieragbaddresscountry_Remoteservicesparameters ;
      private string Combo_supplieragbaddresscountry_Htmltemplate ;
      private string Combo_supplieragbaddresscountry_Multiplevaluestype ;
      private string Combo_supplieragbaddresscountry_Loadingdata ;
      private string Combo_supplieragbaddresscountry_Noresultsfound ;
      private string Combo_supplieragbaddresscountry_Emptyitemtext ;
      private string Combo_supplieragbaddresscountry_Onlyselectedvalues ;
      private string Combo_supplieragbaddresscountry_Selectalltext ;
      private string Combo_supplieragbaddresscountry_Multiplevaluesseparator ;
      private string Combo_supplieragbaddresscountry_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode11 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_supplieragbtypeid_Emptyitem ;
      private bool Combo_supplieragbaddresscountry_Emptyitem ;
      private bool Combo_supplieragbtypeid_Enabled ;
      private bool Combo_supplieragbtypeid_Visible ;
      private bool Combo_supplieragbtypeid_Allowmultipleselection ;
      private bool Combo_supplieragbtypeid_Isgriditem ;
      private bool Combo_supplieragbtypeid_Hasdescription ;
      private bool Combo_supplieragbtypeid_Includeonlyselectedoption ;
      private bool Combo_supplieragbtypeid_Includeselectalloption ;
      private bool Combo_supplieragbtypeid_Includeaddnewoption ;
      private bool Combo_supplieragbaddresscountry_Enabled ;
      private bool Combo_supplieragbaddresscountry_Visible ;
      private bool Combo_supplieragbaddresscountry_Allowmultipleselection ;
      private bool Combo_supplieragbaddresscountry_Isgriditem ;
      private bool Combo_supplieragbaddresscountry_Hasdescription ;
      private bool Combo_supplieragbaddresscountry_Includeonlyselectedoption ;
      private bool Combo_supplieragbaddresscountry_Includeselectalloption ;
      private bool Combo_supplieragbaddresscountry_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n49SupplierAgbId ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z332SupplierAGBAddressCountry ;
      private string Z50SupplierAgbNumber ;
      private string Z51SupplierAgbName ;
      private string Z52SupplierAgbKvkNumber ;
      private string Z299SupplierAgbAddressCity ;
      private string Z298SupplierAgbAddressZipCode ;
      private string Z333SupplierAgbAddressLine1 ;
      private string Z334SupplierAgbAddressLine2 ;
      private string Z55SupplierAgbContactName ;
      private string Z57SupplierAgbEmail ;
      private string A50SupplierAgbNumber ;
      private string A51SupplierAgbName ;
      private string A52SupplierAgbKvkNumber ;
      private string A55SupplierAgbContactName ;
      private string A57SupplierAgbEmail ;
      private string A332SupplierAGBAddressCountry ;
      private string A299SupplierAgbAddressCity ;
      private string A298SupplierAgbAddressZipCode ;
      private string A333SupplierAgbAddressLine1 ;
      private string A334SupplierAgbAddressLine2 ;
      private string AV24ComboSupplierAGBAddressCountry ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private Guid wcpOAV7SupplierAgbId ;
      private Guid Z49SupplierAgbId ;
      private Guid Z283SupplierAgbTypeId ;
      private Guid N283SupplierAgbTypeId ;
      private Guid A283SupplierAgbTypeId ;
      private Guid AV7SupplierAgbId ;
      private Guid AV20ComboSupplierAgbTypeId ;
      private Guid A49SupplierAgbId ;
      private Guid AV13Insert_SupplierAgbTypeId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_supplieragbtypeid ;
      private GXUserControl ucCombo_supplieragbaddresscountry ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15SupplierAgbTypeId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV23SupplierAGBAddressCountry_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item3 ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00075_A49SupplierAgbId ;
      private bool[] T00075_n49SupplierAgbId ;
      private string[] T00075_A332SupplierAGBAddressCountry ;
      private string[] T00075_A50SupplierAgbNumber ;
      private string[] T00075_A51SupplierAgbName ;
      private string[] T00075_A52SupplierAgbKvkNumber ;
      private string[] T00075_A299SupplierAgbAddressCity ;
      private string[] T00075_A298SupplierAgbAddressZipCode ;
      private string[] T00075_A333SupplierAgbAddressLine1 ;
      private string[] T00075_A334SupplierAgbAddressLine2 ;
      private string[] T00075_A55SupplierAgbContactName ;
      private string[] T00075_A56SupplierAgbPhone ;
      private string[] T00075_A57SupplierAgbEmail ;
      private Guid[] T00075_A283SupplierAgbTypeId ;
      private Guid[] T00074_A283SupplierAgbTypeId ;
      private Guid[] T00076_A283SupplierAgbTypeId ;
      private Guid[] T00077_A49SupplierAgbId ;
      private bool[] T00077_n49SupplierAgbId ;
      private Guid[] T00073_A49SupplierAgbId ;
      private bool[] T00073_n49SupplierAgbId ;
      private string[] T00073_A332SupplierAGBAddressCountry ;
      private string[] T00073_A50SupplierAgbNumber ;
      private string[] T00073_A51SupplierAgbName ;
      private string[] T00073_A52SupplierAgbKvkNumber ;
      private string[] T00073_A299SupplierAgbAddressCity ;
      private string[] T00073_A298SupplierAgbAddressZipCode ;
      private string[] T00073_A333SupplierAgbAddressLine1 ;
      private string[] T00073_A334SupplierAgbAddressLine2 ;
      private string[] T00073_A55SupplierAgbContactName ;
      private string[] T00073_A56SupplierAgbPhone ;
      private string[] T00073_A57SupplierAgbEmail ;
      private Guid[] T00073_A283SupplierAgbTypeId ;
      private Guid[] T00078_A49SupplierAgbId ;
      private bool[] T00078_n49SupplierAgbId ;
      private Guid[] T00079_A49SupplierAgbId ;
      private bool[] T00079_n49SupplierAgbId ;
      private Guid[] T00072_A49SupplierAgbId ;
      private bool[] T00072_n49SupplierAgbId ;
      private string[] T00072_A332SupplierAGBAddressCountry ;
      private string[] T00072_A50SupplierAgbNumber ;
      private string[] T00072_A51SupplierAgbName ;
      private string[] T00072_A52SupplierAgbKvkNumber ;
      private string[] T00072_A299SupplierAgbAddressCity ;
      private string[] T00072_A298SupplierAgbAddressZipCode ;
      private string[] T00072_A333SupplierAgbAddressLine1 ;
      private string[] T00072_A334SupplierAgbAddressLine2 ;
      private string[] T00072_A55SupplierAgbContactName ;
      private string[] T00072_A56SupplierAgbPhone ;
      private string[] T00072_A57SupplierAgbEmail ;
      private Guid[] T00072_A283SupplierAgbTypeId ;
      private Guid[] T000713_A58ProductServiceId ;
      private Guid[] T000714_A49SupplierAgbId ;
      private bool[] T000714_n49SupplierAgbId ;
      private Guid[] T000715_A283SupplierAgbTypeId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_supplieragb__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_supplieragb__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00072;
        prmT00072 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00073;
        prmT00073 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00074;
        prmT00074 = new Object[] {
        new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00075;
        prmT00075 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00076;
        prmT00076 = new Object[] {
        new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00077;
        prmT00077 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00078;
        prmT00078 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00079;
        prmT00079 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000710;
        prmT000710 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SupplierAGBAddressCountry",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbNumber",GXType.VarChar,40,0) ,
        new ParDef("SupplierAgbName",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbKvkNumber",GXType.VarChar,40,0) ,
        new ParDef("SupplierAgbAddressCity",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbAddressZipCode",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbAddressLine1",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbAddressLine2",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbContactName",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbPhone",GXType.Char,20,0) ,
        new ParDef("SupplierAgbEmail",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000711;
        prmT000711 = new Object[] {
        new ParDef("SupplierAGBAddressCountry",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbNumber",GXType.VarChar,40,0) ,
        new ParDef("SupplierAgbName",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbKvkNumber",GXType.VarChar,40,0) ,
        new ParDef("SupplierAgbAddressCity",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbAddressZipCode",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbAddressLine1",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbAddressLine2",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbContactName",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbPhone",GXType.Char,20,0) ,
        new ParDef("SupplierAgbEmail",GXType.VarChar,100,0) ,
        new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000712;
        prmT000712 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000713;
        prmT000713 = new Object[] {
        new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000714;
        prmT000714 = new Object[] {
        };
        Object[] prmT000715;
        prmT000715 = new Object[] {
        new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00072", "SELECT SupplierAgbId, SupplierAGBAddressCountry, SupplierAgbNumber, SupplierAgbName, SupplierAgbKvkNumber, SupplierAgbAddressCity, SupplierAgbAddressZipCode, SupplierAgbAddressLine1, SupplierAgbAddressLine2, SupplierAgbContactName, SupplierAgbPhone, SupplierAgbEmail, SupplierAgbTypeId FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId  FOR UPDATE OF Trn_SupplierAGB NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00073", "SELECT SupplierAgbId, SupplierAGBAddressCountry, SupplierAgbNumber, SupplierAgbName, SupplierAgbKvkNumber, SupplierAgbAddressCity, SupplierAgbAddressZipCode, SupplierAgbAddressLine1, SupplierAgbAddressLine2, SupplierAgbContactName, SupplierAgbPhone, SupplierAgbEmail, SupplierAgbTypeId FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00074", "SELECT SupplierAgbTypeId FROM Trn_SupplierAgbType WHERE SupplierAgbTypeId = :SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00075", "SELECT TM1.SupplierAgbId, TM1.SupplierAGBAddressCountry, TM1.SupplierAgbNumber, TM1.SupplierAgbName, TM1.SupplierAgbKvkNumber, TM1.SupplierAgbAddressCity, TM1.SupplierAgbAddressZipCode, TM1.SupplierAgbAddressLine1, TM1.SupplierAgbAddressLine2, TM1.SupplierAgbContactName, TM1.SupplierAgbPhone, TM1.SupplierAgbEmail, TM1.SupplierAgbTypeId FROM Trn_SupplierAGB TM1 WHERE TM1.SupplierAgbId = :SupplierAgbId ORDER BY TM1.SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00076", "SELECT SupplierAgbTypeId FROM Trn_SupplierAgbType WHERE SupplierAgbTypeId = :SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00077", "SELECT SupplierAgbId FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00078", "SELECT SupplierAgbId FROM Trn_SupplierAGB WHERE ( SupplierAgbId > :SupplierAgbId) ORDER BY SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00079", "SELECT SupplierAgbId FROM Trn_SupplierAGB WHERE ( SupplierAgbId < :SupplierAgbId) ORDER BY SupplierAgbId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000710", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierAGB(SupplierAgbId, SupplierAGBAddressCountry, SupplierAgbNumber, SupplierAgbName, SupplierAgbKvkNumber, SupplierAgbAddressCity, SupplierAgbAddressZipCode, SupplierAgbAddressLine1, SupplierAgbAddressLine2, SupplierAgbContactName, SupplierAgbPhone, SupplierAgbEmail, SupplierAgbTypeId) VALUES(:SupplierAgbId, :SupplierAGBAddressCountry, :SupplierAgbNumber, :SupplierAgbName, :SupplierAgbKvkNumber, :SupplierAgbAddressCity, :SupplierAgbAddressZipCode, :SupplierAgbAddressLine1, :SupplierAgbAddressLine2, :SupplierAgbContactName, :SupplierAgbPhone, :SupplierAgbEmail, :SupplierAgbTypeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000710)
           ,new CursorDef("T000711", "SAVEPOINT gxupdate;UPDATE Trn_SupplierAGB SET SupplierAGBAddressCountry=:SupplierAGBAddressCountry, SupplierAgbNumber=:SupplierAgbNumber, SupplierAgbName=:SupplierAgbName, SupplierAgbKvkNumber=:SupplierAgbKvkNumber, SupplierAgbAddressCity=:SupplierAgbAddressCity, SupplierAgbAddressZipCode=:SupplierAgbAddressZipCode, SupplierAgbAddressLine1=:SupplierAgbAddressLine1, SupplierAgbAddressLine2=:SupplierAgbAddressLine2, SupplierAgbContactName=:SupplierAgbContactName, SupplierAgbPhone=:SupplierAgbPhone, SupplierAgbEmail=:SupplierAgbEmail, SupplierAgbTypeId=:SupplierAgbTypeId  WHERE SupplierAgbId = :SupplierAgbId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000711)
           ,new CursorDef("T000712", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierAGB  WHERE SupplierAgbId = :SupplierAgbId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000712)
           ,new CursorDef("T000713", "SELECT ProductServiceId FROM Trn_ProductService WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000714", "SELECT SupplierAgbId FROM Trn_SupplierAGB ORDER BY SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000715", "SELECT SupplierAgbTypeId FROM Trn_SupplierAgbType WHERE SupplierAgbTypeId = :SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000715,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 20);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((Guid[]) buf[12])[0] = rslt.getGuid(13);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 20);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((Guid[]) buf[12])[0] = rslt.getGuid(13);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 20);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((Guid[]) buf[12])[0] = rslt.getGuid(13);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}