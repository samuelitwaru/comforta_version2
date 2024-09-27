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
   public class trn_receptionistgeneral : GXWebComponent
   {
      public trn_receptionistgeneral( )
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

      public trn_receptionistgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ReceptionistId ,
                           Guid aP1_OrganisationId ,
                           Guid aP2_LocationId )
      {
         this.A89ReceptionistId = aP0_ReceptionistId;
         this.A11OrganisationId = aP1_OrganisationId;
         this.A29LocationId = aP2_LocationId;
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
         dynLocationId = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ReceptionistId");
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
                  A89ReceptionistId = StringUtil.StrToGuid( GetPar( "ReceptionistId"));
                  AssignAttri(sPrefix, false, "A89ReceptionistId", A89ReceptionistId.ToString());
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
                  A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                  AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A89ReceptionistId,(Guid)A11OrganisationId,(Guid)A29LocationId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"LOCATIONID") == 0 )
               {
                  A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                  AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLALOCATIONID502( A11OrganisationId) ;
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
                  gxfirstwebparm = GetFirstPar( "ReceptionistId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ReceptionistId");
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
            PA502( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV15Pgmname = "Trn_ReceptionistGeneral";
               GXALOCATIONID_html502( A11OrganisationId) ;
               WS502( ) ;
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
            context.SendWebValue( "Trn_Receptionist General") ;
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
            GXEncryptionTmp = "trn_receptionistgeneral.aspx"+UrlEncode(A89ReceptionistId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(A29LocationId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_receptionistgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA89ReceptionistId", wcpOA89ReceptionistId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA11OrganisationId", wcpOA11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA29LocationId", wcpOA29LocationId.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm502( )
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
         return "Trn_ReceptionistGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Trn_Receptionist General" ;
      }

      protected void WB500( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "trn_receptionistgeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynLocationId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynLocationId_Internalname, "Location", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynLocationId, dynLocationId_Internalname, A29LocationId.ToString(), 1, dynLocationId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "guid", "", 1, dynLocationId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "", true, 0, "HLP_Trn_ReceptionistGeneral.htm");
            dynLocationId.CurrentValue = A29LocationId.ToString();
            AssignProp(sPrefix, false, dynLocationId_Internalname, "Values", (string)(dynLocationId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistGivenName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtReceptionistGivenName_Internalname, "Given Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtReceptionistGivenName_Internalname, A90ReceptionistGivenName, StringUtil.RTrim( context.localUtil.Format( A90ReceptionistGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistGivenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReceptionistGivenName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ReceptionistGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistLastName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtReceptionistLastName_Internalname, "Last Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtReceptionistLastName_Internalname, A91ReceptionistLastName, StringUtil.RTrim( context.localUtil.Format( A91ReceptionistLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReceptionistLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_ReceptionistGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtReceptionistEmail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtReceptionistEmail_Internalname, A93ReceptionistEmail, StringUtil.RTrim( context.localUtil.Format( A93ReceptionistEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A93ReceptionistEmail, "", "", "", edtReceptionistEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReceptionistEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Trn_ReceptionistGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReceptionistPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtReceptionistPhone_Internalname, "Phone", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A94ReceptionistPhone);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtReceptionistPhone_Internalname, StringUtil.RTrim( A94ReceptionistPhone), StringUtil.RTrim( context.localUtil.Format( A94ReceptionistPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtReceptionistPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReceptionistPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Trn_ReceptionistGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 5, "Update", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ReceptionistGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ReceptionistGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtReceptionistId_Internalname, A89ReceptionistId.ToString(), A89ReceptionistId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistId_Jsonclick, 0, "Attribute", "", "", "", "", edtReceptionistId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ReceptionistGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_ReceptionistGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtReceptionistInitials_Internalname, StringUtil.RTrim( A92ReceptionistInitials), StringUtil.RTrim( context.localUtil.Format( A92ReceptionistInitials, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistInitials_Jsonclick, 0, "Attribute", "", "", "", "", edtReceptionistInitials_Visible, 0, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_ReceptionistGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtReceptionistGAMGUID_Internalname, A95ReceptionistGAMGUID, StringUtil.RTrim( context.localUtil.Format( A95ReceptionistGAMGUID, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReceptionistGAMGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtReceptionistGAMGUID_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Trn_ReceptionistGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START502( )
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
            Form.Meta.addItem("description", "Trn_Receptionist General", 0) ;
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
               STRUP500( ) ;
            }
         }
      }

      protected void WS502( )
      {
         START502( ) ;
         EVT502( ) ;
      }

      protected void EVT502( )
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
                                 STRUP500( ) ;
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
                                 STRUP500( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11502 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP500( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12502 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP500( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13502 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP500( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14502 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP500( ) ;
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
                                 STRUP500( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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

      protected void WE502( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm502( ) ;
            }
         }
      }

      protected void PA502( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "trn_receptionistgeneral.aspx")), "trn_receptionistgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "trn_receptionistgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ReceptionistId");
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLALOCATIONID502( Guid A11OrganisationId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLALOCATIONID_data502( A11OrganisationId) ;
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

      protected void GXALOCATIONID_html502( Guid A11OrganisationId )
      {
         Guid gxdynajaxvalue;
         GXDLALOCATIONID_data502( A11OrganisationId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynLocationId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynLocationId.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
      }

      protected void GXDLALOCATIONID_data502( Guid A11OrganisationId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00502 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( A11OrganisationId == new prc_getuserorganisationid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(H00502_A29LocationId[0].ToString());
               gxdynajaxctrldescr.Add(H00502_A31LocationName[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXALOCATIONID_html502( A11OrganisationId) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
            AssignProp(sPrefix, false, dynLocationId_Internalname, "Values", dynLocationId.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF502( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV15Pgmname = "Trn_ReceptionistGeneral";
      }

      protected void RF502( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00503 */
            pr_default.execute(1, new Object[] {A89ReceptionistId, A11OrganisationId, A29LocationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A95ReceptionistGAMGUID = H00503_A95ReceptionistGAMGUID[0];
               AssignAttri(sPrefix, false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
               A92ReceptionistInitials = H00503_A92ReceptionistInitials[0];
               AssignAttri(sPrefix, false, "A92ReceptionistInitials", A92ReceptionistInitials);
               A94ReceptionistPhone = H00503_A94ReceptionistPhone[0];
               AssignAttri(sPrefix, false, "A94ReceptionistPhone", A94ReceptionistPhone);
               A93ReceptionistEmail = H00503_A93ReceptionistEmail[0];
               AssignAttri(sPrefix, false, "A93ReceptionistEmail", A93ReceptionistEmail);
               A91ReceptionistLastName = H00503_A91ReceptionistLastName[0];
               AssignAttri(sPrefix, false, "A91ReceptionistLastName", A91ReceptionistLastName);
               A90ReceptionistGivenName = H00503_A90ReceptionistGivenName[0];
               AssignAttri(sPrefix, false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
               GXALOCATIONID_html502( A11OrganisationId) ;
               /* Execute user event: Load */
               E12502 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB500( ) ;
         }
      }

      protected void send_integrity_lvl_hashes502( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV15Pgmname = "Trn_ReceptionistGeneral";
         GXALOCATIONID_html502( A11OrganisationId) ;
         dynLocationId.Enabled = 0;
         AssignProp(sPrefix, false, dynLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLocationId.Enabled), 5, 0), true);
         edtReceptionistGivenName_Enabled = 0;
         AssignProp(sPrefix, false, edtReceptionistGivenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistGivenName_Enabled), 5, 0), true);
         edtReceptionistLastName_Enabled = 0;
         AssignProp(sPrefix, false, edtReceptionistLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistLastName_Enabled), 5, 0), true);
         edtReceptionistEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtReceptionistEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistEmail_Enabled), 5, 0), true);
         edtReceptionistPhone_Enabled = 0;
         AssignProp(sPrefix, false, edtReceptionistPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistPhone_Enabled), 5, 0), true);
         edtReceptionistId_Enabled = 0;
         AssignProp(sPrefix, false, edtReceptionistId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         edtReceptionistInitials_Enabled = 0;
         AssignProp(sPrefix, false, edtReceptionistInitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistInitials_Enabled), 5, 0), true);
         edtReceptionistGAMGUID_Enabled = 0;
         AssignProp(sPrefix, false, edtReceptionistGAMGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReceptionistGAMGUID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP500( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11502 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA89ReceptionistId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA89ReceptionistId"));
            wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
            wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
            /* Read variables values. */
            A90ReceptionistGivenName = cgiGet( edtReceptionistGivenName_Internalname);
            AssignAttri(sPrefix, false, "A90ReceptionistGivenName", A90ReceptionistGivenName);
            A91ReceptionistLastName = cgiGet( edtReceptionistLastName_Internalname);
            AssignAttri(sPrefix, false, "A91ReceptionistLastName", A91ReceptionistLastName);
            A93ReceptionistEmail = cgiGet( edtReceptionistEmail_Internalname);
            AssignAttri(sPrefix, false, "A93ReceptionistEmail", A93ReceptionistEmail);
            A94ReceptionistPhone = cgiGet( edtReceptionistPhone_Internalname);
            AssignAttri(sPrefix, false, "A94ReceptionistPhone", A94ReceptionistPhone);
            A92ReceptionistInitials = cgiGet( edtReceptionistInitials_Internalname);
            AssignAttri(sPrefix, false, "A92ReceptionistInitials", A92ReceptionistInitials);
            A95ReceptionistGAMGUID = cgiGet( edtReceptionistGAMGUID_Internalname);
            AssignAttri(sPrefix, false, "A95ReceptionistGAMGUID", A95ReceptionistGAMGUID);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXALOCATIONID_html502( A11OrganisationId) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11502 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11502( )
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

      protected void E12502( )
      {
         /* Load Routine */
         returnInSub = false;
         edtReceptionistId_Visible = 0;
         AssignProp(sPrefix, false, edtReceptionistId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp(sPrefix, false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         edtReceptionistInitials_Visible = 0;
         AssignProp(sPrefix, false, edtReceptionistInitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistInitials_Visible), 5, 0), true);
         edtReceptionistGAMGUID_Visible = 0;
         AssignProp(sPrefix, false, edtReceptionistGAMGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReceptionistGAMGUID_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13502( )
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
            GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A89ReceptionistId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(A29LocationId.ToString());
            CallWebObject(formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E14502( )
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
            GXEncryptionTmp = "trn_receptionist.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A89ReceptionistId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(A29LocationId.ToString());
            CallWebObject(formatLink("trn_receptionist.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
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
         AV8TrnContext.gxTpr_Callerobject = AV15Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Trn_Receptionist";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A89ReceptionistId = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A89ReceptionistId", A89ReceptionistId.ToString());
         A11OrganisationId = (Guid)getParm(obj,1);
         AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         A29LocationId = (Guid)getParm(obj,2);
         AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
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
         PA502( ) ;
         WS502( ) ;
         WE502( ) ;
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
         sCtrlA89ReceptionistId = (string)((string)getParm(obj,0));
         sCtrlA11OrganisationId = (string)((string)getParm(obj,1));
         sCtrlA29LocationId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA502( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "trn_receptionistgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA502( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A89ReceptionistId = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A89ReceptionistId", A89ReceptionistId.ToString());
            A11OrganisationId = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
            A29LocationId = (Guid)getParm(obj,4);
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
         wcpOA89ReceptionistId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA89ReceptionistId"));
         wcpOA11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA11OrganisationId"));
         wcpOA29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA29LocationId"));
         if ( ! GetJustCreated( ) && ( ( A89ReceptionistId != wcpOA89ReceptionistId ) || ( A11OrganisationId != wcpOA11OrganisationId ) || ( A29LocationId != wcpOA29LocationId ) ) )
         {
            setjustcreated();
         }
         wcpOA89ReceptionistId = A89ReceptionistId;
         wcpOA11OrganisationId = A11OrganisationId;
         wcpOA29LocationId = A29LocationId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA89ReceptionistId = cgiGet( sPrefix+"A89ReceptionistId_CTRL");
         if ( StringUtil.Len( sCtrlA89ReceptionistId) > 0 )
         {
            A89ReceptionistId = StringUtil.StrToGuid( cgiGet( sCtrlA89ReceptionistId));
            AssignAttri(sPrefix, false, "A89ReceptionistId", A89ReceptionistId.ToString());
         }
         else
         {
            A89ReceptionistId = StringUtil.StrToGuid( cgiGet( sPrefix+"A89ReceptionistId_PARM"));
         }
         sCtrlA11OrganisationId = cgiGet( sPrefix+"A11OrganisationId_CTRL");
         if ( StringUtil.Len( sCtrlA11OrganisationId) > 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( sCtrlA11OrganisationId));
            AssignAttri(sPrefix, false, "A11OrganisationId", A11OrganisationId.ToString());
         }
         else
         {
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( sPrefix+"A11OrganisationId_PARM"));
         }
         sCtrlA29LocationId = cgiGet( sPrefix+"A29LocationId_CTRL");
         if ( StringUtil.Len( sCtrlA29LocationId) > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( cgiGet( sCtrlA29LocationId));
            AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         }
         else
         {
            A29LocationId = StringUtil.StrToGuid( cgiGet( sPrefix+"A29LocationId_PARM"));
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
         PA502( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS502( ) ;
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
         WS502( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A89ReceptionistId_PARM", A89ReceptionistId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA89ReceptionistId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A89ReceptionistId_CTRL", StringUtil.RTrim( sCtrlA89ReceptionistId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A11OrganisationId_PARM", A11OrganisationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA11OrganisationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A11OrganisationId_CTRL", StringUtil.RTrim( sCtrlA11OrganisationId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A29LocationId_PARM", A29LocationId.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA29LocationId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A29LocationId_CTRL", StringUtil.RTrim( sCtrlA29LocationId));
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
         WE502( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202492719472582", true, true);
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
         context.AddJavascriptSource("trn_receptionistgeneral.js", "?202492719472582", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynLocationId.Name = "LOCATIONID";
         dynLocationId.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynLocationId_Internalname = sPrefix+"LOCATIONID";
         edtReceptionistGivenName_Internalname = sPrefix+"RECEPTIONISTGIVENNAME";
         edtReceptionistLastName_Internalname = sPrefix+"RECEPTIONISTLASTNAME";
         edtReceptionistEmail_Internalname = sPrefix+"RECEPTIONISTEMAIL";
         edtReceptionistPhone_Internalname = sPrefix+"RECEPTIONISTPHONE";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtReceptionistId_Internalname = sPrefix+"RECEPTIONISTID";
         edtOrganisationId_Internalname = sPrefix+"ORGANISATIONID";
         edtReceptionistInitials_Internalname = sPrefix+"RECEPTIONISTINITIALS";
         edtReceptionistGAMGUID_Internalname = sPrefix+"RECEPTIONISTGAMGUID";
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
         edtReceptionistGAMGUID_Enabled = 0;
         edtReceptionistInitials_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtReceptionistId_Enabled = 0;
         edtReceptionistGAMGUID_Jsonclick = "";
         edtReceptionistGAMGUID_Visible = 1;
         edtReceptionistInitials_Jsonclick = "";
         edtReceptionistInitials_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Visible = 1;
         edtReceptionistId_Jsonclick = "";
         edtReceptionistId_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtReceptionistPhone_Jsonclick = "";
         edtReceptionistPhone_Enabled = 0;
         edtReceptionistEmail_Jsonclick = "";
         edtReceptionistEmail_Enabled = 0;
         edtReceptionistLastName_Jsonclick = "";
         edtReceptionistLastName_Enabled = 0;
         edtReceptionistGivenName_Jsonclick = "";
         edtReceptionistGivenName_Enabled = 0;
         dynLocationId_Jsonclick = "";
         dynLocationId.Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public void Valid_Organisationid( )
      {
         A29LocationId = StringUtil.StrToGuid( dynLocationId.CurrentValue);
         GXALOCATIONID_html502( A11OrganisationId) ;
         dynload_actions( ) ;
         if ( dynLocationId.ItemCount > 0 )
         {
            A29LocationId = StringUtil.StrToGuid( dynLocationId.getValidValue(A29LocationId.ToString()));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLocationId.CurrentValue = A29LocationId.ToString();
         }
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A29LocationId", A29LocationId.ToString());
         dynLocationId.CurrentValue = A29LocationId.ToString();
         AssignProp(sPrefix, false, dynLocationId_Internalname, "Values", dynLocationId.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E13502","iparms":[{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("'DOUPDATE'",""","oparms":[{"ctrl":"BTNUPDATE","prop":"Visible"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E14502","iparms":[{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"A89ReceptionistId","fld":"RECEPTIONISTID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("'DODELETE'",""","oparms":[{"ctrl":"BTNDELETE","prop":"Visible"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[]}""");
         setEventMetadata("VALID_RECEPTIONISTID","""{"handler":"Valid_Receptionistid","iparms":[]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"dynLocationId"},{"av":"A29LocationId","fld":"LOCATIONID"}]}""");
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
         wcpOA89ReceptionistId = Guid.Empty;
         wcpOA11OrganisationId = Guid.Empty;
         wcpOA29LocationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         A90ReceptionistGivenName = "";
         A91ReceptionistLastName = "";
         A93ReceptionistEmail = "";
         gxphoneLink = "";
         A94ReceptionistPhone = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A92ReceptionistInitials = "";
         A95ReceptionistGAMGUID = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00502_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00502_A29LocationId = new Guid[] {Guid.Empty} ;
         H00502_A31LocationName = new string[] {""} ;
         H00503_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         H00503_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00503_A29LocationId = new Guid[] {Guid.Empty} ;
         H00503_A95ReceptionistGAMGUID = new string[] {""} ;
         H00503_A92ReceptionistInitials = new string[] {""} ;
         H00503_A94ReceptionistPhone = new string[] {""} ;
         H00503_A93ReceptionistEmail = new string[] {""} ;
         H00503_A91ReceptionistLastName = new string[] {""} ;
         H00503_A90ReceptionistGivenName = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA89ReceptionistId = "";
         sCtrlA11OrganisationId = "";
         sCtrlA29LocationId = "";
         Z29LocationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_receptionistgeneral__default(),
            new Object[][] {
                new Object[] {
               H00502_A11OrganisationId, H00502_A29LocationId, H00502_A31LocationName
               }
               , new Object[] {
               H00503_A89ReceptionistId, H00503_A11OrganisationId, H00503_A29LocationId, H00503_A95ReceptionistGAMGUID, H00503_A92ReceptionistInitials, H00503_A94ReceptionistPhone, H00503_A93ReceptionistEmail, H00503_A91ReceptionistLastName, H00503_A90ReceptionistGivenName
               }
            }
         );
         AV15Pgmname = "Trn_ReceptionistGeneral";
         /* GeneXus formulas. */
         AV15Pgmname = "Trn_ReceptionistGeneral";
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
      private int edtReceptionistGivenName_Enabled ;
      private int edtReceptionistLastName_Enabled ;
      private int edtReceptionistEmail_Enabled ;
      private int edtReceptionistPhone_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtReceptionistId_Visible ;
      private int edtOrganisationId_Visible ;
      private int edtReceptionistInitials_Visible ;
      private int edtReceptionistGAMGUID_Visible ;
      private int gxdynajaxindex ;
      private int edtReceptionistId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtReceptionistInitials_Enabled ;
      private int edtReceptionistGAMGUID_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV15Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string dynLocationId_Internalname ;
      private string TempTags ;
      private string dynLocationId_Jsonclick ;
      private string edtReceptionistGivenName_Internalname ;
      private string edtReceptionistGivenName_Jsonclick ;
      private string edtReceptionistLastName_Internalname ;
      private string edtReceptionistLastName_Jsonclick ;
      private string edtReceptionistEmail_Internalname ;
      private string edtReceptionistEmail_Jsonclick ;
      private string edtReceptionistPhone_Internalname ;
      private string gxphoneLink ;
      private string A94ReceptionistPhone ;
      private string edtReceptionistPhone_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtReceptionistId_Internalname ;
      private string edtReceptionistId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string edtReceptionistInitials_Internalname ;
      private string A92ReceptionistInitials ;
      private string edtReceptionistInitials_Jsonclick ;
      private string edtReceptionistGAMGUID_Internalname ;
      private string edtReceptionistGAMGUID_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string sCtrlA89ReceptionistId ;
      private string sCtrlA11OrganisationId ;
      private string sCtrlA29LocationId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A90ReceptionistGivenName ;
      private string A91ReceptionistLastName ;
      private string A93ReceptionistEmail ;
      private string A95ReceptionistGAMGUID ;
      private Guid A89ReceptionistId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid wcpOA89ReceptionistId ;
      private Guid wcpOA11OrganisationId ;
      private Guid wcpOA29LocationId ;
      private Guid Z29LocationId ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynLocationId ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00502_A11OrganisationId ;
      private Guid[] H00502_A29LocationId ;
      private string[] H00502_A31LocationName ;
      private Guid[] H00503_A89ReceptionistId ;
      private Guid[] H00503_A11OrganisationId ;
      private Guid[] H00503_A29LocationId ;
      private string[] H00503_A95ReceptionistGAMGUID ;
      private string[] H00503_A92ReceptionistInitials ;
      private string[] H00503_A94ReceptionistPhone ;
      private string[] H00503_A93ReceptionistEmail ;
      private string[] H00503_A91ReceptionistLastName ;
      private string[] H00503_A90ReceptionistGivenName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_receptionistgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH00502;
          prmH00502 = new Object[] {
          };
          Object[] prmH00503;
          prmH00503 = new Object[] {
          new ParDef("ReceptionistId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00502", "SELECT OrganisationId, LocationId, LocationName FROM Trn_Location ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00502,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00503", "SELECT ReceptionistId, OrganisationId, LocationId, ReceptionistGAMGUID, ReceptionistInitials, ReceptionistPhone, ReceptionistEmail, ReceptionistLastName, ReceptionistGivenName FROM Trn_Receptionist WHERE ReceptionistId = :ReceptionistId and OrganisationId = :OrganisationId and LocationId = :LocationId ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00503,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
       }
    }

 }

}
