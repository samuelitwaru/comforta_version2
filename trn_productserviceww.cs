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
   public class trn_productserviceww : GXDataArea
   {
      public trn_productserviceww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_productserviceww( IGxContext context )
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
         cmbProductServiceGroup = new GXCombobox();
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
         AV39LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         AV19ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV56Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV20TFProductServiceName = GetPar( "TFProductServiceName");
         AV21TFProductServiceName_Sel = GetPar( "TFProductServiceName_Sel");
         AV48TFProductServiceTileName = GetPar( "TFProductServiceTileName");
         AV49TFProductServiceTileName_Sel = GetPar( "TFProductServiceTileName_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV55TFProductServiceGroup_Sels);
         AV33IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV35IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV37IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV38IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV39LocationId, AV19ManageFiltersExecutionStep, AV56Pgmname, AV15FilterFullText, AV20TFProductServiceName, AV21TFProductServiceName_Sel, AV48TFProductServiceTileName, AV49TFProductServiceTileName_Sel, AV55TFProductServiceGroup_Sels, AV33IsAuthorized_Display, AV35IsAuthorized_Update, AV37IsAuthorized_Delete, AV38IsAuthorized_Insert) ;
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
            return "trn_productserviceww_Execute" ;
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
         PA5A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5A2( ) ;
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_productserviceww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV33IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV33IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV35IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV35IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV37IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV37IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV38IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV38IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV30GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV24DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV24DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPRODUCTSERVICENAME", AV20TFProductServiceName);
         GxWebStd.gx_hidden_field( context, "vTFPRODUCTSERVICENAME_SEL", AV21TFProductServiceName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPRODUCTSERVICETILENAME", StringUtil.RTrim( AV48TFProductServiceTileName));
         GxWebStd.gx_hidden_field( context, "vTFPRODUCTSERVICETILENAME_SEL", StringUtil.RTrim( AV49TFProductServiceTileName_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPRODUCTSERVICEGROUP_SELS", AV55TFProductServiceGroup_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPRODUCTSERVICEGROUP_SELS", AV55TFProductServiceGroup_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV33IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV33IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV35IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV35IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV37IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV37IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFPRODUCTSERVICEGROUP_SELSJSON", AV54TFProductServiceGroup_SelsJson);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV38IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV38IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV39LocationId.ToString());
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
         GxWebStd.gx_hidden_field( context, "POPOVER_DESCRIPTION_Gridinternalname", StringUtil.RTrim( Popover_description_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "POPOVER_DESCRIPTION_Iteminternalname", StringUtil.RTrim( Popover_description_Iteminternalname));
         GxWebStd.gx_hidden_field( context, "POPOVER_DESCRIPTION_Isgriditem", StringUtil.BoolToStr( Popover_description_Isgriditem));
         GxWebStd.gx_hidden_field( context, "POPOVER_DESCRIPTION_Trigger", StringUtil.RTrim( Popover_description_Trigger));
         GxWebStd.gx_hidden_field( context, "POPOVER_DESCRIPTION_Triggerelement", StringUtil.RTrim( Popover_description_Triggerelement));
         GxWebStd.gx_hidden_field( context, "POPOVER_DESCRIPTION_Popoverwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Popover_description_Popoverwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POPOVER_DESCRIPTION_Position", StringUtil.RTrim( Popover_description_Position));
         GxWebStd.gx_hidden_field( context, "POPOVER_DESCRIPTION_Keepopened", StringUtil.BoolToStr( Popover_description_Keepopened));
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Popoversingrid", StringUtil.RTrim( Grid_empowerer_Popoversingrid));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
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
            WE5A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5A2( ) ;
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
         return formatLink("trn_productserviceww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_ProductServiceWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Products/Services", "") ;
      }

      protected void WB5A0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ProductServiceWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ProductServiceWW.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_Trn_ProductServiceWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV28GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV29GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV30GridAppliedFilters);
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
            ucPopover_description.SetProperty("IsGridItem", Popover_description_Isgriditem);
            ucPopover_description.SetProperty("Trigger", Popover_description_Trigger);
            ucPopover_description.SetProperty("TriggerElement", Popover_description_Triggerelement);
            ucPopover_description.SetProperty("PopoverWidth", Popover_description_Popoverwidth);
            ucPopover_description.SetProperty("Position", Popover_description_Position);
            ucPopover_description.SetProperty("KeepOpened", Popover_description_Keepopened);
            ucPopover_description.Render(context, "dvelop.wwppopover", Popover_description_Internalname, "POPOVER_DESCRIPTIONContainer");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV24DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("PopoversInGrid", Grid_empowerer_Popoversingrid);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0067"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0067"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_37_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0067"+"");
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

      protected void START5A2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Products/Services", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5A0( ) ;
      }

      protected void WS5A2( )
      {
         START5A2( ) ;
         EVT5A2( ) ;
      }

      protected void EVT5A2( )
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
                              E115A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E125A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E135A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E145A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E155A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E165A2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VDESCRIPTION.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VDESCRIPTION.CLICK") == 0 ) )
                           {
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              A58ProductServiceId = StringUtil.StrToGuid( cgiGet( edtProductServiceId_Internalname));
                              A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              A59ProductServiceName = cgiGet( edtProductServiceName_Internalname);
                              A301ProductServiceTileName = cgiGet( edtProductServiceTileName_Internalname);
                              A61ProductServiceImage = cgiGet( edtProductServiceImage_Internalname);
                              AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
                              AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
                              A42SupplierGenId = StringUtil.StrToGuid( cgiGet( edtSupplierGenId_Internalname));
                              n42SupplierGenId = false;
                              A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
                              A49SupplierAgbId = StringUtil.StrToGuid( cgiGet( edtSupplierAgbId_Internalname));
                              n49SupplierAgbId = false;
                              cmbProductServiceGroup.Name = cmbProductServiceGroup_Internalname;
                              cmbProductServiceGroup.CurrentValue = cgiGet( cmbProductServiceGroup_Internalname);
                              A366ProductServiceGroup = cgiGet( cmbProductServiceGroup_Internalname);
                              AV50Supplier = cgiGet( edtavSupplier_Internalname);
                              AssignAttri("", false, edtavSupplier_Internalname, AV50Supplier);
                              AV52DescriptionWithTags = cgiGet( edtavDescriptionwithtags_Internalname);
                              AssignAttri("", false, edtavDescriptionwithtags_Internalname, AV52DescriptionWithTags);
                              AV51Description = cgiGet( edtavDescription_Internalname);
                              AssignAttri("", false, edtavDescription_Internalname, AV51Description);
                              A51SupplierAgbName = cgiGet( edtSupplierAgbName_Internalname);
                              A60ProductServiceDescription = cgiGet( edtProductServiceDescription_Internalname);
                              AV32Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV32Display);
                              AV34Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV34Update);
                              AV36Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV36Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E175A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E185A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E195A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDESCRIPTION.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E205A2 ();
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
                        if ( nCmpId == 67 )
                        {
                           OldWwpaux_wc = cgiGet( "W0067");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0067", "", sEvt);
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

      protected void WE5A2( )
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

      protected void PA5A2( )
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
                                       Guid AV39LocationId ,
                                       short AV19ManageFiltersExecutionStep ,
                                       string AV56Pgmname ,
                                       string AV15FilterFullText ,
                                       string AV20TFProductServiceName ,
                                       string AV21TFProductServiceName_Sel ,
                                       string AV48TFProductServiceTileName ,
                                       string AV49TFProductServiceTileName_Sel ,
                                       GxSimpleCollection<string> AV55TFProductServiceGroup_Sels ,
                                       bool AV33IsAuthorized_Display ,
                                       bool AV35IsAuthorized_Update ,
                                       bool AV37IsAuthorized_Delete ,
                                       bool AV38IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5A2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTSERVICEID", GetSecureSignedToken( "", A58ProductServiceId, context));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEID", A58ProductServiceId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID", GetSecureSignedToken( "", A29LocationId, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTSERVICEDESCRIPTION", GetSecureSignedToken( "", A60ProductServiceDescription, context));
         GxWebStd.gx_hidden_field( context, "PRODUCTSERVICEDESCRIPTION", A60ProductServiceDescription);
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
         RF5A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV56Pgmname = "Trn_ProductServiceWW";
         edtavSupplier_Enabled = 0;
         edtavDescriptionwithtags_Enabled = 0;
         edtavDescription_Enabled = 0;
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV57Trn_productservicewwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_productservicewwds_2_tfproductservicename = AV20TFProductServiceName;
         AV59Trn_productservicewwds_3_tfproductservicename_sel = AV21TFProductServiceName_Sel;
         AV60Trn_productservicewwds_4_tfproductservicetilename = AV48TFProductServiceTileName;
         AV61Trn_productservicewwds_5_tfproductservicetilename_sel = AV49TFProductServiceTileName_Sel;
         AV62Trn_productservicewwds_6_tfproductservicegroup_sels = AV55TFProductServiceGroup_Sels;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A366ProductServiceGroup ,
                                              AV62Trn_productservicewwds_6_tfproductservicegroup_sels ,
                                              AV59Trn_productservicewwds_3_tfproductservicename_sel ,
                                              AV58Trn_productservicewwds_2_tfproductservicename ,
                                              AV61Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                              AV60Trn_productservicewwds_4_tfproductservicetilename ,
                                              AV62Trn_productservicewwds_6_tfproductservicegroup_sels.Count ,
                                              A59ProductServiceName ,
                                              A301ProductServiceTileName ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV57Trn_productservicewwds_1_filterfulltext ,
                                              A29LocationId ,
                                              AV39LocationId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV58Trn_productservicewwds_2_tfproductservicename), "%", "");
         lV60Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV60Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
         /* Using cursor H005A2 */
         pr_default.execute(0, new Object[] {AV39LocationId, lV58Trn_productservicewwds_2_tfproductservicename, AV59Trn_productservicewwds_3_tfproductservicename_sel, lV60Trn_productservicewwds_4_tfproductservicetilename, AV61Trn_productservicewwds_5_tfproductservicetilename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A60ProductServiceDescription = H005A2_A60ProductServiceDescription[0];
            A51SupplierAgbName = H005A2_A51SupplierAgbName[0];
            A366ProductServiceGroup = H005A2_A366ProductServiceGroup[0];
            A49SupplierAgbId = H005A2_A49SupplierAgbId[0];
            n49SupplierAgbId = H005A2_n49SupplierAgbId[0];
            A44SupplierGenCompanyName = H005A2_A44SupplierGenCompanyName[0];
            A42SupplierGenId = H005A2_A42SupplierGenId[0];
            n42SupplierGenId = H005A2_n42SupplierGenId[0];
            A40000ProductServiceImage_GXI = H005A2_A40000ProductServiceImage_GXI[0];
            AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
            AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A301ProductServiceTileName = H005A2_A301ProductServiceTileName[0];
            A59ProductServiceName = H005A2_A59ProductServiceName[0];
            A11OrganisationId = H005A2_A11OrganisationId[0];
            A29LocationId = H005A2_A29LocationId[0];
            A58ProductServiceId = H005A2_A58ProductServiceId[0];
            A61ProductServiceImage = H005A2_A61ProductServiceImage[0];
            AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
            AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
            A51SupplierAgbName = H005A2_A51SupplierAgbName[0];
            A44SupplierGenCompanyName = H005A2_A44SupplierGenCompanyName[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_productservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV57Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A301ProductServiceTileName , StringUtil.PadR( "%" + AV57Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "agb supplier", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, " AGB Supplier") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "general supplier", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, "General Supplier") == 0 ) ) ) )
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

      protected void RF5A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E185A2 ();
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
                                                 A366ProductServiceGroup ,
                                                 AV62Trn_productservicewwds_6_tfproductservicegroup_sels ,
                                                 AV59Trn_productservicewwds_3_tfproductservicename_sel ,
                                                 AV58Trn_productservicewwds_2_tfproductservicename ,
                                                 AV61Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                                 AV60Trn_productservicewwds_4_tfproductservicetilename ,
                                                 AV62Trn_productservicewwds_6_tfproductservicegroup_sels.Count ,
                                                 A59ProductServiceName ,
                                                 A301ProductServiceTileName ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV57Trn_productservicewwds_1_filterfulltext ,
                                                 A29LocationId ,
                                                 AV39LocationId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV58Trn_productservicewwds_2_tfproductservicename = StringUtil.Concat( StringUtil.RTrim( AV58Trn_productservicewwds_2_tfproductservicename), "%", "");
            lV60Trn_productservicewwds_4_tfproductservicetilename = StringUtil.PadR( StringUtil.RTrim( AV60Trn_productservicewwds_4_tfproductservicetilename), 20, "%");
            /* Using cursor H005A3 */
            pr_default.execute(1, new Object[] {AV39LocationId, lV58Trn_productservicewwds_2_tfproductservicename, AV59Trn_productservicewwds_3_tfproductservicename_sel, lV60Trn_productservicewwds_4_tfproductservicetilename, AV61Trn_productservicewwds_5_tfproductservicetilename_sel});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A60ProductServiceDescription = H005A3_A60ProductServiceDescription[0];
               A51SupplierAgbName = H005A3_A51SupplierAgbName[0];
               A366ProductServiceGroup = H005A3_A366ProductServiceGroup[0];
               A49SupplierAgbId = H005A3_A49SupplierAgbId[0];
               n49SupplierAgbId = H005A3_n49SupplierAgbId[0];
               A44SupplierGenCompanyName = H005A3_A44SupplierGenCompanyName[0];
               A42SupplierGenId = H005A3_A42SupplierGenId[0];
               n42SupplierGenId = H005A3_n42SupplierGenId[0];
               A40000ProductServiceImage_GXI = H005A3_A40000ProductServiceImage_GXI[0];
               AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
               A301ProductServiceTileName = H005A3_A301ProductServiceTileName[0];
               A59ProductServiceName = H005A3_A59ProductServiceName[0];
               A11OrganisationId = H005A3_A11OrganisationId[0];
               A29LocationId = H005A3_A29LocationId[0];
               A58ProductServiceId = H005A3_A58ProductServiceId[0];
               A61ProductServiceImage = H005A3_A61ProductServiceImage[0];
               AssignProp("", false, edtProductServiceImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A61ProductServiceImage)) ? A40000ProductServiceImage_GXI : context.convertURL( context.PathToRelativeUrl( A61ProductServiceImage))), !bGXsfl_37_Refreshing);
               AssignProp("", false, edtProductServiceImage_Internalname, "SrcSet", context.GetImageSrcSet( A61ProductServiceImage), true);
               A51SupplierAgbName = H005A3_A51SupplierAgbName[0];
               A44SupplierGenCompanyName = H005A3_A44SupplierGenCompanyName[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_productservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( A59ProductServiceName , StringUtil.PadR( "%" + AV57Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A301ProductServiceTileName , StringUtil.PadR( "%" + AV57Trn_productservicewwds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "agb supplier", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, " AGB Supplier") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "general supplier", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Trn_productservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A366ProductServiceGroup, "General Supplier") == 0 ) ) ) )
               {
                  /* Execute user event: Grid.Load */
                  E195A2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WB5A0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5A2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV33IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV33IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV35IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV35IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV37IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV37IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV38IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV38IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTSERVICEID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A58ProductServiceId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A29LocationId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTSERVICEDESCRIPTION"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A60ProductServiceDescription, context));
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
         AV57Trn_productservicewwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_productservicewwds_2_tfproductservicename = AV20TFProductServiceName;
         AV59Trn_productservicewwds_3_tfproductservicename_sel = AV21TFProductServiceName_Sel;
         AV60Trn_productservicewwds_4_tfproductservicetilename = AV48TFProductServiceTileName;
         AV61Trn_productservicewwds_5_tfproductservicetilename_sel = AV49TFProductServiceTileName_Sel;
         AV62Trn_productservicewwds_6_tfproductservicegroup_sels = AV55TFProductServiceGroup_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV39LocationId, AV19ManageFiltersExecutionStep, AV56Pgmname, AV15FilterFullText, AV20TFProductServiceName, AV21TFProductServiceName_Sel, AV48TFProductServiceTileName, AV49TFProductServiceTileName_Sel, AV55TFProductServiceGroup_Sels, AV33IsAuthorized_Display, AV35IsAuthorized_Update, AV37IsAuthorized_Delete, AV38IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV57Trn_productservicewwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_productservicewwds_2_tfproductservicename = AV20TFProductServiceName;
         AV59Trn_productservicewwds_3_tfproductservicename_sel = AV21TFProductServiceName_Sel;
         AV60Trn_productservicewwds_4_tfproductservicetilename = AV48TFProductServiceTileName;
         AV61Trn_productservicewwds_5_tfproductservicetilename_sel = AV49TFProductServiceTileName_Sel;
         AV62Trn_productservicewwds_6_tfproductservicegroup_sels = AV55TFProductServiceGroup_Sels;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV39LocationId, AV19ManageFiltersExecutionStep, AV56Pgmname, AV15FilterFullText, AV20TFProductServiceName, AV21TFProductServiceName_Sel, AV48TFProductServiceTileName, AV49TFProductServiceTileName_Sel, AV55TFProductServiceGroup_Sels, AV33IsAuthorized_Display, AV35IsAuthorized_Update, AV37IsAuthorized_Delete, AV38IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV57Trn_productservicewwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_productservicewwds_2_tfproductservicename = AV20TFProductServiceName;
         AV59Trn_productservicewwds_3_tfproductservicename_sel = AV21TFProductServiceName_Sel;
         AV60Trn_productservicewwds_4_tfproductservicetilename = AV48TFProductServiceTileName;
         AV61Trn_productservicewwds_5_tfproductservicetilename_sel = AV49TFProductServiceTileName_Sel;
         AV62Trn_productservicewwds_6_tfproductservicegroup_sels = AV55TFProductServiceGroup_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV39LocationId, AV19ManageFiltersExecutionStep, AV56Pgmname, AV15FilterFullText, AV20TFProductServiceName, AV21TFProductServiceName_Sel, AV48TFProductServiceTileName, AV49TFProductServiceTileName_Sel, AV55TFProductServiceGroup_Sels, AV33IsAuthorized_Display, AV35IsAuthorized_Update, AV37IsAuthorized_Delete, AV38IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV57Trn_productservicewwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_productservicewwds_2_tfproductservicename = AV20TFProductServiceName;
         AV59Trn_productservicewwds_3_tfproductservicename_sel = AV21TFProductServiceName_Sel;
         AV60Trn_productservicewwds_4_tfproductservicetilename = AV48TFProductServiceTileName;
         AV61Trn_productservicewwds_5_tfproductservicetilename_sel = AV49TFProductServiceTileName_Sel;
         AV62Trn_productservicewwds_6_tfproductservicegroup_sels = AV55TFProductServiceGroup_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV39LocationId, AV19ManageFiltersExecutionStep, AV56Pgmname, AV15FilterFullText, AV20TFProductServiceName, AV21TFProductServiceName_Sel, AV48TFProductServiceTileName, AV49TFProductServiceTileName_Sel, AV55TFProductServiceGroup_Sels, AV33IsAuthorized_Display, AV35IsAuthorized_Update, AV37IsAuthorized_Delete, AV38IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV57Trn_productservicewwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_productservicewwds_2_tfproductservicename = AV20TFProductServiceName;
         AV59Trn_productservicewwds_3_tfproductservicename_sel = AV21TFProductServiceName_Sel;
         AV60Trn_productservicewwds_4_tfproductservicetilename = AV48TFProductServiceTileName;
         AV61Trn_productservicewwds_5_tfproductservicetilename_sel = AV49TFProductServiceTileName_Sel;
         AV62Trn_productservicewwds_6_tfproductservicegroup_sels = AV55TFProductServiceGroup_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV39LocationId, AV19ManageFiltersExecutionStep, AV56Pgmname, AV15FilterFullText, AV20TFProductServiceName, AV21TFProductServiceName_Sel, AV48TFProductServiceTileName, AV49TFProductServiceTileName_Sel, AV55TFProductServiceGroup_Sels, AV33IsAuthorized_Display, AV35IsAuthorized_Update, AV37IsAuthorized_Delete, AV38IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV56Pgmname = "Trn_ProductServiceWW";
         edtavSupplier_Enabled = 0;
         edtavDescriptionwithtags_Enabled = 0;
         edtavDescription_Enabled = 0;
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtProductServiceId_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtProductServiceName_Enabled = 0;
         edtProductServiceTileName_Enabled = 0;
         edtProductServiceImage_Enabled = 0;
         edtSupplierGenId_Enabled = 0;
         edtSupplierGenCompanyName_Enabled = 0;
         edtSupplierAgbId_Enabled = 0;
         cmbProductServiceGroup.Enabled = 0;
         edtSupplierAgbName_Enabled = 0;
         edtProductServiceDescription_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E175A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV24DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV28GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV29GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV30GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Popover_description_Gridinternalname = cgiGet( "POPOVER_DESCRIPTION_Gridinternalname");
            Popover_description_Iteminternalname = cgiGet( "POPOVER_DESCRIPTION_Iteminternalname");
            Popover_description_Isgriditem = StringUtil.StrToBool( cgiGet( "POPOVER_DESCRIPTION_Isgriditem"));
            Popover_description_Trigger = cgiGet( "POPOVER_DESCRIPTION_Trigger");
            Popover_description_Triggerelement = cgiGet( "POPOVER_DESCRIPTION_Triggerelement");
            Popover_description_Popoverwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POPOVER_DESCRIPTION_Popoverwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Popover_description_Position = cgiGet( "POPOVER_DESCRIPTION_Position");
            Popover_description_Keepopened = StringUtil.StrToBool( cgiGet( "POPOVER_DESCRIPTION_Keepopened"));
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
            Grid_empowerer_Popoversingrid = cgiGet( "GRID_EMPOWERER_Popoversingrid");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
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
         E175A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E175A2( )
      {
         /* Start Routine */
         returnInSub = false;
         Popover_description_Gridinternalname = subGrid_Internalname;
         ucPopover_description.SendProperty(context, "", false, Popover_description_Internalname, "GridInternalName", Popover_description_Gridinternalname);
         Popover_description_Iteminternalname = edtavDescriptionwithtags_Internalname;
         ucPopover_description.SendProperty(context, "", false, Popover_description_Internalname, "ItemInternalName", Popover_description_Iteminternalname);
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
         AV25GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV26GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV25GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " Products/Services", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV24DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV24DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         GXt_guid2 = AV39LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid2) ;
         AV39LocationId = GXt_guid2;
         AssignAttri("", false, "AV39LocationId", AV39LocationId.ToString());
      }

      protected void E185A2( )
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
         AV28GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV28GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV28GridCurrentPage), 10, 0));
         AV29GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV29GridPageCount", StringUtil.LTrimStr( (decimal)(AV29GridPageCount), 10, 0));
         GXt_char3 = AV30GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV56Pgmname, out  GXt_char3) ;
         AV30GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV30GridAppliedFilters", AV30GridAppliedFilters);
         AV57Trn_productservicewwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_productservicewwds_2_tfproductservicename = AV20TFProductServiceName;
         AV59Trn_productservicewwds_3_tfproductservicename_sel = AV21TFProductServiceName_Sel;
         AV60Trn_productservicewwds_4_tfproductservicetilename = AV48TFProductServiceTileName;
         AV61Trn_productservicewwds_5_tfproductservicetilename_sel = AV49TFProductServiceTileName_Sel;
         AV62Trn_productservicewwds_6_tfproductservicegroup_sels = AV55TFProductServiceGroup_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E125A2( )
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
            AV27PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV27PageToGo) ;
         }
      }

      protected void E135A2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E155A2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProductServiceName") == 0 )
            {
               AV20TFProductServiceName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV20TFProductServiceName", AV20TFProductServiceName);
               AV21TFProductServiceName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV21TFProductServiceName_Sel", AV21TFProductServiceName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProductServiceTileName") == 0 )
            {
               AV48TFProductServiceTileName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFProductServiceTileName", AV48TFProductServiceTileName);
               AV49TFProductServiceTileName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFProductServiceTileName_Sel", AV49TFProductServiceTileName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProductServiceGroup") == 0 )
            {
               AV54TFProductServiceGroup_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV54TFProductServiceGroup_SelsJson", AV54TFProductServiceGroup_SelsJson);
               AV55TFProductServiceGroup_Sels.FromJSonString(AV54TFProductServiceGroup_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55TFProductServiceGroup_Sels", AV55TFProductServiceGroup_Sels);
      }

      private void E195A2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            if ( (Guid.Empty==A49SupplierAgbId) )
            {
               AV50Supplier = A44SupplierGenCompanyName;
               AssignAttri("", false, edtavSupplier_Internalname, AV50Supplier);
            }
            else
            {
               AV50Supplier = A51SupplierAgbName;
               AssignAttri("", false, edtavSupplier_Internalname, AV50Supplier);
            }
            if ( StringUtil.Len( A60ProductServiceDescription) <= 30 )
            {
               AV51Description = A60ProductServiceDescription;
               AssignAttri("", false, edtavDescription_Internalname, AV51Description);
            }
            else
            {
               AV51Description = StringUtil.Substring( A60ProductServiceDescription, 1, 30) + "...";
               AssignAttri("", false, edtavDescription_Internalname, AV51Description);
            }
            AV32Display = "<i class=\"fa fa-search\"></i>";
            AssignAttri("", false, edtavDisplay_Internalname, AV32Display);
            if ( AV33IsAuthorized_Display )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "trn_productserviceview.aspx"+UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
               edtavDisplay_Link = formatLink("trn_productserviceview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            AV34Update = "<i class=\"fa fa-pen\"></i>";
            AssignAttri("", false, edtavUpdate_Internalname, AV34Update);
            if ( AV35IsAuthorized_Update )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "trn_productservice.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
               edtavUpdate_Link = formatLink("trn_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            AV36Delete = "<i class=\"fa fa-times\"></i>";
            AssignAttri("", false, edtavDelete_Internalname, AV36Delete);
            if ( AV37IsAuthorized_Delete )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "trn_productservice.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
               edtavDelete_Link = formatLink("trn_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            AV52DescriptionWithTags = AV51Description;
            AssignAttri("", false, edtavDescriptionwithtags_Internalname, AV52DescriptionWithTags);
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

      protected void E115A2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_ProductServiceWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV56Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_ProductServiceWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV18ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "Trn_ProductServiceWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV56Pgmname+"GridState",  AV18ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55TFProductServiceGroup_Sels", AV55TFProductServiceGroup_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void E165A2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV38IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_productservice.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("trn_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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

      protected void E145A2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0067",(string)"",(string)"Trn_ProductService",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0067"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E205A2( )
      {
         /* Description_Click Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WC_Description")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wc_description", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WC_Description";
            WebComp_Wwpaux_wc_Component = "WC_Description";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0067",(string)"",(string)A60ProductServiceDescription});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0067"+"");
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
         GXt_boolean4 = AV33IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_productserviceview_Execute", out  GXt_boolean4) ;
         AV33IsAuthorized_Display = GXt_boolean4;
         AssignAttri("", false, "AV33IsAuthorized_Display", AV33IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV33IsAuthorized_Display, context));
         if ( ! ( AV33IsAuthorized_Display ) )
         {
            edtavDisplay_Visible = 0;
            AssignProp("", false, edtavDisplay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDisplay_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean4 = AV35IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_productservice_Update", out  GXt_boolean4) ;
         AV35IsAuthorized_Update = GXt_boolean4;
         AssignAttri("", false, "AV35IsAuthorized_Update", AV35IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV35IsAuthorized_Update, context));
         if ( ! ( AV35IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean4 = AV37IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_productservice_Delete", out  GXt_boolean4) ;
         AV37IsAuthorized_Delete = GXt_boolean4;
         AssignAttri("", false, "AV37IsAuthorized_Delete", AV37IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV37IsAuthorized_Delete, context));
         if ( ! ( AV37IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean4 = AV38IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_productservice_Insert", out  GXt_boolean4) ;
         AV38IsAuthorized_Insert = GXt_boolean4;
         AssignAttri("", false, "AV38IsAuthorized_Insert", AV38IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV38IsAuthorized_Insert, context));
         if ( ! ( AV38IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_ProductService",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV17ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_ProductServiceWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV20TFProductServiceName = "";
         AssignAttri("", false, "AV20TFProductServiceName", AV20TFProductServiceName);
         AV21TFProductServiceName_Sel = "";
         AssignAttri("", false, "AV21TFProductServiceName_Sel", AV21TFProductServiceName_Sel);
         AV48TFProductServiceTileName = "";
         AssignAttri("", false, "AV48TFProductServiceTileName", AV48TFProductServiceTileName);
         AV49TFProductServiceTileName_Sel = "";
         AssignAttri("", false, "AV49TFProductServiceTileName_Sel", AV49TFProductServiceTileName_Sel);
         AV55TFProductServiceGroup_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV56Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV56Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV56Pgmname+"GridState"), null, "", "");
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
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV63GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME") == 0 )
            {
               AV20TFProductServiceName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20TFProductServiceName", AV20TFProductServiceName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICENAME_SEL") == 0 )
            {
               AV21TFProductServiceName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV21TFProductServiceName_Sel", AV21TFProductServiceName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETILENAME") == 0 )
            {
               AV48TFProductServiceTileName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFProductServiceTileName", AV48TFProductServiceTileName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICETILENAME_SEL") == 0 )
            {
               AV49TFProductServiceTileName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFProductServiceTileName_Sel", AV49TFProductServiceTileName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPRODUCTSERVICEGROUP_SEL") == 0 )
            {
               AV54TFProductServiceGroup_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFProductServiceGroup_SelsJson", AV54TFProductServiceGroup_SelsJson);
               AV55TFProductServiceGroup_Sels.FromJSonString(AV54TFProductServiceGroup_SelsJson, null);
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProductServiceName_Sel)),  AV21TFProductServiceName_Sel, out  GXt_char3) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProductServiceTileName_Sel)),  AV49TFProductServiceTileName_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV55TFProductServiceGroup_Sels.Count==0),  AV54TFProductServiceGroup_SelsJson, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProductServiceName)),  AV20TFProductServiceName, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProductServiceTileName)),  AV48TFProductServiceTileName, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+GXt_char6+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV56Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPRODUCTSERVICENAME",  context.GetMessage( "Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProductServiceName)),  0,  AV20TFProductServiceName,  AV20TFProductServiceName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProductServiceName_Sel)),  AV21TFProductServiceName_Sel,  AV21TFProductServiceName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPRODUCTSERVICETILENAME",  context.GetMessage( "Tile Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProductServiceTileName)),  0,  AV48TFProductServiceTileName,  AV48TFProductServiceTileName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProductServiceTileName_Sel)),  AV49TFProductServiceTileName_Sel,  AV49TFProductServiceTileName_Sel) ;
         AV45AuxText = ((AV55TFProductServiceGroup_Sels.Count==1) ? "["+((string)AV55TFProductServiceGroup_Sels.Item(1))+"]" : context.GetMessage( "WWP_FilterValueDescription_MultipleValues", ""));
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPRODUCTSERVICEGROUP_SEL",  context.GetMessage( "Category", ""),  !(AV55TFProductServiceGroup_Sels.Count==0),  0,  AV55TFProductServiceGroup_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV45AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV45AuxText, "[AGB Supplier]", context.GetMessage( "AGB Supplier", "")), "[General Supplier]", context.GetMessage( "General Supplier", ""))),  false,  "",  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV56Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV56Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_ProductService";
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
         PA5A2( ) ;
         WS5A2( ) ;
         WE5A2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202410101645228", true, true);
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
         context.AddJavascriptSource("trn_productserviceww.js", "?2024101016452210", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_37_idx;
         edtLocationId_Internalname = "LOCATIONID_"+sGXsfl_37_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_37_idx;
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME_"+sGXsfl_37_idx;
         edtProductServiceTileName_Internalname = "PRODUCTSERVICETILENAME_"+sGXsfl_37_idx;
         edtProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE_"+sGXsfl_37_idx;
         edtSupplierGenId_Internalname = "SUPPLIERGENID_"+sGXsfl_37_idx;
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME_"+sGXsfl_37_idx;
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID_"+sGXsfl_37_idx;
         cmbProductServiceGroup_Internalname = "PRODUCTSERVICEGROUP_"+sGXsfl_37_idx;
         edtavSupplier_Internalname = "vSUPPLIER_"+sGXsfl_37_idx;
         edtavDescriptionwithtags_Internalname = "vDESCRIPTIONWITHTAGS_"+sGXsfl_37_idx;
         edtavDescription_Internalname = "vDESCRIPTION_"+sGXsfl_37_idx;
         edtSupplierAgbName_Internalname = "SUPPLIERAGBNAME_"+sGXsfl_37_idx;
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_37_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_37_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtProductServiceId_Internalname = "PRODUCTSERVICEID_"+sGXsfl_37_fel_idx;
         edtLocationId_Internalname = "LOCATIONID_"+sGXsfl_37_fel_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_37_fel_idx;
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME_"+sGXsfl_37_fel_idx;
         edtProductServiceTileName_Internalname = "PRODUCTSERVICETILENAME_"+sGXsfl_37_fel_idx;
         edtProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE_"+sGXsfl_37_fel_idx;
         edtSupplierGenId_Internalname = "SUPPLIERGENID_"+sGXsfl_37_fel_idx;
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME_"+sGXsfl_37_fel_idx;
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID_"+sGXsfl_37_fel_idx;
         cmbProductServiceGroup_Internalname = "PRODUCTSERVICEGROUP_"+sGXsfl_37_fel_idx;
         edtavSupplier_Internalname = "vSUPPLIER_"+sGXsfl_37_fel_idx;
         edtavDescriptionwithtags_Internalname = "vDESCRIPTIONWITHTAGS_"+sGXsfl_37_fel_idx;
         edtavDescription_Internalname = "vDESCRIPTION_"+sGXsfl_37_fel_idx;
         edtSupplierAgbName_Internalname = "SUPPLIERAGBNAME_"+sGXsfl_37_fel_idx;
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION_"+sGXsfl_37_fel_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_37_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB5A0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceId_Internalname,A58ProductServiceId.ToString(),A58ProductServiceId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationId_Internalname,A29LocationId.ToString(),A29LocationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceName_Internalname,(string)A59ProductServiceName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductServiceTileName_Internalname,StringUtil.RTrim( A301ProductServiceTileName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductServiceTileName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenId_Internalname,A42SupplierGenId.ToString(),A42SupplierGenId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenCompanyName_Internalname,(string)A44SupplierGenCompanyName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenCompanyName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbId_Internalname,A49SupplierAgbId.ToString(),A49SupplierAgbId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbProductServiceGroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PRODUCTSERVICEGROUP_" + sGXsfl_37_idx;
               cmbProductServiceGroup.Name = GXCCtl;
               cmbProductServiceGroup.WebTags = "";
               cmbProductServiceGroup.addItem(" AGB Supplier", context.GetMessage( "AGB Supplier", ""), 0);
               cmbProductServiceGroup.addItem("General Supplier", context.GetMessage( "General Supplier", ""), 0);
               if ( cmbProductServiceGroup.ItemCount > 0 )
               {
                  A366ProductServiceGroup = cmbProductServiceGroup.getValidValue(A366ProductServiceGroup);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProductServiceGroup,(string)cmbProductServiceGroup_Internalname,StringUtil.RTrim( A366ProductServiceGroup),(short)1,(string)cmbProductServiceGroup_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProductServiceGroup.CurrentValue = StringUtil.RTrim( A366ProductServiceGroup);
            AssignProp("", false, cmbProductServiceGroup_Internalname, "Values", (string)(cmbProductServiceGroup.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSupplier_Internalname,(string)AV50Supplier,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSupplier_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSupplier_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDescriptionwithtags_Internalname,(string)AV52DescriptionWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDescriptionwithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavDescriptionwithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDescription_Internalname,(string)AV51Description,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ","'"+""+"'"+",false,"+"'"+"EVDESCRIPTION.CLICK."+sGXsfl_37_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDescription_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavDescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAgbName_Internalname,(string)A51SupplierAgbName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAgbName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDisplay_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV32Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",context.GetMessage( "GXM_display", ""),(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDisplay_Visible,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV34Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",context.GetMessage( "GXM_update", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV36Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes5A2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PRODUCTSERVICEGROUP_" + sGXsfl_37_idx;
         cmbProductServiceGroup.Name = GXCCtl;
         cmbProductServiceGroup.WebTags = "";
         cmbProductServiceGroup.addItem(" AGB Supplier", context.GetMessage( "AGB Supplier", ""), 0);
         cmbProductServiceGroup.addItem("General Supplier", context.GetMessage( "General Supplier", ""), 0);
         if ( cmbProductServiceGroup.ItemCount > 0 )
         {
            A366ProductServiceGroup = cmbProductServiceGroup.getValidValue(A366ProductServiceGroup);
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Service Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tile Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Image", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Supplier Gen Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Supplier Gen Company Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Supplier Agb Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Category", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Supplier", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Supplier Agb Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Description", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A58ProductServiceId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A29LocationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A59ProductServiceName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A301ProductServiceTileName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A61ProductServiceImage));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A42SupplierGenId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A44SupplierGenCompanyName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A49SupplierAgbId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A366ProductServiceGroup));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV50Supplier));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSupplier_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV52DescriptionWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDescriptionwithtags_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV51Description));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDescription_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A51SupplierAgbName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A60ProductServiceDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV32Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV34Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV36Delete)));
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
         edtProductServiceId_Internalname = "PRODUCTSERVICEID";
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtProductServiceName_Internalname = "PRODUCTSERVICENAME";
         edtProductServiceTileName_Internalname = "PRODUCTSERVICETILENAME";
         edtProductServiceImage_Internalname = "PRODUCTSERVICEIMAGE";
         edtSupplierGenId_Internalname = "SUPPLIERGENID";
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME";
         edtSupplierAgbId_Internalname = "SUPPLIERAGBID";
         cmbProductServiceGroup_Internalname = "PRODUCTSERVICEGROUP";
         edtavSupplier_Internalname = "vSUPPLIER";
         edtavDescriptionwithtags_Internalname = "vDESCRIPTIONWITHTAGS";
         edtavDescription_Internalname = "vDESCRIPTION";
         edtSupplierAgbName_Internalname = "SUPPLIERAGBNAME";
         edtProductServiceDescription_Internalname = "PRODUCTSERVICEDESCRIPTION";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Popover_description_Internalname = "POPOVER_DESCRIPTION";
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
         edtavDelete_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 1;
         edtProductServiceDescription_Jsonclick = "";
         edtSupplierAgbName_Jsonclick = "";
         edtavDescription_Jsonclick = "";
         edtavDescription_Enabled = 1;
         edtavDescriptionwithtags_Jsonclick = "";
         edtavDescriptionwithtags_Enabled = 1;
         edtavSupplier_Jsonclick = "";
         edtavSupplier_Enabled = 1;
         cmbProductServiceGroup_Jsonclick = "";
         edtSupplierAgbId_Jsonclick = "";
         edtSupplierGenCompanyName_Jsonclick = "";
         edtSupplierGenId_Jsonclick = "";
         edtProductServiceTileName_Jsonclick = "";
         edtProductServiceName_Jsonclick = "";
         edtOrganisationId_Jsonclick = "";
         edtLocationId_Jsonclick = "";
         edtProductServiceId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtavDisplay_Visible = -1;
         edtProductServiceDescription_Enabled = 0;
         edtSupplierAgbName_Enabled = 0;
         cmbProductServiceGroup.Enabled = 0;
         edtSupplierAgbId_Enabled = 0;
         edtSupplierGenCompanyName_Enabled = 0;
         edtSupplierGenId_Enabled = 0;
         edtProductServiceImage_Enabled = 0;
         edtProductServiceTileName_Enabled = 0;
         edtProductServiceName_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtProductServiceId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Popoversingrid = "Popover_Description";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "Trn_ProductServiceWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||AGB Supplier:AGB Supplier,General Supplier:General Supplier";
         Ddo_grid_Allowmultipleselection = "||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|";
         Ddo_grid_Includefilter = "T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3";
         Ddo_grid_Columnids = "3:ProductServiceName|4:ProductServiceTileName|9:ProductServiceGroup";
         Ddo_grid_Gridinternalname = "";
         Popover_description_Keepopened = Convert.ToBoolean( 0);
         Popover_description_Position = "Bottom";
         Popover_description_Popoverwidth = 400;
         Popover_description_Triggerelement = "Value";
         Popover_description_Trigger = "Click";
         Popover_description_Isgriditem = Convert.ToBoolean( -1);
         Popover_description_Iteminternalname = "";
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
         Form.Caption = context.GetMessage( " Products/Services", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV39LocationId","fld":"vLOCATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV21TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV48TFProductServiceTileName","fld":"vTFPRODUCTSERVICETILENAME"},{"av":"AV49TFProductServiceTileName_Sel","fld":"vTFPRODUCTSERVICETILENAME_SEL"},{"av":"AV55TFProductServiceGroup_Sels","fld":"vTFPRODUCTSERVICEGROUP_SELS"},{"av":"AV33IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV35IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV37IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV38IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV28GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV29GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV30GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV33IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV35IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV37IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV38IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E125A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV39LocationId","fld":"vLOCATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV21TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV48TFProductServiceTileName","fld":"vTFPRODUCTSERVICETILENAME"},{"av":"AV49TFProductServiceTileName_Sel","fld":"vTFPRODUCTSERVICETILENAME_SEL"},{"av":"AV55TFProductServiceGroup_Sels","fld":"vTFPRODUCTSERVICEGROUP_SELS"},{"av":"AV33IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV35IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV37IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV38IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E135A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV39LocationId","fld":"vLOCATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV21TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV48TFProductServiceTileName","fld":"vTFPRODUCTSERVICETILENAME"},{"av":"AV49TFProductServiceTileName_Sel","fld":"vTFPRODUCTSERVICETILENAME_SEL"},{"av":"AV55TFProductServiceGroup_Sels","fld":"vTFPRODUCTSERVICEGROUP_SELS"},{"av":"AV33IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV35IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV37IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV38IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E155A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV39LocationId","fld":"vLOCATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV21TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV48TFProductServiceTileName","fld":"vTFPRODUCTSERVICETILENAME"},{"av":"AV49TFProductServiceTileName_Sel","fld":"vTFPRODUCTSERVICETILENAME_SEL"},{"av":"AV55TFProductServiceGroup_Sels","fld":"vTFPRODUCTSERVICEGROUP_SELS"},{"av":"AV33IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV35IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV37IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV38IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV21TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV48TFProductServiceTileName","fld":"vTFPRODUCTSERVICETILENAME"},{"av":"AV49TFProductServiceTileName_Sel","fld":"vTFPRODUCTSERVICETILENAME_SEL"},{"av":"AV54TFProductServiceGroup_SelsJson","fld":"vTFPRODUCTSERVICEGROUP_SELSJSON"},{"av":"AV55TFProductServiceGroup_Sels","fld":"vTFPRODUCTSERVICEGROUP_SELS"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E195A2","iparms":[{"av":"A49SupplierAgbId","fld":"SUPPLIERAGBID"},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"},{"av":"A51SupplierAgbName","fld":"SUPPLIERAGBNAME"},{"av":"A60ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION","hsh":true},{"av":"AV33IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"AV35IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV37IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV50Supplier","fld":"vSUPPLIER"},{"av":"AV51Description","fld":"vDESCRIPTION"},{"av":"AV32Display","fld":"vDISPLAY"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV34Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV36Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"AV52DescriptionWithTags","fld":"vDESCRIPTIONWITHTAGS"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E115A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV39LocationId","fld":"vLOCATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV21TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV48TFProductServiceTileName","fld":"vTFPRODUCTSERVICETILENAME"},{"av":"AV49TFProductServiceTileName_Sel","fld":"vTFPRODUCTSERVICETILENAME_SEL"},{"av":"AV55TFProductServiceGroup_Sels","fld":"vTFPRODUCTSERVICEGROUP_SELS"},{"av":"AV33IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV35IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV37IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV38IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV54TFProductServiceGroup_SelsJson","fld":"vTFPRODUCTSERVICEGROUP_SELSJSON"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV21TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV48TFProductServiceTileName","fld":"vTFPRODUCTSERVICETILENAME"},{"av":"AV49TFProductServiceTileName_Sel","fld":"vTFPRODUCTSERVICETILENAME_SEL"},{"av":"AV55TFProductServiceGroup_Sels","fld":"vTFPRODUCTSERVICEGROUP_SELS"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV54TFProductServiceGroup_SelsJson","fld":"vTFPRODUCTSERVICEGROUP_SELSJSON"},{"av":"AV28GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV29GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV30GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV33IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV35IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV37IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV38IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E165A2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV39LocationId","fld":"vLOCATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFProductServiceName","fld":"vTFPRODUCTSERVICENAME"},{"av":"AV21TFProductServiceName_Sel","fld":"vTFPRODUCTSERVICENAME_SEL"},{"av":"AV48TFProductServiceTileName","fld":"vTFPRODUCTSERVICETILENAME"},{"av":"AV49TFProductServiceTileName_Sel","fld":"vTFPRODUCTSERVICETILENAME_SEL"},{"av":"AV55TFProductServiceGroup_Sels","fld":"vTFPRODUCTSERVICEGROUP_SELS"},{"av":"AV33IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV35IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV37IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV38IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A58ProductServiceId","fld":"PRODUCTSERVICEID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV28GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV29GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV30GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV33IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV35IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV37IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV38IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E145A2","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VDESCRIPTION.CLICK","""{"handler":"E205A2","iparms":[{"av":"A60ProductServiceDescription","fld":"PRODUCTSERVICEDESCRIPTION","hsh":true}]""");
         setEventMetadata("VDESCRIPTION.CLICK",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VALID_PRODUCTSERVICENAME","""{"handler":"Valid_Productservicename","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICETILENAME","""{"handler":"Valid_Productservicetilename","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERGENID","""{"handler":"Valid_Suppliergenid","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERAGBID","""{"handler":"Valid_Supplieragbid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTSERVICEGROUP","""{"handler":"Valid_Productservicegroup","iparms":[]}""");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV39LocationId = Guid.Empty;
         AV56Pgmname = "";
         AV15FilterFullText = "";
         AV20TFProductServiceName = "";
         AV21TFProductServiceName_Sel = "";
         AV48TFProductServiceTileName = "";
         AV49TFProductServiceTileName_Sel = "";
         AV55TFProductServiceGroup_Sels = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV30GridAppliedFilters = "";
         AV24DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV54TFProductServiceGroup_SelsJson = "";
         Popover_description_Gridinternalname = "";
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
         ucPopover_description = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A58ProductServiceId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A59ProductServiceName = "";
         A301ProductServiceTileName = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         A42SupplierGenId = Guid.Empty;
         A44SupplierGenCompanyName = "";
         A49SupplierAgbId = Guid.Empty;
         A366ProductServiceGroup = "";
         AV50Supplier = "";
         AV52DescriptionWithTags = "";
         AV51Description = "";
         A51SupplierAgbName = "";
         A60ProductServiceDescription = "";
         AV32Display = "";
         AV34Update = "";
         AV36Delete = "";
         AV57Trn_productservicewwds_1_filterfulltext = "";
         AV58Trn_productservicewwds_2_tfproductservicename = "";
         AV59Trn_productservicewwds_3_tfproductservicename_sel = "";
         AV60Trn_productservicewwds_4_tfproductservicetilename = "";
         AV61Trn_productservicewwds_5_tfproductservicetilename_sel = "";
         AV62Trn_productservicewwds_6_tfproductservicegroup_sels = new GxSimpleCollection<string>();
         lV58Trn_productservicewwds_2_tfproductservicename = "";
         lV60Trn_productservicewwds_4_tfproductservicetilename = "";
         H005A2_A60ProductServiceDescription = new string[] {""} ;
         H005A2_A51SupplierAgbName = new string[] {""} ;
         H005A2_A366ProductServiceGroup = new string[] {""} ;
         H005A2_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H005A2_n49SupplierAgbId = new bool[] {false} ;
         H005A2_A44SupplierGenCompanyName = new string[] {""} ;
         H005A2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H005A2_n42SupplierGenId = new bool[] {false} ;
         H005A2_A40000ProductServiceImage_GXI = new string[] {""} ;
         H005A2_A301ProductServiceTileName = new string[] {""} ;
         H005A2_A59ProductServiceName = new string[] {""} ;
         H005A2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005A2_A29LocationId = new Guid[] {Guid.Empty} ;
         H005A2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H005A2_A61ProductServiceImage = new string[] {""} ;
         H005A3_A60ProductServiceDescription = new string[] {""} ;
         H005A3_A51SupplierAgbName = new string[] {""} ;
         H005A3_A366ProductServiceGroup = new string[] {""} ;
         H005A3_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         H005A3_n49SupplierAgbId = new bool[] {false} ;
         H005A3_A44SupplierGenCompanyName = new string[] {""} ;
         H005A3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H005A3_n42SupplierGenId = new bool[] {false} ;
         H005A3_A40000ProductServiceImage_GXI = new string[] {""} ;
         H005A3_A301ProductServiceTileName = new string[] {""} ;
         H005A3_A59ProductServiceName = new string[] {""} ;
         H005A3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005A3_A29LocationId = new Guid[] {Guid.Empty} ;
         H005A3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H005A3_A61ProductServiceImage = new string[] {""} ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV25GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV26GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_guid2 = Guid.Empty;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV16Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV45AuxText = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productserviceww__default(),
            new Object[][] {
                new Object[] {
               H005A2_A60ProductServiceDescription, H005A2_A51SupplierAgbName, H005A2_A366ProductServiceGroup, H005A2_A49SupplierAgbId, H005A2_n49SupplierAgbId, H005A2_A44SupplierGenCompanyName, H005A2_A42SupplierGenId, H005A2_n42SupplierGenId, H005A2_A40000ProductServiceImage_GXI, H005A2_A301ProductServiceTileName,
               H005A2_A59ProductServiceName, H005A2_A11OrganisationId, H005A2_A29LocationId, H005A2_A58ProductServiceId, H005A2_A61ProductServiceImage
               }
               , new Object[] {
               H005A3_A60ProductServiceDescription, H005A3_A51SupplierAgbName, H005A3_A366ProductServiceGroup, H005A3_A49SupplierAgbId, H005A3_n49SupplierAgbId, H005A3_A44SupplierGenCompanyName, H005A3_A42SupplierGenId, H005A3_n42SupplierGenId, H005A3_A40000ProductServiceImage_GXI, H005A3_A301ProductServiceTileName,
               H005A3_A59ProductServiceName, H005A3_A11OrganisationId, H005A3_A29LocationId, H005A3_A58ProductServiceId, H005A3_A61ProductServiceImage
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV56Pgmname = "Trn_ProductServiceWW";
         /* GeneXus formulas. */
         AV56Pgmname = "Trn_ProductServiceWW";
         edtavSupplier_Enabled = 0;
         edtavDescriptionwithtags_Enabled = 0;
         edtavDescription_Enabled = 0;
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
      private int Popover_description_Popoverwidth ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavSupplier_Enabled ;
      private int edtavDescriptionwithtags_Enabled ;
      private int edtavDescription_Enabled ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int AV62Trn_productservicewwds_6_tfproductservicegroup_sels_Count ;
      private int edtProductServiceId_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtProductServiceName_Enabled ;
      private int edtProductServiceTileName_Enabled ;
      private int edtProductServiceImage_Enabled ;
      private int edtSupplierGenId_Enabled ;
      private int edtSupplierGenCompanyName_Enabled ;
      private int edtSupplierAgbId_Enabled ;
      private int edtSupplierAgbName_Enabled ;
      private int edtProductServiceDescription_Enabled ;
      private int AV27PageToGo ;
      private int edtavDisplay_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV63GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV28GridCurrentPage ;
      private long AV29GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV56Pgmname ;
      private string AV48TFProductServiceTileName ;
      private string AV49TFProductServiceTileName_Sel ;
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
      private string Popover_description_Gridinternalname ;
      private string Popover_description_Iteminternalname ;
      private string Popover_description_Trigger ;
      private string Popover_description_Triggerelement ;
      private string Popover_description_Position ;
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
      private string Grid_empowerer_Popoversingrid ;
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
      private string Popover_description_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtProductServiceId_Internalname ;
      private string edtLocationId_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string edtProductServiceName_Internalname ;
      private string A301ProductServiceTileName ;
      private string edtProductServiceTileName_Internalname ;
      private string edtProductServiceImage_Internalname ;
      private string edtSupplierGenId_Internalname ;
      private string edtSupplierGenCompanyName_Internalname ;
      private string edtSupplierAgbId_Internalname ;
      private string cmbProductServiceGroup_Internalname ;
      private string edtavSupplier_Internalname ;
      private string edtavDescriptionwithtags_Internalname ;
      private string edtavDescription_Internalname ;
      private string edtSupplierAgbName_Internalname ;
      private string edtProductServiceDescription_Internalname ;
      private string AV32Display ;
      private string edtavDisplay_Internalname ;
      private string AV34Update ;
      private string edtavUpdate_Internalname ;
      private string AV36Delete ;
      private string edtavDelete_Internalname ;
      private string AV60Trn_productservicewwds_4_tfproductservicetilename ;
      private string AV61Trn_productservicewwds_5_tfproductservicetilename_sel ;
      private string lV60Trn_productservicewwds_4_tfproductservicetilename ;
      private string edtavDisplay_Link ;
      private string GXEncryptionTmp ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string GXt_char3 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtProductServiceId_Jsonclick ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Jsonclick ;
      private string edtProductServiceName_Jsonclick ;
      private string edtProductServiceTileName_Jsonclick ;
      private string sImgUrl ;
      private string edtSupplierGenId_Jsonclick ;
      private string edtSupplierGenCompanyName_Jsonclick ;
      private string edtSupplierAgbId_Jsonclick ;
      private string GXCCtl ;
      private string cmbProductServiceGroup_Jsonclick ;
      private string edtavSupplier_Jsonclick ;
      private string edtavDescriptionwithtags_Jsonclick ;
      private string edtavDescription_Jsonclick ;
      private string edtSupplierAgbName_Jsonclick ;
      private string edtProductServiceDescription_Jsonclick ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV33IsAuthorized_Display ;
      private bool AV35IsAuthorized_Update ;
      private bool AV37IsAuthorized_Delete ;
      private bool AV38IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Popover_description_Isgriditem ;
      private bool Popover_description_Keepopened ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n42SupplierGenId ;
      private bool n49SupplierAgbId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean4 ;
      private bool A61ProductServiceImage_IsBlob ;
      private string AV54TFProductServiceGroup_SelsJson ;
      private string A60ProductServiceDescription ;
      private string AV18ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV20TFProductServiceName ;
      private string AV21TFProductServiceName_Sel ;
      private string AV30GridAppliedFilters ;
      private string A59ProductServiceName ;
      private string A40000ProductServiceImage_GXI ;
      private string A44SupplierGenCompanyName ;
      private string A366ProductServiceGroup ;
      private string AV50Supplier ;
      private string AV52DescriptionWithTags ;
      private string AV51Description ;
      private string A51SupplierAgbName ;
      private string AV57Trn_productservicewwds_1_filterfulltext ;
      private string AV58Trn_productservicewwds_2_tfproductservicename ;
      private string AV59Trn_productservicewwds_3_tfproductservicename_sel ;
      private string lV58Trn_productservicewwds_2_tfproductservicename ;
      private string AV45AuxText ;
      private string A61ProductServiceImage ;
      private Guid AV39LocationId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A42SupplierGenId ;
      private Guid A49SupplierAgbId ;
      private Guid GXt_guid2 ;
      private IGxSession AV16Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucPopover_description ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProductServiceGroup ;
      private GxSimpleCollection<string> AV55TFProductServiceGroup_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV24DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GxSimpleCollection<string> AV62Trn_productservicewwds_6_tfproductservicegroup_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H005A2_A60ProductServiceDescription ;
      private string[] H005A2_A51SupplierAgbName ;
      private string[] H005A2_A366ProductServiceGroup ;
      private Guid[] H005A2_A49SupplierAgbId ;
      private bool[] H005A2_n49SupplierAgbId ;
      private string[] H005A2_A44SupplierGenCompanyName ;
      private Guid[] H005A2_A42SupplierGenId ;
      private bool[] H005A2_n42SupplierGenId ;
      private string[] H005A2_A40000ProductServiceImage_GXI ;
      private string[] H005A2_A301ProductServiceTileName ;
      private string[] H005A2_A59ProductServiceName ;
      private Guid[] H005A2_A11OrganisationId ;
      private Guid[] H005A2_A29LocationId ;
      private Guid[] H005A2_A58ProductServiceId ;
      private string[] H005A2_A61ProductServiceImage ;
      private string[] H005A3_A60ProductServiceDescription ;
      private string[] H005A3_A51SupplierAgbName ;
      private string[] H005A3_A366ProductServiceGroup ;
      private Guid[] H005A3_A49SupplierAgbId ;
      private bool[] H005A3_n49SupplierAgbId ;
      private string[] H005A3_A44SupplierGenCompanyName ;
      private Guid[] H005A3_A42SupplierGenId ;
      private bool[] H005A3_n42SupplierGenId ;
      private string[] H005A3_A40000ProductServiceImage_GXI ;
      private string[] H005A3_A301ProductServiceTileName ;
      private string[] H005A3_A59ProductServiceName ;
      private Guid[] H005A3_A11OrganisationId ;
      private Guid[] H005A3_A29LocationId ;
      private Guid[] H005A3_A58ProductServiceId ;
      private string[] H005A3_A61ProductServiceImage ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV25GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV26GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_productserviceww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005A2( IGxContext context ,
                                             string A366ProductServiceGroup ,
                                             GxSimpleCollection<string> AV62Trn_productservicewwds_6_tfproductservicegroup_sels ,
                                             string AV59Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV58Trn_productservicewwds_2_tfproductservicename ,
                                             string AV61Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV60Trn_productservicewwds_4_tfproductservicetilename ,
                                             int AV62Trn_productservicewwds_6_tfproductservicegroup_sels_Count ,
                                             string A59ProductServiceName ,
                                             string A301ProductServiceTileName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV57Trn_productservicewwds_1_filterfulltext ,
                                             Guid A29LocationId ,
                                             Guid AV39LocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[5];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceDescription, T2.SupplierAgbName, T1.ProductServiceGroup, T1.SupplierAgbId, T3.SupplierGenCompanyName, T1.SupplierGenId, T1.ProductServiceImage_GXI, T1.ProductServiceTileName, T1.ProductServiceName, T1.OrganisationId, T1.LocationId, T1.ProductServiceId, T1.ProductServiceImage FROM ((Trn_ProductService T1 LEFT JOIN Trn_SupplierAGB T2 ON T2.SupplierAgbId = T1.SupplierAgbId) LEFT JOIN Trn_SupplierGen T3 ON T3.SupplierGenId = T1.SupplierGenId)";
         AddWhere(sWhereString, "(T1.LocationId = :AV39LocationId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName like :lV58Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV59Trn_productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName = ( :AV59Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName like :lV60Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV61Trn_productservicewwds_5_tfproductservicetilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName = ( :AV61Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_productservicewwds_5_tfproductservicetilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceTileName))=0))");
         }
         if ( AV62Trn_productservicewwds_6_tfproductservicegroup_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV62Trn_productservicewwds_6_tfproductservicegroup_sels, "T1.ProductServiceGroup IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ProductServiceName, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ProductServiceName DESC, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ProductServiceTileName, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ProductServiceTileName DESC, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ProductServiceGroup, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ProductServiceGroup DESC, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H005A3( IGxContext context ,
                                             string A366ProductServiceGroup ,
                                             GxSimpleCollection<string> AV62Trn_productservicewwds_6_tfproductservicegroup_sels ,
                                             string AV59Trn_productservicewwds_3_tfproductservicename_sel ,
                                             string AV58Trn_productservicewwds_2_tfproductservicename ,
                                             string AV61Trn_productservicewwds_5_tfproductservicetilename_sel ,
                                             string AV60Trn_productservicewwds_4_tfproductservicetilename ,
                                             int AV62Trn_productservicewwds_6_tfproductservicegroup_sels_Count ,
                                             string A59ProductServiceName ,
                                             string A301ProductServiceTileName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV57Trn_productservicewwds_1_filterfulltext ,
                                             Guid A29LocationId ,
                                             Guid AV39LocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[5];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.ProductServiceDescription, T2.SupplierAgbName, T1.ProductServiceGroup, T1.SupplierAgbId, T3.SupplierGenCompanyName, T1.SupplierGenId, T1.ProductServiceImage_GXI, T1.ProductServiceTileName, T1.ProductServiceName, T1.OrganisationId, T1.LocationId, T1.ProductServiceId, T1.ProductServiceImage FROM ((Trn_ProductService T1 LEFT JOIN Trn_SupplierAGB T2 ON T2.SupplierAgbId = T1.SupplierAgbId) LEFT JOIN Trn_SupplierGen T3 ON T3.SupplierGenId = T1.SupplierGenId)";
         AddWhere(sWhereString, "(T1.LocationId = :AV39LocationId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_3_tfproductservicename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_productservicewwds_2_tfproductservicename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName like :lV58Trn_productservicewwds_2_tfproductservicename)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_productservicewwds_3_tfproductservicename_sel)) && ! ( StringUtil.StrCmp(AV59Trn_productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceName = ( :AV59Trn_productservicewwds_3_tfproductservicename_sel))");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_productservicewwds_3_tfproductservicename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_5_tfproductservicetilename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_productservicewwds_4_tfproductservicetilename)) ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName like :lV60Trn_productservicewwds_4_tfproductservicetilename)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_productservicewwds_5_tfproductservicetilename_sel)) && ! ( StringUtil.StrCmp(AV61Trn_productservicewwds_5_tfproductservicetilename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ProductServiceTileName = ( :AV61Trn_productservicewwds_5_tfproductservicetilename_sel))");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_productservicewwds_5_tfproductservicetilename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ProductServiceTileName))=0))");
         }
         if ( AV62Trn_productservicewwds_6_tfproductservicegroup_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV62Trn_productservicewwds_6_tfproductservicegroup_sels, "T1.ProductServiceGroup IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ProductServiceName, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ProductServiceName DESC, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ProductServiceTileName, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ProductServiceTileName DESC, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ProductServiceGroup, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ProductServiceGroup DESC, T1.ProductServiceId, T1.LocationId, T1.OrganisationId";
         }
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005A2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (Guid)dynConstraints[12] , (Guid)dynConstraints[13] );
               case 1 :
                     return conditional_H005A3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (Guid)dynConstraints[12] , (Guid)dynConstraints[13] );
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
          Object[] prmH005A2;
          prmH005A2 = new Object[] {
          new ParDef("AV39LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV58Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV61Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0)
          };
          Object[] prmH005A3;
          prmH005A3 = new Object[] {
          new ParDef("AV39LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV58Trn_productservicewwds_2_tfproductservicename",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_productservicewwds_3_tfproductservicename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_productservicewwds_4_tfproductservicetilename",GXType.Char,20,0) ,
          new ParDef("AV61Trn_productservicewwds_5_tfproductservicetilename_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A3,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[6])[0] = rslt.getGuid(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getMultimediaUri(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                ((Guid[]) buf[13])[0] = rslt.getGuid(12);
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(7));
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[6])[0] = rslt.getGuid(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getMultimediaUri(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                ((Guid[]) buf[13])[0] = rslt.getGuid(12);
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(7));
                return;
       }
    }

 }

}
