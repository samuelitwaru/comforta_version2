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
   public class trn_residentww : GXDataArea
   {
      public trn_residentww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentww( IGxContext context )
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
         cmbResidentSalutation = new GXCombobox();
         cmbResidentGender = new GXCombobox();
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
         AV61Pgmname = GetPar( "Pgmname");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21TFResidentSalutation_Sels);
         AV22TFResidentGivenName = GetPar( "TFResidentGivenName");
         AV23TFResidentGivenName_Sel = GetPar( "TFResidentGivenName_Sel");
         AV24TFResidentLastName = GetPar( "TFResidentLastName");
         AV25TFResidentLastName_Sel = GetPar( "TFResidentLastName_Sel");
         AV26TFResidentBsnNumber = GetPar( "TFResidentBsnNumber");
         AV27TFResidentBsnNumber_Sel = GetPar( "TFResidentBsnNumber_Sel");
         AV28TFResidentEmail = GetPar( "TFResidentEmail");
         AV29TFResidentEmail_Sel = GetPar( "TFResidentEmail_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV31TFResidentGender_Sels);
         AV32TFResidentPhone = GetPar( "TFResidentPhone");
         AV33TFResidentPhone_Sel = GetPar( "TFResidentPhone_Sel");
         AV34TFResidentBirthDate = context.localUtil.ParseDateParm( GetPar( "TFResidentBirthDate"));
         AV35TFResidentBirthDate_To = context.localUtil.ParseDateParm( GetPar( "TFResidentBirthDate_To"));
         AV39TFResidentTypeName = GetPar( "TFResidentTypeName");
         AV40TFResidentTypeName_Sel = GetPar( "TFResidentTypeName_Sel");
         AV41TFMedicalIndicationName = GetPar( "TFMedicalIndicationName");
         AV42TFMedicalIndicationName_Sel = GetPar( "TFMedicalIndicationName_Sel");
         AV52IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV54IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV56IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV50IsAuthorized_ResidentGivenName = StringUtil.StrToBool( GetPar( "IsAuthorized_ResidentGivenName"));
         AV60IsAuthorized_ResidentTypeName = StringUtil.StrToBool( GetPar( "IsAuthorized_ResidentTypeName"));
         AV59IsAuthorized_MedicalIndicationName = StringUtil.StrToBool( GetPar( "IsAuthorized_MedicalIndicationName"));
         AV57IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV61Pgmname, AV21TFResidentSalutation_Sels, AV22TFResidentGivenName, AV23TFResidentGivenName_Sel, AV24TFResidentLastName, AV25TFResidentLastName_Sel, AV26TFResidentBsnNumber, AV27TFResidentBsnNumber_Sel, AV28TFResidentEmail, AV29TFResidentEmail_Sel, AV31TFResidentGender_Sels, AV32TFResidentPhone, AV33TFResidentPhone_Sel, AV34TFResidentBirthDate, AV35TFResidentBirthDate_To, AV39TFResidentTypeName, AV40TFResidentTypeName_Sel, AV41TFMedicalIndicationName, AV42TFMedicalIndicationName_Sel, AV52IsAuthorized_Display, AV54IsAuthorized_Update, AV56IsAuthorized_Delete, AV50IsAuthorized_ResidentGivenName, AV60IsAuthorized_ResidentTypeName, AV59IsAuthorized_MedicalIndicationName, AV57IsAuthorized_Insert) ;
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
            return "trn_residentww_Execute" ;
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
         PA662( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START662( ) ;
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
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1918140), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_residentww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV52IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV52IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV54IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV54IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESIDENTGIVENNAME", AV50IsAuthorized_ResidentGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTGIVENNAME", GetSecureSignedToken( "", AV50IsAuthorized_ResidentGivenName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESIDENTTYPENAME", AV60IsAuthorized_ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTTYPENAME", GetSecureSignedToken( "", AV60IsAuthorized_ResidentTypeName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MEDICALINDICATIONNAME", AV59IsAuthorized_MedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MEDICALINDICATIONNAME", GetSecureSignedToken( "", AV59IsAuthorized_MedicalIndicationName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV49GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV43DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV43DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_RESIDENTBIRTHDATEAUXDATE", context.localUtil.DToC( AV36DDO_ResidentBirthDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_RESIDENTBIRTHDATEAUXDATETO", context.localUtil.DToC( AV37DDO_ResidentBirthDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFRESIDENTSALUTATION_SELS", AV21TFResidentSalutation_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFRESIDENTSALUTATION_SELS", AV21TFResidentSalutation_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTGIVENNAME", AV22TFResidentGivenName);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTGIVENNAME_SEL", AV23TFResidentGivenName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTLASTNAME", AV24TFResidentLastName);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTLASTNAME_SEL", AV25TFResidentLastName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTBSNNUMBER", AV26TFResidentBsnNumber);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTBSNNUMBER_SEL", AV27TFResidentBsnNumber_Sel);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTEMAIL", AV28TFResidentEmail);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTEMAIL_SEL", AV29TFResidentEmail_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFRESIDENTGENDER_SELS", AV31TFResidentGender_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFRESIDENTGENDER_SELS", AV31TFResidentGender_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTPHONE", StringUtil.RTrim( AV32TFResidentPhone));
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTPHONE_SEL", StringUtil.RTrim( AV33TFResidentPhone_Sel));
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTBIRTHDATE", context.localUtil.DToC( AV34TFResidentBirthDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTBIRTHDATE_TO", context.localUtil.DToC( AV35TFResidentBirthDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTTYPENAME", AV39TFResidentTypeName);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTTYPENAME_SEL", AV40TFResidentTypeName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMEDICALINDICATIONNAME", AV41TFMedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "vTFMEDICALINDICATIONNAME_SEL", AV42TFMedicalIndicationName_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV52IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV52IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV54IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV54IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESIDENTGIVENNAME", AV50IsAuthorized_ResidentGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTGIVENNAME", GetSecureSignedToken( "", AV50IsAuthorized_ResidentGivenName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESIDENTTYPENAME", AV60IsAuthorized_ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTTYPENAME", GetSecureSignedToken( "", AV60IsAuthorized_ResidentTypeName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MEDICALINDICATIONNAME", AV59IsAuthorized_MedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MEDICALINDICATIONNAME", GetSecureSignedToken( "", AV59IsAuthorized_MedicalIndicationName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTSALUTATION_SELSJSON", AV20TFResidentSalutation_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFRESIDENTGENDER_SELSJSON", AV30TFResidentGender_SelsJson);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE662( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT662( ) ;
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
         return formatLink("trn_residentww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_ResidentWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Residents" ;
      }

      protected void WB660( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Subscriptions", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ResidentWW.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_Trn_ResidentWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV47GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV48GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV49GridAppliedFilters);
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
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV43DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0073"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0073"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_37_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0073"+"");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_residentbirthdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_residentbirthdateauxdatetext_Internalname, AV38DDO_ResidentBirthDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV38DDO_ResidentBirthDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_residentbirthdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ResidentWW.htm");
            /* User Defined Control */
            ucTfresidentbirthdate_rangepicker.SetProperty("Start Date", AV36DDO_ResidentBirthDateAuxDate);
            ucTfresidentbirthdate_rangepicker.SetProperty("End Date", AV37DDO_ResidentBirthDateAuxDateTo);
            ucTfresidentbirthdate_rangepicker.Render(context, "wwp.daterangepicker", Tfresidentbirthdate_rangepicker_Internalname, "TFRESIDENTBIRTHDATE_RANGEPICKERContainer");
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

      protected void START662( )
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
         Form.Meta.addItem("description", " Residents", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP660( ) ;
      }

      protected void WS662( )
      {
         START662( ) ;
         EVT662( ) ;
      }

      protected void EVT662( )
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
                              E11662 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12662 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13662 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E14662 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E15662 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E16662 ();
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
                              A62ResidentId = StringUtil.StrToGuid( cgiGet( edtResidentId_Internalname));
                              A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              cmbResidentSalutation.Name = cmbResidentSalutation_Internalname;
                              cmbResidentSalutation.CurrentValue = cgiGet( cmbResidentSalutation_Internalname);
                              A72ResidentSalutation = cgiGet( cmbResidentSalutation_Internalname);
                              A64ResidentGivenName = cgiGet( edtResidentGivenName_Internalname);
                              A65ResidentLastName = cgiGet( edtResidentLastName_Internalname);
                              A66ResidentInitials = cgiGet( edtResidentInitials_Internalname);
                              A63ResidentBsnNumber = cgiGet( edtResidentBsnNumber_Internalname);
                              A67ResidentEmail = cgiGet( edtResidentEmail_Internalname);
                              cmbResidentGender.Name = cmbResidentGender_Internalname;
                              cmbResidentGender.CurrentValue = cgiGet( cmbResidentGender_Internalname);
                              A68ResidentGender = cgiGet( cmbResidentGender_Internalname);
                              A70ResidentPhone = cgiGet( edtResidentPhone_Internalname);
                              A73ResidentBirthDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtResidentBirthDate_Internalname), 0));
                              A71ResidentGUID = cgiGet( edtResidentGUID_Internalname);
                              A96ResidentTypeId = StringUtil.StrToGuid( cgiGet( edtResidentTypeId_Internalname));
                              A97ResidentTypeName = cgiGet( edtResidentTypeName_Internalname);
                              A98MedicalIndicationId = StringUtil.StrToGuid( cgiGet( edtMedicalIndicationId_Internalname));
                              A99MedicalIndicationName = cgiGet( edtMedicalIndicationName_Internalname);
                              AV51Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV51Display);
                              AV53Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV53Update);
                              AV55Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV55Delete);
                              A354ResidentCountry = cgiGet( edtResidentCountry_Internalname);
                              A355ResidentCity = cgiGet( edtResidentCity_Internalname);
                              A356ResidentZipCode = cgiGet( edtResidentZipCode_Internalname);
                              A357ResidentAddressLine1 = cgiGet( edtResidentAddressLine1_Internalname);
                              A358ResidentAddressLine2 = cgiGet( edtResidentAddressLine2_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17662 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E18662 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E19662 ();
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
                        if ( nCmpId == 73 )
                        {
                           OldWwpaux_wc = cgiGet( "W0073");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0073", "", sEvt);
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

      protected void WE662( )
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

      protected void PA662( )
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
                                       string AV61Pgmname ,
                                       GxSimpleCollection<string> AV21TFResidentSalutation_Sels ,
                                       string AV22TFResidentGivenName ,
                                       string AV23TFResidentGivenName_Sel ,
                                       string AV24TFResidentLastName ,
                                       string AV25TFResidentLastName_Sel ,
                                       string AV26TFResidentBsnNumber ,
                                       string AV27TFResidentBsnNumber_Sel ,
                                       string AV28TFResidentEmail ,
                                       string AV29TFResidentEmail_Sel ,
                                       GxSimpleCollection<string> AV31TFResidentGender_Sels ,
                                       string AV32TFResidentPhone ,
                                       string AV33TFResidentPhone_Sel ,
                                       DateTime AV34TFResidentBirthDate ,
                                       DateTime AV35TFResidentBirthDate_To ,
                                       string AV39TFResidentTypeName ,
                                       string AV40TFResidentTypeName_Sel ,
                                       string AV41TFMedicalIndicationName ,
                                       string AV42TFMedicalIndicationName_Sel ,
                                       bool AV52IsAuthorized_Display ,
                                       bool AV54IsAuthorized_Update ,
                                       bool AV56IsAuthorized_Delete ,
                                       bool AV50IsAuthorized_ResidentGivenName ,
                                       bool AV60IsAuthorized_ResidentTypeName ,
                                       bool AV59IsAuthorized_MedicalIndicationName ,
                                       bool AV57IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF662( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESIDENTID", GetSecureSignedToken( "", A62ResidentId, context));
         GxWebStd.gx_hidden_field( context, "RESIDENTID", A62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID", GetSecureSignedToken( "", A29LocationId, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
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
         RF662( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV61Pgmname = "Trn_ResidentWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF662( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E18662 ();
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
                                                 A72ResidentSalutation ,
                                                 AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                                 A68ResidentGender ,
                                                 AV72Trn_residentwwds_11_tfresidentgender_sels ,
                                                 AV62Trn_residentwwds_1_filterfulltext ,
                                                 AV63Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                                 AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                                 AV64Trn_residentwwds_3_tfresidentgivenname ,
                                                 AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                                 AV66Trn_residentwwds_5_tfresidentlastname ,
                                                 AV69Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                                 AV68Trn_residentwwds_7_tfresidentbsnnumber ,
                                                 AV71Trn_residentwwds_10_tfresidentemail_sel ,
                                                 AV70Trn_residentwwds_9_tfresidentemail ,
                                                 AV72Trn_residentwwds_11_tfresidentgender_sels.Count ,
                                                 AV74Trn_residentwwds_13_tfresidentphone_sel ,
                                                 AV73Trn_residentwwds_12_tfresidentphone ,
                                                 AV75Trn_residentwwds_14_tfresidentbirthdate ,
                                                 AV76Trn_residentwwds_15_tfresidentbirthdate_to ,
                                                 AV78Trn_residentwwds_17_tfresidenttypename_sel ,
                                                 AV77Trn_residentwwds_16_tfresidenttypename ,
                                                 AV80Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                                 AV79Trn_residentwwds_18_tfmedicalindicationname ,
                                                 A64ResidentGivenName ,
                                                 A65ResidentLastName ,
                                                 A63ResidentBsnNumber ,
                                                 A67ResidentEmail ,
                                                 A70ResidentPhone ,
                                                 A97ResidentTypeName ,
                                                 A99MedicalIndicationName ,
                                                 A73ResidentBirthDate ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
            lV64Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname), "%", "");
            lV66Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname), "%", "");
            lV68Trn_residentwwds_7_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV68Trn_residentwwds_7_tfresidentbsnnumber), "%", "");
            lV70Trn_residentwwds_9_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail), "%", "");
            lV73Trn_residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidentphone), 20, "%");
            lV77Trn_residentwwds_16_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV77Trn_residentwwds_16_tfresidenttypename), "%", "");
            lV79Trn_residentwwds_18_tfmedicalindicationname = StringUtil.Concat( StringUtil.RTrim( AV79Trn_residentwwds_18_tfmedicalindicationname), "%", "");
            /* Using cursor H00662 */
            pr_default.execute(0, new Object[] {lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV64Trn_residentwwds_3_tfresidentgivenname, AV65Trn_residentwwds_4_tfresidentgivenname_sel, lV66Trn_residentwwds_5_tfresidentlastname, AV67Trn_residentwwds_6_tfresidentlastname_sel, lV68Trn_residentwwds_7_tfresidentbsnnumber, AV69Trn_residentwwds_8_tfresidentbsnnumber_sel, lV70Trn_residentwwds_9_tfresidentemail, AV71Trn_residentwwds_10_tfresidentemail_sel, lV73Trn_residentwwds_12_tfresidentphone, AV74Trn_residentwwds_13_tfresidentphone_sel, AV75Trn_residentwwds_14_tfresidentbirthdate, AV76Trn_residentwwds_15_tfresidentbirthdate_to, lV77Trn_residentwwds_16_tfresidenttypename, AV78Trn_residentwwds_17_tfresidenttypename_sel, lV79Trn_residentwwds_18_tfmedicalindicationname, AV80Trn_residentwwds_19_tfmedicalindicationname_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A358ResidentAddressLine2 = H00662_A358ResidentAddressLine2[0];
               A357ResidentAddressLine1 = H00662_A357ResidentAddressLine1[0];
               A356ResidentZipCode = H00662_A356ResidentZipCode[0];
               A355ResidentCity = H00662_A355ResidentCity[0];
               A354ResidentCountry = H00662_A354ResidentCountry[0];
               A99MedicalIndicationName = H00662_A99MedicalIndicationName[0];
               A98MedicalIndicationId = H00662_A98MedicalIndicationId[0];
               A97ResidentTypeName = H00662_A97ResidentTypeName[0];
               A96ResidentTypeId = H00662_A96ResidentTypeId[0];
               A71ResidentGUID = H00662_A71ResidentGUID[0];
               A73ResidentBirthDate = H00662_A73ResidentBirthDate[0];
               A70ResidentPhone = H00662_A70ResidentPhone[0];
               A68ResidentGender = H00662_A68ResidentGender[0];
               A67ResidentEmail = H00662_A67ResidentEmail[0];
               A63ResidentBsnNumber = H00662_A63ResidentBsnNumber[0];
               A66ResidentInitials = H00662_A66ResidentInitials[0];
               A65ResidentLastName = H00662_A65ResidentLastName[0];
               A64ResidentGivenName = H00662_A64ResidentGivenName[0];
               A72ResidentSalutation = H00662_A72ResidentSalutation[0];
               A11OrganisationId = H00662_A11OrganisationId[0];
               A29LocationId = H00662_A29LocationId[0];
               A62ResidentId = H00662_A62ResidentId[0];
               A99MedicalIndicationName = H00662_A99MedicalIndicationName[0];
               A97ResidentTypeName = H00662_A97ResidentTypeName[0];
               /* Execute user event: Grid.Load */
               E19662 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB660( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes662( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV52IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV52IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV54IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV54IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESIDENTGIVENNAME", AV50IsAuthorized_ResidentGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTGIVENNAME", GetSecureSignedToken( "", AV50IsAuthorized_ResidentGivenName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RESIDENTTYPENAME", AV60IsAuthorized_ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTTYPENAME", GetSecureSignedToken( "", AV60IsAuthorized_ResidentTypeName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MEDICALINDICATIONNAME", AV59IsAuthorized_MedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MEDICALINDICATIONNAME", GetSecureSignedToken( "", AV59IsAuthorized_MedicalIndicationName, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_RESIDENTID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A62ResidentId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A29LocationId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, A11OrganisationId, context));
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
         AV62Trn_residentwwds_1_filterfulltext = AV15FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV21TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV22TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV23TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV24TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV25TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentbsnnumber = AV26TFResidentBsnNumber;
         AV69Trn_residentwwds_8_tfresidentbsnnumber_sel = AV27TFResidentBsnNumber_Sel;
         AV70Trn_residentwwds_9_tfresidentemail = AV28TFResidentEmail;
         AV71Trn_residentwwds_10_tfresidentemail_sel = AV29TFResidentEmail_Sel;
         AV72Trn_residentwwds_11_tfresidentgender_sels = AV31TFResidentGender_Sels;
         AV73Trn_residentwwds_12_tfresidentphone = AV32TFResidentPhone;
         AV74Trn_residentwwds_13_tfresidentphone_sel = AV33TFResidentPhone_Sel;
         AV75Trn_residentwwds_14_tfresidentbirthdate = AV34TFResidentBirthDate;
         AV76Trn_residentwwds_15_tfresidentbirthdate_to = AV35TFResidentBirthDate_To;
         AV77Trn_residentwwds_16_tfresidenttypename = AV39TFResidentTypeName;
         AV78Trn_residentwwds_17_tfresidenttypename_sel = AV40TFResidentTypeName_Sel;
         AV79Trn_residentwwds_18_tfmedicalindicationname = AV41TFMedicalIndicationName;
         AV80Trn_residentwwds_19_tfmedicalindicationname_sel = AV42TFMedicalIndicationName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A72ResidentSalutation ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                              A68ResidentGender ,
                                              AV72Trn_residentwwds_11_tfresidentgender_sels ,
                                              AV62Trn_residentwwds_1_filterfulltext ,
                                              AV63Trn_residentwwds_2_tfresidentsalutation_sels.Count ,
                                              AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                              AV64Trn_residentwwds_3_tfresidentgivenname ,
                                              AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                              AV66Trn_residentwwds_5_tfresidentlastname ,
                                              AV69Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                              AV68Trn_residentwwds_7_tfresidentbsnnumber ,
                                              AV71Trn_residentwwds_10_tfresidentemail_sel ,
                                              AV70Trn_residentwwds_9_tfresidentemail ,
                                              AV72Trn_residentwwds_11_tfresidentgender_sels.Count ,
                                              AV74Trn_residentwwds_13_tfresidentphone_sel ,
                                              AV73Trn_residentwwds_12_tfresidentphone ,
                                              AV75Trn_residentwwds_14_tfresidentbirthdate ,
                                              AV76Trn_residentwwds_15_tfresidentbirthdate_to ,
                                              AV78Trn_residentwwds_17_tfresidenttypename_sel ,
                                              AV77Trn_residentwwds_16_tfresidenttypename ,
                                              AV80Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                              AV79Trn_residentwwds_18_tfmedicalindicationname ,
                                              A64ResidentGivenName ,
                                              A65ResidentLastName ,
                                              A63ResidentBsnNumber ,
                                              A67ResidentEmail ,
                                              A70ResidentPhone ,
                                              A97ResidentTypeName ,
                                              A99MedicalIndicationName ,
                                              A73ResidentBirthDate ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV62Trn_residentwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext), "%", "");
         lV64Trn_residentwwds_3_tfresidentgivenname = StringUtil.Concat( StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname), "%", "");
         lV66Trn_residentwwds_5_tfresidentlastname = StringUtil.Concat( StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname), "%", "");
         lV68Trn_residentwwds_7_tfresidentbsnnumber = StringUtil.Concat( StringUtil.RTrim( AV68Trn_residentwwds_7_tfresidentbsnnumber), "%", "");
         lV70Trn_residentwwds_9_tfresidentemail = StringUtil.Concat( StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail), "%", "");
         lV73Trn_residentwwds_12_tfresidentphone = StringUtil.PadR( StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidentphone), 20, "%");
         lV77Trn_residentwwds_16_tfresidenttypename = StringUtil.Concat( StringUtil.RTrim( AV77Trn_residentwwds_16_tfresidenttypename), "%", "");
         lV79Trn_residentwwds_18_tfmedicalindicationname = StringUtil.Concat( StringUtil.RTrim( AV79Trn_residentwwds_18_tfmedicalindicationname), "%", "");
         /* Using cursor H00663 */
         pr_default.execute(1, new Object[] {lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV62Trn_residentwwds_1_filterfulltext, lV64Trn_residentwwds_3_tfresidentgivenname, AV65Trn_residentwwds_4_tfresidentgivenname_sel, lV66Trn_residentwwds_5_tfresidentlastname, AV67Trn_residentwwds_6_tfresidentlastname_sel, lV68Trn_residentwwds_7_tfresidentbsnnumber, AV69Trn_residentwwds_8_tfresidentbsnnumber_sel, lV70Trn_residentwwds_9_tfresidentemail, AV71Trn_residentwwds_10_tfresidentemail_sel, lV73Trn_residentwwds_12_tfresidentphone, AV74Trn_residentwwds_13_tfresidentphone_sel, AV75Trn_residentwwds_14_tfresidentbirthdate, AV76Trn_residentwwds_15_tfresidentbirthdate_to, lV77Trn_residentwwds_16_tfresidenttypename, AV78Trn_residentwwds_17_tfresidenttypename_sel, lV79Trn_residentwwds_18_tfmedicalindicationname, AV80Trn_residentwwds_19_tfmedicalindicationname_sel});
         GRID_nRecordCount = H00663_AGRID_nRecordCount[0];
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
         AV62Trn_residentwwds_1_filterfulltext = AV15FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV21TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV22TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV23TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV24TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV25TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentbsnnumber = AV26TFResidentBsnNumber;
         AV69Trn_residentwwds_8_tfresidentbsnnumber_sel = AV27TFResidentBsnNumber_Sel;
         AV70Trn_residentwwds_9_tfresidentemail = AV28TFResidentEmail;
         AV71Trn_residentwwds_10_tfresidentemail_sel = AV29TFResidentEmail_Sel;
         AV72Trn_residentwwds_11_tfresidentgender_sels = AV31TFResidentGender_Sels;
         AV73Trn_residentwwds_12_tfresidentphone = AV32TFResidentPhone;
         AV74Trn_residentwwds_13_tfresidentphone_sel = AV33TFResidentPhone_Sel;
         AV75Trn_residentwwds_14_tfresidentbirthdate = AV34TFResidentBirthDate;
         AV76Trn_residentwwds_15_tfresidentbirthdate_to = AV35TFResidentBirthDate_To;
         AV77Trn_residentwwds_16_tfresidenttypename = AV39TFResidentTypeName;
         AV78Trn_residentwwds_17_tfresidenttypename_sel = AV40TFResidentTypeName_Sel;
         AV79Trn_residentwwds_18_tfmedicalindicationname = AV41TFMedicalIndicationName;
         AV80Trn_residentwwds_19_tfmedicalindicationname_sel = AV42TFMedicalIndicationName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV61Pgmname, AV21TFResidentSalutation_Sels, AV22TFResidentGivenName, AV23TFResidentGivenName_Sel, AV24TFResidentLastName, AV25TFResidentLastName_Sel, AV26TFResidentBsnNumber, AV27TFResidentBsnNumber_Sel, AV28TFResidentEmail, AV29TFResidentEmail_Sel, AV31TFResidentGender_Sels, AV32TFResidentPhone, AV33TFResidentPhone_Sel, AV34TFResidentBirthDate, AV35TFResidentBirthDate_To, AV39TFResidentTypeName, AV40TFResidentTypeName_Sel, AV41TFMedicalIndicationName, AV42TFMedicalIndicationName_Sel, AV52IsAuthorized_Display, AV54IsAuthorized_Update, AV56IsAuthorized_Delete, AV50IsAuthorized_ResidentGivenName, AV60IsAuthorized_ResidentTypeName, AV59IsAuthorized_MedicalIndicationName, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV62Trn_residentwwds_1_filterfulltext = AV15FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV21TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV22TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV23TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV24TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV25TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentbsnnumber = AV26TFResidentBsnNumber;
         AV69Trn_residentwwds_8_tfresidentbsnnumber_sel = AV27TFResidentBsnNumber_Sel;
         AV70Trn_residentwwds_9_tfresidentemail = AV28TFResidentEmail;
         AV71Trn_residentwwds_10_tfresidentemail_sel = AV29TFResidentEmail_Sel;
         AV72Trn_residentwwds_11_tfresidentgender_sels = AV31TFResidentGender_Sels;
         AV73Trn_residentwwds_12_tfresidentphone = AV32TFResidentPhone;
         AV74Trn_residentwwds_13_tfresidentphone_sel = AV33TFResidentPhone_Sel;
         AV75Trn_residentwwds_14_tfresidentbirthdate = AV34TFResidentBirthDate;
         AV76Trn_residentwwds_15_tfresidentbirthdate_to = AV35TFResidentBirthDate_To;
         AV77Trn_residentwwds_16_tfresidenttypename = AV39TFResidentTypeName;
         AV78Trn_residentwwds_17_tfresidenttypename_sel = AV40TFResidentTypeName_Sel;
         AV79Trn_residentwwds_18_tfmedicalindicationname = AV41TFMedicalIndicationName;
         AV80Trn_residentwwds_19_tfmedicalindicationname_sel = AV42TFMedicalIndicationName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV61Pgmname, AV21TFResidentSalutation_Sels, AV22TFResidentGivenName, AV23TFResidentGivenName_Sel, AV24TFResidentLastName, AV25TFResidentLastName_Sel, AV26TFResidentBsnNumber, AV27TFResidentBsnNumber_Sel, AV28TFResidentEmail, AV29TFResidentEmail_Sel, AV31TFResidentGender_Sels, AV32TFResidentPhone, AV33TFResidentPhone_Sel, AV34TFResidentBirthDate, AV35TFResidentBirthDate_To, AV39TFResidentTypeName, AV40TFResidentTypeName_Sel, AV41TFMedicalIndicationName, AV42TFMedicalIndicationName_Sel, AV52IsAuthorized_Display, AV54IsAuthorized_Update, AV56IsAuthorized_Delete, AV50IsAuthorized_ResidentGivenName, AV60IsAuthorized_ResidentTypeName, AV59IsAuthorized_MedicalIndicationName, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV62Trn_residentwwds_1_filterfulltext = AV15FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV21TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV22TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV23TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV24TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV25TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentbsnnumber = AV26TFResidentBsnNumber;
         AV69Trn_residentwwds_8_tfresidentbsnnumber_sel = AV27TFResidentBsnNumber_Sel;
         AV70Trn_residentwwds_9_tfresidentemail = AV28TFResidentEmail;
         AV71Trn_residentwwds_10_tfresidentemail_sel = AV29TFResidentEmail_Sel;
         AV72Trn_residentwwds_11_tfresidentgender_sels = AV31TFResidentGender_Sels;
         AV73Trn_residentwwds_12_tfresidentphone = AV32TFResidentPhone;
         AV74Trn_residentwwds_13_tfresidentphone_sel = AV33TFResidentPhone_Sel;
         AV75Trn_residentwwds_14_tfresidentbirthdate = AV34TFResidentBirthDate;
         AV76Trn_residentwwds_15_tfresidentbirthdate_to = AV35TFResidentBirthDate_To;
         AV77Trn_residentwwds_16_tfresidenttypename = AV39TFResidentTypeName;
         AV78Trn_residentwwds_17_tfresidenttypename_sel = AV40TFResidentTypeName_Sel;
         AV79Trn_residentwwds_18_tfmedicalindicationname = AV41TFMedicalIndicationName;
         AV80Trn_residentwwds_19_tfmedicalindicationname_sel = AV42TFMedicalIndicationName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV61Pgmname, AV21TFResidentSalutation_Sels, AV22TFResidentGivenName, AV23TFResidentGivenName_Sel, AV24TFResidentLastName, AV25TFResidentLastName_Sel, AV26TFResidentBsnNumber, AV27TFResidentBsnNumber_Sel, AV28TFResidentEmail, AV29TFResidentEmail_Sel, AV31TFResidentGender_Sels, AV32TFResidentPhone, AV33TFResidentPhone_Sel, AV34TFResidentBirthDate, AV35TFResidentBirthDate_To, AV39TFResidentTypeName, AV40TFResidentTypeName_Sel, AV41TFMedicalIndicationName, AV42TFMedicalIndicationName_Sel, AV52IsAuthorized_Display, AV54IsAuthorized_Update, AV56IsAuthorized_Delete, AV50IsAuthorized_ResidentGivenName, AV60IsAuthorized_ResidentTypeName, AV59IsAuthorized_MedicalIndicationName, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV62Trn_residentwwds_1_filterfulltext = AV15FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV21TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV22TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV23TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV24TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV25TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentbsnnumber = AV26TFResidentBsnNumber;
         AV69Trn_residentwwds_8_tfresidentbsnnumber_sel = AV27TFResidentBsnNumber_Sel;
         AV70Trn_residentwwds_9_tfresidentemail = AV28TFResidentEmail;
         AV71Trn_residentwwds_10_tfresidentemail_sel = AV29TFResidentEmail_Sel;
         AV72Trn_residentwwds_11_tfresidentgender_sels = AV31TFResidentGender_Sels;
         AV73Trn_residentwwds_12_tfresidentphone = AV32TFResidentPhone;
         AV74Trn_residentwwds_13_tfresidentphone_sel = AV33TFResidentPhone_Sel;
         AV75Trn_residentwwds_14_tfresidentbirthdate = AV34TFResidentBirthDate;
         AV76Trn_residentwwds_15_tfresidentbirthdate_to = AV35TFResidentBirthDate_To;
         AV77Trn_residentwwds_16_tfresidenttypename = AV39TFResidentTypeName;
         AV78Trn_residentwwds_17_tfresidenttypename_sel = AV40TFResidentTypeName_Sel;
         AV79Trn_residentwwds_18_tfmedicalindicationname = AV41TFMedicalIndicationName;
         AV80Trn_residentwwds_19_tfmedicalindicationname_sel = AV42TFMedicalIndicationName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV61Pgmname, AV21TFResidentSalutation_Sels, AV22TFResidentGivenName, AV23TFResidentGivenName_Sel, AV24TFResidentLastName, AV25TFResidentLastName_Sel, AV26TFResidentBsnNumber, AV27TFResidentBsnNumber_Sel, AV28TFResidentEmail, AV29TFResidentEmail_Sel, AV31TFResidentGender_Sels, AV32TFResidentPhone, AV33TFResidentPhone_Sel, AV34TFResidentBirthDate, AV35TFResidentBirthDate_To, AV39TFResidentTypeName, AV40TFResidentTypeName_Sel, AV41TFMedicalIndicationName, AV42TFMedicalIndicationName_Sel, AV52IsAuthorized_Display, AV54IsAuthorized_Update, AV56IsAuthorized_Delete, AV50IsAuthorized_ResidentGivenName, AV60IsAuthorized_ResidentTypeName, AV59IsAuthorized_MedicalIndicationName, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV62Trn_residentwwds_1_filterfulltext = AV15FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV21TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV22TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV23TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV24TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV25TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentbsnnumber = AV26TFResidentBsnNumber;
         AV69Trn_residentwwds_8_tfresidentbsnnumber_sel = AV27TFResidentBsnNumber_Sel;
         AV70Trn_residentwwds_9_tfresidentemail = AV28TFResidentEmail;
         AV71Trn_residentwwds_10_tfresidentemail_sel = AV29TFResidentEmail_Sel;
         AV72Trn_residentwwds_11_tfresidentgender_sels = AV31TFResidentGender_Sels;
         AV73Trn_residentwwds_12_tfresidentphone = AV32TFResidentPhone;
         AV74Trn_residentwwds_13_tfresidentphone_sel = AV33TFResidentPhone_Sel;
         AV75Trn_residentwwds_14_tfresidentbirthdate = AV34TFResidentBirthDate;
         AV76Trn_residentwwds_15_tfresidentbirthdate_to = AV35TFResidentBirthDate_To;
         AV77Trn_residentwwds_16_tfresidenttypename = AV39TFResidentTypeName;
         AV78Trn_residentwwds_17_tfresidenttypename_sel = AV40TFResidentTypeName_Sel;
         AV79Trn_residentwwds_18_tfmedicalindicationname = AV41TFMedicalIndicationName;
         AV80Trn_residentwwds_19_tfmedicalindicationname_sel = AV42TFMedicalIndicationName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV61Pgmname, AV21TFResidentSalutation_Sels, AV22TFResidentGivenName, AV23TFResidentGivenName_Sel, AV24TFResidentLastName, AV25TFResidentLastName_Sel, AV26TFResidentBsnNumber, AV27TFResidentBsnNumber_Sel, AV28TFResidentEmail, AV29TFResidentEmail_Sel, AV31TFResidentGender_Sels, AV32TFResidentPhone, AV33TFResidentPhone_Sel, AV34TFResidentBirthDate, AV35TFResidentBirthDate_To, AV39TFResidentTypeName, AV40TFResidentTypeName_Sel, AV41TFMedicalIndicationName, AV42TFMedicalIndicationName_Sel, AV52IsAuthorized_Display, AV54IsAuthorized_Update, AV56IsAuthorized_Delete, AV50IsAuthorized_ResidentGivenName, AV60IsAuthorized_ResidentTypeName, AV59IsAuthorized_MedicalIndicationName, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV61Pgmname = "Trn_ResidentWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtResidentId_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         cmbResidentSalutation.Enabled = 0;
         edtResidentGivenName_Enabled = 0;
         edtResidentLastName_Enabled = 0;
         edtResidentInitials_Enabled = 0;
         edtResidentBsnNumber_Enabled = 0;
         edtResidentEmail_Enabled = 0;
         cmbResidentGender.Enabled = 0;
         edtResidentPhone_Enabled = 0;
         edtResidentBirthDate_Enabled = 0;
         edtResidentGUID_Enabled = 0;
         edtResidentTypeId_Enabled = 0;
         edtResidentTypeName_Enabled = 0;
         edtMedicalIndicationId_Enabled = 0;
         edtMedicalIndicationName_Enabled = 0;
         edtResidentCountry_Enabled = 0;
         edtResidentCity_Enabled = 0;
         edtResidentZipCode_Enabled = 0;
         edtResidentAddressLine1_Enabled = 0;
         edtResidentAddressLine2_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP660( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17662 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV43DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ".", ","), 18, MidpointRounding.ToEven));
            AV47GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV48GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV49GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV36DDO_ResidentBirthDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_RESIDENTBIRTHDATEAUXDATE"), 0);
            AV37DDO_ResidentBirthDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_RESIDENTBIRTHDATEAUXDATETO"), 0);
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
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            AV38DDO_ResidentBirthDateAuxDateText = cgiGet( edtavDdo_residentbirthdateauxdatetext_Internalname);
            AssignAttri("", false, "AV38DDO_ResidentBirthDateAuxDateText", AV38DDO_ResidentBirthDateAuxDateText);
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
         E17662 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17662( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFRESIDENTBIRTHDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_residentbirthdateauxdatetext_Internalname});
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
         GXt_boolean1 = AV50IsAuthorized_ResidentGivenName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_residentview_Execute", out  GXt_boolean1) ;
         AV50IsAuthorized_ResidentGivenName = GXt_boolean1;
         AssignAttri("", false, "AV50IsAuthorized_ResidentGivenName", AV50IsAuthorized_ResidentGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTGIVENNAME", GetSecureSignedToken( "", AV50IsAuthorized_ResidentGivenName, context));
         GXt_boolean1 = AV60IsAuthorized_ResidentTypeName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_residenttypeview_Execute", out  GXt_boolean1) ;
         AV60IsAuthorized_ResidentTypeName = GXt_boolean1;
         AssignAttri("", false, "AV60IsAuthorized_ResidentTypeName", AV60IsAuthorized_ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RESIDENTTYPENAME", GetSecureSignedToken( "", AV60IsAuthorized_ResidentTypeName, context));
         GXt_boolean1 = AV59IsAuthorized_MedicalIndicationName;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_medicalindicationview_Execute", out  GXt_boolean1) ;
         AV59IsAuthorized_MedicalIndicationName = GXt_boolean1;
         AssignAttri("", false, "AV59IsAuthorized_MedicalIndicationName", AV59IsAuthorized_MedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MEDICALINDICATIONNAME", GetSecureSignedToken( "", AV59IsAuthorized_MedicalIndicationName, context));
         AV44GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV45GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV44GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Residents";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV43DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV43DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E18662( )
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
         AV47GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV47GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV47GridCurrentPage), 10, 0));
         AV48GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV48GridPageCount", StringUtil.LTrimStr( (decimal)(AV48GridPageCount), 10, 0));
         GXt_char3 = AV49GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV61Pgmname, out  GXt_char3) ;
         AV49GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV49GridAppliedFilters", AV49GridAppliedFilters);
         AV62Trn_residentwwds_1_filterfulltext = AV15FilterFullText;
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = AV21TFResidentSalutation_Sels;
         AV64Trn_residentwwds_3_tfresidentgivenname = AV22TFResidentGivenName;
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = AV23TFResidentGivenName_Sel;
         AV66Trn_residentwwds_5_tfresidentlastname = AV24TFResidentLastName;
         AV67Trn_residentwwds_6_tfresidentlastname_sel = AV25TFResidentLastName_Sel;
         AV68Trn_residentwwds_7_tfresidentbsnnumber = AV26TFResidentBsnNumber;
         AV69Trn_residentwwds_8_tfresidentbsnnumber_sel = AV27TFResidentBsnNumber_Sel;
         AV70Trn_residentwwds_9_tfresidentemail = AV28TFResidentEmail;
         AV71Trn_residentwwds_10_tfresidentemail_sel = AV29TFResidentEmail_Sel;
         AV72Trn_residentwwds_11_tfresidentgender_sels = AV31TFResidentGender_Sels;
         AV73Trn_residentwwds_12_tfresidentphone = AV32TFResidentPhone;
         AV74Trn_residentwwds_13_tfresidentphone_sel = AV33TFResidentPhone_Sel;
         AV75Trn_residentwwds_14_tfresidentbirthdate = AV34TFResidentBirthDate;
         AV76Trn_residentwwds_15_tfresidentbirthdate_to = AV35TFResidentBirthDate_To;
         AV77Trn_residentwwds_16_tfresidenttypename = AV39TFResidentTypeName;
         AV78Trn_residentwwds_17_tfresidenttypename_sel = AV40TFResidentTypeName_Sel;
         AV79Trn_residentwwds_18_tfmedicalindicationname = AV41TFMedicalIndicationName;
         AV80Trn_residentwwds_19_tfmedicalindicationname_sel = AV42TFMedicalIndicationName_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12662( )
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
            AV46PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV46PageToGo) ;
         }
      }

      protected void E13662( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15662( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentSalutation") == 0 )
            {
               AV20TFResidentSalutation_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV20TFResidentSalutation_SelsJson", AV20TFResidentSalutation_SelsJson);
               AV21TFResidentSalutation_Sels.FromJSonString(AV20TFResidentSalutation_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentGivenName") == 0 )
            {
               AV22TFResidentGivenName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV22TFResidentGivenName", AV22TFResidentGivenName);
               AV23TFResidentGivenName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV23TFResidentGivenName_Sel", AV23TFResidentGivenName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentLastName") == 0 )
            {
               AV24TFResidentLastName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV24TFResidentLastName", AV24TFResidentLastName);
               AV25TFResidentLastName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV25TFResidentLastName_Sel", AV25TFResidentLastName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentBsnNumber") == 0 )
            {
               AV26TFResidentBsnNumber = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV26TFResidentBsnNumber", AV26TFResidentBsnNumber);
               AV27TFResidentBsnNumber_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV27TFResidentBsnNumber_Sel", AV27TFResidentBsnNumber_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentEmail") == 0 )
            {
               AV28TFResidentEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFResidentEmail", AV28TFResidentEmail);
               AV29TFResidentEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFResidentEmail_Sel", AV29TFResidentEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentGender") == 0 )
            {
               AV30TFResidentGender_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFResidentGender_SelsJson", AV30TFResidentGender_SelsJson);
               AV31TFResidentGender_Sels.FromJSonString(AV30TFResidentGender_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentPhone") == 0 )
            {
               AV32TFResidentPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV32TFResidentPhone", AV32TFResidentPhone);
               AV33TFResidentPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV33TFResidentPhone_Sel", AV33TFResidentPhone_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentBirthDate") == 0 )
            {
               AV34TFResidentBirthDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 1);
               AssignAttri("", false, "AV34TFResidentBirthDate", context.localUtil.Format(AV34TFResidentBirthDate, "99/99/9999"));
               AV35TFResidentBirthDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 1);
               AssignAttri("", false, "AV35TFResidentBirthDate_To", context.localUtil.Format(AV35TFResidentBirthDate_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ResidentTypeName") == 0 )
            {
               AV39TFResidentTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFResidentTypeName", AV39TFResidentTypeName);
               AV40TFResidentTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFResidentTypeName_Sel", AV40TFResidentTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedicalIndicationName") == 0 )
            {
               AV41TFMedicalIndicationName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFMedicalIndicationName", AV41TFMedicalIndicationName);
               AV42TFMedicalIndicationName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFMedicalIndicationName_Sel", AV42TFMedicalIndicationName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31TFResidentGender_Sels", AV31TFResidentGender_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21TFResidentSalutation_Sels", AV21TFResidentSalutation_Sels);
      }

      private void E19662( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV51Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV51Display);
         if ( AV52IsAuthorized_Display )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_residentview.aspx"+UrlEncode(A62ResidentId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtavDisplay_Link = formatLink("trn_residentview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV53Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV53Update);
         if ( AV54IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A62ResidentId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            edtavUpdate_Link = formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV55Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV55Delete);
         if ( AV56IsAuthorized_Delete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A62ResidentId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            edtavDelete_Link = formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV50IsAuthorized_ResidentGivenName )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_residentview.aspx"+UrlEncode(A62ResidentId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtResidentGivenName_Link = formatLink("trn_residentview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV60IsAuthorized_ResidentTypeName )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_residenttypeview.aspx"+UrlEncode(A96ResidentTypeId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtResidentTypeName_Link = formatLink("trn_residenttypeview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV59IsAuthorized_MedicalIndicationName )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_medicalindicationview.aspx"+UrlEncode(A98MedicalIndicationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtMedicalIndicationName_Link = formatLink("trn_medicalindicationview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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

      protected void E11662( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_ResidentWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV61Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_ResidentWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV18ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "Trn_ResidentWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV61Pgmname+"GridState",  AV18ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21TFResidentSalutation_Sels", AV21TFResidentSalutation_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31TFResidentGender_Sels", AV31TFResidentGender_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void E16662( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV57IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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

      protected void E14662( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0073",(string)"",(string)"Trn_Resident",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0073"+"");
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
         GXt_boolean1 = AV52IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_residentview_Execute", out  GXt_boolean1) ;
         AV52IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV52IsAuthorized_Display", AV52IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV52IsAuthorized_Display, context));
         if ( ! ( AV52IsAuthorized_Display ) )
         {
            edtavDisplay_Visible = 0;
            AssignProp("", false, edtavDisplay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDisplay_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV54IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_resident_Update", out  GXt_boolean1) ;
         AV54IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV54IsAuthorized_Update", AV54IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV54IsAuthorized_Update, context));
         if ( ! ( AV54IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV56IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_resident_Delete", out  GXt_boolean1) ;
         AV56IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV56IsAuthorized_Delete", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         if ( ! ( AV56IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV57IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_resident_Insert", out  GXt_boolean1) ;
         AV57IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV57IsAuthorized_Insert", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
         if ( ! ( AV57IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_Resident",  1) ) )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_ResidentWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV21TFResidentSalutation_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22TFResidentGivenName = "";
         AssignAttri("", false, "AV22TFResidentGivenName", AV22TFResidentGivenName);
         AV23TFResidentGivenName_Sel = "";
         AssignAttri("", false, "AV23TFResidentGivenName_Sel", AV23TFResidentGivenName_Sel);
         AV24TFResidentLastName = "";
         AssignAttri("", false, "AV24TFResidentLastName", AV24TFResidentLastName);
         AV25TFResidentLastName_Sel = "";
         AssignAttri("", false, "AV25TFResidentLastName_Sel", AV25TFResidentLastName_Sel);
         AV26TFResidentBsnNumber = "";
         AssignAttri("", false, "AV26TFResidentBsnNumber", AV26TFResidentBsnNumber);
         AV27TFResidentBsnNumber_Sel = "";
         AssignAttri("", false, "AV27TFResidentBsnNumber_Sel", AV27TFResidentBsnNumber_Sel);
         AV28TFResidentEmail = "";
         AssignAttri("", false, "AV28TFResidentEmail", AV28TFResidentEmail);
         AV29TFResidentEmail_Sel = "";
         AssignAttri("", false, "AV29TFResidentEmail_Sel", AV29TFResidentEmail_Sel);
         AV31TFResidentGender_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32TFResidentPhone = "";
         AssignAttri("", false, "AV32TFResidentPhone", AV32TFResidentPhone);
         AV33TFResidentPhone_Sel = "";
         AssignAttri("", false, "AV33TFResidentPhone_Sel", AV33TFResidentPhone_Sel);
         AV34TFResidentBirthDate = DateTime.MinValue;
         AssignAttri("", false, "AV34TFResidentBirthDate", context.localUtil.Format(AV34TFResidentBirthDate, "99/99/9999"));
         AV35TFResidentBirthDate_To = DateTime.MinValue;
         AssignAttri("", false, "AV35TFResidentBirthDate_To", context.localUtil.Format(AV35TFResidentBirthDate_To, "99/99/9999"));
         AV39TFResidentTypeName = "";
         AssignAttri("", false, "AV39TFResidentTypeName", AV39TFResidentTypeName);
         AV40TFResidentTypeName_Sel = "";
         AssignAttri("", false, "AV40TFResidentTypeName_Sel", AV40TFResidentTypeName_Sel);
         AV41TFMedicalIndicationName = "";
         AssignAttri("", false, "AV41TFMedicalIndicationName", AV41TFMedicalIndicationName);
         AV42TFMedicalIndicationName_Sel = "";
         AssignAttri("", false, "AV42TFMedicalIndicationName_Sel", AV42TFMedicalIndicationName_Sel);
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
         if ( StringUtil.StrCmp(AV16Session.Get(AV61Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV61Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV61Pgmname+"GridState"), null, "", "");
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
         AV81GXV1 = 1;
         while ( AV81GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV81GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTSALUTATION_SEL") == 0 )
            {
               AV20TFResidentSalutation_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20TFResidentSalutation_SelsJson", AV20TFResidentSalutation_SelsJson);
               AV21TFResidentSalutation_Sels.FromJSonString(AV20TFResidentSalutation_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME") == 0 )
            {
               AV22TFResidentGivenName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV22TFResidentGivenName", AV22TFResidentGivenName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTGIVENNAME_SEL") == 0 )
            {
               AV23TFResidentGivenName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23TFResidentGivenName_Sel", AV23TFResidentGivenName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME") == 0 )
            {
               AV24TFResidentLastName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV24TFResidentLastName", AV24TFResidentLastName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTLASTNAME_SEL") == 0 )
            {
               AV25TFResidentLastName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV25TFResidentLastName_Sel", AV25TFResidentLastName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTBSNNUMBER") == 0 )
            {
               AV26TFResidentBsnNumber = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV26TFResidentBsnNumber", AV26TFResidentBsnNumber);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTBSNNUMBER_SEL") == 0 )
            {
               AV27TFResidentBsnNumber_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFResidentBsnNumber_Sel", AV27TFResidentBsnNumber_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL") == 0 )
            {
               AV28TFResidentEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFResidentEmail", AV28TFResidentEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTEMAIL_SEL") == 0 )
            {
               AV29TFResidentEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFResidentEmail_Sel", AV29TFResidentEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTGENDER_SEL") == 0 )
            {
               AV30TFResidentGender_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFResidentGender_SelsJson", AV30TFResidentGender_SelsJson);
               AV31TFResidentGender_Sels.FromJSonString(AV30TFResidentGender_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE") == 0 )
            {
               AV32TFResidentPhone = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFResidentPhone", AV32TFResidentPhone);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTPHONE_SEL") == 0 )
            {
               AV33TFResidentPhone_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFResidentPhone_Sel", AV33TFResidentPhone_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTBIRTHDATE") == 0 )
            {
               AV34TFResidentBirthDate = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 1);
               AssignAttri("", false, "AV34TFResidentBirthDate", context.localUtil.Format(AV34TFResidentBirthDate, "99/99/9999"));
               AV35TFResidentBirthDate_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 1);
               AssignAttri("", false, "AV35TFResidentBirthDate_To", context.localUtil.Format(AV35TFResidentBirthDate_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME") == 0 )
            {
               AV39TFResidentTypeName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFResidentTypeName", AV39TFResidentTypeName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESIDENTTYPENAME_SEL") == 0 )
            {
               AV40TFResidentTypeName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFResidentTypeName_Sel", AV40TFResidentTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMEDICALINDICATIONNAME") == 0 )
            {
               AV41TFMedicalIndicationName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFMedicalIndicationName", AV41TFMedicalIndicationName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMEDICALINDICATIONNAME_SEL") == 0 )
            {
               AV42TFMedicalIndicationName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFMedicalIndicationName_Sel", AV42TFMedicalIndicationName_Sel);
            }
            AV81GXV1 = (int)(AV81GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV21TFResidentSalutation_Sels.Count==0),  AV20TFResidentSalutation_SelsJson, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFResidentGivenName_Sel)),  AV23TFResidentGivenName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFResidentLastName_Sel)),  AV25TFResidentLastName_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFResidentBsnNumber_Sel)),  AV27TFResidentBsnNumber_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFResidentEmail_Sel)),  AV29TFResidentEmail_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV31TFResidentGender_Sels.Count==0),  AV30TFResidentGender_SelsJson, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFResidentPhone_Sel)),  AV33TFResidentPhone_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFResidentTypeName_Sel)),  AV40TFResidentTypeName_Sel, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMedicalIndicationName_Sel)),  AV42TFMedicalIndicationName_Sel, out  GXt_char12) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"||"+GXt_char11+"|"+GXt_char12;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFResidentGivenName)),  AV22TFResidentGivenName, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFResidentLastName)),  AV24TFResidentLastName, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFResidentBsnNumber)),  AV26TFResidentBsnNumber, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFResidentEmail)),  AV28TFResidentEmail, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFResidentPhone)),  AV32TFResidentPhone, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFResidentTypeName)),  AV39TFResidentTypeName, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFMedicalIndicationName)),  AV41TFMedicalIndicationName, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = "|"+GXt_char12+"|"+GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"||"+GXt_char8+"|"+((DateTime.MinValue==AV34TFResidentBirthDate) ? "" : context.localUtil.DToC( AV34TFResidentBirthDate, 1, "/"))+"|"+GXt_char7+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||||||"+((DateTime.MinValue==AV35TFResidentBirthDate_To) ? "" : context.localUtil.DToC( AV35TFResidentBirthDate_To, 1, "/"))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV61Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         AV58AuxText = ((AV21TFResidentSalutation_Sels.Count==1) ? "["+AV21TFResidentSalutation_Sels.GetString(1)+"]" : "multiple values");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFRESIDENTSALUTATION_SEL",  "Salutation",  !(AV21TFResidentSalutation_Sels.Count==0),  0,  AV21TFResidentSalutation_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV58AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV58AuxText, "[Mr]", "Mr"), "[Mrs]", "Mrs"), "[Dr]", "Dr"), "[Miss]", "Miss")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTGIVENNAME",  "Given Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFResidentGivenName)),  0,  AV22TFResidentGivenName,  AV22TFResidentGivenName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFResidentGivenName_Sel)),  AV23TFResidentGivenName_Sel,  AV23TFResidentGivenName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTLASTNAME",  "Last Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFResidentLastName)),  0,  AV24TFResidentLastName,  AV24TFResidentLastName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFResidentLastName_Sel)),  AV25TFResidentLastName_Sel,  AV25TFResidentLastName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTBSNNUMBER",  "BSN Number",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFResidentBsnNumber)),  0,  AV26TFResidentBsnNumber,  AV26TFResidentBsnNumber,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFResidentBsnNumber_Sel)),  AV27TFResidentBsnNumber_Sel,  AV27TFResidentBsnNumber_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTEMAIL",  "Email",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFResidentEmail)),  0,  AV28TFResidentEmail,  AV28TFResidentEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFResidentEmail_Sel)),  AV29TFResidentEmail_Sel,  AV29TFResidentEmail_Sel) ;
         AV58AuxText = ((AV31TFResidentGender_Sels.Count==1) ? "["+((string)AV31TFResidentGender_Sels.Item(1))+"]" : "multiple values");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFRESIDENTGENDER_SEL",  "Gender",  !(AV31TFResidentGender_Sels.Count==0),  0,  AV31TFResidentGender_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV58AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV58AuxText, "[Male]", "Male"), "[Female]", "Female"), "[Other]", "Other")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTPHONE",  "Phone",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFResidentPhone)),  0,  AV32TFResidentPhone,  AV32TFResidentPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFResidentPhone_Sel)),  AV33TFResidentPhone_Sel,  AV33TFResidentPhone_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFRESIDENTBIRTHDATE",  "Date Of Birth",  !((DateTime.MinValue==AV34TFResidentBirthDate)&&(DateTime.MinValue==AV35TFResidentBirthDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV34TFResidentBirthDate, 1, "/")),  ((DateTime.MinValue==AV34TFResidentBirthDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV34TFResidentBirthDate, "99/99/9999"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV35TFResidentBirthDate_To, 1, "/")),  ((DateTime.MinValue==AV35TFResidentBirthDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV35TFResidentBirthDate_To, "99/99/9999")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESIDENTTYPENAME",  "Resident Type",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFResidentTypeName)),  0,  AV39TFResidentTypeName,  AV39TFResidentTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFResidentTypeName_Sel)),  AV40TFResidentTypeName_Sel,  AV40TFResidentTypeName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMEDICALINDICATIONNAME",  "Medical Indication",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFMedicalIndicationName)),  0,  AV41TFMedicalIndicationName,  AV41TFMedicalIndicationName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMedicalIndicationName_Sel)),  AV42TFMedicalIndicationName_Sel,  AV42TFMedicalIndicationName_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV61Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV61Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_Resident";
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
         PA662( ) ;
         WS662( ) ;
         WE662( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202492719504463", true, true);
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
         context.AddJavascriptSource("trn_residentww.js", "?202492719504465", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         edtResidentId_Internalname = "RESIDENTID_"+sGXsfl_37_idx;
         edtLocationId_Internalname = "LOCATIONID_"+sGXsfl_37_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_37_idx;
         cmbResidentSalutation_Internalname = "RESIDENTSALUTATION_"+sGXsfl_37_idx;
         edtResidentGivenName_Internalname = "RESIDENTGIVENNAME_"+sGXsfl_37_idx;
         edtResidentLastName_Internalname = "RESIDENTLASTNAME_"+sGXsfl_37_idx;
         edtResidentInitials_Internalname = "RESIDENTINITIALS_"+sGXsfl_37_idx;
         edtResidentBsnNumber_Internalname = "RESIDENTBSNNUMBER_"+sGXsfl_37_idx;
         edtResidentEmail_Internalname = "RESIDENTEMAIL_"+sGXsfl_37_idx;
         cmbResidentGender_Internalname = "RESIDENTGENDER_"+sGXsfl_37_idx;
         edtResidentPhone_Internalname = "RESIDENTPHONE_"+sGXsfl_37_idx;
         edtResidentBirthDate_Internalname = "RESIDENTBIRTHDATE_"+sGXsfl_37_idx;
         edtResidentGUID_Internalname = "RESIDENTGUID_"+sGXsfl_37_idx;
         edtResidentTypeId_Internalname = "RESIDENTTYPEID_"+sGXsfl_37_idx;
         edtResidentTypeName_Internalname = "RESIDENTTYPENAME_"+sGXsfl_37_idx;
         edtMedicalIndicationId_Internalname = "MEDICALINDICATIONID_"+sGXsfl_37_idx;
         edtMedicalIndicationName_Internalname = "MEDICALINDICATIONNAME_"+sGXsfl_37_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_37_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
         edtResidentCountry_Internalname = "RESIDENTCOUNTRY_"+sGXsfl_37_idx;
         edtResidentCity_Internalname = "RESIDENTCITY_"+sGXsfl_37_idx;
         edtResidentZipCode_Internalname = "RESIDENTZIPCODE_"+sGXsfl_37_idx;
         edtResidentAddressLine1_Internalname = "RESIDENTADDRESSLINE1_"+sGXsfl_37_idx;
         edtResidentAddressLine2_Internalname = "RESIDENTADDRESSLINE2_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtResidentId_Internalname = "RESIDENTID_"+sGXsfl_37_fel_idx;
         edtLocationId_Internalname = "LOCATIONID_"+sGXsfl_37_fel_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_37_fel_idx;
         cmbResidentSalutation_Internalname = "RESIDENTSALUTATION_"+sGXsfl_37_fel_idx;
         edtResidentGivenName_Internalname = "RESIDENTGIVENNAME_"+sGXsfl_37_fel_idx;
         edtResidentLastName_Internalname = "RESIDENTLASTNAME_"+sGXsfl_37_fel_idx;
         edtResidentInitials_Internalname = "RESIDENTINITIALS_"+sGXsfl_37_fel_idx;
         edtResidentBsnNumber_Internalname = "RESIDENTBSNNUMBER_"+sGXsfl_37_fel_idx;
         edtResidentEmail_Internalname = "RESIDENTEMAIL_"+sGXsfl_37_fel_idx;
         cmbResidentGender_Internalname = "RESIDENTGENDER_"+sGXsfl_37_fel_idx;
         edtResidentPhone_Internalname = "RESIDENTPHONE_"+sGXsfl_37_fel_idx;
         edtResidentBirthDate_Internalname = "RESIDENTBIRTHDATE_"+sGXsfl_37_fel_idx;
         edtResidentGUID_Internalname = "RESIDENTGUID_"+sGXsfl_37_fel_idx;
         edtResidentTypeId_Internalname = "RESIDENTTYPEID_"+sGXsfl_37_fel_idx;
         edtResidentTypeName_Internalname = "RESIDENTTYPENAME_"+sGXsfl_37_fel_idx;
         edtMedicalIndicationId_Internalname = "MEDICALINDICATIONID_"+sGXsfl_37_fel_idx;
         edtMedicalIndicationName_Internalname = "MEDICALINDICATIONNAME_"+sGXsfl_37_fel_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_37_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
         edtResidentCountry_Internalname = "RESIDENTCOUNTRY_"+sGXsfl_37_fel_idx;
         edtResidentCity_Internalname = "RESIDENTCITY_"+sGXsfl_37_fel_idx;
         edtResidentZipCode_Internalname = "RESIDENTZIPCODE_"+sGXsfl_37_fel_idx;
         edtResidentAddressLine1_Internalname = "RESIDENTADDRESSLINE1_"+sGXsfl_37_fel_idx;
         edtResidentAddressLine2_Internalname = "RESIDENTADDRESSLINE2_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB660( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentId_Internalname,A62ResidentId.ToString(),A62ResidentId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationId_Internalname,A29LocationId.ToString(),A29LocationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
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
            if ( ( cmbResidentSalutation.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "RESIDENTSALUTATION_" + sGXsfl_37_idx;
               cmbResidentSalutation.Name = GXCCtl;
               cmbResidentSalutation.WebTags = "";
               cmbResidentSalutation.addItem("Mr", "Mr", 0);
               cmbResidentSalutation.addItem("Mrs", "Mrs", 0);
               cmbResidentSalutation.addItem("Dr", "Dr", 0);
               cmbResidentSalutation.addItem("Miss", "Miss", 0);
               if ( cmbResidentSalutation.ItemCount > 0 )
               {
                  A72ResidentSalutation = cmbResidentSalutation.getValidValue(A72ResidentSalutation);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbResidentSalutation,(string)cmbResidentSalutation_Internalname,StringUtil.RTrim( A72ResidentSalutation),(short)1,(string)cmbResidentSalutation_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbResidentSalutation.CurrentValue = StringUtil.RTrim( A72ResidentSalutation);
            AssignProp("", false, cmbResidentSalutation_Internalname, "Values", (string)(cmbResidentSalutation.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentGivenName_Internalname,(string)A64ResidentGivenName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtResidentGivenName_Link,(string)"",(string)"",(string)"",(string)edtResidentGivenName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentLastName_Internalname,(string)A65ResidentLastName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentLastName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentInitials_Internalname,StringUtil.RTrim( A66ResidentInitials),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentInitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentBsnNumber_Internalname,(string)A63ResidentBsnNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentBsnNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"BsnNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentEmail_Internalname,(string)A67ResidentEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A67ResidentEmail,(string)"",(string)"",(string)"",(string)edtResidentEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbResidentGender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "RESIDENTGENDER_" + sGXsfl_37_idx;
               cmbResidentGender.Name = GXCCtl;
               cmbResidentGender.WebTags = "";
               cmbResidentGender.addItem("Male", "Male", 0);
               cmbResidentGender.addItem("Female", "Female", 0);
               cmbResidentGender.addItem("Other", "Other", 0);
               if ( cmbResidentGender.ItemCount > 0 )
               {
                  A68ResidentGender = cmbResidentGender.getValidValue(A68ResidentGender);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbResidentGender,(string)cmbResidentGender_Internalname,StringUtil.RTrim( A68ResidentGender),(short)1,(string)cmbResidentGender_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbResidentGender.CurrentValue = StringUtil.RTrim( A68ResidentGender);
            AssignProp("", false, cmbResidentGender_Internalname, "Values", (string)(cmbResidentGender.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A70ResidentPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentPhone_Internalname,StringUtil.RTrim( A70ResidentPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtResidentPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentBirthDate_Internalname,context.localUtil.Format(A73ResidentBirthDate, "99/99/9999"),context.localUtil.Format( A73ResidentBirthDate, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentBirthDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentGUID_Internalname,(string)A71ResidentGUID,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentGUID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentTypeId_Internalname,A96ResidentTypeId.ToString(),A96ResidentTypeId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentTypeName_Internalname,(string)A97ResidentTypeName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtResidentTypeName_Link,(string)"",(string)"",(string)"",(string)edtResidentTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedicalIndicationId_Internalname,A98MedicalIndicationId.ToString(),A98MedicalIndicationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedicalIndicationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)37,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedicalIndicationName_Internalname,(string)A99MedicalIndicationName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMedicalIndicationName_Link,(string)"",(string)"",(string)"",(string)edtMedicalIndicationName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDisplay_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV51Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Display",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDisplay_Visible,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV53Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Update",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV55Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentCountry_Internalname,(string)A354ResidentCountry,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentCountry_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentCity_Internalname,(string)A355ResidentCity,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentCity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentZipCode_Internalname,(string)A356ResidentZipCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentZipCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentAddressLine1_Internalname,(string)A357ResidentAddressLine1,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentAddressLine1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResidentAddressLine2_Internalname,(string)A358ResidentAddressLine2,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResidentAddressLine2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes662( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "RESIDENTSALUTATION_" + sGXsfl_37_idx;
         cmbResidentSalutation.Name = GXCCtl;
         cmbResidentSalutation.WebTags = "";
         cmbResidentSalutation.addItem("Mr", "Mr", 0);
         cmbResidentSalutation.addItem("Mrs", "Mrs", 0);
         cmbResidentSalutation.addItem("Dr", "Dr", 0);
         cmbResidentSalutation.addItem("Miss", "Miss", 0);
         if ( cmbResidentSalutation.ItemCount > 0 )
         {
            A72ResidentSalutation = cmbResidentSalutation.getValidValue(A72ResidentSalutation);
         }
         GXCCtl = "RESIDENTGENDER_" + sGXsfl_37_idx;
         cmbResidentGender.Name = GXCCtl;
         cmbResidentGender.WebTags = "";
         cmbResidentGender.addItem("Male", "Male", 0);
         cmbResidentGender.addItem("Female", "Female", 0);
         cmbResidentGender.addItem("Other", "Other", 0);
         if ( cmbResidentGender.ItemCount > 0 )
         {
            A68ResidentGender = cmbResidentGender.getValidValue(A68ResidentGender);
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
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Location Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Organisation Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Salutation") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Given Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Last Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Initials") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "BSN Number") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Gender") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Phone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Date Of Birth") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "GUID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Type Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Resident Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Indication Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Medical Indication") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Country") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "City") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A62ResidentId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A29LocationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A72ResidentSalutation)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A64ResidentGivenName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtResidentGivenName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A65ResidentLastName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A66ResidentInitials)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A63ResidentBsnNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A67ResidentEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A68ResidentGender));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A70ResidentPhone)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A73ResidentBirthDate, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A71ResidentGUID));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A96ResidentTypeId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A97ResidentTypeName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtResidentTypeName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A98MedicalIndicationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A99MedicalIndicationName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMedicalIndicationName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV51Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV53Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV55Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A354ResidentCountry));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A355ResidentCity));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A356ResidentZipCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A357ResidentAddressLine1));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A358ResidentAddressLine2));
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
         edtResidentId_Internalname = "RESIDENTID";
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         cmbResidentSalutation_Internalname = "RESIDENTSALUTATION";
         edtResidentGivenName_Internalname = "RESIDENTGIVENNAME";
         edtResidentLastName_Internalname = "RESIDENTLASTNAME";
         edtResidentInitials_Internalname = "RESIDENTINITIALS";
         edtResidentBsnNumber_Internalname = "RESIDENTBSNNUMBER";
         edtResidentEmail_Internalname = "RESIDENTEMAIL";
         cmbResidentGender_Internalname = "RESIDENTGENDER";
         edtResidentPhone_Internalname = "RESIDENTPHONE";
         edtResidentBirthDate_Internalname = "RESIDENTBIRTHDATE";
         edtResidentGUID_Internalname = "RESIDENTGUID";
         edtResidentTypeId_Internalname = "RESIDENTTYPEID";
         edtResidentTypeName_Internalname = "RESIDENTTYPENAME";
         edtMedicalIndicationId_Internalname = "MEDICALINDICATIONID";
         edtMedicalIndicationName_Internalname = "MEDICALINDICATIONNAME";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtResidentCountry_Internalname = "RESIDENTCOUNTRY";
         edtResidentCity_Internalname = "RESIDENTCITY";
         edtResidentZipCode_Internalname = "RESIDENTZIPCODE";
         edtResidentAddressLine1_Internalname = "RESIDENTADDRESSLINE1";
         edtResidentAddressLine2_Internalname = "RESIDENTADDRESSLINE2";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_residentbirthdateauxdatetext_Internalname = "vDDO_RESIDENTBIRTHDATEAUXDATETEXT";
         Tfresidentbirthdate_rangepicker_Internalname = "TFRESIDENTBIRTHDATE_RANGEPICKER";
         divDdo_residentbirthdateauxdates_Internalname = "DDO_RESIDENTBIRTHDATEAUXDATES";
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
         edtResidentAddressLine2_Jsonclick = "";
         edtResidentAddressLine1_Jsonclick = "";
         edtResidentZipCode_Jsonclick = "";
         edtResidentCity_Jsonclick = "";
         edtResidentCountry_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         edtMedicalIndicationName_Jsonclick = "";
         edtMedicalIndicationName_Link = "";
         edtMedicalIndicationId_Jsonclick = "";
         edtResidentTypeName_Jsonclick = "";
         edtResidentTypeName_Link = "";
         edtResidentTypeId_Jsonclick = "";
         edtResidentGUID_Jsonclick = "";
         edtResidentBirthDate_Jsonclick = "";
         edtResidentPhone_Jsonclick = "";
         cmbResidentGender_Jsonclick = "";
         edtResidentEmail_Jsonclick = "";
         edtResidentBsnNumber_Jsonclick = "";
         edtResidentInitials_Jsonclick = "";
         edtResidentLastName_Jsonclick = "";
         edtResidentGivenName_Jsonclick = "";
         edtResidentGivenName_Link = "";
         cmbResidentSalutation_Jsonclick = "";
         edtOrganisationId_Jsonclick = "";
         edtLocationId_Jsonclick = "";
         edtResidentId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtavDisplay_Visible = -1;
         edtResidentAddressLine2_Enabled = 0;
         edtResidentAddressLine1_Enabled = 0;
         edtResidentZipCode_Enabled = 0;
         edtResidentCity_Enabled = 0;
         edtResidentCountry_Enabled = 0;
         edtMedicalIndicationName_Enabled = 0;
         edtMedicalIndicationId_Enabled = 0;
         edtResidentTypeName_Enabled = 0;
         edtResidentTypeId_Enabled = 0;
         edtResidentGUID_Enabled = 0;
         edtResidentBirthDate_Enabled = 0;
         edtResidentPhone_Enabled = 0;
         cmbResidentGender.Enabled = 0;
         edtResidentEmail_Enabled = 0;
         edtResidentBsnNumber_Enabled = 0;
         edtResidentInitials_Enabled = 0;
         edtResidentLastName_Enabled = 0;
         edtResidentGivenName_Enabled = 0;
         cmbResidentSalutation.Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtResidentId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_residentbirthdateauxdatetext_Jsonclick = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "Trn_ResidentWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "Mr:Mr,Mrs:Mrs,Dr:Dr,Miss:Miss|||||Male:Male,Female:Female,Other:Other||||";
         Ddo_grid_Allowmultipleselection = "T|||||T||||";
         Ddo_grid_Datalisttype = "FixedValues|Dynamic|Dynamic|Dynamic|Dynamic|FixedValues|Dynamic||Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T|T|T|T|T|T|T||T|T";
         Ddo_grid_Filterisrange = "|||||||P||";
         Ddo_grid_Filtertype = "|Character|Character|Character|Character||Character|Date|Character|Character";
         Ddo_grid_Includefilter = "|T|T|T|T||T|T|T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9|10";
         Ddo_grid_Columnids = "3:ResidentSalutation|4:ResidentGivenName|5:ResidentLastName|7:ResidentBsnNumber|8:ResidentEmail|9:ResidentGender|10:ResidentPhone|11:ResidentBirthDate|14:ResidentTypeName|16:MedicalIndicationName";
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
         Form.Caption = " Residents";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFResidentSalutation_Sels","fld":"vTFRESIDENTSALUTATION_SELS"},{"av":"AV22TFResidentGivenName","fld":"vTFRESIDENTGIVENNAME"},{"av":"AV23TFResidentGivenName_Sel","fld":"vTFRESIDENTGIVENNAME_SEL"},{"av":"AV24TFResidentLastName","fld":"vTFRESIDENTLASTNAME"},{"av":"AV25TFResidentLastName_Sel","fld":"vTFRESIDENTLASTNAME_SEL"},{"av":"AV26TFResidentBsnNumber","fld":"vTFRESIDENTBSNNUMBER"},{"av":"AV27TFResidentBsnNumber_Sel","fld":"vTFRESIDENTBSNNUMBER_SEL"},{"av":"AV28TFResidentEmail","fld":"vTFRESIDENTEMAIL"},{"av":"AV29TFResidentEmail_Sel","fld":"vTFRESIDENTEMAIL_SEL"},{"av":"AV31TFResidentGender_Sels","fld":"vTFRESIDENTGENDER_SELS"},{"av":"AV32TFResidentPhone","fld":"vTFRESIDENTPHONE"},{"av":"AV33TFResidentPhone_Sel","fld":"vTFRESIDENTPHONE_SEL"},{"av":"AV34TFResidentBirthDate","fld":"vTFRESIDENTBIRTHDATE"},{"av":"AV35TFResidentBirthDate_To","fld":"vTFRESIDENTBIRTHDATE_TO"},{"av":"AV39TFResidentTypeName","fld":"vTFRESIDENTTYPENAME"},{"av":"AV40TFResidentTypeName_Sel","fld":"vTFRESIDENTTYPENAME_SEL"},{"av":"AV41TFMedicalIndicationName","fld":"vTFMEDICALINDICATIONNAME"},{"av":"AV42TFMedicalIndicationName_Sel","fld":"vTFMEDICALINDICATIONNAME_SEL"},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_ResidentGivenName","fld":"vISAUTHORIZED_RESIDENTGIVENNAME","hsh":true},{"av":"AV60IsAuthorized_ResidentTypeName","fld":"vISAUTHORIZED_RESIDENTTYPENAME","hsh":true},{"av":"AV59IsAuthorized_MedicalIndicationName","fld":"vISAUTHORIZED_MEDICALINDICATIONNAME","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV47GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV48GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV49GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV54IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12662","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFResidentSalutation_Sels","fld":"vTFRESIDENTSALUTATION_SELS"},{"av":"AV22TFResidentGivenName","fld":"vTFRESIDENTGIVENNAME"},{"av":"AV23TFResidentGivenName_Sel","fld":"vTFRESIDENTGIVENNAME_SEL"},{"av":"AV24TFResidentLastName","fld":"vTFRESIDENTLASTNAME"},{"av":"AV25TFResidentLastName_Sel","fld":"vTFRESIDENTLASTNAME_SEL"},{"av":"AV26TFResidentBsnNumber","fld":"vTFRESIDENTBSNNUMBER"},{"av":"AV27TFResidentBsnNumber_Sel","fld":"vTFRESIDENTBSNNUMBER_SEL"},{"av":"AV28TFResidentEmail","fld":"vTFRESIDENTEMAIL"},{"av":"AV29TFResidentEmail_Sel","fld":"vTFRESIDENTEMAIL_SEL"},{"av":"AV31TFResidentGender_Sels","fld":"vTFRESIDENTGENDER_SELS"},{"av":"AV32TFResidentPhone","fld":"vTFRESIDENTPHONE"},{"av":"AV33TFResidentPhone_Sel","fld":"vTFRESIDENTPHONE_SEL"},{"av":"AV34TFResidentBirthDate","fld":"vTFRESIDENTBIRTHDATE"},{"av":"AV35TFResidentBirthDate_To","fld":"vTFRESIDENTBIRTHDATE_TO"},{"av":"AV39TFResidentTypeName","fld":"vTFRESIDENTTYPENAME"},{"av":"AV40TFResidentTypeName_Sel","fld":"vTFRESIDENTTYPENAME_SEL"},{"av":"AV41TFMedicalIndicationName","fld":"vTFMEDICALINDICATIONNAME"},{"av":"AV42TFMedicalIndicationName_Sel","fld":"vTFMEDICALINDICATIONNAME_SEL"},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_ResidentGivenName","fld":"vISAUTHORIZED_RESIDENTGIVENNAME","hsh":true},{"av":"AV60IsAuthorized_ResidentTypeName","fld":"vISAUTHORIZED_RESIDENTTYPENAME","hsh":true},{"av":"AV59IsAuthorized_MedicalIndicationName","fld":"vISAUTHORIZED_MEDICALINDICATIONNAME","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13662","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFResidentSalutation_Sels","fld":"vTFRESIDENTSALUTATION_SELS"},{"av":"AV22TFResidentGivenName","fld":"vTFRESIDENTGIVENNAME"},{"av":"AV23TFResidentGivenName_Sel","fld":"vTFRESIDENTGIVENNAME_SEL"},{"av":"AV24TFResidentLastName","fld":"vTFRESIDENTLASTNAME"},{"av":"AV25TFResidentLastName_Sel","fld":"vTFRESIDENTLASTNAME_SEL"},{"av":"AV26TFResidentBsnNumber","fld":"vTFRESIDENTBSNNUMBER"},{"av":"AV27TFResidentBsnNumber_Sel","fld":"vTFRESIDENTBSNNUMBER_SEL"},{"av":"AV28TFResidentEmail","fld":"vTFRESIDENTEMAIL"},{"av":"AV29TFResidentEmail_Sel","fld":"vTFRESIDENTEMAIL_SEL"},{"av":"AV31TFResidentGender_Sels","fld":"vTFRESIDENTGENDER_SELS"},{"av":"AV32TFResidentPhone","fld":"vTFRESIDENTPHONE"},{"av":"AV33TFResidentPhone_Sel","fld":"vTFRESIDENTPHONE_SEL"},{"av":"AV34TFResidentBirthDate","fld":"vTFRESIDENTBIRTHDATE"},{"av":"AV35TFResidentBirthDate_To","fld":"vTFRESIDENTBIRTHDATE_TO"},{"av":"AV39TFResidentTypeName","fld":"vTFRESIDENTTYPENAME"},{"av":"AV40TFResidentTypeName_Sel","fld":"vTFRESIDENTTYPENAME_SEL"},{"av":"AV41TFMedicalIndicationName","fld":"vTFMEDICALINDICATIONNAME"},{"av":"AV42TFMedicalIndicationName_Sel","fld":"vTFMEDICALINDICATIONNAME_SEL"},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_ResidentGivenName","fld":"vISAUTHORIZED_RESIDENTGIVENNAME","hsh":true},{"av":"AV60IsAuthorized_ResidentTypeName","fld":"vISAUTHORIZED_RESIDENTTYPENAME","hsh":true},{"av":"AV59IsAuthorized_MedicalIndicationName","fld":"vISAUTHORIZED_MEDICALINDICATIONNAME","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E15662","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFResidentSalutation_Sels","fld":"vTFRESIDENTSALUTATION_SELS"},{"av":"AV22TFResidentGivenName","fld":"vTFRESIDENTGIVENNAME"},{"av":"AV23TFResidentGivenName_Sel","fld":"vTFRESIDENTGIVENNAME_SEL"},{"av":"AV24TFResidentLastName","fld":"vTFRESIDENTLASTNAME"},{"av":"AV25TFResidentLastName_Sel","fld":"vTFRESIDENTLASTNAME_SEL"},{"av":"AV26TFResidentBsnNumber","fld":"vTFRESIDENTBSNNUMBER"},{"av":"AV27TFResidentBsnNumber_Sel","fld":"vTFRESIDENTBSNNUMBER_SEL"},{"av":"AV28TFResidentEmail","fld":"vTFRESIDENTEMAIL"},{"av":"AV29TFResidentEmail_Sel","fld":"vTFRESIDENTEMAIL_SEL"},{"av":"AV31TFResidentGender_Sels","fld":"vTFRESIDENTGENDER_SELS"},{"av":"AV32TFResidentPhone","fld":"vTFRESIDENTPHONE"},{"av":"AV33TFResidentPhone_Sel","fld":"vTFRESIDENTPHONE_SEL"},{"av":"AV34TFResidentBirthDate","fld":"vTFRESIDENTBIRTHDATE"},{"av":"AV35TFResidentBirthDate_To","fld":"vTFRESIDENTBIRTHDATE_TO"},{"av":"AV39TFResidentTypeName","fld":"vTFRESIDENTTYPENAME"},{"av":"AV40TFResidentTypeName_Sel","fld":"vTFRESIDENTTYPENAME_SEL"},{"av":"AV41TFMedicalIndicationName","fld":"vTFMEDICALINDICATIONNAME"},{"av":"AV42TFMedicalIndicationName_Sel","fld":"vTFMEDICALINDICATIONNAME_SEL"},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_ResidentGivenName","fld":"vISAUTHORIZED_RESIDENTGIVENNAME","hsh":true},{"av":"AV60IsAuthorized_ResidentTypeName","fld":"vISAUTHORIZED_RESIDENTTYPENAME","hsh":true},{"av":"AV59IsAuthorized_MedicalIndicationName","fld":"vISAUTHORIZED_MEDICALINDICATIONNAME","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV41TFMedicalIndicationName","fld":"vTFMEDICALINDICATIONNAME"},{"av":"AV42TFMedicalIndicationName_Sel","fld":"vTFMEDICALINDICATIONNAME_SEL"},{"av":"AV39TFResidentTypeName","fld":"vTFRESIDENTTYPENAME"},{"av":"AV40TFResidentTypeName_Sel","fld":"vTFRESIDENTTYPENAME_SEL"},{"av":"AV34TFResidentBirthDate","fld":"vTFRESIDENTBIRTHDATE"},{"av":"AV35TFResidentBirthDate_To","fld":"vTFRESIDENTBIRTHDATE_TO"},{"av":"AV32TFResidentPhone","fld":"vTFRESIDENTPHONE"},{"av":"AV33TFResidentPhone_Sel","fld":"vTFRESIDENTPHONE_SEL"},{"av":"AV30TFResidentGender_SelsJson","fld":"vTFRESIDENTGENDER_SELSJSON"},{"av":"AV31TFResidentGender_Sels","fld":"vTFRESIDENTGENDER_SELS"},{"av":"AV28TFResidentEmail","fld":"vTFRESIDENTEMAIL"},{"av":"AV29TFResidentEmail_Sel","fld":"vTFRESIDENTEMAIL_SEL"},{"av":"AV26TFResidentBsnNumber","fld":"vTFRESIDENTBSNNUMBER"},{"av":"AV27TFResidentBsnNumber_Sel","fld":"vTFRESIDENTBSNNUMBER_SEL"},{"av":"AV24TFResidentLastName","fld":"vTFRESIDENTLASTNAME"},{"av":"AV25TFResidentLastName_Sel","fld":"vTFRESIDENTLASTNAME_SEL"},{"av":"AV22TFResidentGivenName","fld":"vTFRESIDENTGIVENNAME"},{"av":"AV23TFResidentGivenName_Sel","fld":"vTFRESIDENTGIVENNAME_SEL"},{"av":"AV20TFResidentSalutation_SelsJson","fld":"vTFRESIDENTSALUTATION_SELSJSON"},{"av":"AV21TFResidentSalutation_Sels","fld":"vTFRESIDENTSALUTATION_SELS"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E19662","iparms":[{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"A62ResidentId","fld":"RESIDENTID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"AV54IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_ResidentGivenName","fld":"vISAUTHORIZED_RESIDENTGIVENNAME","hsh":true},{"av":"AV60IsAuthorized_ResidentTypeName","fld":"vISAUTHORIZED_RESIDENTTYPENAME","hsh":true},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"AV59IsAuthorized_MedicalIndicationName","fld":"vISAUTHORIZED_MEDICALINDICATIONNAME","hsh":true},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV51Display","fld":"vDISPLAY"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV53Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV55Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtResidentGivenName_Link","ctrl":"RESIDENTGIVENNAME","prop":"Link"},{"av":"edtResidentTypeName_Link","ctrl":"RESIDENTTYPENAME","prop":"Link"},{"av":"edtMedicalIndicationName_Link","ctrl":"MEDICALINDICATIONNAME","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11662","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFResidentSalutation_Sels","fld":"vTFRESIDENTSALUTATION_SELS"},{"av":"AV22TFResidentGivenName","fld":"vTFRESIDENTGIVENNAME"},{"av":"AV23TFResidentGivenName_Sel","fld":"vTFRESIDENTGIVENNAME_SEL"},{"av":"AV24TFResidentLastName","fld":"vTFRESIDENTLASTNAME"},{"av":"AV25TFResidentLastName_Sel","fld":"vTFRESIDENTLASTNAME_SEL"},{"av":"AV26TFResidentBsnNumber","fld":"vTFRESIDENTBSNNUMBER"},{"av":"AV27TFResidentBsnNumber_Sel","fld":"vTFRESIDENTBSNNUMBER_SEL"},{"av":"AV28TFResidentEmail","fld":"vTFRESIDENTEMAIL"},{"av":"AV29TFResidentEmail_Sel","fld":"vTFRESIDENTEMAIL_SEL"},{"av":"AV31TFResidentGender_Sels","fld":"vTFRESIDENTGENDER_SELS"},{"av":"AV32TFResidentPhone","fld":"vTFRESIDENTPHONE"},{"av":"AV33TFResidentPhone_Sel","fld":"vTFRESIDENTPHONE_SEL"},{"av":"AV34TFResidentBirthDate","fld":"vTFRESIDENTBIRTHDATE"},{"av":"AV35TFResidentBirthDate_To","fld":"vTFRESIDENTBIRTHDATE_TO"},{"av":"AV39TFResidentTypeName","fld":"vTFRESIDENTTYPENAME"},{"av":"AV40TFResidentTypeName_Sel","fld":"vTFRESIDENTTYPENAME_SEL"},{"av":"AV41TFMedicalIndicationName","fld":"vTFMEDICALINDICATIONNAME"},{"av":"AV42TFMedicalIndicationName_Sel","fld":"vTFMEDICALINDICATIONNAME_SEL"},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_ResidentGivenName","fld":"vISAUTHORIZED_RESIDENTGIVENNAME","hsh":true},{"av":"AV60IsAuthorized_ResidentTypeName","fld":"vISAUTHORIZED_RESIDENTTYPENAME","hsh":true},{"av":"AV59IsAuthorized_MedicalIndicationName","fld":"vISAUTHORIZED_MEDICALINDICATIONNAME","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV20TFResidentSalutation_SelsJson","fld":"vTFRESIDENTSALUTATION_SELSJSON"},{"av":"AV30TFResidentGender_SelsJson","fld":"vTFRESIDENTGENDER_SELSJSON"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV21TFResidentSalutation_Sels","fld":"vTFRESIDENTSALUTATION_SELS"},{"av":"AV22TFResidentGivenName","fld":"vTFRESIDENTGIVENNAME"},{"av":"AV23TFResidentGivenName_Sel","fld":"vTFRESIDENTGIVENNAME_SEL"},{"av":"AV24TFResidentLastName","fld":"vTFRESIDENTLASTNAME"},{"av":"AV25TFResidentLastName_Sel","fld":"vTFRESIDENTLASTNAME_SEL"},{"av":"AV26TFResidentBsnNumber","fld":"vTFRESIDENTBSNNUMBER"},{"av":"AV27TFResidentBsnNumber_Sel","fld":"vTFRESIDENTBSNNUMBER_SEL"},{"av":"AV28TFResidentEmail","fld":"vTFRESIDENTEMAIL"},{"av":"AV29TFResidentEmail_Sel","fld":"vTFRESIDENTEMAIL_SEL"},{"av":"AV31TFResidentGender_Sels","fld":"vTFRESIDENTGENDER_SELS"},{"av":"AV32TFResidentPhone","fld":"vTFRESIDENTPHONE"},{"av":"AV33TFResidentPhone_Sel","fld":"vTFRESIDENTPHONE_SEL"},{"av":"AV34TFResidentBirthDate","fld":"vTFRESIDENTBIRTHDATE"},{"av":"AV35TFResidentBirthDate_To","fld":"vTFRESIDENTBIRTHDATE_TO"},{"av":"AV39TFResidentTypeName","fld":"vTFRESIDENTTYPENAME"},{"av":"AV40TFResidentTypeName_Sel","fld":"vTFRESIDENTTYPENAME_SEL"},{"av":"AV41TFMedicalIndicationName","fld":"vTFMEDICALINDICATIONNAME"},{"av":"AV42TFMedicalIndicationName_Sel","fld":"vTFMEDICALINDICATIONNAME_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV30TFResidentGender_SelsJson","fld":"vTFRESIDENTGENDER_SELSJSON"},{"av":"AV20TFResidentSalutation_SelsJson","fld":"vTFRESIDENTSALUTATION_SELSJSON"},{"av":"AV47GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV48GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV49GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV54IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E16662","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV21TFResidentSalutation_Sels","fld":"vTFRESIDENTSALUTATION_SELS"},{"av":"AV22TFResidentGivenName","fld":"vTFRESIDENTGIVENNAME"},{"av":"AV23TFResidentGivenName_Sel","fld":"vTFRESIDENTGIVENNAME_SEL"},{"av":"AV24TFResidentLastName","fld":"vTFRESIDENTLASTNAME"},{"av":"AV25TFResidentLastName_Sel","fld":"vTFRESIDENTLASTNAME_SEL"},{"av":"AV26TFResidentBsnNumber","fld":"vTFRESIDENTBSNNUMBER"},{"av":"AV27TFResidentBsnNumber_Sel","fld":"vTFRESIDENTBSNNUMBER_SEL"},{"av":"AV28TFResidentEmail","fld":"vTFRESIDENTEMAIL"},{"av":"AV29TFResidentEmail_Sel","fld":"vTFRESIDENTEMAIL_SEL"},{"av":"AV31TFResidentGender_Sels","fld":"vTFRESIDENTGENDER_SELS"},{"av":"AV32TFResidentPhone","fld":"vTFRESIDENTPHONE"},{"av":"AV33TFResidentPhone_Sel","fld":"vTFRESIDENTPHONE_SEL"},{"av":"AV34TFResidentBirthDate","fld":"vTFRESIDENTBIRTHDATE"},{"av":"AV35TFResidentBirthDate_To","fld":"vTFRESIDENTBIRTHDATE_TO"},{"av":"AV39TFResidentTypeName","fld":"vTFRESIDENTTYPENAME"},{"av":"AV40TFResidentTypeName_Sel","fld":"vTFRESIDENTTYPENAME_SEL"},{"av":"AV41TFMedicalIndicationName","fld":"vTFMEDICALINDICATIONNAME"},{"av":"AV42TFMedicalIndicationName_Sel","fld":"vTFMEDICALINDICATIONNAME_SEL"},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_ResidentGivenName","fld":"vISAUTHORIZED_RESIDENTGIVENNAME","hsh":true},{"av":"AV60IsAuthorized_ResidentTypeName","fld":"vISAUTHORIZED_RESIDENTTYPENAME","hsh":true},{"av":"AV59IsAuthorized_MedicalIndicationName","fld":"vISAUTHORIZED_MEDICALINDICATIONNAME","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A62ResidentId","fld":"RESIDENTID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV47GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV48GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV49GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV54IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E14662","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VALID_RESIDENTTYPEID","""{"handler":"Valid_Residenttypeid","iparms":[]}""");
         setEventMetadata("VALID_MEDICALINDICATIONID","""{"handler":"Valid_Medicalindicationid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Residentaddressline2","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV61Pgmname = "";
         AV21TFResidentSalutation_Sels = new GxSimpleCollection<string>();
         AV22TFResidentGivenName = "";
         AV23TFResidentGivenName_Sel = "";
         AV24TFResidentLastName = "";
         AV25TFResidentLastName_Sel = "";
         AV26TFResidentBsnNumber = "";
         AV27TFResidentBsnNumber_Sel = "";
         AV28TFResidentEmail = "";
         AV29TFResidentEmail_Sel = "";
         AV31TFResidentGender_Sels = new GxSimpleCollection<string>();
         AV32TFResidentPhone = "";
         AV33TFResidentPhone_Sel = "";
         AV34TFResidentBirthDate = DateTime.MinValue;
         AV35TFResidentBirthDate_To = DateTime.MinValue;
         AV39TFResidentTypeName = "";
         AV40TFResidentTypeName_Sel = "";
         AV41TFMedicalIndicationName = "";
         AV42TFMedicalIndicationName_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV49GridAppliedFilters = "";
         AV43DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV36DDO_ResidentBirthDateAuxDate = DateTime.MinValue;
         AV37DDO_ResidentBirthDateAuxDateTo = DateTime.MinValue;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV20TFResidentSalutation_SelsJson = "";
         AV30TFResidentGender_SelsJson = "";
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
         AV38DDO_ResidentBirthDateAuxDateText = "";
         ucTfresidentbirthdate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A72ResidentSalutation = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A66ResidentInitials = "";
         A63ResidentBsnNumber = "";
         A67ResidentEmail = "";
         A68ResidentGender = "";
         A70ResidentPhone = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A71ResidentGUID = "";
         A96ResidentTypeId = Guid.Empty;
         A97ResidentTypeName = "";
         A98MedicalIndicationId = Guid.Empty;
         A99MedicalIndicationName = "";
         AV51Display = "";
         AV53Update = "";
         AV55Delete = "";
         A354ResidentCountry = "";
         A355ResidentCity = "";
         A356ResidentZipCode = "";
         A357ResidentAddressLine1 = "";
         A358ResidentAddressLine2 = "";
         AV63Trn_residentwwds_2_tfresidentsalutation_sels = new GxSimpleCollection<string>();
         AV72Trn_residentwwds_11_tfresidentgender_sels = new GxSimpleCollection<string>();
         lV62Trn_residentwwds_1_filterfulltext = "";
         lV64Trn_residentwwds_3_tfresidentgivenname = "";
         lV66Trn_residentwwds_5_tfresidentlastname = "";
         lV68Trn_residentwwds_7_tfresidentbsnnumber = "";
         lV70Trn_residentwwds_9_tfresidentemail = "";
         lV73Trn_residentwwds_12_tfresidentphone = "";
         lV77Trn_residentwwds_16_tfresidenttypename = "";
         lV79Trn_residentwwds_18_tfmedicalindicationname = "";
         AV62Trn_residentwwds_1_filterfulltext = "";
         AV65Trn_residentwwds_4_tfresidentgivenname_sel = "";
         AV64Trn_residentwwds_3_tfresidentgivenname = "";
         AV67Trn_residentwwds_6_tfresidentlastname_sel = "";
         AV66Trn_residentwwds_5_tfresidentlastname = "";
         AV69Trn_residentwwds_8_tfresidentbsnnumber_sel = "";
         AV68Trn_residentwwds_7_tfresidentbsnnumber = "";
         AV71Trn_residentwwds_10_tfresidentemail_sel = "";
         AV70Trn_residentwwds_9_tfresidentemail = "";
         AV74Trn_residentwwds_13_tfresidentphone_sel = "";
         AV73Trn_residentwwds_12_tfresidentphone = "";
         AV75Trn_residentwwds_14_tfresidentbirthdate = DateTime.MinValue;
         AV76Trn_residentwwds_15_tfresidentbirthdate_to = DateTime.MinValue;
         AV78Trn_residentwwds_17_tfresidenttypename_sel = "";
         AV77Trn_residentwwds_16_tfresidenttypename = "";
         AV80Trn_residentwwds_19_tfmedicalindicationname_sel = "";
         AV79Trn_residentwwds_18_tfmedicalindicationname = "";
         H00662_A358ResidentAddressLine2 = new string[] {""} ;
         H00662_A357ResidentAddressLine1 = new string[] {""} ;
         H00662_A356ResidentZipCode = new string[] {""} ;
         H00662_A355ResidentCity = new string[] {""} ;
         H00662_A354ResidentCountry = new string[] {""} ;
         H00662_A99MedicalIndicationName = new string[] {""} ;
         H00662_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H00662_A97ResidentTypeName = new string[] {""} ;
         H00662_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H00662_A71ResidentGUID = new string[] {""} ;
         H00662_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         H00662_A70ResidentPhone = new string[] {""} ;
         H00662_A68ResidentGender = new string[] {""} ;
         H00662_A67ResidentEmail = new string[] {""} ;
         H00662_A63ResidentBsnNumber = new string[] {""} ;
         H00662_A66ResidentInitials = new string[] {""} ;
         H00662_A65ResidentLastName = new string[] {""} ;
         H00662_A64ResidentGivenName = new string[] {""} ;
         H00662_A72ResidentSalutation = new string[] {""} ;
         H00662_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00662_A29LocationId = new Guid[] {Guid.Empty} ;
         H00662_A62ResidentId = new Guid[] {Guid.Empty} ;
         H00663_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV44GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV45GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
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
         AV58AuxText = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentww__default(),
            new Object[][] {
                new Object[] {
               H00662_A358ResidentAddressLine2, H00662_A357ResidentAddressLine1, H00662_A356ResidentZipCode, H00662_A355ResidentCity, H00662_A354ResidentCountry, H00662_A99MedicalIndicationName, H00662_A98MedicalIndicationId, H00662_A97ResidentTypeName, H00662_A96ResidentTypeId, H00662_A71ResidentGUID,
               H00662_A73ResidentBirthDate, H00662_A70ResidentPhone, H00662_A68ResidentGender, H00662_A67ResidentEmail, H00662_A63ResidentBsnNumber, H00662_A66ResidentInitials, H00662_A65ResidentLastName, H00662_A64ResidentGivenName, H00662_A72ResidentSalutation, H00662_A11OrganisationId,
               H00662_A29LocationId, H00662_A62ResidentId
               }
               , new Object[] {
               H00663_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV61Pgmname = "Trn_ResidentWW";
         /* GeneXus formulas. */
         AV61Pgmname = "Trn_ResidentWW";
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
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count ;
      private int AV72Trn_residentwwds_11_tfresidentgender_sels_Count ;
      private int edtResidentId_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtResidentGivenName_Enabled ;
      private int edtResidentLastName_Enabled ;
      private int edtResidentInitials_Enabled ;
      private int edtResidentBsnNumber_Enabled ;
      private int edtResidentEmail_Enabled ;
      private int edtResidentPhone_Enabled ;
      private int edtResidentBirthDate_Enabled ;
      private int edtResidentGUID_Enabled ;
      private int edtResidentTypeId_Enabled ;
      private int edtResidentTypeName_Enabled ;
      private int edtMedicalIndicationId_Enabled ;
      private int edtMedicalIndicationName_Enabled ;
      private int edtResidentCountry_Enabled ;
      private int edtResidentCity_Enabled ;
      private int edtResidentZipCode_Enabled ;
      private int edtResidentAddressLine1_Enabled ;
      private int edtResidentAddressLine2_Enabled ;
      private int AV46PageToGo ;
      private int edtavDisplay_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV81GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV47GridCurrentPage ;
      private long AV48GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV61Pgmname ;
      private string AV32TFResidentPhone ;
      private string AV33TFResidentPhone_Sel ;
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
      private string divDdo_residentbirthdateauxdates_Internalname ;
      private string edtavDdo_residentbirthdateauxdatetext_Internalname ;
      private string edtavDdo_residentbirthdateauxdatetext_Jsonclick ;
      private string Tfresidentbirthdate_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtResidentId_Internalname ;
      private string edtLocationId_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string cmbResidentSalutation_Internalname ;
      private string A72ResidentSalutation ;
      private string edtResidentGivenName_Internalname ;
      private string edtResidentLastName_Internalname ;
      private string A66ResidentInitials ;
      private string edtResidentInitials_Internalname ;
      private string edtResidentBsnNumber_Internalname ;
      private string edtResidentEmail_Internalname ;
      private string cmbResidentGender_Internalname ;
      private string A70ResidentPhone ;
      private string edtResidentPhone_Internalname ;
      private string edtResidentBirthDate_Internalname ;
      private string edtResidentGUID_Internalname ;
      private string edtResidentTypeId_Internalname ;
      private string edtResidentTypeName_Internalname ;
      private string edtMedicalIndicationId_Internalname ;
      private string edtMedicalIndicationName_Internalname ;
      private string AV51Display ;
      private string edtavDisplay_Internalname ;
      private string AV53Update ;
      private string edtavUpdate_Internalname ;
      private string AV55Delete ;
      private string edtavDelete_Internalname ;
      private string edtResidentCountry_Internalname ;
      private string edtResidentCity_Internalname ;
      private string edtResidentZipCode_Internalname ;
      private string edtResidentAddressLine1_Internalname ;
      private string edtResidentAddressLine2_Internalname ;
      private string lV73Trn_residentwwds_12_tfresidentphone ;
      private string AV74Trn_residentwwds_13_tfresidentphone_sel ;
      private string AV73Trn_residentwwds_12_tfresidentphone ;
      private string edtavDisplay_Link ;
      private string GXEncryptionTmp ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtResidentGivenName_Link ;
      private string edtResidentTypeName_Link ;
      private string edtMedicalIndicationName_Link ;
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
      private string edtResidentId_Jsonclick ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Jsonclick ;
      private string GXCCtl ;
      private string cmbResidentSalutation_Jsonclick ;
      private string edtResidentGivenName_Jsonclick ;
      private string edtResidentLastName_Jsonclick ;
      private string edtResidentInitials_Jsonclick ;
      private string edtResidentBsnNumber_Jsonclick ;
      private string edtResidentEmail_Jsonclick ;
      private string cmbResidentGender_Jsonclick ;
      private string gxphoneLink ;
      private string edtResidentPhone_Jsonclick ;
      private string edtResidentBirthDate_Jsonclick ;
      private string edtResidentGUID_Jsonclick ;
      private string edtResidentTypeId_Jsonclick ;
      private string edtResidentTypeName_Jsonclick ;
      private string edtMedicalIndicationId_Jsonclick ;
      private string edtMedicalIndicationName_Jsonclick ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtResidentCountry_Jsonclick ;
      private string edtResidentCity_Jsonclick ;
      private string edtResidentZipCode_Jsonclick ;
      private string edtResidentAddressLine1_Jsonclick ;
      private string edtResidentAddressLine2_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV34TFResidentBirthDate ;
      private DateTime AV35TFResidentBirthDate_To ;
      private DateTime AV36DDO_ResidentBirthDateAuxDate ;
      private DateTime AV37DDO_ResidentBirthDateAuxDateTo ;
      private DateTime A73ResidentBirthDate ;
      private DateTime AV75Trn_residentwwds_14_tfresidentbirthdate ;
      private DateTime AV76Trn_residentwwds_15_tfresidentbirthdate_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV52IsAuthorized_Display ;
      private bool AV54IsAuthorized_Update ;
      private bool AV56IsAuthorized_Delete ;
      private bool AV50IsAuthorized_ResidentGivenName ;
      private bool AV60IsAuthorized_ResidentTypeName ;
      private bool AV59IsAuthorized_MedicalIndicationName ;
      private bool AV57IsAuthorized_Insert ;
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
      private string AV20TFResidentSalutation_SelsJson ;
      private string AV30TFResidentGender_SelsJson ;
      private string AV18ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV22TFResidentGivenName ;
      private string AV23TFResidentGivenName_Sel ;
      private string AV24TFResidentLastName ;
      private string AV25TFResidentLastName_Sel ;
      private string AV26TFResidentBsnNumber ;
      private string AV27TFResidentBsnNumber_Sel ;
      private string AV28TFResidentEmail ;
      private string AV29TFResidentEmail_Sel ;
      private string AV39TFResidentTypeName ;
      private string AV40TFResidentTypeName_Sel ;
      private string AV41TFMedicalIndicationName ;
      private string AV42TFMedicalIndicationName_Sel ;
      private string AV49GridAppliedFilters ;
      private string AV38DDO_ResidentBirthDateAuxDateText ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A63ResidentBsnNumber ;
      private string A67ResidentEmail ;
      private string A68ResidentGender ;
      private string A71ResidentGUID ;
      private string A97ResidentTypeName ;
      private string A99MedicalIndicationName ;
      private string A354ResidentCountry ;
      private string A355ResidentCity ;
      private string A356ResidentZipCode ;
      private string A357ResidentAddressLine1 ;
      private string A358ResidentAddressLine2 ;
      private string lV62Trn_residentwwds_1_filterfulltext ;
      private string lV64Trn_residentwwds_3_tfresidentgivenname ;
      private string lV66Trn_residentwwds_5_tfresidentlastname ;
      private string lV68Trn_residentwwds_7_tfresidentbsnnumber ;
      private string lV70Trn_residentwwds_9_tfresidentemail ;
      private string lV77Trn_residentwwds_16_tfresidenttypename ;
      private string lV79Trn_residentwwds_18_tfmedicalindicationname ;
      private string AV62Trn_residentwwds_1_filterfulltext ;
      private string AV65Trn_residentwwds_4_tfresidentgivenname_sel ;
      private string AV64Trn_residentwwds_3_tfresidentgivenname ;
      private string AV67Trn_residentwwds_6_tfresidentlastname_sel ;
      private string AV66Trn_residentwwds_5_tfresidentlastname ;
      private string AV69Trn_residentwwds_8_tfresidentbsnnumber_sel ;
      private string AV68Trn_residentwwds_7_tfresidentbsnnumber ;
      private string AV71Trn_residentwwds_10_tfresidentemail_sel ;
      private string AV70Trn_residentwwds_9_tfresidentemail ;
      private string AV78Trn_residentwwds_17_tfresidenttypename_sel ;
      private string AV77Trn_residentwwds_16_tfresidenttypename ;
      private string AV80Trn_residentwwds_19_tfmedicalindicationname_sel ;
      private string AV79Trn_residentwwds_18_tfmedicalindicationname ;
      private string AV58AuxText ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A96ResidentTypeId ;
      private Guid A98MedicalIndicationId ;
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
      private GXUserControl ucTfresidentbirthdate_rangepicker ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbResidentSalutation ;
      private GXCombobox cmbResidentGender ;
      private GxSimpleCollection<string> AV21TFResidentSalutation_Sels ;
      private GxSimpleCollection<string> AV31TFResidentGender_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV43DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GxSimpleCollection<string> AV63Trn_residentwwds_2_tfresidentsalutation_sels ;
      private GxSimpleCollection<string> AV72Trn_residentwwds_11_tfresidentgender_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H00662_A358ResidentAddressLine2 ;
      private string[] H00662_A357ResidentAddressLine1 ;
      private string[] H00662_A356ResidentZipCode ;
      private string[] H00662_A355ResidentCity ;
      private string[] H00662_A354ResidentCountry ;
      private string[] H00662_A99MedicalIndicationName ;
      private Guid[] H00662_A98MedicalIndicationId ;
      private string[] H00662_A97ResidentTypeName ;
      private Guid[] H00662_A96ResidentTypeId ;
      private string[] H00662_A71ResidentGUID ;
      private DateTime[] H00662_A73ResidentBirthDate ;
      private string[] H00662_A70ResidentPhone ;
      private string[] H00662_A68ResidentGender ;
      private string[] H00662_A67ResidentEmail ;
      private string[] H00662_A63ResidentBsnNumber ;
      private string[] H00662_A66ResidentInitials ;
      private string[] H00662_A65ResidentLastName ;
      private string[] H00662_A64ResidentGivenName ;
      private string[] H00662_A72ResidentSalutation ;
      private Guid[] H00662_A11OrganisationId ;
      private Guid[] H00662_A29LocationId ;
      private Guid[] H00662_A62ResidentId ;
      private long[] H00663_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV44GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV45GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_residentww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00662( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV72Trn_residentwwds_11_tfresidentgender_sels ,
                                             string AV62Trn_residentwwds_1_filterfulltext ,
                                             int AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV64Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV66Trn_residentwwds_5_tfresidentlastname ,
                                             string AV69Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                             string AV68Trn_residentwwds_7_tfresidentbsnnumber ,
                                             string AV71Trn_residentwwds_10_tfresidentemail_sel ,
                                             string AV70Trn_residentwwds_9_tfresidentemail ,
                                             int AV72Trn_residentwwds_11_tfresidentgender_sels_Count ,
                                             string AV74Trn_residentwwds_13_tfresidentphone_sel ,
                                             string AV73Trn_residentwwds_12_tfresidentphone ,
                                             DateTime AV75Trn_residentwwds_14_tfresidentbirthdate ,
                                             DateTime AV76Trn_residentwwds_15_tfresidentbirthdate_to ,
                                             string AV78Trn_residentwwds_17_tfresidenttypename_sel ,
                                             string AV77Trn_residentwwds_16_tfresidenttypename ,
                                             string AV80Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                             string AV79Trn_residentwwds_18_tfmedicalindicationname ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A63ResidentBsnNumber ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string A99MedicalIndicationName ,
                                             DateTime A73ResidentBirthDate ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[33];
         Object[] GXv_Object14 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.ResidentAddressLine2, T1.ResidentAddressLine1, T1.ResidentZipCode, T1.ResidentCity, T1.ResidentCountry, T2.MedicalIndicationName, T1.MedicalIndicationId, T3.ResidentTypeName, T1.ResidentTypeId, T1.ResidentGUID, T1.ResidentBirthDate, T1.ResidentPhone, T1.ResidentGender, T1.ResidentEmail, T1.ResidentBsnNumber, T1.ResidentInitials, T1.ResidentLastName, T1.ResidentGivenName, T1.ResidentSalutation, T1.OrganisationId, T1.LocationId, T1.ResidentId";
         sFromString = " FROM ((Trn_Resident T1 INNER JOIN Trn_MedicalIndication T2 ON T2.MedicalIndicationId = T1.MedicalIndicationId) INNER JOIN Trn_ResidentType T3 ON T3.ResidentTypeId = T1.ResidentTypeId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'mr' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mr')) or ( 'mrs' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mrs')) or ( 'dr' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Dr')) or ( 'miss' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Miss')) or ( T1.ResidentGivenName like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Other')) or ( T1.ResidentPhone like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( T3.ResidentTypeName like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( T2.MedicalIndicationName like '%' || :lV62Trn_residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int13[0] = 1;
            GXv_int13[1] = 1;
            GXv_int13[2] = 1;
            GXv_int13[3] = 1;
            GXv_int13[4] = 1;
            GXv_int13[5] = 1;
            GXv_int13[6] = 1;
            GXv_int13[7] = 1;
            GXv_int13[8] = 1;
            GXv_int13[9] = 1;
            GXv_int13[10] = 1;
            GXv_int13[11] = 1;
            GXv_int13[12] = 1;
            GXv_int13[13] = 1;
         }
         if ( AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV64Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV65Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV66Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV67Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_7_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV68Trn_residentwwds_7_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV69Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV69Trn_residentwwds_8_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV70Trn_residentwwds_9_tfresidentemail)");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV71Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV71Trn_residentwwds_10_tfresidentemail_sel))");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( AV72Trn_residentwwds_11_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV72Trn_residentwwds_11_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV73Trn_residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV74Trn_residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int13[23] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( ! (DateTime.MinValue==AV75Trn_residentwwds_14_tfresidentbirthdate) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate >= :AV75Trn_residentwwds_14_tfresidentbirthdate)");
         }
         else
         {
            GXv_int13[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Trn_residentwwds_15_tfresidentbirthdate_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate <= :AV76Trn_residentwwds_15_tfresidentbirthdate_to)");
         }
         else
         {
            GXv_int13[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_residentwwds_17_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_residentwwds_16_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T3.ResidentTypeName like :lV77Trn_residentwwds_16_tfresidenttypename)");
         }
         else
         {
            GXv_int13[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_residentwwds_17_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV78Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ResidentTypeName = ( :AV78Trn_residentwwds_17_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int13[27] = 1;
         }
         if ( StringUtil.StrCmp(AV78Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ResidentTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_residentwwds_19_tfmedicalindicationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_residentwwds_18_tfmedicalindicationname)) ) )
         {
            AddWhere(sWhereString, "(T2.MedicalIndicationName like :lV79Trn_residentwwds_18_tfmedicalindicationname)");
         }
         else
         {
            GXv_int13[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_residentwwds_19_tfmedicalindicationname_sel)) && ! ( StringUtil.StrCmp(AV80Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.MedicalIndicationName = ( :AV80Trn_residentwwds_19_tfmedicalindicationname_sel))");
         }
         else
         {
            GXv_int13[29] = 1;
         }
         if ( StringUtil.StrCmp(AV80Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.MedicalIndicationName))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentGivenName, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentGivenName DESC, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentSalutation, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentSalutation DESC, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentLastName, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentLastName DESC, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentBsnNumber, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentBsnNumber DESC, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentEmail, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentEmail DESC, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentGender, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentGender DESC, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentPhone, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentPhone DESC, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ResidentBirthDate, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ResidentBirthDate DESC, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.ResidentTypeName, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.ResidentTypeName DESC, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.MedicalIndicationName, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.MedicalIndicationName DESC, T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_H00663( IGxContext context ,
                                             string A72ResidentSalutation ,
                                             GxSimpleCollection<string> AV63Trn_residentwwds_2_tfresidentsalutation_sels ,
                                             string A68ResidentGender ,
                                             GxSimpleCollection<string> AV72Trn_residentwwds_11_tfresidentgender_sels ,
                                             string AV62Trn_residentwwds_1_filterfulltext ,
                                             int AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count ,
                                             string AV65Trn_residentwwds_4_tfresidentgivenname_sel ,
                                             string AV64Trn_residentwwds_3_tfresidentgivenname ,
                                             string AV67Trn_residentwwds_6_tfresidentlastname_sel ,
                                             string AV66Trn_residentwwds_5_tfresidentlastname ,
                                             string AV69Trn_residentwwds_8_tfresidentbsnnumber_sel ,
                                             string AV68Trn_residentwwds_7_tfresidentbsnnumber ,
                                             string AV71Trn_residentwwds_10_tfresidentemail_sel ,
                                             string AV70Trn_residentwwds_9_tfresidentemail ,
                                             int AV72Trn_residentwwds_11_tfresidentgender_sels_Count ,
                                             string AV74Trn_residentwwds_13_tfresidentphone_sel ,
                                             string AV73Trn_residentwwds_12_tfresidentphone ,
                                             DateTime AV75Trn_residentwwds_14_tfresidentbirthdate ,
                                             DateTime AV76Trn_residentwwds_15_tfresidentbirthdate_to ,
                                             string AV78Trn_residentwwds_17_tfresidenttypename_sel ,
                                             string AV77Trn_residentwwds_16_tfresidenttypename ,
                                             string AV80Trn_residentwwds_19_tfmedicalindicationname_sel ,
                                             string AV79Trn_residentwwds_18_tfmedicalindicationname ,
                                             string A64ResidentGivenName ,
                                             string A65ResidentLastName ,
                                             string A63ResidentBsnNumber ,
                                             string A67ResidentEmail ,
                                             string A70ResidentPhone ,
                                             string A97ResidentTypeName ,
                                             string A99MedicalIndicationName ,
                                             DateTime A73ResidentBirthDate ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[30];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((Trn_Resident T1 INNER JOIN Trn_MedicalIndication T3 ON T3.MedicalIndicationId = T1.MedicalIndicationId) INNER JOIN Trn_ResidentType T2 ON T2.ResidentTypeId = T1.ResidentTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Trn_residentwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'mr' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mr')) or ( 'mrs' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Mrs')) or ( 'dr' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Dr')) or ( 'miss' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentSalutation = ( 'Miss')) or ( T1.ResidentGivenName like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( T1.ResidentLastName like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( T1.ResidentBsnNumber like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( T1.ResidentEmail like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( 'male' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Male')) or ( 'female' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Female')) or ( 'other' like '%' || LOWER(:lV62Trn_residentwwds_1_filterfulltext) and T1.ResidentGender = ( 'Other')) or ( T1.ResidentPhone like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( T2.ResidentTypeName like '%' || :lV62Trn_residentwwds_1_filterfulltext) or ( T3.MedicalIndicationName like '%' || :lV62Trn_residentwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int15[0] = 1;
            GXv_int15[1] = 1;
            GXv_int15[2] = 1;
            GXv_int15[3] = 1;
            GXv_int15[4] = 1;
            GXv_int15[5] = 1;
            GXv_int15[6] = 1;
            GXv_int15[7] = 1;
            GXv_int15[8] = 1;
            GXv_int15[9] = 1;
            GXv_int15[10] = 1;
            GXv_int15[11] = 1;
            GXv_int15[12] = 1;
            GXv_int15[13] = 1;
         }
         if ( AV63Trn_residentwwds_2_tfresidentsalutation_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Trn_residentwwds_2_tfresidentsalutation_sels, "T1.ResidentSalutation IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_residentwwds_3_tfresidentgivenname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName like :lV64Trn_residentwwds_3_tfresidentgivenname)");
         }
         else
         {
            GXv_int15[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Trn_residentwwds_4_tfresidentgivenname_sel)) && ! ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentGivenName = ( :AV65Trn_residentwwds_4_tfresidentgivenname_sel))");
         }
         else
         {
            GXv_int15[15] = 1;
         }
         if ( StringUtil.StrCmp(AV65Trn_residentwwds_4_tfresidentgivenname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentGivenName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Trn_residentwwds_5_tfresidentlastname)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName like :lV66Trn_residentwwds_5_tfresidentlastname)");
         }
         else
         {
            GXv_int15[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_residentwwds_6_tfresidentlastname_sel)) && ! ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentLastName = ( :AV67Trn_residentwwds_6_tfresidentlastname_sel))");
         }
         else
         {
            GXv_int15[17] = 1;
         }
         if ( StringUtil.StrCmp(AV67Trn_residentwwds_6_tfresidentlastname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentLastName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_residentwwds_7_tfresidentbsnnumber)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber like :lV68Trn_residentwwds_7_tfresidentbsnnumber)");
         }
         else
         {
            GXv_int15[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_residentwwds_8_tfresidentbsnnumber_sel)) && ! ( StringUtil.StrCmp(AV69Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentBsnNumber = ( :AV69Trn_residentwwds_8_tfresidentbsnnumber_sel))");
         }
         else
         {
            GXv_int15[19] = 1;
         }
         if ( StringUtil.StrCmp(AV69Trn_residentwwds_8_tfresidentbsnnumber_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentBsnNumber))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_residentwwds_9_tfresidentemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail like :lV70Trn_residentwwds_9_tfresidentemail)");
         }
         else
         {
            GXv_int15[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_residentwwds_10_tfresidentemail_sel)) && ! ( StringUtil.StrCmp(AV71Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentEmail = ( :AV71Trn_residentwwds_10_tfresidentemail_sel))");
         }
         else
         {
            GXv_int15[21] = 1;
         }
         if ( StringUtil.StrCmp(AV71Trn_residentwwds_10_tfresidentemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentEmail))=0))");
         }
         if ( AV72Trn_residentwwds_11_tfresidentgender_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV72Trn_residentwwds_11_tfresidentgender_sels, "T1.ResidentGender IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidentphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_residentwwds_12_tfresidentphone)) ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone like :lV73Trn_residentwwds_12_tfresidentphone)");
         }
         else
         {
            GXv_int15[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_residentwwds_13_tfresidentphone_sel)) && ! ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResidentPhone = ( :AV74Trn_residentwwds_13_tfresidentphone_sel))");
         }
         else
         {
            GXv_int15[23] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_residentwwds_13_tfresidentphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.ResidentPhone))=0))");
         }
         if ( ! (DateTime.MinValue==AV75Trn_residentwwds_14_tfresidentbirthdate) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate >= :AV75Trn_residentwwds_14_tfresidentbirthdate)");
         }
         else
         {
            GXv_int15[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Trn_residentwwds_15_tfresidentbirthdate_to) )
         {
            AddWhere(sWhereString, "(T1.ResidentBirthDate <= :AV76Trn_residentwwds_15_tfresidentbirthdate_to)");
         }
         else
         {
            GXv_int15[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_residentwwds_17_tfresidenttypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Trn_residentwwds_16_tfresidenttypename)) ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName like :lV77Trn_residentwwds_16_tfresidenttypename)");
         }
         else
         {
            GXv_int15[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Trn_residentwwds_17_tfresidenttypename_sel)) && ! ( StringUtil.StrCmp(AV78Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ResidentTypeName = ( :AV78Trn_residentwwds_17_tfresidenttypename_sel))");
         }
         else
         {
            GXv_int15[27] = 1;
         }
         if ( StringUtil.StrCmp(AV78Trn_residentwwds_17_tfresidenttypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ResidentTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_residentwwds_19_tfmedicalindicationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Trn_residentwwds_18_tfmedicalindicationname)) ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName like :lV79Trn_residentwwds_18_tfmedicalindicationname)");
         }
         else
         {
            GXv_int15[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Trn_residentwwds_19_tfmedicalindicationname_sel)) && ! ( StringUtil.StrCmp(AV80Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.MedicalIndicationName = ( :AV80Trn_residentwwds_19_tfmedicalindicationname_sel))");
         }
         else
         {
            GXv_int15[29] = 1;
         }
         if ( StringUtil.StrCmp(AV80Trn_residentwwds_19_tfmedicalindicationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.MedicalIndicationName))=0))");
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
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
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
                     return conditional_H00662(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] , (short)dynConstraints[31] , (bool)dynConstraints[32] );
               case 1 :
                     return conditional_H00663(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] , (short)dynConstraints[31] , (bool)dynConstraints[32] );
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
          Object[] prmH00662;
          prmH00662 = new Object[] {
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_residentwwds_7_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV69Trn_residentwwds_8_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Trn_residentwwds_9_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV71Trn_residentwwds_10_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV74Trn_residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("AV75Trn_residentwwds_14_tfresidentbirthdate",GXType.Date,8,0) ,
          new ParDef("AV76Trn_residentwwds_15_tfresidentbirthdate_to",GXType.Date,8,0) ,
          new ParDef("lV77Trn_residentwwds_16_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV78Trn_residentwwds_17_tfresidenttypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV79Trn_residentwwds_18_tfmedicalindicationname",GXType.VarChar,100,0) ,
          new ParDef("AV80Trn_residentwwds_19_tfmedicalindicationname_sel",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00663;
          prmH00663 = new Object[] {
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Trn_residentwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_residentwwds_3_tfresidentgivenname",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_residentwwds_4_tfresidentgivenname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Trn_residentwwds_5_tfresidentlastname",GXType.VarChar,100,0) ,
          new ParDef("AV67Trn_residentwwds_6_tfresidentlastname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV68Trn_residentwwds_7_tfresidentbsnnumber",GXType.VarChar,40,0) ,
          new ParDef("AV69Trn_residentwwds_8_tfresidentbsnnumber_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Trn_residentwwds_9_tfresidentemail",GXType.VarChar,100,0) ,
          new ParDef("AV71Trn_residentwwds_10_tfresidentemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_residentwwds_12_tfresidentphone",GXType.Char,20,0) ,
          new ParDef("AV74Trn_residentwwds_13_tfresidentphone_sel",GXType.Char,20,0) ,
          new ParDef("AV75Trn_residentwwds_14_tfresidentbirthdate",GXType.Date,8,0) ,
          new ParDef("AV76Trn_residentwwds_15_tfresidentbirthdate_to",GXType.Date,8,0) ,
          new ParDef("lV77Trn_residentwwds_16_tfresidenttypename",GXType.VarChar,100,0) ,
          new ParDef("AV78Trn_residentwwds_17_tfresidenttypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV79Trn_residentwwds_18_tfmedicalindicationname",GXType.VarChar,100,0) ,
          new ParDef("AV80Trn_residentwwds_19_tfmedicalindicationname_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00662", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00662,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00663", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00663,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((string[]) buf[17])[0] = rslt.getVarchar(18);
                ((string[]) buf[18])[0] = rslt.getString(19, 20);
                ((Guid[]) buf[19])[0] = rslt.getGuid(20);
                ((Guid[]) buf[20])[0] = rslt.getGuid(21);
                ((Guid[]) buf[21])[0] = rslt.getGuid(22);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
