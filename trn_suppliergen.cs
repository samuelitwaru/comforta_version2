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
   public class trn_suppliergen : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A282SupplierGenTypeId = StringUtil.StrToGuid( GetPar( "SupplierGenTypeId"));
            AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A282SupplierGenTypeId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_suppliergen.aspx")), "trn_suppliergen.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_suppliergen.aspx")))) ;
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
                  AV7SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
                  AssignAttri("", false, "AV7SupplierGenId", AV7SupplierGenId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENID", GetSecureSignedToken( "", AV7SupplierGenId, context));
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
         Form.Meta.addItem("description", "General Suppliers", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_suppliergen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_SupplierGenId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SupplierGenId = aP1_SupplierGenId;
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
            return "trn_suppliergen_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenKvkNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenKvkNumber_Internalname, "KVK Number", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenKvkNumber_Internalname, A43SupplierGenKvkNumber, StringUtil.RTrim( context.localUtil.Format( A43SupplierGenKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenKvkNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenKvkNumber_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "KvkNumber", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsuppliergentypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergentypeid_Internalname, "Supplier Category", "", "", lblTextblocksuppliergentypeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_suppliergentypeid.SetProperty("Caption", Combo_suppliergentypeid_Caption);
         ucCombo_suppliergentypeid.SetProperty("Cls", Combo_suppliergentypeid_Cls);
         ucCombo_suppliergentypeid.SetProperty("EmptyItem", Combo_suppliergentypeid_Emptyitem);
         ucCombo_suppliergentypeid.SetProperty("DropDownOptionsData", AV15SupplierGenTypeId_Data);
         ucCombo_suppliergentypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergentypeid_Internalname, "COMBO_SUPPLIERGENTYPEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenTypeId_Internalname, "Supplier Gen Type Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenTypeId_Internalname, A282SupplierGenTypeId.ToString(), A282SupplierGenTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenTypeId_Visible, edtSupplierGenTypeId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierGen.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenCompanyName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenCompanyName_Internalname, "Supplier Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenCompanyName_Internalname, A44SupplierGenCompanyName, StringUtil.RTrim( context.localUtil.Format( A44SupplierGenCompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenCompanyName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenCompanyName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenContactName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenContactName_Internalname, "Contact Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenContactName_Internalname, A47SupplierGenContactName, StringUtil.RTrim( context.localUtil.Format( A47SupplierGenContactName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenContactName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenContactName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenContactPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenContactPhone_Internalname, "Contact Phone", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A48SupplierGenContactPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenContactPhone_Internalname, StringUtil.RTrim( A48SupplierGenContactPhone), StringUtil.RTrim( context.localUtil.Format( A48SupplierGenContactPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtSupplierGenContactPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenContactPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsuppliergenaddresscountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksuppliergenaddresscountry_Internalname, " Country", "", "", lblTextblocksuppliergenaddresscountry_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_suppliergenaddresscountry.SetProperty("Caption", Combo_suppliergenaddresscountry_Caption);
         ucCombo_suppliergenaddresscountry.SetProperty("Cls", Combo_suppliergenaddresscountry_Cls);
         ucCombo_suppliergenaddresscountry.SetProperty("EmptyItem", Combo_suppliergenaddresscountry_Emptyitem);
         ucCombo_suppliergenaddresscountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_suppliergenaddresscountry.SetProperty("DropDownOptionsData", AV23SupplierGenAddressCountry_Data);
         ucCombo_suppliergenaddresscountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_suppliergenaddresscountry_Internalname, "COMBO_SUPPLIERGENADDRESSCOUNTRYContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressCountry_Internalname, "Supplier Gen Address Country", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressCountry_Internalname, A335SupplierGenAddressCountry, StringUtil.RTrim( context.localUtil.Format( A335SupplierGenAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenAddressCountry_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenAddressCountry_Visible, edtSupplierGenAddressCountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressCity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressCity_Internalname, "City", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressCity_Internalname, A295SupplierGenAddressCity, StringUtil.RTrim( context.localUtil.Format( A295SupplierGenAddressCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenAddressCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressZipCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressZipCode_Internalname, "Zip Code", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressZipCode_Internalname, A294SupplierGenAddressZipCode, StringUtil.RTrim( context.localUtil.Format( A294SupplierGenAddressZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenAddressZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressLine1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressLine1_Internalname, "Address Line 1", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressLine1_Internalname, A336SupplierGenAddressLine1, StringUtil.RTrim( context.localUtil.Format( A336SupplierGenAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierGenAddressLine2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierGenAddressLine2_Internalname, "Address Line 2", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenAddressLine2_Internalname, A337SupplierGenAddressLine2, StringUtil.RTrim( context.localUtil.Format( A337SupplierGenAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierGenAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGen.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_suppliergentypeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosuppliergentypeid_Internalname, AV20ComboSupplierGenTypeId.ToString(), AV20ComboSupplierGenTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosuppliergentypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosuppliergentypeid_Visible, edtavCombosuppliergentypeid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_suppliergenaddresscountry_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosuppliergenaddresscountry_Internalname, AV24ComboSupplierGenAddressCountry, StringUtil.RTrim( context.localUtil.Format( AV24ComboSupplierGenAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosuppliergenaddresscountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosuppliergenaddresscountry_Visible, edtavCombosuppliergenaddresscountry_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_SupplierGen.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierGenId_Internalname, A42SupplierGenId.ToString(), A42SupplierGenId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierGenId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierGenId_Visible, edtSupplierGenId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_SupplierGen.htm");
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
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENTYPEID_DATA"), AV15SupplierGenTypeId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERGENADDRESSCOUNTRY_DATA"), AV23SupplierGenAddressCountry_Data);
               /* Read saved values. */
               Z42SupplierGenId = StringUtil.StrToGuid( cgiGet( "Z42SupplierGenId"));
               Z335SupplierGenAddressCountry = cgiGet( "Z335SupplierGenAddressCountry");
               Z43SupplierGenKvkNumber = cgiGet( "Z43SupplierGenKvkNumber");
               Z44SupplierGenCompanyName = cgiGet( "Z44SupplierGenCompanyName");
               Z295SupplierGenAddressCity = cgiGet( "Z295SupplierGenAddressCity");
               Z294SupplierGenAddressZipCode = cgiGet( "Z294SupplierGenAddressZipCode");
               Z336SupplierGenAddressLine1 = cgiGet( "Z336SupplierGenAddressLine1");
               Z337SupplierGenAddressLine2 = cgiGet( "Z337SupplierGenAddressLine2");
               Z47SupplierGenContactName = cgiGet( "Z47SupplierGenContactName");
               Z48SupplierGenContactPhone = cgiGet( "Z48SupplierGenContactPhone");
               Z282SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( "Z282SupplierGenTypeId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N282SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( "N282SupplierGenTypeId"));
               AV7SupplierGenId = StringUtil.StrToGuid( cgiGet( "vSUPPLIERGENID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( "vINSERT_SUPPLIERGENTYPEID"));
               AV25Pgmname = cgiGet( "vPGMNAME");
               Combo_suppliergentypeid_Objectcall = cgiGet( "COMBO_SUPPLIERGENTYPEID_Objectcall");
               Combo_suppliergentypeid_Class = cgiGet( "COMBO_SUPPLIERGENTYPEID_Class");
               Combo_suppliergentypeid_Icontype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Icontype");
               Combo_suppliergentypeid_Icon = cgiGet( "COMBO_SUPPLIERGENTYPEID_Icon");
               Combo_suppliergentypeid_Caption = cgiGet( "COMBO_SUPPLIERGENTYPEID_Caption");
               Combo_suppliergentypeid_Tooltip = cgiGet( "COMBO_SUPPLIERGENTYPEID_Tooltip");
               Combo_suppliergentypeid_Cls = cgiGet( "COMBO_SUPPLIERGENTYPEID_Cls");
               Combo_suppliergentypeid_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedvalue_set");
               Combo_suppliergentypeid_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedvalue_get");
               Combo_suppliergentypeid_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedtext_set");
               Combo_suppliergentypeid_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectedtext_get");
               Combo_suppliergentypeid_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGENTYPEID_Gamoauthtoken");
               Combo_suppliergentypeid_Ddointernalname = cgiGet( "COMBO_SUPPLIERGENTYPEID_Ddointernalname");
               Combo_suppliergentypeid_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGENTYPEID_Titlecontrolalign");
               Combo_suppliergentypeid_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Dropdownoptionstype");
               Combo_suppliergentypeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Enabled"));
               Combo_suppliergentypeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Visible"));
               Combo_suppliergentypeid_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGENTYPEID_Titlecontrolidtoreplace");
               Combo_suppliergentypeid_Datalisttype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalisttype");
               Combo_suppliergentypeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Allowmultipleselection"));
               Combo_suppliergentypeid_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistfixedvalues");
               Combo_suppliergentypeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Isgriditem"));
               Combo_suppliergentypeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Hasdescription"));
               Combo_suppliergentypeid_Datalistproc = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistproc");
               Combo_suppliergentypeid_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistprocparametersprefix");
               Combo_suppliergentypeid_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGENTYPEID_Remoteservicesparameters");
               Combo_suppliergentypeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENTYPEID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_suppliergentypeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Includeonlyselectedoption"));
               Combo_suppliergentypeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Includeselectalloption"));
               Combo_suppliergentypeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Emptyitem"));
               Combo_suppliergentypeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENTYPEID_Includeaddnewoption"));
               Combo_suppliergentypeid_Htmltemplate = cgiGet( "COMBO_SUPPLIERGENTYPEID_Htmltemplate");
               Combo_suppliergentypeid_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGENTYPEID_Multiplevaluestype");
               Combo_suppliergentypeid_Loadingdata = cgiGet( "COMBO_SUPPLIERGENTYPEID_Loadingdata");
               Combo_suppliergentypeid_Noresultsfound = cgiGet( "COMBO_SUPPLIERGENTYPEID_Noresultsfound");
               Combo_suppliergentypeid_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGENTYPEID_Emptyitemtext");
               Combo_suppliergentypeid_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGENTYPEID_Onlyselectedvalues");
               Combo_suppliergentypeid_Selectalltext = cgiGet( "COMBO_SUPPLIERGENTYPEID_Selectalltext");
               Combo_suppliergentypeid_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGENTYPEID_Multiplevaluesseparator");
               Combo_suppliergentypeid_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGENTYPEID_Addnewoptiontext");
               Combo_suppliergentypeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENTYPEID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_suppliergenaddresscountry_Objectcall = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Objectcall");
               Combo_suppliergenaddresscountry_Class = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Class");
               Combo_suppliergenaddresscountry_Icontype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Icontype");
               Combo_suppliergenaddresscountry_Icon = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Icon");
               Combo_suppliergenaddresscountry_Caption = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Caption");
               Combo_suppliergenaddresscountry_Tooltip = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Tooltip");
               Combo_suppliergenaddresscountry_Cls = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Cls");
               Combo_suppliergenaddresscountry_Selectedvalue_set = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_set");
               Combo_suppliergenaddresscountry_Selectedvalue_get = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_get");
               Combo_suppliergenaddresscountry_Selectedtext_set = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedtext_set");
               Combo_suppliergenaddresscountry_Selectedtext_get = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedtext_get");
               Combo_suppliergenaddresscountry_Gamoauthtoken = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Gamoauthtoken");
               Combo_suppliergenaddresscountry_Ddointernalname = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Ddointernalname");
               Combo_suppliergenaddresscountry_Titlecontrolalign = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Titlecontrolalign");
               Combo_suppliergenaddresscountry_Dropdownoptionstype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Dropdownoptionstype");
               Combo_suppliergenaddresscountry_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Enabled"));
               Combo_suppliergenaddresscountry_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Visible"));
               Combo_suppliergenaddresscountry_Titlecontrolidtoreplace = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Titlecontrolidtoreplace");
               Combo_suppliergenaddresscountry_Datalisttype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalisttype");
               Combo_suppliergenaddresscountry_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Allowmultipleselection"));
               Combo_suppliergenaddresscountry_Datalistfixedvalues = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistfixedvalues");
               Combo_suppliergenaddresscountry_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Isgriditem"));
               Combo_suppliergenaddresscountry_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Hasdescription"));
               Combo_suppliergenaddresscountry_Datalistproc = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistproc");
               Combo_suppliergenaddresscountry_Datalistprocparametersprefix = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistprocparametersprefix");
               Combo_suppliergenaddresscountry_Remoteservicesparameters = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Remoteservicesparameters");
               Combo_suppliergenaddresscountry_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_suppliergenaddresscountry_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Includeonlyselectedoption"));
               Combo_suppliergenaddresscountry_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Includeselectalloption"));
               Combo_suppliergenaddresscountry_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Emptyitem"));
               Combo_suppliergenaddresscountry_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Includeaddnewoption"));
               Combo_suppliergenaddresscountry_Htmltemplate = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Htmltemplate");
               Combo_suppliergenaddresscountry_Multiplevaluestype = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Multiplevaluestype");
               Combo_suppliergenaddresscountry_Loadingdata = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Loadingdata");
               Combo_suppliergenaddresscountry_Noresultsfound = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Noresultsfound");
               Combo_suppliergenaddresscountry_Emptyitemtext = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Emptyitemtext");
               Combo_suppliergenaddresscountry_Onlyselectedvalues = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Onlyselectedvalues");
               Combo_suppliergenaddresscountry_Selectalltext = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectalltext");
               Combo_suppliergenaddresscountry_Multiplevaluesseparator = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Multiplevaluesseparator");
               Combo_suppliergenaddresscountry_Addnewoptiontext = cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Addnewoptiontext");
               Combo_suppliergenaddresscountry_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SUPPLIERGENADDRESSCOUNTRY_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
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
               A43SupplierGenKvkNumber = cgiGet( edtSupplierGenKvkNumber_Internalname);
               AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
               if ( StringUtil.StrCmp(cgiGet( edtSupplierGenTypeId_Internalname), "") == 0 )
               {
                  A282SupplierGenTypeId = Guid.Empty;
                  AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
               }
               else
               {
                  try
                  {
                     A282SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierGenTypeId_Internalname));
                     AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERGENTYPEID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierGenTypeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
               AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
               A47SupplierGenContactName = cgiGet( edtSupplierGenContactName_Internalname);
               AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
               A48SupplierGenContactPhone = cgiGet( edtSupplierGenContactPhone_Internalname);
               AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
               A335SupplierGenAddressCountry = cgiGet( edtSupplierGenAddressCountry_Internalname);
               AssignAttri("", false, "A335SupplierGenAddressCountry", A335SupplierGenAddressCountry);
               A295SupplierGenAddressCity = cgiGet( edtSupplierGenAddressCity_Internalname);
               AssignAttri("", false, "A295SupplierGenAddressCity", A295SupplierGenAddressCity);
               A294SupplierGenAddressZipCode = cgiGet( edtSupplierGenAddressZipCode_Internalname);
               AssignAttri("", false, "A294SupplierGenAddressZipCode", A294SupplierGenAddressZipCode);
               A336SupplierGenAddressLine1 = cgiGet( edtSupplierGenAddressLine1_Internalname);
               AssignAttri("", false, "A336SupplierGenAddressLine1", A336SupplierGenAddressLine1);
               A337SupplierGenAddressLine2 = cgiGet( edtSupplierGenAddressLine2_Internalname);
               AssignAttri("", false, "A337SupplierGenAddressLine2", A337SupplierGenAddressLine2);
               AV20ComboSupplierGenTypeId = StringUtil.StrToGuid( cgiGet( edtavCombosuppliergentypeid_Internalname));
               AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
               AV24ComboSupplierGenAddressCountry = cgiGet( edtavCombosuppliergenaddresscountry_Internalname);
               AssignAttri("", false, "AV24ComboSupplierGenAddressCountry", AV24ComboSupplierGenAddressCountry);
               if ( StringUtil.StrCmp(cgiGet( edtSupplierGenId_Internalname), "") == 0 )
               {
                  A42SupplierGenId = Guid.Empty;
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               }
               else
               {
                  try
                  {
                     A42SupplierGenId = StringUtil.StrToGuid( cgiGet( edtSupplierGenId_Internalname));
                     n42SupplierGenId = false;
                     AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SUPPLIERGENID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierGenId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_SupplierGen");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A42SupplierGenId != Z42SupplierGenId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_suppliergen:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A42SupplierGenId = StringUtil.StrToGuid( GetPar( "SupplierGenId"));
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7SupplierGenId) )
                  {
                     A42SupplierGenId = AV7SupplierGenId;
                     n42SupplierGenId = false;
                     AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A42SupplierGenId) && ( Gx_BScreen == 0 ) )
                     {
                        A42SupplierGenId = Guid.NewGuid( );
                        n42SupplierGenId = false;
                        AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
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
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7SupplierGenId) )
                     {
                        A42SupplierGenId = AV7SupplierGenId;
                        n42SupplierGenId = false;
                        AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A42SupplierGenId) && ( Gx_BScreen == 0 ) )
                        {
                           A42SupplierGenId = Guid.NewGuid( );
                           n42SupplierGenId = false;
                           AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                        }
                     }
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SUPPLIERGENID");
                        AnyError = 1;
                        GX_FocusControl = edtSupplierGenId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_SUPPLIERGENTYPEID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_suppliergentypeid.Onoptionclicked */
                           E12062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13062 ();
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
            E13062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll069( ) ;
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
            DisableAttributes069( ) ;
         }
         AssignProp("", false, edtavCombosuppliergentypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergentypeid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosuppliergenaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenaddresscountry_Enabled), 5, 0), true);
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

      protected void CONFIRM_060( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls069( ) ;
            }
            else
            {
               CheckExtendedTable069( ) ;
               CloseExtendedTableCursors069( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtSupplierGenAddressCountry_Visible = 0;
         AssignProp("", false, edtSupplierGenAddressCountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressCountry_Visible), 5, 0), true);
         AV24ComboSupplierGenAddressCountry = "";
         AssignAttri("", false, "AV24ComboSupplierGenAddressCountry", AV24ComboSupplierGenAddressCountry);
         edtavCombosuppliergenaddresscountry_Visible = 0;
         AssignProp("", false, edtavCombosuppliergenaddresscountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenaddresscountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_suppliergenaddresscountry_Htmltemplate = GXt_char2;
         ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "HTMLTemplate", Combo_suppliergenaddresscountry_Htmltemplate);
         edtSupplierGenTypeId_Visible = 0;
         AssignProp("", false, edtSupplierGenTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Visible), 5, 0), true);
         AV20ComboSupplierGenTypeId = Guid.Empty;
         AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
         edtavCombosuppliergentypeid_Visible = 0;
         AssignProp("", false, edtavCombosuppliergentypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergentypeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENTYPEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSUPPLIERGENADDRESSCOUNTRY' */
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SupplierGenTypeId") == 0 )
               {
                  AV13Insert_SupplierGenTypeId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_SupplierGenTypeId", AV13Insert_SupplierGenTypeId.ToString());
                  if ( ! (Guid.Empty==AV13Insert_SupplierGenTypeId) )
                  {
                     AV20ComboSupplierGenTypeId = AV13Insert_SupplierGenTypeId;
                     AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
                     Combo_suppliergentypeid_Selectedvalue_set = StringUtil.Trim( AV20ComboSupplierGenTypeId.ToString());
                     ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "SelectedValue_set", Combo_suppliergentypeid_Selectedvalue_set);
                     Combo_suppliergentypeid_Enabled = false;
                     ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergentypeid_Enabled));
                  }
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
         edtSupplierGenId_Visible = 0;
         AssignProp("", false, edtSupplierGenId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            Combo_suppliergenaddresscountry_Selectedtext_set = "Netherlands";
            ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "SelectedText_set", Combo_suppliergenaddresscountry_Selectedtext_set);
            Combo_suppliergenaddresscountry_Selectedvalue_set = "Netherlands";
            ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "SelectedValue_set", Combo_suppliergenaddresscountry_Selectedvalue_set);
         }
      }

      protected void E13062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_suppliergenww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E12062( )
      {
         /* Combo_suppliergentypeid_Onoptionclicked Routine */
         returnInSub = false;
         AV20ComboSupplierGenTypeId = StringUtil.StrToGuid( Combo_suppliergentypeid_Selectedvalue_get);
         AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSUPPLIERGENADDRESSCOUNTRY' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV23SupplierGenAddressCountry_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenAddressCountry",  Gx_mode,  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV23SupplierGenAddressCountry_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
         Combo_suppliergenaddresscountry_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "SelectedValue_set", Combo_suppliergenaddresscountry_Selectedvalue_set);
         AV24ComboSupplierGenAddressCountry = AV17ComboSelectedValue;
         AssignAttri("", false, "AV24ComboSupplierGenAddressCountry", AV24ComboSupplierGenAddressCountry);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergenaddresscountry_Enabled = false;
            ucCombo_suppliergenaddresscountry.SendProperty(context, "", false, Combo_suppliergenaddresscountry_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergenaddresscountry_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOSUPPLIERGENTYPEID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV15SupplierGenTypeId_Data;
         new trn_suppliergenloaddvcombo(context ).execute(  "SupplierGenTypeId",  Gx_mode,  AV7SupplierGenId, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV15SupplierGenTypeId_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
         Combo_suppliergentypeid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "SelectedValue_set", Combo_suppliergentypeid_Selectedvalue_set);
         AV20ComboSupplierGenTypeId = StringUtil.StrToGuid( AV17ComboSelectedValue);
         AssignAttri("", false, "AV20ComboSupplierGenTypeId", AV20ComboSupplierGenTypeId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_suppliergentypeid_Enabled = false;
            ucCombo_suppliergentypeid.SendProperty(context, "", false, Combo_suppliergentypeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_suppliergentypeid_Enabled));
         }
      }

      protected void ZM069( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z335SupplierGenAddressCountry = T00063_A335SupplierGenAddressCountry[0];
               Z43SupplierGenKvkNumber = T00063_A43SupplierGenKvkNumber[0];
               Z44SupplierGenCompanyName = T00063_A44SupplierGenCompanyName[0];
               Z295SupplierGenAddressCity = T00063_A295SupplierGenAddressCity[0];
               Z294SupplierGenAddressZipCode = T00063_A294SupplierGenAddressZipCode[0];
               Z336SupplierGenAddressLine1 = T00063_A336SupplierGenAddressLine1[0];
               Z337SupplierGenAddressLine2 = T00063_A337SupplierGenAddressLine2[0];
               Z47SupplierGenContactName = T00063_A47SupplierGenContactName[0];
               Z48SupplierGenContactPhone = T00063_A48SupplierGenContactPhone[0];
               Z282SupplierGenTypeId = T00063_A282SupplierGenTypeId[0];
            }
            else
            {
               Z335SupplierGenAddressCountry = A335SupplierGenAddressCountry;
               Z43SupplierGenKvkNumber = A43SupplierGenKvkNumber;
               Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
               Z295SupplierGenAddressCity = A295SupplierGenAddressCity;
               Z294SupplierGenAddressZipCode = A294SupplierGenAddressZipCode;
               Z336SupplierGenAddressLine1 = A336SupplierGenAddressLine1;
               Z337SupplierGenAddressLine2 = A337SupplierGenAddressLine2;
               Z47SupplierGenContactName = A47SupplierGenContactName;
               Z48SupplierGenContactPhone = A48SupplierGenContactPhone;
               Z282SupplierGenTypeId = A282SupplierGenTypeId;
            }
         }
         if ( GX_JID == -15 )
         {
            Z42SupplierGenId = A42SupplierGenId;
            Z335SupplierGenAddressCountry = A335SupplierGenAddressCountry;
            Z43SupplierGenKvkNumber = A43SupplierGenKvkNumber;
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
            Z295SupplierGenAddressCity = A295SupplierGenAddressCity;
            Z294SupplierGenAddressZipCode = A294SupplierGenAddressZipCode;
            Z336SupplierGenAddressLine1 = A336SupplierGenAddressLine1;
            Z337SupplierGenAddressLine2 = A337SupplierGenAddressLine2;
            Z47SupplierGenContactName = A47SupplierGenContactName;
            Z48SupplierGenContactPhone = A48SupplierGenContactPhone;
            Z282SupplierGenTypeId = A282SupplierGenTypeId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV25Pgmname = "Trn_SupplierGen";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7SupplierGenId) )
         {
            edtSupplierGenId_Enabled = 0;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierGenId_Enabled = 1;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7SupplierGenId) )
         {
            edtSupplierGenId_Enabled = 0;
            AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_SupplierGenTypeId) )
         {
            edtSupplierGenTypeId_Enabled = 0;
            AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierGenTypeId_Enabled = 1;
            AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_SupplierGenTypeId) )
         {
            A282SupplierGenTypeId = AV13Insert_SupplierGenTypeId;
            AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
         }
         else
         {
            A282SupplierGenTypeId = AV20ComboSupplierGenTypeId;
            AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
         }
         A335SupplierGenAddressCountry = AV24ComboSupplierGenAddressCountry;
         AssignAttri("", false, "A335SupplierGenAddressCountry", A335SupplierGenAddressCountry);
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
         if ( ! (Guid.Empty==AV7SupplierGenId) )
         {
            A42SupplierGenId = AV7SupplierGenId;
            n42SupplierGenId = false;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A42SupplierGenId) && ( Gx_BScreen == 0 ) )
            {
               A42SupplierGenId = Guid.NewGuid( );
               n42SupplierGenId = false;
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load069( )
      {
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A335SupplierGenAddressCountry = T00065_A335SupplierGenAddressCountry[0];
            AssignAttri("", false, "A335SupplierGenAddressCountry", A335SupplierGenAddressCountry);
            A43SupplierGenKvkNumber = T00065_A43SupplierGenKvkNumber[0];
            AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
            A44SupplierGenCompanyName = T00065_A44SupplierGenCompanyName[0];
            AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
            A295SupplierGenAddressCity = T00065_A295SupplierGenAddressCity[0];
            AssignAttri("", false, "A295SupplierGenAddressCity", A295SupplierGenAddressCity);
            A294SupplierGenAddressZipCode = T00065_A294SupplierGenAddressZipCode[0];
            AssignAttri("", false, "A294SupplierGenAddressZipCode", A294SupplierGenAddressZipCode);
            A336SupplierGenAddressLine1 = T00065_A336SupplierGenAddressLine1[0];
            AssignAttri("", false, "A336SupplierGenAddressLine1", A336SupplierGenAddressLine1);
            A337SupplierGenAddressLine2 = T00065_A337SupplierGenAddressLine2[0];
            AssignAttri("", false, "A337SupplierGenAddressLine2", A337SupplierGenAddressLine2);
            A47SupplierGenContactName = T00065_A47SupplierGenContactName[0];
            AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
            A48SupplierGenContactPhone = T00065_A48SupplierGenContactPhone[0];
            AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
            A282SupplierGenTypeId = T00065_A282SupplierGenTypeId[0];
            AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
            ZM069( -15) ;
         }
         pr_default.close(3);
         OnLoadActions069( ) ;
      }

      protected void OnLoadActions069( )
      {
      }

      protected void CheckExtendedTable069( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A43SupplierGenKvkNumber)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Supplier Gen Kvk Number", "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENKVKNUMBER");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A282SupplierGenTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_SupplierGenType'.", "ForeignKeyNotFound", 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( (Guid.Empty==A282SupplierGenTypeId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Supplier Gen Type Id", "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A44SupplierGenCompanyName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Supplier Gen Company Name", "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENCOMPANYNAME");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenCompanyName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors069( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( Guid A282SupplierGenTypeId )
      {
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A282SupplierGenTypeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_SupplierGenType'.", "ForeignKeyNotFound", 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
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

      protected void GetKey069( )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM069( 15) ;
            RcdFound9 = 1;
            A42SupplierGenId = T00063_A42SupplierGenId[0];
            n42SupplierGenId = T00063_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            A335SupplierGenAddressCountry = T00063_A335SupplierGenAddressCountry[0];
            AssignAttri("", false, "A335SupplierGenAddressCountry", A335SupplierGenAddressCountry);
            A43SupplierGenKvkNumber = T00063_A43SupplierGenKvkNumber[0];
            AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
            A44SupplierGenCompanyName = T00063_A44SupplierGenCompanyName[0];
            AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
            A295SupplierGenAddressCity = T00063_A295SupplierGenAddressCity[0];
            AssignAttri("", false, "A295SupplierGenAddressCity", A295SupplierGenAddressCity);
            A294SupplierGenAddressZipCode = T00063_A294SupplierGenAddressZipCode[0];
            AssignAttri("", false, "A294SupplierGenAddressZipCode", A294SupplierGenAddressZipCode);
            A336SupplierGenAddressLine1 = T00063_A336SupplierGenAddressLine1[0];
            AssignAttri("", false, "A336SupplierGenAddressLine1", A336SupplierGenAddressLine1);
            A337SupplierGenAddressLine2 = T00063_A337SupplierGenAddressLine2[0];
            AssignAttri("", false, "A337SupplierGenAddressLine2", A337SupplierGenAddressLine2);
            A47SupplierGenContactName = T00063_A47SupplierGenContactName[0];
            AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
            A48SupplierGenContactPhone = T00063_A48SupplierGenContactPhone[0];
            AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
            A282SupplierGenTypeId = T00063_A282SupplierGenTypeId[0];
            AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
            Z42SupplierGenId = A42SupplierGenId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load069( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey069( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey069( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey069( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00068_A42SupplierGenId[0], A42SupplierGenId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00068_A42SupplierGenId[0], A42SupplierGenId, 0) > 0 ) ) )
            {
               A42SupplierGenId = T00068_A42SupplierGenId[0];
               n42SupplierGenId = T00068_n42SupplierGenId[0];
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               RcdFound9 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00069_A42SupplierGenId[0], A42SupplierGenId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00069_A42SupplierGenId[0], A42SupplierGenId, 0) < 0 ) ) )
            {
               A42SupplierGenId = T00069_A42SupplierGenId[0];
               n42SupplierGenId = T00069_n42SupplierGenId[0];
               AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
               RcdFound9 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey069( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert069( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A42SupplierGenId != Z42SupplierGenId )
               {
                  A42SupplierGenId = Z42SupplierGenId;
                  n42SupplierGenId = false;
                  AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUPPLIERGENID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierGenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update069( ) ;
                  GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A42SupplierGenId != Z42SupplierGenId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert069( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUPPLIERGENID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierGenId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert069( ) ;
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
         if ( A42SupplierGenId != Z42SupplierGenId )
         {
            A42SupplierGenId = Z42SupplierGenId;
            n42SupplierGenId = false;
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUPPLIERGENID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSupplierGenKvkNumber_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency069( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGen"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z335SupplierGenAddressCountry, T00062_A335SupplierGenAddressCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z43SupplierGenKvkNumber, T00062_A43SupplierGenKvkNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z44SupplierGenCompanyName, T00062_A44SupplierGenCompanyName[0]) != 0 ) || ( StringUtil.StrCmp(Z295SupplierGenAddressCity, T00062_A295SupplierGenAddressCity[0]) != 0 ) || ( StringUtil.StrCmp(Z294SupplierGenAddressZipCode, T00062_A294SupplierGenAddressZipCode[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z336SupplierGenAddressLine1, T00062_A336SupplierGenAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z337SupplierGenAddressLine2, T00062_A337SupplierGenAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z47SupplierGenContactName, T00062_A47SupplierGenContactName[0]) != 0 ) || ( StringUtil.StrCmp(Z48SupplierGenContactPhone, T00062_A48SupplierGenContactPhone[0]) != 0 ) || ( Z282SupplierGenTypeId != T00062_A282SupplierGenTypeId[0] ) )
            {
               if ( StringUtil.StrCmp(Z335SupplierGenAddressCountry, T00062_A335SupplierGenAddressCountry[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressCountry");
                  GXUtil.WriteLogRaw("Old: ",Z335SupplierGenAddressCountry);
                  GXUtil.WriteLogRaw("Current: ",T00062_A335SupplierGenAddressCountry[0]);
               }
               if ( StringUtil.StrCmp(Z43SupplierGenKvkNumber, T00062_A43SupplierGenKvkNumber[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenKvkNumber");
                  GXUtil.WriteLogRaw("Old: ",Z43SupplierGenKvkNumber);
                  GXUtil.WriteLogRaw("Current: ",T00062_A43SupplierGenKvkNumber[0]);
               }
               if ( StringUtil.StrCmp(Z44SupplierGenCompanyName, T00062_A44SupplierGenCompanyName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenCompanyName");
                  GXUtil.WriteLogRaw("Old: ",Z44SupplierGenCompanyName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A44SupplierGenCompanyName[0]);
               }
               if ( StringUtil.StrCmp(Z295SupplierGenAddressCity, T00062_A295SupplierGenAddressCity[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressCity");
                  GXUtil.WriteLogRaw("Old: ",Z295SupplierGenAddressCity);
                  GXUtil.WriteLogRaw("Current: ",T00062_A295SupplierGenAddressCity[0]);
               }
               if ( StringUtil.StrCmp(Z294SupplierGenAddressZipCode, T00062_A294SupplierGenAddressZipCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressZipCode");
                  GXUtil.WriteLogRaw("Old: ",Z294SupplierGenAddressZipCode);
                  GXUtil.WriteLogRaw("Current: ",T00062_A294SupplierGenAddressZipCode[0]);
               }
               if ( StringUtil.StrCmp(Z336SupplierGenAddressLine1, T00062_A336SupplierGenAddressLine1[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressLine1");
                  GXUtil.WriteLogRaw("Old: ",Z336SupplierGenAddressLine1);
                  GXUtil.WriteLogRaw("Current: ",T00062_A336SupplierGenAddressLine1[0]);
               }
               if ( StringUtil.StrCmp(Z337SupplierGenAddressLine2, T00062_A337SupplierGenAddressLine2[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenAddressLine2");
                  GXUtil.WriteLogRaw("Old: ",Z337SupplierGenAddressLine2);
                  GXUtil.WriteLogRaw("Current: ",T00062_A337SupplierGenAddressLine2[0]);
               }
               if ( StringUtil.StrCmp(Z47SupplierGenContactName, T00062_A47SupplierGenContactName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenContactName");
                  GXUtil.WriteLogRaw("Old: ",Z47SupplierGenContactName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A47SupplierGenContactName[0]);
               }
               if ( StringUtil.StrCmp(Z48SupplierGenContactPhone, T00062_A48SupplierGenContactPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenContactPhone");
                  GXUtil.WriteLogRaw("Old: ",Z48SupplierGenContactPhone);
                  GXUtil.WriteLogRaw("Current: ",T00062_A48SupplierGenContactPhone[0]);
               }
               if ( Z282SupplierGenTypeId != T00062_A282SupplierGenTypeId[0] )
               {
                  GXUtil.WriteLog("trn_suppliergen:[seudo value changed for attri]"+"SupplierGenTypeId");
                  GXUtil.WriteLogRaw("Old: ",Z282SupplierGenTypeId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A282SupplierGenTypeId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierGen"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert069( )
      {
         if ( ! IsAuthorized("trn_suppliergen_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM069( 0) ;
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000610 */
                     pr_default.execute(8, new Object[] {n42SupplierGenId, A42SupplierGenId, A335SupplierGenAddressCountry, A43SupplierGenKvkNumber, A44SupplierGenCompanyName, A295SupplierGenAddressCity, A294SupplierGenAddressZipCode, A336SupplierGenAddressLine1, A337SupplierGenAddressLine2, A47SupplierGenContactName, A48SupplierGenContactPhone, A282SupplierGenTypeId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
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
               Load069( ) ;
            }
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void Update069( )
      {
         if ( ! IsAuthorized("trn_suppliergen_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000611 */
                     pr_default.execute(9, new Object[] {A335SupplierGenAddressCountry, A43SupplierGenKvkNumber, A44SupplierGenCompanyName, A295SupplierGenAddressCity, A294SupplierGenAddressZipCode, A336SupplierGenAddressLine1, A337SupplierGenAddressLine2, A47SupplierGenContactName, A48SupplierGenContactPhone, A282SupplierGenTypeId, n42SupplierGenId, A42SupplierGenId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGen"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate069( ) ;
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
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void DeferredUpdate069( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_suppliergen_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls069( ) ;
            AfterConfirm069( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete069( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000612 */
                  pr_default.execute(10, new Object[] {n42SupplierGenId, A42SupplierGenId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGen");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel069( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls069( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000613 */
            pr_default.execute(11, new Object[] {n42SupplierGenId, A42SupplierGenId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Trn_ProductService"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel069( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete069( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_suppliergen",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_suppliergen",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart069( )
      {
         /* Scan By routine */
         /* Using cursor T000614 */
         pr_default.execute(12);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound9 = 1;
            A42SupplierGenId = T000614_A42SupplierGenId[0];
            n42SupplierGenId = T000614_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext069( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound9 = 1;
            A42SupplierGenId = T000614_A42SupplierGenId[0];
            n42SupplierGenId = T000614_n42SupplierGenId[0];
            AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         }
      }

      protected void ScanEnd069( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm069( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert069( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate069( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete069( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete069( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate069( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes069( )
      {
         edtSupplierGenKvkNumber_Enabled = 0;
         AssignProp("", false, edtSupplierGenKvkNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenKvkNumber_Enabled), 5, 0), true);
         edtSupplierGenTypeId_Enabled = 0;
         AssignProp("", false, edtSupplierGenTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeId_Enabled), 5, 0), true);
         edtSupplierGenCompanyName_Enabled = 0;
         AssignProp("", false, edtSupplierGenCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenCompanyName_Enabled), 5, 0), true);
         edtSupplierGenContactName_Enabled = 0;
         AssignProp("", false, edtSupplierGenContactName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactName_Enabled), 5, 0), true);
         edtSupplierGenContactPhone_Enabled = 0;
         AssignProp("", false, edtSupplierGenContactPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactPhone_Enabled), 5, 0), true);
         edtSupplierGenAddressCountry_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressCountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressCountry_Enabled), 5, 0), true);
         edtSupplierGenAddressCity_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressCity_Enabled), 5, 0), true);
         edtSupplierGenAddressZipCode_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressZipCode_Enabled), 5, 0), true);
         edtSupplierGenAddressLine1_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressLine1_Enabled), 5, 0), true);
         edtSupplierGenAddressLine2_Enabled = 0;
         AssignProp("", false, edtSupplierGenAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenAddressLine2_Enabled), 5, 0), true);
         edtavCombosuppliergentypeid_Enabled = 0;
         AssignProp("", false, edtavCombosuppliergentypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergentypeid_Enabled), 5, 0), true);
         edtavCombosuppliergenaddresscountry_Enabled = 0;
         AssignProp("", false, edtavCombosuppliergenaddresscountry_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosuppliergenaddresscountry_Enabled), 5, 0), true);
         edtSupplierGenId_Enabled = 0;
         AssignProp("", false, edtSupplierGenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierGenId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes069( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7SupplierGenId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_SupplierGen");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_suppliergen:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z42SupplierGenId", Z42SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "Z335SupplierGenAddressCountry", Z335SupplierGenAddressCountry);
         GxWebStd.gx_hidden_field( context, "Z43SupplierGenKvkNumber", Z43SupplierGenKvkNumber);
         GxWebStd.gx_hidden_field( context, "Z44SupplierGenCompanyName", Z44SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "Z295SupplierGenAddressCity", Z295SupplierGenAddressCity);
         GxWebStd.gx_hidden_field( context, "Z294SupplierGenAddressZipCode", Z294SupplierGenAddressZipCode);
         GxWebStd.gx_hidden_field( context, "Z336SupplierGenAddressLine1", Z336SupplierGenAddressLine1);
         GxWebStd.gx_hidden_field( context, "Z337SupplierGenAddressLine2", Z337SupplierGenAddressLine2);
         GxWebStd.gx_hidden_field( context, "Z47SupplierGenContactName", Z47SupplierGenContactName);
         GxWebStd.gx_hidden_field( context, "Z48SupplierGenContactPhone", StringUtil.RTrim( Z48SupplierGenContactPhone));
         GxWebStd.gx_hidden_field( context, "Z282SupplierGenTypeId", Z282SupplierGenTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENTYPEID_DATA", AV15SupplierGenTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENTYPEID_DATA", AV15SupplierGenTypeId_Data);
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERGENADDRESSCOUNTRY_DATA", AV23SupplierGenAddressCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERGENADDRESSCOUNTRY_DATA", AV23SupplierGenAddressCountry_Data);
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
         GxWebStd.gx_hidden_field( context, "vSUPPLIERGENID", AV7SupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERGENID", GetSecureSignedToken( "", AV7SupplierGenId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERGENTYPEID", AV13Insert_SupplierGenTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Objectcall", StringUtil.RTrim( Combo_suppliergentypeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Cls", StringUtil.RTrim( Combo_suppliergentypeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergentypeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Enabled", StringUtil.BoolToStr( Combo_suppliergentypeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENTYPEID_Emptyitem", StringUtil.BoolToStr( Combo_suppliergentypeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Objectcall", StringUtil.RTrim( Combo_suppliergenaddresscountry_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Cls", StringUtil.RTrim( Combo_suppliergenaddresscountry_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedvalue_set", StringUtil.RTrim( Combo_suppliergenaddresscountry_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Selectedtext_set", StringUtil.RTrim( Combo_suppliergenaddresscountry_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Enabled", StringUtil.BoolToStr( Combo_suppliergenaddresscountry_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Emptyitem", StringUtil.BoolToStr( Combo_suppliergenaddresscountry_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_SUPPLIERGENADDRESSCOUNTRY_Htmltemplate", StringUtil.RTrim( Combo_suppliergenaddresscountry_Htmltemplate));
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
         GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7SupplierGenId.ToString());
         return formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_SupplierGen" ;
      }

      public override string GetPgmdesc( )
      {
         return "General Suppliers" ;
      }

      protected void InitializeNonKey069( )
      {
         A282SupplierGenTypeId = Guid.Empty;
         AssignAttri("", false, "A282SupplierGenTypeId", A282SupplierGenTypeId.ToString());
         A335SupplierGenAddressCountry = "";
         AssignAttri("", false, "A335SupplierGenAddressCountry", A335SupplierGenAddressCountry);
         A43SupplierGenKvkNumber = "";
         AssignAttri("", false, "A43SupplierGenKvkNumber", A43SupplierGenKvkNumber);
         A44SupplierGenCompanyName = "";
         AssignAttri("", false, "A44SupplierGenCompanyName", A44SupplierGenCompanyName);
         A295SupplierGenAddressCity = "";
         AssignAttri("", false, "A295SupplierGenAddressCity", A295SupplierGenAddressCity);
         A294SupplierGenAddressZipCode = "";
         AssignAttri("", false, "A294SupplierGenAddressZipCode", A294SupplierGenAddressZipCode);
         A336SupplierGenAddressLine1 = "";
         AssignAttri("", false, "A336SupplierGenAddressLine1", A336SupplierGenAddressLine1);
         A337SupplierGenAddressLine2 = "";
         AssignAttri("", false, "A337SupplierGenAddressLine2", A337SupplierGenAddressLine2);
         A47SupplierGenContactName = "";
         AssignAttri("", false, "A47SupplierGenContactName", A47SupplierGenContactName);
         A48SupplierGenContactPhone = "";
         AssignAttri("", false, "A48SupplierGenContactPhone", A48SupplierGenContactPhone);
         Z335SupplierGenAddressCountry = "";
         Z43SupplierGenKvkNumber = "";
         Z44SupplierGenCompanyName = "";
         Z295SupplierGenAddressCity = "";
         Z294SupplierGenAddressZipCode = "";
         Z336SupplierGenAddressLine1 = "";
         Z337SupplierGenAddressLine2 = "";
         Z47SupplierGenContactName = "";
         Z48SupplierGenContactPhone = "";
         Z282SupplierGenTypeId = Guid.Empty;
      }

      protected void InitAll069( )
      {
         A42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         AssignAttri("", false, "A42SupplierGenId", A42SupplierGenId.ToString());
         InitializeNonKey069( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202492719461937", true, true);
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
         context.AddJavascriptSource("trn_suppliergen.js", "?202492719461939", false, true);
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
         edtSupplierGenKvkNumber_Internalname = "SUPPLIERGENKVKNUMBER";
         lblTextblocksuppliergentypeid_Internalname = "TEXTBLOCKSUPPLIERGENTYPEID";
         Combo_suppliergentypeid_Internalname = "COMBO_SUPPLIERGENTYPEID";
         edtSupplierGenTypeId_Internalname = "SUPPLIERGENTYPEID";
         divTablesplittedsuppliergentypeid_Internalname = "TABLESPLITTEDSUPPLIERGENTYPEID";
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME";
         edtSupplierGenContactName_Internalname = "SUPPLIERGENCONTACTNAME";
         edtSupplierGenContactPhone_Internalname = "SUPPLIERGENCONTACTPHONE";
         lblTextblocksuppliergenaddresscountry_Internalname = "TEXTBLOCKSUPPLIERGENADDRESSCOUNTRY";
         Combo_suppliergenaddresscountry_Internalname = "COMBO_SUPPLIERGENADDRESSCOUNTRY";
         edtSupplierGenAddressCountry_Internalname = "SUPPLIERGENADDRESSCOUNTRY";
         divTablesplittedsuppliergenaddresscountry_Internalname = "TABLESPLITTEDSUPPLIERGENADDRESSCOUNTRY";
         edtSupplierGenAddressCity_Internalname = "SUPPLIERGENADDRESSCITY";
         edtSupplierGenAddressZipCode_Internalname = "SUPPLIERGENADDRESSZIPCODE";
         edtSupplierGenAddressLine1_Internalname = "SUPPLIERGENADDRESSLINE1";
         edtSupplierGenAddressLine2_Internalname = "SUPPLIERGENADDRESSLINE2";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombosuppliergentypeid_Internalname = "vCOMBOSUPPLIERGENTYPEID";
         divSectionattribute_suppliergentypeid_Internalname = "SECTIONATTRIBUTE_SUPPLIERGENTYPEID";
         edtavCombosuppliergenaddresscountry_Internalname = "vCOMBOSUPPLIERGENADDRESSCOUNTRY";
         divSectionattribute_suppliergenaddresscountry_Internalname = "SECTIONATTRIBUTE_SUPPLIERGENADDRESSCOUNTRY";
         edtSupplierGenId_Internalname = "SUPPLIERGENID";
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
         Form.Caption = "General Suppliers";
         Combo_suppliergenaddresscountry_Htmltemplate = "";
         edtSupplierGenId_Jsonclick = "";
         edtSupplierGenId_Enabled = 1;
         edtSupplierGenId_Visible = 1;
         edtavCombosuppliergenaddresscountry_Jsonclick = "";
         edtavCombosuppliergenaddresscountry_Enabled = 0;
         edtavCombosuppliergenaddresscountry_Visible = 1;
         edtavCombosuppliergentypeid_Jsonclick = "";
         edtavCombosuppliergentypeid_Enabled = 0;
         edtavCombosuppliergentypeid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSupplierGenAddressLine2_Jsonclick = "";
         edtSupplierGenAddressLine2_Enabled = 1;
         edtSupplierGenAddressLine1_Jsonclick = "";
         edtSupplierGenAddressLine1_Enabled = 1;
         edtSupplierGenAddressZipCode_Jsonclick = "";
         edtSupplierGenAddressZipCode_Enabled = 1;
         edtSupplierGenAddressCity_Jsonclick = "";
         edtSupplierGenAddressCity_Enabled = 1;
         edtSupplierGenAddressCountry_Jsonclick = "";
         edtSupplierGenAddressCountry_Enabled = 1;
         edtSupplierGenAddressCountry_Visible = 1;
         Combo_suppliergenaddresscountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergenaddresscountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_suppliergenaddresscountry_Caption = "";
         Combo_suppliergenaddresscountry_Enabled = Convert.ToBoolean( -1);
         edtSupplierGenContactPhone_Jsonclick = "";
         edtSupplierGenContactPhone_Enabled = 1;
         edtSupplierGenContactName_Jsonclick = "";
         edtSupplierGenContactName_Enabled = 1;
         edtSupplierGenCompanyName_Jsonclick = "";
         edtSupplierGenCompanyName_Enabled = 1;
         edtSupplierGenTypeId_Jsonclick = "";
         edtSupplierGenTypeId_Enabled = 1;
         edtSupplierGenTypeId_Visible = 1;
         Combo_suppliergentypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_suppliergentypeid_Cls = "ExtendedCombo Attribute";
         Combo_suppliergentypeid_Enabled = Convert.ToBoolean( -1);
         edtSupplierGenKvkNumber_Jsonclick = "";
         edtSupplierGenKvkNumber_Enabled = 1;
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

      public void Valid_Suppliergentypeid( )
      {
         /* Using cursor T000615 */
         pr_default.execute(13, new Object[] {A282SupplierGenTypeId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No matching 'Trn_SupplierGenType'.", "ForeignKeyNotFound", 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
         }
         pr_default.close(13);
         if ( (Guid.Empty==A282SupplierGenTypeId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Supplier Gen Type Id", "", "", "", "", "", "", "", ""), 1, "SUPPLIERGENTYPEID");
            AnyError = 1;
            GX_FocusControl = edtSupplierGenTypeId_Internalname;
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7SupplierGenId","fld":"vSUPPLIERGENID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7SupplierGenId","fld":"vSUPPLIERGENID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E13062","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_SUPPLIERGENTYPEID.ONOPTIONCLICKED","""{"handler":"E12062","iparms":[{"av":"Combo_suppliergentypeid_Selectedvalue_get","ctrl":"COMBO_SUPPLIERGENTYPEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SUPPLIERGENTYPEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV20ComboSupplierGenTypeId","fld":"vCOMBOSUPPLIERGENTYPEID"}]}""");
         setEventMetadata("VALID_SUPPLIERGENKVKNUMBER","""{"handler":"Valid_Suppliergenkvknumber","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENTYPEID","""{"handler":"Valid_Suppliergentypeid","iparms":[{"av":"A282SupplierGenTypeId","fld":"SUPPLIERGENTYPEID"}]}""");
         setEventMetadata("VALID_SUPPLIERGENCOMPANYNAME","""{"handler":"Valid_Suppliergencompanyname","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENTYPEID","""{"handler":"Validv_Combosuppliergentypeid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSUPPLIERGENADDRESSCOUNTRY","""{"handler":"Validv_Combosuppliergenaddresscountry","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENID","""{"handler":"Valid_Suppliergenid","iparms":[]}""");
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
         wcpOAV7SupplierGenId = Guid.Empty;
         Z42SupplierGenId = Guid.Empty;
         Z335SupplierGenAddressCountry = "";
         Z43SupplierGenKvkNumber = "";
         Z44SupplierGenCompanyName = "";
         Z295SupplierGenAddressCity = "";
         Z294SupplierGenAddressZipCode = "";
         Z336SupplierGenAddressLine1 = "";
         Z337SupplierGenAddressLine2 = "";
         Z47SupplierGenContactName = "";
         Z48SupplierGenContactPhone = "";
         Z282SupplierGenTypeId = Guid.Empty;
         N282SupplierGenTypeId = Guid.Empty;
         Combo_suppliergenaddresscountry_Selectedvalue_get = "";
         Combo_suppliergentypeid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A282SupplierGenTypeId = Guid.Empty;
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
         A43SupplierGenKvkNumber = "";
         lblTextblocksuppliergentypeid_Jsonclick = "";
         ucCombo_suppliergentypeid = new GXUserControl();
         Combo_suppliergentypeid_Caption = "";
         AV15SupplierGenTypeId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A44SupplierGenCompanyName = "";
         A47SupplierGenContactName = "";
         gxphoneLink = "";
         A48SupplierGenContactPhone = "";
         lblTextblocksuppliergenaddresscountry_Jsonclick = "";
         ucCombo_suppliergenaddresscountry = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV23SupplierGenAddressCountry_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A335SupplierGenAddressCountry = "";
         A295SupplierGenAddressCity = "";
         A294SupplierGenAddressZipCode = "";
         A336SupplierGenAddressLine1 = "";
         A337SupplierGenAddressLine2 = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV20ComboSupplierGenTypeId = Guid.Empty;
         AV24ComboSupplierGenAddressCountry = "";
         A42SupplierGenId = Guid.Empty;
         AV13Insert_SupplierGenTypeId = Guid.Empty;
         AV25Pgmname = "";
         Combo_suppliergentypeid_Objectcall = "";
         Combo_suppliergentypeid_Class = "";
         Combo_suppliergentypeid_Icontype = "";
         Combo_suppliergentypeid_Icon = "";
         Combo_suppliergentypeid_Tooltip = "";
         Combo_suppliergentypeid_Selectedvalue_set = "";
         Combo_suppliergentypeid_Selectedtext_set = "";
         Combo_suppliergentypeid_Selectedtext_get = "";
         Combo_suppliergentypeid_Gamoauthtoken = "";
         Combo_suppliergentypeid_Ddointernalname = "";
         Combo_suppliergentypeid_Titlecontrolalign = "";
         Combo_suppliergentypeid_Dropdownoptionstype = "";
         Combo_suppliergentypeid_Titlecontrolidtoreplace = "";
         Combo_suppliergentypeid_Datalisttype = "";
         Combo_suppliergentypeid_Datalistfixedvalues = "";
         Combo_suppliergentypeid_Datalistproc = "";
         Combo_suppliergentypeid_Datalistprocparametersprefix = "";
         Combo_suppliergentypeid_Remoteservicesparameters = "";
         Combo_suppliergentypeid_Htmltemplate = "";
         Combo_suppliergentypeid_Multiplevaluestype = "";
         Combo_suppliergentypeid_Loadingdata = "";
         Combo_suppliergentypeid_Noresultsfound = "";
         Combo_suppliergentypeid_Emptyitemtext = "";
         Combo_suppliergentypeid_Onlyselectedvalues = "";
         Combo_suppliergentypeid_Selectalltext = "";
         Combo_suppliergentypeid_Multiplevaluesseparator = "";
         Combo_suppliergentypeid_Addnewoptiontext = "";
         Combo_suppliergenaddresscountry_Objectcall = "";
         Combo_suppliergenaddresscountry_Class = "";
         Combo_suppliergenaddresscountry_Icontype = "";
         Combo_suppliergenaddresscountry_Icon = "";
         Combo_suppliergenaddresscountry_Tooltip = "";
         Combo_suppliergenaddresscountry_Selectedvalue_set = "";
         Combo_suppliergenaddresscountry_Selectedtext_set = "";
         Combo_suppliergenaddresscountry_Selectedtext_get = "";
         Combo_suppliergenaddresscountry_Gamoauthtoken = "";
         Combo_suppliergenaddresscountry_Ddointernalname = "";
         Combo_suppliergenaddresscountry_Titlecontrolalign = "";
         Combo_suppliergenaddresscountry_Dropdownoptionstype = "";
         Combo_suppliergenaddresscountry_Titlecontrolidtoreplace = "";
         Combo_suppliergenaddresscountry_Datalisttype = "";
         Combo_suppliergenaddresscountry_Datalistfixedvalues = "";
         Combo_suppliergenaddresscountry_Datalistproc = "";
         Combo_suppliergenaddresscountry_Datalistprocparametersprefix = "";
         Combo_suppliergenaddresscountry_Remoteservicesparameters = "";
         Combo_suppliergenaddresscountry_Multiplevaluestype = "";
         Combo_suppliergenaddresscountry_Loadingdata = "";
         Combo_suppliergenaddresscountry_Noresultsfound = "";
         Combo_suppliergenaddresscountry_Emptyitemtext = "";
         Combo_suppliergenaddresscountry_Onlyselectedvalues = "";
         Combo_suppliergenaddresscountry_Selectalltext = "";
         Combo_suppliergenaddresscountry_Multiplevaluesseparator = "";
         Combo_suppliergenaddresscountry_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
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
         T00065_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00065_n42SupplierGenId = new bool[] {false} ;
         T00065_A335SupplierGenAddressCountry = new string[] {""} ;
         T00065_A43SupplierGenKvkNumber = new string[] {""} ;
         T00065_A44SupplierGenCompanyName = new string[] {""} ;
         T00065_A295SupplierGenAddressCity = new string[] {""} ;
         T00065_A294SupplierGenAddressZipCode = new string[] {""} ;
         T00065_A336SupplierGenAddressLine1 = new string[] {""} ;
         T00065_A337SupplierGenAddressLine2 = new string[] {""} ;
         T00065_A47SupplierGenContactName = new string[] {""} ;
         T00065_A48SupplierGenContactPhone = new string[] {""} ;
         T00065_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T00064_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T00066_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T00067_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00067_n42SupplierGenId = new bool[] {false} ;
         T00063_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00063_n42SupplierGenId = new bool[] {false} ;
         T00063_A335SupplierGenAddressCountry = new string[] {""} ;
         T00063_A43SupplierGenKvkNumber = new string[] {""} ;
         T00063_A44SupplierGenCompanyName = new string[] {""} ;
         T00063_A295SupplierGenAddressCity = new string[] {""} ;
         T00063_A294SupplierGenAddressZipCode = new string[] {""} ;
         T00063_A336SupplierGenAddressLine1 = new string[] {""} ;
         T00063_A337SupplierGenAddressLine2 = new string[] {""} ;
         T00063_A47SupplierGenContactName = new string[] {""} ;
         T00063_A48SupplierGenContactPhone = new string[] {""} ;
         T00063_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T00068_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00068_n42SupplierGenId = new bool[] {false} ;
         T00069_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00069_n42SupplierGenId = new bool[] {false} ;
         T00062_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T00062_n42SupplierGenId = new bool[] {false} ;
         T00062_A335SupplierGenAddressCountry = new string[] {""} ;
         T00062_A43SupplierGenKvkNumber = new string[] {""} ;
         T00062_A44SupplierGenCompanyName = new string[] {""} ;
         T00062_A295SupplierGenAddressCity = new string[] {""} ;
         T00062_A294SupplierGenAddressZipCode = new string[] {""} ;
         T00062_A336SupplierGenAddressLine1 = new string[] {""} ;
         T00062_A337SupplierGenAddressLine2 = new string[] {""} ;
         T00062_A47SupplierGenContactName = new string[] {""} ;
         T00062_A48SupplierGenContactPhone = new string[] {""} ;
         T00062_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         T000613_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000614_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         T000614_n42SupplierGenId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000615_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergen__default(),
            new Object[][] {
                new Object[] {
               T00062_A42SupplierGenId, T00062_A335SupplierGenAddressCountry, T00062_A43SupplierGenKvkNumber, T00062_A44SupplierGenCompanyName, T00062_A295SupplierGenAddressCity, T00062_A294SupplierGenAddressZipCode, T00062_A336SupplierGenAddressLine1, T00062_A337SupplierGenAddressLine2, T00062_A47SupplierGenContactName, T00062_A48SupplierGenContactPhone,
               T00062_A282SupplierGenTypeId
               }
               , new Object[] {
               T00063_A42SupplierGenId, T00063_A335SupplierGenAddressCountry, T00063_A43SupplierGenKvkNumber, T00063_A44SupplierGenCompanyName, T00063_A295SupplierGenAddressCity, T00063_A294SupplierGenAddressZipCode, T00063_A336SupplierGenAddressLine1, T00063_A337SupplierGenAddressLine2, T00063_A47SupplierGenContactName, T00063_A48SupplierGenContactPhone,
               T00063_A282SupplierGenTypeId
               }
               , new Object[] {
               T00064_A282SupplierGenTypeId
               }
               , new Object[] {
               T00065_A42SupplierGenId, T00065_A335SupplierGenAddressCountry, T00065_A43SupplierGenKvkNumber, T00065_A44SupplierGenCompanyName, T00065_A295SupplierGenAddressCity, T00065_A294SupplierGenAddressZipCode, T00065_A336SupplierGenAddressLine1, T00065_A337SupplierGenAddressLine2, T00065_A47SupplierGenContactName, T00065_A48SupplierGenContactPhone,
               T00065_A282SupplierGenTypeId
               }
               , new Object[] {
               T00066_A282SupplierGenTypeId
               }
               , new Object[] {
               T00067_A42SupplierGenId
               }
               , new Object[] {
               T00068_A42SupplierGenId
               }
               , new Object[] {
               T00069_A42SupplierGenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000613_A58ProductServiceId
               }
               , new Object[] {
               T000614_A42SupplierGenId
               }
               , new Object[] {
               T000615_A282SupplierGenTypeId
               }
            }
         );
         Z42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         A42SupplierGenId = Guid.NewGuid( );
         n42SupplierGenId = false;
         AV25Pgmname = "Trn_SupplierGen";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtSupplierGenKvkNumber_Enabled ;
      private int edtSupplierGenTypeId_Visible ;
      private int edtSupplierGenTypeId_Enabled ;
      private int edtSupplierGenCompanyName_Enabled ;
      private int edtSupplierGenContactName_Enabled ;
      private int edtSupplierGenContactPhone_Enabled ;
      private int edtSupplierGenAddressCountry_Visible ;
      private int edtSupplierGenAddressCountry_Enabled ;
      private int edtSupplierGenAddressCity_Enabled ;
      private int edtSupplierGenAddressZipCode_Enabled ;
      private int edtSupplierGenAddressLine1_Enabled ;
      private int edtSupplierGenAddressLine2_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombosuppliergentypeid_Visible ;
      private int edtavCombosuppliergentypeid_Enabled ;
      private int edtavCombosuppliergenaddresscountry_Visible ;
      private int edtavCombosuppliergenaddresscountry_Enabled ;
      private int edtSupplierGenId_Visible ;
      private int edtSupplierGenId_Enabled ;
      private int Combo_suppliergentypeid_Datalistupdateminimumcharacters ;
      private int Combo_suppliergentypeid_Gxcontroltype ;
      private int Combo_suppliergenaddresscountry_Datalistupdateminimumcharacters ;
      private int Combo_suppliergenaddresscountry_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z48SupplierGenContactPhone ;
      private string Combo_suppliergenaddresscountry_Selectedvalue_get ;
      private string Combo_suppliergentypeid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSupplierGenKvkNumber_Internalname ;
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
      private string edtSupplierGenKvkNumber_Jsonclick ;
      private string divTablesplittedsuppliergentypeid_Internalname ;
      private string lblTextblocksuppliergentypeid_Internalname ;
      private string lblTextblocksuppliergentypeid_Jsonclick ;
      private string Combo_suppliergentypeid_Caption ;
      private string Combo_suppliergentypeid_Cls ;
      private string Combo_suppliergentypeid_Internalname ;
      private string edtSupplierGenTypeId_Internalname ;
      private string edtSupplierGenTypeId_Jsonclick ;
      private string edtSupplierGenCompanyName_Internalname ;
      private string edtSupplierGenCompanyName_Jsonclick ;
      private string edtSupplierGenContactName_Internalname ;
      private string edtSupplierGenContactName_Jsonclick ;
      private string edtSupplierGenContactPhone_Internalname ;
      private string gxphoneLink ;
      private string A48SupplierGenContactPhone ;
      private string edtSupplierGenContactPhone_Jsonclick ;
      private string divTablesplittedsuppliergenaddresscountry_Internalname ;
      private string lblTextblocksuppliergenaddresscountry_Internalname ;
      private string lblTextblocksuppliergenaddresscountry_Jsonclick ;
      private string Combo_suppliergenaddresscountry_Caption ;
      private string Combo_suppliergenaddresscountry_Cls ;
      private string Combo_suppliergenaddresscountry_Internalname ;
      private string edtSupplierGenAddressCountry_Internalname ;
      private string edtSupplierGenAddressCountry_Jsonclick ;
      private string edtSupplierGenAddressCity_Internalname ;
      private string edtSupplierGenAddressCity_Jsonclick ;
      private string edtSupplierGenAddressZipCode_Internalname ;
      private string edtSupplierGenAddressZipCode_Jsonclick ;
      private string edtSupplierGenAddressLine1_Internalname ;
      private string edtSupplierGenAddressLine1_Jsonclick ;
      private string edtSupplierGenAddressLine2_Internalname ;
      private string edtSupplierGenAddressLine2_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_suppliergentypeid_Internalname ;
      private string edtavCombosuppliergentypeid_Internalname ;
      private string edtavCombosuppliergentypeid_Jsonclick ;
      private string divSectionattribute_suppliergenaddresscountry_Internalname ;
      private string edtavCombosuppliergenaddresscountry_Internalname ;
      private string edtavCombosuppliergenaddresscountry_Jsonclick ;
      private string edtSupplierGenId_Internalname ;
      private string edtSupplierGenId_Jsonclick ;
      private string AV25Pgmname ;
      private string Combo_suppliergentypeid_Objectcall ;
      private string Combo_suppliergentypeid_Class ;
      private string Combo_suppliergentypeid_Icontype ;
      private string Combo_suppliergentypeid_Icon ;
      private string Combo_suppliergentypeid_Tooltip ;
      private string Combo_suppliergentypeid_Selectedvalue_set ;
      private string Combo_suppliergentypeid_Selectedtext_set ;
      private string Combo_suppliergentypeid_Selectedtext_get ;
      private string Combo_suppliergentypeid_Gamoauthtoken ;
      private string Combo_suppliergentypeid_Ddointernalname ;
      private string Combo_suppliergentypeid_Titlecontrolalign ;
      private string Combo_suppliergentypeid_Dropdownoptionstype ;
      private string Combo_suppliergentypeid_Titlecontrolidtoreplace ;
      private string Combo_suppliergentypeid_Datalisttype ;
      private string Combo_suppliergentypeid_Datalistfixedvalues ;
      private string Combo_suppliergentypeid_Datalistproc ;
      private string Combo_suppliergentypeid_Datalistprocparametersprefix ;
      private string Combo_suppliergentypeid_Remoteservicesparameters ;
      private string Combo_suppliergentypeid_Htmltemplate ;
      private string Combo_suppliergentypeid_Multiplevaluestype ;
      private string Combo_suppliergentypeid_Loadingdata ;
      private string Combo_suppliergentypeid_Noresultsfound ;
      private string Combo_suppliergentypeid_Emptyitemtext ;
      private string Combo_suppliergentypeid_Onlyselectedvalues ;
      private string Combo_suppliergentypeid_Selectalltext ;
      private string Combo_suppliergentypeid_Multiplevaluesseparator ;
      private string Combo_suppliergentypeid_Addnewoptiontext ;
      private string Combo_suppliergenaddresscountry_Objectcall ;
      private string Combo_suppliergenaddresscountry_Class ;
      private string Combo_suppliergenaddresscountry_Icontype ;
      private string Combo_suppliergenaddresscountry_Icon ;
      private string Combo_suppliergenaddresscountry_Tooltip ;
      private string Combo_suppliergenaddresscountry_Selectedvalue_set ;
      private string Combo_suppliergenaddresscountry_Selectedtext_set ;
      private string Combo_suppliergenaddresscountry_Selectedtext_get ;
      private string Combo_suppliergenaddresscountry_Gamoauthtoken ;
      private string Combo_suppliergenaddresscountry_Ddointernalname ;
      private string Combo_suppliergenaddresscountry_Titlecontrolalign ;
      private string Combo_suppliergenaddresscountry_Dropdownoptionstype ;
      private string Combo_suppliergenaddresscountry_Titlecontrolidtoreplace ;
      private string Combo_suppliergenaddresscountry_Datalisttype ;
      private string Combo_suppliergenaddresscountry_Datalistfixedvalues ;
      private string Combo_suppliergenaddresscountry_Datalistproc ;
      private string Combo_suppliergenaddresscountry_Datalistprocparametersprefix ;
      private string Combo_suppliergenaddresscountry_Remoteservicesparameters ;
      private string Combo_suppliergenaddresscountry_Htmltemplate ;
      private string Combo_suppliergenaddresscountry_Multiplevaluestype ;
      private string Combo_suppliergenaddresscountry_Loadingdata ;
      private string Combo_suppliergenaddresscountry_Noresultsfound ;
      private string Combo_suppliergenaddresscountry_Emptyitemtext ;
      private string Combo_suppliergenaddresscountry_Onlyselectedvalues ;
      private string Combo_suppliergenaddresscountry_Selectalltext ;
      private string Combo_suppliergenaddresscountry_Multiplevaluesseparator ;
      private string Combo_suppliergenaddresscountry_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode9 ;
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
      private bool Combo_suppliergentypeid_Emptyitem ;
      private bool Combo_suppliergenaddresscountry_Emptyitem ;
      private bool Combo_suppliergentypeid_Enabled ;
      private bool Combo_suppliergentypeid_Visible ;
      private bool Combo_suppliergentypeid_Allowmultipleselection ;
      private bool Combo_suppliergentypeid_Isgriditem ;
      private bool Combo_suppliergentypeid_Hasdescription ;
      private bool Combo_suppliergentypeid_Includeonlyselectedoption ;
      private bool Combo_suppliergentypeid_Includeselectalloption ;
      private bool Combo_suppliergentypeid_Includeaddnewoption ;
      private bool Combo_suppliergenaddresscountry_Enabled ;
      private bool Combo_suppliergenaddresscountry_Visible ;
      private bool Combo_suppliergenaddresscountry_Allowmultipleselection ;
      private bool Combo_suppliergenaddresscountry_Isgriditem ;
      private bool Combo_suppliergenaddresscountry_Hasdescription ;
      private bool Combo_suppliergenaddresscountry_Includeonlyselectedoption ;
      private bool Combo_suppliergenaddresscountry_Includeselectalloption ;
      private bool Combo_suppliergenaddresscountry_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n42SupplierGenId ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z335SupplierGenAddressCountry ;
      private string Z43SupplierGenKvkNumber ;
      private string Z44SupplierGenCompanyName ;
      private string Z295SupplierGenAddressCity ;
      private string Z294SupplierGenAddressZipCode ;
      private string Z336SupplierGenAddressLine1 ;
      private string Z337SupplierGenAddressLine2 ;
      private string Z47SupplierGenContactName ;
      private string A43SupplierGenKvkNumber ;
      private string A44SupplierGenCompanyName ;
      private string A47SupplierGenContactName ;
      private string A335SupplierGenAddressCountry ;
      private string A295SupplierGenAddressCity ;
      private string A294SupplierGenAddressZipCode ;
      private string A336SupplierGenAddressLine1 ;
      private string A337SupplierGenAddressLine2 ;
      private string AV24ComboSupplierGenAddressCountry ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private Guid wcpOAV7SupplierGenId ;
      private Guid Z42SupplierGenId ;
      private Guid Z282SupplierGenTypeId ;
      private Guid N282SupplierGenTypeId ;
      private Guid A282SupplierGenTypeId ;
      private Guid AV7SupplierGenId ;
      private Guid AV20ComboSupplierGenTypeId ;
      private Guid A42SupplierGenId ;
      private Guid AV13Insert_SupplierGenTypeId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_suppliergentypeid ;
      private GXUserControl ucCombo_suppliergenaddresscountry ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15SupplierGenTypeId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV23SupplierGenAddressCountry_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item3 ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00065_A42SupplierGenId ;
      private bool[] T00065_n42SupplierGenId ;
      private string[] T00065_A335SupplierGenAddressCountry ;
      private string[] T00065_A43SupplierGenKvkNumber ;
      private string[] T00065_A44SupplierGenCompanyName ;
      private string[] T00065_A295SupplierGenAddressCity ;
      private string[] T00065_A294SupplierGenAddressZipCode ;
      private string[] T00065_A336SupplierGenAddressLine1 ;
      private string[] T00065_A337SupplierGenAddressLine2 ;
      private string[] T00065_A47SupplierGenContactName ;
      private string[] T00065_A48SupplierGenContactPhone ;
      private Guid[] T00065_A282SupplierGenTypeId ;
      private Guid[] T00064_A282SupplierGenTypeId ;
      private Guid[] T00066_A282SupplierGenTypeId ;
      private Guid[] T00067_A42SupplierGenId ;
      private bool[] T00067_n42SupplierGenId ;
      private Guid[] T00063_A42SupplierGenId ;
      private bool[] T00063_n42SupplierGenId ;
      private string[] T00063_A335SupplierGenAddressCountry ;
      private string[] T00063_A43SupplierGenKvkNumber ;
      private string[] T00063_A44SupplierGenCompanyName ;
      private string[] T00063_A295SupplierGenAddressCity ;
      private string[] T00063_A294SupplierGenAddressZipCode ;
      private string[] T00063_A336SupplierGenAddressLine1 ;
      private string[] T00063_A337SupplierGenAddressLine2 ;
      private string[] T00063_A47SupplierGenContactName ;
      private string[] T00063_A48SupplierGenContactPhone ;
      private Guid[] T00063_A282SupplierGenTypeId ;
      private Guid[] T00068_A42SupplierGenId ;
      private bool[] T00068_n42SupplierGenId ;
      private Guid[] T00069_A42SupplierGenId ;
      private bool[] T00069_n42SupplierGenId ;
      private Guid[] T00062_A42SupplierGenId ;
      private bool[] T00062_n42SupplierGenId ;
      private string[] T00062_A335SupplierGenAddressCountry ;
      private string[] T00062_A43SupplierGenKvkNumber ;
      private string[] T00062_A44SupplierGenCompanyName ;
      private string[] T00062_A295SupplierGenAddressCity ;
      private string[] T00062_A294SupplierGenAddressZipCode ;
      private string[] T00062_A336SupplierGenAddressLine1 ;
      private string[] T00062_A337SupplierGenAddressLine2 ;
      private string[] T00062_A47SupplierGenContactName ;
      private string[] T00062_A48SupplierGenContactPhone ;
      private Guid[] T00062_A282SupplierGenTypeId ;
      private Guid[] T000613_A58ProductServiceId ;
      private Guid[] T000614_A42SupplierGenId ;
      private bool[] T000614_n42SupplierGenId ;
      private Guid[] T000615_A282SupplierGenTypeId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_suppliergen__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_suppliergen__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00062;
        prmT00062 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00063;
        prmT00063 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00064;
        prmT00064 = new Object[] {
        new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00065;
        prmT00065 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00066;
        prmT00066 = new Object[] {
        new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00067;
        prmT00067 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00068;
        prmT00068 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00069;
        prmT00069 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000610;
        prmT000610 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SupplierGenAddressCountry",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenKvkNumber",GXType.VarChar,40,0) ,
        new ParDef("SupplierGenCompanyName",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenAddressCity",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenAddressZipCode",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenAddressLine1",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenAddressLine2",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenContactName",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenContactPhone",GXType.Char,20,0) ,
        new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000611;
        prmT000611 = new Object[] {
        new ParDef("SupplierGenAddressCountry",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenKvkNumber",GXType.VarChar,40,0) ,
        new ParDef("SupplierGenCompanyName",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenAddressCity",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenAddressZipCode",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenAddressLine1",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenAddressLine2",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenContactName",GXType.VarChar,100,0) ,
        new ParDef("SupplierGenContactPhone",GXType.Char,20,0) ,
        new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000612;
        prmT000612 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000613;
        prmT000613 = new Object[] {
        new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000614;
        prmT000614 = new Object[] {
        };
        Object[] prmT000615;
        prmT000615 = new Object[] {
        new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00062", "SELECT SupplierGenId, SupplierGenAddressCountry, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCity, SupplierGenAddressZipCode, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenContactPhone, SupplierGenTypeId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId  FOR UPDATE OF Trn_SupplierGen NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00063", "SELECT SupplierGenId, SupplierGenAddressCountry, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCity, SupplierGenAddressZipCode, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenContactPhone, SupplierGenTypeId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00064", "SELECT SupplierGenTypeId FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00065", "SELECT TM1.SupplierGenId, TM1.SupplierGenAddressCountry, TM1.SupplierGenKvkNumber, TM1.SupplierGenCompanyName, TM1.SupplierGenAddressCity, TM1.SupplierGenAddressZipCode, TM1.SupplierGenAddressLine1, TM1.SupplierGenAddressLine2, TM1.SupplierGenContactName, TM1.SupplierGenContactPhone, TM1.SupplierGenTypeId FROM Trn_SupplierGen TM1 WHERE TM1.SupplierGenId = :SupplierGenId ORDER BY TM1.SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00066", "SELECT SupplierGenTypeId FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00067", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00068", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE ( SupplierGenId > :SupplierGenId) ORDER BY SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00069", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE ( SupplierGenId < :SupplierGenId) ORDER BY SupplierGenId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000610", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierGen(SupplierGenId, SupplierGenAddressCountry, SupplierGenKvkNumber, SupplierGenCompanyName, SupplierGenAddressCity, SupplierGenAddressZipCode, SupplierGenAddressLine1, SupplierGenAddressLine2, SupplierGenContactName, SupplierGenContactPhone, SupplierGenTypeId) VALUES(:SupplierGenId, :SupplierGenAddressCountry, :SupplierGenKvkNumber, :SupplierGenCompanyName, :SupplierGenAddressCity, :SupplierGenAddressZipCode, :SupplierGenAddressLine1, :SupplierGenAddressLine2, :SupplierGenContactName, :SupplierGenContactPhone, :SupplierGenTypeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000610)
           ,new CursorDef("T000611", "SAVEPOINT gxupdate;UPDATE Trn_SupplierGen SET SupplierGenAddressCountry=:SupplierGenAddressCountry, SupplierGenKvkNumber=:SupplierGenKvkNumber, SupplierGenCompanyName=:SupplierGenCompanyName, SupplierGenAddressCity=:SupplierGenAddressCity, SupplierGenAddressZipCode=:SupplierGenAddressZipCode, SupplierGenAddressLine1=:SupplierGenAddressLine1, SupplierGenAddressLine2=:SupplierGenAddressLine2, SupplierGenContactName=:SupplierGenContactName, SupplierGenContactPhone=:SupplierGenContactPhone, SupplierGenTypeId=:SupplierGenTypeId  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000611)
           ,new CursorDef("T000612", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierGen  WHERE SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000612)
           ,new CursorDef("T000613", "SELECT ProductServiceId FROM Trn_ProductService WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000614", "SELECT SupplierGenId FROM Trn_SupplierGen ORDER BY SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000615", "SELECT SupplierGenTypeId FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              ((Guid[]) buf[10])[0] = rslt.getGuid(11);
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
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              ((Guid[]) buf[10])[0] = rslt.getGuid(11);
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
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              ((Guid[]) buf[10])[0] = rslt.getGuid(11);
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