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
   public class trn_theme : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_color") == 0 )
         {
            gxnrGridlevel_color_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_theme.aspx")), "trn_theme.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_theme.aspx")))) ;
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
                  AV13Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Trn_ThemeId"));
                  AssignAttri("", false, "AV13Trn_ThemeId", AV13Trn_ThemeId.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTRN_THEMEID", GetSecureSignedToken( "", AV13Trn_ThemeId, context));
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
         Form.Meta.addItem("description", context.GetMessage( "Trn_Theme", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_color_newrow_invoke( )
      {
         nRC_GXsfl_45 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_45"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_45_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_45_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_45_idx = GetPar( "sGXsfl_45_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_color_newrow( ) ;
         /* End function gxnrGridlevel_color_newrow_invoke */
      }

      public trn_theme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_theme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_Trn_ThemeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV13Trn_ThemeId = aP1_Trn_ThemeId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbColorName = new GXCombobox();
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
            return "trn_theme_Execute" ;
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
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_Theme.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeId_Internalname, context.GetMessage( "Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeId_Internalname, A247Trn_ThemeId.ToString(), A247Trn_ThemeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeId_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeName_Internalname, A248Trn_ThemeName, StringUtil.RTrim( context.localUtil.Format( A248Trn_ThemeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeFontFamily_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeFontFamily_Internalname, context.GetMessage( "Font Family", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeFontFamily_Internalname, A260Trn_ThemeFontFamily, StringUtil.RTrim( context.localUtil.Format( A260Trn_ThemeFontFamily, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeFontFamily_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeFontFamily_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_ThemeFontSize_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_ThemeFontSize_Internalname, context.GetMessage( "Font Size", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_ThemeFontSize_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A399Trn_ThemeFontSize), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTrn_ThemeFontSize_Enabled!=0) ? context.localUtil.Format( (decimal)(A399Trn_ThemeFontSize), "ZZZ9") : context.localUtil.Format( (decimal)(A399Trn_ThemeFontSize), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_ThemeFontSize_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_ThemeFontSize_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_Theme.htm");
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
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, context.GetMessage( "Colors", ""), "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_color_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_color( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Theme.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_Theme.htm");
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

      protected void gxdraw_Gridlevel_color( )
      {
         /*  Grid Control  */
         StartGridControl45( ) ;
         nGXsfl_45_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount47 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_47 = 1;
               ScanStart0W47( ) ;
               while ( RcdFound47 != 0 )
               {
                  init_level_properties47( ) ;
                  getByPrimaryKey0W47( ) ;
                  AddRow0W47( ) ;
                  ScanNext0W47( ) ;
               }
               ScanEnd0W47( ) ;
               nBlankRcdCount47 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0W47( ) ;
            standaloneModal0W47( ) ;
            sMode47 = Gx_mode;
            while ( nGXsfl_45_idx < nRC_GXsfl_45 )
            {
               bGXsfl_45_Refreshing = true;
               ReadRow0W47( ) ;
               edtColorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORID_"+sGXsfl_45_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_45_Refreshing);
               cmbColorName.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORNAME_"+sGXsfl_45_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbColorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbColorName.Enabled), 5, 0), !bGXsfl_45_Refreshing);
               edtColorCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORCODE_"+sGXsfl_45_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtColorCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorCode_Enabled), 5, 0), !bGXsfl_45_Refreshing);
               if ( ( nRcdExists_47 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0W47( ) ;
               }
               SendRow0W47( ) ;
               bGXsfl_45_Refreshing = false;
            }
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount47 = 5;
            nRcdExists_47 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0W47( ) ;
               while ( RcdFound47 != 0 )
               {
                  sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_4547( ) ;
                  init_level_properties47( ) ;
                  standaloneNotModal0W47( ) ;
                  getByPrimaryKey0W47( ) ;
                  standaloneModal0W47( ) ;
                  AddRow0W47( ) ;
                  ScanNext0W47( ) ;
               }
               ScanEnd0W47( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode47 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx+1), 4, 0), 4, "0");
            SubsflControlProps_4547( ) ;
            InitAll0W47( ) ;
            init_level_properties47( ) ;
            nRcdExists_47 = 0;
            nIsMod_47 = 0;
            nRcdDeleted_47 = 0;
            nBlankRcdCount47 = (short)(nBlankRcdUsr47+nBlankRcdCount47);
            fRowAdded = 0;
            while ( nBlankRcdCount47 > 0 )
            {
               A249ColorId = Guid.Empty;
               standaloneNotModal0W47( ) ;
               standaloneModal0W47( ) ;
               AddRow0W47( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = cmbColorName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount47 = (short)(nBlankRcdCount47-1);
            }
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_colorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_color", Gridlevel_colorContainer, subGridlevel_color_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_colorContainerData", Gridlevel_colorContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_colorContainerData"+"V", Gridlevel_colorContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_colorContainerData"+"V"+"\" value='"+Gridlevel_colorContainer.GridValuesHidden()+"'/>") ;
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
         E110W2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z247Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "Z247Trn_ThemeId"));
               Z248Trn_ThemeName = cgiGet( "Z248Trn_ThemeName");
               Z260Trn_ThemeFontFamily = cgiGet( "Z260Trn_ThemeFontFamily");
               Z399Trn_ThemeFontSize = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z399Trn_ThemeFontSize"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_45 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_45"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Trn_ThemeId = StringUtil.StrToGuid( cgiGet( "vTRN_THEMEID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtTrn_ThemeId_Internalname), "") == 0 )
               {
                  A247Trn_ThemeId = Guid.Empty;
                  AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               }
               else
               {
                  try
                  {
                     A247Trn_ThemeId = StringUtil.StrToGuid( cgiGet( edtTrn_ThemeId_Internalname));
                     AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_THEMEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A248Trn_ThemeName = cgiGet( edtTrn_ThemeName_Internalname);
               AssignAttri("", false, "A248Trn_ThemeName", A248Trn_ThemeName);
               A260Trn_ThemeFontFamily = cgiGet( edtTrn_ThemeFontFamily_Internalname);
               AssignAttri("", false, "A260Trn_ThemeFontFamily", A260Trn_ThemeFontFamily);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTrn_ThemeFontSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrn_ThemeFontSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRN_THEMEFONTSIZE");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_ThemeFontSize_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A399Trn_ThemeFontSize = 0;
                  AssignAttri("", false, "A399Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A399Trn_ThemeFontSize), 4, 0));
               }
               else
               {
                  A399Trn_ThemeFontSize = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTrn_ThemeFontSize_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A399Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A399Trn_ThemeFontSize), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Theme");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A247Trn_ThemeId != Z247Trn_ThemeId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trn_theme:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A247Trn_ThemeId = StringUtil.StrToGuid( GetPar( "Trn_ThemeId"));
                  AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV13Trn_ThemeId) )
                  {
                     A247Trn_ThemeId = AV13Trn_ThemeId;
                     AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) && ( Gx_BScreen == 0 ) )
                     {
                        A247Trn_ThemeId = Guid.NewGuid( );
                        AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
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
                     sMode46 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV13Trn_ThemeId) )
                     {
                        A247Trn_ThemeId = AV13Trn_ThemeId;
                        AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) && ( Gx_BScreen == 0 ) )
                        {
                           A247Trn_ThemeId = Guid.NewGuid( );
                           AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                        }
                     }
                     Gx_mode = sMode46;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound46 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0W0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TRN_THEMEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ThemeId_Internalname;
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
                           E110W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120W2 ();
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
            E120W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0W46( ) ;
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
            DisableAttributes0W46( ) ;
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

      protected void CONFIRM_0W0( )
      {
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0W46( ) ;
            }
            else
            {
               CheckExtendedTable0W46( ) ;
               CloseExtendedTableCursors0W46( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode46 = Gx_mode;
            CONFIRM_0W47( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode46;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0W47( )
      {
         nGXsfl_45_idx = 0;
         while ( nGXsfl_45_idx < nRC_GXsfl_45 )
         {
            ReadRow0W47( ) ;
            if ( ( nRcdExists_47 != 0 ) || ( nIsMod_47 != 0 ) )
            {
               GetKey0W47( ) ;
               if ( ( nRcdExists_47 == 0 ) && ( nRcdDeleted_47 == 0 ) )
               {
                  if ( RcdFound47 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0W47( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0W47( ) ;
                        CloseExtendedTableCursors0W47( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TRN_THEMEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound47 != 0 )
                  {
                     if ( nRcdDeleted_47 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0W47( ) ;
                        Load0W47( ) ;
                        BeforeValidate0W47( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0W47( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_47 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0W47( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0W47( ) ;
                              CloseExtendedTableCursors0W47( ) ;
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
                     if ( nRcdDeleted_47 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_THEMEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ThemeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtColorId_Internalname, A249ColorId.ToString()) ;
            ChangePostValue( cmbColorName_Internalname, A250ColorName) ;
            ChangePostValue( edtColorCode_Internalname, A251ColorCode) ;
            ChangePostValue( "ZT_"+"Z249ColorId_"+sGXsfl_45_idx, Z249ColorId.ToString()) ;
            ChangePostValue( "ZT_"+"Z250ColorName_"+sGXsfl_45_idx, Z250ColorName) ;
            ChangePostValue( "ZT_"+"Z251ColorCode_"+sGXsfl_45_idx, Z251ColorCode) ;
            ChangePostValue( "nRcdDeleted_47_"+sGXsfl_45_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_47_"+sGXsfl_45_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_47_"+sGXsfl_45_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_47 != 0 )
            {
               ChangePostValue( "COLORID_"+sGXsfl_45_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORNAME_"+sGXsfl_45_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORCODE_"+sGXsfl_45_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0W0( )
      {
      }

      protected void E110W2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trn_themeww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0W46( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z248Trn_ThemeName = T000W5_A248Trn_ThemeName[0];
               Z260Trn_ThemeFontFamily = T000W5_A260Trn_ThemeFontFamily[0];
               Z399Trn_ThemeFontSize = T000W5_A399Trn_ThemeFontSize[0];
            }
            else
            {
               Z248Trn_ThemeName = A248Trn_ThemeName;
               Z260Trn_ThemeFontFamily = A260Trn_ThemeFontFamily;
               Z399Trn_ThemeFontSize = A399Trn_ThemeFontSize;
            }
         }
         if ( GX_JID == -8 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z248Trn_ThemeName = A248Trn_ThemeName;
            Z260Trn_ThemeFontFamily = A260Trn_ThemeFontFamily;
            Z399Trn_ThemeFontSize = A399Trn_ThemeFontSize;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV13Trn_ThemeId) )
         {
            edtTrn_ThemeId_Enabled = 0;
            AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
         }
         else
         {
            edtTrn_ThemeId_Enabled = 1;
            AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV13Trn_ThemeId) )
         {
            edtTrn_ThemeId_Enabled = 0;
            AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
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
         if ( ! (Guid.Empty==AV13Trn_ThemeId) )
         {
            A247Trn_ThemeId = AV13Trn_ThemeId;
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A247Trn_ThemeId) && ( Gx_BScreen == 0 ) )
            {
               A247Trn_ThemeId = Guid.NewGuid( );
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W46( )
      {
         /* Using cursor T000W6 */
         pr_default.execute(4, new Object[] {A247Trn_ThemeId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound46 = 1;
            A248Trn_ThemeName = T000W6_A248Trn_ThemeName[0];
            AssignAttri("", false, "A248Trn_ThemeName", A248Trn_ThemeName);
            A260Trn_ThemeFontFamily = T000W6_A260Trn_ThemeFontFamily[0];
            AssignAttri("", false, "A260Trn_ThemeFontFamily", A260Trn_ThemeFontFamily);
            A399Trn_ThemeFontSize = T000W6_A399Trn_ThemeFontSize[0];
            AssignAttri("", false, "A399Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A399Trn_ThemeFontSize), 4, 0));
            ZM0W46( -8) ;
         }
         pr_default.close(4);
         OnLoadActions0W46( ) ;
      }

      protected void OnLoadActions0W46( )
      {
      }

      protected void CheckExtendedTable0W46( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0W46( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0W46( )
      {
         /* Using cursor T000W7 */
         pr_default.execute(5, new Object[] {A247Trn_ThemeId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound46 = 1;
         }
         else
         {
            RcdFound46 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000W5 */
         pr_default.execute(3, new Object[] {A247Trn_ThemeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0W46( 8) ;
            RcdFound46 = 1;
            A247Trn_ThemeId = T000W5_A247Trn_ThemeId[0];
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
            A248Trn_ThemeName = T000W5_A248Trn_ThemeName[0];
            AssignAttri("", false, "A248Trn_ThemeName", A248Trn_ThemeName);
            A260Trn_ThemeFontFamily = T000W5_A260Trn_ThemeFontFamily[0];
            AssignAttri("", false, "A260Trn_ThemeFontFamily", A260Trn_ThemeFontFamily);
            A399Trn_ThemeFontSize = T000W5_A399Trn_ThemeFontSize[0];
            AssignAttri("", false, "A399Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A399Trn_ThemeFontSize), 4, 0));
            Z247Trn_ThemeId = A247Trn_ThemeId;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0W46( ) ;
            if ( AnyError == 1 )
            {
               RcdFound46 = 0;
               InitializeNonKey0W46( ) ;
            }
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound46 = 0;
            InitializeNonKey0W46( ) ;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W46( ) ;
         if ( RcdFound46 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound46 = 0;
         /* Using cursor T000W8 */
         pr_default.execute(6, new Object[] {A247Trn_ThemeId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000W8_A247Trn_ThemeId[0], A247Trn_ThemeId, 0) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000W8_A247Trn_ThemeId[0], A247Trn_ThemeId, 0) > 0 ) ) )
            {
               A247Trn_ThemeId = T000W8_A247Trn_ThemeId[0];
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               RcdFound46 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound46 = 0;
         /* Using cursor T000W9 */
         pr_default.execute(7, new Object[] {A247Trn_ThemeId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000W9_A247Trn_ThemeId[0], A247Trn_ThemeId, 0) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000W9_A247Trn_ThemeId[0], A247Trn_ThemeId, 0) < 0 ) ) )
            {
               A247Trn_ThemeId = T000W9_A247Trn_ThemeId[0];
               AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
               RcdFound46 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0W46( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0W46( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound46 == 1 )
            {
               if ( A247Trn_ThemeId != Z247Trn_ThemeId )
               {
                  A247Trn_ThemeId = Z247Trn_ThemeId;
                  AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRN_THEMEID");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0W46( ) ;
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A247Trn_ThemeId != Z247Trn_ThemeId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTrn_ThemeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0W46( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_THEMEID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTrn_ThemeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0W46( ) ;
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
         if ( A247Trn_ThemeId != Z247Trn_ThemeId )
         {
            A247Trn_ThemeId = Z247Trn_ThemeId;
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRN_THEMEID");
            AnyError = 1;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrn_ThemeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0W46( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000W4 */
            pr_default.execute(2, new Object[] {A247Trn_ThemeId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z248Trn_ThemeName, T000W4_A248Trn_ThemeName[0]) != 0 ) || ( StringUtil.StrCmp(Z260Trn_ThemeFontFamily, T000W4_A260Trn_ThemeFontFamily[0]) != 0 ) || ( Z399Trn_ThemeFontSize != T000W4_A399Trn_ThemeFontSize[0] ) )
            {
               if ( StringUtil.StrCmp(Z248Trn_ThemeName, T000W4_A248Trn_ThemeName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"Trn_ThemeName");
                  GXUtil.WriteLogRaw("Old: ",Z248Trn_ThemeName);
                  GXUtil.WriteLogRaw("Current: ",T000W4_A248Trn_ThemeName[0]);
               }
               if ( StringUtil.StrCmp(Z260Trn_ThemeFontFamily, T000W4_A260Trn_ThemeFontFamily[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"Trn_ThemeFontFamily");
                  GXUtil.WriteLogRaw("Old: ",Z260Trn_ThemeFontFamily);
                  GXUtil.WriteLogRaw("Current: ",T000W4_A260Trn_ThemeFontFamily[0]);
               }
               if ( Z399Trn_ThemeFontSize != T000W4_A399Trn_ThemeFontSize[0] )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"Trn_ThemeFontSize");
                  GXUtil.WriteLogRaw("Old: ",Z399Trn_ThemeFontSize);
                  GXUtil.WriteLogRaw("Current: ",T000W4_A399Trn_ThemeFontSize[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Theme"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W46( )
      {
         if ( ! IsAuthorized("trn_theme_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W46( 0) ;
            CheckOptimisticConcurrency0W46( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W46( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W46( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W10 */
                     pr_default.execute(8, new Object[] {A247Trn_ThemeId, A248Trn_ThemeName, A260Trn_ThemeFontFamily, A399Trn_ThemeFontSize});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
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
                           ProcessLevel0W46( ) ;
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
               Load0W46( ) ;
            }
            EndLevel0W46( ) ;
         }
         CloseExtendedTableCursors0W46( ) ;
      }

      protected void Update0W46( )
      {
         if ( ! IsAuthorized("trn_theme_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W46( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W46( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W46( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W11 */
                     pr_default.execute(9, new Object[] {A248Trn_ThemeName, A260Trn_ThemeFontFamily, A399Trn_ThemeFontSize, A247Trn_ThemeId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W46( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0W46( ) ;
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
            EndLevel0W46( ) ;
         }
         CloseExtendedTableCursors0W46( ) ;
      }

      protected void DeferredUpdate0W46( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_theme_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W46( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W46( ) ;
            AfterConfirm0W46( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W46( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0W47( ) ;
                  while ( RcdFound47 != 0 )
                  {
                     getByPrimaryKey0W47( ) ;
                     Delete0W47( ) ;
                     ScanNext0W47( ) ;
                  }
                  ScanEnd0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W12 */
                     pr_default.execute(10, new Object[] {A247Trn_ThemeId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
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
         sMode46 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0W46( ) ;
         Gx_mode = sMode46;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0W46( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel0W47( )
      {
         nGXsfl_45_idx = 0;
         while ( nGXsfl_45_idx < nRC_GXsfl_45 )
         {
            ReadRow0W47( ) ;
            if ( ( nRcdExists_47 != 0 ) || ( nIsMod_47 != 0 ) )
            {
               standaloneNotModal0W47( ) ;
               GetKey0W47( ) ;
               if ( ( nRcdExists_47 == 0 ) && ( nRcdDeleted_47 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0W47( ) ;
               }
               else
               {
                  if ( RcdFound47 != 0 )
                  {
                     if ( ( nRcdDeleted_47 != 0 ) && ( nRcdExists_47 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0W47( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_47 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0W47( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_47 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_THEMEID");
                        AnyError = 1;
                        GX_FocusControl = edtTrn_ThemeId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtColorId_Internalname, A249ColorId.ToString()) ;
            ChangePostValue( cmbColorName_Internalname, A250ColorName) ;
            ChangePostValue( edtColorCode_Internalname, A251ColorCode) ;
            ChangePostValue( "ZT_"+"Z249ColorId_"+sGXsfl_45_idx, Z249ColorId.ToString()) ;
            ChangePostValue( "ZT_"+"Z250ColorName_"+sGXsfl_45_idx, Z250ColorName) ;
            ChangePostValue( "ZT_"+"Z251ColorCode_"+sGXsfl_45_idx, Z251ColorCode) ;
            ChangePostValue( "nRcdDeleted_47_"+sGXsfl_45_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_47_"+sGXsfl_45_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_47_"+sGXsfl_45_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_47), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_47 != 0 )
            {
               ChangePostValue( "COLORID_"+sGXsfl_45_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORNAME_"+sGXsfl_45_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COLORCODE_"+sGXsfl_45_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0W47( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_47 = 0;
         nIsMod_47 = 0;
         nRcdDeleted_47 = 0;
      }

      protected void ProcessLevel0W46( )
      {
         /* Save parent mode. */
         sMode46 = Gx_mode;
         ProcessNestedLevel0W47( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode46;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0W46( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W46( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_theme",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_theme",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0W46( )
      {
         /* Scan By routine */
         /* Using cursor T000W13 */
         pr_default.execute(11);
         RcdFound46 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound46 = 1;
            A247Trn_ThemeId = T000W13_A247Trn_ThemeId[0];
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0W46( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound46 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound46 = 1;
            A247Trn_ThemeId = T000W13_A247Trn_ThemeId[0];
            AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         }
      }

      protected void ScanEnd0W46( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0W46( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W46( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W46( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W46( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W46( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W46( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W46( )
      {
         edtTrn_ThemeId_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeId_Enabled), 5, 0), true);
         edtTrn_ThemeName_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeName_Enabled), 5, 0), true);
         edtTrn_ThemeFontFamily_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeFontFamily_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeFontFamily_Enabled), 5, 0), true);
         edtTrn_ThemeFontSize_Enabled = 0;
         AssignProp("", false, edtTrn_ThemeFontSize_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_ThemeFontSize_Enabled), 5, 0), true);
      }

      protected void ZM0W47( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z250ColorName = T000W3_A250ColorName[0];
               Z251ColorCode = T000W3_A251ColorCode[0];
            }
            else
            {
               Z250ColorName = A250ColorName;
               Z251ColorCode = A251ColorCode;
            }
         }
         if ( GX_JID == -9 )
         {
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z249ColorId = A249ColorId;
            Z250ColorName = A250ColorName;
            Z251ColorCode = A251ColorCode;
         }
      }

      protected void standaloneNotModal0W47( )
      {
         edtColorId_Enabled = 0;
         AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_45_Refreshing);
      }

      protected void standaloneModal0W47( )
      {
         if ( IsIns( )  && (Guid.Empty==A249ColorId) && ( Gx_BScreen == 0 ) )
         {
            A249ColorId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W47( )
      {
         /* Using cursor T000W14 */
         pr_default.execute(12, new Object[] {A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound47 = 1;
            A250ColorName = T000W14_A250ColorName[0];
            A251ColorCode = T000W14_A251ColorCode[0];
            ZM0W47( -9) ;
         }
         pr_default.close(12);
         OnLoadActions0W47( ) ;
      }

      protected void OnLoadActions0W47( )
      {
      }

      protected void CheckExtendedTable0W47( )
      {
         nIsDirty_47 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0W47( ) ;
      }

      protected void CloseExtendedTableCursors0W47( )
      {
      }

      protected void enableDisable0W47( )
      {
      }

      protected void GetKey0W47( )
      {
         /* Using cursor T000W15 */
         pr_default.execute(13, new Object[] {A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound47 = 1;
         }
         else
         {
            RcdFound47 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey0W47( )
      {
         /* Using cursor T000W3 */
         pr_default.execute(1, new Object[] {A247Trn_ThemeId, A249ColorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W47( 9) ;
            RcdFound47 = 1;
            InitializeNonKey0W47( ) ;
            A249ColorId = T000W3_A249ColorId[0];
            A250ColorName = T000W3_A250ColorName[0];
            A251ColorCode = T000W3_A251ColorCode[0];
            Z247Trn_ThemeId = A247Trn_ThemeId;
            Z249ColorId = A249ColorId;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0W47( ) ;
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound47 = 0;
            InitializeNonKey0W47( ) ;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0W47( ) ;
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0W47( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0W47( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000W2 */
            pr_default.execute(0, new Object[] {A247Trn_ThemeId, A249ColorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z250ColorName, T000W2_A250ColorName[0]) != 0 ) || ( StringUtil.StrCmp(Z251ColorCode, T000W2_A251ColorCode[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z250ColorName, T000W2_A250ColorName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"ColorName");
                  GXUtil.WriteLogRaw("Old: ",Z250ColorName);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A250ColorName[0]);
               }
               if ( StringUtil.StrCmp(Z251ColorCode, T000W2_A251ColorCode[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_theme:[seudo value changed for attri]"+"ColorCode");
                  GXUtil.WriteLogRaw("Old: ",Z251ColorCode);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A251ColorCode[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeColor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W47( )
      {
         if ( ! IsAuthorized("trn_theme_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W47( 0) ;
            CheckOptimisticConcurrency0W47( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W47( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W16 */
                     pr_default.execute(14, new Object[] {A247Trn_ThemeId, A249ColorId, A250ColorName, A251ColorCode});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                     if ( (pr_default.getStatus(14) == 1) )
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
               Load0W47( ) ;
            }
            EndLevel0W47( ) ;
         }
         CloseExtendedTableCursors0W47( ) ;
      }

      protected void Update0W47( )
      {
         if ( ! IsAuthorized("trn_theme_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W47( ) ;
         }
         if ( ( nIsMod_47 != 0 ) || ( nIsDirty_47 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0W47( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0W47( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000W17 */
                        pr_default.execute(15, new Object[] {A250ColorName, A251ColorCode, A247Trn_ThemeId, A249ColorId});
                        pr_default.close(15);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                        if ( (pr_default.getStatus(15) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0W47( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0W47( ) ;
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
               EndLevel0W47( ) ;
            }
         }
         CloseExtendedTableCursors0W47( ) ;
      }

      protected void DeferredUpdate0W47( )
      {
      }

      protected void Delete0W47( )
      {
         if ( ! IsAuthorized("trn_theme_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W47( ) ;
            AfterConfirm0W47( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W47( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000W18 */
                  pr_default.execute(16, new Object[] {A247Trn_ThemeId, A249ColorId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
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
         sMode47 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0W47( ) ;
         Gx_mode = sMode47;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0W47( )
      {
         standaloneModal0W47( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0W47( )
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

      public void ScanStart0W47( )
      {
         /* Scan By routine */
         /* Using cursor T000W19 */
         pr_default.execute(17, new Object[] {A247Trn_ThemeId});
         RcdFound47 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound47 = 1;
            A249ColorId = T000W19_A249ColorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0W47( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound47 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound47 = 1;
            A249ColorId = T000W19_A249ColorId[0];
         }
      }

      protected void ScanEnd0W47( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0W47( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W47( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W47( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W47( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W47( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W47( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W47( )
      {
         edtColorId_Enabled = 0;
         AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_45_Refreshing);
         cmbColorName.Enabled = 0;
         AssignProp("", false, cmbColorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbColorName.Enabled), 5, 0), !bGXsfl_45_Refreshing);
         edtColorCode_Enabled = 0;
         AssignProp("", false, edtColorCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorCode_Enabled), 5, 0), !bGXsfl_45_Refreshing);
      }

      protected void send_integrity_lvl_hashes0W47( )
      {
      }

      protected void send_integrity_lvl_hashes0W46( )
      {
      }

      protected void SubsflControlProps_4547( )
      {
         edtColorId_Internalname = "COLORID_"+sGXsfl_45_idx;
         cmbColorName_Internalname = "COLORNAME_"+sGXsfl_45_idx;
         edtColorCode_Internalname = "COLORCODE_"+sGXsfl_45_idx;
      }

      protected void SubsflControlProps_fel_4547( )
      {
         edtColorId_Internalname = "COLORID_"+sGXsfl_45_fel_idx;
         cmbColorName_Internalname = "COLORNAME_"+sGXsfl_45_fel_idx;
         edtColorCode_Internalname = "COLORCODE_"+sGXsfl_45_fel_idx;
      }

      protected void AddRow0W47( )
      {
         nGXsfl_45_idx = (int)(nGXsfl_45_idx+1);
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_4547( ) ;
         SendRow0W47( ) ;
      }

      protected void SendRow0W47( )
      {
         Gridlevel_colorRow = GXWebRow.GetNew(context);
         if ( subGridlevel_color_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_color_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
            {
               subGridlevel_color_Linesclass = subGridlevel_color_Class+"Odd";
            }
         }
         else if ( subGridlevel_color_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_color_Backstyle = 0;
            subGridlevel_color_Backcolor = subGridlevel_color_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
            {
               subGridlevel_color_Linesclass = subGridlevel_color_Class+"Uniform";
            }
         }
         else if ( subGridlevel_color_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_color_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
            {
               subGridlevel_color_Linesclass = subGridlevel_color_Class+"Odd";
            }
            subGridlevel_color_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_color_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_color_Backstyle = 1;
            if ( ((int)((nGXsfl_45_idx) % (2))) == 0 )
            {
               subGridlevel_color_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
               {
                  subGridlevel_color_Linesclass = subGridlevel_color_Class+"Even";
               }
            }
            else
            {
               subGridlevel_color_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_color_Class, "") != 0 )
               {
                  subGridlevel_color_Linesclass = subGridlevel_color_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_colorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtColorId_Internalname,A249ColorId.ToString(),A249ColorId.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtColorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtColorId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)45,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_47_" + sGXsfl_45_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_45_idx + "',45)\"";
         if ( ( cmbColorName.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "COLORNAME_" + sGXsfl_45_idx;
            cmbColorName.Name = GXCCtl;
            cmbColorName.WebTags = "";
            cmbColorName.addItem("cardBgColor", context.GetMessage( "Card BG Color", ""), 0);
            cmbColorName.addItem("ButtonBgColor", context.GetMessage( "Button Bg Color", ""), 0);
            cmbColorName.addItem("secondaryColor", context.GetMessage( "Secondary Color", ""), 0);
            cmbColorName.addItem("borderColor", context.GetMessage( "Border Color", ""), 0);
            cmbColorName.addItem("backgroundColor", context.GetMessage( "Background Color", ""), 0);
            cmbColorName.addItem("textColor", context.GetMessage( "Text Color", ""), 0);
            cmbColorName.addItem("cardTextColor", context.GetMessage( "Card Text Color", ""), 0);
            cmbColorName.addItem("accentColor", context.GetMessage( "Accent Color", ""), 0);
            cmbColorName.addItem("buttonTextColor", context.GetMessage( "Button Text Color", ""), 0);
            cmbColorName.addItem("primaryColor", context.GetMessage( "Primary Color", ""), 0);
            if ( cmbColorName.ItemCount > 0 )
            {
               A250ColorName = cmbColorName.getValidValue(A250ColorName);
            }
         }
         /* ComboBox */
         Gridlevel_colorRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbColorName,(string)cmbColorName_Internalname,StringUtil.RTrim( A250ColorName),(short)1,(string)cmbColorName_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbColorName.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"",(string)"",(bool)true,(short)0});
         cmbColorName.CurrentValue = StringUtil.RTrim( A250ColorName);
         AssignProp("", false, cmbColorName_Internalname, "Values", (string)(cmbColorName.ToJavascriptSource()), !bGXsfl_45_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_47_" + sGXsfl_45_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_45_idx + "',45)\"";
         ROClassString = "Attribute";
         Gridlevel_colorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtColorCode_Internalname,(string)A251ColorCode,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtColorCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtColorCode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_colorRow);
         send_integrity_lvl_hashes0W47( ) ;
         GXCCtl = "Z249ColorId_" + sGXsfl_45_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z249ColorId.ToString());
         GXCCtl = "Z250ColorName_" + sGXsfl_45_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z250ColorName);
         GXCCtl = "Z251ColorCode_" + sGXsfl_45_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z251ColorCode);
         GXCCtl = "nRcdDeleted_47_" + sGXsfl_45_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_47), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_47_" + sGXsfl_45_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_47), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_47_" + sGXsfl_45_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_47), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_45_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_45_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTRN_THEMEID_" + sGXsfl_45_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV13Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "COLORID_"+sGXsfl_45_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COLORNAME_"+sGXsfl_45_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COLORCODE_"+sGXsfl_45_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_colorContainer.AddRow(Gridlevel_colorRow);
      }

      protected void ReadRow0W47( )
      {
         nGXsfl_45_idx = (int)(nGXsfl_45_idx+1);
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_4547( ) ;
         edtColorId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORID_"+sGXsfl_45_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbColorName.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORNAME_"+sGXsfl_45_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtColorCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COLORCODE_"+sGXsfl_45_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A249ColorId = StringUtil.StrToGuid( cgiGet( edtColorId_Internalname));
         cmbColorName.Name = cmbColorName_Internalname;
         cmbColorName.CurrentValue = cgiGet( cmbColorName_Internalname);
         A250ColorName = cgiGet( cmbColorName_Internalname);
         A251ColorCode = cgiGet( edtColorCode_Internalname);
         GXCCtl = "Z249ColorId_" + sGXsfl_45_idx;
         Z249ColorId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z250ColorName_" + sGXsfl_45_idx;
         Z250ColorName = cgiGet( GXCCtl);
         GXCCtl = "Z251ColorCode_" + sGXsfl_45_idx;
         Z251ColorCode = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_47_" + sGXsfl_45_idx;
         nRcdDeleted_47 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_47_" + sGXsfl_45_idx;
         nRcdExists_47 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_47_" + sGXsfl_45_idx;
         nIsMod_47 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtColorId_Enabled = edtColorId_Enabled;
      }

      protected void ConfirmValues0W0( )
      {
         nGXsfl_45_idx = 0;
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_4547( ) ;
         while ( nGXsfl_45_idx < nRC_GXsfl_45 )
         {
            nGXsfl_45_idx = (int)(nGXsfl_45_idx+1);
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_4547( ) ;
            ChangePostValue( "Z249ColorId_"+sGXsfl_45_idx, cgiGet( "ZT_"+"Z249ColorId_"+sGXsfl_45_idx)) ;
            DeletePostValue( "ZT_"+"Z249ColorId_"+sGXsfl_45_idx) ;
            ChangePostValue( "Z250ColorName_"+sGXsfl_45_idx, cgiGet( "ZT_"+"Z250ColorName_"+sGXsfl_45_idx)) ;
            DeletePostValue( "ZT_"+"Z250ColorName_"+sGXsfl_45_idx) ;
            ChangePostValue( "Z251ColorCode_"+sGXsfl_45_idx, cgiGet( "ZT_"+"Z251ColorCode_"+sGXsfl_45_idx)) ;
            DeletePostValue( "ZT_"+"Z251ColorCode_"+sGXsfl_45_idx) ;
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
         GXEncryptionTmp = "trn_theme.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV13Trn_ThemeId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_theme.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Trn_Theme");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_theme:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z247Trn_ThemeId", Z247Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "Z248Trn_ThemeName", Z248Trn_ThemeName);
         GxWebStd.gx_hidden_field( context, "Z260Trn_ThemeFontFamily", Z260Trn_ThemeFontFamily);
         GxWebStd.gx_hidden_field( context, "Z399Trn_ThemeFontSize", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z399Trn_ThemeFontSize), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_45", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_45_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vTRN_THEMEID", AV13Trn_ThemeId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTRN_THEMEID", GetSecureSignedToken( "", AV13Trn_ThemeId, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GXEncryptionTmp = "trn_theme.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV13Trn_ThemeId.ToString());
         return formatLink("trn_theme.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Trn_Theme" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Theme", "") ;
      }

      protected void InitializeNonKey0W46( )
      {
         A248Trn_ThemeName = "";
         AssignAttri("", false, "A248Trn_ThemeName", A248Trn_ThemeName);
         A260Trn_ThemeFontFamily = "";
         AssignAttri("", false, "A260Trn_ThemeFontFamily", A260Trn_ThemeFontFamily);
         A399Trn_ThemeFontSize = 0;
         AssignAttri("", false, "A399Trn_ThemeFontSize", StringUtil.LTrimStr( (decimal)(A399Trn_ThemeFontSize), 4, 0));
         Z248Trn_ThemeName = "";
         Z260Trn_ThemeFontFamily = "";
         Z399Trn_ThemeFontSize = 0;
      }

      protected void InitAll0W46( )
      {
         A247Trn_ThemeId = Guid.NewGuid( );
         AssignAttri("", false, "A247Trn_ThemeId", A247Trn_ThemeId.ToString());
         InitializeNonKey0W46( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0W47( )
      {
         A250ColorName = "";
         A251ColorCode = "";
         Z250ColorName = "";
         Z251ColorCode = "";
      }

      protected void InitAll0W47( )
      {
         A249ColorId = Guid.NewGuid( );
         InitializeNonKey0W47( ) ;
      }

      protected void StandaloneModalInsert0W47( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202410281710979", true, true);
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
         context.AddJavascriptSource("trn_theme.js", "?202410281710979", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties47( )
      {
         edtColorId_Enabled = defedtColorId_Enabled;
         AssignProp("", false, edtColorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtColorId_Enabled), 5, 0), !bGXsfl_45_Refreshing);
      }

      protected void StartGridControl45( )
      {
         Gridlevel_colorContainer.AddObjectProperty("GridName", "Gridlevel_color");
         Gridlevel_colorContainer.AddObjectProperty("Header", subGridlevel_color_Header);
         Gridlevel_colorContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_colorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_colorContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_colorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_colorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A249ColorId.ToString()));
         Gridlevel_colorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorId_Enabled), 5, 0, ".", "")));
         Gridlevel_colorContainer.AddColumnProperties(Gridlevel_colorColumn);
         Gridlevel_colorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_colorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A250ColorName));
         Gridlevel_colorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbColorName.Enabled), 5, 0, ".", "")));
         Gridlevel_colorContainer.AddColumnProperties(Gridlevel_colorColumn);
         Gridlevel_colorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_colorColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A251ColorCode));
         Gridlevel_colorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtColorCode_Enabled), 5, 0, ".", "")));
         Gridlevel_colorContainer.AddColumnProperties(Gridlevel_colorColumn);
         Gridlevel_colorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Selectedindex), 4, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Allowselection), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Allowhovering), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_colorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_color_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtTrn_ThemeId_Internalname = "TRN_THEMEID";
         edtTrn_ThemeName_Internalname = "TRN_THEMENAME";
         edtTrn_ThemeFontFamily_Internalname = "TRN_THEMEFONTFAMILY";
         edtTrn_ThemeFontSize_Internalname = "TRN_THEMEFONTSIZE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtColorId_Internalname = "COLORID";
         cmbColorName_Internalname = "COLORNAME";
         edtColorCode_Internalname = "COLORCODE";
         divTableleaflevel_color_Internalname = "TABLELEAFLEVEL_COLOR";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_color_Internalname = "GRIDLEVEL_COLOR";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_color_Allowcollapsing = 0;
         subGridlevel_color_Allowselection = 0;
         subGridlevel_color_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_Theme", "");
         edtColorCode_Jsonclick = "";
         cmbColorName_Jsonclick = "";
         edtColorId_Jsonclick = "";
         subGridlevel_color_Class = "WorkWith";
         subGridlevel_color_Backcolorstyle = 0;
         edtColorCode_Enabled = 1;
         cmbColorName.Enabled = 1;
         edtColorId_Enabled = 0;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTrn_ThemeFontSize_Jsonclick = "";
         edtTrn_ThemeFontSize_Enabled = 1;
         edtTrn_ThemeFontFamily_Jsonclick = "";
         edtTrn_ThemeFontFamily_Enabled = 1;
         edtTrn_ThemeName_Jsonclick = "";
         edtTrn_ThemeName_Enabled = 1;
         edtTrn_ThemeId_Jsonclick = "";
         edtTrn_ThemeId_Enabled = 1;
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

      protected void gxnrGridlevel_color_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_4547( ) ;
         while ( nGXsfl_45_idx <= nRC_GXsfl_45 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0W47( ) ;
            standaloneModal0W47( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0W47( ) ;
            nGXsfl_45_idx = (int)(nGXsfl_45_idx+1);
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_4547( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_colorContainer)) ;
         /* End function gxnrGridlevel_color_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "COLORNAME_" + sGXsfl_45_idx;
         cmbColorName.Name = GXCCtl;
         cmbColorName.WebTags = "";
         cmbColorName.addItem("cardBgColor", context.GetMessage( "Card BG Color", ""), 0);
         cmbColorName.addItem("ButtonBgColor", context.GetMessage( "Button Bg Color", ""), 0);
         cmbColorName.addItem("secondaryColor", context.GetMessage( "Secondary Color", ""), 0);
         cmbColorName.addItem("borderColor", context.GetMessage( "Border Color", ""), 0);
         cmbColorName.addItem("backgroundColor", context.GetMessage( "Background Color", ""), 0);
         cmbColorName.addItem("textColor", context.GetMessage( "Text Color", ""), 0);
         cmbColorName.addItem("cardTextColor", context.GetMessage( "Card Text Color", ""), 0);
         cmbColorName.addItem("accentColor", context.GetMessage( "Accent Color", ""), 0);
         cmbColorName.addItem("buttonTextColor", context.GetMessage( "Button Text Color", ""), 0);
         cmbColorName.addItem("primaryColor", context.GetMessage( "Primary Color", ""), 0);
         if ( cmbColorName.ItemCount > 0 )
         {
            A250ColorName = cmbColorName.getValidValue(A250ColorName);
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV13Trn_ThemeId","fld":"vTRN_THEMEID","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV13Trn_ThemeId","fld":"vTRN_THEMEID","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120W2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_TRN_THEMEID","""{"handler":"Valid_Trn_themeid","iparms":[]}""");
         setEventMetadata("VALID_COLORID","""{"handler":"Valid_Colorid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Colorcode","iparms":[]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV13Trn_ThemeId = Guid.Empty;
         Z247Trn_ThemeId = Guid.Empty;
         Z248Trn_ThemeName = "";
         Z260Trn_ThemeFontFamily = "";
         Z249ColorId = Guid.Empty;
         Z250ColorName = "";
         Z251ColorCode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A247Trn_ThemeId = Guid.Empty;
         A248Trn_ThemeName = "";
         A260Trn_ThemeFontFamily = "";
         lblTextblock1_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_colorContainer = new GXWebGrid( context);
         sMode47 = "";
         A249ColorId = Guid.Empty;
         sStyleString = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode46 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A250ColorName = "";
         A251ColorCode = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000W6_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W6_A248Trn_ThemeName = new string[] {""} ;
         T000W6_A260Trn_ThemeFontFamily = new string[] {""} ;
         T000W6_A399Trn_ThemeFontSize = new short[1] ;
         T000W7_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W5_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W5_A248Trn_ThemeName = new string[] {""} ;
         T000W5_A260Trn_ThemeFontFamily = new string[] {""} ;
         T000W5_A399Trn_ThemeFontSize = new short[1] ;
         T000W8_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W9_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W4_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W4_A248Trn_ThemeName = new string[] {""} ;
         T000W4_A260Trn_ThemeFontFamily = new string[] {""} ;
         T000W4_A399Trn_ThemeFontSize = new short[1] ;
         T000W13_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W14_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W14_A249ColorId = new Guid[] {Guid.Empty} ;
         T000W14_A250ColorName = new string[] {""} ;
         T000W14_A251ColorCode = new string[] {""} ;
         T000W15_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W15_A249ColorId = new Guid[] {Guid.Empty} ;
         T000W3_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W3_A249ColorId = new Guid[] {Guid.Empty} ;
         T000W3_A250ColorName = new string[] {""} ;
         T000W3_A251ColorCode = new string[] {""} ;
         T000W2_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W2_A249ColorId = new Guid[] {Guid.Empty} ;
         T000W2_A250ColorName = new string[] {""} ;
         T000W2_A251ColorCode = new string[] {""} ;
         T000W19_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         T000W19_A249ColorId = new Guid[] {Guid.Empty} ;
         Gridlevel_colorRow = new GXWebRow();
         subGridlevel_color_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         Gridlevel_colorColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_theme__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_theme__default(),
            new Object[][] {
                new Object[] {
               T000W2_A247Trn_ThemeId, T000W2_A249ColorId, T000W2_A250ColorName, T000W2_A251ColorCode
               }
               , new Object[] {
               T000W3_A247Trn_ThemeId, T000W3_A249ColorId, T000W3_A250ColorName, T000W3_A251ColorCode
               }
               , new Object[] {
               T000W4_A247Trn_ThemeId, T000W4_A248Trn_ThemeName, T000W4_A260Trn_ThemeFontFamily, T000W4_A399Trn_ThemeFontSize
               }
               , new Object[] {
               T000W5_A247Trn_ThemeId, T000W5_A248Trn_ThemeName, T000W5_A260Trn_ThemeFontFamily, T000W5_A399Trn_ThemeFontSize
               }
               , new Object[] {
               T000W6_A247Trn_ThemeId, T000W6_A248Trn_ThemeName, T000W6_A260Trn_ThemeFontFamily, T000W6_A399Trn_ThemeFontSize
               }
               , new Object[] {
               T000W7_A247Trn_ThemeId
               }
               , new Object[] {
               T000W8_A247Trn_ThemeId
               }
               , new Object[] {
               T000W9_A247Trn_ThemeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000W13_A247Trn_ThemeId
               }
               , new Object[] {
               T000W14_A247Trn_ThemeId, T000W14_A249ColorId, T000W14_A250ColorName, T000W14_A251ColorCode
               }
               , new Object[] {
               T000W15_A247Trn_ThemeId, T000W15_A249ColorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000W19_A247Trn_ThemeId, T000W19_A249ColorId
               }
            }
         );
         Z249ColorId = Guid.NewGuid( );
         A249ColorId = Guid.NewGuid( );
         Z247Trn_ThemeId = Guid.NewGuid( );
         A247Trn_ThemeId = Guid.NewGuid( );
      }

      private short Z399Trn_ThemeFontSize ;
      private short nRcdDeleted_47 ;
      private short nRcdExists_47 ;
      private short nIsMod_47 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short A399Trn_ThemeFontSize ;
      private short nBlankRcdCount47 ;
      private short RcdFound47 ;
      private short nBlankRcdUsr47 ;
      private short RcdFound46 ;
      private short nIsDirty_47 ;
      private short subGridlevel_color_Backcolorstyle ;
      private short subGridlevel_color_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_color_Allowselection ;
      private short subGridlevel_color_Allowhovering ;
      private short subGridlevel_color_Allowcollapsing ;
      private short subGridlevel_color_Collapsed ;
      private int nRC_GXsfl_45 ;
      private int nGXsfl_45_idx=1 ;
      private int trnEnded ;
      private int edtTrn_ThemeId_Enabled ;
      private int edtTrn_ThemeName_Enabled ;
      private int edtTrn_ThemeFontFamily_Enabled ;
      private int edtTrn_ThemeFontSize_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtColorId_Enabled ;
      private int edtColorCode_Enabled ;
      private int fRowAdded ;
      private int subGridlevel_color_Backcolor ;
      private int subGridlevel_color_Allbackcolor ;
      private int defedtColorId_Enabled ;
      private int idxLst ;
      private int subGridlevel_color_Selectedindex ;
      private int subGridlevel_color_Selectioncolor ;
      private int subGridlevel_color_Hoveringcolor ;
      private long GRIDLEVEL_COLOR_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrn_ThemeId_Internalname ;
      private string sGXsfl_45_idx="0001" ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTrn_ThemeId_Jsonclick ;
      private string edtTrn_ThemeName_Internalname ;
      private string edtTrn_ThemeName_Jsonclick ;
      private string edtTrn_ThemeFontFamily_Internalname ;
      private string edtTrn_ThemeFontFamily_Jsonclick ;
      private string edtTrn_ThemeFontSize_Internalname ;
      private string edtTrn_ThemeFontSize_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTableleaflevel_color_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode47 ;
      private string edtColorId_Internalname ;
      private string cmbColorName_Internalname ;
      private string edtColorCode_Internalname ;
      private string sStyleString ;
      private string subGridlevel_color_Internalname ;
      private string hsh ;
      private string sMode46 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sGXsfl_45_fel_idx="0001" ;
      private string subGridlevel_color_Class ;
      private string subGridlevel_color_Linesclass ;
      private string ROClassString ;
      private string edtColorId_Jsonclick ;
      private string GXCCtl ;
      private string cmbColorName_Jsonclick ;
      private string edtColorCode_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string subGridlevel_color_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_45_Refreshing=false ;
      private bool returnInSub ;
      private string Z248Trn_ThemeName ;
      private string Z260Trn_ThemeFontFamily ;
      private string Z250ColorName ;
      private string Z251ColorCode ;
      private string A248Trn_ThemeName ;
      private string A260Trn_ThemeFontFamily ;
      private string A250ColorName ;
      private string A251ColorCode ;
      private Guid wcpOAV13Trn_ThemeId ;
      private Guid Z247Trn_ThemeId ;
      private Guid Z249ColorId ;
      private Guid AV13Trn_ThemeId ;
      private Guid A247Trn_ThemeId ;
      private Guid A249ColorId ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_colorContainer ;
      private GXWebRow Gridlevel_colorRow ;
      private GXWebColumn Gridlevel_colorColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbColorName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000W6_A247Trn_ThemeId ;
      private string[] T000W6_A248Trn_ThemeName ;
      private string[] T000W6_A260Trn_ThemeFontFamily ;
      private short[] T000W6_A399Trn_ThemeFontSize ;
      private Guid[] T000W7_A247Trn_ThemeId ;
      private Guid[] T000W5_A247Trn_ThemeId ;
      private string[] T000W5_A248Trn_ThemeName ;
      private string[] T000W5_A260Trn_ThemeFontFamily ;
      private short[] T000W5_A399Trn_ThemeFontSize ;
      private Guid[] T000W8_A247Trn_ThemeId ;
      private Guid[] T000W9_A247Trn_ThemeId ;
      private Guid[] T000W4_A247Trn_ThemeId ;
      private string[] T000W4_A248Trn_ThemeName ;
      private string[] T000W4_A260Trn_ThemeFontFamily ;
      private short[] T000W4_A399Trn_ThemeFontSize ;
      private Guid[] T000W13_A247Trn_ThemeId ;
      private Guid[] T000W14_A247Trn_ThemeId ;
      private Guid[] T000W14_A249ColorId ;
      private string[] T000W14_A250ColorName ;
      private string[] T000W14_A251ColorCode ;
      private Guid[] T000W15_A247Trn_ThemeId ;
      private Guid[] T000W15_A249ColorId ;
      private Guid[] T000W3_A247Trn_ThemeId ;
      private Guid[] T000W3_A249ColorId ;
      private string[] T000W3_A250ColorName ;
      private string[] T000W3_A251ColorCode ;
      private Guid[] T000W2_A247Trn_ThemeId ;
      private Guid[] T000W2_A249ColorId ;
      private string[] T000W2_A250ColorName ;
      private string[] T000W2_A251ColorCode ;
      private Guid[] T000W19_A247Trn_ThemeId ;
      private Guid[] T000W19_A249ColorId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_theme__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_theme__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000W2;
        prmT000W2 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W3;
        prmT000W3 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W4;
        prmT000W4 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W5;
        prmT000W5 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W6;
        prmT000W6 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W7;
        prmT000W7 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W8;
        prmT000W8 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W9;
        prmT000W9 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W10;
        prmT000W10 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
        new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
        new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0)
        };
        Object[] prmT000W11;
        prmT000W11 = new Object[] {
        new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
        new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
        new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0) ,
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W12;
        prmT000W12 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W13;
        prmT000W13 = new Object[] {
        };
        Object[] prmT000W14;
        prmT000W14 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W15;
        prmT000W15 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W16;
        prmT000W16 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorName",GXType.VarChar,100,0) ,
        new ParDef("ColorCode",GXType.VarChar,100,0)
        };
        Object[] prmT000W17;
        prmT000W17 = new Object[] {
        new ParDef("ColorName",GXType.VarChar,100,0) ,
        new ParDef("ColorCode",GXType.VarChar,100,0) ,
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W18;
        prmT000W18 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
        new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000W19;
        prmT000W19 = new Object[] {
        new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000W2", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId  FOR UPDATE OF Trn_ThemeColor NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W3", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W4", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId  FOR UPDATE OF Trn_Theme NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W5", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W6", "SELECT TM1.Trn_ThemeId, TM1.Trn_ThemeName, TM1.Trn_ThemeFontFamily, TM1.Trn_ThemeFontSize FROM Trn_Theme TM1 WHERE TM1.Trn_ThemeId = :Trn_ThemeId ORDER BY TM1.Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W7", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W8", "SELECT Trn_ThemeId FROM Trn_Theme WHERE ( Trn_ThemeId > :Trn_ThemeId) ORDER BY Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W9", "SELECT Trn_ThemeId FROM Trn_Theme WHERE ( Trn_ThemeId < :Trn_ThemeId) ORDER BY Trn_ThemeId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W10", "SAVEPOINT gxupdate;INSERT INTO Trn_Theme(Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize) VALUES(:Trn_ThemeId, :Trn_ThemeName, :Trn_ThemeFontFamily, :Trn_ThemeFontSize);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000W10)
           ,new CursorDef("T000W11", "SAVEPOINT gxupdate;UPDATE Trn_Theme SET Trn_ThemeName=:Trn_ThemeName, Trn_ThemeFontFamily=:Trn_ThemeFontFamily, Trn_ThemeFontSize=:Trn_ThemeFontSize  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W11)
           ,new CursorDef("T000W12", "SAVEPOINT gxupdate;DELETE FROM Trn_Theme  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W12)
           ,new CursorDef("T000W13", "SELECT Trn_ThemeId FROM Trn_Theme ORDER BY Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W14", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W14,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W15", "SELECT Trn_ThemeId, ColorId FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W16", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeColor(Trn_ThemeId, ColorId, ColorName, ColorCode) VALUES(:Trn_ThemeId, :ColorId, :ColorName, :ColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000W16)
           ,new CursorDef("T000W17", "SAVEPOINT gxupdate;UPDATE Trn_ThemeColor SET ColorName=:ColorName, ColorCode=:ColorCode  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W17)
           ,new CursorDef("T000W18", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeColor  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000W18)
           ,new CursorDef("T000W19", "SELECT Trn_ThemeId, ColorId FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W19,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
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
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 17 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
     }
  }

}

}
