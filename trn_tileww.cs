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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_tileww : GXDataArea
   {
      public trn_tileww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_tileww( IGxContext context )
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
         cmbTileTextAlignment = new GXCombobox();
         cmbTileIconAlignment = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV19ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV72Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV56TFTileName = GetPar( "TFTileName");
         AV57TFTileName_Sel = GetPar( "TFTileName_Sel");
         AV58TFTileIcon = GetPar( "TFTileIcon");
         AV59TFTileIcon_Sel = GetPar( "TFTileIcon_Sel");
         AV60TFTileBGColor = GetPar( "TFTileBGColor");
         AV61TFTileBGColor_Sel = GetPar( "TFTileBGColor_Sel");
         AV62TFTileBGImageUrl = GetPar( "TFTileBGImageUrl");
         AV63TFTileBGImageUrl_Sel = GetPar( "TFTileBGImageUrl_Sel");
         AV64TFTileTextColor = GetPar( "TFTileTextColor");
         AV65TFTileTextColor_Sel = GetPar( "TFTileTextColor_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV67TFTileTextAlignment_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV69TFTileIconAlignment_Sels);
         AV28TFProductServiceName = GetPar( "TFProductServiceName");
         AV29TFProductServiceName_Sel = GetPar( "TFProductServiceName_Sel");
         AV51TFSG_ToPageName = GetPar( "TFSG_ToPageName");
         AV52TFSG_ToPageName_Sel = GetPar( "TFSG_ToPageName_Sel");
         AV45IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV47IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV49IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV70IsAuthorized_TileName = StringUtil.StrToBool( GetPar( "IsAuthorized_TileName"));
         AV42IsAuthorized_ProductServiceName = StringUtil.StrToBool( GetPar( "IsAuthorized_ProductServiceName"));
         AV53IsAuthorized_SG_ToPageName = StringUtil.StrToBool( GetPar( "IsAuthorized_SG_ToPageName"));
         AV50IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV72Pgmname, AV15FilterFullText, AV56TFTileName, AV57TFTileName_Sel, AV58TFTileIcon, AV59TFTileIcon_Sel, AV60TFTileBGColor, AV61TFTileBGColor_Sel, AV62TFTileBGImageUrl, AV63TFTileBGImageUrl_Sel, AV64TFTileTextColor, AV65TFTileTextColor_Sel, AV67TFTileTextAlignment_Sels, AV69TFTileIconAlignment_Sels, AV28TFProductServiceName, AV29TFProductServiceName_Sel, AV51TFSG_ToPageName, AV52TFSG_ToPageName_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV70IsAuthorized_TileName, AV42IsAuthorized_ProductServiceName, AV53IsAuthorized_SG_ToPageName, AV50IsAuthorized_Insert) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return "trn_tileww_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA5Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5Z2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_tileww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV72Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV72Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TILENAME", AV70IsAuthorized_TileName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TILENAME", GetSecureSignedToken( "", AV70IsAuthorized_TileName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PRODUCTSERVICENAME", AV42IsAuthorized_ProductServiceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICENAME", GetSecureSignedToken( "", AV42IsAuthorized_ProductServiceName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SG_TOPAGENAME", AV53IsAuthorized_SG_ToPageName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SG_TOPAGENAME", GetSecureSignedToken( "", AV53IsAuthorized_SG_ToPageName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV40GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV72Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV72Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFTILENAME", AV56TFTileName);
         GxWebStd.gx_hidden_field( context, "vTFTILENAME_SEL", AV57TFTileName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTILEICON", StringUtil.RTrim( AV58TFTileIcon));
         GxWebStd.gx_hidden_field( context, "vTFTILEICON_SEL", StringUtil.RTrim( AV59TFTileIcon_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTILEBGCOLOR", StringUtil.RTrim( AV60TFTileBGColor));
         GxWebStd.gx_hidden_field( context, "vTFTILEBGCOLOR_SEL", StringUtil.RTrim( AV61TFTileBGColor_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTILEBGIMAGEURL", AV62TFTileBGImageUrl);
         GxWebStd.gx_hidden_field( context, "vTFTILEBGIMAGEURL_SEL", AV63TFTileBGImageUrl_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTILETEXTCOLOR", StringUtil.RTrim( AV64TFTileTextColor));
         GxWebStd.gx_hidden_field( context, "vTFTILETEXTCOLOR_SEL", StringUtil.RTrim( AV65TFTileTextColor_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFTILETEXTALIGNMENT_SELS", AV67TFTileTextAlignment_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFTILETEXTALIGNMENT_SELS", AV67TFTileTextAlignment_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFTILEICONALIGNMENT_SELS", AV69TFTileIconAlignment_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFTILEICONALIGNMENT_SELS", AV69TFTileIconAlignment_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFPRODUCTSERVICENAME", AV28TFProductServiceName);
         GxWebStd.gx_hidden_field( context, "vTFPRODUCTSERVICENAME_SEL", AV29TFProductServiceName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSG_TOPAGENAME", AV51TFSG_ToPageName);
         GxWebStd.gx_hidden_field( context, "vTFSG_TOPAGENAME_SEL", AV52TFSG_ToPageName_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TILENAME", AV70IsAuthorized_TileName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TILENAME", GetSecureSignedToken( "", AV70IsAuthorized_TileName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PRODUCTSERVICENAME", AV42IsAuthorized_ProductServiceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICENAME", GetSecureSignedToken( "", AV42IsAuthorized_ProductServiceName, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SG_TOPAGENAME", AV53IsAuthorized_SG_ToPageName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SG_TOPAGENAME", GetSecureSignedToken( "", AV53IsAuthorized_SG_ToPageName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFTILETEXTALIGNMENT_SELSJSON", AV66TFTileTextAlignment_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFTILEICONALIGNMENT_SELSJSON", AV68TFTileIconAlignment_SelsJson);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE5Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5Z2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("trn_tileww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_TileWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Tile", "") ;
      }

      protected void WB5Z0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_TileWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_TileWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV17ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_Trn_TileWW.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV38GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV39GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV40GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0065"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0065"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_37_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0065"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START5Z2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( " Tile", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5Z0( ) ;
      }

      protected void WS5Z2( )
      {
         START5Z2( ) ;
         EVT5Z2( ) ;
      }

      protected void EVT5Z2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E115Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E125Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E135Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E145Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E155Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E165Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              A407TileId = StringUtil.StrToGuid( cgiGet( edtTileId_Internalname));
                              A400TileName = cgiGet( edtTileName_Internalname);
                              A401TileIcon = cgiGet( edtTileIcon_Internalname);
                              n401TileIcon = false;
                              A402TileBGColor = cgiGet( edtTileBGColor_Internalname);
                              n402TileBGColor = false;
                              A403TileBGImageUrl = cgiGet( edtTileBGImageUrl_Internalname);
                              n403TileBGImageUrl = false;
                              A404TileTextColor = cgiGet( edtTileTextColor_Internalname);
                              cmbTileTextAlignment.Name = cmbTileTextAlignment_Internalname;
                              cmbTileTextAlignment.CurrentValue = cgiGet( cmbTileTextAlignment_Internalname);
                              A405TileTextAlignment = cgiGet( cmbTileTextAlignment_Internalname);
                              cmbTileIconAlignment.Name = cmbTileIconAlignment_Internalname;
                              cmbTileIconAlignment.CurrentValue = cgiGet( cmbTileIconAlignment_Internalname);
                              A406TileIconAlignment = cgiGet( cmbTileIconAlignment_Internalname);
                              A58ProductServiceId = StringUtil.StrToGuid( cgiGet( edtProductServiceId_Internalname));
                              n58ProductServiceId = false;
                              A59ProductServiceName = cgiGet( edtProductServiceName_Internalname);
                              A60ProductServiceDescription = cgiGet( edtProductServiceDescription_Internalname);
                              A61ProductServiceImage = cgiGet( edtProductServiceImage_Internalname);
                              AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
                              AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
                              A329SG_ToPageId = StringUtil.StrToGuid( cgiGet( edtSG_ToPageId_Internalname));
                              A330SG_ToPageName = cgiGet( edtSG_ToPageName_Internalname);
                              AV44Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV44Display);
                              AV46Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV46Update);
                              AV48Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV48Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E175Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E185Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E195Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 65 )
                        {
                           OldWwpaux_wc = cgiGet( "W0065");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0065", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5Z2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA5Z2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       short AV19ManageFiltersExecutionStep ,
                                       string AV72Pgmname ,
                                       string AV15FilterFullText ,
                                       string AV56TFTileName ,
                                       string AV57TFTileName_Sel ,
                                       string AV58TFTileIcon ,
                                       string AV59TFTileIcon_Sel ,
                                       string AV60TFTileBGColor ,
                                       string AV61TFTileBGColor_Sel ,
                                       string AV62TFTileBGImageUrl ,
                                       string AV63TFTileBGImageUrl_Sel ,
                                       string AV64TFTileTextColor ,
                                       string AV65TFTileTextColor_Sel ,
                                       GxSimpleCollection<string> AV67TFTileTextAlignment_Sels ,
                                       GxSimpleCollection<string> AV69TFTileIconAlignment_Sels ,
                                       string AV28TFProductServiceName ,
                                       string AV29TFProductServiceName_Sel ,
                                       string AV51TFSG_ToPageName ,
                                       string AV52TFSG_ToPageName_Sel ,
                                       bool AV45IsAuthorized_Display ,
                                       bool AV47IsAuthorized_Update ,
                                       bool AV49IsAuthorized_Delete ,
                                       bool AV70IsAuthorized_TileName ,
                                       bool AV42IsAuthorized_ProductServiceName ,
                                       bool AV53IsAuthorized_SG_ToPageName ,
                                       bool AV50IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5Z2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TILEID", GetSecureSignedToken( "", A407TileId, context));
         GxWebStd.gx_hidden_field( context, "TILEID", A407TileId.ToString());
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
         RF5Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV72Pgmname = "Trn_TileWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV73Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV74Trn_tilewwds_2_tftilename = AV56TFTileName;
         AV75Trn_tilewwds_3_tftilename_sel = AV57TFTileName_Sel;
         AV76Trn_tilewwds_4_tftileicon = AV58TFTileIcon;
         AV77Trn_tilewwds_5_tftileicon_sel = AV59TFTileIcon_Sel;
         AV78Trn_tilewwds_6_tftilebgcolor = AV60TFTileBGColor;
         AV79Trn_tilewwds_7_tftilebgcolor_sel = AV61TFTileBGColor_Sel;
         AV80Trn_tilewwds_8_tftilebgimageurl = AV62TFTileBGImageUrl;
         AV81Trn_tilewwds_9_tftilebgimageurl_sel = AV63TFTileBGImageUrl_Sel;
         AV82Trn_tilewwds_10_tftiletextcolor = AV64TFTileTextColor;
         AV83Trn_tilewwds_11_tftiletextcolor_sel = AV65TFTileTextColor_Sel;
         AV84Trn_tilewwds_12_tftiletextalignment_sels = AV67TFTileTextAlignment_Sels;
         AV85Trn_tilewwds_13_tftileiconalignment_sels = AV69TFTileIconAlignment_Sels;
         AV86Trn_tilewwds_14_tfproductservicename = AV28TFProductServiceName;
         AV87Trn_tilewwds_15_tfproductservicename_sel = AV29TFProductServiceName_Sel;
         AV88Trn_tilewwds_16_tfsg_topagename = AV51TFSG_ToPageName;
         AV89Trn_tilewwds_17_tfsg_topagename_sel = AV52TFSG_ToPageName_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A405TileTextAlignment ,
                                              AV84Trn_tilewwds_12_tftiletextalignment_sels ,
                                              A406TileIconAlignment ,
                                              AV85Trn_tilewwds_13_tftileiconalignment_sels ,
                                              AV75Trn_tilewwds_3_tftilename_sel ,
                                              AV74Trn_tilewwds_2_tftilename ,
                                              AV77Trn_tilewwds_5_tftileicon_sel ,
                                              AV76Trn_tilewwds_4_tftileicon ,
                                              AV79Trn_tilewwds_7_tftilebgcolor_sel ,
                                              AV78Trn_tilewwds_6_tftilebgcolor ,
                                              AV81Trn_tilewwds_9_tftilebgimageurl_sel ,
                                              AV80Trn_tilewwds_8_tftilebgimageurl ,
                                              AV83Trn_tilewwds_11_tftiletextcolor_sel ,
                                              AV82Trn_tilewwds_10_tftiletextcolor ,
                                              AV84Trn_tilewwds_12_tftiletextalignment_sels.Count ,
                                              AV85Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                              AV87Trn_tilewwds_15_tfproductservicename_sel ,
                                              AV86Trn_tilewwds_14_tfproductservicename ,
                                              AV89Trn_tilewwds_17_tfsg_topagename_sel ,
                                              AV88Trn_tilewwds_16_tfsg_topagename ,
                                              A400TileName ,
                                              A401TileIcon ,
                                              A402TileBGColor ,
                                              A403TileBGImageUrl ,
                                              A404TileTextColor ,
                                              A59ProductServiceName ,
                                              A330SG_ToPageName ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV73Trn_tilewwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV74Trn_tilewwds_2_tftilename), "%", "");
         lV76Trn_tilewwds_4_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV76Trn_tilewwds_4_tftileicon), 20, "%");
         lV78Trn_tilewwds_6_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV78Trn_tilewwds_6_tftilebgcolor), 20, "%");
         lV80Trn_tilewwds_8_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV80Trn_tilewwds_8_tftilebgimageurl), "%", "");
         lV82Trn_tilewwds_10_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV82Trn_tilewwds_10_tftiletextcolor), 20, "%");
         lV86Trn_tilewwds_14_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV86Trn_tilewwds_14_tfproductservicename), "%", "");
         lV88Trn_tilewwds_16_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV88Trn_tilewwds_16_tfsg_topagename), "%", "");
         /* Using cursor H005Z2 */
         pr_default.execute(0, new Object[] {lV74Trn_tilewwds_2_tftilename, AV75Trn_tilewwds_3_tftilename_sel, lV76Trn_tilewwds_4_tftileicon, AV77Trn_tilewwds_5_tftileicon_sel, lV78Trn_tilewwds_6_tftilebgcolor, AV79Trn_tilewwds_7_tftilebgcolor_sel, lV80Trn_tilewwds_8_tftilebgimageurl, AV81Trn_tilewwds_9_tftilebgimageurl_sel, lV82Trn_tilewwds_10_tftiletextcolor, AV83Trn_tilewwds_11_tftiletextcolor_sel, lV86Trn_tilewwds_14_tfproductservicename, AV87Trn_tilewwds_15_tfproductservicename_sel, lV88Trn_tilewwds_16_tfsg_topagename, AV89Trn_tilewwds_17_tfsg_topagename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = H005Z2_A11OrganisationId[0];
            n11OrganisationId = H005Z2_n11OrganisationId[0];
            A29LocationId = H005Z2_A29LocationId[0];
            n29LocationId = H005Z2_n29LocationId[0];
            A330SG_ToPageName = H005Z2_A330SG_ToPageName[0];
            A329SG_ToPageId = H005Z2_A329SG_ToPageId[0];
            A40000ProductServiceImage_GXI = H005Z2_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
            AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A60ProductServiceDescription = H005Z2_A60ProductServiceDescription[0];
            A59ProductServiceName = H005Z2_A59ProductServiceName[0];
            A58ProductServiceId = H005Z2_A58ProductServiceId[0];
            n58ProductServiceId = H005Z2_n58ProductServiceId[0];
            A406TileIconAlignment = H005Z2_A406TileIconAlignment[0];
            A405TileTextAlignment = H005Z2_A405TileTextAlignment[0];
            A404TileTextColor = H005Z2_A404TileTextColor[0];
            A403TileBGImageUrl = H005Z2_A403TileBGImageUrl[0];
            n403TileBGImageUrl = H005Z2_n403TileBGImageUrl[0];
            A402TileBGColor = H005Z2_A402TileBGColor[0];
            n402TileBGColor = H005Z2_n402TileBGColor[0];
            A401TileIcon = H005Z2_A401TileIcon[0];
            n401TileIcon = H005Z2_n401TileIcon[0];
            A400TileName = H005Z2_A400TileName[0];
            A407TileId = H005Z2_A407TileId[0];
            A61ProductServiceImage = H005Z2_A61ProductServiceImage[0];
            AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
            AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A330SG_ToPageName = H005Z2_A330SG_ToPageName[0];
            A40000ProductServiceImage_GXI = H005Z2_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
            AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A60ProductServiceDescription = H005Z2_A60ProductServiceDescription[0];
            A59ProductServiceName = H005Z2_A59ProductServiceName[0];
            A61ProductServiceImage = H005Z2_A61ProductServiceImage[0];
            AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
            AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "center", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, "center") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "left", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A405TileTextAlignment, "left") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "right", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, "right") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "center", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, "center") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "left", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A406TileIconAlignment, "left") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "right", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, "right") == 0 ) ) ||
            ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A330SG_ToPageName , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
            )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF5Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E185Z2 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_372( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A405TileTextAlignment ,
                                                 AV84Trn_tilewwds_12_tftiletextalignment_sels ,
                                                 A406TileIconAlignment ,
                                                 AV85Trn_tilewwds_13_tftileiconalignment_sels ,
                                                 AV75Trn_tilewwds_3_tftilename_sel ,
                                                 AV74Trn_tilewwds_2_tftilename ,
                                                 AV77Trn_tilewwds_5_tftileicon_sel ,
                                                 AV76Trn_tilewwds_4_tftileicon ,
                                                 AV79Trn_tilewwds_7_tftilebgcolor_sel ,
                                                 AV78Trn_tilewwds_6_tftilebgcolor ,
                                                 AV81Trn_tilewwds_9_tftilebgimageurl_sel ,
                                                 AV80Trn_tilewwds_8_tftilebgimageurl ,
                                                 AV83Trn_tilewwds_11_tftiletextcolor_sel ,
                                                 AV82Trn_tilewwds_10_tftiletextcolor ,
                                                 AV84Trn_tilewwds_12_tftiletextalignment_sels.Count ,
                                                 AV85Trn_tilewwds_13_tftileiconalignment_sels.Count ,
                                                 AV87Trn_tilewwds_15_tfproductservicename_sel ,
                                                 AV86Trn_tilewwds_14_tfproductservicename ,
                                                 AV89Trn_tilewwds_17_tfsg_topagename_sel ,
                                                 AV88Trn_tilewwds_16_tfsg_topagename ,
                                                 A400TileName ,
                                                 A401TileIcon ,
                                                 A402TileBGColor ,
                                                 A403TileBGImageUrl ,
                                                 A404TileTextColor ,
                                                 A59ProductServiceName ,
                                                 A330SG_ToPageName ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV73Trn_tilewwds_1_filterfulltext } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV74Trn_tilewwds_2_tftilename = StringUtil.Concat( StringUtil.RTrim( AV74Trn_tilewwds_2_tftilename), "%", "");
            lV76Trn_tilewwds_4_tftileicon = StringUtil.PadR( StringUtil.RTrim( AV76Trn_tilewwds_4_tftileicon), 20, "%");
            lV78Trn_tilewwds_6_tftilebgcolor = StringUtil.PadR( StringUtil.RTrim( AV78Trn_tilewwds_6_tftilebgcolor), 20, "%");
            lV80Trn_tilewwds_8_tftilebgimageurl = StringUtil.Concat( StringUtil.RTrim( AV80Trn_tilewwds_8_tftilebgimageurl), "%", "");
            lV82Trn_tilewwds_10_tftiletextcolor = StringUtil.PadR( StringUtil.RTrim( AV82Trn_tilewwds_10_tftiletextcolor), 20, "%");
            lV86Trn_tilewwds_14_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV86Trn_tilewwds_14_tfproductservicename), "%", "");
            lV88Trn_tilewwds_16_tfsg_topagename = StringUtil.Concat( StringUtil.RTrim( AV88Trn_tilewwds_16_tfsg_topagename), "%", "");
            /* Using cursor H005Z3 */
            pr_default.execute(1, new Object[] {lV74Trn_tilewwds_2_tftilename, AV75Trn_tilewwds_3_tftilename_sel, lV76Trn_tilewwds_4_tftileicon, AV77Trn_tilewwds_5_tftileicon_sel, lV78Trn_tilewwds_6_tftilebgcolor, AV79Trn_tilewwds_7_tftilebgcolor_sel, lV80Trn_tilewwds_8_tftilebgimageurl, AV81Trn_tilewwds_9_tftilebgimageurl_sel, lV82Trn_tilewwds_10_tftiletextcolor, AV83Trn_tilewwds_11_tftiletextcolor_sel, lV86Trn_tilewwds_14_tfproductservicename, AV87Trn_tilewwds_15_tfproductservicename_sel, lV88Trn_tilewwds_16_tfsg_topagename, AV89Trn_tilewwds_17_tfsg_topagename_sel});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A11OrganisationId = H005Z3_A11OrganisationId[0];
               n11OrganisationId = H005Z3_n11OrganisationId[0];
               A29LocationId = H005Z3_A29LocationId[0];
               n29LocationId = H005Z3_n29LocationId[0];
               A330SG_ToPageName = H005Z3_A330SG_ToPageName[0];
               A329SG_ToPageId = H005Z3_A329SG_ToPageId[0];
               A40000ProductServiceImage_GXI = H005Z3_A40000ProductServiceImage_GXI[0];
               AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
               A60ProductServiceDescription = H005Z3_A60ProductServiceDescription[0];
               A59ProductServiceName = H005Z3_A59ProductServiceName[0];
               A58ProductServiceId = H005Z3_A58ProductServiceId[0];
               n58ProductServiceId = H005Z3_n58ProductServiceId[0];
               A406TileIconAlignment = H005Z3_A406TileIconAlignment[0];
               A405TileTextAlignment = H005Z3_A405TileTextAlignment[0];
               A404TileTextColor = H005Z3_A404TileTextColor[0];
               A403TileBGImageUrl = H005Z3_A403TileBGImageUrl[0];
               n403TileBGImageUrl = H005Z3_n403TileBGImageUrl[0];
               A402TileBGColor = H005Z3_A402TileBGColor[0];
               n402TileBGColor = H005Z3_n402TileBGColor[0];
               A401TileIcon = H005Z3_A401TileIcon[0];
               n401TileIcon = H005Z3_n401TileIcon[0];
               A400TileName = H005Z3_A400TileName[0];
               A407TileId = H005Z3_A407TileId[0];
               A61ProductServiceImage = H005Z3_A61ProductServiceImage[0];
               AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
               A330SG_ToPageName = H005Z3_A330SG_ToPageName[0];
               A40000ProductServiceImage_GXI = H005Z3_A40000ProductServiceImage_GXI[0];
               AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
               A60ProductServiceDescription = H005Z3_A60ProductServiceDescription[0];
               A59ProductServiceName = H005Z3_A59ProductServiceName[0];
               A61ProductServiceImage = H005Z3_A61ProductServiceImage[0];
               AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_tilewwds_1_filterfulltext)) || ( ( StringUtil.Like( A400TileName , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A401TileIcon , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( A402TileBGColor , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A403TileBGImageUrl , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 1000 , "%"),  ' ' ) ) || ( StringUtil.Like( A404TileTextColor , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "center", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, "center") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "left", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A405TileTextAlignment, "left") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "right", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A405TileTextAlignment, "right") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "center", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, "center") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "left", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A406TileIconAlignment, "left") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "right", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Trn_tilewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A406TileIconAlignment, "right") == 0 ) ) ||
               ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A330SG_ToPageName , StringUtil.PadR( "%" + AV73Trn_tilewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E195Z2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WB5Z0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5Z2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV72Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV72Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TILENAME", AV70IsAuthorized_TileName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TILENAME", GetSecureSignedToken( "", AV70IsAuthorized_TileName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PRODUCTSERVICENAME", AV42IsAuthorized_ProductServiceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICENAME", GetSecureSignedToken( "", AV42IsAuthorized_ProductServiceName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SG_TOPAGENAME", AV53IsAuthorized_SG_ToPageName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SG_TOPAGENAME", GetSecureSignedToken( "", AV53IsAuthorized_SG_ToPageName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TILEID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A407TileId, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(subGridclient_rec_count_fnc()) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV73Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV74Trn_tilewwds_2_tftilename = AV56TFTileName;
         AV75Trn_tilewwds_3_tftilename_sel = AV57TFTileName_Sel;
         AV76Trn_tilewwds_4_tftileicon = AV58TFTileIcon;
         AV77Trn_tilewwds_5_tftileicon_sel = AV59TFTileIcon_Sel;
         AV78Trn_tilewwds_6_tftilebgcolor = AV60TFTileBGColor;
         AV79Trn_tilewwds_7_tftilebgcolor_sel = AV61TFTileBGColor_Sel;
         AV80Trn_tilewwds_8_tftilebgimageurl = AV62TFTileBGImageUrl;
         AV81Trn_tilewwds_9_tftilebgimageurl_sel = AV63TFTileBGImageUrl_Sel;
         AV82Trn_tilewwds_10_tftiletextcolor = AV64TFTileTextColor;
         AV83Trn_tilewwds_11_tftiletextcolor_sel = AV65TFTileTextColor_Sel;
         AV84Trn_tilewwds_12_tftiletextalignment_sels = AV67TFTileTextAlignment_Sels;
         AV85Trn_tilewwds_13_tftileiconalignment_sels = AV69TFTileIconAlignment_Sels;
         AV86Trn_tilewwds_14_tfproductservicename = AV28TFProductServiceName;
         AV87Trn_tilewwds_15_tfproductservicename_sel = AV29TFProductServiceName_Sel;
         AV88Trn_tilewwds_16_tfsg_topagename = AV51TFSG_ToPageName;
         AV89Trn_tilewwds_17_tfsg_topagename_sel = AV52TFSG_ToPageName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV72Pgmname, AV15FilterFullText, AV56TFTileName, AV57TFTileName_Sel, AV58TFTileIcon, AV59TFTileIcon_Sel, AV60TFTileBGColor, AV61TFTileBGColor_Sel, AV62TFTileBGImageUrl, AV63TFTileBGImageUrl_Sel, AV64TFTileTextColor, AV65TFTileTextColor_Sel, AV67TFTileTextAlignment_Sels, AV69TFTileIconAlignment_Sels, AV28TFProductServiceName, AV29TFProductServiceName_Sel, AV51TFSG_ToPageName, AV52TFSG_ToPageName_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV70IsAuthorized_TileName, AV42IsAuthorized_ProductServiceName, AV53IsAuthorized_SG_ToPageName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV73Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV74Trn_tilewwds_2_tftilename = AV56TFTileName;
         AV75Trn_tilewwds_3_tftilename_sel = AV57TFTileName_Sel;
         AV76Trn_tilewwds_4_tftileicon = AV58TFTileIcon;
         AV77Trn_tilewwds_5_tftileicon_sel = AV59TFTileIcon_Sel;
         AV78Trn_tilewwds_6_tftilebgcolor = AV60TFTileBGColor;
         AV79Trn_tilewwds_7_tftilebgcolor_sel = AV61TFTileBGColor_Sel;
         AV80Trn_tilewwds_8_tftilebgimageurl = AV62TFTileBGImageUrl;
         AV81Trn_tilewwds_9_tftilebgimageurl_sel = AV63TFTileBGImageUrl_Sel;
         AV82Trn_tilewwds_10_tftiletextcolor = AV64TFTileTextColor;
         AV83Trn_tilewwds_11_tftiletextcolor_sel = AV65TFTileTextColor_Sel;
         AV84Trn_tilewwds_12_tftiletextalignment_sels = AV67TFTileTextAlignment_Sels;
         AV85Trn_tilewwds_13_tftileiconalignment_sels = AV69TFTileIconAlignment_Sels;
         AV86Trn_tilewwds_14_tfproductservicename = AV28TFProductServiceName;
         AV87Trn_tilewwds_15_tfproductservicename_sel = AV29TFProductServiceName_Sel;
         AV88Trn_tilewwds_16_tfsg_topagename = AV51TFSG_ToPageName;
         AV89Trn_tilewwds_17_tfsg_topagename_sel = AV52TFSG_ToPageName_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV72Pgmname, AV15FilterFullText, AV56TFTileName, AV57TFTileName_Sel, AV58TFTileIcon, AV59TFTileIcon_Sel, AV60TFTileBGColor, AV61TFTileBGColor_Sel, AV62TFTileBGImageUrl, AV63TFTileBGImageUrl_Sel, AV64TFTileTextColor, AV65TFTileTextColor_Sel, AV67TFTileTextAlignment_Sels, AV69TFTileIconAlignment_Sels, AV28TFProductServiceName, AV29TFProductServiceName_Sel, AV51TFSG_ToPageName, AV52TFSG_ToPageName_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV70IsAuthorized_TileName, AV42IsAuthorized_ProductServiceName, AV53IsAuthorized_SG_ToPageName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV73Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV74Trn_tilewwds_2_tftilename = AV56TFTileName;
         AV75Trn_tilewwds_3_tftilename_sel = AV57TFTileName_Sel;
         AV76Trn_tilewwds_4_tftileicon = AV58TFTileIcon;
         AV77Trn_tilewwds_5_tftileicon_sel = AV59TFTileIcon_Sel;
         AV78Trn_tilewwds_6_tftilebgcolor = AV60TFTileBGColor;
         AV79Trn_tilewwds_7_tftilebgcolor_sel = AV61TFTileBGColor_Sel;
         AV80Trn_tilewwds_8_tftilebgimageurl = AV62TFTileBGImageUrl;
         AV81Trn_tilewwds_9_tftilebgimageurl_sel = AV63TFTileBGImageUrl_Sel;
         AV82Trn_tilewwds_10_tftiletextcolor = AV64TFTileTextColor;
         AV83Trn_tilewwds_11_tftiletextcolor_sel = AV65TFTileTextColor_Sel;
         AV84Trn_tilewwds_12_tftiletextalignment_sels = AV67TFTileTextAlignment_Sels;
         AV85Trn_tilewwds_13_tftileiconalignment_sels = AV69TFTileIconAlignment_Sels;
         AV86Trn_tilewwds_14_tfproductservicename = AV28TFProductServiceName;
         AV87Trn_tilewwds_15_tfproductservicename_sel = AV29TFProductServiceName_Sel;
         AV88Trn_tilewwds_16_tfsg_topagename = AV51TFSG_ToPageName;
         AV89Trn_tilewwds_17_tfsg_topagename_sel = AV52TFSG_ToPageName_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV72Pgmname, AV15FilterFullText, AV56TFTileName, AV57TFTileName_Sel, AV58TFTileIcon, AV59TFTileIcon_Sel, AV60TFTileBGColor, AV61TFTileBGColor_Sel, AV62TFTileBGImageUrl, AV63TFTileBGImageUrl_Sel, AV64TFTileTextColor, AV65TFTileTextColor_Sel, AV67TFTileTextAlignment_Sels, AV69TFTileIconAlignment_Sels, AV28TFProductServiceName, AV29TFProductServiceName_Sel, AV51TFSG_ToPageName, AV52TFSG_ToPageName_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV70IsAuthorized_TileName, AV42IsAuthorized_ProductServiceName, AV53IsAuthorized_SG_ToPageName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV73Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV74Trn_tilewwds_2_tftilename = AV56TFTileName;
         AV75Trn_tilewwds_3_tftilename_sel = AV57TFTileName_Sel;
         AV76Trn_tilewwds_4_tftileicon = AV58TFTileIcon;
         AV77Trn_tilewwds_5_tftileicon_sel = AV59TFTileIcon_Sel;
         AV78Trn_tilewwds_6_tftilebgcolor = AV60TFTileBGColor;
         AV79Trn_tilewwds_7_tftilebgcolor_sel = AV61TFTileBGColor_Sel;
         AV80Trn_tilewwds_8_tftilebgimageurl = AV62TFTileBGImageUrl;
         AV81Trn_tilewwds_9_tftilebgimageurl_sel = AV63TFTileBGImageUrl_Sel;
         AV82Trn_tilewwds_10_tftiletextcolor = AV64TFTileTextColor;
         AV83Trn_tilewwds_11_tftiletextcolor_sel = AV65TFTileTextColor_Sel;
         AV84Trn_tilewwds_12_tftiletextalignment_sels = AV67TFTileTextAlignment_Sels;
         AV85Trn_tilewwds_13_tftileiconalignment_sels = AV69TFTileIconAlignment_Sels;
         AV86Trn_tilewwds_14_tfproductservicename = AV28TFProductServiceName;
         AV87Trn_tilewwds_15_tfproductservicename_sel = AV29TFProductServiceName_Sel;
         AV88Trn_tilewwds_16_tfsg_topagename = AV51TFSG_ToPageName;
         AV89Trn_tilewwds_17_tfsg_topagename_sel = AV52TFSG_ToPageName_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV72Pgmname, AV15FilterFullText, AV56TFTileName, AV57TFTileName_Sel, AV58TFTileIcon, AV59TFTileIcon_Sel, AV60TFTileBGColor, AV61TFTileBGColor_Sel, AV62TFTileBGImageUrl, AV63TFTileBGImageUrl_Sel, AV64TFTileTextColor, AV65TFTileTextColor_Sel, AV67TFTileTextAlignment_Sels, AV69TFTileIconAlignment_Sels, AV28TFProductServiceName, AV29TFProductServiceName_Sel, AV51TFSG_ToPageName, AV52TFSG_ToPageName_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV70IsAuthorized_TileName, AV42IsAuthorized_ProductServiceName, AV53IsAuthorized_SG_ToPageName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV73Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV74Trn_tilewwds_2_tftilename = AV56TFTileName;
         AV75Trn_tilewwds_3_tftilename_sel = AV57TFTileName_Sel;
         AV76Trn_tilewwds_4_tftileicon = AV58TFTileIcon;
         AV77Trn_tilewwds_5_tftileicon_sel = AV59TFTileIcon_Sel;
         AV78Trn_tilewwds_6_tftilebgcolor = AV60TFTileBGColor;
         AV79Trn_tilewwds_7_tftilebgcolor_sel = AV61TFTileBGColor_Sel;
         AV80Trn_tilewwds_8_tftilebgimageurl = AV62TFTileBGImageUrl;
         AV81Trn_tilewwds_9_tftilebgimageurl_sel = AV63TFTileBGImageUrl_Sel;
         AV82Trn_tilewwds_10_tftiletextcolor = AV64TFTileTextColor;
         AV83Trn_tilewwds_11_tftiletextcolor_sel = AV65TFTileTextColor_Sel;
         AV84Trn_tilewwds_12_tftiletextalignment_sels = AV67TFTileTextAlignment_Sels;
         AV85Trn_tilewwds_13_tftileiconalignment_sels = AV69TFTileIconAlignment_Sels;
         AV86Trn_tilewwds_14_tfproductservicename = AV28TFProductServiceName;
         AV87Trn_tilewwds_15_tfproductservicename_sel = AV29TFProductServiceName_Sel;
         AV88Trn_tilewwds_16_tfsg_topagename = AV51TFSG_ToPageName;
         AV89Trn_tilewwds_17_tfsg_topagename_sel = AV52TFSG_ToPageName_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV19ManageFiltersExecutionStep, AV72Pgmname, AV15FilterFullText, AV56TFTileName, AV57TFTileName_Sel, AV58TFTileIcon, AV59TFTileIcon_Sel, AV60TFTileBGColor, AV61TFTileBGColor_Sel, AV62TFTileBGImageUrl, AV63TFTileBGImageUrl_Sel, AV64TFTileTextColor, AV65TFTileTextColor_Sel, AV67TFTileTextAlignment_Sels, AV69TFTileIconAlignment_Sels, AV28TFProductServiceName, AV29TFProductServiceName_Sel, AV51TFSG_ToPageName, AV52TFSG_ToPageName_Sel, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV70IsAuthorized_TileName, AV42IsAuthorized_ProductServiceName, AV53IsAuthorized_SG_ToPageName, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV72Pgmname = "Trn_TileWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtTileId_Enabled = 0;
         edtTileName_Enabled = 0;
         edtTileIcon_Enabled = 0;
         edtTileBGColor_Enabled = 0;
         edtTileBGImageUrl_Enabled = 0;
         edtTileTextColor_Enabled = 0;
         cmbTileTextAlignment.Enabled = 0;
         cmbTileIconAlignment.Enabled = 0;
         edtProductServiceId_Enabled = 0;
         edtProductServiceName_Enabled = 0;
         edtProductServiceDescription_Enabled = 0;
         edtProductServiceImage_Enabled = 0;
         edtSG_ToPageId_Enabled = 0;
         edtSG_ToPageName_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E175Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV34DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV38GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV39GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV40GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( "DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E175Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E175Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV70IsAuthorized_TileName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_tileview_Execute", out  GXt_boolean1) ;
         AV70IsAuthorized_TileName = GXt_boolean1;
         AssignAttri("", false, "AV70IsAuthorized_TileName", AV70IsAuthorized_TileName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TILENAME", GetSecureSignedToken( "", AV70IsAuthorized_TileName, context));
         GXt_boolean1 = AV42IsAuthorized_ProductServiceName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_productserviceview_Execute", out  GXt_boolean1) ;
         AV42IsAuthorized_ProductServiceName = GXt_boolean1;
         AssignAttri("", false, "AV42IsAuthorized_ProductServiceName", AV42IsAuthorized_ProductServiceName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PRODUCTSERVICENAME", GetSecureSignedToken( "", AV42IsAuthorized_ProductServiceName, context));
         GXt_boolean1 = AV53IsAuthorized_SG_ToPageName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_pageview_Execute", out  GXt_boolean1) ;
         AV53IsAuthorized_SG_ToPageName = GXt_boolean1;
         AssignAttri("", false, "AV53IsAuthorized_SG_ToPageName", AV53IsAuthorized_SG_ToPageName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SG_TOPAGENAME", GetSecureSignedToken( "", AV53IsAuthorized_SG_ToPageName, context));
         AV35GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV36GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV35GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " Tile", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV34DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV34DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E185Z2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV19ManageFiltersExecutionStep == 1 )
         {
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV19ManageFiltersExecutionStep == 2 )
         {
            AV19ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV38GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV38GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV38GridCurrentPage), 10, 0));
         AV39GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV39GridPageCount", StringUtil.LTrimStr( (decimal)(AV39GridPageCount), 10, 0));
         GXt_char3 = AV40GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV72Pgmname, out  GXt_char3) ;
         AV40GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV40GridAppliedFilters", AV40GridAppliedFilters);
         AV73Trn_tilewwds_1_filterfulltext = AV15FilterFullText;
         AV74Trn_tilewwds_2_tftilename = AV56TFTileName;
         AV75Trn_tilewwds_3_tftilename_sel = AV57TFTileName_Sel;
         AV76Trn_tilewwds_4_tftileicon = AV58TFTileIcon;
         AV77Trn_tilewwds_5_tftileicon_sel = AV59TFTileIcon_Sel;
         AV78Trn_tilewwds_6_tftilebgcolor = AV60TFTileBGColor;
         AV79Trn_tilewwds_7_tftilebgcolor_sel = AV61TFTileBGColor_Sel;
         AV80Trn_tilewwds_8_tftilebgimageurl = AV62TFTileBGImageUrl;
         AV81Trn_tilewwds_9_tftilebgimageurl_sel = AV63TFTileBGImageUrl_Sel;
         AV82Trn_tilewwds_10_tftiletextcolor = AV64TFTileTextColor;
         AV83Trn_tilewwds_11_tftiletextcolor_sel = AV65TFTileTextColor_Sel;
         AV84Trn_tilewwds_12_tftiletextalignment_sels = AV67TFTileTextAlignment_Sels;
         AV85Trn_tilewwds_13_tftileiconalignment_sels = AV69TFTileIconAlignment_Sels;
         AV86Trn_tilewwds_14_tfproductservicename = AV28TFProductServiceName;
         AV87Trn_tilewwds_15_tfproductservicename_sel = AV29TFProductServiceName_Sel;
         AV88Trn_tilewwds_16_tfsg_topagename = AV51TFSG_ToPageName;
         AV89Trn_tilewwds_17_tfsg_topagename_sel = AV52TFSG_ToPageName_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E125Z2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV37PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV37PageToGo) ;
         }
      }

      protected void E135Z2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E155Z2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileName") == 0 )
            {
               AV56TFTileName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV56TFTileName", AV56TFTileName);
               AV57TFTileName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV57TFTileName_Sel", AV57TFTileName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileIcon") == 0 )
            {
               AV58TFTileIcon = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV58TFTileIcon", AV58TFTileIcon);
               AV59TFTileIcon_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV59TFTileIcon_Sel", AV59TFTileIcon_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileBGColor") == 0 )
            {
               AV60TFTileBGColor = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV60TFTileBGColor", AV60TFTileBGColor);
               AV61TFTileBGColor_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV61TFTileBGColor_Sel", AV61TFTileBGColor_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileBGImageUrl") == 0 )
            {
               AV62TFTileBGImageUrl = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV62TFTileBGImageUrl", AV62TFTileBGImageUrl);
               AV63TFTileBGImageUrl_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV63TFTileBGImageUrl_Sel", AV63TFTileBGImageUrl_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileTextColor") == 0 )
            {
               AV64TFTileTextColor = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV64TFTileTextColor", AV64TFTileTextColor);
               AV65TFTileTextColor_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV65TFTileTextColor_Sel", AV65TFTileTextColor_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileTextAlignment") == 0 )
            {
               AV66TFTileTextAlignment_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV66TFTileTextAlignment_SelsJson", AV66TFTileTextAlignment_SelsJson);
               AV67TFTileTextAlignment_Sels.FromJSonString(AV66TFTileTextAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TileIconAlignment") == 0 )
            {
               AV68TFTileIconAlignment_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV68TFTileIconAlignment_SelsJson", AV68TFTileIconAlignment_SelsJson);
               AV69TFTileIconAlignment_Sels.FromJSonString(AV68TFTileIconAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProductServiceName") == 0 )
            {
               AV28TFProductServiceName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFProductServiceName", AV28TFProductServiceName);
               AV29TFProductServiceName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFProductServiceName_Sel", AV29TFProductServiceName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SG_ToPageName") == 0 )
            {
               AV51TFSG_ToPageName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV51TFSG_ToPageName", AV51TFSG_ToPageName);
               AV52TFSG_ToPageName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV52TFSG_ToPageName_Sel", AV52TFSG_ToPageName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV69TFTileIconAlignment_Sels", AV69TFTileIconAlignment_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67TFTileTextAlignment_Sels", AV67TFTileTextAlignment_Sels);
      }

      private void E195Z2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV44Display = "<i class=\"fa fa-search\"></i>";
            AssignAttri("", false, edtavDisplay_Internalname, AV44Display);
            if ( AV45IsAuthorized_Display )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "trn_tileview.aspx"+UrlEncode(A407TileId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
               edtavDisplay_Link = formatLink("trn_tileview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            AV46Update = "<i class=\"fa fa-pen\"></i>";
            AssignAttri("", false, edtavUpdate_Internalname, AV46Update);
            if ( AV47IsAuthorized_Update )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "trn_tile.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A407TileId.ToString());
               edtavUpdate_Link = formatLink("trn_tile.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            AV48Delete = "<i class=\"fa fa-times\"></i>";
            AssignAttri("", false, edtavDelete_Internalname, AV48Delete);
            if ( AV49IsAuthorized_Delete )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "trn_tile.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A407TileId.ToString());
               edtavDelete_Link = formatLink("trn_tile.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( AV70IsAuthorized_TileName )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "trn_tileview.aspx"+UrlEncode(A407TileId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
               edtTileName_Link = formatLink("trn_tileview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            edtTileBGImageUrl_Linktarget = "_blank";
            edtTileBGImageUrl_Link = A403TileBGImageUrl;
            if ( AV42IsAuthorized_ProductServiceName )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "trn_productserviceview.aspx"+UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
               edtProductServiceName_Link = formatLink("trn_productserviceview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( AV53IsAuthorized_SG_ToPageName )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "trn_pageview.aspx"+UrlEncode(A329SG_ToPageId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
               edtSG_ToPageName_Link = formatLink("trn_pageview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 37;
            }
            sendrow_372( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E115Z2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_TileWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV72Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_TileWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV18ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "Trn_TileWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV18ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV72Pgmname+"GridState",  AV18ManageFiltersXml) ;
               AV11GridState.FromXml(AV18ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67TFTileTextAlignment_Sels", AV67TFTileTextAlignment_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV69TFTileIconAlignment_Sels", AV69TFTileIconAlignment_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void E165Z2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV50IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_tile.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("trn_tile.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E145Z2( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0065",(string)"",(string)"Trn_Tile",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0065"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV45IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_tileview_Execute", out  GXt_boolean1) ;
         AV45IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV45IsAuthorized_Display", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         if ( ! ( AV45IsAuthorized_Display ) )
         {
            edtavDisplay_Visible = 0;
            AssignProp("", false, edtavDisplay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDisplay_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV47IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_page_Update", out  GXt_boolean1) ;
         AV47IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV47IsAuthorized_Update", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         if ( ! ( AV47IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV49IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_page_Delete", out  GXt_boolean1) ;
         AV49IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV49IsAuthorized_Delete", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         if ( ! ( AV49IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV50IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_page_Insert", out  GXt_boolean1) ;
         AV50IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV50IsAuthorized_Insert", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
         if ( ! ( AV50IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_Tile",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV17ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_TileWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV56TFTileName = "";
         AssignAttri("", false, "AV56TFTileName", AV56TFTileName);
         AV57TFTileName_Sel = "";
         AssignAttri("", false, "AV57TFTileName_Sel", AV57TFTileName_Sel);
         AV58TFTileIcon = "";
         AssignAttri("", false, "AV58TFTileIcon", AV58TFTileIcon);
         AV59TFTileIcon_Sel = "";
         AssignAttri("", false, "AV59TFTileIcon_Sel", AV59TFTileIcon_Sel);
         AV60TFTileBGColor = "";
         AssignAttri("", false, "AV60TFTileBGColor", AV60TFTileBGColor);
         AV61TFTileBGColor_Sel = "";
         AssignAttri("", false, "AV61TFTileBGColor_Sel", AV61TFTileBGColor_Sel);
         AV62TFTileBGImageUrl = "";
         AssignAttri("", false, "AV62TFTileBGImageUrl", AV62TFTileBGImageUrl);
         AV63TFTileBGImageUrl_Sel = "";
         AssignAttri("", false, "AV63TFTileBGImageUrl_Sel", AV63TFTileBGImageUrl_Sel);
         AV64TFTileTextColor = "";
         AssignAttri("", false, "AV64TFTileTextColor", AV64TFTileTextColor);
         AV65TFTileTextColor_Sel = "";
         AssignAttri("", false, "AV65TFTileTextColor_Sel", AV65TFTileTextColor_Sel);
         AV67TFTileTextAlignment_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV69TFTileIconAlignment_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28TFProductServiceName = "";
         AssignAttri("", false, "AV28TFProductServiceName", AV28TFProductServiceName);
         AV29TFProductServiceName_Sel = "";
         AssignAttri("", false, "AV29TFProductServiceName_Sel", AV29TFProductServiceName_Sel);
         AV51TFSG_ToPageName = "";
         AssignAttri("", false, "AV51TFSG_ToPageName", AV51TFSG_ToPageName);
         AV52TFSG_ToPageName_Sel = "";
         AssignAttri("", false, "AV52TFSG_ToPageName_Sel", AV52TFSG_ToPageName_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV72Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV72Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV72Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV90GXV1 = 1;
         while ( AV90GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV90GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILENAME") == 0 )
            {
               AV56TFTileName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFTileName", AV56TFTileName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILENAME_SEL") == 0 )
            {
               AV57TFTileName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV57TFTileName_Sel", AV57TFTileName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEICON") == 0 )
            {
               AV58TFTileIcon = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV58TFTileIcon", AV58TFTileIcon);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEICON_SEL") == 0 )
            {
               AV59TFTileIcon_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFTileIcon_Sel", AV59TFTileIcon_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEBGCOLOR") == 0 )
            {
               AV60TFTileBGColor = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFTileBGColor", AV60TFTileBGColor);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEBGCOLOR_SEL") == 0 )
            {
               AV61TFTileBGColor_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV61TFTileBGColor_Sel", AV61TFTileBGColor_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEBGIMAGEURL") == 0 )
            {
               AV62TFTileBGImageUrl = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV62TFTileBGImageUrl", AV62TFTileBGImageUrl);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEBGIMAGEURL_SEL") == 0 )
            {
               AV63TFTileBGImageUrl_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV63TFTileBGImageUrl_Sel", AV63TFTileBGImageUrl_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILETEXTCOLOR") == 0 )
            {
               AV64TFTileTextColor = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFTileTextColor", AV64TFTileTextColor);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILETEXTCOLOR_SEL") == 0 )
            {
               AV65TFTileTextColor_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFTileTextColor_Sel", AV65TFTileTextColor_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILETEXTALIGNMENT_SEL") == 0 )
            {
               AV66TFTileTextAlignment_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFTileTextAlignment_SelsJson", AV66TFTileTextAlignment_SelsJson);
               AV67TFTileTextAlignment_Sels.FromJSonString(AV66TFTileTextAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTILEICONALIGNMENT_SEL") == 0 )
            {
               AV68TFTileIconAlignment_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFTileIconAlignment_SelsJson", AV68TFTileIconAlignment_SelsJson);
               AV69TFTileIconAlignment_Sels.FromJSonString(AV68TFTileIconAlignment_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME") == 0 )
            {
               AV28TFProductServiceName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFProductServiceName", AV28TFProductServiceName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME_SEL") == 0 )
            {
               AV29TFProductServiceName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFProductServiceName_Sel", AV29TFProductServiceName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSG_TOPAGENAME") == 0 )
            {
               AV51TFSG_ToPageName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFSG_ToPageName", AV51TFSG_ToPageName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSG_TOPAGENAME_SEL") == 0 )
            {
               AV52TFSG_ToPageName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFSG_ToPageName_Sel", AV52TFSG_ToPageName_Sel);
            }
            AV90GXV1 = (int)(AV90GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV57TFTileName_Sel)),  AV57TFTileName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFTileIcon_Sel)),  AV59TFTileIcon_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTileBGColor_Sel)),  AV61TFTileBGColor_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV63TFTileBGImageUrl_Sel)),  AV63TFTileBGImageUrl_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFTileTextColor_Sel)),  AV65TFTileTextColor_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV67TFTileTextAlignment_Sels.Count==0),  AV66TFTileTextAlignment_SelsJson, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV69TFTileIconAlignment_Sels.Count==0),  AV68TFTileIconAlignment_SelsJson, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProductServiceName_Sel)),  AV29TFProductServiceName_Sel, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSG_ToPageName_Sel)),  AV52TFSG_ToPageName_Sel, out  GXt_char12) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"||"+GXt_char12;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFTileName)),  AV56TFTileName, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV58TFTileIcon)),  AV58TFTileIcon, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV60TFTileBGColor)),  AV60TFTileBGColor, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV62TFTileBGImageUrl)),  AV62TFTileBGImageUrl, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV64TFTileTextColor)),  AV64TFTileTextColor, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProductServiceName)),  AV28TFProductServiceName, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSG_ToPageName)),  AV51TFSG_ToPageName, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = "|"+GXt_char12+"|"+GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|||"+GXt_char7+"||"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV72Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILENAME",  context.GetMessage( "Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFTileName)),  0,  AV56TFTileName,  AV56TFTileName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV57TFTileName_Sel)),  AV57TFTileName_Sel,  AV57TFTileName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILEICON",  context.GetMessage( "Icon", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV58TFTileIcon)),  0,  AV58TFTileIcon,  AV58TFTileIcon,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFTileIcon_Sel)),  AV59TFTileIcon_Sel,  AV59TFTileIcon_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILEBGCOLOR",  context.GetMessage( "BGColor", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV60TFTileBGColor)),  0,  AV60TFTileBGColor,  AV60TFTileBGColor,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTileBGColor_Sel)),  AV61TFTileBGColor_Sel,  AV61TFTileBGColor_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILEBGIMAGEURL",  context.GetMessage( "BGImage Url", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV62TFTileBGImageUrl)),  0,  AV62TFTileBGImageUrl,  AV62TFTileBGImageUrl,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV63TFTileBGImageUrl_Sel)),  AV63TFTileBGImageUrl_Sel,  AV63TFTileBGImageUrl_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTILETEXTCOLOR",  context.GetMessage( "Text Color", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV64TFTileTextColor)),  0,  AV64TFTileTextColor,  AV64TFTileTextColor,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFTileTextColor_Sel)),  AV65TFTileTextColor_Sel,  AV65TFTileTextColor_Sel) ;
         AV71AuxText = ((AV67TFTileTextAlignment_Sels.Count==1) ? "["+AV67TFTileTextAlignment_Sels.GetString(1)+"]" : context.GetMessage( "WWP_FilterValueDescription_MultipleValues", ""));
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTILETEXTALIGNMENT_SEL",  context.GetMessage( "Text Alignment", ""),  !(AV67TFTileTextAlignment_Sels.Count==0),  0,  AV67TFTileTextAlignment_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV71AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV71AuxText, "[center]", context.GetMessage( "center", "")), "[left]", context.GetMessage( "left", "")), "[right]", context.GetMessage( "right", ""))),  false,  "",  "") ;
         AV71AuxText = ((AV69TFTileIconAlignment_Sels.Count==1) ? "["+AV69TFTileIconAlignment_Sels.GetString(1)+"]" : context.GetMessage( "WWP_FilterValueDescription_MultipleValues", ""));
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTILEICONALIGNMENT_SEL",  context.GetMessage( "Icon Alignment", ""),  !(AV69TFTileIconAlignment_Sels.Count==0),  0,  AV69TFTileIconAlignment_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV71AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV71AuxText, "[center]", context.GetMessage( "center", "")), "[left]", context.GetMessage( "left", "")), "[right]", context.GetMessage( "right", ""))),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPRODUCTSERVICENAME",  context.GetMessage( "Product Service Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProductServiceName)),  0,  AV28TFProductServiceName,  AV28TFProductServiceName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProductServiceName_Sel)),  AV29TFProductServiceName_Sel,  AV29TFProductServiceName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSG_TOPAGENAME",  context.GetMessage( "Page Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSG_ToPageName)),  0,  AV51TFSG_ToPageName,  AV51TFSG_ToPageName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSG_ToPageName_Sel)),  AV52TFSG_ToPageName_Sel,  AV52TFSG_ToPageName_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV72Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV72Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_Tile";
         AV16Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA5Z2( ) ;
         WS5Z2( ) ;
         WE5Z2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241021994323", true, true);
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
         context.AddJavascriptSource("trn_tileww.js", "?20241021994324", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         edtTileId_Internalname = "TILEID_"+sGXsfl_37_idx;
         edtTileName_Internalname = "TILENAME_"+sGXsfl_37_idx;
         edtTileIcon_Internalname = "TILEICON_"+sGXsfl_37_idx;
         edtTileBGColor_Internalname = "TILEBGCOLOR_"+sGXsfl_37_idx;
         edtTileBGImageUrl_Internalname = "TILEBGIMAGEURL_"+sGXsfl_37_idx;
         edtTileTextColor_Internalname = "TILETEXTCOLOR_"+sGXsfl_37_idx;
         cmbTileTextAlignment_Internalname = "TILETEXTALIGNMENT_"+sGXsfl_37_idx;
         cmbTileIconAlignment_Internalname = "TILEICONALIGNMENT_"+sGXsfl_37_idx;
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_37_idx;
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME_"+sGXsfl_37_idx;
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_37_idx;
         edtProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE_"+sGXsfl_37_idx;
         edtSG_ToPageId_Internalname = "SG_TOPAGEID_"+sGXsfl_37_idx;
         edtSG_ToPageName_Internalname = "SG_TOPAGENAME_"+sGXsfl_37_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_37_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtTileId_Internalname = "TILEID_"+sGXsfl_37_fel_idx;
         edtTileName_Internalname = "TILENAME_"+sGXsfl_37_fel_idx;
         edtTileIcon_Internalname = "TILEICON_"+sGXsfl_37_fel_idx;
         edtTileBGColor_Internalname = "TILEBGCOLOR_"+sGXsfl_37_fel_idx;
         edtTileBGImageUrl_Internalname = "TILEBGIMAGEURL_"+sGXsfl_37_fel_idx;
         edtTileTextColor_Internalname = "TILETEXTCOLOR_"+sGXsfl_37_fel_idx;
         cmbTileTextAlignment_Internalname = "TILETEXTALIGNMENT_"+sGXsfl_37_fel_idx;
         cmbTileIconAlignment_Internalname = "TILEICONALIGNMENT_"+sGXsfl_37_fel_idx;
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_37_fel_idx;
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME_"+sGXsfl_37_fel_idx;
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_37_fel_idx;
         edtProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE_"+sGXsfl_37_fel_idx;
         edtSG_ToPageId_Internalname = "SG_TOPAGEID_"+sGXsfl_37_fel_idx;
         edtSG_ToPageName_Internalname = "SG_TOPAGENAME_"+sGXsfl_37_fel_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_37_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB5Z0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileId_Internalname,A407TileId.ToString(),A407TileId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTileId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileName_Internalname,(string)A400TileName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTileName_Link,(string)"",(string)"",(string)"",(string)edtTileName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileIcon_Internalname,StringUtil.RTrim( A401TileIcon),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTileIcon_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileBGColor_Internalname,StringUtil.RTrim( A402TileBGColor),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTileBGColor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileBGImageUrl_Internalname,(string)A403TileBGImageUrl,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTileBGImageUrl_Link,(string)edtTileBGImageUrl_Linktarget,(string)"",(string)"",(string)edtTileBGImageUrl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"url",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTileTextColor_Internalname,StringUtil.RTrim( A404TileTextColor),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTileTextColor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTileTextAlignment.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TILETEXTALIGNMENT_" + sGXsfl_37_idx;
               cmbTileTextAlignment.Name = GXCCtl;
               cmbTileTextAlignment.WebTags = "";
               cmbTileTextAlignment.addItem("center", context.GetMessage( "center", ""), 0);
               cmbTileTextAlignment.addItem("left", context.GetMessage( "left", ""), 0);
               cmbTileTextAlignment.addItem("right", context.GetMessage( "right", ""), 0);
               if ( cmbTileTextAlignment.ItemCount > 0 )
               {
                  A405TileTextAlignment = cmbTileTextAlignment.getValidValue(A405TileTextAlignment);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTileTextAlignment,(string)cmbTileTextAlignment_Internalname,StringUtil.RTrim( A405TileTextAlignment),(short)1,(string)cmbTileTextAlignment_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTileTextAlignment.CurrentValue = StringUtil.RTrim( A405TileTextAlignment);
            AssignProp("", false, cmbTileTextAlignment_Internalname, "Values", (string)(cmbTileTextAlignment.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTileIconAlignment.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TILEICONALIGNMENT_" + sGXsfl_37_idx;
               cmbTileIconAlignment.Name = GXCCtl;
               cmbTileIconAlignment.WebTags = "";
               cmbTileIconAlignment.addItem("center", context.GetMessage( "center", ""), 0);
               cmbTileIconAlignment.addItem("left", context.GetMessage( "left", ""), 0);
               cmbTileIconAlignment.addItem("right", context.GetMessage( "right", ""), 0);
               if ( cmbTileIconAlignment.ItemCount > 0 )
               {
                  A406TileIconAlignment = cmbTileIconAlignment.getValidValue(A406TileIconAlignment);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTileIconAlignment,(string)cmbTileIconAlignment_Internalname,StringUtil.RTrim( A406TileIconAlignment),(short)1,(string)cmbTileIconAlignment_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTileIconAlignment.CurrentValue = StringUtil.RTrim( A406TileIconAlignment);
            AssignProp("", false, cmbTileIconAlignment_Internalname, "Values", (string)(cmbTileIconAlignment.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceId_Internalname,A58ProductServiceId.ToString(),A58ProductServiceId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceName_Internalname,(string)A59ProductServiceName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProductServiceName_Link,(string)"",(string)"",(string)"",(string)edtProductServiceName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceDescription_Internalname,(string)A60ProductServiceDescription,(string)A60ProductServiceDescription,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)37,(short)0,(short)0,(short)-1,(bool)true,(string)"LongDescription",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A61ProductServiceImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductServiceImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.PathToRelativeUrl( A61ProductServiceImage));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceImage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A61ProductServiceImage_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSG_ToPageId_Internalname,A329SG_ToPageId.ToString(),A329SG_ToPageId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSG_ToPageId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSG_ToPageName_Internalname,(string)A330SG_ToPageName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSG_ToPageName_Link,(string)"",(string)"",(string)"",(string)edtSG_ToPageName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDisplay_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV44Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",context.GetMessage( "GXM_display", ""),(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDisplay_Visible,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV46Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",context.GetMessage( "GXM_update", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV48Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes5Z2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "TILETEXTALIGNMENT_" + sGXsfl_37_idx;
         cmbTileTextAlignment.Name = GXCCtl;
         cmbTileTextAlignment.WebTags = "";
         cmbTileTextAlignment.addItem("center", context.GetMessage( "center", ""), 0);
         cmbTileTextAlignment.addItem("left", context.GetMessage( "left", ""), 0);
         cmbTileTextAlignment.addItem("right", context.GetMessage( "right", ""), 0);
         if ( cmbTileTextAlignment.ItemCount > 0 )
         {
            A405TileTextAlignment = cmbTileTextAlignment.getValidValue(A405TileTextAlignment);
         }
         GXCCtl = "TILEICONALIGNMENT_" + sGXsfl_37_idx;
         cmbTileIconAlignment.Name = GXCCtl;
         cmbTileIconAlignment.WebTags = "";
         cmbTileIconAlignment.addItem("center", context.GetMessage( "center", ""), 0);
         cmbTileIconAlignment.addItem("left", context.GetMessage( "left", ""), 0);
         cmbTileIconAlignment.addItem("right", context.GetMessage( "right", ""), 0);
         if ( cmbTileIconAlignment.ItemCount > 0 )
         {
            A406TileIconAlignment = cmbTileIconAlignment.getValidValue(A406TileIconAlignment);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Icon", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "BGColor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "BGImage Url", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Text Color", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Text Alignment", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Icon Alignment", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Product Service Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Product Service Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Product Service Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Product Service Image", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Page Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Page Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDisplay_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A407TileId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A400TileName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTileName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A401TileIcon)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A402TileBGColor)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A403TileBGImageUrl));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTileBGImageUrl_Link));
            GridColumn.AddObjectProperty("Linktarget", StringUtil.RTrim( edtTileBGImageUrl_Linktarget));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A404TileTextColor)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A405TileTextAlignment)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A406TileIconAlignment)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A58ProductServiceId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A59ProductServiceName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtProductServiceName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A60ProductServiceDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A61ProductServiceImage));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A329SG_ToPageId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A330SG_ToPageName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSG_ToPageName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV44Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV46Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV48Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtTileId_Internalname = "TILEID";
         edtTileName_Internalname = "TILENAME";
         edtTileIcon_Internalname = "TILEICON";
         edtTileBGColor_Internalname = "TILEBGCOLOR";
         edtTileBGImageUrl_Internalname = "TILEBGIMAGEURL";
         edtTileTextColor_Internalname = "TILETEXTCOLOR";
         cmbTileTextAlignment_Internalname = "TILETEXTALIGNMENT";
         cmbTileIconAlignment_Internalname = "TILEICONALIGNMENT";
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME";
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION";
         edtProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE";
         edtSG_ToPageId_Internalname = "SG_TOPAGEID";
         edtSG_ToPageName_Internalname = "SG_TOPAGENAME";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         edtSG_ToPageName_Jsonclick = "";
         edtSG_ToPageName_Link = "";
         edtSG_ToPageId_Jsonclick = "";
         edtProductServiceDescription_Jsonclick = "";
         edtProductServiceName_Jsonclick = "";
         edtProductServiceName_Link = "";
         edtProductServiceId_Jsonclick = "";
         cmbTileIconAlignment_Jsonclick = "";
         cmbTileTextAlignment_Jsonclick = "";
         edtTileTextColor_Jsonclick = "";
         edtTileBGImageUrl_Jsonclick = "";
         edtTileBGImageUrl_Linktarget = "";
         edtTileBGImageUrl_Link = "";
         edtTileBGColor_Jsonclick = "";
         edtTileIcon_Jsonclick = "";
         edtTileName_Jsonclick = "";
         edtTileName_Link = "";
         edtTileId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtavDisplay_Visible = -1;
         edtSG_ToPageName_Enabled = 0;
         edtSG_ToPageId_Enabled = 0;
         edtProductServiceImage_Enabled = 0;
         edtProductServiceDescription_Enabled = 0;
         edtProductServiceName_Enabled = 0;
         edtProductServiceId_Enabled = 0;
         cmbTileIconAlignment.Enabled = 0;
         cmbTileTextAlignment.Enabled = 0;
         edtTileTextColor_Enabled = 0;
         edtTileBGImageUrl_Enabled = 0;
         edtTileBGColor_Enabled = 0;
         edtTileIcon_Enabled = 0;
         edtTileName_Enabled = 0;
         edtTileId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "Trn_TileWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||center:center,left:left,right:right|center:center,left:left,right:right|||";
         Ddo_grid_Allowmultipleselection = "||||||T|T|||";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|FixedValues|FixedValues|Dynamic||Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T|T|T|T|T|T||T";
         Ddo_grid_Filtertype = "|Character|Character|Character|Character|Character|||Character||Character";
         Ddo_grid_Includefilter = "|T|T|T|T|T|||T||T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9|10|11";
         Ddo_grid_Columnids = "0:TileId|1:TileName|2:TileIcon|3:TileBGColor|4:TileBGImageUrl|5:TileTextColor|6:TileTextAlignment|7:TileIconAlignment|9:ProductServiceName|12:SG_ToPageId|13:SG_ToPageName";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " Tile", "");
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV56TFTileName","fld":"vTFTILENAME"},{"av":"AV57TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV58TFTileIcon","fld":"vTFTILEICON"},{"av":"AV59TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV60TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV61TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV62TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV63TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV64TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV65TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV67TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV69TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV28TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV29TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV51TFSG_ToPageName","fld":"vTFSG_TOPAGENAME"},{"av":"AV52TFSG_ToPageName_Sel","fld":"vTFSG_TOPAGENAME_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV70IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV42IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV53IsAuthorized_SG_ToPageName","fld":"vISAUTHORIZED_SG_TOPAGENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E125Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV56TFTileName","fld":"vTFTILENAME"},{"av":"AV57TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV58TFTileIcon","fld":"vTFTILEICON"},{"av":"AV59TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV60TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV61TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV62TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV63TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV64TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV65TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV67TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV69TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV28TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV29TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV51TFSG_ToPageName","fld":"vTFSG_TOPAGENAME"},{"av":"AV52TFSG_ToPageName_Sel","fld":"vTFSG_TOPAGENAME_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV70IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV42IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV53IsAuthorized_SG_ToPageName","fld":"vISAUTHORIZED_SG_TOPAGENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E135Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV56TFTileName","fld":"vTFTILENAME"},{"av":"AV57TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV58TFTileIcon","fld":"vTFTILEICON"},{"av":"AV59TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV60TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV61TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV62TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV63TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV64TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV65TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV67TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV69TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV28TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV29TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV51TFSG_ToPageName","fld":"vTFSG_TOPAGENAME"},{"av":"AV52TFSG_ToPageName_Sel","fld":"vTFSG_TOPAGENAME_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV70IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV42IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV53IsAuthorized_SG_ToPageName","fld":"vISAUTHORIZED_SG_TOPAGENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E155Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV56TFTileName","fld":"vTFTILENAME"},{"av":"AV57TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV58TFTileIcon","fld":"vTFTILEICON"},{"av":"AV59TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV60TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV61TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV62TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV63TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV64TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV65TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV67TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV69TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV28TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV29TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV51TFSG_ToPageName","fld":"vTFSG_TOPAGENAME"},{"av":"AV52TFSG_ToPageName_Sel","fld":"vTFSG_TOPAGENAME_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV70IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV42IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV53IsAuthorized_SG_ToPageName","fld":"vISAUTHORIZED_SG_TOPAGENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV51TFSG_ToPageName","fld":"vTFSG_TOPAGENAME"},{"av":"AV52TFSG_ToPageName_Sel","fld":"vTFSG_TOPAGENAME_SEL"},{"av":"AV28TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV29TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV68TFTileIconAlignment_SelsJson","fld":"vTFTILEICONALIGNMENT_SELSJSON"},{"av":"AV69TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV66TFTileTextAlignment_SelsJson","fld":"vTFTILETEXTALIGNMENT_SELSJSON"},{"av":"AV67TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV64TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV65TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV62TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV63TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV60TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV61TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV58TFTileIcon","fld":"vTFTILEICON"},{"av":"AV59TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV56TFTileName","fld":"vTFTILENAME"},{"av":"AV57TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E195Z2","iparms":[{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"A407TileId","fld":"TILEID","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV70IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"A403TileBGImageUrl","fld":"TILEBGIMAGEURL"},{"av":"AV42IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV53IsAuthorized_SG_ToPageName","fld":"vISAUTHORIZED_SG_TOPAGENAME","hsh":true},{"av":"A329SG_ToPageId","fld":"SG_TOPAGEID"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV44Display","fld":"vDISPLAY"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV46Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV48Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtTileName_Link","ctrl":"TILENAME","prop":"Link"},{"av":"edtTileBGImageUrl_Linktarget","ctrl":"TILEBGIMAGEURL","prop":"Linktarget"},{"av":"edtTileBGImageUrl_Link","ctrl":"TILEBGIMAGEURL","prop":"Link"},{"av":"edtProductServiceName_Link","ctrl":"PRODUCTSERVICENAME","prop":"Link"},{"av":"edtSG_ToPageName_Link","ctrl":"SG_TOPAGENAME","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E115Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV56TFTileName","fld":"vTFTILENAME"},{"av":"AV57TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV58TFTileIcon","fld":"vTFTILEICON"},{"av":"AV59TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV60TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV61TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV62TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV63TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV64TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV65TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV67TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV69TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV28TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV29TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV51TFSG_ToPageName","fld":"vTFSG_TOPAGENAME"},{"av":"AV52TFSG_ToPageName_Sel","fld":"vTFSG_TOPAGENAME_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV70IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV42IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV53IsAuthorized_SG_ToPageName","fld":"vISAUTHORIZED_SG_TOPAGENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV66TFTileTextAlignment_SelsJson","fld":"vTFTILETEXTALIGNMENT_SELSJSON"},{"av":"AV68TFTileIconAlignment_SelsJson","fld":"vTFTILEICONALIGNMENT_SELSJSON"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV56TFTileName","fld":"vTFTILENAME"},{"av":"AV57TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV58TFTileIcon","fld":"vTFTILEICON"},{"av":"AV59TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV60TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV61TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV62TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV63TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV64TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV65TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV67TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV69TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV28TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV29TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV51TFSG_ToPageName","fld":"vTFSG_TOPAGENAME"},{"av":"AV52TFSG_ToPageName_Sel","fld":"vTFSG_TOPAGENAME_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV68TFTileIconAlignment_SelsJson","fld":"vTFTILEICONALIGNMENT_SELSJSON"},{"av":"AV66TFTileTextAlignment_SelsJson","fld":"vTFTILETEXTALIGNMENT_SELSJSON"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E165Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV56TFTileName","fld":"vTFTILENAME"},{"av":"AV57TFTileName_Sel","fld":"vTFTILENAME_SEL"},{"av":"AV58TFTileIcon","fld":"vTFTILEICON"},{"av":"AV59TFTileIcon_Sel","fld":"vTFTILEICON_SEL"},{"av":"AV60TFTileBGColor","fld":"vTFTILEBGCOLOR"},{"av":"AV61TFTileBGColor_Sel","fld":"vTFTILEBGCOLOR_SEL"},{"av":"AV62TFTileBGImageUrl","fld":"vTFTILEBGIMAGEURL"},{"av":"AV63TFTileBGImageUrl_Sel","fld":"vTFTILEBGIMAGEURL_SEL"},{"av":"AV64TFTileTextColor","fld":"vTFTILETEXTCOLOR"},{"av":"AV65TFTileTextColor_Sel","fld":"vTFTILETEXTCOLOR_SEL"},{"av":"AV67TFTileTextAlignment_Sels","fld":"vTFTILETEXTALIGNMENT_SELS"},{"av":"AV69TFTileIconAlignment_Sels","fld":"vTFTILEICONALIGNMENT_SELS"},{"av":"AV28TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV29TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV51TFSG_ToPageName","fld":"vTFSG_TOPAGENAME"},{"av":"AV52TFSG_ToPageName_Sel","fld":"vTFSG_TOPAGENAME_SEL"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV70IsAuthorized_TileName","fld":"vISAUTHORIZED_TILENAME","hsh":true},{"av":"AV42IsAuthorized_ProductServiceName","fld":"vISAUTHORIZED_PRODUCTSERVICENAME","hsh":true},{"av":"AV53IsAuthorized_SG_ToPageName","fld":"vISAUTHORIZED_SG_TOPAGENAME","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A407TileId","fld":"TILEID","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E145Z2","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VALID_TILENAME","""{"handler":"Valid_Tilename","iparms":[]}""");
         setEventMetadata("VALID_TILEICON","""{"handler":"Valid_Tileicon","iparms":[]}""");
         setEventMetadata("VALID_TILEBGCOLOR","""{"handler":"Valid_Tilebgcolor","iparms":[]}""");
         setEventMetadata("VALID_TILEBGIMAGEURL","""{"handler":"Valid_Tilebgimageurl","iparms":[]}""");
         setEventMetadata("VALID_TILETEXTCOLOR","""{"handler":"Valid_Tiletextcolor","iparms":[]}""");
         setEventMetadata("VALID_TILETEXTALIGNMENT","""{"handler":"Valid_Tiletextalignment","iparms":[]}""");
         setEventMetadata("VALID_TILEICONALIGNMENT","""{"handler":"Valid_Tileiconalignment","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEID","""{"handler":"Valid_Productserviceid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICENAME","""{"handler":"Valid_Productservicename","iparms":[]}""");
         setEventMetadata("VALID_SG_TOPAGEID","""{"handler":"Valid_Sg_topageid","iparms":[]}""");
         setEventMetadata("VALID_SG_TOPAGENAME","""{"handler":"Valid_Sg_topagename","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Delete","iparms":[]}""");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV72Pgmname = "";
         AV15FilterFullText = "";
         AV56TFTileName = "";
         AV57TFTileName_Sel = "";
         AV58TFTileIcon = "";
         AV59TFTileIcon_Sel = "";
         AV60TFTileBGColor = "";
         AV61TFTileBGColor_Sel = "";
         AV62TFTileBGImageUrl = "";
         AV63TFTileBGImageUrl_Sel = "";
         AV64TFTileTextColor = "";
         AV65TFTileTextColor_Sel = "";
         AV67TFTileTextAlignment_Sels = new GxSimpleCollection<string>();
         AV69TFTileIconAlignment_Sels = new GxSimpleCollection<string>();
         AV28TFProductServiceName = "";
         AV29TFProductServiceName_Sel = "";
         AV51TFSG_ToPageName = "";
         AV52TFSG_ToPageName_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40GridAppliedFilters = "";
         AV34DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV66TFTileTextAlignment_SelsJson = "";
         AV68TFTileIconAlignment_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A407TileId = Guid.Empty;
         A400TileName = "";
         A401TileIcon = "";
         A402TileBGColor = "";
         A403TileBGImageUrl = "";
         A404TileTextColor = "";
         A405TileTextAlignment = "";
         A406TileIconAlignment = "";
         A58ProductServiceId = Guid.Empty;
         A59ProductServiceName = "";
         A60ProductServiceDescription = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         A329SG_ToPageId = Guid.Empty;
         A330SG_ToPageName = "";
         AV44Display = "";
         AV46Update = "";
         AV48Delete = "";
         AV73Trn_tilewwds_1_filterfulltext = "";
         AV74Trn_tilewwds_2_tftilename = "";
         AV75Trn_tilewwds_3_tftilename_sel = "";
         AV76Trn_tilewwds_4_tftileicon = "";
         AV77Trn_tilewwds_5_tftileicon_sel = "";
         AV78Trn_tilewwds_6_tftilebgcolor = "";
         AV79Trn_tilewwds_7_tftilebgcolor_sel = "";
         AV80Trn_tilewwds_8_tftilebgimageurl = "";
         AV81Trn_tilewwds_9_tftilebgimageurl_sel = "";
         AV82Trn_tilewwds_10_tftiletextcolor = "";
         AV83Trn_tilewwds_11_tftiletextcolor_sel = "";
         AV84Trn_tilewwds_12_tftiletextalignment_sels = new GxSimpleCollection<string>();
         AV85Trn_tilewwds_13_tftileiconalignment_sels = new GxSimpleCollection<string>();
         AV86Trn_tilewwds_14_tfproductservicename = "";
         AV87Trn_tilewwds_15_tfproductservicename_sel = "";
         AV88Trn_tilewwds_16_tfsg_topagename = "";
         AV89Trn_tilewwds_17_tfsg_topagename_sel = "";
         lV73Trn_tilewwds_1_filterfulltext = "";
         lV74Trn_tilewwds_2_tftilename = "";
         lV76Trn_tilewwds_4_tftileicon = "";
         lV78Trn_tilewwds_6_tftilebgcolor = "";
         lV80Trn_tilewwds_8_tftilebgimageurl = "";
         lV82Trn_tilewwds_10_tftiletextcolor = "";
         lV86Trn_tilewwds_14_tfproductservicename = "";
         lV88Trn_tilewwds_16_tfsg_topagename = "";
         H005Z2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005Z2_n11OrganisationId = new bool[] {false} ;
         H005Z2_A29LocationId = new Guid[] {Guid.Empty} ;
         H005Z2_n29LocationId = new bool[] {false} ;
         H005Z2_A330SG_ToPageName = new string[] {""} ;
         H005Z2_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         H005Z2_A40000ProductServiceImage_GXI = new string[] {""} ;
         H005Z2_A60ProductServiceDescription = new string[] {""} ;
         H005Z2_A59ProductServiceName = new string[] {""} ;
         H005Z2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H005Z2_n58ProductServiceId = new bool[] {false} ;
         H005Z2_A406TileIconAlignment = new string[] {""} ;
         H005Z2_A405TileTextAlignment = new string[] {""} ;
         H005Z2_A404TileTextColor = new string[] {""} ;
         H005Z2_A403TileBGImageUrl = new string[] {""} ;
         H005Z2_n403TileBGImageUrl = new bool[] {false} ;
         H005Z2_A402TileBGColor = new string[] {""} ;
         H005Z2_n402TileBGColor = new bool[] {false} ;
         H005Z2_A401TileIcon = new string[] {""} ;
         H005Z2_n401TileIcon = new bool[] {false} ;
         H005Z2_A400TileName = new string[] {""} ;
         H005Z2_A407TileId = new Guid[] {Guid.Empty} ;
         H005Z2_A61ProductServiceImage = new string[] {""} ;
         H005Z3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005Z3_n11OrganisationId = new bool[] {false} ;
         H005Z3_A29LocationId = new Guid[] {Guid.Empty} ;
         H005Z3_n29LocationId = new bool[] {false} ;
         H005Z3_A330SG_ToPageName = new string[] {""} ;
         H005Z3_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         H005Z3_A40000ProductServiceImage_GXI = new string[] {""} ;
         H005Z3_A60ProductServiceDescription = new string[] {""} ;
         H005Z3_A59ProductServiceName = new string[] {""} ;
         H005Z3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H005Z3_n58ProductServiceId = new bool[] {false} ;
         H005Z3_A406TileIconAlignment = new string[] {""} ;
         H005Z3_A405TileTextAlignment = new string[] {""} ;
         H005Z3_A404TileTextColor = new string[] {""} ;
         H005Z3_A403TileBGImageUrl = new string[] {""} ;
         H005Z3_n403TileBGImageUrl = new bool[] {false} ;
         H005Z3_A402TileBGColor = new string[] {""} ;
         H005Z3_n402TileBGColor = new bool[] {false} ;
         H005Z3_A401TileIcon = new string[] {""} ;
         H005Z3_n401TileIcon = new bool[] {false} ;
         H005Z3_A400TileName = new string[] {""} ;
         H005Z3_A407TileId = new Guid[] {Guid.Empty} ;
         H005Z3_A61ProductServiceImage = new string[] {""} ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV35GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV36GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV16Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char5 = "";
         GXt_char12 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV71AuxText = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sImgUrl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_tileww__default(),
            new Object[][] {
                new Object[] {
               H005Z2_A11OrganisationId, H005Z2_n11OrganisationId, H005Z2_A29LocationId, H005Z2_n29LocationId, H005Z2_A330SG_ToPageName, H005Z2_A329SG_ToPageId, H005Z2_A40000ProductServiceImage_GXI, H005Z2_A60ProductServiceDescription, H005Z2_A59ProductServiceName, H005Z2_A58ProductServiceId,
               H005Z2_n58ProductServiceId, H005Z2_A406TileIconAlignment, H005Z2_A405TileTextAlignment, H005Z2_A404TileTextColor, H005Z2_A403TileBGImageUrl, H005Z2_n403TileBGImageUrl, H005Z2_A402TileBGColor, H005Z2_n402TileBGColor, H005Z2_A401TileIcon, H005Z2_n401TileIcon,
               H005Z2_A400TileName, H005Z2_A407TileId, H005Z2_A61ProductServiceImage
               }
               , new Object[] {
               H005Z3_A11OrganisationId, H005Z3_n11OrganisationId, H005Z3_A29LocationId, H005Z3_n29LocationId, H005Z3_A330SG_ToPageName, H005Z3_A329SG_ToPageId, H005Z3_A40000ProductServiceImage_GXI, H005Z3_A60ProductServiceDescription, H005Z3_A59ProductServiceName, H005Z3_A58ProductServiceId,
               H005Z3_n58ProductServiceId, H005Z3_A406TileIconAlignment, H005Z3_A405TileTextAlignment, H005Z3_A404TileTextColor, H005Z3_A403TileBGImageUrl, H005Z3_n403TileBGImageUrl, H005Z3_A402TileBGColor, H005Z3_n402TileBGColor, H005Z3_A401TileIcon, H005Z3_n401TileIcon,
               H005Z3_A400TileName, H005Z3_A407TileId, H005Z3_A61ProductServiceImage
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV72Pgmname = "Trn_TileWW";
         /* GeneXus formulas. */
         AV72Pgmname = "Trn_TileWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV19ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int AV84Trn_tilewwds_12_tftiletextalignment_sels_Count ;
      private int AV85Trn_tilewwds_13_tftileiconalignment_sels_Count ;
      private int edtTileId_Enabled ;
      private int edtTileName_Enabled ;
      private int edtTileIcon_Enabled ;
      private int edtTileBGColor_Enabled ;
      private int edtTileBGImageUrl_Enabled ;
      private int edtTileTextColor_Enabled ;
      private int edtProductServiceId_Enabled ;
      private int edtProductServiceName_Enabled ;
      private int edtProductServiceDescription_Enabled ;
      private int edtProductServiceImage_Enabled ;
      private int edtSG_ToPageId_Enabled ;
      private int edtSG_ToPageName_Enabled ;
      private int AV37PageToGo ;
      private int edtavDisplay_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV90GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV38GridCurrentPage ;
      private long AV39GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV72Pgmname ;
      private string AV58TFTileIcon ;
      private string AV59TFTileIcon_Sel ;
      private string AV60TFTileBGColor ;
      private string AV61TFTileBGColor_Sel ;
      private string AV64TFTileTextColor ;
      private string AV65TFTileTextColor_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_subscriptions_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtTileId_Internalname ;
      private string edtTileName_Internalname ;
      private string A401TileIcon ;
      private string edtTileIcon_Internalname ;
      private string A402TileBGColor ;
      private string edtTileBGColor_Internalname ;
      private string edtTileBGImageUrl_Internalname ;
      private string A404TileTextColor ;
      private string edtTileTextColor_Internalname ;
      private string cmbTileTextAlignment_Internalname ;
      private string A405TileTextAlignment ;
      private string cmbTileIconAlignment_Internalname ;
      private string A406TileIconAlignment ;
      private string edtProductServiceId_Internalname ;
      private string edtProductServiceName_Internalname ;
      private string edtProductServiceDescription_Internalname ;
      private string edtProductServiceImage_Internalname ;
      private string edtSG_ToPageId_Internalname ;
      private string edtSG_ToPageName_Internalname ;
      private string AV44Display ;
      private string edtavDisplay_Internalname ;
      private string AV46Update ;
      private string edtavUpdate_Internalname ;
      private string AV48Delete ;
      private string edtavDelete_Internalname ;
      private string AV76Trn_tilewwds_4_tftileicon ;
      private string AV77Trn_tilewwds_5_tftileicon_sel ;
      private string AV78Trn_tilewwds_6_tftilebgcolor ;
      private string AV79Trn_tilewwds_7_tftilebgcolor_sel ;
      private string AV82Trn_tilewwds_10_tftiletextcolor ;
      private string AV83Trn_tilewwds_11_tftiletextcolor_sel ;
      private string lV76Trn_tilewwds_4_tftileicon ;
      private string lV78Trn_tilewwds_6_tftilebgcolor ;
      private string lV82Trn_tilewwds_10_tftiletextcolor ;
      private string edtavDisplay_Link ;
      private string GXEncryptionTmp ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtTileName_Link ;
      private string edtTileBGImageUrl_Linktarget ;
      private string edtTileBGImageUrl_Link ;
      private string edtProductServiceName_Link ;
      private string edtSG_ToPageName_Link ;
      private string GXt_char3 ;
      private string GXt_char5 ;
      private string GXt_char12 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtTileId_Jsonclick ;
      private string edtTileName_Jsonclick ;
      private string edtTileIcon_Jsonclick ;
      private string edtTileBGColor_Jsonclick ;
      private string edtTileBGImageUrl_Jsonclick ;
      private string edtTileTextColor_Jsonclick ;
      private string GXCCtl ;
      private string cmbTileTextAlignment_Jsonclick ;
      private string cmbTileIconAlignment_Jsonclick ;
      private string edtProductServiceId_Jsonclick ;
      private string edtProductServiceName_Jsonclick ;
      private string edtProductServiceDescription_Jsonclick ;
      private string sImgUrl ;
      private string edtSG_ToPageId_Jsonclick ;
      private string edtSG_ToPageName_Jsonclick ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV45IsAuthorized_Display ;
      private bool AV47IsAuthorized_Update ;
      private bool AV49IsAuthorized_Delete ;
      private bool AV70IsAuthorized_TileName ;
      private bool AV42IsAuthorized_ProductServiceName ;
      private bool AV53IsAuthorized_SG_ToPageName ;
      private bool AV50IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n401TileIcon ;
      private bool n402TileBGColor ;
      private bool n403TileBGImageUrl ;
      private bool n58ProductServiceId ;
      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean1 ;
      private bool A61ProductServiceImage_IsBlob ;
      private string AV66TFTileTextAlignment_SelsJson ;
      private string AV68TFTileIconAlignment_SelsJson ;
      private string A60ProductServiceDescription ;
      private string AV18ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV56TFTileName ;
      private string AV57TFTileName_Sel ;
      private string AV62TFTileBGImageUrl ;
      private string AV63TFTileBGImageUrl_Sel ;
      private string AV28TFProductServiceName ;
      private string AV29TFProductServiceName_Sel ;
      private string AV51TFSG_ToPageName ;
      private string AV52TFSG_ToPageName_Sel ;
      private string AV40GridAppliedFilters ;
      private string A400TileName ;
      private string A403TileBGImageUrl ;
      private string A59ProductServiceName ;
      private string A40000ProductServiceImage_GXI ;
      private string A330SG_ToPageName ;
      private string AV73Trn_tilewwds_1_filterfulltext ;
      private string AV74Trn_tilewwds_2_tftilename ;
      private string AV75Trn_tilewwds_3_tftilename_sel ;
      private string AV80Trn_tilewwds_8_tftilebgimageurl ;
      private string AV81Trn_tilewwds_9_tftilebgimageurl_sel ;
      private string AV86Trn_tilewwds_14_tfproductservicename ;
      private string AV87Trn_tilewwds_15_tfproductservicename_sel ;
      private string AV88Trn_tilewwds_16_tfsg_topagename ;
      private string AV89Trn_tilewwds_17_tfsg_topagename_sel ;
      private string lV73Trn_tilewwds_1_filterfulltext ;
      private string lV74Trn_tilewwds_2_tftilename ;
      private string lV80Trn_tilewwds_8_tftilebgimageurl ;
      private string lV86Trn_tilewwds_14_tfproductservicename ;
      private string lV88Trn_tilewwds_16_tfsg_topagename ;
      private string AV71AuxText ;
      private string A61ProductServiceImage ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A407TileId ;
      private Guid A58ProductServiceId ;
      private Guid A329SG_ToPageId ;
      private IGxSession AV16Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTileTextAlignment ;
      private GXCombobox cmbTileIconAlignment ;
      private GxSimpleCollection<string> AV67TFTileTextAlignment_Sels ;
      private GxSimpleCollection<string> AV69TFTileIconAlignment_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV34DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GxSimpleCollection<string> AV84Trn_tilewwds_12_tftiletextalignment_sels ;
      private GxSimpleCollection<string> AV85Trn_tilewwds_13_tftileiconalignment_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005Z2_A11OrganisationId ;
      private bool[] H005Z2_n11OrganisationId ;
      private Guid[] H005Z2_A29LocationId ;
      private bool[] H005Z2_n29LocationId ;
      private string[] H005Z2_A330SG_ToPageName ;
      private Guid[] H005Z2_A329SG_ToPageId ;
      private string[] H005Z2_A40000ProductServiceImage_GXI ;
      private string[] H005Z2_A60ProductServiceDescription ;
      private string[] H005Z2_A59ProductServiceName ;
      private Guid[] H005Z2_A58ProductServiceId ;
      private bool[] H005Z2_n58ProductServiceId ;
      private string[] H005Z2_A406TileIconAlignment ;
      private string[] H005Z2_A405TileTextAlignment ;
      private string[] H005Z2_A404TileTextColor ;
      private string[] H005Z2_A403TileBGImageUrl ;
      private bool[] H005Z2_n403TileBGImageUrl ;
      private string[] H005Z2_A402TileBGColor ;
      private bool[] H005Z2_n402TileBGColor ;
      private string[] H005Z2_A401TileIcon ;
      private bool[] H005Z2_n401TileIcon ;
      private string[] H005Z2_A400TileName ;
      private Guid[] H005Z2_A407TileId ;
      private string[] H005Z2_A61ProductServiceImage ;
      private Guid[] H005Z3_A11OrganisationId ;
      private bool[] H005Z3_n11OrganisationId ;
      private Guid[] H005Z3_A29LocationId ;
      private bool[] H005Z3_n29LocationId ;
      private string[] H005Z3_A330SG_ToPageName ;
      private Guid[] H005Z3_A329SG_ToPageId ;
      private string[] H005Z3_A40000ProductServiceImage_GXI ;
      private string[] H005Z3_A60ProductServiceDescription ;
      private string[] H005Z3_A59ProductServiceName ;
      private Guid[] H005Z3_A58ProductServiceId ;
      private bool[] H005Z3_n58ProductServiceId ;
      private string[] H005Z3_A406TileIconAlignment ;
      private string[] H005Z3_A405TileTextAlignment ;
      private string[] H005Z3_A404TileTextColor ;
      private string[] H005Z3_A403TileBGImageUrl ;
      private bool[] H005Z3_n403TileBGImageUrl ;
      private string[] H005Z3_A402TileBGColor ;
      private bool[] H005Z3_n402TileBGColor ;
      private string[] H005Z3_A401TileIcon ;
      private bool[] H005Z3_n401TileIcon ;
      private string[] H005Z3_A400TileName ;
      private Guid[] H005Z3_A407TileId ;
      private string[] H005Z3_A61ProductServiceImage ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV35GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV36GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_tileww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005Z2( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV84Trn_tilewwds_12_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV85Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV75Trn_tilewwds_3_tftilename_sel ,
                                             string AV74Trn_tilewwds_2_tftilename ,
                                             string AV77Trn_tilewwds_5_tftileicon_sel ,
                                             string AV76Trn_tilewwds_4_tftileicon ,
                                             string AV79Trn_tilewwds_7_tftilebgcolor_sel ,
                                             string AV78Trn_tilewwds_6_tftilebgcolor ,
                                             string AV81Trn_tilewwds_9_tftilebgimageurl_sel ,
                                             string AV80Trn_tilewwds_8_tftilebgimageurl ,
                                             string AV83Trn_tilewwds_11_tftiletextcolor_sel ,
                                             string AV82Trn_tilewwds_10_tftiletextcolor ,
                                             int AV84Trn_tilewwds_12_tftiletextalignment_sels_Count ,
                                             int AV85Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV87Trn_tilewwds_15_tfproductservicename_sel ,
                                             string AV86Trn_tilewwds_14_tfproductservicename ,
                                             string AV89Trn_tilewwds_17_tfsg_topagename_sel ,
                                             string AV88Trn_tilewwds_16_tfsg_topagename ,
                                             string A400TileName ,
                                             string A401TileIcon ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A59ProductServiceName ,
                                             string A330SG_ToPageName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV73Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[14];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.OrganisationId, T1.LocationId, T2.Trn_PageName AS SG_ToPageName, T1.SG_ToPageId AS SG_ToPageId, T3.ProductServiceImage_GXI, T3.ProductServiceDescription, T3.ProductServiceName, T1.ProductServiceId, T1.TileIconAlignment, T1.TileTextAlignment, T1.TileTextColor, T1.TileBGImageUrl, T1.TileBGColor, T1.TileIcon, T1.TileName, T1.TileId, T3.ProductServiceImage FROM ((Trn_Tile T1 INNER JOIN Trn_Page T2 ON T2.Trn_PageId = T1.SG_ToPageId) LEFT JOIN Trn_ProductService T3 ON T3.ProductServiceId = T1.ProductServiceId AND T3.LocationId = T1.LocationId AND T3.OrganisationId = T1.OrganisationId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(T1.TileName like :lV74Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int13[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV75Trn_tilewwds_3_tftilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileName = ( :AV75Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         if ( StringUtil.StrCmp(AV75Trn_tilewwds_3_tftilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_tilewwds_5_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_4_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon like :lV76Trn_tilewwds_4_tftileicon)");
         }
         else
         {
            GXv_int13[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_tilewwds_5_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV77Trn_tilewwds_5_tftileicon_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon = ( :AV77Trn_tilewwds_5_tftileicon_sel))");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         if ( StringUtil.StrCmp(AV77Trn_tilewwds_5_tftileicon_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.TileIcon IS NULL or (char_length(trim(trailing ' ' from T1.TileIcon))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_tilewwds_7_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_tilewwds_6_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor like :lV78Trn_tilewwds_6_tftilebgcolor)");
         }
         else
         {
            GXv_int13[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_tilewwds_7_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV79Trn_tilewwds_7_tftilebgcolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor = ( :AV79Trn_tilewwds_7_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int13[5] = 1;
         }
         if ( StringUtil.StrCmp(AV79Trn_tilewwds_7_tftilebgcolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGColor IS NULL or (char_length(trim(trailing ' ' from T1.TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_tilewwds_9_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_8_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl like :lV80Trn_tilewwds_8_tftilebgimageurl)");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_tilewwds_9_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV81Trn_tilewwds_9_tftilebgimageurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl = ( :AV81Trn_tilewwds_9_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int13[7] = 1;
         }
         if ( StringUtil.StrCmp(AV81Trn_tilewwds_9_tftilebgimageurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from T1.TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Trn_tilewwds_11_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_10_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor like :lV82Trn_tilewwds_10_tftiletextcolor)");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Trn_tilewwds_11_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV83Trn_tilewwds_11_tftiletextcolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor = ( :AV83Trn_tilewwds_11_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( StringUtil.StrCmp(AV83Trn_tilewwds_11_tftiletextcolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileTextColor))=0))");
         }
         if ( AV84Trn_tilewwds_12_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV84Trn_tilewwds_12_tftiletextalignment_sels, "T1.TileTextAlignment IN (", ")")+")");
         }
         if ( AV85Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV85Trn_tilewwds_13_tftileiconalignment_sels, "T1.TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Trn_tilewwds_15_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Trn_tilewwds_14_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName like :lV86Trn_tilewwds_14_tfproductservicename)");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Trn_tilewwds_15_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV87Trn_tilewwds_15_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName = ( :AV87Trn_tilewwds_15_tfproductservicename_sel))");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( StringUtil.StrCmp(AV87Trn_tilewwds_15_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T3.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Trn_tilewwds_17_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Trn_tilewwds_16_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T2.Trn_PageName like :lV88Trn_tilewwds_16_tfsg_topagename)");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Trn_tilewwds_17_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV89Trn_tilewwds_17_tfsg_topagename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.Trn_PageName = ( :AV89Trn_tilewwds_17_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( StringUtil.StrCmp(AV89Trn_tilewwds_17_tfsg_topagename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileName, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileName DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileId DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileIcon, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileIcon DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileBGColor, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileBGColor DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileBGImageUrl, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileBGImageUrl DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileTextColor, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileTextColor DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileTextAlignment, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileTextAlignment DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileIconAlignment, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileIconAlignment DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ProductServiceName, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ProductServiceName DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SG_ToPageId, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SG_ToPageId DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.Trn_PageName, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.Trn_PageName DESC, T1.TileId";
         }
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_H005Z3( IGxContext context ,
                                             string A405TileTextAlignment ,
                                             GxSimpleCollection<string> AV84Trn_tilewwds_12_tftiletextalignment_sels ,
                                             string A406TileIconAlignment ,
                                             GxSimpleCollection<string> AV85Trn_tilewwds_13_tftileiconalignment_sels ,
                                             string AV75Trn_tilewwds_3_tftilename_sel ,
                                             string AV74Trn_tilewwds_2_tftilename ,
                                             string AV77Trn_tilewwds_5_tftileicon_sel ,
                                             string AV76Trn_tilewwds_4_tftileicon ,
                                             string AV79Trn_tilewwds_7_tftilebgcolor_sel ,
                                             string AV78Trn_tilewwds_6_tftilebgcolor ,
                                             string AV81Trn_tilewwds_9_tftilebgimageurl_sel ,
                                             string AV80Trn_tilewwds_8_tftilebgimageurl ,
                                             string AV83Trn_tilewwds_11_tftiletextcolor_sel ,
                                             string AV82Trn_tilewwds_10_tftiletextcolor ,
                                             int AV84Trn_tilewwds_12_tftiletextalignment_sels_Count ,
                                             int AV85Trn_tilewwds_13_tftileiconalignment_sels_Count ,
                                             string AV87Trn_tilewwds_15_tfproductservicename_sel ,
                                             string AV86Trn_tilewwds_14_tfproductservicename ,
                                             string AV89Trn_tilewwds_17_tfsg_topagename_sel ,
                                             string AV88Trn_tilewwds_16_tfsg_topagename ,
                                             string A400TileName ,
                                             string A401TileIcon ,
                                             string A402TileBGColor ,
                                             string A403TileBGImageUrl ,
                                             string A404TileTextColor ,
                                             string A59ProductServiceName ,
                                             string A330SG_ToPageName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV73Trn_tilewwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[14];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT T1.OrganisationId, T1.LocationId, T2.Trn_PageName AS SG_ToPageName, T1.SG_ToPageId AS SG_ToPageId, T3.ProductServiceImage_GXI, T3.ProductServiceDescription, T3.ProductServiceName, T1.ProductServiceId, T1.TileIconAlignment, T1.TileTextAlignment, T1.TileTextColor, T1.TileBGImageUrl, T1.TileBGColor, T1.TileIcon, T1.TileName, T1.TileId, T3.ProductServiceImage FROM ((Trn_Tile T1 INNER JOIN Trn_Page T2 ON T2.Trn_PageId = T1.SG_ToPageId) LEFT JOIN Trn_ProductService T3 ON T3.ProductServiceId = T1.ProductServiceId AND T3.LocationId = T1.LocationId AND T3.OrganisationId = T1.OrganisationId)";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_tilewwds_3_tftilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_tilewwds_2_tftilename)) ) )
         {
            AddWhere(sWhereString, "(T1.TileName like :lV74Trn_tilewwds_2_tftilename)");
         }
         else
         {
            GXv_int15[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Trn_tilewwds_3_tftilename_sel)) && ! ( StringUtil.StrCmp(AV75Trn_tilewwds_3_tftilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileName = ( :AV75Trn_tilewwds_3_tftilename_sel))");
         }
         else
         {
            GXv_int15[1] = 1;
         }
         if ( StringUtil.StrCmp(AV75Trn_tilewwds_3_tftilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_tilewwds_5_tftileicon_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Trn_tilewwds_4_tftileicon)) ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon like :lV76Trn_tilewwds_4_tftileicon)");
         }
         else
         {
            GXv_int15[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_tilewwds_5_tftileicon_sel)) && ! ( StringUtil.StrCmp(AV77Trn_tilewwds_5_tftileicon_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileIcon = ( :AV77Trn_tilewwds_5_tftileicon_sel))");
         }
         else
         {
            GXv_int15[3] = 1;
         }
         if ( StringUtil.StrCmp(AV77Trn_tilewwds_5_tftileicon_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.TileIcon IS NULL or (char_length(trim(trailing ' ' from T1.TileIcon))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_tilewwds_7_tftilebgcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_tilewwds_6_tftilebgcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor like :lV78Trn_tilewwds_6_tftilebgcolor)");
         }
         else
         {
            GXv_int15[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_tilewwds_7_tftilebgcolor_sel)) && ! ( StringUtil.StrCmp(AV79Trn_tilewwds_7_tftilebgcolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGColor = ( :AV79Trn_tilewwds_7_tftilebgcolor_sel))");
         }
         else
         {
            GXv_int15[5] = 1;
         }
         if ( StringUtil.StrCmp(AV79Trn_tilewwds_7_tftilebgcolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGColor IS NULL or (char_length(trim(trailing ' ' from T1.TileBGColor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_tilewwds_9_tftilebgimageurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_tilewwds_8_tftilebgimageurl)) ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl like :lV80Trn_tilewwds_8_tftilebgimageurl)");
         }
         else
         {
            GXv_int15[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Trn_tilewwds_9_tftilebgimageurl_sel)) && ! ( StringUtil.StrCmp(AV81Trn_tilewwds_9_tftilebgimageurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl = ( :AV81Trn_tilewwds_9_tftilebgimageurl_sel))");
         }
         else
         {
            GXv_int15[7] = 1;
         }
         if ( StringUtil.StrCmp(AV81Trn_tilewwds_9_tftilebgimageurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.TileBGImageUrl IS NULL or (char_length(trim(trailing ' ' from T1.TileBGImageUrl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Trn_tilewwds_11_tftiletextcolor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Trn_tilewwds_10_tftiletextcolor)) ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor like :lV82Trn_tilewwds_10_tftiletextcolor)");
         }
         else
         {
            GXv_int15[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Trn_tilewwds_11_tftiletextcolor_sel)) && ! ( StringUtil.StrCmp(AV83Trn_tilewwds_11_tftiletextcolor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.TileTextColor = ( :AV83Trn_tilewwds_11_tftiletextcolor_sel))");
         }
         else
         {
            GXv_int15[9] = 1;
         }
         if ( StringUtil.StrCmp(AV83Trn_tilewwds_11_tftiletextcolor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.TileTextColor))=0))");
         }
         if ( AV84Trn_tilewwds_12_tftiletextalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV84Trn_tilewwds_12_tftiletextalignment_sels, "T1.TileTextAlignment IN (", ")")+")");
         }
         if ( AV85Trn_tilewwds_13_tftileiconalignment_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV85Trn_tilewwds_13_tftileiconalignment_sels, "T1.TileIconAlignment IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Trn_tilewwds_15_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Trn_tilewwds_14_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName like :lV86Trn_tilewwds_14_tfproductservicename)");
         }
         else
         {
            GXv_int15[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Trn_tilewwds_15_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV87Trn_tilewwds_15_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName = ( :AV87Trn_tilewwds_15_tfproductservicename_sel))");
         }
         else
         {
            GXv_int15[11] = 1;
         }
         if ( StringUtil.StrCmp(AV87Trn_tilewwds_15_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ProductServiceName IS NULL or (char_length(trim(trailing ' ' from T3.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Trn_tilewwds_17_tfsg_topagename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Trn_tilewwds_16_tfsg_topagename)) ) )
         {
            AddWhere(sWhereString, "(T2.Trn_PageName like :lV88Trn_tilewwds_16_tfsg_topagename)");
         }
         else
         {
            GXv_int15[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Trn_tilewwds_17_tfsg_topagename_sel)) && ! ( StringUtil.StrCmp(AV89Trn_tilewwds_17_tfsg_topagename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.Trn_PageName = ( :AV89Trn_tilewwds_17_tfsg_topagename_sel))");
         }
         else
         {
            GXv_int15[13] = 1;
         }
         if ( StringUtil.StrCmp(AV89Trn_tilewwds_17_tfsg_topagename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.Trn_PageName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileName, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileName DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileId DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileIcon, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileIcon DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileBGColor, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileBGColor DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileBGImageUrl, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileBGImageUrl DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileTextColor, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileTextColor DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileTextAlignment, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileTextAlignment DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.TileIconAlignment, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.TileIconAlignment DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ProductServiceName, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ProductServiceName DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SG_ToPageId, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SG_ToPageId DESC, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.Trn_PageName, T1.TileId";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.Trn_PageName DESC, T1.TileId";
         }
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005Z2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] );
               case 1 :
                     return conditional_H005Z3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] );
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
          Object[] prmH005Z2;
          prmH005Z2 = new Object[] {
          new ParDef("lV74Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV75Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV76Trn_tilewwds_4_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV77Trn_tilewwds_5_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV78Trn_tilewwds_6_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV79Trn_tilewwds_7_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV80Trn_tilewwds_8_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV81Trn_tilewwds_9_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV82Trn_tilewwds_10_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV83Trn_tilewwds_11_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV86Trn_tilewwds_14_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV87Trn_tilewwds_15_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV88Trn_tilewwds_16_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV89Trn_tilewwds_17_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          Object[] prmH005Z3;
          prmH005Z3 = new Object[] {
          new ParDef("lV74Trn_tilewwds_2_tftilename",GXType.VarChar,100,0) ,
          new ParDef("AV75Trn_tilewwds_3_tftilename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV76Trn_tilewwds_4_tftileicon",GXType.Char,20,0) ,
          new ParDef("AV77Trn_tilewwds_5_tftileicon_sel",GXType.Char,20,0) ,
          new ParDef("lV78Trn_tilewwds_6_tftilebgcolor",GXType.Char,20,0) ,
          new ParDef("AV79Trn_tilewwds_7_tftilebgcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV80Trn_tilewwds_8_tftilebgimageurl",GXType.VarChar,1000,0) ,
          new ParDef("AV81Trn_tilewwds_9_tftilebgimageurl_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV82Trn_tilewwds_10_tftiletextcolor",GXType.Char,20,0) ,
          new ParDef("AV83Trn_tilewwds_11_tftiletextcolor_sel",GXType.Char,20,0) ,
          new ParDef("lV86Trn_tilewwds_14_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV87Trn_tilewwds_15_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV88Trn_tilewwds_16_tfsg_topagename",GXType.VarChar,100,0) ,
          new ParDef("AV89Trn_tilewwds_17_tfsg_topagename_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005Z2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005Z3,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 20);
                ((string[]) buf[12])[0] = rslt.getString(10, 20);
                ((string[]) buf[13])[0] = rslt.getString(11, 20);
                ((string[]) buf[14])[0] = rslt.getVarchar(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 20);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getString(14, 20);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getVarchar(15);
                ((Guid[]) buf[21])[0] = rslt.getGuid(16);
                ((string[]) buf[22])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(5));
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 20);
                ((string[]) buf[12])[0] = rslt.getString(10, 20);
                ((string[]) buf[13])[0] = rslt.getString(11, 20);
                ((string[]) buf[14])[0] = rslt.getVarchar(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 20);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getString(14, 20);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getVarchar(15);
                ((Guid[]) buf[21])[0] = rslt.getGuid(16);
                ((string[]) buf[22])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(5));
                return;
       }
    }

 }

}
