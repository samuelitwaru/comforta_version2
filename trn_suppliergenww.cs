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
   public class trn_suppliergenww : GXDataArea
   {
      public trn_suppliergenww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergenww( IGxContext context )
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
         AV15FilterFullText = GetPar( "FilterFullText");
         AV19ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV56Pgmname = GetPar( "Pgmname");
         AV24TFSupplierGenCompanyName = GetPar( "TFSupplierGenCompanyName");
         AV25TFSupplierGenCompanyName_Sel = GetPar( "TFSupplierGenCompanyName_Sel");
         AV22TFSupplierGenTypeName = GetPar( "TFSupplierGenTypeName");
         AV23TFSupplierGenTypeName_Sel = GetPar( "TFSupplierGenTypeName_Sel");
         AV26TFSupplierGenContactName = GetPar( "TFSupplierGenContactName");
         AV27TFSupplierGenContactName_Sel = GetPar( "TFSupplierGenContactName_Sel");
         AV28TFSupplierGenContactPhone = GetPar( "TFSupplierGenContactPhone");
         AV29TFSupplierGenContactPhone_Sel = GetPar( "TFSupplierGenContactPhone_Sel");
         AV39IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV41IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV43IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV46IsAuthorized_SupplierGenCompanyName = StringUtil.StrToBool( GetPar( "IsAuthorized_SupplierGenCompanyName"));
         AV45IsAuthorized_SupplierGenTypeName = StringUtil.StrToBool( GetPar( "IsAuthorized_SupplierGenTypeName"));
         AV44IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV56Pgmname, AV24TFSupplierGenCompanyName, AV25TFSupplierGenCompanyName_Sel, AV22TFSupplierGenTypeName, AV23TFSupplierGenTypeName_Sel, AV26TFSupplierGenContactName, AV27TFSupplierGenContactName_Sel, AV28TFSupplierGenContactPhone, AV29TFSupplierGenContactPhone_Sel, AV39IsAuthorized_Display, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV46IsAuthorized_SupplierGenCompanyName, AV45IsAuthorized_SupplierGenTypeName, AV44IsAuthorized_Insert) ;
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
            return "trn_suppliergenww_Execute" ;
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
         PA4O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4O2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_suppliergenww.aspx") +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV39IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV39IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV41IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV41IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV43IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV43IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", AV46IsAuthorized_SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", GetSecureSignedToken( "", AV46IsAuthorized_SupplierGenCompanyName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERGENTYPENAME", AV45IsAuthorized_SupplierGenTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERGENTYPENAME", GetSecureSignedToken( "", AV45IsAuthorized_SupplierGenTypeName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV44IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV44IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV36GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV30DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV30DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCOMPANYNAME", AV24TFSupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCOMPANYNAME_SEL", AV25TFSupplierGenCompanyName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENTYPENAME", AV22TFSupplierGenTypeName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENTYPENAME_SEL", AV23TFSupplierGenTypeName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCONTACTNAME", AV26TFSupplierGenContactName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCONTACTNAME_SEL", AV27TFSupplierGenContactName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCONTACTPHONE", StringUtil.RTrim( AV28TFSupplierGenContactPhone));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCONTACTPHONE_SEL", StringUtil.RTrim( AV29TFSupplierGenContactPhone_Sel));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV39IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV39IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV41IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV41IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV43IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV43IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", AV46IsAuthorized_SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", GetSecureSignedToken( "", AV46IsAuthorized_SupplierGenCompanyName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERGENTYPENAME", AV45IsAuthorized_SupplierGenTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERGENTYPENAME", GetSecureSignedToken( "", AV45IsAuthorized_SupplierGenTypeName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV44IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV44IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE4O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4O2( ) ;
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
         return formatLink("trn_suppliergenww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_SupplierGenWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " General Suppliers" ;
      }

      protected void WB4O0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGenWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Subscriptions", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_SupplierGenWW.htm");
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
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_Trn_SupplierGenWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV34GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV35GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV36GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV30DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0064"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0064"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_37_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0064"+"");
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

      protected void START4O2( )
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
         Form.Meta.addItem("description", " General Suppliers", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4O0( ) ;
      }

      protected void WS4O2( )
      {
         START4O2( ) ;
         EVT4O2( ) ;
      }

      protected void EVT4O2( )
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
                              E114O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E124O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E134O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E144O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E154O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E164O2 ();
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
                              A42SupplierGenId = StringUtil.StrToGuid( cgiGet( edtSupplierGenId_Internalname));
                              A43SupplierGenKvkNumber = cgiGet( edtSupplierGenKvkNumber_Internalname);
                              A282SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierGenTypeId_Internalname));
                              A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
                              A290SupplierGenTypeName = cgiGet( edtSupplierGenTypeName_Internalname);
                              A335SupplierGenAddressCountry = cgiGet( edtSupplierGenAddressCountry_Internalname);
                              A295SupplierGenAddressCity = cgiGet( edtSupplierGenAddressCity_Internalname);
                              A294SupplierGenAddressZipCode = cgiGet( edtSupplierGenAddressZipCode_Internalname);
                              A336SupplierGenAddressLine1 = cgiGet( edtSupplierGenAddressLine1_Internalname);
                              A337SupplierGenAddressLine2 = cgiGet( edtSupplierGenAddressLine2_Internalname);
                              A47SupplierGenContactName = cgiGet( edtSupplierGenContactName_Internalname);
                              A48SupplierGenContactPhone = cgiGet( edtSupplierGenContactPhone_Internalname);
                              AV55SupplierGenAddress = cgiGet( edtavSuppliergenaddress_Internalname);
                              AssignAttri("", false, edtavSuppliergenaddress_Internalname, AV55SupplierGenAddress);
                              AV38Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV38Display);
                              AV40Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV40Update);
                              AV42Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV42Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E174O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E184O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E194O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
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
                        if ( nCmpId == 64 )
                        {
                           OldWwpaux_wc = cgiGet( "W0064");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0064", "", sEvt);
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

      protected void WE4O2( )
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

      protected void PA4O2( )
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
                                       string AV15FilterFullText ,
                                       short AV19ManageFiltersExecutionStep ,
                                       string AV56Pgmname ,
                                       string AV24TFSupplierGenCompanyName ,
                                       string AV25TFSupplierGenCompanyName_Sel ,
                                       string AV22TFSupplierGenTypeName ,
                                       string AV23TFSupplierGenTypeName_Sel ,
                                       string AV26TFSupplierGenContactName ,
                                       string AV27TFSupplierGenContactName_Sel ,
                                       string AV28TFSupplierGenContactPhone ,
                                       string AV29TFSupplierGenContactPhone_Sel ,
                                       bool AV39IsAuthorized_Display ,
                                       bool AV41IsAuthorized_Update ,
                                       bool AV43IsAuthorized_Delete ,
                                       bool AV46IsAuthorized_SupplierGenCompanyName ,
                                       bool AV45IsAuthorized_SupplierGenTypeName ,
                                       bool AV44IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4O2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIERGENID", GetSecureSignedToken( "", A42SupplierGenId, context));
         GxWebStd.gx_hidden_field( context, "SUPPLIERGENID", A42SupplierGenId.ToString());
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
         RF4O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV56Pgmname = "Trn_SupplierGenWW";
         edtavSuppliergenaddress_Enabled = 0;
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF4O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E184O2 ();
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
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV57Trn_suppliergenwwds_1_filterfulltext ,
                                                 AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                                 AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                                 AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                                 AV60Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                                 AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                                 AV62Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                                 AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                                 AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                                 A44SupplierGenCompanyName ,
                                                 A290SupplierGenTypeName ,
                                                 A47SupplierGenContactName ,
                                                 A48SupplierGenContactPhone ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV57Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Trn_suppliergenwwds_1_filterfulltext), "%", "");
            lV57Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Trn_suppliergenwwds_1_filterfulltext), "%", "");
            lV57Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Trn_suppliergenwwds_1_filterfulltext), "%", "");
            lV57Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Trn_suppliergenwwds_1_filterfulltext), "%", "");
            lV58Trn_suppliergenwwds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname), "%", "");
            lV60Trn_suppliergenwwds_4_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV60Trn_suppliergenwwds_4_tfsuppliergentypename), "%", "");
            lV62Trn_suppliergenwwds_6_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV62Trn_suppliergenwwds_6_tfsuppliergencontactname), "%", "");
            lV64Trn_suppliergenwwds_8_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone), 20, "%");
            /* Using cursor H004O2 */
            pr_default.execute(0, new Object[] {lV57Trn_suppliergenwwds_1_filterfulltext, lV57Trn_suppliergenwwds_1_filterfulltext, lV57Trn_suppliergenwwds_1_filterfulltext, lV57Trn_suppliergenwwds_1_filterfulltext, lV58Trn_suppliergenwwds_2_tfsuppliergencompanyname, AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, lV60Trn_suppliergenwwds_4_tfsuppliergentypename, AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel, lV62Trn_suppliergenwwds_6_tfsuppliergencontactname, AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, lV64Trn_suppliergenwwds_8_tfsuppliergencontactphone, AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A48SupplierGenContactPhone = H004O2_A48SupplierGenContactPhone[0];
               A47SupplierGenContactName = H004O2_A47SupplierGenContactName[0];
               A337SupplierGenAddressLine2 = H004O2_A337SupplierGenAddressLine2[0];
               A336SupplierGenAddressLine1 = H004O2_A336SupplierGenAddressLine1[0];
               A294SupplierGenAddressZipCode = H004O2_A294SupplierGenAddressZipCode[0];
               A295SupplierGenAddressCity = H004O2_A295SupplierGenAddressCity[0];
               A335SupplierGenAddressCountry = H004O2_A335SupplierGenAddressCountry[0];
               A290SupplierGenTypeName = H004O2_A290SupplierGenTypeName[0];
               A44SupplierGenCompanyName = H004O2_A44SupplierGenCompanyName[0];
               A282SupplierGenTypeId = H004O2_A282SupplierGenTypeId[0];
               A43SupplierGenKvkNumber = H004O2_A43SupplierGenKvkNumber[0];
               A42SupplierGenId = H004O2_A42SupplierGenId[0];
               A290SupplierGenTypeName = H004O2_A290SupplierGenTypeName[0];
               /* Execute user event: Grid.Load */
               E194O2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB4O0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4O2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV39IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV39IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV41IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV41IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV43IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV43IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", AV46IsAuthorized_SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", GetSecureSignedToken( "", AV46IsAuthorized_SupplierGenCompanyName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_SUPPLIERGENTYPENAME", AV45IsAuthorized_SupplierGenTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERGENTYPENAME", GetSecureSignedToken( "", AV45IsAuthorized_SupplierGenTypeName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV44IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV44IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIERGENID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A42SupplierGenId, context));
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
         AV57Trn_suppliergenwwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV24TFSupplierGenCompanyName;
         AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV25TFSupplierGenCompanyName_Sel;
         AV60Trn_suppliergenwwds_4_tfsuppliergentypename = AV22TFSupplierGenTypeName;
         AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV23TFSupplierGenTypeName_Sel;
         AV62Trn_suppliergenwwds_6_tfsuppliergencontactname = AV26TFSupplierGenContactName;
         AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV27TFSupplierGenContactName_Sel;
         AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV28TFSupplierGenContactPhone;
         AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV29TFSupplierGenContactPhone_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV57Trn_suppliergenwwds_1_filterfulltext ,
                                              AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                              AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                              AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                              AV60Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                              AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                              AV62Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                              AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                              AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV57Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV57Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV57Trn_suppliergenwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Trn_suppliergenwwds_1_filterfulltext), "%", "");
         lV58Trn_suppliergenwwds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname), "%", "");
         lV60Trn_suppliergenwwds_4_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV60Trn_suppliergenwwds_4_tfsuppliergentypename), "%", "");
         lV62Trn_suppliergenwwds_6_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV62Trn_suppliergenwwds_6_tfsuppliergencontactname), "%", "");
         lV64Trn_suppliergenwwds_8_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone), 20, "%");
         /* Using cursor H004O3 */
         pr_default.execute(1, new Object[] {lV57Trn_suppliergenwwds_1_filterfulltext, lV57Trn_suppliergenwwds_1_filterfulltext, lV57Trn_suppliergenwwds_1_filterfulltext, lV57Trn_suppliergenwwds_1_filterfulltext, lV58Trn_suppliergenwwds_2_tfsuppliergencompanyname, AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, lV60Trn_suppliergenwwds_4_tfsuppliergentypename, AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel, lV62Trn_suppliergenwwds_6_tfsuppliergencontactname, AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, lV64Trn_suppliergenwwds_8_tfsuppliergencontactphone, AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel});
         GRID_nRecordCount = H004O3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
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
         AV57Trn_suppliergenwwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV24TFSupplierGenCompanyName;
         AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV25TFSupplierGenCompanyName_Sel;
         AV60Trn_suppliergenwwds_4_tfsuppliergentypename = AV22TFSupplierGenTypeName;
         AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV23TFSupplierGenTypeName_Sel;
         AV62Trn_suppliergenwwds_6_tfsuppliergencontactname = AV26TFSupplierGenContactName;
         AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV27TFSupplierGenContactName_Sel;
         AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV28TFSupplierGenContactPhone;
         AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV29TFSupplierGenContactPhone_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV56Pgmname, AV24TFSupplierGenCompanyName, AV25TFSupplierGenCompanyName_Sel, AV22TFSupplierGenTypeName, AV23TFSupplierGenTypeName_Sel, AV26TFSupplierGenContactName, AV27TFSupplierGenContactName_Sel, AV28TFSupplierGenContactPhone, AV29TFSupplierGenContactPhone_Sel, AV39IsAuthorized_Display, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV46IsAuthorized_SupplierGenCompanyName, AV45IsAuthorized_SupplierGenTypeName, AV44IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV57Trn_suppliergenwwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV24TFSupplierGenCompanyName;
         AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV25TFSupplierGenCompanyName_Sel;
         AV60Trn_suppliergenwwds_4_tfsuppliergentypename = AV22TFSupplierGenTypeName;
         AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV23TFSupplierGenTypeName_Sel;
         AV62Trn_suppliergenwwds_6_tfsuppliergencontactname = AV26TFSupplierGenContactName;
         AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV27TFSupplierGenContactName_Sel;
         AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV28TFSupplierGenContactPhone;
         AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV29TFSupplierGenContactPhone_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV56Pgmname, AV24TFSupplierGenCompanyName, AV25TFSupplierGenCompanyName_Sel, AV22TFSupplierGenTypeName, AV23TFSupplierGenTypeName_Sel, AV26TFSupplierGenContactName, AV27TFSupplierGenContactName_Sel, AV28TFSupplierGenContactPhone, AV29TFSupplierGenContactPhone_Sel, AV39IsAuthorized_Display, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV46IsAuthorized_SupplierGenCompanyName, AV45IsAuthorized_SupplierGenTypeName, AV44IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV57Trn_suppliergenwwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV24TFSupplierGenCompanyName;
         AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV25TFSupplierGenCompanyName_Sel;
         AV60Trn_suppliergenwwds_4_tfsuppliergentypename = AV22TFSupplierGenTypeName;
         AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV23TFSupplierGenTypeName_Sel;
         AV62Trn_suppliergenwwds_6_tfsuppliergencontactname = AV26TFSupplierGenContactName;
         AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV27TFSupplierGenContactName_Sel;
         AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV28TFSupplierGenContactPhone;
         AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV29TFSupplierGenContactPhone_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV56Pgmname, AV24TFSupplierGenCompanyName, AV25TFSupplierGenCompanyName_Sel, AV22TFSupplierGenTypeName, AV23TFSupplierGenTypeName_Sel, AV26TFSupplierGenContactName, AV27TFSupplierGenContactName_Sel, AV28TFSupplierGenContactPhone, AV29TFSupplierGenContactPhone_Sel, AV39IsAuthorized_Display, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV46IsAuthorized_SupplierGenCompanyName, AV45IsAuthorized_SupplierGenTypeName, AV44IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV57Trn_suppliergenwwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV24TFSupplierGenCompanyName;
         AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV25TFSupplierGenCompanyName_Sel;
         AV60Trn_suppliergenwwds_4_tfsuppliergentypename = AV22TFSupplierGenTypeName;
         AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV23TFSupplierGenTypeName_Sel;
         AV62Trn_suppliergenwwds_6_tfsuppliergencontactname = AV26TFSupplierGenContactName;
         AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV27TFSupplierGenContactName_Sel;
         AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV28TFSupplierGenContactPhone;
         AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV29TFSupplierGenContactPhone_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV56Pgmname, AV24TFSupplierGenCompanyName, AV25TFSupplierGenCompanyName_Sel, AV22TFSupplierGenTypeName, AV23TFSupplierGenTypeName_Sel, AV26TFSupplierGenContactName, AV27TFSupplierGenContactName_Sel, AV28TFSupplierGenContactPhone, AV29TFSupplierGenContactPhone_Sel, AV39IsAuthorized_Display, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV46IsAuthorized_SupplierGenCompanyName, AV45IsAuthorized_SupplierGenTypeName, AV44IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV57Trn_suppliergenwwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV24TFSupplierGenCompanyName;
         AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV25TFSupplierGenCompanyName_Sel;
         AV60Trn_suppliergenwwds_4_tfsuppliergentypename = AV22TFSupplierGenTypeName;
         AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV23TFSupplierGenTypeName_Sel;
         AV62Trn_suppliergenwwds_6_tfsuppliergencontactname = AV26TFSupplierGenContactName;
         AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV27TFSupplierGenContactName_Sel;
         AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV28TFSupplierGenContactPhone;
         AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV29TFSupplierGenContactPhone_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV56Pgmname, AV24TFSupplierGenCompanyName, AV25TFSupplierGenCompanyName_Sel, AV22TFSupplierGenTypeName, AV23TFSupplierGenTypeName_Sel, AV26TFSupplierGenContactName, AV27TFSupplierGenContactName_Sel, AV28TFSupplierGenContactPhone, AV29TFSupplierGenContactPhone_Sel, AV39IsAuthorized_Display, AV41IsAuthorized_Update, AV43IsAuthorized_Delete, AV46IsAuthorized_SupplierGenCompanyName, AV45IsAuthorized_SupplierGenTypeName, AV44IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV56Pgmname = "Trn_SupplierGenWW";
         edtavSuppliergenaddress_Enabled = 0;
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtSupplierGenId_Enabled = 0;
         edtSupplierGenKvkNumber_Enabled = 0;
         edtSupplierGenTypeId_Enabled = 0;
         edtSupplierGenCompanyName_Enabled = 0;
         edtSupplierGenTypeName_Enabled = 0;
         edtSupplierGenAddressCountry_Enabled = 0;
         edtSupplierGenAddressCity_Enabled = 0;
         edtSupplierGenAddressZipCode_Enabled = 0;
         edtSupplierGenAddressLine1_Enabled = 0;
         edtSupplierGenAddressLine2_Enabled = 0;
         edtSupplierGenContactName_Enabled = 0;
         edtSupplierGenContactPhone_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E174O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV30DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ".", ","), 18, MidpointRounding.ToEven));
            AV34GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV35GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV36GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
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
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ".", ","), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
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
         E174O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E174O2( )
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
         GXt_boolean1 = AV46IsAuthorized_SupplierGenCompanyName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergenview_Execute", out  GXt_boolean1) ;
         AV46IsAuthorized_SupplierGenCompanyName = GXt_boolean1;
         AssignAttri("", false, "AV46IsAuthorized_SupplierGenCompanyName", AV46IsAuthorized_SupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERGENCOMPANYNAME", GetSecureSignedToken( "", AV46IsAuthorized_SupplierGenCompanyName, context));
         GXt_boolean1 = AV45IsAuthorized_SupplierGenTypeName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergentypeview_Execute", out  GXt_boolean1) ;
         AV45IsAuthorized_SupplierGenTypeName = GXt_boolean1;
         AssignAttri("", false, "AV45IsAuthorized_SupplierGenTypeName", AV45IsAuthorized_SupplierGenTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_SUPPLIERGENTYPENAME", GetSecureSignedToken( "", AV45IsAuthorized_SupplierGenTypeName, context));
         AV31GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV32GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV31GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " General Suppliers";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV30DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV30DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E184O2( )
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
         AV34GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV34GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV34GridCurrentPage), 10, 0));
         AV35GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV35GridPageCount", StringUtil.LTrimStr( (decimal)(AV35GridPageCount), 10, 0));
         GXt_char3 = AV36GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV56Pgmname, out  GXt_char3) ;
         AV36GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV36GridAppliedFilters", AV36GridAppliedFilters);
         AV57Trn_suppliergenwwds_1_filterfulltext = AV15FilterFullText;
         AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname = AV24TFSupplierGenCompanyName;
         AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = AV25TFSupplierGenCompanyName_Sel;
         AV60Trn_suppliergenwwds_4_tfsuppliergentypename = AV22TFSupplierGenTypeName;
         AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel = AV23TFSupplierGenTypeName_Sel;
         AV62Trn_suppliergenwwds_6_tfsuppliergencontactname = AV26TFSupplierGenContactName;
         AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = AV27TFSupplierGenContactName_Sel;
         AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone = AV28TFSupplierGenContactPhone;
         AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = AV29TFSupplierGenContactPhone_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E124O2( )
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
            AV33PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV33PageToGo) ;
         }
      }

      protected void E134O2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E154O2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierGenCompanyName") == 0 )
            {
               AV24TFSupplierGenCompanyName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV24TFSupplierGenCompanyName", AV24TFSupplierGenCompanyName);
               AV25TFSupplierGenCompanyName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV25TFSupplierGenCompanyName_Sel", AV25TFSupplierGenCompanyName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierGenTypeName") == 0 )
            {
               AV22TFSupplierGenTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV22TFSupplierGenTypeName", AV22TFSupplierGenTypeName);
               AV23TFSupplierGenTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV23TFSupplierGenTypeName_Sel", AV23TFSupplierGenTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierGenContactName") == 0 )
            {
               AV26TFSupplierGenContactName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV26TFSupplierGenContactName", AV26TFSupplierGenContactName);
               AV27TFSupplierGenContactName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV27TFSupplierGenContactName_Sel", AV27TFSupplierGenContactName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierGenContactPhone") == 0 )
            {
               AV28TFSupplierGenContactPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFSupplierGenContactPhone", AV28TFSupplierGenContactPhone);
               AV29TFSupplierGenContactPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFSupplierGenContactPhone_Sel", AV29TFSupplierGenContactPhone_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E194O2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         GXt_char3 = AV55SupplierGenAddress;
         new prc_concatenateaddress(context ).execute(  A335SupplierGenAddressCountry,  A295SupplierGenAddressCity,  A294SupplierGenAddressZipCode,  A336SupplierGenAddressLine1,  A337SupplierGenAddressLine2, out  GXt_char3) ;
         AV55SupplierGenAddress = GXt_char3;
         AssignAttri("", false, edtavSuppliergenaddress_Internalname, AV55SupplierGenAddress);
         AV38Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV38Display);
         if ( AV39IsAuthorized_Display )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_suppliergenview.aspx"+UrlEncode(A42SupplierGenId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtavDisplay_Link = formatLink("trn_suppliergenview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV40Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV40Update);
         if ( AV41IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A42SupplierGenId.ToString());
            edtavUpdate_Link = formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV42Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV42Delete);
         if ( AV43IsAuthorized_Delete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A42SupplierGenId.ToString());
            edtavDelete_Link = formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV46IsAuthorized_SupplierGenCompanyName )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_suppliergenview.aspx"+UrlEncode(A42SupplierGenId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSupplierGenCompanyName_Link = formatLink("trn_suppliergenview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV45IsAuthorized_SupplierGenTypeName )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_suppliergentypeview.aspx"+UrlEncode(A282SupplierGenTypeId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSupplierGenTypeName_Link = formatLink("trn_suppliergentypeview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 37;
         }
         sendrow_372( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E114O2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_SupplierGenWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV56Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_SupplierGenWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV18ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "Trn_SupplierGenWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV18ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void E164O2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV44IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E144O2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0064",(string)"",(string)"Trn_SupplierGen",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0064"+"");
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
         GXt_boolean1 = AV39IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergenview_Execute", out  GXt_boolean1) ;
         AV39IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV39IsAuthorized_Display", AV39IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV39IsAuthorized_Display, context));
         if ( ! ( AV39IsAuthorized_Display ) )
         {
            edtavDisplay_Visible = 0;
            AssignProp("", false, edtavDisplay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDisplay_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV41IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergen_Update", out  GXt_boolean1) ;
         AV41IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV41IsAuthorized_Update", AV41IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV41IsAuthorized_Update, context));
         if ( ! ( AV41IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV43IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergen_Delete", out  GXt_boolean1) ;
         AV43IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV43IsAuthorized_Delete", AV43IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV43IsAuthorized_Delete, context));
         if ( ! ( AV43IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV44IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergen_Insert", out  GXt_boolean1) ;
         AV44IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV44IsAuthorized_Insert", AV44IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV44IsAuthorized_Insert, context));
         if ( ! ( AV44IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_SupplierGen",  1) ) )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_SupplierGenWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV24TFSupplierGenCompanyName = "";
         AssignAttri("", false, "AV24TFSupplierGenCompanyName", AV24TFSupplierGenCompanyName);
         AV25TFSupplierGenCompanyName_Sel = "";
         AssignAttri("", false, "AV25TFSupplierGenCompanyName_Sel", AV25TFSupplierGenCompanyName_Sel);
         AV22TFSupplierGenTypeName = "";
         AssignAttri("", false, "AV22TFSupplierGenTypeName", AV22TFSupplierGenTypeName);
         AV23TFSupplierGenTypeName_Sel = "";
         AssignAttri("", false, "AV23TFSupplierGenTypeName_Sel", AV23TFSupplierGenTypeName_Sel);
         AV26TFSupplierGenContactName = "";
         AssignAttri("", false, "AV26TFSupplierGenContactName", AV26TFSupplierGenContactName);
         AV27TFSupplierGenContactName_Sel = "";
         AssignAttri("", false, "AV27TFSupplierGenContactName_Sel", AV27TFSupplierGenContactName_Sel);
         AV28TFSupplierGenContactPhone = "";
         AssignAttri("", false, "AV28TFSupplierGenContactPhone", AV28TFSupplierGenContactPhone);
         AV29TFSupplierGenContactPhone_Sel = "";
         AssignAttri("", false, "AV29TFSupplierGenContactPhone_Sel", AV29TFSupplierGenContactPhone_Sel);
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
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV66GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME") == 0 )
            {
               AV24TFSupplierGenCompanyName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV24TFSupplierGenCompanyName", AV24TFSupplierGenCompanyName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME_SEL") == 0 )
            {
               AV25TFSupplierGenCompanyName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV25TFSupplierGenCompanyName_Sel", AV25TFSupplierGenCompanyName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENTYPENAME") == 0 )
            {
               AV22TFSupplierGenTypeName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV22TFSupplierGenTypeName", AV22TFSupplierGenTypeName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENTYPENAME_SEL") == 0 )
            {
               AV23TFSupplierGenTypeName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23TFSupplierGenTypeName_Sel", AV23TFSupplierGenTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTNAME") == 0 )
            {
               AV26TFSupplierGenContactName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV26TFSupplierGenContactName", AV26TFSupplierGenContactName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTNAME_SEL") == 0 )
            {
               AV27TFSupplierGenContactName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFSupplierGenContactName_Sel", AV27TFSupplierGenContactName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTPHONE") == 0 )
            {
               AV28TFSupplierGenContactPhone = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFSupplierGenContactPhone", AV28TFSupplierGenContactPhone);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTPHONE_SEL") == 0 )
            {
               AV29TFSupplierGenContactPhone_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFSupplierGenContactPhone_Sel", AV29TFSupplierGenContactPhone_Sel);
            }
            AV66GXV1 = (int)(AV66GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSupplierGenCompanyName_Sel)),  AV25TFSupplierGenCompanyName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSupplierGenTypeName_Sel)),  AV23TFSupplierGenTypeName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSupplierGenContactName_Sel)),  AV27TFSupplierGenContactName_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplierGenContactPhone_Sel)),  AV29TFSupplierGenContactPhone_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSupplierGenCompanyName)),  AV24TFSupplierGenCompanyName, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSupplierGenTypeName)),  AV22TFSupplierGenTypeName, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSupplierGenContactName)),  AV26TFSupplierGenContactName, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSupplierGenContactPhone)),  AV28TFSupplierGenContactPhone, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
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
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIERGENCOMPANYNAME",  "Company Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSupplierGenCompanyName)),  0,  AV24TFSupplierGenCompanyName,  AV24TFSupplierGenCompanyName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSupplierGenCompanyName_Sel)),  AV25TFSupplierGenCompanyName_Sel,  AV25TFSupplierGenCompanyName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIERGENTYPENAME",  "Category",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSupplierGenTypeName)),  0,  AV22TFSupplierGenTypeName,  AV22TFSupplierGenTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSupplierGenTypeName_Sel)),  AV23TFSupplierGenTypeName_Sel,  AV23TFSupplierGenTypeName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIERGENCONTACTNAME",  "Contact Person",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSupplierGenContactName)),  0,  AV26TFSupplierGenContactName,  AV26TFSupplierGenContactName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSupplierGenContactName_Sel)),  AV27TFSupplierGenContactName_Sel,  AV27TFSupplierGenContactName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSUPPLIERGENCONTACTPHONE",  "Contact Phone",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSupplierGenContactPhone)),  0,  AV28TFSupplierGenContactPhone,  AV28TFSupplierGenContactPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplierGenContactPhone_Sel)),  AV29TFSupplierGenContactPhone_Sel,  AV29TFSupplierGenContactPhone_Sel) ;
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
         AV9TrnContext.gxTpr_Transactionname = "Trn_SupplierGen";
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
         PA4O2( ) ;
         WS4O2( ) ;
         WE4O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202492719501379", true, true);
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
         context.AddJavascriptSource("trn_suppliergenww.js", "?202492719501381", false, true);
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
         edtSupplierGenId_Internalname = "SUPPLIERGENID_"+sGXsfl_37_idx;
         edtSupplierGenKvkNumber_Internalname = "SUPPLIERGENKVKNUMBER_"+sGXsfl_37_idx;
         edtSupplierGenTypeId_Internalname = "SUPPLIERGENTYPEID_"+sGXsfl_37_idx;
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME_"+sGXsfl_37_idx;
         edtSupplierGenTypeName_Internalname = "SUPPLIERGENTYPENAME_"+sGXsfl_37_idx;
         edtSupplierGenAddressCountry_Internalname = "SUPPLIERGENADDRESSCOUNTRY_"+sGXsfl_37_idx;
         edtSupplierGenAddressCity_Internalname = "SUPPLIERGENADDRESSCITY_"+sGXsfl_37_idx;
         edtSupplierGenAddressZipCode_Internalname = "SUPPLIERGENADDRESSZIPCODE_"+sGXsfl_37_idx;
         edtSupplierGenAddressLine1_Internalname = "SUPPLIERGENADDRESSLINE1_"+sGXsfl_37_idx;
         edtSupplierGenAddressLine2_Internalname = "SUPPLIERGENADDRESSLINE2_"+sGXsfl_37_idx;
         edtSupplierGenContactName_Internalname = "SUPPLIERGENCONTACTNAME_"+sGXsfl_37_idx;
         edtSupplierGenContactPhone_Internalname = "SUPPLIERGENCONTACTPHONE_"+sGXsfl_37_idx;
         edtavSuppliergenaddress_Internalname = "vSUPPLIERGENADDRESS_"+sGXsfl_37_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_37_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtSupplierGenId_Internalname = "SUPPLIERGENID_"+sGXsfl_37_fel_idx;
         edtSupplierGenKvkNumber_Internalname = "SUPPLIERGENKVKNUMBER_"+sGXsfl_37_fel_idx;
         edtSupplierGenTypeId_Internalname = "SUPPLIERGENTYPEID_"+sGXsfl_37_fel_idx;
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME_"+sGXsfl_37_fel_idx;
         edtSupplierGenTypeName_Internalname = "SUPPLIERGENTYPENAME_"+sGXsfl_37_fel_idx;
         edtSupplierGenAddressCountry_Internalname = "SUPPLIERGENADDRESSCOUNTRY_"+sGXsfl_37_fel_idx;
         edtSupplierGenAddressCity_Internalname = "SUPPLIERGENADDRESSCITY_"+sGXsfl_37_fel_idx;
         edtSupplierGenAddressZipCode_Internalname = "SUPPLIERGENADDRESSZIPCODE_"+sGXsfl_37_fel_idx;
         edtSupplierGenAddressLine1_Internalname = "SUPPLIERGENADDRESSLINE1_"+sGXsfl_37_fel_idx;
         edtSupplierGenAddressLine2_Internalname = "SUPPLIERGENADDRESSLINE2_"+sGXsfl_37_fel_idx;
         edtSupplierGenContactName_Internalname = "SUPPLIERGENCONTACTNAME_"+sGXsfl_37_fel_idx;
         edtSupplierGenContactPhone_Internalname = "SUPPLIERGENCONTACTPHONE_"+sGXsfl_37_fel_idx;
         edtavSuppliergenaddress_Internalname = "vSUPPLIERGENADDRESS_"+sGXsfl_37_fel_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_37_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB4O0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenId_Internalname,A42SupplierGenId.ToString(),A42SupplierGenId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenKvkNumber_Internalname,(string)A43SupplierGenKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenTypeId_Internalname,A282SupplierGenTypeId.ToString(),A282SupplierGenTypeId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenCompanyName_Internalname,(string)A44SupplierGenCompanyName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSupplierGenCompanyName_Link,(string)"",(string)"",(string)"",(string)edtSupplierGenCompanyName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenTypeName_Internalname,(string)A290SupplierGenTypeName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSupplierGenTypeName_Link,(string)"",(string)"",(string)"",(string)edtSupplierGenTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenAddressCountry_Internalname,(string)A335SupplierGenAddressCountry,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenAddressCountry_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenAddressCity_Internalname,(string)A295SupplierGenAddressCity,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenAddressCity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenAddressZipCode_Internalname,(string)A294SupplierGenAddressZipCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenAddressZipCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenAddressLine1_Internalname,(string)A336SupplierGenAddressLine1,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenAddressLine1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenAddressLine2_Internalname,(string)A337SupplierGenAddressLine2,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenAddressLine2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenContactName_Internalname,(string)A47SupplierGenContactName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenContactName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A48SupplierGenContactPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenContactPhone_Internalname,StringUtil.RTrim( A48SupplierGenContactPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtSupplierGenContactPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSuppliergenaddress_Internalname,(string)AV55SupplierGenAddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( AV55SupplierGenAddress),(string)"_blank",(string)"",(string)"",(string)edtavSuppliergenaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSuppliergenaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDisplay_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV38Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Display",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDisplay_Visible,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV40Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Update",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV42Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes4O2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
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
            context.SendWebValue( "Gen Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Kvk Number") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Type Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Company Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Category") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Address Country") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Address City") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Zip Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Address Line1") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Address Line2") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Contact Person") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Contact Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Address") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A42SupplierGenId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A43SupplierGenKvkNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A282SupplierGenTypeId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A44SupplierGenCompanyName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSupplierGenCompanyName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A290SupplierGenTypeName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSupplierGenTypeName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A335SupplierGenAddressCountry));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A295SupplierGenAddressCity));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A294SupplierGenAddressZipCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A336SupplierGenAddressLine1));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A337SupplierGenAddressLine2));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A47SupplierGenContactName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A48SupplierGenContactPhone)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV55SupplierGenAddress));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSuppliergenaddress_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV38Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV40Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV42Delete)));
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
         edtSupplierGenId_Internalname = "SUPPLIERGENID";
         edtSupplierGenKvkNumber_Internalname = "SUPPLIERGENKVKNUMBER";
         edtSupplierGenTypeId_Internalname = "SUPPLIERGENTYPEID";
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME";
         edtSupplierGenTypeName_Internalname = "SUPPLIERGENTYPENAME";
         edtSupplierGenAddressCountry_Internalname = "SUPPLIERGENADDRESSCOUNTRY";
         edtSupplierGenAddressCity_Internalname = "SUPPLIERGENADDRESSCITY";
         edtSupplierGenAddressZipCode_Internalname = "SUPPLIERGENADDRESSZIPCODE";
         edtSupplierGenAddressLine1_Internalname = "SUPPLIERGENADDRESSLINE1";
         edtSupplierGenAddressLine2_Internalname = "SUPPLIERGENADDRESSLINE2";
         edtSupplierGenContactName_Internalname = "SUPPLIERGENCONTACTNAME";
         edtSupplierGenContactPhone_Internalname = "SUPPLIERGENCONTACTPHONE";
         edtavSuppliergenaddress_Internalname = "vSUPPLIERGENADDRESS";
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
         edtavSuppliergenaddress_Jsonclick = "";
         edtavSuppliergenaddress_Enabled = 0;
         edtSupplierGenContactPhone_Jsonclick = "";
         edtSupplierGenContactName_Jsonclick = "";
         edtSupplierGenAddressLine2_Jsonclick = "";
         edtSupplierGenAddressLine1_Jsonclick = "";
         edtSupplierGenAddressZipCode_Jsonclick = "";
         edtSupplierGenAddressCity_Jsonclick = "";
         edtSupplierGenAddressCountry_Jsonclick = "";
         edtSupplierGenTypeName_Jsonclick = "";
         edtSupplierGenTypeName_Link = "";
         edtSupplierGenCompanyName_Jsonclick = "";
         edtSupplierGenCompanyName_Link = "";
         edtSupplierGenTypeId_Jsonclick = "";
         edtSupplierGenKvkNumber_Jsonclick = "";
         edtSupplierGenId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtavDisplay_Visible = -1;
         edtSupplierGenContactPhone_Enabled = 0;
         edtSupplierGenContactName_Enabled = 0;
         edtSupplierGenAddressLine2_Enabled = 0;
         edtSupplierGenAddressLine1_Enabled = 0;
         edtSupplierGenAddressZipCode_Enabled = 0;
         edtSupplierGenAddressCity_Enabled = 0;
         edtSupplierGenAddressCountry_Enabled = 0;
         edtSupplierGenTypeName_Enabled = 0;
         edtSupplierGenCompanyName_Enabled = 0;
         edtSupplierGenTypeId_Enabled = 0;
         edtSupplierGenKvkNumber_Enabled = 0;
         edtSupplierGenId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "Trn_SupplierGenWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "3:SupplierGenCompanyName|4:SupplierGenTypeName|10:SupplierGenContactName|11:SupplierGenContactPhone";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Page <CURRENT_PAGE> of <TOTAL_PAGES>";
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
         Form.Caption = " General Suppliers";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV25TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV22TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV23TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV26TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV27TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV28TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV29TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV39IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV41IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV43IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV45IsAuthorized_SupplierGenTypeName","fld":"vISAUTHORIZED_SUPPLIERGENTYPENAME","hsh":true},{"av":"AV44IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV34GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV35GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV36GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV39IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV41IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV43IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV44IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E124O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV25TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV22TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV23TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV26TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV27TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV28TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV29TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV39IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV41IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV43IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV45IsAuthorized_SupplierGenTypeName","fld":"vISAUTHORIZED_SUPPLIERGENTYPENAME","hsh":true},{"av":"AV44IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E134O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV25TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV22TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV23TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV26TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV27TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV28TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV29TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV39IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV41IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV43IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV45IsAuthorized_SupplierGenTypeName","fld":"vISAUTHORIZED_SUPPLIERGENTYPENAME","hsh":true},{"av":"AV44IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E154O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV25TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV22TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV23TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV26TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV27TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV28TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV29TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV39IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV41IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV43IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV45IsAuthorized_SupplierGenTypeName","fld":"vISAUTHORIZED_SUPPLIERGENTYPENAME","hsh":true},{"av":"AV44IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV24TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV25TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV22TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV23TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV26TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV27TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV28TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV29TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E194O2","iparms":[{"av":"A335SupplierGenAddressCountry","fld":"SUPPLIERGENADDRESSCOUNTRY"},{"av":"A295SupplierGenAddressCity","fld":"SUPPLIERGENADDRESSCITY"},{"av":"A294SupplierGenAddressZipCode","fld":"SUPPLIERGENADDRESSZIPCODE"},{"av":"A336SupplierGenAddressLine1","fld":"SUPPLIERGENADDRESSLINE1"},{"av":"A337SupplierGenAddressLine2","fld":"SUPPLIERGENADDRESSLINE2"},{"av":"AV39IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID","hsh":true},{"av":"AV41IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV43IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV45IsAuthorized_SupplierGenTypeName","fld":"vISAUTHORIZED_SUPPLIERGENTYPENAME","hsh":true},{"av":"A282SupplierGenTypeId","fld":"SUPPLIERGENTYPEID"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV55SupplierGenAddress","fld":"vSUPPLIERGENADDRESS"},{"av":"AV38Display","fld":"vDISPLAY"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV40Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV42Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtSupplierGenCompanyName_Link","ctrl":"SUPPLIERGENCOMPANYNAME","prop":"Link"},{"av":"edtSupplierGenTypeName_Link","ctrl":"SUPPLIERGENTYPENAME","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E114O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV25TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV22TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV23TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV26TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV27TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV28TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV29TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV39IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV41IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV43IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV45IsAuthorized_SupplierGenTypeName","fld":"vISAUTHORIZED_SUPPLIERGENTYPENAME","hsh":true},{"av":"AV44IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV25TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV22TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV23TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV26TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV27TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV28TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV29TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV34GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV35GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV36GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV39IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV41IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV43IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV44IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E164O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV24TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV25TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV22TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV23TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV26TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV27TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV28TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV29TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV39IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV41IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV43IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_SupplierGenCompanyName","fld":"vISAUTHORIZED_SUPPLIERGENCOMPANYNAME","hsh":true},{"av":"AV45IsAuthorized_SupplierGenTypeName","fld":"vISAUTHORIZED_SUPPLIERGENTYPENAME","hsh":true},{"av":"AV44IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV34GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV35GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV36GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV39IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV41IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV43IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV44IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E144O2","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VALID_SUPPLIERGENTYPEID","""{"handler":"Valid_Suppliergentypeid","iparms":[]}""");
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
         AV15FilterFullText = "";
         AV56Pgmname = "";
         AV24TFSupplierGenCompanyName = "";
         AV25TFSupplierGenCompanyName_Sel = "";
         AV22TFSupplierGenTypeName = "";
         AV23TFSupplierGenTypeName_Sel = "";
         AV26TFSupplierGenContactName = "";
         AV27TFSupplierGenContactName_Sel = "";
         AV28TFSupplierGenContactPhone = "";
         AV29TFSupplierGenContactPhone_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV36GridAppliedFilters = "";
         AV30DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
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
         A42SupplierGenId = Guid.Empty;
         A43SupplierGenKvkNumber = "";
         A282SupplierGenTypeId = Guid.Empty;
         A44SupplierGenCompanyName = "";
         A290SupplierGenTypeName = "";
         A335SupplierGenAddressCountry = "";
         A295SupplierGenAddressCity = "";
         A294SupplierGenAddressZipCode = "";
         A336SupplierGenAddressLine1 = "";
         A337SupplierGenAddressLine2 = "";
         A47SupplierGenContactName = "";
         A48SupplierGenContactPhone = "";
         AV55SupplierGenAddress = "";
         AV38Display = "";
         AV40Update = "";
         AV42Delete = "";
         lV57Trn_suppliergenwwds_1_filterfulltext = "";
         lV58Trn_suppliergenwwds_2_tfsuppliergencompanyname = "";
         lV60Trn_suppliergenwwds_4_tfsuppliergentypename = "";
         lV62Trn_suppliergenwwds_6_tfsuppliergencontactname = "";
         lV64Trn_suppliergenwwds_8_tfsuppliergencontactphone = "";
         AV57Trn_suppliergenwwds_1_filterfulltext = "";
         AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel = "";
         AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname = "";
         AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel = "";
         AV60Trn_suppliergenwwds_4_tfsuppliergentypename = "";
         AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel = "";
         AV62Trn_suppliergenwwds_6_tfsuppliergencontactname = "";
         AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel = "";
         AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone = "";
         H004O2_A48SupplierGenContactPhone = new string[] {""} ;
         H004O2_A47SupplierGenContactName = new string[] {""} ;
         H004O2_A337SupplierGenAddressLine2 = new string[] {""} ;
         H004O2_A336SupplierGenAddressLine1 = new string[] {""} ;
         H004O2_A294SupplierGenAddressZipCode = new string[] {""} ;
         H004O2_A295SupplierGenAddressCity = new string[] {""} ;
         H004O2_A335SupplierGenAddressCountry = new string[] {""} ;
         H004O2_A290SupplierGenTypeName = new string[] {""} ;
         H004O2_A44SupplierGenCompanyName = new string[] {""} ;
         H004O2_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         H004O2_A43SupplierGenKvkNumber = new string[] {""} ;
         H004O2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H004O3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV31GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV32GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV16Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergenww__default(),
            new Object[][] {
                new Object[] {
               H004O2_A48SupplierGenContactPhone, H004O2_A47SupplierGenContactName, H004O2_A337SupplierGenAddressLine2, H004O2_A336SupplierGenAddressLine1, H004O2_A294SupplierGenAddressZipCode, H004O2_A295SupplierGenAddressCity, H004O2_A335SupplierGenAddressCountry, H004O2_A290SupplierGenTypeName, H004O2_A44SupplierGenCompanyName, H004O2_A282SupplierGenTypeId,
               H004O2_A43SupplierGenKvkNumber, H004O2_A42SupplierGenId
               }
               , new Object[] {
               H004O3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV56Pgmname = "Trn_SupplierGenWW";
         /* GeneXus formulas. */
         AV56Pgmname = "Trn_SupplierGenWW";
         edtavSuppliergenaddress_Enabled = 0;
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
      private int edtavSuppliergenaddress_Enabled ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSupplierGenId_Enabled ;
      private int edtSupplierGenKvkNumber_Enabled ;
      private int edtSupplierGenTypeId_Enabled ;
      private int edtSupplierGenCompanyName_Enabled ;
      private int edtSupplierGenTypeName_Enabled ;
      private int edtSupplierGenAddressCountry_Enabled ;
      private int edtSupplierGenAddressCity_Enabled ;
      private int edtSupplierGenAddressZipCode_Enabled ;
      private int edtSupplierGenAddressLine1_Enabled ;
      private int edtSupplierGenAddressLine2_Enabled ;
      private int edtSupplierGenContactName_Enabled ;
      private int edtSupplierGenContactPhone_Enabled ;
      private int AV33PageToGo ;
      private int edtavDisplay_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV66GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV34GridCurrentPage ;
      private long AV35GridPageCount ;
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
      private string AV28TFSupplierGenContactPhone ;
      private string AV29TFSupplierGenContactPhone_Sel ;
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
      private string edtSupplierGenId_Internalname ;
      private string edtSupplierGenKvkNumber_Internalname ;
      private string edtSupplierGenTypeId_Internalname ;
      private string edtSupplierGenCompanyName_Internalname ;
      private string edtSupplierGenTypeName_Internalname ;
      private string edtSupplierGenAddressCountry_Internalname ;
      private string edtSupplierGenAddressCity_Internalname ;
      private string edtSupplierGenAddressZipCode_Internalname ;
      private string edtSupplierGenAddressLine1_Internalname ;
      private string edtSupplierGenAddressLine2_Internalname ;
      private string edtSupplierGenContactName_Internalname ;
      private string A48SupplierGenContactPhone ;
      private string edtSupplierGenContactPhone_Internalname ;
      private string edtavSuppliergenaddress_Internalname ;
      private string AV38Display ;
      private string edtavDisplay_Internalname ;
      private string AV40Update ;
      private string edtavUpdate_Internalname ;
      private string AV42Delete ;
      private string edtavDelete_Internalname ;
      private string lV64Trn_suppliergenwwds_8_tfsuppliergencontactphone ;
      private string AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ;
      private string AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone ;
      private string edtavDisplay_Link ;
      private string GXEncryptionTmp ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtSupplierGenCompanyName_Link ;
      private string edtSupplierGenTypeName_Link ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtSupplierGenId_Jsonclick ;
      private string edtSupplierGenKvkNumber_Jsonclick ;
      private string edtSupplierGenTypeId_Jsonclick ;
      private string edtSupplierGenCompanyName_Jsonclick ;
      private string edtSupplierGenTypeName_Jsonclick ;
      private string edtSupplierGenAddressCountry_Jsonclick ;
      private string edtSupplierGenAddressCity_Jsonclick ;
      private string edtSupplierGenAddressZipCode_Jsonclick ;
      private string edtSupplierGenAddressLine1_Jsonclick ;
      private string edtSupplierGenAddressLine2_Jsonclick ;
      private string edtSupplierGenContactName_Jsonclick ;
      private string gxphoneLink ;
      private string edtSupplierGenContactPhone_Jsonclick ;
      private string edtavSuppliergenaddress_Jsonclick ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV39IsAuthorized_Display ;
      private bool AV41IsAuthorized_Update ;
      private bool AV43IsAuthorized_Delete ;
      private bool AV46IsAuthorized_SupplierGenCompanyName ;
      private bool AV45IsAuthorized_SupplierGenTypeName ;
      private bool AV44IsAuthorized_Insert ;
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
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean1 ;
      private string AV18ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV24TFSupplierGenCompanyName ;
      private string AV25TFSupplierGenCompanyName_Sel ;
      private string AV22TFSupplierGenTypeName ;
      private string AV23TFSupplierGenTypeName_Sel ;
      private string AV26TFSupplierGenContactName ;
      private string AV27TFSupplierGenContactName_Sel ;
      private string AV36GridAppliedFilters ;
      private string A43SupplierGenKvkNumber ;
      private string A44SupplierGenCompanyName ;
      private string A290SupplierGenTypeName ;
      private string A335SupplierGenAddressCountry ;
      private string A295SupplierGenAddressCity ;
      private string A294SupplierGenAddressZipCode ;
      private string A336SupplierGenAddressLine1 ;
      private string A337SupplierGenAddressLine2 ;
      private string A47SupplierGenContactName ;
      private string AV55SupplierGenAddress ;
      private string lV57Trn_suppliergenwwds_1_filterfulltext ;
      private string lV58Trn_suppliergenwwds_2_tfsuppliergencompanyname ;
      private string lV60Trn_suppliergenwwds_4_tfsuppliergentypename ;
      private string lV62Trn_suppliergenwwds_6_tfsuppliergencontactname ;
      private string AV57Trn_suppliergenwwds_1_filterfulltext ;
      private string AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ;
      private string AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname ;
      private string AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel ;
      private string AV60Trn_suppliergenwwds_4_tfsuppliergentypename ;
      private string AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ;
      private string AV62Trn_suppliergenwwds_6_tfsuppliergencontactname ;
      private Guid A42SupplierGenId ;
      private Guid A282SupplierGenTypeId ;
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
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV30DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H004O2_A48SupplierGenContactPhone ;
      private string[] H004O2_A47SupplierGenContactName ;
      private string[] H004O2_A337SupplierGenAddressLine2 ;
      private string[] H004O2_A336SupplierGenAddressLine1 ;
      private string[] H004O2_A294SupplierGenAddressZipCode ;
      private string[] H004O2_A295SupplierGenAddressCity ;
      private string[] H004O2_A335SupplierGenAddressCountry ;
      private string[] H004O2_A290SupplierGenTypeName ;
      private string[] H004O2_A44SupplierGenCompanyName ;
      private Guid[] H004O2_A282SupplierGenTypeId ;
      private string[] H004O2_A43SupplierGenKvkNumber ;
      private Guid[] H004O2_A42SupplierGenId ;
      private long[] H004O3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV31GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV32GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_suppliergenww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004O2( IGxContext context ,
                                             string AV57Trn_suppliergenwwds_1_filterfulltext ,
                                             string AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                             string AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                             string AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                             string AV60Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                             string AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                             string AV62Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                             string AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                             string AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[15];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SupplierGenContactPhone, T1.SupplierGenContactName, T1.SupplierGenAddressLine2, T1.SupplierGenAddressLine1, T1.SupplierGenAddressZipCode, T1.SupplierGenAddressCity, T1.SupplierGenAddressCountry, T2.SupplierGenTypeName, T1.SupplierGenCompanyName, T1.SupplierGenTypeId, T1.SupplierGenKvkNumber, T1.SupplierGenId";
         sFromString = " FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_suppliergenwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV57Trn_suppliergenwwds_1_filterfulltext) or ( T2.SupplierGenTypeName like '%' || :lV57Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactName like '%' || :lV57Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactPhone like '%' || :lV57Trn_suppliergenwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV58Trn_suppliergenwwds_2_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_suppliergenwwds_4_tfsuppliergentypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV60Trn_suppliergenwwds_4_tfsuppliergentypename)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_suppliergenwwds_6_tfsuppliergencontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV62Trn_suppliergenwwds_6_tfsuppliergencontactname)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV64Trn_suppliergenwwds_8_tfsuppliergencontactphone)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SupplierGenCompanyName, T1.SupplierGenId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SupplierGenCompanyName DESC, T1.SupplierGenId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.SupplierGenTypeName, T1.SupplierGenId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.SupplierGenTypeName DESC, T1.SupplierGenId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SupplierGenContactName, T1.SupplierGenId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SupplierGenContactName DESC, T1.SupplierGenId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SupplierGenContactPhone, T1.SupplierGenId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SupplierGenContactPhone DESC, T1.SupplierGenId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SupplierGenId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H004O3( IGxContext context ,
                                             string AV57Trn_suppliergenwwds_1_filterfulltext ,
                                             string AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel ,
                                             string AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname ,
                                             string AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel ,
                                             string AV60Trn_suppliergenwwds_4_tfsuppliergentypename ,
                                             string AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel ,
                                             string AV62Trn_suppliergenwwds_6_tfsuppliergencontactname ,
                                             string AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel ,
                                             string AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone ,
                                             string A44SupplierGenCompanyName ,
                                             string A290SupplierGenTypeName ,
                                             string A47SupplierGenContactName ,
                                             string A48SupplierGenContactPhone ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[12];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Trn_suppliergenwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SupplierGenCompanyName like '%' || :lV57Trn_suppliergenwwds_1_filterfulltext) or ( T2.SupplierGenTypeName like '%' || :lV57Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactName like '%' || :lV57Trn_suppliergenwwds_1_filterfulltext) or ( T1.SupplierGenContactPhone like '%' || :lV57Trn_suppliergenwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Trn_suppliergenwwds_2_tfsuppliergencompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName like :lV58Trn_suppliergenwwds_2_tfsuppliergencompanyname)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Trn_suppliergenwwds_4_tfsuppliergentypename)) ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName like :lV60Trn_suppliergenwwds_4_tfsuppliergentypename)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( StringUtil.StrCmp(AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_suppliergenwwds_6_tfsuppliergencontactname)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName like :lV62Trn_suppliergenwwds_6_tfsuppliergencontactname)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_suppliergenwwds_8_tfsuppliergencontactphone)) ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV64Trn_suppliergenwwds_8_tfsuppliergencontactphone)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
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
                     return conditional_H004O2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
               case 1 :
                     return conditional_H004O3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmH004O2;
          prmH004O2 = new Object[] {
          new ParDef("lV57Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Trn_suppliergenwwds_2_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_suppliergenwwds_4_tfsuppliergentypename",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_suppliergenwwds_6_tfsuppliergencontactname",GXType.VarChar,100,0) ,
          new ParDef("AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_suppliergenwwds_8_tfsuppliergencontactphone",GXType.Char,20,0) ,
          new ParDef("AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel",GXType.Char,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004O3;
          prmH004O3 = new Object[] {
          new ParDef("lV57Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Trn_suppliergenwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Trn_suppliergenwwds_2_tfsuppliergencompanyname",GXType.VarChar,100,0) ,
          new ParDef("AV59Trn_suppliergenwwds_3_tfsuppliergencompanyname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV60Trn_suppliergenwwds_4_tfsuppliergentypename",GXType.VarChar,100,0) ,
          new ParDef("AV61Trn_suppliergenwwds_5_tfsuppliergentypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_suppliergenwwds_6_tfsuppliergencontactname",GXType.VarChar,100,0) ,
          new ParDef("AV63Trn_suppliergenwwds_7_tfsuppliergencontactname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_suppliergenwwds_8_tfsuppliergencontactphone",GXType.Char,20,0) ,
          new ParDef("AV65Trn_suppliergenwwds_9_tfsuppliergencontactphone_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004O2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004O3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[9])[0] = rslt.getGuid(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((Guid[]) buf[11])[0] = rslt.getGuid(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}