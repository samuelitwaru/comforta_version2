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
   public class trn_receptionistww : GXDataArea
   {
      public trn_receptionistww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_receptionistww( IGxContext context )
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
         chkReceptionistIsActive = new GXCheckbox();
         cmbavActiongroup = new GXCombobox();
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
         nRC_GXsfl_39 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_39"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_39_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_39_idx = GetPar( "sGXsfl_39_idx");
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
         ajax_req_read_hidden_sdt(GetNextPar( ), AV58ColumnsSelector);
         AV60Pgmname = GetPar( "Pgmname");
         AV20TFReceptionistGivenName = GetPar( "TFReceptionistGivenName");
         AV21TFReceptionistGivenName_Sel = GetPar( "TFReceptionistGivenName_Sel");
         AV22TFReceptionistLastName = GetPar( "TFReceptionistLastName");
         AV23TFReceptionistLastName_Sel = GetPar( "TFReceptionistLastName_Sel");
         AV26TFReceptionistEmail = GetPar( "TFReceptionistEmail");
         AV27TFReceptionistEmail_Sel = GetPar( "TFReceptionistEmail_Sel");
         AV28TFReceptionistPhone = GetPar( "TFReceptionistPhone");
         AV29TFReceptionistPhone_Sel = GetPar( "TFReceptionistPhone_Sel");
         AV52TFReceptionistIsActive_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFReceptionistIsActive_Sel"), "."), 18, MidpointRounding.ToEven));
         AV41IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV43IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV45IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV39IsAuthorized_ReceptionistGivenName = StringUtil.StrToBool( GetPar( "IsAuthorized_ReceptionistGivenName"));
         AV46IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV60Pgmname, AV20TFReceptionistGivenName, AV21TFReceptionistGivenName_Sel, AV22TFReceptionistLastName, AV23TFReceptionistLastName_Sel, AV26TFReceptionistEmail, AV27TFReceptionistEmail_Sel, AV28TFReceptionistPhone, AV29TFReceptionistPhone_Sel, AV52TFReceptionistIsActive_Sel, AV41IsAuthorized_Display, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV39IsAuthorized_ReceptionistGivenName, AV46IsAuthorized_Insert) ;
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
            return "trn_receptionistww_Execute" ;
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
         PA4R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4R2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_receptionistww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV41IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV41IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV45IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV45IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RECEPTIONISTGIVENNAME", AV39IsAuthorized_ReceptionistGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RECEPTIONISTGIVENNAME", GetSecureSignedToken( "", AV39IsAuthorized_ReceptionistGivenName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV46IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV46IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV38GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV32DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV32DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV58ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV58ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFRECEPTIONISTGIVENNAME", AV20TFReceptionistGivenName);
         GxWebStd.gx_hidden_field( context, "vTFRECEPTIONISTGIVENNAME_SEL", AV21TFReceptionistGivenName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRECEPTIONISTLASTNAME", AV22TFReceptionistLastName);
         GxWebStd.gx_hidden_field( context, "vTFRECEPTIONISTLASTNAME_SEL", AV23TFReceptionistLastName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRECEPTIONISTEMAIL", AV26TFReceptionistEmail);
         GxWebStd.gx_hidden_field( context, "vTFRECEPTIONISTEMAIL_SEL", AV27TFReceptionistEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRECEPTIONISTPHONE", StringUtil.RTrim( AV28TFReceptionistPhone));
         GxWebStd.gx_hidden_field( context, "vTFRECEPTIONISTPHONE_SEL", StringUtil.RTrim( AV29TFReceptionistPhone_Sel));
         GxWebStd.gx_hidden_field( context, "vTFRECEPTIONISTISACTIVE_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52TFReceptionistIsActive_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV41IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV41IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV45IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV45IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RECEPTIONISTGIVENNAME", AV39IsAuthorized_ReceptionistGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RECEPTIONISTGIVENNAME", GetSecureSignedToken( "", AV39IsAuthorized_ReceptionistGivenName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV46IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV46IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
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
            WE4R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4R2( ) ;
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
         return formatLink("trn_receptionistww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_ReceptionistWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Receptionist" ;
      }

      protected void WB4R0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ReceptionistWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ReceptionistWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Subscriptions", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ReceptionistWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_Trn_ReceptionistWW.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders GridHover HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl39( ) ;
         }
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            nRC_GXsfl_39 = (int)(nGXsfl_39_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV36GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV37GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV38GridAppliedFilters);
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
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV32DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV32DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV58ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
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
               if ( bGXsfl_39_Refreshing )
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
         if ( wbEnd == 39 )
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

      protected void START4R2( )
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
         Form.Meta.addItem("description", " Receptionist", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4R0( ) ;
      }

      protected void WS4R2( )
      {
         START4R2( ) ;
         EVT4R2( ) ;
      }

      protected void EVT4R2( )
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
                              E114R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E124R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E134R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E144R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E154R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E164R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E174R2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) )
                           {
                              nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
                              SubsflControlProps_392( ) ;
                              A89ReceptionistId = StringUtil.StrToGuid( cgiGet( edtReceptionistId_Internalname));
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                              A90ReceptionistGivenName = cgiGet( edtReceptionistGivenName_Internalname);
                              A91ReceptionistLastName = cgiGet( edtReceptionistLastName_Internalname);
                              A92ReceptionistInitials = cgiGet( edtReceptionistInitials_Internalname);
                              A93ReceptionistEmail = cgiGet( edtReceptionistEmail_Internalname);
                              A373ReceptionistPhoneCode = cgiGet( edtReceptionistPhoneCode_Internalname);
                              A94ReceptionistPhone = cgiGet( edtReceptionistPhone_Internalname);
                              A374ReceptionistPhoneNumber = cgiGet( edtReceptionistPhoneNumber_Internalname);
                              A95ReceptionistGAMGUID = cgiGet( edtReceptionistGAMGUID_Internalname);
                              A398ReceptionistIsActive = StringUtil.StrToBool( cgiGet( chkReceptionistIsActive_Internalname));
                              cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                              cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                              AV54ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV54ActionGroup), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E184R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E194R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E204R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E214R2 ();
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

      protected void WE4R2( )
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

      protected void PA4R2( )
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
         SubsflControlProps_392( ) ;
         while ( nGXsfl_39_idx <= nRC_GXsfl_39 )
         {
            sendrow_392( ) ;
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       short AV19ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV58ColumnsSelector ,
                                       string AV60Pgmname ,
                                       string AV20TFReceptionistGivenName ,
                                       string AV21TFReceptionistGivenName_Sel ,
                                       string AV22TFReceptionistLastName ,
                                       string AV23TFReceptionistLastName_Sel ,
                                       string AV26TFReceptionistEmail ,
                                       string AV27TFReceptionistEmail_Sel ,
                                       string AV28TFReceptionistPhone ,
                                       string AV29TFReceptionistPhone_Sel ,
                                       short AV52TFReceptionistIsActive_Sel ,
                                       bool AV41IsAuthorized_Display ,
                                       bool AV43IsAuthorized_Update ,
                                       bool AV45IsAuthorized_Delete ,
                                       bool AV39IsAuthorized_ReceptionistGivenName ,
                                       bool AV46IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RECEPTIONISTID", GetSecureSignedToken( "", A89ReceptionistId, context));
         GxWebStd.gx_hidden_field( context, "RECEPTIONISTID", A89ReceptionistId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID", GetSecureSignedToken( "", A29LocationId, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
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
         RF4R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV60Pgmname = "Trn_ReceptionistWW";
      }

      protected void RF4R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E194R2 ();
         nGXsfl_39_idx = 1;
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         bGXsfl_39_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
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
            SubsflControlProps_392( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV61Trn_receptionistwwds_1_filterfulltext ,
                                                 AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                                 AV62Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                                 AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                                 AV64Trn_receptionistwwds_4_tfreceptionistlastname ,
                                                 AV67Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                                 AV66Trn_receptionistwwds_6_tfreceptionistemail ,
                                                 AV69Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                                 AV68Trn_receptionistwwds_8_tfreceptionistphone ,
                                                 AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                                 A90ReceptionistGivenName ,
                                                 A91ReceptionistLastName ,
                                                 A93ReceptionistEmail ,
                                                 A94ReceptionistPhone ,
                                                 A398ReceptionistIsActive ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV61Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_1_filterfulltext), "%", "");
            lV61Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_1_filterfulltext), "%", "");
            lV61Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_1_filterfulltext), "%", "");
            lV61Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_1_filterfulltext), "%", "");
            lV62Trn_receptionistwwds_2_tfreceptionistgivenname = StringUtil.Concat( StringUtil.RTrim( AV62Trn_receptionistwwds_2_tfreceptionistgivenname), "%", "");
            lV64Trn_receptionistwwds_4_tfreceptionistlastname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_receptionistwwds_4_tfreceptionistlastname), "%", "");
            lV66Trn_receptionistwwds_6_tfreceptionistemail = StringUtil.Concat( StringUtil.RTrim( AV66Trn_receptionistwwds_6_tfreceptionistemail), "%", "");
            lV68Trn_receptionistwwds_8_tfreceptionistphone = StringUtil.PadR( StringUtil.RTrim( AV68Trn_receptionistwwds_8_tfreceptionistphone), 20, "%");
            /* Using cursor H004R2 */
            pr_default.execute(0, new Object[] {lV61Trn_receptionistwwds_1_filterfulltext, lV61Trn_receptionistwwds_1_filterfulltext, lV61Trn_receptionistwwds_1_filterfulltext, lV61Trn_receptionistwwds_1_filterfulltext, lV62Trn_receptionistwwds_2_tfreceptionistgivenname, AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel, lV64Trn_receptionistwwds_4_tfreceptionistlastname, AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel, lV66Trn_receptionistwwds_6_tfreceptionistemail, AV67Trn_receptionistwwds_7_tfreceptionistemail_sel, lV68Trn_receptionistwwds_8_tfreceptionistphone, AV69Trn_receptionistwwds_9_tfreceptionistphone_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A398ReceptionistIsActive = H004R2_A398ReceptionistIsActive[0];
               A95ReceptionistGAMGUID = H004R2_A95ReceptionistGAMGUID[0];
               A374ReceptionistPhoneNumber = H004R2_A374ReceptionistPhoneNumber[0];
               A94ReceptionistPhone = H004R2_A94ReceptionistPhone[0];
               A373ReceptionistPhoneCode = H004R2_A373ReceptionistPhoneCode[0];
               A93ReceptionistEmail = H004R2_A93ReceptionistEmail[0];
               A92ReceptionistInitials = H004R2_A92ReceptionistInitials[0];
               A91ReceptionistLastName = H004R2_A91ReceptionistLastName[0];
               A90ReceptionistGivenName = H004R2_A90ReceptionistGivenName[0];
               A29LocationId = H004R2_A29LocationId[0];
               A11OrganisationId = H004R2_A11OrganisationId[0];
               A89ReceptionistId = H004R2_A89ReceptionistId[0];
               /* Execute user event: Grid.Load */
               E204R2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 39;
            WB4R0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4R2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV41IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV41IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV45IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV45IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RECEPTIONISTGIVENNAME", AV39IsAuthorized_ReceptionistGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RECEPTIONISTGIVENNAME", GetSecureSignedToken( "", AV39IsAuthorized_ReceptionistGivenName, context));
         GxWebStd.gx_hidden_field( context, "gxhash_RECEPTIONISTID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, A89ReceptionistId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, A29LocationId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV46IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV46IsAuthorized_Insert, context));
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
         AV61Trn_receptionistwwds_1_filterfulltext = AV15FilterFullText;
         AV62Trn_receptionistwwds_2_tfreceptionistgivenname = AV20TFReceptionistGivenName;
         AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV21TFReceptionistGivenName_Sel;
         AV64Trn_receptionistwwds_4_tfreceptionistlastname = AV22TFReceptionistLastName;
         AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV23TFReceptionistLastName_Sel;
         AV66Trn_receptionistwwds_6_tfreceptionistemail = AV26TFReceptionistEmail;
         AV67Trn_receptionistwwds_7_tfreceptionistemail_sel = AV27TFReceptionistEmail_Sel;
         AV68Trn_receptionistwwds_8_tfreceptionistphone = AV28TFReceptionistPhone;
         AV69Trn_receptionistwwds_9_tfreceptionistphone_sel = AV29TFReceptionistPhone_Sel;
         AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV52TFReceptionistIsActive_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV61Trn_receptionistwwds_1_filterfulltext ,
                                              AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                              AV62Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                              AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                              AV64Trn_receptionistwwds_4_tfreceptionistlastname ,
                                              AV67Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                              AV66Trn_receptionistwwds_6_tfreceptionistemail ,
                                              AV69Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                              AV68Trn_receptionistwwds_8_tfreceptionistphone ,
                                              AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                              A90ReceptionistGivenName ,
                                              A91ReceptionistLastName ,
                                              A93ReceptionistEmail ,
                                              A94ReceptionistPhone ,
                                              A398ReceptionistIsActive ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV61Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV61Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV61Trn_receptionistwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Trn_receptionistwwds_1_filterfulltext), "%", "");
         lV62Trn_receptionistwwds_2_tfreceptionistgivenname = StringUtil.Concat( StringUtil.RTrim( AV62Trn_receptionistwwds_2_tfreceptionistgivenname), "%", "");
         lV64Trn_receptionistwwds_4_tfreceptionistlastname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_receptionistwwds_4_tfreceptionistlastname), "%", "");
         lV66Trn_receptionistwwds_6_tfreceptionistemail = StringUtil.Concat( StringUtil.RTrim( AV66Trn_receptionistwwds_6_tfreceptionistemail), "%", "");
         lV68Trn_receptionistwwds_8_tfreceptionistphone = StringUtil.PadR( StringUtil.RTrim( AV68Trn_receptionistwwds_8_tfreceptionistphone), 20, "%");
         /* Using cursor H004R3 */
         pr_default.execute(1, new Object[] {lV61Trn_receptionistwwds_1_filterfulltext, lV61Trn_receptionistwwds_1_filterfulltext, lV61Trn_receptionistwwds_1_filterfulltext, lV61Trn_receptionistwwds_1_filterfulltext, lV62Trn_receptionistwwds_2_tfreceptionistgivenname, AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel, lV64Trn_receptionistwwds_4_tfreceptionistlastname, AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel, lV66Trn_receptionistwwds_6_tfreceptionistemail, AV67Trn_receptionistwwds_7_tfreceptionistemail_sel, lV68Trn_receptionistwwds_8_tfreceptionistphone, AV69Trn_receptionistwwds_9_tfreceptionistphone_sel});
         GRID_nRecordCount = H004R3_AGRID_nRecordCount[0];
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
         AV61Trn_receptionistwwds_1_filterfulltext = AV15FilterFullText;
         AV62Trn_receptionistwwds_2_tfreceptionistgivenname = AV20TFReceptionistGivenName;
         AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV21TFReceptionistGivenName_Sel;
         AV64Trn_receptionistwwds_4_tfreceptionistlastname = AV22TFReceptionistLastName;
         AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV23TFReceptionistLastName_Sel;
         AV66Trn_receptionistwwds_6_tfreceptionistemail = AV26TFReceptionistEmail;
         AV67Trn_receptionistwwds_7_tfreceptionistemail_sel = AV27TFReceptionistEmail_Sel;
         AV68Trn_receptionistwwds_8_tfreceptionistphone = AV28TFReceptionistPhone;
         AV69Trn_receptionistwwds_9_tfreceptionistphone_sel = AV29TFReceptionistPhone_Sel;
         AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV52TFReceptionistIsActive_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV60Pgmname, AV20TFReceptionistGivenName, AV21TFReceptionistGivenName_Sel, AV22TFReceptionistLastName, AV23TFReceptionistLastName_Sel, AV26TFReceptionistEmail, AV27TFReceptionistEmail_Sel, AV28TFReceptionistPhone, AV29TFReceptionistPhone_Sel, AV52TFReceptionistIsActive_Sel, AV41IsAuthorized_Display, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV39IsAuthorized_ReceptionistGivenName, AV46IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV61Trn_receptionistwwds_1_filterfulltext = AV15FilterFullText;
         AV62Trn_receptionistwwds_2_tfreceptionistgivenname = AV20TFReceptionistGivenName;
         AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV21TFReceptionistGivenName_Sel;
         AV64Trn_receptionistwwds_4_tfreceptionistlastname = AV22TFReceptionistLastName;
         AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV23TFReceptionistLastName_Sel;
         AV66Trn_receptionistwwds_6_tfreceptionistemail = AV26TFReceptionistEmail;
         AV67Trn_receptionistwwds_7_tfreceptionistemail_sel = AV27TFReceptionistEmail_Sel;
         AV68Trn_receptionistwwds_8_tfreceptionistphone = AV28TFReceptionistPhone;
         AV69Trn_receptionistwwds_9_tfreceptionistphone_sel = AV29TFReceptionistPhone_Sel;
         AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV52TFReceptionistIsActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV60Pgmname, AV20TFReceptionistGivenName, AV21TFReceptionistGivenName_Sel, AV22TFReceptionistLastName, AV23TFReceptionistLastName_Sel, AV26TFReceptionistEmail, AV27TFReceptionistEmail_Sel, AV28TFReceptionistPhone, AV29TFReceptionistPhone_Sel, AV52TFReceptionistIsActive_Sel, AV41IsAuthorized_Display, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV39IsAuthorized_ReceptionistGivenName, AV46IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV61Trn_receptionistwwds_1_filterfulltext = AV15FilterFullText;
         AV62Trn_receptionistwwds_2_tfreceptionistgivenname = AV20TFReceptionistGivenName;
         AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV21TFReceptionistGivenName_Sel;
         AV64Trn_receptionistwwds_4_tfreceptionistlastname = AV22TFReceptionistLastName;
         AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV23TFReceptionistLastName_Sel;
         AV66Trn_receptionistwwds_6_tfreceptionistemail = AV26TFReceptionistEmail;
         AV67Trn_receptionistwwds_7_tfreceptionistemail_sel = AV27TFReceptionistEmail_Sel;
         AV68Trn_receptionistwwds_8_tfreceptionistphone = AV28TFReceptionistPhone;
         AV69Trn_receptionistwwds_9_tfreceptionistphone_sel = AV29TFReceptionistPhone_Sel;
         AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV52TFReceptionistIsActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV60Pgmname, AV20TFReceptionistGivenName, AV21TFReceptionistGivenName_Sel, AV22TFReceptionistLastName, AV23TFReceptionistLastName_Sel, AV26TFReceptionistEmail, AV27TFReceptionistEmail_Sel, AV28TFReceptionistPhone, AV29TFReceptionistPhone_Sel, AV52TFReceptionistIsActive_Sel, AV41IsAuthorized_Display, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV39IsAuthorized_ReceptionistGivenName, AV46IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV61Trn_receptionistwwds_1_filterfulltext = AV15FilterFullText;
         AV62Trn_receptionistwwds_2_tfreceptionistgivenname = AV20TFReceptionistGivenName;
         AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV21TFReceptionistGivenName_Sel;
         AV64Trn_receptionistwwds_4_tfreceptionistlastname = AV22TFReceptionistLastName;
         AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV23TFReceptionistLastName_Sel;
         AV66Trn_receptionistwwds_6_tfreceptionistemail = AV26TFReceptionistEmail;
         AV67Trn_receptionistwwds_7_tfreceptionistemail_sel = AV27TFReceptionistEmail_Sel;
         AV68Trn_receptionistwwds_8_tfreceptionistphone = AV28TFReceptionistPhone;
         AV69Trn_receptionistwwds_9_tfreceptionistphone_sel = AV29TFReceptionistPhone_Sel;
         AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV52TFReceptionistIsActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV60Pgmname, AV20TFReceptionistGivenName, AV21TFReceptionistGivenName_Sel, AV22TFReceptionistLastName, AV23TFReceptionistLastName_Sel, AV26TFReceptionistEmail, AV27TFReceptionistEmail_Sel, AV28TFReceptionistPhone, AV29TFReceptionistPhone_Sel, AV52TFReceptionistIsActive_Sel, AV41IsAuthorized_Display, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV39IsAuthorized_ReceptionistGivenName, AV46IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV61Trn_receptionistwwds_1_filterfulltext = AV15FilterFullText;
         AV62Trn_receptionistwwds_2_tfreceptionistgivenname = AV20TFReceptionistGivenName;
         AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV21TFReceptionistGivenName_Sel;
         AV64Trn_receptionistwwds_4_tfreceptionistlastname = AV22TFReceptionistLastName;
         AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV23TFReceptionistLastName_Sel;
         AV66Trn_receptionistwwds_6_tfreceptionistemail = AV26TFReceptionistEmail;
         AV67Trn_receptionistwwds_7_tfreceptionistemail_sel = AV27TFReceptionistEmail_Sel;
         AV68Trn_receptionistwwds_8_tfreceptionistphone = AV28TFReceptionistPhone;
         AV69Trn_receptionistwwds_9_tfreceptionistphone_sel = AV29TFReceptionistPhone_Sel;
         AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV52TFReceptionistIsActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV60Pgmname, AV20TFReceptionistGivenName, AV21TFReceptionistGivenName_Sel, AV22TFReceptionistLastName, AV23TFReceptionistLastName_Sel, AV26TFReceptionistEmail, AV27TFReceptionistEmail_Sel, AV28TFReceptionistPhone, AV29TFReceptionistPhone_Sel, AV52TFReceptionistIsActive_Sel, AV41IsAuthorized_Display, AV43IsAuthorized_Update, AV45IsAuthorized_Delete, AV39IsAuthorized_ReceptionistGivenName, AV46IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV60Pgmname = "Trn_ReceptionistWW";
         edtReceptionistId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtReceptionistGivenName_Enabled = 0;
         edtReceptionistLastName_Enabled = 0;
         edtReceptionistInitials_Enabled = 0;
         edtReceptionistEmail_Enabled = 0;
         edtReceptionistPhoneCode_Enabled = 0;
         edtReceptionistPhone_Enabled = 0;
         edtReceptionistPhoneNumber_Enabled = 0;
         edtReceptionistGAMGUID_Enabled = 0;
         chkReceptionistIsActive.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E184R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV32DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV58ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), ".", ","), 18, MidpointRounding.ToEven));
            AV36GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV37GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV38GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_39_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), ".", ","), 18, MidpointRounding.ToEven));
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            if ( nGXsfl_39_idx > 0 )
            {
               A89ReceptionistId = StringUtil.StrToGuid( cgiGet( edtReceptionistId_Internalname));
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
               A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
               A90ReceptionistGivenName = cgiGet( edtReceptionistGivenName_Internalname);
               A91ReceptionistLastName = cgiGet( edtReceptionistLastName_Internalname);
               A92ReceptionistInitials = cgiGet( edtReceptionistInitials_Internalname);
               A93ReceptionistEmail = cgiGet( edtReceptionistEmail_Internalname);
               A373ReceptionistPhoneCode = cgiGet( edtReceptionistPhoneCode_Internalname);
               A94ReceptionistPhone = cgiGet( edtReceptionistPhone_Internalname);
               A374ReceptionistPhoneNumber = cgiGet( edtReceptionistPhoneNumber_Internalname);
               A95ReceptionistGAMGUID = cgiGet( edtReceptionistGAMGUID_Internalname);
               A398ReceptionistIsActive = StringUtil.StrToBool( cgiGet( chkReceptionistIsActive_Internalname));
               cmbavActiongroup.Name = cmbavActiongroup_Internalname;
               cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
               AV54ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV54ActionGroup), 4, 0));
            }
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
         E184R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E184R2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
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
         GXt_boolean1 = AV39IsAuthorized_ReceptionistGivenName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionistview_Execute", out  GXt_boolean1) ;
         AV39IsAuthorized_ReceptionistGivenName = GXt_boolean1;
         AssignAttri("", false, "AV39IsAuthorized_ReceptionistGivenName", AV39IsAuthorized_ReceptionistGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RECEPTIONISTGIVENNAME", GetSecureSignedToken( "", AV39IsAuthorized_ReceptionistGivenName, context));
         AV33GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV34GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV33GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Receptionist";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV32DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV32DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E194R2( )
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
         if ( StringUtil.StrCmp(AV16Session.Get("Trn_ReceptionistWWColumnsSelector"), "") != 0 )
         {
            AV56ColumnsSelectorXML = AV16Session.Get("Trn_ReceptionistWWColumnsSelector");
            AV58ColumnsSelector.FromXml(AV56ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtReceptionistGivenName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV58ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtReceptionistGivenName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistGivenName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtReceptionistLastName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV58ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtReceptionistLastName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistLastName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtReceptionistEmail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV58ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtReceptionistEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistEmail_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtReceptionistPhone_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV58ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtReceptionistPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistPhone_Visible), 5, 0), !bGXsfl_39_Refreshing);
         chkReceptionistIsActive.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV58ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkReceptionistIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkReceptionistIsActive.Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV36GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV36GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV36GridCurrentPage), 10, 0));
         AV37GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV37GridPageCount", StringUtil.LTrimStr( (decimal)(AV37GridPageCount), 10, 0));
         GXt_char3 = AV38GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV60Pgmname, out  GXt_char3) ;
         AV38GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV38GridAppliedFilters", AV38GridAppliedFilters);
         chkReceptionistIsActive_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, chkReceptionistIsActive_Internalname, "Columnheaderclass", chkReceptionistIsActive_Columnheaderclass, !bGXsfl_39_Refreshing);
         AV61Trn_receptionistwwds_1_filterfulltext = AV15FilterFullText;
         AV62Trn_receptionistwwds_2_tfreceptionistgivenname = AV20TFReceptionistGivenName;
         AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel = AV21TFReceptionistGivenName_Sel;
         AV64Trn_receptionistwwds_4_tfreceptionistlastname = AV22TFReceptionistLastName;
         AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel = AV23TFReceptionistLastName_Sel;
         AV66Trn_receptionistwwds_6_tfreceptionistemail = AV26TFReceptionistEmail;
         AV67Trn_receptionistwwds_7_tfreceptionistemail_sel = AV27TFReceptionistEmail_Sel;
         AV68Trn_receptionistwwds_8_tfreceptionistphone = AV28TFReceptionistPhone;
         AV69Trn_receptionistwwds_9_tfreceptionistphone_sel = AV29TFReceptionistPhone_Sel;
         AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel = AV52TFReceptionistIsActive_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58ColumnsSelector", AV58ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E124R2( )
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
            AV35PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV35PageToGo) ;
         }
      }

      protected void E134R2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E154R2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReceptionistGivenName") == 0 )
            {
               AV20TFReceptionistGivenName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV20TFReceptionistGivenName", AV20TFReceptionistGivenName);
               AV21TFReceptionistGivenName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV21TFReceptionistGivenName_Sel", AV21TFReceptionistGivenName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReceptionistLastName") == 0 )
            {
               AV22TFReceptionistLastName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV22TFReceptionistLastName", AV22TFReceptionistLastName);
               AV23TFReceptionistLastName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV23TFReceptionistLastName_Sel", AV23TFReceptionistLastName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReceptionistEmail") == 0 )
            {
               AV26TFReceptionistEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV26TFReceptionistEmail", AV26TFReceptionistEmail);
               AV27TFReceptionistEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV27TFReceptionistEmail_Sel", AV27TFReceptionistEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReceptionistPhone") == 0 )
            {
               AV28TFReceptionistPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFReceptionistPhone", AV28TFReceptionistPhone);
               AV29TFReceptionistPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFReceptionistPhone_Sel", AV29TFReceptionistPhone_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReceptionistIsActive") == 0 )
            {
               AV52TFReceptionistIsActive_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52TFReceptionistIsActive_Sel", StringUtil.Str( (decimal)(AV52TFReceptionistIsActive_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E204R2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavActiongroup.removeAllItems();
         cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
         if ( AV41IsAuthorized_Display )
         {
            cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", "Display", "fa fa-search", "", "", "", "", "", "", ""), 0);
         }
         if ( AV43IsAuthorized_Update )
         {
            cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", "Update", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV45IsAuthorized_Delete )
         {
            cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", "Delete", "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         if ( cmbavActiongroup.ItemCount == 1 )
         {
            cmbavActiongroup_Class = "Invisible";
         }
         else
         {
            cmbavActiongroup_Class = "ConvertToDDO";
         }
         if ( AV39IsAuthorized_ReceptionistGivenName )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_receptionistview.aspx"+UrlEncode(A89ReceptionistId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtReceptionistGivenName_Link = formatLink("trn_receptionistview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( A398ReceptionistIsActive )
         {
            chkReceptionistIsActive_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( ! A398ReceptionistIsActive )
         {
            chkReceptionistIsActive_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else
         {
            chkReceptionistIsActive_Columnclass = "WWColumn hidden-xs";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 39;
         }
         sendrow_392( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_39_Refreshing )
         {
            DoAjaxLoad(39, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV54ActionGroup), 4, 0));
      }

      protected void E164R2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV56ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV58ColumnsSelector.FromJSonString(AV56ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "Trn_ReceptionistWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV56ColumnsSelectorXML)) ? "" : AV58ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58ColumnsSelector", AV58ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E114R2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_ReceptionistWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV60Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_ReceptionistWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV18ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "Trn_ReceptionistWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV18ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV18ManageFiltersXml) ;
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
               S192 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58ColumnsSelector", AV58ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void E214R2( )
      {
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV54ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV54ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV54ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV54ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV54ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV54ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58ColumnsSelector", AV58ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E174R2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV46IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58ColumnsSelector", AV58ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E144R2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0064",(string)"",(string)"Trn_Receptionist",(short)1,(string)"",(string)""});
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

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV58ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV58ColumnsSelector,  "ReceptionistGivenName",  "",  "First Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV58ColumnsSelector,  "ReceptionistLastName",  "",  "Last Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV58ColumnsSelector,  "ReceptionistEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV58ColumnsSelector,  "ReceptionistPhone",  "",  "Phone",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV58ColumnsSelector,  "ReceptionistIsActive",  "",  "Is Active",  true,  "") ;
         GXt_char3 = AV57UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "Trn_ReceptionistWWColumnsSelector", out  GXt_char3) ;
         AV57UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57UserCustomValue)) ) )
         {
            AV59ColumnsSelectorAux.FromXml(AV57UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV59ColumnsSelectorAux, ref  AV58ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV41IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionistview_Execute", out  GXt_boolean1) ;
         AV41IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV41IsAuthorized_Display", AV41IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV41IsAuthorized_Display, context));
         GXt_boolean1 = AV43IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Update", out  GXt_boolean1) ;
         AV43IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV43IsAuthorized_Update", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         GXt_boolean1 = AV45IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Delete", out  GXt_boolean1) ;
         AV45IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV45IsAuthorized_Delete", AV45IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV45IsAuthorized_Delete, context));
         GXt_boolean1 = AV46IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Insert", out  GXt_boolean1) ;
         AV46IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV46IsAuthorized_Insert", AV46IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV46IsAuthorized_Insert, context));
         if ( ! ( AV46IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_Receptionist",  1) ) )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_ReceptionistWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV20TFReceptionistGivenName = "";
         AssignAttri("", false, "AV20TFReceptionistGivenName", AV20TFReceptionistGivenName);
         AV21TFReceptionistGivenName_Sel = "";
         AssignAttri("", false, "AV21TFReceptionistGivenName_Sel", AV21TFReceptionistGivenName_Sel);
         AV22TFReceptionistLastName = "";
         AssignAttri("", false, "AV22TFReceptionistLastName", AV22TFReceptionistLastName);
         AV23TFReceptionistLastName_Sel = "";
         AssignAttri("", false, "AV23TFReceptionistLastName_Sel", AV23TFReceptionistLastName_Sel);
         AV26TFReceptionistEmail = "";
         AssignAttri("", false, "AV26TFReceptionistEmail", AV26TFReceptionistEmail);
         AV27TFReceptionistEmail_Sel = "";
         AssignAttri("", false, "AV27TFReceptionistEmail_Sel", AV27TFReceptionistEmail_Sel);
         AV28TFReceptionistPhone = "";
         AssignAttri("", false, "AV28TFReceptionistPhone", AV28TFReceptionistPhone);
         AV29TFReceptionistPhone_Sel = "";
         AssignAttri("", false, "AV29TFReceptionistPhone_Sel", AV29TFReceptionistPhone_Sel);
         AV52TFReceptionistIsActive_Sel = 0;
         AssignAttri("", false, "AV52TFReceptionistIsActive_Sel", StringUtil.Str( (decimal)(AV52TFReceptionistIsActive_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S202( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV41IsAuthorized_Display )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_receptionistview.aspx"+UrlEncode(A89ReceptionistId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("trn_receptionistview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
      }

      protected void S212( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV43IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A89ReceptionistId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(A29LocationId.ToString());
            CallWebObject(formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV45IsAuthorized_Delete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A89ReceptionistId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(A29LocationId.ToString());
            CallWebObject(formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV60Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV60Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV60Pgmname+"GridState"), null, "", "");
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
         S192 ();
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

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV71GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTGIVENNAME") == 0 )
            {
               AV20TFReceptionistGivenName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20TFReceptionistGivenName", AV20TFReceptionistGivenName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTGIVENNAME_SEL") == 0 )
            {
               AV21TFReceptionistGivenName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV21TFReceptionistGivenName_Sel", AV21TFReceptionistGivenName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTLASTNAME") == 0 )
            {
               AV22TFReceptionistLastName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV22TFReceptionistLastName", AV22TFReceptionistLastName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTLASTNAME_SEL") == 0 )
            {
               AV23TFReceptionistLastName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23TFReceptionistLastName_Sel", AV23TFReceptionistLastName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTEMAIL") == 0 )
            {
               AV26TFReceptionistEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV26TFReceptionistEmail", AV26TFReceptionistEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTEMAIL_SEL") == 0 )
            {
               AV27TFReceptionistEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFReceptionistEmail_Sel", AV27TFReceptionistEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTPHONE") == 0 )
            {
               AV28TFReceptionistPhone = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFReceptionistPhone", AV28TFReceptionistPhone);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTPHONE_SEL") == 0 )
            {
               AV29TFReceptionistPhone_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFReceptionistPhone_Sel", AV29TFReceptionistPhone_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRECEPTIONISTISACTIVE_SEL") == 0 )
            {
               AV52TFReceptionistIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV52TFReceptionistIsActive_Sel", StringUtil.Str( (decimal)(AV52TFReceptionistIsActive_Sel), 1, 0));
            }
            AV71GXV1 = (int)(AV71GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFReceptionistGivenName_Sel)),  AV21TFReceptionistGivenName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFReceptionistLastName_Sel)),  AV23TFReceptionistLastName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFReceptionistEmail_Sel)),  AV27TFReceptionistEmail_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFReceptionistPhone_Sel)),  AV29TFReceptionistPhone_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+((0==AV52TFReceptionistIsActive_Sel) ? "" : StringUtil.Str( (decimal)(AV52TFReceptionistIsActive_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFReceptionistGivenName)),  AV20TFReceptionistGivenName, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFReceptionistLastName)),  AV22TFReceptionistLastName, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFReceptionistEmail)),  AV26TFReceptionistEmail, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFReceptionistPhone)),  AV28TFReceptionistPhone, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV60Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRECEPTIONISTGIVENNAME",  "First Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFReceptionistGivenName)),  0,  AV20TFReceptionistGivenName,  AV20TFReceptionistGivenName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFReceptionistGivenName_Sel)),  AV21TFReceptionistGivenName_Sel,  AV21TFReceptionistGivenName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRECEPTIONISTLASTNAME",  "Last Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFReceptionistLastName)),  0,  AV22TFReceptionistLastName,  AV22TFReceptionistLastName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFReceptionistLastName_Sel)),  AV23TFReceptionistLastName_Sel,  AV23TFReceptionistLastName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRECEPTIONISTEMAIL",  "Email",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFReceptionistEmail)),  0,  AV26TFReceptionistEmail,  AV26TFReceptionistEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFReceptionistEmail_Sel)),  AV27TFReceptionistEmail_Sel,  AV27TFReceptionistEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRECEPTIONISTPHONE",  "Phone",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFReceptionistPhone)),  0,  AV28TFReceptionistPhone,  AV28TFReceptionistPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFReceptionistPhone_Sel)),  AV29TFReceptionistPhone_Sel,  AV29TFReceptionistPhone_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFRECEPTIONISTISACTIVE_SEL",  "Is Active",  !(0==AV52TFReceptionistIsActive_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV52TFReceptionistIsActive_Sel), 1, 0)),  ((AV52TFReceptionistIsActive_Sel==1) ? "Checked" : "Unchecked"),  false,  "",  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV60Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_Receptionist";
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
         PA4R2( ) ;
         WS4R2( ) ;
         WE4R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024111983816", true, true);
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
         context.AddJavascriptSource("trn_receptionistww.js", "?2024111983819", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_392( )
      {
         edtReceptionistId_Internalname = "RECEPTIONISTID_"+sGXsfl_39_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_39_idx;
         edtLocationId_Internalname = "LOCATIONID_"+sGXsfl_39_idx;
         edtReceptionistGivenName_Internalname = "RECEPTIONISTGIVENNAME_"+sGXsfl_39_idx;
         edtReceptionistLastName_Internalname = "RECEPTIONISTLASTNAME_"+sGXsfl_39_idx;
         edtReceptionistInitials_Internalname = "RECEPTIONISTINITIALS_"+sGXsfl_39_idx;
         edtReceptionistEmail_Internalname = "RECEPTIONISTEMAIL_"+sGXsfl_39_idx;
         edtReceptionistPhoneCode_Internalname = "RECEPTIONISTPHONECODE_"+sGXsfl_39_idx;
         edtReceptionistPhone_Internalname = "RECEPTIONISTPHONE_"+sGXsfl_39_idx;
         edtReceptionistPhoneNumber_Internalname = "RECEPTIONISTPHONENUMBER_"+sGXsfl_39_idx;
         edtReceptionistGAMGUID_Internalname = "RECEPTIONISTGAMGUID_"+sGXsfl_39_idx;
         chkReceptionistIsActive_Internalname = "RECEPTIONISTISACTIVE_"+sGXsfl_39_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtReceptionistId_Internalname = "RECEPTIONISTID_"+sGXsfl_39_fel_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_39_fel_idx;
         edtLocationId_Internalname = "LOCATIONID_"+sGXsfl_39_fel_idx;
         edtReceptionistGivenName_Internalname = "RECEPTIONISTGIVENNAME_"+sGXsfl_39_fel_idx;
         edtReceptionistLastName_Internalname = "RECEPTIONISTLASTNAME_"+sGXsfl_39_fel_idx;
         edtReceptionistInitials_Internalname = "RECEPTIONISTINITIALS_"+sGXsfl_39_fel_idx;
         edtReceptionistEmail_Internalname = "RECEPTIONISTEMAIL_"+sGXsfl_39_fel_idx;
         edtReceptionistPhoneCode_Internalname = "RECEPTIONISTPHONECODE_"+sGXsfl_39_fel_idx;
         edtReceptionistPhone_Internalname = "RECEPTIONISTPHONE_"+sGXsfl_39_fel_idx;
         edtReceptionistPhoneNumber_Internalname = "RECEPTIONISTPHONENUMBER_"+sGXsfl_39_fel_idx;
         edtReceptionistGAMGUID_Internalname = "RECEPTIONISTGAMGUID_"+sGXsfl_39_fel_idx;
         chkReceptionistIsActive_Internalname = "RECEPTIONISTISACTIVE_"+sGXsfl_39_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WB4R0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_39_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_39_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_39_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReceptionistId_Internalname,A89ReceptionistId.ToString(),A89ReceptionistId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReceptionistId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationId_Internalname,A29LocationId.ToString(),A29LocationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtReceptionistGivenName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReceptionistGivenName_Internalname,(string)A90ReceptionistGivenName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtReceptionistGivenName_Link,(string)"",(string)"",(string)"",(string)edtReceptionistGivenName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtReceptionistGivenName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtReceptionistLastName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReceptionistLastName_Internalname,(string)A91ReceptionistLastName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReceptionistLastName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtReceptionistLastName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReceptionistInitials_Internalname,StringUtil.RTrim( A92ReceptionistInitials),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReceptionistInitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtReceptionistEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReceptionistEmail_Internalname,(string)A93ReceptionistEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A93ReceptionistEmail,(string)"",(string)"",(string)"",(string)edtReceptionistEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtReceptionistEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReceptionistPhoneCode_Internalname,(string)A373ReceptionistPhoneCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReceptionistPhoneCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtReceptionistPhone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A94ReceptionistPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReceptionistPhone_Internalname,StringUtil.RTrim( A94ReceptionistPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtReceptionistPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtReceptionistPhone_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReceptionistPhoneNumber_Internalname,(string)A374ReceptionistPhoneNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReceptionistPhoneNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReceptionistGAMGUID_Internalname,(string)A95ReceptionistGAMGUID,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReceptionistGAMGUID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkReceptionistIsActive.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "RECEPTIONISTISACTIVE_" + sGXsfl_39_idx;
            chkReceptionistIsActive.Name = GXCCtl;
            chkReceptionistIsActive.WebTags = "";
            chkReceptionistIsActive.Caption = "";
            AssignProp("", false, chkReceptionistIsActive_Internalname, "TitleCaption", chkReceptionistIsActive.Caption, !bGXsfl_39_Refreshing);
            chkReceptionistIsActive.CheckedValue = "false";
            A398ReceptionistIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A398ReceptionistIsActive));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkReceptionistIsActive_Internalname,StringUtil.BoolToStr( A398ReceptionistIsActive),(string)"",(string)"",chkReceptionistIsActive.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)chkReceptionistIsActive_Columnclass,(string)chkReceptionistIsActive_Columnheaderclass,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_39_idx + "',39)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_39_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  AV54ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV54ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV54ActionGroup), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV54ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_39_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV54ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            send_integrity_lvl_hashes4R2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "RECEPTIONISTISACTIVE_" + sGXsfl_39_idx;
         chkReceptionistIsActive.Name = GXCCtl;
         chkReceptionistIsActive.WebTags = "";
         chkReceptionistIsActive.Caption = "";
         AssignProp("", false, chkReceptionistIsActive_Internalname, "TitleCaption", chkReceptionistIsActive.Caption, !bGXsfl_39_Refreshing);
         chkReceptionistIsActive.CheckedValue = "false";
         A398ReceptionistIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A398ReceptionistIsActive));
         GXCCtl = "vACTIONGROUP_" + sGXsfl_39_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            AV54ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV54ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV54ActionGroup), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl39( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"39\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtReceptionistGivenName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "First Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtReceptionistLastName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Last Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtReceptionistEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtReceptionistPhone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+((chkReceptionistIsActive.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Is Active") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavActiongroup_Class+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A89ReceptionistId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A29LocationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A90ReceptionistGivenName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtReceptionistGivenName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtReceptionistGivenName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A91ReceptionistLastName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtReceptionistLastName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A92ReceptionistInitials)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A93ReceptionistEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtReceptionistEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A373ReceptionistPhoneCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A94ReceptionistPhone)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtReceptionistPhone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A374ReceptionistPhoneNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A95ReceptionistGAMGUID));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A398ReceptionistIsActive)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( chkReceptionistIsActive_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( chkReceptionistIsActive_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkReceptionistIsActive.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54ActionGroup), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavActiongroup_Class));
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
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtReceptionistId_Internalname = "RECEPTIONISTID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtLocationId_Internalname = "LOCATIONID";
         edtReceptionistGivenName_Internalname = "RECEPTIONISTGIVENNAME";
         edtReceptionistLastName_Internalname = "RECEPTIONISTLASTNAME";
         edtReceptionistInitials_Internalname = "RECEPTIONISTINITIALS";
         edtReceptionistEmail_Internalname = "RECEPTIONISTEMAIL";
         edtReceptionistPhoneCode_Internalname = "RECEPTIONISTPHONECODE";
         edtReceptionistPhone_Internalname = "RECEPTIONISTPHONE";
         edtReceptionistPhoneNumber_Internalname = "RECEPTIONISTPHONENUMBER";
         edtReceptionistGAMGUID_Internalname = "RECEPTIONISTGAMGUID";
         chkReceptionistIsActive_Internalname = "RECEPTIONISTISACTIVE";
         cmbavActiongroup_Internalname = "vACTIONGROUP";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
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
         subGrid_Allowhovering = -1;
         subGrid_Allowselection = 1;
         subGrid_Header = "";
         cmbavActiongroup_Jsonclick = "";
         cmbavActiongroup_Class = "ConvertToDDO";
         chkReceptionistIsActive.Caption = "";
         chkReceptionistIsActive_Columnclass = "WWColumn hidden-xs";
         edtReceptionistGAMGUID_Jsonclick = "";
         edtReceptionistPhoneNumber_Jsonclick = "";
         edtReceptionistPhone_Jsonclick = "";
         edtReceptionistPhoneCode_Jsonclick = "";
         edtReceptionistEmail_Jsonclick = "";
         edtReceptionistInitials_Jsonclick = "";
         edtReceptionistLastName_Jsonclick = "";
         edtReceptionistGivenName_Jsonclick = "";
         edtReceptionistGivenName_Link = "";
         edtLocationId_Jsonclick = "";
         edtOrganisationId_Jsonclick = "";
         edtReceptionistId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         chkReceptionistIsActive_Columnheaderclass = "";
         chkReceptionistIsActive.Visible = -1;
         edtReceptionistPhone_Visible = -1;
         edtReceptionistEmail_Visible = -1;
         edtReceptionistLastName_Visible = -1;
         edtReceptionistGivenName_Visible = -1;
         chkReceptionistIsActive.Enabled = 0;
         edtReceptionistGAMGUID_Enabled = 0;
         edtReceptionistPhoneNumber_Enabled = 0;
         edtReceptionistPhone_Enabled = 0;
         edtReceptionistPhoneCode_Enabled = 0;
         edtReceptionistEmail_Enabled = 0;
         edtReceptionistInitials_Enabled = 0;
         edtReceptionistLastName_Enabled = 0;
         edtReceptionistGivenName_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtReceptionistId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "Trn_ReceptionistWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|T|";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5";
         Ddo_grid_Columnids = "3:ReceptionistGivenName|4:ReceptionistLastName|6:ReceptionistEmail|8:ReceptionistPhone|11:ReceptionistIsActive";
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
         Form.Caption = " Receptionist";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFReceptionistGivenName","fld":"vTFRECEPTIONISTGIVENNAME"},{"av":"AV21TFReceptionistGivenName_Sel","fld":"vTFRECEPTIONISTGIVENNAME_SEL"},{"av":"AV22TFReceptionistLastName","fld":"vTFRECEPTIONISTLASTNAME"},{"av":"AV23TFReceptionistLastName_Sel","fld":"vTFRECEPTIONISTLASTNAME_SEL"},{"av":"AV26TFReceptionistEmail","fld":"vTFRECEPTIONISTEMAIL"},{"av":"AV27TFReceptionistEmail_Sel","fld":"vTFRECEPTIONISTEMAIL_SEL"},{"av":"AV28TFReceptionistPhone","fld":"vTFRECEPTIONISTPHONE"},{"av":"AV29TFReceptionistPhone_Sel","fld":"vTFRECEPTIONISTPHONE_SEL"},{"av":"AV52TFReceptionistIsActive_Sel","fld":"vTFRECEPTIONISTISACTIVE_SEL","pic":"9"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV39IsAuthorized_ReceptionistGivenName","fld":"vISAUTHORIZED_RECEPTIONISTGIVENNAME","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtReceptionistGivenName_Visible","ctrl":"RECEPTIONISTGIVENNAME","prop":"Visible"},{"av":"edtReceptionistLastName_Visible","ctrl":"RECEPTIONISTLASTNAME","prop":"Visible"},{"av":"edtReceptionistEmail_Visible","ctrl":"RECEPTIONISTEMAIL","prop":"Visible"},{"av":"edtReceptionistPhone_Visible","ctrl":"RECEPTIONISTPHONE","prop":"Visible"},{"av":"chkReceptionistIsActive.Visible","ctrl":"RECEPTIONISTISACTIVE","prop":"Visible"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"chkReceptionistIsActive_Columnheaderclass","ctrl":"RECEPTIONISTISACTIVE","prop":"Columnheaderclass"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E124R2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFReceptionistGivenName","fld":"vTFRECEPTIONISTGIVENNAME"},{"av":"AV21TFReceptionistGivenName_Sel","fld":"vTFRECEPTIONISTGIVENNAME_SEL"},{"av":"AV22TFReceptionistLastName","fld":"vTFRECEPTIONISTLASTNAME"},{"av":"AV23TFReceptionistLastName_Sel","fld":"vTFRECEPTIONISTLASTNAME_SEL"},{"av":"AV26TFReceptionistEmail","fld":"vTFRECEPTIONISTEMAIL"},{"av":"AV27TFReceptionistEmail_Sel","fld":"vTFRECEPTIONISTEMAIL_SEL"},{"av":"AV28TFReceptionistPhone","fld":"vTFRECEPTIONISTPHONE"},{"av":"AV29TFReceptionistPhone_Sel","fld":"vTFRECEPTIONISTPHONE_SEL"},{"av":"AV52TFReceptionistIsActive_Sel","fld":"vTFRECEPTIONISTISACTIVE_SEL","pic":"9"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV39IsAuthorized_ReceptionistGivenName","fld":"vISAUTHORIZED_RECEPTIONISTGIVENNAME","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E134R2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFReceptionistGivenName","fld":"vTFRECEPTIONISTGIVENNAME"},{"av":"AV21TFReceptionistGivenName_Sel","fld":"vTFRECEPTIONISTGIVENNAME_SEL"},{"av":"AV22TFReceptionistLastName","fld":"vTFRECEPTIONISTLASTNAME"},{"av":"AV23TFReceptionistLastName_Sel","fld":"vTFRECEPTIONISTLASTNAME_SEL"},{"av":"AV26TFReceptionistEmail","fld":"vTFRECEPTIONISTEMAIL"},{"av":"AV27TFReceptionistEmail_Sel","fld":"vTFRECEPTIONISTEMAIL_SEL"},{"av":"AV28TFReceptionistPhone","fld":"vTFRECEPTIONISTPHONE"},{"av":"AV29TFReceptionistPhone_Sel","fld":"vTFRECEPTIONISTPHONE_SEL"},{"av":"AV52TFReceptionistIsActive_Sel","fld":"vTFRECEPTIONISTISACTIVE_SEL","pic":"9"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV39IsAuthorized_ReceptionistGivenName","fld":"vISAUTHORIZED_RECEPTIONISTGIVENNAME","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E154R2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFReceptionistGivenName","fld":"vTFRECEPTIONISTGIVENNAME"},{"av":"AV21TFReceptionistGivenName_Sel","fld":"vTFRECEPTIONISTGIVENNAME_SEL"},{"av":"AV22TFReceptionistLastName","fld":"vTFRECEPTIONISTLASTNAME"},{"av":"AV23TFReceptionistLastName_Sel","fld":"vTFRECEPTIONISTLASTNAME_SEL"},{"av":"AV26TFReceptionistEmail","fld":"vTFRECEPTIONISTEMAIL"},{"av":"AV27TFReceptionistEmail_Sel","fld":"vTFRECEPTIONISTEMAIL_SEL"},{"av":"AV28TFReceptionistPhone","fld":"vTFRECEPTIONISTPHONE"},{"av":"AV29TFReceptionistPhone_Sel","fld":"vTFRECEPTIONISTPHONE_SEL"},{"av":"AV52TFReceptionistIsActive_Sel","fld":"vTFRECEPTIONISTISACTIVE_SEL","pic":"9"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV39IsAuthorized_ReceptionistGivenName","fld":"vISAUTHORIZED_RECEPTIONISTGIVENNAME","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20TFReceptionistGivenName","fld":"vTFRECEPTIONISTGIVENNAME"},{"av":"AV21TFReceptionistGivenName_Sel","fld":"vTFRECEPTIONISTGIVENNAME_SEL"},{"av":"AV22TFReceptionistLastName","fld":"vTFRECEPTIONISTLASTNAME"},{"av":"AV23TFReceptionistLastName_Sel","fld":"vTFRECEPTIONISTLASTNAME_SEL"},{"av":"AV26TFReceptionistEmail","fld":"vTFRECEPTIONISTEMAIL"},{"av":"AV27TFReceptionistEmail_Sel","fld":"vTFRECEPTIONISTEMAIL_SEL"},{"av":"AV28TFReceptionistPhone","fld":"vTFRECEPTIONISTPHONE"},{"av":"AV29TFReceptionistPhone_Sel","fld":"vTFRECEPTIONISTPHONE_SEL"},{"av":"AV52TFReceptionistIsActive_Sel","fld":"vTFRECEPTIONISTISACTIVE_SEL","pic":"9"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E204R2","iparms":[{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV39IsAuthorized_ReceptionistGivenName","fld":"vISAUTHORIZED_RECEPTIONISTGIVENNAME","hsh":true},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true},{"av":"A398ReceptionistIsActive","fld":"RECEPTIONISTISACTIVE"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV54ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtReceptionistGivenName_Link","ctrl":"RECEPTIONISTGIVENNAME","prop":"Link"},{"av":"chkReceptionistIsActive_Columnclass","ctrl":"RECEPTIONISTISACTIVE","prop":"Columnclass"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E164R2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFReceptionistGivenName","fld":"vTFRECEPTIONISTGIVENNAME"},{"av":"AV21TFReceptionistGivenName_Sel","fld":"vTFRECEPTIONISTGIVENNAME_SEL"},{"av":"AV22TFReceptionistLastName","fld":"vTFRECEPTIONISTLASTNAME"},{"av":"AV23TFReceptionistLastName_Sel","fld":"vTFRECEPTIONISTLASTNAME_SEL"},{"av":"AV26TFReceptionistEmail","fld":"vTFRECEPTIONISTEMAIL"},{"av":"AV27TFReceptionistEmail_Sel","fld":"vTFRECEPTIONISTEMAIL_SEL"},{"av":"AV28TFReceptionistPhone","fld":"vTFRECEPTIONISTPHONE"},{"av":"AV29TFReceptionistPhone_Sel","fld":"vTFRECEPTIONISTPHONE_SEL"},{"av":"AV52TFReceptionistIsActive_Sel","fld":"vTFRECEPTIONISTISACTIVE_SEL","pic":"9"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV39IsAuthorized_ReceptionistGivenName","fld":"vISAUTHORIZED_RECEPTIONISTGIVENNAME","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtReceptionistGivenName_Visible","ctrl":"RECEPTIONISTGIVENNAME","prop":"Visible"},{"av":"edtReceptionistLastName_Visible","ctrl":"RECEPTIONISTLASTNAME","prop":"Visible"},{"av":"edtReceptionistEmail_Visible","ctrl":"RECEPTIONISTEMAIL","prop":"Visible"},{"av":"edtReceptionistPhone_Visible","ctrl":"RECEPTIONISTPHONE","prop":"Visible"},{"av":"chkReceptionistIsActive.Visible","ctrl":"RECEPTIONISTISACTIVE","prop":"Visible"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"chkReceptionistIsActive_Columnheaderclass","ctrl":"RECEPTIONISTISACTIVE","prop":"Columnheaderclass"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E114R2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFReceptionistGivenName","fld":"vTFRECEPTIONISTGIVENNAME"},{"av":"AV21TFReceptionistGivenName_Sel","fld":"vTFRECEPTIONISTGIVENNAME_SEL"},{"av":"AV22TFReceptionistLastName","fld":"vTFRECEPTIONISTLASTNAME"},{"av":"AV23TFReceptionistLastName_Sel","fld":"vTFRECEPTIONISTLASTNAME_SEL"},{"av":"AV26TFReceptionistEmail","fld":"vTFRECEPTIONISTEMAIL"},{"av":"AV27TFReceptionistEmail_Sel","fld":"vTFRECEPTIONISTEMAIL_SEL"},{"av":"AV28TFReceptionistPhone","fld":"vTFRECEPTIONISTPHONE"},{"av":"AV29TFReceptionistPhone_Sel","fld":"vTFRECEPTIONISTPHONE_SEL"},{"av":"AV52TFReceptionistIsActive_Sel","fld":"vTFRECEPTIONISTISACTIVE_SEL","pic":"9"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV39IsAuthorized_ReceptionistGivenName","fld":"vISAUTHORIZED_RECEPTIONISTGIVENNAME","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFReceptionistGivenName","fld":"vTFRECEPTIONISTGIVENNAME"},{"av":"AV21TFReceptionistGivenName_Sel","fld":"vTFRECEPTIONISTGIVENNAME_SEL"},{"av":"AV22TFReceptionistLastName","fld":"vTFRECEPTIONISTLASTNAME"},{"av":"AV23TFReceptionistLastName_Sel","fld":"vTFRECEPTIONISTLASTNAME_SEL"},{"av":"AV26TFReceptionistEmail","fld":"vTFRECEPTIONISTEMAIL"},{"av":"AV27TFReceptionistEmail_Sel","fld":"vTFRECEPTIONISTEMAIL_SEL"},{"av":"AV28TFReceptionistPhone","fld":"vTFRECEPTIONISTPHONE"},{"av":"AV29TFReceptionistPhone_Sel","fld":"vTFRECEPTIONISTPHONE_SEL"},{"av":"AV52TFReceptionistIsActive_Sel","fld":"vTFRECEPTIONISTISACTIVE_SEL","pic":"9"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtReceptionistGivenName_Visible","ctrl":"RECEPTIONISTGIVENNAME","prop":"Visible"},{"av":"edtReceptionistLastName_Visible","ctrl":"RECEPTIONISTLASTNAME","prop":"Visible"},{"av":"edtReceptionistEmail_Visible","ctrl":"RECEPTIONISTEMAIL","prop":"Visible"},{"av":"edtReceptionistPhone_Visible","ctrl":"RECEPTIONISTPHONE","prop":"Visible"},{"av":"chkReceptionistIsActive.Visible","ctrl":"RECEPTIONISTISACTIVE","prop":"Visible"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"chkReceptionistIsActive_Columnheaderclass","ctrl":"RECEPTIONISTISACTIVE","prop":"Columnheaderclass"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E214R2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV54ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFReceptionistGivenName","fld":"vTFRECEPTIONISTGIVENNAME"},{"av":"AV21TFReceptionistGivenName_Sel","fld":"vTFRECEPTIONISTGIVENNAME_SEL"},{"av":"AV22TFReceptionistLastName","fld":"vTFRECEPTIONISTLASTNAME"},{"av":"AV23TFReceptionistLastName_Sel","fld":"vTFRECEPTIONISTLASTNAME_SEL"},{"av":"AV26TFReceptionistEmail","fld":"vTFRECEPTIONISTEMAIL"},{"av":"AV27TFReceptionistEmail_Sel","fld":"vTFRECEPTIONISTEMAIL_SEL"},{"av":"AV28TFReceptionistPhone","fld":"vTFRECEPTIONISTPHONE"},{"av":"AV29TFReceptionistPhone_Sel","fld":"vTFRECEPTIONISTPHONE_SEL"},{"av":"AV52TFReceptionistIsActive_Sel","fld":"vTFRECEPTIONISTISACTIVE_SEL","pic":"9"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV39IsAuthorized_ReceptionistGivenName","fld":"vISAUTHORIZED_RECEPTIONISTGIVENNAME","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV54ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtReceptionistGivenName_Visible","ctrl":"RECEPTIONISTGIVENNAME","prop":"Visible"},{"av":"edtReceptionistLastName_Visible","ctrl":"RECEPTIONISTLASTNAME","prop":"Visible"},{"av":"edtReceptionistEmail_Visible","ctrl":"RECEPTIONISTEMAIL","prop":"Visible"},{"av":"edtReceptionistPhone_Visible","ctrl":"RECEPTIONISTPHONE","prop":"Visible"},{"av":"chkReceptionistIsActive.Visible","ctrl":"RECEPTIONISTISACTIVE","prop":"Visible"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"chkReceptionistIsActive_Columnheaderclass","ctrl":"RECEPTIONISTISACTIVE","prop":"Columnheaderclass"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E174R2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFReceptionistGivenName","fld":"vTFRECEPTIONISTGIVENNAME"},{"av":"AV21TFReceptionistGivenName_Sel","fld":"vTFRECEPTIONISTGIVENNAME_SEL"},{"av":"AV22TFReceptionistLastName","fld":"vTFRECEPTIONISTLASTNAME"},{"av":"AV23TFReceptionistLastName_Sel","fld":"vTFRECEPTIONISTLASTNAME_SEL"},{"av":"AV26TFReceptionistEmail","fld":"vTFRECEPTIONISTEMAIL"},{"av":"AV27TFReceptionistEmail_Sel","fld":"vTFRECEPTIONISTEMAIL_SEL"},{"av":"AV28TFReceptionistPhone","fld":"vTFRECEPTIONISTPHONE"},{"av":"AV29TFReceptionistPhone_Sel","fld":"vTFRECEPTIONISTPHONE_SEL"},{"av":"AV52TFReceptionistIsActive_Sel","fld":"vTFRECEPTIONISTISACTIVE_SEL","pic":"9"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV39IsAuthorized_ReceptionistGivenName","fld":"vISAUTHORIZED_RECEPTIONISTGIVENNAME","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtReceptionistGivenName_Visible","ctrl":"RECEPTIONISTGIVENNAME","prop":"Visible"},{"av":"edtReceptionistLastName_Visible","ctrl":"RECEPTIONISTLASTNAME","prop":"Visible"},{"av":"edtReceptionistEmail_Visible","ctrl":"RECEPTIONISTEMAIL","prop":"Visible"},{"av":"edtReceptionistPhone_Visible","ctrl":"RECEPTIONISTPHONE","prop":"Visible"},{"av":"chkReceptionistIsActive.Visible","ctrl":"RECEPTIONISTISACTIVE","prop":"Visible"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"chkReceptionistIsActive_Columnheaderclass","ctrl":"RECEPTIONISTISACTIVE","prop":"Columnheaderclass"},{"av":"AV41IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV43IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV45IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV46IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E144R2","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Actiongroup","iparms":[]}""");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV58ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV60Pgmname = "";
         AV20TFReceptionistGivenName = "";
         AV21TFReceptionistGivenName_Sel = "";
         AV22TFReceptionistLastName = "";
         AV23TFReceptionistLastName_Sel = "";
         AV26TFReceptionistEmail = "";
         AV27TFReceptionistEmail_Sel = "";
         AV28TFReceptionistPhone = "";
         AV29TFReceptionistPhone_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV38GridAppliedFilters = "";
         AV32DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A89ReceptionistId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A90ReceptionistGivenName = "";
         A91ReceptionistLastName = "";
         A92ReceptionistInitials = "";
         A93ReceptionistEmail = "";
         A373ReceptionistPhoneCode = "";
         A94ReceptionistPhone = "";
         A374ReceptionistPhoneNumber = "";
         A95ReceptionistGAMGUID = "";
         lV61Trn_receptionistwwds_1_filterfulltext = "";
         lV62Trn_receptionistwwds_2_tfreceptionistgivenname = "";
         lV64Trn_receptionistwwds_4_tfreceptionistlastname = "";
         lV66Trn_receptionistwwds_6_tfreceptionistemail = "";
         lV68Trn_receptionistwwds_8_tfreceptionistphone = "";
         AV61Trn_receptionistwwds_1_filterfulltext = "";
         AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel = "";
         AV62Trn_receptionistwwds_2_tfreceptionistgivenname = "";
         AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel = "";
         AV64Trn_receptionistwwds_4_tfreceptionistlastname = "";
         AV67Trn_receptionistwwds_7_tfreceptionistemail_sel = "";
         AV66Trn_receptionistwwds_6_tfreceptionistemail = "";
         AV69Trn_receptionistwwds_9_tfreceptionistphone_sel = "";
         AV68Trn_receptionistwwds_8_tfreceptionistphone = "";
         H004R2_A398ReceptionistIsActive = new bool[] {false} ;
         H004R2_A95ReceptionistGAMGUID = new string[] {""} ;
         H004R2_A374ReceptionistPhoneNumber = new string[] {""} ;
         H004R2_A94ReceptionistPhone = new string[] {""} ;
         H004R2_A373ReceptionistPhoneCode = new string[] {""} ;
         H004R2_A93ReceptionistEmail = new string[] {""} ;
         H004R2_A92ReceptionistInitials = new string[] {""} ;
         H004R2_A91ReceptionistLastName = new string[] {""} ;
         H004R2_A90ReceptionistGivenName = new string[] {""} ;
         H004R2_A29LocationId = new Guid[] {Guid.Empty} ;
         H004R2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H004R2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         H004R3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV33GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV34GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16Session = context.GetSession();
         AV56ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         AV57UserCustomValue = "";
         AV59ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
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
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionistww__default(),
            new Object[][] {
                new Object[] {
               H004R2_A398ReceptionistIsActive, H004R2_A95ReceptionistGAMGUID, H004R2_A374ReceptionistPhoneNumber, H004R2_A94ReceptionistPhone, H004R2_A373ReceptionistPhoneCode, H004R2_A93ReceptionistEmail, H004R2_A92ReceptionistInitials, H004R2_A91ReceptionistLastName, H004R2_A90ReceptionistGivenName, H004R2_A29LocationId,
               H004R2_A11OrganisationId, H004R2_A89ReceptionistId
               }
               , new Object[] {
               H004R3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV60Pgmname = "Trn_ReceptionistWW";
         /* GeneXus formulas. */
         AV60Pgmname = "Trn_ReceptionistWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV19ManageFiltersExecutionStep ;
      private short AV52TFReceptionistIsActive_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV54ActionGroup ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_39 ;
      private int nGXsfl_39_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtReceptionistId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtReceptionistGivenName_Enabled ;
      private int edtReceptionistLastName_Enabled ;
      private int edtReceptionistInitials_Enabled ;
      private int edtReceptionistEmail_Enabled ;
      private int edtReceptionistPhoneCode_Enabled ;
      private int edtReceptionistPhone_Enabled ;
      private int edtReceptionistPhoneNumber_Enabled ;
      private int edtReceptionistGAMGUID_Enabled ;
      private int edtReceptionistGivenName_Visible ;
      private int edtReceptionistLastName_Visible ;
      private int edtReceptionistEmail_Visible ;
      private int edtReceptionistPhone_Visible ;
      private int AV35PageToGo ;
      private int AV71GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV36GridCurrentPage ;
      private long AV37GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV60Pgmname ;
      private string AV28TFReceptionistPhone ;
      private string AV29TFReceptionistPhone_Sel ;
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
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
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
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
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
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtReceptionistId_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string edtLocationId_Internalname ;
      private string edtReceptionistGivenName_Internalname ;
      private string edtReceptionistLastName_Internalname ;
      private string A92ReceptionistInitials ;
      private string edtReceptionistInitials_Internalname ;
      private string edtReceptionistEmail_Internalname ;
      private string edtReceptionistPhoneCode_Internalname ;
      private string A94ReceptionistPhone ;
      private string edtReceptionistPhone_Internalname ;
      private string edtReceptionistPhoneNumber_Internalname ;
      private string edtReceptionistGAMGUID_Internalname ;
      private string chkReceptionistIsActive_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string lV68Trn_receptionistwwds_8_tfreceptionistphone ;
      private string AV69Trn_receptionistwwds_9_tfreceptionistphone_sel ;
      private string AV68Trn_receptionistwwds_8_tfreceptionistphone ;
      private string chkReceptionistIsActive_Columnheaderclass ;
      private string cmbavActiongroup_Class ;
      private string edtReceptionistGivenName_Link ;
      private string GXEncryptionTmp ;
      private string chkReceptionistIsActive_Columnclass ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtReceptionistId_Jsonclick ;
      private string edtOrganisationId_Jsonclick ;
      private string edtLocationId_Jsonclick ;
      private string edtReceptionistGivenName_Jsonclick ;
      private string edtReceptionistLastName_Jsonclick ;
      private string edtReceptionistInitials_Jsonclick ;
      private string edtReceptionistEmail_Jsonclick ;
      private string edtReceptionistPhoneCode_Jsonclick ;
      private string gxphoneLink ;
      private string edtReceptionistPhone_Jsonclick ;
      private string edtReceptionistPhoneNumber_Jsonclick ;
      private string edtReceptionistGAMGUID_Jsonclick ;
      private string GXCCtl ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV41IsAuthorized_Display ;
      private bool AV43IsAuthorized_Update ;
      private bool AV45IsAuthorized_Delete ;
      private bool AV39IsAuthorized_ReceptionistGivenName ;
      private bool AV46IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A398ReceptionistIsActive ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean1 ;
      private string AV56ColumnsSelectorXML ;
      private string AV18ManageFiltersXml ;
      private string AV57UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV20TFReceptionistGivenName ;
      private string AV21TFReceptionistGivenName_Sel ;
      private string AV22TFReceptionistLastName ;
      private string AV23TFReceptionistLastName_Sel ;
      private string AV26TFReceptionistEmail ;
      private string AV27TFReceptionistEmail_Sel ;
      private string AV38GridAppliedFilters ;
      private string A90ReceptionistGivenName ;
      private string A91ReceptionistLastName ;
      private string A93ReceptionistEmail ;
      private string A373ReceptionistPhoneCode ;
      private string A374ReceptionistPhoneNumber ;
      private string A95ReceptionistGAMGUID ;
      private string lV61Trn_receptionistwwds_1_filterfulltext ;
      private string lV62Trn_receptionistwwds_2_tfreceptionistgivenname ;
      private string lV64Trn_receptionistwwds_4_tfreceptionistlastname ;
      private string lV66Trn_receptionistwwds_6_tfreceptionistemail ;
      private string AV61Trn_receptionistwwds_1_filterfulltext ;
      private string AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel ;
      private string AV62Trn_receptionistwwds_2_tfreceptionistgivenname ;
      private string AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel ;
      private string AV64Trn_receptionistwwds_4_tfreceptionistlastname ;
      private string AV67Trn_receptionistwwds_7_tfreceptionistemail_sel ;
      private string AV66Trn_receptionistwwds_6_tfreceptionistemail ;
      private Guid A89ReceptionistId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private IGxSession AV16Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkReceptionistIsActive ;
      private GXCombobox cmbavActiongroup ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV58ColumnsSelector ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV32DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private bool[] H004R2_A398ReceptionistIsActive ;
      private string[] H004R2_A95ReceptionistGAMGUID ;
      private string[] H004R2_A374ReceptionistPhoneNumber ;
      private string[] H004R2_A94ReceptionistPhone ;
      private string[] H004R2_A373ReceptionistPhoneCode ;
      private string[] H004R2_A93ReceptionistEmail ;
      private string[] H004R2_A92ReceptionistInitials ;
      private string[] H004R2_A91ReceptionistLastName ;
      private string[] H004R2_A90ReceptionistGivenName ;
      private Guid[] H004R2_A29LocationId ;
      private Guid[] H004R2_A11OrganisationId ;
      private Guid[] H004R2_A89ReceptionistId ;
      private long[] H004R3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV33GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV34GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV59ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_receptionistww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004R2( IGxContext context ,
                                             string AV61Trn_receptionistwwds_1_filterfulltext ,
                                             string AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                             string AV62Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                             string AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                             string AV64Trn_receptionistwwds_4_tfreceptionistlastname ,
                                             string AV67Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                             string AV66Trn_receptionistwwds_6_tfreceptionistemail ,
                                             string AV69Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                             string AV68Trn_receptionistwwds_8_tfreceptionistphone ,
                                             short AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                             string A90ReceptionistGivenName ,
                                             string A91ReceptionistLastName ,
                                             string A93ReceptionistEmail ,
                                             string A94ReceptionistPhone ,
                                             bool A398ReceptionistIsActive ,
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
         sSelectString = " ReceptionistIsActive, ReceptionistGAMGUID, ReceptionistPhoneNumber, ReceptionistPhone, ReceptionistPhoneCode, ReceptionistEmail, ReceptionistInitials, ReceptionistLastName, ReceptionistGivenName, LocationId, OrganisationId, ReceptionistId";
         sFromString = " FROM Trn_Receptionist";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_receptionistwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ReceptionistGivenName like '%' || :lV61Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistLastName like '%' || :lV61Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistEmail like '%' || :lV61Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistPhone like '%' || :lV61Trn_receptionistwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_2_tfreceptionistgivenname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName like :lV62Trn_receptionistwwds_2_tfreceptionistgivenname)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ! ( StringUtil.StrCmp(AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName = ( :AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_receptionistwwds_4_tfreceptionistlastname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName like :lV64Trn_receptionistwwds_4_tfreceptionistlastname)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName = ( :AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_receptionistwwds_6_tfreceptionistemail)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail like :lV66Trn_receptionistwwds_6_tfreceptionistemail)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ! ( StringUtil.StrCmp(AV67Trn_receptionistwwds_7_tfreceptionistemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail = ( :AV67Trn_receptionistwwds_7_tfreceptionistemail_sel))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_receptionistwwds_7_tfreceptionistemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_receptionistwwds_8_tfreceptionistphone)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone like :lV68Trn_receptionistwwds_8_tfreceptionistphone)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ! ( StringUtil.StrCmp(AV69Trn_receptionistwwds_9_tfreceptionistphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone = ( :AV69Trn_receptionistwwds_9_tfreceptionistphone_sel))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_receptionistwwds_9_tfreceptionistphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistPhone))=0))");
         }
         if ( AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = TRUE)");
         }
         if ( AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = FALSE)");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ReceptionistGivenName, ReceptionistId, OrganisationId, LocationId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ReceptionistGivenName DESC, ReceptionistId, OrganisationId, LocationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ReceptionistLastName, ReceptionistId, OrganisationId, LocationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ReceptionistLastName DESC, ReceptionistId, OrganisationId, LocationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ReceptionistEmail, ReceptionistId, OrganisationId, LocationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ReceptionistEmail DESC, ReceptionistId, OrganisationId, LocationId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ReceptionistPhone, ReceptionistId, OrganisationId, LocationId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ReceptionistPhone DESC, ReceptionistId, OrganisationId, LocationId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ReceptionistIsActive, ReceptionistId, OrganisationId, LocationId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ReceptionistIsActive DESC, ReceptionistId, OrganisationId, LocationId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY ReceptionistId, OrganisationId, LocationId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H004R3( IGxContext context ,
                                             string AV61Trn_receptionistwwds_1_filterfulltext ,
                                             string AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel ,
                                             string AV62Trn_receptionistwwds_2_tfreceptionistgivenname ,
                                             string AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel ,
                                             string AV64Trn_receptionistwwds_4_tfreceptionistlastname ,
                                             string AV67Trn_receptionistwwds_7_tfreceptionistemail_sel ,
                                             string AV66Trn_receptionistwwds_6_tfreceptionistemail ,
                                             string AV69Trn_receptionistwwds_9_tfreceptionistphone_sel ,
                                             string AV68Trn_receptionistwwds_8_tfreceptionistphone ,
                                             short AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel ,
                                             string A90ReceptionistGivenName ,
                                             string A91ReceptionistLastName ,
                                             string A93ReceptionistEmail ,
                                             string A94ReceptionistPhone ,
                                             bool A398ReceptionistIsActive ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[12];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Trn_Receptionist";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Trn_receptionistwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ReceptionistGivenName like '%' || :lV61Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistLastName like '%' || :lV61Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistEmail like '%' || :lV61Trn_receptionistwwds_1_filterfulltext) or ( ReceptionistPhone like '%' || :lV61Trn_receptionistwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_receptionistwwds_2_tfreceptionistgivenname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName like :lV62Trn_receptionistwwds_2_tfreceptionistgivenname)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel)) && ! ( StringUtil.StrCmp(AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistGivenName = ( :AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( StringUtil.StrCmp(AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_receptionistwwds_4_tfreceptionistlastname)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName like :lV64Trn_receptionistwwds_4_tfreceptionistlastname)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistLastName = ( :AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_receptionistwwds_6_tfreceptionistemail)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail like :lV66Trn_receptionistwwds_6_tfreceptionistemail)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_receptionistwwds_7_tfreceptionistemail_sel)) && ! ( StringUtil.StrCmp(AV67Trn_receptionistwwds_7_tfreceptionistemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistEmail = ( :AV67Trn_receptionistwwds_7_tfreceptionistemail_sel))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_receptionistwwds_7_tfreceptionistemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_receptionistwwds_8_tfreceptionistphone)) ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone like :lV68Trn_receptionistwwds_8_tfreceptionistphone)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_receptionistwwds_9_tfreceptionistphone_sel)) && ! ( StringUtil.StrCmp(AV69Trn_receptionistwwds_9_tfreceptionistphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ReceptionistPhone = ( :AV69Trn_receptionistwwds_9_tfreceptionistphone_sel))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_receptionistwwds_9_tfreceptionistphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ReceptionistPhone))=0))");
         }
         if ( AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = TRUE)");
         }
         if ( AV70Trn_receptionistwwds_10_tfreceptionistisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(ReceptionistIsActive = FALSE)");
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
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
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
                     return conditional_H004R2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] );
               case 1 :
                     return conditional_H004R3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] );
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
          Object[] prmH004R2;
          prmH004R2 = new Object[] {
          new ParDef("lV61Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_receptionistwwds_2_tfreceptionistgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_receptionistwwds_4_tfreceptionistlastname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_receptionistwwds_6_tfreceptionistemail",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_receptionistwwds_7_tfreceptionistemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_receptionistwwds_8_tfreceptionistphone",GXType.Char,20,0) ,
          new ParDef("AV69Trn_receptionistwwds_9_tfreceptionistphone_sel",GXType.Char,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004R3;
          prmH004R3 = new Object[] {
          new ParDef("lV61Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Trn_receptionistwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_receptionistwwds_2_tfreceptionistgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV63Trn_receptionistwwds_3_tfreceptionistgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_receptionistwwds_4_tfreceptionistlastname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_receptionistwwds_5_tfreceptionistlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_receptionistwwds_6_tfreceptionistemail",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_receptionistwwds_7_tfreceptionistemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_receptionistwwds_8_tfreceptionistphone",GXType.Char,20,0) ,
          new ParDef("AV69Trn_receptionistwwds_9_tfreceptionistphone_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[9])[0] = rslt.getGuid(10);
                ((Guid[]) buf[10])[0] = rslt.getGuid(11);
                ((Guid[]) buf[11])[0] = rslt.getGuid(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
