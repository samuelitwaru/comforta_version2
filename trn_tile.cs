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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A58ProductServiceId, A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A266SG_TileId = StringUtil.StrToGuid( GetPar( "SG_TileId"));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A266SG_TileId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_childtile") == 0 )
         {
            gxnrGridlevel_childtile_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Tile", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrn_TileName_Internalname;
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
         nRC_GXsfl_57 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_57"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_57_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_57_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_57_idx = GetPar( "sGXsfl_57_idx");
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

      protected void gxnrGridlevel_childtile_newrow_invoke( )
      {
         nRC_GXsfl_66 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_66"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_66_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_66_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_66_idx = GetPar( "sGXsfl_66_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_childtile_newrow( ) ;
         /* End function gxnrGridlevel_childtile_newrow_invoke */
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
         cmbSG_TileWidth = new GXCombobox();
         cmbSG_TileColor = new GXCombobox();
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
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Tile.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_TileName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_TileName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_TileName_Internalname, A265Trn_TileName, StringUtil.RTrim( context.localUtil.Format( A265Trn_TileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_TileName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_TileName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTrn_TileWidth_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTrn_TileWidth_Internalname, context.GetMessage( "Width", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTrn_TileWidth, cmbTrn_TileWidth_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A268Trn_TileWidth), 4, 0)), 1, cmbTrn_TileWidth_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTrn_TileWidth.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Trn_Tile.htm");
         cmbTrn_TileWidth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A268Trn_TileWidth), 4, 0));
         AssignProp("", false, cmbTrn_TileWidth_Internalname, "Values", (string)(cmbTrn_TileWidth.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceId_Internalname, context.GetMessage( "Product/Service", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceId_Internalname, A58ProductServiceId.ToString(), A58ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceDescription_Internalname, context.GetMessage( "Product Service Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProductServiceDescription_Internalname, A60ProductServiceDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", 0, 1, edtProductServiceDescription_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "LongDescription", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProductServiceImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Product Service Image", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A61ProductServiceImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServiceImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage));
         GxWebStd.gx_bitmap( context, imgProductServiceImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductServiceImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", "", "", 0, A61ProductServiceImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_Tile.htm");
         AssignProp("", false, imgProductServiceImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage)), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "IsBlob", StringUtil.BoolToStr( A61ProductServiceImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTrn_TileColor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTrn_TileColor_Internalname, context.GetMessage( "Color", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTrn_TileColor, cmbTrn_TileColor_Internalname, StringUtil.RTrim( A270Trn_TileColor), 1, cmbTrn_TileColor_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTrn_TileColor.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_Trn_Tile.htm");
         cmbTrn_TileColor.CurrentValue = StringUtil.RTrim( A270Trn_TileColor);
         AssignProp("", false, cmbTrn_TileColor_Internalname, "Values", (string)(cmbTrn_TileColor.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_TileBGImageUrl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_TileBGImageUrl_Internalname, context.GetMessage( "BGImage Url", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_TileBGImageUrl_Internalname, A271Trn_TileBGImageUrl, StringUtil.RTrim( context.localUtil.Format( A271Trn_TileBGImageUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", A271Trn_TileBGImageUrl, "_blank", "", "", edtTrn_TileBGImageUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_TileBGImageUrl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_Trn_Tile.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_childtile_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_childtile( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
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
         /* User Defined Control */
         ucCombo_sg_tileid.SetProperty("Caption", Combo_sg_tileid_Caption);
         ucCombo_sg_tileid.SetProperty("Cls", Combo_sg_tileid_Cls);
         ucCombo_sg_tileid.SetProperty("IsGridItem", Combo_sg_tileid_Isgriditem);
         ucCombo_sg_tileid.SetProperty("HasDescription", Combo_sg_tileid_Hasdescription);
         ucCombo_sg_tileid.SetProperty("DataListProc", Combo_sg_tileid_Datalistproc);
         ucCombo_sg_tileid.SetProperty("DataListProcParametersPrefix", Combo_sg_tileid_Datalistprocparametersprefix);
         ucCombo_sg_tileid.SetProperty("EmptyItem", Combo_sg_tileid_Emptyitem);
         ucCombo_sg_tileid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_sg_tileid.SetProperty("DropDownOptionsData", AV13SG_TileId_Data);
         ucCombo_sg_tileid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_sg_tileid_Internalname, "COMBO_SG_TILEIDContainer");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_TileId_Internalname, A264Trn_TileId.ToString(), A264Trn_TileId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_TileId_Jsonclick, 0, "Attribute", "", "", "", "", edtTrn_TileId_Visible, edtTrn_TileId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_attribute( )
      {
         /*  Grid Control  */
         StartGridControl57( ) ;
         nGXsfl_57_idx = 0;
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
            while ( nGXsfl_57_idx < nRC_GXsfl_57 )
            {
               bGXsfl_57_Refreshing = true;
               ReadRow0Z52( ) ;
               edtAttributeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTEID_"+sGXsfl_57_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_57_Refreshing);
               edtAttributeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTENAME_"+sGXsfl_57_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttributeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeName_Enabled), 5, 0), !bGXsfl_57_Refreshing);
               edtAttrbuteValue_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRBUTEVALUE_"+sGXsfl_57_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttrbuteValue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttrbuteValue_Enabled), 5, 0), !bGXsfl_57_Refreshing);
               if ( ( nRcdExists_52 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0Z52( ) ;
               }
               SendRow0Z52( ) ;
               bGXsfl_57_Refreshing = false;
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
                  sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5752( ) ;
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
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx+1), 4, 0), 4, "0");
            SubsflControlProps_5752( ) ;
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

      protected void gxdraw_Gridlevel_childtile( )
      {
         /*  Grid Control  */
         StartGridControl66( ) ;
         nGXsfl_66_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount77 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_77 = 1;
               ScanStart0Z77( ) ;
               while ( RcdFound77 != 0 )
               {
                  init_level_properties77( ) ;
                  getByPrimaryKey0Z77( ) ;
                  AddRow0Z77( ) ;
                  ScanNext0Z77( ) ;
               }
               ScanEnd0Z77( ) ;
               nBlankRcdCount77 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0Z77( ) ;
            standaloneModal0Z77( ) ;
            sMode77 = Gx_mode;
            while ( nGXsfl_66_idx < nRC_GXsfl_66 )
            {
               bGXsfl_66_Refreshing = true;
               ReadRow0Z77( ) ;
               edtSG_TileId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SG_TILEID_"+sGXsfl_66_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSG_TileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_TileId_Enabled), 5, 0), !bGXsfl_66_Refreshing);
               edtChildTileOrder_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CHILDTILEORDER_"+sGXsfl_66_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtChildTileOrder_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChildTileOrder_Enabled), 5, 0), !bGXsfl_66_Refreshing);
               cmbSG_TileWidth.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SG_TILEWIDTH_"+sGXsfl_66_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbSG_TileWidth_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSG_TileWidth.Enabled), 5, 0), !bGXsfl_66_Refreshing);
               cmbSG_TileColor.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SG_TILECOLOR_"+sGXsfl_66_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbSG_TileColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSG_TileColor.Enabled), 5, 0), !bGXsfl_66_Refreshing);
               edtSG_TileBGImageUrl_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SG_TILEBGIMAGEURL_"+sGXsfl_66_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSG_TileBGImageUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_TileBGImageUrl_Enabled), 5, 0), !bGXsfl_66_Refreshing);
               if ( ( nRcdExists_77 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0Z77( ) ;
               }
               SendRow0Z77( ) ;
               bGXsfl_66_Refreshing = false;
            }
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount77 = 5;
            nRcdExists_77 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0Z77( ) ;
               while ( RcdFound77 != 0 )
               {
                  sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_6677( ) ;
                  init_level_properties77( ) ;
                  standaloneNotModal0Z77( ) ;
                  getByPrimaryKey0Z77( ) ;
                  standaloneModal0Z77( ) ;
                  AddRow0Z77( ) ;
                  ScanNext0Z77( ) ;
               }
               ScanEnd0Z77( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode77 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx+1), 4, 0), 4, "0");
            SubsflControlProps_6677( ) ;
            InitAll0Z77( ) ;
            init_level_properties77( ) ;
            nRcdExists_77 = 0;
            nIsMod_77 = 0;
            nRcdDeleted_77 = 0;
            nBlankRcdCount77 = (short)(nBlankRcdUsr77+nBlankRcdCount77);
            fRowAdded = 0;
            while ( nBlankRcdCount77 > 0 )
            {
               standaloneNotModal0Z77( ) ;
               standaloneModal0Z77( ) ;
               AddRow0Z77( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtSG_TileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount77 = (short)(nBlankRcdCount77-1);
            }
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_childtileContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_childtile", Gridlevel_childtileContainer, subGridlevel_childtile_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_childtileContainerData", Gridlevel_childtileContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_childtileContainerData"+"V", Gridlevel_childtileContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_childtileContainerData"+"V"+"\" value='"+Gridlevel_childtileContainer.GridValuesHidden()+"'/>") ;
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
               ajax_req_read_hidden_sdt(cgiGet( "vSG_TILEID_DATA"), AV13SG_TileId_Data);
               /* Read saved values. */
               Z264Trn_TileId = StringUtil.StrToGuid( cgiGet( "Z264Trn_TileId"));
               Z265Trn_TileName = cgiGet( "Z265Trn_TileName");
               Z268Trn_TileWidth = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z268Trn_TileWidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z270Trn_TileColor = cgiGet( "Z270Trn_TileColor");
               Z271Trn_TileBGImageUrl = cgiGet( "Z271Trn_TileBGImageUrl");
               Z58ProductServiceId = StringUtil.StrToGuid( cgiGet( "Z58ProductServiceId"));
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               A29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_57 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_57"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_66 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_66"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N58ProductServiceId = StringUtil.StrToGuid( cgiGet( "N58ProductServiceId"));
               N11OrganisationId = StringUtil.StrToGuid( cgiGet( "N11OrganisationId"));
               N29LocationId = StringUtil.StrToGuid( cgiGet( "N29LocationId"));
               AV45Trn_TileId = StringUtil.StrToGuid( cgiGet( "vTRN_TILEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV20Insert_ProductServiceId = StringUtil.StrToGuid( cgiGet( "vINSERT_PRODUCTSERVICEID"));
               AV46Insert_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_ORGANISATIONID"));
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( "ORGANISATIONID"));
               AV47Insert_LocationId = StringUtil.StrToGuid( cgiGet( "vINSERT_LOCATIONID"));
               A29LocationId = StringUtil.StrToGuid( cgiGet( "LOCATIONID"));
               A59ProductServiceName = cgiGet( "PRODUCTSERVICENAME");
               A40000ProductServiceImage_GXI = cgiGet( "PRODUCTSERVICEIMAGE_GXI");
               AV48Pgmname = cgiGet( "vPGMNAME");
               A267SG_TileName = cgiGet( "SG_TILENAME");
               Combo_sg_tileid_Objectcall = cgiGet( "COMBO_SG_TILEID_Objectcall");
               Combo_sg_tileid_Class = cgiGet( "COMBO_SG_TILEID_Class");
               Combo_sg_tileid_Icontype = cgiGet( "COMBO_SG_TILEID_Icontype");
               Combo_sg_tileid_Icon = cgiGet( "COMBO_SG_TILEID_Icon");
               Combo_sg_tileid_Caption = cgiGet( "COMBO_SG_TILEID_Caption");
               Combo_sg_tileid_Tooltip = cgiGet( "COMBO_SG_TILEID_Tooltip");
               Combo_sg_tileid_Cls = cgiGet( "COMBO_SG_TILEID_Cls");
               Combo_sg_tileid_Selectedvalue_set = cgiGet( "COMBO_SG_TILEID_Selectedvalue_set");
               Combo_sg_tileid_Selectedvalue_get = cgiGet( "COMBO_SG_TILEID_Selectedvalue_get");
               Combo_sg_tileid_Selectedtext_set = cgiGet( "COMBO_SG_TILEID_Selectedtext_set");
               Combo_sg_tileid_Selectedtext_get = cgiGet( "COMBO_SG_TILEID_Selectedtext_get");
               Combo_sg_tileid_Gamoauthtoken = cgiGet( "COMBO_SG_TILEID_Gamoauthtoken");
               Combo_sg_tileid_Ddointernalname = cgiGet( "COMBO_SG_TILEID_Ddointernalname");
               Combo_sg_tileid_Titlecontrolalign = cgiGet( "COMBO_SG_TILEID_Titlecontrolalign");
               Combo_sg_tileid_Dropdownoptionstype = cgiGet( "COMBO_SG_TILEID_Dropdownoptionstype");
               Combo_sg_tileid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_SG_TILEID_Enabled"));
               Combo_sg_tileid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_SG_TILEID_Visible"));
               Combo_sg_tileid_Titlecontrolidtoreplace = cgiGet( "COMBO_SG_TILEID_Titlecontrolidtoreplace");
               Combo_sg_tileid_Datalisttype = cgiGet( "COMBO_SG_TILEID_Datalisttype");
               Combo_sg_tileid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SG_TILEID_Allowmultipleselection"));
               Combo_sg_tileid_Datalistfixedvalues = cgiGet( "COMBO_SG_TILEID_Datalistfixedvalues");
               Combo_sg_tileid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_SG_TILEID_Isgriditem"));
               Combo_sg_tileid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_SG_TILEID_Hasdescription"));
               Combo_sg_tileid_Datalistproc = cgiGet( "COMBO_SG_TILEID_Datalistproc");
               Combo_sg_tileid_Datalistprocparametersprefix = cgiGet( "COMBO_SG_TILEID_Datalistprocparametersprefix");
               Combo_sg_tileid_Remoteservicesparameters = cgiGet( "COMBO_SG_TILEID_Remoteservicesparameters");
               Combo_sg_tileid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SG_TILEID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_sg_tileid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SG_TILEID_Includeonlyselectedoption"));
               Combo_sg_tileid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_SG_TILEID_Includeselectalloption"));
               Combo_sg_tileid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_SG_TILEID_Emptyitem"));
               Combo_sg_tileid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_SG_TILEID_Includeaddnewoption"));
               Combo_sg_tileid_Htmltemplate = cgiGet( "COMBO_SG_TILEID_Htmltemplate");
               Combo_sg_tileid_Multiplevaluestype = cgiGet( "COMBO_SG_TILEID_Multiplevaluestype");
               Combo_sg_tileid_Loadingdata = cgiGet( "COMBO_SG_TILEID_Loadingdata");
               Combo_sg_tileid_Noresultsfound = cgiGet( "COMBO_SG_TILEID_Noresultsfound");
               Combo_sg_tileid_Emptyitemtext = cgiGet( "COMBO_SG_TILEID_Emptyitemtext");
               Combo_sg_tileid_Onlyselectedvalues = cgiGet( "COMBO_SG_TILEID_Onlyselectedvalues");
               Combo_sg_tileid_Selectalltext = cgiGet( "COMBO_SG_TILEID_Selectalltext");
               Combo_sg_tileid_Multiplevaluesseparator = cgiGet( "COMBO_SG_TILEID_Multiplevaluesseparator");
               Combo_sg_tileid_Addnewoptiontext = cgiGet( "COMBO_SG_TILEID_Addnewoptiontext");
               Combo_sg_tileid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SG_TILEID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A265Trn_TileName = cgiGet( edtTrn_TileName_Internalname);
               AssignAttri("", false, "A265Trn_TileName", A265Trn_TileName);
               cmbTrn_TileWidth.Name = cmbTrn_TileWidth_Internalname;
               cmbTrn_TileWidth.CurrentValue = cgiGet( cmbTrn_TileWidth_Internalname);
               A268Trn_TileWidth = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbTrn_TileWidth_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A268Trn_TileWidth", StringUtil.LTrimStr( (decimal)(A268Trn_TileWidth), 4, 0));
               if ( StringUtil.StrCmp(cgiGet( edtProductServiceId_Internalname), "") == 0 )
               {
                  A58ProductServiceId = Guid.Empty;
                  AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
               }
               else
               {
                  try
                  {
                     A58ProductServiceId = StringUtil.StrToGuid( cgiGet( edtProductServiceId_Internalname));
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
               A60ProductServiceDescription = cgiGet( edtProductServiceDescription_Internalname);
               AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
               A61ProductServiceImage = cgiGet( imgProductServiceImage_Internalname);
               AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
               cmbTrn_TileColor.Name = cmbTrn_TileColor_Internalname;
               cmbTrn_TileColor.CurrentValue = cgiGet( cmbTrn_TileColor_Internalname);
               A270Trn_TileColor = cgiGet( cmbTrn_TileColor_Internalname);
               AssignAttri("", false, "A270Trn_TileColor", A270Trn_TileColor);
               A271Trn_TileBGImageUrl = cgiGet( edtTrn_TileBGImageUrl_Internalname);
               AssignAttri("", false, "A271Trn_TileBGImageUrl", A271Trn_TileBGImageUrl);
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
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
                           E120Z2 ();
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
            E120Z2 ();
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
               CONFIRM_0Z77( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode71;
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  IsConfirmed = 1;
                  AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode71;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0Z77( )
      {
         nGXsfl_66_idx = 0;
         while ( nGXsfl_66_idx < nRC_GXsfl_66 )
         {
            ReadRow0Z77( ) ;
            if ( ( nRcdExists_77 != 0 ) || ( nIsMod_77 != 0 ) )
            {
               GetKey0Z77( ) ;
               if ( ( nRcdExists_77 == 0 ) && ( nRcdDeleted_77 == 0 ) )
               {
                  if ( RcdFound77 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0Z77( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Z77( ) ;
                        CloseExtendedTableCursors0Z77( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "SG_TILEID_" + sGXsfl_66_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtSG_TileId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound77 != 0 )
                  {
                     if ( nRcdDeleted_77 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0Z77( ) ;
                        Load0Z77( ) ;
                        BeforeValidate0Z77( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Z77( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_77 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0Z77( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Z77( ) ;
                              CloseExtendedTableCursors0Z77( ) ;
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
                     if ( nRcdDeleted_77 == 0 )
                     {
                        GXCCtl = "SG_TILEID_" + sGXsfl_66_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtSG_TileId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSG_TileId_Internalname, A266SG_TileId.ToString()) ;
            ChangePostValue( edtChildTileOrder_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A269ChildTileOrder), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbSG_TileWidth_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A275SG_TileWidth), 4, 0, ".", ""))) ;
            ChangePostValue( cmbSG_TileColor_Internalname, StringUtil.RTrim( A276SG_TileColor)) ;
            ChangePostValue( edtSG_TileBGImageUrl_Internalname, A277SG_TileBGImageUrl) ;
            ChangePostValue( "ZT_"+"Z266SG_TileId_"+sGXsfl_66_idx, Z266SG_TileId.ToString()) ;
            ChangePostValue( "ZT_"+"Z269ChildTileOrder_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z269ChildTileOrder), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_77_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_77_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_77_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_77 != 0 )
            {
               ChangePostValue( "SG_TILEID_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSG_TileId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CHILDTILEORDER_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtChildTileOrder_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SG_TILEWIDTH_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSG_TileWidth.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SG_TILECOLOR_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSG_TileColor.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SG_TILEBGIMAGEURL_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSG_TileBGImageUrl_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0Z52( )
      {
         nGXsfl_57_idx = 0;
         while ( nGXsfl_57_idx < nRC_GXsfl_57 )
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
                     GXCCtl = "ATTRIBUTEID_" + sGXsfl_57_idx;
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
                        GXCCtl = "ATTRIBUTEID_" + sGXsfl_57_idx;
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
            ChangePostValue( "ZT_"+"Z272AttributeId_"+sGXsfl_57_idx, Z272AttributeId.ToString()) ;
            ChangePostValue( "ZT_"+"Z273AttributeName_"+sGXsfl_57_idx, Z273AttributeName) ;
            ChangePostValue( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_57_idx, Z274AttrbuteValue) ;
            ChangePostValue( "nRcdDeleted_52_"+sGXsfl_57_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_52_"+sGXsfl_57_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_52_"+sGXsfl_57_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_52 != 0 )
            {
               ChangePostValue( "ATTRIBUTEID_"+sGXsfl_57_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRIBUTENAME_"+sGXsfl_57_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRBUTEVALUE_"+sGXsfl_57_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttrbuteValue_Enabled), 5, 0, ".", ""))) ;
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
         Combo_sg_tileid_Gamoauthtoken = AV18GAMSession.gxTpr_Token;
         ucCombo_sg_tileid.SendProperty(context, "", false, Combo_sg_tileid_Internalname, "GAMOAuthToken", Combo_sg_tileid_Gamoauthtoken);
         Combo_sg_tileid_Titlecontrolidtoreplace = edtSG_TileId_Internalname;
         ucCombo_sg_tileid.SendProperty(context, "", false, Combo_sg_tileid_Internalname, "TitleControlIdToReplace", Combo_sg_tileid_Titlecontrolidtoreplace);
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV48Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV49GXV1 = 1;
            AssignAttri("", false, "AV49GXV1", StringUtil.LTrimStr( (decimal)(AV49GXV1), 8, 0));
            while ( AV49GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV21TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV49GXV1));
               if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "ProductServiceId") == 0 )
               {
                  AV20Insert_ProductServiceId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV20Insert_ProductServiceId", AV20Insert_ProductServiceId.ToString());
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV46Insert_OrganisationId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV46Insert_OrganisationId", AV46Insert_OrganisationId.ToString());
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "LocationId") == 0 )
               {
                  AV47Insert_LocationId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV47Insert_LocationId", AV47Insert_LocationId.ToString());
               }
               AV49GXV1 = (int)(AV49GXV1+1);
               AssignAttri("", false, "AV49GXV1", StringUtil.LTrimStr( (decimal)(AV49GXV1), 8, 0));
            }
         }
         edtTrn_TileId_Visible = 0;
         AssignProp("", false, edtTrn_TileId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTrn_TileId_Visible), 5, 0), true);
      }

      protected void E120Z2( )
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

      protected void ZM0Z71( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z265Trn_TileName = T000Z8_A265Trn_TileName[0];
               Z268Trn_TileWidth = T000Z8_A268Trn_TileWidth[0];
               Z270Trn_TileColor = T000Z8_A270Trn_TileColor[0];
               Z271Trn_TileBGImageUrl = T000Z8_A271Trn_TileBGImageUrl[0];
               Z58ProductServiceId = T000Z8_A58ProductServiceId[0];
               Z29LocationId = T000Z8_A29LocationId[0];
               Z11OrganisationId = T000Z8_A11OrganisationId[0];
            }
            else
            {
               Z265Trn_TileName = A265Trn_TileName;
               Z268Trn_TileWidth = A268Trn_TileWidth;
               Z270Trn_TileColor = A270Trn_TileColor;
               Z271Trn_TileBGImageUrl = A271Trn_TileBGImageUrl;
               Z58ProductServiceId = A58ProductServiceId;
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z264Trn_TileId = A264Trn_TileId;
            Z265Trn_TileName = A265Trn_TileName;
            Z268Trn_TileWidth = A268Trn_TileWidth;
            Z270Trn_TileColor = A270Trn_TileColor;
            Z271Trn_TileBGImageUrl = A271Trn_TileBGImageUrl;
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z59ProductServiceName = A59ProductServiceName;
            Z60ProductServiceDescription = A60ProductServiceDescription;
            Z61ProductServiceImage = A61ProductServiceImage;
            Z40000ProductServiceImage_GXI = A40000ProductServiceImage_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV48Pgmname = "Trn_Tile";
         AssignAttri("", false, "AV48Pgmname", AV48Pgmname);
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
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV47Insert_LocationId) )
         {
            A29LocationId = AV47Insert_LocationId;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV46Insert_OrganisationId) )
         {
            A11OrganisationId = AV46Insert_OrganisationId;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV20Insert_ProductServiceId) )
         {
            A58ProductServiceId = AV20Insert_ProductServiceId;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
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
            /* Using cursor T000Z9 */
            pr_default.execute(7, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
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
            pr_default.close(7);
         }
      }

      protected void Load0Z71( )
      {
         /* Using cursor T000Z10 */
         pr_default.execute(8, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound71 = 1;
            A265Trn_TileName = T000Z10_A265Trn_TileName[0];
            AssignAttri("", false, "A265Trn_TileName", A265Trn_TileName);
            A268Trn_TileWidth = T000Z10_A268Trn_TileWidth[0];
            AssignAttri("", false, "A268Trn_TileWidth", StringUtil.LTrimStr( (decimal)(A268Trn_TileWidth), 4, 0));
            A270Trn_TileColor = T000Z10_A270Trn_TileColor[0];
            AssignAttri("", false, "A270Trn_TileColor", A270Trn_TileColor);
            A271Trn_TileBGImageUrl = T000Z10_A271Trn_TileBGImageUrl[0];
            AssignAttri("", false, "A271Trn_TileBGImageUrl", A271Trn_TileBGImageUrl);
            A59ProductServiceName = T000Z10_A59ProductServiceName[0];
            A60ProductServiceDescription = T000Z10_A60ProductServiceDescription[0];
            AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
            A40000ProductServiceImage_GXI = T000Z10_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A58ProductServiceId = T000Z10_A58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = T000Z10_A29LocationId[0];
            A11OrganisationId = T000Z10_A11OrganisationId[0];
            A61ProductServiceImage = T000Z10_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            ZM0Z71( -20) ;
         }
         pr_default.close(8);
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
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Trn_Tile Width", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TRN_TILEWIDTH");
            AnyError = 1;
            GX_FocusControl = cmbTrn_TileWidth_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A271Trn_TileBGImageUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Trn_Tile BGImage Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TRN_TILEBGIMAGEURL");
            AnyError = 1;
            GX_FocusControl = edtTrn_TileBGImageUrl_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000Z9 */
         pr_default.execute(7, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors0Z71( )
      {
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_21( Guid A58ProductServiceId ,
                                Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T000Z11 */
         pr_default.execute(9, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
            GX_FocusControl = edtProductServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A59ProductServiceName = T000Z11_A59ProductServiceName[0];
         A60ProductServiceDescription = T000Z11_A60ProductServiceDescription[0];
         AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
         A40000ProductServiceImage_GXI = T000Z11_A40000ProductServiceImage_GXI[0];
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         A61ProductServiceImage = T000Z11_A61ProductServiceImage[0];
         AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A59ProductServiceName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A60ProductServiceDescription)+"\""+","+"\""+GXUtil.EncodeJSConstant( A61ProductServiceImage)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000ProductServiceImage_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void GetKey0Z71( )
      {
         /* Using cursor T000Z12 */
         pr_default.execute(10, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound71 = 1;
         }
         else
         {
            RcdFound71 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Z8 */
         pr_default.execute(6, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM0Z71( 20) ;
            RcdFound71 = 1;
            A264Trn_TileId = T000Z8_A264Trn_TileId[0];
            AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
            A265Trn_TileName = T000Z8_A265Trn_TileName[0];
            AssignAttri("", false, "A265Trn_TileName", A265Trn_TileName);
            A268Trn_TileWidth = T000Z8_A268Trn_TileWidth[0];
            AssignAttri("", false, "A268Trn_TileWidth", StringUtil.LTrimStr( (decimal)(A268Trn_TileWidth), 4, 0));
            A270Trn_TileColor = T000Z8_A270Trn_TileColor[0];
            AssignAttri("", false, "A270Trn_TileColor", A270Trn_TileColor);
            A271Trn_TileBGImageUrl = T000Z8_A271Trn_TileBGImageUrl[0];
            AssignAttri("", false, "A271Trn_TileBGImageUrl", A271Trn_TileBGImageUrl);
            A58ProductServiceId = T000Z8_A58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = T000Z8_A29LocationId[0];
            A11OrganisationId = T000Z8_A11OrganisationId[0];
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
         pr_default.close(6);
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
         /* Using cursor T000Z13 */
         pr_default.execute(11, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000Z13_A264Trn_TileId[0], A264Trn_TileId, 0) < 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000Z13_A264Trn_TileId[0], A264Trn_TileId, 0) > 0 ) ) )
            {
               A264Trn_TileId = T000Z13_A264Trn_TileId[0];
               AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
               RcdFound71 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound71 = 0;
         /* Using cursor T000Z14 */
         pr_default.execute(12, new Object[] {A264Trn_TileId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T000Z14_A264Trn_TileId[0], A264Trn_TileId, 0) > 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T000Z14_A264Trn_TileId[0], A264Trn_TileId, 0) < 0 ) ) )
            {
               A264Trn_TileId = T000Z14_A264Trn_TileId[0];
               AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
               RcdFound71 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Z71( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrn_TileName_Internalname;
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
                  GX_FocusControl = edtTrn_TileName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0Z71( ) ;
                  GX_FocusControl = edtTrn_TileName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A264Trn_TileId != Z264Trn_TileId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTrn_TileName_Internalname;
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
                     GX_FocusControl = edtTrn_TileName_Internalname;
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
            GX_FocusControl = edtTrn_TileName_Internalname;
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
            /* Using cursor T000Z7 */
            pr_default.execute(5, new Object[] {A264Trn_TileId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Tile"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(5) == 101) || ( StringUtil.StrCmp(Z265Trn_TileName, T000Z7_A265Trn_TileName[0]) != 0 ) || ( Z268Trn_TileWidth != T000Z7_A268Trn_TileWidth[0] ) || ( StringUtil.StrCmp(Z270Trn_TileColor, T000Z7_A270Trn_TileColor[0]) != 0 ) || ( StringUtil.StrCmp(Z271Trn_TileBGImageUrl, T000Z7_A271Trn_TileBGImageUrl[0]) != 0 ) || ( Z58ProductServiceId != T000Z7_A58ProductServiceId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z29LocationId != T000Z7_A29LocationId[0] ) || ( Z11OrganisationId != T000Z7_A11OrganisationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z265Trn_TileName, T000Z7_A265Trn_TileName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"Trn_TileName");
                  GXUtil.WriteLogRaw("Old: ",Z265Trn_TileName);
                  GXUtil.WriteLogRaw("Current: ",T000Z7_A265Trn_TileName[0]);
               }
               if ( Z268Trn_TileWidth != T000Z7_A268Trn_TileWidth[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"Trn_TileWidth");
                  GXUtil.WriteLogRaw("Old: ",Z268Trn_TileWidth);
                  GXUtil.WriteLogRaw("Current: ",T000Z7_A268Trn_TileWidth[0]);
               }
               if ( StringUtil.StrCmp(Z270Trn_TileColor, T000Z7_A270Trn_TileColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"Trn_TileColor");
                  GXUtil.WriteLogRaw("Old: ",Z270Trn_TileColor);
                  GXUtil.WriteLogRaw("Current: ",T000Z7_A270Trn_TileColor[0]);
               }
               if ( StringUtil.StrCmp(Z271Trn_TileBGImageUrl, T000Z7_A271Trn_TileBGImageUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"Trn_TileBGImageUrl");
                  GXUtil.WriteLogRaw("Old: ",Z271Trn_TileBGImageUrl);
                  GXUtil.WriteLogRaw("Current: ",T000Z7_A271Trn_TileBGImageUrl[0]);
               }
               if ( Z58ProductServiceId != T000Z7_A58ProductServiceId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"ProductServiceId");
                  GXUtil.WriteLogRaw("Old: ",Z58ProductServiceId);
                  GXUtil.WriteLogRaw("Current: ",T000Z7_A58ProductServiceId[0]);
               }
               if ( Z29LocationId != T000Z7_A29LocationId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z29LocationId);
                  GXUtil.WriteLogRaw("Current: ",T000Z7_A29LocationId[0]);
               }
               if ( Z11OrganisationId != T000Z7_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T000Z7_A11OrganisationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Tile"}), "RecordWasChanged", 1, "");
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
                     /* Using cursor T000Z15 */
                     pr_default.execute(13, new Object[] {A264Trn_TileId, A265Trn_TileName, A268Trn_TileWidth, A270Trn_TileColor, A271Trn_TileBGImageUrl, A58ProductServiceId, A29LocationId, A11OrganisationId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                     if ( (pr_default.getStatus(13) == 1) )
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
                     /* Using cursor T000Z16 */
                     pr_default.execute(14, new Object[] {A265Trn_TileName, A268Trn_TileWidth, A270Trn_TileColor, A271Trn_TileBGImageUrl, A58ProductServiceId, A29LocationId, A11OrganisationId, A264Trn_TileId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Tile"}), "RecordIsLocked", 1, "");
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
                  ScanStart0Z77( ) ;
                  while ( RcdFound77 != 0 )
                  {
                     getByPrimaryKey0Z77( ) ;
                     Delete0Z77( ) ;
                     ScanNext0Z77( ) ;
                  }
                  ScanEnd0Z77( ) ;
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
                     /* Using cursor T000Z17 */
                     pr_default.execute(15, new Object[] {A264Trn_TileId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
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
            /* Using cursor T000Z18 */
            pr_default.execute(16, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
            A59ProductServiceName = T000Z18_A59ProductServiceName[0];
            A60ProductServiceDescription = T000Z18_A60ProductServiceDescription[0];
            AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
            A40000ProductServiceImage_GXI = T000Z18_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A61ProductServiceImage = T000Z18_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000Z19 */
            pr_default.execute(17, new Object[] {A264Trn_TileId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Col", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000Z20 */
            pr_default.execute(18, new Object[] {A264Trn_TileId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_TileChildTile", "")+" ("+context.GetMessage( "SG_Tile", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void ProcessNestedLevel0Z52( )
      {
         nGXsfl_57_idx = 0;
         while ( nGXsfl_57_idx < nRC_GXsfl_57 )
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
                        GXCCtl = "ATTRIBUTEID_" + sGXsfl_57_idx;
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
            ChangePostValue( "ZT_"+"Z272AttributeId_"+sGXsfl_57_idx, Z272AttributeId.ToString()) ;
            ChangePostValue( "ZT_"+"Z273AttributeName_"+sGXsfl_57_idx, Z273AttributeName) ;
            ChangePostValue( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_57_idx, Z274AttrbuteValue) ;
            ChangePostValue( "nRcdDeleted_52_"+sGXsfl_57_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_52_"+sGXsfl_57_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_52_"+sGXsfl_57_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_52 != 0 )
            {
               ChangePostValue( "ATTRIBUTEID_"+sGXsfl_57_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRIBUTENAME_"+sGXsfl_57_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRBUTEVALUE_"+sGXsfl_57_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttrbuteValue_Enabled), 5, 0, ".", ""))) ;
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

      protected void ProcessNestedLevel0Z77( )
      {
         nGXsfl_66_idx = 0;
         while ( nGXsfl_66_idx < nRC_GXsfl_66 )
         {
            ReadRow0Z77( ) ;
            if ( ( nRcdExists_77 != 0 ) || ( nIsMod_77 != 0 ) )
            {
               standaloneNotModal0Z77( ) ;
               GetKey0Z77( ) ;
               if ( ( nRcdExists_77 == 0 ) && ( nRcdDeleted_77 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0Z77( ) ;
               }
               else
               {
                  if ( RcdFound77 != 0 )
                  {
                     if ( ( nRcdDeleted_77 != 0 ) && ( nRcdExists_77 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0Z77( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_77 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0Z77( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_77 == 0 )
                     {
                        GXCCtl = "SG_TILEID_" + sGXsfl_66_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtSG_TileId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtSG_TileId_Internalname, A266SG_TileId.ToString()) ;
            ChangePostValue( edtChildTileOrder_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A269ChildTileOrder), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbSG_TileWidth_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A275SG_TileWidth), 4, 0, ".", ""))) ;
            ChangePostValue( cmbSG_TileColor_Internalname, StringUtil.RTrim( A276SG_TileColor)) ;
            ChangePostValue( edtSG_TileBGImageUrl_Internalname, A277SG_TileBGImageUrl) ;
            ChangePostValue( "ZT_"+"Z266SG_TileId_"+sGXsfl_66_idx, Z266SG_TileId.ToString()) ;
            ChangePostValue( "ZT_"+"Z269ChildTileOrder_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z269ChildTileOrder), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_77_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_77_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_77_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_77 != 0 )
            {
               ChangePostValue( "SG_TILEID_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSG_TileId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CHILDTILEORDER_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtChildTileOrder_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SG_TILEWIDTH_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSG_TileWidth.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SG_TILECOLOR_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSG_TileColor.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SG_TILEBGIMAGEURL_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSG_TileBGImageUrl_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Z77( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_77 = 0;
         nIsMod_77 = 0;
         nRcdDeleted_77 = 0;
      }

      protected void ProcessLevel0Z71( )
      {
         /* Save parent mode. */
         sMode71 = Gx_mode;
         ProcessNestedLevel0Z52( ) ;
         ProcessNestedLevel0Z77( ) ;
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
            pr_default.close(5);
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
         /* Using cursor T000Z21 */
         pr_default.execute(19);
         RcdFound71 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound71 = 1;
            A264Trn_TileId = T000Z21_A264Trn_TileId[0];
            AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z71( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound71 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound71 = 1;
            A264Trn_TileId = T000Z21_A264Trn_TileId[0];
            AssignAttri("", false, "A264Trn_TileId", A264Trn_TileId.ToString());
         }
      }

      protected void ScanEnd0Z71( )
      {
         pr_default.close(19);
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
         edtTrn_TileName_Enabled = 0;
         AssignProp("", false, edtTrn_TileName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_TileName_Enabled), 5, 0), true);
         cmbTrn_TileWidth.Enabled = 0;
         AssignProp("", false, cmbTrn_TileWidth_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrn_TileWidth.Enabled), 5, 0), true);
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         edtProductServiceDescription_Enabled = 0;
         AssignProp("", false, edtProductServiceDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceDescription_Enabled), 5, 0), true);
         imgProductServiceImage_Enabled = 0;
         AssignProp("", false, imgProductServiceImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductServiceImage_Enabled), 5, 0), true);
         cmbTrn_TileColor.Enabled = 0;
         AssignProp("", false, cmbTrn_TileColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrn_TileColor.Enabled), 5, 0), true);
         edtTrn_TileBGImageUrl_Enabled = 0;
         AssignProp("", false, edtTrn_TileBGImageUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_TileBGImageUrl_Enabled), 5, 0), true);
         edtTrn_TileId_Enabled = 0;
         AssignProp("", false, edtTrn_TileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_TileId_Enabled), 5, 0), true);
      }

      protected void ZM0Z52( short GX_JID )
      {
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z273AttributeName = T000Z6_A273AttributeName[0];
               Z274AttrbuteValue = T000Z6_A274AttrbuteValue[0];
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
            AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         }
         else
         {
            edtAttributeId_Enabled = 1;
            AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z52( )
      {
         /* Using cursor T000Z22 */
         pr_default.execute(20, new Object[] {A264Trn_TileId, A272AttributeId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound52 = 1;
            A273AttributeName = T000Z22_A273AttributeName[0];
            A274AttrbuteValue = T000Z22_A274AttrbuteValue[0];
            ZM0Z52( -22) ;
         }
         pr_default.close(20);
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
         /* Using cursor T000Z23 */
         pr_default.execute(21, new Object[] {A264Trn_TileId, A272AttributeId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound52 = 1;
         }
         else
         {
            RcdFound52 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey0Z52( )
      {
         /* Using cursor T000Z6 */
         pr_default.execute(4, new Object[] {A264Trn_TileId, A272AttributeId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0Z52( 22) ;
            RcdFound52 = 1;
            InitializeNonKey0Z52( ) ;
            A272AttributeId = T000Z6_A272AttributeId[0];
            A273AttributeName = T000Z6_A273AttributeName[0];
            A274AttrbuteValue = T000Z6_A274AttrbuteValue[0];
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
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency0Z52( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z5 */
            pr_default.execute(3, new Object[] {A264Trn_TileId, A272AttributeId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_TileAttribute"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z273AttributeName, T000Z5_A273AttributeName[0]) != 0 ) || ( StringUtil.StrCmp(Z274AttrbuteValue, T000Z5_A274AttrbuteValue[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z273AttributeName, T000Z5_A273AttributeName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"AttributeName");
                  GXUtil.WriteLogRaw("Old: ",Z273AttributeName);
                  GXUtil.WriteLogRaw("Current: ",T000Z5_A273AttributeName[0]);
               }
               if ( StringUtil.StrCmp(Z274AttrbuteValue, T000Z5_A274AttrbuteValue[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"AttrbuteValue");
                  GXUtil.WriteLogRaw("Old: ",Z274AttrbuteValue);
                  GXUtil.WriteLogRaw("Current: ",T000Z5_A274AttrbuteValue[0]);
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
                     /* Using cursor T000Z24 */
                     pr_default.execute(22, new Object[] {A264Trn_TileId, A272AttributeId, A273AttributeName, A274AttrbuteValue});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_TileAttribute");
                     if ( (pr_default.getStatus(22) == 1) )
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
                        /* Using cursor T000Z25 */
                        pr_default.execute(23, new Object[] {A273AttributeName, A274AttrbuteValue, A264Trn_TileId, A272AttributeId});
                        pr_default.close(23);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_TileAttribute");
                        if ( (pr_default.getStatus(23) == 103) )
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
                  /* Using cursor T000Z26 */
                  pr_default.execute(24, new Object[] {A264Trn_TileId, A272AttributeId});
                  pr_default.close(24);
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
            pr_default.close(3);
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
         /* Using cursor T000Z27 */
         pr_default.execute(25, new Object[] {A264Trn_TileId});
         RcdFound52 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound52 = 1;
            A272AttributeId = T000Z27_A272AttributeId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z52( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound52 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound52 = 1;
            A272AttributeId = T000Z27_A272AttributeId[0];
         }
      }

      protected void ScanEnd0Z52( )
      {
         pr_default.close(25);
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
         AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtAttributeName_Enabled = 0;
         AssignProp("", false, edtAttributeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeName_Enabled), 5, 0), !bGXsfl_57_Refreshing);
         edtAttrbuteValue_Enabled = 0;
         AssignProp("", false, edtAttrbuteValue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttrbuteValue_Enabled), 5, 0), !bGXsfl_57_Refreshing);
      }

      protected void send_integrity_lvl_hashes0Z52( )
      {
      }

      protected void ZM0Z77( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z269ChildTileOrder = T000Z3_A269ChildTileOrder[0];
            }
            else
            {
               Z269ChildTileOrder = A269ChildTileOrder;
            }
         }
         if ( GX_JID == -23 )
         {
            Z264Trn_TileId = A264Trn_TileId;
            Z269ChildTileOrder = A269ChildTileOrder;
            Z266SG_TileId = A266SG_TileId;
            Z267SG_TileName = A267SG_TileName;
            Z275SG_TileWidth = A275SG_TileWidth;
            Z276SG_TileColor = A276SG_TileColor;
            Z277SG_TileBGImageUrl = A277SG_TileBGImageUrl;
         }
      }

      protected void standaloneNotModal0Z77( )
      {
      }

      protected void standaloneModal0Z77( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtSG_TileId_Enabled = 0;
            AssignProp("", false, edtSG_TileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_TileId_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         }
         else
         {
            edtSG_TileId_Enabled = 1;
            AssignProp("", false, edtSG_TileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_TileId_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         }
      }

      protected void Load0Z77( )
      {
         /* Using cursor T000Z28 */
         pr_default.execute(26, new Object[] {A264Trn_TileId, A266SG_TileId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound77 = 1;
            A267SG_TileName = T000Z28_A267SG_TileName[0];
            A275SG_TileWidth = T000Z28_A275SG_TileWidth[0];
            A276SG_TileColor = T000Z28_A276SG_TileColor[0];
            A277SG_TileBGImageUrl = T000Z28_A277SG_TileBGImageUrl[0];
            A269ChildTileOrder = T000Z28_A269ChildTileOrder[0];
            ZM0Z77( -23) ;
         }
         pr_default.close(26);
         OnLoadActions0Z77( ) ;
      }

      protected void OnLoadActions0Z77( )
      {
      }

      protected void CheckExtendedTable0Z77( )
      {
         nIsDirty_77 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0Z77( ) ;
         /* Using cursor T000Z4 */
         pr_default.execute(2, new Object[] {A266SG_TileId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "SG_TILEID_" + sGXsfl_66_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Tile", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSG_TileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A267SG_TileName = T000Z4_A267SG_TileName[0];
         A275SG_TileWidth = T000Z4_A275SG_TileWidth[0];
         A276SG_TileColor = T000Z4_A276SG_TileColor[0];
         A277SG_TileBGImageUrl = T000Z4_A277SG_TileBGImageUrl[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0Z77( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0Z77( )
      {
      }

      protected void gxLoad_24( Guid A266SG_TileId )
      {
         /* Using cursor T000Z29 */
         pr_default.execute(27, new Object[] {A266SG_TileId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GXCCtl = "SG_TILEID_" + sGXsfl_66_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Tile", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSG_TileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A267SG_TileName = T000Z29_A267SG_TileName[0];
         A275SG_TileWidth = T000Z29_A275SG_TileWidth[0];
         A276SG_TileColor = T000Z29_A276SG_TileColor[0];
         A277SG_TileBGImageUrl = T000Z29_A277SG_TileBGImageUrl[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A267SG_TileName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A275SG_TileWidth), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A276SG_TileColor))+"\""+","+"\""+GXUtil.EncodeJSConstant( A277SG_TileBGImageUrl)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(27) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(27);
      }

      protected void GetKey0Z77( )
      {
         /* Using cursor T000Z30 */
         pr_default.execute(28, new Object[] {A264Trn_TileId, A266SG_TileId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound77 = 1;
         }
         else
         {
            RcdFound77 = 0;
         }
         pr_default.close(28);
      }

      protected void getByPrimaryKey0Z77( )
      {
         /* Using cursor T000Z3 */
         pr_default.execute(1, new Object[] {A264Trn_TileId, A266SG_TileId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z77( 23) ;
            RcdFound77 = 1;
            InitializeNonKey0Z77( ) ;
            A269ChildTileOrder = T000Z3_A269ChildTileOrder[0];
            A266SG_TileId = T000Z3_A266SG_TileId[0];
            Z264Trn_TileId = A264Trn_TileId;
            Z266SG_TileId = A266SG_TileId;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Z77( ) ;
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound77 = 0;
            InitializeNonKey0Z77( ) ;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0Z77( ) ;
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Z77( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0Z77( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z2 */
            pr_default.execute(0, new Object[] {A264Trn_TileId, A266SG_TileId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_TileChildTile"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z269ChildTileOrder != T000Z2_A269ChildTileOrder[0] ) )
            {
               if ( Z269ChildTileOrder != T000Z2_A269ChildTileOrder[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"ChildTileOrder");
                  GXUtil.WriteLogRaw("Old: ",Z269ChildTileOrder);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A269ChildTileOrder[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_TileChildTile"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z77( )
      {
         if ( ! IsAuthorized("trn_page_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z77( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z77( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z77( 0) ;
            CheckOptimisticConcurrency0Z77( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z77( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z77( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z31 */
                     pr_default.execute(29, new Object[] {A264Trn_TileId, A269ChildTileOrder, A266SG_TileId});
                     pr_default.close(29);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_TileChildTile");
                     if ( (pr_default.getStatus(29) == 1) )
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
               Load0Z77( ) ;
            }
            EndLevel0Z77( ) ;
         }
         CloseExtendedTableCursors0Z77( ) ;
      }

      protected void Update0Z77( )
      {
         if ( ! IsAuthorized("trn_page_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z77( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z77( ) ;
         }
         if ( ( nIsMod_77 != 0 ) || ( nIsDirty_77 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0Z77( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0Z77( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0Z77( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000Z32 */
                        pr_default.execute(30, new Object[] {A269ChildTileOrder, A264Trn_TileId, A266SG_TileId});
                        pr_default.close(30);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_TileChildTile");
                        if ( (pr_default.getStatus(30) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_TileChildTile"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0Z77( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0Z77( ) ;
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
               EndLevel0Z77( ) ;
            }
         }
         CloseExtendedTableCursors0Z77( ) ;
      }

      protected void DeferredUpdate0Z77( )
      {
      }

      protected void Delete0Z77( )
      {
         if ( ! IsAuthorized("trn_page_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Z77( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z77( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z77( ) ;
            AfterConfirm0Z77( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z77( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Z33 */
                  pr_default.execute(31, new Object[] {A264Trn_TileId, A266SG_TileId});
                  pr_default.close(31);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_TileChildTile");
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
         sMode77 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z77( ) ;
         Gx_mode = sMode77;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z77( )
      {
         standaloneModal0Z77( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000Z34 */
            pr_default.execute(32, new Object[] {A266SG_TileId});
            A267SG_TileName = T000Z34_A267SG_TileName[0];
            A275SG_TileWidth = T000Z34_A275SG_TileWidth[0];
            A276SG_TileColor = T000Z34_A276SG_TileColor[0];
            A277SG_TileBGImageUrl = T000Z34_A277SG_TileBGImageUrl[0];
            pr_default.close(32);
         }
      }

      protected void EndLevel0Z77( )
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

      public void ScanStart0Z77( )
      {
         /* Scan By routine */
         /* Using cursor T000Z35 */
         pr_default.execute(33, new Object[] {A264Trn_TileId});
         RcdFound77 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound77 = 1;
            A266SG_TileId = T000Z35_A266SG_TileId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z77( )
      {
         /* Scan next routine */
         pr_default.readNext(33);
         RcdFound77 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound77 = 1;
            A266SG_TileId = T000Z35_A266SG_TileId[0];
         }
      }

      protected void ScanEnd0Z77( )
      {
         pr_default.close(33);
      }

      protected void AfterConfirm0Z77( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z77( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z77( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z77( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z77( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z77( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z77( )
      {
         edtSG_TileId_Enabled = 0;
         AssignProp("", false, edtSG_TileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_TileId_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         edtChildTileOrder_Enabled = 0;
         AssignProp("", false, edtChildTileOrder_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChildTileOrder_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         cmbSG_TileWidth.Enabled = 0;
         AssignProp("", false, cmbSG_TileWidth_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSG_TileWidth.Enabled), 5, 0), !bGXsfl_66_Refreshing);
         cmbSG_TileColor.Enabled = 0;
         AssignProp("", false, cmbSG_TileColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSG_TileColor.Enabled), 5, 0), !bGXsfl_66_Refreshing);
         edtSG_TileBGImageUrl_Enabled = 0;
         AssignProp("", false, edtSG_TileBGImageUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_TileBGImageUrl_Enabled), 5, 0), !bGXsfl_66_Refreshing);
      }

      protected void send_integrity_lvl_hashes0Z77( )
      {
      }

      protected void send_integrity_lvl_hashes0Z71( )
      {
      }

      protected void SubsflControlProps_5752( )
      {
         edtAttributeId_Internalname = "ATTRIBUTEID_"+sGXsfl_57_idx;
         edtAttributeName_Internalname = "ATTRIBUTENAME_"+sGXsfl_57_idx;
         edtAttrbuteValue_Internalname = "ATTRBUTEVALUE_"+sGXsfl_57_idx;
      }

      protected void SubsflControlProps_fel_5752( )
      {
         edtAttributeId_Internalname = "ATTRIBUTEID_"+sGXsfl_57_fel_idx;
         edtAttributeName_Internalname = "ATTRIBUTENAME_"+sGXsfl_57_fel_idx;
         edtAttrbuteValue_Internalname = "ATTRBUTEVALUE_"+sGXsfl_57_fel_idx;
      }

      protected void AddRow0Z52( )
      {
         nGXsfl_57_idx = (int)(nGXsfl_57_idx+1);
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_5752( ) ;
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
            if ( ((int)((nGXsfl_57_idx) % (2))) == 0 )
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
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_52_" + sGXsfl_57_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_57_idx + "',57)\"";
         ROClassString = "Attribute";
         Gridlevel_attributeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttributeId_Internalname,A272AttributeId.ToString(),A272AttributeId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttributeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAttributeId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)57,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_52_" + sGXsfl_57_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_57_idx + "',57)\"";
         ROClassString = "Attribute";
         Gridlevel_attributeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttributeName_Internalname,(string)A273AttributeName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttributeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAttributeName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_52_" + sGXsfl_57_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_57_idx + "',57)\"";
         ROClassString = "Attribute";
         Gridlevel_attributeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttrbuteValue_Internalname,(string)A274AttrbuteValue,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttrbuteValue_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAttrbuteValue_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)57,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_attributeRow);
         send_integrity_lvl_hashes0Z52( ) ;
         GXCCtl = "Z272AttributeId_" + sGXsfl_57_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z272AttributeId.ToString());
         GXCCtl = "Z273AttributeName_" + sGXsfl_57_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z273AttributeName);
         GXCCtl = "Z274AttrbuteValue_" + sGXsfl_57_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z274AttrbuteValue);
         GXCCtl = "nRcdDeleted_52_" + sGXsfl_57_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_52), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_52_" + sGXsfl_57_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_52), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_52_" + sGXsfl_57_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_52), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_57_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_57_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTRN_TILEID_" + sGXsfl_57_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV45Trn_TileId.ToString());
         GxWebStd.gx_hidden_field( context, "ATTRIBUTEID_"+sGXsfl_57_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTENAME_"+sGXsfl_57_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRBUTEVALUE_"+sGXsfl_57_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttrbuteValue_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_attributeContainer.AddRow(Gridlevel_attributeRow);
      }

      protected void ReadRow0Z52( )
      {
         nGXsfl_57_idx = (int)(nGXsfl_57_idx+1);
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_5752( ) ;
         edtAttributeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTEID_"+sGXsfl_57_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtAttributeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTENAME_"+sGXsfl_57_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtAttrbuteValue_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRBUTEVALUE_"+sGXsfl_57_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               GXCCtl = "ATTRIBUTEID_" + sGXsfl_57_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtAttributeId_Internalname;
               wbErr = true;
            }
         }
         A273AttributeName = cgiGet( edtAttributeName_Internalname);
         A274AttrbuteValue = cgiGet( edtAttrbuteValue_Internalname);
         GXCCtl = "Z272AttributeId_" + sGXsfl_57_idx;
         Z272AttributeId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z273AttributeName_" + sGXsfl_57_idx;
         Z273AttributeName = cgiGet( GXCCtl);
         GXCCtl = "Z274AttrbuteValue_" + sGXsfl_57_idx;
         Z274AttrbuteValue = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_52_" + sGXsfl_57_idx;
         nRcdDeleted_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_52_" + sGXsfl_57_idx;
         nRcdExists_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_52_" + sGXsfl_57_idx;
         nIsMod_52 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_6677( )
      {
         edtSG_TileId_Internalname = "SG_TILEID_"+sGXsfl_66_idx;
         edtChildTileOrder_Internalname = "CHILDTILEORDER_"+sGXsfl_66_idx;
         cmbSG_TileWidth_Internalname = "SG_TILEWIDTH_"+sGXsfl_66_idx;
         cmbSG_TileColor_Internalname = "SG_TILECOLOR_"+sGXsfl_66_idx;
         edtSG_TileBGImageUrl_Internalname = "SG_TILEBGIMAGEURL_"+sGXsfl_66_idx;
      }

      protected void SubsflControlProps_fel_6677( )
      {
         edtSG_TileId_Internalname = "SG_TILEID_"+sGXsfl_66_fel_idx;
         edtChildTileOrder_Internalname = "CHILDTILEORDER_"+sGXsfl_66_fel_idx;
         cmbSG_TileWidth_Internalname = "SG_TILEWIDTH_"+sGXsfl_66_fel_idx;
         cmbSG_TileColor_Internalname = "SG_TILECOLOR_"+sGXsfl_66_fel_idx;
         edtSG_TileBGImageUrl_Internalname = "SG_TILEBGIMAGEURL_"+sGXsfl_66_fel_idx;
      }

      protected void AddRow0Z77( )
      {
         nGXsfl_66_idx = (int)(nGXsfl_66_idx+1);
         sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
         SubsflControlProps_6677( ) ;
         SendRow0Z77( ) ;
      }

      protected void SendRow0Z77( )
      {
         Gridlevel_childtileRow = GXWebRow.GetNew(context);
         if ( subGridlevel_childtile_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_childtile_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_childtile_Class, "") != 0 )
            {
               subGridlevel_childtile_Linesclass = subGridlevel_childtile_Class+"Odd";
            }
         }
         else if ( subGridlevel_childtile_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_childtile_Backstyle = 0;
            subGridlevel_childtile_Backcolor = subGridlevel_childtile_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_childtile_Class, "") != 0 )
            {
               subGridlevel_childtile_Linesclass = subGridlevel_childtile_Class+"Uniform";
            }
         }
         else if ( subGridlevel_childtile_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_childtile_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_childtile_Class, "") != 0 )
            {
               subGridlevel_childtile_Linesclass = subGridlevel_childtile_Class+"Odd";
            }
            subGridlevel_childtile_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_childtile_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_childtile_Backstyle = 1;
            if ( ((int)((nGXsfl_66_idx) % (2))) == 0 )
            {
               subGridlevel_childtile_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_childtile_Class, "") != 0 )
               {
                  subGridlevel_childtile_Linesclass = subGridlevel_childtile_Class+"Even";
               }
            }
            else
            {
               subGridlevel_childtile_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_childtile_Class, "") != 0 )
               {
                  subGridlevel_childtile_Linesclass = subGridlevel_childtile_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_77_" + sGXsfl_66_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_66_idx + "',66)\"";
         ROClassString = "Attribute";
         Gridlevel_childtileRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSG_TileId_Internalname,A266SG_TileId.ToString(),A266SG_TileId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSG_TileId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSG_TileId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)66,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_77_" + sGXsfl_66_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_66_idx + "',66)\"";
         ROClassString = "Attribute";
         Gridlevel_childtileRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtChildTileOrder_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A269ChildTileOrder), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtChildTileOrder_Enabled!=0) ? context.localUtil.Format( (decimal)(A269ChildTileOrder), "ZZZ9") : context.localUtil.Format( (decimal)(A269ChildTileOrder), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,68);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtChildTileOrder_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtChildTileOrder_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)66,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_77_" + sGXsfl_66_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_66_idx + "',66)\"";
         GXCCtl = "SG_TILEWIDTH_" + sGXsfl_66_idx;
         cmbSG_TileWidth.Name = GXCCtl;
         cmbSG_TileWidth.WebTags = "";
         cmbSG_TileWidth.addItem("1", context.GetMessage( "Small", ""), 0);
         cmbSG_TileWidth.addItem("2", context.GetMessage( "Medium", ""), 0);
         cmbSG_TileWidth.addItem("3", context.GetMessage( "Large", ""), 0);
         if ( cmbSG_TileWidth.ItemCount > 0 )
         {
            A275SG_TileWidth = (short)(Math.Round(NumberUtil.Val( cmbSG_TileWidth.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A275SG_TileWidth), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* ComboBox */
         Gridlevel_childtileRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSG_TileWidth,(string)cmbSG_TileWidth_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A275SG_TileWidth), 4, 0)),(short)1,(string)cmbSG_TileWidth_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbSG_TileWidth.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"",(string)"",(bool)true,(short)0});
         cmbSG_TileWidth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A275SG_TileWidth), 4, 0));
         AssignProp("", false, cmbSG_TileWidth_Internalname, "Values", (string)(cmbSG_TileWidth.ToJavascriptSource()), !bGXsfl_66_Refreshing);
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_77_" + sGXsfl_66_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_66_idx + "',66)\"";
         GXCCtl = "SG_TILECOLOR_" + sGXsfl_66_idx;
         cmbSG_TileColor.Name = GXCCtl;
         cmbSG_TileColor.WebTags = "";
         if ( cmbSG_TileColor.ItemCount > 0 )
         {
            A276SG_TileColor = cmbSG_TileColor.getValidValue(A276SG_TileColor);
         }
         /* ComboBox */
         Gridlevel_childtileRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSG_TileColor,(string)cmbSG_TileColor_Internalname,StringUtil.RTrim( A276SG_TileColor),(short)1,(string)cmbSG_TileColor_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbSG_TileColor.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"",(string)"",(bool)true,(short)0});
         cmbSG_TileColor.CurrentValue = StringUtil.RTrim( A276SG_TileColor);
         AssignProp("", false, cmbSG_TileColor_Internalname, "Values", (string)(cmbSG_TileColor.ToJavascriptSource()), !bGXsfl_66_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_77_" + sGXsfl_66_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_66_idx + "',66)\"";
         ROClassString = "Attribute";
         Gridlevel_childtileRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSG_TileBGImageUrl_Internalname,(string)A277SG_TileBGImageUrl,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)A277SG_TileBGImageUrl,(string)"_blank",(string)"",(string)"",(string)edtSG_TileBGImageUrl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtSG_TileBGImageUrl_Enabled,(short)0,(string)"url",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)66,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_childtileRow);
         send_integrity_lvl_hashes0Z77( ) ;
         GXCCtl = "Z266SG_TileId_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z266SG_TileId.ToString());
         GXCCtl = "Z269ChildTileOrder_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z269ChildTileOrder), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_77_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_77), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_77_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_77), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_77_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_77), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_66_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTRN_TILEID_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV45Trn_TileId.ToString());
         GxWebStd.gx_hidden_field( context, "SG_TILEID_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSG_TileId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CHILDTILEORDER_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtChildTileOrder_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SG_TILEWIDTH_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSG_TileWidth.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SG_TILECOLOR_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSG_TileColor.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SG_TILEBGIMAGEURL_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSG_TileBGImageUrl_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_childtileContainer.AddRow(Gridlevel_childtileRow);
      }

      protected void ReadRow0Z77( )
      {
         nGXsfl_66_idx = (int)(nGXsfl_66_idx+1);
         sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
         SubsflControlProps_6677( ) ;
         edtSG_TileId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SG_TILEID_"+sGXsfl_66_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtChildTileOrder_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CHILDTILEORDER_"+sGXsfl_66_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbSG_TileWidth.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SG_TILEWIDTH_"+sGXsfl_66_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbSG_TileColor.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SG_TILECOLOR_"+sGXsfl_66_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtSG_TileBGImageUrl_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SG_TILEBGIMAGEURL_"+sGXsfl_66_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtSG_TileId_Internalname), "") == 0 )
         {
            A266SG_TileId = Guid.Empty;
         }
         else
         {
            try
            {
               A266SG_TileId = StringUtil.StrToGuid( cgiGet( edtSG_TileId_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "SG_TILEID_" + sGXsfl_66_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtSG_TileId_Internalname;
               wbErr = true;
            }
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtChildTileOrder_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtChildTileOrder_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "CHILDTILEORDER_" + sGXsfl_66_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtChildTileOrder_Internalname;
            wbErr = true;
            A269ChildTileOrder = 0;
         }
         else
         {
            A269ChildTileOrder = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtChildTileOrder_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         cmbSG_TileWidth.Name = cmbSG_TileWidth_Internalname;
         cmbSG_TileWidth.CurrentValue = cgiGet( cmbSG_TileWidth_Internalname);
         A275SG_TileWidth = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbSG_TileWidth_Internalname), "."), 18, MidpointRounding.ToEven));
         cmbSG_TileColor.Name = cmbSG_TileColor_Internalname;
         cmbSG_TileColor.CurrentValue = cgiGet( cmbSG_TileColor_Internalname);
         A276SG_TileColor = cgiGet( cmbSG_TileColor_Internalname);
         A277SG_TileBGImageUrl = cgiGet( edtSG_TileBGImageUrl_Internalname);
         GXCCtl = "Z266SG_TileId_" + sGXsfl_66_idx;
         Z266SG_TileId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z269ChildTileOrder_" + sGXsfl_66_idx;
         Z269ChildTileOrder = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_77_" + sGXsfl_66_idx;
         nRcdDeleted_77 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_77_" + sGXsfl_66_idx;
         nRcdExists_77 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_77_" + sGXsfl_66_idx;
         nIsMod_77 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtSG_TileId_Enabled = edtSG_TileId_Enabled;
         defedtAttributeId_Enabled = edtAttributeId_Enabled;
      }

      protected void ConfirmValues0Z0( )
      {
         nGXsfl_57_idx = 0;
         sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
         SubsflControlProps_5752( ) ;
         while ( nGXsfl_57_idx < nRC_GXsfl_57 )
         {
            nGXsfl_57_idx = (int)(nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_5752( ) ;
            ChangePostValue( "Z272AttributeId_"+sGXsfl_57_idx, cgiGet( "ZT_"+"Z272AttributeId_"+sGXsfl_57_idx)) ;
            DeletePostValue( "ZT_"+"Z272AttributeId_"+sGXsfl_57_idx) ;
            ChangePostValue( "Z273AttributeName_"+sGXsfl_57_idx, cgiGet( "ZT_"+"Z273AttributeName_"+sGXsfl_57_idx)) ;
            DeletePostValue( "ZT_"+"Z273AttributeName_"+sGXsfl_57_idx) ;
            ChangePostValue( "Z274AttrbuteValue_"+sGXsfl_57_idx, cgiGet( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_57_idx)) ;
            DeletePostValue( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_57_idx) ;
         }
         nGXsfl_66_idx = 0;
         sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
         SubsflControlProps_6677( ) ;
         while ( nGXsfl_66_idx < nRC_GXsfl_66 )
         {
            nGXsfl_66_idx = (int)(nGXsfl_66_idx+1);
            sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
            SubsflControlProps_6677( ) ;
            ChangePostValue( "Z266SG_TileId_"+sGXsfl_66_idx, cgiGet( "ZT_"+"Z266SG_TileId_"+sGXsfl_66_idx)) ;
            DeletePostValue( "ZT_"+"Z266SG_TileId_"+sGXsfl_66_idx) ;
            ChangePostValue( "Z269ChildTileOrder_"+sGXsfl_66_idx, cgiGet( "ZT_"+"Z269ChildTileOrder_"+sGXsfl_66_idx)) ;
            DeletePostValue( "ZT_"+"Z269ChildTileOrder_"+sGXsfl_66_idx) ;
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
         GxWebStd.gx_hidden_field( context, "Z268Trn_TileWidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z268Trn_TileWidth), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z270Trn_TileColor", StringUtil.RTrim( Z270Trn_TileColor));
         GxWebStd.gx_hidden_field( context, "Z271Trn_TileBGImageUrl", Z271Trn_TileBGImageUrl);
         GxWebStd.gx_hidden_field( context, "Z58ProductServiceId", Z58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_57", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_57_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_66", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_66_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N58ProductServiceId", A58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "N11OrganisationId", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "N29LocationId", A29LocationId.ToString());
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSG_TILEID_DATA", AV13SG_TileId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSG_TILEID_DATA", AV13SG_TileId_Data);
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
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODUCTSERVICEID", AV20Insert_ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_ORGANISATIONID", AV46Insert_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_LOCATIONID", AV47Insert_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICENAME", A59ProductServiceName);
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEIMAGE_GXI", A40000ProductServiceImage_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV48Pgmname));
         GxWebStd.gx_hidden_field( context, "SG_TILENAME", A267SG_TileName);
         GXCCtlgxBlob = "PRODUCTSERVICEIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A61ProductServiceImage);
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TILEID_Objectcall", StringUtil.RTrim( Combo_sg_tileid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TILEID_Cls", StringUtil.RTrim( Combo_sg_tileid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TILEID_Gamoauthtoken", StringUtil.RTrim( Combo_sg_tileid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TILEID_Enabled", StringUtil.BoolToStr( Combo_sg_tileid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TILEID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_sg_tileid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TILEID_Isgriditem", StringUtil.BoolToStr( Combo_sg_tileid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TILEID_Hasdescription", StringUtil.BoolToStr( Combo_sg_tileid_Hasdescription));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TILEID_Datalistproc", StringUtil.RTrim( Combo_sg_tileid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TILEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_sg_tileid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TILEID_Emptyitem", StringUtil.BoolToStr( Combo_sg_tileid_Emptyitem));
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
         return context.GetMessage( "Tile", "") ;
      }

      protected void InitializeNonKey0Z71( )
      {
         A58ProductServiceId = Guid.Empty;
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         A11OrganisationId = Guid.Empty;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A29LocationId = Guid.Empty;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
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
         Z265Trn_TileName = "";
         Z268Trn_TileWidth = 0;
         Z270Trn_TileColor = "";
         Z271Trn_TileBGImageUrl = "";
         Z58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
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

      protected void InitializeNonKey0Z77( )
      {
         A267SG_TileName = "";
         AssignAttri("", false, "A267SG_TileName", A267SG_TileName);
         A275SG_TileWidth = 0;
         A276SG_TileColor = "";
         A277SG_TileBGImageUrl = "";
         A269ChildTileOrder = 0;
         Z269ChildTileOrder = 0;
      }

      protected void InitAll0Z77( )
      {
         A266SG_TileId = Guid.Empty;
         InitializeNonKey0Z77( ) ;
      }

      protected void StandaloneModalInsert0Z77( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024101016433063", true, true);
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
         context.AddJavascriptSource("trn_tile.js", "?2024101016433064", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties52( )
      {
         edtAttributeId_Enabled = defedtAttributeId_Enabled;
         AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_57_Refreshing);
      }

      protected void init_level_properties77( )
      {
         edtSG_TileId_Enabled = defedtSG_TileId_Enabled;
         AssignProp("", false, edtSG_TileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_TileId_Enabled), 5, 0), !bGXsfl_66_Refreshing);
      }

      protected void StartGridControl57( )
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

      protected void StartGridControl66( )
      {
         Gridlevel_childtileContainer.AddObjectProperty("GridName", "Gridlevel_childtile");
         Gridlevel_childtileContainer.AddObjectProperty("Header", subGridlevel_childtile_Header);
         Gridlevel_childtileContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_childtileContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_childtileContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_childtileContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_childtile_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_childtileContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_childtileContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_childtileColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_childtileColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A266SG_TileId.ToString()));
         Gridlevel_childtileColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSG_TileId_Enabled), 5, 0, ".", "")));
         Gridlevel_childtileContainer.AddColumnProperties(Gridlevel_childtileColumn);
         Gridlevel_childtileColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_childtileColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A269ChildTileOrder), 4, 0, ".", ""))));
         Gridlevel_childtileColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtChildTileOrder_Enabled), 5, 0, ".", "")));
         Gridlevel_childtileContainer.AddColumnProperties(Gridlevel_childtileColumn);
         Gridlevel_childtileColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_childtileColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A275SG_TileWidth), 4, 0, ".", ""))));
         Gridlevel_childtileColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSG_TileWidth.Enabled), 5, 0, ".", "")));
         Gridlevel_childtileContainer.AddColumnProperties(Gridlevel_childtileColumn);
         Gridlevel_childtileColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_childtileColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A276SG_TileColor)));
         Gridlevel_childtileColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSG_TileColor.Enabled), 5, 0, ".", "")));
         Gridlevel_childtileContainer.AddColumnProperties(Gridlevel_childtileColumn);
         Gridlevel_childtileColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_childtileColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A277SG_TileBGImageUrl));
         Gridlevel_childtileColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSG_TileBGImageUrl_Enabled), 5, 0, ".", "")));
         Gridlevel_childtileContainer.AddColumnProperties(Gridlevel_childtileColumn);
         Gridlevel_childtileContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_childtile_Selectedindex), 4, 0, ".", "")));
         Gridlevel_childtileContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_childtile_Allowselection), 1, 0, ".", "")));
         Gridlevel_childtileContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_childtile_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_childtileContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_childtile_Allowhovering), 1, 0, ".", "")));
         Gridlevel_childtileContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_childtile_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_childtileContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_childtile_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_childtileContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_childtile_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtTrn_TileName_Internalname = "TRN_TILENAME";
         cmbTrn_TileWidth_Internalname = "TRN_TILEWIDTH";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION";
         imgProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE";
         cmbTrn_TileColor_Internalname = "TRN_TILECOLOR";
         edtTrn_TileBGImageUrl_Internalname = "TRN_TILEBGIMAGEURL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         edtAttributeId_Internalname = "ATTRIBUTEID";
         edtAttributeName_Internalname = "ATTRIBUTENAME";
         edtAttrbuteValue_Internalname = "ATTRBUTEVALUE";
         divTableleaflevel_attribute_Internalname = "TABLELEAFLEVEL_ATTRIBUTE";
         edtSG_TileId_Internalname = "SG_TILEID";
         edtChildTileOrder_Internalname = "CHILDTILEORDER";
         cmbSG_TileWidth_Internalname = "SG_TILEWIDTH";
         cmbSG_TileColor_Internalname = "SG_TILECOLOR";
         edtSG_TileBGImageUrl_Internalname = "SG_TILEBGIMAGEURL";
         divTableleaflevel_childtile_Internalname = "TABLELEAFLEVEL_CHILDTILE";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Combo_sg_tileid_Internalname = "COMBO_SG_TILEID";
         edtTrn_TileId_Internalname = "TRN_TILEID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_attribute_Internalname = "GRIDLEVEL_ATTRIBUTE";
         subGridlevel_childtile_Internalname = "GRIDLEVEL_CHILDTILE";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_childtile_Allowcollapsing = 0;
         subGridlevel_childtile_Allowselection = 0;
         subGridlevel_childtile_Header = "";
         subGridlevel_attribute_Allowcollapsing = 0;
         subGridlevel_attribute_Allowselection = 0;
         subGridlevel_attribute_Header = "";
         Combo_sg_tileid_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Tile", "");
         edtSG_TileBGImageUrl_Jsonclick = "";
         cmbSG_TileColor_Jsonclick = "";
         cmbSG_TileWidth_Jsonclick = "";
         edtChildTileOrder_Jsonclick = "";
         edtSG_TileId_Jsonclick = "";
         subGridlevel_childtile_Class = "WorkWith";
         subGridlevel_childtile_Backcolorstyle = 0;
         edtAttrbuteValue_Jsonclick = "";
         edtAttributeName_Jsonclick = "";
         edtAttributeId_Jsonclick = "";
         subGridlevel_attribute_Class = "WorkWith";
         subGridlevel_attribute_Backcolorstyle = 0;
         Combo_sg_tileid_Titlecontrolidtoreplace = "";
         edtSG_TileBGImageUrl_Enabled = 0;
         cmbSG_TileColor.Enabled = 0;
         cmbSG_TileWidth.Enabled = 0;
         edtChildTileOrder_Enabled = 1;
         edtSG_TileId_Enabled = 1;
         edtAttrbuteValue_Enabled = 1;
         edtAttributeName_Enabled = 1;
         edtAttributeId_Enabled = 1;
         edtTrn_TileId_Jsonclick = "";
         edtTrn_TileId_Enabled = 1;
         edtTrn_TileId_Visible = 1;
         Combo_sg_tileid_Emptyitem = Convert.ToBoolean( 0);
         Combo_sg_tileid_Datalistprocparametersprefix = " \"ComboName\": \"SG_TileId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"Trn_TileId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_sg_tileid_Datalistproc = "Trn_TileLoadDVCombo";
         Combo_sg_tileid_Hasdescription = Convert.ToBoolean( -1);
         Combo_sg_tileid_Isgriditem = Convert.ToBoolean( -1);
         Combo_sg_tileid_Cls = "ExtendedCombo";
         Combo_sg_tileid_Caption = "";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTrn_TileBGImageUrl_Jsonclick = "";
         edtTrn_TileBGImageUrl_Enabled = 1;
         cmbTrn_TileColor_Jsonclick = "";
         cmbTrn_TileColor.Enabled = 1;
         imgProductServiceImage_Enabled = 0;
         edtProductServiceDescription_Enabled = 0;
         edtProductServiceId_Jsonclick = "";
         edtProductServiceId_Enabled = 1;
         cmbTrn_TileWidth_Jsonclick = "";
         cmbTrn_TileWidth.Enabled = 1;
         edtTrn_TileName_Jsonclick = "";
         edtTrn_TileName_Enabled = 1;
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
         SubsflControlProps_5752( ) ;
         while ( nGXsfl_57_idx <= nRC_GXsfl_57 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0Z52( ) ;
            standaloneModal0Z52( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0Z52( ) ;
            nGXsfl_57_idx = (int)(nGXsfl_57_idx+1);
            sGXsfl_57_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_57_idx), 4, 0), 4, "0");
            SubsflControlProps_5752( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_attributeContainer)) ;
         /* End function gxnrGridlevel_attribute_newrow */
      }

      protected void gxnrGridlevel_childtile_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_6677( ) ;
         while ( nGXsfl_66_idx <= nRC_GXsfl_66 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0Z77( ) ;
            standaloneModal0Z77( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0Z77( ) ;
            nGXsfl_66_idx = (int)(nGXsfl_66_idx+1);
            sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
            SubsflControlProps_6677( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_childtileContainer)) ;
         /* End function gxnrGridlevel_childtile_newrow */
      }

      protected void init_web_controls( )
      {
         cmbTrn_TileWidth.Name = "TRN_TILEWIDTH";
         cmbTrn_TileWidth.WebTags = "";
         cmbTrn_TileWidth.addItem("1", context.GetMessage( "Small", ""), 0);
         cmbTrn_TileWidth.addItem("2", context.GetMessage( "Medium", ""), 0);
         cmbTrn_TileWidth.addItem("3", context.GetMessage( "Large", ""), 0);
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
         GXCCtl = "SG_TILEWIDTH_" + sGXsfl_66_idx;
         cmbSG_TileWidth.Name = GXCCtl;
         cmbSG_TileWidth.WebTags = "";
         cmbSG_TileWidth.addItem("1", context.GetMessage( "Small", ""), 0);
         cmbSG_TileWidth.addItem("2", context.GetMessage( "Medium", ""), 0);
         cmbSG_TileWidth.addItem("3", context.GetMessage( "Large", ""), 0);
         if ( cmbSG_TileWidth.ItemCount > 0 )
         {
            A275SG_TileWidth = (short)(Math.Round(NumberUtil.Val( cmbSG_TileWidth.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A275SG_TileWidth), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "SG_TILECOLOR_" + sGXsfl_66_idx;
         cmbSG_TileColor.Name = GXCCtl;
         cmbSG_TileColor.WebTags = "";
         if ( cmbSG_TileColor.ItemCount > 0 )
         {
            A276SG_TileColor = cmbSG_TileColor.getValidValue(A276SG_TileColor);
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

      public void Valid_Sg_tileid( )
      {
         A275SG_TileWidth = (short)(Math.Round(NumberUtil.Val( cmbSG_TileWidth.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbSG_TileWidth.CurrentValue = StringUtil.LTrimStr( (decimal)(A275SG_TileWidth), 4, 0);
         A276SG_TileColor = cmbSG_TileColor.CurrentValue;
         cmbSG_TileColor.CurrentValue = A276SG_TileColor;
         /* Using cursor T000Z34 */
         pr_default.execute(32, new Object[] {A266SG_TileId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Tile", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_TILEID");
            AnyError = 1;
            GX_FocusControl = edtSG_TileId_Internalname;
         }
         A267SG_TileName = T000Z34_A267SG_TileName[0];
         A275SG_TileWidth = T000Z34_A275SG_TileWidth[0];
         cmbSG_TileWidth.CurrentValue = StringUtil.LTrimStr( (decimal)(A275SG_TileWidth), 4, 0);
         A276SG_TileColor = T000Z34_A276SG_TileColor[0];
         cmbSG_TileColor.CurrentValue = A276SG_TileColor;
         A277SG_TileBGImageUrl = T000Z34_A277SG_TileBGImageUrl[0];
         pr_default.close(32);
         dynload_actions( ) ;
         if ( cmbSG_TileWidth.ItemCount > 0 )
         {
            A275SG_TileWidth = (short)(Math.Round(NumberUtil.Val( cmbSG_TileWidth.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A275SG_TileWidth), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbSG_TileWidth.CurrentValue = StringUtil.LTrimStr( (decimal)(A275SG_TileWidth), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSG_TileWidth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A275SG_TileWidth), 4, 0));
         }
         if ( cmbSG_TileColor.ItemCount > 0 )
         {
            A276SG_TileColor = cmbSG_TileColor.getValidValue(A276SG_TileColor);
            cmbSG_TileColor.CurrentValue = A276SG_TileColor;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSG_TileColor.CurrentValue = StringUtil.RTrim( A276SG_TileColor);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A267SG_TileName", A267SG_TileName);
         AssignAttri("", false, "A275SG_TileWidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(A275SG_TileWidth), 4, 0, ".", "")));
         cmbSG_TileWidth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A275SG_TileWidth), 4, 0));
         AssignProp("", false, cmbSG_TileWidth_Internalname, "Values", cmbSG_TileWidth.ToJavascriptSource(), true);
         AssignAttri("", false, "A276SG_TileColor", StringUtil.RTrim( A276SG_TileColor));
         cmbSG_TileColor.CurrentValue = StringUtil.RTrim( A276SG_TileColor);
         AssignProp("", false, cmbSG_TileColor_Internalname, "Values", cmbSG_TileColor.ToJavascriptSource(), true);
         AssignAttri("", false, "A277SG_TileBGImageUrl", A277SG_TileBGImageUrl);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV45Trn_TileId","fld":"vTRN_TILEID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV45Trn_TileId","fld":"vTRN_TILEID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120Z2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_TRN_TILEWIDTH","""{"handler":"Valid_Trn_tilewidth","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[]}""");
         setEventMetadata("VALID_TRN_TILEBGIMAGEURL","""{"handler":"Valid_Trn_tilebgimageurl","iparms":[]}""");
         setEventMetadata("VALID_TRN_TILEID","""{"handler":"Valid_Trn_tileid","iparms":[]}""");
         setEventMetadata("VALID_ATTRIBUTEID","""{"handler":"Valid_Attributeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Attrbutevalue","iparms":[]}""");
         setEventMetadata("VALID_SG_TILEID","""{"handler":"Valid_Sg_tileid","iparms":[{"av":"A266SG_TileId","fld":"SG_TILEID"},{"av":"A267SG_TileName","fld":"SG_TILENAME"},{"av":"cmbSG_TileWidth"},{"av":"A275SG_TileWidth","fld":"SG_TILEWIDTH","pic":"ZZZ9"},{"av":"cmbSG_TileColor"},{"av":"A276SG_TileColor","fld":"SG_TILECOLOR"},{"av":"A277SG_TileBGImageUrl","fld":"SG_TILEBGIMAGEURL"}]""");
         setEventMetadata("VALID_SG_TILEID",""","oparms":[{"av":"A267SG_TileName","fld":"SG_TILENAME"},{"av":"cmbSG_TileWidth"},{"av":"A275SG_TileWidth","fld":"SG_TILEWIDTH","pic":"ZZZ9"},{"av":"cmbSG_TileColor"},{"av":"A276SG_TileColor","fld":"SG_TILECOLOR"},{"av":"A277SG_TileBGImageUrl","fld":"SG_TILEBGIMAGEURL"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Sg_tilebgimageurl","iparms":[]}""");
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
         pr_default.close(32);
         pr_default.close(4);
         pr_default.close(6);
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
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         N58ProductServiceId = Guid.Empty;
         N11OrganisationId = Guid.Empty;
         N29LocationId = Guid.Empty;
         Z272AttributeId = Guid.Empty;
         Z273AttributeName = "";
         Z274AttrbuteValue = "";
         Z266SG_TileId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A58ProductServiceId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A266SG_TileId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A270Trn_TileColor = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A265Trn_TileName = "";
         A60ProductServiceDescription = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         sImgUrl = "";
         A271Trn_TileBGImageUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucCombo_sg_tileid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13SG_TileId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A264Trn_TileId = Guid.Empty;
         Gridlevel_attributeContainer = new GXWebGrid( context);
         sMode52 = "";
         A272AttributeId = Guid.Empty;
         sStyleString = "";
         Gridlevel_childtileContainer = new GXWebGrid( context);
         sMode77 = "";
         AV20Insert_ProductServiceId = Guid.Empty;
         AV46Insert_OrganisationId = Guid.Empty;
         AV47Insert_LocationId = Guid.Empty;
         A59ProductServiceName = "";
         AV48Pgmname = "";
         A267SG_TileName = "";
         Combo_sg_tileid_Objectcall = "";
         Combo_sg_tileid_Class = "";
         Combo_sg_tileid_Icontype = "";
         Combo_sg_tileid_Icon = "";
         Combo_sg_tileid_Tooltip = "";
         Combo_sg_tileid_Selectedvalue_set = "";
         Combo_sg_tileid_Selectedvalue_get = "";
         Combo_sg_tileid_Selectedtext_set = "";
         Combo_sg_tileid_Selectedtext_get = "";
         Combo_sg_tileid_Gamoauthtoken = "";
         Combo_sg_tileid_Ddointernalname = "";
         Combo_sg_tileid_Titlecontrolalign = "";
         Combo_sg_tileid_Dropdownoptionstype = "";
         Combo_sg_tileid_Datalisttype = "";
         Combo_sg_tileid_Datalistfixedvalues = "";
         Combo_sg_tileid_Remoteservicesparameters = "";
         Combo_sg_tileid_Htmltemplate = "";
         Combo_sg_tileid_Multiplevaluestype = "";
         Combo_sg_tileid_Loadingdata = "";
         Combo_sg_tileid_Noresultsfound = "";
         Combo_sg_tileid_Emptyitemtext = "";
         Combo_sg_tileid_Onlyselectedvalues = "";
         Combo_sg_tileid_Selectalltext = "";
         Combo_sg_tileid_Multiplevaluesseparator = "";
         Combo_sg_tileid_Addnewoptiontext = "";
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
         A276SG_TileColor = "";
         A277SG_TileBGImageUrl = "";
         A273AttributeName = "";
         A274AttrbuteValue = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV18GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV19GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV21TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z59ProductServiceName = "";
         Z60ProductServiceDescription = "";
         Z61ProductServiceImage = "";
         Z40000ProductServiceImage_GXI = "";
         T000Z9_A59ProductServiceName = new string[] {""} ;
         T000Z9_A60ProductServiceDescription = new string[] {""} ;
         T000Z9_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z9_A61ProductServiceImage = new string[] {""} ;
         T000Z10_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z10_A265Trn_TileName = new string[] {""} ;
         T000Z10_A268Trn_TileWidth = new short[1] ;
         T000Z10_A270Trn_TileColor = new string[] {""} ;
         T000Z10_A271Trn_TileBGImageUrl = new string[] {""} ;
         T000Z10_A59ProductServiceName = new string[] {""} ;
         T000Z10_A60ProductServiceDescription = new string[] {""} ;
         T000Z10_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z10_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z10_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z10_A61ProductServiceImage = new string[] {""} ;
         T000Z11_A59ProductServiceName = new string[] {""} ;
         T000Z11_A60ProductServiceDescription = new string[] {""} ;
         T000Z11_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z11_A61ProductServiceImage = new string[] {""} ;
         T000Z12_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z8_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z8_A265Trn_TileName = new string[] {""} ;
         T000Z8_A268Trn_TileWidth = new short[1] ;
         T000Z8_A270Trn_TileColor = new string[] {""} ;
         T000Z8_A271Trn_TileBGImageUrl = new string[] {""} ;
         T000Z8_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z8_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z13_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z14_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z7_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z7_A265Trn_TileName = new string[] {""} ;
         T000Z7_A268Trn_TileWidth = new short[1] ;
         T000Z7_A270Trn_TileColor = new string[] {""} ;
         T000Z7_A271Trn_TileBGImageUrl = new string[] {""} ;
         T000Z7_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z7_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z18_A59ProductServiceName = new string[] {""} ;
         T000Z18_A60ProductServiceDescription = new string[] {""} ;
         T000Z18_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z18_A61ProductServiceImage = new string[] {""} ;
         T000Z19_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         T000Z20_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z20_A266SG_TileId = new Guid[] {Guid.Empty} ;
         T000Z21_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z22_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z22_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z22_A273AttributeName = new string[] {""} ;
         T000Z22_A274AttrbuteValue = new string[] {""} ;
         T000Z23_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z23_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z6_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z6_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z6_A273AttributeName = new string[] {""} ;
         T000Z6_A274AttrbuteValue = new string[] {""} ;
         T000Z5_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z5_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z5_A273AttributeName = new string[] {""} ;
         T000Z5_A274AttrbuteValue = new string[] {""} ;
         T000Z27_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z27_A272AttributeId = new Guid[] {Guid.Empty} ;
         Z267SG_TileName = "";
         Z276SG_TileColor = "";
         Z277SG_TileBGImageUrl = "";
         T000Z28_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z28_A267SG_TileName = new string[] {""} ;
         T000Z28_A275SG_TileWidth = new short[1] ;
         T000Z28_A276SG_TileColor = new string[] {""} ;
         T000Z28_A277SG_TileBGImageUrl = new string[] {""} ;
         T000Z28_A269ChildTileOrder = new short[1] ;
         T000Z28_A266SG_TileId = new Guid[] {Guid.Empty} ;
         T000Z4_A267SG_TileName = new string[] {""} ;
         T000Z4_A275SG_TileWidth = new short[1] ;
         T000Z4_A276SG_TileColor = new string[] {""} ;
         T000Z4_A277SG_TileBGImageUrl = new string[] {""} ;
         T000Z29_A267SG_TileName = new string[] {""} ;
         T000Z29_A275SG_TileWidth = new short[1] ;
         T000Z29_A276SG_TileColor = new string[] {""} ;
         T000Z29_A277SG_TileBGImageUrl = new string[] {""} ;
         T000Z30_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z30_A266SG_TileId = new Guid[] {Guid.Empty} ;
         T000Z3_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z3_A269ChildTileOrder = new short[1] ;
         T000Z3_A266SG_TileId = new Guid[] {Guid.Empty} ;
         T000Z2_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z2_A269ChildTileOrder = new short[1] ;
         T000Z2_A266SG_TileId = new Guid[] {Guid.Empty} ;
         T000Z34_A267SG_TileName = new string[] {""} ;
         T000Z34_A275SG_TileWidth = new short[1] ;
         T000Z34_A276SG_TileColor = new string[] {""} ;
         T000Z34_A277SG_TileBGImageUrl = new string[] {""} ;
         T000Z35_A264Trn_TileId = new Guid[] {Guid.Empty} ;
         T000Z35_A266SG_TileId = new Guid[] {Guid.Empty} ;
         Gridlevel_attributeRow = new GXWebRow();
         subGridlevel_attribute_Linesclass = "";
         ROClassString = "";
         Gridlevel_childtileRow = new GXWebRow();
         subGridlevel_childtile_Linesclass = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         Gridlevel_attributeColumn = new GXWebColumn();
         Gridlevel_childtileColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_tile__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tile__default(),
            new Object[][] {
                new Object[] {
               T000Z2_A264Trn_TileId, T000Z2_A269ChildTileOrder, T000Z2_A266SG_TileId
               }
               , new Object[] {
               T000Z3_A264Trn_TileId, T000Z3_A269ChildTileOrder, T000Z3_A266SG_TileId
               }
               , new Object[] {
               T000Z4_A267SG_TileName, T000Z4_A275SG_TileWidth, T000Z4_A276SG_TileColor, T000Z4_A277SG_TileBGImageUrl
               }
               , new Object[] {
               T000Z5_A264Trn_TileId, T000Z5_A272AttributeId, T000Z5_A273AttributeName, T000Z5_A274AttrbuteValue
               }
               , new Object[] {
               T000Z6_A264Trn_TileId, T000Z6_A272AttributeId, T000Z6_A273AttributeName, T000Z6_A274AttrbuteValue
               }
               , new Object[] {
               T000Z7_A264Trn_TileId, T000Z7_A265Trn_TileName, T000Z7_A268Trn_TileWidth, T000Z7_A270Trn_TileColor, T000Z7_A271Trn_TileBGImageUrl, T000Z7_A58ProductServiceId, T000Z7_A29LocationId, T000Z7_A11OrganisationId
               }
               , new Object[] {
               T000Z8_A264Trn_TileId, T000Z8_A265Trn_TileName, T000Z8_A268Trn_TileWidth, T000Z8_A270Trn_TileColor, T000Z8_A271Trn_TileBGImageUrl, T000Z8_A58ProductServiceId, T000Z8_A29LocationId, T000Z8_A11OrganisationId
               }
               , new Object[] {
               T000Z9_A59ProductServiceName, T000Z9_A60ProductServiceDescription, T000Z9_A40000ProductServiceImage_GXI, T000Z9_A61ProductServiceImage
               }
               , new Object[] {
               T000Z10_A264Trn_TileId, T000Z10_A265Trn_TileName, T000Z10_A268Trn_TileWidth, T000Z10_A270Trn_TileColor, T000Z10_A271Trn_TileBGImageUrl, T000Z10_A59ProductServiceName, T000Z10_A60ProductServiceDescription, T000Z10_A40000ProductServiceImage_GXI, T000Z10_A58ProductServiceId, T000Z10_A29LocationId,
               T000Z10_A11OrganisationId, T000Z10_A61ProductServiceImage
               }
               , new Object[] {
               T000Z11_A59ProductServiceName, T000Z11_A60ProductServiceDescription, T000Z11_A40000ProductServiceImage_GXI, T000Z11_A61ProductServiceImage
               }
               , new Object[] {
               T000Z12_A264Trn_TileId
               }
               , new Object[] {
               T000Z13_A264Trn_TileId
               }
               , new Object[] {
               T000Z14_A264Trn_TileId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z18_A59ProductServiceName, T000Z18_A60ProductServiceDescription, T000Z18_A40000ProductServiceImage_GXI, T000Z18_A61ProductServiceImage
               }
               , new Object[] {
               T000Z19_A328Trn_ColId
               }
               , new Object[] {
               T000Z20_A264Trn_TileId, T000Z20_A266SG_TileId
               }
               , new Object[] {
               T000Z21_A264Trn_TileId
               }
               , new Object[] {
               T000Z22_A264Trn_TileId, T000Z22_A272AttributeId, T000Z22_A273AttributeName, T000Z22_A274AttrbuteValue
               }
               , new Object[] {
               T000Z23_A264Trn_TileId, T000Z23_A272AttributeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z27_A264Trn_TileId, T000Z27_A272AttributeId
               }
               , new Object[] {
               T000Z28_A264Trn_TileId, T000Z28_A267SG_TileName, T000Z28_A275SG_TileWidth, T000Z28_A276SG_TileColor, T000Z28_A277SG_TileBGImageUrl, T000Z28_A269ChildTileOrder, T000Z28_A266SG_TileId
               }
               , new Object[] {
               T000Z29_A267SG_TileName, T000Z29_A275SG_TileWidth, T000Z29_A276SG_TileColor, T000Z29_A277SG_TileBGImageUrl
               }
               , new Object[] {
               T000Z30_A264Trn_TileId, T000Z30_A266SG_TileId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z34_A267SG_TileName, T000Z34_A275SG_TileWidth, T000Z34_A276SG_TileColor, T000Z34_A277SG_TileBGImageUrl
               }
               , new Object[] {
               T000Z35_A264Trn_TileId, T000Z35_A266SG_TileId
               }
            }
         );
         Z272AttributeId = Guid.NewGuid( );
         A272AttributeId = Guid.NewGuid( );
         Z264Trn_TileId = Guid.NewGuid( );
         A264Trn_TileId = Guid.NewGuid( );
         AV48Pgmname = "Trn_Tile";
      }

      private short Z268Trn_TileWidth ;
      private short nRcdDeleted_52 ;
      private short nRcdExists_52 ;
      private short nIsMod_52 ;
      private short Z269ChildTileOrder ;
      private short nRcdDeleted_77 ;
      private short nRcdExists_77 ;
      private short nIsMod_77 ;
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
      private short nBlankRcdCount77 ;
      private short RcdFound77 ;
      private short nBlankRcdUsr77 ;
      private short RcdFound71 ;
      private short A269ChildTileOrder ;
      private short A275SG_TileWidth ;
      private short nIsDirty_52 ;
      private short Z275SG_TileWidth ;
      private short nIsDirty_77 ;
      private short subGridlevel_attribute_Backcolorstyle ;
      private short subGridlevel_attribute_Backstyle ;
      private short subGridlevel_childtile_Backcolorstyle ;
      private short subGridlevel_childtile_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_attribute_Allowselection ;
      private short subGridlevel_attribute_Allowhovering ;
      private short subGridlevel_attribute_Allowcollapsing ;
      private short subGridlevel_attribute_Collapsed ;
      private short subGridlevel_childtile_Allowselection ;
      private short subGridlevel_childtile_Allowhovering ;
      private short subGridlevel_childtile_Allowcollapsing ;
      private short subGridlevel_childtile_Collapsed ;
      private int nRC_GXsfl_57 ;
      private int nGXsfl_57_idx=1 ;
      private int nRC_GXsfl_66 ;
      private int nGXsfl_66_idx=1 ;
      private int trnEnded ;
      private int edtTrn_TileName_Enabled ;
      private int edtProductServiceId_Enabled ;
      private int edtProductServiceDescription_Enabled ;
      private int imgProductServiceImage_Enabled ;
      private int edtTrn_TileBGImageUrl_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtTrn_TileId_Visible ;
      private int edtTrn_TileId_Enabled ;
      private int edtAttributeId_Enabled ;
      private int edtAttributeName_Enabled ;
      private int edtAttrbuteValue_Enabled ;
      private int fRowAdded ;
      private int edtSG_TileId_Enabled ;
      private int edtChildTileOrder_Enabled ;
      private int edtSG_TileBGImageUrl_Enabled ;
      private int Combo_sg_tileid_Datalistupdateminimumcharacters ;
      private int Combo_sg_tileid_Gxcontroltype ;
      private int AV49GXV1 ;
      private int subGridlevel_attribute_Backcolor ;
      private int subGridlevel_attribute_Allbackcolor ;
      private int subGridlevel_childtile_Backcolor ;
      private int subGridlevel_childtile_Allbackcolor ;
      private int defedtSG_TileId_Enabled ;
      private int defedtAttributeId_Enabled ;
      private int idxLst ;
      private int subGridlevel_attribute_Selectedindex ;
      private int subGridlevel_attribute_Selectioncolor ;
      private int subGridlevel_attribute_Hoveringcolor ;
      private int subGridlevel_childtile_Selectedindex ;
      private int subGridlevel_childtile_Selectioncolor ;
      private int subGridlevel_childtile_Hoveringcolor ;
      private long GRIDLEVEL_ATTRIBUTE_nFirstRecordOnPage ;
      private long GRIDLEVEL_CHILDTILE_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z270Trn_TileColor ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrn_TileName_Internalname ;
      private string sGXsfl_57_idx="0001" ;
      private string sGXsfl_66_idx="0001" ;
      private string cmbTrn_TileWidth_Internalname ;
      private string A270Trn_TileColor ;
      private string cmbTrn_TileColor_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTrn_TileName_Jsonclick ;
      private string cmbTrn_TileWidth_Jsonclick ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceId_Jsonclick ;
      private string edtProductServiceDescription_Internalname ;
      private string imgProductServiceImage_Internalname ;
      private string sImgUrl ;
      private string cmbTrn_TileColor_Jsonclick ;
      private string edtTrn_TileBGImageUrl_Internalname ;
      private string edtTrn_TileBGImageUrl_Jsonclick ;
      private string divTableleaflevel_attribute_Internalname ;
      private string divTableleaflevel_childtile_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Combo_sg_tileid_Caption ;
      private string Combo_sg_tileid_Cls ;
      private string Combo_sg_tileid_Datalistproc ;
      private string Combo_sg_tileid_Datalistprocparametersprefix ;
      private string Combo_sg_tileid_Internalname ;
      private string edtTrn_TileId_Internalname ;
      private string edtTrn_TileId_Jsonclick ;
      private string sMode52 ;
      private string edtAttributeId_Internalname ;
      private string edtAttributeName_Internalname ;
      private string edtAttrbuteValue_Internalname ;
      private string sStyleString ;
      private string subGridlevel_attribute_Internalname ;
      private string sMode77 ;
      private string edtSG_TileId_Internalname ;
      private string edtChildTileOrder_Internalname ;
      private string cmbSG_TileWidth_Internalname ;
      private string cmbSG_TileColor_Internalname ;
      private string edtSG_TileBGImageUrl_Internalname ;
      private string subGridlevel_childtile_Internalname ;
      private string AV48Pgmname ;
      private string Combo_sg_tileid_Objectcall ;
      private string Combo_sg_tileid_Class ;
      private string Combo_sg_tileid_Icontype ;
      private string Combo_sg_tileid_Icon ;
      private string Combo_sg_tileid_Tooltip ;
      private string Combo_sg_tileid_Selectedvalue_set ;
      private string Combo_sg_tileid_Selectedvalue_get ;
      private string Combo_sg_tileid_Selectedtext_set ;
      private string Combo_sg_tileid_Selectedtext_get ;
      private string Combo_sg_tileid_Gamoauthtoken ;
      private string Combo_sg_tileid_Ddointernalname ;
      private string Combo_sg_tileid_Titlecontrolalign ;
      private string Combo_sg_tileid_Dropdownoptionstype ;
      private string Combo_sg_tileid_Titlecontrolidtoreplace ;
      private string Combo_sg_tileid_Datalisttype ;
      private string Combo_sg_tileid_Datalistfixedvalues ;
      private string Combo_sg_tileid_Remoteservicesparameters ;
      private string Combo_sg_tileid_Htmltemplate ;
      private string Combo_sg_tileid_Multiplevaluestype ;
      private string Combo_sg_tileid_Loadingdata ;
      private string Combo_sg_tileid_Noresultsfound ;
      private string Combo_sg_tileid_Emptyitemtext ;
      private string Combo_sg_tileid_Onlyselectedvalues ;
      private string Combo_sg_tileid_Selectalltext ;
      private string Combo_sg_tileid_Multiplevaluesseparator ;
      private string Combo_sg_tileid_Addnewoptiontext ;
      private string hsh ;
      private string sMode71 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A276SG_TileColor ;
      private string Z276SG_TileColor ;
      private string sGXsfl_57_fel_idx="0001" ;
      private string subGridlevel_attribute_Class ;
      private string subGridlevel_attribute_Linesclass ;
      private string ROClassString ;
      private string edtAttributeId_Jsonclick ;
      private string edtAttributeName_Jsonclick ;
      private string edtAttrbuteValue_Jsonclick ;
      private string sGXsfl_66_fel_idx="0001" ;
      private string subGridlevel_childtile_Class ;
      private string subGridlevel_childtile_Linesclass ;
      private string edtSG_TileId_Jsonclick ;
      private string edtChildTileOrder_Jsonclick ;
      private string cmbSG_TileWidth_Jsonclick ;
      private string cmbSG_TileColor_Jsonclick ;
      private string edtSG_TileBGImageUrl_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private string subGridlevel_attribute_Header ;
      private string subGridlevel_childtile_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A61ProductServiceImage_IsBlob ;
      private bool Combo_sg_tileid_Isgriditem ;
      private bool Combo_sg_tileid_Hasdescription ;
      private bool Combo_sg_tileid_Emptyitem ;
      private bool bGXsfl_57_Refreshing=false ;
      private bool bGXsfl_66_Refreshing=false ;
      private bool Combo_sg_tileid_Enabled ;
      private bool Combo_sg_tileid_Visible ;
      private bool Combo_sg_tileid_Allowmultipleselection ;
      private bool Combo_sg_tileid_Includeonlyselectedoption ;
      private bool Combo_sg_tileid_Includeselectalloption ;
      private bool Combo_sg_tileid_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A60ProductServiceDescription ;
      private string Z60ProductServiceDescription ;
      private string Z265Trn_TileName ;
      private string Z271Trn_TileBGImageUrl ;
      private string Z273AttributeName ;
      private string Z274AttrbuteValue ;
      private string A265Trn_TileName ;
      private string A40000ProductServiceImage_GXI ;
      private string A271Trn_TileBGImageUrl ;
      private string A59ProductServiceName ;
      private string A267SG_TileName ;
      private string A277SG_TileBGImageUrl ;
      private string A273AttributeName ;
      private string A274AttrbuteValue ;
      private string Z59ProductServiceName ;
      private string Z40000ProductServiceImage_GXI ;
      private string Z267SG_TileName ;
      private string Z277SG_TileBGImageUrl ;
      private string A61ProductServiceImage ;
      private string Z61ProductServiceImage ;
      private Guid wcpOAV45Trn_TileId ;
      private Guid Z264Trn_TileId ;
      private Guid Z58ProductServiceId ;
      private Guid Z29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid N58ProductServiceId ;
      private Guid N11OrganisationId ;
      private Guid N29LocationId ;
      private Guid Z272AttributeId ;
      private Guid Z266SG_TileId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A266SG_TileId ;
      private Guid AV45Trn_TileId ;
      private Guid A264Trn_TileId ;
      private Guid A272AttributeId ;
      private Guid AV20Insert_ProductServiceId ;
      private Guid AV46Insert_OrganisationId ;
      private Guid AV47Insert_LocationId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_attributeContainer ;
      private GXWebGrid Gridlevel_childtileContainer ;
      private GXWebRow Gridlevel_attributeRow ;
      private GXWebRow Gridlevel_childtileRow ;
      private GXWebColumn Gridlevel_attributeColumn ;
      private GXWebColumn Gridlevel_childtileColumn ;
      private GXUserControl ucCombo_sg_tileid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTrn_TileWidth ;
      private GXCombobox cmbTrn_TileColor ;
      private GXCombobox cmbSG_TileWidth ;
      private GXCombobox cmbSG_TileColor ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13SG_TileId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV18GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV19GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV21TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000Z9_A59ProductServiceName ;
      private string[] T000Z9_A60ProductServiceDescription ;
      private string[] T000Z9_A40000ProductServiceImage_GXI ;
      private string[] T000Z9_A61ProductServiceImage ;
      private Guid[] T000Z10_A264Trn_TileId ;
      private string[] T000Z10_A265Trn_TileName ;
      private short[] T000Z10_A268Trn_TileWidth ;
      private string[] T000Z10_A270Trn_TileColor ;
      private string[] T000Z10_A271Trn_TileBGImageUrl ;
      private string[] T000Z10_A59ProductServiceName ;
      private string[] T000Z10_A60ProductServiceDescription ;
      private string[] T000Z10_A40000ProductServiceImage_GXI ;
      private Guid[] T000Z10_A58ProductServiceId ;
      private Guid[] T000Z10_A29LocationId ;
      private Guid[] T000Z10_A11OrganisationId ;
      private string[] T000Z10_A61ProductServiceImage ;
      private string[] T000Z11_A59ProductServiceName ;
      private string[] T000Z11_A60ProductServiceDescription ;
      private string[] T000Z11_A40000ProductServiceImage_GXI ;
      private string[] T000Z11_A61ProductServiceImage ;
      private Guid[] T000Z12_A264Trn_TileId ;
      private Guid[] T000Z8_A264Trn_TileId ;
      private string[] T000Z8_A265Trn_TileName ;
      private short[] T000Z8_A268Trn_TileWidth ;
      private string[] T000Z8_A270Trn_TileColor ;
      private string[] T000Z8_A271Trn_TileBGImageUrl ;
      private Guid[] T000Z8_A58ProductServiceId ;
      private Guid[] T000Z8_A29LocationId ;
      private Guid[] T000Z8_A11OrganisationId ;
      private Guid[] T000Z13_A264Trn_TileId ;
      private Guid[] T000Z14_A264Trn_TileId ;
      private Guid[] T000Z7_A264Trn_TileId ;
      private string[] T000Z7_A265Trn_TileName ;
      private short[] T000Z7_A268Trn_TileWidth ;
      private string[] T000Z7_A270Trn_TileColor ;
      private string[] T000Z7_A271Trn_TileBGImageUrl ;
      private Guid[] T000Z7_A58ProductServiceId ;
      private Guid[] T000Z7_A29LocationId ;
      private Guid[] T000Z7_A11OrganisationId ;
      private string[] T000Z18_A59ProductServiceName ;
      private string[] T000Z18_A60ProductServiceDescription ;
      private string[] T000Z18_A40000ProductServiceImage_GXI ;
      private string[] T000Z18_A61ProductServiceImage ;
      private Guid[] T000Z19_A328Trn_ColId ;
      private Guid[] T000Z20_A264Trn_TileId ;
      private Guid[] T000Z20_A266SG_TileId ;
      private Guid[] T000Z21_A264Trn_TileId ;
      private Guid[] T000Z22_A264Trn_TileId ;
      private Guid[] T000Z22_A272AttributeId ;
      private string[] T000Z22_A273AttributeName ;
      private string[] T000Z22_A274AttrbuteValue ;
      private Guid[] T000Z23_A264Trn_TileId ;
      private Guid[] T000Z23_A272AttributeId ;
      private Guid[] T000Z6_A264Trn_TileId ;
      private Guid[] T000Z6_A272AttributeId ;
      private string[] T000Z6_A273AttributeName ;
      private string[] T000Z6_A274AttrbuteValue ;
      private Guid[] T000Z5_A264Trn_TileId ;
      private Guid[] T000Z5_A272AttributeId ;
      private string[] T000Z5_A273AttributeName ;
      private string[] T000Z5_A274AttrbuteValue ;
      private Guid[] T000Z27_A264Trn_TileId ;
      private Guid[] T000Z27_A272AttributeId ;
      private Guid[] T000Z28_A264Trn_TileId ;
      private string[] T000Z28_A267SG_TileName ;
      private short[] T000Z28_A275SG_TileWidth ;
      private string[] T000Z28_A276SG_TileColor ;
      private string[] T000Z28_A277SG_TileBGImageUrl ;
      private short[] T000Z28_A269ChildTileOrder ;
      private Guid[] T000Z28_A266SG_TileId ;
      private string[] T000Z4_A267SG_TileName ;
      private short[] T000Z4_A275SG_TileWidth ;
      private string[] T000Z4_A276SG_TileColor ;
      private string[] T000Z4_A277SG_TileBGImageUrl ;
      private string[] T000Z29_A267SG_TileName ;
      private short[] T000Z29_A275SG_TileWidth ;
      private string[] T000Z29_A276SG_TileColor ;
      private string[] T000Z29_A277SG_TileBGImageUrl ;
      private Guid[] T000Z30_A264Trn_TileId ;
      private Guid[] T000Z30_A266SG_TileId ;
      private Guid[] T000Z3_A264Trn_TileId ;
      private short[] T000Z3_A269ChildTileOrder ;
      private Guid[] T000Z3_A266SG_TileId ;
      private Guid[] T000Z2_A264Trn_TileId ;
      private short[] T000Z2_A269ChildTileOrder ;
      private Guid[] T000Z2_A266SG_TileId ;
      private string[] T000Z34_A267SG_TileName ;
      private short[] T000Z34_A275SG_TileWidth ;
      private string[] T000Z34_A276SG_TileColor ;
      private string[] T000Z34_A277SG_TileBGImageUrl ;
      private Guid[] T000Z35_A264Trn_TileId ;
      private Guid[] T000Z35_A266SG_TileId ;
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
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new UpdateCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new UpdateCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
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
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z3;
        prmT000Z3 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z4;
        prmT000Z4 = new Object[] {
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z5;
        prmT000Z5 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z6;
        prmT000Z6 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z7;
        prmT000Z7 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z8;
        prmT000Z8 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z9;
        prmT000Z9 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z10;
        prmT000Z10 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z11;
        prmT000Z11 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
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
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z15;
        prmT000Z15 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_TileName",GXType.VarChar,100,0) ,
        new ParDef("Trn_TileWidth",GXType.Int16,4,0) ,
        new ParDef("Trn_TileColor",GXType.Char,20,0) ,
        new ParDef("Trn_TileBGImageUrl",GXType.VarChar,1000,0) ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z16;
        prmT000Z16 = new Object[] {
        new ParDef("Trn_TileName",GXType.VarChar,100,0) ,
        new ParDef("Trn_TileWidth",GXType.Int16,4,0) ,
        new ParDef("Trn_TileColor",GXType.Char,20,0) ,
        new ParDef("Trn_TileBGImageUrl",GXType.VarChar,1000,0) ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z17;
        prmT000Z17 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z18;
        prmT000Z18 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z19;
        prmT000Z19 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z20;
        prmT000Z20 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z21;
        prmT000Z21 = new Object[] {
        };
        Object[] prmT000Z22;
        prmT000Z22 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z23;
        prmT000Z23 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z24;
        prmT000Z24 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeName",GXType.VarChar,100,0) ,
        new ParDef("AttrbuteValue",GXType.VarChar,100,0)
        };
        Object[] prmT000Z25;
        prmT000Z25 = new Object[] {
        new ParDef("AttributeName",GXType.VarChar,100,0) ,
        new ParDef("AttrbuteValue",GXType.VarChar,100,0) ,
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z26;
        prmT000Z26 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z27;
        prmT000Z27 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z28;
        prmT000Z28 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z29;
        prmT000Z29 = new Object[] {
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z30;
        prmT000Z30 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z31;
        prmT000Z31 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ChildTileOrder",GXType.Int16,4,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z32;
        prmT000Z32 = new Object[] {
        new ParDef("ChildTileOrder",GXType.Int16,4,0) ,
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z33;
        prmT000Z33 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z34;
        prmT000Z34 = new Object[] {
        new ParDef("SG_TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z35;
        prmT000Z35 = new Object[] {
        new ParDef("Trn_TileId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000Z2", "SELECT Trn_TileId, ChildTileOrder, SG_TileId FROM Trn_TileChildTile WHERE Trn_TileId = :Trn_TileId AND SG_TileId = :SG_TileId  FOR UPDATE OF Trn_TileChildTile NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z3", "SELECT Trn_TileId, ChildTileOrder, SG_TileId FROM Trn_TileChildTile WHERE Trn_TileId = :Trn_TileId AND SG_TileId = :SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z4", "SELECT Trn_TileName AS SG_TileName, Trn_TileWidth AS SG_TileWidth, Trn_TileColor AS SG_TileColor, Trn_TileBGImageUrl AS SG_TileBGImageUrl FROM Trn_Tile WHERE Trn_TileId = :SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z5", "SELECT Trn_TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId  FOR UPDATE OF Trn_TileAttribute NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z6", "SELECT Trn_TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z7", "SELECT Trn_TileId, Trn_TileName, Trn_TileWidth, Trn_TileColor, Trn_TileBGImageUrl, ProductServiceId, LocationId, OrganisationId FROM Trn_Tile WHERE Trn_TileId = :Trn_TileId  FOR UPDATE OF Trn_Tile NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z8", "SELECT Trn_TileId, Trn_TileName, Trn_TileWidth, Trn_TileColor, Trn_TileBGImageUrl, ProductServiceId, LocationId, OrganisationId FROM Trn_Tile WHERE Trn_TileId = :Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z9", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z10", "SELECT TM1.Trn_TileId, TM1.Trn_TileName, TM1.Trn_TileWidth, TM1.Trn_TileColor, TM1.Trn_TileBGImageUrl, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceImage_GXI, TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId, T2.ProductServiceImage FROM (Trn_Tile TM1 INNER JOIN Trn_ProductService T2 ON T2.ProductServiceId = TM1.ProductServiceId AND T2.LocationId = TM1.LocationId AND T2.OrganisationId = TM1.OrganisationId) WHERE TM1.Trn_TileId = :Trn_TileId ORDER BY TM1.Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z11", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z12", "SELECT Trn_TileId FROM Trn_Tile WHERE Trn_TileId = :Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z13", "SELECT Trn_TileId FROM Trn_Tile WHERE ( Trn_TileId > :Trn_TileId) ORDER BY Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z14", "SELECT Trn_TileId FROM Trn_Tile WHERE ( Trn_TileId < :Trn_TileId) ORDER BY Trn_TileId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z15", "SAVEPOINT gxupdate;INSERT INTO Trn_Tile(Trn_TileId, Trn_TileName, Trn_TileWidth, Trn_TileColor, Trn_TileBGImageUrl, ProductServiceId, LocationId, OrganisationId) VALUES(:Trn_TileId, :Trn_TileName, :Trn_TileWidth, :Trn_TileColor, :Trn_TileBGImageUrl, :ProductServiceId, :LocationId, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Z15)
           ,new CursorDef("T000Z16", "SAVEPOINT gxupdate;UPDATE Trn_Tile SET Trn_TileName=:Trn_TileName, Trn_TileWidth=:Trn_TileWidth, Trn_TileColor=:Trn_TileColor, Trn_TileBGImageUrl=:Trn_TileBGImageUrl, ProductServiceId=:ProductServiceId, LocationId=:LocationId, OrganisationId=:OrganisationId  WHERE Trn_TileId = :Trn_TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z16)
           ,new CursorDef("T000Z17", "SAVEPOINT gxupdate;DELETE FROM Trn_Tile  WHERE Trn_TileId = :Trn_TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z17)
           ,new CursorDef("T000Z18", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z19", "SELECT Trn_ColId FROM Trn_Col1 WHERE Trn_TileId = :Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z20", "SELECT Trn_TileId, SG_TileId FROM Trn_TileChildTile WHERE SG_TileId = :Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z21", "SELECT Trn_TileId FROM Trn_Tile ORDER BY Trn_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z21,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z22", "SELECT Trn_TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId and AttributeId = :AttributeId ORDER BY Trn_TileId, AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z22,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z23", "SELECT Trn_TileId, AttributeId FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z24", "SAVEPOINT gxupdate;INSERT INTO Trn_TileAttribute(Trn_TileId, AttributeId, AttributeName, AttrbuteValue) VALUES(:Trn_TileId, :AttributeId, :AttributeName, :AttrbuteValue);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Z24)
           ,new CursorDef("T000Z25", "SAVEPOINT gxupdate;UPDATE Trn_TileAttribute SET AttributeName=:AttributeName, AttrbuteValue=:AttrbuteValue  WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z25)
           ,new CursorDef("T000Z26", "SAVEPOINT gxupdate;DELETE FROM Trn_TileAttribute  WHERE Trn_TileId = :Trn_TileId AND AttributeId = :AttributeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z26)
           ,new CursorDef("T000Z27", "SELECT Trn_TileId, AttributeId FROM Trn_TileAttribute WHERE Trn_TileId = :Trn_TileId ORDER BY Trn_TileId, AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z27,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z28", "SELECT T1.Trn_TileId, T2.Trn_TileName AS SG_TileName, T2.Trn_TileWidth AS SG_TileWidth, T2.Trn_TileColor AS SG_TileColor, T2.Trn_TileBGImageUrl AS SG_TileBGImageUrl, T1.ChildTileOrder, T1.SG_TileId AS SG_TileId FROM (Trn_TileChildTile T1 INNER JOIN Trn_Tile T2 ON T2.Trn_TileId = T1.SG_TileId) WHERE T1.Trn_TileId = :Trn_TileId and T1.SG_TileId = :SG_TileId ORDER BY T1.Trn_TileId, T1.SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z28,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z29", "SELECT Trn_TileName AS SG_TileName, Trn_TileWidth AS SG_TileWidth, Trn_TileColor AS SG_TileColor, Trn_TileBGImageUrl AS SG_TileBGImageUrl FROM Trn_Tile WHERE Trn_TileId = :SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z30", "SELECT Trn_TileId, SG_TileId FROM Trn_TileChildTile WHERE Trn_TileId = :Trn_TileId AND SG_TileId = :SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z31", "SAVEPOINT gxupdate;INSERT INTO Trn_TileChildTile(Trn_TileId, ChildTileOrder, SG_TileId) VALUES(:Trn_TileId, :ChildTileOrder, :SG_TileId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Z31)
           ,new CursorDef("T000Z32", "SAVEPOINT gxupdate;UPDATE Trn_TileChildTile SET ChildTileOrder=:ChildTileOrder  WHERE Trn_TileId = :Trn_TileId AND SG_TileId = :SG_TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z32)
           ,new CursorDef("T000Z33", "SAVEPOINT gxupdate;DELETE FROM Trn_TileChildTile  WHERE Trn_TileId = :Trn_TileId AND SG_TileId = :SG_TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z33)
           ,new CursorDef("T000Z34", "SELECT Trn_TileName AS SG_TileName, Trn_TileWidth AS SG_TileWidth, Trn_TileColor AS SG_TileColor, Trn_TileBGImageUrl AS SG_TileBGImageUrl FROM Trn_Tile WHERE Trn_TileId = :SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z35", "SELECT Trn_TileId, SG_TileId FROM Trn_TileChildTile WHERE Trn_TileId = :Trn_TileId ORDER BY Trn_TileId, SG_TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z35,11, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((Guid[]) buf[2])[0] = rslt.getGuid(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((Guid[]) buf[5])[0] = rslt.getGuid(6);
              ((Guid[]) buf[6])[0] = rslt.getGuid(7);
              ((Guid[]) buf[7])[0] = rslt.getGuid(8);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((Guid[]) buf[5])[0] = rslt.getGuid(6);
              ((Guid[]) buf[6])[0] = rslt.getGuid(7);
              ((Guid[]) buf[7])[0] = rslt.getGuid(8);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
              ((Guid[]) buf[8])[0] = rslt.getGuid(9);
              ((Guid[]) buf[9])[0] = rslt.getGuid(10);
              ((Guid[]) buf[10])[0] = rslt.getGuid(11);
              ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(8));
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 17 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 18 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 19 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 20 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 21 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 25 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 26 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((Guid[]) buf[6])[0] = rslt.getGuid(7);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 28 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 33 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
     }
  }

}

}
