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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_forminstanceww : GXDataArea
   {
      public wwp_forminstanceww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_forminstanceww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           string aP1_WWPFormTitle )
      {
         this.AV40WWPFormId = aP0_WWPFormId;
         this.AV44WWPFormTitle = aP1_WWPFormTitle;
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
            gxfirstwebparm = GetFirstPar( "WWPFormId");
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
               gxfirstwebparm = GetFirstPar( "WWPFormId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPFormId");
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
         nRC_GXsfl_31 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_31"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_31_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_31_idx = GetPar( "sGXsfl_31_idx");
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
         AV11OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV12OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV13FilterFullText = GetPar( "FilterFullText");
         AV23ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV55Pgmname = GetPar( "Pgmname");
         AV40WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
         AV24TFWWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormInstanceId"), "."), 18, MidpointRounding.ToEven));
         AV25TFWWPFormInstanceId_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormInstanceId_To"), "."), 18, MidpointRounding.ToEven));
         AV26TFWWPFormInstanceDate = context.localUtil.ParseDateParm( GetPar( "TFWWPFormInstanceDate"));
         AV27TFWWPFormInstanceDate_To = context.localUtil.ParseDateParm( GetPar( "TFWWPFormInstanceDate_To"));
         AV31TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
         AV32TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormVersionNumber_To"), "."), 18, MidpointRounding.ToEven));
         AV48TFWWPUserExtendedFullName = GetPar( "TFWWPUserExtendedFullName");
         AV49TFWWPUserExtendedFullName_Sel = GetPar( "TFWWPUserExtendedFullName_Sel");
         AV44WWPFormTitle = GetPar( "WWPFormTitle");
         AV52IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV53IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV54IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV23ManageFiltersExecutionStep, AV55Pgmname, AV40WWPFormId, AV24TFWWPFormInstanceId, AV25TFWWPFormInstanceId_To, AV26TFWWPFormInstanceDate, AV27TFWWPFormInstanceDate_To, AV31TFWWPFormVersionNumber, AV32TFWWPFormVersionNumber_To, AV48TFWWPUserExtendedFullName, AV49TFWWPUserExtendedFullName_Sel, AV44WWPFormTitle, AV52IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Display) ;
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
            return "wwp_forminstanceww_Execute" ;
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
         PA202( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START202( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_forminstanceww.aspx"+UrlEncode(StringUtil.LTrimStr(AV40WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV44WWPFormTitle));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_forminstanceww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTITLE", AV44WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44WWPFormTitle, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV52IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV52IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV54IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV54IsAuthorized_Display, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV12OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV13FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_31", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_31), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV21ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV37GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV33DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV33DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_WWPFORMINSTANCEDATEAUXDATE", context.localUtil.DToC( AV28DDO_WWPFormInstanceDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_WWPFORMINSTANCEDATEAUXDATETO", context.localUtil.DToC( AV29DDO_WWPFormInstanceDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMINSTANCEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24TFWWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMINSTANCEID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFWWPFormInstanceId_To), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMINSTANCEDATE", context.localUtil.DToC( AV26TFWWPFormInstanceDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMINSTANCEDATE_TO", context.localUtil.DToC( AV27TFWWPFormInstanceDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFWWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMVERSIONNUMBER_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFWWPFormVersionNumber_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWWPUSEREXTENDEDFULLNAME", AV48TFWWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "vTFWWPUSEREXTENDEDFULLNAME_SEL", AV49TFWWPUserExtendedFullName_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV12OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vWWPFORMTITLE", AV44WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44WWPFormTitle, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV52IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV52IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV54IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV54IsAuthorized_Display, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV9GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV9GridState);
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMLATESTVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE202( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT202( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_forminstanceww.aspx"+UrlEncode(StringUtil.LTrimStr(AV40WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV44WWPFormTitle));
         return formatLink("workwithplus.dynamicforms.wwp_forminstanceww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.DynamicForms.WWP_FormInstanceWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " WWPForm Instance", "") ;
      }

      protected void WB200( )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV21ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_31_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV13FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstanceWW.htm");
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
            StartGridControl31( ) ;
         }
         if ( wbEnd == 31 )
         {
            wbEnd = 0;
            nRC_GXsfl_31 = (int)(nGXsfl_31_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV35GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV36GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV37GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV33DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_wwpforminstancedateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_31_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_wwpforminstancedateauxdatetext_Internalname, AV30DDO_WWPFormInstanceDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV30DDO_WWPFormInstanceDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_wwpforminstancedateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormInstanceWW.htm");
            /* User Defined Control */
            ucTfwwpforminstancedate_rangepicker.SetProperty("Start Date", AV28DDO_WWPFormInstanceDateAuxDate);
            ucTfwwpforminstancedate_rangepicker.SetProperty("End Date", AV29DDO_WWPFormInstanceDateAuxDateTo);
            ucTfwwpforminstancedate_rangepicker.Render(context, "wwp.daterangepicker", Tfwwpforminstancedate_rangepicker_Internalname, "TFWWPFORMINSTANCEDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 31 )
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

      protected void START202( )
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
         Form.Meta.addItem("description", context.GetMessage( " WWPForm Instance", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP200( ) ;
      }

      protected void WS202( )
      {
         START202( ) ;
         EVT202( ) ;
      }

      protected void EVT202( )
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
                              E11202 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12202 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13202 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14202 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVIEWREPORT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVIEWREPORT.CLICK") == 0 ) )
                           {
                              nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
                              SubsflControlProps_312( ) ;
                              A214WWPFormInstanceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormInstanceId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A239WWPFormInstanceDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtWWPFormInstanceDate_Internalname), 0));
                              AV43WWPFormVersionNumberWithTags = cgiGet( edtavWwpformversionnumberwithtags_Internalname);
                              AssignAttri("", false, edtavWwpformversionnumberwithtags_Internalname, AV43WWPFormVersionNumberWithTags);
                              A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
                              A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
                              A113WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
                              AV38Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV38Update);
                              AV39Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV39Delete);
                              AV41Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV41Display);
                              AV45ViewReport = cgiGet( edtavViewreport_Internalname);
                              AssignAttri("", false, edtavViewreport_Internalname, AV45ViewReport);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15202 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E16202 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E17202 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VVIEWREPORT.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E18202 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV12OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV13FilterFullText) != 0 )
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE202( )
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

      protected void PA202( )
      {
         if ( nDonePA == 0 )
         {
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_forminstanceww.aspx")), "workwithplus.dynamicforms.wwp_forminstanceww.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_forminstanceww.aspx")))) ;
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
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "WWPFormId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV40WWPFormId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV40WWPFormId", StringUtil.LTrimStr( (decimal)(AV40WWPFormId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV44WWPFormTitle = GetPar( "WWPFormTitle");
                        AssignAttri("", false, "AV44WWPFormTitle", AV44WWPFormTitle);
                        GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44WWPFormTitle, "")), context));
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
         SubsflControlProps_312( ) ;
         while ( nGXsfl_31_idx <= nRC_GXsfl_31 )
         {
            sendrow_312( ) ;
            nGXsfl_31_idx = ((subGrid_Islastpage==1)&&(nGXsfl_31_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
            sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
            SubsflControlProps_312( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV11OrderedBy ,
                                       bool AV12OrderedDsc ,
                                       string AV13FilterFullText ,
                                       short AV23ManageFiltersExecutionStep ,
                                       string AV55Pgmname ,
                                       short AV40WWPFormId ,
                                       int AV24TFWWPFormInstanceId ,
                                       int AV25TFWWPFormInstanceId_To ,
                                       DateTime AV26TFWWPFormInstanceDate ,
                                       DateTime AV27TFWWPFormInstanceDate_To ,
                                       short AV31TFWWPFormVersionNumber ,
                                       short AV32TFWWPFormVersionNumber_To ,
                                       string AV48TFWWPUserExtendedFullName ,
                                       string AV49TFWWPUserExtendedFullName_Sel ,
                                       string AV44WWPFormTitle ,
                                       bool AV52IsAuthorized_Update ,
                                       bool AV53IsAuthorized_Delete ,
                                       bool AV54IsAuthorized_Display )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF202( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMINSTANCEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A214WWPFormInstanceId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMINSTANCEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A214WWPFormInstanceId), 6, 0, ".", "")));
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
         RF202( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV55Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstanceWW";
         edtavWwpformversionnumberwithtags_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtavDisplay_Enabled = 0;
         edtavViewreport_Enabled = 0;
      }

      protected void RF202( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 31;
         /* Execute user event: Refresh */
         E16202 ();
         nGXsfl_31_idx = 1;
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         bGXsfl_31_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_312( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext ,
                                                 AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid ,
                                                 AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to ,
                                                 AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate ,
                                                 AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to ,
                                                 AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber ,
                                                 AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to ,
                                                 AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel ,
                                                 AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname ,
                                                 A214WWPFormInstanceId ,
                                                 A207WWPFormVersionNumber ,
                                                 A113WWPUserExtendedFullName ,
                                                 A239WWPFormInstanceDate ,
                                                 AV11OrderedBy ,
                                                 AV12OrderedDsc ,
                                                 A206WWPFormId ,
                                                 AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext), "%", "");
            lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext), "%", "");
            lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext), "%", "");
            lV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = StringUtil.Concat( StringUtil.RTrim( AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname), "%", "");
            /* Using cursor H00202 */
            pr_default.execute(0, new Object[] {AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid, lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext, lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext, lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext, AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid, AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to, AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate, AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to, AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber, AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to, lV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname, AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_31_idx = 1;
            sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
            SubsflControlProps_312( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A112WWPUserExtendedId = H00202_A112WWPUserExtendedId[0];
               A113WWPUserExtendedFullName = H00202_A113WWPUserExtendedFullName[0];
               A208WWPFormReferenceName = H00202_A208WWPFormReferenceName[0];
               A209WWPFormTitle = H00202_A209WWPFormTitle[0];
               A207WWPFormVersionNumber = H00202_A207WWPFormVersionNumber[0];
               A239WWPFormInstanceDate = H00202_A239WWPFormInstanceDate[0];
               A214WWPFormInstanceId = H00202_A214WWPFormInstanceId[0];
               A206WWPFormId = H00202_A206WWPFormId[0];
               A113WWPUserExtendedFullName = H00202_A113WWPUserExtendedFullName[0];
               A208WWPFormReferenceName = H00202_A208WWPFormReferenceName[0];
               A209WWPFormTitle = H00202_A209WWPFormTitle[0];
               GXt_int1 = A219WWPFormLatestVersionNumber;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
               A219WWPFormLatestVersionNumber = GXt_int1;
               AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
               /* Execute user event: Grid.Load */
               E17202 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 31;
            WB200( ) ;
         }
         bGXsfl_31_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes202( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV52IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV52IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV54IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV54IsAuthorized_Display, context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMINSTANCEID"+"_"+sGXsfl_31_idx, GetSecureSignedToken( sGXsfl_31_idx, context.localUtil.Format( (decimal)(A214WWPFormInstanceId), "ZZZZZ9"), context));
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
         AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid = AV40WWPFormId;
         AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = AV13FilterFullText;
         AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid = AV24TFWWPFormInstanceId;
         AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to = AV25TFWWPFormInstanceId_To;
         AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate = AV26TFWWPFormInstanceDate;
         AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to = AV27TFWWPFormInstanceDate_To;
         AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber = AV31TFWWPFormVersionNumber;
         AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to = AV32TFWWPFormVersionNumber_To;
         AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = AV48TFWWPUserExtendedFullName;
         AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel = AV49TFWWPUserExtendedFullName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext ,
                                              AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid ,
                                              AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to ,
                                              AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate ,
                                              AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to ,
                                              AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber ,
                                              AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to ,
                                              AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel ,
                                              AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname ,
                                              A214WWPFormInstanceId ,
                                              A207WWPFormVersionNumber ,
                                              A113WWPUserExtendedFullName ,
                                              A239WWPFormInstanceDate ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A206WWPFormId ,
                                              AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext), "%", "");
         lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext), "%", "");
         lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext), "%", "");
         lV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = StringUtil.Concat( StringUtil.RTrim( AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname), "%", "");
         /* Using cursor H00203 */
         pr_default.execute(1, new Object[] {AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid, lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext, lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext, lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext, AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid, AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to, AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate, AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to, AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber, AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to, lV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname, AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel});
         GRID_nRecordCount = H00203_AGRID_nRecordCount[0];
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
         AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid = AV40WWPFormId;
         AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = AV13FilterFullText;
         AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid = AV24TFWWPFormInstanceId;
         AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to = AV25TFWWPFormInstanceId_To;
         AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate = AV26TFWWPFormInstanceDate;
         AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to = AV27TFWWPFormInstanceDate_To;
         AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber = AV31TFWWPFormVersionNumber;
         AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to = AV32TFWWPFormVersionNumber_To;
         AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = AV48TFWWPUserExtendedFullName;
         AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel = AV49TFWWPUserExtendedFullName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV23ManageFiltersExecutionStep, AV55Pgmname, AV40WWPFormId, AV24TFWWPFormInstanceId, AV25TFWWPFormInstanceId_To, AV26TFWWPFormInstanceDate, AV27TFWWPFormInstanceDate_To, AV31TFWWPFormVersionNumber, AV32TFWWPFormVersionNumber_To, AV48TFWWPUserExtendedFullName, AV49TFWWPUserExtendedFullName_Sel, AV44WWPFormTitle, AV52IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Display) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid = AV40WWPFormId;
         AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = AV13FilterFullText;
         AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid = AV24TFWWPFormInstanceId;
         AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to = AV25TFWWPFormInstanceId_To;
         AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate = AV26TFWWPFormInstanceDate;
         AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to = AV27TFWWPFormInstanceDate_To;
         AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber = AV31TFWWPFormVersionNumber;
         AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to = AV32TFWWPFormVersionNumber_To;
         AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = AV48TFWWPUserExtendedFullName;
         AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel = AV49TFWWPUserExtendedFullName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV23ManageFiltersExecutionStep, AV55Pgmname, AV40WWPFormId, AV24TFWWPFormInstanceId, AV25TFWWPFormInstanceId_To, AV26TFWWPFormInstanceDate, AV27TFWWPFormInstanceDate_To, AV31TFWWPFormVersionNumber, AV32TFWWPFormVersionNumber_To, AV48TFWWPUserExtendedFullName, AV49TFWWPUserExtendedFullName_Sel, AV44WWPFormTitle, AV52IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Display) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid = AV40WWPFormId;
         AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = AV13FilterFullText;
         AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid = AV24TFWWPFormInstanceId;
         AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to = AV25TFWWPFormInstanceId_To;
         AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate = AV26TFWWPFormInstanceDate;
         AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to = AV27TFWWPFormInstanceDate_To;
         AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber = AV31TFWWPFormVersionNumber;
         AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to = AV32TFWWPFormVersionNumber_To;
         AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = AV48TFWWPUserExtendedFullName;
         AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel = AV49TFWWPUserExtendedFullName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV23ManageFiltersExecutionStep, AV55Pgmname, AV40WWPFormId, AV24TFWWPFormInstanceId, AV25TFWWPFormInstanceId_To, AV26TFWWPFormInstanceDate, AV27TFWWPFormInstanceDate_To, AV31TFWWPFormVersionNumber, AV32TFWWPFormVersionNumber_To, AV48TFWWPUserExtendedFullName, AV49TFWWPUserExtendedFullName_Sel, AV44WWPFormTitle, AV52IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Display) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid = AV40WWPFormId;
         AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = AV13FilterFullText;
         AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid = AV24TFWWPFormInstanceId;
         AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to = AV25TFWWPFormInstanceId_To;
         AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate = AV26TFWWPFormInstanceDate;
         AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to = AV27TFWWPFormInstanceDate_To;
         AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber = AV31TFWWPFormVersionNumber;
         AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to = AV32TFWWPFormVersionNumber_To;
         AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = AV48TFWWPUserExtendedFullName;
         AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel = AV49TFWWPUserExtendedFullName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV23ManageFiltersExecutionStep, AV55Pgmname, AV40WWPFormId, AV24TFWWPFormInstanceId, AV25TFWWPFormInstanceId_To, AV26TFWWPFormInstanceDate, AV27TFWWPFormInstanceDate_To, AV31TFWWPFormVersionNumber, AV32TFWWPFormVersionNumber_To, AV48TFWWPUserExtendedFullName, AV49TFWWPUserExtendedFullName_Sel, AV44WWPFormTitle, AV52IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Display) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid = AV40WWPFormId;
         AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = AV13FilterFullText;
         AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid = AV24TFWWPFormInstanceId;
         AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to = AV25TFWWPFormInstanceId_To;
         AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate = AV26TFWWPFormInstanceDate;
         AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to = AV27TFWWPFormInstanceDate_To;
         AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber = AV31TFWWPFormVersionNumber;
         AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to = AV32TFWWPFormVersionNumber_To;
         AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = AV48TFWWPUserExtendedFullName;
         AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel = AV49TFWWPUserExtendedFullName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV11OrderedBy, AV12OrderedDsc, AV13FilterFullText, AV23ManageFiltersExecutionStep, AV55Pgmname, AV40WWPFormId, AV24TFWWPFormInstanceId, AV25TFWWPFormInstanceId_To, AV26TFWWPFormInstanceDate, AV27TFWWPFormInstanceDate_To, AV31TFWWPFormVersionNumber, AV32TFWWPFormVersionNumber_To, AV48TFWWPUserExtendedFullName, AV49TFWWPUserExtendedFullName_Sel, AV44WWPFormTitle, AV52IsAuthorized_Update, AV53IsAuthorized_Delete, AV54IsAuthorized_Display) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV55Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstanceWW";
         edtavWwpformversionnumberwithtags_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtavDisplay_Enabled = 0;
         edtavViewreport_Enabled = 0;
         edtWWPFormInstanceId_Enabled = 0;
         edtWWPFormInstanceDate_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPUserExtendedFullName_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP200( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15202 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV21ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV33DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_31 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_31"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV35GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV36GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV37GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV28DDO_WWPFormInstanceDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_WWPFORMINSTANCEDATEAUXDATE"), 0);
            AV29DDO_WWPFormInstanceDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_WWPFORMINSTANCEDATEAUXDATETO"), 0);
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
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV13FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
            AV30DDO_WWPFormInstanceDateAuxDateText = cgiGet( edtavDdo_wwpforminstancedateauxdatetext_Internalname);
            AssignAttri("", false, "AV30DDO_WWPFormInstanceDateAuxDateText", AV30DDO_WWPFormInstanceDateAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV12OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV13FilterFullText) != 0 )
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
         E15202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15202( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFWWPFORMINSTANCEDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_wwpforminstancedateauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV6HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV50GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV51GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV50GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = StringUtil.Format( context.GetMessage( "WWP_DF_FilledOutFormsCaption", ""), AV44WWPFormTitle, "", "", "", "", "", "", "", "");
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
         if ( AV11OrderedBy < 1 )
         {
            AV11OrderedBy = 1;
            AssignAttri("", false, "AV11OrderedBy", StringUtil.LTrimStr( (decimal)(AV11OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV33DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV33DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E16202( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV5WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV23ManageFiltersExecutionStep == 1 )
         {
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV23ManageFiltersExecutionStep == 2 )
         {
            AV23ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
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
         AV35GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV35GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV35GridCurrentPage), 10, 0));
         AV36GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV36GridPageCount", StringUtil.LTrimStr( (decimal)(AV36GridPageCount), 10, 0));
         GXt_char3 = AV37GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV55Pgmname, out  GXt_char3) ;
         AV37GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV37GridAppliedFilters", AV37GridAppliedFilters);
         AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid = AV40WWPFormId;
         AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = AV13FilterFullText;
         AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid = AV24TFWWPFormInstanceId;
         AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to = AV25TFWWPFormInstanceId_To;
         AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate = AV26TFWWPFormInstanceDate;
         AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to = AV27TFWWPFormInstanceDate_To;
         AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber = AV31TFWWPFormVersionNumber;
         AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to = AV32TFWWPFormVersionNumber_To;
         AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = AV48TFWWPUserExtendedFullName;
         AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel = AV49TFWWPUserExtendedFullName_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9GridState", AV9GridState);
      }

      protected void E12202( )
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
            AV34PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV34PageToGo) ;
         }
      }

      protected void E13202( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14202( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV11OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11OrderedBy", StringUtil.LTrimStr( (decimal)(AV11OrderedBy), 4, 0));
            AV12OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV12OrderedDsc", AV12OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormInstanceId") == 0 )
            {
               AV24TFWWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24TFWWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV24TFWWPFormInstanceId), 6, 0));
               AV25TFWWPFormInstanceId_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFWWPFormInstanceId_To", StringUtil.LTrimStr( (decimal)(AV25TFWWPFormInstanceId_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormInstanceDate") == 0 )
            {
               AV26TFWWPFormInstanceDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV26TFWWPFormInstanceDate", context.localUtil.Format(AV26TFWWPFormInstanceDate, "99/99/99"));
               AV27TFWWPFormInstanceDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV27TFWWPFormInstanceDate_To", context.localUtil.Format(AV27TFWWPFormInstanceDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormVersionNumber") == 0 )
            {
               AV31TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV31TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV31TFWWPFormVersionNumber), 4, 0));
               AV32TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV32TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV32TFWWPFormVersionNumber_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPUserExtendedFullName") == 0 )
            {
               AV48TFWWPUserExtendedFullName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFWWPUserExtendedFullName", AV48TFWWPUserExtendedFullName);
               AV49TFWWPUserExtendedFullName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFWWPUserExtendedFullName_Sel", AV49TFWWPUserExtendedFullName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E17202( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV38Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV38Update);
         if ( AV52IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_dynamicform.aspx"+UrlEncode(StringUtil.RTrim(A208WWPFormReferenceName)) + "," + UrlEncode(StringUtil.LTrimStr(A214WWPFormInstanceId,6,0)) + "," + UrlEncode(StringUtil.RTrim("UPD"));
            edtavUpdate_Link = formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV39Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV39Delete);
         if ( AV53IsAuthorized_Delete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_dynamicform.aspx"+UrlEncode(StringUtil.RTrim(A208WWPFormReferenceName)) + "," + UrlEncode(StringUtil.LTrimStr(A214WWPFormInstanceId,6,0)) + "," + UrlEncode(StringUtil.RTrim("UPD"));
            edtavDelete_Link = formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV41Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV41Display);
         if ( AV54IsAuthorized_Display )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_dynamicform.aspx"+UrlEncode(StringUtil.RTrim(A208WWPFormReferenceName)) + "," + UrlEncode(StringUtil.LTrimStr(A214WWPFormInstanceId,6,0)) + "," + UrlEncode(StringUtil.RTrim("DSP"));
            edtavDisplay_Link = formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV45ViewReport = "<i class=\"far fa-file-pdf\"></i>";
         AssignAttri("", false, edtavViewreport_Internalname, AV45ViewReport);
         edtavWwpformversionnumberwithtags_Horizontalalignment = "Right";
         AV43WWPFormVersionNumberWithTags = StringUtil.Trim( context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"));
         AssignAttri("", false, edtavWwpformversionnumberwithtags_Internalname, AV43WWPFormVersionNumberWithTags);
         if ( A207WWPFormVersionNumber < A219WWPFormLatestVersionNumber )
         {
            AV43WWPFormVersionNumberWithTags += StringUtil.Format( "<i class='fa fa-exclamation-circle FontColorIconDanger	 TagAfterText BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "WWP_DF_FilledOutInDeprecatedVersion", ""), "", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavWwpformversionnumberwithtags_Internalname, AV43WWPFormVersionNumberWithTags);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 31;
         }
         sendrow_312( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_31_Refreshing )
         {
            DoAjaxLoad(31, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E11202( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WorkWithPlus.DynamicForms.WWP_FormInstanceWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV55Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WorkWithPlus.DynamicForms.WWP_FormInstanceWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV23ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV23ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV23ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV22ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WorkWithPlus.DynamicForms.WWP_FormInstanceWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV22ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV55Pgmname+"GridState",  AV22ManageFiltersXml) ;
               AV9GridState.FromXml(AV22ManageFiltersXml, null, "", "");
               AV11OrderedBy = AV9GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV11OrderedBy", StringUtil.LTrimStr( (decimal)(AV11OrderedBy), 4, 0));
               AV12OrderedDsc = AV9GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV12OrderedDsc", AV12OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9GridState", AV9GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ManageFiltersData", AV21ManageFiltersData);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV11OrderedBy), 4, 0))+":"+(AV12OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean4 = AV52IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_dynamicform_Execute", out  GXt_boolean4) ;
         AV52IsAuthorized_Update = GXt_boolean4;
         AssignAttri("", false, "AV52IsAuthorized_Update", AV52IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV52IsAuthorized_Update, context));
         if ( ! ( AV52IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_31_Refreshing);
         }
         GXt_boolean4 = AV53IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_dynamicform_Execute", out  GXt_boolean4) ;
         AV53IsAuthorized_Delete = GXt_boolean4;
         AssignAttri("", false, "AV53IsAuthorized_Delete", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         if ( ! ( AV53IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_31_Refreshing);
         }
         GXt_boolean4 = AV54IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_dynamicform_Execute", out  GXt_boolean4) ;
         AV54IsAuthorized_Display = GXt_boolean4;
         AssignAttri("", false, "AV54IsAuthorized_Display", AV54IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV54IsAuthorized_Display, context));
         if ( ! ( AV54IsAuthorized_Display ) )
         {
            edtavDisplay_Visible = 0;
            AssignProp("", false, edtavDisplay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDisplay_Visible), 5, 0), !bGXsfl_31_Refreshing);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV21ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WorkWithPlus.DynamicForms.WWP_FormInstanceWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV21ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV13FilterFullText = "";
         AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
         AV24TFWWPFormInstanceId = 0;
         AssignAttri("", false, "AV24TFWWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV24TFWWPFormInstanceId), 6, 0));
         AV25TFWWPFormInstanceId_To = 0;
         AssignAttri("", false, "AV25TFWWPFormInstanceId_To", StringUtil.LTrimStr( (decimal)(AV25TFWWPFormInstanceId_To), 6, 0));
         AV26TFWWPFormInstanceDate = DateTime.MinValue;
         AssignAttri("", false, "AV26TFWWPFormInstanceDate", context.localUtil.Format(AV26TFWWPFormInstanceDate, "99/99/99"));
         AV27TFWWPFormInstanceDate_To = DateTime.MinValue;
         AssignAttri("", false, "AV27TFWWPFormInstanceDate_To", context.localUtil.Format(AV27TFWWPFormInstanceDate_To, "99/99/99"));
         AV31TFWWPFormVersionNumber = 0;
         AssignAttri("", false, "AV31TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV31TFWWPFormVersionNumber), 4, 0));
         AV32TFWWPFormVersionNumber_To = 0;
         AssignAttri("", false, "AV32TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV32TFWWPFormVersionNumber_To), 4, 0));
         AV48TFWWPUserExtendedFullName = "";
         AssignAttri("", false, "AV48TFWWPUserExtendedFullName", AV48TFWWPUserExtendedFullName);
         AV49TFWWPUserExtendedFullName_Sel = "";
         AssignAttri("", false, "AV49TFWWPUserExtendedFullName_Sel", AV49TFWWPUserExtendedFullName_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get(AV55Pgmname+"GridState"), "") == 0 )
         {
            AV9GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV55Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV9GridState.FromXml(AV20Session.Get(AV55Pgmname+"GridState"), null, "", "");
         }
         AV11OrderedBy = AV9GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV11OrderedBy", StringUtil.LTrimStr( (decimal)(AV11OrderedBy), 4, 0));
         AV12OrderedDsc = AV9GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV12OrderedDsc", AV12OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV9GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV9GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV9GridState.gxTpr_Currentpage) ;
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV9GridState.gxTpr_Filtervalues.Count )
         {
            AV10GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV9GridState.gxTpr_Filtervalues.Item(AV66GXV1));
            if ( StringUtil.StrCmp(AV10GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV10GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV13FilterFullText", AV13FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV10GridStateFilterValue.gxTpr_Name, "TFWWPFORMINSTANCEID") == 0 )
            {
               AV24TFWWPFormInstanceId = (int)(Math.Round(NumberUtil.Val( AV10GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24TFWWPFormInstanceId", StringUtil.LTrimStr( (decimal)(AV24TFWWPFormInstanceId), 6, 0));
               AV25TFWWPFormInstanceId_To = (int)(Math.Round(NumberUtil.Val( AV10GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFWWPFormInstanceId_To", StringUtil.LTrimStr( (decimal)(AV25TFWWPFormInstanceId_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV10GridStateFilterValue.gxTpr_Name, "TFWWPFORMINSTANCEDATE") == 0 )
            {
               AV26TFWWPFormInstanceDate = context.localUtil.CToD( AV10GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV26TFWWPFormInstanceDate", context.localUtil.Format(AV26TFWWPFormInstanceDate, "99/99/99"));
               AV27TFWWPFormInstanceDate_To = context.localUtil.CToD( AV10GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV27TFWWPFormInstanceDate_To", context.localUtil.Format(AV27TFWWPFormInstanceDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV10GridStateFilterValue.gxTpr_Name, "TFWWPFORMVERSIONNUMBER") == 0 )
            {
               AV31TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV10GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV31TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV31TFWWPFormVersionNumber), 4, 0));
               AV32TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV10GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV32TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV32TFWWPFormVersionNumber_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV10GridStateFilterValue.gxTpr_Name, "TFWWPUSEREXTENDEDFULLNAME") == 0 )
            {
               AV48TFWWPUserExtendedFullName = AV10GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFWWPUserExtendedFullName", AV48TFWWPUserExtendedFullName);
            }
            else if ( StringUtil.StrCmp(AV10GridStateFilterValue.gxTpr_Name, "TFWWPUSEREXTENDEDFULLNAME_SEL") == 0 )
            {
               AV49TFWWPUserExtendedFullName_Sel = AV10GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFWWPUserExtendedFullName_Sel", AV49TFWWPUserExtendedFullName_Sel);
            }
            AV66GXV1 = (int)(AV66GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFWWPUserExtendedFullName_Sel)),  AV49TFWWPUserExtendedFullName_Sel, out  GXt_char3) ;
         Ddo_grid_Selectedvalue_set = "|||"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFWWPUserExtendedFullName)),  AV48TFWWPUserExtendedFullName, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV24TFWWPFormInstanceId) ? "" : StringUtil.Str( (decimal)(AV24TFWWPFormInstanceId), 6, 0))+"|"+((DateTime.MinValue==AV26TFWWPFormInstanceDate) ? "" : context.localUtil.DToC( AV26TFWWPFormInstanceDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((0==AV31TFWWPFormVersionNumber) ? "" : StringUtil.Str( (decimal)(AV31TFWWPFormVersionNumber), 4, 0))+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV25TFWWPFormInstanceId_To) ? "" : StringUtil.Str( (decimal)(AV25TFWWPFormInstanceId_To), 6, 0))+"|"+((DateTime.MinValue==AV27TFWWPFormInstanceDate_To) ? "" : context.localUtil.DToC( AV27TFWWPFormInstanceDate_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((0==AV32TFWWPFormVersionNumber_To) ? "" : StringUtil.Str( (decimal)(AV32TFWWPFormVersionNumber_To), 4, 0))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV9GridState.FromXml(AV20Session.Get(AV55Pgmname+"GridState"), null, "", "");
         AV9GridState.gxTpr_Orderedby = AV11OrderedBy;
         AV9GridState.gxTpr_Ordereddsc = AV12OrderedDsc;
         AV9GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV9GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)),  0,  AV13FilterFullText,  AV13FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV9GridState,  "TFWWPFORMINSTANCEID",  context.GetMessage( "WWP_DF_Id", ""),  !((0==AV24TFWWPFormInstanceId)&&(0==AV25TFWWPFormInstanceId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV24TFWWPFormInstanceId), 6, 0)),  ((0==AV24TFWWPFormInstanceId) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV24TFWWPFormInstanceId), "ZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFWWPFormInstanceId_To), 6, 0)),  ((0==AV25TFWWPFormInstanceId_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV25TFWWPFormInstanceId_To), "ZZZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV9GridState,  "TFWWPFORMINSTANCEDATE",  context.GetMessage( "WWP_DF_Date", ""),  !((DateTime.MinValue==AV26TFWWPFormInstanceDate)&&(DateTime.MinValue==AV27TFWWPFormInstanceDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV26TFWWPFormInstanceDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV26TFWWPFormInstanceDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV26TFWWPFormInstanceDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV27TFWWPFormInstanceDate_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  ((DateTime.MinValue==AV27TFWWPFormInstanceDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV27TFWWPFormInstanceDate_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV9GridState,  "TFWWPFORMVERSIONNUMBER",  context.GetMessage( "WWP_DF_FormVersion", ""),  !((0==AV31TFWWPFormVersionNumber)&&(0==AV32TFWWPFormVersionNumber_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFWWPFormVersionNumber), 4, 0)),  ((0==AV31TFWWPFormVersionNumber) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV31TFWWPFormVersionNumber), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFWWPFormVersionNumber_To), 4, 0)),  ((0==AV32TFWWPFormVersionNumber_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV32TFWWPFormVersionNumber_To), "ZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV9GridState,  "TFWWPUSEREXTENDEDFULLNAME",  context.GetMessage( "WWP_DF_UserName", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFWWPUserExtendedFullName)),  0,  AV48TFWWPUserExtendedFullName,  AV48TFWWPUserExtendedFullName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFWWPUserExtendedFullName_Sel)),  AV49TFWWPUserExtendedFullName_Sel,  AV49TFWWPUserExtendedFullName_Sel) ;
         if ( ! (0==AV40WWPFormId) )
         {
            AV10GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV10GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMID";
            AV10GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV40WWPFormId), 4, 0);
            AV9GridState.gxTpr_Filtervalues.Add(AV10GridStateFilterValue, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44WWPFormTitle)) )
         {
            AV10GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV10GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMTITLE";
            AV10GridStateFilterValue.gxTpr_Value = AV44WWPFormTitle;
            AV9GridState.gxTpr_Filtervalues.Add(AV10GridStateFilterValue, 0);
         }
         AV9GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV9GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV55Pgmname+"GridState",  AV9GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV55Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = true;
         AV7TrnContext.gxTpr_Callerurl = AV6HTTPRequest.ScriptName+"?"+AV6HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "WorkWithPlus.DynamicForms.WWP_FormInstance";
         AV8TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "WWPFormId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV40WWPFormId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV20Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      protected void E18202( )
      {
         /* Viewreport_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_report.aspx"+UrlEncode(StringUtil.LTrimStr(A214WWPFormInstanceId,6,0));
         Innewwindow1_Target = formatLink("workwithplus.dynamicforms.wwp_df_report.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV40WWPFormId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV40WWPFormId", StringUtil.LTrimStr( (decimal)(AV40WWPFormId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
         AV44WWPFormTitle = (string)getParm(obj,1);
         AssignAttri("", false, "AV44WWPFormTitle", AV44WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44WWPFormTitle, "")), context));
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
         PA202( ) ;
         WS202( ) ;
         WE202( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024101016435551", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_forminstanceww.js", "?2024101016435553", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_312( )
      {
         edtWWPFormInstanceId_Internalname = "WWPFORMINSTANCEID_"+sGXsfl_31_idx;
         edtWWPFormInstanceDate_Internalname = "WWPFORMINSTANCEDATE_"+sGXsfl_31_idx;
         edtavWwpformversionnumberwithtags_Internalname = "vWWPFORMVERSIONNUMBERWITHTAGS_"+sGXsfl_31_idx;
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER_"+sGXsfl_31_idx;
         edtWWPFormId_Internalname = "WWPFORMID_"+sGXsfl_31_idx;
         edtWWPFormTitle_Internalname = "WWPFORMTITLE_"+sGXsfl_31_idx;
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME_"+sGXsfl_31_idx;
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME_"+sGXsfl_31_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_31_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_31_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_31_idx;
         edtavViewreport_Internalname = "vVIEWREPORT_"+sGXsfl_31_idx;
      }

      protected void SubsflControlProps_fel_312( )
      {
         edtWWPFormInstanceId_Internalname = "WWPFORMINSTANCEID_"+sGXsfl_31_fel_idx;
         edtWWPFormInstanceDate_Internalname = "WWPFORMINSTANCEDATE_"+sGXsfl_31_fel_idx;
         edtavWwpformversionnumberwithtags_Internalname = "vWWPFORMVERSIONNUMBERWITHTAGS_"+sGXsfl_31_fel_idx;
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER_"+sGXsfl_31_fel_idx;
         edtWWPFormId_Internalname = "WWPFORMID_"+sGXsfl_31_fel_idx;
         edtWWPFormTitle_Internalname = "WWPFORMTITLE_"+sGXsfl_31_fel_idx;
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME_"+sGXsfl_31_fel_idx;
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME_"+sGXsfl_31_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_31_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_31_fel_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_31_fel_idx;
         edtavViewreport_Internalname = "vVIEWREPORT_"+sGXsfl_31_fel_idx;
      }

      protected void sendrow_312( )
      {
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         WB200( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_31_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_31_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_31_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A214WWPFormInstanceId), 6, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A214WWPFormInstanceId), "ZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormInstanceDate_Internalname,context.localUtil.Format(A239WWPFormInstanceDate, "99/99/99"),context.localUtil.Format( A239WWPFormInstanceDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormInstanceDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+edtavWwpformversionnumberwithtags_Horizontalalignment+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_31_idx + "',31)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpformversionnumberwithtags_Internalname,(string)AV43WWPFormVersionNumberWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpformversionnumberwithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavWwpformversionnumberwithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)edtavWwpformversionnumberwithtags_Horizontalalignment,(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormVersionNumber_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormVersionNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormTitle_Internalname,(string)A209WWPFormTitle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormTitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormReferenceName_Internalname,(string)A208WWPFormReferenceName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormReferenceName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPUserExtendedFullName_Internalname,(string)A113WWPUserExtendedFullName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPUserExtendedFullName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"WWPBaseObjects\\WWP_Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_31_idx + "',31)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV38Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",context.GetMessage( "GXM_update", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_31_idx + "',31)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV39Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDisplay_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_31_idx + "',31)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV41Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",context.GetMessage( "GXM_display", ""),(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDisplay_Visible,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_31_idx + "',31)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavViewreport_Internalname,StringUtil.RTrim( AV45ViewReport),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"","'"+""+"'"+",false,"+"'"+"EVVIEWREPORT.CLICK."+sGXsfl_31_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavViewreport_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavViewreport_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes202( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_31_idx = ((subGrid_Islastpage==1)&&(nGXsfl_31_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
            sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
            SubsflControlProps_312( ) ;
         }
         /* End function sendrow_312 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl31( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"31\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_Date", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+edtavWwpformversionnumberwithtags_Horizontalalignment+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_FormVersion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_FormVersion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWPForm Title", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWPForm Reference Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_UserName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDisplay_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A214WWPFormInstanceId), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A239WWPFormInstanceDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV43WWPFormVersionNumberWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpformversionnumberwithtags_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtavWwpformversionnumberwithtags_Horizontalalignment));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A209WWPFormTitle));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A208WWPFormReferenceName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A113WWPUserExtendedFullName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV38Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV39Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV41Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV45ViewReport)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavViewreport_Enabled), 5, 0, ".", "")));
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
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtWWPFormInstanceId_Internalname = "WWPFORMINSTANCEID";
         edtWWPFormInstanceDate_Internalname = "WWPFORMINSTANCEDATE";
         edtavWwpformversionnumberwithtags_Internalname = "vWWPFORMVERSIONNUMBERWITHTAGS";
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER";
         edtWWPFormId_Internalname = "WWPFORMID";
         edtWWPFormTitle_Internalname = "WWPFORMTITLE";
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavViewreport_Internalname = "vVIEWREPORT";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_wwpforminstancedateauxdatetext_Internalname = "vDDO_WWPFORMINSTANCEDATEAUXDATETEXT";
         Tfwwpforminstancedate_rangepicker_Internalname = "TFWWPFORMINSTANCEDATE_RANGEPICKER";
         divDdo_wwpforminstancedateauxdates_Internalname = "DDO_WWPFORMINSTANCEDATEAUXDATES";
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
         edtavViewreport_Jsonclick = "";
         edtavViewreport_Enabled = 1;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 1;
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPFormReferenceName_Jsonclick = "";
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormId_Jsonclick = "";
         edtWWPFormVersionNumber_Jsonclick = "";
         edtavWwpformversionnumberwithtags_Jsonclick = "";
         edtavWwpformversionnumberwithtags_Enabled = 1;
         edtavWwpformversionnumberwithtags_Horizontalalignment = "start";
         edtWWPFormInstanceDate_Jsonclick = "";
         edtWWPFormInstanceId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDisplay_Visible = -1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtWWPUserExtendedFullName_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormInstanceDate_Enabled = 0;
         edtWWPFormInstanceId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_wwpforminstancedateauxdatetext_Jsonclick = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "6.0||4.0|";
         Ddo_grid_Datalistproc = "WorkWithPlus.DynamicForms.WWP_FormInstanceWWGetFilterData";
         Ddo_grid_Datalisttype = "|||Dynamic";
         Ddo_grid_Includedatalist = "|||T";
         Ddo_grid_Filterisrange = "T|P|T|";
         Ddo_grid_Filtertype = "Numeric|Date|Numeric|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T|T|T|";
         Ddo_grid_Columnssortvalues = "2|1|3|";
         Ddo_grid_Columnids = "0:WWPFormInstanceId|1:WWPFormInstanceDate|2:WWPFormVersionNumber|7:WWPUserExtendedFullName";
         Ddo_grid_Gridinternalname = "";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
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
         Form.Caption = context.GetMessage( " WWPForm Instance", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV12OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV24TFWWPFormInstanceId","fld":"vTFWWPFORMINSTANCEID","pic":"ZZZZZ9"},{"av":"AV25TFWWPFormInstanceId_To","fld":"vTFWWPFORMINSTANCEID_TO","pic":"ZZZZZ9"},{"av":"AV26TFWWPFormInstanceDate","fld":"vTFWWPFORMINSTANCEDATE"},{"av":"AV27TFWWPFormInstanceDate_To","fld":"vTFWWPFORMINSTANCEDATE_TO"},{"av":"AV31TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV48TFWWPUserExtendedFullName","fld":"vTFWWPUSEREXTENDEDFULLNAME"},{"av":"AV49TFWWPUserExtendedFullName_Sel","fld":"vTFWWPUSEREXTENDEDFULLNAME_SEL"},{"av":"AV44WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV52IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV53IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV35GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV36GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV37GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV52IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV53IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV9GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12202","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV12OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV24TFWWPFormInstanceId","fld":"vTFWWPFORMINSTANCEID","pic":"ZZZZZ9"},{"av":"AV25TFWWPFormInstanceId_To","fld":"vTFWWPFORMINSTANCEID_TO","pic":"ZZZZZ9"},{"av":"AV26TFWWPFormInstanceDate","fld":"vTFWWPFORMINSTANCEDATE"},{"av":"AV27TFWWPFormInstanceDate_To","fld":"vTFWWPFORMINSTANCEDATE_TO"},{"av":"AV31TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV48TFWWPUserExtendedFullName","fld":"vTFWWPUSEREXTENDEDFULLNAME"},{"av":"AV49TFWWPUserExtendedFullName_Sel","fld":"vTFWWPUSEREXTENDEDFULLNAME_SEL"},{"av":"AV44WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV52IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV53IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13202","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV12OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV24TFWWPFormInstanceId","fld":"vTFWWPFORMINSTANCEID","pic":"ZZZZZ9"},{"av":"AV25TFWWPFormInstanceId_To","fld":"vTFWWPFORMINSTANCEID_TO","pic":"ZZZZZ9"},{"av":"AV26TFWWPFormInstanceDate","fld":"vTFWWPFORMINSTANCEDATE"},{"av":"AV27TFWWPFormInstanceDate_To","fld":"vTFWWPFORMINSTANCEDATE_TO"},{"av":"AV31TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV48TFWWPUserExtendedFullName","fld":"vTFWWPUSEREXTENDEDFULLNAME"},{"av":"AV49TFWWPUserExtendedFullName_Sel","fld":"vTFWWPUSEREXTENDEDFULLNAME_SEL"},{"av":"AV44WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV52IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV53IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14202","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV12OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV24TFWWPFormInstanceId","fld":"vTFWWPFORMINSTANCEID","pic":"ZZZZZ9"},{"av":"AV25TFWWPFormInstanceId_To","fld":"vTFWWPFORMINSTANCEID_TO","pic":"ZZZZZ9"},{"av":"AV26TFWWPFormInstanceDate","fld":"vTFWWPFORMINSTANCEDATE"},{"av":"AV27TFWWPFormInstanceDate_To","fld":"vTFWWPFORMINSTANCEDATE_TO"},{"av":"AV31TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV48TFWWPUserExtendedFullName","fld":"vTFWWPUSEREXTENDEDFULLNAME"},{"av":"AV49TFWWPUserExtendedFullName_Sel","fld":"vTFWWPUSEREXTENDEDFULLNAME_SEL"},{"av":"AV44WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV52IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV53IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV11OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV12OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV24TFWWPFormInstanceId","fld":"vTFWWPFORMINSTANCEID","pic":"ZZZZZ9"},{"av":"AV25TFWWPFormInstanceId_To","fld":"vTFWWPFORMINSTANCEID_TO","pic":"ZZZZZ9"},{"av":"AV26TFWWPFormInstanceDate","fld":"vTFWWPFORMINSTANCEDATE"},{"av":"AV27TFWWPFormInstanceDate_To","fld":"vTFWWPFORMINSTANCEDATE_TO"},{"av":"AV31TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV48TFWWPUserExtendedFullName","fld":"vTFWWPUSEREXTENDEDFULLNAME"},{"av":"AV49TFWWPUserExtendedFullName_Sel","fld":"vTFWWPUSEREXTENDEDFULLNAME_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E17202","iparms":[{"av":"AV52IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"A214WWPFormInstanceId","fld":"WWPFORMINSTANCEID","pic":"ZZZZZ9","hsh":true},{"av":"AV53IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"A219WWPFormLatestVersionNumber","fld":"WWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV38Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV39Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"AV41Display","fld":"vDISPLAY"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV45ViewReport","fld":"vVIEWREPORT"},{"av":"edtavWwpformversionnumberwithtags_Horizontalalignment","ctrl":"vWWPFORMVERSIONNUMBERWITHTAGS","prop":"Horizontalalignment"},{"av":"AV43WWPFormVersionNumberWithTags","fld":"vWWPFORMVERSIONNUMBERWITHTAGS"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11202","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV12OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV24TFWWPFormInstanceId","fld":"vTFWWPFORMINSTANCEID","pic":"ZZZZZ9"},{"av":"AV25TFWWPFormInstanceId_To","fld":"vTFWWPFORMINSTANCEID_TO","pic":"ZZZZZ9"},{"av":"AV26TFWWPFormInstanceDate","fld":"vTFWWPFORMINSTANCEDATE"},{"av":"AV27TFWWPFormInstanceDate_To","fld":"vTFWWPFORMINSTANCEDATE_TO"},{"av":"AV31TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV48TFWWPUserExtendedFullName","fld":"vTFWWPUSEREXTENDEDFULLNAME"},{"av":"AV49TFWWPUserExtendedFullName_Sel","fld":"vTFWWPUSEREXTENDEDFULLNAME_SEL"},{"av":"AV44WWPFormTitle","fld":"vWWPFORMTITLE","hsh":true},{"av":"AV52IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV53IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV9GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV23ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV9GridState","fld":"vGRIDSTATE"},{"av":"AV11OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV12OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV24TFWWPFormInstanceId","fld":"vTFWWPFORMINSTANCEID","pic":"ZZZZZ9"},{"av":"AV25TFWWPFormInstanceId_To","fld":"vTFWWPFORMINSTANCEID_TO","pic":"ZZZZZ9"},{"av":"AV26TFWWPFormInstanceDate","fld":"vTFWWPFORMINSTANCEDATE"},{"av":"AV27TFWWPFormInstanceDate_To","fld":"vTFWWPFORMINSTANCEDATE_TO"},{"av":"AV31TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV48TFWWPUserExtendedFullName","fld":"vTFWWPUSEREXTENDEDFULLNAME"},{"av":"AV49TFWWPUserExtendedFullName_Sel","fld":"vTFWWPUSEREXTENDEDFULLNAME_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV35GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV36GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV37GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV52IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV53IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV21ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VVIEWREPORT.CLICK","""{"handler":"E18202","iparms":[{"av":"A214WWPFormInstanceId","fld":"WWPFORMINSTANCEID","pic":"ZZZZZ9","hsh":true}]""");
         setEventMetadata("VVIEWREPORT.CLICK",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"}]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Viewreport","iparms":[]}""");
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
         wcpOAV44WWPFormTitle = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV13FilterFullText = "";
         AV55Pgmname = "";
         AV26TFWWPFormInstanceDate = DateTime.MinValue;
         AV27TFWWPFormInstanceDate_To = DateTime.MinValue;
         AV48TFWWPUserExtendedFullName = "";
         AV49TFWWPUserExtendedFullName_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV21ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV37GridAppliedFilters = "";
         AV33DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV28DDO_WWPFormInstanceDateAuxDate = DateTime.MinValue;
         AV29DDO_WWPFormInstanceDateAuxDateTo = DateTime.MinValue;
         AV9GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV30DDO_WWPFormInstanceDateAuxDateText = "";
         ucTfwwpforminstancedate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A239WWPFormInstanceDate = DateTime.MinValue;
         AV43WWPFormVersionNumberWithTags = "";
         A209WWPFormTitle = "";
         A208WWPFormReferenceName = "";
         A113WWPUserExtendedFullName = "";
         AV38Update = "";
         AV39Delete = "";
         AV41Display = "";
         AV45ViewReport = "";
         GXDecQS = "";
         lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = "";
         lV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = "";
         AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext = "";
         AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate = DateTime.MinValue;
         AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to = DateTime.MinValue;
         AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel = "";
         AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname = "";
         H00202_A112WWPUserExtendedId = new string[] {""} ;
         H00202_A113WWPUserExtendedFullName = new string[] {""} ;
         H00202_A208WWPFormReferenceName = new string[] {""} ;
         H00202_A209WWPFormTitle = new string[] {""} ;
         H00202_A207WWPFormVersionNumber = new short[1] ;
         H00202_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         H00202_A214WWPFormInstanceId = new int[1] ;
         H00202_A206WWPFormId = new short[1] ;
         A112WWPUserExtendedId = "";
         H00203_AGRID_nRecordCount = new long[1] ;
         AV6HTTPRequest = new GxHttpRequest( context);
         AV50GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV51GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV5WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV22ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV20Session = context.GetSession();
         AV10GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         AV7TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_forminstanceww__default(),
            new Object[][] {
                new Object[] {
               H00202_A112WWPUserExtendedId, H00202_A113WWPUserExtendedFullName, H00202_A208WWPFormReferenceName, H00202_A209WWPFormTitle, H00202_A207WWPFormVersionNumber, H00202_A239WWPFormInstanceDate, H00202_A214WWPFormInstanceId, H00202_A206WWPFormId
               }
               , new Object[] {
               H00203_AGRID_nRecordCount
               }
            }
         );
         AV55Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstanceWW";
         /* GeneXus formulas. */
         AV55Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstanceWW";
         edtavWwpformversionnumberwithtags_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtavDisplay_Enabled = 0;
         edtavViewreport_Enabled = 0;
      }

      private short AV40WWPFormId ;
      private short wcpOAV40WWPFormId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private short AV23ManageFiltersExecutionStep ;
      private short AV31TFWWPFormVersionNumber ;
      private short AV32TFWWPFormVersionNumber_To ;
      private short gxajaxcallmode ;
      private short A219WWPFormLatestVersionNumber ;
      private short wbEnd ;
      private short wbStart ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber ;
      private short AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to ;
      private short AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid ;
      private short GXt_int1 ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_31 ;
      private int nGXsfl_31_idx=1 ;
      private int AV24TFWWPFormInstanceId ;
      private int AV25TFWWPFormInstanceId_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A214WWPFormInstanceId ;
      private int subGrid_Islastpage ;
      private int edtavWwpformversionnumberwithtags_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int edtavDisplay_Enabled ;
      private int edtavViewreport_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid ;
      private int AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to ;
      private int edtWWPFormInstanceId_Enabled ;
      private int edtWWPFormInstanceDate_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int AV34PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int edtavDisplay_Visible ;
      private int AV66GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV35GridCurrentPage ;
      private long AV36GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_31_idx="0001" ;
      private string AV55Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string TempTags ;
      private string edtavFilterfulltext_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string Innewwindow1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_wwpforminstancedateauxdates_Internalname ;
      private string edtavDdo_wwpforminstancedateauxdatetext_Internalname ;
      private string edtavDdo_wwpforminstancedateauxdatetext_Jsonclick ;
      private string Tfwwpforminstancedate_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtWWPFormInstanceId_Internalname ;
      private string edtWWPFormInstanceDate_Internalname ;
      private string edtavWwpformversionnumberwithtags_Internalname ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormId_Internalname ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormReferenceName_Internalname ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string AV38Update ;
      private string edtavUpdate_Internalname ;
      private string AV39Delete ;
      private string edtavDelete_Internalname ;
      private string AV41Display ;
      private string edtavDisplay_Internalname ;
      private string AV45ViewReport ;
      private string edtavViewreport_Internalname ;
      private string GXDecQS ;
      private string A112WWPUserExtendedId ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtavDisplay_Link ;
      private string edtavWwpformversionnumberwithtags_Horizontalalignment ;
      private string GXt_char3 ;
      private string sGXsfl_31_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtWWPFormInstanceId_Jsonclick ;
      private string edtWWPFormInstanceDate_Jsonclick ;
      private string edtavWwpformversionnumberwithtags_Jsonclick ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormTitle_Jsonclick ;
      private string edtWWPFormReferenceName_Jsonclick ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtavDisplay_Jsonclick ;
      private string edtavViewreport_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV26TFWWPFormInstanceDate ;
      private DateTime AV27TFWWPFormInstanceDate_To ;
      private DateTime AV28DDO_WWPFormInstanceDateAuxDate ;
      private DateTime AV29DDO_WWPFormInstanceDateAuxDateTo ;
      private DateTime A239WWPFormInstanceDate ;
      private DateTime AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate ;
      private DateTime AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12OrderedDsc ;
      private bool AV52IsAuthorized_Update ;
      private bool AV53IsAuthorized_Delete ;
      private bool AV54IsAuthorized_Display ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_31_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean4 ;
      private string AV22ManageFiltersXml ;
      private string AV44WWPFormTitle ;
      private string wcpOAV44WWPFormTitle ;
      private string AV13FilterFullText ;
      private string AV48TFWWPUserExtendedFullName ;
      private string AV49TFWWPUserExtendedFullName_Sel ;
      private string AV37GridAppliedFilters ;
      private string AV30DDO_WWPFormInstanceDateAuxDateText ;
      private string AV43WWPFormVersionNumberWithTags ;
      private string A209WWPFormTitle ;
      private string A208WWPFormReferenceName ;
      private string A113WWPUserExtendedFullName ;
      private string lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext ;
      private string lV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname ;
      private string AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext ;
      private string AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel ;
      private string AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname ;
      private IGxSession AV20Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfwwpforminstancedate_rangepicker ;
      private GxHttpRequest AV6HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV21ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV33DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV9GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H00202_A112WWPUserExtendedId ;
      private string[] H00202_A113WWPUserExtendedFullName ;
      private string[] H00202_A208WWPFormReferenceName ;
      private string[] H00202_A209WWPFormTitle ;
      private short[] H00202_A207WWPFormVersionNumber ;
      private DateTime[] H00202_A239WWPFormInstanceDate ;
      private int[] H00202_A214WWPFormInstanceId ;
      private short[] H00202_A206WWPFormId ;
      private long[] H00203_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV50GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV51GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV5WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV10GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV7TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV8TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_forminstanceww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00202( IGxContext context ,
                                             string AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext ,
                                             int AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid ,
                                             int AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to ,
                                             DateTime AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate ,
                                             DateTime AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to ,
                                             short AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber ,
                                             short AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to ,
                                             string AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel ,
                                             string AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname ,
                                             int A214WWPFormInstanceId ,
                                             short A207WWPFormVersionNumber ,
                                             string A113WWPUserExtendedFullName ,
                                             DateTime A239WWPFormInstanceDate ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             short A206WWPFormId ,
                                             short AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[15];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.WWPUserExtendedId, T2.WWPUserExtendedFullName, T3.WWPFormReferenceName, T3.WWPFormTitle, T1.WWPFormVersionNumber, T1.WWPFormInstanceDate, T1.WWPFormInstanceId, T1.WWPFormId";
         sFromString = " FROM ((WWP_FormInstance T1 INNER JOIN WWP_UserExtended T2 ON T2.WWPUserExtendedId = T1.WWPUserExtendedId) INNER JOIN WWP_Form T3 ON T3.WWPFormId = T1.WWPFormId AND T3.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.WWPFormId = :AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.WWPFormInstanceId,'999999'), 2) like '%' || :lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull) or ( SUBSTR(TO_CHAR(T1.WWPFormVersionNumber,'9999'), 2) like '%' || :lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull) or ( T2.WWPUserExtendedFullName like '%' || :lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull))");
         }
         else
         {
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceId >= :AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpformi)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (0==AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceId <= :AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpformi)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceDate >= :AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpformi)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceDate <= :AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpformi)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! (0==AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformv)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! (0==AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformv)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname)) ) )
         {
            AddWhere(sWhereString, "(T2.WWPUserExtendedFullName like :lV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpusere)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel)) && ! ( StringUtil.StrCmp(AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WWPUserExtendedFullName = ( :AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuser))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPUserExtendedFullName))=0))");
         }
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WWPFormId, T1.WWPFormInstanceDate, T1.WWPFormInstanceId";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WWPFormId DESC, T1.WWPFormInstanceDate DESC, T1.WWPFormInstanceId";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WWPFormId, T1.WWPFormInstanceId";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WWPFormId DESC, T1.WWPFormInstanceId DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormInstanceId";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WWPFormId DESC, T1.WWPFormVersionNumber DESC, T1.WWPFormInstanceId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.WWPFormInstanceId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00203( IGxContext context ,
                                             string AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext ,
                                             int AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid ,
                                             int AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to ,
                                             DateTime AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate ,
                                             DateTime AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to ,
                                             short AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber ,
                                             short AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to ,
                                             string AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel ,
                                             string AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname ,
                                             int A214WWPFormInstanceId ,
                                             short A207WWPFormVersionNumber ,
                                             string A113WWPUserExtendedFullName ,
                                             DateTime A239WWPFormInstanceDate ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             short A206WWPFormId ,
                                             short AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[12];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((WWP_FormInstance T1 INNER JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = T1.WWPUserExtendedId) INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T1.WWPFormId = :AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.WWPFormInstanceId,'999999'), 2) like '%' || :lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull) or ( SUBSTR(TO_CHAR(T1.WWPFormVersionNumber,'9999'), 2) like '%' || :lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull) or ( T3.WWPUserExtendedFullName like '%' || :lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull))");
         }
         else
         {
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpforminstanceid) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceId >= :AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpformi)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (0==AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpforminstanceid_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceId <= :AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpformi)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpforminstancedate) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceDate >= :AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpformi)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpforminstancedate_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormInstanceDate <= :AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpformi)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! (0==AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformversionnumber) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformv)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! (0==AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformversionnumber_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformv)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpuserextendedfullname)) ) )
         {
            AddWhere(sWhereString, "(T3.WWPUserExtendedFullName like :lV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpusere)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel)) && ! ( StringUtil.StrCmp(AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.WWPUserExtendedFullName = ( :AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuser))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuserextendedfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.WWPUserExtendedFullName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00202(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
               case 1 :
                     return conditional_H00203(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] );
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
          Object[] prmH00202;
          prmH00202 = new Object[] {
          new ParDef("AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid",GXType.Int16,4,0) ,
          new ParDef("lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull",GXType.VarChar,100,0) ,
          new ParDef("lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull",GXType.VarChar,100,0) ,
          new ParDef("lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull",GXType.VarChar,100,0) ,
          new ParDef("AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpformi",GXType.Int32,6,0) ,
          new ParDef("AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpformi",GXType.Int32,6,0) ,
          new ParDef("AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpformi",GXType.Date,8,0) ,
          new ParDef("AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpformi",GXType.Date,8,0) ,
          new ParDef("AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformv",GXType.Int16,4,0) ,
          new ParDef("AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformv",GXType.Int16,4,0) ,
          new ParDef("lV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpusere",GXType.VarChar,100,0) ,
          new ParDef("AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuser",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00203;
          prmH00203 = new Object[] {
          new ParDef("AV56Workwithplus_dynamicforms_wwp_forminstancewwds_1_wwpformid",GXType.Int16,4,0) ,
          new ParDef("lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull",GXType.VarChar,100,0) ,
          new ParDef("lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull",GXType.VarChar,100,0) ,
          new ParDef("lV57Workwithplus_dynamicforms_wwp_forminstancewwds_2_filterfull",GXType.VarChar,100,0) ,
          new ParDef("AV58Workwithplus_dynamicforms_wwp_forminstancewwds_3_tfwwpformi",GXType.Int32,6,0) ,
          new ParDef("AV59Workwithplus_dynamicforms_wwp_forminstancewwds_4_tfwwpformi",GXType.Int32,6,0) ,
          new ParDef("AV60Workwithplus_dynamicforms_wwp_forminstancewwds_5_tfwwpformi",GXType.Date,8,0) ,
          new ParDef("AV61Workwithplus_dynamicforms_wwp_forminstancewwds_6_tfwwpformi",GXType.Date,8,0) ,
          new ParDef("AV62Workwithplus_dynamicforms_wwp_forminstancewwds_7_tfwwpformv",GXType.Int16,4,0) ,
          new ParDef("AV63Workwithplus_dynamicforms_wwp_forminstancewwds_8_tfwwpformv",GXType.Int16,4,0) ,
          new ParDef("lV64Workwithplus_dynamicforms_wwp_forminstancewwds_9_tfwwpusere",GXType.VarChar,100,0) ,
          new ParDef("AV65Workwithplus_dynamicforms_wwp_forminstancewwds_10_tfwwpuser",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00202", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00202,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00203", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00203,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
