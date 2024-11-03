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
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A329SG_ToPageId = StringUtil.StrToGuid( GetPar( "SG_ToPageId"));
            n329SG_ToPageId = false;
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A329SG_ToPageId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A58ProductServiceId = StringUtil.StrToGuid( GetPar( "ProductServiceId"));
            n58ProductServiceId = false;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A58ProductServiceId, A29LocationId, A11OrganisationId) ;
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
                  AV58TileId = StringUtil.StrToGuid( GetPar( "TileId"));
                  AssignAttri("", false, "AV58TileId", AV58TileId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTILEID", GetSecureSignedToken( "", AV58TileId, context));
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
            GX_FocusControl = edtTileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
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
                           Guid aP1_TileId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV58TileId = aP1_TileId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTileTextAlignment = new GXCombobox();
         cmbTileIconAlignment = new GXCombobox();
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
         if ( cmbTileTextAlignment.ItemCount > 0 )
         {
            A405TileTextAlignment = cmbTileTextAlignment.getValidValue(A405TileTextAlignment);
            AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTileTextAlignment.CurrentValue = StringUtil.RTrim( A405TileTextAlignment);
            AssignProp("", false, cmbTileTextAlignment_Internalname, "Values", cmbTileTextAlignment.ToJavascriptSource(), true);
         }
         if ( cmbTileIconAlignment.ItemCount > 0 )
         {
            A406TileIconAlignment = cmbTileIconAlignment.getValidValue(A406TileIconAlignment);
            AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTileIconAlignment.CurrentValue = StringUtil.RTrim( A406TileIconAlignment);
            AssignProp("", false, cmbTileIconAlignment_Internalname, "Values", cmbTileIconAlignment.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileId_Internalname, A407TileId.ToString(), A407TileId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileName_Internalname, A400TileName, StringUtil.RTrim( context.localUtil.Format( A400TileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileIcon_Internalname, context.GetMessage( "Icon", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileIcon_Internalname, StringUtil.RTrim( A401TileIcon), StringUtil.RTrim( context.localUtil.Format( A401TileIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileIcon_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileBGColor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileBGColor_Internalname, context.GetMessage( "BGColor", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileBGColor_Internalname, StringUtil.RTrim( A402TileBGColor), StringUtil.RTrim( context.localUtil.Format( A402TileBGColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileBGColor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileBGColor_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileBGImageUrl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileBGImageUrl_Internalname, context.GetMessage( "BGImage Url", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileBGImageUrl_Internalname, A403TileBGImageUrl, StringUtil.RTrim( context.localUtil.Format( A403TileBGImageUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", A403TileBGImageUrl, "_blank", "", "", edtTileBGImageUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileBGImageUrl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileTextColor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileTextColor_Internalname, context.GetMessage( "Text Color", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileTextColor_Internalname, StringUtil.RTrim( A404TileTextColor), StringUtil.RTrim( context.localUtil.Format( A404TileTextColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileTextColor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileTextColor_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTileTextAlignment_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTileTextAlignment_Internalname, context.GetMessage( "Text Alignment", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTileTextAlignment, cmbTileTextAlignment_Internalname, StringUtil.RTrim( A405TileTextAlignment), 1, cmbTileTextAlignment_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTileTextAlignment.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_Trn_Tile.htm");
         cmbTileTextAlignment.CurrentValue = StringUtil.RTrim( A405TileTextAlignment);
         AssignProp("", false, cmbTileTextAlignment_Internalname, "Values", (string)(cmbTileTextAlignment.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTileIconAlignment_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTileIconAlignment_Internalname, context.GetMessage( "Icon Alignment", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTileIconAlignment, cmbTileIconAlignment_Internalname, StringUtil.RTrim( A406TileIconAlignment), 1, cmbTileIconAlignment_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTileIconAlignment.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 0, "HLP_Trn_Tile.htm");
         cmbTileIconAlignment.CurrentValue = StringUtil.RTrim( A406TileIconAlignment);
         AssignProp("", false, cmbTileIconAlignment_Internalname, "Values", (string)(cmbTileIconAlignment.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceId_Internalname, A58ProductServiceId.ToString(), A58ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedorganisationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockorganisationid_Internalname, context.GetMessage( "Organisations", ""), "", "", lblTextblockorganisationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_organisationid.SetProperty("Caption", Combo_organisationid_Caption);
         ucCombo_organisationid.SetProperty("Cls", Combo_organisationid_Cls);
         ucCombo_organisationid.SetProperty("DataListProc", Combo_organisationid_Datalistproc);
         ucCombo_organisationid.SetProperty("DataListProcParametersPrefix", Combo_organisationid_Datalistprocparametersprefix);
         ucCombo_organisationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_organisationid.SetProperty("DropDownOptionsData", AV51OrganisationId_Data);
         ucCombo_organisationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationid_Internalname, "COMBO_ORGANISATIONIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationId_Internalname, context.GetMessage( "Organisation Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, edtOrganisationId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationId_Internalname, context.GetMessage( "Location", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProductServiceDescription_Internalname, A60ProductServiceDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", 0, 1, edtProductServiceDescription_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "LongDescription", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A61ProductServiceImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServiceImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage));
         GxWebStd.gx_bitmap( context, imgProductServiceImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductServiceImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", "", "", 0, A61ProductServiceImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_Tile.htm");
         AssignProp("", false, imgProductServiceImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage)), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "IsBlob", StringUtil.BoolToStr( A61ProductServiceImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedsg_topageid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocksg_topageid_Internalname, context.GetMessage( "Trn_Page", ""), "", "", lblTextblocksg_topageid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_sg_topageid.SetProperty("Caption", Combo_sg_topageid_Caption);
         ucCombo_sg_topageid.SetProperty("Cls", Combo_sg_topageid_Cls);
         ucCombo_sg_topageid.SetProperty("DataListProc", Combo_sg_topageid_Datalistproc);
         ucCombo_sg_topageid.SetProperty("DataListProcParametersPrefix", Combo_sg_topageid_Datalistprocparametersprefix);
         ucCombo_sg_topageid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_sg_topageid.SetProperty("DropDownOptionsData", AV55SG_ToPageId_Data);
         ucCombo_sg_topageid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_sg_topageid_Internalname, "COMBO_SG_TOPAGEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSG_ToPageId_Internalname, context.GetMessage( "SG_To Page Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSG_ToPageId_Internalname, A329SG_ToPageId.ToString(), A329SG_ToPageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSG_ToPageId_Jsonclick, 0, "Attribute", "", "", "", "", edtSG_ToPageId_Visible, edtSG_ToPageId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_organisationid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboorganisationid_Internalname, AV52ComboOrganisationId.ToString(), AV52ComboOrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboorganisationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboorganisationid_Visible, edtavComboorganisationid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_sg_topageid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosg_topageid_Internalname, AV56ComboSG_ToPageId.ToString(), AV56ComboSG_ToPageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosg_topageid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosg_topageid_Visible, edtavCombosg_topageid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Tile.htm");
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
         E110Z2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vORGANISATIONID_DATA"), AV51OrganisationId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vSG_TOPAGEID_DATA"), AV55SG_ToPageId_Data);
               /* Read saved values. */
               Z407TileId = StringUtil.StrToGuid( cgiGet( "Z407TileId"));
               Z400TileName = cgiGet( "Z400TileName");
               Z402TileBGColor = cgiGet( "Z402TileBGColor");
               n402TileBGColor = (String.IsNullOrEmpty(StringUtil.RTrim( A402TileBGColor)) ? true : false);
               Z403TileBGImageUrl = cgiGet( "Z403TileBGImageUrl");
               n403TileBGImageUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A403TileBGImageUrl)) ? true : false);
               Z404TileTextColor = cgiGet( "Z404TileTextColor");
               Z405TileTextAlignment = cgiGet( "Z405TileTextAlignment");
               Z401TileIcon = cgiGet( "Z401TileIcon");
               n401TileIcon = (String.IsNullOrEmpty(StringUtil.RTrim( A401TileIcon)) ? true : false);
               Z406TileIconAlignment = cgiGet( "Z406TileIconAlignment");
               Z438TileIconColor = cgiGet( "Z438TileIconColor");
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               Z329SG_ToPageId = StringUtil.StrToGuid( cgiGet( "Z329SG_ToPageId"));
               n329SG_ToPageId = ((Guid.Empty==A329SG_ToPageId) ? true : false);
               Z58ProductServiceId = StringUtil.StrToGuid( cgiGet( "Z58ProductServiceId"));
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               A438TileIconColor = cgiGet( "Z438TileIconColor");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N11OrganisationId = StringUtil.StrToGuid( cgiGet( "N11OrganisationId"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               N329SG_ToPageId = StringUtil.StrToGuid( cgiGet( "N329SG_ToPageId"));
               n329SG_ToPageId = ((Guid.Empty==A329SG_ToPageId) ? true : false);
               AV58TileId = StringUtil.StrToGuid( cgiGet( "vTILEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV46Insert_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_ORGANISATIONID"));
               AV48Insert_SG_ToPageId = StringUtil.StrToGuid( cgiGet( "vINSERT_SG_TOPAGEID"));
               A438TileIconColor = cgiGet( "TILEICONCOLOR");
               A436TileAction = cgiGet( "TILEACTION");
               A330SG_ToPageName = cgiGet( "SG_TOPAGENAME");
               A59ProductServiceName = cgiGet( "PRODUCTSERVICENAME");
               A40000ProductServiceImage_GXI = cgiGet( "PRODUCTSERVICEIMAGE_GXI");
               AV59Pgmname = cgiGet( "vPGMNAME");
               Combo_organisationid_Objectcall = cgiGet( "COMBO_ORGANISATIONID_Objectcall");
               Combo_organisationid_Class = cgiGet( "COMBO_ORGANISATIONID_Class");
               Combo_organisationid_Icontype = cgiGet( "COMBO_ORGANISATIONID_Icontype");
               Combo_organisationid_Icon = cgiGet( "COMBO_ORGANISATIONID_Icon");
               Combo_organisationid_Caption = cgiGet( "COMBO_ORGANISATIONID_Caption");
               Combo_organisationid_Tooltip = cgiGet( "COMBO_ORGANISATIONID_Tooltip");
               Combo_organisationid_Cls = cgiGet( "COMBO_ORGANISATIONID_Cls");
               Combo_organisationid_Selectedvalue_set = cgiGet( "COMBO_ORGANISATIONID_Selectedvalue_set");
               Combo_organisationid_Selectedvalue_get = cgiGet( "COMBO_ORGANISATIONID_Selectedvalue_get");
               Combo_organisationid_Selectedtext_set = cgiGet( "COMBO_ORGANISATIONID_Selectedtext_set");
               Combo_organisationid_Selectedtext_get = cgiGet( "COMBO_ORGANISATIONID_Selectedtext_get");
               Combo_organisationid_Gamoauthtoken = cgiGet( "COMBO_ORGANISATIONID_Gamoauthtoken");
               Combo_organisationid_Ddointernalname = cgiGet( "COMBO_ORGANISATIONID_Ddointernalname");
               Combo_organisationid_Titlecontrolalign = cgiGet( "COMBO_ORGANISATIONID_Titlecontrolalign");
               Combo_organisationid_Dropdownoptionstype = cgiGet( "COMBO_ORGANISATIONID_Dropdownoptionstype");
               Combo_organisationid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Enabled"));
               Combo_organisationid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Visible"));
               Combo_organisationid_Titlecontrolidtoreplace = cgiGet( "COMBO_ORGANISATIONID_Titlecontrolidtoreplace");
               Combo_organisationid_Datalisttype = cgiGet( "COMBO_ORGANISATIONID_Datalisttype");
               Combo_organisationid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Allowmultipleselection"));
               Combo_organisationid_Datalistfixedvalues = cgiGet( "COMBO_ORGANISATIONID_Datalistfixedvalues");
               Combo_organisationid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Isgriditem"));
               Combo_organisationid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Hasdescription"));
               Combo_organisationid_Datalistproc = cgiGet( "COMBO_ORGANISATIONID_Datalistproc");
               Combo_organisationid_Datalistprocparametersprefix = cgiGet( "COMBO_ORGANISATIONID_Datalistprocparametersprefix");
               Combo_organisationid_Remoteservicesparameters = cgiGet( "COMBO_ORGANISATIONID_Remoteservicesparameters");
               Combo_organisationid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_organisationid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeonlyselectedoption"));
               Combo_organisationid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeselectalloption"));
               Combo_organisationid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Emptyitem"));
               Combo_organisationid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ORGANISATIONID_Includeaddnewoption"));
               Combo_organisationid_Htmltemplate = cgiGet( "COMBO_ORGANISATIONID_Htmltemplate");
               Combo_organisationid_Multiplevaluestype = cgiGet( "COMBO_ORGANISATIONID_Multiplevaluestype");
               Combo_organisationid_Loadingdata = cgiGet( "COMBO_ORGANISATIONID_Loadingdata");
               Combo_organisationid_Noresultsfound = cgiGet( "COMBO_ORGANISATIONID_Noresultsfound");
               Combo_organisationid_Emptyitemtext = cgiGet( "COMBO_ORGANISATIONID_Emptyitemtext");
               Combo_organisationid_Onlyselectedvalues = cgiGet( "COMBO_ORGANISATIONID_Onlyselectedvalues");
               Combo_organisationid_Selectalltext = cgiGet( "COMBO_ORGANISATIONID_Selectalltext");
               Combo_organisationid_Multiplevaluesseparator = cgiGet( "COMBO_ORGANISATIONID_Multiplevaluesseparator");
               Combo_organisationid_Addnewoptiontext = cgiGet( "COMBO_ORGANISATIONID_Addnewoptiontext");
               Combo_organisationid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_ORGANISATIONID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               Combo_sg_topageid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SG_TOPAGEID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               Combo_sg_topageid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_SG_TOPAGEID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtTileId_Internalname), "") == 0 )
               {
                  A407TileId = Guid.Empty;
                  AssignAttri("", false, "A407TileId", A407TileId.ToString());
               }
               else
               {
                  try
                  {
                     A407TileId = StringUtil.StrToGuid( cgiGet( edtTileId_Internalname));
                     AssignAttri("", false, "A407TileId", A407TileId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TILEID");
                     AnyError = 1;
                     GX_FocusControl = edtTileId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A400TileName = cgiGet( edtTileName_Internalname);
               AssignAttri("", false, "A400TileName", A400TileName);
               A401TileIcon = cgiGet( edtTileIcon_Internalname);
               n401TileIcon = false;
               AssignAttri("", false, "A401TileIcon", A401TileIcon);
               n401TileIcon = (String.IsNullOrEmpty(StringUtil.RTrim( A401TileIcon)) ? true : false);
               A402TileBGColor = cgiGet( edtTileBGColor_Internalname);
               n402TileBGColor = false;
               AssignAttri("", false, "A402TileBGColor", A402TileBGColor);
               n402TileBGColor = (String.IsNullOrEmpty(StringUtil.RTrim( A402TileBGColor)) ? true : false);
               A403TileBGImageUrl = cgiGet( edtTileBGImageUrl_Internalname);
               n403TileBGImageUrl = false;
               AssignAttri("", false, "A403TileBGImageUrl", A403TileBGImageUrl);
               n403TileBGImageUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A403TileBGImageUrl)) ? true : false);
               A404TileTextColor = cgiGet( edtTileTextColor_Internalname);
               AssignAttri("", false, "A404TileTextColor", A404TileTextColor);
               cmbTileTextAlignment.CurrentValue = cgiGet( cmbTileTextAlignment_Internalname);
               A405TileTextAlignment = cgiGet( cmbTileTextAlignment_Internalname);
               AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
               cmbTileIconAlignment.CurrentValue = cgiGet( cmbTileIconAlignment_Internalname);
               A406TileIconAlignment = cgiGet( cmbTileIconAlignment_Internalname);
               AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
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
               if ( StringUtil.StrCmp(cgiGet( edtOrganisationId_Internalname), "") == 0 )
               {
                  A11OrganisationId = Guid.Empty;
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
               else
               {
                  try
                  {
                     A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                     n11OrganisationId = false;
                     AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ORGANISATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtOrganisationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
               n29LocationId = false;
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               A60ProductServiceDescription = cgiGet( edtProductServiceDescription_Internalname);
               AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
               A61ProductServiceImage = cgiGet( imgProductServiceImage_Internalname);
               AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
               if ( StringUtil.StrCmp(cgiGet( edtSG_ToPageId_Internalname), "") == 0 )
               {
                  A329SG_ToPageId = Guid.Empty;
                  n329SG_ToPageId = false;
                  AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
               }
               else
               {
                  try
                  {
                     A329SG_ToPageId = StringUtil.StrToGuid( cgiGet( edtSG_ToPageId_Internalname));
                     n329SG_ToPageId = false;
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
               n329SG_ToPageId = ((Guid.Empty==A329SG_ToPageId) ? true : false);
               AV52ComboOrganisationId = StringUtil.StrToGuid( cgiGet( edtavComboorganisationid_Internalname));
               AssignAttri("", false, "AV52ComboOrganisationId", AV52ComboOrganisationId.ToString());
               AV56ComboSG_ToPageId = StringUtil.StrToGuid( cgiGet( edtavCombosg_topageid_Internalname));
               AssignAttri("", false, "AV56ComboSG_ToPageId", AV56ComboSG_ToPageId.ToString());
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProductServiceImage_Internalname, ref  A61ProductServiceImage, ref  A40000ProductServiceImage_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Tile");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("TileIconColor", StringUtil.RTrim( context.localUtil.Format( A438TileIconColor, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A407TileId != Z407TileId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
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
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A407TileId = StringUtil.StrToGuid( GetPar( "TileId"));
                  AssignAttri("", false, "A407TileId", A407TileId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV58TileId) )
                  {
                     A407TileId = AV58TileId;
                     AssignAttri("", false, "A407TileId", A407TileId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A407TileId) && ( Gx_BScreen == 0 ) )
                     {
                        A407TileId = Guid.NewGuid( );
                        AssignAttri("", false, "A407TileId", A407TileId.ToString());
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
                     sMode81 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV58TileId) )
                     {
                        A407TileId = AV58TileId;
                        AssignAttri("", false, "A407TileId", A407TileId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A407TileId) && ( Gx_BScreen == 0 ) )
                        {
                           A407TileId = Guid.NewGuid( );
                           AssignAttri("", false, "A407TileId", A407TileId.ToString());
                        }
                     }
                     Gx_mode = sMode81;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound81 == 1 )
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
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TILEID");
                        AnyError = 1;
                        GX_FocusControl = edtTileId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_ORGANISATIONID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_organisationid.Onoptionclicked */
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
               InitAll0Z81( ) ;
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
            DisableAttributes0Z81( ) ;
         }
         AssignProp("", false, edtavComboorganisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Enabled), 5, 0), true);
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
         BeforeValidate0Z81( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Z81( ) ;
            }
            else
            {
               CheckExtendedTable0Z81( ) ;
               CloseExtendedTableCursors0Z81( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
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
         AV56ComboSG_ToPageId = Guid.Empty;
         AssignAttri("", false, "AV56ComboSG_ToPageId", AV56ComboSG_ToPageId.ToString());
         edtavCombosg_topageid_Visible = 0;
         AssignProp("", false, edtavCombosg_topageid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosg_topageid_Visible), 5, 0), true);
         Combo_organisationid_Gamoauthtoken = AV18GAMSession.gxTpr_Token;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "GAMOAuthToken", Combo_organisationid_Gamoauthtoken);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         AV52ComboOrganisationId = Guid.Empty;
         AssignAttri("", false, "AV52ComboOrganisationId", AV52ComboOrganisationId.ToString());
         edtavComboorganisationid_Visible = 0;
         AssignProp("", false, edtavComboorganisationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONID' */
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
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV59Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV60GXV1 = 1;
            AssignAttri("", false, "AV60GXV1", StringUtil.LTrimStr( (decimal)(AV60GXV1), 8, 0));
            while ( AV60GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV21TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV60GXV1));
               if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV46Insert_OrganisationId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV46Insert_OrganisationId", AV46Insert_OrganisationId.ToString());
                  if ( ! (Guid.Empty==AV46Insert_OrganisationId) )
                  {
                     AV52ComboOrganisationId = AV46Insert_OrganisationId;
                     AssignAttri("", false, "AV52ComboOrganisationId", AV52ComboOrganisationId.ToString());
                     Combo_organisationid_Selectedvalue_set = StringUtil.Trim( AV52ComboOrganisationId.ToString());
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedValue_set", Combo_organisationid_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new trn_tileloaddvcombo(context ).execute(  "OrganisationId",  "GET",  false,  AV58TileId,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_organisationid_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedText_set", Combo_organisationid_Selectedtext_set);
                     Combo_organisationid_Enabled = false;
                     ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "SG_ToPageId") == 0 )
               {
                  AV48Insert_SG_ToPageId = StringUtil.StrToGuid( AV21TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV48Insert_SG_ToPageId", AV48Insert_SG_ToPageId.ToString());
                  if ( ! (Guid.Empty==AV48Insert_SG_ToPageId) )
                  {
                     AV56ComboSG_ToPageId = AV48Insert_SG_ToPageId;
                     AssignAttri("", false, "AV56ComboSG_ToPageId", AV56ComboSG_ToPageId.ToString());
                     Combo_sg_topageid_Selectedvalue_set = StringUtil.Trim( AV56ComboSG_ToPageId.ToString());
                     ucCombo_sg_topageid.SendProperty(context, "", false, Combo_sg_topageid_Internalname, "SelectedValue_set", Combo_sg_topageid_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new trn_tileloaddvcombo(context ).execute(  "SG_ToPageId",  "GET",  false,  AV58TileId,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
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
               AV60GXV1 = (int)(AV60GXV1+1);
               AssignAttri("", false, "AV60GXV1", StringUtil.LTrimStr( (decimal)(AV60GXV1), 8, 0));
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
         AV56ComboSG_ToPageId = StringUtil.StrToGuid( Combo_sg_topageid_Selectedvalue_get);
         AssignAttri("", false, "AV56ComboSG_ToPageId", AV56ComboSG_ToPageId.ToString());
         /*  Sending Event outputs  */
      }

      protected void E120Z2( )
      {
         /* Combo_organisationid_Onoptionclicked Routine */
         returnInSub = false;
         AV52ComboOrganisationId = StringUtil.StrToGuid( Combo_organisationid_Selectedvalue_get);
         AssignAttri("", false, "AV52ComboOrganisationId", AV52ComboOrganisationId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSG_TOPAGEID' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new trn_tileloaddvcombo(context ).execute(  "SG_ToPageId",  Gx_mode,  false,  AV58TileId,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_sg_topageid_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_sg_topageid.SendProperty(context, "", false, Combo_sg_topageid_Internalname, "SelectedValue_set", Combo_sg_topageid_Selectedvalue_set);
         Combo_sg_topageid_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_sg_topageid.SendProperty(context, "", false, Combo_sg_topageid_Internalname, "SelectedText_set", Combo_sg_topageid_Selectedtext_set);
         AV56ComboSG_ToPageId = StringUtil.StrToGuid( AV15ComboSelectedValue);
         AssignAttri("", false, "AV56ComboSG_ToPageId", AV56ComboSG_ToPageId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_sg_topageid_Enabled = false;
            ucCombo_sg_topageid.SendProperty(context, "", false, Combo_sg_topageid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_sg_topageid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOORGANISATIONID' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new trn_tileloaddvcombo(context ).execute(  "OrganisationId",  Gx_mode,  false,  AV58TileId,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_organisationid_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedValue_set", Combo_organisationid_Selectedvalue_set);
         Combo_organisationid_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "SelectedText_set", Combo_organisationid_Selectedtext_set);
         AV52ComboOrganisationId = StringUtil.StrToGuid( AV15ComboSelectedValue);
         AssignAttri("", false, "AV52ComboOrganisationId", AV52ComboOrganisationId.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_organisationid_Enabled = false;
            ucCombo_organisationid.SendProperty(context, "", false, Combo_organisationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
         }
      }

      protected void ZM0Z81( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z400TileName = T000Z3_A400TileName[0];
               Z402TileBGColor = T000Z3_A402TileBGColor[0];
               Z403TileBGImageUrl = T000Z3_A403TileBGImageUrl[0];
               Z404TileTextColor = T000Z3_A404TileTextColor[0];
               Z405TileTextAlignment = T000Z3_A405TileTextAlignment[0];
               Z401TileIcon = T000Z3_A401TileIcon[0];
               Z406TileIconAlignment = T000Z3_A406TileIconAlignment[0];
               Z438TileIconColor = T000Z3_A438TileIconColor[0];
               Z11OrganisationId = T000Z3_A11OrganisationId[0];
               Z329SG_ToPageId = T000Z3_A329SG_ToPageId[0];
               Z58ProductServiceId = T000Z3_A58ProductServiceId[0];
            }
            else
            {
               Z400TileName = A400TileName;
               Z402TileBGColor = A402TileBGColor;
               Z403TileBGImageUrl = A403TileBGImageUrl;
               Z404TileTextColor = A404TileTextColor;
               Z405TileTextAlignment = A405TileTextAlignment;
               Z401TileIcon = A401TileIcon;
               Z406TileIconAlignment = A406TileIconAlignment;
               Z438TileIconColor = A438TileIconColor;
               Z11OrganisationId = A11OrganisationId;
               Z329SG_ToPageId = A329SG_ToPageId;
               Z58ProductServiceId = A58ProductServiceId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z407TileId = A407TileId;
            Z400TileName = A400TileName;
            Z402TileBGColor = A402TileBGColor;
            Z403TileBGImageUrl = A403TileBGImageUrl;
            Z404TileTextColor = A404TileTextColor;
            Z405TileTextAlignment = A405TileTextAlignment;
            Z401TileIcon = A401TileIcon;
            Z406TileIconAlignment = A406TileIconAlignment;
            Z438TileIconColor = A438TileIconColor;
            Z436TileAction = A436TileAction;
            Z11OrganisationId = A11OrganisationId;
            Z329SG_ToPageId = A329SG_ToPageId;
            Z58ProductServiceId = A58ProductServiceId;
            Z330SG_ToPageName = A330SG_ToPageName;
            Z29LocationId = A29LocationId;
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
         AV59Pgmname = "Trn_Tile";
         AssignAttri("", false, "AV59Pgmname", AV59Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV58TileId) )
         {
            edtTileId_Enabled = 0;
            AssignProp("", false, edtTileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileId_Enabled), 5, 0), true);
         }
         else
         {
            edtTileId_Enabled = 1;
            AssignProp("", false, edtTileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV58TileId) )
         {
            edtTileId_Enabled = 0;
            AssignProp("", false, edtTileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV46Insert_OrganisationId) )
         {
            edtOrganisationId_Enabled = 0;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         else
         {
            edtOrganisationId_Enabled = 1;
            AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV48Insert_SG_ToPageId) )
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV46Insert_OrganisationId) )
         {
            A11OrganisationId = AV46Insert_OrganisationId;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV52ComboOrganisationId) )
            {
               A11OrganisationId = Guid.Empty;
               n11OrganisationId = false;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               n11OrganisationId = true;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV52ComboOrganisationId) )
               {
                  A11OrganisationId = AV52ComboOrganisationId;
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV48Insert_SG_ToPageId) )
         {
            A329SG_ToPageId = AV48Insert_SG_ToPageId;
            n329SG_ToPageId = false;
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV56ComboSG_ToPageId) )
            {
               A329SG_ToPageId = Guid.Empty;
               n329SG_ToPageId = false;
               AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
               n329SG_ToPageId = true;
               AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV56ComboSG_ToPageId) )
               {
                  A329SG_ToPageId = AV56ComboSG_ToPageId;
                  n329SG_ToPageId = false;
                  AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
               }
            }
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
         if ( ! (Guid.Empty==AV58TileId) )
         {
            A407TileId = AV58TileId;
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A407TileId) && ( Gx_BScreen == 0 ) )
            {
               A407TileId = Guid.NewGuid( );
               AssignAttri("", false, "A407TileId", A407TileId.ToString());
            }
         }
         if ( IsIns( )  && (Guid.Empty==A58ProductServiceId) && ( Gx_BScreen == 0 ) )
         {
            A58ProductServiceId = Guid.NewGuid( );
            n58ProductServiceId = false;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000Z5 */
            pr_default.execute(3, new Object[] {n329SG_ToPageId, A329SG_ToPageId});
            A330SG_ToPageName = T000Z5_A330SG_ToPageName[0];
            A29LocationId = T000Z5_A29LocationId[0];
            n29LocationId = T000Z5_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            pr_default.close(3);
            /* Using cursor T000Z6 */
            pr_default.execute(4, new Object[] {n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
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
         }
      }

      protected void Load0Z81( )
      {
         /* Using cursor T000Z7 */
         pr_default.execute(5, new Object[] {A407TileId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound81 = 1;
            A400TileName = T000Z7_A400TileName[0];
            AssignAttri("", false, "A400TileName", A400TileName);
            A402TileBGColor = T000Z7_A402TileBGColor[0];
            n402TileBGColor = T000Z7_n402TileBGColor[0];
            AssignAttri("", false, "A402TileBGColor", A402TileBGColor);
            A403TileBGImageUrl = T000Z7_A403TileBGImageUrl[0];
            n403TileBGImageUrl = T000Z7_n403TileBGImageUrl[0];
            AssignAttri("", false, "A403TileBGImageUrl", A403TileBGImageUrl);
            A404TileTextColor = T000Z7_A404TileTextColor[0];
            AssignAttri("", false, "A404TileTextColor", A404TileTextColor);
            A405TileTextAlignment = T000Z7_A405TileTextAlignment[0];
            AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
            A401TileIcon = T000Z7_A401TileIcon[0];
            n401TileIcon = T000Z7_n401TileIcon[0];
            AssignAttri("", false, "A401TileIcon", A401TileIcon);
            A406TileIconAlignment = T000Z7_A406TileIconAlignment[0];
            AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
            A438TileIconColor = T000Z7_A438TileIconColor[0];
            A59ProductServiceName = T000Z7_A59ProductServiceName[0];
            A60ProductServiceDescription = T000Z7_A60ProductServiceDescription[0];
            AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
            A40000ProductServiceImage_GXI = T000Z7_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A436TileAction = T000Z7_A436TileAction[0];
            A330SG_ToPageName = T000Z7_A330SG_ToPageName[0];
            A11OrganisationId = T000Z7_A11OrganisationId[0];
            n11OrganisationId = T000Z7_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A329SG_ToPageId = T000Z7_A329SG_ToPageId[0];
            n329SG_ToPageId = T000Z7_n329SG_ToPageId[0];
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
            A29LocationId = T000Z7_A29LocationId[0];
            n29LocationId = T000Z7_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A58ProductServiceId = T000Z7_A58ProductServiceId[0];
            n58ProductServiceId = T000Z7_n58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A61ProductServiceImage = T000Z7_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            ZM0Z81( -20) ;
         }
         pr_default.close(5);
         OnLoadActions0Z81( ) ;
      }

      protected void OnLoadActions0Z81( )
      {
      }

      protected void CheckExtendedTable0Z81( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A403TileBGImageUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A403TileBGImageUrl)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Tile BGImage Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TILEBGIMAGEURL");
            AnyError = 1;
            GX_FocusControl = edtTileBGImageUrl_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A405TileTextAlignment, "center") == 0 ) || ( StringUtil.StrCmp(A405TileTextAlignment, "left") == 0 ) || ( StringUtil.StrCmp(A405TileTextAlignment, "right") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Tile Text Alignment", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TILETEXTALIGNMENT");
            AnyError = 1;
            GX_FocusControl = cmbTileTextAlignment_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A406TileIconAlignment, "center") == 0 ) || ( StringUtil.StrCmp(A406TileIconAlignment, "left") == 0 ) || ( StringUtil.StrCmp(A406TileIconAlignment, "right") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Tile Icon Alignment", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "TILEICONALIGNMENT");
            AnyError = 1;
            GX_FocusControl = cmbTileIconAlignment_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000Z4 */
         pr_default.execute(2, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtOrganisationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T000Z5 */
         pr_default.execute(3, new Object[] {n329SG_ToPageId, A329SG_ToPageId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A329SG_ToPageId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_To Page", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_TOPAGEID");
               AnyError = 1;
               GX_FocusControl = edtSG_ToPageId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A330SG_ToPageName = T000Z5_A330SG_ToPageName[0];
         A29LocationId = T000Z5_A29LocationId[0];
         n29LocationId = T000Z5_n29LocationId[0];
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         pr_default.close(3);
         /* Using cursor T000Z6 */
         pr_default.execute(4, new Object[] {n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
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
      }

      protected void CloseExtendedTableCursors0Z81( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_21( Guid A11OrganisationId )
      {
         /* Using cursor T000Z8 */
         pr_default.execute(6, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtOrganisationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_22( Guid A329SG_ToPageId )
      {
         /* Using cursor T000Z9 */
         pr_default.execute(7, new Object[] {n329SG_ToPageId, A329SG_ToPageId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A329SG_ToPageId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_To Page", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_TOPAGEID");
               AnyError = 1;
               GX_FocusControl = edtSG_ToPageId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A330SG_ToPageName = T000Z9_A330SG_ToPageName[0];
         A29LocationId = T000Z9_A29LocationId[0];
         n29LocationId = T000Z9_n29LocationId[0];
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A330SG_ToPageName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A29LocationId.ToString())+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_23( Guid A58ProductServiceId ,
                                Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T000Z10 */
         pr_default.execute(8, new Object[] {n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtProductServiceId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A59ProductServiceName = T000Z10_A59ProductServiceName[0];
         A60ProductServiceDescription = T000Z10_A60ProductServiceDescription[0];
         AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
         A40000ProductServiceImage_GXI = T000Z10_A40000ProductServiceImage_GXI[0];
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         A61ProductServiceImage = T000Z10_A61ProductServiceImage[0];
         AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A59ProductServiceName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A60ProductServiceDescription)+"\""+","+"\""+GXUtil.EncodeJSConstant( A61ProductServiceImage)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000ProductServiceImage_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0Z81( )
      {
         /* Using cursor T000Z11 */
         pr_default.execute(9, new Object[] {A407TileId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound81 = 1;
         }
         else
         {
            RcdFound81 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Z3 */
         pr_default.execute(1, new Object[] {A407TileId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z81( 20) ;
            RcdFound81 = 1;
            A407TileId = T000Z3_A407TileId[0];
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
            A400TileName = T000Z3_A400TileName[0];
            AssignAttri("", false, "A400TileName", A400TileName);
            A402TileBGColor = T000Z3_A402TileBGColor[0];
            n402TileBGColor = T000Z3_n402TileBGColor[0];
            AssignAttri("", false, "A402TileBGColor", A402TileBGColor);
            A403TileBGImageUrl = T000Z3_A403TileBGImageUrl[0];
            n403TileBGImageUrl = T000Z3_n403TileBGImageUrl[0];
            AssignAttri("", false, "A403TileBGImageUrl", A403TileBGImageUrl);
            A404TileTextColor = T000Z3_A404TileTextColor[0];
            AssignAttri("", false, "A404TileTextColor", A404TileTextColor);
            A405TileTextAlignment = T000Z3_A405TileTextAlignment[0];
            AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
            A401TileIcon = T000Z3_A401TileIcon[0];
            n401TileIcon = T000Z3_n401TileIcon[0];
            AssignAttri("", false, "A401TileIcon", A401TileIcon);
            A406TileIconAlignment = T000Z3_A406TileIconAlignment[0];
            AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
            A438TileIconColor = T000Z3_A438TileIconColor[0];
            A436TileAction = T000Z3_A436TileAction[0];
            A11OrganisationId = T000Z3_A11OrganisationId[0];
            n11OrganisationId = T000Z3_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            A329SG_ToPageId = T000Z3_A329SG_ToPageId[0];
            n329SG_ToPageId = T000Z3_n329SG_ToPageId[0];
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
            A58ProductServiceId = T000Z3_A58ProductServiceId[0];
            n58ProductServiceId = T000Z3_n58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            Z407TileId = A407TileId;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Z81( ) ;
            if ( AnyError == 1 )
            {
               RcdFound81 = 0;
               InitializeNonKey0Z81( ) ;
            }
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound81 = 0;
            InitializeNonKey0Z81( ) ;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Z81( ) ;
         if ( RcdFound81 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound81 = 0;
         /* Using cursor T000Z12 */
         pr_default.execute(10, new Object[] {A407TileId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000Z12_A407TileId[0], A407TileId, 0) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000Z12_A407TileId[0], A407TileId, 0) > 0 ) ) )
            {
               A407TileId = T000Z12_A407TileId[0];
               AssignAttri("", false, "A407TileId", A407TileId.ToString());
               RcdFound81 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound81 = 0;
         /* Using cursor T000Z13 */
         pr_default.execute(11, new Object[] {A407TileId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000Z13_A407TileId[0], A407TileId, 0) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T000Z13_A407TileId[0], A407TileId, 0) < 0 ) ) )
            {
               A407TileId = T000Z13_A407TileId[0];
               AssignAttri("", false, "A407TileId", A407TileId.ToString());
               RcdFound81 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Z81( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Z81( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound81 == 1 )
            {
               if ( A407TileId != Z407TileId )
               {
                  A407TileId = Z407TileId;
                  AssignAttri("", false, "A407TileId", A407TileId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TILEID");
                  AnyError = 1;
                  GX_FocusControl = edtTileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0Z81( ) ;
                  GX_FocusControl = edtTileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A407TileId != Z407TileId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTileId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Z81( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TILEID");
                     AnyError = 1;
                     GX_FocusControl = edtTileId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTileId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Z81( ) ;
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
         if ( A407TileId != Z407TileId )
         {
            A407TileId = Z407TileId;
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TILEID");
            AnyError = 1;
            GX_FocusControl = edtTileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTileId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0Z81( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z2 */
            pr_default.execute(0, new Object[] {A407TileId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Tile"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z400TileName, T000Z2_A400TileName[0]) != 0 ) || ( StringUtil.StrCmp(Z402TileBGColor, T000Z2_A402TileBGColor[0]) != 0 ) || ( StringUtil.StrCmp(Z403TileBGImageUrl, T000Z2_A403TileBGImageUrl[0]) != 0 ) || ( StringUtil.StrCmp(Z404TileTextColor, T000Z2_A404TileTextColor[0]) != 0 ) || ( StringUtil.StrCmp(Z405TileTextAlignment, T000Z2_A405TileTextAlignment[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z401TileIcon, T000Z2_A401TileIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z406TileIconAlignment, T000Z2_A406TileIconAlignment[0]) != 0 ) || ( StringUtil.StrCmp(Z438TileIconColor, T000Z2_A438TileIconColor[0]) != 0 ) || ( Z11OrganisationId != T000Z2_A11OrganisationId[0] ) || ( Z329SG_ToPageId != T000Z2_A329SG_ToPageId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z58ProductServiceId != T000Z2_A58ProductServiceId[0] ) )
            {
               if ( StringUtil.StrCmp(Z400TileName, T000Z2_A400TileName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileName");
                  GXUtil.WriteLogRaw("Old: ",Z400TileName);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A400TileName[0]);
               }
               if ( StringUtil.StrCmp(Z402TileBGColor, T000Z2_A402TileBGColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileBGColor");
                  GXUtil.WriteLogRaw("Old: ",Z402TileBGColor);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A402TileBGColor[0]);
               }
               if ( StringUtil.StrCmp(Z403TileBGImageUrl, T000Z2_A403TileBGImageUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileBGImageUrl");
                  GXUtil.WriteLogRaw("Old: ",Z403TileBGImageUrl);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A403TileBGImageUrl[0]);
               }
               if ( StringUtil.StrCmp(Z404TileTextColor, T000Z2_A404TileTextColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileTextColor");
                  GXUtil.WriteLogRaw("Old: ",Z404TileTextColor);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A404TileTextColor[0]);
               }
               if ( StringUtil.StrCmp(Z405TileTextAlignment, T000Z2_A405TileTextAlignment[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileTextAlignment");
                  GXUtil.WriteLogRaw("Old: ",Z405TileTextAlignment);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A405TileTextAlignment[0]);
               }
               if ( StringUtil.StrCmp(Z401TileIcon, T000Z2_A401TileIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileIcon");
                  GXUtil.WriteLogRaw("Old: ",Z401TileIcon);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A401TileIcon[0]);
               }
               if ( StringUtil.StrCmp(Z406TileIconAlignment, T000Z2_A406TileIconAlignment[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileIconAlignment");
                  GXUtil.WriteLogRaw("Old: ",Z406TileIconAlignment);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A406TileIconAlignment[0]);
               }
               if ( StringUtil.StrCmp(Z438TileIconColor, T000Z2_A438TileIconColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileIconColor");
                  GXUtil.WriteLogRaw("Old: ",Z438TileIconColor);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A438TileIconColor[0]);
               }
               if ( Z11OrganisationId != T000Z2_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A11OrganisationId[0]);
               }
               if ( Z329SG_ToPageId != T000Z2_A329SG_ToPageId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"SG_ToPageId");
                  GXUtil.WriteLogRaw("Old: ",Z329SG_ToPageId);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A329SG_ToPageId[0]);
               }
               if ( Z58ProductServiceId != T000Z2_A58ProductServiceId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"ProductServiceId");
                  GXUtil.WriteLogRaw("Old: ",Z58ProductServiceId);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A58ProductServiceId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Tile"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z81( )
      {
         if ( ! IsAuthorized("trn_page_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z81( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z81( 0) ;
            CheckOptimisticConcurrency0Z81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z14 */
                     pr_default.execute(12, new Object[] {A407TileId, A400TileName, n402TileBGColor, A402TileBGColor, n403TileBGImageUrl, A403TileBGImageUrl, A404TileTextColor, A405TileTextAlignment, n401TileIcon, A401TileIcon, A406TileIconAlignment, A438TileIconColor, A436TileAction, n11OrganisationId, A11OrganisationId, n329SG_ToPageId, A329SG_ToPageId, n58ProductServiceId, A58ProductServiceId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
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
               Load0Z81( ) ;
            }
            EndLevel0Z81( ) ;
         }
         CloseExtendedTableCursors0Z81( ) ;
      }

      protected void Update0Z81( )
      {
         if ( ! IsAuthorized("trn_page_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z81( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z15 */
                     pr_default.execute(13, new Object[] {A400TileName, n402TileBGColor, A402TileBGColor, n403TileBGImageUrl, A403TileBGImageUrl, A404TileTextColor, A405TileTextAlignment, n401TileIcon, A401TileIcon, A406TileIconAlignment, A438TileIconColor, A436TileAction, n11OrganisationId, A11OrganisationId, n329SG_ToPageId, A329SG_ToPageId, n58ProductServiceId, A58ProductServiceId, A407TileId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Tile"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z81( ) ;
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
            EndLevel0Z81( ) ;
         }
         CloseExtendedTableCursors0Z81( ) ;
      }

      protected void DeferredUpdate0Z81( )
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
         BeforeValidate0Z81( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z81( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z81( ) ;
            AfterConfirm0Z81( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z81( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Z16 */
                  pr_default.execute(14, new Object[] {A407TileId});
                  pr_default.close(14);
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
         sMode81 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z81( ) ;
         Gx_mode = sMode81;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z81( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000Z17 */
            pr_default.execute(15, new Object[] {n329SG_ToPageId, A329SG_ToPageId});
            A330SG_ToPageName = T000Z17_A330SG_ToPageName[0];
            A29LocationId = T000Z17_A29LocationId[0];
            n29LocationId = T000Z17_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            pr_default.close(15);
            /* Using cursor T000Z18 */
            pr_default.execute(16, new Object[] {n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
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
            pr_default.execute(17, new Object[] {A407TileId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Col", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel0Z81( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Z81( ) ;
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

      public void ScanStart0Z81( )
      {
         /* Scan By routine */
         /* Using cursor T000Z20 */
         pr_default.execute(18);
         RcdFound81 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound81 = 1;
            A407TileId = T000Z20_A407TileId[0];
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z81( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound81 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound81 = 1;
            A407TileId = T000Z20_A407TileId[0];
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
         }
      }

      protected void ScanEnd0Z81( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0Z81( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z81( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z81( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z81( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z81( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z81( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z81( )
      {
         edtTileId_Enabled = 0;
         AssignProp("", false, edtTileId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileId_Enabled), 5, 0), true);
         edtTileName_Enabled = 0;
         AssignProp("", false, edtTileName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileName_Enabled), 5, 0), true);
         edtTileIcon_Enabled = 0;
         AssignProp("", false, edtTileIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileIcon_Enabled), 5, 0), true);
         edtTileBGColor_Enabled = 0;
         AssignProp("", false, edtTileBGColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileBGColor_Enabled), 5, 0), true);
         edtTileBGImageUrl_Enabled = 0;
         AssignProp("", false, edtTileBGImageUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileBGImageUrl_Enabled), 5, 0), true);
         edtTileTextColor_Enabled = 0;
         AssignProp("", false, edtTileTextColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTileTextColor_Enabled), 5, 0), true);
         cmbTileTextAlignment.Enabled = 0;
         AssignProp("", false, cmbTileTextAlignment_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTileTextAlignment.Enabled), 5, 0), true);
         cmbTileIconAlignment.Enabled = 0;
         AssignProp("", false, cmbTileIconAlignment_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTileIconAlignment.Enabled), 5, 0), true);
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtProductServiceDescription_Enabled = 0;
         AssignProp("", false, edtProductServiceDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceDescription_Enabled), 5, 0), true);
         imgProductServiceImage_Enabled = 0;
         AssignProp("", false, imgProductServiceImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductServiceImage_Enabled), 5, 0), true);
         edtSG_ToPageId_Enabled = 0;
         AssignProp("", false, edtSG_ToPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_ToPageId_Enabled), 5, 0), true);
         edtavComboorganisationid_Enabled = 0;
         AssignProp("", false, edtavComboorganisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboorganisationid_Enabled), 5, 0), true);
         edtavCombosg_topageid_Enabled = 0;
         AssignProp("", false, edtavCombosg_topageid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosg_topageid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Z81( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Z0( )
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
         GXEncryptionTmp = "trn_tile.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV58TileId.ToString());
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
         forbiddenHiddens.Add("TileIconColor", StringUtil.RTrim( context.localUtil.Format( A438TileIconColor, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_tile:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z407TileId", Z407TileId.ToString());
         GxWebStd.gx_hidden_field( context, "Z400TileName", Z400TileName);
         GxWebStd.gx_hidden_field( context, "Z402TileBGColor", StringUtil.RTrim( Z402TileBGColor));
         GxWebStd.gx_hidden_field( context, "Z403TileBGImageUrl", Z403TileBGImageUrl);
         GxWebStd.gx_hidden_field( context, "Z404TileTextColor", StringUtil.RTrim( Z404TileTextColor));
         GxWebStd.gx_hidden_field( context, "Z405TileTextAlignment", StringUtil.RTrim( Z405TileTextAlignment));
         GxWebStd.gx_hidden_field( context, "Z401TileIcon", StringUtil.RTrim( Z401TileIcon));
         GxWebStd.gx_hidden_field( context, "Z406TileIconAlignment", StringUtil.RTrim( Z406TileIconAlignment));
         GxWebStd.gx_hidden_field( context, "Z438TileIconColor", StringUtil.RTrim( Z438TileIconColor));
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z329SG_ToPageId", Z329SG_ToPageId.ToString());
         GxWebStd.gx_hidden_field( context, "Z58ProductServiceId", Z58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N11OrganisationId", A11OrganisationId.ToString());
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vORGANISATIONID_DATA", AV51OrganisationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vORGANISATIONID_DATA", AV51OrganisationId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSG_TOPAGEID_DATA", AV55SG_ToPageId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSG_TOPAGEID_DATA", AV55SG_ToPageId_Data);
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
         GxWebStd.gx_hidden_field( context, "vTILEID", AV58TileId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTILEID", GetSecureSignedToken( "", AV58TileId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ORGANISATIONID", AV46Insert_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_SG_TOPAGEID", AV48Insert_SG_ToPageId.ToString());
         GxWebStd.gx_hidden_field( context, "TILEICONCOLOR", StringUtil.RTrim( A438TileIconColor));
         GxWebStd.gx_hidden_field( context, "TILEACTION", A436TileAction);
         GxWebStd.gx_hidden_field( context, "SG_TOPAGENAME", A330SG_ToPageName);
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICENAME", A59ProductServiceName);
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEIMAGE_GXI", A40000ProductServiceImage_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GXCCtlgxBlob = "PRODUCTSERVICEIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A61ProductServiceImage);
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Objectcall", StringUtil.RTrim( Combo_organisationid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Cls", StringUtil.RTrim( Combo_organisationid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Selectedvalue_set", StringUtil.RTrim( Combo_organisationid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Selectedtext_set", StringUtil.RTrim( Combo_organisationid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Gamoauthtoken", StringUtil.RTrim( Combo_organisationid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Enabled", StringUtil.BoolToStr( Combo_organisationid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Datalistproc", StringUtil.RTrim( Combo_organisationid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ORGANISATIONID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_organisationid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Objectcall", StringUtil.RTrim( Combo_sg_topageid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Cls", StringUtil.RTrim( Combo_sg_topageid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Selectedvalue_set", StringUtil.RTrim( Combo_sg_topageid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Selectedtext_set", StringUtil.RTrim( Combo_sg_topageid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Gamoauthtoken", StringUtil.RTrim( Combo_sg_topageid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Enabled", StringUtil.BoolToStr( Combo_sg_topageid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Datalistproc", StringUtil.RTrim( Combo_sg_topageid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_sg_topageid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "trn_tile.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV58TileId.ToString());
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

      protected void InitializeNonKey0Z81( )
      {
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
         A329SG_ToPageId = Guid.Empty;
         n329SG_ToPageId = false;
         AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
         n329SG_ToPageId = ((Guid.Empty==A329SG_ToPageId) ? true : false);
         A400TileName = "";
         AssignAttri("", false, "A400TileName", A400TileName);
         A402TileBGColor = "";
         n402TileBGColor = false;
         AssignAttri("", false, "A402TileBGColor", A402TileBGColor);
         n402TileBGColor = (String.IsNullOrEmpty(StringUtil.RTrim( A402TileBGColor)) ? true : false);
         A403TileBGImageUrl = "";
         n403TileBGImageUrl = false;
         AssignAttri("", false, "A403TileBGImageUrl", A403TileBGImageUrl);
         n403TileBGImageUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A403TileBGImageUrl)) ? true : false);
         A404TileTextColor = "";
         AssignAttri("", false, "A404TileTextColor", A404TileTextColor);
         A405TileTextAlignment = "";
         AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
         A401TileIcon = "";
         n401TileIcon = false;
         AssignAttri("", false, "A401TileIcon", A401TileIcon);
         n401TileIcon = (String.IsNullOrEmpty(StringUtil.RTrim( A401TileIcon)) ? true : false);
         A406TileIconAlignment = "";
         AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
         A438TileIconColor = "";
         AssignAttri("", false, "A438TileIconColor", A438TileIconColor);
         A29LocationId = Guid.Empty;
         n29LocationId = false;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
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
         A436TileAction = "";
         AssignAttri("", false, "A436TileAction", A436TileAction);
         A330SG_ToPageName = "";
         AssignAttri("", false, "A330SG_ToPageName", A330SG_ToPageName);
         A58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         Z400TileName = "";
         Z402TileBGColor = "";
         Z403TileBGImageUrl = "";
         Z404TileTextColor = "";
         Z405TileTextAlignment = "";
         Z401TileIcon = "";
         Z406TileIconAlignment = "";
         Z438TileIconColor = "";
         Z11OrganisationId = Guid.Empty;
         Z329SG_ToPageId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
      }

      protected void InitAll0Z81( )
      {
         A407TileId = Guid.NewGuid( );
         AssignAttri("", false, "A407TileId", A407TileId.ToString());
         InitializeNonKey0Z81( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A58ProductServiceId = i58ProductServiceId;
         n58ProductServiceId = false;
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241131802473", true, true);
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
         context.AddJavascriptSource("trn_tile.js", "?20241131802475", false, true);
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
         edtTileId_Internalname = "TILEID";
         edtTileName_Internalname = "TILENAME";
         edtTileIcon_Internalname = "TILEICON";
         edtTileBGColor_Internalname = "TILEBGCOLOR";
         edtTileBGImageUrl_Internalname = "TILEBGIMAGEURL";
         edtTileTextColor_Internalname = "TILETEXTCOLOR";
         cmbTileTextAlignment_Internalname = "TILETEXTALIGNMENT";
         cmbTileIconAlignment_Internalname = "TILEICONALIGNMENT";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         lblTextblockorganisationid_Internalname = "TEXTBLOCKORGANISATIONID";
         Combo_organisationid_Internalname = "COMBO_ORGANISATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         divTablesplittedorganisationid_Internalname = "TABLESPLITTEDORGANISATIONID";
         edtLocationId_Internalname = "LOCATIONID";
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION";
         imgProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE";
         lblTextblocksg_topageid_Internalname = "TEXTBLOCKSG_TOPAGEID";
         Combo_sg_topageid_Internalname = "COMBO_SG_TOPAGEID";
         edtSG_ToPageId_Internalname = "SG_TOPAGEID";
         divTablesplittedsg_topageid_Internalname = "TABLESPLITTEDSG_TOPAGEID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboorganisationid_Internalname = "vCOMBOORGANISATIONID";
         divSectionattribute_organisationid_Internalname = "SECTIONATTRIBUTE_ORGANISATIONID";
         edtavCombosg_topageid_Internalname = "vCOMBOSG_TOPAGEID";
         divSectionattribute_sg_topageid_Internalname = "SECTIONATTRIBUTE_SG_TOPAGEID";
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
         Form.Caption = context.GetMessage( "Tile", "");
         edtavCombosg_topageid_Jsonclick = "";
         edtavCombosg_topageid_Enabled = 0;
         edtavCombosg_topageid_Visible = 1;
         edtavComboorganisationid_Jsonclick = "";
         edtavComboorganisationid_Enabled = 0;
         edtavComboorganisationid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSG_ToPageId_Jsonclick = "";
         edtSG_ToPageId_Enabled = 1;
         edtSG_ToPageId_Visible = 1;
         Combo_sg_topageid_Datalistprocparametersprefix = " \"ComboName\": \"SG_ToPageId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"TileId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_sg_topageid_Datalistproc = "Trn_TileLoadDVCombo";
         Combo_sg_topageid_Cls = "ExtendedCombo Attribute";
         Combo_sg_topageid_Caption = "";
         Combo_sg_topageid_Enabled = Convert.ToBoolean( -1);
         imgProductServiceImage_Enabled = 0;
         edtProductServiceDescription_Enabled = 0;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 0;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtOrganisationId_Visible = 1;
         Combo_organisationid_Datalistprocparametersprefix = " \"ComboName\": \"OrganisationId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"TileId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_organisationid_Datalistproc = "Trn_TileLoadDVCombo";
         Combo_organisationid_Cls = "ExtendedCombo Attribute";
         Combo_organisationid_Caption = "";
         Combo_organisationid_Enabled = Convert.ToBoolean( -1);
         edtProductServiceId_Jsonclick = "";
         edtProductServiceId_Enabled = 1;
         cmbTileIconAlignment_Jsonclick = "";
         cmbTileIconAlignment.Enabled = 1;
         cmbTileTextAlignment_Jsonclick = "";
         cmbTileTextAlignment.Enabled = 1;
         edtTileTextColor_Jsonclick = "";
         edtTileTextColor_Enabled = 1;
         edtTileBGImageUrl_Jsonclick = "";
         edtTileBGImageUrl_Enabled = 1;
         edtTileBGColor_Jsonclick = "";
         edtTileBGColor_Enabled = 1;
         edtTileIcon_Jsonclick = "";
         edtTileIcon_Enabled = 1;
         edtTileName_Jsonclick = "";
         edtTileName_Enabled = 1;
         edtTileId_Jsonclick = "";
         edtTileId_Enabled = 1;
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
         cmbTileTextAlignment.Name = "TILETEXTALIGNMENT";
         cmbTileTextAlignment.WebTags = "";
         cmbTileTextAlignment.addItem("center", context.GetMessage( "center", ""), 0);
         cmbTileTextAlignment.addItem("left", context.GetMessage( "left", ""), 0);
         cmbTileTextAlignment.addItem("right", context.GetMessage( "right", ""), 0);
         if ( cmbTileTextAlignment.ItemCount > 0 )
         {
            A405TileTextAlignment = cmbTileTextAlignment.getValidValue(A405TileTextAlignment);
            AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
         }
         cmbTileIconAlignment.Name = "TILEICONALIGNMENT";
         cmbTileIconAlignment.WebTags = "";
         cmbTileIconAlignment.addItem("center", context.GetMessage( "center", ""), 0);
         cmbTileIconAlignment.addItem("left", context.GetMessage( "left", ""), 0);
         cmbTileIconAlignment.addItem("right", context.GetMessage( "right", ""), 0);
         if ( cmbTileIconAlignment.ItemCount > 0 )
         {
            A406TileIconAlignment = cmbTileIconAlignment.getValidValue(A406TileIconAlignment);
            AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
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

      public void Valid_Organisationid( )
      {
         n11OrganisationId = false;
         /* Using cursor T000Z21 */
         pr_default.execute(19, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtOrganisationId_Internalname;
            }
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Locationid( )
      {
         n58ProductServiceId = false;
         n29LocationId = false;
         n11OrganisationId = false;
         /* Using cursor T000Z18 */
         pr_default.execute(16, new Object[] {n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtProductServiceId_Internalname;
            }
         }
         A59ProductServiceName = T000Z18_A59ProductServiceName[0];
         A60ProductServiceDescription = T000Z18_A60ProductServiceDescription[0];
         A40000ProductServiceImage_GXI = T000Z18_A40000ProductServiceImage_GXI[0];
         A61ProductServiceImage = T000Z18_A61ProductServiceImage[0];
         pr_default.close(16);
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
         n329SG_ToPageId = false;
         n29LocationId = false;
         /* Using cursor T000Z17 */
         pr_default.execute(15, new Object[] {n329SG_ToPageId, A329SG_ToPageId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (Guid.Empty==A329SG_ToPageId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_To Page", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_TOPAGEID");
               AnyError = 1;
               GX_FocusControl = edtSG_ToPageId_Internalname;
            }
         }
         A330SG_ToPageName = T000Z17_A330SG_ToPageName[0];
         A29LocationId = T000Z17_A29LocationId[0];
         n29LocationId = T000Z17_n29LocationId[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A330SG_ToPageName", A330SG_ToPageName);
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV58TileId","fld":"vTILEID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV58TileId","fld":"vTILEID","hsh":true},{"av":"A438TileIconColor","fld":"TILEICONCOLOR"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E140Z2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_SG_TOPAGEID.ONOPTIONCLICKED","""{"handler":"E130Z2","iparms":[{"av":"Combo_sg_topageid_Selectedvalue_get","ctrl":"COMBO_SG_TOPAGEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SG_TOPAGEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV56ComboSG_ToPageId","fld":"vCOMBOSG_TOPAGEID"}]}""");
         setEventMetadata("COMBO_ORGANISATIONID.ONOPTIONCLICKED","""{"handler":"E120Z2","iparms":[{"av":"Combo_organisationid_Selectedvalue_get","ctrl":"COMBO_ORGANISATIONID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_ORGANISATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV52ComboOrganisationId","fld":"vCOMBOORGANISATIONID"}]}""");
         setEventMetadata("VALID_TILEID","""{"handler":"Valid_Tileid","iparms":[]}""");
         setEventMetadata("VALID_TILEBGIMAGEURL","""{"handler":"Valid_Tilebgimageurl","iparms":[]}""");
         setEventMetadata("VALID_TILETEXTALIGNMENT","""{"handler":"Valid_Tiletextalignment","iparms":[]}""");
         setEventMetadata("VALID_TILEICONALIGNMENT","""{"handler":"Valid_Tileiconalignment","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A59ProductServiceName","fld":"PRODUCTSERVICENAME"},{"av":"A60ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION"},{"av":"A61ProductServiceImage","fld":"PRODUCTSERVICEIMAGE"},{"av":"A40000ProductServiceImage_GXI","fld":"PRODUCTSERVICEIMAGE_GXI"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"A59ProductServiceName","fld":"PRODUCTSERVICENAME"},{"av":"A60ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION"},{"av":"A61ProductServiceImage","fld":"PRODUCTSERVICEIMAGE"},{"av":"A40000ProductServiceImage_GXI","fld":"PRODUCTSERVICEIMAGE_GXI"}]}""");
         setEventMetadata("VALID_SG_TOPAGEID","""{"handler":"Valid_Sg_topageid","iparms":[{"av":"A329SG_ToPageId","fld":"SG_TOPAGEID"},{"av":"A330SG_ToPageName","fld":"SG_TOPAGENAME"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_SG_TOPAGEID",""","oparms":[{"av":"A330SG_ToPageName","fld":"SG_TOPAGENAME"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
         setEventMetadata("VALIDV_COMBOORGANISATIONID","""{"handler":"Validv_Comboorganisationid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOSG_TOPAGEID","""{"handler":"Validv_Combosg_topageid","iparms":[]}""");
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
         pr_default.close(19);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV58TileId = Guid.Empty;
         Z407TileId = Guid.Empty;
         Z400TileName = "";
         Z402TileBGColor = "";
         Z403TileBGImageUrl = "";
         Z404TileTextColor = "";
         Z405TileTextAlignment = "";
         Z401TileIcon = "";
         Z406TileIconAlignment = "";
         Z438TileIconColor = "";
         Z11OrganisationId = Guid.Empty;
         Z329SG_ToPageId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
         N11OrganisationId = Guid.Empty;
         N329SG_ToPageId = Guid.Empty;
         Combo_sg_topageid_Selectedvalue_get = "";
         Combo_organisationid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A11OrganisationId = Guid.Empty;
         A329SG_ToPageId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         A29LocationId = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A405TileTextAlignment = "";
         A406TileIconAlignment = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A407TileId = Guid.Empty;
         A400TileName = "";
         A401TileIcon = "";
         A402TileBGColor = "";
         A403TileBGImageUrl = "";
         A404TileTextColor = "";
         lblTextblockorganisationid_Jsonclick = "";
         ucCombo_organisationid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV51OrganisationId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A60ProductServiceDescription = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         sImgUrl = "";
         lblTextblocksg_topageid_Jsonclick = "";
         ucCombo_sg_topageid = new GXUserControl();
         AV55SG_ToPageId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV52ComboOrganisationId = Guid.Empty;
         AV56ComboSG_ToPageId = Guid.Empty;
         A438TileIconColor = "";
         AV46Insert_OrganisationId = Guid.Empty;
         AV48Insert_SG_ToPageId = Guid.Empty;
         A436TileAction = "";
         A330SG_ToPageName = "";
         A59ProductServiceName = "";
         AV59Pgmname = "";
         Combo_organisationid_Objectcall = "";
         Combo_organisationid_Class = "";
         Combo_organisationid_Icontype = "";
         Combo_organisationid_Icon = "";
         Combo_organisationid_Tooltip = "";
         Combo_organisationid_Selectedvalue_set = "";
         Combo_organisationid_Selectedtext_set = "";
         Combo_organisationid_Selectedtext_get = "";
         Combo_organisationid_Gamoauthtoken = "";
         Combo_organisationid_Ddointernalname = "";
         Combo_organisationid_Titlecontrolalign = "";
         Combo_organisationid_Dropdownoptionstype = "";
         Combo_organisationid_Titlecontrolidtoreplace = "";
         Combo_organisationid_Datalisttype = "";
         Combo_organisationid_Datalistfixedvalues = "";
         Combo_organisationid_Remoteservicesparameters = "";
         Combo_organisationid_Htmltemplate = "";
         Combo_organisationid_Multiplevaluestype = "";
         Combo_organisationid_Loadingdata = "";
         Combo_organisationid_Noresultsfound = "";
         Combo_organisationid_Emptyitemtext = "";
         Combo_organisationid_Onlyselectedvalues = "";
         Combo_organisationid_Selectalltext = "";
         Combo_organisationid_Multiplevaluesseparator = "";
         Combo_organisationid_Addnewoptiontext = "";
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
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode81 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
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
         Z436TileAction = "";
         Z330SG_ToPageName = "";
         Z29LocationId = Guid.Empty;
         Z59ProductServiceName = "";
         Z60ProductServiceDescription = "";
         Z61ProductServiceImage = "";
         Z40000ProductServiceImage_GXI = "";
         T000Z5_A330SG_ToPageName = new string[] {""} ;
         T000Z5_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z5_n29LocationId = new bool[] {false} ;
         T000Z6_A59ProductServiceName = new string[] {""} ;
         T000Z6_A60ProductServiceDescription = new string[] {""} ;
         T000Z6_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z6_A61ProductServiceImage = new string[] {""} ;
         T000Z7_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z7_A400TileName = new string[] {""} ;
         T000Z7_A402TileBGColor = new string[] {""} ;
         T000Z7_n402TileBGColor = new bool[] {false} ;
         T000Z7_A403TileBGImageUrl = new string[] {""} ;
         T000Z7_n403TileBGImageUrl = new bool[] {false} ;
         T000Z7_A404TileTextColor = new string[] {""} ;
         T000Z7_A405TileTextAlignment = new string[] {""} ;
         T000Z7_A401TileIcon = new string[] {""} ;
         T000Z7_n401TileIcon = new bool[] {false} ;
         T000Z7_A406TileIconAlignment = new string[] {""} ;
         T000Z7_A438TileIconColor = new string[] {""} ;
         T000Z7_A59ProductServiceName = new string[] {""} ;
         T000Z7_A60ProductServiceDescription = new string[] {""} ;
         T000Z7_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z7_A436TileAction = new string[] {""} ;
         T000Z7_A330SG_ToPageName = new string[] {""} ;
         T000Z7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z7_n11OrganisationId = new bool[] {false} ;
         T000Z7_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         T000Z7_n329SG_ToPageId = new bool[] {false} ;
         T000Z7_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z7_n29LocationId = new bool[] {false} ;
         T000Z7_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z7_n58ProductServiceId = new bool[] {false} ;
         T000Z7_A61ProductServiceImage = new string[] {""} ;
         T000Z4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z4_n11OrganisationId = new bool[] {false} ;
         T000Z8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z8_n11OrganisationId = new bool[] {false} ;
         T000Z9_A330SG_ToPageName = new string[] {""} ;
         T000Z9_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z9_n29LocationId = new bool[] {false} ;
         T000Z10_A59ProductServiceName = new string[] {""} ;
         T000Z10_A60ProductServiceDescription = new string[] {""} ;
         T000Z10_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z10_A61ProductServiceImage = new string[] {""} ;
         T000Z11_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z3_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z3_A400TileName = new string[] {""} ;
         T000Z3_A402TileBGColor = new string[] {""} ;
         T000Z3_n402TileBGColor = new bool[] {false} ;
         T000Z3_A403TileBGImageUrl = new string[] {""} ;
         T000Z3_n403TileBGImageUrl = new bool[] {false} ;
         T000Z3_A404TileTextColor = new string[] {""} ;
         T000Z3_A405TileTextAlignment = new string[] {""} ;
         T000Z3_A401TileIcon = new string[] {""} ;
         T000Z3_n401TileIcon = new bool[] {false} ;
         T000Z3_A406TileIconAlignment = new string[] {""} ;
         T000Z3_A438TileIconColor = new string[] {""} ;
         T000Z3_A436TileAction = new string[] {""} ;
         T000Z3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z3_n11OrganisationId = new bool[] {false} ;
         T000Z3_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         T000Z3_n329SG_ToPageId = new bool[] {false} ;
         T000Z3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z3_n58ProductServiceId = new bool[] {false} ;
         T000Z12_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z13_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z2_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z2_A400TileName = new string[] {""} ;
         T000Z2_A402TileBGColor = new string[] {""} ;
         T000Z2_n402TileBGColor = new bool[] {false} ;
         T000Z2_A403TileBGImageUrl = new string[] {""} ;
         T000Z2_n403TileBGImageUrl = new bool[] {false} ;
         T000Z2_A404TileTextColor = new string[] {""} ;
         T000Z2_A405TileTextAlignment = new string[] {""} ;
         T000Z2_A401TileIcon = new string[] {""} ;
         T000Z2_n401TileIcon = new bool[] {false} ;
         T000Z2_A406TileIconAlignment = new string[] {""} ;
         T000Z2_A438TileIconColor = new string[] {""} ;
         T000Z2_A436TileAction = new string[] {""} ;
         T000Z2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z2_n11OrganisationId = new bool[] {false} ;
         T000Z2_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         T000Z2_n329SG_ToPageId = new bool[] {false} ;
         T000Z2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z2_n58ProductServiceId = new bool[] {false} ;
         T000Z17_A330SG_ToPageName = new string[] {""} ;
         T000Z17_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z17_n29LocationId = new bool[] {false} ;
         T000Z18_A59ProductServiceName = new string[] {""} ;
         T000Z18_A60ProductServiceDescription = new string[] {""} ;
         T000Z18_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z18_A61ProductServiceImage = new string[] {""} ;
         T000Z19_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         T000Z20_A407TileId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         i58ProductServiceId = Guid.Empty;
         T000Z21_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z21_n11OrganisationId = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_tile__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tile__default(),
            new Object[][] {
                new Object[] {
               T000Z2_A407TileId, T000Z2_A400TileName, T000Z2_A402TileBGColor, T000Z2_n402TileBGColor, T000Z2_A403TileBGImageUrl, T000Z2_n403TileBGImageUrl, T000Z2_A404TileTextColor, T000Z2_A405TileTextAlignment, T000Z2_A401TileIcon, T000Z2_n401TileIcon,
               T000Z2_A406TileIconAlignment, T000Z2_A438TileIconColor, T000Z2_A436TileAction, T000Z2_A11OrganisationId, T000Z2_n11OrganisationId, T000Z2_A329SG_ToPageId, T000Z2_n329SG_ToPageId, T000Z2_A58ProductServiceId, T000Z2_n58ProductServiceId
               }
               , new Object[] {
               T000Z3_A407TileId, T000Z3_A400TileName, T000Z3_A402TileBGColor, T000Z3_n402TileBGColor, T000Z3_A403TileBGImageUrl, T000Z3_n403TileBGImageUrl, T000Z3_A404TileTextColor, T000Z3_A405TileTextAlignment, T000Z3_A401TileIcon, T000Z3_n401TileIcon,
               T000Z3_A406TileIconAlignment, T000Z3_A438TileIconColor, T000Z3_A436TileAction, T000Z3_A11OrganisationId, T000Z3_n11OrganisationId, T000Z3_A329SG_ToPageId, T000Z3_n329SG_ToPageId, T000Z3_A58ProductServiceId, T000Z3_n58ProductServiceId
               }
               , new Object[] {
               T000Z4_A11OrganisationId
               }
               , new Object[] {
               T000Z5_A330SG_ToPageName, T000Z5_A29LocationId, T000Z5_n29LocationId
               }
               , new Object[] {
               T000Z6_A59ProductServiceName, T000Z6_A60ProductServiceDescription, T000Z6_A40000ProductServiceImage_GXI, T000Z6_A61ProductServiceImage
               }
               , new Object[] {
               T000Z7_A407TileId, T000Z7_A400TileName, T000Z7_A402TileBGColor, T000Z7_n402TileBGColor, T000Z7_A403TileBGImageUrl, T000Z7_n403TileBGImageUrl, T000Z7_A404TileTextColor, T000Z7_A405TileTextAlignment, T000Z7_A401TileIcon, T000Z7_n401TileIcon,
               T000Z7_A406TileIconAlignment, T000Z7_A438TileIconColor, T000Z7_A59ProductServiceName, T000Z7_A60ProductServiceDescription, T000Z7_A40000ProductServiceImage_GXI, T000Z7_A436TileAction, T000Z7_A330SG_ToPageName, T000Z7_A11OrganisationId, T000Z7_n11OrganisationId, T000Z7_A329SG_ToPageId,
               T000Z7_n329SG_ToPageId, T000Z7_A29LocationId, T000Z7_n29LocationId, T000Z7_A58ProductServiceId, T000Z7_n58ProductServiceId, T000Z7_A61ProductServiceImage
               }
               , new Object[] {
               T000Z8_A11OrganisationId
               }
               , new Object[] {
               T000Z9_A330SG_ToPageName, T000Z9_A29LocationId, T000Z9_n29LocationId
               }
               , new Object[] {
               T000Z10_A59ProductServiceName, T000Z10_A60ProductServiceDescription, T000Z10_A40000ProductServiceImage_GXI, T000Z10_A61ProductServiceImage
               }
               , new Object[] {
               T000Z11_A407TileId
               }
               , new Object[] {
               T000Z12_A407TileId
               }
               , new Object[] {
               T000Z13_A407TileId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z17_A330SG_ToPageName, T000Z17_A29LocationId, T000Z17_n29LocationId
               }
               , new Object[] {
               T000Z18_A59ProductServiceName, T000Z18_A60ProductServiceDescription, T000Z18_A40000ProductServiceImage_GXI, T000Z18_A61ProductServiceImage
               }
               , new Object[] {
               T000Z19_A328Trn_ColId
               }
               , new Object[] {
               T000Z20_A407TileId
               }
               , new Object[] {
               T000Z21_A11OrganisationId
               }
            }
         );
         Z58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         i58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         A58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         Z407TileId = Guid.NewGuid( );
         A407TileId = Guid.NewGuid( );
         AV59Pgmname = "Trn_Tile";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound81 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtTileId_Enabled ;
      private int edtTileName_Enabled ;
      private int edtTileIcon_Enabled ;
      private int edtTileBGColor_Enabled ;
      private int edtTileBGImageUrl_Enabled ;
      private int edtTileTextColor_Enabled ;
      private int edtProductServiceId_Enabled ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationId_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtProductServiceDescription_Enabled ;
      private int imgProductServiceImage_Enabled ;
      private int edtSG_ToPageId_Visible ;
      private int edtSG_ToPageId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboorganisationid_Visible ;
      private int edtavComboorganisationid_Enabled ;
      private int edtavCombosg_topageid_Visible ;
      private int edtavCombosg_topageid_Enabled ;
      private int Combo_organisationid_Datalistupdateminimumcharacters ;
      private int Combo_organisationid_Gxcontroltype ;
      private int Combo_sg_topageid_Datalistupdateminimumcharacters ;
      private int Combo_sg_topageid_Gxcontroltype ;
      private int AV60GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z402TileBGColor ;
      private string Z404TileTextColor ;
      private string Z405TileTextAlignment ;
      private string Z401TileIcon ;
      private string Z406TileIconAlignment ;
      private string Z438TileIconColor ;
      private string Combo_sg_topageid_Selectedvalue_get ;
      private string Combo_organisationid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTileId_Internalname ;
      private string A405TileTextAlignment ;
      private string cmbTileTextAlignment_Internalname ;
      private string A406TileIconAlignment ;
      private string cmbTileIconAlignment_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTileId_Jsonclick ;
      private string edtTileName_Internalname ;
      private string edtTileName_Jsonclick ;
      private string edtTileIcon_Internalname ;
      private string A401TileIcon ;
      private string edtTileIcon_Jsonclick ;
      private string edtTileBGColor_Internalname ;
      private string A402TileBGColor ;
      private string edtTileBGColor_Jsonclick ;
      private string edtTileBGImageUrl_Internalname ;
      private string edtTileBGImageUrl_Jsonclick ;
      private string edtTileTextColor_Internalname ;
      private string A404TileTextColor ;
      private string edtTileTextColor_Jsonclick ;
      private string cmbTileTextAlignment_Jsonclick ;
      private string cmbTileIconAlignment_Jsonclick ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceId_Jsonclick ;
      private string divTablesplittedorganisationid_Internalname ;
      private string lblTextblockorganisationid_Internalname ;
      private string lblTextblockorganisationid_Jsonclick ;
      private string Combo_organisationid_Caption ;
      private string Combo_organisationid_Cls ;
      private string Combo_organisationid_Datalistproc ;
      private string Combo_organisationid_Datalistprocparametersprefix ;
      private string Combo_organisationid_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
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
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_organisationid_Internalname ;
      private string edtavComboorganisationid_Internalname ;
      private string edtavComboorganisationid_Jsonclick ;
      private string divSectionattribute_sg_topageid_Internalname ;
      private string edtavCombosg_topageid_Internalname ;
      private string edtavCombosg_topageid_Jsonclick ;
      private string A438TileIconColor ;
      private string AV59Pgmname ;
      private string Combo_organisationid_Objectcall ;
      private string Combo_organisationid_Class ;
      private string Combo_organisationid_Icontype ;
      private string Combo_organisationid_Icon ;
      private string Combo_organisationid_Tooltip ;
      private string Combo_organisationid_Selectedvalue_set ;
      private string Combo_organisationid_Selectedtext_set ;
      private string Combo_organisationid_Selectedtext_get ;
      private string Combo_organisationid_Gamoauthtoken ;
      private string Combo_organisationid_Ddointernalname ;
      private string Combo_organisationid_Titlecontrolalign ;
      private string Combo_organisationid_Dropdownoptionstype ;
      private string Combo_organisationid_Titlecontrolidtoreplace ;
      private string Combo_organisationid_Datalisttype ;
      private string Combo_organisationid_Datalistfixedvalues ;
      private string Combo_organisationid_Remoteservicesparameters ;
      private string Combo_organisationid_Htmltemplate ;
      private string Combo_organisationid_Multiplevaluestype ;
      private string Combo_organisationid_Loadingdata ;
      private string Combo_organisationid_Noresultsfound ;
      private string Combo_organisationid_Emptyitemtext ;
      private string Combo_organisationid_Onlyselectedvalues ;
      private string Combo_organisationid_Selectalltext ;
      private string Combo_organisationid_Multiplevaluesseparator ;
      private string Combo_organisationid_Addnewoptiontext ;
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
      private string hsh ;
      private string sMode81 ;
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
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n11OrganisationId ;
      private bool n329SG_ToPageId ;
      private bool n58ProductServiceId ;
      private bool n29LocationId ;
      private bool wbErr ;
      private bool A61ProductServiceImage_IsBlob ;
      private bool n402TileBGColor ;
      private bool n403TileBGImageUrl ;
      private bool n401TileIcon ;
      private bool Combo_organisationid_Enabled ;
      private bool Combo_organisationid_Visible ;
      private bool Combo_organisationid_Allowmultipleselection ;
      private bool Combo_organisationid_Isgriditem ;
      private bool Combo_organisationid_Hasdescription ;
      private bool Combo_organisationid_Includeonlyselectedoption ;
      private bool Combo_organisationid_Includeselectalloption ;
      private bool Combo_organisationid_Emptyitem ;
      private bool Combo_organisationid_Includeaddnewoption ;
      private bool Combo_sg_topageid_Enabled ;
      private bool Combo_sg_topageid_Visible ;
      private bool Combo_sg_topageid_Allowmultipleselection ;
      private bool Combo_sg_topageid_Isgriditem ;
      private bool Combo_sg_topageid_Hasdescription ;
      private bool Combo_sg_topageid_Includeonlyselectedoption ;
      private bool Combo_sg_topageid_Includeselectalloption ;
      private bool Combo_sg_topageid_Emptyitem ;
      private bool Combo_sg_topageid_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A60ProductServiceDescription ;
      private string A436TileAction ;
      private string AV17Combo_DataJson ;
      private string Z436TileAction ;
      private string Z60ProductServiceDescription ;
      private string Z400TileName ;
      private string Z403TileBGImageUrl ;
      private string A400TileName ;
      private string A403TileBGImageUrl ;
      private string A40000ProductServiceImage_GXI ;
      private string A330SG_ToPageName ;
      private string A59ProductServiceName ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private string Z330SG_ToPageName ;
      private string Z59ProductServiceName ;
      private string Z40000ProductServiceImage_GXI ;
      private string A61ProductServiceImage ;
      private string Z61ProductServiceImage ;
      private Guid wcpOAV58TileId ;
      private Guid Z407TileId ;
      private Guid Z11OrganisationId ;
      private Guid Z329SG_ToPageId ;
      private Guid Z58ProductServiceId ;
      private Guid N11OrganisationId ;
      private Guid N329SG_ToPageId ;
      private Guid A11OrganisationId ;
      private Guid A329SG_ToPageId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid AV58TileId ;
      private Guid A407TileId ;
      private Guid AV52ComboOrganisationId ;
      private Guid AV56ComboSG_ToPageId ;
      private Guid AV46Insert_OrganisationId ;
      private Guid AV48Insert_SG_ToPageId ;
      private Guid Z29LocationId ;
      private Guid i58ProductServiceId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_organisationid ;
      private GXUserControl ucCombo_sg_topageid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTileTextAlignment ;
      private GXCombobox cmbTileIconAlignment ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV51OrganisationId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV55SG_ToPageId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV18GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV19GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV21TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000Z5_A330SG_ToPageName ;
      private Guid[] T000Z5_A29LocationId ;
      private bool[] T000Z5_n29LocationId ;
      private string[] T000Z6_A59ProductServiceName ;
      private string[] T000Z6_A60ProductServiceDescription ;
      private string[] T000Z6_A40000ProductServiceImage_GXI ;
      private string[] T000Z6_A61ProductServiceImage ;
      private Guid[] T000Z7_A407TileId ;
      private string[] T000Z7_A400TileName ;
      private string[] T000Z7_A402TileBGColor ;
      private bool[] T000Z7_n402TileBGColor ;
      private string[] T000Z7_A403TileBGImageUrl ;
      private bool[] T000Z7_n403TileBGImageUrl ;
      private string[] T000Z7_A404TileTextColor ;
      private string[] T000Z7_A405TileTextAlignment ;
      private string[] T000Z7_A401TileIcon ;
      private bool[] T000Z7_n401TileIcon ;
      private string[] T000Z7_A406TileIconAlignment ;
      private string[] T000Z7_A438TileIconColor ;
      private string[] T000Z7_A59ProductServiceName ;
      private string[] T000Z7_A60ProductServiceDescription ;
      private string[] T000Z7_A40000ProductServiceImage_GXI ;
      private string[] T000Z7_A436TileAction ;
      private string[] T000Z7_A330SG_ToPageName ;
      private Guid[] T000Z7_A11OrganisationId ;
      private bool[] T000Z7_n11OrganisationId ;
      private Guid[] T000Z7_A329SG_ToPageId ;
      private bool[] T000Z7_n329SG_ToPageId ;
      private Guid[] T000Z7_A29LocationId ;
      private bool[] T000Z7_n29LocationId ;
      private Guid[] T000Z7_A58ProductServiceId ;
      private bool[] T000Z7_n58ProductServiceId ;
      private string[] T000Z7_A61ProductServiceImage ;
      private Guid[] T000Z4_A11OrganisationId ;
      private bool[] T000Z4_n11OrganisationId ;
      private Guid[] T000Z8_A11OrganisationId ;
      private bool[] T000Z8_n11OrganisationId ;
      private string[] T000Z9_A330SG_ToPageName ;
      private Guid[] T000Z9_A29LocationId ;
      private bool[] T000Z9_n29LocationId ;
      private string[] T000Z10_A59ProductServiceName ;
      private string[] T000Z10_A60ProductServiceDescription ;
      private string[] T000Z10_A40000ProductServiceImage_GXI ;
      private string[] T000Z10_A61ProductServiceImage ;
      private Guid[] T000Z11_A407TileId ;
      private Guid[] T000Z3_A407TileId ;
      private string[] T000Z3_A400TileName ;
      private string[] T000Z3_A402TileBGColor ;
      private bool[] T000Z3_n402TileBGColor ;
      private string[] T000Z3_A403TileBGImageUrl ;
      private bool[] T000Z3_n403TileBGImageUrl ;
      private string[] T000Z3_A404TileTextColor ;
      private string[] T000Z3_A405TileTextAlignment ;
      private string[] T000Z3_A401TileIcon ;
      private bool[] T000Z3_n401TileIcon ;
      private string[] T000Z3_A406TileIconAlignment ;
      private string[] T000Z3_A438TileIconColor ;
      private string[] T000Z3_A436TileAction ;
      private Guid[] T000Z3_A11OrganisationId ;
      private bool[] T000Z3_n11OrganisationId ;
      private Guid[] T000Z3_A329SG_ToPageId ;
      private bool[] T000Z3_n329SG_ToPageId ;
      private Guid[] T000Z3_A58ProductServiceId ;
      private bool[] T000Z3_n58ProductServiceId ;
      private Guid[] T000Z12_A407TileId ;
      private Guid[] T000Z13_A407TileId ;
      private Guid[] T000Z2_A407TileId ;
      private string[] T000Z2_A400TileName ;
      private string[] T000Z2_A402TileBGColor ;
      private bool[] T000Z2_n402TileBGColor ;
      private string[] T000Z2_A403TileBGImageUrl ;
      private bool[] T000Z2_n403TileBGImageUrl ;
      private string[] T000Z2_A404TileTextColor ;
      private string[] T000Z2_A405TileTextAlignment ;
      private string[] T000Z2_A401TileIcon ;
      private bool[] T000Z2_n401TileIcon ;
      private string[] T000Z2_A406TileIconAlignment ;
      private string[] T000Z2_A438TileIconColor ;
      private string[] T000Z2_A436TileAction ;
      private Guid[] T000Z2_A11OrganisationId ;
      private bool[] T000Z2_n11OrganisationId ;
      private Guid[] T000Z2_A329SG_ToPageId ;
      private bool[] T000Z2_n329SG_ToPageId ;
      private Guid[] T000Z2_A58ProductServiceId ;
      private bool[] T000Z2_n58ProductServiceId ;
      private string[] T000Z17_A330SG_ToPageName ;
      private Guid[] T000Z17_A29LocationId ;
      private bool[] T000Z17_n29LocationId ;
      private string[] T000Z18_A59ProductServiceName ;
      private string[] T000Z18_A60ProductServiceDescription ;
      private string[] T000Z18_A40000ProductServiceImage_GXI ;
      private string[] T000Z18_A61ProductServiceImage ;
      private Guid[] T000Z19_A328Trn_ColId ;
      private Guid[] T000Z20_A407TileId ;
      private Guid[] T000Z21_A11OrganisationId ;
      private bool[] T000Z21_n11OrganisationId ;
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000Z2;
        prmT000Z2 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z3;
        prmT000Z3 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z4;
        prmT000Z4 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z5;
        prmT000Z5 = new Object[] {
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z6;
        prmT000Z6 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z7;
        prmT000Z7 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z8;
        prmT000Z8 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z9;
        prmT000Z9 = new Object[] {
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z10;
        prmT000Z10 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z11;
        prmT000Z11 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z12;
        prmT000Z12 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z13;
        prmT000Z13 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z14;
        prmT000Z14 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("TileName",GXType.VarChar,100,0) ,
        new ParDef("TileBGColor",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileBGImageUrl",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("TileTextColor",GXType.Char,20,0) ,
        new ParDef("TileTextAlignment",GXType.Char,20,0) ,
        new ParDef("TileIcon",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileIconAlignment",GXType.Char,20,0) ,
        new ParDef("TileIconColor",GXType.Char,20,0) ,
        new ParDef("TileAction",GXType.LongVarChar,2097152,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z15;
        prmT000Z15 = new Object[] {
        new ParDef("TileName",GXType.VarChar,100,0) ,
        new ParDef("TileBGColor",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileBGImageUrl",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("TileTextColor",GXType.Char,20,0) ,
        new ParDef("TileTextAlignment",GXType.Char,20,0) ,
        new ParDef("TileIcon",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileIconAlignment",GXType.Char,20,0) ,
        new ParDef("TileIconColor",GXType.Char,20,0) ,
        new ParDef("TileAction",GXType.LongVarChar,2097152,0) ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z16;
        prmT000Z16 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z17;
        prmT000Z17 = new Object[] {
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z18;
        prmT000Z18 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z19;
        prmT000Z19 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z20;
        prmT000Z20 = new Object[] {
        };
        Object[] prmT000Z21;
        prmT000Z21 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T000Z2", "SELECT TileId, TileName, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIcon, TileIconAlignment, TileIconColor, TileAction, OrganisationId, SG_ToPageId, ProductServiceId FROM Trn_Tile WHERE TileId = :TileId  FOR UPDATE OF Trn_Tile NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z3", "SELECT TileId, TileName, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIcon, TileIconAlignment, TileIconColor, TileAction, OrganisationId, SG_ToPageId, ProductServiceId FROM Trn_Tile WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z4", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z5", "SELECT Trn_PageName AS SG_ToPageName, LocationId FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z6", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z7", "SELECT TM1.TileId, TM1.TileName, TM1.TileBGColor, TM1.TileBGImageUrl, TM1.TileTextColor, TM1.TileTextAlignment, TM1.TileIcon, TM1.TileIconAlignment, TM1.TileIconColor, T3.ProductServiceName, T3.ProductServiceDescription, T3.ProductServiceImage_GXI, TM1.TileAction, T2.Trn_PageName AS SG_ToPageName, TM1.OrganisationId, TM1.SG_ToPageId AS SG_ToPageId, T2.LocationId, TM1.ProductServiceId, T3.ProductServiceImage FROM ((Trn_Tile TM1 LEFT JOIN Trn_Page T2 ON T2.Trn_PageId = TM1.SG_ToPageId) LEFT JOIN Trn_ProductService T3 ON T3.ProductServiceId = TM1.ProductServiceId AND T3.LocationId = T2.LocationId AND T3.OrganisationId = TM1.OrganisationId) WHERE TM1.TileId = :TileId ORDER BY TM1.TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z8", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z9", "SELECT Trn_PageName AS SG_ToPageName, LocationId FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z10", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z11", "SELECT TileId FROM Trn_Tile WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z12", "SELECT TileId FROM Trn_Tile WHERE ( TileId > :TileId) ORDER BY TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z13", "SELECT TileId FROM Trn_Tile WHERE ( TileId < :TileId) ORDER BY TileId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z14", "SAVEPOINT gxupdate;INSERT INTO Trn_Tile(TileId, TileName, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIcon, TileIconAlignment, TileIconColor, TileAction, OrganisationId, SG_ToPageId, ProductServiceId) VALUES(:TileId, :TileName, :TileBGColor, :TileBGImageUrl, :TileTextColor, :TileTextAlignment, :TileIcon, :TileIconAlignment, :TileIconColor, :TileAction, :OrganisationId, :SG_ToPageId, :ProductServiceId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z14)
           ,new CursorDef("T000Z15", "SAVEPOINT gxupdate;UPDATE Trn_Tile SET TileName=:TileName, TileBGColor=:TileBGColor, TileBGImageUrl=:TileBGImageUrl, TileTextColor=:TileTextColor, TileTextAlignment=:TileTextAlignment, TileIcon=:TileIcon, TileIconAlignment=:TileIconAlignment, TileIconColor=:TileIconColor, TileAction=:TileAction, OrganisationId=:OrganisationId, SG_ToPageId=:SG_ToPageId, ProductServiceId=:ProductServiceId  WHERE TileId = :TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z15)
           ,new CursorDef("T000Z16", "SAVEPOINT gxupdate;DELETE FROM Trn_Tile  WHERE TileId = :TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z16)
           ,new CursorDef("T000Z17", "SELECT Trn_PageName AS SG_ToPageName, LocationId FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z18", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z19", "SELECT Trn_ColId FROM Trn_Col WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z20", "SELECT TileId FROM Trn_Tile ORDER BY TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z20,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z21", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z21,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 20);
              ((string[]) buf[7])[0] = rslt.getString(6, 20);
              ((string[]) buf[8])[0] = rslt.getString(7, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(10);
              ((Guid[]) buf[13])[0] = rslt.getGuid(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((Guid[]) buf[15])[0] = rslt.getGuid(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((Guid[]) buf[17])[0] = rslt.getGuid(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 20);
              ((string[]) buf[7])[0] = rslt.getString(6, 20);
              ((string[]) buf[8])[0] = rslt.getString(7, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(10);
              ((Guid[]) buf[13])[0] = rslt.getGuid(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((Guid[]) buf[15])[0] = rslt.getGuid(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((Guid[]) buf[17])[0] = rslt.getGuid(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getString(5, 20);
              ((string[]) buf[7])[0] = rslt.getString(6, 20);
              ((string[]) buf[8])[0] = rslt.getString(7, 20);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((string[]) buf[11])[0] = rslt.getString(9, 20);
              ((string[]) buf[12])[0] = rslt.getVarchar(10);
              ((string[]) buf[13])[0] = rslt.getLongVarchar(11);
              ((string[]) buf[14])[0] = rslt.getMultimediaUri(12);
              ((string[]) buf[15])[0] = rslt.getLongVarchar(13);
              ((string[]) buf[16])[0] = rslt.getVarchar(14);
              ((Guid[]) buf[17])[0] = rslt.getGuid(15);
              ((bool[]) buf[18])[0] = rslt.wasNull(15);
              ((Guid[]) buf[19])[0] = rslt.getGuid(16);
              ((bool[]) buf[20])[0] = rslt.wasNull(16);
              ((Guid[]) buf[21])[0] = rslt.getGuid(17);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((Guid[]) buf[23])[0] = rslt.getGuid(18);
              ((bool[]) buf[24])[0] = rslt.wasNull(18);
              ((string[]) buf[25])[0] = rslt.getMultimediaFile(19, rslt.getVarchar(12));
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
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
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
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
              return;
           case 19 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
