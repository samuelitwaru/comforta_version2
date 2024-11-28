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
   public class wp_organisationgeneralsuppliers : GXDataArea
   {
      public wp_organisationgeneralsuppliers( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_organisationgeneralsuppliers( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
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
         chkavIsselected = new GXCheckbox();
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
         AV19OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV20OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV21FilterFullText = GetPar( "FilterFullText");
         AV26ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV61ColumnsSelector);
         AV63Pgmname = GetPar( "Pgmname");
         A429PreferredGenOrganisationId = StringUtil.StrToGuid( GetPar( "PreferredGenOrganisationId"));
         AV56OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         A426PreferredSupplierGenId = StringUtil.StrToGuid( GetPar( "PreferredSupplierGenId"));
         AV27TFSupplierGenCompanyName = GetPar( "TFSupplierGenCompanyName");
         AV52TFSupplierGenCompanyNameOperator = (short)(Math.Round(NumberUtil.Val( GetPar( "TFSupplierGenCompanyNameOperator"), "."), 18, MidpointRounding.ToEven));
         AV28TFSupplierGenCompanyName_Sel = GetPar( "TFSupplierGenCompanyName_Sel");
         AV29TFSupplierGenTypeName = GetPar( "TFSupplierGenTypeName");
         AV30TFSupplierGenTypeName_Sel = GetPar( "TFSupplierGenTypeName_Sel");
         AV31TFSupplierGenContactName = GetPar( "TFSupplierGenContactName");
         AV32TFSupplierGenContactName_Sel = GetPar( "TFSupplierGenContactName_Sel");
         AV33TFSupplierGenContactPhone = GetPar( "TFSupplierGenContactPhone");
         AV34TFSupplierGenContactPhone_Sel = GetPar( "TFSupplierGenContactPhone_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV54PreferredSuppliers);
         AV45IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV47IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV49IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV50IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV19OrderedBy, AV20OrderedDsc, AV21FilterFullText, AV26ManageFiltersExecutionStep, AV61ColumnsSelector, AV63Pgmname, A429PreferredGenOrganisationId, AV56OrganisationId, A426PreferredSupplierGenId, AV27TFSupplierGenCompanyName, AV52TFSupplierGenCompanyNameOperator, AV28TFSupplierGenCompanyName_Sel, AV29TFSupplierGenTypeName, AV30TFSupplierGenTypeName_Sel, AV31TFSupplierGenContactName, AV32TFSupplierGenContactName_Sel, AV33TFSupplierGenContactPhone, AV34TFSupplierGenContactPhone_Sel, AV54PreferredSuppliers, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV50IsAuthorized_Insert) ;
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
            return "wp_organisationgeneralsuppliers_Execute" ;
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
         PA762( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START762( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_organisationgeneralsuppliers.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV56OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV56OrganisationId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPREFERREDSUPPLIERS", AV54PreferredSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPREFERREDSUPPLIERS", AV54PreferredSuppliers);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPREFERREDSUPPLIERS", GetSecureSignedToken( "", AV54PreferredSuppliers, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV20OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV21FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV41GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV35DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV35DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV61ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV61ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "PREFERREDGENORGANISATIONID", A429PreferredGenOrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV56OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV56OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "PREFERREDSUPPLIERGENID", A426PreferredSupplierGenId.ToString());
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCOMPANYNAME", AV27TFSupplierGenCompanyName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCOMPANYNAMEOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52TFSupplierGenCompanyNameOperator), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCOMPANYNAME_SEL", AV28TFSupplierGenCompanyName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENTYPENAME", AV29TFSupplierGenTypeName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENTYPENAME_SEL", AV30TFSupplierGenTypeName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCONTACTNAME", AV31TFSupplierGenContactName);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCONTACTNAME_SEL", AV32TFSupplierGenContactName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCONTACTPHONE", StringUtil.RTrim( AV33TFSupplierGenContactPhone));
         GxWebStd.gx_hidden_field( context, "vTFSUPPLIERGENCONTACTPHONE_SEL", StringUtil.RTrim( AV34TFSupplierGenContactPhone_Sel));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV20OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPREFERREDSUPPLIERS", AV54PreferredSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPREFERREDSUPPLIERS", AV54PreferredSuppliers);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPREFERREDSUPPLIERS", GetSecureSignedToken( "", AV54PreferredSuppliers, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV17GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV17GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_PREFERREDGENSUPPLIER", AV55Trn_PreferredGenSupplier);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_PREFERREDGENSUPPLIER", AV55Trn_PreferredGenSupplier);
         }
         GxWebStd.gx_hidden_field( context, "PREFERREDGENSUPPLIERID", A427PreferredGenSupplierId.ToString());
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixedfilters", StringUtil.RTrim( Ddo_grid_Fixedfilters));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedfixedfilter));
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
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
            WE762( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT762( ) ;
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
         return formatLink("wp_organisationgeneralsuppliers.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_OrganisationGeneralSuppliers" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " General Suppliers", "") ;
      }

      protected void WB760( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_OrganisationGeneralSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_OrganisationGeneralSuppliers.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_OrganisationGeneralSuppliers.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV24ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV21FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV21FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WP_OrganisationGeneralSuppliers.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV39GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV40GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV41GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("FixedFilters", Ddo_grid_Fixedfilters);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV35DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV35DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV61ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0070"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0070"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_39_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0070"+"");
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

      protected void START762( )
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
         Form.Meta.addItem("description", context.GetMessage( " General Suppliers", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP760( ) ;
      }

      protected void WS762( )
      {
         START762( ) ;
         EVT762( ) ;
      }

      protected void EVT762( )
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
                              E11762 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12762 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13762 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E14762 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E15762 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E16762 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E17762 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VISSELECTED.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VISSELECTED.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) )
                           {
                              nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
                              SubsflControlProps_392( ) ;
                              AV51isSelected = StringUtil.StrToBool( cgiGet( chkavIsselected_Internalname));
                              AssignAttri("", false, chkavIsselected_Internalname, AV51isSelected);
                              A42SupplierGenId = StringUtil.StrToGuid( cgiGet( edtSupplierGenId_Internalname));
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              n11OrganisationId = false;
                              A43SupplierGenKvkNumber = cgiGet( edtSupplierGenKvkNumber_Internalname);
                              AV53SupplierGenCompanyNameWithTags = cgiGet( edtavSuppliergencompanynamewithtags_Internalname);
                              AssignAttri("", false, edtavSuppliergencompanynamewithtags_Internalname, AV53SupplierGenCompanyNameWithTags);
                              A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
                              A282SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierGenTypeId_Internalname));
                              A290SupplierGenTypeName = cgiGet( edtSupplierGenTypeName_Internalname);
                              A335SupplierGenAddressCountry = cgiGet( edtSupplierGenAddressCountry_Internalname);
                              A295SupplierGenAddressCity = cgiGet( edtSupplierGenAddressCity_Internalname);
                              A294SupplierGenAddressZipCode = cgiGet( edtSupplierGenAddressZipCode_Internalname);
                              A336SupplierGenAddressLine1 = cgiGet( edtSupplierGenAddressLine1_Internalname);
                              A337SupplierGenAddressLine2 = cgiGet( edtSupplierGenAddressLine2_Internalname);
                              A47SupplierGenContactName = cgiGet( edtSupplierGenContactName_Internalname);
                              A48SupplierGenContactPhone = cgiGet( edtSupplierGenContactPhone_Internalname);
                              A381SupplierGenPhoneCode = cgiGet( edtSupplierGenPhoneCode_Internalname);
                              A382SupplierGenPhoneNumber = cgiGet( edtSupplierGenPhoneNumber_Internalname);
                              AV22SupplierAddress = cgiGet( edtavSupplieraddress_Internalname);
                              AssignAttri("", false, edtavSupplieraddress_Internalname, AV22SupplierAddress);
                              cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                              cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                              AV57ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV57ActionGroup), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18762 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E19762 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E20762 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E21762 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VISSELECTED.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E22762 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV19OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV20OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV21FilterFullText) != 0 )
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
                        if ( nCmpId == 70 )
                        {
                           OldWwpaux_wc = cgiGet( "W0070");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0070", "", sEvt);
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

      protected void WE762( )
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

      protected void PA762( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
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
                                       short AV19OrderedBy ,
                                       bool AV20OrderedDsc ,
                                       string AV21FilterFullText ,
                                       short AV26ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV61ColumnsSelector ,
                                       string AV63Pgmname ,
                                       Guid A429PreferredGenOrganisationId ,
                                       Guid AV56OrganisationId ,
                                       Guid A426PreferredSupplierGenId ,
                                       string AV27TFSupplierGenCompanyName ,
                                       short AV52TFSupplierGenCompanyNameOperator ,
                                       string AV28TFSupplierGenCompanyName_Sel ,
                                       string AV29TFSupplierGenTypeName ,
                                       string AV30TFSupplierGenTypeName_Sel ,
                                       string AV31TFSupplierGenContactName ,
                                       string AV32TFSupplierGenContactName_Sel ,
                                       string AV33TFSupplierGenContactPhone ,
                                       string AV34TFSupplierGenContactPhone_Sel ,
                                       GxSimpleCollection<Guid> AV54PreferredSuppliers ,
                                       bool AV45IsAuthorized_Display ,
                                       bool AV47IsAuthorized_Update ,
                                       bool AV49IsAuthorized_Delete ,
                                       bool AV50IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF762( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
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
         RF762( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV63Pgmname = "WP_OrganisationGeneralSuppliers";
         edtavSuppliergencompanynamewithtags_Enabled = 0;
         edtavSupplieraddress_Enabled = 0;
      }

      protected void RF762( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E19762 ();
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
                                                 AV65Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                                 AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                                 AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                                 AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                                 AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                                 AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                                 AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                                 AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                                 AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                                 AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                                 A44SupplierGenCompanyName ,
                                                 A290SupplierGenTypeName ,
                                                 A47SupplierGenContactName ,
                                                 A48SupplierGenContactPhone ,
                                                 AV51isSelected ,
                                                 AV19OrderedBy ,
                                                 AV20OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV65Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
            lV65Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
            lV65Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
            lV65Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
            lV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname), "%", "");
            lV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename), "%", "");
            lV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname), "%", "");
            lV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone), 20, "%");
            /* Using cursor H00762 */
            pr_default.execute(0, new Object[] {lV65Wp_organisationgeneralsuppliersds_1_filterfulltext, lV65Wp_organisationgeneralsuppliersds_1_filterfulltext, lV65Wp_organisationgeneralsuppliersds_1_filterfulltext, lV65Wp_organisationgeneralsuppliersds_1_filterfulltext, lV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname, AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, AV51isSelected, lV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename, AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, lV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname, AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, lV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone, AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A42SupplierGenId = H00762_A42SupplierGenId[0];
               A382SupplierGenPhoneNumber = H00762_A382SupplierGenPhoneNumber[0];
               A381SupplierGenPhoneCode = H00762_A381SupplierGenPhoneCode[0];
               A48SupplierGenContactPhone = H00762_A48SupplierGenContactPhone[0];
               A47SupplierGenContactName = H00762_A47SupplierGenContactName[0];
               A337SupplierGenAddressLine2 = H00762_A337SupplierGenAddressLine2[0];
               A336SupplierGenAddressLine1 = H00762_A336SupplierGenAddressLine1[0];
               A294SupplierGenAddressZipCode = H00762_A294SupplierGenAddressZipCode[0];
               A295SupplierGenAddressCity = H00762_A295SupplierGenAddressCity[0];
               A335SupplierGenAddressCountry = H00762_A335SupplierGenAddressCountry[0];
               A290SupplierGenTypeName = H00762_A290SupplierGenTypeName[0];
               A282SupplierGenTypeId = H00762_A282SupplierGenTypeId[0];
               A44SupplierGenCompanyName = H00762_A44SupplierGenCompanyName[0];
               A43SupplierGenKvkNumber = H00762_A43SupplierGenKvkNumber[0];
               A11OrganisationId = H00762_A11OrganisationId[0];
               n11OrganisationId = H00762_n11OrganisationId[0];
               A290SupplierGenTypeName = H00762_A290SupplierGenTypeName[0];
               /* Execute user event: Grid.Load */
               E20762 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 39;
            WB760( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes762( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV56OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV56OrganisationId, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPREFERREDSUPPLIERS", AV54PreferredSuppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPREFERREDSUPPLIERS", AV54PreferredSuppliers);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPREFERREDSUPPLIERS", GetSecureSignedToken( "", AV54PreferredSuppliers, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_SUPPLIERGENID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, A42SupplierGenId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
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
         AV65Wp_organisationgeneralsuppliersds_1_filterfulltext = AV21FilterFullText;
         AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = AV27TFSupplierGenCompanyName;
         AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator = AV52TFSupplierGenCompanyNameOperator;
         AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = AV28TFSupplierGenCompanyName_Sel;
         AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = AV29TFSupplierGenTypeName;
         AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = AV30TFSupplierGenTypeName_Sel;
         AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = AV31TFSupplierGenContactName;
         AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = AV32TFSupplierGenContactName_Sel;
         AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = AV33TFSupplierGenContactPhone;
         AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = AV34TFSupplierGenContactPhone_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV65Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                              AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                              AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                              AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                              AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                              AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                              AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                              AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                              AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                              AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                              A44SupplierGenCompanyName ,
                                              A290SupplierGenTypeName ,
                                              A47SupplierGenContactName ,
                                              A48SupplierGenContactPhone ,
                                              AV51isSelected ,
                                              AV19OrderedBy ,
                                              AV20OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV65Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV65Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV65Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV65Wp_organisationgeneralsuppliersds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wp_organisationgeneralsuppliersds_1_filterfulltext), "%", "");
         lV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = StringUtil.Concat( StringUtil.RTrim( AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname), "%", "");
         lV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = StringUtil.Concat( StringUtil.RTrim( AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename), "%", "");
         lV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = StringUtil.Concat( StringUtil.RTrim( AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname), "%", "");
         lV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = StringUtil.PadR( StringUtil.RTrim( AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone), 20, "%");
         /* Using cursor H00763 */
         pr_default.execute(1, new Object[] {lV65Wp_organisationgeneralsuppliersds_1_filterfulltext, lV65Wp_organisationgeneralsuppliersds_1_filterfulltext, lV65Wp_organisationgeneralsuppliersds_1_filterfulltext, lV65Wp_organisationgeneralsuppliersds_1_filterfulltext, lV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname, AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, AV51isSelected, lV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename, AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, lV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname, AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, lV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone, AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel});
         GRID_nRecordCount = H00763_AGRID_nRecordCount[0];
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
         AV65Wp_organisationgeneralsuppliersds_1_filterfulltext = AV21FilterFullText;
         AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = AV27TFSupplierGenCompanyName;
         AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator = AV52TFSupplierGenCompanyNameOperator;
         AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = AV28TFSupplierGenCompanyName_Sel;
         AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = AV29TFSupplierGenTypeName;
         AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = AV30TFSupplierGenTypeName_Sel;
         AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = AV31TFSupplierGenContactName;
         AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = AV32TFSupplierGenContactName_Sel;
         AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = AV33TFSupplierGenContactPhone;
         AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = AV34TFSupplierGenContactPhone_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19OrderedBy, AV20OrderedDsc, AV21FilterFullText, AV26ManageFiltersExecutionStep, AV61ColumnsSelector, AV63Pgmname, A429PreferredGenOrganisationId, AV56OrganisationId, A426PreferredSupplierGenId, AV27TFSupplierGenCompanyName, AV52TFSupplierGenCompanyNameOperator, AV28TFSupplierGenCompanyName_Sel, AV29TFSupplierGenTypeName, AV30TFSupplierGenTypeName_Sel, AV31TFSupplierGenContactName, AV32TFSupplierGenContactName_Sel, AV33TFSupplierGenContactPhone, AV34TFSupplierGenContactPhone_Sel, AV54PreferredSuppliers, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV65Wp_organisationgeneralsuppliersds_1_filterfulltext = AV21FilterFullText;
         AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = AV27TFSupplierGenCompanyName;
         AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator = AV52TFSupplierGenCompanyNameOperator;
         AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = AV28TFSupplierGenCompanyName_Sel;
         AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = AV29TFSupplierGenTypeName;
         AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = AV30TFSupplierGenTypeName_Sel;
         AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = AV31TFSupplierGenContactName;
         AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = AV32TFSupplierGenContactName_Sel;
         AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = AV33TFSupplierGenContactPhone;
         AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = AV34TFSupplierGenContactPhone_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV19OrderedBy, AV20OrderedDsc, AV21FilterFullText, AV26ManageFiltersExecutionStep, AV61ColumnsSelector, AV63Pgmname, A429PreferredGenOrganisationId, AV56OrganisationId, A426PreferredSupplierGenId, AV27TFSupplierGenCompanyName, AV52TFSupplierGenCompanyNameOperator, AV28TFSupplierGenCompanyName_Sel, AV29TFSupplierGenTypeName, AV30TFSupplierGenTypeName_Sel, AV31TFSupplierGenContactName, AV32TFSupplierGenContactName_Sel, AV33TFSupplierGenContactPhone, AV34TFSupplierGenContactPhone_Sel, AV54PreferredSuppliers, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV65Wp_organisationgeneralsuppliersds_1_filterfulltext = AV21FilterFullText;
         AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = AV27TFSupplierGenCompanyName;
         AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator = AV52TFSupplierGenCompanyNameOperator;
         AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = AV28TFSupplierGenCompanyName_Sel;
         AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = AV29TFSupplierGenTypeName;
         AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = AV30TFSupplierGenTypeName_Sel;
         AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = AV31TFSupplierGenContactName;
         AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = AV32TFSupplierGenContactName_Sel;
         AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = AV33TFSupplierGenContactPhone;
         AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = AV34TFSupplierGenContactPhone_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV19OrderedBy, AV20OrderedDsc, AV21FilterFullText, AV26ManageFiltersExecutionStep, AV61ColumnsSelector, AV63Pgmname, A429PreferredGenOrganisationId, AV56OrganisationId, A426PreferredSupplierGenId, AV27TFSupplierGenCompanyName, AV52TFSupplierGenCompanyNameOperator, AV28TFSupplierGenCompanyName_Sel, AV29TFSupplierGenTypeName, AV30TFSupplierGenTypeName_Sel, AV31TFSupplierGenContactName, AV32TFSupplierGenContactName_Sel, AV33TFSupplierGenContactPhone, AV34TFSupplierGenContactPhone_Sel, AV54PreferredSuppliers, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV65Wp_organisationgeneralsuppliersds_1_filterfulltext = AV21FilterFullText;
         AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = AV27TFSupplierGenCompanyName;
         AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator = AV52TFSupplierGenCompanyNameOperator;
         AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = AV28TFSupplierGenCompanyName_Sel;
         AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = AV29TFSupplierGenTypeName;
         AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = AV30TFSupplierGenTypeName_Sel;
         AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = AV31TFSupplierGenContactName;
         AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = AV32TFSupplierGenContactName_Sel;
         AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = AV33TFSupplierGenContactPhone;
         AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = AV34TFSupplierGenContactPhone_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV19OrderedBy, AV20OrderedDsc, AV21FilterFullText, AV26ManageFiltersExecutionStep, AV61ColumnsSelector, AV63Pgmname, A429PreferredGenOrganisationId, AV56OrganisationId, A426PreferredSupplierGenId, AV27TFSupplierGenCompanyName, AV52TFSupplierGenCompanyNameOperator, AV28TFSupplierGenCompanyName_Sel, AV29TFSupplierGenTypeName, AV30TFSupplierGenTypeName_Sel, AV31TFSupplierGenContactName, AV32TFSupplierGenContactName_Sel, AV33TFSupplierGenContactPhone, AV34TFSupplierGenContactPhone_Sel, AV54PreferredSuppliers, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV65Wp_organisationgeneralsuppliersds_1_filterfulltext = AV21FilterFullText;
         AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = AV27TFSupplierGenCompanyName;
         AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator = AV52TFSupplierGenCompanyNameOperator;
         AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = AV28TFSupplierGenCompanyName_Sel;
         AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = AV29TFSupplierGenTypeName;
         AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = AV30TFSupplierGenTypeName_Sel;
         AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = AV31TFSupplierGenContactName;
         AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = AV32TFSupplierGenContactName_Sel;
         AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = AV33TFSupplierGenContactPhone;
         AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = AV34TFSupplierGenContactPhone_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV19OrderedBy, AV20OrderedDsc, AV21FilterFullText, AV26ManageFiltersExecutionStep, AV61ColumnsSelector, AV63Pgmname, A429PreferredGenOrganisationId, AV56OrganisationId, A426PreferredSupplierGenId, AV27TFSupplierGenCompanyName, AV52TFSupplierGenCompanyNameOperator, AV28TFSupplierGenCompanyName_Sel, AV29TFSupplierGenTypeName, AV30TFSupplierGenTypeName_Sel, AV31TFSupplierGenContactName, AV32TFSupplierGenContactName_Sel, AV33TFSupplierGenContactPhone, AV34TFSupplierGenContactPhone_Sel, AV54PreferredSuppliers, AV45IsAuthorized_Display, AV47IsAuthorized_Update, AV49IsAuthorized_Delete, AV50IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV63Pgmname = "WP_OrganisationGeneralSuppliers";
         edtavSuppliergencompanynamewithtags_Enabled = 0;
         edtavSupplieraddress_Enabled = 0;
         edtSupplierGenId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtSupplierGenKvkNumber_Enabled = 0;
         edtSupplierGenCompanyName_Enabled = 0;
         edtSupplierGenTypeId_Enabled = 0;
         edtSupplierGenTypeName_Enabled = 0;
         edtSupplierGenAddressCountry_Enabled = 0;
         edtSupplierGenAddressCity_Enabled = 0;
         edtSupplierGenAddressZipCode_Enabled = 0;
         edtSupplierGenAddressLine1_Enabled = 0;
         edtSupplierGenAddressLine2_Enabled = 0;
         edtSupplierGenContactName_Enabled = 0;
         edtSupplierGenContactPhone_Enabled = 0;
         edtSupplierGenPhoneCode_Enabled = 0;
         edtSupplierGenPhoneNumber_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP760( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18762 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV35DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV61ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV39GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV40GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV41GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Fixedfilters = cgiGet( "DDO_GRID_Fixedfilters");
            Ddo_grid_Selectedfixedfilter = cgiGet( "DDO_GRID_Selectedfixedfilter");
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
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Selectedcolumnfixedfilter = cgiGet( "DDO_GRID_Selectedcolumnfixedfilter");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV21FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV21FilterFullText", AV21FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_39_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            if ( nGXsfl_39_idx > 0 )
            {
               AV51isSelected = StringUtil.StrToBool( cgiGet( chkavIsselected_Internalname));
               AssignAttri("", false, chkavIsselected_Internalname, AV51isSelected);
               A42SupplierGenId = StringUtil.StrToGuid( cgiGet( edtSupplierGenId_Internalname));
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
               n11OrganisationId = false;
               A43SupplierGenKvkNumber = cgiGet( edtSupplierGenKvkNumber_Internalname);
               AV53SupplierGenCompanyNameWithTags = cgiGet( edtavSuppliergencompanynamewithtags_Internalname);
               AssignAttri("", false, edtavSuppliergencompanynamewithtags_Internalname, AV53SupplierGenCompanyNameWithTags);
               A44SupplierGenCompanyName = cgiGet( edtSupplierGenCompanyName_Internalname);
               A282SupplierGenTypeId = StringUtil.StrToGuid( cgiGet( edtSupplierGenTypeId_Internalname));
               A290SupplierGenTypeName = cgiGet( edtSupplierGenTypeName_Internalname);
               A335SupplierGenAddressCountry = cgiGet( edtSupplierGenAddressCountry_Internalname);
               A295SupplierGenAddressCity = cgiGet( edtSupplierGenAddressCity_Internalname);
               A294SupplierGenAddressZipCode = cgiGet( edtSupplierGenAddressZipCode_Internalname);
               A336SupplierGenAddressLine1 = cgiGet( edtSupplierGenAddressLine1_Internalname);
               A337SupplierGenAddressLine2 = cgiGet( edtSupplierGenAddressLine2_Internalname);
               A47SupplierGenContactName = cgiGet( edtSupplierGenContactName_Internalname);
               A48SupplierGenContactPhone = cgiGet( edtSupplierGenContactPhone_Internalname);
               A381SupplierGenPhoneCode = cgiGet( edtSupplierGenPhoneCode_Internalname);
               A382SupplierGenPhoneNumber = cgiGet( edtSupplierGenPhoneNumber_Internalname);
               AV22SupplierAddress = cgiGet( edtavSupplieraddress_Internalname);
               AssignAttri("", false, edtavSupplieraddress_Internalname, AV22SupplierAddress);
               cmbavActiongroup.Name = cmbavActiongroup_Internalname;
               cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
               AV57ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV57ActionGroup), 4, 0));
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV19OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV20OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV21FilterFullText) != 0 )
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
         E18762 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18762( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV14HTTPRequest.Method, "GET") == 0 )
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
         AV36GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV37GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV36GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " General Suppliers", "");
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
         if ( AV19OrderedBy < 1 )
         {
            AV19OrderedBy = 1;
            AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV35DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV35DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         GXt_guid2 = AV56OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid2) ;
         AV56OrganisationId = GXt_guid2;
         AssignAttri("", false, "AV56OrganisationId", AV56OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV56OrganisationId, context));
      }

      protected void E19762( )
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
         if ( AV26ManageFiltersExecutionStep == 1 )
         {
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV26ManageFiltersExecutionStep == 2 )
         {
            AV26ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV23Session.Get("WP_OrganisationGeneralSuppliersColumnsSelector"), "") != 0 )
         {
            AV59ColumnsSelectorXML = AV23Session.Get("WP_OrganisationGeneralSuppliersColumnsSelector");
            AV61ColumnsSelector.FromXml(AV59ColumnsSelectorXML, null, "", "");
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
         chkavIsselected.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV61ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkavIsselected_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsselected.Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavSuppliergencompanynamewithtags_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV61ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSuppliergencompanynamewithtags_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSuppliergencompanynamewithtags_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSupplierGenTypeName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV61ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierGenTypeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenTypeName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSupplierGenContactName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV61ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierGenContactName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSupplierGenContactPhone_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV61ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSupplierGenContactPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierGenContactPhone_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavSupplieraddress_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV61ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSupplieraddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSupplieraddress_Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV39GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV39GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV39GridCurrentPage), 10, 0));
         AV40GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV40GridPageCount", StringUtil.LTrimStr( (decimal)(AV40GridPageCount), 10, 0));
         GXt_char3 = AV41GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV63Pgmname, out  GXt_char3) ;
         AV41GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV41GridAppliedFilters", AV41GridAppliedFilters);
         AV54PreferredSuppliers.Clear();
         /* Using cursor H00764 */
         pr_default.execute(2, new Object[] {AV56OrganisationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A429PreferredGenOrganisationId = H00764_A429PreferredGenOrganisationId[0];
            A426PreferredSupplierGenId = H00764_A426PreferredSupplierGenId[0];
            AV54PreferredSuppliers.Add(A426PreferredSupplierGenId, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV65Wp_organisationgeneralsuppliersds_1_filterfulltext = AV21FilterFullText;
         AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = AV27TFSupplierGenCompanyName;
         AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator = AV52TFSupplierGenCompanyNameOperator;
         AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = AV28TFSupplierGenCompanyName_Sel;
         AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = AV29TFSupplierGenTypeName;
         AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = AV30TFSupplierGenTypeName_Sel;
         AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = AV31TFSupplierGenContactName;
         AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = AV32TFSupplierGenContactName_Sel;
         AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = AV33TFSupplierGenContactPhone;
         AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = AV34TFSupplierGenContactPhone_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ColumnsSelector", AV61ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV54PreferredSuppliers", AV54PreferredSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridState", AV17GridState);
      }

      protected void E12762( )
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
            AV38PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV38PageToGo) ;
         }
      }

      protected void E13762( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15762( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV19OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
            AV20OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV20OrderedDsc", AV20OrderedDsc);
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
               if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "1") == 0 )
               {
                  AV52TFSupplierGenCompanyNameOperator = 1;
                  AssignAttri("", false, "AV52TFSupplierGenCompanyNameOperator", StringUtil.LTrimStr( (decimal)(AV52TFSupplierGenCompanyNameOperator), 4, 0));
                  AV27TFSupplierGenCompanyName = "";
                  AssignAttri("", false, "AV27TFSupplierGenCompanyName", AV27TFSupplierGenCompanyName);
                  AV28TFSupplierGenCompanyName_Sel = "";
                  AssignAttri("", false, "AV28TFSupplierGenCompanyName_Sel", AV28TFSupplierGenCompanyName_Sel);
               }
               else
               {
                  AV52TFSupplierGenCompanyNameOperator = 0;
                  AssignAttri("", false, "AV52TFSupplierGenCompanyNameOperator", StringUtil.LTrimStr( (decimal)(AV52TFSupplierGenCompanyNameOperator), 4, 0));
                  AV27TFSupplierGenCompanyName = Ddo_grid_Filteredtext_get;
                  AssignAttri("", false, "AV27TFSupplierGenCompanyName", AV27TFSupplierGenCompanyName);
                  AV28TFSupplierGenCompanyName_Sel = Ddo_grid_Selectedvalue_get;
                  AssignAttri("", false, "AV28TFSupplierGenCompanyName_Sel", AV28TFSupplierGenCompanyName_Sel);
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierGenTypeName") == 0 )
            {
               AV29TFSupplierGenTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFSupplierGenTypeName", AV29TFSupplierGenTypeName);
               AV30TFSupplierGenTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFSupplierGenTypeName_Sel", AV30TFSupplierGenTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierGenContactName") == 0 )
            {
               AV31TFSupplierGenContactName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFSupplierGenContactName", AV31TFSupplierGenContactName);
               AV32TFSupplierGenContactName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFSupplierGenContactName_Sel", AV32TFSupplierGenContactName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SupplierGenContactPhone") == 0 )
            {
               AV33TFSupplierGenContactPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFSupplierGenContactPhone", AV33TFSupplierGenContactPhone);
               AV34TFSupplierGenContactPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFSupplierGenContactPhone_Sel", AV34TFSupplierGenContactPhone_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E20762( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         GXt_char3 = AV22SupplierAddress;
         new prc_concatenateaddress(context ).execute(  A335SupplierGenAddressCountry,  A295SupplierGenAddressCity,  A294SupplierGenAddressZipCode,  A336SupplierGenAddressLine1,  A337SupplierGenAddressLine2, out  GXt_char3) ;
         AV22SupplierAddress = GXt_char3;
         AssignAttri("", false, edtavSupplieraddress_Internalname, AV22SupplierAddress);
         if ( (AV54PreferredSuppliers.IndexOf(A42SupplierGenId)>0) )
         {
            AV51isSelected = true;
            AssignAttri("", false, chkavIsselected_Internalname, AV51isSelected);
         }
         else
         {
            AV51isSelected = false;
            AssignAttri("", false, chkavIsselected_Internalname, AV51isSelected);
         }
         cmbavActiongroup.removeAllItems();
         cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
         if ( AV45IsAuthorized_Display )
         {
            cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         }
         if ( AV47IsAuthorized_Update )
         {
            cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV49IsAuthorized_Delete )
         {
            cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         if ( cmbavActiongroup.ItemCount == 1 )
         {
            cmbavActiongroup_Class = "Invisible";
         }
         else
         {
            cmbavActiongroup_Class = "ConvertToDDO";
         }
         AV53SupplierGenCompanyNameWithTags = A44SupplierGenCompanyName;
         AssignAttri("", false, edtavSuppliergencompanynamewithtags_Internalname, AV53SupplierGenCompanyNameWithTags);
         if ( AV51isSelected )
         {
            AV53SupplierGenCompanyNameWithTags = StringUtil.Format( "<i class='fa fa-star FontColorIconWarning TagBeforeText BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Preferred", ""), "", "", "", "", "", "", "", "") + AV53SupplierGenCompanyNameWithTags;
            AssignAttri("", false, edtavSuppliergencompanynamewithtags_Internalname, AV53SupplierGenCompanyNameWithTags);
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
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57ActionGroup), 4, 0));
      }

      protected void E16762( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV59ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV61ColumnsSelector.FromJSonString(AV59ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "WP_OrganisationGeneralSuppliersColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV59ColumnsSelectorXML)) ? "" : AV61ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ColumnsSelector", AV61ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV54PreferredSuppliers", AV54PreferredSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridState", AV17GridState);
      }

      protected void E11762( )
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
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WP_OrganisationGeneralSuppliersFilters")) + "," + UrlEncode(StringUtil.RTrim(AV63Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WP_OrganisationGeneralSuppliersFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV25ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WP_OrganisationGeneralSuppliersFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV25ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV63Pgmname+"GridState",  AV25ManageFiltersXml) ;
               AV17GridState.FromXml(AV25ManageFiltersXml, null, "", "");
               AV19OrderedBy = AV17GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
               AV20OrderedDsc = AV17GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV20OrderedDsc", AV20OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridState", AV17GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ColumnsSelector", AV61ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV54PreferredSuppliers", AV54PreferredSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E21762( )
      {
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV57ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV57ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV57ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV57ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ColumnsSelector", AV61ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV54PreferredSuppliers", AV54PreferredSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridState", AV17GridState);
      }

      protected void E17762( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV50IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ColumnsSelector", AV61ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV54PreferredSuppliers", AV54PreferredSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridState", AV17GridState);
      }

      protected void E14762( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0070",(string)"",(string)"Trn_SupplierGen",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0070"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0))+":"+(AV20OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV61ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV61ColumnsSelector,  "&isSelected",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV61ColumnsSelector,  "SupplierGenCompanyName",  "",  "Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV61ColumnsSelector,  "SupplierGenTypeName",  "",  "Category",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV61ColumnsSelector,  "SupplierGenContactName",  "",  "Contact Person",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV61ColumnsSelector,  "SupplierGenContactPhone",  "",  "Phone",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV61ColumnsSelector,  "&SupplierAddress",  "",  "Address",  true,  "") ;
         GXt_char3 = AV60UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "WP_OrganisationGeneralSuppliersColumnsSelector", out  GXt_char3) ;
         AV60UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60UserCustomValue)) ) )
         {
            AV62ColumnsSelectorAux.FromXml(AV60UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV62ColumnsSelectorAux, ref  AV61ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean4 = AV45IsAuthorized_Display;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergen_Execute", out  GXt_boolean4) ;
         AV45IsAuthorized_Display = GXt_boolean4;
         AssignAttri("", false, "AV45IsAuthorized_Display", AV45IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV45IsAuthorized_Display, context));
         GXt_boolean4 = AV47IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergen_Update", out  GXt_boolean4) ;
         AV47IsAuthorized_Update = GXt_boolean4;
         AssignAttri("", false, "AV47IsAuthorized_Update", AV47IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV47IsAuthorized_Update, context));
         GXt_boolean4 = AV49IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergen_Delete", out  GXt_boolean4) ;
         AV49IsAuthorized_Delete = GXt_boolean4;
         AssignAttri("", false, "AV49IsAuthorized_Delete", AV49IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV49IsAuthorized_Delete, context));
         GXt_boolean4 = AV50IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_suppliergen_Insert", out  GXt_boolean4) ;
         AV50IsAuthorized_Insert = GXt_boolean4;
         AssignAttri("", false, "AV50IsAuthorized_Insert", AV50IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV50IsAuthorized_Insert, context));
         if ( ! ( AV50IsAuthorized_Insert ) )
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV24ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WP_OrganisationGeneralSuppliersFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV21FilterFullText = "";
         AssignAttri("", false, "AV21FilterFullText", AV21FilterFullText);
         AV27TFSupplierGenCompanyName = "";
         AssignAttri("", false, "AV27TFSupplierGenCompanyName", AV27TFSupplierGenCompanyName);
         AV28TFSupplierGenCompanyName_Sel = "";
         AssignAttri("", false, "AV28TFSupplierGenCompanyName_Sel", AV28TFSupplierGenCompanyName_Sel);
         AV52TFSupplierGenCompanyNameOperator = 0;
         AssignAttri("", false, "AV52TFSupplierGenCompanyNameOperator", StringUtil.LTrimStr( (decimal)(AV52TFSupplierGenCompanyNameOperator), 4, 0));
         Ddo_grid_Selectedfixedfilter = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
         AV29TFSupplierGenTypeName = "";
         AssignAttri("", false, "AV29TFSupplierGenTypeName", AV29TFSupplierGenTypeName);
         AV30TFSupplierGenTypeName_Sel = "";
         AssignAttri("", false, "AV30TFSupplierGenTypeName_Sel", AV30TFSupplierGenTypeName_Sel);
         AV31TFSupplierGenContactName = "";
         AssignAttri("", false, "AV31TFSupplierGenContactName", AV31TFSupplierGenContactName);
         AV32TFSupplierGenContactName_Sel = "";
         AssignAttri("", false, "AV32TFSupplierGenContactName_Sel", AV32TFSupplierGenContactName_Sel);
         AV33TFSupplierGenContactPhone = "";
         AssignAttri("", false, "AV33TFSupplierGenContactPhone", AV33TFSupplierGenContactPhone);
         AV34TFSupplierGenContactPhone_Sel = "";
         AssignAttri("", false, "AV34TFSupplierGenContactPhone_Sel", AV34TFSupplierGenContactPhone_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S202( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV45IsAuthorized_Display )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(A42SupplierGenId.ToString());
            CallWebObject(formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S212( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV47IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A42SupplierGenId.ToString());
            CallWebObject(formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV49IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_suppliergen.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A42SupplierGenId.ToString());
            CallWebObject(formatLink("trn_suppliergen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get(AV63Pgmname+"GridState"), "") == 0 )
         {
            AV17GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV63Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV17GridState.FromXml(AV23Session.Get(AV63Pgmname+"GridState"), null, "", "");
         }
         AV19OrderedBy = AV17GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
         AV20OrderedDsc = AV17GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV20OrderedDsc", AV20OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV17GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV17GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV17GridState.gxTpr_Currentpage) ;
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV75GXV1 = 1;
         while ( AV75GXV1 <= AV17GridState.gxTpr_Filtervalues.Count )
         {
            AV18GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV17GridState.gxTpr_Filtervalues.Item(AV75GXV1));
            if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV21FilterFullText = AV18GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV21FilterFullText", AV21FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME") == 0 )
            {
               AV52TFSupplierGenCompanyNameOperator = AV18GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV52TFSupplierGenCompanyNameOperator", StringUtil.LTrimStr( (decimal)(AV52TFSupplierGenCompanyNameOperator), 4, 0));
               if ( AV52TFSupplierGenCompanyNameOperator == 0 )
               {
                  AV27TFSupplierGenCompanyName = AV18GridStateFilterValue.gxTpr_Value;
                  AssignAttri("", false, "AV27TFSupplierGenCompanyName", AV27TFSupplierGenCompanyName);
               }
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCOMPANYNAME_SEL") == 0 )
            {
               AV28TFSupplierGenCompanyName_Sel = AV18GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFSupplierGenCompanyName_Sel", AV28TFSupplierGenCompanyName_Sel);
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENTYPENAME") == 0 )
            {
               AV29TFSupplierGenTypeName = AV18GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFSupplierGenTypeName", AV29TFSupplierGenTypeName);
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENTYPENAME_SEL") == 0 )
            {
               AV30TFSupplierGenTypeName_Sel = AV18GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFSupplierGenTypeName_Sel", AV30TFSupplierGenTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTNAME") == 0 )
            {
               AV31TFSupplierGenContactName = AV18GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFSupplierGenContactName", AV31TFSupplierGenContactName);
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTNAME_SEL") == 0 )
            {
               AV32TFSupplierGenContactName_Sel = AV18GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFSupplierGenContactName_Sel", AV32TFSupplierGenContactName_Sel);
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTPHONE") == 0 )
            {
               AV33TFSupplierGenContactPhone = AV18GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFSupplierGenContactPhone", AV33TFSupplierGenContactPhone);
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFSUPPLIERGENCONTACTPHONE_SEL") == 0 )
            {
               AV34TFSupplierGenContactPhone_Sel = AV18GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFSupplierGenContactPhone_Sel", AV34TFSupplierGenContactPhone_Sel);
            }
            AV75GXV1 = (int)(AV75GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSupplierGenCompanyName_Sel)),  AV28TFSupplierGenCompanyName_Sel, out  GXt_char3) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSupplierGenTypeName_Sel)),  AV30TFSupplierGenTypeName_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSupplierGenContactName_Sel)),  AV32TFSupplierGenContactName_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSupplierGenContactPhone_Sel)),  AV34TFSupplierGenContactPhone_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  !(0==AV52TFSupplierGenCompanyNameOperator)||String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSupplierGenCompanyName)),  AV27TFSupplierGenCompanyName, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplierGenTypeName)),  AV29TFSupplierGenTypeName, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSupplierGenContactName)),  AV31TFSupplierGenContactName, out  GXt_char6) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSupplierGenContactPhone)),  AV33TFSupplierGenContactPhone, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char3+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Selectedfixedfilter = ((AV52TFSupplierGenCompanyNameOperator!=1) ? "" : "1")+"||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV17GridState.FromXml(AV23Session.Get(AV63Pgmname+"GridState"), null, "", "");
         AV17GridState.gxTpr_Orderedby = AV19OrderedBy;
         AV17GridState.gxTpr_Ordereddsc = AV20OrderedDsc;
         AV17GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV17GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV21FilterFullText)),  0,  AV21FilterFullText,  AV21FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV17GridState,  "TFSUPPLIERGENCOMPANYNAME",  context.GetMessage( "Name", ""),  !(String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSupplierGenCompanyName))&&(0==AV52TFSupplierGenCompanyNameOperator)),  AV52TFSupplierGenCompanyNameOperator,  AV27TFSupplierGenCompanyName,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV52TFSupplierGenCompanyNameOperator+1), 10, 0)), AV27TFSupplierGenCompanyName, context.GetMessage( "Preferred", ""), "", "", "", "", "", "", ""),  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSupplierGenCompanyName_Sel)),  AV28TFSupplierGenCompanyName_Sel,  AV28TFSupplierGenCompanyName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV17GridState,  "TFSUPPLIERGENTYPENAME",  context.GetMessage( "Category", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSupplierGenTypeName)),  0,  AV29TFSupplierGenTypeName,  AV29TFSupplierGenTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSupplierGenTypeName_Sel)),  AV30TFSupplierGenTypeName_Sel,  AV30TFSupplierGenTypeName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV17GridState,  "TFSUPPLIERGENCONTACTNAME",  context.GetMessage( "Contact Person", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSupplierGenContactName)),  0,  AV31TFSupplierGenContactName,  AV31TFSupplierGenContactName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSupplierGenContactName_Sel)),  AV32TFSupplierGenContactName_Sel,  AV32TFSupplierGenContactName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV17GridState,  "TFSUPPLIERGENCONTACTPHONE",  context.GetMessage( "Phone", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSupplierGenContactPhone)),  0,  AV33TFSupplierGenContactPhone,  AV33TFSupplierGenContactPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSupplierGenContactPhone_Sel)),  AV34TFSupplierGenContactPhone_Sel,  AV34TFSupplierGenContactPhone_Sel) ;
         AV17GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV17GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV63Pgmname+"GridState",  AV17GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV15TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV15TrnContext.gxTpr_Callerobject = AV63Pgmname;
         AV15TrnContext.gxTpr_Callerondelete = true;
         AV15TrnContext.gxTpr_Callerurl = AV14HTTPRequest.ScriptName+"?"+AV14HTTPRequest.QueryString;
         AV15TrnContext.gxTpr_Transactionname = "Trn_SupplierGen";
         AV23Session.Set("TrnContext", AV15TrnContext.ToXml(false, true, "", ""));
      }

      protected void E22762( )
      {
         /* Isselected_Click Routine */
         returnInSub = false;
         if ( AV51isSelected )
         {
            AV55Trn_PreferredGenSupplier.gxTpr_Preferredgensupplierid = Guid.NewGuid( );
            AV55Trn_PreferredGenSupplier.gxTpr_Preferredsuppliergenid = A42SupplierGenId;
            AV55Trn_PreferredGenSupplier.Insert();
         }
         else
         {
            /* Using cursor H00765 */
            pr_default.execute(3, new Object[] {A42SupplierGenId, AV56OrganisationId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A426PreferredSupplierGenId = H00765_A426PreferredSupplierGenId[0];
               A429PreferredGenOrganisationId = H00765_A429PreferredGenOrganisationId[0];
               A427PreferredGenSupplierId = H00765_A427PreferredGenSupplierId[0];
               AV55Trn_PreferredGenSupplier.Load(A427PreferredGenSupplierId);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV55Trn_PreferredGenSupplier.Delete();
         }
         context.CommitDataStores("wp_organisationgeneralsuppliers",pr_default);
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55Trn_PreferredGenSupplier", AV55Trn_PreferredGenSupplier);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ColumnsSelector", AV61ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV54PreferredSuppliers", AV54PreferredSuppliers);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17GridState", AV17GridState);
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
         PA762( ) ;
         WS762( ) ;
         WE762( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241128943504", true, true);
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
         context.AddJavascriptSource("wp_organisationgeneralsuppliers.js", "?20241128943506", false, true);
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
         chkavIsselected_Internalname = "vISSELECTED_"+sGXsfl_39_idx;
         edtSupplierGenId_Internalname = "SUPPLIERGENID_"+sGXsfl_39_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_39_idx;
         edtSupplierGenKvkNumber_Internalname = "SUPPLIERGENKVKNUMBER_"+sGXsfl_39_idx;
         edtavSuppliergencompanynamewithtags_Internalname = "vSUPPLIERGENCOMPANYNAMEWITHTAGS_"+sGXsfl_39_idx;
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME_"+sGXsfl_39_idx;
         edtSupplierGenTypeId_Internalname = "SUPPLIERGENTYPEID_"+sGXsfl_39_idx;
         edtSupplierGenTypeName_Internalname = "SUPPLIERGENTYPENAME_"+sGXsfl_39_idx;
         edtSupplierGenAddressCountry_Internalname = "SUPPLIERGENADDRESSCOUNTRY_"+sGXsfl_39_idx;
         edtSupplierGenAddressCity_Internalname = "SUPPLIERGENADDRESSCITY_"+sGXsfl_39_idx;
         edtSupplierGenAddressZipCode_Internalname = "SUPPLIERGENADDRESSZIPCODE_"+sGXsfl_39_idx;
         edtSupplierGenAddressLine1_Internalname = "SUPPLIERGENADDRESSLINE1_"+sGXsfl_39_idx;
         edtSupplierGenAddressLine2_Internalname = "SUPPLIERGENADDRESSLINE2_"+sGXsfl_39_idx;
         edtSupplierGenContactName_Internalname = "SUPPLIERGENCONTACTNAME_"+sGXsfl_39_idx;
         edtSupplierGenContactPhone_Internalname = "SUPPLIERGENCONTACTPHONE_"+sGXsfl_39_idx;
         edtSupplierGenPhoneCode_Internalname = "SUPPLIERGENPHONECODE_"+sGXsfl_39_idx;
         edtSupplierGenPhoneNumber_Internalname = "SUPPLIERGENPHONENUMBER_"+sGXsfl_39_idx;
         edtavSupplieraddress_Internalname = "vSUPPLIERADDRESS_"+sGXsfl_39_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         chkavIsselected_Internalname = "vISSELECTED_"+sGXsfl_39_fel_idx;
         edtSupplierGenId_Internalname = "SUPPLIERGENID_"+sGXsfl_39_fel_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_39_fel_idx;
         edtSupplierGenKvkNumber_Internalname = "SUPPLIERGENKVKNUMBER_"+sGXsfl_39_fel_idx;
         edtavSuppliergencompanynamewithtags_Internalname = "vSUPPLIERGENCOMPANYNAMEWITHTAGS_"+sGXsfl_39_fel_idx;
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME_"+sGXsfl_39_fel_idx;
         edtSupplierGenTypeId_Internalname = "SUPPLIERGENTYPEID_"+sGXsfl_39_fel_idx;
         edtSupplierGenTypeName_Internalname = "SUPPLIERGENTYPENAME_"+sGXsfl_39_fel_idx;
         edtSupplierGenAddressCountry_Internalname = "SUPPLIERGENADDRESSCOUNTRY_"+sGXsfl_39_fel_idx;
         edtSupplierGenAddressCity_Internalname = "SUPPLIERGENADDRESSCITY_"+sGXsfl_39_fel_idx;
         edtSupplierGenAddressZipCode_Internalname = "SUPPLIERGENADDRESSZIPCODE_"+sGXsfl_39_fel_idx;
         edtSupplierGenAddressLine1_Internalname = "SUPPLIERGENADDRESSLINE1_"+sGXsfl_39_fel_idx;
         edtSupplierGenAddressLine2_Internalname = "SUPPLIERGENADDRESSLINE2_"+sGXsfl_39_fel_idx;
         edtSupplierGenContactName_Internalname = "SUPPLIERGENCONTACTNAME_"+sGXsfl_39_fel_idx;
         edtSupplierGenContactPhone_Internalname = "SUPPLIERGENCONTACTPHONE_"+sGXsfl_39_fel_idx;
         edtSupplierGenPhoneCode_Internalname = "SUPPLIERGENPHONECODE_"+sGXsfl_39_fel_idx;
         edtSupplierGenPhoneNumber_Internalname = "SUPPLIERGENPHONENUMBER_"+sGXsfl_39_fel_idx;
         edtavSupplieraddress_Internalname = "vSUPPLIERADDRESS_"+sGXsfl_39_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WB760( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkavIsselected.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vISSELECTED_" + sGXsfl_39_idx;
            chkavIsselected.Name = GXCCtl;
            chkavIsselected.WebTags = "";
            chkavIsselected.Caption = "";
            AssignProp("", false, chkavIsselected_Internalname, "TitleCaption", chkavIsselected.Caption, !bGXsfl_39_Refreshing);
            chkavIsselected.CheckedValue = "false";
            AV51isSelected = StringUtil.StrToBool( StringUtil.BoolToStr( AV51isSelected));
            AssignAttri("", false, chkavIsselected_Internalname, AV51isSelected);
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIsselected_Internalname,StringUtil.BoolToStr( AV51isSelected),(string)"",(string)"",chkavIsselected.Visible,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn WWIconActionColumn",(string)"",TempTags+" onblur=\""+""+";gx.evt.onblur(this,40);\""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenId_Internalname,A42SupplierGenId.ToString(),A42SupplierGenId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenKvkNumber_Internalname,(string)A43SupplierGenKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSuppliergencompanynamewithtags_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSuppliergencompanynamewithtags_Internalname,(string)AV53SupplierGenCompanyNameWithTags,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSuppliergencompanynamewithtags_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSuppliergencompanynamewithtags_Visible,(int)edtavSuppliergencompanynamewithtags_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)1,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenCompanyName_Internalname,(string)A44SupplierGenCompanyName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenCompanyName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenTypeId_Internalname,A282SupplierGenTypeId.ToString(),A282SupplierGenTypeId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierGenTypeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenTypeName_Internalname,(string)A290SupplierGenTypeName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierGenTypeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenAddressCountry_Internalname,(string)A335SupplierGenAddressCountry,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenAddressCountry_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenAddressCity_Internalname,(string)A295SupplierGenAddressCity,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenAddressCity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenAddressZipCode_Internalname,(string)A294SupplierGenAddressZipCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenAddressZipCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenAddressLine1_Internalname,(string)A336SupplierGenAddressLine1,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenAddressLine1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenAddressLine2_Internalname,(string)A337SupplierGenAddressLine2,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenAddressLine2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierGenContactName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenContactName_Internalname,(string)A47SupplierGenContactName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenContactName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierGenContactName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSupplierGenContactPhone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A48SupplierGenContactPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenContactPhone_Internalname,StringUtil.RTrim( A48SupplierGenContactPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtSupplierGenContactPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSupplierGenContactPhone_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenPhoneCode_Internalname,(string)A381SupplierGenPhoneCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenPhoneCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierGenPhoneNumber_Internalname,(string)A382SupplierGenPhoneNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierGenPhoneNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSupplieraddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSupplieraddress_Internalname,(string)AV22SupplierAddress,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( AV22SupplierAddress),(string)"_blank",(string)"",(string)"",(string)edtavSupplieraddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSupplieraddress_Visible,(int)edtavSupplieraddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_39_idx + "',39)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_39_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  AV57ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV57ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV57ActionGroup), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV57ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_39_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            send_integrity_lvl_hashes762( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vISSELECTED_" + sGXsfl_39_idx;
         chkavIsselected.Name = GXCCtl;
         chkavIsselected.WebTags = "";
         chkavIsselected.Caption = "";
         AssignProp("", false, chkavIsselected_Internalname, "TitleCaption", chkavIsselected.Caption, !bGXsfl_39_Refreshing);
         chkavIsselected.CheckedValue = "false";
         AV51isSelected = StringUtil.StrToBool( StringUtil.BoolToStr( AV51isSelected));
         AssignAttri("", false, chkavIsselected_Internalname, AV51isSelected);
         GXCCtl = "vACTIONGROUP_" + sGXsfl_39_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            AV57ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV57ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV57ActionGroup), 4, 0));
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+((chkavIsselected.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "&nbsp;", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSuppliergencompanynamewithtags_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplierGenTypeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Category", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplierGenContactName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Contact Person", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSupplierGenContactPhone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSupplieraddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Address", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV51isSelected)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavIsselected.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A42SupplierGenId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A43SupplierGenKvkNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV53SupplierGenCompanyNameWithTags));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSuppliergencompanynamewithtags_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSuppliergencompanynamewithtags_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A44SupplierGenCompanyName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A282SupplierGenTypeId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A290SupplierGenTypeName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierGenTypeName_Visible), 5, 0, ".", "")));
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
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierGenContactName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A48SupplierGenContactPhone)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierGenContactPhone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A381SupplierGenPhoneCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A382SupplierGenPhoneNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV22SupplierAddress));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSupplieraddress_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSupplieraddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57ActionGroup), 4, 0, ".", ""))));
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
         chkavIsselected_Internalname = "vISSELECTED";
         edtSupplierGenId_Internalname = "SUPPLIERGENID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtSupplierGenKvkNumber_Internalname = "SUPPLIERGENKVKNUMBER";
         edtavSuppliergencompanynamewithtags_Internalname = "vSUPPLIERGENCOMPANYNAMEWITHTAGS";
         edtSupplierGenCompanyName_Internalname = "SUPPLIERGENCOMPANYNAME";
         edtSupplierGenTypeId_Internalname = "SUPPLIERGENTYPEID";
         edtSupplierGenTypeName_Internalname = "SUPPLIERGENTYPENAME";
         edtSupplierGenAddressCountry_Internalname = "SUPPLIERGENADDRESSCOUNTRY";
         edtSupplierGenAddressCity_Internalname = "SUPPLIERGENADDRESSCITY";
         edtSupplierGenAddressZipCode_Internalname = "SUPPLIERGENADDRESSZIPCODE";
         edtSupplierGenAddressLine1_Internalname = "SUPPLIERGENADDRESSLINE1";
         edtSupplierGenAddressLine2_Internalname = "SUPPLIERGENADDRESSLINE2";
         edtSupplierGenContactName_Internalname = "SUPPLIERGENCONTACTNAME";
         edtSupplierGenContactPhone_Internalname = "SUPPLIERGENCONTACTPHONE";
         edtSupplierGenPhoneCode_Internalname = "SUPPLIERGENPHONECODE";
         edtSupplierGenPhoneNumber_Internalname = "SUPPLIERGENPHONENUMBER";
         edtavSupplieraddress_Internalname = "vSUPPLIERADDRESS";
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
         edtavSupplieraddress_Jsonclick = "";
         edtavSupplieraddress_Enabled = 1;
         edtSupplierGenPhoneNumber_Jsonclick = "";
         edtSupplierGenPhoneCode_Jsonclick = "";
         edtSupplierGenContactPhone_Jsonclick = "";
         edtSupplierGenContactName_Jsonclick = "";
         edtSupplierGenAddressLine2_Jsonclick = "";
         edtSupplierGenAddressLine1_Jsonclick = "";
         edtSupplierGenAddressZipCode_Jsonclick = "";
         edtSupplierGenAddressCity_Jsonclick = "";
         edtSupplierGenAddressCountry_Jsonclick = "";
         edtSupplierGenTypeName_Jsonclick = "";
         edtSupplierGenTypeId_Jsonclick = "";
         edtSupplierGenCompanyName_Jsonclick = "";
         edtavSuppliergencompanynamewithtags_Jsonclick = "";
         edtavSuppliergencompanynamewithtags_Enabled = 1;
         edtSupplierGenKvkNumber_Jsonclick = "";
         edtOrganisationId_Jsonclick = "";
         edtSupplierGenId_Jsonclick = "";
         chkavIsselected.Caption = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSupplieraddress_Visible = -1;
         edtSupplierGenContactPhone_Visible = -1;
         edtSupplierGenContactName_Visible = -1;
         edtSupplierGenTypeName_Visible = -1;
         edtavSuppliergencompanynamewithtags_Visible = -1;
         chkavIsselected.Visible = -1;
         edtSupplierGenPhoneNumber_Enabled = 0;
         edtSupplierGenPhoneCode_Enabled = 0;
         edtSupplierGenContactPhone_Enabled = 0;
         edtSupplierGenContactName_Enabled = 0;
         edtSupplierGenAddressLine2_Enabled = 0;
         edtSupplierGenAddressLine1_Enabled = 0;
         edtSupplierGenAddressZipCode_Enabled = 0;
         edtSupplierGenAddressCity_Enabled = 0;
         edtSupplierGenAddressCountry_Enabled = 0;
         edtSupplierGenTypeName_Enabled = 0;
         edtSupplierGenTypeId_Enabled = 0;
         edtSupplierGenCompanyName_Enabled = 0;
         edtSupplierGenKvkNumber_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtSupplierGenId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Fixedfilters = "1:Preferred:fa fa-star FontColorIconWarning ConditionalFormattingFilterIcon||||";
         Ddo_grid_Datalistproc = "WP_OrganisationGeneralSuppliersGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|";
         Ddo_grid_Includedatalist = "T|T|T|T|";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|T|";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|";
         Ddo_grid_Columnssortvalues = "1|2|3|4|";
         Ddo_grid_Columnids = "4:SupplierGenCompanyName|7:SupplierGenTypeName|13:SupplierGenContactName|14:SupplierGenContactPhone|17:SupplierAddress";
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
         Form.Caption = context.GetMessage( " General Suppliers", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV20OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV21FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A429PreferredGenOrganisationId","fld":"PREFERREDGENORGANISATIONID"},{"av":"AV56OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A426PreferredSupplierGenId","fld":"PREFERREDSUPPLIERGENID"},{"av":"AV27TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV52TFSupplierGenCompanyNameOperator","fld":"vTFSUPPLIERGENCOMPANYNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV28TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV29TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV30TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV31TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV32TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV33TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV34TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"chkavIsselected.Visible","ctrl":"vISSELECTED","prop":"Visible"},{"av":"edtavSuppliergencompanynamewithtags_Visible","ctrl":"vSUPPLIERGENCOMPANYNAMEWITHTAGS","prop":"Visible"},{"av":"edtSupplierGenTypeName_Visible","ctrl":"SUPPLIERGENTYPENAME","prop":"Visible"},{"av":"edtSupplierGenContactName_Visible","ctrl":"SUPPLIERGENCONTACTNAME","prop":"Visible"},{"av":"edtSupplierGenContactPhone_Visible","ctrl":"SUPPLIERGENCONTACTPHONE","prop":"Visible"},{"av":"edtavSupplieraddress_Visible","ctrl":"vSUPPLIERADDRESS","prop":"Visible"},{"av":"AV39GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV40GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV41GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV17GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12762","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV20OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV21FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A429PreferredGenOrganisationId","fld":"PREFERREDGENORGANISATIONID"},{"av":"AV56OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A426PreferredSupplierGenId","fld":"PREFERREDSUPPLIERGENID"},{"av":"AV27TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV52TFSupplierGenCompanyNameOperator","fld":"vTFSUPPLIERGENCOMPANYNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV28TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV29TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV30TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV31TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV32TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV33TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV34TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13762","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV20OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV21FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A429PreferredGenOrganisationId","fld":"PREFERREDGENORGANISATIONID"},{"av":"AV56OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A426PreferredSupplierGenId","fld":"PREFERREDSUPPLIERGENID"},{"av":"AV27TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV52TFSupplierGenCompanyNameOperator","fld":"vTFSUPPLIERGENCOMPANYNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV28TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV29TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV30TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV31TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV32TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV33TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV34TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E15762","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV20OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV21FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A429PreferredGenOrganisationId","fld":"PREFERREDGENORGANISATIONID"},{"av":"AV56OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A426PreferredSupplierGenId","fld":"PREFERREDSUPPLIERGENID"},{"av":"AV27TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV52TFSupplierGenCompanyNameOperator","fld":"vTFSUPPLIERGENCOMPANYNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV28TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV29TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV30TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV31TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV32TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV33TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV34TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Selectedcolumnfixedfilter","ctrl":"DDO_GRID","prop":"SelectedColumnFixedFilter"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV19OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV20OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV52TFSupplierGenCompanyNameOperator","fld":"vTFSUPPLIERGENCOMPANYNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV27TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV28TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV29TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV30TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV31TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV32TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV33TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV34TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E20762","iparms":[{"av":"A335SupplierGenAddressCountry","fld":"SUPPLIERGENADDRESSCOUNTRY"},{"av":"A295SupplierGenAddressCity","fld":"SUPPLIERGENADDRESSCITY"},{"av":"A294SupplierGenAddressZipCode","fld":"SUPPLIERGENADDRESSZIPCODE"},{"av":"A336SupplierGenAddressLine1","fld":"SUPPLIERGENADDRESSLINE1"},{"av":"A337SupplierGenAddressLine2","fld":"SUPPLIERGENADDRESSLINE2"},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID","hsh":true},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"A44SupplierGenCompanyName","fld":"SUPPLIERGENCOMPANYNAME"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV22SupplierAddress","fld":"vSUPPLIERADDRESS"},{"av":"AV51isSelected","fld":"vISSELECTED"},{"av":"cmbavActiongroup"},{"av":"AV57ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV53SupplierGenCompanyNameWithTags","fld":"vSUPPLIERGENCOMPANYNAMEWITHTAGS"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E16762","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV20OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV21FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A429PreferredGenOrganisationId","fld":"PREFERREDGENORGANISATIONID"},{"av":"AV56OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A426PreferredSupplierGenId","fld":"PREFERREDSUPPLIERGENID"},{"av":"AV27TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV52TFSupplierGenCompanyNameOperator","fld":"vTFSUPPLIERGENCOMPANYNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV28TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV29TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV30TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV31TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV32TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV33TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV34TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"chkavIsselected.Visible","ctrl":"vISSELECTED","prop":"Visible"},{"av":"edtavSuppliergencompanynamewithtags_Visible","ctrl":"vSUPPLIERGENCOMPANYNAMEWITHTAGS","prop":"Visible"},{"av":"edtSupplierGenTypeName_Visible","ctrl":"SUPPLIERGENTYPENAME","prop":"Visible"},{"av":"edtSupplierGenContactName_Visible","ctrl":"SUPPLIERGENCONTACTNAME","prop":"Visible"},{"av":"edtSupplierGenContactPhone_Visible","ctrl":"SUPPLIERGENCONTACTPHONE","prop":"Visible"},{"av":"edtavSupplieraddress_Visible","ctrl":"vSUPPLIERADDRESS","prop":"Visible"},{"av":"AV39GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV40GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV41GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV17GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11762","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV20OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV21FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A429PreferredGenOrganisationId","fld":"PREFERREDGENORGANISATIONID"},{"av":"AV56OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A426PreferredSupplierGenId","fld":"PREFERREDSUPPLIERGENID"},{"av":"AV27TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV52TFSupplierGenCompanyNameOperator","fld":"vTFSUPPLIERGENCOMPANYNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV28TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV29TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV30TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV31TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV32TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV33TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV34TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV17GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV17GridState","fld":"vGRIDSTATE"},{"av":"AV19OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV20OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV21FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV27TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV28TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV52TFSupplierGenCompanyNameOperator","fld":"vTFSUPPLIERGENCOMPANYNAMEOPERATOR","pic":"ZZZ9"},{"av":"Ddo_grid_Selectedfixedfilter","ctrl":"DDO_GRID","prop":"SelectedFixedFilter"},{"av":"AV29TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV30TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV31TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV32TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV33TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV34TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"chkavIsselected.Visible","ctrl":"vISSELECTED","prop":"Visible"},{"av":"edtavSuppliergencompanynamewithtags_Visible","ctrl":"vSUPPLIERGENCOMPANYNAMEWITHTAGS","prop":"Visible"},{"av":"edtSupplierGenTypeName_Visible","ctrl":"SUPPLIERGENTYPENAME","prop":"Visible"},{"av":"edtSupplierGenContactName_Visible","ctrl":"SUPPLIERGENCONTACTNAME","prop":"Visible"},{"av":"edtSupplierGenContactPhone_Visible","ctrl":"SUPPLIERGENCONTACTPHONE","prop":"Visible"},{"av":"edtavSupplieraddress_Visible","ctrl":"vSUPPLIERADDRESS","prop":"Visible"},{"av":"AV39GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV40GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV41GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E21762","iparms":[{"av":"cmbavActiongroup"},{"av":"AV57ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV20OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV21FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A429PreferredGenOrganisationId","fld":"PREFERREDGENORGANISATIONID"},{"av":"AV56OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A426PreferredSupplierGenId","fld":"PREFERREDSUPPLIERGENID"},{"av":"AV27TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV52TFSupplierGenCompanyNameOperator","fld":"vTFSUPPLIERGENCOMPANYNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV28TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV29TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV30TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV31TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV32TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV33TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV34TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID","hsh":true}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV57ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"chkavIsselected.Visible","ctrl":"vISSELECTED","prop":"Visible"},{"av":"edtavSuppliergencompanynamewithtags_Visible","ctrl":"vSUPPLIERGENCOMPANYNAMEWITHTAGS","prop":"Visible"},{"av":"edtSupplierGenTypeName_Visible","ctrl":"SUPPLIERGENTYPENAME","prop":"Visible"},{"av":"edtSupplierGenContactName_Visible","ctrl":"SUPPLIERGENCONTACTNAME","prop":"Visible"},{"av":"edtSupplierGenContactPhone_Visible","ctrl":"SUPPLIERGENCONTACTPHONE","prop":"Visible"},{"av":"edtavSupplieraddress_Visible","ctrl":"vSUPPLIERADDRESS","prop":"Visible"},{"av":"AV39GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV40GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV41GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV17GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E17762","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV20OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV21FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A429PreferredGenOrganisationId","fld":"PREFERREDGENORGANISATIONID"},{"av":"AV56OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A426PreferredSupplierGenId","fld":"PREFERREDSUPPLIERGENID"},{"av":"AV27TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV52TFSupplierGenCompanyNameOperator","fld":"vTFSUPPLIERGENCOMPANYNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV28TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV29TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV30TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV31TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV32TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV33TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV34TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"chkavIsselected.Visible","ctrl":"vISSELECTED","prop":"Visible"},{"av":"edtavSuppliergencompanynamewithtags_Visible","ctrl":"vSUPPLIERGENCOMPANYNAMEWITHTAGS","prop":"Visible"},{"av":"edtSupplierGenTypeName_Visible","ctrl":"SUPPLIERGENTYPENAME","prop":"Visible"},{"av":"edtSupplierGenContactName_Visible","ctrl":"SUPPLIERGENCONTACTNAME","prop":"Visible"},{"av":"edtSupplierGenContactPhone_Visible","ctrl":"SUPPLIERGENCONTACTPHONE","prop":"Visible"},{"av":"edtavSupplieraddress_Visible","ctrl":"vSUPPLIERADDRESS","prop":"Visible"},{"av":"AV39GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV40GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV41GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV17GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E14762","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VISSELECTED.CLICK","""{"handler":"E22762","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV19OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV20OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV21FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"A429PreferredGenOrganisationId","fld":"PREFERREDGENORGANISATIONID"},{"av":"AV56OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"A426PreferredSupplierGenId","fld":"PREFERREDSUPPLIERGENID"},{"av":"AV27TFSupplierGenCompanyName","fld":"vTFSUPPLIERGENCOMPANYNAME"},{"av":"AV52TFSupplierGenCompanyNameOperator","fld":"vTFSUPPLIERGENCOMPANYNAMEOPERATOR","pic":"ZZZ9"},{"av":"AV28TFSupplierGenCompanyName_Sel","fld":"vTFSUPPLIERGENCOMPANYNAME_SEL"},{"av":"AV29TFSupplierGenTypeName","fld":"vTFSUPPLIERGENTYPENAME"},{"av":"AV30TFSupplierGenTypeName_Sel","fld":"vTFSUPPLIERGENTYPENAME_SEL"},{"av":"AV31TFSupplierGenContactName","fld":"vTFSUPPLIERGENCONTACTNAME"},{"av":"AV32TFSupplierGenContactName_Sel","fld":"vTFSUPPLIERGENCONTACTNAME_SEL"},{"av":"AV33TFSupplierGenContactPhone","fld":"vTFSUPPLIERGENCONTACTPHONE"},{"av":"AV34TFSupplierGenContactPhone_Sel","fld":"vTFSUPPLIERGENCONTACTPHONE_SEL"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV51isSelected","fld":"vISSELECTED"},{"av":"AV55Trn_PreferredGenSupplier","fld":"vTRN_PREFERREDGENSUPPLIER"},{"av":"A42SupplierGenId","fld":"SUPPLIERGENID","hsh":true},{"av":"A427PreferredGenSupplierId","fld":"PREFERREDGENSUPPLIERID"}]""");
         setEventMetadata("VISSELECTED.CLICK",""","oparms":[{"av":"AV55Trn_PreferredGenSupplier","fld":"vTRN_PREFERREDGENSUPPLIER"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV61ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"chkavIsselected.Visible","ctrl":"vISSELECTED","prop":"Visible"},{"av":"edtavSuppliergencompanynamewithtags_Visible","ctrl":"vSUPPLIERGENCOMPANYNAMEWITHTAGS","prop":"Visible"},{"av":"edtSupplierGenTypeName_Visible","ctrl":"SUPPLIERGENTYPENAME","prop":"Visible"},{"av":"edtSupplierGenContactName_Visible","ctrl":"SUPPLIERGENCONTACTNAME","prop":"Visible"},{"av":"edtSupplierGenContactPhone_Visible","ctrl":"SUPPLIERGENCONTACTPHONE","prop":"Visible"},{"av":"edtavSupplieraddress_Visible","ctrl":"vSUPPLIERADDRESS","prop":"Visible"},{"av":"AV39GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV40GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV41GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54PreferredSuppliers","fld":"vPREFERREDSUPPLIERS","hsh":true},{"av":"AV45IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV47IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV49IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV50IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV17GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VALID_SUPPLIERGENTYPEID","""{"handler":"Valid_Suppliergentypeid","iparms":[]}""");
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
         Ddo_grid_Selectedcolumnfixedfilter = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV21FilterFullText = "";
         AV61ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV63Pgmname = "";
         A429PreferredGenOrganisationId = Guid.Empty;
         AV56OrganisationId = Guid.Empty;
         A426PreferredSupplierGenId = Guid.Empty;
         AV27TFSupplierGenCompanyName = "";
         AV28TFSupplierGenCompanyName_Sel = "";
         AV29TFSupplierGenTypeName = "";
         AV30TFSupplierGenTypeName_Sel = "";
         AV31TFSupplierGenContactName = "";
         AV32TFSupplierGenContactName_Sel = "";
         AV33TFSupplierGenContactPhone = "";
         AV34TFSupplierGenContactPhone_Sel = "";
         AV54PreferredSuppliers = new GxSimpleCollection<Guid>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV41GridAppliedFilters = "";
         AV35DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV17GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV55Trn_PreferredGenSupplier = new SdtTrn_PreferredGenSupplier(context);
         A427PreferredGenSupplierId = Guid.Empty;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_grid_Selectedfixedfilter = "";
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
         A42SupplierGenId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A43SupplierGenKvkNumber = "";
         AV53SupplierGenCompanyNameWithTags = "";
         A44SupplierGenCompanyName = "";
         A282SupplierGenTypeId = Guid.Empty;
         A290SupplierGenTypeName = "";
         A335SupplierGenAddressCountry = "";
         A295SupplierGenAddressCity = "";
         A294SupplierGenAddressZipCode = "";
         A336SupplierGenAddressLine1 = "";
         A337SupplierGenAddressLine2 = "";
         A47SupplierGenContactName = "";
         A48SupplierGenContactPhone = "";
         A381SupplierGenPhoneCode = "";
         A382SupplierGenPhoneNumber = "";
         AV22SupplierAddress = "";
         lV65Wp_organisationgeneralsuppliersds_1_filterfulltext = "";
         lV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = "";
         lV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = "";
         lV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = "";
         lV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = "";
         AV65Wp_organisationgeneralsuppliersds_1_filterfulltext = "";
         AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel = "";
         AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname = "";
         AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel = "";
         AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename = "";
         AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel = "";
         AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname = "";
         AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel = "";
         AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone = "";
         H00762_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         H00762_A382SupplierGenPhoneNumber = new string[] {""} ;
         H00762_A381SupplierGenPhoneCode = new string[] {""} ;
         H00762_A48SupplierGenContactPhone = new string[] {""} ;
         H00762_A47SupplierGenContactName = new string[] {""} ;
         H00762_A337SupplierGenAddressLine2 = new string[] {""} ;
         H00762_A336SupplierGenAddressLine1 = new string[] {""} ;
         H00762_A294SupplierGenAddressZipCode = new string[] {""} ;
         H00762_A295SupplierGenAddressCity = new string[] {""} ;
         H00762_A335SupplierGenAddressCountry = new string[] {""} ;
         H00762_A290SupplierGenTypeName = new string[] {""} ;
         H00762_A282SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         H00762_A44SupplierGenCompanyName = new string[] {""} ;
         H00762_A43SupplierGenKvkNumber = new string[] {""} ;
         H00762_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00762_n11OrganisationId = new bool[] {false} ;
         H00763_AGRID_nRecordCount = new long[1] ;
         AV14HTTPRequest = new GxHttpRequest( context);
         AV36GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV37GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_guid2 = Guid.Empty;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23Session = context.GetSession();
         AV59ColumnsSelectorXML = "";
         H00764_A427PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         H00764_A429PreferredGenOrganisationId = new Guid[] {Guid.Empty} ;
         H00764_A426PreferredSupplierGenId = new Guid[] {Guid.Empty} ;
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV25ManageFiltersXml = "";
         AV60UserCustomValue = "";
         AV62ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV18GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char3 = "";
         AV15TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         H00765_A426PreferredSupplierGenId = new Guid[] {Guid.Empty} ;
         H00765_A429PreferredGenOrganisationId = new Guid[] {Guid.Empty} ;
         H00765_A427PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationgeneralsuppliers__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationgeneralsuppliers__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationgeneralsuppliers__default(),
            new Object[][] {
                new Object[] {
               H00762_A42SupplierGenId, H00762_A382SupplierGenPhoneNumber, H00762_A381SupplierGenPhoneCode, H00762_A48SupplierGenContactPhone, H00762_A47SupplierGenContactName, H00762_A337SupplierGenAddressLine2, H00762_A336SupplierGenAddressLine1, H00762_A294SupplierGenAddressZipCode, H00762_A295SupplierGenAddressCity, H00762_A335SupplierGenAddressCountry,
               H00762_A290SupplierGenTypeName, H00762_A282SupplierGenTypeId, H00762_A44SupplierGenCompanyName, H00762_A43SupplierGenKvkNumber, H00762_A11OrganisationId, H00762_n11OrganisationId
               }
               , new Object[] {
               H00763_AGRID_nRecordCount
               }
               , new Object[] {
               H00764_A427PreferredGenSupplierId, H00764_A429PreferredGenOrganisationId, H00764_A426PreferredSupplierGenId
               }
               , new Object[] {
               H00765_A426PreferredSupplierGenId, H00765_A429PreferredGenOrganisationId, H00765_A427PreferredGenSupplierId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV63Pgmname = "WP_OrganisationGeneralSuppliers";
         /* GeneXus formulas. */
         AV63Pgmname = "WP_OrganisationGeneralSuppliers";
         edtavSuppliergencompanynamewithtags_Enabled = 0;
         edtavSupplieraddress_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV19OrderedBy ;
      private short AV26ManageFiltersExecutionStep ;
      private short AV52TFSupplierGenCompanyNameOperator ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV57ActionGroup ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ;
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
      private int edtavSuppliergencompanynamewithtags_Enabled ;
      private int edtavSupplieraddress_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSupplierGenId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtSupplierGenKvkNumber_Enabled ;
      private int edtSupplierGenCompanyName_Enabled ;
      private int edtSupplierGenTypeId_Enabled ;
      private int edtSupplierGenTypeName_Enabled ;
      private int edtSupplierGenAddressCountry_Enabled ;
      private int edtSupplierGenAddressCity_Enabled ;
      private int edtSupplierGenAddressZipCode_Enabled ;
      private int edtSupplierGenAddressLine1_Enabled ;
      private int edtSupplierGenAddressLine2_Enabled ;
      private int edtSupplierGenContactName_Enabled ;
      private int edtSupplierGenContactPhone_Enabled ;
      private int edtSupplierGenPhoneCode_Enabled ;
      private int edtSupplierGenPhoneNumber_Enabled ;
      private int edtavSuppliergencompanynamewithtags_Visible ;
      private int edtSupplierGenTypeName_Visible ;
      private int edtSupplierGenContactName_Visible ;
      private int edtSupplierGenContactPhone_Visible ;
      private int edtavSupplieraddress_Visible ;
      private int AV38PageToGo ;
      private int AV75GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV39GridCurrentPage ;
      private long AV40GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Selectedcolumnfixedfilter ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV63Pgmname ;
      private string AV33TFSupplierGenContactPhone ;
      private string AV34TFSupplierGenContactPhone_Sel ;
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
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Fixedfilters ;
      private string Ddo_grid_Selectedfixedfilter ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
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
      private string chkavIsselected_Internalname ;
      private string edtSupplierGenId_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string edtSupplierGenKvkNumber_Internalname ;
      private string edtavSuppliergencompanynamewithtags_Internalname ;
      private string edtSupplierGenCompanyName_Internalname ;
      private string edtSupplierGenTypeId_Internalname ;
      private string edtSupplierGenTypeName_Internalname ;
      private string edtSupplierGenAddressCountry_Internalname ;
      private string edtSupplierGenAddressCity_Internalname ;
      private string edtSupplierGenAddressZipCode_Internalname ;
      private string edtSupplierGenAddressLine1_Internalname ;
      private string edtSupplierGenAddressLine2_Internalname ;
      private string edtSupplierGenContactName_Internalname ;
      private string A48SupplierGenContactPhone ;
      private string edtSupplierGenContactPhone_Internalname ;
      private string edtSupplierGenPhoneCode_Internalname ;
      private string edtSupplierGenPhoneNumber_Internalname ;
      private string edtavSupplieraddress_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string lV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ;
      private string AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ;
      private string AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ;
      private string cmbavActiongroup_Class ;
      private string GXEncryptionTmp ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char3 ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtSupplierGenId_Jsonclick ;
      private string edtOrganisationId_Jsonclick ;
      private string edtSupplierGenKvkNumber_Jsonclick ;
      private string edtavSuppliergencompanynamewithtags_Jsonclick ;
      private string edtSupplierGenCompanyName_Jsonclick ;
      private string edtSupplierGenTypeId_Jsonclick ;
      private string edtSupplierGenTypeName_Jsonclick ;
      private string edtSupplierGenAddressCountry_Jsonclick ;
      private string edtSupplierGenAddressCity_Jsonclick ;
      private string edtSupplierGenAddressZipCode_Jsonclick ;
      private string edtSupplierGenAddressLine1_Jsonclick ;
      private string edtSupplierGenAddressLine2_Jsonclick ;
      private string edtSupplierGenContactName_Jsonclick ;
      private string gxphoneLink ;
      private string edtSupplierGenContactPhone_Jsonclick ;
      private string edtSupplierGenPhoneCode_Jsonclick ;
      private string edtSupplierGenPhoneNumber_Jsonclick ;
      private string edtavSupplieraddress_Jsonclick ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV20OrderedDsc ;
      private bool AV45IsAuthorized_Display ;
      private bool AV47IsAuthorized_Update ;
      private bool AV49IsAuthorized_Delete ;
      private bool AV50IsAuthorized_Insert ;
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
      private bool AV51isSelected ;
      private bool n11OrganisationId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean4 ;
      private string AV59ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV60UserCustomValue ;
      private string AV21FilterFullText ;
      private string AV27TFSupplierGenCompanyName ;
      private string AV28TFSupplierGenCompanyName_Sel ;
      private string AV29TFSupplierGenTypeName ;
      private string AV30TFSupplierGenTypeName_Sel ;
      private string AV31TFSupplierGenContactName ;
      private string AV32TFSupplierGenContactName_Sel ;
      private string AV41GridAppliedFilters ;
      private string A43SupplierGenKvkNumber ;
      private string AV53SupplierGenCompanyNameWithTags ;
      private string A44SupplierGenCompanyName ;
      private string A290SupplierGenTypeName ;
      private string A335SupplierGenAddressCountry ;
      private string A295SupplierGenAddressCity ;
      private string A294SupplierGenAddressZipCode ;
      private string A336SupplierGenAddressLine1 ;
      private string A337SupplierGenAddressLine2 ;
      private string A47SupplierGenContactName ;
      private string A381SupplierGenPhoneCode ;
      private string A382SupplierGenPhoneNumber ;
      private string AV22SupplierAddress ;
      private string lV65Wp_organisationgeneralsuppliersds_1_filterfulltext ;
      private string lV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ;
      private string lV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ;
      private string lV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ;
      private string AV65Wp_organisationgeneralsuppliersds_1_filterfulltext ;
      private string AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ;
      private string AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ;
      private string AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ;
      private string AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ;
      private string AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ;
      private string AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ;
      private Guid A429PreferredGenOrganisationId ;
      private Guid AV56OrganisationId ;
      private Guid A426PreferredSupplierGenId ;
      private Guid A427PreferredGenSupplierId ;
      private Guid A42SupplierGenId ;
      private Guid A11OrganisationId ;
      private Guid A282SupplierGenTypeId ;
      private Guid GXt_guid2 ;
      private IGxSession AV23Session ;
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
      private GxHttpRequest AV14HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIsselected ;
      private GXCombobox cmbavActiongroup ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV61ColumnsSelector ;
      private GxSimpleCollection<Guid> AV54PreferredSuppliers ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV35DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV17GridState ;
      private SdtTrn_PreferredGenSupplier AV55Trn_PreferredGenSupplier ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00762_A42SupplierGenId ;
      private string[] H00762_A382SupplierGenPhoneNumber ;
      private string[] H00762_A381SupplierGenPhoneCode ;
      private string[] H00762_A48SupplierGenContactPhone ;
      private string[] H00762_A47SupplierGenContactName ;
      private string[] H00762_A337SupplierGenAddressLine2 ;
      private string[] H00762_A336SupplierGenAddressLine1 ;
      private string[] H00762_A294SupplierGenAddressZipCode ;
      private string[] H00762_A295SupplierGenAddressCity ;
      private string[] H00762_A335SupplierGenAddressCountry ;
      private string[] H00762_A290SupplierGenTypeName ;
      private Guid[] H00762_A282SupplierGenTypeId ;
      private string[] H00762_A44SupplierGenCompanyName ;
      private string[] H00762_A43SupplierGenKvkNumber ;
      private Guid[] H00762_A11OrganisationId ;
      private bool[] H00762_n11OrganisationId ;
      private long[] H00763_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV36GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV37GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private Guid[] H00764_A427PreferredGenSupplierId ;
      private Guid[] H00764_A429PreferredGenOrganisationId ;
      private Guid[] H00764_A426PreferredSupplierGenId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV62ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV18GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV15TrnContext ;
      private Guid[] H00765_A426PreferredSupplierGenId ;
      private Guid[] H00765_A429PreferredGenOrganisationId ;
      private Guid[] H00765_A427PreferredGenSupplierId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_organisationgeneralsuppliers__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
       return "DATASTORE1";
    }

 }

 public class wp_organisationgeneralsuppliers__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_organisationgeneralsuppliers__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_H00762( IGxContext context ,
                                          string AV65Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                          string AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                          string AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                          short AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                          string AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                          string AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                          string AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                          string AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                          string AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                          string AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                          string A44SupplierGenCompanyName ,
                                          string A290SupplierGenTypeName ,
                                          string A47SupplierGenContactName ,
                                          string A48SupplierGenContactPhone ,
                                          bool AV51isSelected ,
                                          short AV19OrderedBy ,
                                          bool AV20OrderedDsc )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int9 = new short[16];
      Object[] GXv_Object10 = new Object[2];
      string sSelectString;
      string sFromString;
      string sOrderString;
      sSelectString = " T1.SupplierGenId, T1.SupplierGenPhoneNumber, T1.SupplierGenPhoneCode, T1.SupplierGenContactPhone, T1.SupplierGenContactName, T1.SupplierGenAddressLine2, T1.SupplierGenAddressLine1, T1.SupplierGenAddressZipCode, T1.SupplierGenAddressCity, T1.SupplierGenAddressCountry, T2.SupplierGenTypeName, T1.SupplierGenTypeId, T1.SupplierGenCompanyName, T1.SupplierGenKvkNumber, T1.OrganisationId";
      sFromString = " FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
      sOrderString = "";
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wp_organisationgeneralsuppliersds_1_filterfulltext)) )
      {
         AddWhere(sWhereString, "(( LOWER(T1.SupplierGenCompanyName) like '%' || LOWER(:lV65Wp_organisationgeneralsuppliersds_1_filterfulltext)) or ( LOWER(T2.SupplierGenTypeName) like '%' || LOWER(:lV65Wp_organisationgeneralsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierGenContactName) like '%' || LOWER(:lV65Wp_organisationgeneralsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierGenContactPhone) like '%' || LOWER(:lV65Wp_organisationgeneralsuppliersds_1_filterfulltext)))");
      }
      else
      {
         GXv_int9[0] = 1;
         GXv_int9[1] = 1;
         GXv_int9[2] = 1;
         GXv_int9[3] = 1;
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname)) ) )
      {
         AddWhere(sWhereString, "(LOWER(T1.SupplierGenCompanyName) like LOWER(:lV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam))");
      }
      else
      {
         GXv_int9[4] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam))");
      }
      else
      {
         GXv_int9[5] = 1;
      }
      if ( StringUtil.StrCmp(AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
      }
      if ( AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator == 1 )
      {
         AddWhere(sWhereString, "(:AV51isSelected = TRUE)");
      }
      else
      {
         GXv_int9[6] = 1;
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename)) ) )
      {
         AddWhere(sWhereString, "(LOWER(T2.SupplierGenTypeName) like LOWER(:lV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename))");
      }
      else
      {
         GXv_int9[7] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s))");
      }
      else
      {
         GXv_int9[8] = 1;
      }
      if ( StringUtil.StrCmp(AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname)) ) )
      {
         AddWhere(sWhereString, "(LOWER(T1.SupplierGenContactName) like LOWER(:lV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam))");
      }
      else
      {
         GXv_int9[9] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam))");
      }
      else
      {
         GXv_int9[10] = 1;
      }
      if ( StringUtil.StrCmp(AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone)) ) )
      {
         AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho)");
      }
      else
      {
         GXv_int9[11] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph))");
      }
      else
      {
         GXv_int9[12] = 1;
      }
      if ( StringUtil.StrCmp(AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
      }
      if ( ( AV19OrderedBy == 1 ) && ! AV20OrderedDsc )
      {
         sOrderString += " ORDER BY T1.SupplierGenCompanyName, T1.SupplierGenId";
      }
      else if ( ( AV19OrderedBy == 1 ) && ( AV20OrderedDsc ) )
      {
         sOrderString += " ORDER BY T1.SupplierGenCompanyName DESC, T1.SupplierGenId";
      }
      else if ( ( AV19OrderedBy == 2 ) && ! AV20OrderedDsc )
      {
         sOrderString += " ORDER BY T2.SupplierGenTypeName, T1.SupplierGenId";
      }
      else if ( ( AV19OrderedBy == 2 ) && ( AV20OrderedDsc ) )
      {
         sOrderString += " ORDER BY T2.SupplierGenTypeName DESC, T1.SupplierGenId";
      }
      else if ( ( AV19OrderedBy == 3 ) && ! AV20OrderedDsc )
      {
         sOrderString += " ORDER BY T1.SupplierGenContactName, T1.SupplierGenId";
      }
      else if ( ( AV19OrderedBy == 3 ) && ( AV20OrderedDsc ) )
      {
         sOrderString += " ORDER BY T1.SupplierGenContactName DESC, T1.SupplierGenId";
      }
      else if ( ( AV19OrderedBy == 4 ) && ! AV20OrderedDsc )
      {
         sOrderString += " ORDER BY T1.SupplierGenContactPhone, T1.SupplierGenId";
      }
      else if ( ( AV19OrderedBy == 4 ) && ( AV20OrderedDsc ) )
      {
         sOrderString += " ORDER BY T1.SupplierGenContactPhone DESC, T1.SupplierGenId";
      }
      else if ( true )
      {
         sOrderString += " ORDER BY T1.SupplierGenId";
      }
      scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
      GXv_Object10[0] = scmdbuf;
      GXv_Object10[1] = GXv_int9;
      return GXv_Object10 ;
   }

   protected Object[] conditional_H00763( IGxContext context ,
                                          string AV65Wp_organisationgeneralsuppliersds_1_filterfulltext ,
                                          string AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel ,
                                          string AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname ,
                                          short AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator ,
                                          string AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel ,
                                          string AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename ,
                                          string AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel ,
                                          string AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname ,
                                          string AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel ,
                                          string AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone ,
                                          string A44SupplierGenCompanyName ,
                                          string A290SupplierGenTypeName ,
                                          string A47SupplierGenContactName ,
                                          string A48SupplierGenContactPhone ,
                                          bool AV51isSelected ,
                                          short AV19OrderedBy ,
                                          bool AV20OrderedDsc )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int11 = new short[13];
      Object[] GXv_Object12 = new Object[2];
      scmdbuf = "SELECT COUNT(*) FROM (Trn_SupplierGen T1 INNER JOIN Trn_SupplierGenType T2 ON T2.SupplierGenTypeId = T1.SupplierGenTypeId)";
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wp_organisationgeneralsuppliersds_1_filterfulltext)) )
      {
         AddWhere(sWhereString, "(( LOWER(T1.SupplierGenCompanyName) like '%' || LOWER(:lV65Wp_organisationgeneralsuppliersds_1_filterfulltext)) or ( LOWER(T2.SupplierGenTypeName) like '%' || LOWER(:lV65Wp_organisationgeneralsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierGenContactName) like '%' || LOWER(:lV65Wp_organisationgeneralsuppliersds_1_filterfulltext)) or ( LOWER(T1.SupplierGenContactPhone) like '%' || LOWER(:lV65Wp_organisationgeneralsuppliersds_1_filterfulltext)))");
      }
      else
      {
         GXv_int11[0] = 1;
         GXv_int11[1] = 1;
         GXv_int11[2] = 1;
         GXv_int11[3] = 1;
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanyname)) ) )
      {
         AddWhere(sWhereString, "(LOWER(T1.SupplierGenCompanyName) like LOWER(:lV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam))");
      }
      else
      {
         GXv_int11[4] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel)) && ! ( StringUtil.StrCmp(AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierGenCompanyName = ( :AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam))");
      }
      else
      {
         GXv_int11[5] = 1;
      }
      if ( StringUtil.StrCmp(AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanyname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenCompanyName))=0))");
      }
      if ( AV67Wp_organisationgeneralsuppliersds_3_tfsuppliergencompanynameoperator == 1 )
      {
         AddWhere(sWhereString, "(:AV51isSelected = TRUE)");
      }
      else
      {
         GXv_int11[6] = 1;
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename)) ) )
      {
         AddWhere(sWhereString, "(LOWER(T2.SupplierGenTypeName) like LOWER(:lV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename))");
      }
      else
      {
         GXv_int11[7] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel)) && ! ( StringUtil.StrCmp(AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T2.SupplierGenTypeName = ( :AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s))");
      }
      else
      {
         GXv_int11[8] = 1;
      }
      if ( StringUtil.StrCmp(AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SupplierGenTypeName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactname)) ) )
      {
         AddWhere(sWhereString, "(LOWER(T1.SupplierGenContactName) like LOWER(:lV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam))");
      }
      else
      {
         GXv_int11[9] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel)) && ! ( StringUtil.StrCmp(AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierGenContactName = ( :AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam))");
      }
      else
      {
         GXv_int11[10] = 1;
      }
      if ( StringUtil.StrCmp(AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactphone)) ) )
      {
         AddWhere(sWhereString, "(T1.SupplierGenContactPhone like :lV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho)");
      }
      else
      {
         GXv_int11[11] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel)) && ! ( StringUtil.StrCmp(AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.SupplierGenContactPhone = ( :AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph))");
      }
      else
      {
         GXv_int11[12] = 1;
      }
      if ( StringUtil.StrCmp(AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactphone_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.SupplierGenContactPhone))=0))");
      }
      scmdbuf += sWhereString;
      if ( ( AV19OrderedBy == 1 ) && ! AV20OrderedDsc )
      {
         scmdbuf += "";
      }
      else if ( ( AV19OrderedBy == 1 ) && ( AV20OrderedDsc ) )
      {
         scmdbuf += "";
      }
      else if ( ( AV19OrderedBy == 2 ) && ! AV20OrderedDsc )
      {
         scmdbuf += "";
      }
      else if ( ( AV19OrderedBy == 2 ) && ( AV20OrderedDsc ) )
      {
         scmdbuf += "";
      }
      else if ( ( AV19OrderedBy == 3 ) && ! AV20OrderedDsc )
      {
         scmdbuf += "";
      }
      else if ( ( AV19OrderedBy == 3 ) && ( AV20OrderedDsc ) )
      {
         scmdbuf += "";
      }
      else if ( ( AV19OrderedBy == 4 ) && ! AV20OrderedDsc )
      {
         scmdbuf += "";
      }
      else if ( ( AV19OrderedBy == 4 ) && ( AV20OrderedDsc ) )
      {
         scmdbuf += "";
      }
      else if ( true )
      {
         scmdbuf += "";
      }
      GXv_Object12[0] = scmdbuf;
      GXv_Object12[1] = GXv_int11;
      return GXv_Object12 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 0 :
                  return conditional_H00762(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] );
            case 1 :
                  return conditional_H00763(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH00764;
       prmH00764 = new Object[] {
       new ParDef("AV56OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00765;
       prmH00765 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV56OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00762;
       prmH00762 = new Object[] {
       new ParDef("lV65Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV65Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV65Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV65Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
       new ParDef("AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
       new ParDef("AV51isSelected",GXType.Boolean,4,0) ,
       new ParDef("lV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename",GXType.VarChar,100,0) ,
       new ParDef("AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s",GXType.VarChar,100,0) ,
       new ParDef("lV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
       new ParDef("AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
       new ParDef("lV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho",GXType.Char,20,0) ,
       new ParDef("AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph",GXType.Char,20,0) ,
       new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
       new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
       new ParDef("GXPagingTo2",GXType.Int32,9,0)
       };
       Object[] prmH00763;
       prmH00763 = new Object[] {
       new ParDef("lV65Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV65Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV65Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV65Wp_organisationgeneralsuppliersds_1_filterfulltext",GXType.VarChar,100,0) ,
       new ParDef("lV66Wp_organisationgeneralsuppliersds_2_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
       new ParDef("AV68Wp_organisationgeneralsuppliersds_4_tfsuppliergencompanynam",GXType.VarChar,100,0) ,
       new ParDef("AV51isSelected",GXType.Boolean,4,0) ,
       new ParDef("lV69Wp_organisationgeneralsuppliersds_5_tfsuppliergentypename",GXType.VarChar,100,0) ,
       new ParDef("AV70Wp_organisationgeneralsuppliersds_6_tfsuppliergentypename_s",GXType.VarChar,100,0) ,
       new ParDef("lV71Wp_organisationgeneralsuppliersds_7_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
       new ParDef("AV72Wp_organisationgeneralsuppliersds_8_tfsuppliergencontactnam",GXType.VarChar,100,0) ,
       new ParDef("lV73Wp_organisationgeneralsuppliersds_9_tfsuppliergencontactpho",GXType.Char,20,0) ,
       new ParDef("AV74Wp_organisationgeneralsuppliersds_10_tfsuppliergencontactph",GXType.Char,20,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00762", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00762,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00763", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00763,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00764", "SELECT PreferredGenSupplierId, PreferredGenOrganisationId, PreferredSupplierGenId FROM Trn_PreferredGenSupplier WHERE PreferredGenOrganisationId = :AV56OrganisationId ORDER BY PreferredGenSupplierId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00764,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00765", "SELECT PreferredSupplierGenId, PreferredGenOrganisationId, PreferredGenSupplierId FROM Trn_PreferredGenSupplier WHERE (PreferredSupplierGenId = :SupplierGenId) AND (PreferredGenOrganisationId = :AV56OrganisationId) ORDER BY PreferredGenSupplierId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00765,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 20);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((string[]) buf[12])[0] = rslt.getVarchar(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             ((bool[]) buf[15])[0] = rslt.wasNull(15);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
