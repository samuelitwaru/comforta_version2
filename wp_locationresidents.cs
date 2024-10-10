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
   public class wp_locationresidents : GXDataArea
   {
      public wp_locationresidents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_locationresidents( IGxContext context )
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
         dynavLocationoption = new GXCombobox();
         dynavSdt_residents__organisationid = new GXCombobox();
         cmbavSdt_residents__residentsalutation = new GXCombobox();
         cmbavSdt_residents__residentgender = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLOCATIONOPTION") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvLOCATIONOPTION6N2( ) ;
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
         nRC_GXsfl_43 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
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
         AV18ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV54Pgmname = GetPar( "Pgmname");
         AV7FilterFullText = GetPar( "FilterFullText");
         A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         AV56Udparg1 = StringUtil.StrToGuid( GetPar( "Udparg1"));
         A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         dynavLocationoption.FromJSonString( GetNextPar( ));
         AV16LocationOption = StringUtil.StrToGuid( GetPar( "LocationOption"));
         A62ResidentId = StringUtil.StrToGuid( GetPar( "ResidentId"));
         A72ResidentSalutation = GetPar( "ResidentSalutation");
         A63ResidentBsnNumber = GetPar( "ResidentBsnNumber");
         A64ResidentGivenName = GetPar( "ResidentGivenName");
         A65ResidentLastName = GetPar( "ResidentLastName");
         A66ResidentInitials = GetPar( "ResidentInitials");
         A67ResidentEmail = GetPar( "ResidentEmail");
         A68ResidentGender = GetPar( "ResidentGender");
         A354ResidentCountry = GetPar( "ResidentCountry");
         A355ResidentCity = GetPar( "ResidentCity");
         A356ResidentZipCode = GetPar( "ResidentZipCode");
         A357ResidentAddressLine1 = GetPar( "ResidentAddressLine1");
         A358ResidentAddressLine2 = GetPar( "ResidentAddressLine2");
         A70ResidentPhone = GetPar( "ResidentPhone");
         A97ResidentTypeName = GetPar( "ResidentTypeName");
         A98MedicalIndicationId = StringUtil.StrToGuid( GetPar( "MedicalIndicationId"));
         A99MedicalIndicationName = GetPar( "MedicalIndicationName");
         A73ResidentBirthDate = context.localUtil.ParseDateParm( GetPar( "ResidentBirthDate"));
         A96ResidentTypeId = StringUtil.StrToGuid( GetPar( "ResidentTypeId"));
         A71ResidentGUID = GetPar( "ResidentGUID");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV54Pgmname, AV7FilterFullText, A11OrganisationId, AV56Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A354ResidentCountry, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID) ;
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
            return "wp_locationresidents_Execute" ;
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
         PA6N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6N2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_locationresidents.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV56Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV56Udparg1, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdt_residents", AV22SDT_Residents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdt_residents", AV22SDT_Residents);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV9GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV56Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV56Udparg1, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "RESIDENTID", A62ResidentId.ToString());
         GxWebStd.gx_hidden_field( context, "RESIDENTSALUTATION", StringUtil.RTrim( A72ResidentSalutation));
         GxWebStd.gx_hidden_field( context, "RESIDENTBSNNUMBER", A63ResidentBsnNumber);
         GxWebStd.gx_hidden_field( context, "RESIDENTGIVENNAME", A64ResidentGivenName);
         GxWebStd.gx_hidden_field( context, "RESIDENTLASTNAME", A65ResidentLastName);
         GxWebStd.gx_hidden_field( context, "RESIDENTINITIALS", StringUtil.RTrim( A66ResidentInitials));
         GxWebStd.gx_hidden_field( context, "RESIDENTEMAIL", A67ResidentEmail);
         GxWebStd.gx_hidden_field( context, "RESIDENTGENDER", A68ResidentGender);
         GxWebStd.gx_hidden_field( context, "RESIDENTCOUNTRY", A354ResidentCountry);
         GxWebStd.gx_hidden_field( context, "RESIDENTCITY", A355ResidentCity);
         GxWebStd.gx_hidden_field( context, "RESIDENTZIPCODE", A356ResidentZipCode);
         GxWebStd.gx_hidden_field( context, "RESIDENTADDRESSLINE1", A357ResidentAddressLine1);
         GxWebStd.gx_hidden_field( context, "RESIDENTADDRESSLINE2", A358ResidentAddressLine2);
         GxWebStd.gx_hidden_field( context, "RESIDENTPHONE", StringUtil.RTrim( A70ResidentPhone));
         GxWebStd.gx_hidden_field( context, "RESIDENTTYPENAME", A97ResidentTypeName);
         GxWebStd.gx_hidden_field( context, "MEDICALINDICATIONID", A98MedicalIndicationId.ToString());
         GxWebStd.gx_hidden_field( context, "MEDICALINDICATIONNAME", A99MedicalIndicationName);
         GxWebStd.gx_hidden_field( context, "RESIDENTBIRTHDATE", context.localUtil.DToC( A73ResidentBirthDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "RESIDENTTYPEID", A96ResidentTypeId.ToString());
         GxWebStd.gx_hidden_field( context, "RESIDENTGUID", A71ResidentGUID);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV12GridState);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_RESIDENTS", AV22SDT_Residents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_RESIDENTS", AV22SDT_Residents);
         }
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
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
            WE6N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6N2( ) ;
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
         return formatLink("wp_locationresidents.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_LocationResidents" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Location Residents", "") ;
      }

      protected void WB6N0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_LocationResidents.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV7FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV7FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WP_LocationResidents.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablelocationoption_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_6_25", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocklocationoption_Internalname, "", "", "", lblTextblocklocationoption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_LocationResidents.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_93_75", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLocationoption_Internalname, context.GetMessage( "Location Option", ""), "col-sm-3 AddressAttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_43_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationoption, dynavLocationoption_Internalname, AV16LocationOption.ToString(), 1, dynavLocationoption_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "guid", "", dynavLocationoption.Visible, dynavLocationoption.Enabled, 0, 0, 20, "em", 0, "", "", "AddressAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_WP_LocationResidents.htm");
            dynavLocationoption.CurrentValue = AV16LocationOption.ToString();
            AssignProp("", false, dynavLocationoption_Internalname, "Values", (string)(dynavLocationoption.ToJavascriptSource()), true);
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
            StartGridControl43( ) ;
         }
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            nRC_GXsfl_43 = (int)(nGXsfl_43_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV35GXV1 = nGXsfl_43_idx;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV10GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV11GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV9GridAppliedFilters);
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
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 43 )
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
                  AV35GXV1 = nGXsfl_43_idx;
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

      protected void START6N2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Location Residents", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6N0( ) ;
      }

      protected void WS6N2( )
      {
         START6N2( ) ;
         EVT6N2( ) ;
      }

      protected void EVT6N2( )
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
                              E116N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E126N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E136N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E146N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VLOCATIONOPTION.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E156N2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VDISPLAY.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVIEWQRCODE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VVIEWQRCODE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VDISPLAY.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) )
                           {
                              nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
                              SubsflControlProps_432( ) ;
                              AV35GXV1 = (int)(nGXsfl_43_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV22SDT_Residents.Count >= AV35GXV1 ) && ( AV35GXV1 > 0 ) )
                              {
                                 AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1));
                                 AV28viewQrCode = cgiGet( edtavViewqrcode_Internalname);
                                 AssignAttri("", false, edtavViewqrcode_Internalname, AV28viewQrCode);
                                 AV6Display = cgiGet( edtavDisplay_Internalname);
                                 AssignAttri("", false, edtavDisplay_Internalname, AV6Display);
                                 AV27Update = cgiGet( edtavUpdate_Internalname);
                                 AssignAttri("", false, edtavUpdate_Internalname, AV27Update);
                                 AV5Delete = cgiGet( edtavDelete_Internalname);
                                 AssignAttri("", false, edtavDelete_Internalname, AV5Delete);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E166N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E176N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E186N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDISPLAY.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E196N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUPDATE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E206N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E216N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VVIEWQRCODE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E226N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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

      protected void WE6N2( )
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

      protected void PA6N2( )
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

      protected void GXDLVvLOCATIONOPTION6N2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONOPTION_data6N2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvLOCATIONOPTION_html6N2( )
      {
         Guid gxdynajaxvalue;
         GXDLVvLOCATIONOPTION_data6N2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLocationoption.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavLocationoption.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvLOCATIONOPTION_data6N2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(Guid.Empty.ToString());
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Location", ""));
         /* Using cursor H006N2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( H006N2_A11OrganisationId[0] == new prc_getuserorganisationid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(H006N2_A29LocationId[0].ToString());
               gxdynajaxctrldescr.Add(H006N2_A31LocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_432( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            sendrow_432( ) ;
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV18ManageFiltersExecutionStep ,
                                       string AV54Pgmname ,
                                       string AV7FilterFullText ,
                                       Guid A11OrganisationId ,
                                       Guid AV56Udparg1 ,
                                       Guid A29LocationId ,
                                       Guid AV16LocationOption ,
                                       Guid A62ResidentId ,
                                       string A72ResidentSalutation ,
                                       string A63ResidentBsnNumber ,
                                       string A64ResidentGivenName ,
                                       string A65ResidentLastName ,
                                       string A66ResidentInitials ,
                                       string A67ResidentEmail ,
                                       string A68ResidentGender ,
                                       string A354ResidentCountry ,
                                       string A355ResidentCity ,
                                       string A356ResidentZipCode ,
                                       string A357ResidentAddressLine1 ,
                                       string A358ResidentAddressLine2 ,
                                       string A70ResidentPhone ,
                                       string A97ResidentTypeName ,
                                       Guid A98MedicalIndicationId ,
                                       string A99MedicalIndicationName ,
                                       DateTime A73ResidentBirthDate ,
                                       Guid A96ResidentTypeId ,
                                       string A71ResidentGUID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF6N2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvLOCATIONOPTION_html6N2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLocationoption.ItemCount > 0 )
         {
            AV16LocationOption = StringUtil.StrToGuid( dynavLocationoption.getValidValue(AV16LocationOption.ToString()));
            AssignAttri("", false, "AV16LocationOption", AV16LocationOption.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationoption.CurrentValue = AV16LocationOption.ToString();
            AssignProp("", false, dynavLocationoption_Internalname, "Values", dynavLocationoption.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV54Pgmname = "WP_LocationResidents";
         edtavViewqrcode_Enabled = 0;
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         dynavSdt_residents__organisationid.Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF6N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E176N2 ();
         nGXsfl_43_idx = 1;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         bGXsfl_43_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_432( ) ;
            /* Execute user event: Grid.Load */
            E186N2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_43_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E186N2 ();
            }
            wbEnd = 43;
            WB6N0( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6N2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUDPARG1", AV56Udparg1.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG1", GetSecureSignedToken( "", AV56Udparg1, context));
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
         return AV22SDT_Residents.Count ;
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV54Pgmname, AV7FilterFullText, A11OrganisationId, AV56Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A354ResidentCountry, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV54Pgmname, AV7FilterFullText, A11OrganisationId, AV56Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A354ResidentCountry, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV54Pgmname, AV7FilterFullText, A11OrganisationId, AV56Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A354ResidentCountry, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV54Pgmname, AV7FilterFullText, A11OrganisationId, AV56Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A354ResidentCountry, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV54Pgmname, AV7FilterFullText, A11OrganisationId, AV56Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A354ResidentCountry, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV54Pgmname = "WP_LocationResidents";
         edtavViewqrcode_Enabled = 0;
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         dynavSdt_residents__organisationid.Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         GXVvLOCATIONOPTION_html6N2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E166N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdt_residents"), AV22SDT_Residents);
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_RESIDENTS"), AV22SDT_Residents);
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV10GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV11GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV9GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_43_fel_idx = 0;
            while ( nGXsfl_43_fel_idx < nRC_GXsfl_43 )
            {
               nGXsfl_43_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_fel_idx+1);
               sGXsfl_43_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_432( ) ;
               AV35GXV1 = (int)(nGXsfl_43_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV22SDT_Residents.Count >= AV35GXV1 ) && ( AV35GXV1 > 0 ) )
               {
                  AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1));
                  AV28viewQrCode = cgiGet( edtavViewqrcode_Internalname);
                  AV6Display = cgiGet( edtavDisplay_Internalname);
                  AV27Update = cgiGet( edtavUpdate_Internalname);
                  AV5Delete = cgiGet( edtavDelete_Internalname);
               }
            }
            if ( nGXsfl_43_fel_idx == 0 )
            {
               nGXsfl_43_idx = 1;
               sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
               SubsflControlProps_432( ) ;
            }
            nGXsfl_43_fel_idx = 1;
            /* Read variables values. */
            AV7FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV7FilterFullText", AV7FilterFullText);
            dynavLocationoption.Name = dynavLocationoption_Internalname;
            dynavLocationoption.CurrentValue = cgiGet( dynavLocationoption_Internalname);
            AV16LocationOption = StringUtil.StrToGuid( cgiGet( dynavLocationoption_Internalname));
            AssignAttri("", false, "AV16LocationOption", AV16LocationOption.ToString());
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E166N2 ();
         if (returnInSub) return;
      }

      protected void E166N2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV14HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         Form.Caption = context.GetMessage( "Location Residents", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         GXt_SdtGAMUser1 = AV8GAMUser;
         new prc_getloggedinuser(context ).execute( out  GXt_SdtGAMUser1) ;
         AV8GAMUser = GXt_SdtGAMUser1;
         if ( AV8GAMUser.checkrole("Organisation Manager") )
         {
            dynavLocationoption.Visible = 1;
            AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
         }
         else
         {
            if ( AV8GAMUser.checkrole("Receptionist") )
            {
               GXt_guid2 = AV16LocationOption;
               new prc_getuserlocationid(context ).execute( out  GXt_guid2) ;
               AV16LocationOption = GXt_guid2;
               AssignAttri("", false, "AV16LocationOption", AV16LocationOption.ToString());
               dynavLocationoption.Visible = 0;
               AssignProp("", false, dynavLocationoption_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationoption.Visible), 5, 0), true);
            }
         }
      }

      protected void E176N2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV29WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         if ( AV18ManageFiltersExecutionStep == 1 )
         {
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV18ManageFiltersExecutionStep == 2 )
         {
            AV18ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S152 ();
         if (returnInSub) return;
         AV10GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV10GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV10GridCurrentPage), 10, 0));
         AV11GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV11GridPageCount", StringUtil.LTrimStr( (decimal)(AV11GridPageCount), 10, 0));
         GXt_char3 = AV9GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV54Pgmname, out  GXt_char3) ;
         AV9GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV9GridAppliedFilters", AV9GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
      }

      protected void E126N2( )
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
            AV20PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV20PageToGo) ;
         }
      }

      protected void E136N2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E186N2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV35GXV1 = 1;
         while ( AV35GXV1 <= AV22SDT_Residents.Count )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1));
            AV28viewQrCode = "<i class=\"fas fa-qrcode\"></i>";
            AssignAttri("", false, edtavViewqrcode_Internalname, AV28viewQrCode);
            AV6Display = "<i class=\"fa fa-search\"></i>";
            AssignAttri("", false, edtavDisplay_Internalname, AV6Display);
            AV27Update = "<i class=\"fa fa-pen\"></i>";
            AssignAttri("", false, edtavUpdate_Internalname, AV27Update);
            AV5Delete = "<i class=\"fa fa-times\"></i>";
            AssignAttri("", false, edtavDelete_Internalname, AV5Delete);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 43;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_432( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_43_Refreshing )
            {
               DoAjaxLoad(43, GridRow);
            }
            AV35GXV1 = (int)(AV35GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E116N2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S142 ();
            if (returnInSub) return;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WP_LocationResidentsFilters")) + "," + UrlEncode(StringUtil.RTrim(AV54Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WP_LocationResidentsFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV19ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WP_LocationResidentsFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV19ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if (returnInSub) return;
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV54Pgmname+"GridState",  AV19ManageFiltersXml) ;
               AV12GridState.FromXml(AV19ManageFiltersXml, null, "", "");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         if ( gx_BV43 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
            nGXsfl_43_bak_idx = nGXsfl_43_idx;
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV54Pgmname, AV7FilterFullText, A11OrganisationId, AV56Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A354ResidentCountry, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID) ;
            nGXsfl_43_idx = nGXsfl_43_bak_idx;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
      }

      protected void E146N2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wp_createresidentandnetwork.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
         AV22SDT_Residents.Clear();
         gx_BV43 = true;
         AV56Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV16LocationOption ,
                                              A29LocationId ,
                                              A11OrganisationId ,
                                              AV56Udparg1 } ,
                                              new int[]{
                                              }
         });
         /* Using cursor H006N3 */
         pr_default.execute(1, new Object[] {AV56Udparg1, AV16LocationOption});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = H006N3_A29LocationId[0];
            A11OrganisationId = H006N3_A11OrganisationId[0];
            A62ResidentId = H006N3_A62ResidentId[0];
            A72ResidentSalutation = H006N3_A72ResidentSalutation[0];
            A63ResidentBsnNumber = H006N3_A63ResidentBsnNumber[0];
            A64ResidentGivenName = H006N3_A64ResidentGivenName[0];
            A65ResidentLastName = H006N3_A65ResidentLastName[0];
            A66ResidentInitials = H006N3_A66ResidentInitials[0];
            A67ResidentEmail = H006N3_A67ResidentEmail[0];
            A68ResidentGender = H006N3_A68ResidentGender[0];
            A354ResidentCountry = H006N3_A354ResidentCountry[0];
            A355ResidentCity = H006N3_A355ResidentCity[0];
            A356ResidentZipCode = H006N3_A356ResidentZipCode[0];
            A357ResidentAddressLine1 = H006N3_A357ResidentAddressLine1[0];
            A358ResidentAddressLine2 = H006N3_A358ResidentAddressLine2[0];
            A70ResidentPhone = H006N3_A70ResidentPhone[0];
            A97ResidentTypeName = H006N3_A97ResidentTypeName[0];
            A98MedicalIndicationId = H006N3_A98MedicalIndicationId[0];
            A99MedicalIndicationName = H006N3_A99MedicalIndicationName[0];
            A73ResidentBirthDate = H006N3_A73ResidentBirthDate[0];
            A96ResidentTypeId = H006N3_A96ResidentTypeId[0];
            A71ResidentGUID = H006N3_A71ResidentGUID[0];
            A99MedicalIndicationName = H006N3_A99MedicalIndicationName[0];
            A97ResidentTypeName = H006N3_A97ResidentTypeName[0];
            AV21SDT_Resident = new SdtSDT_Resident(context);
            AV21SDT_Resident.gxTpr_Residentid = A62ResidentId;
            AV21SDT_Resident.gxTpr_Locationid = A29LocationId;
            AV21SDT_Resident.gxTpr_Organisationid = A11OrganisationId;
            AV21SDT_Resident.gxTpr_Residentsalutation = A72ResidentSalutation;
            AV21SDT_Resident.gxTpr_Residentbsnnumber = A63ResidentBsnNumber;
            AV21SDT_Resident.gxTpr_Residentgivenname = A64ResidentGivenName;
            AV21SDT_Resident.gxTpr_Residentlastname = A65ResidentLastName;
            AV21SDT_Resident.gxTpr_Residentinitials = A66ResidentInitials;
            AV21SDT_Resident.gxTpr_Residentemail = A67ResidentEmail;
            AV21SDT_Resident.gxTpr_Residentgender = A68ResidentGender;
            GXt_char3 = "";
            new prc_concatenateaddress(context ).execute(  A354ResidentCountry,  A355ResidentCity,  A356ResidentZipCode,  A357ResidentAddressLine1,  A358ResidentAddressLine2, out  GXt_char3) ;
            AV21SDT_Resident.gxTpr_Residentaddress = GXt_char3;
            AV21SDT_Resident.gxTpr_Residentphone = A70ResidentPhone;
            AV21SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
            AV21SDT_Resident.gxTpr_Medicalindicationid = A98MedicalIndicationId;
            AV21SDT_Resident.gxTpr_Medicalindicationname = A99MedicalIndicationName;
            AV21SDT_Resident.gxTpr_Residentbirthdate = A73ResidentBirthDate;
            AV21SDT_Resident.gxTpr_Residenttypeid = A96ResidentTypeId;
            AV21SDT_Resident.gxTpr_Residenttypename = A97ResidentTypeName;
            AV21SDT_Resident.gxTpr_Residentguid = A71ResidentGUID;
            AV22SDT_Residents.Add(AV21SDT_Resident, 0);
            gx_BV43 = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean4 = AV32IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_resident_Update", out  GXt_boolean4) ;
         AV32IsAuthorized_Update = GXt_boolean4;
         if ( ! ( AV32IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_43_Refreshing);
         }
         GXt_boolean4 = AV33IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_resident_Delete", out  GXt_boolean4) ;
         AV33IsAuthorized_Delete = GXt_boolean4;
         if ( ! ( AV33IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_43_Refreshing);
         }
         GXt_boolean4 = AV31IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_resident_Insert", out  GXt_boolean4) ;
         AV31IsAuthorized_Insert = GXt_boolean4;
         if ( ! ( AV31IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV17ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WP_LocationResidentsFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV7FilterFullText = "";
         AssignAttri("", false, "AV7FilterFullText", AV7FilterFullText);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV24Session.Get(AV54Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV54Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV24Session.Get(AV54Pgmname+"GridState"), null, "", "");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV12GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV57GXV20 = 1;
         while ( AV57GXV20 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV57GXV20));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV7FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV7FilterFullText", AV7FilterFullText);
            }
            AV57GXV20 = (int)(AV57GXV20+1);
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV24Session.Get(AV54Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV7FilterFullText)),  0,  AV7FilterFullText,  AV7FilterFullText,  false,  "",  "") ;
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV12GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV54Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void E156N2( )
      {
         /* Locationoption_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV43 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_Residents", AV22SDT_Residents);
            nGXsfl_43_bak_idx = nGXsfl_43_idx;
            gxgrGrid_refresh( subGrid_Rows, AV18ManageFiltersExecutionStep, AV54Pgmname, AV7FilterFullText, A11OrganisationId, AV56Udparg1, A29LocationId, AV16LocationOption, A62ResidentId, A72ResidentSalutation, A63ResidentBsnNumber, A64ResidentGivenName, A65ResidentLastName, A66ResidentInitials, A67ResidentEmail, A68ResidentGender, A354ResidentCountry, A355ResidentCity, A356ResidentZipCode, A357ResidentAddressLine1, A358ResidentAddressLine2, A70ResidentPhone, A97ResidentTypeName, A98MedicalIndicationId, A99MedicalIndicationName, A73ResidentBirthDate, A96ResidentTypeId, A71ResidentGUID) ;
            nGXsfl_43_idx = nGXsfl_43_bak_idx;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
      }

      protected void E196N2( )
      {
         AV35GXV1 = (int)(nGXsfl_43_idx+GRID_nFirstRecordOnPage);
         if ( ( AV35GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV35GXV1 ) )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1));
         }
         /* Display_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "trn_residentview.aspx"+UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("trn_residentview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E206N2( )
      {
         AV35GXV1 = (int)(nGXsfl_43_idx+GRID_nFirstRecordOnPage);
         if ( ( AV35GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV35GXV1 ) )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1));
         }
         /* Update_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString());
         CallWebObject(formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E216N2( )
      {
         AV35GXV1 = (int)(nGXsfl_43_idx+GRID_nFirstRecordOnPage);
         if ( ( AV35GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV35GXV1 ) )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1));
         }
         /* Delete_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "trn_resident.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Locationid.ToString()) + "," + UrlEncode(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Organisationid.ToString());
         CallWebObject(formatLink("trn_resident.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E226N2( )
      {
         AV35GXV1 = (int)(nGXsfl_43_idx+GRID_nFirstRecordOnPage);
         if ( ( AV35GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV35GXV1 ) )
         {
            AV22SDT_Residents.CurrentItem = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1));
         }
         /* Viewqrcode_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wp_residentqrcode.aspx"+UrlEncode(StringUtil.RTrim(((SdtSDT_Resident)(AV22SDT_Residents.CurrentItem)).gxTpr_Residentguid));
         context.PopUp(formatLink("wp_residentqrcode.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
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
         PA6N2( ) ;
         WS6N2( ) ;
         WE6N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024101016452991", true, true);
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
         context.AddJavascriptSource("wp_locationresidents.js", "?2024101016452993", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_432( )
      {
         edtavViewqrcode_Internalname = "vVIEWQRCODE_"+sGXsfl_43_idx;
         edtavSdt_residents__residentid_Internalname = "SDT_RESIDENTS__RESIDENTID_"+sGXsfl_43_idx;
         edtavSdt_residents__locationid_Internalname = "SDT_RESIDENTS__LOCATIONID_"+sGXsfl_43_idx;
         dynavSdt_residents__organisationid_Internalname = "SDT_RESIDENTS__ORGANISATIONID_"+sGXsfl_43_idx;
         edtavSdt_residents__residentbsnnumber_Internalname = "SDT_RESIDENTS__RESIDENTBSNNUMBER_"+sGXsfl_43_idx;
         cmbavSdt_residents__residentsalutation_Internalname = "SDT_RESIDENTS__RESIDENTSALUTATION_"+sGXsfl_43_idx;
         edtavSdt_residents__residentgivenname_Internalname = "SDT_RESIDENTS__RESIDENTGIVENNAME_"+sGXsfl_43_idx;
         edtavSdt_residents__residentlastname_Internalname = "SDT_RESIDENTS__RESIDENTLASTNAME_"+sGXsfl_43_idx;
         edtavSdt_residents__residentinitials_Internalname = "SDT_RESIDENTS__RESIDENTINITIALS_"+sGXsfl_43_idx;
         cmbavSdt_residents__residentgender_Internalname = "SDT_RESIDENTS__RESIDENTGENDER_"+sGXsfl_43_idx;
         edtavSdt_residents__residentbirthdate_Internalname = "SDT_RESIDENTS__RESIDENTBIRTHDATE_"+sGXsfl_43_idx;
         edtavSdt_residents__residentemail_Internalname = "SDT_RESIDENTS__RESIDENTEMAIL_"+sGXsfl_43_idx;
         edtavSdt_residents__residentphone_Internalname = "SDT_RESIDENTS__RESIDENTPHONE_"+sGXsfl_43_idx;
         edtavSdt_residents__residentguid_Internalname = "SDT_RESIDENTS__RESIDENTGUID_"+sGXsfl_43_idx;
         edtavSdt_residents__residenttypeid_Internalname = "SDT_RESIDENTS__RESIDENTTYPEID_"+sGXsfl_43_idx;
         edtavSdt_residents__residenttypename_Internalname = "SDT_RESIDENTS__RESIDENTTYPENAME_"+sGXsfl_43_idx;
         edtavSdt_residents__medicalindicationid_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONID_"+sGXsfl_43_idx;
         edtavSdt_residents__medicalindicationname_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONNAME_"+sGXsfl_43_idx;
         edtavSdt_residents__residentaddress_Internalname = "SDT_RESIDENTS__RESIDENTADDRESS_"+sGXsfl_43_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_43_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_43_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         edtavViewqrcode_Internalname = "vVIEWQRCODE_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residentid_Internalname = "SDT_RESIDENTS__RESIDENTID_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__locationid_Internalname = "SDT_RESIDENTS__LOCATIONID_"+sGXsfl_43_fel_idx;
         dynavSdt_residents__organisationid_Internalname = "SDT_RESIDENTS__ORGANISATIONID_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residentbsnnumber_Internalname = "SDT_RESIDENTS__RESIDENTBSNNUMBER_"+sGXsfl_43_fel_idx;
         cmbavSdt_residents__residentsalutation_Internalname = "SDT_RESIDENTS__RESIDENTSALUTATION_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residentgivenname_Internalname = "SDT_RESIDENTS__RESIDENTGIVENNAME_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residentlastname_Internalname = "SDT_RESIDENTS__RESIDENTLASTNAME_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residentinitials_Internalname = "SDT_RESIDENTS__RESIDENTINITIALS_"+sGXsfl_43_fel_idx;
         cmbavSdt_residents__residentgender_Internalname = "SDT_RESIDENTS__RESIDENTGENDER_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residentbirthdate_Internalname = "SDT_RESIDENTS__RESIDENTBIRTHDATE_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residentemail_Internalname = "SDT_RESIDENTS__RESIDENTEMAIL_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residentphone_Internalname = "SDT_RESIDENTS__RESIDENTPHONE_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residentguid_Internalname = "SDT_RESIDENTS__RESIDENTGUID_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residenttypeid_Internalname = "SDT_RESIDENTS__RESIDENTTYPEID_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residenttypename_Internalname = "SDT_RESIDENTS__RESIDENTTYPENAME_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__medicalindicationid_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONID_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__medicalindicationname_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONNAME_"+sGXsfl_43_fel_idx;
         edtavSdt_residents__residentaddress_Internalname = "SDT_RESIDENTS__RESIDENTADDRESS_"+sGXsfl_43_fel_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_43_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_43_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         WB6N0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_43_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_43_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavViewqrcode_Internalname,StringUtil.RTrim( AV28viewQrCode),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"","'"+""+"'"+",false,"+"'"+"EVVIEWQRCODE.CLICK."+sGXsfl_43_idx+"'",(string)"",(string)"",context.GetMessage( "QR Code", ""),(string)"",(string)edtavViewqrcode_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavViewqrcode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentid.ToString(),((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)43,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__locationid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Locationid.ToString(),((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Locationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__locationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__locationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)43,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( dynavSdt_residents__organisationid.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_RESIDENTS__ORGANISATIONID_" + sGXsfl_43_idx;
               dynavSdt_residents__organisationid.Name = GXCCtl;
               dynavSdt_residents__organisationid.WebTags = "";
               dynavSdt_residents__organisationid.removeAllItems();
               /* Using cursor H006N4 */
               pr_default.execute(2);
               while ( (pr_default.getStatus(2) != 101) )
               {
                  dynavSdt_residents__organisationid.addItem(H006N4_A11OrganisationId[0].ToString(), H006N4_A13OrganisationName[0], 0);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               if ( dynavSdt_residents__organisationid.ItemCount > 0 )
               {
                  if ( ( AV35GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV35GXV1 ) && (Guid.Empty==((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Organisationid) )
                  {
                     ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Organisationid = StringUtil.StrToGuid( dynavSdt_residents__organisationid.getValidValue(((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Organisationid.ToString()));
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavSdt_residents__organisationid,(string)dynavSdt_residents__organisationid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Organisationid.ToString(),(short)1,(string)dynavSdt_residents__organisationid_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"guid",(string)"",(short)0,dynavSdt_residents__organisationid.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            dynavSdt_residents__organisationid.CurrentValue = ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Organisationid.ToString();
            AssignProp("", false, dynavSdt_residents__organisationid_Internalname, "Values", (string)(dynavSdt_residents__organisationid.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentbsnnumber_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentbsnnumber,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentbsnnumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentbsnnumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbavSdt_residents__residentsalutation.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_RESIDENTS__RESIDENTSALUTATION_" + sGXsfl_43_idx;
               cmbavSdt_residents__residentsalutation.Name = GXCCtl;
               cmbavSdt_residents__residentsalutation.WebTags = "";
               cmbavSdt_residents__residentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
               cmbavSdt_residents__residentsalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
               if ( cmbavSdt_residents__residentsalutation.ItemCount > 0 )
               {
                  if ( ( AV35GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV35GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentsalutation)) )
                  {
                     ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentsalutation = cmbavSdt_residents__residentsalutation.getValidValue(((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentsalutation);
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_residents__residentsalutation,(string)cmbavSdt_residents__residentsalutation_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentsalutation),(short)1,(string)cmbavSdt_residents__residentsalutation_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,cmbavSdt_residents__residentsalutation.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            cmbavSdt_residents__residentsalutation.CurrentValue = StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentsalutation);
            AssignProp("", false, cmbavSdt_residents__residentsalutation_Internalname, "Values", (string)(cmbavSdt_residents__residentsalutation.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentgivenname_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentgivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentgivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_residents__residentgivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentlastname_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_residents__residentlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentinitials_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentinitials),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentinitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentinitials_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbavSdt_residents__residentgender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_RESIDENTS__RESIDENTGENDER_" + sGXsfl_43_idx;
               cmbavSdt_residents__residentgender.Name = GXCCtl;
               cmbavSdt_residents__residentgender.WebTags = "";
               cmbavSdt_residents__residentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
               cmbavSdt_residents__residentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
               cmbavSdt_residents__residentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
               if ( cmbavSdt_residents__residentgender.ItemCount > 0 )
               {
                  if ( ( AV35GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV35GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentgender)) )
                  {
                     ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentgender = cmbavSdt_residents__residentgender.getValidValue(((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentgender);
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_residents__residentgender,(string)cmbavSdt_residents__residentgender_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentgender),(short)1,(string)cmbavSdt_residents__residentgender_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)0,cmbavSdt_residents__residentgender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
            cmbavSdt_residents__residentgender.CurrentValue = StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentgender);
            AssignProp("", false, cmbavSdt_residents__residentgender_Internalname, "Values", (string)(cmbavSdt_residents__residentgender.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentbirthdate_Internalname,context.localUtil.Format(((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentbirthdate, "99/99/9999"),context.localUtil.Format( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentbirthdate, "99/99/9999"),""+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentbirthdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentbirthdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentemail_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentemail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentemail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_residents__residentemail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentphone_Internalname,StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_residents__residentphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentguid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentguid,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentguid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentguid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residenttypeid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residenttypeid.ToString(),((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residenttypeid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residenttypeid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residenttypeid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)43,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residenttypename_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residenttypename,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residenttypename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_residents__residenttypename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__medicalindicationid_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Medicalindicationid.ToString(),((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Medicalindicationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__medicalindicationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__medicalindicationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)43,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__medicalindicationname_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Medicalindicationname,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__medicalindicationname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__medicalindicationname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_residents__residentaddress_Internalname,((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentaddress,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_residents__residentaddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_residents__residentaddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV6Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"","'"+""+"'"+",false,"+"'"+"EVDISPLAY.CLICK."+sGXsfl_43_idx+"'",(string)"",(string)"",context.GetMessage( "GXM_display", ""),(string)"",(string)edtavDisplay_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV27Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"","'"+""+"'"+",false,"+"'"+"EVUPDATE.CLICK."+sGXsfl_43_idx+"'",(string)"",(string)"",context.GetMessage( "GXM_update", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV5Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"","'"+""+"'"+",false,"+"'"+"EVDELETE.CLICK."+sGXsfl_43_idx+"'",(string)"",(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes6N2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
         dynavLocationoption.Name = "vLOCATIONOPTION";
         dynavLocationoption.WebTags = "";
         GXCCtl = "SDT_RESIDENTS__ORGANISATIONID_" + sGXsfl_43_idx;
         dynavSdt_residents__organisationid.Name = GXCCtl;
         dynavSdt_residents__organisationid.WebTags = "";
         dynavSdt_residents__organisationid.removeAllItems();
         /* Using cursor H006N5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            dynavSdt_residents__organisationid.addItem(H006N5_A11OrganisationId[0].ToString(), H006N5_A13OrganisationName[0], 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( dynavSdt_residents__organisationid.ItemCount > 0 )
         {
            if ( ( AV35GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV35GXV1 ) && (Guid.Empty==((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Organisationid) )
            {
               ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Organisationid = StringUtil.StrToGuid( dynavSdt_residents__organisationid.getValidValue(((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Organisationid.ToString()));
            }
         }
         GXCCtl = "SDT_RESIDENTS__RESIDENTSALUTATION_" + sGXsfl_43_idx;
         cmbavSdt_residents__residentsalutation.Name = GXCCtl;
         cmbavSdt_residents__residentsalutation.WebTags = "";
         cmbavSdt_residents__residentsalutation.addItem("Mr", context.GetMessage( "Mr", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Mrs", context.GetMessage( "Mrs", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Dr", context.GetMessage( "Dr", ""), 0);
         cmbavSdt_residents__residentsalutation.addItem("Miss", context.GetMessage( "Miss", ""), 0);
         if ( cmbavSdt_residents__residentsalutation.ItemCount > 0 )
         {
            if ( ( AV35GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV35GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentsalutation)) )
            {
               ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentsalutation = cmbavSdt_residents__residentsalutation.getValidValue(((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentsalutation);
            }
         }
         GXCCtl = "SDT_RESIDENTS__RESIDENTGENDER_" + sGXsfl_43_idx;
         cmbavSdt_residents__residentgender.Name = GXCCtl;
         cmbavSdt_residents__residentgender.WebTags = "";
         cmbavSdt_residents__residentgender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavSdt_residents__residentgender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavSdt_residents__residentgender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavSdt_residents__residentgender.ItemCount > 0 )
         {
            if ( ( AV35GXV1 > 0 ) && ( AV22SDT_Residents.Count >= AV35GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentgender)) )
            {
               ((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentgender = cmbavSdt_residents__residentgender.getValidValue(((SdtSDT_Resident)AV22SDT_Residents.Item(AV35GXV1)).gxTpr_Residentgender);
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl43( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"43\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Location Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "BSN Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Salutation", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "First Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Initials", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Gender", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Date Of Birth", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident GUID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Type Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Resident Type", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Medical Indication Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Medical Indication", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV28viewQrCode)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavViewqrcode_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__locationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavSdt_residents__organisationid.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentbsnnumber_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_residents__residentsalutation.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentgivenname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentlastname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentinitials_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_residents__residentgender.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentbirthdate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentemail_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentphone_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentguid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residenttypeid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residenttypename_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__medicalindicationid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__medicalindicationname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_residents__residentaddress_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV6Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV27Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV5Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
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
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         lblTextblocklocationoption_Internalname = "TEXTBLOCKLOCATIONOPTION";
         dynavLocationoption_Internalname = "vLOCATIONOPTION";
         divUnnamedtablelocationoption_Internalname = "UNNAMEDTABLELOCATIONOPTION";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavViewqrcode_Internalname = "vVIEWQRCODE";
         edtavSdt_residents__residentid_Internalname = "SDT_RESIDENTS__RESIDENTID";
         edtavSdt_residents__locationid_Internalname = "SDT_RESIDENTS__LOCATIONID";
         dynavSdt_residents__organisationid_Internalname = "SDT_RESIDENTS__ORGANISATIONID";
         edtavSdt_residents__residentbsnnumber_Internalname = "SDT_RESIDENTS__RESIDENTBSNNUMBER";
         cmbavSdt_residents__residentsalutation_Internalname = "SDT_RESIDENTS__RESIDENTSALUTATION";
         edtavSdt_residents__residentgivenname_Internalname = "SDT_RESIDENTS__RESIDENTGIVENNAME";
         edtavSdt_residents__residentlastname_Internalname = "SDT_RESIDENTS__RESIDENTLASTNAME";
         edtavSdt_residents__residentinitials_Internalname = "SDT_RESIDENTS__RESIDENTINITIALS";
         cmbavSdt_residents__residentgender_Internalname = "SDT_RESIDENTS__RESIDENTGENDER";
         edtavSdt_residents__residentbirthdate_Internalname = "SDT_RESIDENTS__RESIDENTBIRTHDATE";
         edtavSdt_residents__residentemail_Internalname = "SDT_RESIDENTS__RESIDENTEMAIL";
         edtavSdt_residents__residentphone_Internalname = "SDT_RESIDENTS__RESIDENTPHONE";
         edtavSdt_residents__residentguid_Internalname = "SDT_RESIDENTS__RESIDENTGUID";
         edtavSdt_residents__residenttypeid_Internalname = "SDT_RESIDENTS__RESIDENTTYPEID";
         edtavSdt_residents__residenttypename_Internalname = "SDT_RESIDENTS__RESIDENTTYPENAME";
         edtavSdt_residents__medicalindicationid_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONID";
         edtavSdt_residents__medicalindicationname_Internalname = "SDT_RESIDENTS__MEDICALINDICATIONNAME";
         edtavSdt_residents__residentaddress_Internalname = "SDT_RESIDENTS__RESIDENTADDRESS";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
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
         edtavDelete_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Enabled = 1;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Enabled = 1;
         edtavSdt_residents__residentaddress_Jsonclick = "";
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Jsonclick = "";
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Jsonclick = "";
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__residenttypename_Jsonclick = "";
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__residenttypeid_Jsonclick = "";
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residentguid_Jsonclick = "";
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residentphone_Jsonclick = "";
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentemail_Jsonclick = "";
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentbirthdate_Jsonclick = "";
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         cmbavSdt_residents__residentgender_Jsonclick = "";
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentinitials_Jsonclick = "";
         edtavSdt_residents__residentinitials_Enabled = 0;
         edtavSdt_residents__residentlastname_Jsonclick = "";
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentgivenname_Jsonclick = "";
         edtavSdt_residents__residentgivenname_Enabled = 0;
         cmbavSdt_residents__residentsalutation_Jsonclick = "";
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Jsonclick = "";
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         dynavSdt_residents__organisationid_Jsonclick = "";
         dynavSdt_residents__organisationid.Enabled = 0;
         edtavSdt_residents__locationid_Jsonclick = "";
         edtavSdt_residents__locationid_Enabled = 0;
         edtavSdt_residents__residentid_Jsonclick = "";
         edtavSdt_residents__residentid_Enabled = 0;
         edtavViewqrcode_Jsonclick = "";
         edtavViewqrcode_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtavSdt_residents__residentaddress_Enabled = -1;
         edtavSdt_residents__medicalindicationname_Enabled = -1;
         edtavSdt_residents__medicalindicationid_Enabled = -1;
         edtavSdt_residents__residenttypename_Enabled = -1;
         edtavSdt_residents__residenttypeid_Enabled = -1;
         edtavSdt_residents__residentguid_Enabled = -1;
         edtavSdt_residents__residentphone_Enabled = -1;
         edtavSdt_residents__residentemail_Enabled = -1;
         edtavSdt_residents__residentbirthdate_Enabled = -1;
         cmbavSdt_residents__residentgender.Enabled = -1;
         edtavSdt_residents__residentinitials_Enabled = -1;
         edtavSdt_residents__residentlastname_Enabled = -1;
         edtavSdt_residents__residentgivenname_Enabled = -1;
         cmbavSdt_residents__residentsalutation.Enabled = -1;
         edtavSdt_residents__residentbsnnumber_Enabled = -1;
         dynavSdt_residents__organisationid.Enabled = -1;
         edtavSdt_residents__locationid_Enabled = -1;
         edtavSdt_residents__residentid_Enabled = -1;
         dynavLocationoption_Jsonclick = "";
         dynavLocationoption.Visible = 1;
         dynavLocationoption.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;;;;;;;;;;;;";
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
         Form.Caption = context.GetMessage( "Location Residents", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV54Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV56Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A354ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A355ResidentCity","fld":"RESIDENTCITY"},{"av":"A356ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A357ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A358ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV10GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV11GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV12GridState","fld":"vGRIDSTATE"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E126N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV54Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV56Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A354ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A355ResidentCity","fld":"RESIDENTCITY"},{"av":"A356ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A357ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A358ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E136N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV54Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV56Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A354ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A355ResidentCity","fld":"RESIDENTCITY"},{"av":"A356ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A357ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A358ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E186N2","iparms":[]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV28viewQrCode","fld":"vVIEWQRCODE"},{"av":"AV6Display","fld":"vDISPLAY"},{"av":"AV27Update","fld":"vUPDATE"},{"av":"AV5Delete","fld":"vDELETE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E116N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV54Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV56Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A354ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A355ResidentCity","fld":"RESIDENTCITY"},{"av":"A356ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A357ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A358ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV12GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV12GridState","fld":"vGRIDSTATE"},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV10GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV11GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E146N2","iparms":[]}""");
         setEventMetadata("VLOCATIONOPTION.CONTROLVALUECHANGED","""{"handler":"E156N2","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"AV56Udparg1","fld":"vUDPARG1","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"dynavLocationoption"},{"av":"AV16LocationOption","fld":"vLOCATIONOPTION"},{"av":"A62ResidentId","fld":"RESIDENTID"},{"av":"A72ResidentSalutation","fld":"RESIDENTSALUTATION"},{"av":"A63ResidentBsnNumber","fld":"RESIDENTBSNNUMBER"},{"av":"A64ResidentGivenName","fld":"RESIDENTGIVENNAME"},{"av":"A65ResidentLastName","fld":"RESIDENTLASTNAME"},{"av":"A66ResidentInitials","fld":"RESIDENTINITIALS"},{"av":"A67ResidentEmail","fld":"RESIDENTEMAIL"},{"av":"A68ResidentGender","fld":"RESIDENTGENDER"},{"av":"A354ResidentCountry","fld":"RESIDENTCOUNTRY"},{"av":"A355ResidentCity","fld":"RESIDENTCITY"},{"av":"A356ResidentZipCode","fld":"RESIDENTZIPCODE"},{"av":"A357ResidentAddressLine1","fld":"RESIDENTADDRESSLINE1"},{"av":"A358ResidentAddressLine2","fld":"RESIDENTADDRESSLINE2"},{"av":"A70ResidentPhone","fld":"RESIDENTPHONE"},{"av":"A97ResidentTypeName","fld":"RESIDENTTYPENAME"},{"av":"A98MedicalIndicationId","fld":"MEDICALINDICATIONID"},{"av":"A99MedicalIndicationName","fld":"MEDICALINDICATIONNAME"},{"av":"A73ResidentBirthDate","fld":"RESIDENTBIRTHDATE"},{"av":"A96ResidentTypeId","fld":"RESIDENTTYPEID"},{"av":"A71ResidentGUID","fld":"RESIDENTGUID"},{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"GRID_nEOF"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV54Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV7FilterFullText","fld":"vFILTERFULLTEXT"}]""");
         setEventMetadata("VLOCATIONOPTION.CONTROLVALUECHANGED",""","oparms":[{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43}]}""");
         setEventMetadata("VDISPLAY.CLICK","""{"handler":"E196N2","iparms":[{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43}]}""");
         setEventMetadata("VUPDATE.CLICK","""{"handler":"E206N2","iparms":[{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43}]}""");
         setEventMetadata("VDELETE.CLICK","""{"handler":"E216N2","iparms":[{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43}]}""");
         setEventMetadata("VVIEWQRCODE.CLICK","""{"handler":"E226N2","iparms":[{"av":"AV22SDT_Residents","fld":"vSDT_RESIDENTS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43}]}""");
         setEventMetadata("VALIDV_LOCATIONOPTION","""{"handler":"Validv_Locationoption","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV4","""{"handler":"Validv_Gxv4","iparms":[]}""");
         setEventMetadata("VALIDV_GXV6","""{"handler":"Validv_Gxv6","iparms":[]}""");
         setEventMetadata("VALIDV_GXV10","""{"handler":"Validv_Gxv10","iparms":[]}""");
         setEventMetadata("VALIDV_GXV12","""{"handler":"Validv_Gxv12","iparms":[]}""");
         setEventMetadata("VALIDV_GXV15","""{"handler":"Validv_Gxv15","iparms":[]}""");
         setEventMetadata("VALIDV_GXV17","""{"handler":"Validv_Gxv17","iparms":[]}""");
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
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV54Pgmname = "";
         AV7FilterFullText = "";
         A11OrganisationId = Guid.Empty;
         AV56Udparg1 = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV16LocationOption = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A72ResidentSalutation = "";
         A63ResidentBsnNumber = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A66ResidentInitials = "";
         A67ResidentEmail = "";
         A68ResidentGender = "";
         A354ResidentCountry = "";
         A355ResidentCity = "";
         A356ResidentZipCode = "";
         A357ResidentAddressLine1 = "";
         A358ResidentAddressLine2 = "";
         A70ResidentPhone = "";
         A97ResidentTypeName = "";
         A98MedicalIndicationId = Guid.Empty;
         A99MedicalIndicationName = "";
         A73ResidentBirthDate = DateTime.MinValue;
         A96ResidentTypeId = Guid.Empty;
         A71ResidentGUID = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22SDT_Residents = new GXBaseCollection<SdtSDT_Resident>( context, "SDT_Resident", "Comforta_version2");
         AV17ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV9GridAppliedFilters = "";
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         lblTextblocklocationoption_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV28viewQrCode = "";
         AV6Display = "";
         AV27Update = "";
         AV5Delete = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H006N2_A29LocationId = new Guid[] {Guid.Empty} ;
         H006N2_A31LocationName = new string[] {""} ;
         H006N2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV14HTTPRequest = new GxHttpRequest( context);
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_SdtGAMUser1 = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_guid2 = Guid.Empty;
         AV29WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV19ManageFiltersXml = "";
         H006N3_A29LocationId = new Guid[] {Guid.Empty} ;
         H006N3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006N3_A62ResidentId = new Guid[] {Guid.Empty} ;
         H006N3_A72ResidentSalutation = new string[] {""} ;
         H006N3_A63ResidentBsnNumber = new string[] {""} ;
         H006N3_A64ResidentGivenName = new string[] {""} ;
         H006N3_A65ResidentLastName = new string[] {""} ;
         H006N3_A66ResidentInitials = new string[] {""} ;
         H006N3_A67ResidentEmail = new string[] {""} ;
         H006N3_A68ResidentGender = new string[] {""} ;
         H006N3_A354ResidentCountry = new string[] {""} ;
         H006N3_A355ResidentCity = new string[] {""} ;
         H006N3_A356ResidentZipCode = new string[] {""} ;
         H006N3_A357ResidentAddressLine1 = new string[] {""} ;
         H006N3_A358ResidentAddressLine2 = new string[] {""} ;
         H006N3_A70ResidentPhone = new string[] {""} ;
         H006N3_A97ResidentTypeName = new string[] {""} ;
         H006N3_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         H006N3_A99MedicalIndicationName = new string[] {""} ;
         H006N3_A73ResidentBirthDate = new DateTime[] {DateTime.MinValue} ;
         H006N3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         H006N3_A71ResidentGUID = new string[] {""} ;
         AV21SDT_Resident = new SdtSDT_Resident(context);
         GXt_char3 = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV24Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         H006N4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006N4_A13OrganisationName = new string[] {""} ;
         H006N5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006N5_A13OrganisationName = new string[] {""} ;
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_locationresidents__default(),
            new Object[][] {
                new Object[] {
               H006N2_A29LocationId, H006N2_A31LocationName, H006N2_A11OrganisationId
               }
               , new Object[] {
               H006N3_A29LocationId, H006N3_A11OrganisationId, H006N3_A62ResidentId, H006N3_A72ResidentSalutation, H006N3_A63ResidentBsnNumber, H006N3_A64ResidentGivenName, H006N3_A65ResidentLastName, H006N3_A66ResidentInitials, H006N3_A67ResidentEmail, H006N3_A68ResidentGender,
               H006N3_A354ResidentCountry, H006N3_A355ResidentCity, H006N3_A356ResidentZipCode, H006N3_A357ResidentAddressLine1, H006N3_A358ResidentAddressLine2, H006N3_A70ResidentPhone, H006N3_A97ResidentTypeName, H006N3_A98MedicalIndicationId, H006N3_A99MedicalIndicationName, H006N3_A73ResidentBirthDate,
               H006N3_A96ResidentTypeId, H006N3_A71ResidentGUID
               }
               , new Object[] {
               H006N4_A11OrganisationId, H006N4_A13OrganisationName
               }
               , new Object[] {
               H006N5_A11OrganisationId, H006N5_A13OrganisationName
               }
            }
         );
         AV54Pgmname = "WP_LocationResidents";
         /* GeneXus formulas. */
         AV54Pgmname = "WP_LocationResidents";
         edtavViewqrcode_Enabled = 0;
         edtavSdt_residents__residentid_Enabled = 0;
         edtavSdt_residents__locationid_Enabled = 0;
         dynavSdt_residents__organisationid.Enabled = 0;
         edtavSdt_residents__residentbsnnumber_Enabled = 0;
         cmbavSdt_residents__residentsalutation.Enabled = 0;
         edtavSdt_residents__residentgivenname_Enabled = 0;
         edtavSdt_residents__residentlastname_Enabled = 0;
         edtavSdt_residents__residentinitials_Enabled = 0;
         cmbavSdt_residents__residentgender.Enabled = 0;
         edtavSdt_residents__residentbirthdate_Enabled = 0;
         edtavSdt_residents__residentemail_Enabled = 0;
         edtavSdt_residents__residentphone_Enabled = 0;
         edtavSdt_residents__residentguid_Enabled = 0;
         edtavSdt_residents__residenttypeid_Enabled = 0;
         edtavSdt_residents__residenttypename_Enabled = 0;
         edtavSdt_residents__medicalindicationid_Enabled = 0;
         edtavSdt_residents__medicalindicationname_Enabled = 0;
         edtavSdt_residents__residentaddress_Enabled = 0;
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV18ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int AV35GXV1 ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int edtavViewqrcode_Enabled ;
      private int edtavSdt_residents__residentid_Enabled ;
      private int edtavSdt_residents__locationid_Enabled ;
      private int edtavSdt_residents__residentbsnnumber_Enabled ;
      private int edtavSdt_residents__residentgivenname_Enabled ;
      private int edtavSdt_residents__residentlastname_Enabled ;
      private int edtavSdt_residents__residentinitials_Enabled ;
      private int edtavSdt_residents__residentbirthdate_Enabled ;
      private int edtavSdt_residents__residentemail_Enabled ;
      private int edtavSdt_residents__residentphone_Enabled ;
      private int edtavSdt_residents__residentguid_Enabled ;
      private int edtavSdt_residents__residenttypeid_Enabled ;
      private int edtavSdt_residents__residenttypename_Enabled ;
      private int edtavSdt_residents__medicalindicationid_Enabled ;
      private int edtavSdt_residents__medicalindicationname_Enabled ;
      private int edtavSdt_residents__residentaddress_Enabled ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_43_fel_idx=1 ;
      private int AV20PageToGo ;
      private int nGXsfl_43_bak_idx=1 ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV57GXV20 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV10GridCurrentPage ;
      private long AV11GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_43_idx="0001" ;
      private string AV54Pgmname ;
      private string A72ResidentSalutation ;
      private string A66ResidentInitials ;
      private string A70ResidentPhone ;
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
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divUnnamedtablelocationoption_Internalname ;
      private string lblTextblocklocationoption_Internalname ;
      private string lblTextblocklocationoption_Jsonclick ;
      private string dynavLocationoption_Internalname ;
      private string dynavLocationoption_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV28viewQrCode ;
      private string edtavViewqrcode_Internalname ;
      private string AV6Display ;
      private string edtavDisplay_Internalname ;
      private string AV27Update ;
      private string edtavUpdate_Internalname ;
      private string AV5Delete ;
      private string edtavDelete_Internalname ;
      private string gxwrpcisep ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string GXEncryptionTmp ;
      private string GXt_char3 ;
      private string edtavSdt_residents__residentid_Internalname ;
      private string edtavSdt_residents__locationid_Internalname ;
      private string dynavSdt_residents__organisationid_Internalname ;
      private string edtavSdt_residents__residentbsnnumber_Internalname ;
      private string cmbavSdt_residents__residentsalutation_Internalname ;
      private string edtavSdt_residents__residentgivenname_Internalname ;
      private string edtavSdt_residents__residentlastname_Internalname ;
      private string edtavSdt_residents__residentinitials_Internalname ;
      private string cmbavSdt_residents__residentgender_Internalname ;
      private string edtavSdt_residents__residentbirthdate_Internalname ;
      private string edtavSdt_residents__residentemail_Internalname ;
      private string edtavSdt_residents__residentphone_Internalname ;
      private string edtavSdt_residents__residentguid_Internalname ;
      private string edtavSdt_residents__residenttypeid_Internalname ;
      private string edtavSdt_residents__residenttypename_Internalname ;
      private string edtavSdt_residents__medicalindicationid_Internalname ;
      private string edtavSdt_residents__medicalindicationname_Internalname ;
      private string edtavSdt_residents__residentaddress_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavViewqrcode_Jsonclick ;
      private string edtavSdt_residents__residentid_Jsonclick ;
      private string edtavSdt_residents__locationid_Jsonclick ;
      private string GXCCtl ;
      private string dynavSdt_residents__organisationid_Jsonclick ;
      private string edtavSdt_residents__residentbsnnumber_Jsonclick ;
      private string cmbavSdt_residents__residentsalutation_Jsonclick ;
      private string edtavSdt_residents__residentgivenname_Jsonclick ;
      private string edtavSdt_residents__residentlastname_Jsonclick ;
      private string edtavSdt_residents__residentinitials_Jsonclick ;
      private string cmbavSdt_residents__residentgender_Jsonclick ;
      private string edtavSdt_residents__residentbirthdate_Jsonclick ;
      private string edtavSdt_residents__residentemail_Jsonclick ;
      private string edtavSdt_residents__residentphone_Jsonclick ;
      private string edtavSdt_residents__residentguid_Jsonclick ;
      private string edtavSdt_residents__residenttypeid_Jsonclick ;
      private string edtavSdt_residents__residenttypename_Jsonclick ;
      private string edtavSdt_residents__medicalindicationid_Jsonclick ;
      private string edtavSdt_residents__medicalindicationname_Jsonclick ;
      private string edtavSdt_residents__residentaddress_Jsonclick ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A73ResidentBirthDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool gx_BV43 ;
      private bool AV32IsAuthorized_Update ;
      private bool AV33IsAuthorized_Delete ;
      private bool AV31IsAuthorized_Insert ;
      private bool GXt_boolean4 ;
      private string AV19ManageFiltersXml ;
      private string AV7FilterFullText ;
      private string A63ResidentBsnNumber ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A67ResidentEmail ;
      private string A68ResidentGender ;
      private string A354ResidentCountry ;
      private string A355ResidentCity ;
      private string A356ResidentZipCode ;
      private string A357ResidentAddressLine1 ;
      private string A358ResidentAddressLine2 ;
      private string A97ResidentTypeName ;
      private string A99MedicalIndicationName ;
      private string A71ResidentGUID ;
      private string AV9GridAppliedFilters ;
      private Guid A11OrganisationId ;
      private Guid AV56Udparg1 ;
      private Guid A29LocationId ;
      private Guid AV16LocationOption ;
      private Guid A62ResidentId ;
      private Guid A98MedicalIndicationId ;
      private Guid A96ResidentTypeId ;
      private Guid GXt_guid2 ;
      private IGxSession AV24Session ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV14HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLocationoption ;
      private GXCombobox dynavSdt_residents__organisationid ;
      private GXCombobox cmbavSdt_residents__residentsalutation ;
      private GXCombobox cmbavSdt_residents__residentgender ;
      private GXBaseCollection<SdtSDT_Resident> AV22SDT_Residents ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private IDataStoreProvider pr_default ;
      private Guid[] H006N2_A29LocationId ;
      private string[] H006N2_A31LocationName ;
      private Guid[] H006N2_A11OrganisationId ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser GXt_SdtGAMUser1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV29WWPContext ;
      private Guid[] H006N3_A29LocationId ;
      private Guid[] H006N3_A11OrganisationId ;
      private Guid[] H006N3_A62ResidentId ;
      private string[] H006N3_A72ResidentSalutation ;
      private string[] H006N3_A63ResidentBsnNumber ;
      private string[] H006N3_A64ResidentGivenName ;
      private string[] H006N3_A65ResidentLastName ;
      private string[] H006N3_A66ResidentInitials ;
      private string[] H006N3_A67ResidentEmail ;
      private string[] H006N3_A68ResidentGender ;
      private string[] H006N3_A354ResidentCountry ;
      private string[] H006N3_A355ResidentCity ;
      private string[] H006N3_A356ResidentZipCode ;
      private string[] H006N3_A357ResidentAddressLine1 ;
      private string[] H006N3_A358ResidentAddressLine2 ;
      private string[] H006N3_A70ResidentPhone ;
      private string[] H006N3_A97ResidentTypeName ;
      private Guid[] H006N3_A98MedicalIndicationId ;
      private string[] H006N3_A99MedicalIndicationName ;
      private DateTime[] H006N3_A73ResidentBirthDate ;
      private Guid[] H006N3_A96ResidentTypeId ;
      private string[] H006N3_A71ResidentGUID ;
      private SdtSDT_Resident AV21SDT_Resident ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] H006N4_A11OrganisationId ;
      private string[] H006N4_A13OrganisationName ;
      private Guid[] H006N5_A11OrganisationId ;
      private string[] H006N5_A13OrganisationName ;
   }

   public class wp_locationresidents__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H006N3( IGxContext context ,
                                             Guid AV16LocationOption ,
                                             Guid A29LocationId ,
                                             Guid A11OrganisationId ,
                                             Guid AV56Udparg1 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[2];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.LocationId, T1.OrganisationId, T1.ResidentId, T1.ResidentSalutation, T1.ResidentBsnNumber, T1.ResidentGivenName, T1.ResidentLastName, T1.ResidentInitials, T1.ResidentEmail, T1.ResidentGender, T1.ResidentCountry, T1.ResidentCity, T1.ResidentZipCode, T1.ResidentAddressLine1, T1.ResidentAddressLine2, T1.ResidentPhone, T3.ResidentTypeName, T1.MedicalIndicationId, T2.MedicalIndicationName, T1.ResidentBirthDate, T1.ResidentTypeId, T1.ResidentGUID FROM ((Trn_Resident T1 INNER JOIN Trn_MedicalIndication T2 ON T2.MedicalIndicationId = T1.MedicalIndicationId) INNER JOIN Trn_ResidentType T3 ON T3.ResidentTypeId = T1.ResidentTypeId)";
         AddWhere(sWhereString, "(T1.OrganisationId = :AV56Udparg1)");
         if ( ! (Guid.Empty==AV16LocationOption) )
         {
            AddWhere(sWhereString, "(T1.LocationId = :AV16LocationOption)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H006N3(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
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
          Object[] prmH006N2;
          prmH006N2 = new Object[] {
          };
          Object[] prmH006N4;
          prmH006N4 = new Object[] {
          };
          Object[] prmH006N5;
          prmH006N5 = new Object[] {
          };
          Object[] prmH006N3;
          prmH006N3 = new Object[] {
          new ParDef("AV56Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV16LocationOption",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006N2", "SELECT LocationId, LocationName, OrganisationId FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006N2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006N3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006N4", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006N4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006N5", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006N5,0, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((string[]) buf[16])[0] = rslt.getVarchar(17);
                ((Guid[]) buf[17])[0] = rslt.getGuid(18);
                ((string[]) buf[18])[0] = rslt.getVarchar(19);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(20);
                ((Guid[]) buf[20])[0] = rslt.getGuid(21);
                ((string[]) buf[21])[0] = rslt.getVarchar(22);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
