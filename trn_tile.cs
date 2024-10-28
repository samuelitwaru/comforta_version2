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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_27") == 0 )
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
            gxLoad_27( A58ProductServiceId, A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A329SG_ToPageId = StringUtil.StrToGuid( GetPar( "SG_ToPageId"));
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A329SG_ToPageId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_26") == 0 )
         {
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
            gxLoad_26( A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
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
            gxLoad_25( A11OrganisationId) ;
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
            GX_FocusControl = edtProductServiceId_Internalname;
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
         nRC_GXsfl_88 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_88"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_88_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_88_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_88_idx = GetPar( "sGXsfl_88_idx");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductServiceId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductServiceId_Internalname, context.GetMessage( "Product/Service", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductServiceId_Internalname, A58ProductServiceId.ToString(), A58ProductServiceId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductServiceId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductServiceId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProductServiceDescription_Internalname, A60ProductServiceDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", 0, 1, edtProductServiceDescription_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "LongDescription", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A61ProductServiceImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServiceImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage));
         GxWebStd.gx_bitmap( context, imgProductServiceImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductServiceImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", "", "", 0, A61ProductServiceImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_Tile.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTileId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTileId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileId_Internalname, A407TileId.ToString(), A407TileId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileName_Internalname, A400TileName, StringUtil.RTrim( context.localUtil.Format( A400TileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileIcon_Internalname, StringUtil.RTrim( A401TileIcon), StringUtil.RTrim( context.localUtil.Format( A401TileIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileIcon_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileBGColor_Internalname, StringUtil.RTrim( A402TileBGColor), StringUtil.RTrim( context.localUtil.Format( A402TileBGColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileBGColor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileBGColor_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileBGImageUrl_Internalname, A403TileBGImageUrl, StringUtil.RTrim( context.localUtil.Format( A403TileBGImageUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", A403TileBGImageUrl, "_blank", "", "", edtTileBGImageUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileBGImageUrl_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTileTextColor_Internalname, StringUtil.RTrim( A404TileTextColor), StringUtil.RTrim( context.localUtil.Format( A404TileTextColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTileTextColor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTileTextColor_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTileTextAlignment, cmbTileTextAlignment_Internalname, StringUtil.RTrim( A405TileTextAlignment), 1, cmbTileTextAlignment_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTileTextAlignment.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTileIconAlignment, cmbTileIconAlignment_Internalname, StringUtil.RTrim( A406TileIconAlignment), 1, cmbTileIconAlignment_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTileIconAlignment.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_Trn_Tile.htm");
         cmbTileIconAlignment.CurrentValue = StringUtil.RTrim( A406TileIconAlignment);
         AssignProp("", false, cmbTileIconAlignment_Internalname, "Values", (string)(cmbTileIconAlignment.ToJavascriptSource()), true);
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
         ucCombo_sg_topageid.SetProperty("EmptyItem", Combo_sg_topageid_Emptyitem);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSG_ToPageId_Internalname, A329SG_ToPageId.ToString(), A329SG_ToPageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSG_ToPageId_Jsonclick, 0, "Attribute", "", "", "", "", edtSG_ToPageId_Visible, edtSG_ToPageId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Tile.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Tile.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
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
         GxWebStd.gx_div_start( context, divSectionattribute_sg_topageid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombosg_topageid_Internalname, AV56ComboSG_ToPageId.ToString(), AV56ComboSG_ToPageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombosg_topageid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombosg_topageid_Visible, edtavCombosg_topageid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_Trn_Tile.htm");
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
         StartGridControl88( ) ;
         nGXsfl_88_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount82 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_82 = 1;
               ScanStart0Z82( ) ;
               while ( RcdFound82 != 0 )
               {
                  init_level_properties82( ) ;
                  getByPrimaryKey0Z82( ) ;
                  AddRow0Z82( ) ;
                  ScanNext0Z82( ) ;
               }
               ScanEnd0Z82( ) ;
               nBlankRcdCount82 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0Z82( ) ;
            standaloneModal0Z82( ) ;
            sMode82 = Gx_mode;
            while ( nGXsfl_88_idx < nRC_GXsfl_88 )
            {
               bGXsfl_88_Refreshing = true;
               ReadRow0Z82( ) ;
               edtAttributeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTEID_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtAttributeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTENAME_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttributeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeName_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtAttrbuteValue_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRBUTEVALUE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttrbuteValue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttrbuteValue_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               if ( ( nRcdExists_82 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0Z82( ) ;
               }
               SendRow0Z82( ) ;
               bGXsfl_88_Refreshing = false;
            }
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount82 = 5;
            nRcdExists_82 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0Z82( ) ;
               while ( RcdFound82 != 0 )
               {
                  sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8882( ) ;
                  init_level_properties82( ) ;
                  standaloneNotModal0Z82( ) ;
                  getByPrimaryKey0Z82( ) ;
                  standaloneModal0Z82( ) ;
                  AddRow0Z82( ) ;
                  ScanNext0Z82( ) ;
               }
               ScanEnd0Z82( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode82 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8882( ) ;
            InitAll0Z82( ) ;
            init_level_properties82( ) ;
            nRcdExists_82 = 0;
            nIsMod_82 = 0;
            nRcdDeleted_82 = 0;
            nBlankRcdCount82 = (short)(nBlankRcdUsr82+nBlankRcdCount82);
            fRowAdded = 0;
            while ( nBlankRcdCount82 > 0 )
            {
               A272AttributeId = Guid.Empty;
               standaloneNotModal0Z82( ) ;
               standaloneModal0Z82( ) ;
               AddRow0Z82( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtAttributeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount82 = (short)(nBlankRcdCount82-1);
            }
            Gx_mode = sMode82;
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
               ajax_req_read_hidden_sdt(cgiGet( "vSG_TOPAGEID_DATA"), AV55SG_ToPageId_Data);
               /* Read saved values. */
               Z407TileId = StringUtil.StrToGuid( cgiGet( "Z407TileId"));
               Z400TileName = cgiGet( "Z400TileName");
               Z401TileIcon = cgiGet( "Z401TileIcon");
               n401TileIcon = (String.IsNullOrEmpty(StringUtil.RTrim( A401TileIcon)) ? true : false);
               Z402TileBGColor = cgiGet( "Z402TileBGColor");
               n402TileBGColor = (String.IsNullOrEmpty(StringUtil.RTrim( A402TileBGColor)) ? true : false);
               Z403TileBGImageUrl = cgiGet( "Z403TileBGImageUrl");
               n403TileBGImageUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A403TileBGImageUrl)) ? true : false);
               Z404TileTextColor = cgiGet( "Z404TileTextColor");
               Z405TileTextAlignment = cgiGet( "Z405TileTextAlignment");
               Z406TileIconAlignment = cgiGet( "Z406TileIconAlignment");
               Z58ProductServiceId = StringUtil.StrToGuid( cgiGet( "Z58ProductServiceId"));
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               n29LocationId = ((Guid.Empty==A29LocationId) ? true : false);
               Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               Z329SG_ToPageId = StringUtil.StrToGuid( cgiGet( "Z329SG_ToPageId"));
               A29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
               n29LocationId = false;
               n29LocationId = ((Guid.Empty==A29LocationId) ? true : false);
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
               n11OrganisationId = false;
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_88 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_88"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N58ProductServiceId = StringUtil.StrToGuid( cgiGet( "N58ProductServiceId"));
               n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
               N11OrganisationId = StringUtil.StrToGuid( cgiGet( "N11OrganisationId"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               N29LocationId = StringUtil.StrToGuid( cgiGet( "N29LocationId"));
               n29LocationId = ((Guid.Empty==A29LocationId) ? true : false);
               N329SG_ToPageId = StringUtil.StrToGuid( cgiGet( "N329SG_ToPageId"));
               AV58TileId = StringUtil.StrToGuid( cgiGet( "vTILEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV20Insert_ProductServiceId = StringUtil.StrToGuid( cgiGet( "vINSERT_PRODUCTSERVICEID"));
               AV46Insert_OrganisationId = StringUtil.StrToGuid( cgiGet( "vINSERT_ORGANISATIONID"));
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( "ORGANISATIONID"));
               n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
               AV47Insert_LocationId = StringUtil.StrToGuid( cgiGet( "vINSERT_LOCATIONID"));
               A29LocationId = StringUtil.StrToGuid( cgiGet( "LOCATIONID"));
               n29LocationId = ((Guid.Empty==A29LocationId) ? true : false);
               AV48Insert_SG_ToPageId = StringUtil.StrToGuid( cgiGet( "vINSERT_SG_TOPAGEID"));
               A59ProductServiceName = cgiGet( "PRODUCTSERVICENAME");
               A40000ProductServiceImage_GXI = cgiGet( "PRODUCTSERVICEIMAGE_GXI");
               A330SG_ToPageName = cgiGet( "SG_TOPAGENAME");
               AV59Pgmname = cgiGet( "vPGMNAME");
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
               cmbTileTextAlignment.Name = cmbTileTextAlignment_Internalname;
               cmbTileTextAlignment.CurrentValue = cgiGet( cmbTileTextAlignment_Internalname);
               A405TileTextAlignment = cgiGet( cmbTileTextAlignment_Internalname);
               AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
               cmbTileIconAlignment.Name = cmbTileIconAlignment_Internalname;
               cmbTileIconAlignment.CurrentValue = cgiGet( cmbTileIconAlignment_Internalname);
               A406TileIconAlignment = cgiGet( cmbTileIconAlignment_Internalname);
               AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
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
               AV56ComboSG_ToPageId = StringUtil.StrToGuid( cgiGet( edtavCombosg_topageid_Internalname));
               AssignAttri("", false, "AV56ComboSG_ToPageId", AV56ComboSG_ToPageId.ToString());
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProductServiceImage_Internalname, ref  A61ProductServiceImage, ref  A40000ProductServiceImage_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Tile");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_SG_TOPAGEID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_sg_topageid.Onoptionclicked */
                           E120Z2 ();
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
                           E130Z2 ();
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
            E130Z2 ();
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
            /* Save parent mode. */
            sMode81 = Gx_mode;
            CONFIRM_0Z82( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode81;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0Z82( )
      {
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow0Z82( ) ;
            if ( ( nRcdExists_82 != 0 ) || ( nIsMod_82 != 0 ) )
            {
               GetKey0Z82( ) ;
               if ( ( nRcdExists_82 == 0 ) && ( nRcdDeleted_82 == 0 ) )
               {
                  if ( RcdFound82 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0Z82( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Z82( ) ;
                        CloseExtendedTableCursors0Z82( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "ATTRIBUTEID_" + sGXsfl_88_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtAttributeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound82 != 0 )
                  {
                     if ( nRcdDeleted_82 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0Z82( ) ;
                        Load0Z82( ) ;
                        BeforeValidate0Z82( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Z82( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_82 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0Z82( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Z82( ) ;
                              CloseExtendedTableCursors0Z82( ) ;
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
                     if ( nRcdDeleted_82 == 0 )
                     {
                        GXCCtl = "ATTRIBUTEID_" + sGXsfl_88_idx;
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
            ChangePostValue( "ZT_"+"Z272AttributeId_"+sGXsfl_88_idx, Z272AttributeId.ToString()) ;
            ChangePostValue( "ZT_"+"Z273AttributeName_"+sGXsfl_88_idx, Z273AttributeName) ;
            ChangePostValue( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_88_idx, Z274AttrbuteValue) ;
            ChangePostValue( "nRcdDeleted_82_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_82_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_82_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_82 != 0 )
            {
               ChangePostValue( "ATTRIBUTEID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRIBUTENAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRBUTEVALUE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttrbuteValue_Enabled), 5, 0, ".", ""))) ;
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
         AV56ComboSG_ToPageId = Guid.Empty;
         AssignAttri("", false, "AV56ComboSG_ToPageId", AV56ComboSG_ToPageId.ToString());
         edtavCombosg_topageid_Visible = 0;
         AssignProp("", false, edtavCombosg_topageid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombosg_topageid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOSG_TOPAGEID' */
         S112 ();
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

      protected void E130Z2( )
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

      protected void E120Z2( )
      {
         /* Combo_sg_topageid_Onoptionclicked Routine */
         returnInSub = false;
         AV56ComboSG_ToPageId = StringUtil.StrToGuid( Combo_sg_topageid_Selectedvalue_get);
         AssignAttri("", false, "AV56ComboSG_ToPageId", AV56ComboSG_ToPageId.ToString());
         /*  Sending Event outputs  */
      }

      protected void S112( )
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

      protected void ZM0Z81( short GX_JID )
      {
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z400TileName = T000Z5_A400TileName[0];
               Z401TileIcon = T000Z5_A401TileIcon[0];
               Z402TileBGColor = T000Z5_A402TileBGColor[0];
               Z403TileBGImageUrl = T000Z5_A403TileBGImageUrl[0];
               Z404TileTextColor = T000Z5_A404TileTextColor[0];
               Z405TileTextAlignment = T000Z5_A405TileTextAlignment[0];
               Z406TileIconAlignment = T000Z5_A406TileIconAlignment[0];
               Z58ProductServiceId = T000Z5_A58ProductServiceId[0];
               Z29LocationId = T000Z5_A29LocationId[0];
               Z11OrganisationId = T000Z5_A11OrganisationId[0];
               Z329SG_ToPageId = T000Z5_A329SG_ToPageId[0];
            }
            else
            {
               Z400TileName = A400TileName;
               Z401TileIcon = A401TileIcon;
               Z402TileBGColor = A402TileBGColor;
               Z403TileBGImageUrl = A403TileBGImageUrl;
               Z404TileTextColor = A404TileTextColor;
               Z405TileTextAlignment = A405TileTextAlignment;
               Z406TileIconAlignment = A406TileIconAlignment;
               Z58ProductServiceId = A58ProductServiceId;
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
               Z329SG_ToPageId = A329SG_ToPageId;
            }
         }
         if ( GX_JID == -24 )
         {
            Z407TileId = A407TileId;
            Z400TileName = A400TileName;
            Z401TileIcon = A401TileIcon;
            Z402TileBGColor = A402TileBGColor;
            Z403TileBGImageUrl = A403TileBGImageUrl;
            Z404TileTextColor = A404TileTextColor;
            Z405TileTextAlignment = A405TileTextAlignment;
            Z406TileIconAlignment = A406TileIconAlignment;
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV47Insert_LocationId) )
         {
            A29LocationId = AV47Insert_LocationId;
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV46Insert_OrganisationId) )
         {
            A11OrganisationId = AV46Insert_OrganisationId;
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV20Insert_ProductServiceId) )
         {
            A58ProductServiceId = AV20Insert_ProductServiceId;
            n58ProductServiceId = false;
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV48Insert_SG_ToPageId) )
         {
            A329SG_ToPageId = AV48Insert_SG_ToPageId;
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
         }
         else
         {
            A329SG_ToPageId = AV56ComboSG_ToPageId;
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000Z8 */
            pr_default.execute(6, new Object[] {n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            A59ProductServiceName = T000Z8_A59ProductServiceName[0];
            A60ProductServiceDescription = T000Z8_A60ProductServiceDescription[0];
            AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
            A40000ProductServiceImage_GXI = T000Z8_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A61ProductServiceImage = T000Z8_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            pr_default.close(6);
            /* Using cursor T000Z9 */
            pr_default.execute(7, new Object[] {A329SG_ToPageId});
            A330SG_ToPageName = T000Z9_A330SG_ToPageName[0];
            pr_default.close(7);
         }
      }

      protected void Load0Z81( )
      {
         /* Using cursor T000Z10 */
         pr_default.execute(8, new Object[] {A407TileId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound81 = 1;
            A400TileName = T000Z10_A400TileName[0];
            AssignAttri("", false, "A400TileName", A400TileName);
            A401TileIcon = T000Z10_A401TileIcon[0];
            n401TileIcon = T000Z10_n401TileIcon[0];
            AssignAttri("", false, "A401TileIcon", A401TileIcon);
            A402TileBGColor = T000Z10_A402TileBGColor[0];
            n402TileBGColor = T000Z10_n402TileBGColor[0];
            AssignAttri("", false, "A402TileBGColor", A402TileBGColor);
            A403TileBGImageUrl = T000Z10_A403TileBGImageUrl[0];
            n403TileBGImageUrl = T000Z10_n403TileBGImageUrl[0];
            AssignAttri("", false, "A403TileBGImageUrl", A403TileBGImageUrl);
            A404TileTextColor = T000Z10_A404TileTextColor[0];
            AssignAttri("", false, "A404TileTextColor", A404TileTextColor);
            A405TileTextAlignment = T000Z10_A405TileTextAlignment[0];
            AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
            A406TileIconAlignment = T000Z10_A406TileIconAlignment[0];
            AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
            A59ProductServiceName = T000Z10_A59ProductServiceName[0];
            A60ProductServiceDescription = T000Z10_A60ProductServiceDescription[0];
            AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
            A40000ProductServiceImage_GXI = T000Z10_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A330SG_ToPageName = T000Z10_A330SG_ToPageName[0];
            A58ProductServiceId = T000Z10_A58ProductServiceId[0];
            n58ProductServiceId = T000Z10_n58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = T000Z10_A29LocationId[0];
            n29LocationId = T000Z10_n29LocationId[0];
            A11OrganisationId = T000Z10_A11OrganisationId[0];
            n11OrganisationId = T000Z10_n11OrganisationId[0];
            A329SG_ToPageId = T000Z10_A329SG_ToPageId[0];
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
            A61ProductServiceImage = T000Z10_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            ZM0Z81( -24) ;
         }
         pr_default.close(8);
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
         /* Using cursor T000Z8 */
         pr_default.execute(6, new Object[] {n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtProductServiceId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A59ProductServiceName = T000Z8_A59ProductServiceName[0];
         A60ProductServiceDescription = T000Z8_A60ProductServiceDescription[0];
         AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
         A40000ProductServiceImage_GXI = T000Z8_A40000ProductServiceImage_GXI[0];
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         A61ProductServiceImage = T000Z8_A61ProductServiceImage[0];
         AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
         AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
         AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
         pr_default.close(6);
         /* Using cursor T000Z9 */
         pr_default.execute(7, new Object[] {A329SG_ToPageId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_To Page", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_TOPAGEID");
            AnyError = 1;
            GX_FocusControl = edtSG_ToPageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A330SG_ToPageName = T000Z9_A330SG_ToPageName[0];
         pr_default.close(7);
         /* Using cursor T000Z7 */
         pr_default.execute(5, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(5);
         /* Using cursor T000Z6 */
         pr_default.execute(4, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0Z81( )
      {
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(5);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_27( Guid A58ProductServiceId ,
                                Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T000Z11 */
         pr_default.execute(9, new Object[] {n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_ProductService", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtProductServiceId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void gxLoad_28( Guid A329SG_ToPageId )
      {
         /* Using cursor T000Z12 */
         pr_default.execute(10, new Object[] {A329SG_ToPageId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_To Page", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_TOPAGEID");
            AnyError = 1;
            GX_FocusControl = edtSG_ToPageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A330SG_ToPageName = T000Z12_A330SG_ToPageName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A330SG_ToPageName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_26( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T000Z13 */
         pr_default.execute(11, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_25( Guid A11OrganisationId )
      {
         /* Using cursor T000Z14 */
         pr_default.execute(12, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey0Z81( )
      {
         /* Using cursor T000Z15 */
         pr_default.execute(13, new Object[] {A407TileId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound81 = 1;
         }
         else
         {
            RcdFound81 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Z5 */
         pr_default.execute(3, new Object[] {A407TileId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0Z81( 24) ;
            RcdFound81 = 1;
            A407TileId = T000Z5_A407TileId[0];
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
            A400TileName = T000Z5_A400TileName[0];
            AssignAttri("", false, "A400TileName", A400TileName);
            A401TileIcon = T000Z5_A401TileIcon[0];
            n401TileIcon = T000Z5_n401TileIcon[0];
            AssignAttri("", false, "A401TileIcon", A401TileIcon);
            A402TileBGColor = T000Z5_A402TileBGColor[0];
            n402TileBGColor = T000Z5_n402TileBGColor[0];
            AssignAttri("", false, "A402TileBGColor", A402TileBGColor);
            A403TileBGImageUrl = T000Z5_A403TileBGImageUrl[0];
            n403TileBGImageUrl = T000Z5_n403TileBGImageUrl[0];
            AssignAttri("", false, "A403TileBGImageUrl", A403TileBGImageUrl);
            A404TileTextColor = T000Z5_A404TileTextColor[0];
            AssignAttri("", false, "A404TileTextColor", A404TileTextColor);
            A405TileTextAlignment = T000Z5_A405TileTextAlignment[0];
            AssignAttri("", false, "A405TileTextAlignment", A405TileTextAlignment);
            A406TileIconAlignment = T000Z5_A406TileIconAlignment[0];
            AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
            A58ProductServiceId = T000Z5_A58ProductServiceId[0];
            n58ProductServiceId = T000Z5_n58ProductServiceId[0];
            AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
            A29LocationId = T000Z5_A29LocationId[0];
            n29LocationId = T000Z5_n29LocationId[0];
            A11OrganisationId = T000Z5_A11OrganisationId[0];
            n11OrganisationId = T000Z5_n11OrganisationId[0];
            A329SG_ToPageId = T000Z5_A329SG_ToPageId[0];
            AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
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
         pr_default.close(3);
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
         /* Using cursor T000Z16 */
         pr_default.execute(14, new Object[] {A407TileId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( GuidUtil.Compare(T000Z16_A407TileId[0], A407TileId, 0) < 0 ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( GuidUtil.Compare(T000Z16_A407TileId[0], A407TileId, 0) > 0 ) ) )
            {
               A407TileId = T000Z16_A407TileId[0];
               AssignAttri("", false, "A407TileId", A407TileId.ToString());
               RcdFound81 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound81 = 0;
         /* Using cursor T000Z17 */
         pr_default.execute(15, new Object[] {A407TileId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( GuidUtil.Compare(T000Z17_A407TileId[0], A407TileId, 0) > 0 ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( GuidUtil.Compare(T000Z17_A407TileId[0], A407TileId, 0) < 0 ) ) )
            {
               A407TileId = T000Z17_A407TileId[0];
               AssignAttri("", false, "A407TileId", A407TileId.ToString());
               RcdFound81 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Z81( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductServiceId_Internalname;
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
                  GX_FocusControl = edtProductServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0Z81( ) ;
                  GX_FocusControl = edtProductServiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A407TileId != Z407TileId )
               {
                  /* Insert record */
                  GX_FocusControl = edtProductServiceId_Internalname;
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
                     GX_FocusControl = edtProductServiceId_Internalname;
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
            GX_FocusControl = edtProductServiceId_Internalname;
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
            /* Using cursor T000Z4 */
            pr_default.execute(2, new Object[] {A407TileId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Tile"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z400TileName, T000Z4_A400TileName[0]) != 0 ) || ( StringUtil.StrCmp(Z401TileIcon, T000Z4_A401TileIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z402TileBGColor, T000Z4_A402TileBGColor[0]) != 0 ) || ( StringUtil.StrCmp(Z403TileBGImageUrl, T000Z4_A403TileBGImageUrl[0]) != 0 ) || ( StringUtil.StrCmp(Z404TileTextColor, T000Z4_A404TileTextColor[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z405TileTextAlignment, T000Z4_A405TileTextAlignment[0]) != 0 ) || ( StringUtil.StrCmp(Z406TileIconAlignment, T000Z4_A406TileIconAlignment[0]) != 0 ) || ( Z58ProductServiceId != T000Z4_A58ProductServiceId[0] ) || ( Z29LocationId != T000Z4_A29LocationId[0] ) || ( Z11OrganisationId != T000Z4_A11OrganisationId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z329SG_ToPageId != T000Z4_A329SG_ToPageId[0] ) )
            {
               if ( StringUtil.StrCmp(Z400TileName, T000Z4_A400TileName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileName");
                  GXUtil.WriteLogRaw("Old: ",Z400TileName);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A400TileName[0]);
               }
               if ( StringUtil.StrCmp(Z401TileIcon, T000Z4_A401TileIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileIcon");
                  GXUtil.WriteLogRaw("Old: ",Z401TileIcon);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A401TileIcon[0]);
               }
               if ( StringUtil.StrCmp(Z402TileBGColor, T000Z4_A402TileBGColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileBGColor");
                  GXUtil.WriteLogRaw("Old: ",Z402TileBGColor);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A402TileBGColor[0]);
               }
               if ( StringUtil.StrCmp(Z403TileBGImageUrl, T000Z4_A403TileBGImageUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileBGImageUrl");
                  GXUtil.WriteLogRaw("Old: ",Z403TileBGImageUrl);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A403TileBGImageUrl[0]);
               }
               if ( StringUtil.StrCmp(Z404TileTextColor, T000Z4_A404TileTextColor[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileTextColor");
                  GXUtil.WriteLogRaw("Old: ",Z404TileTextColor);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A404TileTextColor[0]);
               }
               if ( StringUtil.StrCmp(Z405TileTextAlignment, T000Z4_A405TileTextAlignment[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileTextAlignment");
                  GXUtil.WriteLogRaw("Old: ",Z405TileTextAlignment);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A405TileTextAlignment[0]);
               }
               if ( StringUtil.StrCmp(Z406TileIconAlignment, T000Z4_A406TileIconAlignment[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"TileIconAlignment");
                  GXUtil.WriteLogRaw("Old: ",Z406TileIconAlignment);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A406TileIconAlignment[0]);
               }
               if ( Z58ProductServiceId != T000Z4_A58ProductServiceId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"ProductServiceId");
                  GXUtil.WriteLogRaw("Old: ",Z58ProductServiceId);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A58ProductServiceId[0]);
               }
               if ( Z29LocationId != T000Z4_A29LocationId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z29LocationId);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A29LocationId[0]);
               }
               if ( Z11OrganisationId != T000Z4_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A11OrganisationId[0]);
               }
               if ( Z329SG_ToPageId != T000Z4_A329SG_ToPageId[0] )
               {
                  GXUtil.WriteLog("trn_tile:[seudo value changed for attri]"+"SG_ToPageId");
                  GXUtil.WriteLogRaw("Old: ",Z329SG_ToPageId);
                  GXUtil.WriteLogRaw("Current: ",T000Z4_A329SG_ToPageId[0]);
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
                     /* Using cursor T000Z18 */
                     pr_default.execute(16, new Object[] {A407TileId, A400TileName, n401TileIcon, A401TileIcon, n402TileBGColor, A402TileBGColor, n403TileBGImageUrl, A403TileBGImageUrl, A404TileTextColor, A405TileTextAlignment, A406TileIconAlignment, n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId, A329SG_ToPageId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                     if ( (pr_default.getStatus(16) == 1) )
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
                           ProcessLevel0Z81( ) ;
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
                     /* Using cursor T000Z19 */
                     pr_default.execute(17, new Object[] {A400TileName, n401TileIcon, A401TileIcon, n402TileBGColor, A402TileBGColor, n403TileBGImageUrl, A403TileBGImageUrl, A404TileTextColor, A405TileTextAlignment, A406TileIconAlignment, n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId, A329SG_ToPageId, A407TileId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Tile");
                     if ( (pr_default.getStatus(17) == 103) )
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
                           ProcessLevel0Z81( ) ;
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
                  ScanStart0Z82( ) ;
                  while ( RcdFound82 != 0 )
                  {
                     getByPrimaryKey0Z82( ) ;
                     Delete0Z82( ) ;
                     ScanNext0Z82( ) ;
                  }
                  ScanEnd0Z82( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z20 */
                     pr_default.execute(18, new Object[] {A407TileId});
                     pr_default.close(18);
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
            /* Using cursor T000Z21 */
            pr_default.execute(19, new Object[] {A329SG_ToPageId});
            A330SG_ToPageName = T000Z21_A330SG_ToPageName[0];
            pr_default.close(19);
            /* Using cursor T000Z22 */
            pr_default.execute(20, new Object[] {n58ProductServiceId, A58ProductServiceId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            A59ProductServiceName = T000Z22_A59ProductServiceName[0];
            A60ProductServiceDescription = T000Z22_A60ProductServiceDescription[0];
            AssignAttri("", false, "A60ProductServiceDescription", A60ProductServiceDescription);
            A40000ProductServiceImage_GXI = T000Z22_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A61ProductServiceImage = T000Z22_A61ProductServiceImage[0];
            AssignAttri("", false, "A61ProductServiceImage", A61ProductServiceImage);
            AssignProp("", false, imgProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), true);
            AssignProp("", false, imgProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            pr_default.close(20);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000Z23 */
            pr_default.execute(21, new Object[] {A407TileId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Col", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void ProcessNestedLevel0Z82( )
      {
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow0Z82( ) ;
            if ( ( nRcdExists_82 != 0 ) || ( nIsMod_82 != 0 ) )
            {
               standaloneNotModal0Z82( ) ;
               GetKey0Z82( ) ;
               if ( ( nRcdExists_82 == 0 ) && ( nRcdDeleted_82 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0Z82( ) ;
               }
               else
               {
                  if ( RcdFound82 != 0 )
                  {
                     if ( ( nRcdDeleted_82 != 0 ) && ( nRcdExists_82 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0Z82( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_82 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0Z82( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_82 == 0 )
                     {
                        GXCCtl = "ATTRIBUTEID_" + sGXsfl_88_idx;
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
            ChangePostValue( "ZT_"+"Z272AttributeId_"+sGXsfl_88_idx, Z272AttributeId.ToString()) ;
            ChangePostValue( "ZT_"+"Z273AttributeName_"+sGXsfl_88_idx, Z273AttributeName) ;
            ChangePostValue( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_88_idx, Z274AttrbuteValue) ;
            ChangePostValue( "nRcdDeleted_82_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_82_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_82_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_82), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_82 != 0 )
            {
               ChangePostValue( "ATTRIBUTEID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRIBUTENAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRBUTEVALUE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttrbuteValue_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Z82( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_82 = 0;
         nIsMod_82 = 0;
         nRcdDeleted_82 = 0;
      }

      protected void ProcessLevel0Z81( )
      {
         /* Save parent mode. */
         sMode81 = Gx_mode;
         ProcessNestedLevel0Z82( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode81;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0Z81( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
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
         /* Using cursor T000Z24 */
         pr_default.execute(22);
         RcdFound81 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound81 = 1;
            A407TileId = T000Z24_A407TileId[0];
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z81( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound81 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound81 = 1;
            A407TileId = T000Z24_A407TileId[0];
            AssignAttri("", false, "A407TileId", A407TileId.ToString());
         }
      }

      protected void ScanEnd0Z81( )
      {
         pr_default.close(22);
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
         edtProductServiceId_Enabled = 0;
         AssignProp("", false, edtProductServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceId_Enabled), 5, 0), true);
         edtProductServiceDescription_Enabled = 0;
         AssignProp("", false, edtProductServiceDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductServiceDescription_Enabled), 5, 0), true);
         imgProductServiceImage_Enabled = 0;
         AssignProp("", false, imgProductServiceImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductServiceImage_Enabled), 5, 0), true);
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
         edtSG_ToPageId_Enabled = 0;
         AssignProp("", false, edtSG_ToPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSG_ToPageId_Enabled), 5, 0), true);
         edtavCombosg_topageid_Enabled = 0;
         AssignProp("", false, edtavCombosg_topageid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombosg_topageid_Enabled), 5, 0), true);
      }

      protected void ZM0Z82( short GX_JID )
      {
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
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
         if ( GX_JID == -29 )
         {
            Z407TileId = A407TileId;
            Z272AttributeId = A272AttributeId;
            Z273AttributeName = A273AttributeName;
            Z274AttrbuteValue = A274AttrbuteValue;
         }
      }

      protected void standaloneNotModal0Z82( )
      {
      }

      protected void standaloneModal0Z82( )
      {
         if ( IsIns( )  && (Guid.Empty==A272AttributeId) && ( Gx_BScreen == 0 ) )
         {
            A272AttributeId = Guid.NewGuid( );
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtAttributeId_Enabled = 0;
            AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
         else
         {
            edtAttributeId_Enabled = 1;
            AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z82( )
      {
         /* Using cursor T000Z25 */
         pr_default.execute(23, new Object[] {A407TileId, A272AttributeId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound82 = 1;
            A273AttributeName = T000Z25_A273AttributeName[0];
            A274AttrbuteValue = T000Z25_A274AttrbuteValue[0];
            ZM0Z82( -29) ;
         }
         pr_default.close(23);
         OnLoadActions0Z82( ) ;
      }

      protected void OnLoadActions0Z82( )
      {
      }

      protected void CheckExtendedTable0Z82( )
      {
         nIsDirty_82 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0Z82( ) ;
      }

      protected void CloseExtendedTableCursors0Z82( )
      {
      }

      protected void enableDisable0Z82( )
      {
      }

      protected void GetKey0Z82( )
      {
         /* Using cursor T000Z26 */
         pr_default.execute(24, new Object[] {A407TileId, A272AttributeId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound82 = 1;
         }
         else
         {
            RcdFound82 = 0;
         }
         pr_default.close(24);
      }

      protected void getByPrimaryKey0Z82( )
      {
         /* Using cursor T000Z3 */
         pr_default.execute(1, new Object[] {A407TileId, A272AttributeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z82( 29) ;
            RcdFound82 = 1;
            InitializeNonKey0Z82( ) ;
            A272AttributeId = T000Z3_A272AttributeId[0];
            A273AttributeName = T000Z3_A273AttributeName[0];
            A274AttrbuteValue = T000Z3_A274AttrbuteValue[0];
            Z407TileId = A407TileId;
            Z272AttributeId = A272AttributeId;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Z82( ) ;
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound82 = 0;
            InitializeNonKey0Z82( ) ;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0Z82( ) ;
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Z82( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0Z82( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z2 */
            pr_default.execute(0, new Object[] {A407TileId, A272AttributeId});
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

      protected void Insert0Z82( )
      {
         if ( ! IsAuthorized("trn_page_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z82( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z82( 0) ;
            CheckOptimisticConcurrency0Z82( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z82( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z82( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z27 */
                     pr_default.execute(25, new Object[] {A407TileId, A272AttributeId, A273AttributeName, A274AttrbuteValue});
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_TileAttribute");
                     if ( (pr_default.getStatus(25) == 1) )
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
               Load0Z82( ) ;
            }
            EndLevel0Z82( ) ;
         }
         CloseExtendedTableCursors0Z82( ) ;
      }

      protected void Update0Z82( )
      {
         if ( ! IsAuthorized("trn_page_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Z82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z82( ) ;
         }
         if ( ( nIsMod_82 != 0 ) || ( nIsDirty_82 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0Z82( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0Z82( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0Z82( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000Z28 */
                        pr_default.execute(26, new Object[] {A273AttributeName, A274AttrbuteValue, A407TileId, A272AttributeId});
                        pr_default.close(26);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_TileAttribute");
                        if ( (pr_default.getStatus(26) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_TileAttribute"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0Z82( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0Z82( ) ;
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
               EndLevel0Z82( ) ;
            }
         }
         CloseExtendedTableCursors0Z82( ) ;
      }

      protected void DeferredUpdate0Z82( )
      {
      }

      protected void Delete0Z82( )
      {
         if ( ! IsAuthorized("trn_page_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Z82( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z82( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z82( ) ;
            AfterConfirm0Z82( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z82( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Z29 */
                  pr_default.execute(27, new Object[] {A407TileId, A272AttributeId});
                  pr_default.close(27);
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
         sMode82 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z82( ) ;
         Gx_mode = sMode82;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z82( )
      {
         standaloneModal0Z82( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Z82( )
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

      public void ScanStart0Z82( )
      {
         /* Scan By routine */
         /* Using cursor T000Z30 */
         pr_default.execute(28, new Object[] {A407TileId});
         RcdFound82 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound82 = 1;
            A272AttributeId = T000Z30_A272AttributeId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z82( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound82 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound82 = 1;
            A272AttributeId = T000Z30_A272AttributeId[0];
         }
      }

      protected void ScanEnd0Z82( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm0Z82( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z82( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z82( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z82( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z82( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z82( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z82( )
      {
         edtAttributeId_Enabled = 0;
         AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtAttributeName_Enabled = 0;
         AssignProp("", false, edtAttributeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeName_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtAttrbuteValue_Enabled = 0;
         AssignProp("", false, edtAttrbuteValue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttrbuteValue_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void send_integrity_lvl_hashes0Z82( )
      {
      }

      protected void send_integrity_lvl_hashes0Z81( )
      {
      }

      protected void SubsflControlProps_8882( )
      {
         edtAttributeId_Internalname = "ATTRIBUTEID_"+sGXsfl_88_idx;
         edtAttributeName_Internalname = "ATTRIBUTENAME_"+sGXsfl_88_idx;
         edtAttrbuteValue_Internalname = "ATTRBUTEVALUE_"+sGXsfl_88_idx;
      }

      protected void SubsflControlProps_fel_8882( )
      {
         edtAttributeId_Internalname = "ATTRIBUTEID_"+sGXsfl_88_fel_idx;
         edtAttributeName_Internalname = "ATTRIBUTENAME_"+sGXsfl_88_fel_idx;
         edtAttrbuteValue_Internalname = "ATTRBUTEVALUE_"+sGXsfl_88_fel_idx;
      }

      protected void AddRow0Z82( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8882( ) ;
         SendRow0Z82( ) ;
      }

      protected void SendRow0Z82( )
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
            if ( ((int)((nGXsfl_88_idx) % (2))) == 0 )
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
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_82_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_attributeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttributeId_Internalname,A272AttributeId.ToString(),A272AttributeId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttributeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAttributeId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)88,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_82_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_attributeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttributeName_Internalname,(string)A273AttributeName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttributeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAttributeName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_82_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridlevel_attributeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttrbuteValue_Internalname,(string)A274AttrbuteValue,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttrbuteValue_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtAttrbuteValue_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_attributeRow);
         send_integrity_lvl_hashes0Z82( ) ;
         GXCCtl = "Z272AttributeId_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z272AttributeId.ToString());
         GXCCtl = "Z273AttributeName_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z273AttributeName);
         GXCCtl = "Z274AttrbuteValue_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z274AttrbuteValue);
         GXCCtl = "nRcdDeleted_82_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_82), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_82_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_82), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_82_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_82), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_88_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTILEID_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV58TileId.ToString());
         GxWebStd.gx_hidden_field( context, "ATTRIBUTEID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRIBUTENAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttributeName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRBUTEVALUE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttrbuteValue_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_attributeContainer.AddRow(Gridlevel_attributeRow);
      }

      protected void ReadRow0Z82( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8882( ) ;
         edtAttributeId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTEID_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtAttributeName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRIBUTENAME_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtAttrbuteValue_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRBUTEVALUE_"+sGXsfl_88_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               GXCCtl = "ATTRIBUTEID_" + sGXsfl_88_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtAttributeId_Internalname;
               wbErr = true;
            }
         }
         A273AttributeName = cgiGet( edtAttributeName_Internalname);
         A274AttrbuteValue = cgiGet( edtAttrbuteValue_Internalname);
         GXCCtl = "Z272AttributeId_" + sGXsfl_88_idx;
         Z272AttributeId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z273AttributeName_" + sGXsfl_88_idx;
         Z273AttributeName = cgiGet( GXCCtl);
         GXCCtl = "Z274AttrbuteValue_" + sGXsfl_88_idx;
         Z274AttrbuteValue = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_82_" + sGXsfl_88_idx;
         nRcdDeleted_82 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_82_" + sGXsfl_88_idx;
         nRcdExists_82 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_82_" + sGXsfl_88_idx;
         nIsMod_82 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtAttributeId_Enabled = edtAttributeId_Enabled;
      }

      protected void ConfirmValues0Z0( )
      {
         nGXsfl_88_idx = 0;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8882( ) ;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8882( ) ;
            ChangePostValue( "Z272AttributeId_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z272AttributeId_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z272AttributeId_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z273AttributeName_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z273AttributeName_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z273AttributeName_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z274AttrbuteValue_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z274AttrbuteValue_"+sGXsfl_88_idx) ;
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
         GxWebStd.gx_hidden_field( context, "Z401TileIcon", StringUtil.RTrim( Z401TileIcon));
         GxWebStd.gx_hidden_field( context, "Z402TileBGColor", StringUtil.RTrim( Z402TileBGColor));
         GxWebStd.gx_hidden_field( context, "Z403TileBGImageUrl", Z403TileBGImageUrl);
         GxWebStd.gx_hidden_field( context, "Z404TileTextColor", StringUtil.RTrim( Z404TileTextColor));
         GxWebStd.gx_hidden_field( context, "Z405TileTextAlignment", StringUtil.RTrim( Z405TileTextAlignment));
         GxWebStd.gx_hidden_field( context, "Z406TileIconAlignment", StringUtil.RTrim( Z406TileIconAlignment));
         GxWebStd.gx_hidden_field( context, "Z58ProductServiceId", Z58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z329SG_ToPageId", Z329SG_ToPageId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_88", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_88_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N58ProductServiceId", A58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "N11OrganisationId", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "N29LocationId", A29LocationId.ToString());
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
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODUCTSERVICEID", AV20Insert_ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_ORGANISATIONID", AV46Insert_OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_LOCATIONID", AV47Insert_LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_SG_TOPAGEID", AV48Insert_SG_ToPageId.ToString());
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICENAME", A59ProductServiceName);
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEIMAGE_GXI", A40000ProductServiceImage_GXI);
         GxWebStd.gx_hidden_field( context, "SG_TOPAGENAME", A330SG_ToPageName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GXCCtlgxBlob = "PRODUCTSERVICEIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A61ProductServiceImage);
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Objectcall", StringUtil.RTrim( Combo_sg_topageid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Cls", StringUtil.RTrim( Combo_sg_topageid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Selectedvalue_set", StringUtil.RTrim( Combo_sg_topageid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Selectedtext_set", StringUtil.RTrim( Combo_sg_topageid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Gamoauthtoken", StringUtil.RTrim( Combo_sg_topageid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Enabled", StringUtil.BoolToStr( Combo_sg_topageid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Datalistproc", StringUtil.RTrim( Combo_sg_topageid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_sg_topageid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_SG_TOPAGEID_Emptyitem", StringUtil.BoolToStr( Combo_sg_topageid_Emptyitem));
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
         A58ProductServiceId = Guid.Empty;
         n58ProductServiceId = false;
         AssignAttri("", false, "A58ProductServiceId", A58ProductServiceId.ToString());
         n58ProductServiceId = ((Guid.Empty==A58ProductServiceId) ? true : false);
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         A29LocationId = Guid.Empty;
         n29LocationId = false;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         A329SG_ToPageId = Guid.Empty;
         AssignAttri("", false, "A329SG_ToPageId", A329SG_ToPageId.ToString());
         A400TileName = "";
         AssignAttri("", false, "A400TileName", A400TileName);
         A401TileIcon = "";
         n401TileIcon = false;
         AssignAttri("", false, "A401TileIcon", A401TileIcon);
         n401TileIcon = (String.IsNullOrEmpty(StringUtil.RTrim( A401TileIcon)) ? true : false);
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
         A406TileIconAlignment = "";
         AssignAttri("", false, "A406TileIconAlignment", A406TileIconAlignment);
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
         Z400TileName = "";
         Z401TileIcon = "";
         Z402TileBGColor = "";
         Z403TileBGImageUrl = "";
         Z404TileTextColor = "";
         Z405TileTextAlignment = "";
         Z406TileIconAlignment = "";
         Z58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z329SG_ToPageId = Guid.Empty;
      }

      protected void InitAll0Z81( )
      {
         A407TileId = Guid.NewGuid( );
         AssignAttri("", false, "A407TileId", A407TileId.ToString());
         InitializeNonKey0Z81( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0Z82( )
      {
         A273AttributeName = "";
         A274AttrbuteValue = "";
         Z273AttributeName = "";
         Z274AttrbuteValue = "";
      }

      protected void InitAll0Z82( )
      {
         A272AttributeId = Guid.NewGuid( );
         InitializeNonKey0Z82( ) ;
      }

      protected void StandaloneModalInsert0Z82( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241028527149", true, true);
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
         context.AddJavascriptSource("trn_tile.js", "?20241028527151", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties82( )
      {
         edtAttributeId_Enabled = defedtAttributeId_Enabled;
         AssignProp("", false, edtAttributeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttributeId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void StartGridControl88( )
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
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION";
         imgProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE";
         edtTileId_Internalname = "TILEID";
         edtTileName_Internalname = "TILENAME";
         edtTileIcon_Internalname = "TILEICON";
         edtTileBGColor_Internalname = "TILEBGCOLOR";
         edtTileBGImageUrl_Internalname = "TILEBGIMAGEURL";
         edtTileTextColor_Internalname = "TILETEXTCOLOR";
         cmbTileTextAlignment_Internalname = "TILETEXTALIGNMENT";
         cmbTileIconAlignment_Internalname = "TILEICONALIGNMENT";
         lblTextblocksg_topageid_Internalname = "TEXTBLOCKSG_TOPAGEID";
         Combo_sg_topageid_Internalname = "COMBO_SG_TOPAGEID";
         edtSG_ToPageId_Internalname = "SG_TOPAGEID";
         divTablesplittedsg_topageid_Internalname = "TABLESPLITTEDSG_TOPAGEID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         edtAttributeId_Internalname = "ATTRIBUTEID";
         edtAttributeName_Internalname = "ATTRIBUTENAME";
         edtAttrbuteValue_Internalname = "ATTRBUTEVALUE";
         divTableleaflevel_attribute_Internalname = "TABLELEAFLEVEL_ATTRIBUTE";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = context.GetMessage( "Tile", "");
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
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSG_ToPageId_Jsonclick = "";
         edtSG_ToPageId_Enabled = 1;
         edtSG_ToPageId_Visible = 1;
         Combo_sg_topageid_Emptyitem = Convert.ToBoolean( 0);
         Combo_sg_topageid_Datalistprocparametersprefix = " \"ComboName\": \"SG_ToPageId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"TileId\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_sg_topageid_Datalistproc = "Trn_TileLoadDVCombo";
         Combo_sg_topageid_Cls = "ExtendedCombo Attribute";
         Combo_sg_topageid_Caption = "";
         Combo_sg_topageid_Enabled = Convert.ToBoolean( -1);
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
         imgProductServiceImage_Enabled = 0;
         edtProductServiceDescription_Enabled = 0;
         edtProductServiceId_Jsonclick = "";
         edtProductServiceId_Enabled = 1;
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
         SubsflControlProps_8882( ) ;
         while ( nGXsfl_88_idx <= nRC_GXsfl_88 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0Z82( ) ;
            standaloneModal0Z82( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0Z82( ) ;
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8882( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_attributeContainer)) ;
         /* End function gxnrGridlevel_attribute_newrow */
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

      public void Valid_Sg_topageid( )
      {
         /* Using cursor T000Z21 */
         pr_default.execute(19, new Object[] {A329SG_ToPageId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_To Page", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_TOPAGEID");
            AnyError = 1;
            GX_FocusControl = edtSG_ToPageId_Internalname;
         }
         A330SG_ToPageName = T000Z21_A330SG_ToPageName[0];
         pr_default.close(19);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV58TileId","fld":"vTILEID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV58TileId","fld":"vTILEID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E130Z2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("COMBO_SG_TOPAGEID.ONOPTIONCLICKED","""{"handler":"E120Z2","iparms":[{"av":"Combo_sg_topageid_Selectedvalue_get","ctrl":"COMBO_SG_TOPAGEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_SG_TOPAGEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV56ComboSG_ToPageId","fld":"vCOMBOSG_TOPAGEID"}]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[]}""");
         setEventMetadata("VALID_TILEID","""{"handler":"Valid_Tileid","iparms":[]}""");
         setEventMetadata("VALID_TILEBGIMAGEURL","""{"handler":"Valid_Tilebgimageurl","iparms":[]}""");
         setEventMetadata("VALID_TILETEXTALIGNMENT","""{"handler":"Valid_Tiletextalignment","iparms":[]}""");
         setEventMetadata("VALID_TILEICONALIGNMENT","""{"handler":"Valid_Tileiconalignment","iparms":[]}""");
         setEventMetadata("VALID_SG_TOPAGEID","""{"handler":"Valid_Sg_topageid","iparms":[{"av":"A329SG_ToPageId","fld":"SG_TOPAGEID"},{"av":"A330SG_ToPageName","fld":"SG_TOPAGENAME"}]""");
         setEventMetadata("VALID_SG_TOPAGEID",""","oparms":[{"av":"A330SG_ToPageName","fld":"SG_TOPAGENAME"}]}""");
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
         pr_default.close(20);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV58TileId = Guid.Empty;
         Z407TileId = Guid.Empty;
         Z400TileName = "";
         Z401TileIcon = "";
         Z402TileBGColor = "";
         Z403TileBGImageUrl = "";
         Z404TileTextColor = "";
         Z405TileTextAlignment = "";
         Z406TileIconAlignment = "";
         Z58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z329SG_ToPageId = Guid.Empty;
         N58ProductServiceId = Guid.Empty;
         N11OrganisationId = Guid.Empty;
         N29LocationId = Guid.Empty;
         N329SG_ToPageId = Guid.Empty;
         Combo_sg_topageid_Selectedvalue_get = "";
         Z272AttributeId = Guid.Empty;
         Z273AttributeName = "";
         Z274AttrbuteValue = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A58ProductServiceId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A329SG_ToPageId = Guid.Empty;
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
         A60ProductServiceDescription = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         sImgUrl = "";
         A407TileId = Guid.Empty;
         A400TileName = "";
         A401TileIcon = "";
         A402TileBGColor = "";
         A403TileBGImageUrl = "";
         A404TileTextColor = "";
         lblTextblocksg_topageid_Jsonclick = "";
         ucCombo_sg_topageid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV55SG_ToPageId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV56ComboSG_ToPageId = Guid.Empty;
         Gridlevel_attributeContainer = new GXWebGrid( context);
         sMode82 = "";
         A272AttributeId = Guid.Empty;
         sStyleString = "";
         AV20Insert_ProductServiceId = Guid.Empty;
         AV46Insert_OrganisationId = Guid.Empty;
         AV47Insert_LocationId = Guid.Empty;
         AV48Insert_SG_ToPageId = Guid.Empty;
         A59ProductServiceName = "";
         A330SG_ToPageName = "";
         AV59Pgmname = "";
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
         T000Z8_A59ProductServiceName = new string[] {""} ;
         T000Z8_A60ProductServiceDescription = new string[] {""} ;
         T000Z8_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z8_A61ProductServiceImage = new string[] {""} ;
         T000Z9_A330SG_ToPageName = new string[] {""} ;
         T000Z10_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z10_A400TileName = new string[] {""} ;
         T000Z10_A401TileIcon = new string[] {""} ;
         T000Z10_n401TileIcon = new bool[] {false} ;
         T000Z10_A402TileBGColor = new string[] {""} ;
         T000Z10_n402TileBGColor = new bool[] {false} ;
         T000Z10_A403TileBGImageUrl = new string[] {""} ;
         T000Z10_n403TileBGImageUrl = new bool[] {false} ;
         T000Z10_A404TileTextColor = new string[] {""} ;
         T000Z10_A405TileTextAlignment = new string[] {""} ;
         T000Z10_A406TileIconAlignment = new string[] {""} ;
         T000Z10_A59ProductServiceName = new string[] {""} ;
         T000Z10_A60ProductServiceDescription = new string[] {""} ;
         T000Z10_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z10_A330SG_ToPageName = new string[] {""} ;
         T000Z10_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z10_n58ProductServiceId = new bool[] {false} ;
         T000Z10_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z10_n29LocationId = new bool[] {false} ;
         T000Z10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z10_n11OrganisationId = new bool[] {false} ;
         T000Z10_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         T000Z10_A61ProductServiceImage = new string[] {""} ;
         T000Z7_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z7_n29LocationId = new bool[] {false} ;
         T000Z6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z6_n11OrganisationId = new bool[] {false} ;
         T000Z11_A59ProductServiceName = new string[] {""} ;
         T000Z11_A60ProductServiceDescription = new string[] {""} ;
         T000Z11_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z11_A61ProductServiceImage = new string[] {""} ;
         T000Z12_A330SG_ToPageName = new string[] {""} ;
         T000Z13_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z13_n29LocationId = new bool[] {false} ;
         T000Z14_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z14_n11OrganisationId = new bool[] {false} ;
         T000Z15_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z5_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z5_A400TileName = new string[] {""} ;
         T000Z5_A401TileIcon = new string[] {""} ;
         T000Z5_n401TileIcon = new bool[] {false} ;
         T000Z5_A402TileBGColor = new string[] {""} ;
         T000Z5_n402TileBGColor = new bool[] {false} ;
         T000Z5_A403TileBGImageUrl = new string[] {""} ;
         T000Z5_n403TileBGImageUrl = new bool[] {false} ;
         T000Z5_A404TileTextColor = new string[] {""} ;
         T000Z5_A405TileTextAlignment = new string[] {""} ;
         T000Z5_A406TileIconAlignment = new string[] {""} ;
         T000Z5_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z5_n58ProductServiceId = new bool[] {false} ;
         T000Z5_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z5_n29LocationId = new bool[] {false} ;
         T000Z5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z5_n11OrganisationId = new bool[] {false} ;
         T000Z5_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         T000Z16_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z17_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z4_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z4_A400TileName = new string[] {""} ;
         T000Z4_A401TileIcon = new string[] {""} ;
         T000Z4_n401TileIcon = new bool[] {false} ;
         T000Z4_A402TileBGColor = new string[] {""} ;
         T000Z4_n402TileBGColor = new bool[] {false} ;
         T000Z4_A403TileBGImageUrl = new string[] {""} ;
         T000Z4_n403TileBGImageUrl = new bool[] {false} ;
         T000Z4_A404TileTextColor = new string[] {""} ;
         T000Z4_A405TileTextAlignment = new string[] {""} ;
         T000Z4_A406TileIconAlignment = new string[] {""} ;
         T000Z4_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         T000Z4_n58ProductServiceId = new bool[] {false} ;
         T000Z4_A29LocationId = new Guid[] {Guid.Empty} ;
         T000Z4_n29LocationId = new bool[] {false} ;
         T000Z4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T000Z4_n11OrganisationId = new bool[] {false} ;
         T000Z4_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         T000Z21_A330SG_ToPageName = new string[] {""} ;
         T000Z22_A59ProductServiceName = new string[] {""} ;
         T000Z22_A60ProductServiceDescription = new string[] {""} ;
         T000Z22_A40000ProductServiceImage_GXI = new string[] {""} ;
         T000Z22_A61ProductServiceImage = new string[] {""} ;
         T000Z23_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         T000Z24_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z25_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z25_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z25_A273AttributeName = new string[] {""} ;
         T000Z25_A274AttrbuteValue = new string[] {""} ;
         T000Z26_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z26_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z3_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z3_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z3_A273AttributeName = new string[] {""} ;
         T000Z3_A274AttrbuteValue = new string[] {""} ;
         T000Z2_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z2_A272AttributeId = new Guid[] {Guid.Empty} ;
         T000Z2_A273AttributeName = new string[] {""} ;
         T000Z2_A274AttrbuteValue = new string[] {""} ;
         T000Z30_A407TileId = new Guid[] {Guid.Empty} ;
         T000Z30_A272AttributeId = new Guid[] {Guid.Empty} ;
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
               T000Z2_A407TileId, T000Z2_A272AttributeId, T000Z2_A273AttributeName, T000Z2_A274AttrbuteValue
               }
               , new Object[] {
               T000Z3_A407TileId, T000Z3_A272AttributeId, T000Z3_A273AttributeName, T000Z3_A274AttrbuteValue
               }
               , new Object[] {
               T000Z4_A407TileId, T000Z4_A400TileName, T000Z4_A401TileIcon, T000Z4_n401TileIcon, T000Z4_A402TileBGColor, T000Z4_n402TileBGColor, T000Z4_A403TileBGImageUrl, T000Z4_n403TileBGImageUrl, T000Z4_A404TileTextColor, T000Z4_A405TileTextAlignment,
               T000Z4_A406TileIconAlignment, T000Z4_A58ProductServiceId, T000Z4_n58ProductServiceId, T000Z4_A29LocationId, T000Z4_n29LocationId, T000Z4_A11OrganisationId, T000Z4_n11OrganisationId, T000Z4_A329SG_ToPageId
               }
               , new Object[] {
               T000Z5_A407TileId, T000Z5_A400TileName, T000Z5_A401TileIcon, T000Z5_n401TileIcon, T000Z5_A402TileBGColor, T000Z5_n402TileBGColor, T000Z5_A403TileBGImageUrl, T000Z5_n403TileBGImageUrl, T000Z5_A404TileTextColor, T000Z5_A405TileTextAlignment,
               T000Z5_A406TileIconAlignment, T000Z5_A58ProductServiceId, T000Z5_n58ProductServiceId, T000Z5_A29LocationId, T000Z5_n29LocationId, T000Z5_A11OrganisationId, T000Z5_n11OrganisationId, T000Z5_A329SG_ToPageId
               }
               , new Object[] {
               T000Z6_A11OrganisationId
               }
               , new Object[] {
               T000Z7_A29LocationId
               }
               , new Object[] {
               T000Z8_A59ProductServiceName, T000Z8_A60ProductServiceDescription, T000Z8_A40000ProductServiceImage_GXI, T000Z8_A61ProductServiceImage
               }
               , new Object[] {
               T000Z9_A330SG_ToPageName
               }
               , new Object[] {
               T000Z10_A407TileId, T000Z10_A400TileName, T000Z10_A401TileIcon, T000Z10_n401TileIcon, T000Z10_A402TileBGColor, T000Z10_n402TileBGColor, T000Z10_A403TileBGImageUrl, T000Z10_n403TileBGImageUrl, T000Z10_A404TileTextColor, T000Z10_A405TileTextAlignment,
               T000Z10_A406TileIconAlignment, T000Z10_A59ProductServiceName, T000Z10_A60ProductServiceDescription, T000Z10_A40000ProductServiceImage_GXI, T000Z10_A330SG_ToPageName, T000Z10_A58ProductServiceId, T000Z10_n58ProductServiceId, T000Z10_A29LocationId, T000Z10_n29LocationId, T000Z10_A11OrganisationId,
               T000Z10_n11OrganisationId, T000Z10_A329SG_ToPageId, T000Z10_A61ProductServiceImage
               }
               , new Object[] {
               T000Z11_A59ProductServiceName, T000Z11_A60ProductServiceDescription, T000Z11_A40000ProductServiceImage_GXI, T000Z11_A61ProductServiceImage
               }
               , new Object[] {
               T000Z12_A330SG_ToPageName
               }
               , new Object[] {
               T000Z13_A29LocationId
               }
               , new Object[] {
               T000Z14_A11OrganisationId
               }
               , new Object[] {
               T000Z15_A407TileId
               }
               , new Object[] {
               T000Z16_A407TileId
               }
               , new Object[] {
               T000Z17_A407TileId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z21_A330SG_ToPageName
               }
               , new Object[] {
               T000Z22_A59ProductServiceName, T000Z22_A60ProductServiceDescription, T000Z22_A40000ProductServiceImage_GXI, T000Z22_A61ProductServiceImage
               }
               , new Object[] {
               T000Z23_A328Trn_ColId
               }
               , new Object[] {
               T000Z24_A407TileId
               }
               , new Object[] {
               T000Z25_A407TileId, T000Z25_A272AttributeId, T000Z25_A273AttributeName, T000Z25_A274AttrbuteValue
               }
               , new Object[] {
               T000Z26_A407TileId, T000Z26_A272AttributeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z30_A407TileId, T000Z30_A272AttributeId
               }
            }
         );
         Z272AttributeId = Guid.NewGuid( );
         A272AttributeId = Guid.NewGuid( );
         Z407TileId = Guid.NewGuid( );
         A407TileId = Guid.NewGuid( );
         AV59Pgmname = "Trn_Tile";
      }

      private short nRcdDeleted_82 ;
      private short nRcdExists_82 ;
      private short nIsMod_82 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount82 ;
      private short RcdFound82 ;
      private short nBlankRcdUsr82 ;
      private short RcdFound81 ;
      private short nIsDirty_82 ;
      private short subGridlevel_attribute_Backcolorstyle ;
      private short subGridlevel_attribute_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_attribute_Allowselection ;
      private short subGridlevel_attribute_Allowhovering ;
      private short subGridlevel_attribute_Allowcollapsing ;
      private short subGridlevel_attribute_Collapsed ;
      private int nRC_GXsfl_88 ;
      private int nGXsfl_88_idx=1 ;
      private int trnEnded ;
      private int edtProductServiceId_Enabled ;
      private int edtProductServiceDescription_Enabled ;
      private int imgProductServiceImage_Enabled ;
      private int edtTileId_Enabled ;
      private int edtTileName_Enabled ;
      private int edtTileIcon_Enabled ;
      private int edtTileBGColor_Enabled ;
      private int edtTileBGImageUrl_Enabled ;
      private int edtTileTextColor_Enabled ;
      private int edtSG_ToPageId_Visible ;
      private int edtSG_ToPageId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombosg_topageid_Visible ;
      private int edtavCombosg_topageid_Enabled ;
      private int edtAttributeId_Enabled ;
      private int edtAttributeName_Enabled ;
      private int edtAttrbuteValue_Enabled ;
      private int fRowAdded ;
      private int Combo_sg_topageid_Datalistupdateminimumcharacters ;
      private int Combo_sg_topageid_Gxcontroltype ;
      private int AV60GXV1 ;
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
      private string Z401TileIcon ;
      private string Z402TileBGColor ;
      private string Z404TileTextColor ;
      private string Z405TileTextAlignment ;
      private string Z406TileIconAlignment ;
      private string Combo_sg_topageid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProductServiceId_Internalname ;
      private string sGXsfl_88_idx="0001" ;
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
      private string edtProductServiceId_Jsonclick ;
      private string edtProductServiceDescription_Internalname ;
      private string imgProductServiceImage_Internalname ;
      private string sImgUrl ;
      private string edtTileId_Internalname ;
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
      private string divSectionattribute_sg_topageid_Internalname ;
      private string edtavCombosg_topageid_Internalname ;
      private string edtavCombosg_topageid_Jsonclick ;
      private string sMode82 ;
      private string edtAttributeId_Internalname ;
      private string edtAttributeName_Internalname ;
      private string edtAttrbuteValue_Internalname ;
      private string sStyleString ;
      private string subGridlevel_attribute_Internalname ;
      private string AV59Pgmname ;
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
      private string GXCCtl ;
      private string GXt_char2 ;
      private string sGXsfl_88_fel_idx="0001" ;
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
      private bool n29LocationId ;
      private bool n11OrganisationId ;
      private bool wbErr ;
      private bool A61ProductServiceImage_IsBlob ;
      private bool Combo_sg_topageid_Emptyitem ;
      private bool bGXsfl_88_Refreshing=false ;
      private bool n401TileIcon ;
      private bool n402TileBGColor ;
      private bool n403TileBGImageUrl ;
      private bool Combo_sg_topageid_Enabled ;
      private bool Combo_sg_topageid_Visible ;
      private bool Combo_sg_topageid_Allowmultipleselection ;
      private bool Combo_sg_topageid_Isgriditem ;
      private bool Combo_sg_topageid_Hasdescription ;
      private bool Combo_sg_topageid_Includeonlyselectedoption ;
      private bool Combo_sg_topageid_Includeselectalloption ;
      private bool Combo_sg_topageid_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A60ProductServiceDescription ;
      private string AV17Combo_DataJson ;
      private string Z60ProductServiceDescription ;
      private string Z400TileName ;
      private string Z403TileBGImageUrl ;
      private string Z273AttributeName ;
      private string Z274AttrbuteValue ;
      private string A40000ProductServiceImage_GXI ;
      private string A400TileName ;
      private string A403TileBGImageUrl ;
      private string A59ProductServiceName ;
      private string A330SG_ToPageName ;
      private string A273AttributeName ;
      private string A274AttrbuteValue ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private string Z59ProductServiceName ;
      private string Z40000ProductServiceImage_GXI ;
      private string Z330SG_ToPageName ;
      private string A61ProductServiceImage ;
      private string Z61ProductServiceImage ;
      private Guid wcpOAV58TileId ;
      private Guid Z407TileId ;
      private Guid Z58ProductServiceId ;
      private Guid Z29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid Z329SG_ToPageId ;
      private Guid N58ProductServiceId ;
      private Guid N11OrganisationId ;
      private Guid N29LocationId ;
      private Guid N329SG_ToPageId ;
      private Guid Z272AttributeId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A329SG_ToPageId ;
      private Guid AV58TileId ;
      private Guid A407TileId ;
      private Guid AV56ComboSG_ToPageId ;
      private Guid A272AttributeId ;
      private Guid AV20Insert_ProductServiceId ;
      private Guid AV46Insert_OrganisationId ;
      private Guid AV47Insert_LocationId ;
      private Guid AV48Insert_SG_ToPageId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_attributeContainer ;
      private GXWebRow Gridlevel_attributeRow ;
      private GXWebColumn Gridlevel_attributeColumn ;
      private GXUserControl ucCombo_sg_topageid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTileTextAlignment ;
      private GXCombobox cmbTileIconAlignment ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV55SG_ToPageId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV18GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV19GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV21TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000Z8_A59ProductServiceName ;
      private string[] T000Z8_A60ProductServiceDescription ;
      private string[] T000Z8_A40000ProductServiceImage_GXI ;
      private string[] T000Z8_A61ProductServiceImage ;
      private string[] T000Z9_A330SG_ToPageName ;
      private Guid[] T000Z10_A407TileId ;
      private string[] T000Z10_A400TileName ;
      private string[] T000Z10_A401TileIcon ;
      private bool[] T000Z10_n401TileIcon ;
      private string[] T000Z10_A402TileBGColor ;
      private bool[] T000Z10_n402TileBGColor ;
      private string[] T000Z10_A403TileBGImageUrl ;
      private bool[] T000Z10_n403TileBGImageUrl ;
      private string[] T000Z10_A404TileTextColor ;
      private string[] T000Z10_A405TileTextAlignment ;
      private string[] T000Z10_A406TileIconAlignment ;
      private string[] T000Z10_A59ProductServiceName ;
      private string[] T000Z10_A60ProductServiceDescription ;
      private string[] T000Z10_A40000ProductServiceImage_GXI ;
      private string[] T000Z10_A330SG_ToPageName ;
      private Guid[] T000Z10_A58ProductServiceId ;
      private bool[] T000Z10_n58ProductServiceId ;
      private Guid[] T000Z10_A29LocationId ;
      private bool[] T000Z10_n29LocationId ;
      private Guid[] T000Z10_A11OrganisationId ;
      private bool[] T000Z10_n11OrganisationId ;
      private Guid[] T000Z10_A329SG_ToPageId ;
      private string[] T000Z10_A61ProductServiceImage ;
      private Guid[] T000Z7_A29LocationId ;
      private bool[] T000Z7_n29LocationId ;
      private Guid[] T000Z6_A11OrganisationId ;
      private bool[] T000Z6_n11OrganisationId ;
      private string[] T000Z11_A59ProductServiceName ;
      private string[] T000Z11_A60ProductServiceDescription ;
      private string[] T000Z11_A40000ProductServiceImage_GXI ;
      private string[] T000Z11_A61ProductServiceImage ;
      private string[] T000Z12_A330SG_ToPageName ;
      private Guid[] T000Z13_A29LocationId ;
      private bool[] T000Z13_n29LocationId ;
      private Guid[] T000Z14_A11OrganisationId ;
      private bool[] T000Z14_n11OrganisationId ;
      private Guid[] T000Z15_A407TileId ;
      private Guid[] T000Z5_A407TileId ;
      private string[] T000Z5_A400TileName ;
      private string[] T000Z5_A401TileIcon ;
      private bool[] T000Z5_n401TileIcon ;
      private string[] T000Z5_A402TileBGColor ;
      private bool[] T000Z5_n402TileBGColor ;
      private string[] T000Z5_A403TileBGImageUrl ;
      private bool[] T000Z5_n403TileBGImageUrl ;
      private string[] T000Z5_A404TileTextColor ;
      private string[] T000Z5_A405TileTextAlignment ;
      private string[] T000Z5_A406TileIconAlignment ;
      private Guid[] T000Z5_A58ProductServiceId ;
      private bool[] T000Z5_n58ProductServiceId ;
      private Guid[] T000Z5_A29LocationId ;
      private bool[] T000Z5_n29LocationId ;
      private Guid[] T000Z5_A11OrganisationId ;
      private bool[] T000Z5_n11OrganisationId ;
      private Guid[] T000Z5_A329SG_ToPageId ;
      private Guid[] T000Z16_A407TileId ;
      private Guid[] T000Z17_A407TileId ;
      private Guid[] T000Z4_A407TileId ;
      private string[] T000Z4_A400TileName ;
      private string[] T000Z4_A401TileIcon ;
      private bool[] T000Z4_n401TileIcon ;
      private string[] T000Z4_A402TileBGColor ;
      private bool[] T000Z4_n402TileBGColor ;
      private string[] T000Z4_A403TileBGImageUrl ;
      private bool[] T000Z4_n403TileBGImageUrl ;
      private string[] T000Z4_A404TileTextColor ;
      private string[] T000Z4_A405TileTextAlignment ;
      private string[] T000Z4_A406TileIconAlignment ;
      private Guid[] T000Z4_A58ProductServiceId ;
      private bool[] T000Z4_n58ProductServiceId ;
      private Guid[] T000Z4_A29LocationId ;
      private bool[] T000Z4_n29LocationId ;
      private Guid[] T000Z4_A11OrganisationId ;
      private bool[] T000Z4_n11OrganisationId ;
      private Guid[] T000Z4_A329SG_ToPageId ;
      private string[] T000Z21_A330SG_ToPageName ;
      private string[] T000Z22_A59ProductServiceName ;
      private string[] T000Z22_A60ProductServiceDescription ;
      private string[] T000Z22_A40000ProductServiceImage_GXI ;
      private string[] T000Z22_A61ProductServiceImage ;
      private Guid[] T000Z23_A328Trn_ColId ;
      private Guid[] T000Z24_A407TileId ;
      private Guid[] T000Z25_A407TileId ;
      private Guid[] T000Z25_A272AttributeId ;
      private string[] T000Z25_A273AttributeName ;
      private string[] T000Z25_A274AttrbuteValue ;
      private Guid[] T000Z26_A407TileId ;
      private Guid[] T000Z26_A272AttributeId ;
      private Guid[] T000Z3_A407TileId ;
      private Guid[] T000Z3_A272AttributeId ;
      private string[] T000Z3_A273AttributeName ;
      private string[] T000Z3_A274AttrbuteValue ;
      private Guid[] T000Z2_A407TileId ;
      private Guid[] T000Z2_A272AttributeId ;
      private string[] T000Z2_A273AttributeName ;
      private string[] T000Z2_A274AttrbuteValue ;
      private Guid[] T000Z30_A407TileId ;
      private Guid[] T000Z30_A272AttributeId ;
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new ForEachCursor(def[28])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000Z2;
        prmT000Z2 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z3;
        prmT000Z3 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z4;
        prmT000Z4 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z5;
        prmT000Z5 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z6;
        prmT000Z6 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z7;
        prmT000Z7 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z8;
        prmT000Z8 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z9;
        prmT000Z9 = new Object[] {
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z10;
        prmT000Z10 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z11;
        prmT000Z11 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z12;
        prmT000Z12 = new Object[] {
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z13;
        prmT000Z13 = new Object[] {
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z14;
        prmT000Z14 = new Object[] {
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z15;
        prmT000Z15 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z16;
        prmT000Z16 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z17;
        prmT000Z17 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z18;
        prmT000Z18 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("TileName",GXType.VarChar,100,0) ,
        new ParDef("TileIcon",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileBGColor",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileBGImageUrl",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("TileTextColor",GXType.Char,20,0) ,
        new ParDef("TileTextAlignment",GXType.Char,20,0) ,
        new ParDef("TileIconAlignment",GXType.Char,20,0) ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z19;
        prmT000Z19 = new Object[] {
        new ParDef("TileName",GXType.VarChar,100,0) ,
        new ParDef("TileIcon",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileBGColor",GXType.Char,20,0){Nullable=true} ,
        new ParDef("TileBGImageUrl",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("TileTextColor",GXType.Char,20,0) ,
        new ParDef("TileTextAlignment",GXType.Char,20,0) ,
        new ParDef("TileIconAlignment",GXType.Char,20,0) ,
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z20;
        prmT000Z20 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z21;
        prmT000Z21 = new Object[] {
        new ParDef("SG_ToPageId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z22;
        prmT000Z22 = new Object[] {
        new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000Z23;
        prmT000Z23 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z24;
        prmT000Z24 = new Object[] {
        };
        Object[] prmT000Z25;
        prmT000Z25 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z26;
        prmT000Z26 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z27;
        prmT000Z27 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeName",GXType.VarChar,100,0) ,
        new ParDef("AttrbuteValue",GXType.VarChar,100,0)
        };
        Object[] prmT000Z28;
        prmT000Z28 = new Object[] {
        new ParDef("AttributeName",GXType.VarChar,100,0) ,
        new ParDef("AttrbuteValue",GXType.VarChar,100,0) ,
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z29;
        prmT000Z29 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AttributeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Z30;
        prmT000Z30 = new Object[] {
        new ParDef("TileId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000Z2", "SELECT TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE TileId = :TileId AND AttributeId = :AttributeId  FOR UPDATE OF Trn_TileAttribute NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z3", "SELECT TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE TileId = :TileId AND AttributeId = :AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z4", "SELECT TileId, TileName, TileIcon, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIconAlignment, ProductServiceId, LocationId, OrganisationId, SG_ToPageId FROM Trn_Tile WHERE TileId = :TileId  FOR UPDATE OF Trn_Tile NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z5", "SELECT TileId, TileName, TileIcon, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIconAlignment, ProductServiceId, LocationId, OrganisationId, SG_ToPageId FROM Trn_Tile WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z6", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z7", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z8", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z9", "SELECT Trn_PageName AS SG_ToPageName FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z10", "SELECT TM1.TileId, TM1.TileName, TM1.TileIcon, TM1.TileBGColor, TM1.TileBGImageUrl, TM1.TileTextColor, TM1.TileTextAlignment, TM1.TileIconAlignment, T2.ProductServiceName, T2.ProductServiceDescription, T2.ProductServiceImage_GXI, T3.Trn_PageName AS SG_ToPageName, TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId, TM1.SG_ToPageId AS SG_ToPageId, T2.ProductServiceImage FROM ((Trn_Tile TM1 LEFT JOIN Trn_ProductService T2 ON T2.ProductServiceId = TM1.ProductServiceId AND T2.LocationId = TM1.LocationId AND T2.OrganisationId = TM1.OrganisationId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = TM1.SG_ToPageId) WHERE TM1.TileId = :TileId ORDER BY TM1.TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z11", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z12", "SELECT Trn_PageName AS SG_ToPageName FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z13", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z14", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z15", "SELECT TileId FROM Trn_Tile WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z16", "SELECT TileId FROM Trn_Tile WHERE ( TileId > :TileId) ORDER BY TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z17", "SELECT TileId FROM Trn_Tile WHERE ( TileId < :TileId) ORDER BY TileId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z18", "SAVEPOINT gxupdate;INSERT INTO Trn_Tile(TileId, TileName, TileIcon, TileBGColor, TileBGImageUrl, TileTextColor, TileTextAlignment, TileIconAlignment, ProductServiceId, LocationId, OrganisationId, SG_ToPageId) VALUES(:TileId, :TileName, :TileIcon, :TileBGColor, :TileBGImageUrl, :TileTextColor, :TileTextAlignment, :TileIconAlignment, :ProductServiceId, :LocationId, :OrganisationId, :SG_ToPageId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z18)
           ,new CursorDef("T000Z19", "SAVEPOINT gxupdate;UPDATE Trn_Tile SET TileName=:TileName, TileIcon=:TileIcon, TileBGColor=:TileBGColor, TileBGImageUrl=:TileBGImageUrl, TileTextColor=:TileTextColor, TileTextAlignment=:TileTextAlignment, TileIconAlignment=:TileIconAlignment, ProductServiceId=:ProductServiceId, LocationId=:LocationId, OrganisationId=:OrganisationId, SG_ToPageId=:SG_ToPageId  WHERE TileId = :TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z19)
           ,new CursorDef("T000Z20", "SAVEPOINT gxupdate;DELETE FROM Trn_Tile  WHERE TileId = :TileId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z20)
           ,new CursorDef("T000Z21", "SELECT Trn_PageName AS SG_ToPageName FROM Trn_Page WHERE Trn_PageId = :SG_ToPageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z22", "SELECT ProductServiceName, ProductServiceDescription, ProductServiceImage_GXI, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z23", "SELECT Trn_ColId FROM Trn_Col WHERE TileId = :TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z24", "SELECT TileId FROM Trn_Tile ORDER BY TileId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z24,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z25", "SELECT TileId, AttributeId, AttributeName, AttrbuteValue FROM Trn_TileAttribute WHERE TileId = :TileId and AttributeId = :AttributeId ORDER BY TileId, AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z25,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z26", "SELECT TileId, AttributeId FROM Trn_TileAttribute WHERE TileId = :TileId AND AttributeId = :AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z27", "SAVEPOINT gxupdate;INSERT INTO Trn_TileAttribute(TileId, AttributeId, AttributeName, AttrbuteValue) VALUES(:TileId, :AttributeId, :AttributeName, :AttrbuteValue);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Z27)
           ,new CursorDef("T000Z28", "SAVEPOINT gxupdate;UPDATE Trn_TileAttribute SET AttributeName=:AttributeName, AttrbuteValue=:AttrbuteValue  WHERE TileId = :TileId AND AttributeId = :AttributeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z28)
           ,new CursorDef("T000Z29", "SAVEPOINT gxupdate;DELETE FROM Trn_TileAttribute  WHERE TileId = :TileId AND AttributeId = :AttributeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Z29)
           ,new CursorDef("T000Z30", "SELECT TileId, AttributeId FROM Trn_TileAttribute WHERE TileId = :TileId ORDER BY TileId, AttributeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z30,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((string[]) buf[8])[0] = rslt.getString(6, 20);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((Guid[]) buf[11])[0] = rslt.getGuid(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((Guid[]) buf[13])[0] = rslt.getGuid(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((Guid[]) buf[15])[0] = rslt.getGuid(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((Guid[]) buf[17])[0] = rslt.getGuid(12);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((string[]) buf[8])[0] = rslt.getString(6, 20);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((Guid[]) buf[11])[0] = rslt.getGuid(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((Guid[]) buf[13])[0] = rslt.getGuid(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((Guid[]) buf[15])[0] = rslt.getGuid(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((Guid[]) buf[17])[0] = rslt.getGuid(12);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((string[]) buf[8])[0] = rslt.getString(6, 20);
              ((string[]) buf[9])[0] = rslt.getString(7, 20);
              ((string[]) buf[10])[0] = rslt.getString(8, 20);
              ((string[]) buf[11])[0] = rslt.getVarchar(9);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(10);
              ((string[]) buf[13])[0] = rslt.getMultimediaUri(11);
              ((string[]) buf[14])[0] = rslt.getVarchar(12);
              ((Guid[]) buf[15])[0] = rslt.getGuid(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              ((Guid[]) buf[17])[0] = rslt.getGuid(14);
              ((bool[]) buf[18])[0] = rslt.wasNull(14);
              ((Guid[]) buf[19])[0] = rslt.getGuid(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              ((Guid[]) buf[21])[0] = rslt.getGuid(16);
              ((string[]) buf[22])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(11));
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 15 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
              return;
           case 21 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 22 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 23 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 24 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 28 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
     }
  }

}

}
