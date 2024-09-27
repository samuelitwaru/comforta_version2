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
   public class trn_tile : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
            n58ProductServiceId = false;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A58ProductServiceId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A329SG_ToPageId = StringUtil.StrToGuid( GetPar( "SG_ToPageId"));
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A329SG_ToPageId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_attribute") == 0 )
         {
            gxnrGridlevel_attribute_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_tile.aspx")), "trn_tile.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_tile.aspx")))) ;
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
                  AV45Trn_TileId = StringUtil.StrToGuid( GetPar( "Trn_TileId"));
                  AssignAttri("", false, "AV45Trn_TileId", AV45Trn_TileId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRN_TILEID", GetSecureSignedToken( "", AV45Trn_TileId, context));
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
         Form.Meta.addItem("description", "Tile", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrn_TileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_attribute_newrow_invoke( )
      {
         nRC_GXsfl_76 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_76"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_76_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_76_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_76_idx = GetPar( "sGXsfl_76_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_attribute_newrow( ) ;
         /* End function gxnrGridlevel_attribute_newrow_invoke */
      }

      public trn_tile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_tile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_Trn_TileId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV45Trn_TileId = aP1_Trn_TileId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTrn_TileWidth = new GXCombobox();
         cmbTrn_TileColor = new GXCombobox();
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
         if ( cmbTrn_TileWidth.ItemCount > 0 )
         {
            A268Trn_TileWidth = (short)(Math.Round(NumberUtil.Val( cmbTrn_TileWidth.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A268Trn_TileWidth), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A268Trn_TileWidth", StringUtil.LTrimStr( (decimal)(A268Trn_TileWidth), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTrn_TileWidth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A268Trn_TileWidth), 4, 0));
            AssignProp("", false, cmbTrn_TileWidth_Internalname, "Values", cmbTrn_TileWidth.ToJavascriptSource(), true);
         }
         if ( cmbTrn_TileColor.ItemCount > 0 )
         {
            A270Trn_TileColor = cmbTrn_TileColor.getValidValue(A270Trn_TileColor);
            AssignAttri("", false, "A270Trn_TileColor", A270Trn_TileColor);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTrn_TileColor.CurrentValue = StringUtil.RTrim( A270Trn_TileColor);
            AssignProp("", false, cmbTrn_TileColor_Internalname, "Values", cmbTrn_TileColor.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_TileId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_TileId_Internalname, "Id", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_TileId_Internalname, A264Trn_TileId.ToString(), A264Trn_TileId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_TileId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_TileId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_TileName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_TileName_Internalname, "Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_TileName_Internalname, A265Trn_TileName, StringUtil.RTrim( context.localUtil.Format( A265Trn_TileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_TileName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_TileName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTrn_TileWidth_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTrn_TileWidth_Internalname, "Width", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTrn_TileWidth, cmbTrn_TileWidth_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A268Trn_TileWidth), 4, 0)), 1, cmbTrn_TileWidth_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTrn_TileWidth.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 0, "HLP_Trn_Tile.htm");
         cmbTrn_TileWidth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A268Trn_TileWidth), 4, 0));
         AssignProp("", false, cmbTrn_TileWidth_Internalname, "Values", (string)(cmbTrn_TileWidth.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTrn_TileColor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTrn_TileColor_Internalname, "Color", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTrn_TileColor, cmbTrn_TileColor_Internalname, StringUtil.RTrim( A270Trn_TileColor), 1, cmbTrn_TileColor_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTrn_TileColor.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_Trn_Tile.htm");
         cmbTrn_TileColor.CurrentValue = StringUtil.RTrim( A270Trn_TileColor);
         AssignProp("", false, cmbTrn_TileColor_Internalname, "Values", (string)(cmbTrn_TileColor.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_TileBGImageUrl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_TileBGImageUrl_Internalname, "BGImage Url", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_TileBGImageUrl_Internalname, A271Trn_TileBGImageUrl, StringUtil.RTrim( context.localUtil.Format( A271Trn_TileBGImageUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", A271Trn_TileBGImageUrl, "_blank", "", "", edtTrn_TileBGImageUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_TileBGImageUrl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedproductserviceid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockproductserviceid_Internalname, "Product/Service", "", "", lblTextblockproductserviceid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_productserviceid.SetProperty("Caption", Combo_productserviceid_Caption);
         ucCombo_productserviceid.SetProperty("Cls", Combo_productserviceid_Cls);
         ucCombo_productserviceid.SetProperty("DataListProc", Combo_productserviceid_Datalistproc);
         ucCombo_productserviceid.SetProperty("DataListProcParametersPrefix", Combo_productserviceid_Datalistprocparametersprefix);
         ucCombo_productserviceid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_productserviceid.SetProperty("DropDownOptionsData", AV22ProductServiceId_Data);
         ucCombo_productserviceid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_productserviceid_Internalname, "COMBO_PRODUCTSERVICEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceId_Internalname, "Product Service Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceId_Internalname, A58ProductServiceId.ToString(), A58ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceId_Jsonclick, 0, "Attribute", "", "", "", "", edtProductServiceId_Visible, edtProductServiceId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceDescription_Internalname, "Product Service Description", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProductServiceDescription_Internalname, A60ProductServiceDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", 0, 1, edtProductServiceDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProductServiceImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Product Service Image", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A61ProductServiceImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServiceImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage));
         GxWebStd.gx_bitmap( context, imgProductServiceImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductServiceImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", "", "", 0, A61ProductServiceImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_Tile.htm");
         AssignProp("", false, imgProductServiceImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage)), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "IsBlob", StringUtil.BoolToStr( A61ProductServiceImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsg_topageid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksg_topageid_Internalname, "Trn_Page", "", "", lblTextblocksg_topageid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_sg_topageid.SetProperty("Caption", Combo_sg_topageid_Caption);
         ucCombo_sg_topageid.SetProperty("Cls", Combo_sg_topageid_Cls);
         ucCombo_sg_topageid.SetProperty("DataListProc", Combo_sg_topageid_Datalistproc);
         ucCombo_sg_topageid.SetProperty("DataListProcParametersPrefix", Combo_sg_topageid_Datalistprocparametersprefix);
         ucCombo_sg_topageid.SetProperty("EmptyItem", Combo_sg_topageid_Emptyitem);
         ucCombo_sg_topageid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_sg_topageid.SetProperty("DropDownOptionsData", AV42SG_ToPageId_Data);
         ucCombo_sg_topageid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_sg_topageid_Internalname, "COMBO_SG_TOPAGEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSG_ToPageId_Internalname, "SG_To Page Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSG_ToPageId_Internalname, A329SG_ToPageId.ToString(), A329SG_ToPageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSG_ToPageId_Jsonclick, 0, "Attribute", "", "", "", "", edtSG_ToPageId_Visible, edtSG_ToPageId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_attribute_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_attribute( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_productserviceid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboproductserviceid_Internalname, AV23ComboProductServiceId.ToString(), AV23ComboProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboproductserviceid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboproductserviceid_Visible, edtavComboproductserviceid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_sg_topageid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosg_topageid_Internalname, AV43ComboSG_ToPageId.ToString(), AV43ComboSG_ToPageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosg_topageid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosg_topageid_Visible, edtavCombosg_topageid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_attribute( )
      {
         /*  Grid Control  */
         StartGridControl76( ) ;
         nGXsfl_76_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount52 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_52 = 1;
               ScanStart0Z52( ) ;
               while ( RcdFound52 != 0 )
               {
                  init_level_properties52( ) ;
                  getByPrimaryKey0Z52( ) ;
                  AddRow0Z52( ) ;
                  ScanNext0Z52( ) ;
               }
               ScanEnd0Z52( ) ;
               nBlankRcdCount52 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0Z52( ) ;
            standaloneModal0Z52( ) ;
            sMode52 = Gx_mode;
            while ( nGXsfl_76_idx < nRC_GXsfl_76 )
            {
               bGXsfl_76_Refreshing = true;
               ReadRow0Z52( ) ;
               edtAttributeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTEID_"+sGXsfl_76_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               edtAttributeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTENAME_"+sGXsfl_76_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttributeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeName_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               edtAttrbuteValue_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRBUTEVALUE_"+sGXsfl_76_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttrbuteValue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttrbuteValue_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               if ( ( nRcdExists_52 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0Z52( ) ;
               }
               SendRow0Z52( ) ;
               bGXsfl_76_Refreshing = false;
            }
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount52 = 5;
            nRcdExists_52 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0Z52( ) ;
               while ( RcdFound52 != 0 )
               {
                  sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_7652( ) ;
                  init_level_properties52( ) ;
                  standaloneNotModal0Z52( ) ;
                  getByPrimaryKey0Z52( ) ;
                  standaloneModal0Z52( ) ;
                  AddRow0Z52( ) ;
                  ScanNext0Z52( ) ;
               }
               ScanEnd0Z52( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode52 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx+1), 4, 0), 4, "0");
            SubsflControlProps_7652( ) ;
            InitAll0Z52( ) ;
            init_level_properties52( ) ;
            nRcdExists_52 = 0;
            nIsMod_52 = 0;
            nRcdDeleted_52 = 0;
            nBlankRcdCount52 = (short)(nBlankRcdUsr52+nBlankRcdCount52);
            fRowAdded = 0;
            while ( nBlankRcdCount52 > 0 )
            {
               A272AttributeId = Guid.Empty;
               standaloneNotModal0Z52( ) ;
               standaloneModal0Z52( ) ;
               AddRow0Z52( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtAttributeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount52 = (short)(nBlankRcdCount52-1);
            }
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_attributeContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_attribute", Gridlevel_attributeContainer, subGridlevel_attribute_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_attributeContainerData", Gridlevel_attributeContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_attributeContainerData"+"V", Gridlevel_attributeContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_attributeContainerData"+"V"+"\" value='"+Gridlevel_attributeContainer.GridValuesHidden()+"'/>") ;
         }
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
         E110Z2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPRODUCTSERVICEID_DATA"), AV22ProductServiceId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSG_TOPAGEID_DATA"), AV42SG_ToPageId_Data);
               /* Read saved values. */
               Z264Trn_TileId = StringUtil.StrToGuid( cgiGet( "Z264Trn_TileId"));
               Z265Trn_TileName = cgiGet( "Z265Trn_TileName");
               Z268Trn_TileWidth = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z268Trn_TileWidth"), ".", ","), 18, MidpointRounding.ToEven));
               Z270Trn_TileColor = cgiGet( "Z270Trn_TileColor");
               Z271Trn_TileBGImageUrl = cgiGet( "Z271Trn_TileBGImageUrl");
               Z58ProductServiceId = StringUtil.StrToGuid( cgiGet( "Z58ProductServiceId"));
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               Z329SG_ToPageId = StringUtil.StrToGuid( cgiGet( "Z329SG_ToPageId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_76 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_76"), ".", ","), 18, MidpointRounding.ToEven));
               N58ProductServiceId = StringUtil.StrToGuid( cgiGet( "N58ProductServiceId"));
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               N329SG_ToPageId = StringUtil.StrToGuid( cgiGet( "N329SG_ToPageId"));
               AV45Trn_TileId = StringUtil.StrToGuid( cgiGet( "vTRN_TILEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV20Insert_ProductServiceId = StringUtil.StrToGuid( cgiGet( "vINSERT_PRODUCTSERVICEID"));
               AV41Insert_SG_ToPageId = StringUtil.StrToGuid( cgiGet( "vINSERT_SG_TOPAGEID"));
               A59ProductServiceName = cgiGet( "PRODUCTSERVICENAME");
               A40000ProductServiceImage_GXI = cgiGet( "PRODUCTSERVICEIMAGE_GXI");
               A330SG_ToPageName = cgiGet( "SG_TOPAGENAME");
               AV46Pgmname = cgiGet( "vPGMNAME");
               Combo_productserviceid_Objectcall = cgiGet( "COMBO_PRODUCTSERVICEID_Objectcall");
               Combo_productserviceid_Class = cgiGet( "COMBO_PRODUCTSERVICEID_Class");
               Combo_productserviceid_Icontype = cgiGet( "COMBO_PRODUCTSERVICEID_Icontype");
               Combo_productserviceid_Icon = cgiGet( "COMBO_PRODUCTSERVICEID_Icon");
               Combo_productserviceid_Caption = cgiGet( "COMBO_PRODUCTSERVICEID_Caption");
               Combo_productserviceid_Tooltip = cgiGet( "COMBO_PRODUCTSERVICEID_Tooltip");
               Combo_productserviceid_Cls = cgiGet( "COMBO_PRODUCTSERVICEID_Cls");
               Combo_productserviceid_Selectedvalue_set = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedvalue_set");
               Combo_productserviceid_Selectedvalue_get = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedvalue_get");
               Combo_productserviceid_Selectedtext_set = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedtext_set");
               Combo_productserviceid_Selectedtext_get = cgiGet( "COMBO_PRODUCTSERVICEID_Selectedtext_get");
               Combo_productserviceid_Gamoauthtoken = cgiGet( "COMBO_PRODUCTSERVICEID_Gamoauthtoken");
               Combo_productserviceid_Ddointernalname = cgiGet( "COMBO_PRODUCTSERVICEID_Ddointernalname");
               Combo_productserviceid_Titlecontrolalign = cgiGet( "COMBO_PRODUCTSERVICEID_Titlecontrolalign");
               Combo_productserviceid_Dropdownoptionstype = cgiGet( "COMBO_PRODUCTSERVICEID_Dropdownoptionstype");
               Combo_productserviceid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Enabled"));
               Combo_productserviceid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Visible"));
               Combo_productserviceid_Titlecontrolidtoreplace = cgiGet( "COMBO_PRODUCTSERVICEID_Titlecontrolidtoreplace");
               Combo_productserviceid_Datalisttype = cgiGet( "COMBO_PRODUCTSERVICEID_Datalisttype");
               Combo_productserviceid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Allowmultipleselection"));
               Combo_productserviceid_Datalistfixedvalues = cgiGet( "COMBO_PRODUCTSERVICEID_Datalistfixedvalues");
               Combo_productserviceid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Isgriditem"));
               Combo_productserviceid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Hasdescription"));
               Combo_productserviceid_Datalistproc = cgiGet( "COMBO_PRODUCTSERVICEID_Datalistproc");
               Combo_productserviceid_Datalistprocparametersprefix = cgiGet( "COMBO_PRODUCTSERVICEID_Datalistprocparametersprefix");
               Combo_productserviceid_Remoteservicesparameters = cgiGet( "COMBO_PRODUCTSERVICEID_Remoteservicesparameters");
               Combo_productserviceid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRODUCTSERVICEID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_productserviceid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Includeonlyselectedoption"));
               Combo_productserviceid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Includeselectalloption"));
               Combo_productserviceid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Emptyitem"));
               Combo_productserviceid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PRODUCTSERVICEID_Includeaddnewoption"));
               Combo_productserviceid_Htmltemplate = cgiGet( "COMBO_PRODUCTSERVICEID_Htmltemplate");
               Combo_productserviceid_Multiplevaluestype = cgiGet( "COMBO_PRODUCTSERVICEID_Multiplevaluestype");
               Combo_productserviceid_Loadingdata = cgiGet( "COMBO_PRODUCTSERVICEID_Loadingdata");
               Combo_productserviceid_Noresultsfound = cgiGet( "COMBO_PRODUCTSERVICEID_Noresultsfound");
               Combo_productserviceid_Emptyitemtext = cgiGet( "COMBO_PRODUCTSERVICEID_Emptyitemtext");
               Combo_productserviceid_Onlyselectedvalues = cgiGet( "COMBO_PRODUCTSERVICEID_Onlyselectedvalues");
               Combo_productserviceid_Selectalltext = cgiGet( "COMBO_PRODUCTSERVICEID_Selectalltext");
               Combo_productserviceid_Multiplevaluesseparator = cgiGet( "COMBO_PRODUCTSERVICEID_Multiplevaluesseparator");
               Combo_productserviceid_Addnewoptiontext = cgiGet( "COMBO_PRODUCTSERVICEID_Addnewoptiontext");
               Combo_productserviceid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRODUCTSERVICEID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_sg_topageid_Objectcall = cgiGet( "COMBO_SG_TOPAGEID_Objectcall");
               Combo_sg_topageid_Class = cgiGet( "COMBO_SG_TOPAGEID_Class");
               Combo_sg_topageid_Icontype = cgiGet( "COMBO_SG_TOPAGEID_Icontype");
               Combo_sg_topageid_Icon = cgiGet( "COMBO_SG_TOPAGEID_Icon");
               Combo_sg_topageid_Caption = cgiGet( "COMBO_SG_TOPAGEID_Caption");
               Combo_sg_topageid_Tooltip = cgiGet( "COMBO_SG_TOPAGEID_Tooltip");
               Combo_sg_topageid_Cls = cgiGet( "COMBO_SG_TOPAGEID_Cls");
               Combo_sg_topageid_Selectedvalue_set = cgiGet( "COMBO_SG_TOPAGEID_Selectedvalue_set");
               Combo_sg_topageid_Selectedvalue_get = cgiGet( "COMBO_SG_TOPAGEID_Selectedvalue_get");
               Combo_sg_topageid_Selectedtext_set = cgiGet( "COMBO_SG_TOPAGEID_Selectedtext_set");
               Combo_sg_topageid_Selectedtext_get = cgiGet( "COMBO_SG_TOPAGEID_Selectedtext_get");
               Combo_sg_topageid_Gamoauthtoken = cgiGet( "COMBO_SG_TOPAGEID_Gamoauthtoken");
               Combo_sg_topageid_Ddointernalname = cgiGet( "COMBO_SG_TOPAGEID_Ddointernalname");
               Combo_sg_topageid_Titlecontrolalign = cgiGet( "COMBO_SG_TOPAGEID_Titlecontrolalign");
               Combo_sg_topageid_Dropdownoptionstype = cgiGet( "COMBO_SG_TOPAGEID_Dropdownoptionstype");
               Combo_sg_topageid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SG_TOPAGEID_Enabled"));
               Combo_sg_topageid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SG_TOPAGEID_Visible"));
               Combo_sg_topageid_Titlecontrolidtoreplace = cgiGet( "COMBO_SG_TOPAGEID_Titlecontrolidtoreplace");
               Combo_sg_topageid_Datalisttype = cgiGet( "COMBO_SG_TOPAGEID_Datalisttype");
               Combo_sg_topageid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SG_TOPAGEID_Allowmultipleselection"));
               Combo_sg_topageid_Datalistfixedvalues = cgiGet( "COMBO_SG_TOPAGEID_Datalistfixedvalues");
               Combo_sg_topageid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SG_TOPAGEID_Isgriditem"));
               Combo_sg_topageid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SG_TOPAGEID_Hasdescription"));
               Combo_sg_topageid_Datalistproc = cgiGet( "COMBO_SG_TOPAGEID_Datalistproc");
               Combo_sg_topageid_Datalistprocparametersprefix = cgiGet( "COMBO_SG_TOPAGEID_Datalistprocparametersprefix");
               Combo_sg_topageid_Remoteservicesparameters = cgiGet( "COMBO_SG_TOPAGEID_Remoteservicesparameters");
               Combo_sg_topageid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SG_TOPAGEID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_sg_topageid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SG_TOPAGEID_Includeonlyselectedoption"));
               Combo_sg_topageid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SG_TOPAGEID_Includeselectalloption"));
               Combo_sg_topageid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SG_TOPAGEID_Emptyitem"));
               Combo_sg_topageid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SG_TOPAGEID_Includeaddnewoption"));
               Combo_sg_topageid_Htmltemplate = cgiGet( "COMBO_SG_TOPAGEID_Htmltemplate");
               Combo_sg_topageid_Multiplevaluestype = cgiGet( "COMBO_SG_TOPAGEID_Multiplevaluestype");
               Combo_sg_topageid_Loadingdata = cgiGet( "COMBO_SG_TOPAGEID_Loadingdata");
               Combo_sg_topageid_Noresultsfound = cgiGet( "COMBO_SG_TOPAGEID_Noresultsfound");
               Combo_sg_topageid_Emptyitemtext = cgiGet( "COMBO_SG_TOPAGEID_Emptyitemtext");
               Combo_sg_topageid_Onlyselectedvalues = cgiGet( "COMBO_SG_TOPAGEID_Onlyselectedvalues");
               Combo_sg_topageid_Selectalltext = cgiGet( "COMBO_SG_TOPAGEID_Selectalltext");
               Combo_sg_topageid_Multiplevaluesseparator = cgiGet( "COMBO_SG_TOPAGEID_Multiplevaluesseparator");
               Combo_sg_topageid_Addnewoptiontext = cgiGet( "COMBO_SG_TOPAGEID_Addnewoptiontext");
               Combo_sg_topageid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SG_TOPAGEID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
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
               if ( StringUtil.StrCmp(cgiGet( edtTrn_TileId_Internalname), "") == 0 )
               {
                  A264Trn_TileId = Guid.Empty;
                  AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
               }
               else
               {
                  try
                  {
                     A264Trn_TileId = StringUtil.StrToGuid( cgiGet( edtTrn_TileId_Internalname));
                     AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_TILEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_TileId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A265Trn_TileName = cgiGet( edtTrn_TileName_Internalname);
               AssignAttri("", false, "A265Trn_TileName", A265Trn_TileName);
               cmbTrn_TileWidth.Name = cmbTrn_TileWidth_Internalname;
               cmbTrn_TileWidth.CurrentValue = cgiGet( cmbTrn_TileWidth_Internalname);
               A268Trn_TileWidth = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbTrn_TileWidth_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A268Trn_TileWidth", StringUtil.LTrimStr( (decimal)(A268Trn_TileWidth), 4, 0));
               cmbTrn_TileColor.Name = cmbTrn_TileColor_Internalname;
               cmbTrn_TileColor.CurrentValue = cgiGet( cmbTrn_TileColor_Internalname);
               A270Trn_TileColor = cgiGet( cmbTrn_TileColor_Internalname);
               AssignAttri("", false, "A270Trn_TileColor", A270Trn_TileColor);
               A271Trn_TileBGImageUrl = cgiGet( edtTrn_TileBGImageUrl_Internalname);
               AssignAttri("", false, "A271Trn_TileBGImageUrl", A271Trn_TileBGImageUrl);
               if ( StringUtil.StrCmp(cgiGet( edtProductServiceId_Internalname), "") == 0 )
               {
                  A58ProductServiceId = Guid.Empty;
                  n58ProductServiceId = false;
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               }
               else
               {
                  try
                  {
                     A58ProductServiceId = StringUtil.StrToGuid( cgiGet( edtProductServiceId_Internalname));
                     n58ProductServiceId = false;
                     AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "PRODUCTSERVICEID");
                     AnyError = 1;
                     GX_FocusControl = edtProductServiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               A60ProductServiceDescription = cgiGet( edtProductServiceDescription_Internalname);
               AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
               A61ProductServiceImage = cgiGet( imgProductServiceImage_Internalname);
               AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
               if ( StringUtil.StrCmp(cgiGet( edtSG_ToPageId_Internalname), "") == 0 )
               {
                  A329SG_ToPageId = Guid.Empty;
                  AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
               }
               else
               {
                  try
                  {
                     A329SG_ToPageId = StringUtil.StrToGuid( cgiGet( edtSG_ToPageId_Internalname));
                     AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "SG_TOPAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtSG_ToPageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               AV23ComboProductServiceId = StringUtil.StrToGuid( cgiGet( edtavComboproductserviceid_Internalname));
               AssignAttri("", false, "AV23ComboProductServiceId", AV23ComboProductServiceId.ToString());
               AV43ComboSG_ToPageId = StringUtil.StrToGuid( cgiGet( edtavCombosg_topageid_Internalname));
               AssignAttri("", false, "AV43ComboSG_ToPageId", AV43ComboSG_ToPageId.ToString());
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProductServiceImage_Internalname, ref  A61ProductServiceImage, ref  A40000ProductServiceImage_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Tile");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A264Trn_TileId != Z264Trn_TileId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_tile:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A264Trn_TileId = StringUtil.StrToGuid( GetPar( "Trn_TileId"));
                  AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV45Trn_TileId) )
                  {
                     A264Trn_TileId = AV45Trn_TileId;
                     AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A264Trn_TileId) && ( Gx_BScreen == 0 ) )
                     {
                        A264Trn_TileId = Guid.NewGuid( );
                        AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
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
                     sMode71 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV45Trn_TileId) )
                     {
                        A264Trn_TileId = AV45Trn_TileId;
                        AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A264Trn_TileId) && ( Gx_BScreen == 0 ) )
                        {
                           A264Trn_TileId = Guid.NewGuid( );
                           AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
                        }
                     }
                     Gx_mode = sMode71;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound71 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0Z0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TRN_TILEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_TileId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_PRODUCTSERVICEID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_productserviceid.Onoptionclicked */
                           E120Z2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_SG_TOPAGEID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_sg_topageid.Onoptionclicked */
                           E130Z2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110Z2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E140Z2 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E140Z2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0Z71( ) ;
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
            DisableAttributes0Z71( ) ;
         }
         AssignProp("", false, edtavComboproductserviceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboproductserviceid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombosg_topageid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosg_topageid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0Z0( )
      {
         BeforeValidate0Z71( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Z71( ) ;
            }
            else
            {
               CheckExtendedTable0Z71( ) ;
               CloseExtendedTableCursors0Z71( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode71 = Gx_mode;
            CONFIRM_0Z52( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode71;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode71;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0Z52( )
      {
         nGXsfl_76_idx = 0;
         while ( nGXsfl_76_idx < nRC_GXsfl_76 )
         {
            ReadRow0Z52( ) ;
            if ( ( nRcdExists_52 != 0 ) || ( nIsMod_52 != 0 ) )
            {
               GetKey0Z52( ) ;
               if ( ( nRcdExists_52 == 0 ) && ( nRcdDeleted_52 == 0 ) )
               {
                  if ( RcdFound52 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0Z52( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Z52( ) ;
                        CloseExtendedTableCursors0Z52( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "ATTRIBUTEID_" + sGXsfl_76_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtAttributeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound52 != 0 )
                  {
                     if ( nRcdDeleted_52 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0Z52( ) ;
                        Load0Z52( ) ;
                        BeforeValidate0Z52( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Z52( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_52 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0Z52( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Z52( ) ;
                              CloseExtendedTableCursors0Z52( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_52 == 0 )
                     {
                        GXCCtl = "ATTRIBUTEID_" + sGXsfl_76_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtAttributeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAttributeId_Internalname, A272AttributeId.ToString()) ;
            ChangePostValue( edtAttributeName_Internalname, A273AttributeName) ;
            ChangePostValue( edtAttrbuteValue_Internalname, A274AttrbuteValue) ;
            ChangePostValue( "ZT_"+"Z272AttributeId_"+sGXsfl_76_idx, Z272AttributeId.ToString()) ;
            ChangePostValue( "ZT_"+"Z273AttributeName_"+sGXsfl_76_idx, Z273AttributeName) ;
            ChangePostValue( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_76_idx, Z274AttrbuteValue) ;
            ChangePostValue( "nRcdDeleted_52_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_52_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_52_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, ".", ""))) ;
            if ( nIsMod_52 != 0 )
            {
               ChangePostValue( "ATTRIBUTEID_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRIBUTENAME_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRBUTEVALUE_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttrbuteValue_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0Z0( )
      {
      }

      protected void E110Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV18GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV19GAMErrors);
         Combo_sg_topageid_Gamoauthtoken = AV18GAMSession.gxTpr_Token;
         ucCombo_sg_topageid.SendProperty(context, "", false, Combo_sg_topageid_Internalname, "GAMOAuthToken", Combo_sg_topageid_Gamoauthtoken);
         edtSG_ToPageId_Visible = 0;
         AssignProp("", false, edtSG_ToPageId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSG_ToPageId_Visible), 5, 0), true);
         AV43ComboSG_ToPageId = Guid.Empty;
         AssignAttri("", false, "AV43ComboSG_ToPageId", AV43ComboSG_ToPageId.ToString());
         edtavCombosg_topageid_Visible = 0;
         AssignProp("", false, edtavCombosg_topageid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosg_topageid_Visible), 5, 0), true);
         Combo_productserviceid_Gamoauthtoken = AV18GAMSession.gxTpr_Token;
         ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "GAMOAuthToken", Combo_productserviceid_Gamoauthtoken);
         edtProductServiceId_Visible = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Visible), 5, 0), true);
         AV23ComboProductServiceId = Guid.Empty;
         AssignAttri("", false, "AV23ComboProductServiceId", AV23ComboProductServiceId.ToString());
         edtavComboproductserviceid_Visible = 0;
         AssignProp("", false, edtavComboproductserviceid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboproductserviceid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPRODUCTSERVICEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOSG_TOPAGEID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV46Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV47GXV1 = 1;
            AssignAttri("", false, "AV47GXV1", StringUtil.LTrimStr( (decimal)(AV47GXV1), 8, 0));
            while ( AV47GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV21TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV47GXV1));
               if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "ProductServiceId") == 0 )
               {
                  AV20Insert_ProductServiceId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV20Insert_ProductServiceId", AV20Insert_ProductServiceId.ToString());
                  if ( ! (Guid.Empty==AV20Insert_ProductServiceId) )
                  {
                     AV23ComboProductServiceId = AV20Insert_ProductServiceId;
                     AssignAttri("", false, "AV23ComboProductServiceId", AV23ComboProductServiceId.ToString());
                     Combo_productserviceid_Selectedvalue_set = StringUtil.Trim( AV23ComboProductServiceId.ToString());
                     ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedValue_set", Combo_productserviceid_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new trn_tileloaddvcombo(context ).execute(  "ProductServiceId",  "GET",  false,  AV45Trn_TileId,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_productserviceid_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedText_set", Combo_productserviceid_Selectedtext_set);
                     Combo_productserviceid_Enabled = false;
                     ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_productserviceid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "SG_ToPageId") == 0 )
               {
                  AV41Insert_SG_ToPageId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV41Insert_SG_ToPageId", AV41Insert_SG_ToPageId.ToString());
                  if ( ! (Guid.Empty==AV41Insert_SG_ToPageId) )
                  {
                     AV43ComboSG_ToPageId = AV41Insert_SG_ToPageId;
                     AssignAttri("", false, "AV43ComboSG_ToPageId", AV43ComboSG_ToPageId.ToString());
                     Combo_sg_topageid_Selectedvalue_set = StringUtil.Trim( AV43ComboSG_ToPageId.ToString());
                     ucCombo_sg_topageid.SendProperty(context, "", false, Combo_sg_topageid_Internalname, "SelectedValue_set", Combo_sg_topageid_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new trn_tileloaddvcombo(context ).execute(  "SG_ToPageId",  "GET",  false,  AV45Trn_TileId,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_sg_topageid_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_sg_topageid.SendProperty(context, "", false, Combo_sg_topageid_Internalname, "SelectedText_set", Combo_sg_topageid_Selectedtext_set);
                     Combo_sg_topageid_Enabled = false;
                     ucCombo_sg_topageid.SendProperty(context, "", false, Combo_sg_topageid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_sg_topageid_Enabled));
                  }
               }
               AV47GXV1 = (int)(AV47GXV1+1);
               AssignAttri("", false, "AV47GXV1", StringUtil.LTrimStr( (decimal)(AV47GXV1), 8, 0));
            }
         }
      }

      protected void E140Z2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_tileww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E130Z2( )
      {
         /* Combo_sg_topageid_Onoptionclicked Routine */
         returnInSub = false;
         AV43ComboSG_ToPageId = StringUtil.StrToGuid( Combo_sg_topageid_Selectedvalue_get);
         AssignAttri("", false, "AV43ComboSG_ToPageId", AV43ComboSG_ToPageId.ToString());
         /*  Sending Event outputs  */
      }

      protected void E120Z2( )
      {
         /* Combo_productserviceid_Onoptionclicked Routine */
         returnInSub = false;
         AV23ComboProductServiceId = StringUtil.StrToGuid( Combo_productserviceid_Selectedvalue_get);
         AssignAttri("", false, "AV23ComboProductServiceId", AV23ComboProductServiceId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSG_TOPAGEID' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new trn_tileloaddvcombo(context ).execute(  "SG_ToPageId",  Gx_mode,  false,  AV45Trn_TileId,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_sg_topageid_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_sg_topageid.SendProperty(context, "", false, Combo_sg_topageid_Internalname, "SelectedValue_set", Combo_sg_topageid_Selectedvalue_set);
         Combo_sg_topageid_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_sg_topageid.SendProperty(context, "", false, Combo_sg_topageid_Internalname, "SelectedText_set", Combo_sg_topageid_Selectedtext_set);
         AV43ComboSG_ToPageId = StringUtil.StrToGuid( AV15ComboSelectedValue);
         AssignAttri("", false, "AV43ComboSG_ToPageId", AV43ComboSG_ToPageId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_sg_topageid_Enabled = false;
            ucCombo_sg_topageid.SendProperty(context, "", false, Combo_sg_topageid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_sg_topageid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPRODUCTSERVICEID' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new trn_tileloaddvcombo(context ).execute(  "ProductServiceId",  Gx_mode,  false,  AV45Trn_TileId,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_productserviceid_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedValue_set", Combo_productserviceid_Selectedvalue_set);
         Combo_productserviceid_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "SelectedText_set", Combo_productserviceid_Selectedtext_set);
         AV23ComboProductServiceId = StringUtil.StrToGuid( AV15ComboSelectedValue);
         AssignAttri("", false, "AV23ComboProductServiceId", AV23ComboProductServiceId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_productserviceid_Enabled = false;
            ucCombo_productserviceid.SendProperty(context, "", false, Combo_productserviceid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_productserviceid_Enabled));
         }
      }

      protected void ZM0Z71( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z265Trn_TileName = T000Z5_A265Trn_TileName[0];
               Z268Trn_TileWidth = T000Z5_A268Trn_TileWidth[0];
               Z270Trn_TileColor = T000Z5_A270Trn_TileColor[0];
               Z271Trn_TileBGImageUrl = T000Z5_A271Trn_TileBGImageUrl[0];
               Z58ProductServiceId = T000Z5_A58ProductServiceId[0];
               Z329SG_ToPageId = T000Z5_A329SG_ToPageId[0];
            }
            else
            {
               Z265Trn_TileName = A265Trn_TileName;
               Z268Trn_TileWidth = A268Trn_TileWidth;
               Z270Trn_TileColor = A270Trn_TileColor;
               Z271Trn_TileBGImageUrl = A271Trn_TileBGImageUrl;
               Z58ProductServiceId = A58ProductServiceId;
               Z329SG_ToPageId = A329SG_ToPageId;
            }
         }
         if ( GX_JID == -19 )
         {
            Z264Trn_TileId = A264Trn_TileId;
            Z265Trn_TileName = A265Trn_TileName;
            Z268Trn_TileWidth = A268Trn_TileWidth;
            Z270Trn_TileColor = A270Trn_TileColor;
            Z271Trn_TileBGImageUrl = A271Trn_TileBGImageUrl;
            Z58ProductServiceId = A58ProductServiceId;
            Z329SG_ToPageId = A329SG_ToPageId;
            Z59ProductServiceName = A59ProductServiceName;
            Z60ProductServiceDescription = A60ProductServiceDescription;
            Z61ProductServiceImage = A61ProductServiceImage;
            Z40000ProductServiceImage_GXI = A40000ProductServiceImage_GXI;
            Z330SG_ToPageName = A330SG_ToPageName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV46Pgmname = "Trn_Tile";
         AssignAttri("", false, "AV46Pgmname", AV46Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV45Trn_TileId) )
         {
            edtTrn_TileId_Enabled = 0;
            AssignProp("", false, edtTrn_TileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_TileId_Enabled), 5, 0), true);
         }
         else
         {
            edtTrn_TileId_Enabled = 1;
            AssignProp("", false, edtTrn_TileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_TileId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV45Trn_TileId) )
         {
            edtTrn_TileId_Enabled = 0;
            AssignProp("", false, edtTrn_TileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_TileId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV20Insert_ProductServiceId) )
         {
            edtProductServiceId_Enabled = 0;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         }
         else
         {
            edtProductServiceId_Enabled = 1;
            AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV41Insert_SG_ToPageId) )
         {
            edtSG_ToPageId_Enabled = 0;
            AssignProp("", false, edtSG_ToPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_ToPageId_Enabled), 5, 0), true);
         }
         else
         {
            edtSG_ToPageId_Enabled = 1;
            AssignProp("", false, edtSG_ToPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_ToPageId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV20Insert_ProductServiceId) )
         {
            A58ProductServiceId = AV20Insert_ProductServiceId;
            n58ProductServiceId = false;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV23ComboProductServiceId) )
            {
               A58ProductServiceId = Guid.Empty;
               n58ProductServiceId = false;
               AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               n58ProductServiceId = true;
               AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV23ComboProductServiceId) )
               {
                  A58ProductServiceId = AV23ComboProductServiceId;
                  n58ProductServiceId = false;
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV41Insert_SG_ToPageId) )
         {
            A329SG_ToPageId = AV41Insert_SG_ToPageId;
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
         }
         else
         {
            A329SG_ToPageId = AV43ComboSG_ToPageId;
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
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
         if ( ! (Guid.Empty==AV45Trn_TileId) )
         {
            A264Trn_TileId = AV45Trn_TileId;
            AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A264Trn_TileId) && ( Gx_BScreen == 0 ) )
            {
               A264Trn_TileId = Guid.NewGuid( );
               AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000Z6 */
            pr_default.execute(4, new Object[] {n58ProductServiceId, A58ProductServiceId});
            A59ProductServiceName = T000Z6_A59ProductServiceName[0];
            A60ProductServiceDescription = T000Z6_A60ProductServiceDescription[0];
            AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
            A40000ProductServiceImage_GXI = T000Z6_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A61ProductServiceImage = T000Z6_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            pr_default.close(4);
            /* Using cursor T000Z7 */
            pr_default.execute(5, new Object[] {A329SG_ToPageId});
            A330SG_ToPageName = T000Z7_A330SG_ToPageName[0];
            pr_default.close(5);
         }
      }

      protected void Load0Z71( )
      {
         /* Using cursor T000Z8 */
         pr_default.execute(6, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound71 = 1;
            A265Trn_TileName = T000Z8_A265Trn_TileName[0];
            AssignAttri("", false, "A265Trn_TileName", A265Trn_TileName);
            A268Trn_TileWidth = T000Z8_A268Trn_TileWidth[0];
            AssignAttri("", false, "A268Trn_TileWidth", StringUtil.LTrimStr( (decimal)(A268Trn_TileWidth), 4, 0));
            A270Trn_TileColor = T000Z8_A270Trn_TileColor[0];
            AssignAttri("", false, "A270Trn_TileColor", A270Trn_TileColor);
            A271Trn_TileBGImageUrl = T000Z8_A271Trn_TileBGImageUrl[0];
            AssignAttri("", false, "A271Trn_TileBGImageUrl", A271Trn_TileBGImageUrl);
            A59ProductServiceName = T000Z8_A59ProductServiceName[0];
            A60ProductServiceDescription = T000Z8_A60ProductServiceDescription[0];
            AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
            A40000ProductServiceImage_GXI = T000Z8_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A330SG_ToPageName = T000Z8_A330SG_ToPageName[0];
            A58ProductServiceId = T000Z8_A58ProductServiceId[0];
            n58ProductServiceId = T000Z8_n58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A329SG_ToPageId = T000Z8_A329SG_ToPageId[0];
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
            A61ProductServiceImage = T000Z8_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            ZM0Z71( -19) ;
         }
         pr_default.close(6);
         OnLoadActions0Z71( ) ;
      }

      protected void OnLoadActions0Z71( )
      {
      }

      protected void CheckExtendedTable0Z71( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A268Trn_TileWidth == 1 ) || ( A268Trn_TileWidth == 2 ) || ( A268Trn_TileWidth == 3 ) ) )
         {
            GX_msglist.addItem("Field Trn_Tile Width is out of range", "OutOfRange", 1, "TRN_TILEWIDTH");
            AnyError = 1;
            GX_FocusControl = cmbTrn_TileWidth_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A271Trn_TileBGImageUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("Field Trn_Tile BGImage Url does not match the specified pattern", "OutOfRange", 1, "TRN_TILEBGIMAGEURL");
            AnyError = 1;
            GX_FocusControl = edtTrn_TileBGImageUrl_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000Z6 */
         pr_default.execute(4, new Object[] {n58ProductServiceId, A58ProductServiceId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) ) )
            {
               GX_msglist.addItem("No matching 'Trn_ProductService'.", "ForeignKeyNotFound", 1, "PRODUCTSERVICEID");
               AnyError = 1;
               GX_FocusControl = edtProductServiceId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A59ProductServiceName = T000Z6_A59ProductServiceName[0];
         A60ProductServiceDescription = T000Z6_A60ProductServiceDescription[0];
         AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
         A40000ProductServiceImage_GXI = T000Z6_A40000ProductServiceImage_GXI[0];
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         A61ProductServiceImage = T000Z6_A61ProductServiceImage[0];
         AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         pr_default.close(4);
         /* Using cursor T000Z7 */
         pr_default.execute(5, new Object[] {A329SG_ToPageId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'SG_To Page'.", "ForeignKeyNotFound", 1, "SG_TOPAGEID");
            AnyError = 1;
            GX_FocusControl = edtSG_ToPageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A330SG_ToPageName = T000Z7_A330SG_ToPageName[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors0Z71( )
      {
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_20( Guid A58ProductServiceId )
      {
         /* Using cursor T000Z9 */
         pr_default.execute(7, new Object[] {n58ProductServiceId, A58ProductServiceId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) ) )
            {
               GX_msglist.addItem("No matching 'Trn_ProductService'.", "ForeignKeyNotFound", 1, "PRODUCTSERVICEID");
               AnyError = 1;
               GX_FocusControl = edtProductServiceId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A59ProductServiceName = T000Z9_A59ProductServiceName[0];
         A60ProductServiceDescription = T000Z9_A60ProductServiceDescription[0];
         AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
         A40000ProductServiceImage_GXI = T000Z9_A40000ProductServiceImage_GXI[0];
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         A61ProductServiceImage = T000Z9_A61ProductServiceImage[0];
         AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A59ProductServiceName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A60ProductServiceDescription)+"\""+","+"\""+GXUtil.EncodeJSConstant( A61ProductServiceImage)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000ProductServiceImage_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_21( Guid A329SG_ToPageId )
      {
         /* Using cursor T000Z10 */
         pr_default.execute(8, new Object[] {A329SG_ToPageId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'SG_To Page'.", "ForeignKeyNotFound", 1, "SG_TOPAGEID");
            AnyError = 1;
            GX_FocusControl = edtSG_ToPageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A330SG_ToPageName = T000Z10_A330SG_ToPageName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A330SG_ToPageName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0Z71( )
      {
         /* Using cursor T000Z11 */
         pr_default.execute(9, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound71 = 1;
         }
         else
         {
            RcdFound71 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Z5 */
         pr_default.execute(3, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0Z71( 19) ;
            RcdFound71 = 1;
            A264Trn_TileId = T000Z5_A264Trn_TileId[0];
            AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
            A265Trn_TileName = T000Z5_A265Trn_TileName[0];
            AssignAttri("", false, "A265Trn_TileName", A265Trn_TileName);
            A268Trn_TileWidth = T000Z5_A268Trn_TileWidth[0];
            AssignAttri("", false, "A268Trn_TileWidth", StringUtil.LTrimStr( (decimal)(A268Trn_TileWidth), 4, 0));
            A270Trn_TileColor = T000Z5_A270Trn_TileColor[0];
            AssignAttri("", false, "A270Trn_TileColor", A270Trn_TileColor);
            A271Trn_TileBGImageUrl = T000Z5_A271Trn_TileBGImageUrl[0];
            AssignAttri("", false, "A271Trn_TileBGImageUrl", A271Trn_TileBGImageUrl);
            A58ProductServiceId = T000Z5_A58ProductServiceId[0];
            n58ProductServiceId = T000Z5_n58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A329SG_ToPageId = T000Z5_A329SG_ToPageId[0];
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
            Z264Trn_TileId = A264Trn_TileId;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Z71( ) ;
            if ( AnyError == 1 )
            {
               RcdFound71 = 0;
               InitializeNonKey0Z71( ) ;
            }
            Gx_mode = sMode71;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound71 = 0;
            InitializeNonKey0Z71( ) ;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode71;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Z71( ) ;
         if ( RcdFound71 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound71 = 0;
         /* Using cursor T000Z12 */
         pr_default.execute(10, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000Z12_A264Trn_TileId[0], A264Trn_TileId, 0) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000Z12_A264Trn_TileId[0], A264Trn_TileId, 0) > 0 ) ) )
            {
               A264Trn_TileId = T000Z12_A264Trn_TileId[0];
               AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
               RcdFound71 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound71 = 0;
         /* Using cursor T000Z13 */
         pr_default.execute(11, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000Z13_A264Trn_TileId[0], A264Trn_TileId, 0) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000Z13_A264Trn_TileId[0], A264Trn_TileId, 0) < 0 ) ) )
            {
               A264Trn_TileId = T000Z13_A264Trn_TileId[0];
               AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
               RcdFound71 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Z71( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrn_TileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Z71( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound71 == 1 )
            {
               if ( A264Trn_TileId != Z264Trn_TileId )
               {
                  A264Trn_TileId = Z264Trn_TileId;
                  AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRN_TILEID");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_TileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrn_TileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0Z71( ) ;
                  GX_FocusControl = edtTrn_TileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A264Trn_TileId != Z264Trn_TileId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTrn_TileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Z71( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_TILEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_TileId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTrn_TileId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Z71( ) ;
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
         if ( A264Trn_TileId != Z264Trn_TileId )
         {
            A264Trn_TileId = Z264Trn_TileId;
            AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRN_TILEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_TileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrn_TileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0Z71( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z4 */
            pr_default.execute(2, new Object[] {A264Trn_TileId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Col"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z265Trn_TileName, T000Z4_A265Trn_TileName[0]) != 0 ) || ( Z268Trn_TileWidth != T000Z4_A268Trn_TileWidth[0] ) || ( StringUtil.StrCmp(Z270Trn_TileColor, T000Z4_A270Trn_TileColor[0]) != 0 ) || ( StringUtil.StrCmp(Z271Trn_TileBGImageUrl, T000Z4_A271Trn_TileBGImageUrl[0]) != 0 ) || ( Z58ProductServiceId != T000Z4_A58ProductServiceId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z329SG_ToPageId != T000Z4_A329SG_ToPageId[0] ) )
            {
               if ( StringUtil.StrCmp(Z265Trn_TileName, T000Z4_A265Trn_TileName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"Trn_TileName");
                  GXUtil.WriteLogRaw("Old: ",Z265Trn_TileName);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A265Trn_TileName[0]);
               }
               if ( Z268Trn_TileWidth != T000Z4_A268Trn_TileWidth[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"Trn_TileWidth");
                  GXUtil.WriteLogRaw("Old: ",Z268Trn_TileWidth);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A268Trn_TileWidth[0]);
               }
               if ( StringUtil.StrCmp(Z270Trn_TileColor, T000Z4_A270Trn_TileColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"Trn_TileColor");
                  GXUtil.WriteLogRaw("Old: ",Z270Trn_TileColor);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A270Trn_TileColor[0]);
               }
               if ( StringUtil.StrCmp(Z271Trn_TileBGImageUrl, T000Z4_A271Trn_TileBGImageUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"Trn_TileBGImageUrl");
                  GXUtil.WriteLogRaw("Old: ",Z271Trn_TileBGImageUrl);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A271Trn_TileBGImageUrl[0]);
               }
               if ( Z58ProductServiceId != T000Z4_A58ProductServiceId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"ProductServiceId");
                  GXUtil.WriteLogRaw("Old: ",Z58ProductServiceId);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A58ProductServiceId[0]);
               }
               if ( Z329SG_ToPageId != T000Z4_A329SG_ToPageId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"SG_ToPageId");
                  GXUtil.WriteLogRaw("Old: ",Z329SG_ToPageId);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A329SG_ToPageId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Col"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z71( )
      {
         if ( ! IsAuthorized("trn_page_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z71( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z71( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z71( 0) ;
            CheckOptimisticConcurrency0Z71( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z71( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z71( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z14 */
                     pr_default.execute(12, new Object[] {A264Trn_TileId, A265Trn_TileName, A268Trn_TileWidth, A270Trn_TileColor, A271Trn_TileBGImageUrl, n58ProductServiceId, A58ProductServiceId, A329SG_ToPageId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Col");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ProcessLevel0Z71( ) ;
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
               Load0Z71( ) ;
            }
            EndLevel0Z71( ) ;
         }
         CloseExtendedTableCursors0Z71( ) ;
      }

      protected void Update0Z71( )
      {
         if ( ! IsAuthorized("trn_page_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z71( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z71( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z71( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z71( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z71( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z15 */
                     pr_default.execute(13, new Object[] {A265Trn_TileName, A268Trn_TileWidth, A270Trn_TileColor, A271Trn_TileBGImageUrl, n58ProductServiceId, A58ProductServiceId, A329SG_ToPageId, A264Trn_TileId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Col");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Col"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z71( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Z71( ) ;
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
            }
            EndLevel0Z71( ) ;
         }
         CloseExtendedTableCursors0Z71( ) ;
      }

      protected void DeferredUpdate0Z71( )
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
         BeforeValidate0Z71( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z71( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z71( ) ;
            AfterConfirm0Z71( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z71( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0Z52( ) ;
                  while ( RcdFound52 != 0 )
                  {
                     getByPrimaryKey0Z52( ) ;
                     Delete0Z52( ) ;
                     ScanNext0Z52( ) ;
                  }
                  ScanEnd0Z52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z16 */
                     pr_default.execute(14, new Object[] {A264Trn_TileId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Col");
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
         }
         sMode71 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z71( ) ;
         Gx_mode = sMode71;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z71( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000Z17 */
            pr_default.execute(15, new Object[] {n58ProductServiceId, A58ProductServiceId});
            A59ProductServiceName = T000Z17_A59ProductServiceName[0];
            A60ProductServiceDescription = T000Z17_A60ProductServiceDescription[0];
            AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
            A40000ProductServiceImage_GXI = T000Z17_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A61ProductServiceImage = T000Z17_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            pr_default.close(15);
            /* Using cursor T000Z18 */
            pr_default.execute(16, new Object[] {A329SG_ToPageId});
            A330SG_ToPageName = T000Z18_A330SG_ToPageName[0];
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000Z19 */
            pr_default.execute(17, new Object[] {A264Trn_TileId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Trn_Col"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel0Z52( )
      {
         nGXsfl_76_idx = 0;
         while ( nGXsfl_76_idx < nRC_GXsfl_76 )
         {
            ReadRow0Z52( ) ;
            if ( ( nRcdExists_52 != 0 ) || ( nIsMod_52 != 0 ) )
            {
               standaloneNotModal0Z52( ) ;
               GetKey0Z52( ) ;
               if ( ( nRcdExists_52 == 0 ) && ( nRcdDeleted_52 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0Z52( ) ;
               }
               else
               {
                  if ( RcdFound52 != 0 )
                  {
                     if ( ( nRcdDeleted_52 != 0 ) && ( nRcdExists_52 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0Z52( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_52 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0Z52( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_52 == 0 )
                     {
                        GXCCtl = "ATTRIBUTEID_" + sGXsfl_76_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtAttributeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAttributeId_Internalname, A272AttributeId.ToString()) ;
            ChangePostValue( edtAttributeName_Internalname, A273AttributeName) ;
            ChangePostValue( edtAttrbuteValue_Internalname, A274AttrbuteValue) ;
            ChangePostValue( "ZT_"+"Z272AttributeId_"+sGXsfl_76_idx, Z272AttributeId.ToString()) ;
            ChangePostValue( "ZT_"+"Z273AttributeName_"+sGXsfl_76_idx, Z273AttributeName) ;
            ChangePostValue( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_76_idx, Z274AttrbuteValue) ;
            ChangePostValue( "nRcdDeleted_52_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_52_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_52_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, ".", ""))) ;
            if ( nIsMod_52 != 0 )
            {
               ChangePostValue( "ATTRIBUTEID_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRIBUTENAME_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRBUTEVALUE_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttrbuteValue_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Z52( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_52 = 0;
         nIsMod_52 = 0;
         nRcdDeleted_52 = 0;
      }

      protected void ProcessLevel0Z71( )
      {
         /* Save parent mode. */
         sMode71 = Gx_mode;
         ProcessNestedLevel0Z52( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode71;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0Z71( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Z71( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_tile",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_tile",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Z71( )
      {
         /* Scan By routine */
         /* Using cursor T000Z20 */
         pr_default.execute(18);
         RcdFound71 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound71 = 1;
            A264Trn_TileId = T000Z20_A264Trn_TileId[0];
            AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z71( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound71 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound71 = 1;
            A264Trn_TileId = T000Z20_A264Trn_TileId[0];
            AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
         }
      }

      protected void ScanEnd0Z71( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0Z71( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z71( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z71( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z71( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z71( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z71( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z71( )
      {
         edtTrn_TileId_Enabled = 0;
         AssignProp("", false, edtTrn_TileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_TileId_Enabled), 5, 0), true);
         edtTrn_TileName_Enabled = 0;
         AssignProp("", false, edtTrn_TileName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_TileName_Enabled), 5, 0), true);
         cmbTrn_TileWidth.Enabled = 0;
         AssignProp("", false, cmbTrn_TileWidth_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrn_TileWidth.Enabled), 5, 0), true);
         cmbTrn_TileColor.Enabled = 0;
         AssignProp("", false, cmbTrn_TileColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrn_TileColor.Enabled), 5, 0), true);
         edtTrn_TileBGImageUrl_Enabled = 0;
         AssignProp("", false, edtTrn_TileBGImageUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_TileBGImageUrl_Enabled), 5, 0), true);
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         edtProductServiceDescription_Enabled = 0;
         AssignProp("", false, edtProductServiceDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceDescription_Enabled), 5, 0), true);
         imgProductServiceImage_Enabled = 0;
         AssignProp("", false, imgProductServiceImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductServiceImage_Enabled), 5, 0), true);
         edtSG_ToPageId_Enabled = 0;
         AssignProp("", false, edtSG_ToPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_ToPageId_Enabled), 5, 0), true);
         edtavComboproductserviceid_Enabled = 0;
         AssignProp("", false, edtavComboproductserviceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboproductserviceid_Enabled), 5, 0), true);
         edtavCombosg_topageid_Enabled = 0;
         AssignProp("", false, edtavCombosg_topageid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosg_topageid_Enabled), 5, 0), true);
      }

      protected void ZM0Z52( short GX_JID )
      {
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z273AttributeName = T000Z3_A273AttributeName[0];
               Z274AttrbuteValue = T000Z3_A274AttrbuteValue[0];
            }
            else
            {
               Z273AttributeName = A273AttributeName;
               Z274AttrbuteValue = A274AttrbuteValue;
            }
         }
         if ( GX_JID == -22 )
         {
            Z264Trn_TileId = A264Trn_TileId;
            Z272AttributeId = A272AttributeId;
            Z273AttributeName = A273AttributeName;
            Z274AttrbuteValue = A274AttrbuteValue;
         }
      }

      protected void standaloneNotModal0Z52( )
      {
      }

      protected void standaloneModal0Z52( )
      {
         if ( IsIns( )  && (Guid.Empty==A272AttributeId) && ( Gx_BScreen == 0 ) )
         {
            A272AttributeId = Guid.NewGuid( );
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtAttributeId_Enabled = 0;
            AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         }
         else
         {
            edtAttributeId_Enabled = 1;
            AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z52( )
      {
         /* Using cursor T000Z21 */
         pr_default.execute(19, new Object[] {A264Trn_TileId, A272AttributeId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound52 = 1;
            A273AttributeName = T000Z21_A273AttributeName[0];
            A274AttrbuteValue = T000Z21_A274AttrbuteValue[0];
            ZM0Z52( -22) ;
         }
         pr_default.close(19);
         OnLoadActions0Z52( ) ;
      }

      protected void OnLoadActions0Z52( )
      {
      }

      protected void CheckExtendedTable0Z52( )
      {
         nIsDirty_52 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0Z52( ) ;
      }

      protected void CloseExtendedTableCursors0Z52( )
      {
      }

      protected void enableDisable0Z52( )
      {
      }

      protected void GetKey0Z52( )
      {
         /* Using cursor T000Z22 */
         pr_default.execute(20, new Object[] {A264Trn_TileId, A272AttributeId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound52 = 1;
         }
         else
         {
            RcdFound52 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey0Z52( )
      {
         /* Using cursor T000Z3 */
         pr_default.execute(1, new Object[] {A264Trn_TileId, A272AttributeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z52( 22) ;
            RcdFound52 = 1;
            InitializeNonKey0Z52( ) ;
            A272AttributeId = T000Z3_A272AttributeId[0];
            A273AttributeName = T000Z3_A273AttributeName[0];
            A274AttrbuteValue = T000Z3_A274AttrbuteValue[0];
            Z264Trn_TileId = A264Trn_TileId;
            Z272AttributeId = A272AttributeId;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Z52( ) ;
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound52 = 0;
            InitializeNonKey0Z52( ) ;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0Z52( ) ;
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Z52( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0Z52( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z2 */
            pr_default.execute(0, new Object[] {A264Trn_TileId, A272AttributeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_TileAttribute"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z273AttributeName, T000Z2_A273AttributeName[0]) != 0 ) || ( StringUtil.StrCmp(Z274AttrbuteValue, T000Z2_A274AttrbuteValue[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z273AttributeName, T000Z2_A273AttributeName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"AttributeName");
                  GXUtil.WriteLogRaw("Old: ",Z273AttributeName);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A273AttributeName[0]);
               }
               if ( StringUtil.StrCmp(Z274AttrbuteValue, T000Z2_A274AttrbuteValue[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"AttrbuteValue");
                  GXUtil.WriteLogRaw("Old: ",Z274AttrbuteValue);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A274AttrbuteValue[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_TileAttribute"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z52( )
      {
         if ( ! IsAuthorized("trn_page_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z52( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z52( 0) ;
            CheckOptimisticConcurrency0Z52( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z52( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z23 */
                     pr_default.execute(21, new Object[] {A264Trn_TileId, A272AttributeId, A273AttributeName, A274AttrbuteValue});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_TileAttribute");
                     if ( (pr_default.getStatus(21) == 1) )
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
               Load0Z52( ) ;
            }
            EndLevel0Z52( ) ;
         }
         CloseExtendedTableCursors0Z52( ) ;
      }

      protected void Update0Z52( )
      {
         if ( ! IsAuthorized("trn_page_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z52( ) ;
         }
         if ( ( nIsMod_52 != 0 ) || ( nIsDirty_52 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0Z52( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0Z52( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0Z52( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000Z24 */
                        pr_default.execute(22, new Object[] {A273AttributeName, A274AttrbuteValue, A264Trn_TileId, A272AttributeId});
                        pr_default.close(22);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_TileAttribute");
                        if ( (pr_default.getStatus(22) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_TileAttribute"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0Z52( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0Z52( ) ;
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
               EndLevel0Z52( ) ;
            }
         }
         CloseExtendedTableCursors0Z52( ) ;
      }

      protected void DeferredUpdate0Z52( )
      {
      }

      protected void Delete0Z52( )
      {
         if ( ! IsAuthorized("trn_page_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Z52( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z52( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z52( ) ;
            AfterConfirm0Z52( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z52( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Z25 */
                  pr_default.execute(23, new Object[] {A264Trn_TileId, A272AttributeId});
                  pr_default.close(23);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_TileAttribute");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode52 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z52( ) ;
         Gx_mode = sMode52;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z52( )
      {
         standaloneModal0Z52( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Z52( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Z52( )
      {
         /* Scan By routine */
         /* Using cursor T000Z26 */
         pr_default.execute(24, new Object[] {A264Trn_TileId});
         RcdFound52 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound52 = 1;
            A272AttributeId = T000Z26_A272AttributeId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z52( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound52 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound52 = 1;
            A272AttributeId = T000Z26_A272AttributeId[0];
         }
      }

      protected void ScanEnd0Z52( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm0Z52( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z52( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z52( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z52( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z52( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z52( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z52( )
      {
         edtAttributeId_Enabled = 0;
         AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtAttributeName_Enabled = 0;
         AssignProp("", false, edtAttributeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeName_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtAttrbuteValue_Enabled = 0;
         AssignProp("", false, edtAttrbuteValue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttrbuteValue_Enabled), 5, 0), !bGXsfl_76_Refreshing);
      }

      protected void send_integrity_lvl_hashes0Z52( )
      {
      }

      protected void send_integrity_lvl_hashes0Z71( )
      {
      }

      protected void SubsflControlProps_7652( )
      {
         edtAttributeId_Internalname = "ATTRIBUTEID_"+sGXsfl_76_idx;
         edtAttributeName_Internalname = "ATTRIBUTENAME_"+sGXsfl_76_idx;
         edtAttrbuteValue_Internalname = "ATTRBUTEVALUE_"+sGXsfl_76_idx;
      }

      protected void SubsflControlProps_fel_7652( )
      {
         edtAttributeId_Internalname = "ATTRIBUTEID_"+sGXsfl_76_fel_idx;
         edtAttributeName_Internalname = "ATTRIBUTENAME_"+sGXsfl_76_fel_idx;
         edtAttrbuteValue_Internalname = "ATTRBUTEVALUE_"+sGXsfl_76_fel_idx;
      }

      protected void AddRow0Z52( )
      {
         nGXsfl_76_idx = (int)(nGXsfl_76_idx+1);
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_7652( ) ;
         SendRow0Z52( ) ;
      }

      protected void SendRow0Z52( )
      {
         Gridlevel_attributeRow = GXWebRow.GetNew(context);
         if ( subGridlevel_attribute_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_attribute_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_attribute_Class, "") != 0 )
            {
               subGridlevel_attribute_Linesclass = subGridlevel_attribute_Class+"Odd";
            }
         }
         else if ( subGridlevel_attribute_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_attribute_Backstyle = 0;
            subGridlevel_attribute_Backcolor = subGridlevel_attribute_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_attribute_Class, "") != 0 )
            {
               subGridlevel_attribute_Linesclass = subGridlevel_attribute_Class+"Uniform";
            }
         }
         else if ( subGridlevel_attribute_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_attribute_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_attribute_Class, "") != 0 )
            {
               subGridlevel_attribute_Linesclass = subGridlevel_attribute_Class+"Odd";
            }
            subGridlevel_attribute_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_attribute_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_attribute_Backstyle = 1;
            if ( ((int)((nGXsfl_76_idx) % (2))) == 0 )
            {
               subGridlevel_attribute_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_attribute_Class, "") != 0 )
               {
                  subGridlevel_attribute_Linesclass = subGridlevel_attribute_Class+"Even";
               }
            }
            else
            {
               subGridlevel_attribute_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_attribute_Class, "") != 0 )
               {
                  subGridlevel_attribute_Linesclass = subGridlevel_attribute_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_52_" + sGXsfl_76_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_76_idx + "',76)\"";
         ROClassString = "Attribute";
         Gridlevel_attributeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttributeId_Internalname,A272AttributeId.ToString(),A272AttributeId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttributeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAttributeId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)76,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_52_" + sGXsfl_76_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_76_idx + "',76)\"";
         ROClassString = "Attribute";
         Gridlevel_attributeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttributeName_Internalname,(string)A273AttributeName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttributeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAttributeName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_52_" + sGXsfl_76_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_76_idx + "',76)\"";
         ROClassString = "Attribute";
         Gridlevel_attributeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttrbuteValue_Internalname,(string)A274AttrbuteValue,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttrbuteValue_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAttrbuteValue_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_attributeRow);
         send_integrity_lvl_hashes0Z52( ) ;
         GXCCtl = "Z272AttributeId_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z272AttributeId.ToString());
         GXCCtl = "Z273AttributeName_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z273AttributeName);
         GXCCtl = "Z274AttrbuteValue_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z274AttrbuteValue);
         GXCCtl = "nRcdDeleted_52_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_52_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, ".", "")));
         GXCCtl = "nIsMod_52_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_76_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTRN_TILEID_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV45Trn_TileId.ToString());
         GxWebStd.gx_hidden_field( context, "ATTRIBUTEID_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTENAME_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRBUTEVALUE_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttrbuteValue_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_attributeContainer.AddRow(Gridlevel_attributeRow);
      }

      protected void ReadRow0Z52( )
      {
         nGXsfl_76_idx = (int)(nGXsfl_76_idx+1);
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_7652( ) ;
         edtAttributeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTEID_"+sGXsfl_76_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtAttributeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTENAME_"+sGXsfl_76_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtAttrbuteValue_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRBUTEVALUE_"+sGXsfl_76_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtAttributeId_Internalname), "") == 0 )
         {
            A272AttributeId = Guid.Empty;
         }
         else
         {
            try
            {
               A272AttributeId = StringUtil.StrToGuid( cgiGet( edtAttributeId_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "ATTRIBUTEID_" + sGXsfl_76_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtAttributeId_Internalname;
               wbErr = true;
            }
         }
         A273AttributeName = cgiGet( edtAttributeName_Internalname);
         A274AttrbuteValue = cgiGet( edtAttrbuteValue_Internalname);
         GXCCtl = "Z272AttributeId_" + sGXsfl_76_idx;
         Z272AttributeId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z273AttributeName_" + sGXsfl_76_idx;
         Z273AttributeName = cgiGet( GXCCtl);
         GXCCtl = "Z274AttrbuteValue_" + sGXsfl_76_idx;
         Z274AttrbuteValue = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_52_" + sGXsfl_76_idx;
         nRcdDeleted_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_52_" + sGXsfl_76_idx;
         nRcdExists_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_52_" + sGXsfl_76_idx;
         nIsMod_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtAttributeId_Enabled = edtAttributeId_Enabled;
      }

      protected void ConfirmValues0Z0( )
      {
         nGXsfl_76_idx = 0;
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_7652( ) ;
         while ( nGXsfl_76_idx < nRC_GXsfl_76 )
         {
            nGXsfl_76_idx = (int)(nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_7652( ) ;
            ChangePostValue( "Z272AttributeId_"+sGXsfl_76_idx, cgiGet( "ZT_"+"Z272AttributeId_"+sGXsfl_76_idx)) ;
            DeletePostValue( "ZT_"+"Z272AttributeId_"+sGXsfl_76_idx) ;
            ChangePostValue( "Z273AttributeName_"+sGXsfl_76_idx, cgiGet( "ZT_"+"Z273AttributeName_"+sGXsfl_76_idx)) ;
            DeletePostValue( "ZT_"+"Z273AttributeName_"+sGXsfl_76_idx) ;
            ChangePostValue( "Z274AttrbuteValue_"+sGXsfl_76_idx, cgiGet( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_76_idx)) ;
            DeletePostValue( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_76_idx) ;
         }
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
         GXEncryptionTmp = "trn_tile.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV45Trn_TileId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_tile.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Tile");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_tile:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z264Trn_TileId", Z264Trn_TileId.ToString());
         GxWebStd.gx_hidden_field( context, "Z265Trn_TileName", Z265Trn_TileName);
         GxWebStd.gx_hidden_field( context, "Z268Trn_TileWidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z268Trn_TileWidth), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z270Trn_TileColor", StringUtil.RTrim( Z270Trn_TileColor));
         GxWebStd.gx_hidden_field( context, "Z271Trn_TileBGImageUrl", Z271Trn_TileBGImageUrl);
         GxWebStd.gx_hidden_field( context, "Z58ProductServiceId", Z58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "Z329SG_ToPageId", Z329SG_ToPageId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_76", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_76_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N58ProductServiceId", A58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "N329SG_ToPageId", A329SG_ToPageId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSERVICEID_DATA", AV22ProductServiceId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSERVICEID_DATA", AV22ProductServiceId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSG_TOPAGEID_DATA", AV42SG_ToPageId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSG_TOPAGEID_DATA", AV42SG_ToPageId_Data);
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
         GxWebStd.gx_hidden_field( context, "vTRN_TILEID", AV45Trn_TileId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRN_TILEID", GetSecureSignedToken( "", AV45Trn_TileId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODUCTSERVICEID", AV20Insert_ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_SG_TOPAGEID", AV41Insert_SG_ToPageId.ToString());
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICENAME", A59ProductServiceName);
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEIMAGE_GXI", A40000ProductServiceImage_GXI);
         GxWebStd.gx_hidden_field( context, "SG_TOPAGENAME", A330SG_ToPageName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GXCCtlgxBlob = "PRODUCTSERVICEIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A61ProductServiceImage);
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Objectcall", StringUtil.RTrim( Combo_productserviceid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Cls", StringUtil.RTrim( Combo_productserviceid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Selectedvalue_set", StringUtil.RTrim( Combo_productserviceid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Selectedtext_set", StringUtil.RTrim( Combo_productserviceid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Gamoauthtoken", StringUtil.RTrim( Combo_productserviceid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Enabled", StringUtil.BoolToStr( Combo_productserviceid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Datalistproc", StringUtil.RTrim( Combo_productserviceid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PRODUCTSERVICEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_productserviceid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Objectcall", StringUtil.RTrim( Combo_sg_topageid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Cls", StringUtil.RTrim( Combo_sg_topageid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Selectedvalue_set", StringUtil.RTrim( Combo_sg_topageid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Selectedtext_set", StringUtil.RTrim( Combo_sg_topageid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Gamoauthtoken", StringUtil.RTrim( Combo_sg_topageid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Enabled", StringUtil.BoolToStr( Combo_sg_topageid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Datalistproc", StringUtil.RTrim( Combo_sg_topageid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_sg_topageid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Emptyitem", StringUtil.BoolToStr( Combo_sg_topageid_Emptyitem));
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
         GXEncryptionTmp = "trn_tile.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV45Trn_TileId.ToString());
         return formatLink("trn_tile.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Tile" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tile" ;
      }

      protected void InitializeNonKey0Z71( )
      {
         A58ProductServiceId = Guid.Empty;
         n58ProductServiceId = false;
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
         A329SG_ToPageId = Guid.Empty;
         AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
         A265Trn_TileName = "";
         AssignAttri("", false, "A265Trn_TileName", A265Trn_TileName);
         A268Trn_TileWidth = 0;
         AssignAttri("", false, "A268Trn_TileWidth", StringUtil.LTrimStr( (decimal)(A268Trn_TileWidth), 4, 0));
         A270Trn_TileColor = "";
         AssignAttri("", false, "A270Trn_TileColor", A270Trn_TileColor);
         A271Trn_TileBGImageUrl = "";
         AssignAttri("", false, "A271Trn_TileBGImageUrl", A271Trn_TileBGImageUrl);
         A59ProductServiceName = "";
         AssignAttri("", false, "A59ProductServiceName", A59ProductServiceName);
         A60ProductServiceDescription = "";
         AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
         A61ProductServiceImage = "";
         AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         A40000ProductServiceImage_GXI = "";
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         A330SG_ToPageName = "";
         AssignAttri("", false, "A330SG_ToPageName", A330SG_ToPageName);
         Z265Trn_TileName = "";
         Z268Trn_TileWidth = 0;
         Z270Trn_TileColor = "";
         Z271Trn_TileBGImageUrl = "";
         Z58ProductServiceId = Guid.Empty;
         Z329SG_ToPageId = Guid.Empty;
      }

      protected void InitAll0Z71( )
      {
         A264Trn_TileId = Guid.NewGuid( );
         AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
         InitializeNonKey0Z71( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0Z52( )
      {
         A273AttributeName = "";
         A274AttrbuteValue = "";
         Z273AttributeName = "";
         Z274AttrbuteValue = "";
      }

      protected void InitAll0Z52( )
      {
         A272AttributeId = Guid.NewGuid( );
         InitializeNonKey0Z52( ) ;
      }

      protected void StandaloneModalInsert0Z52( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20249271948263", true, true);
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
         context.AddJavascriptSource("trn_tile.js", "?20249271948266", false, true);
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

      protected void init_level_properties52( )
      {
         edtAttributeId_Enabled = defedtAttributeId_Enabled;
         AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_76_Refreshing);
      }

      protected void StartGridControl76( )
      {
         Gridlevel_attributeContainer.AddObjectProperty("GridName", "Gridlevel_attribute");
         Gridlevel_attributeContainer.AddObjectProperty("Header", subGridlevel_attribute_Header);
         Gridlevel_attributeContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_attributeContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_attributeContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_attributeContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_attribute_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_attributeContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_attributeContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_attributeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_attributeColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A272AttributeId.ToString()));
         Gridlevel_attributeColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeId_Enabled), 5, 0, ".", "")));
         Gridlevel_attributeContainer.AddColumnProperties(Gridlevel_attributeColumn);
         Gridlevel_attributeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_attributeColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A273AttributeName));
         Gridlevel_attributeColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeName_Enabled), 5, 0, ".", "")));
         Gridlevel_attributeContainer.AddColumnProperties(Gridlevel_attributeColumn);
         Gridlevel_attributeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_attributeColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A274AttrbuteValue));
         Gridlevel_attributeColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttrbuteValue_Enabled), 5, 0, ".", "")));
         Gridlevel_attributeContainer.AddColumnProperties(Gridlevel_attributeColumn);
         Gridlevel_attributeContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_attribute_Selectedindex), 4, 0, ".", "")));
         Gridlevel_attributeContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_attribute_Allowselection), 1, 0, ".", "")));
         Gridlevel_attributeContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_attribute_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_attributeContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_attribute_Allowhovering), 1, 0, ".", "")));
         Gridlevel_attributeContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_attribute_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_attributeContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_attribute_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_attributeContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_attribute_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtTrn_TileId_Internalname = "TRN_TILEID";
         edtTrn_TileName_Internalname = "TRN_TILENAME";
         cmbTrn_TileWidth_Internalname = "TRN_TILEWIDTH";
         cmbTrn_TileColor_Internalname = "TRN_TILECOLOR";
         edtTrn_TileBGImageUrl_Internalname = "TRN_TILEBGIMAGEURL";
         lblTextblockproductserviceid_Internalname = "TEXTBLOCKPRODUCTSERVICEID";
         Combo_productserviceid_Internalname = "COMBO_PRODUCTSERVICEID";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         divTablesplittedproductserviceid_Internalname = "TABLESPLITTEDPRODUCTSERVICEID";
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION";
         imgProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE";
         lblTextblocksg_topageid_Internalname = "TEXTBLOCKSG_TOPAGEID";
         Combo_sg_topageid_Internalname = "COMBO_SG_TOPAGEID";
         edtSG_ToPageId_Internalname = "SG_TOPAGEID";
         divTablesplittedsg_topageid_Internalname = "TABLESPLITTEDSG_TOPAGEID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtAttributeId_Internalname = "ATTRIBUTEID";
         edtAttributeName_Internalname = "ATTRIBUTENAME";
         edtAttrbuteValue_Internalname = "ATTRBUTEVALUE";
         divTableleaflevel_attribute_Internalname = "TABLELEAFLEVEL_ATTRIBUTE";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboproductserviceid_Internalname = "vCOMBOPRODUCTSERVICEID";
         divSectionattribute_productserviceid_Internalname = "SECTIONATTRIBUTE_PRODUCTSERVICEID";
         edtavCombosg_topageid_Internalname = "vCOMBOSG_TOPAGEID";
         divSectionattribute_sg_topageid_Internalname = "SECTIONATTRIBUTE_SG_TOPAGEID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_attribute_Internalname = "GRIDLEVEL_ATTRIBUTE";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_attribute_Allowcollapsing = 0;
         subGridlevel_attribute_Allowselection = 0;
         subGridlevel_attribute_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Tile";
         edtAttrbuteValue_Jsonclick = "";
         edtAttributeName_Jsonclick = "";
         edtAttributeId_Jsonclick = "";
         subGridlevel_attribute_Class = "WorkWith";
         subGridlevel_attribute_Backcolorstyle = 0;
         edtAttrbuteValue_Enabled = 1;
         edtAttributeName_Enabled = 1;
         edtAttributeId_Enabled = 1;
         edtavCombosg_topageid_Jsonclick = "";
         edtavCombosg_topageid_Enabled = 0;
         edtavCombosg_topageid_Visible = 1;
         edtavComboproductserviceid_Jsonclick = "";
         edtavComboproductserviceid_Enabled = 0;
         edtavComboproductserviceid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSG_ToPageId_Jsonclick = "";
         edtSG_ToPageId_Enabled = 1;
         edtSG_ToPageId_Visible = 1;
         Combo_sg_topageid_Emptyitem = Convert.ToBoolean( 0);
         Combo_sg_topageid_Datalistprocparametersprefix = " \"ComboName\": \"SG_ToPageId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"Trn_TileId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_sg_topageid_Datalistproc = "Trn_TileLoadDVCombo";
         Combo_sg_topageid_Cls = "ExtendedCombo Attribute";
         Combo_sg_topageid_Caption = "";
         Combo_sg_topageid_Enabled = Convert.ToBoolean( -1);
         imgProductServiceImage_Enabled = 0;
         edtProductServiceDescription_Enabled = 0;
         edtProductServiceId_Jsonclick = "";
         edtProductServiceId_Enabled = 1;
         edtProductServiceId_Visible = 1;
         Combo_productserviceid_Datalistprocparametersprefix = " \"ComboName\": \"ProductServiceId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"Trn_TileId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_productserviceid_Datalistproc = "Trn_TileLoadDVCombo";
         Combo_productserviceid_Cls = "ExtendedCombo Attribute";
         Combo_productserviceid_Caption = "";
         Combo_productserviceid_Enabled = Convert.ToBoolean( -1);
         edtTrn_TileBGImageUrl_Jsonclick = "";
         edtTrn_TileBGImageUrl_Enabled = 1;
         cmbTrn_TileColor_Jsonclick = "";
         cmbTrn_TileColor.Enabled = 1;
         cmbTrn_TileWidth_Jsonclick = "";
         cmbTrn_TileWidth.Enabled = 1;
         edtTrn_TileName_Jsonclick = "";
         edtTrn_TileName_Enabled = 1;
         edtTrn_TileId_Jsonclick = "";
         edtTrn_TileId_Enabled = 1;
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

      protected void gxnrGridlevel_attribute_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_7652( ) ;
         while ( nGXsfl_76_idx <= nRC_GXsfl_76 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0Z52( ) ;
            standaloneModal0Z52( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0Z52( ) ;
            nGXsfl_76_idx = (int)(nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_7652( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_attributeContainer)) ;
         /* End function gxnrGridlevel_attribute_newrow */
      }

      protected void init_web_controls( )
      {
         cmbTrn_TileWidth.Name = "TRN_TILEWIDTH";
         cmbTrn_TileWidth.WebTags = "";
         cmbTrn_TileWidth.addItem("1", "Small", 0);
         cmbTrn_TileWidth.addItem("2", "Medium", 0);
         cmbTrn_TileWidth.addItem("3", "Large", 0);
         if ( cmbTrn_TileWidth.ItemCount > 0 )
         {
            A268Trn_TileWidth = (short)(Math.Round(NumberUtil.Val( cmbTrn_TileWidth.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A268Trn_TileWidth), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A268Trn_TileWidth", StringUtil.LTrimStr( (decimal)(A268Trn_TileWidth), 4, 0));
         }
         cmbTrn_TileColor.Name = "TRN_TILECOLOR";
         cmbTrn_TileColor.WebTags = "";
         if ( cmbTrn_TileColor.ItemCount > 0 )
         {
            A270Trn_TileColor = cmbTrn_TileColor.getValidValue(A270Trn_TileColor);
            AssignAttri("", false, "A270Trn_TileColor", A270Trn_TileColor);
         }
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

      public void Valid_Productserviceid( )
      {
         n58ProductServiceId = false;
         /* Using cursor T000Z17 */
         pr_default.execute(15, new Object[] {n58ProductServiceId, A58ProductServiceId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) ) )
            {
               GX_msglist.addItem("No matching 'Trn_ProductService'.", "ForeignKeyNotFound", 1, "PRODUCTSERVICEID");
               AnyError = 1;
               GX_FocusControl = edtProductServiceId_Internalname;
            }
         }
         A59ProductServiceName = T000Z17_A59ProductServiceName[0];
         A60ProductServiceDescription = T000Z17_A60ProductServiceDescription[0];
         A40000ProductServiceImage_GXI = T000Z17_A40000ProductServiceImage_GXI[0];
         A61ProductServiceImage = T000Z17_A61ProductServiceImage[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A59ProductServiceName", A59ProductServiceName);
         AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
         AssignAttri("", false, "A61ProductServiceImage", context.PathToRelativeUrl( A61ProductServiceImage));
         GXCCtlgxBlob = "PRODUCTSERVICEIMAGE" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A61ProductServiceImage));
         AssignAttri("", false, "A40000ProductServiceImage_GXI", A40000ProductServiceImage_GXI);
      }

      public void Valid_Sg_topageid( )
      {
         /* Using cursor T000Z18 */
         pr_default.execute(16, new Object[] {A329SG_ToPageId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching 'SG_To Page'.", "ForeignKeyNotFound", 1, "SG_TOPAGEID");
            AnyError = 1;
            GX_FocusControl = edtSG_ToPageId_Internalname;
         }
         A330SG_ToPageName = T000Z18_A330SG_ToPageName[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A330SG_ToPageName", A330SG_ToPageName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV45Trn_TileId","fld":"vTRN_TILEID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV45Trn_TileId","fld":"vTRN_TILEID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E140Z2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_SG_TOPAGEID.ONOPTIONCLICKED","""{"handler":"E130Z2","iparms":[{"av":"Combo_sg_topageid_Selectedvalue_get","ctrl":"COMBO_SG_TOPAGEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SG_TOPAGEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV43ComboSG_ToPageId","fld":"vCOMBOSG_TOPAGEID"}]}""");
         setEventMetadata("COMBO_PRODUCTSERVICEID.ONOPTIONCLICKED","""{"handler":"E120Z2","iparms":[{"av":"Combo_productserviceid_Selectedvalue_get","ctrl":"COMBO_PRODUCTSERVICEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_PRODUCTSERVICEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV23ComboProductServiceId","fld":"vCOMBOPRODUCTSERVICEID"}]}""");
         setEventMetadata("VALID_TRN_TILEID","""{"handler":"Valid_Trn_tileid","iparms":[]}""");
         setEventMetadata("VALID_TRN_TILEWIDTH","""{"handler":"Valid_Trn_tilewidth","iparms":[]}""");
         setEventMetadata("VALID_TRN_TILEBGIMAGEURL","""{"handler":"Valid_Trn_tilebgimageurl","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"A59ProductServiceName","fld":"PRODUCTSERVICENAME"},{"av":"A60ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION"},{"av":"A61ProductServiceImage","fld":"PRODUCTSERVICEIMAGE"},{"av":"A40000ProductServiceImage_GXI","fld":"PRODUCTSERVICEIMAGE_GXI"}]""");
         setEventMetadata("VALID_PRODUCTSERVICEID",""","oparms":[{"av":"A59ProductServiceName","fld":"PRODUCTSERVICENAME"},{"av":"A60ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION"},{"av":"A61ProductServiceImage","fld":"PRODUCTSERVICEIMAGE"},{"av":"A40000ProductServiceImage_GXI","fld":"PRODUCTSERVICEIMAGE_GXI"}]}""");
         setEventMetadata("VALID_SG_TOPAGEID","""{"handler":"Valid_Sg_topageid","iparms":[{"av":"A329SG_ToPageId","fld":"SG_TOPAGEID"},{"av":"A330SG_ToPageName","fld":"SG_TOPAGENAME"}]""");
         setEventMetadata("VALID_SG_TOPAGEID",""","oparms":[{"av":"A330SG_ToPageName","fld":"SG_TOPAGENAME"}]}""");
         setEventMetadata("VALIDV_COMBOPRODUCTSERVICEID","""{"handler":"Validv_Comboproductserviceid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSG_TOPAGEID","""{"handler":"Validv_Combosg_topageid","iparms":[]}""");
         setEventMetadata("VALID_ATTRIBUTEID","""{"handler":"Valid_Attributeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Attrbutevalue","iparms":[]}""");
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
         pr_default.close(3);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV45Trn_TileId = Guid.Empty;
         Z264Trn_TileId = Guid.Empty;
         Z265Trn_TileName = "";
         Z270Trn_TileColor = "";
         Z271Trn_TileBGImageUrl = "";
         Z58ProductServiceId = Guid.Empty;
         Z329SG_ToPageId = Guid.Empty;
         N58ProductServiceId = Guid.Empty;
         N329SG_ToPageId = Guid.Empty;
         Combo_sg_topageid_Selectedvalue_get = "";
         Combo_productserviceid_Selectedvalue_get = "";
         Z272AttributeId = Guid.Empty;
         Z273AttributeName = "";
         Z274AttrbuteValue = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A58ProductServiceId = Guid.Empty;
         A329SG_ToPageId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A270Trn_TileColor = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A264Trn_TileId = Guid.Empty;
         A265Trn_TileName = "";
         A271Trn_TileBGImageUrl = "";
         lblTextblockproductserviceid_Jsonclick = "";
         ucCombo_productserviceid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV22ProductServiceId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A60ProductServiceDescription = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         sImgUrl = "";
         lblTextblocksg_topageid_Jsonclick = "";
         ucCombo_sg_topageid = new GXUserControl();
         AV42SG_ToPageId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV23ComboProductServiceId = Guid.Empty;
         AV43ComboSG_ToPageId = Guid.Empty;
         Gridlevel_attributeContainer = new GXWebGrid( context);
         sMode52 = "";
         A272AttributeId = Guid.Empty;
         sStyleString = "";
         AV20Insert_ProductServiceId = Guid.Empty;
         AV41Insert_SG_ToPageId = Guid.Empty;
         A59ProductServiceName = "";
         A330SG_ToPageName = "";
         AV46Pgmname = "";
         Combo_productserviceid_Objectcall = "";
         Combo_productserviceid_Class = "";
         Combo_productserviceid_Icontype = "";
         Combo_productserviceid_Icon = "";
         Combo_productserviceid_Tooltip = "";
         Combo_productserviceid_Selectedvalue_set = "";
         Combo_productserviceid_Selectedtext_set = "";
         Combo_productserviceid_Selectedtext_get = "";
         Combo_productserviceid_Gamoauthtoken = "";
         Combo_productserviceid_Ddointernalname = "";
         Combo_productserviceid_Titlecontrolalign = "";
         Combo_productserviceid_Dropdownoptionstype = "";
         Combo_productserviceid_Titlecontrolidtoreplace = "";
         Combo_productserviceid_Datalisttype = "";
         Combo_productserviceid_Datalistfixedvalues = "";
         Combo_productserviceid_Remoteservicesparameters = "";
         Combo_productserviceid_Htmltemplate = "";
         Combo_productserviceid_Multiplevaluestype = "";
         Combo_productserviceid_Loadingdata = "";
         Combo_productserviceid_Noresultsfound = "";
         Combo_productserviceid_Emptyitemtext = "";
         Combo_productserviceid_Onlyselectedvalues = "";
         Combo_productserviceid_Selectalltext = "";
         Combo_productserviceid_Multiplevaluesseparator = "";
         Combo_productserviceid_Addnewoptiontext = "";
         Combo_sg_topageid_Objectcall = "";
         Combo_sg_topageid_Class = "";
         Combo_sg_topageid_Icontype = "";
         Combo_sg_topageid_Icon = "";
         Combo_sg_topageid_Tooltip = "";
         Combo_sg_topageid_Selectedvalue_set = "";
         Combo_sg_topageid_Selectedtext_set = "";
         Combo_sg_topageid_Selectedtext_get = "";
         Combo_sg_topageid_Gamoauthtoken = "";
         Combo_sg_topageid_Ddointernalname = "";
         Combo_sg_topageid_Titlecontrolalign = "";
         Combo_sg_topageid_Dropdownoptionstype = "";
         Combo_sg_topageid_Titlecontrolidtoreplace = "";
         Combo_sg_topageid_Datalisttype = "";
         Combo_sg_topageid_Datalistfixedvalues = "";
         Combo_sg_topageid_Remoteservicesparameters = "";
         Combo_sg_topageid_Htmltemplate = "";
         Combo_sg_topageid_Multiplevaluestype = "";
         Combo_sg_topageid_Loadingdata = "";
         Combo_sg_topageid_Noresultsfound = "";
         Combo_sg_topageid_Emptyitemtext = "";
         Combo_sg_topageid_Onlyselectedvalues = "";
         Combo_sg_topageid_Selectalltext = "";
         Combo_sg_topageid_Multiplevaluesseparator = "";
         Combo_sg_topageid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode71 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A273AttributeName = "";
         A274AttrbuteValue = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV18GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV19GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV21TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV17Combo_DataJson = "";
         AV15ComboSelectedValue = "";
         AV16ComboSelectedText = "";
         GXt_char2 = "";
         Z59ProductServiceName = "";
         Z60ProductServiceDescription = "";
         Z61ProductServiceImage = "";
         Z40000ProductServiceImage_GXI = "";
         Z330SG_ToPageName = "";
         T000Z6_A59ProductServiceName = new string[] {""} ;
         T000Z6_A60ProductServiceDescription = new string[] {""} ;
         T000Z6_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z6_A61ProductServiceImage = new string[] {""} ;
         T000Z7_A330SG_ToPageName = new string[] {""} ;
         T000Z8_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z8_A265Trn_TileName = new string[] {""} ;
         T000Z8_A268Trn_TileWidth = new short[1] ;
         T000Z8_A270Trn_TileColor = new string[] {""} ;
         T000Z8_A271Trn_TileBGImageUrl = new string[] {""} ;
         T000Z8_A59ProductServiceName = new string[] {""} ;
         T000Z8_A60ProductServiceDescription = new string[] {""} ;
         T000Z8_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z8_A330SG_ToPageName = new string[] {""} ;
         T000Z8_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z8_n58ProductServiceId = new bool[] {false} ;
         T000Z8_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         T000Z8_A61ProductServiceImage = new string[] {""} ;
         T000Z9_A59ProductServiceName = new string[] {""} ;
         T000Z9_A60ProductServiceDescription = new string[] {""} ;
         T000Z9_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z9_A61ProductServiceImage = new string[] {""} ;
         T000Z10_A330SG_ToPageName = new string[] {""} ;
         T000Z11_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z5_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z5_A265Trn_TileName = new string[] {""} ;
         T000Z5_A268Trn_TileWidth = new short[1] ;
         T000Z5_A270Trn_TileColor = new string[] {""} ;
         T000Z5_A271Trn_TileBGImageUrl = new string[] {""} ;
         T000Z5_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z5_n58ProductServiceId = new bool[] {false} ;
         T000Z5_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         T000Z12_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z13_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z4_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z4_A265Trn_TileName = new string[] {""} ;
         T000Z4_A268Trn_TileWidth = new short[1] ;
         T000Z4_A270Trn_TileColor = new string[] {""} ;
         T000Z4_A271Trn_TileBGImageUrl = new string[] {""} ;
         T000Z4_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z4_n58ProductServiceId = new bool[] {false} ;
         T000Z4_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         T000Z17_A59ProductServiceName = new string[] {""} ;
         T000Z17_A60ProductServiceDescription = new string[] {""} ;
         T000Z17_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z17_A61ProductServiceImage = new string[] {""} ;
         T000Z18_A330SG_ToPageName = new string[] {""} ;
         T000Z19_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         T000Z20_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z21_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z21_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z21_A273AttributeName = new string[] {""} ;
         T000Z21_A274AttrbuteValue = new string[] {""} ;
         T000Z22_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z22_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z3_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z3_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z3_A273AttributeName = new string[] {""} ;
         T000Z3_A274AttrbuteValue = new string[] {""} ;
         T000Z2_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z2_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z2_A273AttributeName = new string[] {""} ;
         T000Z2_A274AttrbuteValue = new string[] {""} ;
         T000Z26_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z26_A272AttributeId = new Guid[] {Guid.Empty} ;
         Gridlevel_attributeRow = new GXWebRow();
         subGridlevel_attribute_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         Gridlevel_attributeColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_tile__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tile__default(),
            new Object[][] {
                new Object[] {
               T000Z2_A264Trn_TileId, T000Z2_A272AttributeId, T000Z2_A273AttributeName, T000Z2_A274AttrbuteValue
               }
               , new Object[] {
               T000Z3_A264Trn_TileId, T000Z3_A272AttributeId, T000Z3_A273AttributeName, T000Z3_A274AttrbuteValue
               }
               , new Object[] {
               T000Z4_A264Trn_TileId, T000Z4_A265Trn_TileName, T000Z4_A268Trn_TileWidth, T000Z4_A270Trn_TileColor, T000Z4_A271Trn_TileBGImageUrl, T000Z4_A58ProductServiceId, T000Z4_n58ProductServiceId, T000Z4_A329SG_ToPageId
               }
               , new Object[] {
               T000Z5_A264Trn_TileId, T000Z5_A265Trn_TileName, T000Z5_A268Trn_TileWidth, T000Z5_A270Trn_TileColor, T000Z5_A271Trn_TileBGImageUrl, T000Z5_A58ProductServiceId, T000Z5_n58ProductServiceId, T000Z5_A329SG_ToPageId
               }
               , new Object[] {
               T000Z6_A59ProductServiceName, T000Z6_A60ProductServiceDescription, T000Z6_A40000ProductServiceImage_GXI, T000Z6_A61ProductServiceImage
               }
               , new Object[] {
               T000Z7_A330SG_ToPageName
               }
               , new Object[] {
               T000Z8_A264Trn_TileId, T000Z8_A265Trn_TileName, T000Z8_A268Trn_TileWidth, T000Z8_A270Trn_TileColor, T000Z8_A271Trn_TileBGImageUrl, T000Z8_A59ProductServiceName, T000Z8_A60ProductServiceDescription, T000Z8_A40000ProductServiceImage_GXI, T000Z8_A330SG_ToPageName, T000Z8_A58ProductServiceId,
               T000Z8_n58ProductServiceId, T000Z8_A329SG_ToPageId, T000Z8_A61ProductServiceImage
               }
               , new Object[] {
               T000Z9_A59ProductServiceName, T000Z9_A60ProductServiceDescription, T000Z9_A40000ProductServiceImage_GXI, T000Z9_A61ProductServiceImage
               }
               , new Object[] {
               T000Z10_A330SG_ToPageName
               }
               , new Object[] {
               T000Z11_A264Trn_TileId
               }
               , new Object[] {
               T000Z12_A264Trn_TileId
               }
               , new Object[] {
               T000Z13_A264Trn_TileId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z17_A59ProductServiceName, T000Z17_A60ProductServiceDescription, T000Z17_A40000ProductServiceImage_GXI, T000Z17_A61ProductServiceImage
               }
               , new Object[] {
               T000Z18_A330SG_ToPageName
               }
               , new Object[] {
               T000Z19_A328Trn_ColId
               }
               , new Object[] {
               T000Z20_A264Trn_TileId
               }
               , new Object[] {
               T000Z21_A264Trn_TileId, T000Z21_A272AttributeId, T000Z21_A273AttributeName, T000Z21_A274AttrbuteValue
               }
               , new Object[] {
               T000Z22_A264Trn_TileId, T000Z22_A272AttributeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z26_A264Trn_TileId, T000Z26_A272AttributeId
               }
            }
         );
         Z272AttributeId = Guid.NewGuid( );
         A272AttributeId = Guid.NewGuid( );
         Z264Trn_TileId = Guid.NewGuid( );
         A264Trn_TileId = Guid.NewGuid( );
         AV46Pgmname = "Trn_Tile";
      }

      private short Z268Trn_TileWidth ;
      private short nRcdDeleted_52 ;
      private short nRcdExists_52 ;
      private short nIsMod_52 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short A268Trn_TileWidth ;
      private short nBlankRcdCount52 ;
      private short RcdFound52 ;
      private short nBlankRcdUsr52 ;
      private short RcdFound71 ;
      private short nIsDirty_52 ;
      private short subGridlevel_attribute_Backcolorstyle ;
      private short subGridlevel_attribute_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_attribute_Allowselection ;
      private short subGridlevel_attribute_Allowhovering ;
      private short subGridlevel_attribute_Allowcollapsing ;
      private short subGridlevel_attribute_Collapsed ;
      private int nRC_GXsfl_76 ;
      private int nGXsfl_76_idx=1 ;
      private int trnEnded ;
      private int edtTrn_TileId_Enabled ;
      private int edtTrn_TileName_Enabled ;
      private int edtTrn_TileBGImageUrl_Enabled ;
      private int edtProductServiceId_Visible ;
      private int edtProductServiceId_Enabled ;
      private int edtProductServiceDescription_Enabled ;
      private int imgProductServiceImage_Enabled ;
      private int edtSG_ToPageId_Visible ;
      private int edtSG_ToPageId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboproductserviceid_Visible ;
      private int edtavComboproductserviceid_Enabled ;
      private int edtavCombosg_topageid_Visible ;
      private int edtavCombosg_topageid_Enabled ;
      private int edtAttributeId_Enabled ;
      private int edtAttributeName_Enabled ;
      private int edtAttrbuteValue_Enabled ;
      private int fRowAdded ;
      private int Combo_productserviceid_Datalistupdateminimumcharacters ;
      private int Combo_productserviceid_Gxcontroltype ;
      private int Combo_sg_topageid_Datalistupdateminimumcharacters ;
      private int Combo_sg_topageid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV47GXV1 ;
      private int subGridlevel_attribute_Backcolor ;
      private int subGridlevel_attribute_Allbackcolor ;
      private int defedtAttributeId_Enabled ;
      private int idxLst ;
      private int subGridlevel_attribute_Selectedindex ;
      private int subGridlevel_attribute_Selectioncolor ;
      private int subGridlevel_attribute_Hoveringcolor ;
      private long GRIDLEVEL_ATTRIBUTE_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z270Trn_TileColor ;
      private string Combo_sg_topageid_Selectedvalue_get ;
      private string Combo_productserviceid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrn_TileId_Internalname ;
      private string sGXsfl_76_idx="0001" ;
      private string cmbTrn_TileWidth_Internalname ;
      private string A270Trn_TileColor ;
      private string cmbTrn_TileColor_Internalname ;
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
      private string edtTrn_TileId_Jsonclick ;
      private string edtTrn_TileName_Internalname ;
      private string edtTrn_TileName_Jsonclick ;
      private string cmbTrn_TileWidth_Jsonclick ;
      private string cmbTrn_TileColor_Jsonclick ;
      private string edtTrn_TileBGImageUrl_Internalname ;
      private string edtTrn_TileBGImageUrl_Jsonclick ;
      private string divTablesplittedproductserviceid_Internalname ;
      private string lblTextblockproductserviceid_Internalname ;
      private string lblTextblockproductserviceid_Jsonclick ;
      private string Combo_productserviceid_Caption ;
      private string Combo_productserviceid_Cls ;
      private string Combo_productserviceid_Datalistproc ;
      private string Combo_productserviceid_Datalistprocparametersprefix ;
      private string Combo_productserviceid_Internalname ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceId_Jsonclick ;
      private string edtProductServiceDescription_Internalname ;
      private string imgProductServiceImage_Internalname ;
      private string sImgUrl ;
      private string divTablesplittedsg_topageid_Internalname ;
      private string lblTextblocksg_topageid_Internalname ;
      private string lblTextblocksg_topageid_Jsonclick ;
      private string Combo_sg_topageid_Caption ;
      private string Combo_sg_topageid_Cls ;
      private string Combo_sg_topageid_Datalistproc ;
      private string Combo_sg_topageid_Datalistprocparametersprefix ;
      private string Combo_sg_topageid_Internalname ;
      private string edtSG_ToPageId_Internalname ;
      private string edtSG_ToPageId_Jsonclick ;
      private string divTableleaflevel_attribute_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_productserviceid_Internalname ;
      private string edtavComboproductserviceid_Internalname ;
      private string edtavComboproductserviceid_Jsonclick ;
      private string divSectionattribute_sg_topageid_Internalname ;
      private string edtavCombosg_topageid_Internalname ;
      private string edtavCombosg_topageid_Jsonclick ;
      private string sMode52 ;
      private string edtAttributeId_Internalname ;
      private string edtAttributeName_Internalname ;
      private string edtAttrbuteValue_Internalname ;
      private string sStyleString ;
      private string subGridlevel_attribute_Internalname ;
      private string AV46Pgmname ;
      private string Combo_productserviceid_Objectcall ;
      private string Combo_productserviceid_Class ;
      private string Combo_productserviceid_Icontype ;
      private string Combo_productserviceid_Icon ;
      private string Combo_productserviceid_Tooltip ;
      private string Combo_productserviceid_Selectedvalue_set ;
      private string Combo_productserviceid_Selectedtext_set ;
      private string Combo_productserviceid_Selectedtext_get ;
      private string Combo_productserviceid_Gamoauthtoken ;
      private string Combo_productserviceid_Ddointernalname ;
      private string Combo_productserviceid_Titlecontrolalign ;
      private string Combo_productserviceid_Dropdownoptionstype ;
      private string Combo_productserviceid_Titlecontrolidtoreplace ;
      private string Combo_productserviceid_Datalisttype ;
      private string Combo_productserviceid_Datalistfixedvalues ;
      private string Combo_productserviceid_Remoteservicesparameters ;
      private string Combo_productserviceid_Htmltemplate ;
      private string Combo_productserviceid_Multiplevaluestype ;
      private string Combo_productserviceid_Loadingdata ;
      private string Combo_productserviceid_Noresultsfound ;
      private string Combo_productserviceid_Emptyitemtext ;
      private string Combo_productserviceid_Onlyselectedvalues ;
      private string Combo_productserviceid_Selectalltext ;
      private string Combo_productserviceid_Multiplevaluesseparator ;
      private string Combo_productserviceid_Addnewoptiontext ;
      private string Combo_sg_topageid_Objectcall ;
      private string Combo_sg_topageid_Class ;
      private string Combo_sg_topageid_Icontype ;
      private string Combo_sg_topageid_Icon ;
      private string Combo_sg_topageid_Tooltip ;
      private string Combo_sg_topageid_Selectedvalue_set ;
      private string Combo_sg_topageid_Selectedtext_set ;
      private string Combo_sg_topageid_Selectedtext_get ;
      private string Combo_sg_topageid_Gamoauthtoken ;
      private string Combo_sg_topageid_Ddointernalname ;
      private string Combo_sg_topageid_Titlecontrolalign ;
      private string Combo_sg_topageid_Dropdownoptionstype ;
      private string Combo_sg_topageid_Titlecontrolidtoreplace ;
      private string Combo_sg_topageid_Datalisttype ;
      private string Combo_sg_topageid_Datalistfixedvalues ;
      private string Combo_sg_topageid_Remoteservicesparameters ;
      private string Combo_sg_topageid_Htmltemplate ;
      private string Combo_sg_topageid_Multiplevaluestype ;
      private string Combo_sg_topageid_Loadingdata ;
      private string Combo_sg_topageid_Noresultsfound ;
      private string Combo_sg_topageid_Emptyitemtext ;
      private string Combo_sg_topageid_Onlyselectedvalues ;
      private string Combo_sg_topageid_Selectalltext ;
      private string Combo_sg_topageid_Multiplevaluesseparator ;
      private string Combo_sg_topageid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode71 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string GXt_char2 ;
      private string sGXsfl_76_fel_idx="0001" ;
      private string subGridlevel_attribute_Class ;
      private string subGridlevel_attribute_Linesclass ;
      private string ROClassString ;
      private string edtAttributeId_Jsonclick ;
      private string edtAttributeName_Jsonclick ;
      private string edtAttrbuteValue_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private string subGridlevel_attribute_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n58ProductServiceId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A61ProductServiceImage_IsBlob ;
      private bool Combo_sg_topageid_Emptyitem ;
      private bool bGXsfl_76_Refreshing=false ;
      private bool Combo_productserviceid_Enabled ;
      private bool Combo_productserviceid_Visible ;
      private bool Combo_productserviceid_Allowmultipleselection ;
      private bool Combo_productserviceid_Isgriditem ;
      private bool Combo_productserviceid_Hasdescription ;
      private bool Combo_productserviceid_Includeonlyselectedoption ;
      private bool Combo_productserviceid_Includeselectalloption ;
      private bool Combo_productserviceid_Emptyitem ;
      private bool Combo_productserviceid_Includeaddnewoption ;
      private bool Combo_sg_topageid_Enabled ;
      private bool Combo_sg_topageid_Visible ;
      private bool Combo_sg_topageid_Allowmultipleselection ;
      private bool Combo_sg_topageid_Isgriditem ;
      private bool Combo_sg_topageid_Hasdescription ;
      private bool Combo_sg_topageid_Includeonlyselectedoption ;
      private bool Combo_sg_topageid_Includeselectalloption ;
      private bool Combo_sg_topageid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV17Combo_DataJson ;
      private string Z265Trn_TileName ;
      private string Z271Trn_TileBGImageUrl ;
      private string Z273AttributeName ;
      private string Z274AttrbuteValue ;
      private string A265Trn_TileName ;
      private string A271Trn_TileBGImageUrl ;
      private string A60ProductServiceDescription ;
      private string A40000ProductServiceImage_GXI ;
      private string A59ProductServiceName ;
      private string A330SG_ToPageName ;
      private string A273AttributeName ;
      private string A274AttrbuteValue ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private string Z59ProductServiceName ;
      private string Z60ProductServiceDescription ;
      private string Z40000ProductServiceImage_GXI ;
      private string Z330SG_ToPageName ;
      private string A61ProductServiceImage ;
      private string Z61ProductServiceImage ;
      private Guid wcpOAV45Trn_TileId ;
      private Guid Z264Trn_TileId ;
      private Guid Z58ProductServiceId ;
      private Guid Z329SG_ToPageId ;
      private Guid N58ProductServiceId ;
      private Guid N329SG_ToPageId ;
      private Guid Z272AttributeId ;
      private Guid A58ProductServiceId ;
      private Guid A329SG_ToPageId ;
      private Guid AV45Trn_TileId ;
      private Guid A264Trn_TileId ;
      private Guid AV23ComboProductServiceId ;
      private Guid AV43ComboSG_ToPageId ;
      private Guid A272AttributeId ;
      private Guid AV20Insert_ProductServiceId ;
      private Guid AV41Insert_SG_ToPageId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_attributeContainer ;
      private GXWebRow Gridlevel_attributeRow ;
      private GXWebColumn Gridlevel_attributeColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_productserviceid ;
      private GXUserControl ucCombo_sg_topageid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTrn_TileWidth ;
      private GXCombobox cmbTrn_TileColor ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22ProductServiceId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV42SG_ToPageId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV18GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV19GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV21TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000Z6_A59ProductServiceName ;
      private string[] T000Z6_A60ProductServiceDescription ;
      private string[] T000Z6_A40000ProductServiceImage_GXI ;
      private string[] T000Z6_A61ProductServiceImage ;
      private string[] T000Z7_A330SG_ToPageName ;
      private Guid[] T000Z8_A264Trn_TileId ;
      private string[] T000Z8_A265Trn_TileName ;
      private short[] T000Z8_A268Trn_TileWidth ;
      private string[] T000Z8_A270Trn_TileColor ;
      private string[] T000Z8_A271Trn_TileBGImageUrl ;
      private string[] T000Z8_A59ProductServiceName ;
      private string[] T000Z8_A60ProductServiceDescription ;
      private string[] T000Z8_A40000ProductServiceImage_GXI ;
      private string[] T000Z8_A330SG_ToPageName ;
      private Guid[] T000Z8_A58ProductServiceId ;
      private bool[] T000Z8_n58ProductServiceId ;
      private Guid[] T000Z8_A329SG_ToPageId ;
      private string[] T000Z8_A61ProductServiceImage ;
      private string[] T000Z9_A59ProductServiceName ;
      private string[] T000Z9_A60ProductServiceDescription ;
      private string[] T000Z9_A40000ProductServiceImage_GXI ;
      private string[] T000Z9_A61ProductServiceImage ;
      private string[] T000Z10_A330SG_ToPageName ;
      private Guid[] T000Z11_A264Trn_TileId ;
      private Guid[] T000Z5_A264Trn_TileId ;
      private string[] T000Z5_A265Trn_TileName ;
      private short[] T000Z5_A268Trn_TileWidth ;
      private string[] T000Z5_A270Trn_TileColor ;
      private string[] T000Z5_A271Trn_TileBGImageUrl ;
      private Guid[] T000Z5_A58ProductServiceId ;
      private bool[] T000Z5_n58ProductServiceId ;
      private Guid[] T000Z5_A329SG_ToPageId ;
      private Guid[] T000Z12_A264Trn_TileId ;
      private Guid[] T000Z13_A264Trn_TileId ;
      private Guid[] T000Z4_A264Trn_TileId ;
      private string[] T000Z4_A265Trn_TileName ;
      private short[] T000Z4_A268Trn_TileWidth ;
      private string[] T000Z4_A270Trn_TileColor ;
      private string[] T000Z4_A271Trn_TileBGImageUrl ;
      private Guid[] T000Z4_A58ProductServiceId ;
      private bool[] T000Z4_n58ProductServiceId ;
      private Guid[] T000Z4_A329SG_ToPageId ;
      private string[] T000Z17_A59ProductServiceName ;
      private string[] T000Z17_A60ProductServiceDescription ;
      private string[] T000Z17_A40000ProductServiceImage_GXI ;
      private string[] T000Z17_A61ProductServiceImage ;
      private string[] T000Z18_A330SG_ToPageName ;
      private Guid[] T000Z19_A328Trn_ColId ;
      private Guid[] T000Z20_A264Trn_TileId ;
      private Guid[] T000Z21_A264Trn_TileId ;
      private Guid[] T000Z21_A272AttributeId ;
      private string[] T000Z21_A273AttributeName ;
      private string[] T000Z21_A274AttrbuteValue ;
      private Guid[] T000Z22_A264Trn_TileId ;
      private Guid[] T000Z22_A272AttributeId ;
      private Guid[] T000Z3_A264Trn_TileId ;
      private Guid[] T000Z3_A272AttributeId ;
      private string[] T000Z3_A273AttributeName ;
      private string[] T000Z3_A274AttrbuteValue ;
      private Guid[] T000Z2_A264Trn_TileId ;
      private Guid[] T000Z2_A272AttributeId ;
      private string[] T000Z2_A273AttributeName ;
      private string[] T000Z2_A274AttrbuteValue ;
      private Guid[] T000Z26_A264Trn_TileId ;
      private Guid[] T000Z26_A272AttributeId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_tile__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_tile__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000Z2;
        prmT000Z2 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z3;
        prmT000Z3 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z4;
        prmT000Z4 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z5;
        prmT000Z5 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z6;
        prmT000Z6 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z7;
        prmT000Z7 = new Object[] {
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z8;
        prmT000Z8 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z9;
        prmT000Z9 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z10;
        prmT000Z10 = new Object[] {
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z11;
        prmT000Z11 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z12;
        prmT000Z12 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z13;
        prmT000Z13 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z14;
        prmT000Z14 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_TileName",GXType.VarChar,100,0) ,
        new ParDef("Trn_TileWidth",GXType.Int16,4,0) ,
        new ParDef("Trn_TileColor",GXType.Char,20,0) ,
        new ParDef("Trn_TileBGImageUrl",GXType.VarChar,1000,0) ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z15;
        prmT000Z15 = new Object[] {
        new ParDef("Trn_TileName",GXType.VarChar,100,0) ,
        new ParDef("Trn_TileWidth",GXType.Int16,4,0) ,
        new ParDef("Trn_TileColor",GXType.Char,20,0) ,
        new ParDef("Trn_TileBGImageUrl",GXType.VarChar,1000,0) ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z16;
        prmT000Z16 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z17;
        prmT000Z17 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z18;
        prmT000Z18 = new Object[] {
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z19;
        prmT000Z19 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z20;
        prmT000Z20 = new Object[] {
        };
        Object[] prmT000Z21;
        prmT000Z21 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z22;
        prmT000Z22 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z23;
        prmT000Z23 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeName",GXType.VarChar,100,0) ,
        new ParDef("AttrbuteValue",GXType.VarChar,100,0)
        };
        Object[] prmT000Z24;
        prmT000Z24 = new Object[] {
        new ParDef("AttributeName",GXType.VarChar,100,0) ,
        new ParDef("AttrbuteValue",GXType.VarChar,100,0) ,
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z25;
        prmT000Z25 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z26;
        prmT000Z26 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000Z2", "SELECT Trn_TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId  FOR UPDATE OF Trn_TileAttribute NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z3", "SELECT Trn_TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z4", "SELECT Trn_TileId, Trn_TileName, Trn_TileWidth, Trn_TileColor, Trn_TileBGImageUrl, ProductServiceId, SG_ToPageId FROM Trn_Col WHERE Trn_TileId = :Trn_TileId  FOR UPDATE OF Trn_Col NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z5", "SELECT Trn_TileId, Trn_TileName, Trn_TileWidth, Trn_TileColor, Trn_TileBGImageUrl, ProductServiceId, SG_ToPageId FROM Trn_Col WHERE Trn_TileId = :Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z6", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z7", "SELECT Trn_PageName AS SG_ToPageName FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z8", "SELECT TM1.Trn_TileId, TM1.Trn_TileName, TM1.Trn_TileWidth, TM1.Trn_TileColor, TM1.Trn_TileBGImageUrl, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceImage_GXI, T3.Trn_PageName AS SG_ToPageName, TM1.ProductServiceId, TM1.SG_ToPageId AS SG_ToPageId, T2.ProductServiceImage FROM ((Trn_Col TM1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = TM1.ProductServiceId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = TM1.SG_ToPageId) WHERE TM1.Trn_TileId = :Trn_TileId ORDER BY TM1.Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z9", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z10", "SELECT Trn_PageName AS SG_ToPageName FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z11", "SELECT Trn_TileId FROM Trn_Col WHERE Trn_TileId = :Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z12", "SELECT Trn_TileId FROM Trn_Col WHERE ( Trn_TileId > :Trn_TileId) ORDER BY Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z13", "SELECT Trn_TileId FROM Trn_Col WHERE ( Trn_TileId < :Trn_TileId) ORDER BY Trn_TileId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z14", "SAVEPOINT gxupdate;INSERT INTO Trn_Col(Trn_TileId, Trn_TileName, Trn_TileWidth, Trn_TileColor, Trn_TileBGImageUrl, ProductServiceId, SG_ToPageId) VALUES(:Trn_TileId, :Trn_TileName, :Trn_TileWidth, :Trn_TileColor, :Trn_TileBGImageUrl, :ProductServiceId, :SG_ToPageId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Z14)
           ,new CursorDef("T000Z15", "SAVEPOINT gxupdate;UPDATE Trn_Col SET Trn_TileName=:Trn_TileName, Trn_TileWidth=:Trn_TileWidth, Trn_TileColor=:Trn_TileColor, Trn_TileBGImageUrl=:Trn_TileBGImageUrl, ProductServiceId=:ProductServiceId, SG_ToPageId=:SG_ToPageId  WHERE Trn_TileId = :Trn_TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z15)
           ,new CursorDef("T000Z16", "SAVEPOINT gxupdate;DELETE FROM Trn_Col  WHERE Trn_TileId = :Trn_TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z16)
           ,new CursorDef("T000Z17", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z18", "SELECT Trn_PageName AS SG_ToPageName FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z19", "SELECT Trn_ColId FROM Trn_Col1 WHERE Trn_TileId = :Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z20", "SELECT Trn_TileId FROM Trn_Col ORDER BY Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z20,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z21", "SELECT Trn_TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId and AttributeId = :AttributeId ORDER BY Trn_TileId, AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z21,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z22", "SELECT Trn_TileId, AttributeId FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z23", "SAVEPOINT gxupdate;INSERT INTO Trn_TileAttribute(Trn_TileId, AttributeId, AttributeName, AttrbuteValue) VALUES(:Trn_TileId, :AttributeId, :AttributeName, :AttrbuteValue);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Z23)
           ,new CursorDef("T000Z24", "SAVEPOINT gxupdate;UPDATE Trn_TileAttribute SET AttributeName=:AttributeName, AttrbuteValue=:AttrbuteValue  WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z24)
           ,new CursorDef("T000Z25", "SAVEPOINT gxupdate;DELETE FROM Trn_TileAttribute  WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z25)
           ,new CursorDef("T000Z26", "SELECT Trn_TileId, AttributeId FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId ORDER BY Trn_TileId, AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z26,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((Guid[]) buf[5])[0] = rslt.getGuid(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((Guid[]) buf[7])[0] = rslt.getGuid(7);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((Guid[]) buf[5])[0] = rslt.getGuid(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((Guid[]) buf[7])[0] = rslt.getGuid(7);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((Guid[]) buf[9])[0] = rslt.getGuid(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((Guid[]) buf[11])[0] = rslt.getGuid(11);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(8));
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 17 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 18 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 19 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 20 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 24 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
     }
  }

}

}
