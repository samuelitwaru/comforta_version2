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
   public class trn_organisationsettinggeneral : GXWebComponent
   {
      public trn_organisationsettinggeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public trn_organisationsettinggeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationSettingid )
      {
         this.A100OrganisationSettingid = aP0_OrganisationSettingid;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "OrganisationSettingid");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A100OrganisationSettingid = StringUtil.StrToGuid( GetPar( "OrganisationSettingid"));
                  AssignAttri(sPrefix, false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A100OrganisationSettingid});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "OrganisationSettingid");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "OrganisationSettingid");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA462( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV25Pgmname = "Trn_OrganisationSettingGeneral";
               edtavOrganisationsettinglanguage_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavOrganisationsettinglanguage_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationsettinglanguage_description_Enabled), 5, 0), true);
               edtavOrganisationsettingfontsize_description_Enabled = 0;
               AssignProp(sPrefix, false, edtavOrganisationsettingfontsize_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationsettingfontsize_description_Enabled), 5, 0), true);
               WS462( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Trn_Organisation Setting General", "")) ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_organisationsettinggeneral.aspx"+UrlEncode(A100OrganisationSettingid.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_organisationsettinggeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONSETTINGLANGUAGE_DESCRIPTION", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV14OrganisationSettingLanguage_Description, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Trn_OrganisationSettingGeneral");
         forbiddenHiddens.Add("OrganisationSettingLanguage_Description", StringUtil.RTrim( context.localUtil.Format( AV14OrganisationSettingLanguage_Description, "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trn_organisationsettinggeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA100OrganisationSettingid", wcpOA100OrganisationSettingid.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm462( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "Trn_OrganisationSettingGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Organisation Setting General", "") ;
      }

      protected void WB460( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_organisationsettinggeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgOrganisationSettingLogo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Logo", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A101OrganisationSettingLogo_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000OrganisationSettingLogo_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)) ? A40000OrganisationSettingLogo_GXI : context.PathToRelativeUrl( A101OrganisationSettingLogo));
            GxWebStd.gx_bitmap( context, imgOrganisationSettingLogo_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A101OrganisationSettingLogo_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_OrganisationSettingGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgOrganisationSettingFavicon_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Favicon", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A102OrganisationSettingFavicon_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001OrganisationSettingFavicon_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)) ? A40001OrganisationSettingFavicon_GXI : context.PathToRelativeUrl( A102OrganisationSettingFavicon));
            GxWebStd.gx_bitmap( context, imgOrganisationSettingFavicon_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A102OrganisationSettingFavicon_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Trn_OrganisationSettingGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationsettinglanguage_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationsettinglanguage_description_Internalname, context.GetMessage( "Language", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationsettinglanguage_description_Internalname, AV14OrganisationSettingLanguage_Description, StringUtil.RTrim( context.localUtil.Format( AV14OrganisationSettingLanguage_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationsettinglanguage_description_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationsettinglanguage_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationSettingGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationsettingfontsize_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationsettingfontsize_description_Internalname, context.GetMessage( "Font Size", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationsettingfontsize_description_Internalname, AV21OrganisationSettingFontSize_Description, StringUtil.RTrim( context.localUtil.Format( AV21OrganisationSettingFontSize_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationsettingfontsize_description_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationsettingfontsize_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationSettingGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_basecolor_Internalname, context.GetMessage( "Base Color", ""), "", "", lblTransactiondetail_basecolor_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_Trn_OrganisationSettingGeneral.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_OrganisationSettingGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_OrganisationSettingGeneral.htm");
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
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_OrganisationSettingGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtOrganisationSettingid_Internalname, A100OrganisationSettingid.ToString(), A100OrganisationSettingid.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationSettingid_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationSettingid_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_OrganisationSettingGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtOrganisationSettingBaseColor_Internalname, A103OrganisationSettingBaseColor, StringUtil.RTrim( context.localUtil.Format( A103OrganisationSettingBaseColor, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationSettingBaseColor_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationSettingBaseColor_Visible, 0, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_OrganisationSettingGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START462( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Trn_Organisation Setting General", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP460( ) ;
            }
         }
      }

      protected void WS462( )
      {
         START462( ) ;
         EVT462( ) ;
      }

      protected void EVT462( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
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
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP460( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP460( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11462 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP460( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12462 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP460( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13462 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP460( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14462 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP460( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP460( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavOrganisationsettinglanguage_description_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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
      }

      protected void WE462( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm462( ) ;
            }
         }
      }

      protected void PA462( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_organisationsettinggeneral.aspx")), "trn_organisationsettinggeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_organisationsettinggeneral.aspx")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "OrganisationSettingid");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavOrganisationsettinglanguage_description_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         RF462( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV25Pgmname = "Trn_OrganisationSettingGeneral";
         edtavOrganisationsettinglanguage_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavOrganisationsettinglanguage_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationsettinglanguage_description_Enabled), 5, 0), true);
         edtavOrganisationsettingfontsize_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavOrganisationsettingfontsize_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationsettingfontsize_description_Enabled), 5, 0), true);
      }

      protected void RF462( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00462 */
            pr_default.execute(0, new Object[] {A100OrganisationSettingid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A105OrganisationSettingLanguage = H00462_A105OrganisationSettingLanguage[0];
               A104OrganisationSettingFontSize = H00462_A104OrganisationSettingFontSize[0];
               A103OrganisationSettingBaseColor = H00462_A103OrganisationSettingBaseColor[0];
               AssignAttri(sPrefix, false, "A103OrganisationSettingBaseColor", A103OrganisationSettingBaseColor);
               A11OrganisationId = H00462_A11OrganisationId[0];
               AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
               A40001OrganisationSettingFavicon_GXI = H00462_A40001OrganisationSettingFavicon_GXI[0];
               AssignProp(sPrefix, false, imgOrganisationSettingFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)) ? A40001OrganisationSettingFavicon_GXI : context.convertURL( context.PathToRelativeUrl( A102OrganisationSettingFavicon))), true);
               AssignProp(sPrefix, false, imgOrganisationSettingFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A102OrganisationSettingFavicon), true);
               A40000OrganisationSettingLogo_GXI = H00462_A40000OrganisationSettingLogo_GXI[0];
               AssignProp(sPrefix, false, imgOrganisationSettingLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)) ? A40000OrganisationSettingLogo_GXI : context.convertURL( context.PathToRelativeUrl( A101OrganisationSettingLogo))), true);
               AssignProp(sPrefix, false, imgOrganisationSettingLogo_Internalname, "SrcSet", context.GetImageSrcSet( A101OrganisationSettingLogo), true);
               A102OrganisationSettingFavicon = H00462_A102OrganisationSettingFavicon[0];
               AssignAttri(sPrefix, false, "A102OrganisationSettingFavicon", A102OrganisationSettingFavicon);
               AssignProp(sPrefix, false, imgOrganisationSettingFavicon_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A102OrganisationSettingFavicon)) ? A40001OrganisationSettingFavicon_GXI : context.convertURL( context.PathToRelativeUrl( A102OrganisationSettingFavicon))), true);
               AssignProp(sPrefix, false, imgOrganisationSettingFavicon_Internalname, "SrcSet", context.GetImageSrcSet( A102OrganisationSettingFavicon), true);
               A101OrganisationSettingLogo = H00462_A101OrganisationSettingLogo[0];
               AssignAttri(sPrefix, false, "A101OrganisationSettingLogo", A101OrganisationSettingLogo);
               AssignProp(sPrefix, false, imgOrganisationSettingLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A101OrganisationSettingLogo)) ? A40000OrganisationSettingLogo_GXI : context.convertURL( context.PathToRelativeUrl( A101OrganisationSettingLogo))), true);
               AssignProp(sPrefix, false, imgOrganisationSettingLogo_Internalname, "SrcSet", context.GetImageSrcSet( A101OrganisationSettingLogo), true);
               /* Execute user event: Load */
               E12462 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB460( ) ;
         }
      }

      protected void send_integrity_lvl_hashes462( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONSETTINGLANGUAGE_DESCRIPTION", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV14OrganisationSettingLanguage_Description, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV25Pgmname = "Trn_OrganisationSettingGeneral";
         edtavOrganisationsettinglanguage_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavOrganisationsettinglanguage_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationsettinglanguage_description_Enabled), 5, 0), true);
         edtavOrganisationsettingfontsize_description_Enabled = 0;
         AssignProp(sPrefix, false, edtavOrganisationsettingfontsize_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOrganisationsettingfontsize_description_Enabled), 5, 0), true);
         imgOrganisationSettingLogo_Enabled = 0;
         AssignProp(sPrefix, false, imgOrganisationSettingLogo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgOrganisationSettingLogo_Enabled), 5, 0), true);
         imgOrganisationSettingFavicon_Enabled = 0;
         AssignProp(sPrefix, false, imgOrganisationSettingFavicon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgOrganisationSettingFavicon_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtOrganisationSettingid_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationSettingid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingid_Enabled), 5, 0), true);
         edtOrganisationSettingBaseColor_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationSettingBaseColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingBaseColor_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP460( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11462 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA100OrganisationSettingid = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA100OrganisationSettingid"));
            /* Read variables values. */
            A101OrganisationSettingLogo = cgiGet( imgOrganisationSettingLogo_Internalname);
            AssignAttri(sPrefix, false, "A101OrganisationSettingLogo", A101OrganisationSettingLogo);
            A102OrganisationSettingFavicon = cgiGet( imgOrganisationSettingFavicon_Internalname);
            AssignAttri(sPrefix, false, "A102OrganisationSettingFavicon", A102OrganisationSettingFavicon);
            AV14OrganisationSettingLanguage_Description = cgiGet( edtavOrganisationsettinglanguage_description_Internalname);
            AssignAttri(sPrefix, false, "AV14OrganisationSettingLanguage_Description", AV14OrganisationSettingLanguage_Description);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONSETTINGLANGUAGE_DESCRIPTION", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV14OrganisationSettingLanguage_Description, "")), context));
            AV21OrganisationSettingFontSize_Description = cgiGet( edtavOrganisationsettingfontsize_description_Internalname);
            AssignAttri(sPrefix, false, "AV21OrganisationSettingFontSize_Description", AV21OrganisationSettingFontSize_Description);
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
            A103OrganisationSettingBaseColor = cgiGet( edtOrganisationSettingBaseColor_Internalname);
            AssignAttri(sPrefix, false, "A103OrganisationSettingBaseColor", A103OrganisationSettingBaseColor);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Trn_OrganisationSettingGeneral");
            AV14OrganisationSettingLanguage_Description = cgiGet( edtavOrganisationsettinglanguage_description_Internalname);
            AssignAttri(sPrefix, false, "AV14OrganisationSettingLanguage_Description", AV14OrganisationSettingLanguage_Description);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONSETTINGLANGUAGE_DESCRIPTION", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV14OrganisationSettingLanguage_Description, "")), context));
            forbiddenHiddens.Add("OrganisationSettingLanguage_Description", StringUtil.RTrim( context.localUtil.Format( AV14OrganisationSettingLanguage_Description, "")));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("trn_organisationsettinggeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E11462 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11462( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12462( )
      {
         /* Load Routine */
         returnInSub = false;
         AV19ComboSelectedItems = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV19ComboSelectedItems.FromJSonString(A105OrganisationSettingLanguage, null);
         AV24GXV1 = 1;
         while ( AV24GXV1 <= AV19ComboSelectedItems.Count )
         {
            AV20ComboSelectedItem = ((string)AV19ComboSelectedItems.Item(AV24GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14OrganisationSettingLanguage_Description)) )
            {
               AV14OrganisationSettingLanguage_Description += ", ";
               AssignAttri(sPrefix, false, "AV14OrganisationSettingLanguage_Description", AV14OrganisationSettingLanguage_Description);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONSETTINGLANGUAGE_DESCRIPTION", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV14OrganisationSettingLanguage_Description, "")), context));
            }
            if ( StringUtil.StrCmp(AV20ComboSelectedItem, "English") == 0 )
            {
               AV14OrganisationSettingLanguage_Description += context.GetMessage( "English", "");
               AssignAttri(sPrefix, false, "AV14OrganisationSettingLanguage_Description", AV14OrganisationSettingLanguage_Description);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONSETTINGLANGUAGE_DESCRIPTION", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV14OrganisationSettingLanguage_Description, "")), context));
            }
            else if ( StringUtil.StrCmp(AV20ComboSelectedItem, "Dutch") == 0 )
            {
               AV14OrganisationSettingLanguage_Description += context.GetMessage( "Dutch", "");
               AssignAttri(sPrefix, false, "AV14OrganisationSettingLanguage_Description", AV14OrganisationSettingLanguage_Description);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONSETTINGLANGUAGE_DESCRIPTION", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV14OrganisationSettingLanguage_Description, "")), context));
            }
            else if ( StringUtil.StrCmp(AV20ComboSelectedItem, "Spanish") == 0 )
            {
               AV14OrganisationSettingLanguage_Description += context.GetMessage( "Spanish", "");
               AssignAttri(sPrefix, false, "AV14OrganisationSettingLanguage_Description", AV14OrganisationSettingLanguage_Description);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vORGANISATIONSETTINGLANGUAGE_DESCRIPTION", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV14OrganisationSettingLanguage_Description, "")), context));
            }
            AV24GXV1 = (int)(AV24GXV1+1);
         }
         if ( StringUtil.StrCmp(A104OrganisationSettingFontSize, "Small") == 0 )
         {
            AV21OrganisationSettingFontSize_Description = context.GetMessage( "Small", "");
            AssignAttri(sPrefix, false, "AV21OrganisationSettingFontSize_Description", AV21OrganisationSettingFontSize_Description);
         }
         else if ( StringUtil.StrCmp(A104OrganisationSettingFontSize, "Medium") == 0 )
         {
            AV21OrganisationSettingFontSize_Description = context.GetMessage( "Medium", "");
            AssignAttri(sPrefix, false, "AV21OrganisationSettingFontSize_Description", AV21OrganisationSettingFontSize_Description);
         }
         else if ( StringUtil.StrCmp(A104OrganisationSettingFontSize, "Large") == 0 )
         {
            AV21OrganisationSettingFontSize_Description = context.GetMessage( "Large", "");
            AssignAttri(sPrefix, false, "AV21OrganisationSettingFontSize_Description", AV21OrganisationSettingFontSize_Description);
         }
         edtOrganisationId_Visible = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         edtOrganisationSettingid_Visible = 0;
         AssignProp(sPrefix, false, edtOrganisationSettingid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingid_Visible), 5, 0), true);
         edtOrganisationSettingBaseColor_Visible = 0;
         AssignProp(sPrefix, false, edtOrganisationSettingBaseColor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationSettingBaseColor_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_organisationsetting_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_organisationsetting_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13462( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         if ( AV12IsAuthorized_Update )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_organisationsetting.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A100OrganisationSettingid.ToString());
            CallWebObject(formatLink("trn_organisationsetting.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E14462( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         if ( AV13IsAuthorized_Delete )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "trn_organisationsetting.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A100OrganisationSettingid.ToString());
            CallWebObject(formatLink("trn_organisationsetting.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV25Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_OrganisationSetting";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A100OrganisationSettingid = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
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
         PA462( ) ;
         WS462( ) ;
         WE462( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SESSION ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA100OrganisationSettingid = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA462( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_organisationsettinggeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA462( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A100OrganisationSettingid = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
         }
         wcpOA100OrganisationSettingid = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA100OrganisationSettingid"));
         if ( ! GetJustCreated( ) && ( ( A100OrganisationSettingid != wcpOA100OrganisationSettingid ) ) )
         {
            setjustcreated();
         }
         wcpOA100OrganisationSettingid = A100OrganisationSettingid;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA100OrganisationSettingid = cgiGet( sPrefix+"A100OrganisationSettingid_CTRL");
         if ( StringUtil.Len( sCtrlA100OrganisationSettingid) > 0 )
         {
            A100OrganisationSettingid = StringUtil.StrToGuid( cgiGet( sCtrlA100OrganisationSettingid));
            AssignAttri(sPrefix, false, "A100OrganisationSettingid", A100OrganisationSettingid.ToString());
         }
         else
         {
            A100OrganisationSettingid = StringUtil.StrToGuid( cgiGet( sPrefix+"A100OrganisationSettingid_PARM"));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA462( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS462( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS462( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A100OrganisationSettingid_PARM", A100OrganisationSettingid.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA100OrganisationSettingid)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A100OrganisationSettingid_CTRL", StringUtil.RTrim( sCtrlA100OrganisationSettingid));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE462( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241028526687", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("trn_organisationsettinggeneral.js", "?20241028526688", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgOrganisationSettingLogo_Internalname = sPrefix+"ORGANISATIONSETTINGLOGO";
         imgOrganisationSettingFavicon_Internalname = sPrefix+"ORGANISATIONSETTINGFAVICON";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         edtavOrganisationsettinglanguage_description_Internalname = sPrefix+"vORGANISATIONSETTINGLANGUAGE_DESCRIPTION";
         edtavOrganisationsettingfontsize_description_Internalname = sPrefix+"vORGANISATIONSETTINGFONTSIZE_DESCRIPTION";
         lblTransactiondetail_basecolor_Internalname = sPrefix+"TRANSACTIONDETAIL_BASECOLOR";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID";
         edtOrganisationSettingid_Internalname = sPrefix+"ORGANISATIONSETTINGID";
         edtOrganisationSettingBaseColor_Internalname = sPrefix+"ORGANISATIONSETTINGBASECOLOR";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtOrganisationSettingBaseColor_Enabled = 0;
         edtOrganisationSettingid_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         imgOrganisationSettingFavicon_Enabled = 0;
         imgOrganisationSettingLogo_Enabled = 0;
         edtOrganisationSettingBaseColor_Jsonclick = "";
         edtOrganisationSettingBaseColor_Visible = 1;
         edtOrganisationSettingid_Jsonclick = "";
         edtOrganisationSettingid_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtavOrganisationsettingfontsize_description_Jsonclick = "";
         edtavOrganisationsettingfontsize_description_Enabled = 1;
         edtavOrganisationsettinglanguage_description_Jsonclick = "";
         edtavOrganisationsettinglanguage_description_Enabled = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A100OrganisationSettingid","fld":"ORGANISATIONSETTINGID"},{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV14OrganisationSettingLanguage_Description","fld":"vORGANISATIONSETTINGLANGUAGE_DESCRIPTION","hsh":true}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E13462","iparms":[{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A100OrganisationSettingid","fld":"ORGANISATIONSETTINGID"}]""");
         setEventMetadata("'DOUPDATE'",""","oparms":[{"ctrl":"BTNUPDATE","prop":"Visible"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E14462","iparms":[{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"A100OrganisationSettingid","fld":"ORGANISATIONSETTINGID"}]""");
         setEventMetadata("'DODELETE'",""","oparms":[{"ctrl":"BTNDELETE","prop":"Visible"}]}""");
         setEventMetadata("VALID_ORGANISATIONSETTINGID","""{"handler":"Valid_Organisationsettingid","iparms":[]}""");
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
         wcpOA100OrganisationSettingid = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV25Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV14OrganisationSettingLanguage_Description = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         A101OrganisationSettingLogo = "";
         A40000OrganisationSettingLogo_GXI = "";
         sImgUrl = "";
         A102OrganisationSettingFavicon = "";
         A40001OrganisationSettingFavicon_GXI = "";
         TempTags = "";
         AV21OrganisationSettingFontSize_Description = "";
         lblTransactiondetail_basecolor_Jsonclick = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A11OrganisationId = Guid.Empty;
         A103OrganisationSettingBaseColor = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00462_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         H00462_A105OrganisationSettingLanguage = new string[] {""} ;
         H00462_A104OrganisationSettingFontSize = new string[] {""} ;
         H00462_A103OrganisationSettingBaseColor = new string[] {""} ;
         H00462_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00462_A40001OrganisationSettingFavicon_GXI = new string[] {""} ;
         H00462_A40000OrganisationSettingLogo_GXI = new string[] {""} ;
         H00462_A102OrganisationSettingFavicon = new string[] {""} ;
         H00462_A101OrganisationSettingLogo = new string[] {""} ;
         A105OrganisationSettingLanguage = "";
         A104OrganisationSettingFontSize = "";
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV19ComboSelectedItems = new GxSimpleCollection<string>();
         AV20ComboSelectedItem = "";
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA100OrganisationSettingid = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationsettinggeneral__default(),
            new Object[][] {
                new Object[] {
               H00462_A100OrganisationSettingid, H00462_A105OrganisationSettingLanguage, H00462_A104OrganisationSettingFontSize, H00462_A103OrganisationSettingBaseColor, H00462_A11OrganisationId, H00462_A40001OrganisationSettingFavicon_GXI, H00462_A40000OrganisationSettingLogo_GXI, H00462_A102OrganisationSettingFavicon, H00462_A101OrganisationSettingLogo
               }
            }
         );
         AV25Pgmname = "Trn_OrganisationSettingGeneral";
         /* GeneXus formulas. */
         AV25Pgmname = "Trn_OrganisationSettingGeneral";
         edtavOrganisationsettinglanguage_description_Enabled = 0;
         edtavOrganisationsettingfontsize_description_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavOrganisationsettinglanguage_description_Enabled ;
      private int edtavOrganisationsettingfontsize_description_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtOrganisationId_Visible ;
      private int edtOrganisationSettingid_Visible ;
      private int edtOrganisationSettingBaseColor_Visible ;
      private int imgOrganisationSettingLogo_Enabled ;
      private int imgOrganisationSettingFavicon_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtOrganisationSettingid_Enabled ;
      private int edtOrganisationSettingBaseColor_Enabled ;
      private int AV24GXV1 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV25Pgmname ;
      private string edtavOrganisationsettinglanguage_description_Internalname ;
      private string edtavOrganisationsettingfontsize_description_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string imgOrganisationSettingLogo_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgOrganisationSettingFavicon_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string TempTags ;
      private string edtavOrganisationsettinglanguage_description_Jsonclick ;
      private string edtavOrganisationsettingfontsize_description_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string lblTransactiondetail_basecolor_Internalname ;
      private string lblTransactiondetail_basecolor_Jsonclick ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtOrganisationSettingid_Internalname ;
      private string edtOrganisationSettingid_Jsonclick ;
      private string edtOrganisationSettingBaseColor_Internalname ;
      private string edtOrganisationSettingBaseColor_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string hsh ;
      private string sCtrlA100OrganisationSettingid ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool A101OrganisationSettingLogo_IsBlob ;
      private bool A102OrganisationSettingFavicon_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A105OrganisationSettingLanguage ;
      private string AV14OrganisationSettingLanguage_Description ;
      private string A40000OrganisationSettingLogo_GXI ;
      private string A40001OrganisationSettingFavicon_GXI ;
      private string AV21OrganisationSettingFontSize_Description ;
      private string A103OrganisationSettingBaseColor ;
      private string A104OrganisationSettingFontSize ;
      private string AV20ComboSelectedItem ;
      private string A101OrganisationSettingLogo ;
      private string A102OrganisationSettingFavicon ;
      private Guid A100OrganisationSettingid ;
      private Guid wcpOA100OrganisationSettingid ;
      private Guid A11OrganisationId ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00462_A100OrganisationSettingid ;
      private string[] H00462_A105OrganisationSettingLanguage ;
      private string[] H00462_A104OrganisationSettingFontSize ;
      private string[] H00462_A103OrganisationSettingBaseColor ;
      private Guid[] H00462_A11OrganisationId ;
      private string[] H00462_A40001OrganisationSettingFavicon_GXI ;
      private string[] H00462_A40000OrganisationSettingLogo_GXI ;
      private string[] H00462_A102OrganisationSettingFavicon ;
      private string[] H00462_A101OrganisationSettingLogo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GxSimpleCollection<string> AV19ComboSelectedItems ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_organisationsettinggeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00462;
          prmH00462 = new Object[] {
          new ParDef("OrganisationSettingid",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00462", "SELECT OrganisationSettingid, OrganisationSettingLanguage, OrganisationSettingFontSize, OrganisationSettingBaseColor, OrganisationId, OrganisationSettingFavicon_GXI, OrganisationSettingLogo_GXI, OrganisationSettingFavicon, OrganisationSettingLogo FROM Trn_OrganisationSetting WHERE OrganisationSettingid = :OrganisationSettingid ORDER BY OrganisationSettingid ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00462,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(6));
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(7));
                return;
       }
    }

 }

}
