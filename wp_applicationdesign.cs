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
   public class wp_applicationdesign : GXHttpHandler
   {
      public wp_applicationdesign( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_applicationdesign( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_Trn_PageId )
      {
         this.AV16Trn_PageId = aP0_Trn_PageId;
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
            gxfirstwebparm = GetFirstPar( "Trn_PageId");
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
               gxfirstwebparm = GetFirstPar( "Trn_PageId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Trn_PageId");
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
            return "wp_applicationdesign_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            ValidateSpaRequest();
            PA472( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS472( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE472( ) ;
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( context.GetMessage( "WP_Application Design", "")) ;
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
         context.AddJavascriptSource("UserControls/UC_AppToolBox2Render.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wp_applicationdesign.aspx"+UrlEncode(AV16Trn_PageId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_applicationdesign.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_TILE", AV9BC_Trn_Tile);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_TILE", AV9BC_Trn_Tile);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_PAGE", AV14SDT_Page);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_PAGE", AV14SDT_Page);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_PAGECOLLECTION", AV15SDT_PageCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_PAGECOLLECTION", AV15SDT_PageCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_TEMPLATECOLLECTION", AV10BC_Trn_TemplateCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_TEMPLATECOLLECTION", AV10BC_Trn_TemplateCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_THEMECOLLECTION", AV13BC_Trn_ThemeCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_THEMECOLLECTION", AV13BC_Trn_ThemeCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_MEDIACOLLECTION", AV21BC_Trn_MediaCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_MEDIACOLLECTION", AV21BC_Trn_MediaCollection);
         }
         GxWebStd.gx_hidden_field( context, "vTRN_PAGEID", AV16Trn_PageId.ToString());
      }

      protected void RenderHtmlCloseForm472( )
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "WP_ApplicationDesign" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Application Design", "") ;
      }

      protected void WB470( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucApptoolbox1.SetProperty("SDT_Tile", AV9BC_Trn_Tile);
            ucApptoolbox1.SetProperty("SDT_Page", AV14SDT_Page);
            ucApptoolbox1.SetProperty("SDT_PageCollection", AV15SDT_PageCollection);
            ucApptoolbox1.SetProperty("BC_Trn_TemplateCollection", AV10BC_Trn_TemplateCollection);
            ucApptoolbox1.SetProperty("BC_Trn_ThemeCollection", AV13BC_Trn_ThemeCollection);
            ucApptoolbox1.SetProperty("BC_Trn_MediaCollection", AV21BC_Trn_MediaCollection);
            ucApptoolbox1.Render(context, "uc_apptoolbox2", Apptoolbox1_Internalname, "APPTOOLBOX1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START472( )
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
         Form.Meta.addItem("description", context.GetMessage( "WP_Application Design", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP470( ) ;
      }

      protected void WS472( )
      {
         START472( ) ;
         EVT472( ) ;
      }

      protected void EVT472( )
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
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11472 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E12472 ();
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
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE472( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm472( ) ;
            }
         }
      }

      protected void PA472( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_applicationdesign.aspx")), "wp_applicationdesign.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_applicationdesign.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "Trn_PageId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV16Trn_PageId = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV16Trn_PageId", AV16Trn_PageId.ToString());
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         RF472( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF472( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12472 ();
            WB470( ) ;
         }
      }

      protected void send_integrity_lvl_hashes472( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP470( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11472 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_TILE"), AV9BC_Trn_Tile);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_PAGE"), AV14SDT_Page);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_PAGECOLLECTION"), AV15SDT_PageCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_TEMPLATECOLLECTION"), AV10BC_Trn_TemplateCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_THEMECOLLECTION"), AV13BC_Trn_ThemeCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_MEDIACOLLECTION"), AV21BC_Trn_MediaCollection);
            /* Read saved values. */
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11472 ();
         if (returnInSub) return;
      }

      protected void E11472( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Headerrawhtml = Form.Headerrawhtml+"<link rel=\"stylesheet\" href=\"Resources/UCGrapes/new-design/grapes/grapes.css\">"+"<link rel=\"stylesheet\" href=\"/Resources/UCGrapes/new-design/css/styles.css\" />"+"<script src=\"Resources/UCGrapes/new-design/grapes/grapes.js\"></script>";
         /* Using cursor H00472 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A310Trn_PageId = H00472_A310Trn_PageId[0];
            A318Trn_PageName = H00472_A318Trn_PageName[0];
            if ( ! ( StringUtil.StrCmp(A318Trn_PageName, context.GetMessage( "Home", "")) == 0 ) )
            {
               AV14SDT_Page = new SdtSDT_Page(context);
               AV14SDT_Page.gxTpr_Pageid = A310Trn_PageId;
               AV14SDT_Page.gxTpr_Pagename = A318Trn_PageName;
               /* Using cursor H00473 */
               pr_default.execute(1, new Object[] {A310Trn_PageId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A319Trn_RowId = H00473_A319Trn_RowId[0];
                  A320Trn_RowName = H00473_A320Trn_RowName[0];
                  AV17SDT_Row = new SdtSDT_Row(context);
                  AV17SDT_Row.gxTpr_Rowid = A319Trn_RowId;
                  AV17SDT_Row.gxTpr_Rowname = A320Trn_RowName;
                  AV14SDT_Page.gxTpr_Row.Add(AV17SDT_Row, 0);
                  /* Using cursor H00474 */
                  pr_default.execute(2, new Object[] {A319Trn_RowId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A328Trn_ColId = H00474_A328Trn_ColId[0];
                     A327Trn_ColName = H00474_A327Trn_ColName[0];
                     A407TileId = H00474_A407TileId[0];
                     A400TileName = H00474_A400TileName[0];
                     A402TileBGColor = H00474_A402TileBGColor[0];
                     n402TileBGColor = H00474_n402TileBGColor[0];
                     A403TileBGImageUrl = H00474_A403TileBGImageUrl[0];
                     n403TileBGImageUrl = H00474_n403TileBGImageUrl[0];
                     A404TileTextColor = H00474_A404TileTextColor[0];
                     A405TileTextAlignment = H00474_A405TileTextAlignment[0];
                     A406TileIconAlignment = H00474_A406TileIconAlignment[0];
                     A329SG_ToPageId = H00474_A329SG_ToPageId[0];
                     A330SG_ToPageName = H00474_A330SG_ToPageName[0];
                     A400TileName = H00474_A400TileName[0];
                     A402TileBGColor = H00474_A402TileBGColor[0];
                     n402TileBGColor = H00474_n402TileBGColor[0];
                     A403TileBGImageUrl = H00474_A403TileBGImageUrl[0];
                     n403TileBGImageUrl = H00474_n403TileBGImageUrl[0];
                     A404TileTextColor = H00474_A404TileTextColor[0];
                     A405TileTextAlignment = H00474_A405TileTextAlignment[0];
                     A406TileIconAlignment = H00474_A406TileIconAlignment[0];
                     A329SG_ToPageId = H00474_A329SG_ToPageId[0];
                     A330SG_ToPageName = H00474_A330SG_ToPageName[0];
                     AV18SDT_Col = new SdtSDT_Col(context);
                     AV19SDT_Tile = new SdtSDT_Tile(context);
                     AV18SDT_Col.gxTpr_Colid = A328Trn_ColId;
                     AV18SDT_Col.gxTpr_Colname = A327Trn_ColName;
                     AV19SDT_Tile.gxTpr_Tileid = A407TileId;
                     AV19SDT_Tile.gxTpr_Tilename = A400TileName;
                     AV19SDT_Tile.gxTpr_Tilebgcolor = A402TileBGColor;
                     AV19SDT_Tile.gxTpr_Tilebgimageurl = A403TileBGImageUrl;
                     AV19SDT_Tile.gxTpr_Tiletextcolor = A404TileTextColor;
                     AV19SDT_Tile.gxTpr_Tiletextalignment = A405TileTextAlignment;
                     AV19SDT_Tile.gxTpr_Tileiconalignment = A406TileIconAlignment;
                     AV19SDT_Tile.gxTpr_Tilename = A400TileName;
                     AV19SDT_Tile.gxTpr_Topageid = A329SG_ToPageId;
                     AV19SDT_Tile.gxTpr_Topagename = A330SG_ToPageName;
                     AV18SDT_Col.gxTpr_Tile = AV19SDT_Tile;
                     AV17SDT_Row.gxTpr_Col.Add(AV18SDT_Col, 0);
                     pr_default.readNext(2);
                  }
                  pr_default.close(2);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV15SDT_PageCollection.Add(AV14SDT_Page, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor H00475 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A400TileName = H00475_A400TileName[0];
            A407TileId = H00475_A407TileId[0];
            if ( StringUtil.StrCmp(A400TileName, context.GetMessage( "Home", "")) == 0 )
            {
               AV9BC_Trn_Tile.Load(A407TileId);
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor H00476 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A278Trn_TemplateId = H00476_A278Trn_TemplateId[0];
            AV11BC_Trn_Template = new SdtTrn_Template(context);
            AV11BC_Trn_Template.Load(A278Trn_TemplateId);
            AV10BC_Trn_TemplateCollection.Add(AV11BC_Trn_Template, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Using cursor H00477 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A409MediaId = H00477_A409MediaId[0];
            AV20BC_Trn_Media = new SdtTrn_Media(context);
            AV20BC_Trn_Media.Load(A409MediaId);
            AV21BC_Trn_MediaCollection.Add(AV20BC_Trn_Media, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Using cursor H00478 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A247Trn_ThemeId = H00478_A247Trn_ThemeId[0];
            AV12BC_Trn_Theme = new SdtTrn_Theme(context);
            AV12BC_Trn_Theme.Load(A247Trn_ThemeId);
            AV13BC_Trn_ThemeCollection.Add(AV12BC_Trn_Theme, 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void nextLoad( )
      {
      }

      protected void E12472( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16Trn_PageId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV16Trn_PageId", AV16Trn_PageId.ToString());
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
         PA472( ) ;
         WS472( ) ;
         WE472( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241028843481", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wp_applicationdesign.js", "?20241028843482", false, true);
            context.AddJavascriptSource("UserControls/UC_AppToolBox2Render.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTablecontent_Internalname = "TABLECONTENT";
         Apptoolbox1_Internalname = "APPTOOLBOX1";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
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
         wcpOAV16Trn_PageId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9BC_Trn_Tile = new SdtTrn_Tile(context);
         AV14SDT_Page = new SdtSDT_Page(context);
         AV15SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         AV10BC_Trn_TemplateCollection = new GXBCCollection<SdtTrn_Template>( context, "Trn_Template", "Comforta_version2");
         AV13BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2");
         AV21BC_Trn_MediaCollection = new GXBCCollection<SdtTrn_Media>( context, "Trn_Media", "Comforta_version2");
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucApptoolbox1 = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00472_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         H00472_A318Trn_PageName = new string[] {""} ;
         A310Trn_PageId = Guid.Empty;
         A318Trn_PageName = "";
         H00473_A310Trn_PageId = new Guid[] {Guid.Empty} ;
         H00473_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         H00473_A320Trn_RowName = new string[] {""} ;
         A319Trn_RowId = Guid.Empty;
         A320Trn_RowName = "";
         AV17SDT_Row = new SdtSDT_Row(context);
         H00474_A319Trn_RowId = new Guid[] {Guid.Empty} ;
         H00474_A328Trn_ColId = new Guid[] {Guid.Empty} ;
         H00474_A327Trn_ColName = new string[] {""} ;
         H00474_A407TileId = new Guid[] {Guid.Empty} ;
         H00474_A400TileName = new string[] {""} ;
         H00474_A402TileBGColor = new string[] {""} ;
         H00474_n402TileBGColor = new bool[] {false} ;
         H00474_A403TileBGImageUrl = new string[] {""} ;
         H00474_n403TileBGImageUrl = new bool[] {false} ;
         H00474_A404TileTextColor = new string[] {""} ;
         H00474_A405TileTextAlignment = new string[] {""} ;
         H00474_A406TileIconAlignment = new string[] {""} ;
         H00474_A329SG_ToPageId = new Guid[] {Guid.Empty} ;
         H00474_A330SG_ToPageName = new string[] {""} ;
         A328Trn_ColId = Guid.Empty;
         A327Trn_ColName = "";
         A407TileId = Guid.Empty;
         A400TileName = "";
         A402TileBGColor = "";
         A403TileBGImageUrl = "";
         A404TileTextColor = "";
         A405TileTextAlignment = "";
         A406TileIconAlignment = "";
         A329SG_ToPageId = Guid.Empty;
         A330SG_ToPageName = "";
         AV18SDT_Col = new SdtSDT_Col(context);
         AV19SDT_Tile = new SdtSDT_Tile(context);
         H00475_A400TileName = new string[] {""} ;
         H00475_A407TileId = new Guid[] {Guid.Empty} ;
         H00476_A278Trn_TemplateId = new Guid[] {Guid.Empty} ;
         A278Trn_TemplateId = Guid.Empty;
         AV11BC_Trn_Template = new SdtTrn_Template(context);
         H00477_A409MediaId = new Guid[] {Guid.Empty} ;
         A409MediaId = Guid.Empty;
         AV20BC_Trn_Media = new SdtTrn_Media(context);
         H00478_A247Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A247Trn_ThemeId = Guid.Empty;
         AV12BC_Trn_Theme = new SdtTrn_Theme(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_applicationdesign__default(),
            new Object[][] {
                new Object[] {
               H00472_A310Trn_PageId, H00472_A318Trn_PageName
               }
               , new Object[] {
               H00473_A310Trn_PageId, H00473_A319Trn_RowId, H00473_A320Trn_RowName
               }
               , new Object[] {
               H00474_A319Trn_RowId, H00474_A328Trn_ColId, H00474_A327Trn_ColName, H00474_A407TileId, H00474_A400TileName, H00474_A402TileBGColor, H00474_n402TileBGColor, H00474_A403TileBGImageUrl, H00474_n403TileBGImageUrl, H00474_A404TileTextColor,
               H00474_A405TileTextAlignment, H00474_A406TileIconAlignment, H00474_A329SG_ToPageId, H00474_A330SG_ToPageName
               }
               , new Object[] {
               H00475_A400TileName, H00475_A407TileId
               }
               , new Object[] {
               H00476_A278Trn_TemplateId
               }
               , new Object[] {
               H00477_A409MediaId
               }
               , new Object[] {
               H00478_A247Trn_ThemeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Apptoolbox1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string A402TileBGColor ;
      private string A404TileTextColor ;
      private string A405TileTextAlignment ;
      private string A406TileIconAlignment ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n402TileBGColor ;
      private bool n403TileBGImageUrl ;
      private string A318Trn_PageName ;
      private string A320Trn_RowName ;
      private string A327Trn_ColName ;
      private string A400TileName ;
      private string A403TileBGImageUrl ;
      private string A330SG_ToPageName ;
      private Guid AV16Trn_PageId ;
      private Guid wcpOAV16Trn_PageId ;
      private Guid A310Trn_PageId ;
      private Guid A319Trn_RowId ;
      private Guid A328Trn_ColId ;
      private Guid A407TileId ;
      private Guid A329SG_ToPageId ;
      private Guid A278Trn_TemplateId ;
      private Guid A409MediaId ;
      private Guid A247Trn_ThemeId ;
      private GXUserControl ucApptoolbox1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Tile AV9BC_Trn_Tile ;
      private SdtSDT_Page AV14SDT_Page ;
      private GXBaseCollection<SdtSDT_Page> AV15SDT_PageCollection ;
      private GXBCCollection<SdtTrn_Template> AV10BC_Trn_TemplateCollection ;
      private GXBCCollection<SdtTrn_Theme> AV13BC_Trn_ThemeCollection ;
      private GXBCCollection<SdtTrn_Media> AV21BC_Trn_MediaCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00472_A310Trn_PageId ;
      private string[] H00472_A318Trn_PageName ;
      private Guid[] H00473_A310Trn_PageId ;
      private Guid[] H00473_A319Trn_RowId ;
      private string[] H00473_A320Trn_RowName ;
      private SdtSDT_Row AV17SDT_Row ;
      private Guid[] H00474_A319Trn_RowId ;
      private Guid[] H00474_A328Trn_ColId ;
      private string[] H00474_A327Trn_ColName ;
      private Guid[] H00474_A407TileId ;
      private string[] H00474_A400TileName ;
      private string[] H00474_A402TileBGColor ;
      private bool[] H00474_n402TileBGColor ;
      private string[] H00474_A403TileBGImageUrl ;
      private bool[] H00474_n403TileBGImageUrl ;
      private string[] H00474_A404TileTextColor ;
      private string[] H00474_A405TileTextAlignment ;
      private string[] H00474_A406TileIconAlignment ;
      private Guid[] H00474_A329SG_ToPageId ;
      private string[] H00474_A330SG_ToPageName ;
      private SdtSDT_Col AV18SDT_Col ;
      private SdtSDT_Tile AV19SDT_Tile ;
      private string[] H00475_A400TileName ;
      private Guid[] H00475_A407TileId ;
      private Guid[] H00476_A278Trn_TemplateId ;
      private SdtTrn_Template AV11BC_Trn_Template ;
      private Guid[] H00477_A409MediaId ;
      private SdtTrn_Media AV20BC_Trn_Media ;
      private Guid[] H00478_A247Trn_ThemeId ;
      private SdtTrn_Theme AV12BC_Trn_Theme ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_applicationdesign__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00472;
          prmH00472 = new Object[] {
          };
          Object[] prmH00473;
          prmH00473 = new Object[] {
          new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH00474;
          prmH00474 = new Object[] {
          new ParDef("Trn_RowId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH00475;
          prmH00475 = new Object[] {
          };
          Object[] prmH00476;
          prmH00476 = new Object[] {
          };
          Object[] prmH00477;
          prmH00477 = new Object[] {
          };
          Object[] prmH00478;
          prmH00478 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00472", "SELECT Trn_PageId, Trn_PageName FROM Trn_Page ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00472,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00473", "SELECT Trn_PageId, Trn_RowId, Trn_RowName FROM Trn_Row WHERE Trn_PageId = :Trn_PageId ORDER BY Trn_PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00473,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00474", "SELECT T1.Trn_RowId, T1.Trn_ColId, T1.Trn_ColName, T1.TileId, T2.TileName, T2.TileBGColor, T2.TileBGImageUrl, T2.TileTextColor, T2.TileTextAlignment, T2.TileIconAlignment, T2.SG_ToPageId AS SG_ToPageId, T3.Trn_PageName AS SG_ToPageName FROM ((Trn_Col T1 INNER JOIN Trn_Tile T2 ON T2.TileId = T1.TileId) INNER JOIN Trn_Page T3 ON T3.Trn_PageId = T2.SG_ToPageId) WHERE T1.Trn_RowId = :Trn_RowId ORDER BY T1.Trn_RowId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00474,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00475", "SELECT TileName, TileId FROM Trn_Tile ORDER BY TileId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00475,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00476", "SELECT Trn_TemplateId FROM Trn_Template ORDER BY Trn_TemplateId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00476,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00477", "SELECT MediaId FROM Trn_Media ORDER BY MediaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00477,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00478", "SELECT Trn_ThemeId FROM Trn_Theme ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00478,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((string[]) buf[11])[0] = rslt.getString(10, 20);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
